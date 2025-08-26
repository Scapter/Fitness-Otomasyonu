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
    public partial class k_fiyatlar : Form
    {
        FitnessEntities2 db = new FitnessEntities2();
        public k_fiyatlar()
        {
            InitializeComponent();
        }

        private void user_fiyat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void user_fiyat_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.UyelikFiyat.ToList();
            dataGridView1.Columns["Id"].Visible = false; // Id sütununu gizle
            dataGridView2.DataSource = db.İcecekFiyat.ToList();
            dataGridView2.Columns["Id"].Visible = false; // Id sütununu gizle

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                var ufiyat = db.UyelikFiyat.FirstOrDefault(x => x.ID == id);
                if (ufiyat != null)
                {
                    ufiyat.Üyelik = dataGridView1.CurrentRow.Cells["Üyelik"].Value.ToString();
                    ufiyat.Fiyat = dataGridView1.CurrentRow.Cells["Fiyat"].Value.ToString();
                }
                db.SaveChanges();
                MessageBox.Show("Başarıyla Güncellendi");
            }
        }
    }
}
