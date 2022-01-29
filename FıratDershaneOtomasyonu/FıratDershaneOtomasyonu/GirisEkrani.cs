using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace FıratDershaneOtomasyonu
{

   

    public partial class GirisEkrani : Form
    {
        // SqlConnection baglanti = new SqlConnection(baglanSınıfı.baglanti);
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4SCIA0P\\SQLEXPRESS;Initial Catalog=FıratDershaneOtomasyon;Integrated Security=True");

        public GirisEkrani()
        {
            InitializeComponent();
        }
        WebBrowser ceviri = new WebBrowser();
        private void GirisEkrani_Load(object sender, EventArgs e)
        {
           


        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select*from AdminTablosu where Admin=@admin and parola=@parola",baglanti);
            komut.Parameters.AddWithValue("@admin",txtAdmin.Text);
            komut.Parameters.AddWithValue("@parola",txtParola.Text);
            SqlDataReader read = komut.ExecuteReader();
            if (read.Read())
            {
             
                Form1 anaForm = new Form1();
                anaForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Ya da Parola Yanlış !","BİLGİLENDİRME",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            baglanti.Close();

        }

        private void txtSifreUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
            sifremiUnuttum.Show();
        }

     

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtParola.UseSystemPasswordChar = true;
            }
            else
            {
                txtParola.UseSystemPasswordChar = false;

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz ?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

   
    }
}
