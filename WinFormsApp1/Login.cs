using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            //Tools.GenData();
            if (textBox_username.Text.Trim() == "")
            {
                MessageBox.Show("提示：请输入用户名。");
            }
            else if (textBox_password.Text.Trim() == "")
            {
                MessageBox.Show("提示：请输入密码。");
            }
            else
            {
                //MySqlConnection conn = new MySqlConnection("server=localhost; database=data; UID=root; PWD = 123456; port = 3306");
                Connection con = new Connection();
                bool connected = con.Open();
                if (connected)
                {
                    string selectedType = LoginTypeComboBox.SelectedItem.ToString();
                    int type = loginComboBoxItems[selectedType];

                    bool logined = con.Login(textBox_username.Text.Trim(), textBox_password.Text.Trim(), type);
                    string user_id = con.GetId();
                    con.Close();
                    if (logined)
                    {
                        //MessageBox.Show("success");
                        if (type == 1)
                        {
                            Content cot = new Content();
                            cot.setUserName_ID(textBox_username.Text.Trim(),user_id,type);
                            //MessageBox.Show(Tools.GenID());
                            cot.Show();
                            //this.Hide();
                        }
                        else if (type == 2)
                        {
                            ManagerContent mCot = new ManagerContent();
                            mCot.setInfo(user_id, textBox_username.Text.Trim());
                            mCot.Show();
                            //this.Hide();
                        }


                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误");
                    }
                }
            }
        }

        private void Sign_Label_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LoginTypeComboBox.SelectedIndex = 0;
            loginComboBoxItems = new Dictionary<string, int>
            {
                { "我是读者", 1 },
                { "我是管理员", 2 }
            };
            /*   一开始是这样写，错在没有为loginComboBoxItems初始化分配内存  
             *   而LoginTypeComboBox是窗体中的物件，在load之前已经被初始化了
            LoginTypeComboBox.SelectedIndex = 0;
            loginComboBoxItems.Add("我是读者", 0);
            loginComboBoxItems.Add("我是管理员", 1);
            */
        }

        /*        private void LoginLoad(object sender, EventArgs e)
        {

        }*/
    }
}