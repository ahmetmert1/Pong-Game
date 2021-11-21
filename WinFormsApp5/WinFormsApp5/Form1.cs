using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        oyun oyun_nesne;
        public Form1()
        {
            oyun_nesne = new oyun(this);
            InitializeComponent();

            
        }

        private void tusa_basildi(object sender, KeyEventArgs e)
        {
            oyun_nesne.tusa_basildi_oyun(e);
        }

        private void tus_cekildi(object sender, KeyEventArgs e)
        {
            oyun_nesne.tus_cekildi_oyun(e);
        }

        //timer1 'e bağlı 10 ms de bir tetiklenen topların hareketini sağlayan fonksiyon
        private void hareket_ettir(object sender, EventArgs e)
        {

            oyun_nesne.hareket_ettir_oyun(timer1, timer2, timer3, pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7);
        }

        //10 saniyede 1 top oluşturan fonksiyon
        private void top_olustur(object sender, EventArgs e)
        {
            oyun_nesne.top_olustur_oyun();
        }

        private void tahta_hareket(object sender, EventArgs e)
        {
            oyun_nesne.tahta_hareket_oyun(pictureBox1);
        }

        //private void ikili_top_olustur()
        //{
            

        //}

        ////Topların yönünü belirleyen fonksiyon
        //private int bir_yada_eksibir()
        //{
            


        //}

        private void devam_et(object sender, EventArgs e)
        {

            oyun_nesne.devam_et_oyun(timer1,timer2,timer3);
        }

        private void durdur(object sender, EventArgs e)
        {
            oyun_nesne.durdur_oyun(timer1, timer2, timer3);
        }
    }
}
