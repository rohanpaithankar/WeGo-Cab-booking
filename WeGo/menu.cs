using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeGo
{
    public partial class menu : Form
    {
        
        public menu()
        {
            InitializeComponent();
        }
        private void LoginUser_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
            LoginUser c = new LoginUser();
            this.Visible = false;
            c.Show();
            
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            viewCab v = new viewCab();
            v.Show();
            this.Hide();
        }
    }
}
