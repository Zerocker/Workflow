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
        public List<Point> Points = new List<Point>();

        private Draw Drawing;
        
        private Color BgColor = Color.White;

        private Color CurrentColor;

        public MainForm()
        {
            InitializeComponent();
            Drawing = new Draw(drawBox.Width, drawBox.Height);
            drawBox.Image = Drawing.Canvas;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Color[] palette = Draw.GetArne16Palette();
            int h = palettePanel.Height - 8;

            for (int i = 0; i < palette.Length; i++)
            {
                var control = new Panel
                {
                    BackColor = palette[i],
                    Left = i * (h + 3),
                    Top = 0,
                    Width = h,
                    Height = h
                };

                control.Click += this.ColorPaletteClickHandler;

                palettePanel.Controls.Add(control);
            }

            CurrentColor = palette[0];
            Drawing.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            
            drawBox.MouseClick += (object Asender, MouseEventArgs Ae) =>
            {
                var mousePosition = Ae.Location;

                if (pointButton.Checked)
                {
                    Drawing.DrawPixel(mousePosition, CurrentColor);
                }

                if (lineButton.Checked)
                {
                    Drawing.DrawPixel(mousePosition, CurrentColor);
                    Points.Add(mousePosition);

                    if (Points.Count > 1)
                    {
                        DrawLines();
                    }  
                }
                else
                {
                    Points.Clear();
                }

                if (fillButton.Checked)
                {
                    if (fourModeButton.Checked)
                    {
                        Drawing.FillFour(mousePosition, BgColor, CurrentColor);
                    }
                        
                    if (eightModeButton.Checked)
                    {
                        Drawing.FillEight(mousePosition, BgColor, CurrentColor);
                    }

                    if (randomModeButton.Checked)
                    {
                        Drawing.FillRandom(mousePosition, BgColor);
                    }
                }

                drawBox.Image = Drawing.Canvas;
            };
        }

        private void DrawLines() 
        {
            var p1 = Points[1];
            var p2 = Points.TakeAt(0);
            
            Drawing.LineBresenham(p1, p2, CurrentColor);
        }

        private void ColorPaletteClickHandler(object sender, EventArgs e)
        {
            var control = (Panel)sender;
            CurrentColor = control.BackColor;
            colorPanel.BackColor = CurrentColor;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Drawing.Clear();
            drawBox.Image = Drawing.Canvas;
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            CurrentColor = Draw.GetRandomColor(ref rnd);
            colorPanel.BackColor = CurrentColor;
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
