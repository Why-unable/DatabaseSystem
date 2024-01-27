using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ManagerContent : Form
    {
        private string Mid;
        private string Mname;
        public ManagerContent()
        {
            InitializeComponent();
        }

        public void setInfo(string id,string uname)
        {
            Mid = id;
            Mname = uname;
        }

        private void ReaderMButton_Click(object sender, EventArgs e)
        {
            ReaderInfoM readerInfoM = new ReaderInfoM();
            readerInfoM.setInfo(Mid);
            readerInfoM.Show();
        }

        private void ReturnMButton_Click(object sender, EventArgs e)
        {
            MReturn mReturn = new MReturn();
            mReturn.setInfo(Mid,Mname);
            mReturn.Show();
        }
    }
}
