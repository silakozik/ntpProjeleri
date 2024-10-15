using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adamAsmaca
{
    public partial class Form1 : Form
    {
        string[] kelimeler = { "YILDIZLI GECE","MERHABA","DÜNYA","OYUN","PROGRAMLAMA",
            "DENİZ","KURT","KELEBEK","KARAMEL","LABİRENT","BİLGİSAYAR","YALNIZLIK",
            "SÜPERNOVA","ORKİDE","ATATÜRK","KAHVE","ÇİKOLATA","ÖTÜKEN","ŞİMŞEK","ATTİLA" };
        string secilenKelime;
        char[] tahminEdilenKelime;
        int yanlisTahminSayisi = 0;
        int maxYanlisSayisi = 10;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            YeniOyun();
        }

        private void YeniOyun()
        {
            secilenKelime = kelimeler[random.Next(kelimeler.Length)];
            tahminEdilenKelime = new string('_', secilenKelime.Length).ToCharArray();
            lblKelime.Text = new string(tahminEdilenKelime);
            yanlisTahminSayisi = 0;
            lblDurum.Text = "Yanlış Tahmin Sayısı: 0";
            pictureBoxAdam.Image = null;
            btnTahminEt.Enabled = true;
        }

        private void btnTahminEt_Click(object sender, EventArgs e)
        {
           if(!string.IsNullOrWhiteSpace(txtTahmin.Text))
            {
                char tahmin = txtTahmin.Text.ToUpper()[0];
                txtTahmin.Clear();

                bool dogruTahmin = false;
                for (int i = 0; i < secilenKelime.Length; i ++)
                {
                    if (secilenKelime[i] == tahmin)
                    {
                        tahminEdilenKelime[i] = tahmin;
                        dogruTahmin = true;
                    }
                }
                if(dogruTahmin)
                {
                    lblKelime.Text = new string(tahminEdilenKelime);
                }
                else
                {
                    yanlisTahminSayisi++;
                    lblDurum.Text = "Yanlış Tahmin Sayısı:" + yanlisTahminSayisi;
                    AdamResmiGuncelle();
                }

                if (yanlisTahminSayisi >= maxYanlisSayisi)
                {
                    MessageBox.Show("Kaybettiniz! Kelime:" + secilenKelime);
                    btnTahminEt.Enabled = false;
                }

                if (new string(tahminEdilenKelime) == secilenKelime)
                {
                    MessageBox.Show("Tebrikler, kelimeyi buldunuz!");
                    btnTahminEt.Enabled = false;
                }
            }
        }

        private void AdamResmiGuncelle()
        {
            if (yanlisTahminSayisi <= 10)
            {
                string resimYolu = $"Paint/adam{yanlisTahminSayisi}.png"; // 'Images' yerine 'Paint' yazıldı
                try
                {
                    pictureBoxAdam.Image = Image.FromFile(resimYolu);
                }
                catch (Exception)
                {
                    MessageBox.Show("Resim bulunamadı: " + resimYolu);
                }
            }
        }


        private void btnYeniOyun_Click(object sender, EventArgs e)
        {
            YeniOyun();
        }

        private void txtTahmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblKelime_Click(object sender, EventArgs e)
        {

        }
    }
}
