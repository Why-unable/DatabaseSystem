namespace WinFormsApp1
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            login_button = new Button();
            label_password = new Label();
            label_user_name = new Label();
            textBox_username = new TextBox();
            textBox_password = new TextBox();
            sign_in_label = new Label();
            LoginTypeComboBox = new ComboBox();
            SuspendLayout();
            // 
            // login_button
            // 
            login_button.Location = new Point(318, 318);
            login_button.Name = "login_button";
            login_button.Size = new Size(150, 46);
            login_button.TabIndex = 1;
            login_button.Text = "登录";
            login_button.UseVisualStyleBackColor = true;
            login_button.Click += LoginButton_Click;
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Location = new Point(191, 155);
            label_password.Name = "label_password";
            label_password.Size = new Size(62, 31);
            label_password.TabIndex = 3;
            label_password.Text = "密码";
            // 
            // label_user_name
            // 
            label_user_name.AutoSize = true;
            label_user_name.Location = new Point(191, 95);
            label_user_name.Name = "label_user_name";
            label_user_name.Size = new Size(86, 31);
            label_user_name.TabIndex = 4;
            label_user_name.Text = "用户名";
            // 
            // textBox_username
            // 
            textBox_username.Location = new Point(283, 95);
            textBox_username.Name = "textBox_username";
            textBox_username.Size = new Size(200, 38);
            textBox_username.TabIndex = 5;
            // 
            // textBox_password
            // 
            textBox_password.Location = new Point(283, 155);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(200, 38);
            textBox_password.TabIndex = 6;
            // 
            // sign_in_label
            // 
            sign_in_label.AutoSize = true;
            sign_in_label.Cursor = Cursors.SizeAll;
            sign_in_label.ImageAlign = ContentAlignment.BottomCenter;
            sign_in_label.Location = new Point(649, 333);
            sign_in_label.Name = "sign_in_label";
            sign_in_label.Size = new Size(110, 31);
            sign_in_label.TabIndex = 7;
            sign_in_label.Text = "点此注册";
            sign_in_label.Click += Sign_Label_Click;
            // 
            // LoginTypeComboBox
            // 
            LoginTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LoginTypeComboBox.FormattingEnabled = true;
            LoginTypeComboBox.Items.AddRange(new object[] { "我是读者", "我是管理员" });
            LoginTypeComboBox.Location = new Point(567, 95);
            LoginTypeComboBox.Name = "LoginTypeComboBox";
            LoginTypeComboBox.Size = new Size(192, 39);
            LoginTypeComboBox.TabIndex = 8;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 475);
            Controls.Add(LoginTypeComboBox);
            Controls.Add(sign_in_label);
            Controls.Add(textBox_password);
            Controls.Add(textBox_username);
            Controls.Add(label_user_name);
            Controls.Add(label_password);
            Controls.Add(login_button);
            Name = "Login";
            Text = "登录";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button login_button;
        private Label label_password;
        private Label label_user_name;
        private TextBox textBox_username;
        private TextBox textBox_password;
        private Label sign_in_label;
        private ComboBox LoginTypeComboBox;
        private Dictionary<string, int> loginComboBoxItems;


    }
}