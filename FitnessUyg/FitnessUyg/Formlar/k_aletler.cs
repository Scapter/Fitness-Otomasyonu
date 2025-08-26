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
using System.IO;

namespace FitnessUyg.Formlar
{
    public partial class k_aletler : Form
    {
        public k_aletler()
        {
            InitializeComponent();
        }

        private void user_aletler_Load(object sender, EventArgs e)
        {
      

            ListeleAletler();

            /*
                        label1.MaximumSize = new Size(panel1.Width, 0);
                        label1.AutoSize = true;
                        label2.MaximumSize = new Size(panel1.Width, 0);
                        label2.AutoSize = true;
                        label3.MaximumSize = new Size(panel1.Width, 0);
                        label3.AutoSize = true;
            */

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        FitnessEntities2 db = new FitnessEntities2();
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }


        private void ListeleAletler()
        {
            flowLayoutPanel1.Controls.Clear();

            Task.Run(() =>
            {
                var aletler = db.Aletler.ToList();

                foreach (var alet in aletler)
                {
                    Image img = null;

                    if (!string.IsNullOrEmpty(alet.Dizin) && File.Exists(alet.Dizin))
                    {
                        using (var fs = new FileStream(alet.Dizin, FileMode.Open, FileAccess.Read))
                        {
                            img = Image.FromStream(fs);
                        }
                    }

                    flowLayoutPanel1.Invoke((Action)(() =>
                    {
                        // Panel
                        Panel pnl = new Panel();
                        pnl.Size = new Size(400, 420);
                        pnl.BorderStyle = BorderStyle.FixedSingle;
                        pnl.BackColor = Color.LightGray;

                        // PictureBox (resim panelin üst kısmına)
                        PictureBox pb = new PictureBox();
                        pb.Size = new Size(pnl.Width - 20, 220);
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Image = img;
                        pb.Top = 10;
                        pb.Left = 10;

                        // Ad Label
                        Label lblAd = new Label();
                        lblAd.Text = alet.AletAdi;
                        lblAd.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                        lblAd.AutoSize = false;
                        lblAd.Width = pnl.Width - 20;
                        lblAd.Height = 30;
                        lblAd.TextAlign = ContentAlignment.MiddleCenter;
                        lblAd.Top = pb.Bottom + 10;
                        lblAd.Left = 10;

                        // Açıklama Label
                        Label lblAciklama = new Label();
                        lblAciklama.Text = alet.Aciklama;
                        lblAciklama.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                        lblAciklama.AutoSize = false;
                        lblAciklama.Width = pnl.Width - 20;
                        lblAciklama.Height = 120;
                        lblAciklama.TextAlign = ContentAlignment.TopCenter;
                        lblAciklama.Top = lblAd.Bottom + 10;
                        lblAciklama.Left = 10;

                        // Panele ekle
                        pnl.Controls.Add(pb);
                        pnl.Controls.Add(lblAd);
                        pnl.Controls.Add(lblAciklama);

                        // FlowLayoutPanel’e ekle
                        flowLayoutPanel1.Controls.Add(pnl);
                    }));
                }
            });
        }
   
    

    }
}

