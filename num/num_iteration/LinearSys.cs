using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iteration
{
    class LinearSys
    {
        // Матрицы
        float[,] A;
        float[] B;
        float[] X;
        float Epsilon;
        
        // Размерность
        readonly int Size;
        
        /* -------------------------------------------------------------------- */

        public LinearSys(float[,] A, float[] B, float EpsValue = 0) 
        // Конструктор
        { 
            this.A = A;
            this.B = B;

            Size = B.GetLength(0);
            Epsilon = EpsValue;

            X = new float[Size];
        }

        private bool CanIteraion()
        //  Возможность применения метода простых итераций.
        {
            int count = 0;
            for (int i = 0; i < Size; i++)
            {
                float Sum = 0;
                for (int j = 0; (j < Size) && (j != i); j++)
                {
                    Sum += Math.Abs(A[i, j]);
                }

                if ((Math.Abs(A[i, i]) > Sum) && Math.Abs(A[i, i]) > 0)
                    count++;
            }
            return count != Size ? false : true;
        }

        public void CalculateResult()
        //  Метод простых итераций
        {
            if (!CanIteraion())
            {
                Console.WriteLine($"Невозможно провести метод простых итераций!");
                return;
            }

            float[] PreviousValues = new float[Size];
            float[] CurrentValues = new float [Size];

            while (true)
            {
                int EpsCount = 0;
                B.CopyTo(CurrentValues, 0);

                /*  Нахождение текущих значений для решения СЛАУ */
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (j < i)
                        {
                            CurrentValues[i] -= A[i, j] * CurrentValues[j];
                        }
			
			            if (j > i)
			            {
			                 CurrentValues[i] -= A[i, j] * PreviousValues[j];
			            }
                            
                    }
                    CurrentValues[i] /= A[i, i];
                }

                /*  Проверка точности */           
                for (int i = 0; i < Size; i++)
                {
                    if (Math.Abs(CurrentValues[i] - PreviousValues[i]) < Epsilon)
                        EpsCount++;
                }

                /*  Если все разности прошли проверку, то  
                 *  текущие значения становятся результатом
                 *  для решения СЛАУ */
                if (EpsCount == Size)
                {
                    CurrentValues.CopyTo(X, 0);
                    break;
                }

                /*  Если выше проверка не прошла  
                 *  текущие значения становятся предыдущими */
                CurrentValues.CopyTo(PreviousValues, 0);
            }
        }

        /* -------------------------------------------------------------------- */

        public void Print()
        {
            Print(A, "A");
            Print(B, "B");
            Print(X, "X");
        }

        public static void Print(float[,] Array, string Message = "Matrix")
        //  Вывод матрицы
        {
            Console.WriteLine(Message + ":");
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Console.Write("{0,10}", Array[i, j]);
                }
                if (i != Array.Length)
                    Console.WriteLine();
            }
        }

        public static void Print(float[] Array, string Message = "List")
        //  Вывод вектора
        {
            Console.WriteLine(Message + ":");
            foreach (float item in Array)
            {
                Console.Write("{0,10}", $"{item:F4}");
            }
            Console.WriteLine();
        }
    }
}
