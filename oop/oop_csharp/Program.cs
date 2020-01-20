using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2D First = new Vector2D();
            Vector2D Second = new Vector2D(5.2f, 3.14f);

            Console.WriteLine(First.ToString());
            Console.WriteLine(Second.ToString() + $" : {Second.X}");

            Second.Multiply(26.3f);
            Second.X = 12.4f;

            Console.WriteLine(Second.ToString() + $" : {Second.X}");

            IVector[] Vectorz = new IVector[] { First, Second, new Vector3D(75.1f, 28.7f, 31.2f) };
            foreach(IVector Object in Vectorz)
            {
                Console.WriteLine($"> {Object.ToString()} : {Object.GetLength()}");
            }

            Vector3D A = new Vector3D(-1f, 1f, -1f);
            Vector3D B = new Vector3D(2f, -2f, 2f);
            Console.WriteLine($"Angle: {Vector3D.Angle(A, B)}");
        }
    }
}
