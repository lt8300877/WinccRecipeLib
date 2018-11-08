using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Sql;
using CCHMIRUNTIME;
using System.Runtime.InteropServices;
using System.IO;

namespace WinccRecipeLib
{
    public partial class WinccRecipe: UserControl
    {
        //实例化对象
        HMIRuntime hMI = new HMIRuntime();
        List<MyRecipeStruct> recipeData = new List<MyRecipeStruct>(); //读取数据暂存

        string sqlServerName; //SQL服务器名称
        string sqlDataName;//SQL数据库名称
        string recipeName = "Data_Name"; //工件配方名称Data_Name
        //WINCC变量名
        string recipeControlID = "Recipe_ID";
        string recipeControlJOB = "Recipe_JOB";
        //WINCC进程运行状态
        bool winccProcessState = false;
        public WinccRecipe()
        {
            InitializeComponent();
            try
            {
                recipeNameCbx.SelectedIndex = 0;
                winccProcessState = GetRunProcess();
                if (!winccProcessState) return;
                string[] name = new string[2];
                name = GetSqlAllName();
                sqlServerName = name[0];
                sqlDataName = name[1];
                //sqlServerName = INI_FILE_RD.InifileReadValue("配置", "服务器名称", INI_FILE_RD.iniPath);
                //sqlDataName =  INI_FILE_RD.InifileReadValue("配置", "数据库名称", INI_FILE_RD.iniPath);
                GetRecipeData(); //获取一次数据
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        /// <summary>
        /// 获取服务器名称和数据库名称
        /// </summary>
        /// <returns></returns>
        private string[] GetSqlAllName()
        {
            string[] names = new string[2];
            try
            {
                names[0] = GetMachineName() + @"\WINCC";
                foreach (string p in GetAllDataBase(names[0]))
                {
                    if (p.Trim().Substring(p.Length - 1) == "R" && p.Trim().Substring(0, 3) == "CC_")
                    {
                        names[1] = p.Trim().ToString();
                    }
                }
                return names;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return names;
            }
            
        }


        /// <summary>
        /// 获取配方数据
        /// </summary>
        private void GetRecipeData()
        {
            try
            {
                recipeData = FindData();
                recipeNameCbx.Items.Clear();
                foreach (var name in recipeData)
                {
                    recipeNameCbx.Items.Add(name.name.ToString());
                }
                if(int.Parse(INI_FILE_RD.InifileReadValue("配置", "列表索引", INI_FILE_RD.iniPath)) < recipeNameCbx.Items.Count)
                    recipeNameCbx.SelectedIndex = int.Parse(INI_FILE_RD.InifileReadValue("配置", "列表索引", INI_FILE_RD.iniPath));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 单击列表组件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recipeNameCbx_Click(object sender, EventArgs e)
        {
            if (!winccProcessState) return;
            GetRecipeData();
        }

        //列表选择改变时更新ID显示并修改WINCC变量ID,使之保持一致
        private void recipeNameCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!winccProcessState) return;
            try
            {
                foreach (var name in recipeData)
                {
                    if (name.name == recipeNameCbx.SelectedItem.ToString())
                    {
                        recipeidTbx.Text = name.id.ToString();
                        hMI.Tags[recipeControlID].Write(name.id);
                    }
                }
                //列表索引写入INI文件
                INI_FILE_RD.InifileWriteValue("配置", "列表索引", recipeNameCbx.SelectedIndex.ToString(), INI_FILE_RD.iniPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //查找SQL数据库中的ID和工件名称
        private List<MyRecipeStruct> FindData()
        {
            //连接数据库字符串
            string strconn = String.Format("Server=SQLNCLI11;Data Source={0};Integrated Security=SSPI;Initial Catalog={1}", sqlServerName, sqlDataName);
            //查表
            string sql = "select * from [UA#Recipe_1]";
            List<MyRecipeStruct> data = new List<MyRecipeStruct>();
            //2.投递数据库查询 strconn 为数据库连接字符串
            SqlConnection Connection = new SqlConnection(strconn);
            SqlCommand command = new SqlCommand(sql, Connection);
            //3.执行数据库查询获取返回值
            using (Connection)
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //创建结构体实例
                    MyRecipeStruct myrecipe = new MyRecipeStruct();
                    //获取ID信息
                    myrecipe.id = reader.GetInt32(reader.GetOrdinal("ID"));
                    //获取配方内名称信息
                    myrecipe.name = reader.GetString(reader.GetOrdinal(recipeName));
                    //添加到表格
                    data.Add(myrecipe);
                }
            }
            return data;
        }
        //WINCC数据库ID和工件名称结构体
        public struct MyRecipeStruct
        {
            public int id;//配方ID
            public string name;//工件名称
        }

        //CCUCSurrogate.exe
        /// <summary>
        /// 检测进程是否运行
        /// </summary>
        /// <returns></returns>
        private bool GetRunProcess()
        {
            System.Diagnostics.Process[] findprocess1 = System.Diagnostics.Process.GetProcessesByName("CCUsrAcv"); //CCUsrAcv
            System.Diagnostics.Process[] findprocess2 = System.Diagnostics.Process.GetProcessesByName("CCUAImport"); //CCUAImport

            if (findprocess1.Length > 0 && findprocess2.Length > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取计算机名
        /// </summary>
        /// <returns></returns>
        private string GetMachineName()
        {
            try
            {
                return System.Environment.MachineName;
            }
            catch (Exception ex)
            {
                return "";
            }
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
        /// 新建按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtn_Click(object sender, EventArgs e)
        {
            if (!winccProcessState) return;
            if (MessageBox.Show("确定要新建一个程序吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string dt = hMI.Tags[recipeName].Read(HMIReadType.hmiReadCache);
                for (int i = 0; i < recipeNameCbx.Items.Count; i++)
                {
                    if(dt.Trim() == recipeNameCbx.Items[i].ToString())
                    {
                        MessageBox.Show("程序名称不能有相同！", "提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                }
                hMI.Tags[recipeControlID].Write(-1);
                hMI.Tags[recipeControlJOB].Write(6);
                System.Threading.Thread.Sleep(500);//给WINCC响应时间，防止在数据库改变之前已经读取
                GetRecipeData(); //读取数据
                if (recipeNameCbx.Items.Count > 0)
                    recipeNameCbx.SelectedIndex = recipeNameCbx.Items.Count - 1;
            } 
        }
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delBtn_Click(object sender, EventArgs e)
        {
            if (!winccProcessState) return;
            if (MessageBox.Show("确定要删除此程序吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                hMI.Tags[recipeControlJOB].Write(8);
                System.Threading.Thread.Sleep(500);//
                GetRecipeData();
                if (recipeNameCbx.Items.Count > 0)
                    recipeNameCbx.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!winccProcessState) return;
            hMI.Tags[recipeControlJOB].Write(6);
            System.Threading.Thread.Sleep(500);//
            GetRecipeData();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// 下载按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downBtn_Click(object sender, EventArgs e)
        {
            if (!winccProcessState) return;
            hMI.Tags[recipeControlJOB].Write(7);
            MessageBox.Show("下载成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
