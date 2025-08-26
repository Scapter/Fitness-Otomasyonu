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
    public partial class a_kullaniciislem : Form
    {
        public a_kullaniciislem()
        {
            InitializeComponent();
        }

        private void kullaniciislem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        FitnessEntities2 DB = new FitnessEntities2();

        void listele()
        {
            var deger = (from x in DB.Uyeler
                         select new
                         {
                             x.ID,
                             x.Ad,
                             x.Soyad,
                             x.Cinsiyet,
                             x.DoğumTarihi,
                             x.Mail,
                             x.Kilo,
                             x.TelNo,
                             x.ÜyelikBitiş,
                             x.Durum
                         }).ToList();
            dataGridView1.DataSource = deger;




        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  listele();
            dataGridView1.DataSource = DB.Uyeler.ToList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                var uye = DB.Uyeler.FirstOrDefault(x => x.ID == id);

                if (uye != null)
                {
                    // DataGridView üzerindeki yeni değerleri al
                    uye.Ad = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
                    uye.Soyad = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
                    uye.Cinsiyet = dataGridView1.CurrentRow.Cells["Cinsiyet"].Value.ToString();
                    uye.DoğumTarihi = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DoğumTarihi"].Value);
                    uye.Mail = dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
                    uye.Kilo = dataGridView1.CurrentRow.Cells["Kilo"].Value.ToString();
                    uye.TelNo = dataGridView1.CurrentRow.Cells["TelNo"].Value.ToString();
                    uye.ÜyelikBitiş = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["ÜyelikBitiş"].Value);
                    uye.Durum = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Durum"].Value);

                    DB.SaveChanges(); // Güncellemeyi veritabanına yansıt
                    MessageBox.Show("Üye başarıyla güncellendi.");
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger = DB.Uyeler.Find(x);
            DB.Uyeler.Remove(deger);
            DB.SaveChanges();
            MessageBox.Show("Üye başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
     

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DB.SaveChanges(); // Değişiklikleri kaydet
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            a_yeniuye yeniperson = new a_yeniuye();
            yeniperson.Show();
            this.Hide();
        }

        private void kullaniciislem_Load(object sender, EventArgs e)
        {
    
        }
    }
}


