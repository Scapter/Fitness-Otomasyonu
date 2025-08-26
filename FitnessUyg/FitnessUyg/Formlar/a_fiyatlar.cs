using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitnessUyg.DB;

namespace FitnessUyg.Formlar
{

    public partial class a_fiyatlar : Form
    {
        public a_fiyatlar()
        {
            InitializeComponent();
        }
        FitnessEntities2 db = new FitnessEntities2();
        private void btnListele_Click(object sender, EventArgs e)
        {

        }
        public string secilen;

        private void a_fiyatlar_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboBox1.SelectedItem == null) return;

            secilen = comboBox1.SelectedItem.ToString();

            if (secilen == "ÜyelikFiyat")
            {
                dataGridView1.DataSource = db.UyelikFiyat.ToList();
                label1.Text = "Üyelik Tipi : ";
            }
            else if (secilen == "İcecekFiyat")
            {
                dataGridView1.DataSource = db.İcecekFiyat.ToList();
                label1.Text = "Ürün : ";
            }
            else
            {
                // Geçerli tablo değilse DataGridView temizle veya mesaj göster
                dataGridView1.DataSource = null;
                MessageBox.Show("Lütfen geçerli bir tablo seçin.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            secilen = comboBox1.SelectedItem?.ToString();

            if (secilen == "UyelikFiyat")
            {
                var yeniFiyat = new UyelikFiyat
                {
                    Üyelik = txtUyelik.Text,
                    Fiyat = txtFiyat.Text
                };
                db.UyelikFiyat.Add(yeniFiyat);
                dataGridView1.DataSource = db.UyelikFiyat.ToList();
            }
            else if (secilen == "İcecekFiyat")
            {
                var yeniFiyat = new İcecekFiyat
                {
                    Ürün = txtUyelik.Text,
                    Fiyat = txtFiyat.Text
                };
                db.İcecekFiyat.Add(yeniFiyat);
        
                dataGridView1.DataSource = db.İcecekFiyat.ToList();

            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir tablo seçin.");
                return;
            }
            db.SaveChanges(); // Yeni fiyatı veritabanına kaydet
        }




        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilen == "ÜyelikFiyat" && dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                var fiyatt = db.UyelikFiyat.FirstOrDefault(x => x.ID == id);
                if (fiyatt != null)
                {
                    fiyatt.Üyelik = dataGridView1.CurrentRow.Cells["Üyelik"].Value.ToString();
                    fiyatt.Fiyat = dataGridView1.CurrentRow.Cells["Fiyat"].Value.ToString();



                    fiyatt.Üyelik = txtUyelik.Text;
                    fiyatt.Fiyat = txtFiyat.Text;
                    db.SaveChanges(); // Güncellemeyi veritabanına yansıt
                    MessageBox.Show("Veriler başarıyla güncellendi.");
                }
                dataGridView1.DataSource = db.UyelikFiyat.ToList();


            }
            else if (secilen == "İcecekFiyat" && dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                var fiyattt = db.İcecekFiyat.FirstOrDefault(x => x.ID == id);
                if (fiyattt != null)
                {

                    fiyattt.Ürün = dataGridView1.CurrentRow.Cells["Ürün"].Value.ToString();
                    fiyattt.Fiyat = dataGridView1.CurrentRow.Cells["Fiyat"].Value.ToString();


                    fiyattt.Ürün = txtUyelik.Text;
                    fiyattt.Fiyat = txtFiyat.Text;
                    db.SaveChanges(); // Güncellemeyi veritabanına yansıt
                    MessageBox.Show("Veriler başarıyla güncellendi.");
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir tablo seçin."); 
                }

                    dataGridView1.DataSource = db.UyelikFiyat.ToList();
            }
        }

                
            






        

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            if (secilen == "ÜyelikFiyat")
            {
                var item = db.UyelikFiyat.FirstOrDefault(x => x.ID == id);
                if (item != null)
                {
                    db.UyelikFiyat.Remove(item);
                }
            }
            else if (secilen == "İcecekFiyat")
            {
                var item = db.İcecekFiyat.FirstOrDefault(x => x.ID == id);
                if (item != null)
                {
                    db.İcecekFiyat.Remove(item);
                }
            }

            db.SaveChanges();

            // DataGridView’i tekrar listele
            if (secilen == "ÜyelikFiyat")
                dataGridView1.DataSource = db.UyelikFiyat.ToList();
            else
                dataGridView1.DataSource = db.İcecekFiyat.ToList();

            MessageBox.Show("Veri silindi!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            txtUyelik.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtFiyat.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }
    }
}
