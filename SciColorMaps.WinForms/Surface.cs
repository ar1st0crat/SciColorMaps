using System;

namespace SciColorMaps.WinForms
{
    /// <summary>
    /// The Surface class provides some parameterized surfaces for demo
    /// </summary>
    static class Surface
    {
        public static double FancySurface(double x, double y)
        {
            x /= 60;
            y /= 90;

            var z = x * x + y * y;
            return 70 * Math.Exp(-z) * Math.Sin(2 * Math.PI * x * y);
        }

        public static double HyperbolicParaboloid(double x, double y)
        {
            float a = 6, b = 5, p = 2;

            return ((x * x) / (a * a) - (y * y) / (b * b)) / (2 * p);
        }

        public static double EllipticParaboloid(double x, double y)
        {
            double a = 6, b = 7, p = 2;

            return ((x * x) / (a * a) + (y * y) / (b * b)) / (2 * p);
        }
    }
}
