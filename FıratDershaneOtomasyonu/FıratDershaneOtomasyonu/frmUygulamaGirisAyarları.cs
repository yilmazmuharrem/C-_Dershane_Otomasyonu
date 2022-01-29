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
    public partial class frmUygulamaGirisAyarları : Form
    {
        public frmUygulamaGirisAyarları()
        {
            InitializeComponent();
        }
        //SqlConnection baglanti = new SqlConnection(baglanSınıfı.baglanti);
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4SCIA0P\\SQLEXPRESS;Initial Catalog=FıratDershaneOtomasyon;Integrated Security=True");


        private void frmUygulamaGirisAyarları_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fıratDershaneOtomasyonDataSet3.AdminTablosu' table. You can move, or remove it, as needed.
            this.adminTablosuTableAdapter.Fill(this.fıratDershaneOtomasyonDataSet3.AdminTablosu);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into AdminTablosu (Admin,parola,ePosta) values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1",txtAdmin.Text);
            komut.Parameters.AddWithValue("@p2",txtParola.Text);
            komut.Parameters.AddWithValue("@p3", txtEmail.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("başarılı");

            SqlDataAdapter adaptor = new SqlDataAdapter("select*from AdminTablosu", baglanti);
            DataSet dataset = new DataSet();
            adaptor.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];



        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1.form.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamadan Çıkmak İstediğinize Emin Misiniz ?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
