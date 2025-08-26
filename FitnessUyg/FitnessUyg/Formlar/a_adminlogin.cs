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
    public partial class a_adminlogin : Form
    {
        public a_adminlogin()
        {
            InitializeComponent();
        }
        FitnessEntities2 db = new FitnessEntities2();

        private void a_adminlogin_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Admin.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            /*
            int x = int.Parse(txtID.Text);
            var deger = db.Admin.Find(x);
            db.Admin.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Admin başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */

            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

                var admin = db.Admin.Find(id);
                if (admin != null)
                {
                    db.Admin.Remove(admin);
                    db.SaveChanges();
                    MessageBox.Show("Admin başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Grid'i yenile
                    dataGridView1.DataSource = db.Admin.ToList();
                }
                else
                {
                    MessageBox.Show("Admin bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek admini seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
      
        
            txtID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                var admin = db.Admin.FirstOrDefault(x => x.ID == id);
                if (admin != null)
                {
                    admin.KullaniciAdi = dataGridView1.CurrentRow.Cells["KullaniciAdi"].Value.ToString();
                    admin.Sifre = dataGridView1.CurrentRow.Cells["Sifre"].Value.ToString();

                    admin.KullaniciAdi = txtID.Text;
                    admin.Sifre = textBox1.Text;


                    db.SaveChanges(); // Veritabanına kaydet
                    MessageBox.Show("Admin başarıyla güncellendi!");
                    // DataGridView’i güncelle
                    dataGridView1.DataSource = db.Admin.ToList();
                }
                else
                {
                    MessageBox.Show("Admin bulunamadı.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ekle = new Admin()
            {
                KullaniciAdi = txtID.Text,
                Sifre = textBox1.Text
            };
            db.Admin.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Admin başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
