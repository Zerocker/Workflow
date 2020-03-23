using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Lines
{
    public class Draw
    {
		public Bitmap Canvas { get; private set; }

		public Draw(int width, int height)
		{
			Canvas = new Bitmap(width, height);
		}

		public void DrawPixel(Point a, Color color)
		{
			var x = a.X;
			var y = a.Y;
			
			Canvas.SetPixel(a.X, a.Y, color);

			Canvas.SetPixel(x - 1, y - 1, color);
			Canvas.SetPixel(x - 1, y, color);
			Canvas.SetPixel(x - 1, y + 1, color);
			Canvas.SetPixel(x, y - 1, color);
			Canvas.SetPixel(x, y + 1, color);
			Canvas.SetPixel(x + 1, y - 1, color);
			Canvas.SetPixel(x + 1, y, color);
			Canvas.SetPixel(x + 1, y + 1, color);
		}

		public void DrawRect(Point a, int width, int height, Color color)
		{
			using (Graphics gfx = Graphics.FromImage(Canvas))
			using (SolidBrush brush = new SolidBrush(color))
			{
				gfx.FillRectangle(brush, 0, 0, width, height);
			}
		}

		public void LineDDA(Point A, Point B, Color color)
        {
			int deltaX = Math.Abs(A.X - B.X);
			int deltaY = Math.Abs(A.Y - B.Y);
			int length = (deltaX >= deltaY) ? deltaX : deltaY;

			if (length == 0)
			{
				Canvas.SetPixel(A.X, A.Y, Color.Black);
				return;
			}

			double dX = (double)(B.X - A.X) / length;
			double dY = (double)(B.Y - A.Y) / length;

			double x = A.X;
			double y = A.Y;

			while (length > 0)
			{
				x += dX;
				y += dY;
				Canvas.SetPixel((int)x, (int)y, color);

				length--;
			}
		}

		public void LineBresenham(Point A, Point B, Color color)
		{
			int sX = (B.X >= A.X) ? 1 : -1;
			int sY = (B.Y >= A.Y) ? 1 : -1;

			int dX = (B.X > A.X) ? (B.X - A.X) : (A.X - B.X);
			int dY = (B.Y > A.Y) ? (B.Y - A.Y) : (A.Y - B.Y);

			if (dY < dX)
			{
				int d = (dY << 1) - dX;
				int d1 = dY << 1;
				int d2 = (dY - dX) << 1;

				DrawPixel(A, color);
				int x = A.X + sX;
				int y = A.Y;

				for (int i = 1; i <= dX; i++)
				{
					if (d > 0)
					{
						d += d2;
						y += sY;
					}
					else
						d += d1;
					DrawPixel(new Point(x, y), color);
					x += sX;
				}
			}
			else
			{
				int d = (dX << 1) - dY;
				int d1 = dX << 1;
				int d2 = (dX - dY) << 1;

				DrawPixel(A, color);
				int x = A.X;
				int y = A.Y + sY;

				for (int i = 1; i <= dY; i++)
				{
					if (d > 0)
					{
						d += d2;
						x += sX;
					}
					else
						d += d1;
					DrawPixel(new Point(x, y), color);
					y += sY;
				}
			}
		}

		public void Circle(Point center, int radius, Color color)
		{
			int x = 0, y = radius;
			int d = 3 - 2 * radius;
			int u = 6;
			int v = 10 - 4 * radius;
			SetEllipsePixels(center.X, center.Y, x, y, color);

			while (y >= x)
			{
				x++;

				if (d < 0)
				{
					d += u;
					u += 4;
					v += 4;
				}
				else
				{
					y--;
					d += v;
					u += 4;
					v += 8;
				}
					
				SetEllipsePixels(center.X, center.Y, x, y, color);
			}
		}

		public void Triagle(Point p1, Point p2, Point p3)
		{
			var rnd = new Random();
			
			if (p2.Y < p1.Y)
				Swap(ref p1, ref p2);

			if (p3.Y < p1.Y)
				Swap(ref p1, ref p3);

			if (p2.Y < p3.Y)
				Swap(ref p2, ref p3);

			double dxAC = ((double)p3.X - (double)p1.X) / ((double)p3.Y - (double)p1.Y);
			double dxAB = ((double)p2.X - (double)p1.X) / ((double)p2.Y - (double)p1.Y);
			double dxBC = ((double)p3.X - (double)p2.X) / ((double)p3.Y - (double)p2.Y);

			double x1 = p1.X;
			double x2 = p1.X;

			for (int i = p1.Y; i < p3.Y; i++)
			{
				x1 += dxAB;
				x2 += dxAC;

				LineBresenham(
					new Point(Convert.ToInt32(Math.Round(x1)), i),
					new Point(Convert.ToInt32(Math.Round(x2)), i), GetRandomColor(ref rnd));
			}

			for (int i = p3.Y; i < p2.Y; i++)
			{
				x1 += dxAB;
				x2 += dxBC;

				LineBresenham(
					new Point(Convert.ToInt32(Math.Round(x1)), i),
					new Point(Convert.ToInt32(Math.Round(x2)), i), GetRandomColor(ref rnd));
			}
		}

		private static double Roundf(double x)
		{
			return Math.Floor(x) + 0.5d;
		}

		private static void Swap<T>(ref T lhs, ref T rhs)
		{
			T temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		public static Color GetRandomColor(ref Random rnd)
		{
			return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
		}

		public void FillFour(Point point, Color bg, Color fill)
		{
			Stack<Point> neighbors = new Stack<Point>();
			bg = Canvas.GetPixel(point.X, point.Y);
			neighbors.Push(point);

			while (neighbors.Count > 0)
			{
				var a = neighbors.Pop();
				if (a.X < Canvas.Width && a.X > 0 && a.Y < Canvas.Height && a.Y > 0)
				{
					if (Canvas.GetPixel(a.X, a.Y) == bg)
					{
						Canvas.SetPixel(a.X, a.Y, fill);
						neighbors.Push(new Point(a.X - 1, a.Y));
						neighbors.Push(new Point(a.X + 1, a.Y));
						neighbors.Push(new Point(a.X, a.Y - 1));
						neighbors.Push(new Point(a.X, a.Y + 1));
					}
				}
			}
		}

		public void FillEight(Point point, Color bg, Color fill)
		{
			List<int> dX = new List<int> { 0, 1, 1, 1, 0, -1, -1, -1 };
			List<int> dY = new List<int> { -1, -1, 0, 1, 1, 1, 0, -1 };

			Stack<Point> neighbors = new Stack<Point>(); neighbors.Push(point);
			bg = Canvas.GetPixel(point.X, point.Y);

			while (neighbors.Count > 0)
			{
				var a = neighbors.Pop();
				Canvas.SetPixel(a.X, a.Y, fill);

				for (int i = 0; i < dX.Count; i++)
				{
					int nX = a.X + dX[i];
					int nY = a.Y + dY[i];

					if (nX < Canvas.Width && nX > 0 && nY < Canvas.Height && nY > 0 && Canvas.GetPixel(nX, nY) == bg)
					{
						neighbors.Push(new Point(nX, nY));
					}
				}
			}
		}

		public void FillRandom(Point point, Color bg)
		{
			Random rnd = new Random();
			Stack<Point> neighbors = new Stack<Point>();
			bg = Canvas.GetPixel(point.X, point.Y);
			neighbors.Push(point);

			while (neighbors.Count > 0)
			{
				var a = neighbors.Pop();
				if (a.X < Canvas.Width && a.X > 0 && a.Y < Canvas.Height && a.Y > 0)
				{
					if (Canvas.GetPixel(a.X, a.Y) == bg)
					{
						var fill = GetRandomColor(ref rnd);
						Canvas.SetPixel(a.X, a.Y, fill);
						neighbors.Push(new Point(a.X - 1, a.Y));
						neighbors.Push(new Point(a.X + 1, a.Y));
						neighbors.Push(new Point(a.X, a.Y - 1));
						neighbors.Push(new Point(a.X, a.Y + 1));
					}
				}
			}
		}

		public void Clear()
		{
			DrawRect(new Point(0, 0), Canvas.Width, Canvas.Height, Color.White);
		}

		public void NewEllipse(Point center, int a, int b, Color color)
		{
			int col, row;
			long sqrA, sqrB, twoSqrA, twoSqrB, fourSqrA, fourSqrB, d;

			sqrB = b * b;
			sqrA = a * a;
			row = b;
			col = 0;
			twoSqrA = sqrA << 1;
			fourSqrA = sqrA << 2;
			fourSqrB = sqrB << 2;
			twoSqrB = sqrB << 1;
			d = twoSqrA * ((row - 1) * (row)) + sqrA + twoSqrB * (1 - sqrA);

			while (sqrA * (row) > sqrB * (col))
			{
				SetEllipsePixels(center.X, center.Y, col, row, color, false);
				if (d >= 0)
				{
					row--;
					d -= fourSqrA * (row);
				}
				d += twoSqrB * (3 + (col << 1));
				col++;
			}

			d = twoSqrB * (col + 1) * col + twoSqrA * (row * (row - 2) + 1) + (1 - twoSqrA) * sqrB;
			while ((row) + 1 > 0)
			{
				SetEllipsePixels(center.X, center.Y, col, row, color, false);
				if (d <= 0)
				{
					col++;
					d += fourSqrB * col;
				}
				row--;
				d += twoSqrA * (3 - (row << 1));
			}
		}

		public void Ellipse(Point center, int a, int b, Color color)
		{
			int x = 0, y = b;
			int d = 0;
			int u = 12 * b;
			int v = 12 * b + 8 * a;
			int l = a * b;
			SetEllipsePixels(center.X, center.Y, x, y, color);

			while (x <= y)
			{
				x++;

				if (d < 0)
				{
					d += u;
					u += 8 * b;
					v += 8 * a;
					l -= b;
				}
				else
				{
					y--;
					d += v;
					u += 8 * b;
					v += 8 * (b + a);
					l -= (b + a);
				}
				SetEllipsePixels(center.X, center.Y, x, y, color);
			}
		}

		private void SetEllipsePixels(int xc, int yc, int x, int y, Color color, bool both = true)
		{
			Canvas.SetPixel(xc + x, yc + y, color);
			Canvas.SetPixel(xc - x, yc + y, color);
			Canvas.SetPixel(xc + x, yc - y, color);
			Canvas.SetPixel(xc - x, yc - y, color);
			
			if (both)
			{
				Canvas.SetPixel(xc + y, yc + x, color);
				Canvas.SetPixel(xc - y, yc + x, color);
				Canvas.SetPixel(xc + y, yc - x, color);
				Canvas.SetPixel(xc - y, yc - x, color);
			}
		}

		public static Color[] GetArne16Palette()
		{
			return new[]
			{
			   Color.FromArgb(0, 0, 0),
			   Color.FromArgb(157, 157, 157),
			   Color.FromArgb(255, 255, 255),
			   Color.FromArgb(190, 38, 51),
			   Color.FromArgb(224, 111, 139),
			   Color.FromArgb(73, 60, 43),
			   Color.FromArgb(164, 100, 34),
			   Color.FromArgb(235, 137, 49),
			   Color.FromArgb(247, 226, 107),
			   Color.FromArgb(47, 72, 78),
			   Color.FromArgb(68, 137, 26),
			   Color.FromArgb(163, 206, 39),
			   Color.FromArgb(27, 38, 50),
			   Color.FromArgb(0, 87, 132),
			   Color.FromArgb(49, 162, 242),
			   Color.FromArgb(178, 220, 239)
			};
		}
    }
}
