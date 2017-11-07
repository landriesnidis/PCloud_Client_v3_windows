using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCloud_Client_v3
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPsw.Text;
            string repassword = txtRePsw.Text;

            if (password != repassword)
            {
                labInfo.Text = "两次密码输入不一致！";
                txtRePsw.Focus();
                return;
            }

            //拼接url
            string strURL = URL.GetUrl_UserRegister(username, password);

            //异步HTTP请求
            AsyncHttpRequester ahr = new AsyncHttpRequester();
            ahr.PostExecute += (result) =>
            {
                //获取Json数据
                ActionJson ajson = new ActionJson(result);

                //成功
                if (ajson.flag)
                {
                    //跨线程修改UI
                    MethodInvoker mi = new MethodInvoker(() =>
                    {
                        //显示信息
                        labInfo.ForeColor = Color.LimeGreen;
                        labInfo.Text = "新用户注册成功";
                        
                        Thread.Sleep(500);

                        //关闭界面
                        this.Hide();
                        this.Dispose();
                    });
                    this.BeginInvoke(mi);
                }
                //失败
                else
                {
                    //提示登陆错误
                    MessageBox.Show(ajson.message);

                    //跨线程修改UI
                    MethodInvoker mi = new MethodInvoker(() =>
                    {
                        btnReg.Enabled = true;
                    });
                    this.BeginInvoke(mi);
                }
            };
            btnReg.Enabled = false;
            ahr.PostHttpResponse(strURL, null);
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
