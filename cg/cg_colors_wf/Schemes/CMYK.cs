using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2C
{
    class CMYK
    {
        private double cyan;             // 0..100
        private double magenta;       // 0..100
        private double yellow;            // 0..100
        private double black;         // 0..100        

        public CMYK()
        { 
            cyan = 0.0; 
            magenta = 0.0; 
            yellow = 0.0; 
            black = 0.0; 
        }

        public CMYK(double c, double m, double y, double k) 
        { 
            cyan = c; 
            magenta = m; 
            yellow = y; 
            black = k; 
        }

        public double Cyan
        {
            get
            {
                return cyan;
            }

            set
            {
                cyan = value;
            }
        }

        public double Magenta
        {
            get
            {
                return magenta;
            }

            set
            {
                magenta = value;
            }
        }

        public double Yellow
        {
            get
            {
                return yellow;
            }

            set
            {
                yellow = value;
            }
        }

        public double Black
        {
            get
            {
                return black;
            }

            set
            {
                black = value;
            }
        }

        public RGB ToRGB()
        {
            RGB rgbColor = new RGB();
            rgbColor.Red = 255 * (1 - Cyan/100) * (1 - Black/100);
            rgbColor.Green = 255 * (1 - Magenta/100) * (1 - Black/100);
            rgbColor.Blue = 255 * (1 - Yellow/100) * (1 - Black/100);

            return rgbColor;
        }
    }
}
