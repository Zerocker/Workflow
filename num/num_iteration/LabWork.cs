using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iteration
{
    class LabWork
    {
        static void Main()
        {
            float[,] Arr = { { 23, -5, -3, -6, -6 }, 
                             { -5, 32, 9, -6, -5 }, 
                             { -1, 7, 28, 5, 5 },
                             { -3, -9, -7, 37, 9},
                             { 4, 2, -6, -8, 26} };

            float[] Brr = { 3, 50, 132, 54, 18 };

            /*
            float[,] Arr = { { 34, 9, -5, 1, 9},
                             { 0, 24, 5, -6, 8},
                             { 9, 8, 28, 2, -1},
                             {-8, -8, -2, 34, 9},
                             {9, 6, -4, -4, 35} };

            float[] Brr = { 48, 62, 138, 50, 42 };
            */

            //  Задаем значения для решения СЛАУ
            LinearSys Lab = new LinearSys(Arr, Brr, 0.001f);

            //  Метод простых итераций
            Lab.CalculateResult();

            //  Вывод
            Lab.Print();
        }
    }
}
