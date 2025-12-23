namespace burger_avcisi_app
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblSkor = new System.Windows.Forms.Label();
            this.oyunTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlGiris = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBasla = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSure = new System.Windows.Forms.Label();
            this.pizzakutusu = new System.Windows.Forms.PictureBox();
            this.pnlGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pizzakutusu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSkor
            // 
            this.lblSkor.AutoSize = true;
            this.lblSkor.BackColor = System.Drawing.Color.Transparent;
            this.lblSkor.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSkor.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSkor.Location = new System.Drawing.Point(12, 18);
            this.lblSkor.Name = "lblSkor";
            this.lblSkor.Size = new System.Drawing.Size(142, 45);
            this.lblSkor.TabIndex = 1;
            this.lblSkor.Text = "Skor: 0";
            // 
            // oyunTimer
            // 
            this.oyunTimer.Interval = 17;
            // 
            // pnlGiris
            // 
            this.pnlGiris.BackColor = System.Drawing.Color.Transparent;
            this.pnlGiris.BackgroundImage = global::burger_avcisi_app.Properties.Resources.mutfakResim;
            this.pnlGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlGiris.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGiris.Controls.Add(this.pictureBox1);
            this.pnlGiris.Controls.Add(this.btnBasla);
            this.pnlGiris.Controls.Add(this.label1);
            this.pnlGiris.Controls.Add(this.lblSure);
            this.pnlGiris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGiris.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pnlGiris.Location = new System.Drawing.Point(0, 0);
            this.pnlGiris.Name = "pnlGiris";
            this.pnlGiris.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlGiris.Size = new System.Drawing.Size(1545, 755);
            this.pnlGiris.TabIndex = 3;
            this.pnlGiris.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGiris_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // btnBasla
            // 
            this.btnBasla.BackColor = System.Drawing.Color.Crimson;
            this.btnBasla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBasla.FlatAppearance.BorderSize = 0;
            this.btnBasla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasla.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBasla.ForeColor = System.Drawing.Color.White;
            this.btnBasla.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBasla.Location = new System.Drawing.Point(434, 418);
            this.btnBasla.Name = "btnBasla";
            this.btnBasla.Size = new System.Drawing.Size(338, 98);
            this.btnBasla.TabIndex = 1;
            this.btnBasla.Text = "OYUNA BAŞLA";
            this.btnBasla.UseVisualStyleBackColor = false;
            this.btnBasla.Click += new System.EventHandler(this.btnBasla_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(296, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(596, 84);
            this.label1.TabIndex = 0;
            this.label1.Text = "LEZZET YAĞMURU";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblSure
            // 
            this.lblSure.AutoSize = true;
            this.lblSure.BackColor = System.Drawing.Color.Transparent;
            this.lblSure.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSure.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSure.Location = new System.Drawing.Point(1124, 16);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(162, 45);
            this.lblSure.TabIndex = 2;
            this.lblSure.Text = "Süre: 10";
            // 
            // pizzakutusu
            // 
            this.pizzakutusu.BackColor = System.Drawing.Color.Transparent;
            this.pizzakutusu.Image = global::burger_avcisi_app.Properties.Resources.pizzakutusu;
            this.pizzakutusu.Location = new System.Drawing.Point(485, 580);
            this.pizzakutusu.Name = "pizzakutusu";
            this.pizzakutusu.Size = new System.Drawing.Size(271, 201);
            this.pizzakutusu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pizzakutusu.TabIndex = 3;
            this.pizzakutusu.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1545, 755);
            this.Controls.Add(this.pnlGiris);
            this.Controls.Add(this.pizzakutusu);
            this.Controls.Add(this.lblSkor);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.pnlGiris.ResumeLayout(false);
            this.pnlGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pizzakutusu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSkor;
        private System.Windows.Forms.Timer oyunTimer;
        private System.Windows.Forms.Panel pnlGiris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBasla;
        private System.Windows.Forms.PictureBox pizzakutusu;
        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

