using System;
using System.Collections.Generic;

namespace Lagrange_Interpolation
{
    class Lagrange
    {
        private readonly List<double> X;
        private readonly List<double> Y;

        public Lagrange(List<double> X, List<double> Y)
        {
            this.X = X;
            this.Y = Y;
        }

        private double Formula_A(int k, double Z)
        {
            var N = Z * (X[k-1] - X[k]) + (Y[k] - Y[k-1]);
            var D = (X[k] - X[k-1]) * (X[k] - X[k - 1]);
            return N / D;
        }

        private double Formula_B(int k, double Z)
        {
            var N = Z * (X[k]*X[k] - X[k-1]*X[k-1]) + 2 * X[k-1] * (Y[k-1] - Y[k]);
            var D = (X[k] - X[k - 1]) * (X[k] - X[k - 1]);
            return N / D;
        }

        private double Formula_C(int k, double Z)
        {
            var N = X[k]*X[k]*Y[k-1] - X[k]*X[k-1]*(2*Y[k-1]+X[k]*Z) + X[k-1]*X[k-1]*(Y[k]+X[k]*Z);
            var D = (X[k] - X[k - 1]) * (X[k] - X[k - 1]);
            return N / D;
        }

        private double Formula_Z(int k, double Z)
        {
            return 2 * Formula_A(k, Z) * X[k] + Formula_B(k, Z);
        }

        public double Polynomial(double Value)
        {
            var R = 0.0;
            for (int k = 0; k < X.Count; k++)
            {
                var Numerator = 1.0;
                for (int i = 0; i < X.Count; i++)
                {
                    if (i != k)
                    {
                        Numerator *= Value - X[i];
                    }
                }

                var Denominator = 1.0;
                for (int j = 0; j < X.Count; j++)
                {
                    if (j != k)
                    {
                        Denominator *= X[k] - X[j];
                    }
                }

                R += Y[k] * Numerator / Denominator;
            }
            return R;
        }

        public void Spline(double value)
        {
            var Z = value;
            for (var k = 1; k < X.Count; k++)
            {
                Console.WriteLine($"A[{k}] = {Formula_A(k, Z)}");
                Console.WriteLine($"B[{k}] = {Formula_B(k, Z)}");
                Console.WriteLine($"C[{k}] = {Formula_C(k, Z)}");

                Z = Formula_Z(k, Z);

                Console.WriteLine($"Z[{k}] = {Z}");

                if (k < X.Count - 1 )
                    Console.WriteLine("* ------------ *");
            }
        }
    }
}
