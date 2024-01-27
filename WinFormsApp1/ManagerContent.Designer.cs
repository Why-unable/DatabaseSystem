namespace WinFormsApp1
{
    partial class ManagerContent
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
            ReaderMButton = new Button();
            Welcome_Label = new Label();
            BorrowMButton = new Button();
            ReturnMButton = new Button();
            FineMButton = new Button();
            SuspendLayout();
            // 
            // ReaderMButton
            // 
            ReaderMButton.Location = new Point(219, 140);
            ReaderMButton.Name = "ReaderMButton";
            ReaderMButton.Size = new Size(150, 50);
            ReaderMButton.TabIndex = 0;
            ReaderMButton.Text = "读者管理";
            ReaderMButton.UseVisualStyleBackColor = true;
            ReaderMButton.Click += ReaderMButton_Click;
            // 
            // Welcome_Label
            // 
            Welcome_Label.AutoSize = true;
            Welcome_Label.Location = new Point(55, 41);
            Welcome_Label.Name = "Welcome_Label";
            Welcome_Label.Size = new Size(82, 31);
            Welcome_Label.TabIndex = 1;
            Welcome_Label.Text = "label1";
            // 
            // BorrowMButton
            // 
            BorrowMButton.Location = new Point(219, 277);
            BorrowMButton.Name = "BorrowMButton";
            BorrowMButton.Size = new Size(150, 46);
            BorrowMButton.TabIndex = 2;
            BorrowMButton.Text = "借阅管理";
            BorrowMButton.UseVisualStyleBackColor = true;
            // 
            // ReturnMButton
            // 
            ReturnMButton.Location = new Point(219, 403);
            ReturnMButton.Name = "ReturnMButton";
            ReturnMButton.Size = new Size(150, 46);
            ReturnMButton.TabIndex = 3;
            ReturnMButton.Text = "归还管理";
            ReturnMButton.UseVisualStyleBackColor = true;
            ReturnMButton.Click += ReturnMButton_Click;
            // 
            // FineMButton
            // 
            FineMButton.Location = new Point(219, 529);
            FineMButton.Name = "FineMButton";
            FineMButton.Size = new Size(150, 46);
            FineMButton.TabIndex = 4;
            FineMButton.Text = "罚款管理";
            FineMButton.UseVisualStyleBackColor = true;
            // 
            // ManagerContent
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 731);
            Controls.Add(FineMButton);
            Controls.Add(ReturnMButton);
            Controls.Add(BorrowMButton);
            Controls.Add(Welcome_Label);
            Controls.Add(ReaderMButton);
            Name = "ManagerContent";
            Text = "管理员界面";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ReaderMButton;
        private Label Welcome_Label;
        private Button BorrowMButton;
        private Button ReturnMButton;
        private Button FineMButton;
    }
}