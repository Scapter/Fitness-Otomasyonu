using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitnessUyg.DB;

namespace FitnessUyg.Formlar
{
    public partial class k_kayit : Form
    {
        public k_kayit()
        {
            InitializeComponent();
        }
        FitnessEntities2 db = new FitnessEntities2();
        private void userkayit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cinsiyet;

            if (rbErkek.Checked)
                cinsiyet = "Erkek";
            else if (rbKadin.Checked)
                cinsiyet = "Kadın";
            else
            {
                MessageBox.Show("Lütfen cinsiyet seçiniz.");
                return;
            }


            var yenikullanici = new Kullanicilar
            {
                KullaniciAdi = txtKullaniciAd.Text,
                Sifre = txtSifre.Text,
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                Cinsiyet = cinsiyet,
                DogumTarihi = dtpDogumTarihi.Value,
                Mail = txtMail.Text,
                Kilo = txtKilo.Text,
            };
            db.Kullanicilar.Add(yenikullanici);
            db.SaveChanges();

            MessageBox.Show("Kayıt başarıyla eklendi.");

        }

        private void userkayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
