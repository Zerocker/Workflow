using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Bitmap Background = null;

        private Bitmap Foreground = null;

        private Bitmap CombinedBitmap = null;

        private Point FgLocation = new Point(0, 0);

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        /* Let the user open a file */
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Open the file.
                    Background = new Bitmap(ofdFile.FileName);
                    picImage.Image = Background;
                    picImage.Visible = true;
                    ClientSize = new Size(
                        picImage.Right + picImage.Left,
                        picImage.Bottom + picImage.Left);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file.\n" + ex.Message,
                        "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /* Load the overlay image */
        private void mnuFileOverlay_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Open the file.
                    Foreground = new Bitmap(ofdFile.FileName);
                    picImage.Cursor = Cursors.Cross;

                    //Display the combined image.
                    ShowCombinedImage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file.\n" + ex.Message,
                        "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /* Display the combined image */
        private void ShowCombinedImage()
        {
            if (Background == null) return;

            var opacity = Convert.ToByte(opacityNumUpDown.Value);
            if (Foreground != null)
            {

                if (fstRadioBtn.Checked)
                {
                    CombinedBitmap = OverlayBitmap(Foreground, Background, opacity, FgLocation);
                }
                else if (sndRadioBtn.Checked)
                {
                    CombinedBitmap = MaskBitmap(Foreground, Background, opacity, FgLocation);
                }
            }
            picImage.Image = CombinedBitmap;
        }


        /* Drag the overlay image */
        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (Foreground == null) return;

            FgLocation = new Point(
                e.X - Foreground.Width / 2,
                e.Y - Foreground.Height / 2);
            
            ShowCombinedImage();
        }


        /* Finish dragging the overlay image */
        private void picImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (Foreground == null) return;
            Foreground = null;
            picImage.Cursor = Cursors.Default;

            // Make the overlay permanent.
            Background = CombinedBitmap;
        }


        /* Default overlay routine */
        public Bitmap OverlayBitmap(Bitmap fg, Bitmap bg, byte opacity, Point location)
        {
            Bitmap output = new Bitmap(bg);

            // Start at row indicated by location, or at row 0 if location.y is negative.
            for (int y = Math.Max(location.Y, 0); y < bg.Height; y++)
            {
                // Due to translation
                int fY = y - location.Y;    
                
                // Done with processing all rows of the foreground image
                if (fY >= fg.Height) break;

                // Start at col indicated by location, or at col 0 if location.y is negative.
                for (int x = Math.Max(location.X, 0); x < bg.Width; x++)
                {
                    // Due to translation
                    int fX = x - location.X;

                    // Done with processing all cols of the foreground image
                    if (fX >= fg.Width) break;

                    // Get each pixel from both images
                    Color fgPx = fg.GetPixel(fX, fY);
                    Color bgPx = bg.GetPixel(x, y);
                    
                    // Determining the opacity of both images
                    int aFg = (fgPx.A * opacity / 255);
                    int aBg = bgPx.A;

                    // Combine the background and foreground pixel, using the opacity
                    int r = (fgPx.R * aFg + bgPx.R * (255 - aFg)) / 255;
                    int g = (fgPx.G * aFg + bgPx.G * (255 - aFg)) / 255;
                    int b = (fgPx.B * aFg + bgPx.B * (255 - aFg)) / 255;

                    // Set a new pixel in result image
                    output.SetPixel(x, y, Color.FromArgb(aBg, r, g, b));
                }
            }

            // Well, f*ck it...
            return output;
        }

        /* Mask overlay routine */
        public Bitmap MaskBitmap(Bitmap fg, Bitmap bg, byte opacity, Point location)
        {
            Bitmap output = new Bitmap(bg);

            for (int y = Math.Max(location.Y, 0); y < bg.Height; y++)
            {
                int fY = y - location.Y;

                if (fY >= fg.Height) break;

                for (int x = Math.Max(location.X, 0); x < bg.Width; x++)
                {
                    int fX = x - location.X;

                    if (fX >= fg.Width) break;

                    Color blendPx = fg.GetPixel(fX, fY);
                    Color bgPx = bg.GetPixel(x, y);

                    if (blendPx.A == 0)
                    {
                        output.SetPixel(x, y, bgPx);
                    }
                    else if (blendPx != bgPx)
                    {
                        float opF = blendPx.A / 255f;

                        int r = Math.Max(0, Math.Min(255, (int)((bgPx.R - (opF) * blendPx.R) / (1 - opF))));
                        int g = Math.Max(0, Math.Min(255, (int)((bgPx.G - (opF) * blendPx.G) / (1 - opF))));
                        int b = Math.Max(0, Math.Min(255, (int)((bgPx.B - (opF) * blendPx.B) / (1 - opF))));

                        output.SetPixel(x, y, Color.FromArgb(opacity, r, g, b));
                    }
                }
            }

            return output;
        }
    }
}
