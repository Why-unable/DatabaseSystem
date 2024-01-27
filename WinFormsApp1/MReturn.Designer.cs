namespace WinFormsApp1
{
    partial class MReturn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            searchTextBox = new TextBox();
            searchButton = new Button();
            welcomeLabel = new Label();
            BorrowListView = new ListView();
            returnButton = new Button();
            exceedLabel = new Label();
            searchTextBox2 = new TextBox();
            searchButton2 = new Button();
            damageComboBox = new ComboBox();
            SuspendLayout();
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(44, 89);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(200, 38);
            searchTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(250, 89);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(144, 38);
            searchButton.TabIndex = 1;
            searchButton.Text = "查询该读者";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Location = new Point(44, 19);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(134, 31);
            welcomeLabel.TabIndex = 2;
            welcomeLabel.Text = "欢迎回来，";
            // 
            // BorrowListView
            // 
            BorrowListView.Location = new Point(44, 133);
            BorrowListView.Name = "BorrowListView";
            BorrowListView.Size = new Size(1108, 378);
            BorrowListView.TabIndex = 3;
            BorrowListView.UseCompatibleStateImageBehavior = false;
            // 
            // returnButton
            // 
            returnButton.Location = new Point(1002, 517);
            returnButton.Name = "returnButton";
            returnButton.Size = new Size(150, 46);
            returnButton.TabIndex = 4;
            returnButton.Text = "归还此书";
            returnButton.UseVisualStyleBackColor = true;
            returnButton.Click += returnButton_Click;
            // 
            // exceedLabel
            // 
            exceedLabel.AutoSize = true;
            exceedLabel.Location = new Point(44, 532);
            exceedLabel.Name = "exceedLabel";
            exceedLabel.Size = new Size(123, 31);
            exceedLabel.TabIndex = 5;
            exceedLabel.Text = "is_exceed";
            // 
            // searchTextBox2
            // 
            searchTextBox2.Location = new Point(796, 87);
            searchTextBox2.Name = "searchTextBox2";
            searchTextBox2.Size = new Size(200, 38);
            searchTextBox2.TabIndex = 6;
            // 
            // searchButton2
            // 
            searchButton2.Location = new Point(1002, 87);
            searchButton2.Name = "searchButton2";
            searchButton2.Size = new Size(150, 38);
            searchButton2.TabIndex = 7;
            searchButton2.Text = "查询该书籍";
            searchButton2.UseVisualStyleBackColor = true;
            searchButton2.Click += searchButton2_Click;
            // 
            // damageComboBox
            // 
            damageComboBox.FormattingEnabled = true;
            damageComboBox.Location = new Point(44, 588);
            damageComboBox.Name = "damageComboBox";
            damageComboBox.Size = new Size(152, 39);
            damageComboBox.TabIndex = 8;
            // 
            // MReturn
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 667);
            Controls.Add(damageComboBox);
            Controls.Add(searchButton2);
            Controls.Add(searchTextBox2);
            Controls.Add(exceedLabel);
            Controls.Add(returnButton);
            Controls.Add(BorrowListView);
            Controls.Add(welcomeLabel);
            Controls.Add(searchButton);
            Controls.Add(searchTextBox);
            Name = "MReturn";
            Text = "图书归还";
            Load += MReturn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchTextBox;
        private Button searchButton;
        private Label welcomeLabel;
        private ListView BorrowListView;
        private Button returnButton;
        private Label exceedLabel;
        private TextBox searchTextBox2;
        private Button searchButton2;
        private ComboBox damageComboBox;
    }
}