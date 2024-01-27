namespace WinFormsApp1
{
    partial class Content
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
            Welcome_Label = new Label();
            ReaderInfoButton = new Button();
            enterShelfButton = new Button();
            BookListView = new ListView();
            searchTextBox = new TextBox();
            searchButton = new Button();
            selectButton = new Button();
            State = new Label();
            SuspendLayout();
            // 
            // Welcome_Label
            // 
            Welcome_Label.AutoSize = true;
            Welcome_Label.Location = new Point(27, 28);
            Welcome_Label.Name = "Welcome_Label";
            Welcome_Label.Size = new Size(110, 31);
            Welcome_Label.TabIndex = 0;
            Welcome_Label.Text = "欢迎回来";
            // 
            // ReaderInfoButton
            // 
            ReaderInfoButton.Location = new Point(30, 81);
            ReaderInfoButton.Name = "ReaderInfoButton";
            ReaderInfoButton.Size = new Size(150, 46);
            ReaderInfoButton.TabIndex = 1;
            ReaderInfoButton.Text = "个人信息";
            ReaderInfoButton.UseVisualStyleBackColor = true;
            ReaderInfoButton.Click += ReaderInfoButton_Click;
            // 
            // enterShelfButton
            // 
            enterShelfButton.Location = new Point(250, 82);
            enterShelfButton.Name = "enterShelfButton";
            enterShelfButton.Size = new Size(150, 46);
            enterShelfButton.TabIndex = 2;
            enterShelfButton.Text = "我的书架";
            enterShelfButton.UseVisualStyleBackColor = true;
            enterShelfButton.Click += EnterShelfButton_Click;
            // 
            // BookListView
            // 
            BookListView.BackColor = SystemColors.InactiveCaption;
            BookListView.Location = new Point(27, 207);
            BookListView.Name = "BookListView";
            BookListView.Size = new Size(1239, 518);
            BookListView.TabIndex = 3;
            BookListView.UseCompatibleStateImageBehavior = false;
            BookListView.ItemSelectionChanged += BookListView_ItemSelectionChanged;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(30, 163);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(250, 38);
            searchTextBox.TabIndex = 5;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(286, 163);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(150, 40);
            searchButton.TabIndex = 7;
            searchButton.Text = "查询";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            // 
            // selectButton
            // 
            selectButton.Location = new Point(1116, 163);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(150, 40);
            selectButton.TabIndex = 8;
            selectButton.Text = "借阅此书";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += selectButton_Click;
            // 
            // State
            // 
            State.AutoSize = true;
            State.Location = new Point(1100, 44);
            State.Name = "State";
            State.Size = new Size(82, 31);
            State.TabIndex = 9;
            State.Text = "label1";
            // 
            // Content
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1310, 850);
            Controls.Add(State);
            Controls.Add(selectButton);
            Controls.Add(searchButton);
            Controls.Add(searchTextBox);
            Controls.Add(BookListView);
            Controls.Add(enterShelfButton);
            Controls.Add(ReaderInfoButton);
            Controls.Add(Welcome_Label);
            Name = "Content";
            Text = "主界面";
            Load += Content_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Welcome_Label;
        private Button ReaderInfoButton;
        private Button enterShelfButton;
        private ListView BookListView;
        private TextBox searchTextBox;
        private Button searchButton;
        private Button selectButton;
        private Label State;
    }
}