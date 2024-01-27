namespace WinFormsApp1
{
    partial class ReaderInfo
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
            RInfoTitlePanel = new Panel();
            RInfoDetailPanel = new Panel();
            assureButton = new Button();
            SuspendLayout();
            // 
            // RInfoTitlePanel
            // 
            RInfoTitlePanel.Location = new Point(120, 30);
            RInfoTitlePanel.Name = "RInfoTitlePanel";
            RInfoTitlePanel.Size = new Size(150, 600);
            RInfoTitlePanel.TabIndex = 0;
            // 
            // RInfoDetailPanel
            // 
            RInfoDetailPanel.Location = new Point(300, 30);
            RInfoDetailPanel.Name = "RInfoDetailPanel";
            RInfoDetailPanel.Size = new Size(300, 600);
            RInfoDetailPanel.TabIndex = 1;
            // 
            // assureButton
            // 
            assureButton.Location = new Point(686, 584);
            assureButton.Name = "assureButton";
            assureButton.Size = new Size(150, 46);
            assureButton.TabIndex = 2;
            assureButton.Text = "确认修改";
            assureButton.UseVisualStyleBackColor = true;
            assureButton.Click += AssureButton_Click;
            // 
            // ReaderInfo
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 677);
            Controls.Add(assureButton);
            Controls.Add(RInfoDetailPanel);
            Controls.Add(RInfoTitlePanel);
            Name = "ReaderInfo";
            Text = "我的";
            Load += ReaderInfo_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel RInfoTitlePanel;
        private Panel RInfoDetailPanel;
        private Button assureButton;
    }
}