using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_6._4
{
    public partial class Portal : Form
    {
        public Portal()
        {
            InitializeComponent();
        }

        private void Portal_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "User" && txtPassword.Text == "password")
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                txtUserID.Clear();
                txtPassword.Clear();
                MessageBox.Show("Incorrect User ID / Password! Please try again.");
            }
        }

        private void btnExitMain_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
