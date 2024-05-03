using System.Drawing;
using System;

namespace Fractals
{
    internal static class DragonFractalTask
    {
        private const double V = Math.PI / 4;
        private const double S = 3 * Math.PI / 4;

        private static Double[] Transform(Double x, Double y, Double z)
        {
            Double[] point = new Double[2];
            point[0] = (x * Math.Cos(z) - y * Math.Sin(z)) / Math.Sqrt(2);
            point[1] = (x * Math.Sin(z) + y * Math.Cos(z)) / Math.Sqrt(2);
            if (z == S) point[0] += 1;
            return point;
        }

        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            Double x = 1;
            Double y = 0;
            Double[] newPoint; 
 
            var random = new Random(seed);         
            pixels.SetPixel(x, y);

            for (int i = 0; i < iterationsCount; i++)
            {
                var nextNumber = random.Next(10);

                if (nextNumber % 2 == 0) newPoint = Transform(x, y, V);
                else newPoint = Transform(x, y, S);
                
                x = newPoint[0];
                y = newPoint[1];

                pixels.SetPixel(x, y);
            }
        }
    }
}