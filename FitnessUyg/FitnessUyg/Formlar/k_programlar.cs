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
    public partial class k_programlar : Form
    {
      
        private string kullaniciAdi2;
        public k_programlar(string kullaniciAdi2)
        {
            InitializeComponent();
            this.kullaniciAdi2 = kullaniciAdi2;
        }


        FitnessEntities2 db = new FitnessEntities2();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void user_program_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Kardiyo Programı");
            comboBox1.Items.Add("Ağırlık Programı");
            comboBox1.Items.Add("Genel Sağlık Programı");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {




            string secilenTablo = comboBox1.SelectedItem.ToString();

            using (var db = new FitnessEntities2())
            {
                if (secilenTablo == "Kardiyo Programı")
                {
                    var data = db.EgzersizProgram1.ToList();
                    dataGridView2.DataSource = data;
                }
                else if (secilenTablo == "Ağırlık Programı")
                {


                    var data = db.EgzersizProgram2.ToList();
                    dataGridView2.DataSource = data;
                }
                else if (secilenTablo == "Genel Sağlık Programı")
                {


                    var data = db.EgzersizProgram3.ToList();
                    dataGridView2.DataSource = data;
                }




            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string secilenProgram = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(secilenProgram))
            {
                MessageBox.Show("Lütfen bir program seçin.");
                return;
            }

            using (var db = new FitnessEntities2())
            {
                // Kullanıcıyı kullanıcı adı ile buluyoruz
                var kullanici = db.Kullanicilar.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi2);

                if (kullanici == null)
                {
                    MessageBox.Show("Kullanıcı bulunamadı.");
                    return;
                }

                // Programa alanını güncelle
                kullanici.Program = secilenProgram;

                // Değişiklikleri kaydet
                db.SaveChanges();

                MessageBox.Show("Program başarıyla kaydedildi.");
            }
        }

        private void user_program_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
