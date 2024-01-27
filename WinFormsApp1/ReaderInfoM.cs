using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{

    public partial class ReaderInfoM : Form
    {
        private string Mid;

        private string selectedUser;
        private string selectedUid;
        private string selectedRtype;
        private string selectedSex;
        private string selectedPassW;
        private string selectedContact;
        private string selectedDate_rigi;
        private string selectedDate_due;
        private string selectedDate_remark;
        private string selectedState;



        public ReaderInfoM()
        {
            InitializeComponent();
        }

        private void ReaderInfoM_Load(object sender, EventArgs e)
        {
            MyInit();
            FillTheList();
        }
        public void setInfo(string id)
        {
            Mid = id;
        }

        private void FillTheList()
        {
            try
            {
                Connection con = new Connection();
                con.Open();
                MySqlConnection conn = con.getCon();
                string query_readerInfo = "";
                //ReaderID       | RTypeID | Rname | sex  | regist_date | valid_to   | Contact    | hold_count | borrow_count |
                //break_time | state | Remark | password
                //RType | count_limit | day_limit
                query_readerInfo = "SELECT ReaderID  AS '读者编号', RType AS '读者类别',Rname AS '读者名称'," +
                                   " sex AS '性别', regist_date AS '注册日期', valid_to AS '到期日期', Contact AS '联系方式', hold_count AS '当前借书数量', borrow_count AS '历史借书数量'," +
                                   " break_time as '违规次数', state as '状态', remark as '备注', password as '密码'" +
                                   " FROM  reader_info, readerType " +
                                   " WHERE reader_info.RtypeID = readerType.RtypeID";

                using (MySqlCommand command = new MySqlCommand(query_readerInfo, conn))
                {
                    // 添加预编译参数
                    //command.Parameters.AddWithValue("@name", user_name);

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
                            //MessageBox.Show("abs");
                            //return dt;
                            //MessageBox.Show("wuhu!!!");
                            // 清空 ListView 控件

                            readerInfoListView.Items.Clear();
                            readerInfoListView.Columns.Clear();
                            readerInfoListView.View = View.Details;
                            //BookListView.Width = 1150;
                            readerInfoListView.Scrollable = true;


                            // 添加列标题
                            foreach (DataColumn column in dt.Columns)
                            {
                                readerInfoListView.Columns.Add(column.Caption);
                            }

                            // 添加行数据
                            foreach (DataRow row in dt.Rows)
                            {
                                //ListViewItem item = new ListViewItem(row.ItemArray.Select(x => x.ToString()).ToArray());
                                //readerInfoListView.Items.Add(item);
                                string gender = row["性别"].ToString() == "0" ? "男" : "女";
                                string[] rowData = row.ItemArray.Select(x => x.ToString()).ToArray();
                                rowData[3] = gender;

                                ListViewItem item = new ListViewItem(rowData);
                                readerInfoListView.Items.Add(item);
                            }
                            readerInfoListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                            // 遍历所有列并修改宽度
                            foreach (ColumnHeader column in readerInfoListView.Columns)
                            {
                                if (column.Width < 120)
                                    column.Width = 120;// 新的宽度值;
                            }

                        }
                    }

                }
                con.Close();
                //return new DataTable();
            }
            catch (Exception ex)
            {
                // 处理异常
                Console.WriteLine("查询时出现异常：" + ex.Message);
                //return new DataTable();
            }


        }

        private void ReaderInfoListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (editStateComboBox.SelectedItem.ToString() == "添加")
            {
                readerInfoListView.SelectedIndices.Clear();
                return;
            }
            if (e.IsSelected)
            {
                // A row has been selected
                // You can access the selected row's data using e.Item.SubItems[index].Text
                // Replace 'index' with the corresponding column index in your DataTable

                // Example:
                selectedUser = e.Item.SubItems[2].Text; // Assuming the book name is in the first column
                selectedUid = e.Item.SubItems[0].Text;
                selectedRtype = e.Item.SubItems[1].Text;
                selectedSex = e.Item.SubItems[3].Text;
                selectedPassW = e.Item.SubItems[12].Text;
                selectedContact = e.Item.SubItems[6].Text;
                selectedDate_rigi = e.Item.SubItems[4].Text;
                selectedDate_due = e.Item.SubItems[5].Text;
                selectedDate_remark = e.Item.SubItems[11].Text;
                selectedState = e.Item.SubItems[10].Text;

                FillText();
                /*  query_readerInfo = "SELECT ReaderID  AS '读者编号', RType AS '读者类别',Rname AS '读者名称'," +
                    " sex AS '性别', regist_date AS '注册日期', valid_to AS '到期日期', Contact AS '联系方式', hold_count AS '当前借书数量', borrow_count AS '历史借书数量'," +
                    " break_time as '违规次数', state as '状态', remark as '备注', password as '密码'" +
                    " FROM  reader_info, readerType " +
                    " WHERE reader_info.RtypeID = readerType.RtypeID";

                    private string selectedUser;
                    private string selectedUid;
                    private string selectedRtype;
                    private string selectedSex;
                    private string selectedPassW;
                    private string selectedContact;
                    private string selectedDate_rigi;
                    private string selectedDate_due;
                    private string selectedDate_remark;
                    private string selectedDate_state;
                */


            }
        }

        private void FillText()
        {
            if (selectedRtype == "学生")
            {
                rTypeComboBox.SelectedIndex = 0;
            }
            else
            {
                rTypeComboBox.SelectedIndex = 1;
            }

            if (selectedSex == "男")
            {
                sexComboBox.SelectedIndex = 0;
            }
            else
            {
                sexComboBox.SelectedIndex = 1;
            }

            if (selectedState == "0")
            {
                stateComboBox.SelectedIndex = 0;
            }
            else
            {
                stateComboBox.SelectedIndex = 1;
            }

            passWTextBox.Text = selectedPassW;
            nameTextBox.Text = selectedUser;
            idTextBox.Text = selectedUid;
            contactTextBox.Text = selectedContact;
            rigiDateTextBox.Text = selectedDate_rigi;
            ValidToTextBox.Text = selectedDate_due;
            remarkTextBox.Text = selectedDate_remark;

            /*
                            selectedUser = e.Item.SubItems[2].Text; // Assuming the book name is in the first column
                selectedUid = e.Item.SubItems[0].Text;
                selectedRtype = e.Item.SubItems[1].Text;
                selectedSex = e.Item.SubItems[3].Text;
                selectedPassW = e.Item.SubItems[12].Text;
                selectedContact = e.Item.SubItems[6].Text;
                selectedDate_rigi = e.Item.SubItems[4].Text;
                selectedDate_due = e.Item.SubItems[5].Text;
                selectedDate_remark = e.Item.SubItems[11].Text;
                selectedState = e.Item.SubItems[10].Text;
             */


        }

        private void MyInit()
        {
            rTypeComboBox.Items.Add("学生");
            rTypeComboBox.Items.Add("教职工");
            sexComboBox.Items.Add("男");
            sexComboBox.Items.Add("女");
            stateComboBox.Items.Add("正常");
            stateComboBox.Items.Add("失效");

            editStateComboBox.Items.Add("编辑");
            editStateComboBox.Items.Add("添加");
            editStateComboBox.SelectedIndex = 1;

            rigiDateTextBox.Enabled = false;
            idTextBox.Enabled = false;
        }

        private void EditStateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editStateComboBox.SelectedItem.ToString() == "添加")
            {
                readerInfoListView.SelectedIndices.Clear();
                passWTextBox.Text = "";
                nameTextBox.Text = "";
                idTextBox.Text = "";
                contactTextBox.Text = "";
                rigiDateTextBox.Text = "";
                ValidToTextBox.Text = "";
                remarkTextBox.Text = "";

                selectedUser = ""; // Assuming the book name is in the first column
                selectedUid = "";
                selectedRtype = "";
                selectedSex = "";
                selectedPassW = "";
                selectedContact = "";
                selectedDate_rigi = "";
                selectedDate_due = "";
                selectedDate_remark = "";
                selectedState = "";
            }
            else if (editStateComboBox.SelectedItem.ToString() == "编辑" && readerInfoListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("已进入编辑模式\n自动选择第一个读者\n点击上方表格更改编辑对象");
                readerInfoListView.SelectedIndices.Add(0);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            FillText();

        }

        private void assureButton_Click(object sender, EventArgs e)
        {

            string messageString = "确定" + editStateComboBox.SelectedItem.ToString() + "该读者吗？";
            string titleString = "请确认：";
            DialogResult result = MessageBox.Show(messageString, titleString, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }



            string rtype = rTypeComboBox.SelectedItem.ToString();
            string rname = nameTextBox.Text;
            string sex = sexComboBox.SelectedItem.ToString();
            string passw = passWTextBox.Text;
            string contact = contactTextBox.Text;
            string due_date = ValidToTextBox.Text;
            string remark = remarkTextBox.Text;
            string state = stateComboBox.Text;

            string uid = idTextBox.Text;
            //DateTime rigi_date = rigiDateTextBox.Text;

            if (sex == "男")
            {
                sex = "0";
            }
            else if (sex == "女")
            {
                sex = "1";
            }

            if (state == "正常")
            {
                state = "0";
            }
            else if (state == "失效")
            {
                state = "1";
            }

            if (rtype == "学生")
            {
                rtype = "1";
            }
            else if (rtype == "教职工")
            {
                rtype = "2";
            }

            if (editStateComboBox.SelectedItem.ToString() == "添加")
            {
                try
                {
                    Connection con = new Connection();
                    con.Open();
                    MySqlConnection conn = con.getCon();

                    string query_insert = "INSERT INTO reader_info VALUES( @rid, @tid, @name, @sex, @rigi_date, @validTo, @contact, @hold_count, " +
                        "@borrow_count, @break_time, @state, @remark, @passw)";
                    //| ReaderID  | RTypeID | Rname | sex  | regist_date | valid_to   | Contact    | hold_count | borrow_count | break_time | state | Remark | password |

                    using (MySqlCommand command = new MySqlCommand(query_insert, conn))
                    {
                        // 添加预编译参数
                        command.Parameters.AddWithValue("@rid", Tools.GenID());
                        command.Parameters.AddWithValue("@tid", rtype);
                        command.Parameters.AddWithValue("@name", rname);
                        command.Parameters.AddWithValue("@sex", sex);
                        command.Parameters.AddWithValue("@rigi_date", DateTime.Now);
                        command.Parameters.AddWithValue("@validTo", due_date);
                        command.Parameters.AddWithValue("@contact", contact);
                        command.Parameters.AddWithValue("@hold_count", 0);
                        command.Parameters.AddWithValue("@borrow_count", 0);
                        command.Parameters.AddWithValue("@break_time", 0);
                        command.Parameters.AddWithValue("@state", 0);
                        command.Parameters.AddWithValue("@remark", remark);
                        command.Parameters.AddWithValue("@passw", passw);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // 更新成功
                            MessageBox.Show("success!!");
                            FillTheList();

                        }
                        else
                        {
                            // 更新失败
                            MessageBox.Show("failed..");
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
            else if (editStateComboBox.SelectedItem.ToString() == "编辑")
            {
                try
                {
                    Connection con = new Connection();
                    con.Open();
                    MySqlConnection conn = con.getCon();

                    string query_userInfo = "UPDATE reader_info SET RTypeID = @tid, Rname = @name, sex = @sex, valid_to = @validTo, Contact = @contact," +
                        " state = @state, Remark = @remark, password = @passw WHERE ReaderID = @rid";

                    using (MySqlCommand command = new MySqlCommand(query_userInfo, conn))
                    {
                        // 添加预编译参数
                        command.Parameters.AddWithValue("@tid", rtype);
                        command.Parameters.AddWithValue("@name", rname);
                        command.Parameters.AddWithValue("@sex", sex);
                        command.Parameters.AddWithValue("@validTo", due_date);
                        command.Parameters.AddWithValue("@contact", contact);
                        command.Parameters.AddWithValue("@state", state);
                        command.Parameters.AddWithValue("@remark", remark);
                        command.Parameters.AddWithValue("@passw", passw);
                        command.Parameters.AddWithValue("@rid", uid);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // 更新成功
                            MessageBox.Show("success!!");
                            FillTheList();

                        }
                        else
                        {
                            // 更新失败
                            MessageBox.Show("failed..");
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

        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            if(editStateComboBox.SelectedItem.ToString() == "编辑")
            {

                string messageString = "确定要删除该读者吗？";
                string titleString = "请确认：";
                DialogResult result = MessageBox.Show(messageString, titleString, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }

                try
                {
                    Connection con = new Connection();
                    con.Open();
                    MySqlConnection conn = con.getCon();

                    string query_delUser = "DELETE from reader_info where ReaderID = @rid";

                    string uid = idTextBox.Text;

                    using (MySqlCommand command = new MySqlCommand(query_delUser, conn))
                    {

                        command.Parameters.AddWithValue("@rid", uid);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // 更新成功
                            MessageBox.Show("success!!");
                            FillTheList();

                        }
                        else
                        {
                            // 更新失败
                            MessageBox.Show("failed..");
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
        }
    }
}
