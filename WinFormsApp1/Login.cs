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
                MessageBox.Show("��ʾ���������û�����");
            }
            else if (textBox_password.Text.Trim() == "")
            {
                MessageBox.Show("��ʾ�����������롣");
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
                        MessageBox.Show("�û������������");
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
                { "���Ƕ���", 1 },
                { "���ǹ���Ա", 2 }
            };
            /*   һ��ʼ������д������û��ΪloginComboBoxItems��ʼ�������ڴ�  
             *   ��LoginTypeComboBox�Ǵ����е��������load֮ǰ�Ѿ�����ʼ����
            LoginTypeComboBox.SelectedIndex = 0;
            loginComboBoxItems.Add("���Ƕ���", 0);
            loginComboBoxItems.Add("���ǹ���Ա", 1);
            */
        }

        /*        private void LoginLoad(object sender, EventArgs e)
        {

        }*/
    }
}