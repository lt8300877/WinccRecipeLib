using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCHMIRUNTIME;
namespace WinccRecipeSqlFind
{
    public partial class Start : Form
    {

        HMIRuntime hMI = new HMIRuntime();
        public Start()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 查找SQL服务器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findBtn_Click(object sender, EventArgs e)
        {
            try
            {
                serverNameCbx.Items.Clear();//清除当前内容
                //历遍服务器列表，显示在comboBox控件上
                foreach (var servername in GetSqlServerName())
                {
                    serverNameCbx.Items.Add(servername.ToString());
                }
                //显示第一个索引内容
                serverNameCbx.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("错误！", "提示");
            }
            MessageBox.Show("查找完成！", "提示");
        }

        /// <summary>
        /// SQL服务器列表改变后更新数据库列表内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serverNameCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlDataCbx.Items.Clear();
            foreach (var dataname in GetAllDataBase(serverNameCbx.SelectedItem.ToString()))
            {
                sqlDataCbx.Items.Add(dataname.ToString());
            }
            sqlDataCbx.SelectedIndex = 0;
        }


        /// <summary>
        /// 获取本地计算机SQL服务器列表
        /// <paramref name="findName"> 服务器检索字符 </param>
        /// <returns>返回所需要的服务器名称</returns>
        private ArrayList GetSqlServerName()
        {
            ArrayList ServerNameList = new ArrayList();
            //枚举本地计算机SQL服务器列表
            SqlDataSourceEnumerator sqlServer = SqlDataSourceEnumerator.Instance;
            DataTable db = sqlServer.GetDataSources();
            foreach (DataRow row in db.Rows)
            {
                ServerNameList.Add(row[0].ToString().Trim() + @"\" + row[1].ToString().Trim());
            }
            return ServerNameList;
        }

        private void 配方操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            RecipeSet recipeSet = new RecipeSet();
            recipeSet.Show();
        }

        /// <summary>
        /// 获取指定服务器的数据库所有数据库实例名。
        /// </summary>
        /// <param name="servername">指定的服务器名称。</param>
        /// <returns>返回包含数据实例名的列表。</returns>
        private ArrayList GetAllDataBase(string servername)
        {
            ArrayList DBNameList = new ArrayList();
            SqlConnection Connection = new SqlConnection(String.Format("Server=SQLNCLI11;Data Source={0};Integrated Security=SSPI", servername));
            DataTable DBNameTable = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("select name from master..sysdatabases", Connection);

            lock (Adapter)
            {
                Adapter.Fill(DBNameTable);
            }
            foreach (DataRow row in DBNameTable.Rows)
            {
                DBNameList.Add(row["name"]);
            }
            return DBNameList;
        }
        /// <summary>
        /// 设置按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (serverNameCbx.SelectedItem.ToString() != "" && sqlDataCbx.SelectedItem.ToString() != "")
                {
                    INI_FILE_RD.InifileWriteValue("配置", "服务器名称", serverNameCbx.SelectedItem.ToString(), INI_FILE_RD.iniPath);
                    INI_FILE_RD.InifileWriteValue("配置", "数据库名称", sqlDataCbx.SelectedItem.ToString(), INI_FILE_RD.iniPath);
                    INI_FILE_RD.InifileWriteValue("配置", "列表索引", "0", INI_FILE_RD.iniPath);
                    System.Threading.Thread.Sleep(500);//
                    if (INI_FILE_RD.InifileReadValue("配置", "服务器名称", INI_FILE_RD.iniPath) == serverNameCbx.SelectedItem.ToString() && 
                        INI_FILE_RD.InifileReadValue("配置", "数据库名称", INI_FILE_RD.iniPath) == sqlDataCbx.SelectedItem.ToString())
                    MessageBox.Show("设置完成！", "提示");
                }
            }
            catch
            {
                MessageBox.Show("没有可用数据库！", "提示");
            }
        }
    }





    public static class INI_FILE_RD  //配置INI文件读写API
    {
        public static string iniPath = @"C:\Recipe\RunTimeCFG.ini";//ini配置文件路径
        [DllImport("kernel32", CharSet = CharSet.Unicode)] // 写入配置文件的接口
        private static extern long WritePrivateProfileString(
        string section, string key, string val, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)] // 读取配置文件的接口
        private static extern int GetPrivateProfileString(
        string section, string key, string def,
        StringBuilder retVal, int size, string filePath);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键值</param>
        /// <param name="value">写入数据</param>
        /// <param name="path">INI文件路径</param>
        public static void InifileWriteValue(
        string section, string key, string value, string path)
        {
            //创建INI文件
            if (!Directory.Exists(Path.GetDirectoryName(iniPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(iniPath));
                if (!File.Exists(iniPath))
                {
                    File.Create(iniPath);
                }
            }
            WritePrivateProfileString(section, key, value, path);
        }
        /// <summary>
        /// 读取INI配置文件内容
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键值</param>
        /// <param name="path">INI文件路径</param>
        /// <returns></returns>
        public static string InifileReadValue(
        string section, string key, string path)
        {
            StringBuilder sb = new StringBuilder(255);
            //创建INI文件
            if (!Directory.Exists(Path.GetDirectoryName(iniPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(iniPath));
                if (!File.Exists(iniPath))
                {
                    File.Create(iniPath);
                }
            }
            GetPrivateProfileString(section, key, "", sb, 255, path);
            return sb.ToString().Trim();
        }
    }
}
