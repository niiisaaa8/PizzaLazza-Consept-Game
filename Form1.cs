using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace burger_avcisi_app
{
    public partial class Form1 : Form
    {
        // --- DEĞİŞKENLER ---
        int skor = 0;
        int kalanSure = 10;
        int saniyeSayaci = 0;
        Random rastgele = new Random();
        List<PictureBox> dusenNesneler = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            this.Text = "PizzaLazza - Lezzet Avcısı";

            // --- İŞTE BU EKSİK KABLOLAR (Bunları Ekle) ---
            oyunTimer.Tick += new EventHandler(OyunZamani); // Motoru bağla
            this.KeyDown += new KeyEventHandler(TuşaBasildi); // Klavyeyi bağla
                                   

            // --- 1. BAŞLANGIÇ TEMİZLİĞİ ---
            this.DoubleBuffered = true; // Donmayı engeller

            // Oyunu durdur (Otomatik başlamasın)
            oyunTimer.Enabled = false;

            oyunTimer.Stop();
            // Menüyü ortala
            Form1_Resize(null, null);
        }

        // --- 2. OYUNA BAŞLA BUTONU ---
        private void btnBasla_Click(object sender, EventArgs e)
        {

            // İŞTE BU SATIRI EKLE:
            lblSure.BringToFront();
        
           // 1. Yazıyı formun kendisine bağla (Yanlışlıkla başka panelin içine kaçmasın)
           lblSure.Parent = this;

            // 2. Yazıyı ekranın görünen yerine ışınla (X=600, Y=20)
            lblSure.Location = new Point(1250, 20);

            // 3. Yazıyı en öne getir (Resimlerin altında kalmasın)
            lblSure.BringToFront();

            // 4. Rengini CIRTLAK KIRMIZI yap ki kesin görelim
            lblSure.ForeColor = Color.DarkRed;

            // 5. Görünür olduğundan emin ol
            lblSure.Visible = true;
            // Giriş ekranını kapat
            pnlGiris.Visible = false;

            // Ekranın genişliğinden sepeti çıkar, ikiye böl = Tam Orta
            pizzakutusu.Left = (this.ClientSize.Width - pizzakutusu.Width) / 2;
          
            // Garsonu sahneye çağır ve EN ÖNE al
            pizzakutusu.Visible = true;
            pizzakutusu.BringToFront();

            // Oyunu başlat
            oyunTimer.Start();

            // Odağı forma ver (Klavye çalışsın diye)
            this.Focus();
        }

        // --- 3. EKRAN BOYUTU DEĞİŞİRSE ---
        private void Form1_Resize(object sender, EventArgs e)
        {
            // Menüdeki Başlığı Ortala (label1 senin başlığınsa ismini kontrol et)
            // Eğer başlığının adı lblBaslik ise burayı değiştir
            try
            {
                // Menü başlığını ortala
                foreach (Control c in pnlGiris.Controls)
                {
                    if (c is Label) // Başlık
                    {
                        c.Left = (this.ClientSize.Width - c.Width) / 2;
                        c.Top = (this.ClientSize.Height / 2) - 80;
                    }
                    if (c is Button) // Buton
                    {
                        c.Left = (this.ClientSize.Width - c.Width) / 2;
                        c.Top = (this.ClientSize.Height / 2) + 20;
                    }
                }
            }
            catch { }

            // Sepeti aşağı sabitle
            if (pizzakutusu != null)
                pizzakutusu.Top = this.ClientSize.Height - pizzakutusu.Height;
        }

        // --- 4. KLAVYE KONTROLÜ ---
        private void TuşaBasildi(object sender, KeyEventArgs e)
        {
            int sepetHizi = 45; // Hız
            if (e.KeyCode == Keys.Left && pizzakutusu.Left > 0)
                pizzakutusu.Left -= sepetHizi;
            else if (e.KeyCode == Keys.Right && pizzakutusu.Right < this.ClientSize.Width)
                pizzakutusu.Left += sepetHizi;
        }

        // --- 5. OYUN ZAMANI (HER ŞEY BURADA DÖNÜYOR) ---
        // --- OYUN ZAMANI (HER ŞEYİN OLDUĞU ANA MOTOR) ---
        private void OyunZamani(object sender, EventArgs e)
        {
            // 1. SEPETİ AŞAĞIYA ÇAK (Ekran boyutu değişse bile)
            if (pizzakutusu != null)
                pizzakutusu.Top = this.ClientSize.Height - pizzakutusu.Height;


            // 3. SÜRE SAYACI
            saniyeSayaci++;
            if (saniyeSayaci >= 40) // Yaklaşık 1 saniye geçince
            {
                saniyeSayaci = 0;
                kalanSure--;
                try { lblSure.Text = "Süre: " + kalanSure; } catch { }

                // SÜRE BİTTİ Mİ? (KAYBETME)
                if (kalanSure <= 0)
                {
                    oyunTimer.Stop();
                    // Windows'un Hata sesini çal (Bitiş uyarısı)
                    System.Media.SoundPlayer ses = new System.Media.SoundPlayer(Properties.Resources.kaybedis_wav);
                    ses.Play();

                    DialogResult cevap = MessageBox.Show(
                        "SÜRE BİTTİ! Topladığın Puan: " + skor + "\n\nTekrar denemek ister misin?",
                        "Oyun Sonu",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (cevap == DialogResult.Yes) OyunuSifirla();
                    else Application.Exit();
                }
            }

            // 4. YENİ NESNE ÜRETME (%6 Şansla)
            if (rastgele.Next(0, 100) < 6)
            {
                NesneUret();
            }

            // 5. HAREKET VE ÇARPIŞMA KONTROLÜ
            for (int i = dusenNesneler.Count - 1; i >= 0; i--)
            {
                PictureBox nesne = dusenNesneler[i];
                nesne.Top += 7; // Düşme hızı

                // A) Yere düştü mü? (Ekrandan çıktı mı?)
                if (nesne.Top > this.ClientSize.Height)
                {
                    this.Controls.Remove(nesne);
                    dusenNesneler.Remove(nesne);
                }
                // B) Sepete çarptı mı? (Yakaladık!)
                else if (nesne.Bounds.IntersectsWith(pizzakutusu.Bounds))
                {
                    string tur = nesne.Tag.ToString();

                    if (tur == "Pizza")
                    {
                        skor += 20;
                        // OLUMLU SES (Dın!)
                        System.Media.SoundPlayer ses = new System.Media.SoundPlayer(Properties.Resources.ye_wav);
                        ses.Play();
                    }
                    else // Brokoli
                    {
                        skor -= 10;
                        // OLUMSUZ SES (Düm!)
                        System.Media.SoundPlayer ses = new System.Media.SoundPlayer(Properties.Resources.hata_wav);
                        ses.Play();
                    }

                    // Skoru güncelle ve nesneyi yok et
                    lblSkor.Text = "Skor: " + skor;
                    this.Controls.Remove(nesne);
                    dusenNesneler.Remove(nesne);
                }
            }

            // 6. KAZANMA KONTROLÜ (Hedef 100 Puan Olsun)
            if (skor >= 100)
            {
                oyunTimer.Stop();
                System.Media.SoundPlayer ses = new System.Media.SoundPlayer(Properties.Resources.kazanis_wav);
                ses.Play();

                DialogResult cevap = MessageBox.Show(
                    "TEBRİKLER ŞAMPİYON! \n PİZZALAZZA'dan %20 İndirim Kodun: LAZZA20\n\nTekrar oynamak ister misin?",
                    "Zafer!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Asterisk);

                if (cevap == DialogResult.Yes) OyunuSifirla();
                else Application.Exit();
            }
        }

        // --- 6. NESNE ÜRETME ---
        private void NesneUret()
        {
            PictureBox yeniNesne = new PictureBox();
            yeniNesne.Size = new Size(110, 110);
            yeniNesne.Top =-100;
            yeniNesne.Left = rastgele.Next(20, this.ClientSize.Width - 100);
            yeniNesne.SizeMode = PictureBoxSizeMode.StretchImage;
            yeniNesne.BackColor = Color.Transparent;

            int sans = rastgele.Next(0, 100);
           
           if (sans < 60) // pizza
            {
                yeniNesne.Tag = "Pizza";
                try { yeniNesne.Image = Properties.Resources.pizzaResim; } catch { yeniNesne.BackColor = Color.Orange; }
            }
            else // çürük
            {
                yeniNesne.Tag = "Yanık Pizza";
                try { yeniNesne.Image = Properties.Resources.yanıkPizza; } catch { yeniNesne.BackColor = Color.Green; }
            }

            dusenNesneler.Add(yeniNesne);
            this.Controls.Add(yeniNesne);
            yeniNesne.BringToFront();

            // Eğer menü açıksa nesneyi arkaya at (Hata önleyici)
            if (pnlGiris.Visible == true) yeniNesne.SendToBack();
        }

        // --- 7. OYUNU SIFIRLA ---
        private void OyunuSifirla()
        {
            skor = 0;
            kalanSure = 15;
            lblSkor.Text = "Skor: 0";
            lblSure.Text = "Süre: 15";

            foreach (PictureBox nesne in dusenNesneler) this.Controls.Remove(nesne);
            dusenNesneler.Clear();

            // Giriş ekranına dön
            pnlGiris.Visible = true;
            pizzakutusu.Visible = false;
            // Ekranın genişliğinden sepeti çıkar, ikiye böl = Tam Orta
            pizzakutusu.Left = (this.ClientSize.Width - pizzakutusu.Width) / 2;
            oyunTimer.Stop(); // Zamanı durdur, butona basılmasını bekle
          
      
        }

        // Hata Önleyiciler (Boş kalsın)
        private void Form1_Load(object sender, EventArgs e)
        {
            // Sepet (Kutu) ayarı buraya gelecek
            pizzakutusu.Size = new Size(150, 100);
            pizzakutusu.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pnlGiris_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}


