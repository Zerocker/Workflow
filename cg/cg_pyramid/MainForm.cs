using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Numerics;
using Lab.GL;

namespace Lab
{
    public partial class MainForm : Form
    {
        private Mesh @object;
        float height = 2;
        int sides = 3;
        
        Vector3 position = new Vector3(0, 0, 0);
        Vector3 point = new Vector3(10, 10, 10);
        Vector3 size = new Vector3(75, 75, 75);
        float yaw = 0f;
        float pitch = 0f;
        float roll = 0f;
        float angle = 0f;

        public MainForm()
        {
            InitializeComponent();

            tbX.Maximum = 360;
            tbX.Value = 0;
            tbY.Maximum = 360;
            tbY.Value = 0;
            tbZ.Maximum = 360;
            tbZ.Value = 0;

            tbXY.Maximum = 360;
            tbXY.Value = 0;
            tbYZ.Maximum = 360;
            tbYZ.Value = 0;
            tbXZ.Maximum = 360;
            tbXZ.Value = 0;

            tbXYZ.Maximum = 360;
            tbXYZ.Value = 0;

            @object = new Mesh()
            {
                Vertices = PyramidMesh.GenerateVertices(sides, height, Vector3.Zero),
                Triangles = PyramidMesh.GenerateFaces(sides)
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            tbHeight.ValueChanged += tbHeight_ValueChanged;
            tbSides.ValueChanged += tbSides_ValueChanged;

            tbZ.ValueChanged += tb_ZChanged;
            tbX.ValueChanged += tb_XChanged;
            tbY.ValueChanged += tb_YChanged;

            tbXY.ValueChanged += tb_XYChanged;
            tbYZ.ValueChanged += tb_YZChanged;
            tbXZ.ValueChanged += tb_XZChanged;

            tbXYZ.ValueChanged += tb_XYZChanged;

            tbHeight_ValueChanged(null, EventArgs.Empty);
        }

        void tbSides_ValueChanged(object sender, EventArgs e)
        {
            sides = Convert.ToInt32(tbSides.Value);
            @object.Vertices = PyramidMesh.GenerateVertices(sides, height, position);
            @object.Triangles = PyramidMesh.GenerateFaces(sides);

            gWindow.Invalidate();
        }

        void tbHeight_ValueChanged(object sender, EventArgs e)
        {
            height = Convert.ToSingle(tbHeight.Value);
            @object.Vertices = PyramidMesh.GenerateVertices(sides, height, position);

            gWindow.Invalidate();
        }

        void tb_XChanged(object sender, EventArgs e)
        {
            pitch = (float)(tbX.Value * Math.PI / 180);

            gWindow.Invalidate();
        }

        void tb_YChanged(object sender, EventArgs e)
        {
            yaw = (float)(tbY.Value * Math.PI / 180);
            
            gWindow.Invalidate();
        }

        void tb_ZChanged(object sender, EventArgs e)
        {
            roll = (float)(tbZ.Value * Math.PI / 180);

            gWindow.Invalidate();
        }


        void tb_XYChanged(object sender, EventArgs e)
        {
            pitch = (float)(tbXY.Value * Math.PI / 180);
            yaw = (float)(tbXY.Value * Math.PI / 180);
            
            gWindow.Invalidate();
        }

        void tb_YZChanged(object sender, EventArgs e)
        {
            roll = (float)(tbYZ.Value * Math.PI / 180);
            yaw = (float)(tbYZ.Value * Math.PI / 180);

            gWindow.Invalidate();
        }

        void tb_XZChanged(object sender, EventArgs e)
        {
            pitch = (float)(tbXZ.Value * Math.PI / 180);
            roll = (float)(tbXZ.Value * Math.PI / 180);

            gWindow.Invalidate();
        }

        void tb_XYZChanged(object sender, EventArgs e)
        {
            pitch = (float)(tbXYZ.Value * Math.PI / 180);
            roll = (float)(tbXYZ.Value * Math.PI / 180);
            yaw = (float)(tbXYZ.Value * Math.PI / 180);

            gWindow.Invalidate();
        }

        void tb_CustomChanged(object sender, EventArgs e)
        {
            @object.RotateAround(point.ToVector4(), position.ToVector4(), angle);

            gWindow.Invalidate();
        }

        private void gWindow_OnPaint(object sender, PaintEventArgs e)
        {
            var aspect = Convert.ToSingle(gWindow.Width) / Convert.ToSingle(gWindow.Height);
            var paneXY = Extensions.BuildPerspective(90f, aspect, 1.0f, 1000f);

            @object.Transform(position, new Vector3(pitch, roll, yaw), size);
            @object.Draw(e.Graphics, new PointF(240, 240), paneXY);
            @object.SortDepth();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((checkBox1.Checked == true) && (checkBox2.Checked == false) && (checkBox3.Checked == false))
            {
                timer1.Enabled = true;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer6.Enabled = false;
                timer7.Enabled = false;
                timer8.Enabled = false;
            }
            else if ((checkBox1.Checked == false) && (checkBox2.Checked == true) && (checkBox3.Checked == false))
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer6.Enabled = false;
                timer7.Enabled = false;
                timer8.Enabled = false;
            }
            else if ((checkBox1.Checked == false) && (checkBox2.Checked == false) && (checkBox3.Checked == true))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = true;
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer6.Enabled = false;
                timer7.Enabled = false;
                timer8.Enabled = false;
            }
            else if ((checkBox1.Checked == true) && (checkBox2.Checked == true) && (checkBox3.Checked == false))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = true;
                timer5.Enabled = false;
                timer6.Enabled = false;
                timer7.Enabled = false;
                timer8.Enabled = false;
            }
            else if ((checkBox1.Checked == false) && (checkBox2.Checked == true) && (checkBox3.Checked == true))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = true;
                timer6.Enabled = false;
                timer7.Enabled = false;
                timer8.Enabled = false;
            }
            else if ((checkBox1.Checked == true) && (checkBox2.Checked == false) && (checkBox3.Checked == true))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer6.Enabled = true;
                timer7.Enabled = false;
                timer8.Enabled = false;
            }
            else if ((checkBox1.Checked == true) && (checkBox2.Checked == true) && (checkBox3.Checked == true))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer6.Enabled = false;
                timer7.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer6.Enabled = false;
                timer7.Enabled = false;
                timer8.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tb_XChanged(sender, e);
            if (tbX.Value >= tbX.Maximum) { tbX.Value = 0; }
            else { tbX.Value++; }       
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tb_YChanged(sender, e);
            if (tbY.Value >= tbY.Maximum) { tbY.Value = 0; }
            else { tbY.Value++; }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            tb_ZChanged(sender, e);
            if (tbZ.Value >= tbZ.Maximum) { tbZ.Value = 0; }
            else { tbZ.Value++; }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            tb_XYChanged(sender, e);
            if (tbXY.Value >= tbXY.Maximum) { tbXY.Value = 0; }
            else { tbXY.Value++; }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            tb_YZChanged(sender, e);
            if (tbYZ.Value >= tbYZ.Maximum) { tbYZ.Value = 0; }
            else { tbYZ.Value++; }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            tb_XZChanged(sender, e);
            if (tbXZ.Value >= tbXZ.Maximum) { tbXZ.Value = 0; }
            else { tbXZ.Value++; }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            tb_XYZChanged(sender, e);
            if (tbXYZ.Value >= tbXYZ.Maximum) { tbXYZ.Value = 0; }
            else { tbXYZ.Value++; }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            tb_CustomChanged(sender, e);
            angle++;
            angle %= 360;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = false;
            timer7.Enabled = false;
            timer8.Enabled = false;

            tbX.Value = tbX.Minimum;
            tbY.Value = tbX.Minimum;
            tbZ.Value = tbX.Minimum;
            tbXY.Value = tbXY.Minimum;
            tbYZ.Value = tbYZ.Minimum;
            tbXZ.Value = tbXZ.Minimum;
            tbXYZ.Value = tbXYZ.Minimum;
        }
    }
}
