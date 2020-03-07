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
            this.label1 = new System.Windows.Forms.Label();
            this.drawBox = new System.Windows.Forms.PictureBox();
            this.lineButton = new System.Windows.Forms.RadioButton();
            this.circleButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // drawBox
            // 
            this.drawBox.Location = new System.Drawing.Point(12, 12);
            this.drawBox.Name = "drawBox";
            this.drawBox.Size = new System.Drawing.Size(559, 381);
            this.drawBox.TabIndex = 3;
            this.drawBox.TabStop = false;
            // 
            // lineButton
            // 
            this.lineButton.AutoSize = true;
            this.lineButton.Checked = true;
            this.lineButton.Location = new System.Drawing.Point(459, 413);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(45, 17);
            this.lineButton.TabIndex = 4;
            this.lineButton.TabStop = true;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            // 
            // circleButton
            // 
            this.circleButton.AutoSize = true;
            this.circleButton.Location = new System.Drawing.Point(510, 413);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(51, 17);
            this.circleButton.TabIndex = 5;
            this.circleButton.TabStop = true;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 450);
            this.Controls.Add(this.circleButton);
            this.Controls.Add(this.lineButton);
            this.Controls.Add(this.drawBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox drawBox;
        private System.Windows.Forms.RadioButton lineButton;
        private System.Windows.Forms.RadioButton circleButton;
    }
}

