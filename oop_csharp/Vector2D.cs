using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self
{
    public class Vector2D : IVector
    {
        private float X_;
        private float Y_;
        public float X
        {
            get { return X_; }
            set { X_ = value; }
        }
        public float Y
        {
            get { return Y_; }
            set { Y_ = value; }
        }
        public Vector2D(float X, float Y)
        {
            this.X_ = X;
            this.Y_ = Y;
        }
        public Vector2D() : this(0.0f, 0.0f) { }
        public float GetLength()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }
        public override string ToString() 
        {
            return $"({X}, {Y})";
        }
        public static float Angle(Vector2D A, Vector2D B)
        {
            float Numerator = A.X * B.X + A.Y * B.Y;

            float Denominator = 
                (float)Math.Sqrt(A.X * A.X + A.Y * A.Y) *
                (float)Math.Sqrt(B.X * B.X + B.Y * B.Y);

            return (float)(Math.Acos(Numerator / Denominator) * 180.0f / Math.PI);
        }

        public static Vector2D operator +(Vector2D First, Vector2D Second)
        {
            return new Vector2D
            {
                X = First.X + Second.X, Y = First.Y + Second.Y
            };
        }
        public static Vector2D operator -(Vector2D First, Vector2D Second)
        {
            return new Vector2D
            {
                X = First.X - Second.X, Y = First.Y - Second.Y
            };
        }
        public static Vector2D operator *(Vector2D Vector, float Value)
        {
            return new Vector2D
            {
                X = Vector.X * Value, Y = Vector.Y * Value
            };
        }
    }
}
