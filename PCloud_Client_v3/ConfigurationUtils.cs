using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCloud_Client_v3
{
    public class ConfigurationUtils
    {
        /// <summary>
        /// 读取配置数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static SettingItem[] readFile(string filepath)
        {
            SettingItem[] arrItems;

            //如果配置文件不存在
            if (!new FileInfo(UserInstance.CONFIG_FILE_PATH).Exists)
            {
                arrItems = initData();
                saveFile(filepath, arrItems);
                return arrItems;
            }

            JArray jsonArray = JArray.Parse(File.ReadAllText(filepath));

            arrItems = new SettingItem[jsonArray.Count];
            int index = 0;
            foreach (var j in jsonArray)
            {
                arrItems[index] = new SettingItem((JObject)j);
                index++;
            }
            return arrItems;
        }

        /// <summary>
        /// 保存配置数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="arrItems"></param>
        public static void saveFile(string filepath, SettingItem[] arrItems)
        {
            JArray jsonArray = new JArray();

            foreach (SettingItem si in arrItems)
            {
                jsonArray.Add(si.ToJsonObject());
            }

            //保存配置文件
            string str = jsonArray.ToString();
            File.WriteAllText(UserInstance.CONFIG_FILE_PATH, str, Encoding.UTF8);
        }

        /// <summary>
        /// 默认配置
        /// </summary>
        /// <returns></returns>
        public static SettingItem[] initData()
        {
            //默认配置
            SettingItem[] arrItems = new SettingItem[]{
                new SettingItem("Host","120.25.222.235:8080","服务器地址","Basic"),
                new SettingItem("DownloadFolder",@".\PCloud_Download\","下载文件保存目录","Basic"),
                new SettingItem("Username","","用户名","User")
            };

            return arrItems;
        }
    }

    public class SettingItem
    {
        public string key { set; get; }
        public string value { set; get; }
        public string note { set; get; }
        public string group { set; get; }

        public SettingItem() { }


        public SettingItem(JObject json)
        {
            this.key = json.GetValue("key").ToString();
            this.value = json.GetValue("value").ToString();
            this.note = json.GetValue("note").ToString();
            this.group = json.GetValue("group").ToString();
        }

        public SettingItem(string key, string value, string note, string group)
        {
            this.key = key;
            this.value = value;
            this.note = note;
            this.group = group;
        }

        public JObject ToJsonObject()
        {
            JObject json = new JObject();
            json.Add("key", key);
            json.Add("value", value);
            json.Add("note", note);
            json.Add("group", group);
            return json;
        }

    }
}
