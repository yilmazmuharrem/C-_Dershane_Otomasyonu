using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FıratDershaneOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static Form1 form = new Form1();

     

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            System.Diagnostics.Process.Start("https://www.geleceginyazilimcisi.com/");
        }

     

   

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmOgrenciIslemleri ogrenciIslemleri = new frmOgrenciIslemleri();
            ogrenciIslemleri.Show();
            this.Hide();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmUygulamaGirisAyarları frmUygulamaGirisAyarları = new frmUygulamaGirisAyarları();
            frmUygulamaGirisAyarları.Show();
            this.Hide();


        }

        private void pngOgrSilme_Click(object sender, EventArgs e)
        {
            OgrenciSilme ogrenciSilme = new OgrenciSilme();
            ogrenciSilme.Show();
                      this.Hide();
           


        }

        private void pngOgrListele_Click(object sender, EventArgs e)
        {

            frmOgrenciListele deneme = new frmOgrenciListele();
            deneme.Show();
            this.Hide();

        }

        private void pngUcretTablosu_Click(object sender, EventArgs e)
        {
            btnTaksitÖde ogrenciUcretIslemleri = new btnTaksitÖde();
            ogrenciUcretIslemleri.Show();
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("Çıkmak İstediğinize Emin Misiniz ?","ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frYöneticiVeYetkiliGirism frYöneticiVeYetkiliGirism = new frYöneticiVeYetkiliGirism();
            frYöneticiVeYetkiliGirism.Show();
            this.Hide();
        }
    }
}


