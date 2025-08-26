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
    public partial class k_yenikullanici : Form
    {
        public k_yenikullanici()
        {
            InitializeComponent();
        }

        private void newuserpage_Load(object sender, EventArgs e)
        {
            panel2.Controls.Clear();  // Önce paneldeki önceki formları temizle

            k_kayit newuserfrm = new k_kayit()
            {
                TopLevel = false,
                TopMost = true
            };
            newuserfrm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(newuserfrm);
            newuserfrm.Show();
        }

        private void newuserpage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
