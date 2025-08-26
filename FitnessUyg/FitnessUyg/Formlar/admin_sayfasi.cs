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
    public partial class admin_sayfasi : Form
    {
        public admin_sayfasi()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();  // Önce paneldeki önceki formları temizle

            a_yonetim ayonetimfrm = new a_yonetim()
            {
                TopLevel = false,
                TopMost = true
            };
            ayonetimfrm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(ayonetimfrm);
            ayonetimfrm.Show();
        }

        private void admin_page_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void admin_page_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();  // Önce paneldeki önceki formları temizle

            a_yeniuye newuserfrm = new a_yeniuye()
            {
                TopLevel = false,
                TopMost = true
            };
            newuserfrm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(newuserfrm);
            newuserfrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();

        }

        private void admin_page_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(60, 0, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();  // Önce paneldeki önceki formları temizle
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();  // Önce paneldeki önceki formları temizle

            a_salon salonfrm = new a_salon()
            {
                TopLevel = false,
                TopMost = true
            };

            salonfrm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(salonfrm);
            salonfrm.Show();
        }
    }
}
