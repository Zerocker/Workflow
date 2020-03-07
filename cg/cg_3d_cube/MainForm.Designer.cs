namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.timer7 = new System.Windows.Forms.Timer(this.components);
            this.tbSize = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TrackBar();
            this.tbY = new System.Windows.Forms.TrackBar();
            this.tbZ = new System.Windows.Forms.TrackBar();
            this.tbXZ = new System.Windows.Forms.TrackBar();
            this.tbYZ = new System.Windows.Forms.TrackBar();
            this.tbXY = new System.Windows.Forms.TrackBar();
            this.tbXYZ = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXYZ)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(31, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "x";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(64, 33);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(31, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "y";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(110, 33);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(31, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "z";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Старт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Вращение по X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Вращение по Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Вращение по Z";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(630, 297);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Вращение по XZ";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 10;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Interval = 10;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // timer6
            // 
            this.timer6.Interval = 10;
            this.timer6.Tick += new System.EventHandler(this.timer6_Tick);
            // 
            // timer7
            // 
            this.timer7.Interval = 10;
            this.timer7.Tick += new System.EventHandler(this.timer7_Tick);
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(14, 181);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(104, 45);
            this.tbSize.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Размер";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(14, 47);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(104, 45);
            this.tbX.TabIndex = 14;
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(129, 47);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(104, 45);
            this.tbY.TabIndex = 15;
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(243, 47);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(104, 45);
            this.tbZ.TabIndex = 16;
            // 
            // tbXZ
            // 
            this.tbXZ.Location = new System.Drawing.Point(243, 120);
            this.tbXZ.Name = "tbXZ";
            this.tbXZ.Size = new System.Drawing.Size(104, 45);
            this.tbXZ.TabIndex = 19;
            // 
            // tbYZ
            // 
            this.tbYZ.Location = new System.Drawing.Point(129, 117);
            this.tbYZ.Name = "tbYZ";
            this.tbYZ.Size = new System.Drawing.Size(104, 45);
            this.tbYZ.TabIndex = 18;
            // 
            // tbXY
            // 
            this.tbXY.Location = new System.Drawing.Point(16, 117);
            this.tbXY.Name = "tbXY";
            this.tbXY.Size = new System.Drawing.Size(104, 45);
            this.tbXY.TabIndex = 17;
            // 
            // tbXYZ
            // 
            this.tbXYZ.Location = new System.Drawing.Point(243, 193);
            this.tbXYZ.Name = "tbXYZ";
            this.tbXYZ.Size = new System.Drawing.Size(104, 45);
            this.tbXYZ.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Вращение по XZ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Вращение по YZ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Вращение по XY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(249, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Вращение по XYZ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbSize);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbXYZ);
            this.groupBox1.Controls.Add(this.tbX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbXZ);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbY);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbYZ);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbZ);
            this.groupBox1.Controls.Add(this.tbXY);
            this.groupBox1.Location = new System.Drawing.Point(556, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 249);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(556, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 74);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Закрепление";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(280, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Стоп";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXYZ)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.Timer timer7;
        private System.Windows.Forms.TrackBar tbSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tbX;
        private System.Windows.Forms.TrackBar tbY;
        private System.Windows.Forms.TrackBar tbZ;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TrackBar tbXZ;
        private System.Windows.Forms.TrackBar tbYZ;
        private System.Windows.Forms.TrackBar tbXY;
        private System.Windows.Forms.TrackBar tbXYZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
    }
}

