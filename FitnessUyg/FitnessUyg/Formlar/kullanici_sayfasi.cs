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
    

    public partial class kullanici_sayfasi : Form
    {
        private string kullaniciAdi2;
        private string sifre;
        public kullanici_sayfasi(string kullaniciAdi2, string sifre)
        {
            InitializeComponent();
            this.kullaniciAdi2 = kullaniciAdi2;
            this.sifre = sifre;


        }




        FitnessEntities2 db = new FitnessEntities2();
        private void userpage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void userpage_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(60, 0, 0, 0);
            
            label1.BackColor = Color.FromArgb(190, 0, 0, 0);
            label2.BackColor = Color.FromArgb(190, 0, 0, 0);


            using (var db = new FitnessEntities2())
            {
               var user = db.Kullanicilar.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi2 && k.Sifre == sifre);

                if (user != null)
                {
                    if (user.Program == null)
                    {
                        MessageBox.Show("Lütfen Egzersiz Programı Seçiniz!");
                     
                    }
                    /*             else
                                 {
                                     MessageBox.Show($"Hoşgeldin {user.KullaniciAdi}, Egzersiz Programın: {user.Program}");
                                 }*/

                    label1.Text = "Merhaba " + kullaniciAdi2;
                    label2.Text = "Egzersiz Programınız : " + user.Program;
                }
              

            }




            }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           


            panel3.Controls.Clear();  // Önce paneldeki önceki formları temizle


            k_programlar userProgramForm = new k_programlar(kullaniciAdi2)
            {
                TopLevel = false,
                TopMost = true
            };
         
            panel3.Controls.Add(userProgramForm);
            userProgramForm.Show();
            label1.Visible = false; // Kullanıcı adını gizle
            label2.Visible = false; // Program bilgisini gizle


            panel4.Visible = false; // Panel4'ü gizle
        }

        private void button4_Click(object sender, EventArgs e)
        {

            panel3.Controls.Clear();  // Önce paneldeki önceki formları temizle
       
            label1.Visible = true; // Kullanıcı adını göster
            label2.Visible = true; // Program bilgisini göster

            panel4.Visible = true; // Panel4'ü göster
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();  // Önce paneldeki önceki formları temizle

            k_aletler userAletlerForm = new k_aletler()
            {
                TopLevel = false,
                TopMost = true
            };
            panel3.Controls.Add(userAletlerForm);
            userAletlerForm.Show();
            label1.Visible = false; // Kullanıcı adını gizle
            label2.Visible = false; // Program bilgisini gizle

            panel4.Visible = false; // Panel4'ü gizle


            /*   user_aletler userAletlerForm = new user_aletler();    
               userAletlerForm.Show();
               this.Hide();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 anaForm = new Form1();
            anaForm.Show();
            this.Hide(); // Mevcut formu gizle
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();  // Önce paneldeki önceki formları temizle

            k_fiyatlar userFiyatForm = new k_fiyatlar()
            {
                TopLevel = false,
                TopMost = true
            };
          
            panel3.Controls.Add(userFiyatForm);
            userFiyatForm.Show();
            label1.Visible = false; // Kullanıcı adını gizle
            label2.Visible = false; // Program bilgisini gizle
            panel4.Visible = false; // Panel4'ü gizle

        }
    }
}
