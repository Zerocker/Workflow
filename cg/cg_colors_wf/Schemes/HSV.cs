using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2C
{
    class HSV
    {
        private double hue;
        private double saturation;
        private double value;

        public HSV() 
        { 
            hue = 0.0; 
            saturation = 0.0; 
            value = 0.0; 
        }

        public HSV(double h, double s, double v) 
        { 
            hue = h;
            saturation = s;
            value = v;
        }

        public double Hue
        {
            get
            {
                return hue;
            }

            set
            {
                hue = value;
            }
        }

        public double Saturation
        {
            get
            {
                return saturation;
            }

            set
            {
                saturation = value;
            }
        }

        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public RGB ToRGB()
        {
            int i;
            double f, p, q, t;
            RGB rgbColor = new RGB();

            double h = Hue / 360;
            double s = Saturation / 100;
            double v = Value / 100;

            if (s == 0)
            {
                rgbColor.Red = rgbColor.Green = rgbColor.Blue = Math.Round(v * 255);
                return rgbColor;
            }

            i = Convert.ToInt32(Math.Floor(h * 6));
            f = h * 6 - i;
            p = v * (1 - s);
            q = v * (1 - s * f);
            t = v * (1 - s * (1 - f));
            switch (i % 6)
            {
                case 0:
                    rgbColor.Red = Math.Round(255 * v);
                    rgbColor.Green = Math.Round(255 * t);
                    rgbColor.Blue = Math.Round(255 * p);
                    return rgbColor;
                case 1:
                    rgbColor.Red = Math.Round(255 * q);
                    rgbColor.Green = Math.Round(255 * v);
                    rgbColor.Blue = Math.Round(255 * p);
                    return rgbColor;
                case 2:
                    rgbColor.Red = Math.Round(255 * p);
                    rgbColor.Green = Math.Round(255 * v);
                    rgbColor.Blue = Math.Round(255 * t);
                    return rgbColor;
                case 3:
                    rgbColor.Red = Math.Round(255 * p);
                    rgbColor.Green = Math.Round(255 * q);
                    rgbColor.Blue = Math.Round(255 * v);
                    return rgbColor;
                case 4:
                    rgbColor.Red = Math.Round(255 * t);
                    rgbColor.Green = Math.Round(255 * p);
                    rgbColor.Blue = Math.Round(255 * v);
                    return rgbColor;
                default:
                    rgbColor.Red = Math.Round(255 * v);
                    rgbColor.Green = Math.Round(255 * p);
                    rgbColor.Blue = Math.Round(255 * q);
                    return rgbColor;
            }

        }
    }
}
