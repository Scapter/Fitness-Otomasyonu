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
    public partial class a_yeniuye : Form
    {
        public a_yeniuye()
        {
            InitializeComponent();
        }
        FitnessEntities2 db = new FitnessEntities2();
        private void newuser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
        ;


            if (comboBoxUyelik.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen üyelik türünü seçiniz.");
                return;  // Seçim yapılmadan devam etme
            }

            DateTime bugün = DateTime.Now;
            string uyelikTuru = comboBoxUyelik.SelectedItem.ToString();
            DateTime uyelikBitis = bugün;

            if (uyelikTuru == "1 Aylık")
            {
                uyelikBitis = bugün.AddMonths(1);
            }
            else if (uyelikTuru == "3 Aylık")
            {
                uyelikBitis = bugün.AddMonths(3);
            }
            else if (uyelikTuru == "6 Aylık")
            {
                uyelikBitis = bugün.AddMonths(6);
            }
            else if (uyelikTuru == "Yıllık")
            {
                uyelikBitis = bugün.AddYears(1);
            }






            bool bosAlanVar = this.Controls.OfType<TextBox>().Any(tb => string.IsNullOrWhiteSpace(tb.Text));

            if (bosAlanVar)
            {
                MessageBox.Show("Tüm metin kutularını doldurmalısınız.");
                return;
            }


                var yeniuye = new Uyeler
                {
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    Cinsiyet = cinsiyet,
                    DoğumTarihi = dtpDogumTarihi.Value,
                    Mail = txtMail.Text,
                    Kilo = txtKilo.Text,
                    TelNo = txtTelno.Text,
                    ÜyelikTürü = uyelikTuru,
                    ÜyelikBitiş = uyelikBitis,
                    Durum = true // Varsayılan olarak aktif
                };
            db.Uyeler.Add(yeniuye);
            db.SaveChanges();

            MessageBox.Show("Kayıt başarıyla eklendi.");


        }
    }
}
