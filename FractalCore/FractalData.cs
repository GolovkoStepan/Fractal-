using System;

namespace FractalCore
{
    [Serializable]
    public class FractalData : ICloneable // класс, хранящий данные для расчета фрактала
    {
        private FractalEnumType fractalType;

        public double SizeArea { get; set; } // коэффициент увеличения  
        public double CenterX { get; set; } // координата X центра
        public double CenterY { get; set; } // координата Y центра
        public FractalEnumType FractalType  // тип фрактала
        {
            get
            {
                return fractalType;
            }
            set
            {
                fractalType = value;
                Reset();
            }
        } 

        public FractalData(FractalEnumType fractalType = FractalEnumType.Mandelbrot,
                           double sizeArea = 3, double centerX = -0.5d, double centerY = 0)
        {
            FractalType = fractalType;
            SizeArea = sizeArea;
            CenterX = centerX;
            CenterY = centerY;
        }

        public FractalData(FractalEnumType fractalType)
        {
            FractalType = fractalType;
            Reset();
        }

        public void ZoomPlus() // увеличение изображения
        {
            SizeArea /= 3;
        }

        public void ZoomMinus() // уменьшение изображения
        {
            SizeArea *= 3;
        }

        public void Reset() // метод сброса значений параметров по умолчанию
        {
            switch (FractalType)
            {
                case FractalEnumType.Mandelbrot:
                    {
                        CenterX = -0.5d;
                        CenterY = 0d;
                        SizeArea = 3d;
                        break;
                    }
                case FractalEnumType.Julia:
                    {
                        SizeArea = 5d;
                        CenterX = 0.00476190476190441d;
                        CenterY = -0.0166666666666666d;
                        break;
                    }
                case FractalEnumType.Lambda:
                    {
                        CenterX = 1.05142857142857d;
                        CenterY = -0.0642857142857185d;
                        SizeArea = 7d;
                        break;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        public override string ToString() // переопределение метода ToString()
        {
            return $"Type: {FractalType.ToString()}; X: {CenterX}; Y: {CenterY}; Zoom: {SizeArea};";
        }

        public override bool Equals(object obj) // переопределение метода Equals()
        {
            if (!(obj is FractalData))
            {
                return false;
            }

            var data = obj as FractalData;

            if (this.FractalType == data.FractalType)
            {
                if (this.CenterX == data.CenterX)
                {
                    if (this.CenterY == data.CenterY)
                    {
                        if (this.SizeArea == data.SizeArea)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override int GetHashCode() // переопределение метода GetHashCode()
        {
            var hash = 19;

            hash = hash * 37 + CenterX.GetHashCode();
            hash = hash * 37 + CenterY.GetHashCode();
            hash = hash * 37 + SizeArea.GetHashCode();
            hash = hash * 37 + FractalType.GetHashCode();

            return hash;
        }

        public object Clone() // реализация интерфейса ICloneable
        {
            return new FractalData(this.FractalType, this.SizeArea, this.CenterX, this.CenterY) as object;
        }
    }
}