using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCloud_Client_v3
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (init() < 0) return;
            Application.Run(new LoginForm());
        }

        static int init()
        {
            //读取配置文件
            UserInstance.Instance.UpdateConfigData(ConfigurationUtils.readFile(UserInstance.CONFIG_FILE_PATH));

            if (!Directory.Exists("./icon"))//如果不存在就创建file文件夹
            {
                MessageBox.Show("找不到图标图库：./icon");
                return -2;
            }

            if (!Directory.Exists("./Downloads"))//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory("./Downloads");
            }
            return 0;
        }
    }
}
