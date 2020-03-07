using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Schemes
{
    public class Cmyk : ICloneable
    {
		private double _cyan;
		private double _magenta;
		private double _yellow;
		private double _key;

		public Cmyk(double c, double m, double y, double k)
		{
			this._cyan = c;
			this._magenta = m;
			this._yellow = y;
			this._key = k;
		}

		public double C
		{
			get { return this._cyan; }
			set { this._cyan = value; }
		}

		public double M
		{
			get { return this._magenta; }
			set { this._magenta = value; }
		}

		public double Y
		{
			get { return this._yellow; }
			set { this._yellow = value; }
		}

		public double K
		{
			get { return this._key; }
			set { this._key = value; }
		}

		public bool Equals(Cmyk cmyk)
		{
			return (this.C == cmyk.C) && (this.M == cmyk.M) && (this.Y == cmyk.Y) && (this.K == cmyk.K);
		}

		public override string ToString()
		{
			return $"cmyk({C}, {M}, {Y}, {K})";
		}

		public Rgb ToRgb()
		{
			byte r = (byte)(255 * (1 - C / 100d) * (1 - K / 100d));
			byte g = (byte)(255 * (1 - M / 100d) * (1 - K / 100d));
			byte b = (byte)(255 * (1 - Y / 100d) * (1 - K / 100d));

			return new Rgb(r, g, b);
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
