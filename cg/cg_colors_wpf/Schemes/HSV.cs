using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Schemes
{
    public class Hsv : ICloneable
	{
		private double _hue;
		private double _saturation;
		private double _value;

		public Hsv(double h, double s, double v)
		{
			this._hue = h;
			this._saturation = s;
			this._value = v;
		}

		public double H
		{
			get { return this._hue; }
			set { this._hue = value; }
		}

		public double S
		{
			get { return this._saturation; }
			set { this._saturation = value; }
		}

		public double V
		{
			get { return this._value; }
			set { this._value = value; }
		}

		public bool Equals(Hsv hsv)
		{
			return (this.H == hsv.H) && (this.S == hsv.S) && (this.V == hsv.V);
		}

		public override string ToString()
		{
			return $"hsv({H}, {S}, {V})";
		}

		public Rgb ToRgb()
		{
			double h = H, s = S / 100d, vx = V / 100d;
			
			int hi = Convert.ToInt32(Math.Floor(h / 60d)) % 6;
			double f = h / 60d - Math.Floor(h / 60d);

			vx *= 255d;
			int v = Convert.ToInt32(vx);
			int p = Convert.ToInt32(vx * (1 - s));
			int q = Convert.ToInt32(vx * (1 - f * s));
			int t = Convert.ToInt32(vx * (1 - (1 - f) * s));

			switch (hi)
			{
				case 0:
					return new Rgb((byte)v, (byte)t, (byte)p);
				case 1:
					return new Rgb((byte)q, (byte)v, (byte)p);
				case 2:
					return new Rgb((byte)p, (byte)v, (byte)t);
				case 3:
					return new Rgb((byte)p, (byte)q, (byte)v);
				case 4:
					return new Rgb((byte)t, (byte)p, (byte)v);
				default:
					return new Rgb((byte)v, (byte)p, (byte)q);
			}
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
