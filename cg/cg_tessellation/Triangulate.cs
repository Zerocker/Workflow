using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lines
{
    public class Triangulate
    {
        static float Epsilon = 0.0000000001f;

        public static bool Process(List<PointF> polygon, out List<Point> result)
        {
            result = new List<Point>();

            /* allocate and initialize list of Vertices in polygon */
            int n = polygon.Count;
            if (n < 3)
                return false;

            int[] V = new int[n];

            /* we want a counter-clockwise polygon in V */
            if (0.0f < Area(polygon))
                for (int v = 0; v < n; v++) V[v] = v;
            else
                for (int v = 0; v < n; v++) V[v] = (n - 1) - v;

            int nv = n;

            /*  remove nv-2 Vertices, creating 1 triangle every time */
            int count = 2 * nv;   /* error detection */

            for (int m = 0, v = nv - 1; nv > 2;)
            {
                /* if we loop, it is probably a non-simple polygon */
                if (0 >= (count--))
                {
                    //** Triangulate: ERROR - probable bad polygon!
                    return false;
                }

                /* three consecutive vertices in current polygon, <u,v,w> */
                int u = v; if (nv <= u) u = 0;     /* previous */
                v = u + 1; if (nv <= v) v = 0;     /* new v    */
                int w = v + 1; if (nv <= w) w = 0;     /* next     */

                if (Snip(polygon, u, v, w, nv, V))
                {
                    int a, b, c, s, t;

                    /* true names of the vertices */
                    a = V[u]; b = V[v]; c = V[w];

                    /* output Triangle */
                    result.Add(Point.Round(polygon[a]));
                    result.Add(Point.Round(polygon[b]));
                    result.Add(Point.Round(polygon[c]));

                    m++;

                    /* remove v from remaining polygon */
                    for (s = v, t = v + 1; t < nv; s++, t++) V[s] = V[t]; nv--;

                    /* resest error detection counter */
                    count = 2 * nv;
                }
            }

            return true;
        }

        public static float Area(List<PointF> polygon)
        {
            float area = 0.0f;
            for (int p = polygon.Count - 1, q = 0; q < polygon.Count; p = q++)
            {
                area = polygon[p].X * polygon[p].Y - polygon[q].X * polygon[q].Y;
            }
            return area / 2f;
        }

        public static bool InsideTriangle(PointF a, PointF b, PointF c, PointF p)
        {
            float ax, ay, bx, by, cx, cy, apx, apy, bpx, bpy, cpx, cpy;
            float cxap, bxcp, axbp;

            ax = c.X - b.X; ay = c.Y - b.Y;
            bx = a.X - c.X; by = a.Y - c.Y;
            cx  = b.X - a.X; cy = b.Y - a.Y;
            apx = p.X - a.X; apy = p.Y - a.Y;
            bpx = p.X - b.X; bpy = p.Y - b.Y;
            cpx = p.X - c.X; cpy = p.Y - c.Y;

            axbp = ax * bpy - ay * bpx;
            cxap = cx * apy - cy * apx;
            bxcp = bx * cpy - by * cpx;

            return ((axbp >= 0.0f) && (bxcp >= 0.0f) && (cxap >= 0.0f));
        }

        private static bool Snip(List<PointF> polygon, int u, int v, int w, int n, int[] V)
        {
            PointF A, B, C, P;
            float Ax, Ay, Bx, By, Cx, Cy, Px, Py;

            Ax = polygon[V[u]].X;
            Ay = polygon[V[u]].Y;

            Bx = polygon[V[v]].X;
            By = polygon[V[v]].Y;

            Cx = polygon[V[w]].X;
            Cy = polygon[V[w]].Y;

            A = new PointF(Ax, Ay);
            B = new PointF(Bx, By);
            C = new PointF(Cx, Cy);

            if (Epsilon > (((Bx - Ax) * (Cy - Ay)) - ((By - Ay) * (Cx - Ax)))) return false;

            for (int p = 0; p < n; p++)
            {
                if ((p == u) || (p == v) || (p == w)) 
                    continue;
                Px = polygon[V[p]].X;
                Py = polygon[V[p]].Y;
                P = new PointF(Px, Py);

                if (InsideTriangle(A, B, C, P)) 
                    return false;
            }

            return true;
        }
    }
}