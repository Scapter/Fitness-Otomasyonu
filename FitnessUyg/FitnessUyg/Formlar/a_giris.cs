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
    public partial class a_giris : Form
    {
        public a_giris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=VICTUS\\EMİR;Database=Fitness;Trusted_Connection=True;");


        private void button1_Click(object sender, EventArgs e)
        {

        }
        //  FitnessEntities2 db = new FitnessEntities2();
        private void button1_Click_1(object sender, EventArgs e)
        {
            string kullanici = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            SqlCommand komut = new SqlCommand("SELECT * FROM admin WHERE KullaniciAdi=@kullanici AND Sifre=@sifre", baglanti);
            komut.Parameters.AddWithValue("@kullanici", kullanici);
            komut.Parameters.AddWithValue("@sifre", sifre);

            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {


                admin_sayfasi admin1 = new admin_sayfasi();
                admin1.Show(); // Modal olarak aç
                this.Hide(); // Yeni formu aç

            }
            else
            {
                MessageBox.Show("Hatalı giriş.");
            }

            baglanti.Close();
        }

        private void admin_Load(object sender, EventArgs e)
        {


        }

        private void admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*    string kullanici = txtKullaniciAdi.Text;
                string sifre = txtSifre.Text;

                SqlCommand komut = new SqlCommand("SELECT * FROM admin WHERE KullaniciAdi=@kullanici AND Sifre=@sifre", baglanti);
                komut.Parameters.AddWithValue("@kullanici", kullanici);
                komut.Parameters.AddWithValue("@sifre", sifre);

                baglanti.Open();
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {


                    admin_page admin1 = new admin_page();
                    admin1.Show(); // Modal olarak aç
                    this.Hide(); // Yeni formu aç

                }
                else
                {
                    MessageBox.Show("Hatalı giriş.");
                }

                baglanti.Close();*/



            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            using (var db = new FitnessEntities2())
            {
                var admin = db.Admin.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);



                if (admin != null)
                {
               
                    // Ana formu aç

                    admin_sayfasi anaForm = new admin_sayfasi();
                    anaForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

