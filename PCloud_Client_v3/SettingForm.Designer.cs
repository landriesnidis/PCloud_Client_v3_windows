namespace PCloud_Client_v3
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvSettingItem = new System.Windows.Forms.ListView();
            this.chKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiRead = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvSettingItem
            // 
            this.lvSettingItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvSettingItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chKey,
            this.chValue,
            this.chNote});
            this.lvSettingItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSettingItem.FullRowSelect = true;
            this.lvSettingItem.GridLines = true;
            this.lvSettingItem.Location = new System.Drawing.Point(0, 25);
            this.lvSettingItem.MultiSelect = false;
            this.lvSettingItem.Name = "lvSettingItem";
            this.lvSettingItem.Size = new System.Drawing.Size(603, 315);
            this.lvSettingItem.TabIndex = 0;
            this.lvSettingItem.UseCompatibleStateImageBehavior = false;
            this.lvSettingItem.View = System.Windows.Forms.View.Details;
            this.lvSettingItem.DoubleClick += new System.EventHandler(this.lvSettingItem_DoubleClick);
            // 
            // chKey
            // 
            this.chKey.Text = "Key";
            this.chKey.Width = 142;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 147;
            // 
            // chNote
            // 
            this.chNote.Text = "Note";
            this.chNote.Width = 313;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRead,
            this.tsmiSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(603, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiRead
            // 
            this.tsmiRead.Name = "tsmiRead";
            this.tsmiRead.Size = new System.Drawing.Size(68, 21);
            this.tsmiRead.Text = "重新读取";
            this.tsmiRead.Click += new System.EventHandler(this.tsmiRead_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(68, 21);
            this.tsmiSave.Text = "保存配置";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 340);
            this.Controls.Add(this.lvSettingItem);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvSettingItem;
        private System.Windows.Forms.ColumnHeader chKey;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.ColumnHeader chNote;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRead;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;

    }
}