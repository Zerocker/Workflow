using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lines
{
    public partial class MainForm : Form
    {
        public int Clicks = 0;
        public Point Center;

        public List<Point> Points = new List<Point>();

        private Draw Drawing;

        public MainForm()
        {
            InitializeComponent();
            Drawing = new Draw(drawBox.Width * 4, drawBox.Height * 4);
            Center = new Point(drawBox.Width / 2, drawBox.Height / 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;

            drawBox.MouseClick += (object Asender, MouseEventArgs Ae) =>
            {
                var mousePosition = drawBox.PointToClient(MousePosition);

                Drawing.DrawPixel(mousePosition, Color.Red);
                drawBox.Image = Drawing.Canvas;

                Clicks++;

                Points.Add(mousePosition);

                if (Clicks >= 2)
                    Logic();
            };
        }

        private void Logic() 
        {
            // Point p2 = new Point(Points[Points.Count - 4], Points[Points.Count - 3]);
            // Point p1 = new Point(Points[Points.Count - 2], Points[Points.Count - 1]);

            var p2 = Points[Points.Count - 2];
            var p1 = Points[Points.Count - 1];

            Drawing.LineBresenham(p2, p1, Color.Black);
            drawBox.Image = Drawing.Canvas;
        }

        private void splitBtn_Click(object sender, EventArgs e)
        {
            //var points = ToDoubleList(Points);
            //var holes = new List<int>();
            //var indices = Earcut.Tessellate(points, holes);

            //Drawing.Clear();
            //for (int i = 0; i < indices.Count; i += 3)
            //{
            //    Point a = Points[indices[i]];
            //    Point b = Points[indices[i + 1]];
            //    Point c = Points[indices[i + 2]];

            //    Drawing.LineBresenham(a, b, Color.Black);
            //    Drawing.LineBresenham(b, c, Color.Black);
            //    Drawing.LineBresenham(c, a, Color.Black);
            //}
            //drawBox.Image = Drawing.Canvas;

            var points = Points.Select<Point, PointF>(i => i).ToList();

            if (Triangulate.Process(points, out List<Point> result))
            {
                int count = result.Count / 3;

                Drawing.Clear();
                for (int i = 0; i < count; i++)
                {
                    var p1 = result[i * 3 + 0];
                    var p2 = result[i * 3 + 1];
                    var p3 = result[i * 3 + 2];

                    Drawing.LineBresenham(p1, p2, Color.Black);
                    Drawing.LineBresenham(p2, p3, Color.Black);
                    Drawing.LineBresenham(p3, p1, Color.Black);
                }
                drawBox.Image = Drawing.Canvas;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            drawBox.Image = Drawing.Clear();
            Points.Clear();
            Clicks = 0;
        }

        private static List<double> ToDoubleList(List<Point> list)
        {
            var result = new List<double>();
            foreach (var point in list)
            {
                result.Add((double)point.X);
                result.Add((double)point.Y);
            }
            return result;
        }
    }
}
