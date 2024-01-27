using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Shelf : Form
    {
        private string user_name;
        private string user_id;
        private int readerType;
        private int Type_cur = 1;
        private int Type_his = 2;
        public Shelf()
        {
            InitializeComponent();
        }

        private void Shelf_Load(object sender, EventArgs e)
        {
            FillTheList(1);
        }
        public void SetInfo(string uname, string uid)
        {
            user_name = uname;
            user_id = uid;
        }

        private void FillTheList(int Type)
        {
            try
            {
                Connection con = new Connection();
                con.Open();
                MySqlConnection conn = con.getCon();
                string query_borrowInfo = "";
                if (Type == Type_cur)
                {
                    query_borrowInfo = "SELECT Book_basic_info.ISBN_ID AS '图书编号', borrow_record.BCID as '馆藏编号'," +
                    " BName AS '图书名称', author AS '作者', order_edition AS '版本', borrow_date as '借阅日期', due_date as '到期日期', is_return as '是否归还'" +
                    " FROM  Book_basic_info, Book_collect_info, borrow_record " +
                    " WHERE Book_collect_info.ISBN_ID = Book_basic_info.ISBN_ID and borrow_record.readerid = @userId and borrow_record.BCID = Book_collect_info.BCID";

                }
                else if (Type == Type_his)
                {
                    query_borrowInfo = "SELECT Book_basic_info.ISBN_ID AS '图书编号', borrow_record.BCID as '馆藏编号'," +
                    " BName AS '图书名称', author AS '作者', order_edition AS '版本', borrow_date as '借阅日期', due_date as '到期日期'" +
                    " FROM  Book_basic_info, Book_collect_info, borrow_record " +
                    " WHERE Book_collect_info.ISBN_ID = Book_basic_info.ISBN_ID and borrow_record.readerid = @userId and borrow_record.BCID = Book_collect_info.BCID";
                }
                else
                {
                    return;
                }
                using (MySqlCommand command = new MySqlCommand(query_borrowInfo, conn))
                {
                    // 添加预编译参数
                    //command.Parameters.AddWithValue("@name", user_name);
                    command.Parameters.AddWithValue("@userId", user_id);

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
                            shelfListView.Items.Clear();
                            shelfListView.Columns.Clear();
                            shelfListView.View = View.Details;
                            //BookListView.Width = 1150;
                            shelfListView.Scrollable = true;


                            // 添加列标题
                            foreach (DataColumn column in dt.Columns)
                            {
                                shelfListView.Columns.Add(column.Caption);
                            }

                            // 添加行数据
                            foreach (DataRow row in dt.Rows)
                            {
                                string is_return = row["是否归还"].ToString() == "0" ? "否" : "是";
                                string[] rowData = row.ItemArray.Select(x => x.ToString()).ToArray();
                                rowData[7] = is_return;
                                ListViewItem item = new ListViewItem(rowData);
                                shelfListView.Items.Add(item);
                            }
                            shelfListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                            // 遍历所有列并修改宽度
                            foreach (ColumnHeader column in shelfListView.Columns)
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
    }
}
