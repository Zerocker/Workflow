using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private Vector4[] cube;
        float size = 100f;
        Vector4 position = new Vector4(0, 0, 0, 0);
        float yaw = 0f;
        float pitch = 0f;
        float roll = 0f;
        float angle = 0F;

        public MainForm()
        {
            InitializeComponent();

            tbSize.Maximum = 150;
            tbSize.Value = 75;

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            
            tbSize.ValueChanged += tb_ValueChanged;

            tbZ.ValueChanged += tb_ZChanged;
            tbX.ValueChanged += tb_XChanged;
            tbY.ValueChanged += tb_YChanged;

            tbXY.ValueChanged += tb_XYChanged;
            tbYZ.ValueChanged += tb_YZChanged;
            tbXZ.ValueChanged += tb_XZChanged;

            tbXYZ.ValueChanged += tb_XYZChanged;

            tb_ValueChanged(null, EventArgs.Empty);
        }


        void tb_XChanged(object sender, EventArgs e)
        {
            size = tbSize.Value;
            pitch = (float)(tbX.Value * Math.PI / 180);
            //roll = (float)(tbZ.Value * Math.PI / 180);
            //yaw = (float)(tbPitch.Value * Math.PI / 180);
            cube = CreateCube(size, position, yaw, pitch, roll);

            Invalidate();
        }

        void tb_YChanged(object sender, EventArgs e)
        {
            size = tbSize.Value;
            //pitch = (float)(tbX.Value * Math.PI / 180);
            //roll = (float)(tbZ.Value * Math.PI / 180);
            yaw = (float)(tbY.Value * Math.PI / 180);
            cube = CreateCube(size, position, yaw, pitch, roll);

            Invalidate();
        }

        void tb_ZChanged(object sender, EventArgs e)
        {
            size = tbSize.Value;
            //pitch = (float)(tbX.Value * Math.PI / 180);
            roll = (float)(tbZ.Value * Math.PI / 180);
            //yaw = (float)(tbPitch.Value * Math.PI / 180);
            cube = CreateCube(size, position, yaw, pitch, roll);

            Invalidate();
        }


        void tb_XYChanged(object sender, EventArgs e)
        {
            size = tbSize.Value;
            pitch = (float)(tbXY.Value * Math.PI / 180);
            //roll = (float)(tbZ.Value * Math.PI / 180);
            yaw = (float)(tbXY.Value * Math.PI / 180);
            cube = CreateCube(size, position, yaw, pitch, roll);

            Invalidate();
        }

        void tb_YZChanged(object sender, EventArgs e)
        {
            size = tbSize.Value;
            //pitch = (float)(tbXY.Value * Math.PI / 180);
            roll = (float)(tbYZ.Value * Math.PI / 180);
            yaw = (float)(tbYZ.Value * Math.PI / 180);
            cube = CreateCube(size, position, yaw, pitch, roll);

            Invalidate();
        }

        void tb_XZChanged(object sender, EventArgs e)
        {
            size = tbSize.Value;
            pitch = (float)(tbXZ.Value * Math.PI / 180);
            roll = (float)(tbXZ.Value * Math.PI / 180);
            //yaw = (float)(tbYZ.Value * Math.PI / 180);
            cube = CreateCube(size, position, yaw, pitch, roll);

            Invalidate();
        }

        void tb_XYZChanged(object sender, EventArgs e)
        {
            size = tbSize.Value;
            pitch = (float)(tbXYZ.Value * Math.PI / 180);
            roll = (float)(tbXYZ.Value * Math.PI / 180);
            yaw = (float)(tbXYZ.Value * Math.PI / 180);
            cube = CreateCube(size, position, yaw, pitch, roll);

            Invalidate();
        }

        void tb_ValueChanged(object sender, EventArgs e)
        {
            size = tbSize.Value;
            pitch = (float)(tbX.Value * Math.PI / 180);
            roll = (float)(tbZ.Value * Math.PI / 180);
            //yaw = (float)(tbPitch.Value * Math.PI / 180);
            cube = CreateCube(size, position, yaw, pitch, roll);

            Invalidate();
        }

        private Vector4[] CreateCube(float scale, Vector4 position, float yaw, float pitch, float roll)
        {
            //задаем вершины куба
            cube = new Vector4[8];
            cube[0] = new Vector4(1, 1, 1, 1);
            cube[1] = new Vector4(-1, 1, 1, 1);
            cube[2] = new Vector4(-1, -1, 1, 1);
            cube[3] = new Vector4(1, -1, 1, 1);
            cube[4] = new Vector4(1, 1, -1, 1);
            cube[5] = new Vector4(-1, 1, -1, 1);
            cube[6] = new Vector4(-1, -1, -1, 1);
            cube[7] = new Vector4(1, -1, -1, 1);
            //матрица масштабирования
            var scaleM = Matrix4x4.CreateScale(scale / 2);
            //матрица вращения
            var rotateM = Matrix4x4.CreateFromYawPitchRoll(yaw, pitch, roll);
            //матрица переноса
            var translateM = Matrix4x4.CreateTranslation(position);
            //результирующая матрица
            var m = translateM * rotateM * scaleM;
            //умножаем векторы на матрицу
            for (int i = 0; i < cube.Length; i++)
                cube[i] = m * cube[i];

            return cube;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //создаем матрицу проекции на плоскость XY
            var paneXY = new Matrix4x4() { V00 = 1f, V11 = 1f, V33 = 1f };
            //рисуем
            DrawCube(e.Graphics, new PointF(100, 200), paneXY);

            //создаем матрицу проекции на плоскость XZ
            var paneXZ = new Matrix4x4() { V00 = 1f, V12 = 1f, V33 = 1f };
            //рисуем
            DrawCube(e.Graphics, new PointF(300, 200), paneXZ);
        }

        void DrawCube(Graphics gr, PointF startPoint, Matrix4x4 projectionMatrix)
        {
            //проекция
            var p = new Vector4[cube.Length];
            for (int i = 0; i < cube.Length; i++)
                p[i] = projectionMatrix * cube[i];

            //создаем путь
            var path = new GraphicsPath();
            AddLine(path, p[0], p[1], p[2], p[3], p[0], p[4], p[5], p[6], p[7], p[4]);
            AddLine(path, p[5], p[1]);
            AddLine(path, p[2], p[6]);
            AddLine(path, p[6], p[7]);
            AddLine(path, p[7], p[3]);
            //сдвигаем
            gr.ResetTransform();
            gr.TranslateTransform(startPoint.X, startPoint.Y);
            //рисуем
            gr.DrawPath(Pens.Black, path);
        }

        void AddLine(GraphicsPath path, params Vector4[] points)
        {
            foreach (var p in points)
                path.AddLines(new PointF[] { new PointF(p.X, p.Y) });
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
            } // По Z
            else if ((checkBox1.Checked == false) && (checkBox2.Checked == false) && (checkBox3.Checked == true))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = true;
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer6.Enabled = false;
                timer7.Enabled = false;
            } // По X,Y
            else if ((checkBox1.Checked == true) && (checkBox2.Checked == true) && (checkBox3.Checked == false))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = true;
                timer5.Enabled = false;
                timer6.Enabled = false;
                timer7.Enabled = false;
            } // По Y,Z
            else if ((checkBox1.Checked == false) && (checkBox2.Checked == true) && (checkBox3.Checked == true))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = true;
                timer6.Enabled = false;
                timer7.Enabled = false;
            } // По X,Z
            else if ((checkBox1.Checked == true) && (checkBox2.Checked == false) && (checkBox3.Checked == true))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer6.Enabled = true;
                timer7.Enabled = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = false;
            timer7.Enabled = false;

            tbX.Value = tbX.Minimum;
            tbY.Value = tbX.Minimum;
            tbZ.Value = tbX.Minimum;
            tbXY.Value = tbXY.Minimum;
            tbYZ.Value = tbYZ.Minimum;
            tbXZ.Value = tbXZ.Minimum;
            tbXYZ.Value = tbXYZ.Minimum;
        }
    }

    public struct Matrix4x4
    {
        public float V00;
        public float V01;
        public float V02;
        public float V03;
        public float V10;
        public float V11;
        public float V12;
        public float V13;
        public float V20;
        public float V21;
        public float V22;
        public float V23;
        public float V30;
        public float V31;
        public float V32;
        public float V33;

        public static Matrix4x4 Identity
        {
            get
            {
                Matrix4x4 m = new Matrix4x4();
                m.V00 = m.V11 = m.V22 = m.V33 = 1;
                return m;
            }
        }

        public static Matrix4x4 CreateScale(float scale)
        {
            var m = new Matrix4x4();
            m.V00 = m.V11 = m.V22 = scale;
            m.V33 = 1f;

            return m;
        }


        public static Matrix4x4 CreateRotationY(float radians)
        {
            Matrix4x4 m = Matrix4x4.Identity;

            float cos = (float)System.Math.Cos(radians);
            float sin = (float)System.Math.Sin(radians);

            m.V00 = m.V22 = cos;
            m.V02 = sin;
            m.V20 = -sin;

            return m;
        }

        public static Matrix4x4 CreateRotationX(float radians)
        {
            Matrix4x4 m = Matrix4x4.Identity;

            float cos = (float)System.Math.Cos(radians);
            float sin = (float)System.Math.Sin(radians);

            m.V11 = m.V22 = cos;
            m.V12 = -sin;
            m.V21 = sin;

            return m;
        }

        public static Matrix4x4 CreateRotationZ(float radians)
        {
            Matrix4x4 m = Matrix4x4.Identity;

            float cos = (float)System.Math.Cos(radians);
            float sin = (float)System.Math.Sin(radians);

            m.V00 = m.V11 = cos;
            m.V01 = -sin;
            m.V10 = sin;

            return m;
        }

        public static Matrix4x4 CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            return (CreateRotationY(yaw) * CreateRotationX(pitch) * CreateRotationZ(roll));
        }

        public static Matrix4x4 CreateTranslation(Vector4 position)
        {
            Matrix4x4 m = Matrix4x4.Identity;

            m.V03 = position.X;
            m.V13 = position.Y;
            m.V23 = position.Z;

            return m;
        }

        public static Matrix4x4 operator *(Matrix4x4 matrix1, Matrix4x4 matrix2)
        {
            Matrix4x4 m = new Matrix4x4();

            m.V00 = matrix1.V00 * matrix2.V00 + matrix1.V01 * matrix2.V10 + matrix1.V02 * matrix2.V20 + matrix1.V03 * matrix2.V30;
            m.V01 = matrix1.V00 * matrix2.V01 + matrix1.V01 * matrix2.V11 + matrix1.V02 * matrix2.V21 + matrix1.V03 * matrix2.V31;
            m.V02 = matrix1.V00 * matrix2.V02 + matrix1.V01 * matrix2.V12 + matrix1.V02 * matrix2.V22 + matrix1.V03 * matrix2.V32;
            m.V03 = matrix1.V00 * matrix2.V03 + matrix1.V01 * matrix2.V13 + matrix1.V02 * matrix2.V23 + matrix1.V03 * matrix2.V33;

            m.V10 = matrix1.V10 * matrix2.V00 + matrix1.V11 * matrix2.V10 + matrix1.V12 * matrix2.V20 + matrix1.V13 * matrix2.V30;
            m.V11 = matrix1.V10 * matrix2.V01 + matrix1.V11 * matrix2.V11 + matrix1.V12 * matrix2.V21 + matrix1.V13 * matrix2.V31;
            m.V12 = matrix1.V10 * matrix2.V02 + matrix1.V11 * matrix2.V12 + matrix1.V12 * matrix2.V22 + matrix1.V13 * matrix2.V32;
            m.V13 = matrix1.V10 * matrix2.V03 + matrix1.V11 * matrix2.V13 + matrix1.V12 * matrix2.V23 + matrix1.V13 * matrix2.V33;

            m.V20 = matrix1.V20 * matrix2.V00 + matrix1.V21 * matrix2.V10 + matrix1.V22 * matrix2.V20 + matrix1.V23 * matrix2.V30;
            m.V21 = matrix1.V20 * matrix2.V01 + matrix1.V21 * matrix2.V11 + matrix1.V22 * matrix2.V21 + matrix1.V23 * matrix2.V31;
            m.V22 = matrix1.V20 * matrix2.V02 + matrix1.V21 * matrix2.V12 + matrix1.V22 * matrix2.V22 + matrix1.V23 * matrix2.V32;
            m.V23 = matrix1.V20 * matrix2.V03 + matrix1.V21 * matrix2.V13 + matrix1.V22 * matrix2.V23 + matrix1.V23 * matrix2.V33;

            m.V30 = matrix1.V30 * matrix2.V00 + matrix1.V31 * matrix2.V10 + matrix1.V32 * matrix2.V20 + matrix1.V33 * matrix2.V30;
            m.V31 = matrix1.V30 * matrix2.V01 + matrix1.V31 * matrix2.V11 + matrix1.V32 * matrix2.V21 + matrix1.V33 * matrix2.V31;
            m.V32 = matrix1.V30 * matrix2.V02 + matrix1.V31 * matrix2.V12 + matrix1.V32 * matrix2.V22 + matrix1.V33 * matrix2.V32;
            m.V33 = matrix1.V30 * matrix2.V03 + matrix1.V31 * matrix2.V13 + matrix1.V32 * matrix2.V23 + matrix1.V33 * matrix2.V33;

            return m;
        }

        public static Vector4 operator *(Matrix4x4 matrix, Vector4 vector)
        {
            return new Vector4(
                matrix.V00 * vector.X + matrix.V01 * vector.Y + matrix.V02 * vector.Z + matrix.V03 * vector.W,
                matrix.V10 * vector.X + matrix.V11 * vector.Y + matrix.V12 * vector.Z + matrix.V13 * vector.W,
                matrix.V20 * vector.X + matrix.V21 * vector.Y + matrix.V22 * vector.Z + matrix.V23 * vector.W,
                matrix.V30 * vector.X + matrix.V31 * vector.Y + matrix.V32 * vector.Z + matrix.V33 * vector.W
                );
        }
    }

    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
}
