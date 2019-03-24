using System;
using System.Collections.Generic;

namespace Lagrange_Interpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            var Xs = 3.3;

            var X = new List<double>()
            {
                -1.1, -1.0, 0.6, 0.8, 2.5, 3.2
            };

            var Y = new List<double>()
            {
                1.6419, 0.0, 14.37696, 19.51488, 9.84375, 2.79552
            };

            var Math = new Lagrange(X, Y);
            var Poly = Math.Polynomial(Xs);

            Console.WriteLine($"Lagrange Polynomial = {Poly}\n");
            Console.WriteLine($"Splines: ");
            Math.Spline(2.0);
        }
    }
}
