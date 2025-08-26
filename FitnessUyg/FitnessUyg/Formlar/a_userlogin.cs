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
    public partial class a_userlogin : Form
    {
        public a_userlogin()
        {
            InitializeComponent();
        }
        FitnessEntities2 db = new FitnessEntities2();   
        private void a_userlogin_Load(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Kullanicilar.ToList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                var kullanici = db.Kullanicilar.FirstOrDefault(x => x.ID == id); 
                if (kullanici != null)
                {
                    kullanici.KullaniciAdi = dataGridView1.CurrentRow.Cells["KullaniciAdi"].Value.ToString();
                    kullanici.Sifre = dataGridView1.CurrentRow.Cells["Sifre"].Value.ToString();
                    kullanici.Ad = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
                    kullanici.Soyad = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
                    kullanici.Cinsiyet = dataGridView1.CurrentRow.Cells["Cinsiyet"].Value.ToString();
                    kullanici.DogumTarihi = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DogumTarihi"].Value);
                    kullanici.Mail = dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
                    kullanici.Kilo = dataGridView1.CurrentRow.Cells["Kilo"].Value.ToString();
                    kullanici.Program = dataGridView1.CurrentRow.Cells["Program"].Value.ToString();

                    db.SaveChanges(); // Veritabanına kaydet
                    MessageBox.Show("Kullanıcı başarıyla güncellendi!");

                    // DataGridView’i güncelle
                    dataGridView1.DataSource = db.Kullanicilar.ToList();


                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı.");
                }




            }
          
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

                var kullanici = db.Kullanicilar.Find(id);
                if (kullanici != null)
                {
                    db.Kullanicilar.Remove(kullanici);
                    db.SaveChanges();
                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Grid'i yenile
                    dataGridView1.DataSource = db.Kullanicilar.ToList();
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek kullanıcıyı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            /*
            int x = int.Parse(txtID.Text);
            var deger = db.Kullanicilar.Find(x);
            db.Kullanicilar.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Üye başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
