using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Content : Form
    {
        private string user_name;
        private string user_id;
        private int readerType;
        private string welcomeText = "欢迎回来，";
        private int searchType_all = 0;
        private int searchType_request = 1;
        private string selectedISBN = "";
        private string selectedBname = "";
        public Content()
        {
            InitializeComponent();
        }

        private void Content_Load(object sender, EventArgs e)
        {
            Welcome_Label.Text = welcomeText + user_name + "!";
            FillTheList(searchType_all);
        }
        private void FillTheList(int searchType, string request = "")
        {
            try
            {
                Connection con = new Connection();
                con.Open();
                MySqlConnection conn = con.getCon();
                string query_bookInfo = "";
                if (searchType == searchType_all)
                {
                    query_bookInfo = "SELECT ISBN_ID AS '图书编号', Book_type.BTName AS '图书类别',publish_house_info.PDName AS '出版社'," +
                    " BName AS '图书名称', author AS '作者', order_edition AS '版本', price AS '价格', total_count AS '总数量', left_count AS '剩余数量'" +
                    " FROM  Book_basic_info,Book_type,publish_house_info " +
                    "WHERE left_count > 0 and Book_type.BTID = Book_basic_info.BTID and publish_house_info.publish_HID = Book_basic_info.publish_HID";

                }
                else if (searchType == searchType_request && request != "")
                {
                    query_bookInfo = "SELECT ISBN_ID AS '图书编号', Book_type.BTName AS '图书类别',publish_house_info.PDName AS '出版社'," +
                    " BName AS '图书名称', author AS '作者', order_edition AS '版本', price AS '价格', total_count AS '总数量', left_count AS '剩余数量'" +
                    " FROM  Book_basic_info,Book_type,publish_house_info " +
                    "WHERE left_count > 0 and Book_type.BTID = Book_basic_info.BTID and publish_house_info.publish_HID = Book_basic_info.publish_HID " +
                    "and BName like CONCAT('%', @Bname, '%')";
                    //注意写法：BName like CONCAT('%', @Bname, '%')；  以及：字符串分行时，注意行末或行首要留有原本未分行前该位置需要有的空格
                }
                else
                {
                    return;
                }
                using (MySqlCommand command = new MySqlCommand(query_bookInfo, conn))
                {
                    // 添加预编译参数
                    //command.Parameters.AddWithValue("@name", user_name);
                    if (searchType == searchType_request)
                    {
                        command.Parameters.AddWithValue("@Bname", request);
                    }

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
                            BookListView.Items.Clear();
                            BookListView.Columns.Clear();
                            BookListView.View = View.Details;
                            //BookListView.Width = 1150;
                            BookListView.Scrollable = true;


                            // 添加列标题
                            foreach (DataColumn column in dt.Columns)
                            {
                                BookListView.Columns.Add(column.Caption);
                            }

                            // 添加行数据
                            foreach (DataRow row in dt.Rows)
                            {
                                ListViewItem item = new ListViewItem(row.ItemArray.Select(x => x.ToString()).ToArray());
                                BookListView.Items.Add(item);
                            }
                            BookListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                            // 遍历所有列并修改宽度
                            foreach (ColumnHeader column in BookListView.Columns)
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
        public void setUserName_ID(string userName, string user_id, int readerType)
        {
            this.user_name = userName;
            this.user_id = user_id;
            this.readerType = readerType;
        }

        private void ReaderInfoButton_Click(object sender, EventArgs e)
        {
            ReaderInfo readerInfo = new ReaderInfo();
            readerInfo.SetUName(user_name);
            readerInfo.Show();
        }

        private void BookListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                // A row has been selected
                // You can access the selected row's data using e.Item.SubItems[index].Text
                // Replace 'index' with the corresponding column index in your DataTable

                // Example:
                selectedBname = e.Item.SubItems[3].Text; // Assuming the book name is in the first column
                selectedISBN = e.Item.SubItems[0].Text;
                // Do something with the selected row's data
                //MessageBox.Show("Selected book: " + selectedBname);


            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            if (searchTextBox.Text.Trim() == "")
            {
                FillTheList(searchType_all);
            }
            else
            {
                string searchText = searchTextBox.Text.Trim();
                FillTheList(searchType_request, searchText);

            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (selectedISBN == "")
            {
                MessageBox.Show("请先选中一本书");

            }
            else
            {
                string messageString = "确定要借阅 " + selectedBname + " 吗？";
                string titleString = "ISBN：" + selectedISBN;
                DialogResult result = MessageBox.Show(messageString, titleString, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    // 用户点击了确定按钮
                    // 执行操作
                    if (BorrowBook(selectedISBN))
                    {
                        MessageBox.Show("成功！可前往书架查看");
                    }
                    else
                    {
                        MessageBox.Show("失败！");
                    }
                    FillTheList(searchType_all);

                }
                else if (result == DialogResult.Cancel)
                {
                    // 用户点击了取消按钮
                    // 取消操作
                }
            }
        }
        private bool BorrowBook(string ISBN)
        {
            //借书事务
            try
            {
                Connection con = new Connection();
                con.Open();
                MySqlConnection conn = con.getCon();

                MySqlTransaction transaction = conn.BeginTransaction();
                State.Text = "借阅事务已开始";

                try
                {
                    //首先判断用户借阅数目是否到达限制
                    string search_query = "select * from reader_info where ReaderID = @Rid and hold_count < 5";
                    if (readerType == 2)
                    {
                        search_query = "select * from reader_info where ReaderID = @Rid and hold_count < 10";
                    }
                    MySqlCommand searchCommand_count = new MySqlCommand(search_query, conn, transaction);
                    searchCommand_count.Parameters.AddWithValue("@Rid", user_id);
                    MySqlDataAdapter adapter_count = new MySqlDataAdapter();
                    adapter_count.SelectCommand = searchCommand_count;
                    // 创建数据集
                    DataTable dt_count = new DataTable();
                    // 填充数据集
                    adapter_count.Fill(dt_count);
                    if (dt_count.Rows.Count > 0)
                    {

                    }
                    else if (dt_count.Rows.Count == 0)
                    {
                        MessageBox.Show("你已经到达借阅数量限制");
                        State.Text = "到达数量限制，返回";
                        transaction.Rollback();
                        return false;
                    }


                    string bcid = "";
                    //搜索书目book_collect_info得到BCID
                    string searchQuery = "select BCID from book_collect_info where ISBN_ID = @ISBN_ID and Bstate = 0 LIMIT 1";
                    MySqlCommand searchCommand = new MySqlCommand(searchQuery, conn, transaction);
                    searchCommand.Parameters.AddWithValue("@ISBN_ID", selectedISBN);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = searchCommand;
                    // 创建数据集
                    DataTable dt = new DataTable();
                    // 填充数据集
                    adapter.Fill(dt);
                    // 处理查询结果
                    if (dt.Rows.Count > 0)
                    {
                        State.Text = "有可借书籍,开始生成借阅记录";
                        DataRow firstRow = dt.Rows[0];

                        // 获取第一条结果的 BCID 值
                        bcid = firstRow["BCID"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("这本书已经被借光了");
                        State.Text = "书籍无剩余";
                        transaction.Rollback();
                        return false;
                    }
                    if (bcid == "")
                    {
                        MessageBox.Show("馆藏编号怎么为空了？");
                        transaction.Rollback();
                        return false;
                    }


                    //补充日志
                    // 生成借阅记录的插入操作
                    string insertQuery = "INSERT INTO borrow_record VALUES (@borrow_ID, @ReaderID, @AID, @BCID, @Borrow_date, @Due_date, @renewal_count,0)";
                    MySqlCommand insertCommand = new MySqlCommand(insertQuery, conn, transaction);
                    insertCommand.Parameters.AddWithValue("@borrow_ID", Tools.GenID());
                    insertCommand.Parameters.AddWithValue("@ReaderID", user_id);
                    insertCommand.Parameters.AddWithValue("@AID", "12172231");
                    insertCommand.Parameters.AddWithValue("@BCID", bcid);
                    Dictionary<int, TimeSpan> readerType_due = new Dictionary<int, TimeSpan>
                    {
                        { 1, new TimeSpan(90, 0, 0, 0) },
                        { 2, new TimeSpan(150, 0, 0, 0) }
                    };

                    DateTime now = DateTime.Now;
                    DateTime dueDate = now + readerType_due[readerType];
                    insertCommand.Parameters.AddWithValue("@Borrow_date", now);
                    insertCommand.Parameters.AddWithValue("@Due_date", dueDate);
                    insertCommand.Parameters.AddWithValue("@renewal_count", 0);
                    int rows_affected = insertCommand.ExecuteNonQuery();
                    if (rows_affected == 0)
                    {
                        State.Text = "记录生成失败";
                        MessageBox.Show("生成借阅记录失败");
                        transaction.Rollback();
                        return false;
                    }

                    State.Text = "记录已生成，开始更新书本状态";
                    // 修改图书状态的更新操作 book_collect_info
                    string updateQuery = "UPDATE book_collect_info SET Bstate = 1 WHERE BCID = @BookId";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, conn, transaction);
                    updateCommand.Parameters.AddWithValue("@BookId", bcid);
                    rows_affected = updateCommand.ExecuteNonQuery();
                    if (rows_affected == 0)
                    {
                        State.Text = "书本更新失败";
                        MessageBox.Show("更新失败");
                        transaction.Rollback();
                        return false;
                    }

                    // 修改图书馆藏书量的更新操作 book_basic_info
                    string updateQuery_basicInfo = "UPDATE book_basic_info SET left_count = left_count - 1 WHERE ISBN_ID = @ISBN_Id";
                    MySqlCommand updateCommand_basic = new MySqlCommand(updateQuery_basicInfo, conn, transaction);
                    updateCommand_basic.Parameters.AddWithValue("@ISBN_Id", selectedISBN);
                    rows_affected = updateCommand_basic.ExecuteNonQuery();
                    if (rows_affected == 0)
                    {
                        State.Text = "书本数量更新失败";
                        MessageBox.Show("数量更新失败");
                        transaction.Rollback();
                        return false;
                    }


                    // 更新用户当前借阅情况
                    string updateQuery_count = "UPDATE reader_info SET hold_count = hold_count + 1, borrow_count = borrow_count + 1 WHERE ReaderID = @RId";
                    MySqlCommand updateCommand_count = new MySqlCommand(updateQuery_count, conn, transaction);
                    updateCommand_count.Parameters.AddWithValue("@RId", user_id);
                    rows_affected = updateCommand_count.ExecuteNonQuery();
                    if (rows_affected == 0)
                    {
                        State.Text = "用户借阅信息更新失败";
                        MessageBox.Show("借阅数量更新失败");
                        transaction.Rollback();
                        return false;
                    }

                    // 提交事务
                    transaction.Commit();
                    State.Text = "完成";
                    return true;

                }
                catch (Exception ex)
                {
                    // 发生异常时回滚事务
                    transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return false;
                }

            }
            catch (Exception ex)
            {
                // 处理异常
                Console.WriteLine("查询时出现异常：" + ex.Message);
                //return new DataTable();
            }
            return false;
        }

        private void EnterShelfButton_Click(object sender, EventArgs e)
        {
            Shelf myShelf = new Shelf();
            myShelf.SetInfo(user_name, user_id);
            myShelf.Show();
        }
    }
}
