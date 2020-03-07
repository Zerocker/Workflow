using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab.Schemes
{
    public class Rgb : ICloneable
    {
        private byte _red;
        private byte _green;
        private byte _blue;

        public Rgb(byte red, byte green, byte blue)
        {
            _red = red;
            _green = green;
            _blue = blue;
        }

        public Rgb(Color color)
        {
            _red = color.R;
            _green = color.G;
            _blue = color.B;
        }

        public byte R
        {
            get { return _red; }
            set { _red = value; }
        }

        public byte G
        {
            get { return _green; }
            set { _green = value; }
        }

        public byte B
        {
            get { return _blue; }
            set { _blue = value; }
        }

        public bool Equals(Rgb rgb)
        {
            return (R == rgb.R) && (G == rgb.G) && (B == rgb.B);
        }

        public override string ToString()
        {
            return $"rgb({R}, {G}, {B})";
        }

        public Cmyk ToCmyk()
        {
            double Clamp(double value)
            {
                return (value < 0 || double.IsNaN(value)) ? 0 : value;
            }
            
            double dr = (double)R / 255f;
            double dg = (double)G / 255f;
            double db = (double)B / 255f;
            
            double k = 1 - Math.Max(Math.Max(dr, dg), db);
            double c = (1 - dr - k) / (1 - k);
            double m = (1 - dg - k) / (1 - k);
            double y = (1 - db - k) / (1 - k);

            k = Clamp(k);
            c = Clamp(c);
            m = Clamp(m);
            y = Clamp(y);

            return new Cmyk(c, m, y, k);
        }

        public Color ToColor()
        {
            return Color.FromRgb(R, G, B);
        }

        public Hsv ToHsv()
        {
            double r = R / 255d;
            double g = G / 255d;
            double b = B / 255d;
            double h = 0, s, v;

            var max = new[] { r, g, b }.Max();
            var min = new[] { r, g, b }.Min();
            var delta = max - min;

            s = max != 0 ? delta / max : 0;
            v = max;

            if (s == 0)
                return new Hsv(h, s, v);

            if (r == max)
                h = ((g - b) / delta);
            else if (g == max)
                h = ((b - r) / delta) + 2.0;
            else if (b == max)
                h = ((r - g) / delta) + 4.0;
            
            h *= 60.0;
            if (h < 0)
                h += 360.0;

            return new Hsv(h, s, v);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
