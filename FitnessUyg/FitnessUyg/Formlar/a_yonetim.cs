using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessUyg.Formlar
{
    public partial class a_yonetim : Form
    {
        public a_yonetim()
        {
            InitializeComponent();
        }

        private void a_yonetim_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void a_yonetim_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(10, 0, 0, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();  // Önce paneldeki önceki formları temizle

            a_adminlogin a_Adminlogin = new a_adminlogin()
            {
                TopLevel = false,
                TopMost = true
            };

            a_Adminlogin.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(a_Adminlogin);
            a_Adminlogin.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();  // Önce paneldeki önceki formları temizle

            a_userlogin auserfrm = new a_userlogin()
            {
                TopLevel = false,
                TopMost = true
            };
            auserfrm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(auserfrm);
            auserfrm.Show();
        }
    }
}
