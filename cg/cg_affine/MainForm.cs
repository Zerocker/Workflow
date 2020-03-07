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

        public List<int> X = new List<int>();
        public List<int> Y = new List<int>();
        
        public List<int> X_ = new List<int>();
        public List<int> Y_ = new List<int>();

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

                if (Ae.Button == MouseButtons.Right)
                {
                    Center = mousePosition;
                    label1.Text = $"Center: {Center}";
                }
                else
                {
                    Clicks++;

                    X.Add(mousePosition.X);
                    Y.Add(mousePosition.Y);

                    X_.Add(mousePosition.X);
                    Y_.Add(mousePosition.Y);

                    if (Clicks >= 2)
                        Logic();
                } 
            };
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int centY = Center.Y;
            int centX = Center.X;
            int angle = 0, distance = 0;

            if (e.KeyCode == Keys.Q)
            {
                angle = 360;
                distance = -1;
            }
            else if (e.KeyCode == Keys.E)
            {
                angle = 361;
                distance = 1;
            }
            else
            {
                return;
            }

            if ((X.Count >= 3) && (Y.Count >= 3))
            {
                Drawing.LineBresenham(
                    new Point(X[X.Count - 1], Y[Y.Count - 1]),
                    new Point(X[0], Y[0]), Color.Black);

                while (true)
                {

                    for (int i = 0; i < X.Count; i++)
                    {
                        X_[i] = (int)(centX + ((X[i] - centX) * Math.Cos(angle * Math.PI / 180) - (Y[i] - centY) * Math.Sin(angle * Math.PI / 180)));
                        Y_[i] = (int)(centY + ((X[i] - centX) * Math.Sin(angle * Math.PI / 180) + (Y[i] - centY) * Math.Cos(angle * Math.PI / 180)));
                    }

                    for (int i = 0; i < X.Count - 1; i++)
                    {
                        Drawing.LineBresenham(
                            new Point(X_[i], Y_[i]),
                            new Point(X_[i + 1], Y_[i + 1]), Color.Black);
                    }

                    Drawing.LineBresenham(
                            new Point(X_[X_.Count - 1], Y_[Y_.Count - 1]),
                            new Point(X_[0], Y_[0]), Color.Black);

                    angle += distance;
                    label1.Text = $"Degrees: {angle}";

                    Thread.Sleep(50);
                    drawBox.Refresh();

                    if (angle % 360 == 0)
                        return;
                    else
                        drawBox.Image = Drawing.Clear();
                }
            }
        }

        private void Logic() 
        {
            if (lineButton.Checked)
            {
                Drawing.LineBresenham(
                    new Point(X[X.Count - 2], Y[Y.Count - 2]),
                    new Point(X[X.Count - 1], Y[Y.Count - 1]), Color.Black);
                
                label1.Text = X[X.Count-2] + ";" + Y[Y.Count-2] + " - " + X[X.Count-1] + ";" + Y[Y.Count-1] + ";";
                drawBox.Image = Drawing.Canvas;
            }
        }
    }
}
