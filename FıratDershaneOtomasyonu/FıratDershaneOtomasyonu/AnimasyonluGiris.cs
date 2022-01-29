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
    public partial class AnimasyonluGiris : Form
    {
        public AnimasyonluGiris()
        {
            InitializeComponent();
        }
        bool islem = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!islem)
            {
                this.Opacity += 0.009;
            }
            if (this.Opacity==1.0)
            {
                islem = true;
            }
            if (islem)
            {
                this.Opacity -= 0.009;
                if (this.Opacity == 0)
                {
                    GirisEkrani girisEkrani = new GirisEkrani();
                    girisEkrani.Show();
                    timer1.Enabled = false;
                }
                {

                }
            }
        }
    }
}
