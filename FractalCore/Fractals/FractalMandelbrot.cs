using FractalCore.Common;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace FractalCore.Fractals
{
    [Serializable]
    public sealed class FractalMandelbrot : AbstractFractal
    {
        public override void Reset()
        {
            CenterX = -0.5d;
            CenterY = 0d;
            SizeArea = 3d;
        }

        public override object Clone()
        {
            return new FractalMandelbrot(SizeArea, CenterX, CenterY) as object;
        }

        public override int[,] GetFractalMatrixOneThread(GenerationSettings generationSettings)
        {
            var fractalMatrix = new int[generationSettings.Resolution.Width, generationSettings.Resolution.Height];

            for (var i = 0; i < generationSettings.Resolution.Width / generationSettings.QualityFactor; i++)
            {
                for (var j = 0; j < generationSettings.Resolution.Height / generationSettings.QualityFactor; j++)
                {
                    Complex z = new Complex();
                    Complex c = new Complex(((CenterX - SizeArea / 2) + i * (SizeArea / (generationSettings.Resolution.Width / generationSettings.QualityFactor))),
                                            ((CenterY - SizeArea / 2) + j * (SizeArea / (generationSettings.Resolution.Height / generationSettings.QualityFactor))));

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

        public override int[,] GetFractalMatrixMultiThread(GenerationSettings generationSettings)
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
                    Complex c = new Complex(((CenterX - SizeArea / 2) + index_i * (SizeArea / (generationSettings.Resolution.Width / generationSettings.QualityFactor))),
                                            ((CenterY - SizeArea / 2) + index_j * (SizeArea / (generationSettings.Resolution.Height / generationSettings.QualityFactor))));

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

        public override int[,] GetFractalMatrixOneThread()
        {
            return GetFractalMatrixOneThread(new GenerationSettings());
        }

        public override int[,] GetFractalMatrixMultiThread()
        {
            return GetFractalMatrixMultiThread(new GenerationSettings());
        }

        public FractalMandelbrot() : base("Mandelbrot")
        {
        }

        public FractalMandelbrot(double sizeArea, double centerX, double centerY) : this()
        {
            SizeArea = sizeArea;
            CenterX = centerX;
            CenterY = centerY;
        }
    }
}
