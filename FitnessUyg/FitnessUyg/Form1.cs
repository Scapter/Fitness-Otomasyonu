using DevExpress.XtraEditors;
using FitnessUyg.Formlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessUyg
{

   
    public partial class Form1 : Form
    {
        private Form childform = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
       
        private void button3_Click(object sender, EventArgs e)
        {

        }
     


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

 
        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(60, 0, 0, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            a_giris adminfrm = new a_giris();
            adminfrm.Show();
            this.Hide();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(60, 0, 0, 0);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            k_giris usergirisfrm = new k_giris();
            usergirisfrm.Show();
            this.Hide();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
  

}
