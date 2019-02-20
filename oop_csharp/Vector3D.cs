using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self
{
    public class Vector3D : Vector2D
    {
        private float Z_;

        public float Z
        {
            get { return Z_; }
            set { Z_ = value; }
        }
        public Vector3D(float X, float Y, float Z) : base(X, Y)
        {
            this.Z_ = Z; 
        }
        public Vector3D() : this(0.0f, 0.0f, 0.0f) {}

        public new float GetLength()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }
        public new void Multiply(float Value)
        {
            X *= Value;
            Y *= Value;
            Z *= Value;
        }
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
        public static Vector3D operator +(Vector3D First, Vector3D Second)
        {
            return new Vector3D {
                X = First.X + Second.X,
                Y = First.Y + Second.Y,
                Z = First.Z + Second.Z,
            };
        }
        public static Vector3D operator -(Vector3D First, Vector3D Second)
        {
            return new Vector3D
            {
                X = First.X - Second.X,
                Y = First.Y - Second.Y,
                Z = First.Z - Second.Z,
            };
        }
        public static Vector3D operator *(Vector3D Vector, float Value)
        {
            return new Vector3D
            {
                X = Vector.X * Value,
                Y = Vector.Y * Value,
                Z = Vector.Z * Value,
            };
        }

        public static float Angle(Vector3D A, Vector3D B)
        {
            float Numerator = A.X * B.X + A.Y * B.Y + A.Z * B.Z;

            float Denominator =
                (float)Math.Sqrt(A.X * A.X + A.Y * A.Y + A.Z * A.Z) *
                (float)Math.Sqrt(B.X * B.X + B.Y * B.Y + B.Z * B.Z);

            return (float)(Math.Acos(Numerator / Denominator) * 180.0f / Math.PI);
        }
    }
}
