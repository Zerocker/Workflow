using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C2C
{
    public partial class MainForm : Form
    {
        RGB _rgb = new RGB();
        HSV _hsv = new HSV();
        CMYK _cmyk = new CMYK();
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            redBox.Value = redSlider.Value;

            _rgb.Red = redSlider.Value;
            DrawRect(rgbRect, _rgb);

            _hsv = _rgb.ToHSV();

            hueSlider.Value = Convert.ToInt32(_hsv.Hue);
            hueBox.Value = hueSlider.Value;
            satSlider.Value = Convert.ToInt32(_hsv.Saturation);
            satBox.Value = satSlider.Value;
            valueSlider.Value = Convert.ToInt32(_hsv.Value);
            valueBox.Value = valueSlider.Value;

            RGB tempRGB = _hsv.ToRGB();
            DrawRect(hsvRect, tempRGB);

            _cmyk = _rgb.ToCMYK();

            cyanSlider.Value = Convert.ToInt32(_cmyk.Cyan);
            cyanBox.Value = cyanSlider.Value;
            magentaSlider.Value = Convert.ToInt32(_cmyk.Magenta);
            magentaBox.Value = magentaSlider.Value;
            yellowSlider.Value = Convert.ToInt32(_cmyk.Yellow);
            yellowBox.Value = yellowSlider.Value;
            blackSlider.Value = Convert.ToInt32(_cmyk.Black);
            blackBox.Value = blackSlider.Value;
            
            RGB tempRGB2 = _cmyk.ToRGB();
            DrawRect(cmykRect, tempRGB2);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            greenBox.Value = greenSlider.Value;

            _rgb.Green = greenSlider.Value;
            DrawRect(rgbRect, _rgb);

            _hsv = _rgb.ToHSV();
            hueSlider.Value = Convert.ToInt32(_hsv.Hue);
            hueBox.Value = hueSlider.Value;
            satSlider.Value = Convert.ToInt32(_hsv.Saturation);
            satBox.Value = satSlider.Value;
            valueSlider.Value = Convert.ToInt32(_hsv.Value);
            valueBox.Value = valueSlider.Value;
            RGB tempRGB = _hsv.ToRGB();
            DrawRect(hsvRect, tempRGB);

            _cmyk = _rgb.ToCMYK();
            // 7 8 9 13
            cyanSlider.Value = Convert.ToInt32(_cmyk.Cyan);
            cyanBox.Value = cyanSlider.Value;
            magentaSlider.Value = Convert.ToInt32(_cmyk.Magenta);
            magentaBox.Value = magentaSlider.Value;
            yellowSlider.Value = Convert.ToInt32(_cmyk.Yellow);
            yellowBox.Value = yellowSlider.Value;
            blackSlider.Value = Convert.ToInt32(_cmyk.Black);
            blackBox.Value = blackSlider.Value;
            RGB tempRGB2 = _cmyk.ToRGB();
            DrawRect(cmykRect, tempRGB2);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            blueBox.Value = blueSlider.Value;

            _rgb.Blue = blueSlider.Value;
            DrawRect(rgbRect, _rgb);

            _hsv = _rgb.ToHSV();
            hueSlider.Value = Convert.ToInt32(_hsv.Hue);
            hueBox.Value = hueSlider.Value;
            satSlider.Value = Convert.ToInt32(_hsv.Saturation);
            satBox.Value = satSlider.Value;
            valueSlider.Value = Convert.ToInt32(_hsv.Value);
            valueBox.Value = valueSlider.Value;
            RGB tempRGB = _hsv.ToRGB();
            DrawRect(hsvRect, tempRGB);

            _cmyk = _rgb.ToCMYK();
            // 7 8 9 13
            cyanSlider.Value = Convert.ToInt32(_cmyk.Cyan);
            cyanBox.Value = cyanSlider.Value;
            magentaSlider.Value = Convert.ToInt32(_cmyk.Magenta);
            magentaBox.Value = magentaSlider.Value;
            yellowSlider.Value = Convert.ToInt32(_cmyk.Yellow);
            yellowBox.Value = yellowSlider.Value;
            blackSlider.Value = Convert.ToInt32(_cmyk.Black);
            blackBox.Value = blackSlider.Value;
            RGB tempRGB2 = _cmyk.ToRGB();
            DrawRect(cmykRect, tempRGB2);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            hueBox.Value = hueSlider.Value;

            _hsv.Hue = hueSlider.Value;
            _rgb = _hsv.ToRGB();

            redSlider.Value = Convert.ToInt32(_rgb.Red);
            redBox.Value = redSlider.Value;
            greenSlider.Value = Convert.ToInt32(_rgb.Green);
            greenBox.Value = greenSlider.Value;
            blueSlider.Value = Convert.ToInt32(_rgb.Blue);
            blueBox.Value = blueSlider.Value;
            DrawRect(hsvRect, _rgb);

            DrawRect(cmykRect, _rgb.ToCMYK().ToRGB());

        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            satBox.Value = satSlider.Value;

            _hsv.Saturation = satSlider.Value;
            _rgb = _hsv.ToRGB();

            redSlider.Value = Convert.ToInt32(_rgb.Red);
            redBox.Value = redSlider.Value;
            greenSlider.Value = Convert.ToInt32(_rgb.Green);
            greenBox.Value = greenSlider.Value;
            blueSlider.Value = Convert.ToInt32(_rgb.Blue);
            blueBox.Value = blueSlider.Value;
            DrawRect(hsvRect, _rgb);

            DrawRect(cmykRect, _rgb.ToCMYK().ToRGB());
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            valueBox.Value = valueSlider.Value;

            _hsv.Value = valueSlider.Value;
            _rgb = _hsv.ToRGB();

            redSlider.Value = Convert.ToInt32(_rgb.Red);
            redBox.Value = redSlider.Value;
            greenSlider.Value = Convert.ToInt32(_rgb.Green);
            greenBox.Value = greenSlider.Value;
            blueSlider.Value = Convert.ToInt32(_rgb.Blue);
            blueBox.Value = blueSlider.Value;
            DrawRect(hsvRect, _rgb);

            DrawRect(cmykRect, _rgb.ToCMYK().ToRGB());
        }
  
        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            cyanBox.Value = cyanSlider.Value;
            _cmyk.Cyan = cyanSlider.Value;
            RGB tempRGB = _cmyk.ToRGB();
            DrawRect(cmykRect, tempRGB);

            redSlider.Value = Convert.ToInt32(tempRGB.Red);
            greenSlider.Value = Convert.ToInt32(tempRGB.Green);
            blueSlider.Value = Convert.ToInt32(tempRGB.Blue);
            DrawRect(rgbRect, tempRGB);

            HSV tempHSV = tempRGB.ToHSV();
            hueSlider.Value = Convert.ToInt32(tempHSV.Hue);
            satSlider.Value = Convert.ToInt32(tempHSV.Saturation);
            valueSlider.Value = Convert.ToInt32(tempHSV.Value);
            DrawRect(hsvRect, tempHSV.ToRGB());
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            magentaBox.Value = magentaSlider.Value;
            _cmyk.Magenta = magentaSlider.Value;
            RGB tempRGB = _cmyk.ToRGB();
            DrawRect(cmykRect, tempRGB);

            redSlider.Value = Convert.ToInt32(tempRGB.Red);
            redBox.Value = redSlider.Value;
            greenSlider.Value = Convert.ToInt32(tempRGB.Green);
            greenBox.Value = greenSlider.Value;
            blueSlider.Value = Convert.ToInt32(tempRGB.Blue);
            blueBox.Value = blueSlider.Value;
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            yellowBox.Value = yellowSlider.Value;
            _cmyk.Yellow = yellowSlider.Value;
            RGB tempRGB = _cmyk.ToRGB();
            DrawRect(cmykRect, tempRGB);

            redSlider.Value = Convert.ToInt32(tempRGB.Red);
            redBox.Value = redSlider.Value;
            greenSlider.Value = Convert.ToInt32(tempRGB.Green);
            greenBox.Value = greenSlider.Value;
            blueSlider.Value = Convert.ToInt32(tempRGB.Blue);
            blueBox.Value = blueSlider.Value;
        }

        private void trackBar13_Scroll(object sender, EventArgs e)
        {
            blackBox.Value = blackSlider.Value;
            _cmyk.Black = blackSlider.Value;
            RGB tempRGB = _cmyk.ToRGB();
            DrawRect(cmykRect, tempRGB);

            redSlider.Value = Convert.ToInt32(tempRGB.Red);
            redBox.Value = redSlider.Value;
            greenSlider.Value = Convert.ToInt32(tempRGB.Green);
            greenBox.Value = greenSlider.Value;
            blueSlider.Value = Convert.ToInt32(tempRGB.Blue);
            blueBox.Value = blueSlider.Value;
        }

        private void DrawRect(Panel panel, RGB rgb)
        {
            panel.BackColor = rgb.ToColor();

        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _rgb.Red = redSlider.Value;
            _rgb.Green = greenSlider.Value;
            _rgb.Blue = blueSlider.Value;

            _hsv.Hue = hueSlider.Value;
            _hsv.Saturation = satSlider.Value;
            _hsv.Value = valueSlider.Value;

            _cmyk.Cyan = cyanSlider.Value;
            _cmyk.Magenta = magentaSlider.Value;
            _cmyk.Yellow = yellowSlider.Value;
            _cmyk.Black = blackSlider.Value;
        }

        

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            redSlider.Value = Convert.ToInt32(redBox.Value);

            _rgb.Red = redSlider.Value;
            DrawRect(rgbRect, _rgb);

            _hsv = _rgb.ToHSV();

            hueSlider.Value = Convert.ToInt32(_hsv.Hue);
            satSlider.Value = Convert.ToInt32(_hsv.Saturation);
            valueSlider.Value = Convert.ToInt32(_hsv.Value);

            hueBox.Value = Convert.ToInt32(_hsv.Hue);
            satBox.Value = Convert.ToInt32(_hsv.Saturation);
            valueBox.Value = Convert.ToInt32(_hsv.Value);

            RGB tempRGB = _hsv.ToRGB();
            DrawRect(hsvRect, tempRGB);

            _cmyk = _rgb.ToCMYK();
            cyanSlider.Value = Convert.ToInt32(_cmyk.Cyan);
            magentaSlider.Value = Convert.ToInt32(_cmyk.Magenta);
            yellowSlider.Value = Convert.ToInt32(_cmyk.Yellow);
            blackSlider.Value = Convert.ToInt32(_cmyk.Black);

            cyanBox.Value = Convert.ToInt32(_cmyk.Cyan);
            magentaBox.Value = Convert.ToInt32(_cmyk.Magenta);
            yellowBox.Value = Convert.ToInt32(_cmyk.Yellow);
            blackBox.Value = Convert.ToInt32(_cmyk.Black);

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            greenSlider.Value = Convert.ToInt32(greenBox.Value);

            _rgb.Green = greenSlider.Value;
            DrawRect(rgbRect, _rgb);

            _hsv = _rgb.ToHSV();

            hueSlider.Value = Convert.ToInt32(_hsv.Hue);
            satSlider.Value = Convert.ToInt32(_hsv.Saturation);
            valueSlider.Value = Convert.ToInt32(_hsv.Value);

            hueBox.Value = Convert.ToInt32(_hsv.Hue);
            satBox.Value = Convert.ToInt32(_hsv.Saturation);
            valueBox.Value = Convert.ToInt32(_hsv.Value);

            RGB tempRGB = _hsv.ToRGB();
            DrawRect(hsvRect, tempRGB);

            _cmyk = _rgb.ToCMYK();
            cyanSlider.Value = Convert.ToInt32(_cmyk.Cyan);
            magentaSlider.Value = Convert.ToInt32(_cmyk.Magenta);
            yellowSlider.Value = Convert.ToInt32(_cmyk.Yellow);
            blackSlider.Value = Convert.ToInt32(_cmyk.Black);

            cyanBox.Value = Convert.ToInt32(_cmyk.Cyan);
            magentaBox.Value = Convert.ToInt32(_cmyk.Magenta);
            yellowBox.Value = Convert.ToInt32(_cmyk.Yellow);
            blackBox.Value = Convert.ToInt32(_cmyk.Black);

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            blueSlider.Value = Convert.ToInt32(blueBox.Value);

            _rgb.Blue = blueSlider.Value;
            DrawRect(rgbRect, _rgb);

            _hsv = _rgb.ToHSV();

            hueSlider.Value = Convert.ToInt32(_hsv.Hue);
            satSlider.Value = Convert.ToInt32(_hsv.Saturation);
            valueSlider.Value = Convert.ToInt32(_hsv.Value);

            hueBox.Value = Convert.ToInt32(_hsv.Hue);
            satBox.Value = Convert.ToInt32(_hsv.Saturation);
            valueBox.Value = Convert.ToInt32(_hsv.Value);

            RGB tempRGB = _hsv.ToRGB();
            DrawRect(hsvRect, tempRGB);

            _cmyk = _rgb.ToCMYK();
            cyanSlider.Value = Convert.ToInt32(_cmyk.Cyan);
            magentaSlider.Value = Convert.ToInt32(_cmyk.Magenta);
            yellowSlider.Value = Convert.ToInt32(_cmyk.Yellow);
            blackSlider.Value = Convert.ToInt32(_cmyk.Black);

            cyanBox.Value = Convert.ToInt32(_cmyk.Cyan);
            magentaBox.Value = Convert.ToInt32(_cmyk.Magenta);
            yellowBox.Value = Convert.ToInt32(_cmyk.Yellow);
            blackBox.Value = Convert.ToInt32(_cmyk.Black);

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            hueSlider.Value = Convert.ToInt32(hueBox.Value);

            _hsv.Hue = hueSlider.Value;
            _rgb = _hsv.ToRGB();

            redSlider.Value = Convert.ToInt32(_rgb.Red);
            redBox.Value = redSlider.Value;
            greenSlider.Value = Convert.ToInt32(_rgb.Green);
            greenBox.Value = greenSlider.Value;
            blueSlider.Value = Convert.ToInt32(_rgb.Blue);
            blueBox.Value = blueSlider.Value;
            DrawRect(hsvRect, _rgb);

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            satSlider.Value = Convert.ToInt32(satBox.Value);

            satBox.Value = satSlider.Value;

            _hsv.Saturation = satSlider.Value;
            _rgb = _hsv.ToRGB();

            redSlider.Value = Convert.ToInt32(_rgb.Red);
            redBox.Value = redSlider.Value;
            greenSlider.Value = Convert.ToInt32(_rgb.Green);
            greenBox.Value = greenSlider.Value;
            blueSlider.Value = Convert.ToInt32(_rgb.Blue);
            blueBox.Value = blueSlider.Value;
            DrawRect(hsvRect, _rgb);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            valueSlider.Value = Convert.ToInt32(valueBox.Value);

            valueBox.Value = valueSlider.Value;

            _hsv.Value = valueSlider.Value;
            _rgb = _hsv.ToRGB();

            redSlider.Value = Convert.ToInt32(_rgb.Red);
            redBox.Value = redSlider.Value;
            greenSlider.Value = Convert.ToInt32(_rgb.Green);
            greenBox.Value = greenSlider.Value;
            blueSlider.Value = Convert.ToInt32(_rgb.Blue);
            blueBox.Value = blueSlider.Value;
            DrawRect(hsvRect, _rgb);
        }
    }
}
