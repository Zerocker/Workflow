using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        Bitmap image;
        Bitmap original;
        Dictionary<double, double> RedChannel;
        Dictionary<double, double> GreenChannel;
        Dictionary<double, double> BlueChannel;
        Dictionary<double, double> MixChannel;

        private List<Point> Points = new List<Point>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(Channel));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open an image file";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image = new Bitmap(dlg.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    original = (Bitmap)image.Clone();

                    pictureBox7.Image = original;
                    pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
                }

                RedChannel = Histogram.CountByChannel(image, Channel.Red);
                GreenChannel = Histogram.CountByChannel(image, Channel.Green);
                BlueChannel = Histogram.CountByChannel(image, Channel.Blue);
                MixChannel = Histogram.CountAsWhole(RedChannel, GreenChannel, BlueChannel);
                DrawHistograms();
            }
        }

        private void DrawHistograms()
        {
            pictureBox1.Image = image;
            pictureBox2.Image = Histogram.Create(RedChannel, Color.Red);
            pictureBox3.Image = Histogram.Create(GreenChannel, Color.Green);
            pictureBox4.Image = Histogram.Create(BlueChannel, Color.Blue);
            pictureBox5.Image = Histogram.Create(MixChannel, Color.LightGray);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void customBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (Point point in Points)
                e.Graphics.FillEllipse(Brushes.White, point.X, point.Y, 1, 1);
            if (Points.Count < 2) return;

            e.Graphics.DrawCurve(Pens.White, Points.ToArray());
        }

        private void customBox_MouseClick(object sender, MouseEventArgs e)
        {
            Points.Add(e.Location);
            Refresh();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            Points.Clear();
            pictureBox7.Image = original;
            Refresh();
        }

        private void castBtn_Click(object sender, EventArgs e)
        {
            Channel selectedChannel = (Channel)comboBox1.SelectedItem;
            if (selectedChannel == Channel.Mixed)
                return;

            var bmp = new Bitmap(pictureBox6.Width, pictureBox6.Height);
            pictureBox6.DrawToBitmap(bmp, pictureBox6.ClientRectangle);

            var newHisto = Histogram.BuildCast(bmp);
            var newChannel = Histogram.MatchCDF(image, newHisto, selectedChannel);
            Histogram.ApplyChannel(image, selectedChannel, newChannel);

            //foreach(var item in newHisto)
            //{
            //    Console.WriteLine($"[{item.Key}] = {item.Value},");
            //}
            //foreach (var item in newHisto)
            //{
            //    Console.WriteLine($"    \"{item.Key}\": {item.Value},");
            //}

            switch(selectedChannel)
            {
                case Channel.Red:
                    RedChannel = newHisto;
                    break;
                case Channel.Green:
                    GreenChannel = newHisto;
                    break;
                case Channel.Blue:
                    BlueChannel = newHisto;
                    break;
            }
            MixChannel = Histogram.CountAsWhole(RedChannel, GreenChannel, BlueChannel);
            DrawHistograms();
        }
    }
}
