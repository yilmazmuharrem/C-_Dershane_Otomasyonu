using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace FıratDershaneOtomasyonu
{
    public partial class OgrenciSilme : Form
    {
        public OgrenciSilme()
        {
            InitializeComponent();
        }
      //  SqlConnection baglanti = new SqlConnection(baglanSınıfı.baglanti);
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4SCIA0P\\SQLEXPRESS;Initial Catalog=FıratDershaneOtomasyon;Integrated Security=True");


        public void ogrenciListele(string komut)
        {
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(komut, baglanti);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
            baglanti.Close();

        }


        private void OgrenciSilme_Load(object sender, EventArgs e)
        {

            // ogrenciListele("Select Ad, Soyad, Tc, DogumYili, Sınıf,OgrTel from TblOgrenci");
            ogrenciListele("select Ad,Soyad,Tc,DogumYili,Sınıf,OgrTel from TblOgrenci");


        }

     

        private void btnSilme_Click(object sender, EventArgs e)
        {


            if (txtAd.Text == "")
            {
                MessageBox.Show("Öğrenci Seçmediniz Lütfen Öğrenci Şeçin", "ÖĞRENCİ İŞLEMLERİ", MessageBoxButtons.OK);
            }
            else
            {
                baglanti.Open();
                SqlCommand ogrSilKomutu = new SqlCommand("delete from TblOgrenci where Tc=@p1", baglanti);
                ogrSilKomutu.Parameters.AddWithValue("@p1", lblTc.Text);
                ogrSilKomutu.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Öğrenci Silindi", "ÖĞRENCİ İŞLEMLERİ", MessageBoxButtons.OK);
                txtAd.Text = "";
                txtSoyad.Text = "";
                lblTc.Text = "";
                txtSınıf.Text = "";
                txtOgrenciTel.Text = "";
                txtDogum.Text = "";
                txtAd.Focus();
                ogrenciListele("Select Ad, Soyad, Tc, DogumYili, Sınıf,OgrTel from TblOgrenci");
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {

            if (txtAd.Text == "")
            {
                MessageBox.Show("Öğrenci Seçmediniz Lütfen Öğrenci Seçip Öyle Deneyin", "ÖĞRENCİ İŞLEMLERİ", MessageBoxButtons.OK);
            }
            else
            {
                baglanti.Open();
                SqlCommand ogrenciGuncelleKomutu = new SqlCommand("update TblOgrenci set Ad=@p1,Soyad=@p2,DogumYili=@p3,Sınıf=@p4,OgrTel=@p5 where Tc=@p6", baglanti);
                ogrenciGuncelleKomutu.Parameters.AddWithValue("@p1", txtAd.Text);
                ogrenciGuncelleKomutu.Parameters.AddWithValue("@p2", txtSoyad.Text);
                ogrenciGuncelleKomutu.Parameters.AddWithValue("@p3", txtDogum.Text);
                ogrenciGuncelleKomutu.Parameters.AddWithValue("@p4", txtSınıf.Text);
                ogrenciGuncelleKomutu.Parameters.AddWithValue("@p5", txtOgrenciTel.Text);
                ogrenciGuncelleKomutu.Parameters.AddWithValue("@p6", lblTc.Text);
                ogrenciGuncelleKomutu.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("öğrenci Güncellendi", "ÖĞRENCİ İŞLEMLERİ", MessageBoxButtons.OK);
                ogrenciListele("Select Ad, Soyad, Tc, DogumYili, Sınıf,OgrTel from TblOgrenci");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenSutun = dataGridView1.SelectedCells[0].RowIndex;
            string Ad = dataGridView1.Rows[secilenSutun].Cells[0].Value.ToString();
            string soyad = dataGridView1.Rows[secilenSutun].Cells[1].Value.ToString();
            string Tc = dataGridView1.Rows[secilenSutun].Cells[2].Value.ToString();
            string DogumYili = dataGridView1.Rows[secilenSutun].Cells[3].Value.ToString();
            string Sınıf = dataGridView1.Rows[secilenSutun].Cells[4].Value.ToString();
            string OgrTel = dataGridView1.Rows[secilenSutun].Cells[5].Value.ToString();


            txtAd.Text = Ad;
            txtSoyad.Text = soyad;
            lblTc.Text = Tc;
            txtDogum.Text = DogumYili;
            txtSınıf.Text = Sınıf;
            txtOgrenciTel.Text = OgrTel;
        }

   //     A%

        private void btnArama_Click(object sender, EventArgs e)
        {
            string arancakTc = txtArancakTc.Text;
            baglanti.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from TblOgrenci where Tc LIKE '%"+arancakTc+"%'",baglanti);
            DataSet dataset = new DataSet();
            adaptor.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            baglanti.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1.form.Show();
            this.Close();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Uygulamadan Çıkmak İstediğinize Emin Misiniz ?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}





























