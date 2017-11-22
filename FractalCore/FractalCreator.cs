using FractalCore.Common;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace FractalCore
{
    public class FractalCreator // класс для создания изображений фракталов
    {
        private FractalData fractalData; // данные фрактала
        private GenerationSettings generationSettings; // настройки генерации
        private ColorSettings colorSettings; // настройки цветовой схемы
        private int[,] fractalMatrix = null; // матрица фрактала
        private int maxIterations; // максимальное число итераций

        public FractalCreator(FractalData fractalData, GenerationSettings generationSettings, ColorSettings colorSettings)
        {
            this.fractalData = fractalData;
            this.generationSettings = generationSettings;
            this.colorSettings = colorSettings;
            maxIterations = generationSettings.IterationCount;
        }

        // ======================================================================================================================

        // метод создает изображение фрактала согласно всем параметрам
        public Bitmap Create()
        {
            fractalMatrix = GetFractalMatrix();
            return GetFractalBitmap(fractalMatrix);
        }

        // метод перерисовывает изображение фрактала на основе уже созданной матрицы
        public Bitmap ReDraw()
        {
            if (fractalMatrix != null)
            {
                if (maxIterations != generationSettings.IterationCount)
                {
                    maxIterations = generationSettings.IterationCount;
                    return Create();
                }
                else
                {
                    return GetFractalBitmap(fractalMatrix);
                }
            }
            else
            {
                return null;
            }
        }

        // асинхронный метод Create()
        public Task<Bitmap> CreateAsync()
        {
            return Task.Run(() =>
            {
                return Create();
            });
        }

        // асинхронный метод ReDraw()
        public Task<Bitmap> ReDrawAsync()
        {
            return Task.Run(() =>
            {
                return ReDraw();
            });
        }

        // асинхронный метод SaveImage()
        public Task SaveImageAsync(Size resolution, string fileName)
        {
            return Task.Run(() =>
            {
                var genSettings = generationSettings.Clone() as GenerationSettings;

                genSettings.Resolution = resolution;

                var creator = new FractalCreator(fractalData, genSettings, colorSettings);

                creator.Create().Save(fileName);
            });
        }

        // метод возвращает координату X относительно системы координат фрактала
        public double PositionXFractalCoord(int coordBase)
        {
            return (fractalData.CenterX - fractalData.SizeArea / 2) + (coordBase / generationSettings.QualityFactor) * (fractalData.SizeArea / (generationSettings.Resolution.Width / generationSettings.QualityFactor));
        }

        // метод возвращает координату Y относительно системы координат фрактала
        public double PositionYFractalCoord(int coordBase)
        {
            return (fractalData.CenterY - fractalData.SizeArea / 2) + (coordBase / generationSettings.QualityFactor) * (fractalData.SizeArea / (generationSettings.Resolution.Height / generationSettings.QualityFactor));
        }

        // метод сохраняет изображение в формате BMP
        public void SaveImage(Size resolution, string fileName)
        {
            var genSettings = generationSettings.Clone() as GenerationSettings;

            genSettings.Resolution = resolution;

            var creator = new FractalCreator(fractalData, genSettings, colorSettings);

            creator.Create().Save(fileName);
        }

        // метод сериализует объект FractalData
        public void SaveFractalInfo(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, fractalData);
            }
        }

        // ======================================================================================================================

        // метод, возвращающий матрицу с учетом типа фрактала и алгоритма расчета
        private int[,] GetFractalMatrix()
        {
            switch(generationSettings.Algorithm)
            {
                case GenerationAlgorithms.MultiThreadCalculation:
                    {
                        switch(fractalData.FractalType)
                        {
                            case FractalEnumType.Mandelbrot:
                                {
                                    return GetFractalMatrixMandelbrotMultiThread();
                                }
                            case FractalEnumType.Julia:
                                {
                                    return GetFractalMatrixJuliaMultiThread();
                                }
                            case FractalEnumType.Lambda:
                                {
                                    return GetFractalMatrixLambdaMultiThread();
                                }
                            default:
                                {
                                    throw new NotImplementedException();
                                }
                        }
                    }
                case GenerationAlgorithms.OneThreadCalculation:
                    {
                        switch (fractalData.FractalType)
                        {
                            case FractalEnumType.Mandelbrot:
                                {
                                    return GetFractalMatrixMandelbrotOneThread();
                                }
                            case FractalEnumType.Julia:
                                {
                                    return GetFractalMatrixJuliaOneThread();
                                }
                            case FractalEnumType.Lambda:
                                {
                                    return GetFractalMatrixLambdaOneThread();
                                }
                            default:
                                {
                                    throw new NotImplementedException();
                                }
                        }
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        // метод, возвращающий изображение фрактала
        private Bitmap GetFractalBitmap(int[,] fractalMatrix)
        {
            switch(colorSettings.Algorithm)
            {
                case ColorAlgorithms.EscapeTimeAlgorithm:
                    {
                        return EscapeTimeAlgorithm(fractalMatrix);
                    }
                case ColorAlgorithms.NormalizedIterationCountAlgorithm:
                    {
                        return NormalizedIterationCountAlgorithm(fractalMatrix);
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        #region Методы создания изображения
        // метод, возвращающий изображение фрактала с учетом алгоритма и цветовой схемы (NormalizedIterationCountAlgorithm)
        private Bitmap NormalizedIterationCountAlgorithm(int[,] fractalMatrix)
        {
            var bmp = new Bitmap(generationSettings.Resolution.Width / generationSettings.QualityFactor, generationSettings.Resolution.Height / generationSettings.QualityFactor);
            var fb = new FastBitmap(bmp);
            PixelData pData;

            for(var i = 0; i < generationSettings.Resolution.Width / generationSettings.QualityFactor; i++)
            {
                for(var j = 0; j < generationSettings.Resolution.Height / generationSettings.QualityFactor; j++)
                {
                    if (fractalMatrix[i, j] > generationSettings.IterationCount)
                    {
                        pData.R = colorSettings.NotFractalPointsColor.R;
                        pData.G = colorSettings.NotFractalPointsColor.G;
                        pData.B = colorSettings.NotFractalPointsColor.B;
                    }
                    else
                    {
                        double t = fractalMatrix[i, j] / (double)generationSettings.IterationCount;

                        pData.R = (byte)(9 * (1 - t) * t * t * t * colorSettings.R);
                        pData.G = (byte)(15 * (1 - t) * (1 - t) * t * t * colorSettings.G);
                        pData.B = (byte)(8.5 * (1 - t) * (1 - t) * (1 - t) * t * colorSettings.B);
                    }

                    fb.SetPixelData(i, j, pData);
                }
            }
            fb.Dispose();

            return bmp;
        }

        // метод, возвращающий изображение фрактала с учетом алгоритма и цветовой схемы (EscapeTimeAlgorithm)
        private Bitmap EscapeTimeAlgorithm(int[,] fractalMatrix)
        {
            var bmp = new Bitmap(generationSettings.Resolution.Width / generationSettings.QualityFactor, generationSettings.Resolution.Height / generationSettings.QualityFactor);
            var fb = new FastBitmap(bmp);
            PixelData pData;

            for (var i = 0; i < generationSettings.Resolution.Width / generationSettings.QualityFactor; i++)
            {
                for (var j = 0; j < generationSettings.Resolution.Height / generationSettings.QualityFactor; j++)
                {
                    if (fractalMatrix[i, j] > generationSettings.IterationCount)
                    {
                        pData.R = colorSettings.NotFractalPointsColor.R;
                        pData.G = colorSettings.NotFractalPointsColor.G;
                        pData.B = colorSettings.NotFractalPointsColor.B;
                    }
                    else
                    {
                        pData.B = (byte)((fractalMatrix[i, j] * 20) % colorSettings.B);
                        pData.G = (byte)((fractalMatrix[i, j] * 15) % colorSettings.G);
                        pData.R = (byte)((fractalMatrix[i, j] * 10) % colorSettings.R);
                    }

                    fb.SetPixelData(i, j, pData);
                }
            }
            fb.Dispose();

            return bmp;
        }
        #endregion

        #region Методы однопоточного расчета матриц Фракталов
        // метод, возвращающий матрицу для Лямбда - фрактала (однопоточные расчеты)
        private int[,] GetFractalMatrixLambdaOneThread()
        {
            var fractalMatrix = new int[generationSettings.Resolution.Width, generationSettings.Resolution.Height];

            for (var i = 0; i < generationSettings.Resolution.Width / generationSettings.QualityFactor; i++)
            {
                for (var j = 0; j < generationSettings.Resolution.Height / generationSettings.QualityFactor; j++)
                {
                    Complex z = new Complex(0.5, 0);
                    Complex c = new Complex(((fractalData.CenterX - fractalData.SizeArea / 2) + i * (fractalData.SizeArea / (generationSettings.Resolution.Width / generationSettings.QualityFactor))),
                                            ((fractalData.CenterY - fractalData.SizeArea / 2) + j * (fractalData.SizeArea / (generationSettings.Resolution.Height / generationSettings.QualityFactor))));

                    int k;

                    for (k = 1; k <= generationSettings.IterationCount; k++)
                    {
                        Complex lambda = new Complex(z.Re - Math.Pow(z.Re, 2) + Math.Pow(z.Im, 2), z.Im - 2 * z.Re * z.Im);

                        z = c * lambda;

                        if (z.MagnitudeSq > 4)
                        {
                            break;
                        }
                    }

                    fractalMatrix[i, j] = k;
                }
            }

            return fractalMatrix;
        }

        // метод, возвращающий матрицу для фрактала Жюлиа (однопоточные расчеты)
        private int[,] GetFractalMatrixJuliaOneThread()
        {
            var fractalMatrix = new int[generationSettings.Resolution.Width, generationSettings.Resolution.Height];
            Complex c = new Complex(-0.70176, -0.3842);

            for (var i = 0; i < generationSettings.Resolution.Width / generationSettings.QualityFactor; i++)
            {
                for (var j = 0; j < generationSettings.Resolution.Height / generationSettings.QualityFactor; j++)
                {
                    Complex z = new Complex(((fractalData.CenterX - fractalData.SizeArea / 2) + i * (fractalData.SizeArea / (generationSettings.Resolution.Width / generationSettings.QualityFactor))),
                                            ((fractalData.CenterY - fractalData.SizeArea / 2) + j * (fractalData.SizeArea / (generationSettings.Resolution.Height / generationSettings.QualityFactor))));

                    int k;

                    for (k = 1; k <= generationSettings.IterationCount; k++)
                    {
                        z = z * z + c; //formula

                        if (z.MagnitudeSq > 4)
                        {
                            break;
                        }
                    }

                    fractalMatrix[i, j] = k;
                }
            }

            return fractalMatrix;
        }

        // метод, возвращающий матрицу для фрактала Мандельброта (однопоточные расчеты)
        private int[,] GetFractalMatrixMandelbrotOneThread()
        {
            var fractalMatrix = new int[generationSettings.Resolution.Width, generationSettings.Resolution.Height];

            for(var i = 0; i < generationSettings.Resolution.Width / generationSettings.QualityFactor; i++)
            {
                for(var j = 0; j < generationSettings.Resolution.Height / generationSettings.QualityFactor; j++)
                {
                    Complex z = new Complex();
                    Complex c = new Complex(((fractalData.CenterX - fractalData.SizeArea / 2) + i * (fractalData.SizeArea / (generationSettings.Resolution.Width / generationSettings.QualityFactor))),
                                            ((fractalData.CenterY - fractalData.SizeArea / 2) + j * (fractalData.SizeArea / (generationSettings.Resolution.Height / generationSettings.QualityFactor))));

                    int k;

                    for (k = 1; k <= generationSettings.IterationCount; k++)
                    {
                        z = z * z + c; //formula

                        if (z.MagnitudeSq > 4)
                        {
                            break;
                        }
                    }

                    fractalMatrix[i, j] = k;
                }
            }

            return fractalMatrix;
        }
        #endregion

        #region Методы многопоточного расчета матриц Фракталов
        // метод, возвращающий матрицу для фрактала Мандельброта (многопоточные расчеты)
        private int[,] GetFractalMatrixMandelbrotMultiThread()
        {
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount - 1
            };

            var fractalMatrix = new int[generationSettings.Resolution.Width / generationSettings.QualityFactor, generationSettings.Resolution.Height / generationSettings.QualityFactor];

            Parallel.ForEach(Partitioner.Create(0, ((generationSettings.Resolution.Width / generationSettings.QualityFactor) * (generationSettings.Resolution.Height / generationSettings.QualityFactor))), options, range =>
            {
                for (int index = range.Item1; index < range.Item2; index++)
                {
                    int index_i = index / (generationSettings.Resolution.Width / generationSettings.QualityFactor);
                    int index_j = index % (generationSettings.Resolution.Height / generationSettings.QualityFactor);

                    Complex z = new Complex();
                    Complex c = new Complex(((fractalData.CenterX - fractalData.SizeArea / 2) + index_i * (fractalData.SizeArea / (generationSettings.Resolution.Width / generationSettings.QualityFactor))),
                                            ((fractalData.CenterY - fractalData.SizeArea / 2) + index_j * (fractalData.SizeArea / (generationSettings.Resolution.Height / generationSettings.QualityFactor))));

                    int k;

                    for (k = 1; k <= generationSettings.IterationCount; k++)
                    {
                        z = z * z + c; //formula

                        if (z.MagnitudeSq > 4)
                        {
                            break;
                        }
                    }

                    fractalMatrix[index_i, index_j] = k;
                }
            });

            return fractalMatrix;
        }

        // метод, возвращающий матрицу для фрактала Жюлиа (многопоточные расчеты)
        private int[,] GetFractalMatrixJuliaMultiThread()
        {
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount - 1
            };

            var fractalMatrix = new int[generationSettings.Resolution.Width / generationSettings.QualityFactor, generationSettings.Resolution.Height / generationSettings.QualityFactor];
            Complex c = new Complex(-0.70176, -0.3842);

            Parallel.ForEach(Partitioner.Create(0, ((generationSettings.Resolution.Width / generationSettings.QualityFactor) * (generationSettings.Resolution.Height / generationSettings.QualityFactor))), options, range =>
            {
                for (int index = range.Item1; index < range.Item2; index++)
                {
                    int index_i = index / (generationSettings.Resolution.Width / generationSettings.QualityFactor);
                    int index_j = index % (generationSettings.Resolution.Height / generationSettings.QualityFactor);


                    Complex z = new Complex(((fractalData.CenterX - fractalData.SizeArea / 2) + index_i * (fractalData.SizeArea / (generationSettings.Resolution.Width / generationSettings.QualityFactor))),
                                            ((fractalData.CenterY - fractalData.SizeArea / 2) + index_j * (fractalData.SizeArea / (generationSettings.Resolution.Height / generationSettings.QualityFactor))));

                    int k;

                    for (k = 1; k <= generationSettings.IterationCount; k++)
                    {
                        z = z * z + c;

                        if (z.MagnitudeSq > 4)
                        {
                            break;
                        }
                    }

                    fractalMatrix[index_i, index_j] = k;
                }
            });

            return fractalMatrix;
        }

        // метод, возвращающий матрицу для Лямбда - фрактала (многопоточные расчеты)
        private int[,] GetFractalMatrixLambdaMultiThread()
        {
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount - 1
            };

            var fractalMatrix = new int[generationSettings.Resolution.Width / generationSettings.QualityFactor, generationSettings.Resolution.Height / generationSettings.QualityFactor];

            Parallel.ForEach(Partitioner.Create(0, ((generationSettings.Resolution.Width / generationSettings.QualityFactor) * (generationSettings.Resolution.Height / generationSettings.QualityFactor))), options, range =>
            {
                for (int index = range.Item1; index < range.Item2; index++)
                {
                    int index_i = index / (generationSettings.Resolution.Width / generationSettings.QualityFactor);
                    int index_j = index % (generationSettings.Resolution.Height / generationSettings.QualityFactor);

                    int k;

                    Complex z = new Complex(0.5, 0);
                    Complex c = new Complex(((fractalData.CenterX - fractalData.SizeArea / 2) + index_i * (fractalData.SizeArea / (generationSettings.Resolution.Width / generationSettings.QualityFactor))),
                                            ((fractalData.CenterY - fractalData.SizeArea / 2) + index_j * (fractalData.SizeArea / (generationSettings.Resolution.Height / generationSettings.QualityFactor))));

                    for (k = 1; k <= generationSettings.IterationCount; k++)
                    {
                        Complex lambda = new Complex(z.Re - Math.Pow(z.Re, 2) + Math.Pow(z.Im, 2), z.Im - 2 * z.Re * z.Im);

                        z = c * lambda;

                        if (z.MagnitudeSq > 4)
                        {
                            break;
                        }
                    }

                    fractalMatrix[index_i, index_j] = k;
                }
            });

            return fractalMatrix;
        }
        #endregion
    }
}