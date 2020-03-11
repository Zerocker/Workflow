using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2C
{
    class RGB
    {
        private double red;
        private double green;
        private double blue;

        public RGB() 
        { 
            red = 0; 
            green = 0; 
            blue = 0;
        }

        public RGB(double r, double g, double b)
        { 
            red = r; 
            green = g; 
            blue = b; 
        }

        public double Red 
        {
            get 
            {
                return red;
            }

            set 
            {
                red = value;
            }
        }

        public double Green
        {
            get
            {
                return green;
            }

            set
            {
                green = value;
            }
        }

        public double Blue
        {
            get
            {
                return blue;
            }

            set
            {
                blue = value;
            }
        }

        public HSV ToHSV() 
        {
            HSV hsvColor = new HSV();

            double r = Red / 255.0;
            double g = Green / 255.0;
            double b = Blue / 255.0;

            double cmax = Math.Max(r, Math.Max(g, b)); // maximum of r, g, b 
            double cmin = Math.Min(r, Math.Min(g, b)); // minimum of r, g, b 
            double diff = cmax - cmin; // diff of cmax and cmin. 
            double h = -1, s = -1;

            // if cmax and cmax are equal then h = 0 
            if (cmax == cmin)
                h = 0;

            // if cmax equal r then compute h 
            else if (cmax == r)
                h = (60 * ((g - b) / diff) + 360) % 360;

            // if cmax equal g then compute h 
            else if (cmax == g)
                h = (60 * ((b - r) / diff) + 120) % 360;

            // if cmax equal b then compute h 
            else if (cmax == b)
                h = (60 * ((r - g) / diff) + 240) % 360;

            // if cmax equal zero 
            if (cmax == 0)
                s = 0;
            else
                s = (diff / cmax) * 100;

            // compute v 
            double v = cmax * 100;

            hsvColor.Hue = h;
            hsvColor.Saturation = s;
            hsvColor.Value = v;

            return hsvColor;
        }

        public CMYK ToCMYK()
        {
            CMYK cmykColor = new CMYK();
            cmykColor.Black = (1 - Math.Max(Red/255, (Math.Max(Green/255, Blue/255))));
            if (cmykColor.Black != 1) 
            {
                cmykColor.Cyan = ((1 - Red / 255 - cmykColor.Black) / (1 - cmykColor.Black));
                cmykColor.Magenta = ((1 - Green / 255 - cmykColor.Black) / (1 - cmykColor.Black));
                cmykColor.Yellow = ((1 - Blue / 255 - cmykColor.Black) / (1 - cmykColor.Black));

                cmykColor.Black *= 100;
                cmykColor.Cyan *= 100;
                cmykColor.Magenta *= 100;
                cmykColor.Yellow *= 100;
            }
            

            return cmykColor;
        }

        public Color ToColor()
        {
            return Color.FromArgb(Convert.ToInt32(Red), Convert.ToInt32(Green), Convert.ToInt32(Blue));
        }
    }
}
