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
using System.Net;

namespace PCloud_Client_v3
{
    public partial class FileUploadProgressBar : UserControl
    {
        public string UploadUrl { get; set; }
        public string FilePath
        {
            get
            {
                return labSavePath.Text;
            }
            set
            {
                labSavePath.Text = value;
            }
        }

        public string FileName 
        {
            get
            {
                return labFileName.Text;
            }
            set
            {
                labFileName.Text = value;
            }
        
        }

        public FileUploadProgressBar()
        {
            InitializeComponent();

            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
        }


        FileUploader fu;
        public void StartUpload()
        {
            fu = new FileUploader();

            fu.Started += (totalBytes) =>
            {
                MethodInvoker mi = new MethodInvoker(() =>
                {
                    labState.ForeColor = Color.Green;
                    labState.Text = "下载中";
                });
                this.BeginInvoke(mi);
            };

            fu.ProgressChanged += (totalDownloadedByte,percent) =>
            {
                MethodInvoker mi = new MethodInvoker(() =>
                {
                    progressBar.Value = (int)(percent*100);
                });
                this.BeginInvoke(mi);
            };

            fu.Finished += (savePath) =>
            {
                MethodInvoker mi = new MethodInvoker(() =>
                {
                    labState.ForeColor = Color.Blue;
                    labState.Text = "已完成";
                    llabCancel.Enabled = false;
                });
                this.BeginInvoke(mi);
            };

            //执行上传
            Task task = new Task(() =>
            {
                fu.UploadFile(UploadUrl, FilePath, null);
            });
            task.Start();
        }

        private void llabCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fu.isCancel = true;
        }
    }

    public class FileUploader
    {
        public delegate void OnProgressChanged(long totalDownloadedByte, double percent);
        public event OnProgressChanged ProgressChanged;

        public delegate void OnStarted(long totalBytes);
        public event OnStarted Started;

        public delegate void OnFinished(string savePath);
        public event OnFinished Finished;

        public Boolean isCancel { set; get; }

        public string UploadFile(string strURL, string strFilePath ,Dictionary<string,string> dict)
        {
            List<FormItemModel> formDatas = new List<FormItemModel>();
            //添加文件
            string name = new FileInfo(strFilePath).Name;
            formDatas.Add(new FormItemModel()
            {
                Key = "file",
                Value = "",
                FileName = name,
                FileContent = File.OpenRead(strFilePath)
            });
            //添加键值对
            if(dict != null){
                foreach (string k in dict.Keys)
                {
                    formDatas.Add(new FormItemModel()
                    {
                        Key = k,
                        Value = dict[k]
                    });
                }
            }

            //提交表单
            string result = PostForm(strURL, formDatas);
            
            if (Finished != null) Finished(strFilePath);

            return result;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果
        /// </summary>
        /// <param name="UploadUrl"></param>
        /// <param name="formItems">Post表单内容</param>
        /// <param name="cookieContainer"></param>
        /// <param name="timeOut">默认20秒</param>
        /// <param name="encoding">响应内容的编码类型（默认utf-8）</param>
        /// <returns></returns>
        public string PostForm(string url, List<FormItemModel> formItems, CookieContainer cookieContainer = null, string refererUrl = null, Encoding encoding = null, int timeOut = 20000)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            #region 初始化请求对象
            request.Method = "POST";
            request.Timeout = timeOut;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
            if (!string.IsNullOrEmpty(refererUrl))
                request.Referer = refererUrl;
            if (cookieContainer != null)
                request.CookieContainer = cookieContainer;
            #endregion

            string boundary = "----" + DateTime.Now.Ticks.ToString("x");//分隔符
            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            //请求流
            var postStream = new MemoryStream();
            #region 处理Form表单请求内容
            //是否用Form上传文件
            var formUploadFile = formItems != null && formItems.Count > 0;
            if (formUploadFile)
            {
                //文件数据模板
                string fileFormdataTemplate =
                    "\r\n--" + boundary +
                    "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" +
                    "\r\nContent-Type: application/octet-stream" +
                    "\r\n\r\n";
                //文本数据模板
                string dataFormdataTemplate =
                    "\r\n--" + boundary +
                    "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                    "\r\n\r\n{1}";
                foreach (FormItemModel item in formItems)
                {
                    string formdata = null;
                    if (item.IsFile)
                    {
                        //上传文件
                        formdata = string.Format(
                            fileFormdataTemplate,
                            item.Key, //表单键
                            item.FileName);
                    }
                    else
                    {
                        //上传文本
                        formdata = string.Format(
                            dataFormdataTemplate,
                            item.Key,
                            item.Value);
                    }

                    //统一处理
                    byte[] formdataBytes = null;
                    //第一行不需要换行
                    if (postStream.Length == 0)
                        formdataBytes = Encoding.UTF8.GetBytes(formdata.Substring(2, formdata.Length - 2));
                    else
                        formdataBytes = Encoding.UTF8.GetBytes(formdata);
                    postStream.Write(formdataBytes, 0, formdataBytes.Length);

                    //获取文件长度
                    long fileLength = item.FileContent.Length;
                    //返回上传文件的大小
                    if (Started!=null) Started(fileLength);
                    //写入文件内容
                    if (item.FileContent != null && fileLength > 0)
                    {
                        int sendLength = 0;
                        using (var stream = item.FileContent)
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead = 0;
                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                if (isCancel) return "{\"content\":\"{\"flag\":\"false\",\"message\":\"上传任务已取消\",\"action\":\"UserLogin\"} ";
                                sendLength += bytesRead;
                                //分段上传文件
                                postStream.Write(buffer, 0, bytesRead);
                                //通过事件返回文件上传的状态
                                if (ProgressChanged != null) ProgressChanged(sendLength, sendLength / fileLength);
                            }
                        }
                    }


                }
                //结尾
                var footer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
                postStream.Write(footer, 0, footer.Length);
            }
            else
            {
                request.ContentType = "application/x-www-form-urlencoded";
            }
            #endregion

            request.ContentLength = postStream.Length;

            #region 输入二进制流
            if (postStream != null)
            {
                postStream.Position = 0;
                //直接写入流
                Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                ////debug
                //postStream.Seek(0, SeekOrigin.Begin);
                //StreamReader sr = new StreamReader(postStream);
                //var postStr = sr.ReadToEnd();
                postStream.Close();//关闭文件访问
            }
            #endregion

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (cookieContainer != null)
            {
                response.Cookies = cookieContainer.GetCookies(response.ResponseUri);
            }

            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(responseStream, encoding ?? Encoding.UTF8))
                {
                    string retString = myStreamReader.ReadToEnd();
                    return retString;
                }
            }
        }
    }

    /// <summary>
    /// 表单数据项
    /// </summary>
    public class FormItemModel
    {
        /// <summary>
        /// 表单键，request["key"]
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// 表单值,上传文件时忽略，request["key"].value
        /// </summary>
        public string Value { set; get; }
        /// <summary>
        /// 是否是文件
        /// </summary>
        public bool IsFile
        {
            get
            {
                if (FileContent == null || FileContent.Length == 0)
                    return false;

                if (FileContent != null && FileContent.Length > 0 && FileName == null && FileName.Equals(""))
                    throw new Exception("上传文件时 FileName 属性值不能为空");
                return true;
            }
        }
        /// <summary>
        /// 上传的文件名
        /// </summary>
        public string FileName { set; get; }
        /// <summary>
        /// 上传的文件内容
        /// </summary>
        public Stream FileContent { set; get; }
    }
}
