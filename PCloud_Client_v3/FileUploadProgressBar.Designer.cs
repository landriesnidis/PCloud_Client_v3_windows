namespace PCloud_Client_v3
{
    partial class FileUploadProgressBar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labFileName = new System.Windows.Forms.Label();
            this.labSavePath = new System.Windows.Forms.Label();
            this.labState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 47);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(514, 26);
            this.progressBar.TabIndex = 1;
            // 
            // labFileName
            // 
            this.labFileName.AutoSize = true;
            this.labFileName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labFileName.Location = new System.Drawing.Point(4, 4);
            this.labFileName.Name = "labFileName";
            this.labFileName.Size = new System.Drawing.Size(121, 20);
            this.labFileName.TabIndex = 2;
            this.labFileName.Text = "上传文件的文件名";
            // 
            // labSavePath
            // 
            this.labSavePath.AutoSize = true;
            this.labSavePath.Location = new System.Drawing.Point(8, 28);
            this.labSavePath.Name = "labSavePath";
            this.labSavePath.Size = new System.Drawing.Size(77, 12);
            this.labSavePath.TabIndex = 3;
            this.labSavePath.Text = "上传文件路径";
            // 
            // labState
            // 
            this.labState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labState.AutoSize = true;
            this.labState.ForeColor = System.Drawing.Color.Red;
            this.labState.Location = new System.Drawing.Point(470, 4);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(41, 12);
            this.labState.TabIndex = 4;
            this.labState.Text = "label1";
            // 
            // FileUploadProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labState);
            this.Controls.Add(this.labSavePath);
            this.Controls.Add(this.labFileName);
            this.Controls.Add(this.progressBar);
            this.Name = "FileUploadProgressBar";
            this.Size = new System.Drawing.Size(514, 73);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labFileName;
        private System.Windows.Forms.Label labSavePath;
        private System.Windows.Forms.Label labState;
    }
}
