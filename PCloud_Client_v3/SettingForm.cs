using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCloud_Client_v3
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void showData(SettingItem[] arrItems)
        {
            //清空列表内信息
            lvSettingItem.Items.Clear();

            //用于保存元素组对象的字典
            Dictionary<string, ListViewGroup> dictListViewGroups = new Dictionary<string, ListViewGroup>();

            foreach (SettingItem si in arrItems)
            {
                //如果“组”字典中不存在记录
                if (!dictListViewGroups.ContainsKey(si.group))
                {
                    //实例化元素组对象
                    ListViewGroup lvg = new ListViewGroup(si.group);
                    //加入字典
                    dictListViewGroups.Add(si.group, lvg);
                    //将元素组添加至列表
                    lvSettingItem.Groups.Add(lvg);
                }
                //实例化列表元素
                ListViewItem item = new ListViewItem(new string[] { si.key, si.value, si.note }, -1);
                //为列表元素指定所在的组
                item.Group = dictListViewGroups[si.group];
                //将列表元素加入列表
                lvSettingItem.Items.Add(item);
            }
        }



        private void lvSettingItem_DoubleClick(object sender, EventArgs e)
        {
            string key = lvSettingItem.SelectedItems[0].SubItems[0].Text;
            string value = Microsoft.VisualBasic.Interaction.InputBox(string.Format("请输入 [{0}] 的新值：",key), "修改配置", lvSettingItem.SelectedItems[0].SubItems[1].Text);
            if (value == null || value == "") return;
            lvSettingItem.SelectedItems[0].SubItems[1].Text = value;
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveFile()
        {
            SettingItem[] arrItems = new SettingItem[lvSettingItem.Items.Count];
            JArray jsonArray = new JArray();

            int index = 0;
            foreach (ListViewItem lvi in lvSettingItem.Items)
            {
                arrItems[index].key = lvi.SubItems[0].Text;
                arrItems[index].value = lvi.SubItems[1].Text;
                arrItems[index].note = lvi.SubItems[2].Text;
                arrItems[index].group = lvi.Group.Header;
                index++;
            }

            //保存配置文件
            ConfigurationUtils.saveFile(UserInstance.CONFIG_FILE_PATH,arrItems);
        }

        

        private void tsmiRead_Click(object sender, EventArgs e)
        {
            //显示配置文件数据
            showData(ConfigurationUtils.readFile(UserInstance.CONFIG_FILE_PATH));
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //显示配置文件数据
            showData(ConfigurationUtils.readFile(UserInstance.CONFIG_FILE_PATH));
        }
    }
}
