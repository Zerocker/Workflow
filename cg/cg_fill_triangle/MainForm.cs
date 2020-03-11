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

        public List<Point> Points = new List<Point>();
        
        public List<Point> Vertices = new List<Point>();

        private Draw Drawing;

        public MainForm()
        {
            InitializeComponent();
            Drawing = new Draw(drawBox.Width * 4, drawBox.Height * 4);
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
                Vertices.Add(mousePosition);

                if (Clicks >= 2)
                    Logic();

                if (Clicks % 4 == 0)
                {
                    Clicks = 0;
                    Points.Clear();

                    try
                    {
                        Drawing.Triagle(Vertices[0], Vertices[1], Vertices[2]);
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }
                    Vertices.Clear();
                    
                    drawBox.Image = Drawing.Canvas;
                }
            };
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Logic() 
        {
            var p1 = Points[1];
            var p2 = Points.TakeAt(0);
            
            Drawing.LineBresenham(p1, p2, Color.Black);
            drawBox.Image = Drawing.Canvas;
        }
    }

    static class ListExtension
    {
        public static T TakeAt<T>(this List<T> list, int index)
        {
            T r = list[index];
            list.RemoveAt(index);
            return r;
        }
    }
}
