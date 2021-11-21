using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public class oyun
    {
        //AHMET MERT ÖZ 
        //18360859037
        //Görsel Programlama Ödev 4 


        //Oyun sonunda kazanınca ya da kaybedince gelen label fontu
        Font SonucFont = new Font("Snap ITC", 16);


        //klavyeden sağ ok ya da sol ok tuşuna basılı kontrol
        bool saga_git;
        bool sola_git;

        Label sonuc_yazisi; 

        int score = 0;

        //topların düşmesini engelleyen picBox'ın konum değişim hızı
        private int tahta_hizi = 10;
        //10 saniyede bir üretilen topların kontrolü
        private int top_10sn_sayi = 0;

        //10 sn de bir oluşturulan topların sayısı
        private int top_sayisi = 0;

        Random rastgele_sayi = new Random();

        private int top_yukseklik = 70;
        private int top_genislik = 70;

        //Y ekseni Hızı
        int[] y_ekseni_hizi = new int[70];
        //X ekseni Hızı
        int[] x_ekseni_hizi = new int[70];

        //ekranda mevcut bulunan top sayısı
        private int ekrandaki_top = 0;

        //Toplara rastgele renk vermemizi sağlayacak olan renk listesi
        List<Color> renkler = new List<Color>();

        //Oluştuduğumuz topları tuttuğumuz Liste
        List<PictureBox> toplar = new List<PictureBox>();

        Form form;
        public oyun(Form form)
        {
            this.form = form;

            sonuc_yazisi = new Label();

            for (int i = 0; i < 70; i++)
            {
                y_ekseni_hizi[i] = 2 * bir_yada_eksibir_oyun();
            }


            //X eksenindeki hız

            for (int i = 0; i < 70; i++)
            {
                x_ekseni_hizi[i] = 2 * bir_yada_eksibir_oyun();
            }


            renkler.Add(Color.Gray);
            //renkler.Add(Color.AliceBlue);
            renkler.Add(Color.Aquamarine);
            //renkler.Add(Color.Black);
            renkler.Add(Color.Brown);
            renkler.Add(Color.DarkCyan);
            renkler.Add(Color.Red);
            renkler.Add(Color.PaleGreen);
            renkler.Add(Color.DarkGreen);
            renkler.Add(Color.Pink);
            renkler.Add(Color.Fuchsia);
            renkler.Add(Color.Lime);
            renkler.Add(Color.Lavender);
            renkler.Add(Color.LightSeaGreen);
            renkler.Add(Color.Azure);
            renkler.Add(Color.PowderBlue);
            renkler.Add(Color.Tan);
        }

        public void tusa_basildi_oyun(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                sola_git = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                saga_git = true;
            }
        }

        public void tus_cekildi_oyun(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                sola_git = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                saga_git = false;
            }
        }

        public void hareket_ettir_oyun(Timer timer1, Timer timer2, Timer timer3,PictureBox pictureBox1, PictureBox pictureBox2, PictureBox pictureBox3, PictureBox pictureBox4, PictureBox pictureBox5, PictureBox pictureBox6, PictureBox pictureBox7)
        {
            if (ekrandaki_top == 10)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                //Oyun sonunda sonucu yazan label
                //Label sonuc_yazisi = new Label();
                sonuc_yazisi.Text = "KAYBETTİNİZ";
                sonuc_yazisi.ForeColor = Color.Black;
                sonuc_yazisi.BackColor = Color.Transparent;
                sonuc_yazisi.Font = SonucFont;
                sonuc_yazisi.Size = new Size(200, 100);
                sonuc_yazisi.Location = new Point(300, 200);
                sonuc_yazisi.Enabled = true;
                form.Controls.Add(sonuc_yazisi);
            }
            else if (4 < 5)
            {
                for (int i = 0; i < toplar.Count; i++)
                {
                    toplar[i].Left = toplar[i].Left + x_ekseni_hizi[i];
                    toplar[i].Top = toplar[i].Top + y_ekseni_hizi[i];



                    ////YUKARIDAN YOK OLAN TOP
                    if (toplar[i].Top < 0)
                    {
                        form.Controls.Remove(toplar[i]);
                        toplar.RemoveAt(i);
                        score = score + 10;
                        form.Controls["label5"].Text = "SCORE : " + score.ToString();


                        ekrandaki_top--;
                        if (ekrandaki_top == 0 && top_10sn_sayi > 5)
                        {
                            timer1.Stop();
                            timer2.Stop();
                            timer3.Stop();
                            //Label sonuc_yazisi = new Label();
                            sonuc_yazisi.Text = "KAZANDINIZ";
                            sonuc_yazisi.ForeColor = Color.Black;
                            sonuc_yazisi.Font = SonucFont;
                            sonuc_yazisi.Size = new Size(200, 100);
                            sonuc_yazisi.Location = new Point(300, 200);
                            sonuc_yazisi.Enabled = true;
                            form.Controls.Add(sonuc_yazisi);
                        }
                        form.Controls["label1"].Text = "Mevcut Top : " + ekrandaki_top.ToString();
                        break;
                    }


                    ////AŞAĞIDAN YOK OLAN TOP
                    if (toplar[i].Top > form.ClientSize.Height)
                    {
                        form.Controls.Remove(toplar[i]);
                        toplar.RemoveAt(i);
                        score = score - 20;
                        form.Controls["label5"].Text = "SCORE : " + score.ToString();

                        ekrandaki_top--;
                        if (ekrandaki_top == 0 && top_10sn_sayi >= 5)
                        {
                            timer1.Stop();
                            timer2.Stop();
                            timer3.Stop();
                            //Label sonuc_yazisi = new Label();
                            sonuc_yazisi.Text = "KAZANDINIZ";
                            sonuc_yazisi.ForeColor = Color.Black;
                            sonuc_yazisi.Font = SonucFont;
                            sonuc_yazisi.Size = new Size(200, 100);
                            sonuc_yazisi.Location = new Point(300, 200);
                            sonuc_yazisi.Enabled = true;
                            form.Controls.Add(sonuc_yazisi);
                        }
                        form.Controls["label1"].Text = "Mevcut Top : " + ekrandaki_top.ToString();

                        ikili_top_olustur_oyun();

                    }

                    //// KENARLARLA ETKİLEŞİM
                    if (toplar[i].Bounds.IntersectsWith(pictureBox1.Bounds))
                    {
                        y_ekseni_hizi[i] = -y_ekseni_hizi[i];
                        score = score + 1;
                        form.Controls["label5"].Text = "SCORE : " + score.ToString();
                    }

                    if (toplar[i].Bounds.IntersectsWith(pictureBox4.Bounds))
                    {
                        x_ekseni_hizi[i] = -x_ekseni_hizi[i];
                    }

                    if (toplar[i].Bounds.IntersectsWith(pictureBox2.Bounds))
                    {
                        y_ekseni_hizi[i] = -y_ekseni_hizi[i];
                    }

                    if (toplar[i].Bounds.IntersectsWith(pictureBox3.Bounds))
                    {
                        y_ekseni_hizi[i] = -y_ekseni_hizi[i];
                    }

                    if (toplar[i].Bounds.IntersectsWith(pictureBox5.Bounds))
                    {
                        x_ekseni_hizi[i] = -x_ekseni_hizi[i];
                    }

                    if (toplar[i].Bounds.IntersectsWith(pictureBox6.Bounds))
                    {
                        x_ekseni_hizi[i] = -x_ekseni_hizi[i];
                    }

                    if (toplar[i].Bounds.IntersectsWith(pictureBox7.Bounds))
                    {
                        x_ekseni_hizi[i] = -x_ekseni_hizi[i];
                    }




                }
            }
        }

        public void top_olustur_oyun()
        {
            if (top_sayisi < 5)
            {


                PictureBox top = new Class2();
                top.BackColor = renkler[rastgele_sayi.Next(0, 10)];
                top.Size = new Size(top_genislik, top_yukseklik);
                top.Location = new Point(rastgele_sayi.Next(40, 700), rastgele_sayi.Next(35, 300));
                top.Enabled = true;
                form.Controls.Add(top);
                toplar.Add(top);
                top_10sn_sayi++;
                top_sayisi++;
                ekrandaki_top++;
                form.Controls["label1"].Text = "Mevcut Top : " + toplar.Count.ToString();
                form.Controls["label2"].Text = "10 saniyede gelen top : " + top_10sn_sayi.ToString();


            }
        }

        public void tahta_hareket_oyun(PictureBox pictureBox1)
        {
            if (sola_git == true && pictureBox1.Left > 30)
            {
                pictureBox1.Left -= tahta_hizi;
            }
            if (saga_git == true && pictureBox1.Left < 620)
            {
                pictureBox1.Left += tahta_hizi;
            }
        }

        public void ikili_top_olustur_oyun()
        {
            for (int i = 0; i < 2; i++)
            {
                PictureBox top = new Class2();
                top.BackColor = renkler[rastgele_sayi.Next(0, 10)];
                top.Size = new Size(top_genislik, top_yukseklik);
                top.Location = new Point(rastgele_sayi.Next(35, 700), rastgele_sayi.Next(35, 350));
                top.Enabled = true;
                form.Controls.Add(top);
                toplar.Add(top);
                //top_sayisi++;
                ekrandaki_top++;
                form.Controls["label1"].Text = "Mevcut Top : " + toplar.Count.ToString();
            }
        }

        public int bir_yada_eksibir_oyun()
        {
            int sayi = rastgele_sayi.Next(-100, 100);
            if (sayi > 0)
            {
                return 1;
            }
            else if (sayi < 0)
            {
                return -1;
            }
            else
            {
                //0 olma durumu
                return 1;
            }
        }

        public void devam_et_oyun(Timer timer1,Timer timer2, Timer timer3)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            //Label sonuc_yazisi = new Label();
            //sonuc_yazisi.Text = "Oyun Duraklatıldı";
            //sonuc_yazisi.ForeColor = Color.Black;
            //sonuc_yazisi.Font = SonucFont;
            //sonuc_yazisi.Size = new Size(200, 100);
            //sonuc_yazisi.Location = new Point(300, 200);
            //sonuc_yazisi.Enabled = true;
            //Controls.Add(sonuc_yazisi);
            form.Controls.Remove(sonuc_yazisi);
        }

        public void durdur_oyun(Timer timer1, Timer timer2, Timer timer3)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            //Label sonuc_yazisi = new Label();
            sonuc_yazisi.Text = "Oyun Duraklatıldı";
            sonuc_yazisi.ForeColor = Color.Black;
            sonuc_yazisi.Font = SonucFont;
            sonuc_yazisi.Size = new Size(200, 100);
            sonuc_yazisi.Location = new Point(300, 200);
            sonuc_yazisi.Enabled = true;
            form.Controls.Add(sonuc_yazisi);
        }
    }
}
