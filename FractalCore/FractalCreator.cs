using FractalCore.Common;
using FractalCore.Fractals;
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
        private AbstractFractal fractalData; // данные фрактала

        private GenerationSettings generationSettings; // настройки генерации

        private ColorSettings colorSettings; // настройки цветовой схемы

        private int[,] fractalMatrix = null; // матрица фрактала

        private int maxIterations; // максимальное число итераций

        public FractalCreator(AbstractFractal fractalData, GenerationSettings generationSettings, ColorSettings colorSettings)
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
            switch (generationSettings.Algorithm)
            {
                case GenerationAlgorithms.MultiThreadCalculation:
                    {
                        return fractalData.GetFractalMatrixMultiThread(generationSettings);
                    }
                case GenerationAlgorithms.OneThreadCalculation:
                    {
                        return fractalData.GetFractalMatrixOneThread(generationSettings);
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
            switch (colorSettings.Algorithm)
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

    }
}