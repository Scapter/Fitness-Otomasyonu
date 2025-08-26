using DevExpress.XtraEditors.TextEditController.Win32;
using FitnessUyg.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessUyg.Formlar
{

    public partial class a_programlar : Form
    {
        public a_programlar()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string tableName = textBox1.Text;

            using (var conn = new SqlConnection("Server = VICTUS\\EMİR; Database = Fitness; Integrated Security = True; Encrypt = False;"))
            {
                conn.Open();

                // 1) Tabloyu oluştur
                string createSql = $@"
            CREATE TABLE {tableName} (
            ID INT PRIMARY KEY IDENTITY(1,1),
            Gun NVARCHAR(50) NULL,
            Egzersiz NVARCHAR(50) NOT NULL,
            [Set] NVARCHAR(50) NOT NULL,
            Tekrar NVARCHAR(50) NOT NULL,
            [Not] NVARCHAR(200) NULL
        )";

                using (var cmd = new SqlCommand(createSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 2) DataGridView’den verileri tabloya ekle
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue; // son boş satırı atla
                    object gun = string.IsNullOrWhiteSpace(row.Cells["Gun"].Value?.ToString()) ? DBNull.Value : (object)row.Cells["Gun"].Value.ToString();
                    string egzersiz = row.Cells["Egzersiz"].Value?.ToString();
                    int set = Convert.ToInt32(row.Cells["Set"].Value);
                    int tekrar = Convert.ToInt32(row.Cells["Tekrar"].Value);
                    string not = row.Cells["Not"].Value?.ToString();

                    string insertSql = $@"
            INSERT INTO {tableName} (Gun, Egzersiz, [Set], Tekrar, [Not])
            VALUES (@gun, @egzersiz, @set, @tekrar, @not)";

                    using (var insertCmd = new SqlCommand(insertSql, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@gun", gun);
                        insertCmd.Parameters.AddWithValue("@egzersiz", egzersiz);
                        insertCmd.Parameters.AddWithValue("@set", set);
                        insertCmd.Parameters.AddWithValue("@tekrar", tekrar);
                        insertCmd.Parameters.AddWithValue("@not", not ?? (object)DBNull.Value);

                        insertCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"{tableName} programı oluşturuldu ve veriler eklendi!");
            }
        }



        private void a_programlar_Load(object sender, EventArgs e)
        {
          

            var conn = new SqlConnection("Server = VICTUS\\EMİR; Database = Fitness; Integrated Security = True; Encrypt = False;");
            conn.Open();

            string sql = @"
        SELECT TABLE_NAME 
        FROM INFORMATION_SCHEMA.TABLES
        WHERE TABLE_TYPE = 'BASE TABLE'
          AND TABLE_NAME NOT IN ('Admin', 'Aletler', 'İcecekFiyat', 'Kullanicilar', 'Uyeler', 'UyelikFiyat')
        ORDER BY TABLE_NAME";

            using (var cmd = new SqlCommand(sql, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    comboBox1.Items.Clear();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["TABLE_NAME"].ToString());
                   

                    }
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {


            string tableName = comboBox1.SelectedItem.ToString();
            DataTable dt = (DataTable)dataGridView1.DataSource;

            using (var conn = new SqlConnection("Server = VICTUS\\EMİR; Database = Fitness; Integrated Security = True; Encrypt = False;"))
            {
                conn.Open();
                using (var adapter = new SqlDataAdapter($"SELECT * FROM {tableName}", conn))
                {
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(dt);
                }
            }

            MessageBox.Show("Güncelleme kaydedildi!");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear(); // Önceki sütunları temizle

            string tableName = comboBox1.SelectedItem.ToString();
            using (var conn = new SqlConnection("Server = VICTUS\\EMİR; Database = Fitness; Integrated Security = True; Encrypt = False;"))
            {
                conn.Open();
                string sql = $"SELECT * FROM {tableName}";
                using (var adapter = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            



                }
            }
        
        private void RefreshComboBox()
        {
            comboBox1.Items.Clear();

            using (var conn = new SqlConnection("Server=.;Database=Fitness;Trusted_Connection=True;Encrypt=False;"))
            {
                conn.Open();
                string sql = @"
            SELECT TABLE_NAME 
            FROM INFORMATION_SCHEMA.TABLES
            WHERE TABLE_TYPE = 'BASE TABLE'
              AND TABLE_NAME NOT IN ('Admin', 'Aletler', 'İcecekFiyat', 'Kullanicilar', 'Uyeler', 'UyelikFiyat')
            ORDER BY TABLE_NAME";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["TABLE_NAME"].ToString());
                        }
                    }
                }
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir tablo seçiniz.");
                return;
            }

            string tableName = comboBox1.SelectedItem.ToString();

            // Onay alalım
            var result = MessageBox.Show($"{tableName} tablosunu silmek istediğine emin misin?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var conn = new SqlConnection("Server = VICTUS\\EMİR; Database = Fitness; Integrated Security = True; Encrypt = False;"))
                {
                    conn.Open();
                    string sql = $"DROP TABLE [{tableName}]";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"{tableName} tablosu silindi!");


                RefreshComboBox();
                // Combobox’ı güncelle



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndex = -1; // Seçili öğeyi temizle
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            //event hatası aldık sadece -1 yazmak yetmez eventi devre dışı bırakıp sonra tekrar etkinleştirdik

            if (dataGridView1.DataSource is DataTable dt)
            {
                dt.Rows.Clear(); // Mevcut satırları temizle
            }
            else
            {
                // Eğer DataSource farklıysa yeni DataTable oluştur
                DataTable newDt = new DataTable();
                newDt.Columns.Add("Gun", typeof(string));
                newDt.Columns.Add("Egzersiz", typeof(string));
                newDt.Columns.Add("Set", typeof(int));
                newDt.Columns.Add("Tekrar", typeof(int));
                newDt.Columns.Add("Not", typeof(string));
                dataGridView1.DataSource = newDt;
            }
        }
    }
}

