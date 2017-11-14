namespace PCloud_Client_v3
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.flpFunctionButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labFileInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.flpCurrentFolder = new System.Windows.Forms.FlowLayoutPanel();
            this.tsFolderFunction = new System.Windows.Forms.ToolStrip();
            this.tsbtnUpload = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCreateFolder = new System.Windows.Forms.ToolStripButton();
            this.tsFolderPath = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tabpageUpload = new System.Windows.Forms.TabPage();
            this.UploadTaskListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabpageDownload = new System.Windows.Forms.TabPage();
            this.DownlaodTaskListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cmsFolderList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.flpFunctionButtonPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tsFolderFunction.SuspendLayout();
            this.tsFolderPath.SuspendLayout();
            this.tabpageUpload.SuspendLayout();
            this.tabpageDownload.SuspendLayout();
            this.cmsFolderList.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.flpFunctionButtonPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer.Panel2.Controls.Add(this.tabControl);
            this.splitContainer.Size = new System.Drawing.Size(784, 561);
            this.splitContainer.SplitterDistance = 53;
            this.splitContainer.TabIndex = 2;
            // 
            // flpFunctionButtonPanel
            // 
            this.flpFunctionButtonPanel.AutoScroll = true;
            this.flpFunctionButtonPanel.Controls.Add(this.btnUser);
            this.flpFunctionButtonPanel.Controls.Add(this.btnShare);
            this.flpFunctionButtonPanel.Controls.Add(this.btnOpenFolder);
            this.flpFunctionButtonPanel.Controls.Add(this.btnSetting);
            this.flpFunctionButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFunctionButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.flpFunctionButtonPanel.Name = "flpFunctionButtonPanel";
            this.flpFunctionButtonPanel.Size = new System.Drawing.Size(784, 53);
            this.flpFunctionButtonPanel.TabIndex = 0;
            this.flpFunctionButtonPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flpFunctionButtonPanel_ControlAdded);
            // 
            // btnUser
            // 
            this.btnUser.BackgroundImage = global::PCloud_Client_v3.Properties.Resources.image_id;
            this.btnUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUser.Enabled = false;
            this.btnUser.Location = new System.Drawing.Point(3, 3);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(47, 47);
            this.btnUser.TabIndex = 1;
            this.btnUser.UseVisualStyleBackColor = true;
            // 
            // btnShare
            // 
            this.btnShare.BackgroundImage = global::PCloud_Client_v3.Properties.Resources.image_share;
            this.btnShare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShare.Enabled = false;
            this.btnShare.Location = new System.Drawing.Point(56, 3);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(47, 47);
            this.btnShare.TabIndex = 2;
            this.btnShare.UseVisualStyleBackColor = true;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.BackgroundImage = global::PCloud_Client_v3.Properties.Resources.image_folder;
            this.btnOpenFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenFolder.Location = new System.Drawing.Point(109, 3);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(47, 47);
            this.btnOpenFolder.TabIndex = 3;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundImage = global::PCloud_Client_v3.Properties.Resources.image_setting;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.Location = new System.Drawing.Point(162, 3);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(47, 47);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labFileInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 482);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labFileInfo
            // 
            this.labFileInfo.Name = "labFileInfo";
            this.labFileInfo.Size = new System.Drawing.Size(32, 17);
            this.labFileInfo.Text = "就绪";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabpageUpload);
            this.tabControl.Controls.Add(this.tabpageDownload);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ImageList = this.imageList;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(784, 504);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStripContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 477);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "我的网盘";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.flpCurrentFolder);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(770, 446);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(3, 3);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(770, 471);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsFolderFunction);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsFolderPath);
            // 
            // flpCurrentFolder
            // 
            this.flpCurrentFolder.AllowDrop = true;
            this.flpCurrentFolder.AutoScroll = true;
            this.flpCurrentFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCurrentFolder.Location = new System.Drawing.Point(0, 0);
            this.flpCurrentFolder.Margin = new System.Windows.Forms.Padding(0);
            this.flpCurrentFolder.Name = "flpCurrentFolder";
            this.flpCurrentFolder.Size = new System.Drawing.Size(770, 446);
            this.flpCurrentFolder.TabIndex = 1;
            this.flpCurrentFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpCurrentFolder_DragDrop);
            this.flpCurrentFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpCurrentFolder_DragEnter);
            this.flpCurrentFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FilelistPanel_MouseClick);
            // 
            // tsFolderFunction
            // 
            this.tsFolderFunction.Dock = System.Windows.Forms.DockStyle.None;
            this.tsFolderFunction.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsFolderFunction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnUpload,
            this.tsbtnRefresh,
            this.tsbtnCreateFolder});
            this.tsFolderFunction.Location = new System.Drawing.Point(3, 0);
            this.tsFolderFunction.Name = "tsFolderFunction";
            this.tsFolderFunction.Size = new System.Drawing.Size(103, 25);
            this.tsFolderFunction.TabIndex = 1;
            // 
            // tsbtnUpload
            // 
            this.tsbtnUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnUpload.Image = global::PCloud_Client_v3.Properties.Resources.upload;
            this.tsbtnUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUpload.Name = "tsbtnUpload";
            this.tsbtnUpload.Size = new System.Drawing.Size(23, 22);
            this.tsbtnUpload.Text = "上传";
            this.tsbtnUpload.Click += new System.EventHandler(this.tsbtnUpload_Click);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRefresh.Image = global::PCloud_Client_v3.Properties.Resources.refresh;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRefresh.Text = "刷新";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // tsbtnCreateFolder
            // 
            this.tsbtnCreateFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCreateFolder.Image = global::PCloud_Client_v3.Properties.Resources.newfolder;
            this.tsbtnCreateFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCreateFolder.Name = "tsbtnCreateFolder";
            this.tsbtnCreateFolder.Size = new System.Drawing.Size(23, 22);
            this.tsbtnCreateFolder.Text = "新建文件夹";
            this.tsbtnCreateFolder.Click += new System.EventHandler(this.tsbtnCreateFolder_Click);
            // 
            // tsFolderPath
            // 
            this.tsFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsFolderPath.Dock = System.Windows.Forms.DockStyle.None;
            this.tsFolderPath.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsFolderPath.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.tsFolderPath.Location = new System.Drawing.Point(106, 0);
            this.tsFolderPath.Name = "tsFolderPath";
            this.tsFolderPath.Size = new System.Drawing.Size(3, 25);
            this.tsFolderPath.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // tabpageUpload
            // 
            this.tabpageUpload.Controls.Add(this.UploadTaskListPanel);
            this.tabpageUpload.ImageIndex = 0;
            this.tabpageUpload.Location = new System.Drawing.Point(4, 23);
            this.tabpageUpload.Name = "tabpageUpload";
            this.tabpageUpload.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageUpload.Size = new System.Drawing.Size(776, 477);
            this.tabpageUpload.TabIndex = 1;
            this.tabpageUpload.Text = "上传列表";
            this.tabpageUpload.UseVisualStyleBackColor = true;
            // 
            // UploadTaskListPanel
            // 
            this.UploadTaskListPanel.AutoScroll = true;
            this.UploadTaskListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UploadTaskListPanel.Location = new System.Drawing.Point(3, 3);
            this.UploadTaskListPanel.Name = "UploadTaskListPanel";
            this.UploadTaskListPanel.Size = new System.Drawing.Size(770, 471);
            this.UploadTaskListPanel.TabIndex = 0;
            this.UploadTaskListPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.UploadTaskListPanel_ControlAdded);
            this.UploadTaskListPanel.Resize += new System.EventHandler(this.UploadTaskListPanel_Resize);
            // 
            // tabpageDownload
            // 
            this.tabpageDownload.Controls.Add(this.DownlaodTaskListPanel);
            this.tabpageDownload.ImageIndex = 0;
            this.tabpageDownload.Location = new System.Drawing.Point(4, 23);
            this.tabpageDownload.Name = "tabpageDownload";
            this.tabpageDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageDownload.Size = new System.Drawing.Size(776, 477);
            this.tabpageDownload.TabIndex = 2;
            this.tabpageDownload.Text = "下载列表";
            this.tabpageDownload.UseVisualStyleBackColor = true;
            // 
            // DownlaodTaskListPanel
            // 
            this.DownlaodTaskListPanel.AutoScroll = true;
            this.DownlaodTaskListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownlaodTaskListPanel.Location = new System.Drawing.Point(3, 3);
            this.DownlaodTaskListPanel.Name = "DownlaodTaskListPanel";
            this.DownlaodTaskListPanel.Size = new System.Drawing.Size(770, 471);
            this.DownlaodTaskListPanel.TabIndex = 0;
            this.DownlaodTaskListPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.UploadTaskListPanel_ControlAdded);
            this.DownlaodTaskListPanel.Resize += new System.EventHandler(this.UploadTaskListPanel_Resize);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "image_nonews.png");
            this.imageList.Images.SetKeyName(1, "image_news.png");
            // 
            // cmsFolderList
            // 
            this.cmsFolderList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpload,
            this.tsmiPaste,
            this.tsmiRefresh,
            this.tsmiCreateFolder});
            this.cmsFolderList.Name = "cmsFolderList";
            this.cmsFolderList.Size = new System.Drawing.Size(137, 92);
            this.cmsFolderList.Opening += new System.ComponentModel.CancelEventHandler(this.cmsFolderList_Opening);
            this.cmsFolderList.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsFolderList_ItemClicked);
            // 
            // tsmiUpload
            // 
            this.tsmiUpload.Name = "tsmiUpload";
            this.tsmiUpload.Size = new System.Drawing.Size(136, 22);
            this.tsmiUpload.Text = "上传";
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.Size = new System.Drawing.Size(136, 22);
            this.tsmiPaste.Text = "粘贴";
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(136, 22);
            this.tsmiRefresh.Text = "刷新";
            // 
            // tsmiCreateFolder
            // 
            this.tsmiCreateFolder.Name = "tsmiCreateFolder";
            this.tsmiCreateFolder.Size = new System.Drawing.Size(136, 22);
            this.tsmiCreateFolder.Text = "新建文件夹";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.flpFunctionButtonPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tsFolderFunction.ResumeLayout(false);
            this.tsFolderFunction.PerformLayout();
            this.tsFolderPath.ResumeLayout(false);
            this.tsFolderPath.PerformLayout();
            this.tabpageUpload.ResumeLayout(false);
            this.tabpageDownload.ResumeLayout(false);
            this.cmsFolderList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabpageUpload;
        private System.Windows.Forms.TabPage tabpageDownload;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.FlowLayoutPanel flpCurrentFolder;
        private System.Windows.Forms.ToolStrip tsFolderPath;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip tsFolderFunction;
        private System.Windows.Forms.ToolStripButton tsbtnUpload;
        private System.Windows.Forms.ToolStripButton tsbtnCreateFolder;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.FlowLayoutPanel DownlaodTaskListPanel;
        private System.Windows.Forms.FlowLayoutPanel UploadTaskListPanel;
        private System.Windows.Forms.ContextMenuStrip cmsFolderList;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpload;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaste;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateFolder;
        private System.Windows.Forms.FlowLayoutPanel flpFunctionButtonPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labFileInfo;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ImageList imageList;


    }
}