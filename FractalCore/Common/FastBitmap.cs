using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace FractalCore.Common
{
    internal sealed unsafe class FastBitmap : IDisposable // класс для работы с объектом Bitmap с улучшенной производительностью
    {
        private readonly Bitmap bitmap; // ссылка на Bitmap пользователя
        private int width;
        private BitmapData bitmapData = null;
        private byte* pBase = null;
        private PixelData* pInitPixel = null;
        private Point size; // размер Bitmap пользователя
        private bool locked = false; // логическое свойство, фиксирующее блокировку Bitmap 

        // конструктор, принимающий в качестве параметра ссылку на Bitmap, с последующей блокировкой 
        public FastBitmap(Bitmap bmp)
        {
            bitmap = bmp ?? throw new ArgumentNullException("bitmap");

            size = new Point(bmp.Width, bmp.Height);

            LockBitmap();
        }

        public PixelData* GetInitialPixelForRow(int rowNumber) => (PixelData*)(pBase + rowNumber * width);

        private void InitCurrentPixel() => pInitPixel = (PixelData*)pBase;

        // индексатор, возвращающий указатель на PixelData согласно указанным координатам х и y
        public PixelData* this[int x, int y] => (PixelData*)(pBase + y * width + x * sizeof(PixelData));

        // метод, возвращающий цвет пикселя, согласно координатам
        public Color GetColor(int x, int y)
        {
            PixelData* data = this[x, y];
            return Color.FromArgb(data->R, data->G, data->B);
        }

        // метод, устанавливающий соответствующий цвет пикселю согласно координатам
        public void SetColor(int x, int y, Color c)
        {
            PixelData* data = this[x, y];
            data->R = c.R;
            data->G = c.G;
            data->B = c.B;
        }

        // метод, устанавливающий соответствующий цвет пикселю согласно координатам
        public void SetPixelData(int x, int y, PixelData p)
        {
            PixelData* data = this[x, y];
            data->R = p.R;
            data->G = p.G;
            data->B = p.B;
        }

        // метод, блокирующий Bitmap в системной памяти 
        private void LockBitmap()
        {
            if (locked)
            {
                throw new InvalidOperationException("Already locked");
            }

            var bounds = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            width = bounds.Width * sizeof(PixelData);

            if (width % 4 != 0)
            {
                width = 4 * (width / 4 + 1);
            }

            bitmapData = bitmap.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            pBase = (byte*)bitmapData.Scan0.ToPointer();
            locked = true;
        }

        // метод, разблокирующий Bitmap из системной памяти
        private void UnlockBitmap()
        {
            if (!locked)
            {
                throw new InvalidOperationException("Not currently locked");
            }

            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pBase = null;
            locked = false;
        }

        // реализация интерфейса IDisposable
        public void Dispose()
        {
            if (locked)
            {
                UnlockBitmap();
            }
        }
    }
}
