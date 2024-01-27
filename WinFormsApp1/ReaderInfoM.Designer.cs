namespace WinFormsApp1
{
    partial class ReaderInfoM
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
            readerInfoListView = new ListView();
            editGroupBox = new GroupBox();
            delButton = new Button();
            cancelButton = new Button();
            assureButton = new Button();
            editStateComboBox = new ComboBox();
            stateComboBox = new ComboBox();
            remarkTextBox = new TextBox();
            ValidToTextBox = new TextBox();
            rigiDateTextBox = new TextBox();
            idTextBox = new TextBox();
            stateLabel = new Label();
            remarkLabel = new Label();
            validToLabel = new Label();
            rigiDateLabel = new Label();
            idLabel = new Label();
            contactTextBox = new TextBox();
            passWTextBox = new TextBox();
            sexComboBox = new ComboBox();
            nameTextBox = new TextBox();
            contactLabel = new Label();
            passWLabel = new Label();
            sexLabel = new Label();
            nameLabel = new Label();
            typeLabel = new Label();
            rTypeComboBox = new ComboBox();
            editGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // readerInfoListView
            // 
            readerInfoListView.BackColor = SystemColors.GradientActiveCaption;
            readerInfoListView.Location = new Point(31, 12);
            readerInfoListView.Name = "readerInfoListView";
            readerInfoListView.Size = new Size(1271, 393);
            readerInfoListView.TabIndex = 0;
            readerInfoListView.UseCompatibleStateImageBehavior = false;
            readerInfoListView.ItemSelectionChanged += ReaderInfoListView_ItemSelectionChanged;
            // 
            // editGroupBox
            // 
            editGroupBox.BackColor = SystemColors.GradientActiveCaption;
            editGroupBox.Controls.Add(delButton);
            editGroupBox.Controls.Add(cancelButton);
            editGroupBox.Controls.Add(assureButton);
            editGroupBox.Controls.Add(editStateComboBox);
            editGroupBox.Controls.Add(stateComboBox);
            editGroupBox.Controls.Add(remarkTextBox);
            editGroupBox.Controls.Add(ValidToTextBox);
            editGroupBox.Controls.Add(rigiDateTextBox);
            editGroupBox.Controls.Add(idTextBox);
            editGroupBox.Controls.Add(stateLabel);
            editGroupBox.Controls.Add(remarkLabel);
            editGroupBox.Controls.Add(validToLabel);
            editGroupBox.Controls.Add(rigiDateLabel);
            editGroupBox.Controls.Add(idLabel);
            editGroupBox.Controls.Add(contactTextBox);
            editGroupBox.Controls.Add(passWTextBox);
            editGroupBox.Controls.Add(sexComboBox);
            editGroupBox.Controls.Add(nameTextBox);
            editGroupBox.Controls.Add(contactLabel);
            editGroupBox.Controls.Add(passWLabel);
            editGroupBox.Controls.Add(sexLabel);
            editGroupBox.Controls.Add(nameLabel);
            editGroupBox.Controls.Add(typeLabel);
            editGroupBox.Controls.Add(rTypeComboBox);
            editGroupBox.Location = new Point(31, 438);
            editGroupBox.Name = "editGroupBox";
            editGroupBox.Size = new Size(1271, 367);
            editGroupBox.TabIndex = 2;
            editGroupBox.TabStop = false;
            editGroupBox.Text = "信息预览   状态：";
            // 
            // delButton
            // 
            delButton.ForeColor = Color.Red;
            delButton.Location = new Point(960, 315);
            delButton.Name = "delButton";
            delButton.Size = new Size(150, 46);
            delButton.TabIndex = 23;
            delButton.Text = "删除该读者";
            delButton.UseVisualStyleBackColor = true;
            delButton.Click += DelButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(714, 315);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(150, 46);
            cancelButton.TabIndex = 22;
            cancelButton.Text = "取消";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // assureButton
            // 
            assureButton.Location = new Point(499, 315);
            assureButton.Name = "assureButton";
            assureButton.Size = new Size(150, 46);
            assureButton.TabIndex = 21;
            assureButton.Text = "确认";
            assureButton.UseVisualStyleBackColor = true;
            assureButton.Click += assureButton_Click;
            // 
            // editStateComboBox
            // 
            editStateComboBox.FormattingEnabled = true;
            editStateComboBox.Location = new Point(201, 0);
            editStateComboBox.Name = "editStateComboBox";
            editStateComboBox.Size = new Size(209, 39);
            editStateComboBox.TabIndex = 20;
            editStateComboBox.SelectedIndexChanged += EditStateComboBox_SelectedIndexChanged;
            // 
            // stateComboBox
            // 
            stateComboBox.FormattingEnabled = true;
            stateComboBox.Location = new Point(924, 250);
            stateComboBox.Name = "stateComboBox";
            stateComboBox.Size = new Size(90, 39);
            stateComboBox.TabIndex = 19;
            // 
            // remarkTextBox
            // 
            remarkTextBox.Location = new Point(924, 205);
            remarkTextBox.Name = "remarkTextBox";
            remarkTextBox.Size = new Size(200, 38);
            remarkTextBox.TabIndex = 18;
            // 
            // ValidToTextBox
            // 
            ValidToTextBox.Location = new Point(924, 160);
            ValidToTextBox.Name = "ValidToTextBox";
            ValidToTextBox.Size = new Size(200, 38);
            ValidToTextBox.TabIndex = 17;
            // 
            // rigiDateTextBox
            // 
            rigiDateTextBox.Location = new Point(924, 115);
            rigiDateTextBox.Name = "rigiDateTextBox";
            rigiDateTextBox.Size = new Size(200, 38);
            rigiDateTextBox.TabIndex = 16;
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(924, 70);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(200, 38);
            idTextBox.TabIndex = 15;
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new Point(670, 250);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(111, 31);
            stateLabel.TabIndex = 14;
            stateLabel.Text = "       状态";
            // 
            // remarkLabel
            // 
            remarkLabel.AutoSize = true;
            remarkLabel.Location = new Point(670, 205);
            remarkLabel.Name = "remarkLabel";
            remarkLabel.Size = new Size(111, 31);
            remarkLabel.TabIndex = 13;
            remarkLabel.Text = "       备注";
            // 
            // validToLabel
            // 
            validToLabel.AutoSize = true;
            validToLabel.Location = new Point(670, 160);
            validToLabel.Name = "validToLabel";
            validToLabel.Size = new Size(110, 31);
            validToLabel.TabIndex = 12;
            validToLabel.Text = "到期日期";
            // 
            // rigiDateLabel
            // 
            rigiDateLabel.AutoSize = true;
            rigiDateLabel.Location = new Point(670, 115);
            rigiDateLabel.Name = "rigiDateLabel";
            rigiDateLabel.Size = new Size(110, 31);
            rigiDateLabel.TabIndex = 11;
            rigiDateLabel.Text = "登记日期";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(670, 70);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(110, 31);
            idLabel.TabIndex = 10;
            idLabel.Text = "读者编号";
            // 
            // contactTextBox
            // 
            contactTextBox.Location = new Point(257, 250);
            contactTextBox.Name = "contactTextBox";
            contactTextBox.Size = new Size(200, 38);
            contactTextBox.TabIndex = 9;
            // 
            // passWTextBox
            // 
            passWTextBox.Location = new Point(257, 202);
            passWTextBox.Name = "passWTextBox";
            passWTextBox.Size = new Size(200, 38);
            passWTextBox.TabIndex = 8;
            // 
            // sexComboBox
            // 
            sexComboBox.FormattingEnabled = true;
            sexComboBox.Location = new Point(257, 156);
            sexComboBox.Name = "sexComboBox";
            sexComboBox.Size = new Size(105, 39);
            sexComboBox.TabIndex = 7;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(257, 112);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(200, 38);
            nameTextBox.TabIndex = 6;
            // 
            // contactLabel
            // 
            contactLabel.AutoSize = true;
            contactLabel.Location = new Point(54, 250);
            contactLabel.Name = "contactLabel";
            contactLabel.Size = new Size(110, 31);
            contactLabel.TabIndex = 5;
            contactLabel.Text = "联系方式";
            // 
            // passWLabel
            // 
            passWLabel.AutoSize = true;
            passWLabel.Location = new Point(54, 205);
            passWLabel.Name = "passWLabel";
            passWLabel.Size = new Size(110, 31);
            passWLabel.TabIndex = 4;
            passWLabel.Text = "登录密码";
            // 
            // sexLabel
            // 
            sexLabel.AutoSize = true;
            sexLabel.Location = new Point(54, 160);
            sexLabel.Name = "sexLabel";
            sexLabel.Size = new Size(111, 31);
            sexLabel.TabIndex = 3;
            sexLabel.Text = "       性别";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(54, 115);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(110, 31);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "读者名称";
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(54, 70);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(110, 31);
            typeLabel.TabIndex = 1;
            typeLabel.Text = "读者类型";
            // 
            // rTypeComboBox
            // 
            rTypeComboBox.FormattingEnabled = true;
            rTypeComboBox.Location = new Point(257, 67);
            rTypeComboBox.Name = "rTypeComboBox";
            rTypeComboBox.Size = new Size(105, 39);
            rTypeComboBox.TabIndex = 0;
            // 
            // ReaderInfoM
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1333, 817);
            Controls.Add(editGroupBox);
            Controls.Add(readerInfoListView);
            Name = "ReaderInfoM";
            Load += ReaderInfoM_Load;
            editGroupBox.ResumeLayout(false);
            editGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView readerInfoListView;
        private GroupBox editGroupBox;
        private Label contactLabel;
        private Label passWLabel;
        private Label sexLabel;
        private Label nameLabel;
        private Label typeLabel;
        private ComboBox rTypeComboBox;
        private Label validToLabel;
        private Label rigiDateLabel;
        private Label idLabel;
        private TextBox contactTextBox;
        private TextBox passWTextBox;
        private ComboBox sexComboBox;
        private TextBox nameTextBox;
        private Label stateLabel;
        private Label remarkLabel;
        private ComboBox stateComboBox;
        private TextBox remarkTextBox;
        private TextBox ValidToTextBox;
        private TextBox rigiDateTextBox;
        private TextBox idTextBox;
        private Button cancelButton;
        private Button assureButton;
        private ComboBox editStateComboBox;
        private Button delButton;
    }
}