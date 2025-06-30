using System;

namespace RownanieKwadratoweApp
{
    public class QuadraticSolver
    {
        public static (int liczbaPierwiastkow, double? x1, double? x2) ObliczPierwiastki(double a, double b, double c)
        {
            if (a == 0)
                throw new ArgumentException("Współczynnik 'a' nie może być zerem w równaniu kwadratowym.");

            double delta = b * b - 4 * a * c;

            if (delta < 0)
                return (0, null, null);

            if (delta == 0)
            {
                double x = -b / (2 * a);
                return (1, x, null);
            }

            double sqrtDelta = Math.Sqrt(delta);
            double x1 = (-b - sqrtDelta) / (2 * a);
            double x2 = (-b + sqrtDelta) / (2 * a);
            return (2, x1, x2);
        }
    }
}