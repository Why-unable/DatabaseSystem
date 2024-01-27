using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Tools
    {
        public static string GenID()
        {
            // 获取当前时间戳
            DateTime now = DateTime.Now;
            string timestamp = now.ToString("yyyyMMddHHmmss");


            string Guid_part = Guid.NewGuid().ToString().Substring(0,15);


            return timestamp + Guid_part;
        }

        public static bool GenData() {
            return true;
            try
            {
                Connection con = new();
                bool flag = con.Open();
                MySqlConnection conn = con.getCon();
                /*

                string Query = $"UPDATE {tableName} SET {columnName1} = @NewContact , {columnName2} = @NewPassword WHERE Rname = @user_name";
                */
                string BCid = "";
                string ISBN_id = "";
                int Bstate = 0;
                string BCtime = "";
                string Query = "INSERT INTO book_collect_info values(@BCID, @ISBN_ID, @Bstate, @BCtime)";
                using (MySqlCommand command = new MySqlCommand(Query, conn))
                {
                    // 添加预编译参数
                    command.Parameters.Add("@BCID", MySqlDbType.VarChar);
                    command.Parameters.Add("@ISBN_ID", MySqlDbType.VarChar);
                    command.Parameters.Add("@Bstate", MySqlDbType.VarChar);
                    command.Parameters.Add("@BCtime", MySqlDbType.VarChar);

                    int rf = 0;
                    for(int i = 0; i < 85; i++)
                    {
                        BCid = GenID();
                        // 设置参数的值
                        ISBN_id = "100020003300";
                        DateTime currentDateTime = DateTime.Now;
                        BCtime = currentDateTime.ToString("yyyy-MM-dd");
                        command.Parameters["@BCID"].Value = BCid;
                        command.Parameters["@ISBN_ID"].Value = ISBN_id;
                        command.Parameters["@Bstate"].Value = Bstate;
                        command.Parameters["@BCtime"].Value = BCtime;
                        int rowsAffected = command.ExecuteNonQuery();
                        rf += rowsAffected;
                    }
                    MessageBox.Show(rf.ToString());
                    //int rowsAffected = command.ExecuteNonQuery();
                    /*
                    if (rowsAffected > 0)
                    {
                        // 更新成功
                        MessageBox.Show("yes");
                    }
                    else
                    {
                        // 更新失败
                    }
                    */

                }
                con.Close();
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
