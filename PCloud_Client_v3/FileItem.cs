using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace PCloud_Client_v3
{
    public partial class FileItem : UserControl
    {
        public FileJson fileInfo { get; set; }
        public FolderJson folderInfo { get; set; }
        private IFileItemCallBack callback;
        private Type ItemType;
        public enum Type
        {
            FILE, FOLDER
        }

        public FileItem(Type t, JObject json, IFileItemCallBack callback)
        {
            InitializeComponent();
            //文件图标的类型
            ItemType = t;
            //回调接口
            this.callback = callback;
            //文件图标
            if (t == Type.FILE)
            {
                fileInfo = new FileJson(json);

                labName.Text = fileInfo.filename;
                labSize.Text = fileInfo.FileSize();
                picboxIcon.BackgroundImage = fileInfo.fileIcon;
            }
            //文件夹图标
            else if (t == Type.FOLDER)
            {
                folderInfo = new FolderJson(json);

                labName.Text = folderInfo.foldername;
                labSize.Text = "";
                picboxIcon.BackgroundImage = folderInfo.folderIcon;
            }
            //控件居中对齐
            AlignCenter();

        }

        /// <summary>
        /// FileItem控件中所有控件居中
        /// </summary>
        private void AlignCenter()
        {
            foreach (Control c in this.Controls)
            {
                c.Left = (this.Width - c.Width) / 2;
            }
        }

        private void FileItem_MouseMove(object sender, MouseEventArgs e)
        {
            //通过回调接口返回信息
            callback.IFileItemCallBack_OnMouseMove(ItemType, this);

            //如果文件名过长则滚动显示完整文件名
            if (labName.Width > this.Width)
            {
                timerShowFullName.Enabled = true;
            }
        }

        private void FileItem_DoubleClick(object sender, EventArgs e)
        {
            callback.IFileItemCallBack_OnDoubleClick(ItemType, this);
        }

        private void FileItem_MouseClick(object sender, MouseEventArgs e)
        {
            //picboxIcon_MouseClick(sender, e);
            //右键单击显示快捷菜单
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //如果是文件项
                if (ItemType == Type.FILE)
                {
                    //显示文件快捷菜单
                    cmsFileItem.Show(Cursor.Position);
                }
                //如果是文件夹项
                else if (ItemType == Type.FOLDER)
                {
                    //显示文件夹快捷菜单
                    cmsFolderItem.Show(Cursor.Position);
                }
            }
            //左键单击
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //通过回调接口返回信息
                callback.IFileItemCallBack_OnMouseClick(ItemType, this);
            }
        }

        private void cmsFileItem_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsFileItem.Hide();
            cmsFolderItem.Hide();
            callback.IFileItemCallBack_OnFileItemMenuStripClick(ItemType, e.ClickedItem, this);
        }

        private void cmsFileItem_Opening(object sender, CancelEventArgs e)
        {
            tsmiInfo_name.Text = "名称： " + this.fileInfo.filename;
            tsmiInfo_Size.Text = "大小： " + this.fileInfo.FileSize();
            tsmiInfo_Type.Text = "类型： " + this.fileInfo.type.ToUpper();
        }

        /// <summary>
        /// 复制文件名到剪贴板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiInfo_CopyFileName_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.fileInfo.filename);
        }

        private void timerShowFullName_Tick(object sender, EventArgs e)
        {
            if(labName.Left < (this.Width - labName.Width)*1.3){
                labName.Left = this.Width/3;
            }
            else
            {
                labName.Left = labName.Left - 1;
            }
        }

        private void FileItem_MouseLeave(object sender, EventArgs e)
        {
            timerShowFullName.Enabled = false;
        }

    }

    /// <summary>
    /// 用于解析文件格式json数据的工具类
    /// </summary>
    public class FileJson
    {
        public int fileid{set;get;}
        public string tempcode { set; get; }
        public string md5 { set; get; }
        public string filename { set; get; }
        public int size { set; get; }
        public Image fileIcon {get; set; }
        public string type { get; set; }

        public FileJson(JObject json)
        {
            fileid = (int)json.GetValue("id");
            tempcode = json.GetValue("tempcode").ToString();
            md5 = json.GetValue("md5").ToString();
            filename = json.GetValue("filename").ToString();
            size = (int)json.GetValue("size");

            init();
        }

        private void init()
        {
            int dot;

            //获取文件名中最后一个字符‘.’在文件名中的位置
            dot = filename.LastIndexOf('.');
            //判断文件是否有后缀名(时候包含‘.’ 或 ‘.’是否在首位 或 末尾为‘.’)
            if (dot == -1 || dot ==0 || filename[filename.Length-1]=='.')
            {
                //设置表示未知文件的图标
                fileIcon = Image.FromFile(@".\icon\null.png");
            }
            //获取文件后缀
            type = filename.Substring(dot+1);
            //设置与文件后缀对应的图标
            try
            {
                fileIcon = Image.FromFile(@".\icon\" + type + ".png");
            }
            catch
            {
                fileIcon = Image.FromFile(@".\icon\null.png");
            }
        }

        /// <summary>
        /// 将文件的字节大小转换为带有进制单位的字符串
        /// </summary>
        /// <returns></returns>
        public string FileSize(){
            double filesize = size;
            string[] arr = new string[] { "B", "KB", "MB", "GB", "TB" };
            int i = 0;
            while (true)
            {
                if (filesize > 1024 && i < arr.Length)
                {
                    filesize = filesize / 1024;
                    i++;
                }
                else
                {
                    return string.Format("{0:#.00} {1}", filesize, arr[i]);
                }
            }
        }
    }

    /// <summary>
    /// 用于解析文件夹格式json数据的工具类
    /// </summary>
    public class FolderJson
    {
        public string foldername { set; get; }
        public int folderid { set; get; }
        public Image folderIcon { private set; get; }
        

        public FolderJson(JObject json)
        {
            foldername = json.GetValue("foldername").ToString();
            folderid = (int)json.GetValue("id");

            init();
        }

        private void init()
        {
            folderIcon = Image.FromFile(@".\icon\folder.png");
        }
    }

    public interface IFileItemCallBack
    {
        /// <summary>
        /// 当鼠标移动到文件图标上的时候
        /// </summary>
        /// <param name="type"></param>
        /// <param name="item"></param>
        void IFileItemCallBack_OnMouseMove(FileItem.Type type, FileItem item);

        /// <summary>
        /// 当鼠标左键单击文件图标的时候
        /// </summary>
        /// <param name="type"></param>
        /// <param name="item"></param>
        void IFileItemCallBack_OnMouseClick(FileItem.Type type, FileItem item);

        /// <summary>
        /// 当双击文件图标时
        /// </summary>
        /// <param name="type"></param>
        /// <param name="item"></param>
        void IFileItemCallBack_OnDoubleClick(FileItem.Type type, FileItem item);

        /// <summary>
        /// 当文件图标的快捷菜单项被单击时
        /// </summary>
        /// <param name="type"></param>
        /// <param name="menuItem"></param>
        /// <param name="item"></param>
        void IFileItemCallBack_OnFileItemMenuStripClick(FileItem.Type type, ToolStripItem menuItem, FileItem item);
    }
}
