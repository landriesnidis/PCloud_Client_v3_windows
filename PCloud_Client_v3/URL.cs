using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCloud_Client_v3
{
    class URL
    {

        //服务端地址
        public static string server_address = UserInstance.Instance.Configuration["Host"];

        //用户登录      
        public static string strUrl_UserLogin = "http://{0}/PCloud_Server/Function?Action=UserLogin&username={1}&password={2}";
        //用户登出      
        public static string strUrl_UserLogout = "http://{0}/PCloud_Server/Function?Action=UserLogout&token={1}";
        //用户注册      
        public static string strUrl_UserRegister = "http://{0}/PCloud_Server/Function?Action=UserRegister&username={1}&password={2}";
        //删除文件      
        public static string strUrl_DeleteFile = "http://{0}/PCloud_Server/Function?Action=DeleteFile&token={1}&folderid={2}&fileid={3}";
        //文件重命名    
        public static string strUrl_RenameFile = "http://{0}/PCloud_Server/Function?Action=RenameFile&token={1}&folderid={2}&fileid={3}&newfilename={4}";
        //文件移动      
        public static string strUrl_MoveFile = "http://{0}/PCloud_Server/Function?Action=MoveFile&token={1}&folder1id={2}&folder2id={3}&fileid={4}";
        //新建文件夹    
        public static string strUrl_CreateFolder = "http://{0}/PCloud_Server/Function?Action=CreateFolder&token={1}&folderid={2}&newfoldername={3}";
        //获取文件目录  
        public static string strUrl_FolderMenu = "http://{0}/PCloud_Server/Function?Action=FolderMenu&token={1}&folderid={2}";
        //文件拷贝      
        public static string strUrl_CopyFile = "http://{0}/PCloud_Server/Function?Action=CopyFile&token={1}&folderid1={2}&folderid2={3}&fileid={4}";
        //文件下载      
        public static string strUrl_Download = "http://{0}/PCloud_Server/Function?Action=Download&token={1}&filename={2}&fileid={3}";
        //文件上传   
        public static string strUrl_Upload = "http://{0}/PCloud_Server/Function?Action=Upload&token={1}&filename={2}&filemd5={3}&folderid={4}";


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetUrl_UserLogin(string username, string password)
        {
            return string.Format(strUrl_UserLogin, server_address, username, password);
        }

        /// <summary>
        /// 用户登出
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetUrl_UserLogout()
        {
            return string.Format(strUrl_UserLogout, server_address, UserInstance.Instance.Token);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetUrl_UserRegister(string username, string password)
        {
            return string.Format(strUrl_UserRegister, server_address, username, password);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetUrl_DeleteFile(int folderid,int fileid)
        {
            return string.Format(strUrl_DeleteFile, server_address, UserInstance.Instance.Token, folderid, fileid);
        }

        /// <summary>
        /// 文件重命名
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetUrl_RenameFile(int folderid, int fileid, string newfilename)
        {
            return string.Format(strUrl_RenameFile, server_address, UserInstance.Instance.Token, folderid, fileid, newfilename);
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetUrl_MoveFile(int folder1id,int folder2id,int fileid)
        {
            return string.Format(strUrl_MoveFile, server_address, UserInstance.Instance.Token, folder1id, folder2id, fileid);
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetUrl_CreateFolder(int folderid,string newfoldername)
        {
            return string.Format(strUrl_CreateFolder, server_address, UserInstance.Instance.Token, folderid, newfoldername);
        }

        /// <summary>
        /// 获取文件夹目录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetUrl_FolderMenu(int folderid)
        {
            return string.Format(strUrl_FolderMenu, server_address, UserInstance.Instance.Token, folderid);
        }

        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetUrl_CopyFile(int folderid1,int folderid2,int fileid)
        {
            return string.Format(strUrl_CopyFile, server_address, UserInstance.Instance.Token, folderid1, folderid2, fileid);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetUrl_Download(string filename,int fileid)
        {
            return string.Format(strUrl_Download, server_address, UserInstance.Instance.Token,filename,fileid);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetUrl_Upload(string filename,string filemd5, int folderid)
        {
            return string.Format(strUrl_Upload, server_address, UserInstance.Instance.Token, filename, filemd5, folderid);
        }
    }
}
