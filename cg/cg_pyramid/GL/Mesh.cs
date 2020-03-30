using System;
using System.Drawing;
using System.Numerics;

namespace Lab.GL
{
    public struct Triangle
    {
        public int A, B, C;
        public Brush Color;
    } 
    
    public class Mesh
    {
        public Vector4[] Vertices { get; set; }

        public Vector3[] Normals { get; set; }

        public Triangle[] Triangles { get; set; }

        private Vector4[] Temp;

        public void Transform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            var tMatrix = Matrix4x4.CreateTranslation(position);
            var sMatrix = Matrix4x4.CreateScale(scale.X, scale.Y, scale.Y);
            var rMatrix = Matrix4x4.CreateFromYawPitchRoll(rotation.X, rotation.Y, rotation.Z);
            var matrix = tMatrix * rMatrix * sMatrix;

            Temp = new Vector4[Vertices.Length];
            for (int i = 0; i < Vertices.Length; i++)
                Temp[i] = Vector4.Transform(Vertices[i], matrix);
        }

        public void Draw(Graphics gr, PointF start, Matrix4x4 projection)
        {
            var final = new Vector4[Temp.Length];
            for (int i = 0; i < Temp.Length; i++)
            {
                final[i] = Vector4.Transform(Temp[i], projection);
            }

            for (int i = 0; i < Triangles.Length; i++)
            {
                var A = Temp[Triangles[i].A];
                var B = Temp[Triangles[i].B];
                var C = Temp[Triangles[i].C];

                var triangle = CurvePolygons(A, B, C);

                gr.ResetTransform();
                gr.TranslateTransform(start.X, start.Y);
                gr.FillPolygon(Triangles[i].Color, triangle);
            }
        }

        private PointF[] CurvePolygons(params Vector4[] points)
        {
            var temp = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                temp[i] = new PointF(points[i].X, points[i].Y);
            }

            return temp;
        }

        public void SortDepth()
        {
            var sort = new float[Triangles.Length];

            for (int i = 0; i < Triangles.Length; i++)
            {
                var A = Temp[Triangles[i].A];
                var B = Temp[Triangles[i].B];
                var C = Temp[Triangles[i].C];

                sort[i] = (A.Z + B.Z + C.Z) / 3f;
            }

            for (int i = 0; i < Triangles.Length - 1; i++)
            {
                for (int j = 0; j < Triangles.Length - 1; j++)
                {
                    if (sort[j] <= sort[j + 1])
                    {
                        var temp = sort[j];
                        sort[j] = sort[j + 1];
                        sort[j + 1] = temp;

                        var temp1 = Triangles[j];
                        Triangles[j] = Triangles[j + 1];
                        Triangles[j + 1] = temp1;
                    }
                }
            }
        }

        public void RotateAround(Vector4 point, Vector4 origin, double angle)
        {
            var R = new Matrix4x4
            {
                M11 = (float)(Math.Cos(angle) + (1 - Math.Cos(angle)) * Math.Pow(point.X, 2)),
                M12 = (float)((1 - Math.Cos(angle))*point.X*point.Y - Math.Sin(angle)*point.Z),
                M13 = (float)((1 - Math.Cos(angle))*point.X*point.Z - Math.Sin(angle)*point.Y),
                M14 = 0,

                M21 = (float)((1 - Math.Cos(angle))*point.Y*point.X - Math.Sin(angle)*point.Z),
                M22 = (float)(Math.Cos(angle) + (1 - Math.Cos(angle)) * Math.Pow(point.Y, 2)),
                M23 = (float)((1 - Math.Cos(angle))*point.Y*point.Z - Math.Sin(angle)*point.X),
                M24 = 0,


                M31 = (float)((1 - Math.Cos(angle))*point.Z*point.X - Math.Sin(angle)*point.Y),
                M32 = (float)((1 - Math.Cos(angle))*point.Z*point.Y - Math.Sin(angle)*point.X),
                M33 = (float)(Math.Cos(angle) + (1 - Math.Cos(angle)) * Math.Pow(point.Z, 2)),
                M34 = 0,

                M44 = 1,
            };

            var OP = point - origin;
            
            for (int i = 0; i < Vertices.Length; i++)
            {
                Temp[i] = Vector4.Transform((Vertices[i] - OP), R) + OP;
            }
        }
    }
}
