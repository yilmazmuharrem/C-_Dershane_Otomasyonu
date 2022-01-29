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
    public partial class frYöneticiVeYetkiliGirism : Form
    {
        public frYöneticiVeYetkiliGirism()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmOğretmenListesi oğretmenListesi = new frmOğretmenListesi();
            oğretmenListesi.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmPersonelListesi personelListesi = new frmPersonelListesi();
            personelListesi.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1.form.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Uygulamadan Çıkmak İstediğinize Emin Misiniz ?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frYöneticiVeYetkiliGirism_Load(object sender, EventArgs e)
        {

        }
    }
}
