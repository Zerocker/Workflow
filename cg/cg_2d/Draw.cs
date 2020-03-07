using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Lines
{
    public class Draw
    {
		public Bitmap Canvas { get; private set; }
		public Color CurrentColor { get; set; }

		public Draw(int width, int height)
		{
			Canvas = new Bitmap(width, height);
		}

		public static void ApplyTransformation(Graphics graphics, int width, int height)
		{
			Matrix matrix = new Matrix();

			matrix.Translate(width / 2, height / 2);


		}

		public void LineDDA(Point A, Point B)
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
				Canvas.SetPixel((int)x, (int)y, CurrentColor);

				length--;
			}
		}

		public void LineBresenham(Point A, Point B)
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

				Canvas.SetPixel(A.X, A.Y, CurrentColor);
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
					Canvas.SetPixel(x, y, CurrentColor);
					x += sX;
				}
			}
			else
			{
				int d = (dX << 1) - dY;
				int d1 = dX << 1;
				int d2 = (dX - dY) << 1;

				Canvas.SetPixel(A.X, A.Y, CurrentColor);
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
					Canvas.SetPixel(x, y, CurrentColor);
					y += sY;
				}
			}
		}

		public void Circle(Point center, int radius)
		{
			int x = 0, y = radius;
			int d = 3 - 2 * radius;
			int u = 6;
			int v = 10 - 4 * radius;
			SetEllipsePixels(center.X, center.Y, x, y);

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
					
				SetEllipsePixels(center.X, center.Y, x, y);
			}
		}

		public Bitmap Clear()
		{
			Canvas = new Bitmap(Canvas.Width, Canvas.Height);
			return Canvas;
		}

		public void NewEllipse(Point center, int a, int b)
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
				SetEllipsePixels(center.X, center.Y, col, row, false);
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
				SetEllipsePixels(center.X, center.Y, col, row, false);
				if (d <= 0)
				{
					col++;
					d += fourSqrB * col;
				}
				row--;
				d += twoSqrA * (3 - (row << 1));
			}
		}

		public void Ellipse(Point center, int a, int b)
		{
			int x = 0, y = b;
			int d = 0;
			int u = 12 * b;
			int v = 12 * b + 8 * a;
			int l = a * b;
			SetEllipsePixels(center.X, center.Y, x, y);

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
				SetEllipsePixels(center.X, center.Y, x, y);
			}
		}

		private void SetEllipsePixels(int xc, int yc, int x, int y, bool both = true)
		{
			Canvas.SetPixel(xc + x, yc + y, Color.Black);
			Canvas.SetPixel(xc - x, yc + y, Color.Black);
			Canvas.SetPixel(xc + x, yc - y, Color.Black);
			Canvas.SetPixel(xc - x, yc - y, Color.Black);
			
			if (both)
			{
				Canvas.SetPixel(xc + y, yc + x, CurrentColor);
				Canvas.SetPixel(xc - y, yc + x, CurrentColor);
				Canvas.SetPixel(xc + y, yc - x, CurrentColor);
				Canvas.SetPixel(xc - y, yc - x, CurrentColor);
			}
		}
    }
}
