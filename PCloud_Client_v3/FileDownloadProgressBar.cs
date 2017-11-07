using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PCloud_Client_v3
{
    public partial class FileDownloadProgressBar : UserControl
    {
        public string DownloadUrl{get;set;}
        public string SavePath { get; set; }
        public string FileName { get; set; }

        public FileDownloadProgressBar()
        {
            InitializeComponent();

            SavePath = UserInstance.Instance.Configuration["DownloadFolder"];
            DirectoryInfo fi = new DirectoryInfo(SavePath);
            if (!fi.Exists) fi.Create();
        }


        public void StartDownload()
        {
            labFileName.Text = FileName;
            labSavePath.Text = SavePath + FileName;

            FileDownloader fd = new FileDownloader(DownloadUrl, SavePath, FileName);

            //下载开始事件（返回值：文件总字节数）
            fd.Started += (totalBytes) =>
            {
                MethodInvoker mi = new MethodInvoker(() =>
                {
                    progressBar.Maximum = 100;
                    progressBar.Minimum = 0;
                });
                this.BeginInvoke(mi);
            };

            //下载进度事件（返回值：已完成下载的字节数，百分比进度）
            fd.ProgressChanged += (totalDownloadedByte, percent) =>
            {
                MethodInvoker mi = new MethodInvoker(() =>
                {
                    progressBar.Value = (int)percent;
                });
                this.BeginInvoke(mi);
            };

            //下载完成事件（返回值：文件存放路径）
            fd.Finished += (savePath) =>{
                MethodInvoker mi = new MethodInvoker(() =>
                {
                    labFileName.Text = labFileName.Text + " - 已完成";
                });
                this.BeginInvoke(mi);
            };

            Task task = new Task(() =>
            {
                fd.DownloadFile();
            });
            task.Start();
        }
    }

    public class FileDownloader
    {
        public delegate void OnProgressChanged(long totalDownloadedByte, double percent);
        public event OnProgressChanged ProgressChanged;

        public delegate void OnStarted(long totalBytes);
        public event OnStarted Started;

        public delegate void OnFinished(string savePath);
        public event OnFinished Finished;

        private string DownloadUrl { get; set; }
        private string SavePath { get; set; }
        private string FileName { get; set; }

        public FileDownloader(string strDownloadUrl, string strSavePath, string strFileName)
        {
            DownloadUrl = strDownloadUrl;
            SavePath = strSavePath;
            FileName = strFileName;
        }

        /// <summary>        
        /// 下载文件        
        /// </summary>        
        /// <param name="UploadUrl">下载文件地址</param>       
        /// <param name="Filename">下载后的存放路径</param>          
        /// 
        public void DownloadFile()
        {
            double percent = 0;
            try
            {
                //网络请求工具类
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(DownloadUrl);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();

                //获取文件大小
                long totalBytes = myrp.ContentLength;
                //触发Started事件
                if (Started != null) Started(totalBytes);

                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(SavePath + FileName, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);
                    //计算已完成的百分比
                    percent = (double)totalDownloadedByte / (double)totalBytes * 100;
                    //触发ProgressChanged事件
                    if (ProgressChanged != null && percent > 0) ProgressChanged(totalDownloadedByte, percent);
                }
                so.Close();
                st.Close();
                //触发Finished事件
                if (Finished != null) Finished(SavePath);
            }
            catch (System.Exception)
            {
                //throw;
            }
        }

    }
}
