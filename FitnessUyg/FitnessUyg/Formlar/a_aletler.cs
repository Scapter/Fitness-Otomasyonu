using FitnessUyg.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace FitnessUyg.Formlar
{

    public partial class a_aletler : Form
    {
        string selectedImagePath = "";
        public a_aletler()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Resim Seç";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                pictureBox1.Image = Image.FromFile(selectedImagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            txtDizin.Text = selectedImagePath;

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            /*
            // 1️⃣ Alanların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Tüm alanları doldurun ve resim seçin!");
                return;
            }

            using (var db = new FitnessEntities2())
            {
                // Resimlerin kaydedileceği klasör
                string imagesFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "FitnessApp", "Images"
                );
                Directory.CreateDirectory(imagesFolder); // klasör yoksa oluştur

                // Benzersiz dosya adı üret
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);

                // Hedef yol
                string newPath = Path.Combine(imagesFolder, fileName);

                // Resmi kopyala
                File.Copy(selectedImagePath, newPath, true);

                // DB’ye sadece dosya adı kaydet
                Aletler eq = new Aletler()
                {
                    AletAdi = txtName.Text,
                    Aciklama = txtDescription.Text,
                    Dizin = newPath // Dosya yolunu kaydet
                };

                db.Aletler.Add(eq);
                db.SaveChanges();
            }

            MessageBox.Show("Alet başarıyla kaydedildi!");
            txtName.Clear();
            txtDescription.Clear();
            pictureBox1.Image = null;
            selectedImagePath = "";
            txtDizin.Text = "";


            */





            // 1️⃣ Alanların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Tüm alanları doldurun ve resim seçin!");
                return;
            }

            using (var db = new FitnessEntities2())
            {
                // Resimlerin kaydedileceği klasör
                string imagesFolder = Path.Combine(Application.StartupPath, "Images");
            

              /*  string imagesFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "FitnessApp", "Images"*/
                
                Directory.CreateDirectory(imagesFolder); // klasör yoksa oluştur

                // Dosya hash'ini hesapla
                string newPath = "";
                using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(selectedImagePath))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    string hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();

                    // Aynı hash’e sahip bir dosya var mı kontrol et
                    var existingFile = Directory.GetFiles(imagesFolder)
                        .FirstOrDefault(f =>
                        {
                            using (var fs = File.OpenRead(f))
                            {
                                byte[] existingHash = md5.ComputeHash(fs);
                                string existingHashString = BitConverter.ToString(existingHash).Replace("-", "").ToLower();
                                return existingHashString == hashString;
                            }
                        });

                    if (existingFile != null)
                    {
                        // Zaten var, aynı yolu kullan
                        newPath = existingFile;
                    }
                    else
                    {
                        // Yoksa kopyala
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
                        newPath = Path.Combine(imagesFolder, fileName);
                        File.Copy(selectedImagePath, newPath, true);
                    }
                }

                // Veritabanına kaydet
                Aletler eq = new Aletler()
                {
                    AletAdi = txtName.Text,
                    Aciklama = txtDescription.Text,
                    Dizin = newPath // Dosya yolunu kaydet
                };

                db.Aletler.Add(eq);
                db.SaveChanges();
            }

            // Kullanıcıya mesaj ve alanları temizleme
            MessageBox.Show("Alet başarıyla kaydedildi!");
            txtName.Clear();
            txtDescription.Clear();
            pictureBox1.Image = null;
            selectedImagePath = "";
            txtDizin.Text = "";
        }


        FitnessEntities2 db = new FitnessEntities2();
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Aletler.ToList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                var alet = db.Aletler.FirstOrDefault(x => x.ID == id);

                if (alet != null)
                {

                    alet.AletAdi = dataGridView1.CurrentRow.Cells["AletAdi"].Value?.ToString();
                    alet.Aciklama = dataGridView1.CurrentRow.Cells["Aciklama"].Value?.ToString();
                    alet.Dizin = dataGridView1.CurrentRow.Cells["Dizin"].Value?.ToString();


                    alet.AletAdi = txtName.Text.Trim(); 
                    alet.Aciklama = txtDescription.Text.Trim();
                    alet.Dizin = txtDizin.Text.Trim();

                    db.SaveChanges();
                    MessageBox.Show("Başarıyla Güncellendi!");
                }

                // DataGridView’i güncelle
                dataGridView1.DataSource = db.Aletler.ToList();





            }
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            using (var db = new FitnessEntities2())
            {
                var alet = db.Aletler.FirstOrDefault(x => x.ID == id);
                if (alet != null)
                {
                    // PictureBox'taki resmi serbest bırak
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }

                    // Resim dosyasını sil
                    string imagesFolder = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "FitnessApp",
                        "Images"
                    );
                    string fullPath = Path.Combine(imagesFolder, alet.Dizin);

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            File.Delete(fullPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Resim silinemedi: " + ex.Message);
                        }
                    }

                    // Veritabanından sil
                    db.Aletler.Remove(alet);
                    db.SaveChanges();

                    MessageBox.Show("Alet başarıyla silindi!");

                    // DataGridView güncelle
                    dataGridView1.DataSource = db.Aletler.ToList();




                }
            }


            /*
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            using (var db = new FitnessEntities2())
            {
                var alet = db.Aletler.FirstOrDefault(x => x.ID == id);
                if (alet != null)
                {
                    // Eğer PictureBox'ta o resim yüklüyse, serbest bırak
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    // Dosya varsa sil
                    if (!string.IsNullOrEmpty(alet.Dizin) && System.IO.File.Exists(alet.Dizin))
                    {
                        try
                        {
                            System.IO.File.Delete(alet.Dizin);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Resim silinemedi: " + ex.Message);
                        }
                    }

                    // Veritabanından sil
                    db.Aletler.Remove(alet);
                    db.SaveChanges();

                    MessageBox.Show("Alet başarıyla silindi!");

                    // DataGridView güncelle
                    dataGridView1.DataSource = db.Aletler.ToList();
                }*/
        }
    


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            txtName.Text = dataGridView1.CurrentRow.Cells["AletAdi"].Value?.ToString();
            txtDescription.Text = dataGridView1.CurrentRow.Cells["Aciklama"].Value?.ToString();
            txtDizin.Text = dataGridView1.CurrentRow.Cells["Dizin"].Value?.ToString();

            string path = txtDizin.Text;
            if (!string.IsNullOrEmpty(path) && System.IO.File.Exists(path))
            {
                // MemoryStream ile yükle ki dosya kilitlenmesin
                using (var fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    pictureBox1.Image = Image.FromStream(fs);
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.Image = null;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            txtDizin.Text = "";
            pictureBox1.Image = null;
        }

        private void a_aletler_Load(object sender, EventArgs e)
        {

        }
    }
}

