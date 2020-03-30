using System;
using System.Collections.Generic;
using System.Numerics;

namespace Lab.GL
{
    public class PyramidMesh
    {
        public static Vector4[] GenerateVertices(int sides, float height, Vector3 center, float radius = 1, float rotation = 0)
        {
            Vector4[] vertices = new Vector4[sides+2];

            double oneSegment = Math.PI * 2d / Convert.ToDouble(sides);
            for (int i = 0; i < sides; i++)
            {
                double x = Math.Sin(oneSegment * i + rotation) * radius + center.X;
                double y = Math.Cos(oneSegment * i + rotation) * radius + center.Y;

                vertices[i] = new Vector4((float)x, 0f, (float)y, 0f);
            }
            vertices[sides] = new Vector4(0f, -height, 0f, 0f);
            vertices[sides + 1] = Vector4.Zero;

            return vertices;
        }

        public static Triangle[] GenerateFaces(int sides)
        {
            List<Triangle> indices = new List<Triangle>();

            for (int i = 0; i < sides * 2; i++)
            {
                var v1 = i % sides;
                var v2 = (i + 1) % sides;
                var v3 = (i < sides) ? sides : sides + 1;

                indices.Add(new Triangle 
                { 
                    A = v1, 
                    B = v2, 
                    C = v3,
                    Color = Extensions.PickBrush()
                });
            }

            return indices.ToArray();
        }
    }
}
