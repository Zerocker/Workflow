namespace CacheSimulator
{
    partial class Window
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
            this.MemoryUIBox = new System.Windows.Forms.RichTextBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.DebugLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.MemoryGroup = new System.Windows.Forms.GroupBox();
            this.SetButton = new System.Windows.Forms.Button();
            this.ItemSelect = new System.Windows.Forms.ComboBox();
            this.RowSelect = new System.Windows.Forms.ComboBox();
            this.PageSelect = new System.Windows.Forms.ComboBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.CacheUIBox = new System.Windows.Forms.RichTextBox();
            this.CacheGroup = new System.Windows.Forms.GroupBox();
            this.TagUIBox = new System.Windows.Forms.RichTextBox();
            this.PageSelectBox = new System.Windows.Forms.ComboBox();
            this.PageLabel = new System.Windows.Forms.Label();
            this.StatusStrip.SuspendLayout();
            this.MemoryGroup.SuspendLayout();
            this.CacheGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // MemoryUIBox
            // 
            this.MemoryUIBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MemoryUIBox.Location = new System.Drawing.Point(16, 35);
            this.MemoryUIBox.Name = "MemoryUIBox";
            this.MemoryUIBox.Size = new System.Drawing.Size(240, 240);
            this.MemoryUIBox.TabIndex = 0;
            this.MemoryUIBox.Text = "";
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DebugLog});
            this.StatusStrip.Location = new System.Drawing.Point(0, 369);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(611, 22);
            this.StatusStrip.TabIndex = 3;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // DebugLog
            // 
            this.DebugLog.DoubleClickEnabled = true;
            this.DebugLog.Name = "DebugLog";
            this.DebugLog.Size = new System.Drawing.Size(38, 17);
            this.DebugLog.Text = "Hello!";
            // 
            // MemoryGroup
            // 
            this.MemoryGroup.Controls.Add(this.PageSelectBox);
            this.MemoryGroup.Controls.Add(this.MemoryUIBox);
            this.MemoryGroup.Controls.Add(this.PageLabel);
            this.MemoryGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MemoryGroup.Location = new System.Drawing.Point(16, 16);
            this.MemoryGroup.Name = "MemoryGroup";
            this.MemoryGroup.Size = new System.Drawing.Size(272, 336);
            this.MemoryGroup.TabIndex = 5;
            this.MemoryGroup.TabStop = false;
            this.MemoryGroup.Text = "Memory";
            // 
            // SetButton
            // 
            this.SetButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SetButton.Location = new System.Drawing.Point(203, 291);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(53, 24);
            this.SetButton.TabIndex = 7;
            this.SetButton.Text = "Push";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // ItemSelect
            // 
            this.ItemSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ItemSelect.FormattingEnabled = true;
            this.ItemSelect.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.ItemSelect.Location = new System.Drawing.Point(161, 292);
            this.ItemSelect.Name = "ItemSelect";
            this.ItemSelect.Size = new System.Drawing.Size(36, 23);
            this.ItemSelect.TabIndex = 12;
            this.ItemSelect.Text = "1";
            // 
            // RowSelect
            // 
            this.RowSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RowSelect.FormattingEnabled = true;
            this.RowSelect.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.RowSelect.Location = new System.Drawing.Point(119, 292);
            this.RowSelect.Name = "RowSelect";
            this.RowSelect.Size = new System.Drawing.Size(36, 23);
            this.RowSelect.TabIndex = 11;
            this.RowSelect.Text = "1";
            // 
            // PageSelect
            // 
            this.PageSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PageSelect.FormattingEnabled = true;
            this.PageSelect.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.PageSelect.Location = new System.Drawing.Point(77, 292);
            this.PageSelect.Name = "PageSelect";
            this.PageSelect.Size = new System.Drawing.Size(36, 23);
            this.PageSelect.TabIndex = 10;
            this.PageSelect.Text = "1";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddressLabel.Location = new System.Drawing.Point(16, 295);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(59, 17);
            this.AddressLabel.TabIndex = 9;
            this.AddressLabel.Text = "Address:";
            // 
            // CacheUIBox
            // 
            this.CacheUIBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CacheUIBox.Location = new System.Drawing.Point(57, 35);
            this.CacheUIBox.Name = "CacheUIBox";
            this.CacheUIBox.Size = new System.Drawing.Size(198, 240);
            this.CacheUIBox.TabIndex = 0;
            this.CacheUIBox.Text = "";
            // 
            // CacheGroup
            // 
            this.CacheGroup.Controls.Add(this.SetButton);
            this.CacheGroup.Controls.Add(this.TagUIBox);
            this.CacheGroup.Controls.Add(this.ItemSelect);
            this.CacheGroup.Controls.Add(this.CacheUIBox);
            this.CacheGroup.Controls.Add(this.AddressLabel);
            this.CacheGroup.Controls.Add(this.RowSelect);
            this.CacheGroup.Controls.Add(this.PageSelect);
            this.CacheGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CacheGroup.Location = new System.Drawing.Point(320, 16);
            this.CacheGroup.Name = "CacheGroup";
            this.CacheGroup.Size = new System.Drawing.Size(272, 336);
            this.CacheGroup.TabIndex = 6;
            this.CacheGroup.TabStop = false;
            this.CacheGroup.Text = "Cache";
            // 
            // TagUIBox
            // 
            this.TagUIBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TagUIBox.Location = new System.Drawing.Point(18, 35);
            this.TagUIBox.Name = "TagUIBox";
            this.TagUIBox.Size = new System.Drawing.Size(34, 240);
            this.TagUIBox.TabIndex = 1;
            this.TagUIBox.Text = "";
            // 
            // PageSelectBox
            // 
            this.PageSelectBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PageSelectBox.FormattingEnabled = true;
            this.PageSelectBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.PageSelectBox.Location = new System.Drawing.Point(139, 292);
            this.PageSelectBox.Name = "PageSelectBox";
            this.PageSelectBox.Size = new System.Drawing.Size(36, 25);
            this.PageSelectBox.TabIndex = 10;
            this.PageSelectBox.Text = "1";
            // 
            // PageLabel
            // 
            this.PageLabel.AutoSize = true;
            this.PageLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PageLabel.Location = new System.Drawing.Point(97, 295);
            this.PageLabel.Name = "PageLabel";
            this.PageLabel.Size = new System.Drawing.Size(40, 17);
            this.PageLabel.TabIndex = 9;
            this.PageLabel.Text = "Page:";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(611, 391);
            this.Controls.Add(this.CacheGroup);
            this.Controls.Add(this.MemoryGroup);
            this.Controls.Add(this.StatusStrip);
            this.Name = "Window";
            this.Text = "Direct Mapped Cache";
            this.Load += new System.EventHandler(this.Window_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MemoryGroup.ResumeLayout(false);
            this.MemoryGroup.PerformLayout();
            this.CacheGroup.ResumeLayout(false);
            this.CacheGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox MemoryUIBox;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel DebugLog;
        private System.Windows.Forms.GroupBox MemoryGroup;
        private System.Windows.Forms.Button SetButton;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.ComboBox ItemSelect;
        private System.Windows.Forms.ComboBox RowSelect;
        private System.Windows.Forms.ComboBox PageSelect;
        private System.Windows.Forms.RichTextBox CacheUIBox;
        private System.Windows.Forms.GroupBox CacheGroup;
        private System.Windows.Forms.ComboBox PageSelectBox;
        private System.Windows.Forms.Label PageLabel;
        private System.Windows.Forms.RichTextBox TagUIBox;
    }
}

