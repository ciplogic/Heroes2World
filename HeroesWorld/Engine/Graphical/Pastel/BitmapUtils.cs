using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using NHeroes2.Utilities;
using Sdl2.Core;

namespace HeroesWorld.Engine.Graphical.Pastel
{
    internal static class BitmapUtils
    {
        private const double Epsilon = 1e-6;

        static double Distance(double x1, double y1, double x2, double y2)
        {
            var deltaX = x2 - x1;
            var deltaY = y2 - y1;
            var distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return distance;
        }

        static bool IsInteger(double x)
        {
            var intX = (int) x;
            var deltaX = (x - intX);
            return deltaX < Epsilon;
        }

        static void Add(List<DistanceColor> colors, Bitmap rawBitmap, double x, double y, int targetX, int targetY)
        {
            var col = rawBitmap.GetPixel(targetX, targetY);
            var distance = Distance(x, y, targetX, targetY);
            var disColor = new DistanceColor(col, distance);
            colors.Add(disColor);
        }

        public static void FillCloseColors(List<DistanceColor> colors, Bitmap rawBitmap, double x, double y)
        {
            colors.Clear();
            var intX = (int) x;
            var intY = (int) y;
            Add(colors, rawBitmap, x, y, intX, intY);
            var isX = IsInteger(x);
            var isY = IsInteger(y);
            if (isX && isY)
                return;
            if (!isX)
                Add(colors, rawBitmap, x, y, intX + 1, intY);
            if (!isY)
                Add(colors, rawBitmap, x, y, intX, intY + 1);
            if (!isX && !isY)
                Add(colors, rawBitmap, x, y, intX + 1, intY + 1);
        }

        static Color InterpolateColors(List<DistanceColor> colors, List<double> ratios)
        {
            if (colors.Count == 1)
                return colors[0].color;
            ratios.Clear();
            var sum = 0.0;
            foreach (var col in colors)
            {
                var colRatio = 1.0 / col.distance;
                sum += colRatio;
                ratios.Add(colRatio);
            }

            var sumRatio = 1.0 / sum;

            var colR = 0.0;
            var colG = 0.0;
            var colB = 0.0;
            var colA = 0.0;
            for (var index = 0; index < colors.Count; index++)
            {
                var colItem = colors[index];
                var pixelRatio = ratios[index] * sumRatio;
                colR += colItem.color.R * pixelRatio;
                colG += colItem.color.G * pixelRatio;
                colB += colItem.color.B * pixelRatio;
                colA += colItem.color.A * pixelRatio;
            }

            var resultColor = Color.FromArgb((byte) Math.Round(colA), (byte) Math.Round(colR), (byte) Math.Round(colG),
                (byte) Math.Round(colB));
            return resultColor;
        }

        public static Bitmap CloneImageScaled(Bitmap rawImage, int newWidth, int newHeight)
        {
            var cloneBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);

            var scaleWidth = (double) (rawImage.Width - 1) / (newWidth - 1);
            var scaleHeight = (double) (rawImage.Height - 1) / (newHeight - 1);

            var aproxColors = new List<DistanceColor>();
            var colorRatios = new List<double>();
            for (var y = 0; y < newHeight; y++)
            {
                var posY = scaleHeight * y;
                for (var x = 0; x < newWidth; x++)
                {
                    FillCloseColors(aproxColors, rawImage, scaleWidth * x, posY);
                    var optimalColor = InterpolateColors(aproxColors, colorRatios);

                    cloneBitmap.SetPixel(x, y, optimalColor);
                }
            }

            return cloneBitmap;
        }

        public static Bitmap CloneImageScaledFast(Bitmap rawImage, int newWidth, int newHeight)
        {
            var cloneBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);

            var scaleWidth = (double) (rawImage.Width - 1) / (newWidth - 1);
            var scaleHeight = (double) (rawImage.Height - 1) / (newHeight - 1);

            for (var y = 0; y < newHeight; y++)
            {
                for (var x = 0; x < newWidth; x++)
                {
                    var optimalColor = rawImage.GetPixel((int) (x * scaleWidth), (int) (y * scaleHeight));

                    cloneBitmap.SetPixel(x, y, optimalColor);
                }
            }

            return cloneBitmap;
        }

        public static SDL.SDL_Rect ToSdlRect(this Rectangle r)
        {
            return new SDL.SDL_Rect {x = r.X, y = r.Y, w = r.Width, h = r.Height};
        }

        public static Bitmap CutImage(Bitmap rawBitmap, Rectangle area)
        {
            var cloneBitmap = new Bitmap(area.Width, area.Height, rawBitmap.PixelFormat);
            var w = cloneBitmap.Width;
            var h = cloneBitmap.Height;
            var lx = area.X;
            var ly = area.Y;
            for (var y = 0; y < h; y++)
            {
                for (var x = 0; x < w; x++)
                {
                    var pixel = rawBitmap.GetPixel(lx + x, ly + y);
                    cloneBitmap.SetPixel(x, y, pixel);
                }
            }


            return cloneBitmap;
        }

        internal struct DistanceColor
        {
            public Color color;
            public double distance;

            public DistanceColor(Color c, double d)
            {
                color = c;
                distance = d;
            }

            public override string ToString()
            {
                return this.SerializeToJsonString();
            }
        }
    }
}