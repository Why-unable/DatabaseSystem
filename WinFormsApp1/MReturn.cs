using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace WinFormsApp1
{
    public partial class MReturn : Form
    {

        private string Mid;
        private string Mname;
        private string labelContent = "欢迎回来，";
        private Dictionary<string, int> damageComboBoxItems;

        private string readerName;
        private string bcid;

        private string readerID;
        private string BCID;
        private string AID;
        private string BorrowID;
        private string dueDate;
        private string is_damage;
        private string is_exceed;
        private string ISBN;

        public MReturn()
        {
            InitializeComponent();
        }

        public void setInfo(string Mid, string Mname)
        {
            this.Mid = Mid;
            this.Mname = Mname;
            labelContent += this.Mname + "!";
        }

        private void MReturn_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text = labelContent;

            damageComboBox.Items.AddRange(new object[] { "有损坏", "无损坏" });

            damageComboBox.SelectedIndex = 1;
            damageComboBoxItems = new Dictionary<string, int>
            {
                { "有损坏", 1 },
                { "无损坏", 0 }
            };
        }

        public void Search(string readerName, string bcid = "-1")
        {
            try
            {
                Connection con = new Connection();
                con.Open();
                MySqlConnection conn = con.getCon();
                string query_borrowInfo = "";
                if (bcid == "-1")
                {
                    query_borrowInfo = "SELECT borrow_record.readerid AS '读者编号', Book_basic_info.ISBN_ID AS '图书编号', borrow_record.BCID as '馆藏编号'," +
                    " BName AS '图书名称', author AS '作者', order_edition AS '版本', borrow_date as '借阅日期', due_date as '到期日期', is_return as '是否归还' " +
                    " FROM  Book_basic_info, Book_collect_info, borrow_record, reader_info" +
                    " WHERE Book_collect_info.ISBN_ID = Book_basic_info.ISBN_ID and borrow_record.readerid = reader_info.readerid and reader_info.Rname = @rname and borrow_record.BCID = Book_collect_info.BCID";
                }
                else
                {
                    query_borrowInfo = "SELECT borrow_record.readerid AS '读者编号', borrow_record.borrow_ID as '借阅记录编号', Book_basic_info.ISBN_ID AS '图书编号', borrow_record.BCID as '馆藏编号'," +
                    " BName AS '图书名称', author AS '作者', order_edition AS '版本', borrow_date as '借阅日期', due_date as '到期日期', is_return as '是否归还' " +
                    " FROM  Book_basic_info, Book_collect_info, borrow_record, reader_info" +
                    " WHERE Book_collect_info.ISBN_ID = Book_basic_info.ISBN_ID and borrow_record.readerid = reader_info.readerid and reader_info.Rname = @rname and borrow_record.BCID = @bcid and borrow_record.BCID = Book_collect_info.BCID";
                }
                using (MySqlCommand command = new MySqlCommand(query_borrowInfo, conn))
                {
                    // 添加预编译参数
                    //command.Parameters.AddWithValue("@name", user_name);

                    command.Parameters.AddWithValue("@rname", readerName);
                    if (bcid != "-1")
                    {
                        command.Parameters.AddWithValue("@bcid", bcid);
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
                            BorrowListView.Items.Clear();
                            BorrowListView.Columns.Clear();
                            BorrowListView.View = View.Details;
                            //BookListView.Width = 1150;
                            BorrowListView.Scrollable = true;


                            // 添加列标题
                            foreach (DataColumn column in dt.Columns)
                            {
                                BorrowListView.Columns.Add(column.Caption);
                            }

                            // 添加行数据
                            foreach (DataRow row in dt.Rows)
                            {
                                string is_return = row["是否归还"].ToString() == "0" ? "否" : "是";

                                if (is_return == "否")
                                {
                                    if (bcid != "-1")
                                    {
                                        readerID = row["读者编号"].ToString();
                                        BCID = row["馆藏编号"].ToString();
                                        BorrowID = row["借阅记录编号"].ToString();
                                        dueDate = row["到期日期"].ToString();
                                        ISBN = row["图书编号"].ToString();


                                        if (DateTime.Now < DateTime.Parse(dueDate))
                                        {
                                            exceedLabel.Text = "未到期";
                                            is_exceed = "0";
                                        }
                                        else
                                        {
                                            MessageBox.Show("超期，需要办理罚款业务");
                                            exceedLabel.Text = "已超期";
                                            is_exceed = "1";
                                        }

                                    }
                                }

                                string[] rowData = row.ItemArray.Select(x => x.ToString()).ToArray();
                                rowData[9] = is_return;
                                ListViewItem item = new ListViewItem(rowData);
                                BorrowListView.Items.Add(item);
                            }
                            BorrowListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                            // 遍历所有列并修改宽度
                            foreach (ColumnHeader column in BorrowListView.Columns)
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            readerName = searchTextBox.Text.Trim();
            if (readerName.Length > 0)
            {
                Search(readerName);

            }
        }

        private void searchButton2_Click(object sender, EventArgs e)
        {
            bcid = searchTextBox2.Text.Trim();
            if (bcid.Length > 0 && searchTextBox.Text.Trim().Length > 0)
            {
                try
                {
                    Search(searchTextBox.Text.Trim(), bcid);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("????" + ex);
                }
            }
            else return;

                        

        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            bool ans = ReturnBook();
            if (ans)
            {
                MessageBox.Show("归还成功");
            }
            else
            {
                MessageBox.Show("归还失败");
            }

        }

        public bool ReturnBook()
        {
            try
            {
                //开始事务
                Connection con = new Connection();
                con.Open();
                MySqlConnection conn = con.getCon();

                MySqlTransaction transaction = conn.BeginTransaction();

                //生成归还记录
                string insertQuery = "INSERT INTO return_record VALUES (@return_ID, @ReaderID, @BCID, @AID, @Borrow_ID, @return_time, @time_limit_exceed, @damage)";
                MySqlCommand insertCommand = new MySqlCommand(insertQuery, conn, transaction);
                insertCommand.Parameters.AddWithValue("@return_ID", Tools.GenID());
                insertCommand.Parameters.AddWithValue("@ReaderID", readerID);
                insertCommand.Parameters.AddWithValue("@AID", Mid);
                insertCommand.Parameters.AddWithValue("@BCID", BCID);
                insertCommand.Parameters.AddWithValue("@Borrow_ID", BorrowID);
                insertCommand.Parameters.AddWithValue("@return_time", DateTime.Now);
                insertCommand.Parameters.AddWithValue("@time_limit_exceed", is_exceed);  //damageComboBoxItems
                insertCommand.Parameters.AddWithValue("@damage", damageComboBoxItems[damageComboBox.SelectedItem.ToString()]);

                int rows_affected = insertCommand.ExecuteNonQuery();
                if (rows_affected == 0)
                {
                    MessageBox.Show("生成归还记录失败");

                    // 发生异常时回滚事务
                    transaction.Rollback();
                    return false;
                }
                else
                {
                }

                //修改借阅记录
                string updateQueryBorrow = "UPDATE borrow_record SET is_return = 1 WHERE Borrow_id = @borrow_id";
                MySqlCommand updateBCommand = new MySqlCommand(updateQueryBorrow, conn, transaction);
                updateBCommand.Parameters.AddWithValue("@borrow_id", BorrowID);
                rows_affected = updateBCommand.ExecuteNonQuery();
                if (rows_affected == 0)
                {
                    MessageBox.Show("更新失败");
                    transaction.Rollback();
                    return false;
                }

                //修改图书属性
                string updateQueryBook = "UPDATE book_collect_info SET Bstate = 0 WHERE BCID = @BookId";
                MySqlCommand updateCommandBook = new MySqlCommand(updateQueryBook, conn, transaction);
                updateCommandBook.Parameters.AddWithValue("@BookId", BCID);
                rows_affected = updateCommandBook.ExecuteNonQuery();
                if (rows_affected == 0)
                {
                    MessageBox.Show("更新失败");
                    transaction.Rollback();
                    return false;
                }

                //修改馆藏数量
                string updateQuery_basicInfo = "UPDATE book_basic_info SET left_count = left_count + 1 WHERE ISBN_ID = @ISBN_Id";
                MySqlCommand updateCommand_basic = new MySqlCommand(updateQuery_basicInfo, conn, transaction);
                updateCommand_basic.Parameters.AddWithValue("@ISBN_Id", ISBN);
                rows_affected = updateCommand_basic.ExecuteNonQuery();
                if (rows_affected == 0)
                {
                    MessageBox.Show("数量更新失败");
                    transaction.Rollback();
                    return false;
                }

                //修改读者hold_count
                string updateQuery_count = "UPDATE reader_info SET hold_count = hold_count - 1 WHERE ReaderID = @RId";
                MySqlCommand updateCommand_count = new MySqlCommand(updateQuery_count, conn, transaction);
                updateCommand_count.Parameters.AddWithValue("@RId", readerID);
                rows_affected = updateCommand_count.ExecuteNonQuery();
                if (rows_affected == 0)
                {
                    MessageBox.Show("借阅数量更新失败");
                    transaction.Rollback();
                    return false;
                }

                //可能的罚款
                if (damageComboBoxItems[damageComboBox.SelectedItem.ToString()] == 1)
                {
                    MessageBox.Show(readerID + Mid + BCID + BorrowID + is_exceed + damageComboBoxItems[damageComboBox.SelectedItem.ToString()]);
                    string insertQueryVio = "INSERT INTO violate_record VALUES (@vioID, @AID, @borrow_ID, null, @pay_account, @pay_state, null)";
                    MySqlCommand insertCommandVio = new MySqlCommand(insertQueryVio, conn, transaction);
                    insertCommandVio.Parameters.AddWithValue("@vioID", Tools.GenID());
                    insertCommandVio.Parameters.AddWithValue("@AID", Mid);
                    insertCommandVio.Parameters.AddWithValue("@Borrow_ID", BorrowID);
                    //insertCommandVio.Parameters.AddWithValue("@pay_date", );
                    insertCommandVio.Parameters.AddWithValue("@pay_account", 20);  //damageComboBoxItems
                    insertCommandVio.Parameters.AddWithValue("@pay_state", 0);
                    //insertCommandVio.Parameters.AddWithValue("@statement", null);

                    rows_affected = insertCommandVio.ExecuteNonQuery();
                    if (rows_affected == 0)
                    {
                        MessageBox.Show("生成罚款记录失败");

                        // 发生异常时回滚事务
                        transaction.Rollback();
                        return false;
                    }
                }

                // 提交事务
                transaction.Commit();
                return true;

            }
            catch (Exception ex)
            {
               
                MessageBox.Show("An error occurred: " + ex.Message);
                return false;
            }

        }
    }
}
