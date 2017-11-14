using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCloud_Client_v3
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUser.Text = UserInstance.Instance.Configuration["Username"];
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RegisterForm().ShowDialog();
            this.Show();
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPsw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                login();
            }
        }

        private void login()
        {
            string username = txtUser.Text;
            string password = txtPsw.Text;

            //拼接url
            string strURL = URL.GetUrl_UserLogin(username, password);

            //异步HTTP请求
            AsyncHttpRequester ahr = new AsyncHttpRequester();
            ahr.PostExecute += (result) =>
            {
                //获取Json数据
                ActionJson ajson = new ActionJson(result);

                //登陆成功
                if (ajson.flag)
                {
                    //content中包含用户token和根目录id
                    JObject json = JObject.Parse(ajson.content);

                    //将用户的数据保存
                    UserInstance.Instance.Token = json["token"].ToString();
                    UserInstance.Instance.RootFolderID = (int)json["rootfolder"];

                    //保存用户名到配置文件中
                    UserInstance.Instance.Configuration["Username"] = txtUser.Text;

                    //跨线程修改UI
                    MethodInvoker mi = new MethodInvoker(() =>
                    {
                        //打开主界面
                        this.Hide();
                        MainForm form = new MainForm();
                        form.Show();
                    });
                    this.BeginInvoke(mi);
                }
                //登录失败
                else
                {
                    //提示登陆错误
                    MessageBox.Show(ajson.message);
                    //跨线程修改UI
                    MethodInvoker mi = new MethodInvoker(() =>
                    {
                        btnLogin.Enabled = true;
                    });
                    this.BeginInvoke(mi);
                }
            };
            btnLogin.Enabled = false;
            ahr.PostHttpResponse(strURL, null);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            new SettingForm().ShowDialog();
        }
    }
}
