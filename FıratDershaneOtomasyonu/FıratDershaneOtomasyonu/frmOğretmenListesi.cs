using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FıratDershaneOtomasyonu
{
    public partial class frmOğretmenListesi : Form
    {
        public frmOğretmenListesi()
        {
            InitializeComponent();
        }
        //    SqlConnection baglanti = new SqlConnection(baglanSınıfı.baglanti);
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4SCIA0P\\SQLEXPRESS;Initial Catalog=FıratDershaneOtomasyon;Integrated Security=True");

        string Sistemid;
        string SistemadSoyad;
        string Sistemmaas;
        string Sistemtelefon;
        public void ogretmenleriListele(string komut)
        {
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(komut, baglanti);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
            baglanti.Close();

        }
        public void temizle()
        {
            txtMaas.Clear();
            txtOgretmenAdSoyad.Clear();
            txtTelefon.Clear();
            lblOgrtID.Text = "**";
        }
        private void frmOğretmenListesi_Load(object sender, EventArgs e)
        {
            ogretmenleriListele("select * from TblOgretmenler");

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenSutun = dataGridView1.SelectedCells[0].RowIndex;
            string ıd = dataGridView1.Rows[secilenSutun].Cells[0].Value.ToString();
            string AdSoyad = dataGridView1.Rows[secilenSutun].Cells[1].Value.ToString();
            string telefon = dataGridView1.Rows[secilenSutun].Cells[2].Value.ToString();
            string Maas = dataGridView1.Rows[secilenSutun].Cells[3].Value.ToString();
            lblOgrtID.Text = ıd;
            txtOgretmenAdSoyad.Text = AdSoyad;
            txtTelefon.Text = telefon;
            txtMaas.Text = Maas;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lblOgrtID.Text == "**")
            {
                MessageBox.Show("LÜTFEN ÖNCE BİR ÖĞRENCİ SEÇİN", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                baglanti.Open();
                SqlCommand ogrSilKomutu = new SqlCommand("delete from TblOgretmenler where OgretmenID=@p1", baglanti);
                ogrSilKomutu.Parameters.AddWithValue("@p1", lblOgrtID.Text);
                ogrSilKomutu.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("ÖĞRETMEN SİLİNDİ", "ÖĞRETMEN İŞLEMLERİ", MessageBoxButtons.OK,MessageBoxIcon.Information);
                ogretmenleriListele("select * from TblOgretmenler");
                temizle();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lblOgrtID.Text == "**")
            {
                if (txtOgretmenAdSoyad.Text != "")
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into TblOgretmenler (OgretmenAdSoyad,OgretmenTelefon,OgretmenMaas) values (@p1,@p2,@p3)", baglanti);
                    komut.Parameters.AddWithValue("@p1", txtOgretmenAdSoyad.Text);
                    komut.Parameters.AddWithValue("@p2", txtTelefon.Text);
                    komut.Parameters.AddWithValue("@p3", txtMaas.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    temizle();

                    MessageBox.Show("ÖĞRETMEN KAYDEDİLDİ");
                    ogretmenleriListele("select*from TblOgretmenler");
                }
                else
                {
                    MessageBox.Show("LÜTFEN ÖĞRETMEN ADINI VE SOYADINI GİRİNİZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



            }
            else
            {
                MessageBox.Show("LÜTFEN ÖNCE TEMİZLE BUTONUNA TIKLAYINIZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            if (lblOgrtID.Text == "**")
            {
                MessageBox.Show("LÜTFEN ÖNCE BİR ÖĞRETMEN SEÇİNİZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                {
                    if (txtOgretmenAdSoyad.Text == "")
                    {
                        MessageBox.Show("LÜTFEN ÖNCE BİR ÖĞRETMEN AD SOYAD GİRİNİZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }


                    baglanti.Open();
                    SqlCommand ogretmenGuncelle = new SqlCommand("update TblOgretmenler set OgretmenAdSoyad=@p1,OgretmenTelefon=@p2,OgretmenMaas=@p3 where OgretmenID=@p4", baglanti);
                    ogretmenGuncelle.Parameters.AddWithValue("@p1", txtOgretmenAdSoyad.Text);
                    ogretmenGuncelle.Parameters.AddWithValue("@p2", txtTelefon.Text);
                    ogretmenGuncelle.Parameters.AddWithValue("@p3", txtMaas.Text);
                    ogretmenGuncelle.Parameters.AddWithValue("@p4", lblOgrtID.Text);
                    ogretmenGuncelle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("OGRETMEN GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    temizle();
                    ogretmenleriListele("select*from TblOgretmenler");




                }
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
