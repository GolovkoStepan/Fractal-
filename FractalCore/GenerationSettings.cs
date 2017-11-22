using System;
using System.Drawing;

namespace FractalCore
{
    public class GenerationSettings : ICloneable // класс, хранящий данные для генерации изображения
    {
        public Size Resolution { get; set; } // разрешение изображения
        public int IterationCount { get; set; } // максимальное число итераций
        public int QualityFactor { get; set; } // значение качества прорисовки
        public GenerationAlgorithms Algorithm { get; set; } // алгоритм расчета матрицы фрактала

        public GenerationSettings()
        {
            Resolution = new Size(600, 600);
            IterationCount = 500;
            QualityFactor = 1;
            Algorithm = GenerationAlgorithms.OneThreadCalculation;
        }

        public GenerationSettings(
            Size resolution, 
            int iterCount = 500, 
            GenerationAlgorithms algorithm = GenerationAlgorithms.OneThreadCalculation, 
            int qualityFactor = 1)
        {
            Resolution = resolution;
            IterationCount = iterCount;
            QualityFactor = qualityFactor;
            Algorithm = algorithm;
        }

        public object Clone() // реализация интерфейса ICloneable
        {
            return new GenerationSettings(Resolution, IterationCount, Algorithm, QualityFactor);
        }
    }
}

