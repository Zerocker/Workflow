/*
 * Created by SharpDevelop.
 * User: E401
 * Date: 04.02.2020
 * Time: 13:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Lines
{ 
	public partial class MainForm : Form
	{
		Draw BobRoss;

		int MouseClicks = 0;

		Point C = new Point();
		Point B = new Point();
		Point A = new Point();
		
		public MainForm()
		{
			InitializeComponent();

			BobRoss = new Draw(drawBox.Width, drawBox.Height)
			{
				CurrentColor = Color.Blue
			};
		}

		void DrawBoxClick(object sender, MouseEventArgs @event)
		{
			MouseClicks++;
			
			if (MouseClicks % 2 == 1)
			{
				A.X = @event.Location.X;
				A.Y = @event.Location.Y;

				using (var gr = Graphics.FromImage(BobRoss.Canvas))
				{
					gr.DrawRectangle(new Pen(Color.Gray, 1), A.X, A.Y, 1, 1);
				}

				if (radioButton3.Checked && textBoxA.Text != string.Empty)
				{
					BobRoss.Circle(A, int.Parse(textBoxA.Text));
					MouseClicks = 0;
				}
				else if (radioButton4.Checked && textBoxA.Text != string.Empty && textBoxB.Text != string.Empty)
				{
					BobRoss.NewEllipse(A, int.Parse(textBoxA.Text), int.Parse(textBoxB.Text));
					MouseClicks = 0;
				}
			}
			
			if (MouseClicks % 2 == 0)
			{
				B.X = @event.Location.X;
				B.Y = @event.Location.Y;
				
				using (var gr = Graphics.FromImage(BobRoss.Canvas))
				{
					gr.DrawRectangle(new Pen(Color.Gray, 1), B.X, B.Y, 1, 1);
				}
				
				if (radioButton1.Checked)
				{
					BobRoss.LineDDA(A, B);
				}
				else if (radioButton2.Checked)
				{
					BobRoss.LineBresenham(A, B);
				}
			}

			drawBox.Image = BobRoss.Canvas;
		}

		void ClearButtonClick(object sender, EventArgs e)
		{
			drawBox.Image = BobRoss.Clear();
		}
	}
}
