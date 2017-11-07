using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCloud_Client_v3
{
    public sealed class UserInstance
    {
        private static volatile UserInstance instance;
        private static readonly object obj = new object();
        private UserInstance() { }
        public static UserInstance Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new UserInstance();
                        }
                    }

                }
                return instance;
            }
        }

        public string Token { get; set; }
        public int RootFolderID { get; set; }

        public const string CONFIG_FILE_PATH = @".\config.json";

        public Dictionary<string, string> Configuration { set; get; }

        public void UpdateConfigData(SettingItem[] arrItems)
        {
            if (Configuration == null) 
                Configuration = new Dictionary<string, string>();

            foreach(SettingItem si in arrItems){
                if (Configuration.ContainsKey(si.key))
                {
                    Configuration[si.key] = si.value;
                }
                else
                {
                    Configuration.Add(si.key,si.value);
                }
            }
        }

        public void UpdateConfigFile()
        {
            //读取配置项
            SettingItem[] arrItems = ConfigurationUtils.readFile(CONFIG_FILE_PATH);
            //修改数据
            foreach (SettingItem si in arrItems)
            {
                if (Configuration.ContainsKey(si.key))
                {
                    si.value = Configuration[si.key];
                }
            }
            //保存配置项
            ConfigurationUtils.saveFile(CONFIG_FILE_PATH,arrItems);
        }
    }
}
