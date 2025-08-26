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
    public partial class a_salon : Form
    {
        public a_salon()
        {
            InitializeComponent();
        }

        private void a_salon_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void a_salon_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(10, 0, 0, 0);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();  // Önce paneldeki önceki formları temizle

            a_programlar a_Programlar = new a_programlar()
            {
                TopLevel = false,
                TopMost = true
            };
        

            panel1.Controls.Add(a_Programlar);
            a_Programlar.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();  // Önce paneldeki önceki formları temizle

            a_aletler aletlerfrm = new a_aletler()
            {
                TopLevel = false,
                TopMost = true
            };

            panel1.Controls.Add(aletlerfrm);
            aletlerfrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();  // Önce paneldeki önceki formları temizle

            a_fiyatlar a_fiyatlarfrm = new a_fiyatlar()
            {
                TopLevel = false,
                TopMost = true
            };
          

            panel1.Controls.Add(a_fiyatlarfrm);
            a_fiyatlarfrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();  // Önce paneldeki önceki formları temizle

            a_kullaniciislem kullaniciislemfrm = new a_kullaniciislem()
            {
                TopLevel = false,
                TopMost = true
            };
            kullaniciislemfrm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(kullaniciislemfrm);
            kullaniciislemfrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();  // Önce paneldeki önceki formları temizle

            a_yeniuye newuserfrm = new a_yeniuye()
            {
                TopLevel = false,
                TopMost = true
            };
            newuserfrm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(newuserfrm);
            newuserfrm.Show();
        }
    }
}
