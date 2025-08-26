using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitnessUyg.DB;

namespace FitnessUyg.Formlar
{
    public partial class k_giris : Form
    {
        public k_giris()
        {
            InitializeComponent();
        }
      //  FitnessEntities2 db = new FitnessEntities2();
        private void button3_Click(object sender, EventArgs e)
        {
        



            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            using (var db = new FitnessEntities2())
            {
                var kullanici = db.Kullanicilar.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);



                if (kullanici != null)
                {
                    // Ana formu aç

                    kullanici_sayfasi anaForm = new kullanici_sayfasi(kullanici.KullaniciAdi, kullanici.Sifre);
                    anaForm.Show();
                    this.Hide();




                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



  


            }
        }

        private void usergiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            k_yenikullanici userkayitfrm = new k_yenikullanici();
            userkayitfrm.Show();
            this.Hide();
        }
    }
}
