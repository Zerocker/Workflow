using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;

namespace Lab
{
    public static class Extensions
    {
        public static float PI_OVER_360 = 0.0087266f;

        private static readonly Random random = new Random();

        public static Brush PickBrush()
        {
            Brush result = Brushes.Transparent;

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int rnd = random.Next(properties.Length);
            
            result = (Brush)properties[rnd].GetValue(null, null);

            return result;
        }

        public static Matrix4x4 BuildPerspective(float fov, float aspect, float near, float far)
        {
            float xyMax = near * (float)Math.Tan(fov * PI_OVER_360);
            float xMin = -xyMax;
            float yMin = -xyMax;

            float width = xyMax - xMin;
            float height = xyMax - yMin;

            float depth = far - near;
            float q = -(far + near) / depth;
            float qn = -2f * (far * near) / depth;

            float w = 2f * near / width;
            w = w / aspect;
            float h = 2 * near / height;

            return new Matrix4x4 { M11 = w, M22 = h, M33 = q, M34 = qn, M43 = -1f };
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static void Swap<T>(this T[] source, int index1, int index2)
        {
            T tmp = source[index1];
            source[index1] = source[index2];
            source[index2] = tmp;
        }

        public static Vector4 ToVector4(this Vector3 vector)
        {
            return new Vector4(vector.X, vector.Y, vector.Z, 0);
        }
    }
}
