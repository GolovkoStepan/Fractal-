﻿using System;
using System.Drawing;

namespace FractalCore
{
    public class ColorSettings : ICloneable // класс, хранящий данные для расчета цвета 
    {
        public byte R { get; set; }  // основа для создания цвета (красный)
        public byte G { get; set; }  // основа для создания цвета (зеленый)
        public byte B { get; set; }  // основа для создания цвета (синий)
        public Color NotFractalPointsColor { get; set; } = Color.Black; // цвет точек, не принадлежащих множеству
        public ColorAlgorithms Algorithm { get; set; } // тип алгоритма цветообразования

        public ColorSettings(byte r = 255, byte g = 255, byte b = 255, ColorAlgorithms algorithm = ColorAlgorithms.EscapeTimeAlgorithm)
        {
            R = r;
            G = g;
            B = b;
            Algorithm = algorithm;
        }

        public object Clone() // реализация интерфейса ICloneable
        {
            return new ColorSettings(R, G, B, Algorithm) as object;
        }
    }
}
