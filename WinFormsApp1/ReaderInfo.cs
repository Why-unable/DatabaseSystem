using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp1
{
    public partial class ReaderInfo : Form
    {
        private string user_name;
        private DataTable userInfoDT;

        private string newPassword;
        private string newContact;
        private string oldPassword;
        private string oldContact;

        public ReaderInfo()
        {
            InitializeComponent();
        }

        private void ReaderInfo_Load(object sender, EventArgs e)
        {
            //dt = GetInfo();
            string[] title = { "编号", "读者类型", "姓名", "性别", "注册日期", "过期日期", "联系电话", "在借书籍数", "历史借书数", "违约次数", "状态", "备注", "密码" };
            int i = 0;
            foreach (DataColumn col in userInfoDT.Columns)
            {
                // 访问具体的单元格值
                Console.WriteLine(userInfoDT.Rows[0][col]);
                Label titleLabel = new Label();
                titleLabel.Height = 40;
                titleLabel.Width = 150;
                titleLabel.Text = title[i++];
                titleLabel.Location = new Point(2, i * (titleLabel.Height + 1));
                RInfoTitlePanel.Controls.Add(titleLabel);

                System.Windows.Forms.TextBox detailTextBox = new System.Windows.Forms.TextBox();
                detailTextBox.Height = 40;
                detailTextBox.Width = 300;
                detailTextBox.ReadOnly = true; // 设置文本框为只读模式
                if (col.ColumnName == "Contact" || col.ColumnName == "password")
                {
                    if (col.ColumnName == "Contact")
                    {
                        newContact = userInfoDT.Rows[0][col].ToString();
                        oldContact = userInfoDT.Rows[0][col].ToString();
                    }
                    else
                    {
                        newPassword = userInfoDT.Rows[0][col].ToString();
                        oldPassword = userInfoDT.Rows[0][col].ToString();
                    }
                    detailTextBox.ReadOnly = false;
                    detailTextBox.Tag = col.ColumnName;
                    detailTextBox.TextChanged += DetailTextBox_TextChanged;

                }
                if (col.ColumnName == "RTypeID" || col.ColumnName == "sex" || col.ColumnName == "state")
                {
                    if (col.ColumnName == "RTypeID")
                    {
                        Dictionary<string, string> rtype = new Dictionary<string, string>()
                {
                    {"1","学生" },
                    {"2","教师" }
                };
                        detailTextBox.Text = rtype[userInfoDT.Rows[0][col].ToString()];

                    }
                    else if (col.ColumnName == "sex")
                    {
                        Dictionary<string, string> stype = new Dictionary<string, string>()
                {
                    {"0","男" },
                    {"1","女" }
                };
                        detailTextBox.Text = stype[userInfoDT.Rows[0][col].ToString()];
                    }
                    else
                    {
                        detailTextBox.Text = userInfoDT.Rows[0][col].ToString();
                    }
                }
                else
                {
                    detailTextBox.Text = userInfoDT.Rows[0][col].ToString();
                }
                detailTextBox.Location = new Point(2, i * (detailTextBox.Height + 3));
                RInfoDetailPanel.Controls.Add(detailTextBox);

                //detailTextBox.Click += DetailTextBox_Click; // 添加点击事件处理程序
            }
        }
        private void DetailTextBox_TextChanged(object sender, EventArgs e)
        {

            System.Windows.Forms.TextBox changedTextBox = (System.Windows.Forms.TextBox)sender; // 获取触发事件的文本框
            string newContent = changedTextBox.Text; // 获取文本框的新内容
            if (changedTextBox.Tag.ToString() == "Contact")
            {
                newContact = newContent;
            }
            else if (changedTextBox.Tag.ToString() == "password")
            {
                newPassword = newContent;
            }

            // 在这里可以根据需要处理新内容的逻辑
        }

        public void SetUName(string uName)
        {
            user_name = uName;
            userInfoDT = GetInfo();
        }

        public DataTable GetInfo()
        {
            try
            {
                Connection con = new Connection();
                con.Open();
                MySqlConnection conn = con.getCon();

                string query_userInfo = "SELECT * FROM reader_info WHERE Rname = @name";

                using (MySqlCommand command = new MySqlCommand(query_userInfo, conn))
                {
                    // 添加预编译参数
                    command.Parameters.AddWithValue("@name", user_name);

                    // 创建数据适配器
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                    {
                        adapter.SelectCommand = command;

                        // 创建数据集
                        DataTable dt = new DataTable();

                        // 填充数据集
                        adapter.Fill(dt);

                        // 处理查询结果
                        if (dt.Rows.Count > 0)
                        {
                            return dt;
                        }
                    }

                }
                con.Close();
                return new DataTable();
            }
            catch (Exception ex)
            {
                // 处理异常
                Console.WriteLine("查询时出现异常：" + ex.Message);
                return new DataTable();
            }
        }

        private void AssureButton_Click(object sender, EventArgs e)
        {
            try
            {

                Connection con = new();
                bool flag = con.Open();
                MySqlConnection conn = con.getCon();
                string tableName = "Reader_Info";
                string columnName1 = "Contact";
                string columnName2 = "password";
                string Query = $"UPDATE {tableName} SET {columnName1} = @NewContact , {columnName2} = @NewPassword WHERE Rname = @user_name";

                using (MySqlCommand command = new MySqlCommand(Query, conn))
                {
                    // 添加预编译参数
                    command.Parameters.AddWithValue("@NewContact", newContact);
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@user_name", user_name);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // 更新成功
                        MessageBox.Show("yes");
                        oldContact = newContact;
                        oldPassword = newPassword;
                    }
                    else
                    {
                        // 更新失败
                    }

                }
                con.Close();
            }
            catch (Exception ex)
            {
                // 处理异常
                Console.WriteLine("查询时出现异常：" + ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {


        }
    }
}
