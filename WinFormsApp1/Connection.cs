using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    internal class Connection
    {
        private MySqlConnection conn;
        //MySqlConnection conn = new MySqlConnection("server=localhost; database=data; UID=root; PWD = 123456; port = 3306");
        private string server_name = "localhost";
        private string database="data";
        private string uid="root";
        private string pwd="123456";
        private string port="3306";

        private string user_id;

        public Connection()
        {
            conn = new MySqlConnection("server="+server_name + "; database=" + database + "; UID=" + uid + "; PWD = " + pwd + "; port = " + port);

        }
        public bool Open()
        {
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }
        public MySqlConnection getCon()
        {
            return conn;
        }
        public string GetId()
        {
            return user_id;
        }
        public void Close()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool Login(string username,string password, int loginType)
        {
            try
            {
                string query_user = "SELECT * FROM reader_info WHERE Rname = @name and password = @password";

                string query_manager = "SELECT * FROM admin_info WHERE Aname = @name and password = @password";
                string query= query_user;
                if(loginType == 1) {
                    query = query_user;
                }else if(loginType == 2) { query = query_manager; }


                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    // 添加预编译参数
                    command.Parameters.AddWithValue("@name", username);
                    command.Parameters.AddWithValue("@password", password);

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
                            if(loginType == 1)
                                user_id = dt.Rows[0]["ReaderID"].ToString();
                            else if(loginType == 2)
                                user_id = dt.Rows[0]["AID"].ToString();
                            return true;
                        }
                    }
        
                }
            }
            catch (Exception ex)
            {
                // 处理异常
                Console.WriteLine("查询时出现异常：" + ex.Message);
            }
            return false;
        }

    }
}
