namespace FitnessUyg.Formlar
{
    partial class a_programlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Gun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Egzersiz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Set = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tekrar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Not = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 45);
            this.button1.TabIndex = 34;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(126, 264);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(190, 45);
            this.btnSil.TabIndex = 32;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Gun,
            this.Egzersiz,
            this.Set,
            this.Tekrar,
            this.Not});
            this.dataGridView1.Location = new System.Drawing.Point(505, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1416, 1093);
            this.dataGridView1.TabIndex = 29;
            // 
            // Gun
            // 
            this.Gun.HeaderText = "Gün";
            this.Gun.Name = "Gun";
            // 
            // Egzersiz
            // 
            this.Egzersiz.HeaderText = "Egzersiz";
            this.Egzersiz.Name = "Egzersiz";
            // 
            // Set
            // 
            this.Set.HeaderText = "Set";
            this.Set.Name = "Set";
            // 
            // Tekrar
            // 
            this.Tekrar.HeaderText = "Tekrar";
            this.Tekrar.Name = "Tekrar";
            // 
            // Not
            // 
            this.Not.HeaderText = "Not";
            this.Not.Name = "Not";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(126, 213);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(190, 45);
            this.btnGuncelle.TabIndex = 31;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Yeni"});
            this.comboBox1.Location = new System.Drawing.Point(126, 329);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(190, 21);
            this.comboBox1.TabIndex = 35;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(126, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 37;
            this.label1.Text = "Tablo Adı :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(212, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 45);
            this.button2.TabIndex = 38;
            this.button2.Text = "Tabloyu Temizle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // a_programlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGuncelle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "a_programlar";
            this.Text = "a_programlar";
            this.Load += new System.EventHandler(this.a_programlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gun;
        private System.Windows.Forms.DataGridViewTextBoxColumn Egzersiz;
        private System.Windows.Forms.DataGridViewTextBoxColumn Set;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tekrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Not;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}