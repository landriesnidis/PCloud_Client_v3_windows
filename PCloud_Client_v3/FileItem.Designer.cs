namespace PCloud_Client_v3
{
    partial class FileItem
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
            this.components = new System.ComponentModel.Container();
            this.picboxIcon = new System.Windows.Forms.PictureBox();
            this.labName = new System.Windows.Forms.Label();
            this.labSize = new System.Windows.Forms.Label();
            this.cmsFileItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShare = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInfo_name = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInfo_CopyFileName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInfo_Size = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInfo_Type = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFolderItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenameFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.timerShowFullName = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picboxIcon)).BeginInit();
            this.cmsFileItem.SuspendLayout();
            this.cmsFolderItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // picboxIcon
            // 
            this.picboxIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picboxIcon.Location = new System.Drawing.Point(5, 5);
            this.picboxIcon.Name = "picboxIcon";
            this.picboxIcon.Size = new System.Drawing.Size(90, 90);
            this.picboxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picboxIcon.TabIndex = 0;
            this.picboxIcon.TabStop = false;
            this.picboxIcon.DoubleClick += new System.EventHandler(this.FileItem_DoubleClick);
            this.picboxIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FileItem_MouseClick);
            this.picboxIcon.MouseLeave += new System.EventHandler(this.FileItem_MouseLeave);
            this.picboxIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FileItem_MouseMove);
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(3, 98);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(41, 12);
            this.labName.TabIndex = 1;
            this.labName.Text = "label1";
            // 
            // labSize
            // 
            this.labSize.AutoSize = true;
            this.labSize.Location = new System.Drawing.Point(3, 114);
            this.labSize.Name = "labSize";
            this.labSize.Size = new System.Drawing.Size(41, 12);
            this.labSize.TabIndex = 2;
            this.labSize.Text = "label1";
            // 
            // cmsFileItem
            // 
            this.cmsFileItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDownload,
            this.toolStripSeparator2,
            this.tsmiCopy,
            this.tsmiShear,
            this.tsmiRename,
            this.toolStripSeparator1,
            this.tsmiShare,
            this.tsmiDelete,
            this.tsmiInfo});
            this.cmsFileItem.Name = "cmsFileItem";
            this.cmsFileItem.Size = new System.Drawing.Size(113, 170);
            this.cmsFileItem.Opening += new System.ComponentModel.CancelEventHandler(this.cmsFileItem_Opening);
            this.cmsFileItem.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsFileItem_ItemClicked);
            // 
            // tsmiDownload
            // 
            this.tsmiDownload.Name = "tsmiDownload";
            this.tsmiDownload.Size = new System.Drawing.Size(112, 22);
            this.tsmiDownload.Text = "下载";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(109, 6);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(112, 22);
            this.tsmiCopy.Text = "复制";
            // 
            // tsmiShear
            // 
            this.tsmiShear.Name = "tsmiShear";
            this.tsmiShear.Size = new System.Drawing.Size(112, 22);
            this.tsmiShear.Text = "剪切";
            // 
            // tsmiRename
            // 
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(112, 22);
            this.tsmiRename.Text = "重命名";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // tsmiShare
            // 
            this.tsmiShare.Enabled = false;
            this.tsmiShare.Name = "tsmiShare";
            this.tsmiShare.Size = new System.Drawing.Size(112, 22);
            this.tsmiShare.Text = "分享";
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(112, 22);
            this.tsmiDelete.Text = "删除";
            // 
            // tsmiInfo
            // 
            this.tsmiInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInfo_name,
            this.tsmiInfo_Size,
            this.tsmiInfo_Type});
            this.tsmiInfo.Name = "tsmiInfo";
            this.tsmiInfo.Size = new System.Drawing.Size(112, 22);
            this.tsmiInfo.Text = "属性";
            // 
            // tsmiInfo_name
            // 
            this.tsmiInfo_name.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInfo_CopyFileName});
            this.tsmiInfo_name.Name = "tsmiInfo_name";
            this.tsmiInfo_name.Size = new System.Drawing.Size(124, 22);
            this.tsmiInfo_name.Text = "文件名称";
            // 
            // tsmiInfo_CopyFileName
            // 
            this.tsmiInfo_CopyFileName.Name = "tsmiInfo_CopyFileName";
            this.tsmiInfo_CopyFileName.Size = new System.Drawing.Size(148, 22);
            this.tsmiInfo_CopyFileName.Text = "复制到剪贴板";
            this.tsmiInfo_CopyFileName.Click += new System.EventHandler(this.tsmiInfo_CopyFileName_Click);
            // 
            // tsmiInfo_Size
            // 
            this.tsmiInfo_Size.Name = "tsmiInfo_Size";
            this.tsmiInfo_Size.Size = new System.Drawing.Size(124, 22);
            this.tsmiInfo_Size.Text = "文件大小";
            // 
            // tsmiInfo_Type
            // 
            this.tsmiInfo_Type.Name = "tsmiInfo_Type";
            this.tsmiInfo_Type.Size = new System.Drawing.Size(124, 22);
            this.tsmiInfo_Type.Text = "文件类型";
            // 
            // cmsFolderItem
            // 
            this.cmsFolderItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenFolder,
            this.tsmiRenameFolder,
            this.tsmiMoveFolder,
            this.tsmiDeleteFolder});
            this.cmsFolderItem.Name = "cmsFolderItem";
            this.cmsFolderItem.Size = new System.Drawing.Size(153, 114);
            this.cmsFolderItem.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsFileItem_ItemClicked);
            // 
            // tsmiOpenFolder
            // 
            this.tsmiOpenFolder.Name = "tsmiOpenFolder";
            this.tsmiOpenFolder.Size = new System.Drawing.Size(152, 22);
            this.tsmiOpenFolder.Text = "打开";
            // 
            // tsmiRenameFolder
            // 
            this.tsmiRenameFolder.Enabled = false;
            this.tsmiRenameFolder.Name = "tsmiRenameFolder";
            this.tsmiRenameFolder.Size = new System.Drawing.Size(152, 22);
            this.tsmiRenameFolder.Text = "重命名";
            // 
            // tsmiMoveFolder
            // 
            this.tsmiMoveFolder.Enabled = false;
            this.tsmiMoveFolder.Name = "tsmiMoveFolder";
            this.tsmiMoveFolder.Size = new System.Drawing.Size(152, 22);
            this.tsmiMoveFolder.Text = "移动";
            // 
            // tsmiDeleteFolder
            // 
            this.tsmiDeleteFolder.Enabled = false;
            this.tsmiDeleteFolder.Name = "tsmiDeleteFolder";
            this.tsmiDeleteFolder.Size = new System.Drawing.Size(152, 22);
            this.tsmiDeleteFolder.Text = "删除";
            // 
            // timerShowFullName
            // 
            this.timerShowFullName.Interval = 50;
            this.timerShowFullName.Tick += new System.EventHandler(this.timerShowFullName_Tick);
            // 
            // FileItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labSize);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.picboxIcon);
            this.Name = "FileItem";
            this.Size = new System.Drawing.Size(100, 130);
            this.DoubleClick += new System.EventHandler(this.FileItem_DoubleClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FileItem_MouseClick);
            this.MouseLeave += new System.EventHandler(this.FileItem_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FileItem_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picboxIcon)).EndInit();
            this.cmsFileItem.ResumeLayout(false);
            this.cmsFolderItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public  System.Windows.Forms.PictureBox picboxIcon;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labSize;
        private System.Windows.Forms.ContextMenuStrip cmsFileItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDownload;
        private System.Windows.Forms.ToolStripMenuItem tsmiRename;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiShear;
        private System.Windows.Forms.ToolStripMenuItem tsmiShare;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiInfo;
        private System.Windows.Forms.ContextMenuStrip cmsFolderItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenameFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiInfo_name;
        private System.Windows.Forms.ToolStripMenuItem tsmiInfo_CopyFileName;
        private System.Windows.Forms.ToolStripMenuItem tsmiInfo_Size;
        private System.Windows.Forms.ToolStripMenuItem tsmiInfo_Type;
        private System.Windows.Forms.Timer timerShowFullName;
    }
}
