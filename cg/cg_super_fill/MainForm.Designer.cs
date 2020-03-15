namespace Lines
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.drawBox = new System.Windows.Forms.PictureBox();
            this.palettePanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fillButton = new System.Windows.Forms.RadioButton();
            this.lineButton = new System.Windows.Forms.RadioButton();
            this.pointButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.randomModeButton = new System.Windows.Forms.RadioButton();
            this.fourModeButton = new System.Windows.Forms.RadioButton();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.randomButton = new System.Windows.Forms.Button();
            this.eightModeButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawBox
            // 
            this.drawBox.Location = new System.Drawing.Point(12, 12);
            this.drawBox.Name = "drawBox";
            this.drawBox.Size = new System.Drawing.Size(559, 363);
            this.drawBox.TabIndex = 3;
            this.drawBox.TabStop = false;
            // 
            // palettePanel
            // 
            this.palettePanel.Location = new System.Drawing.Point(12, 381);
            this.palettePanel.Name = "palettePanel";
            this.palettePanel.Size = new System.Drawing.Size(760, 48);
            this.palettePanel.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fillButton);
            this.groupBox1.Controls.Add(this.lineButton);
            this.groupBox1.Controls.Add(this.pointButton);
            this.groupBox1.Location = new System.Drawing.Point(578, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 53);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // fillButton
            // 
            this.fillButton.AutoSize = true;
            this.fillButton.Location = new System.Drawing.Point(142, 22);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(37, 17);
            this.fillButton.TabIndex = 2;
            this.fillButton.TabStop = true;
            this.fillButton.Text = "Fill";
            this.fillButton.UseVisualStyleBackColor = true;
            // 
            // lineButton
            // 
            this.lineButton.AutoSize = true;
            this.lineButton.Location = new System.Drawing.Point(79, 22);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(45, 17);
            this.lineButton.TabIndex = 1;
            this.lineButton.TabStop = true;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            // 
            // pointButton
            // 
            this.pointButton.AutoSize = true;
            this.pointButton.Location = new System.Drawing.Point(11, 22);
            this.pointButton.Name = "pointButton";
            this.pointButton.Size = new System.Drawing.Size(49, 17);
            this.pointButton.TabIndex = 0;
            this.pointButton.TabStop = true;
            this.pointButton.Text = "Point";
            this.pointButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.eightModeButton);
            this.groupBox2.Controls.Add(this.colorPanel);
            this.groupBox2.Controls.Add(this.randomModeButton);
            this.groupBox2.Controls.Add(this.fourModeButton);
            this.groupBox2.Location = new System.Drawing.Point(578, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 78);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // randomModeButton
            // 
            this.randomModeButton.AutoSize = true;
            this.randomModeButton.Location = new System.Drawing.Point(11, 45);
            this.randomModeButton.Name = "randomModeButton";
            this.randomModeButton.Size = new System.Drawing.Size(79, 17);
            this.randomModeButton.TabIndex = 1;
            this.randomModeButton.TabStop = true;
            this.randomModeButton.Text = "Color Noise";
            this.randomModeButton.UseVisualStyleBackColor = true;
            // 
            // fourModeButton
            // 
            this.fourModeButton.AutoSize = true;
            this.fourModeButton.Location = new System.Drawing.Point(11, 22);
            this.fourModeButton.Name = "fourModeButton";
            this.fourModeButton.Size = new System.Drawing.Size(60, 17);
            this.fourModeButton.TabIndex = 0;
            this.fourModeButton.TabStop = true;
            this.fourModeButton.Text = "4 pixels";
            this.fourModeButton.UseVisualStyleBackColor = true;
            // 
            // colorPanel
            // 
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPanel.Location = new System.Drawing.Point(152, 15);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(28, 28);
            this.colorPanel.TabIndex = 5;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(697, 352);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // randomButton
            // 
            this.randomButton.Location = new System.Drawing.Point(616, 352);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(75, 23);
            this.randomButton.TabIndex = 8;
            this.randomButton.Text = "Random";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // eightModeButton
            // 
            this.eightModeButton.AutoSize = true;
            this.eightModeButton.Location = new System.Drawing.Point(77, 22);
            this.eightModeButton.Name = "eightModeButton";
            this.eightModeButton.Size = new System.Drawing.Size(60, 17);
            this.eightModeButton.TabIndex = 6;
            this.eightModeButton.TabStop = true;
            this.eightModeButton.Text = "8 pixels";
            this.eightModeButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.randomButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.palettePanel);
            this.Controls.Add(this.drawBox);
            this.MaximumSize = new System.Drawing.Size(800, 480);
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox drawBox;
        private System.Windows.Forms.Panel palettePanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton fillButton;
        private System.Windows.Forms.RadioButton lineButton;
        private System.Windows.Forms.RadioButton pointButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton randomModeButton;
        private System.Windows.Forms.RadioButton fourModeButton;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.RadioButton eightModeButton;
    }
}

