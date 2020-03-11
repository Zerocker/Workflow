namespace C2C
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.hsvRect = new System.Windows.Forms.Panel();
            this.cmykRect = new System.Windows.Forms.Panel();
            this.redSlider = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.redBox = new System.Windows.Forms.NumericUpDown();
            this.blueBox = new System.Windows.Forms.NumericUpDown();
            this.greenBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.blueSlider = new System.Windows.Forms.TrackBar();
            this.greenSlider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.valueSlider = new System.Windows.Forms.TrackBar();
            this.valueBox = new System.Windows.Forms.NumericUpDown();
            this.satBox = new System.Windows.Forms.NumericUpDown();
            this.satSlider = new System.Windows.Forms.TrackBar();
            this.hueSlider = new System.Windows.Forms.TrackBar();
            this.hueBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.blackBox = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.blackSlider = new System.Windows.Forms.TrackBar();
            this.cyanBox = new System.Windows.Forms.NumericUpDown();
            this.magentaBox = new System.Windows.Forms.NumericUpDown();
            this.cyanSlider = new System.Windows.Forms.TrackBar();
            this.magentaSlider = new System.Windows.Forms.TrackBar();
            this.yellowBox = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.yellowSlider = new System.Windows.Forms.TrackBar();
            this.rgbRect = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.redSlider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenSlider)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blackBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cyanBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magentaBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cyanSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magentaSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.hsvRect.Location = new System.Drawing.Point(505, 242);
            this.hsvRect.Margin = new System.Windows.Forms.Padding(4);
            this.hsvRect.Name = "panel2";
            this.hsvRect.Size = new System.Drawing.Size(129, 118);
            this.hsvRect.TabIndex = 5;
            // 
            // panel4
            // 
            this.cmykRect.Location = new System.Drawing.Point(505, 462);
            this.cmykRect.Margin = new System.Windows.Forms.Padding(4);
            this.cmykRect.Name = "panel4";
            this.cmykRect.Size = new System.Drawing.Size(129, 118);
            this.cmykRect.TabIndex = 11;
            // 
            // redSlider
            // 
            this.redSlider.LargeChange = 1;
            this.redSlider.Location = new System.Drawing.Point(52, 23);
            this.redSlider.Margin = new System.Windows.Forms.Padding(4);
            this.redSlider.Maximum = 255;
            this.redSlider.Name = "redSlider";
            this.redSlider.Size = new System.Drawing.Size(339, 56);
            this.redSlider.TabIndex = 13;
            this.redSlider.Value = 200;
            this.redSlider.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.redBox);
            this.groupBox1.Controls.Add(this.blueBox);
            this.groupBox1.Controls.Add(this.greenBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.blueSlider);
            this.groupBox1.Controls.Add(this.greenSlider);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.redSlider);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(460, 186);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RGB";
            // 
            // redBox
            // 
            this.redBox.Location = new System.Drawing.Point(399, 32);
            this.redBox.Margin = new System.Windows.Forms.Padding(4);
            this.redBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size(53, 22);
            this.redBox.TabIndex = 15;
            this.redBox.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.redBox.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // blueBox
            // 
            this.blueBox.Location = new System.Drawing.Point(399, 129);
            this.blueBox.Margin = new System.Windows.Forms.Padding(4);
            this.blueBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size(53, 22);
            this.blueBox.TabIndex = 18;
            this.blueBox.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // greenBox
            // 
            this.greenBox.Location = new System.Drawing.Point(399, 78);
            this.greenBox.Margin = new System.Windows.Forms.Padding(4);
            this.greenBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size(53, 22);
            this.greenBox.TabIndex = 16;
            this.greenBox.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.greenBox.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 129);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Blue";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Green";
            // 
            // blueSlider
            // 
            this.blueSlider.LargeChange = 1;
            this.blueSlider.Location = new System.Drawing.Point(52, 121);
            this.blueSlider.Margin = new System.Windows.Forms.Padding(4);
            this.blueSlider.Maximum = 255;
            this.blueSlider.Name = "blueSlider";
            this.blueSlider.Size = new System.Drawing.Size(339, 56);
            this.blueSlider.TabIndex = 16;
            this.blueSlider.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // greenSlider
            // 
            this.greenSlider.LargeChange = 1;
            this.greenSlider.Location = new System.Drawing.Point(52, 69);
            this.greenSlider.Margin = new System.Windows.Forms.Padding(4);
            this.greenSlider.Maximum = 255;
            this.greenSlider.Name = "greenSlider";
            this.greenSlider.Size = new System.Drawing.Size(339, 56);
            this.greenSlider.TabIndex = 16;
            this.greenSlider.Value = 70;
            this.greenSlider.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Red";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.valueSlider);
            this.groupBox2.Controls.Add(this.valueBox);
            this.groupBox2.Controls.Add(this.satBox);
            this.groupBox2.Controls.Add(this.satSlider);
            this.groupBox2.Controls.Add(this.hueSlider);
            this.groupBox2.Controls.Add(this.hueBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(16, 209);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(460, 186);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HSV";
            // 
            // valueSlider
            // 
            this.valueSlider.LargeChange = 1;
            this.valueSlider.Location = new System.Drawing.Point(52, 121);
            this.valueSlider.Margin = new System.Windows.Forms.Padding(4);
            this.valueSlider.Maximum = 100;
            this.valueSlider.Name = "valueSlider";
            this.valueSlider.Size = new System.Drawing.Size(339, 56);
            this.valueSlider.TabIndex = 13;
            this.valueSlider.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // numericUpDown6
            // 
            this.valueBox.Location = new System.Drawing.Point(399, 129);
            this.valueBox.Margin = new System.Windows.Forms.Padding(4);
            this.valueBox.Name = "numericUpDown6";
            this.valueBox.Size = new System.Drawing.Size(53, 22);
            this.valueBox.TabIndex = 21;
            this.valueBox.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // numericUpDown5
            // 
            this.satBox.Location = new System.Drawing.Point(399, 79);
            this.satBox.Margin = new System.Windows.Forms.Padding(4);
            this.satBox.Name = "numericUpDown5";
            this.satBox.Size = new System.Drawing.Size(53, 22);
            this.satBox.TabIndex = 19;
            this.satBox.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // satSlider
            // 
            this.satSlider.LargeChange = 1;
            this.satSlider.Location = new System.Drawing.Point(52, 69);
            this.satSlider.Margin = new System.Windows.Forms.Padding(4);
            this.satSlider.Maximum = 100;
            this.satSlider.Name = "satSlider";
            this.satSlider.Size = new System.Drawing.Size(339, 56);
            this.satSlider.TabIndex = 20;
            this.satSlider.Scroll += new System.EventHandler(this.trackBar5_Scroll);
            // 
            // hueSlider
            // 
            this.hueSlider.LargeChange = 1;
            this.hueSlider.Location = new System.Drawing.Point(52, 23);
            this.hueSlider.Margin = new System.Windows.Forms.Padding(4);
            this.hueSlider.Maximum = 360;
            this.hueSlider.Name = "hueSlider";
            this.hueSlider.Size = new System.Drawing.Size(339, 56);
            this.hueSlider.TabIndex = 18;
            this.hueSlider.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // numericUpDown4
            // 
            this.hueBox.Location = new System.Drawing.Point(399, 32);
            this.hueBox.Margin = new System.Windows.Forms.Padding(4);
            this.hueBox.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.hueBox.Name = "numericUpDown4";
            this.hueBox.Size = new System.Drawing.Size(53, 22);
            this.hueBox.TabIndex = 15;
            this.hueBox.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Sat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Hue";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.blackBox);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.blackSlider);
            this.groupBox3.Controls.Add(this.cyanBox);
            this.groupBox3.Controls.Add(this.magentaBox);
            this.groupBox3.Controls.Add(this.cyanSlider);
            this.groupBox3.Controls.Add(this.magentaSlider);
            this.groupBox3.Controls.Add(this.yellowBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.yellowSlider);
            this.groupBox3.Location = new System.Drawing.Point(16, 403);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(460, 230);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CMYK";
            // 
            // numericUpDown13
            // 
            this.blackBox.Location = new System.Drawing.Point(399, 177);
            this.blackBox.Margin = new System.Windows.Forms.Padding(4);
            this.blackBox.Name = "numericUpDown13";
            this.blackBox.Size = new System.Drawing.Size(53, 22);
            this.blackBox.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 180);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 17);
            this.label15.TabIndex = 24;
            this.label15.Text = "Black";
            // 
            // trackBar13
            // 
            this.blackSlider.LargeChange = 1;
            this.blackSlider.Location = new System.Drawing.Point(52, 171);
            this.blackSlider.Margin = new System.Windows.Forms.Padding(4);
            this.blackSlider.Maximum = 100;
            this.blackSlider.Name = "trackBar13";
            this.blackSlider.Size = new System.Drawing.Size(339, 56);
            this.blackSlider.TabIndex = 22;
            this.blackSlider.Scroll += new System.EventHandler(this.trackBar13_Scroll);
            // 
            // numericUpDown7
            // 
            this.cyanBox.Location = new System.Drawing.Point(399, 23);
            this.cyanBox.Margin = new System.Windows.Forms.Padding(4);
            this.cyanBox.Name = "numericUpDown7";
            this.cyanBox.Size = new System.Drawing.Size(53, 22);
            this.cyanBox.TabIndex = 21;
            // 
            // numericUpDown8
            // 
            this.magentaBox.Location = new System.Drawing.Point(399, 79);
            this.magentaBox.Margin = new System.Windows.Forms.Padding(4);
            this.magentaBox.Name = "numericUpDown8";
            this.magentaBox.Size = new System.Drawing.Size(53, 22);
            this.magentaBox.TabIndex = 19;
            // 
            // trackBar7
            // 
            this.cyanSlider.LargeChange = 1;
            this.cyanSlider.Location = new System.Drawing.Point(52, 23);
            this.cyanSlider.Margin = new System.Windows.Forms.Padding(4);
            this.cyanSlider.Maximum = 100;
            this.cyanSlider.Name = "trackBar7";
            this.cyanSlider.Size = new System.Drawing.Size(339, 56);
            this.cyanSlider.TabIndex = 20;
            this.cyanSlider.Scroll += new System.EventHandler(this.trackBar7_Scroll);
            // 
            // trackBar8
            // 
            this.magentaSlider.LargeChange = 1;
            this.magentaSlider.Location = new System.Drawing.Point(52, 70);
            this.magentaSlider.Margin = new System.Windows.Forms.Padding(4);
            this.magentaSlider.Maximum = 100;
            this.magentaSlider.Name = "trackBar8";
            this.magentaSlider.Size = new System.Drawing.Size(339, 56);
            this.magentaSlider.TabIndex = 18;
            this.magentaSlider.Scroll += new System.EventHandler(this.trackBar8_Scroll);
            // 
            // numericUpDown9
            // 
            this.yellowBox.Location = new System.Drawing.Point(399, 127);
            this.yellowBox.Margin = new System.Windows.Forms.Padding(4);
            this.yellowBox.Name = "numericUpDown9";
            this.yellowBox.Size = new System.Drawing.Size(53, 22);
            this.yellowBox.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 129);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Yellow";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 78);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "Mage";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 32);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Cyan";
            // 
            // trackBar9
            // 
            this.yellowSlider.LargeChange = 1;
            this.yellowSlider.Location = new System.Drawing.Point(52, 121);
            this.yellowSlider.Margin = new System.Windows.Forms.Padding(4);
            this.yellowSlider.Maximum = 100;
            this.yellowSlider.Name = "trackBar9";
            this.yellowSlider.Size = new System.Drawing.Size(339, 56);
            this.yellowSlider.TabIndex = 13;
            this.yellowSlider.Scroll += new System.EventHandler(this.trackBar9_Scroll);
            // 
            // panel1
            // 
            this.rgbRect.Location = new System.Drawing.Point(505, 48);
            this.rgbRect.Margin = new System.Windows.Forms.Padding(4);
            this.rgbRect.Name = "panel1";
            this.rgbRect.Size = new System.Drawing.Size(129, 118);
            this.rgbRect.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 681);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmykRect);
            this.Controls.Add(this.hsvRect);
            this.Controls.Add(this.rgbRect);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.redSlider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenSlider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blackBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cyanBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magentaBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cyanSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magentaSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel hsvRect;
        private System.Windows.Forms.Panel cmykRect;
        private System.Windows.Forms.TrackBar redSlider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar blueSlider;
        private System.Windows.Forms.TrackBar greenSlider;
        private System.Windows.Forms.NumericUpDown redBox;
        private System.Windows.Forms.NumericUpDown blueBox;
        private System.Windows.Forms.NumericUpDown greenBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown valueBox;
        private System.Windows.Forms.NumericUpDown satBox;
        private System.Windows.Forms.TrackBar satSlider;
        private System.Windows.Forms.TrackBar hueSlider;
        private System.Windows.Forms.NumericUpDown hueBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar valueSlider;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown cyanBox;
        private System.Windows.Forms.NumericUpDown magentaBox;
        private System.Windows.Forms.TrackBar cyanSlider;
        private System.Windows.Forms.TrackBar magentaSlider;
        private System.Windows.Forms.NumericUpDown yellowBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar yellowSlider;
        private System.Windows.Forms.NumericUpDown blackBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar blackSlider;
        private System.Windows.Forms.Panel rgbRect;
    }
}

