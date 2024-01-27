namespace WinFormsApp1
{
    partial class Shelf
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
            shelfListView = new ListView();
            curButton = new Button();
            historyButton = new Button();
            returnButton = new Button();
            SuspendLayout();
            // 
            // shelfListView
            // 
            shelfListView.Location = new Point(62, 93);
            shelfListView.Name = "shelfListView";
            shelfListView.Size = new Size(1026, 456);
            shelfListView.TabIndex = 0;
            shelfListView.UseCompatibleStateImageBehavior = false;
            // 
            // curButton
            // 
            curButton.Location = new Point(62, 41);
            curButton.Name = "curButton";
            curButton.Size = new Size(150, 46);
            curButton.TabIndex = 1;
            curButton.Text = "当前借阅";
            curButton.UseVisualStyleBackColor = true;
            // 
            // historyButton
            // 
            historyButton.Location = new Point(218, 41);
            historyButton.Name = "historyButton";
            historyButton.Size = new Size(150, 46);
            historyButton.TabIndex = 2;
            historyButton.Text = "历史借阅";
            historyButton.UseVisualStyleBackColor = true;
            // 
            // returnButton
            // 
            returnButton.Location = new Point(938, 41);
            returnButton.Name = "returnButton";
            returnButton.Size = new Size(150, 46);
            returnButton.TabIndex = 3;
            returnButton.Text = "归还此书";
            returnButton.UseVisualStyleBackColor = true;
            // 
            // Shelf
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 613);
            Controls.Add(returnButton);
            Controls.Add(historyButton);
            Controls.Add(curButton);
            Controls.Add(shelfListView);
            Name = "Shelf";
            Text = "我的书架";
            Load += Shelf_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView shelfListView;
        private Button curButton;
        private Button historyButton;
        private Button returnButton;
    }
}