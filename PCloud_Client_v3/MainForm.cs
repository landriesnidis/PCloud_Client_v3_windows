using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCloud_Client_v3
{
    

    public partial class MainForm : Form,IFileItemCallBack
    {
        public Color COLOR_FILEITEM_MOUSEMOVE = System.Drawing.Color.FromArgb(245, 245, 245);
        public Color COLOR_FILEITEM_CLICKED = System.Drawing.Color.FromArgb(220, 220, 220);

        private int CuttentFolderID = UserInstance.Instance.RootFolderID;

        
        //文件操作类型
        private FileItemOperationType FileOperation_Type = FileItemOperationType.NONE;
        //被操作项所在文件夹id
        private int FileOperation_FolderID = 0;
        //被操作项的id
        private int FileOperation_ItemID = 0;

        /// <summary>
        /// 文件操作类型枚举
        /// </summary>
        enum FileItemOperationType
        {
            NONE,FILE_COPY,FILE_SHEAR,FOLDER_COPY,FOLDER_SHEAR
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //默认读取用户根目录
            openFolder("我的网盘", CuttentFolderID);

            //
            this.Text = string.Format("{0} - {1} - {2}", Application.ProductName,Application.ProductVersion,UserInstance.Instance.Configuration["Username"]);
        }

        /// <summary>
        /// 读取指定文件夹ID的文件夹内容
        /// </summary>
        private void readFolderMenu(int folderid)
        {
            //异步HTTP请求
            AsyncHttpRequester ahr = new AsyncHttpRequester();
            ahr.PostExecute += (result) =>
            {
                ActionJson ajson = new ActionJson(result);
                if (ajson.flag)
                {
                    //获取文件夹json数据
                    JObject jsonContent = JObject.Parse(ajson.content);
                    //读取文件夹json数组
                    JArray jsonFolders = (JArray)jsonContent.GetValue("folder");
                    //读取文件json数组
                    JArray jsonFiles = (JArray)jsonContent.GetValue("file");

                    //跨线程修改UI
                    MethodInvoker mi = new MethodInvoker(() =>
                    {
                        //清空文件图标
                        flpCurrentFolder.Controls.Clear();


                        //读取文件夹json数组数据，并添加文件夹图标
                        for (int i = 0; i < jsonFolders.Count; i++)
                        {
                            JObject jsonFolder = (JObject)jsonFolders[i];
                            FileItem item = new FileItem(FileItem.Type.FOLDER, jsonFolder,this);
                            flpCurrentFolder.Controls.Add(item);
                        }

                        //将读取到的文件信息显示在界面上
                        for (int i = 0; i < jsonFiles.Count; i++)
                        {
                            //读取文件json数组数据，并添加文件图标
                            JObject jsonFile = (JObject)jsonFiles[i];
                            FileItem item = new FileItem(FileItem.Type.FILE, jsonFile,this);
                            flpCurrentFolder.Controls.Add(item);
                        }

                        System.Windows.Forms.Application.DoEvents();
                    });
                    this.BeginInvoke(mi);
                }
                else
                {
                    MessageBox.Show(ajson.message);
                }
            };
            ahr.PostHttpResponse(URL.GetUrl_FolderMenu(folderid), null);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //当该窗体被关闭时，向服务器发出登出命令
            HttpResponse.PostHttpResponse(URL.GetUrl_UserLogout(), null);

            //更新配置文件
            UserInstance.Instance.UpdateConfigFile();

            Application.Exit();
        }

        public void IFileItemCallBack_OnMouseMove(FileItem.Type type, FileItem item)
        {
            //将文件列表里面的所有的控件背景色改为其容器的背景色
            foreach (Control c in flpCurrentFolder.Controls)
            {
                c.BackColor = flpCurrentFolder.BackColor;
            }
            //将鼠标移动过的文件图标背景色改为特定背景色
            item.BackColor = COLOR_FILEITEM_MOUSEMOVE;
        }

        public void IFileItemCallBack_OnMouseClick(FileItem.Type type,FileItem item)
        {
            
            if(type == FileItem.Type.FILE){
                //MessageBox.Show("单击文件：" + item.fileInfo.filename);
                string info = string.Format("{0} - {1}",item.fileInfo.filename,item.fileInfo.FileSize());
                labFileInfo.Text = info;
            }else{
                //MessageBox.Show("单击文件夹：" + item.folderInfo.foldername);
            }
            item.BackColor = COLOR_FILEITEM_CLICKED;
        }


        public void IFileItemCallBack_OnDoubleClick(FileItem.Type type, FileItem item)
        {
            
            if (type == FileItem.Type.FILE)
            {
                //下载文件
                downloadFile(item.fileInfo.filename, item.fileInfo.fileid);
            }
            else
            {
                //打开所选的文件夹
                openFolder(item.folderInfo.foldername, item.folderInfo.folderid);
            }
        }

        public void IFileItemCallBack_OnFileItemMenuStripClick(FileItem.Type type, ToolStripItem menuItem, FileItem item)
        {
            //如果是文件的快捷菜单项被单击
            if (type == FileItem.Type.FILE)
            {
                //判断被单击的快捷菜单项
                switch (menuItem.Name)
                {
                    //下载
                    case "tsmiDownload":
                        downloadFile(item.fileInfo.filename, item.fileInfo.fileid);
                        break;
                    //删除
                    case "tsmiDelete":
                        deleteFile(item);
                        break;
                    //重命名
                    case "tsmiRename":
                        string newfilename = Microsoft.VisualBasic.Interaction.InputBox("请输入文件的新名称：", "重命名", item.fileInfo.filename);
                        if (newfilename == null || newfilename == "") return;
                        renameFile(CuttentFolderID,item.fileInfo.fileid,newfilename);
                        break;
                    //复制
                    case "tsmiCopy":
                        FileOperation_Type = FileItemOperationType.FILE_COPY;
                        FileOperation_ItemID = item.fileInfo.fileid;
                        FileOperation_FolderID = CuttentFolderID;
                        labFileInfo.Text = "复制文件 - " + item.fileInfo.filename;
                        break;
                    //剪切
                    case "tsmiShear":
                        FileOperation_Type = FileItemOperationType.FILE_SHEAR;
                        FileOperation_ItemID = item.fileInfo.fileid;
                        FileOperation_FolderID = CuttentFolderID;
                        labFileInfo.Text = "剪切文件 - " + item.fileInfo.filename;
                        break;
                    default:
                        MessageBox.Show("文件名：" + item.fileInfo.filename + "\n" + menuItem.Text + " 功能未完成.");
                        break;
                }

            }
            //如果是文件夹的快捷菜单项被单击
            else if (type == FileItem.Type.FOLDER)
            {
                switch (menuItem.Name)
                {
                    //打开文件夹
                    case "tsmiOpenFolder":
                        //打开所选的文件夹
                        openFolder(item.folderInfo.foldername, item.folderInfo.folderid);
                        break;
                    //删除文件夹
                    //case "tsmiDeleteFolder":
                    //    deleteFolder(item);
                    //    break;
                    default:
                        MessageBox.Show("文件夹名：" + item.folderInfo.foldername + "\n" + menuItem.Text + " 功能未完成.");
                        break;
                }
            }
        }

        private void renameFile(int folderid, int fileid, string newfilename)
        {
            string strURL = URL.GetUrl_RenameFile(folderid, fileid, newfilename);

            //异步HTTP请求
            AsyncHttpRequester ahr = new AsyncHttpRequester();
            ahr.PostExecute += (result) =>
            {
                //获取Json数据
                ActionJson ajson = new ActionJson(result);

                //重命名成功
                if (ajson.flag)
                {
                    //跨线程修改UI
                    MethodInvoker mi = new MethodInvoker(() =>
                    {
                        readFolderMenu(CuttentFolderID);
                    });
                    this.BeginInvoke(mi);
                }
                //失败
                else
                {
                    //提示错误信息
                    MessageBox.Show(ajson.message);
                }
            };
            ahr.GetHttpResponse(strURL, null);
        }

        private void downloadFile(string filename,int fileid)
        {
            //获取文件下载的url
            string strURL = URL.GetUrl_Download(filename, fileid);

            //实例化一个文件下载器控件
            FileDownloadProgressBar fdpb = new FileDownloadProgressBar();
            fdpb.FileName = filename;
            fdpb.DownloadUrl = strURL;

            //将文件上传器控件添加到下载任务的面板内
            DownlaodTaskListPanel.Controls.Add(fdpb);
            fdpb.Dock = DockStyle.Top;

            //执行异步下载任务
            fdpb.StartDownload();

            //选项卡页面跳转至下载页面
            tabControl.SelectedIndex = 2;
        }


        private void uploadFile(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            string strURL = URL.GetUrl_Upload(fi.Name, MD5.GetMD5HashFromFile(filePath), CuttentFolderID);

            //实例化一个文件上传器控件
            FileUploadProgressBar fupb = new FileUploadProgressBar();
            fupb.UploadUrl = strURL;
            fupb.FilePath = filePath;
            fupb.FileName = fi.Name;

            //将文件上传器控件添加到上传任务的面板内
            UploadTaskListPanel.Controls.Add(fupb);

            //执行异步上传任务
            fupb.StartUpload();
            
            //选项卡页面跳转至上传页面
            tabControl.SelectedIndex = 1;
            
        }

        private void deleteFile(FileItem item)
        {
            //删除文件HTTP请求
            string result = HttpResponse.GetHttpResponse(URL.GetUrl_DeleteFile(CuttentFolderID,item.fileInfo.fileid), null);
            ActionJson ajson = new ActionJson(result);
            //执行成功
            if (ajson.flag)
            {
                //移除指定文件的图标
                flpCurrentFolder.Controls.Remove(item);
            }
            else
            {
                MessageBox.Show(ajson.message);
            }
        }

        private void createFolder(){

            string strFolderName = Microsoft.VisualBasic.Interaction.InputBox("请输入新文件夹的名称：", "新建文件夹", "");

            if (strFolderName == null || strFolderName == "") return;

            string result = HttpResponse.GetHttpResponse(URL.GetUrl_CreateFolder(CuttentFolderID, strFolderName), null);
            ActionJson ajson = new ActionJson(result);
            if(ajson.flag){
                JObject jsonFolder = new JObject();
                jsonFolder.Add("id", ajson.content);
                jsonFolder.Add("foldername", strFolderName);
                FileItem item = new FileItem(FileItem.Type.FOLDER, jsonFolder, this);
                flpCurrentFolder.Controls.Add(item);
            }
            else
            {
                MessageBox.Show(ajson.message);
            }
        }

        private void deleteFolder(FileItem item)
        {
            
        }

        private void openFolder(string foldername, int folderid)
        {
            CuttentFolderID = folderid;
            readFolderMenu(folderid);
            addPathBarItem(foldername,folderid);
        }

        private void fileCopy(string strURL)
        {
            //异步HTTP请求
            AsyncHttpRequester ahr = new AsyncHttpRequester();
            ahr.PostExecute += (result) =>
            {
                //获取Json数据
                ActionJson ajson = new ActionJson(result);

                //文件拷贝成功
                if (ajson.flag)
                {
                    //跨线程修改UI
                    MethodInvoker mi = new MethodInvoker(() =>
                    {
                        readFolderMenu(CuttentFolderID);
                    });
                    this.BeginInvoke(mi);
                }
                //文件拷贝失败
                else
                {
                    //提示错误信息
                    MessageBox.Show(ajson.message);
                }
            };
            ahr.GetHttpResponse(strURL, null);
        }


        private void addPathBarItem(string foldername,int folderid)
        {
            //为路径栏添加一个ToolStripItem作为文件夹图标
            //ToolStripItem分两部分：ToolStripButton、ToolStripLabel

            //实例化ToolStripButton对象
            ToolStripButton tsbtn = new ToolStripButton();
            tsbtn.Name = "tsbtnFolderItem_id" + folderid;
            tsbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbtn.Size = new System.Drawing.Size(76, 22);
            tsbtn.Text = foldername;
            //如果路径栏中没有文件夹图标则显示home图标，否则显示folder图标(初始状态有1项元素)
            if (tsFolderPath.Items.Count == 1)
                tsbtn.Image = global::PCloud_Client_v3.Properties.Resources.home;
            else
                tsbtn.Image = global::PCloud_Client_v3.Properties.Resources.folder;

            //实例化ToolStripLabel对象
            ToolStripLabel tslab = new ToolStripLabel();
            tslab.Name = "tslabFolderItem_id" + folderid;
            tslab.Size = new System.Drawing.Size(0, 22);

            //将图标添加至路径栏中
            tsFolderPath.Items.AddRange(new ToolStripItem[] {tsbtn,tslab});
            tsFolderPath.PerformLayout();

            //为该图标添加单击事件
            tsbtn.Click += (s, r) =>
            {
                //读取对应的目录
                CuttentFolderID = folderid;
                readFolderMenu(folderid);

                //删除路径栏中后续的内容
                int index = tsFolderPath.Items.IndexOf(tslab);
                for (int i = index + 1; i < tsFolderPath.Items.Count;)
                {
                    tsFolderPath.Items.RemoveAt(i);
                }
            };
        }

        private void tsbtnCreateFolder_Click(object sender, EventArgs e)
        {
            //创建文件夹
            createFolder();
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            //刷新当前文件夹的目录
            readFolderMenu(CuttentFolderID);
        }

        private void tsbtnUpload_Click(object sender, EventArgs e)
        {
            //打开一个文件选择器
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择要上传的文件";
            ofd.ShowDialog();

            if (ofd.FileName == null || ofd.FileName == "") return;

            //执行文件上传
            uploadFile(ofd.FileName);
        }

        private void UploadTaskListPanel_Resize(object sender, EventArgs e)
        {
            foreach (Control c in UploadTaskListPanel.Controls)
            {
                c.Width = UploadTaskListPanel.Width;
            }
        }

        private void UploadTaskListPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Width = UploadTaskListPanel.Width;
        }

        private void cmsFolderList_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                //粘贴项
                case "tsmiPaste":
                    //判断操作类型
                    switch (FileOperation_Type)
                    {
                        case FileItemOperationType.FILE_COPY:
                            string strURL_FileCopy = URL.GetUrl_CopyFile(FileOperation_FolderID, CuttentFolderID, FileOperation_ItemID);
                            fileCopy(strURL_FileCopy);
                            break;
                        case FileItemOperationType.FILE_SHEAR:
                            string strURL_FileShear = URL.GetUrl_MoveFile(FileOperation_FolderID, CuttentFolderID, FileOperation_ItemID);
                            fileCopy(strURL_FileShear);//文件移动和拷贝的操作非常类似
                            //剪切执行完成后操作类型置空
                            FileOperation_Type = FileItemOperationType.NONE;
                            break;
                        default:
                            break;
                    }
                    break;
                case "tsmiUpload":
                    //打开一个文件选择器
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Title = "选择要上传的文件";
                    ofd.ShowDialog();

                    if (ofd.FileName == null || ofd.FileName == "") return;

                    //执行文件上传
                    uploadFile(ofd.FileName);
                    break;
                case "tsmiRefresh":
                    readFolderMenu(CuttentFolderID);
                    break;
                case "tsmiCreateFolder":
                    createFolder();
                    break;
                default:
                    break;
            }
        }

        private void FilelistPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cmsFolderList.Show(Cursor.Position);
            }
        }

        private void cmsFolderList_Opening(object sender, CancelEventArgs e)
        {
            //将快捷菜单内所有项都设为可用
            foreach (ToolStripItem tsi in cmsFolderList.Items)
            {
                try
                {
                    tsi.Enabled = true;
                }
                catch
                {}
            }

            //如果文件项操作为空则屏蔽粘贴功能
            if (FileOperation_Type == FileItemOperationType.NONE)
            {
                tsmiPaste.Enabled = false;
            }
        }

        private void flpFunctionButtonPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Height = flpFunctionButtonPanel.Height;
            e.Control.Width = e.Control.Height;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            new SettingForm().ShowDialog();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(UserInstance.Instance.Configuration["DownloadFolder"]);
        }


    }
}
