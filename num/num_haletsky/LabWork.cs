using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haletsky
{
    class Lab
    {
        static void Main(string[] args)
        {
            // X = {476, -201, -12, 113, -182}

            int[,] Arr = { {1, 1, -1, -1, 1},
                           {2, 3, -1, 0, 2},
                           {-1, -1, 2, 1, -1},
                           {-3, -2, 1, 6, -2},
                           {-3, 0, 7, 7, -4} };
            int[] Crr = { -8, -3, -4, 4, 7 };
            int Size = Crr.GetLength(0);

            int[,] Brr = new int[Size, Size];
            int[,] Trr = new int[Size, Size];
            SplitToBC(Arr, Brr, Trr);

            int[] Yrr = FindY(Brr, Crr);
            int[] Xrr = FindX(Trr, Yrr);

            PrintMatrix(Arr, "A");
            PrintMatrix(Crr, "C");

            PrintMatrix(Brr, "B");
            PrintMatrix(Trr, "T");
            PrintMatrix(Yrr, "Y");
            PrintMatrix(Xrr, "X");

            Console.Write("Press any key to exit . . . ");
            Console.Read();

        }

        /*  Finds Y with BY=C */
        public static void SplitToBC(int[,] A, int[,] B, int[,] T)
        {
            int N = A.GetLength(0);

            for (int i = 0; i < N; i++)
            {
                B[i, 0] = A[i, 0];
                T[i, i] = 1;
            }

            for (int j = 1; j < N; j++)
            {
                T[0, j] = A[0, j] / B[0, 0];  
            }


            for (int k = 1; k < N; k++)
            {
                // for B matrix
                for (int i = k; i < N; i++)
                {
                    int Sum = 0;
                    for (int m = 0; m <= k - 1; m++)
                    {
                        Sum += (B[i, m] * T[m, k]);
                    }

                    B[i, k] = A[i, k] - Sum;
                }

                // for T matrix
                for (int j = k + 1; j < N; j++)
                {
                    int Sum = 0;
                    for (int m = 0; m <= k - 1; m++)
                    {
                        Sum += (B[k, m] * T[m, j]);
                    }

                    T[k, j] = (A[k, j] - Sum) / B[k, k];
                }
            }
        }

        /*  Finds Y with BY=C */
        public static int[] FindY(int[,] B, int[] C)
        {
            int N = C.GetLength(0);
            int[] Y = new int[N];

            Y[0] = C[0] / B[0, 0];

            for (int i = 1; i < N; i++)
            {
                int Sum = 0;
                for (int m = 0; m <= i - 1; m++)
                {
                    Sum += (B[i, m] * Y[m]);
                }
                Y[i] = (C[i] - Sum) / B[i, i];
            }
            return Y;
        }

        /*  Finds X with TX=Y */
        public static int[] FindX(int[,] T, int[] Y)
        {
            int N = Y.GetLength(0);
            int[] X = new int[N];

            X[N-1] = Y[N-1];

            for (int i = N - 2; i >= 0; --i)
            {
                int Sum = 0;
                for (int m = i+1; m < N; m++)
                {
                    Sum += (T[i, m] * X[m]);
                }
                X[i] = Y[i] - Sum;
            }
            return X;
        }

        /*  Multiply two matrices */
        public static int[,] Multiply(int[,] List1, int[,] List2)
        {
            int N = List1.GetLength(0);
            int[,] Result = new int[5, 5];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        Result[i, j] += List1[i, k] * List2[k, j];
                    }
                }
            }
            return Result;
        }

        /*  Prints 2d array */
        public static void PrintMatrix(int[,] Array, string Message = "Matrix")
        {
            Console.WriteLine(Message + ":");
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Console.Write("{0,6}", Array[i, j]);
                }
                if (i != Array.Length)
                    Console.WriteLine();
            }
        }
        /*  Prints simple array */
        public static void PrintMatrix(int[] Array, string Message = "List")
        {
            Console.WriteLine(Message + ":");
            foreach (int item in Array)
            {
                Console.Write("{0,6}", item);
            }
            Console.WriteLine();
        }
    }
}
