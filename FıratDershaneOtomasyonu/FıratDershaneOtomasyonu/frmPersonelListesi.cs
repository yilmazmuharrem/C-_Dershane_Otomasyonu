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
    public partial class frmPersonelListesi : Form
    {
        public frmPersonelListesi()
        {
            InitializeComponent();
        }
        //  SqlConnection baglanti = new SqlConnection(baglanSınıfı.baglanti);
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4SCIA0P\\SQLEXPRESS;Initial Catalog=FıratDershaneOtomasyon;Integrated Security=True");


        public void personelListele()
        {
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select*from TblPersonelListesi", baglanti);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
            baglanti.Close();



        }
        public void temizle()
        {
            txtMaas.Clear();
            txtPersonelAdSoyad.Clear();
            txtTelefon.Clear();
            lblOgrtID.Text = "**";
        }
        private void frmPersonelListesi_Load(object sender, EventArgs e)
        {
            personelListele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenSutun = dataGridView1.SelectedCells[0].RowIndex;
            string ıd = dataGridView1.Rows[secilenSutun].Cells[0].Value.ToString();
            string AdSoyad = dataGridView1.Rows[secilenSutun].Cells[1].Value.ToString();
            string telefon = dataGridView1.Rows[secilenSutun].Cells[2].Value.ToString();
            string Maas = dataGridView1.Rows[secilenSutun].Cells[3].Value.ToString();
            lblOgrtID.Text = ıd;
            txtPersonelAdSoyad.Text = AdSoyad;
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
                SqlCommand ogrSilKomutu = new SqlCommand("delete from TblPersonelListesi where PersonelID=@p1", baglanti);
                ogrSilKomutu.Parameters.AddWithValue("@p1", lblOgrtID.Text);
                ogrSilKomutu.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("PERSONEL SİLİNDİ", "PERSONEL İŞLEMLERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personelListele();
                temizle();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lblOgrtID.Text == "**")
            {
                if (txtPersonelAdSoyad.Text != "")
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into TblPersonelListesi (PersonelAdSoyad,PersonelTelefon,PersonelMaas) values (@p1,@p2,@p3)", baglanti);
                    komut.Parameters.AddWithValue("@p1", txtPersonelAdSoyad.Text);
                    komut.Parameters.AddWithValue("@p2", txtTelefon.Text);
                    komut.Parameters.AddWithValue("@p3", txtMaas.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    temizle();

                    MessageBox.Show("PERSONEL KAYDEDİLDİ");
                    personelListele();
                }
                else
                {
                    MessageBox.Show("LÜTFEN PERSONEL ADINI VE SOYADINI GİRİNİZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



            }
            else
            {
                MessageBox.Show("LÜTFEN ÖNCE TEMİZLE BUTONUNA TIKLAYINIZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            if (lblOgrtID.Text == "**")
            {
                MessageBox.Show("LÜTFEN ÖNCE BİR PERSONEL SEÇİNİZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                {
                    if (txtPersonelAdSoyad.Text == "")
                    {
                        MessageBox.Show("LÜTFEN ÖNCE BİR PERSONEL AD SOYAD GİRİNİZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }


                    baglanti.Open();
                    SqlCommand ogretmenGuncelle = new SqlCommand("update TblPersonelListesi set PersonelAdSoyad=@p1,PersonelTelefon=@p2,PersonelMaas=@p3 where PersonelID=@p4", baglanti);
                    ogretmenGuncelle.Parameters.AddWithValue("@p1", txtPersonelAdSoyad.Text);
                    ogretmenGuncelle.Parameters.AddWithValue("@p2", txtTelefon.Text);
                    ogretmenGuncelle.Parameters.AddWithValue("@p3", txtMaas.Text);
                    ogretmenGuncelle.Parameters.AddWithValue("@p4", lblOgrtID.Text);
                    ogretmenGuncelle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("PERSONEL GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    temizle();
                    personelListele();



                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
