using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCloud_Client_v3
{
    public class AsyncHttpRequester
    {
        public delegate void OnPostExecute(string result);
        public event OnPostExecute PostExecute;

        public void GetHttpResponse(string url, IWebProxy webProxy)
        {
            //创建任务
            Task task = new Task(() =>
            {
                string result = HttpResponse.GetHttpResponse(url, webProxy);
                PostExecute(result);
            });
            task.Start();
        }

        public void PostHttpResponse(string url, IWebProxy webProxy)
        {
            //创建任务
            Task task = new Task(() =>
            {
                string result = HttpResponse.PostHttpResponse(url, webProxy);
                PostExecute(result);
            });
            task.Start();
        }

        public void PostHttpResponse(string url, IWebProxy webProxy, IDictionary<string, string> postDict)
        {
            //创建任务
            Task task = new Task(() =>
            {
                string result = HttpResponse.PostHttpResponse(url, webProxy, postDict);
                PostExecute(result);
            });
            task.Start();
        }

    }

    public class HttpResponse
    {
        #region Static Field

        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        #endregion Static Field

        #region public Method

        /// <summary>
        /// Get方法获取数据
        /// </summary>
        /// <param name="UploadUrl"></param>
        /// <returns></returns>
        public static string GetHttpResponse(string url, IWebProxy webProxy)
        {
            string result = string.Empty;
            Encoding encoding = Encoding.UTF8;
            HttpWebResponse Response = CreateGetHttpResponse(new HttpGetParametersModel()
            {
                Url = url,
                WebProxy = webProxy
            });
            result = GetStream(Response, encoding);
            return result;
        }

        /// <summary>
        /// Post Url获取数据
        /// </summary>
        /// <param name="UploadUrl"></param>
        /// <returns></returns>
        public static string PostHttpResponse(string url, IWebProxy webProxy)
        {
            string result = string.Empty;
            Encoding encoding = Encoding.UTF8;
            HttpWebResponse Response = CreatePostHttpResponse(new HttpPostParametersModel()
            {
                Url = url,
                RequestEncoding = encoding,
                WebProxy = webProxy
            });
            result = GetStream(Response, encoding);
            return result;
        }

        /// <summary>
        ///  Post带参数的 Url获取数据
        /// </summary>
        /// <param name="UploadUrl"></param>
        /// <param name="postDict"></param>
        /// <returns></returns>
        public static string PostHttpResponse(string url, IWebProxy webProxy, IDictionary<string, string> postDict)
        {
            string result = string.Empty;
            Encoding encoding = Encoding.UTF8;
            HttpWebResponse Response = CreatePostHttpResponse(new HttpPostParametersModel()
            {
                Url = url,
                DictParameters = postDict,
                WebProxy = webProxy,
                RequestEncoding = encoding
            });
            result = GetStream(Response, encoding);
            return result;
        }

        /// <summary>
        /// 创建GET方式的HTTP请求
        /// </summary>
        /// <param name="UploadUrl">请求的URL</param>
        /// <param name="timeout">请求的超时时间</param>
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>
        /// <returns></returns>
        public static HttpWebResponse CreateGetHttpResponse(HttpGetParametersModel getParametersModel)
        {
            if (string.IsNullOrEmpty(getParametersModel.Url))
            {
                throw new ArgumentNullException("getParametersModel.Url");
            }
            HttpWebRequest request = WebRequest.Create(getParametersModel.Url) as HttpWebRequest;
            if (getParametersModel.WebProxy != null)
            {
                request.Proxy = getParametersModel.WebProxy;
            }
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;
            if (!string.IsNullOrEmpty(getParametersModel.UserAgent))
            {
                request.UserAgent = getParametersModel.UserAgent;
            }
            if (getParametersModel.Timeout.HasValue)
            {
                request.Timeout = getParametersModel.Timeout.Value;
            }
            if (getParametersModel.Cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(getParametersModel.Cookies);
            }
            return request.GetResponse() as HttpWebResponse;
        }

        /// <summary>
        /// 创建POST方式的HTTP请求
        /// </summary>
        /// <param name="UploadUrl">请求的URL</param>
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>
        /// <param name="timeout">请求的超时时间</param>
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>
        /// <returns></returns>
        public static HttpWebResponse CreatePostHttpResponse(HttpPostParametersModel postParametersModel)
        {
            if (string.IsNullOrEmpty(postParametersModel.Url))
            {
                throw new ArgumentNullException("postParametersModel.Url");
            }
            if (postParametersModel.RequestEncoding == null)
            {
                throw new ArgumentNullException("postParametersModel.RequestEncoding");
            }
            HttpWebRequest request = null;
            //如果是发送HTTPS请求
            if (postParametersModel.Url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(postParametersModel.Url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(postParametersModel.Url) as HttpWebRequest;
            }
            if (postParametersModel.WebProxy != null)
            {
                request.Proxy = postParametersModel.WebProxy;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            if (!string.IsNullOrEmpty(postParametersModel.UserAgent))
            {
                request.UserAgent = postParametersModel.UserAgent;
            }
            else
            {
                request.UserAgent = DefaultUserAgent;
            }

            if (postParametersModel.Timeout.HasValue)
            {
                request.Timeout = postParametersModel.Timeout.Value;
            }
            if (postParametersModel.Cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(postParametersModel.Cookies);
            }
            //如果需要POST数据
            if (!(postParametersModel.DictParameters == null || postParametersModel.DictParameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in postParametersModel.DictParameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, postParametersModel.DictParameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, postParametersModel.DictParameters[key]);
                    }
                    i++;
                }
                byte[] data = postParametersModel.RequestEncoding.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }

        #endregion public Method

        #region Private Method

        /// <summary>
        /// 设置https证书校验机制,默认返回True,验证通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受
        }

        /// <summary>
        /// 将response转换成文本
        /// </summary>
        /// <param name="response"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static string GetStream(HttpWebResponse response, Encoding encoding)
        {
            try
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    switch (response.ContentEncoding.ToLower())
                    {
                        case "gzip":
                            {
                                string result = Decompress(response.GetResponseStream(), encoding);
                                response.Close();
                                return result;
                            }
                        default:
                            {
                                using (StreamReader sr = new StreamReader(response.GetResponseStream(), encoding))
                                {
                                    string result = sr.ReadToEnd();
                                    sr.Close();
                                    sr.Dispose();
                                    response.Close();
                                    return result;
                                }
                            }
                    }
                }
                else
                {
                    response.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return "";
        }

        private static string Decompress(Stream stream, Encoding encoding)
        {
            byte[] buffer = new byte[100];
            //int length = 0;

            using (GZipStream gz = new GZipStream(stream, CompressionMode.Decompress))
            {
                //GZipStream gzip = new GZipStream(res.GetResponseStream(), CompressionMode.Decompress);
                using (StreamReader reader = new StreamReader(gz, encoding))
                {
                    return reader.ReadToEnd();
                }
                /*
                using (MemoryStream msTemp = new MemoryStream())
                {
                    //解压时直接使用Read方法读取内容，不能调用GZipStream实例的Length等属性，否则会出错：System.NotSupportedException: 不支持此操作；
                    while ((length = gz.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        msTemp.Write(buffer, 0, length);
                    }

                    return encoding.GetString(msTemp.ToArray());
                }
                 * */
            }
        }

        #endregion Private Method

        #region 废弃方法

        /// <summary>
        /// 创建POST方式Json数据的HTTP请求（包括了https站点请求）
        /// </summary>
        /// <param name="UploadUrl">请求的URL</param>
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>
        /// <param name="timeout">请求的超时时间</param>
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>
        /// <returns></returns>
        [Obsolete("该方法暂时废弃")]
        private HttpWebResponse CreatePostHttpResponseJson(string url, string postJson, string parameters, int? timeout, string userAgent, Encoding requestEncoding, string referer)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (requestEncoding == null)
            {
                throw new ArgumentNullException("requestEncoding");
            }

            HttpWebRequest request = null;
            //如果是发送HTTPS请求
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }

            request.Method = "POST";
            //服务端 判断 客户端 提交的是否是 JSON数据 时
            request.ContentType = "application/json;charset=UTF-8";
            request.KeepAlive = true;

            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            else
            {
                request.UserAgent = DefaultUserAgent;
            }

            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }

            //如果需要POST数据

            #region post parameter  类似querystring格式

            if (parameters != null)
            {
                byte[] data = requestEncoding.GetBytes(parameters);
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
            }

            #endregion post parameter  类似querystring格式

            #region post result

            if (!string.IsNullOrEmpty(postJson))
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    //string result = "{\"user\":\"test\"," +
                    //              "\"password\":\"bla\"}";

                    streamWriter.Write(postJson);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            #endregion post result

            if (!string.IsNullOrEmpty(referer))
            {
                request.Referer = referer;
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            if (request.CookieContainer != null)
            {
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
            }

            return response;
        }

        #endregion 废弃方法
    }

    #region GET/POST请求参数模型

    /// <summary>
    /// GET请求参数模型
    /// </summary>
    public class HttpGetParametersModel
    {
        /// <summary>
        /// 请求的URL(GET方式就附加参数)
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public int? Timeout { get; set; }

        /// <summary>
        ///浏览器代理类型
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Web请求代理
        /// </summary>
        public IWebProxy WebProxy { get; set; }

        /// <summary>
        /// Cookies列表
        /// </summary>
        public CookieCollection Cookies { get; set; }
    }

    /// <summary>
    /// POST请求参数模型
    /// </summary>
    public class HttpPostParametersModel : HttpGetParametersModel
    {
        /// <summary>
        /// POST参数字典
        /// </summary>
        public IDictionary<string, string> DictParameters { get; set; }

        /// <summary>
        /// 发送HTTP请求时所用的编码
        /// </summary>
        public Encoding RequestEncoding { get; set; }
    }

    #endregion GET/POST请求参数模型
}

