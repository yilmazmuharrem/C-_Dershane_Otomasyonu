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
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
namespace FıratDershaneOtomasyonu
{
    public partial class btnTaksitÖde : Form
    {
        public btnTaksitÖde()
        {
            InitializeComponent();
        }

        //  double GüncelKalanTaksitSayısı;


        
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4SCIA0P\\SQLEXPRESS;Initial Catalog=FıratDershaneOtomasyon;Integrated Security=True");
     //   SqlConnection baglanti = new SqlConnection(baglanSınıfı.baglanti);
        private void OgrenciUcretIslemleri_Load(object sender, EventArgs e)
        {


            ElemanlarıListele();
            timeee.Text = lblTime.Text;
      
        }
        int GüncelKalanTaksitSayısı;
        private void btnArama_Click(object sender, EventArgs e)
        {
            string arancakKisi = txtVerenKisiAd.Text;
            baglanti.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from TblTaksit where VerenKisiAdSoyad LIKE '%" + arancakKisi + "%'", baglanti);
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

        public   void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenSutun = dataGridView1.SelectedCells[0].RowIndex;
            string ID = dataGridView1.Rows[secilenSutun].Cells[0].Value.ToString();
            string Tc = dataGridView1.Rows[secilenSutun].Cells[1].Value.ToString();
            string AlanPersonelAdSoyad = dataGridView1.Rows[secilenSutun].Cells[2].Value.ToString();
            string VerenKisiAdSoyad = dataGridView1.Rows[secilenSutun].Cells[3].Value.ToString();
            string odenecekTutar = dataGridView1.Rows[secilenSutun].Cells[7].Value.ToString();
            string kalanTutar = dataGridView1.Rows[secilenSutun].Cells[9].Value.ToString();
            string kalanTaksitAdedi = dataGridView1.Rows[secilenSutun].Cells[8].Value.ToString();


               GüncelKalanTaksitSayısı = Int32.Parse(kalanTaksitAdedi);
            double kalanUcret = double.Parse(kalanTutar);
            double ödenilenTaksitUcreti = double.Parse(odenecekTutar);

            kalanUcret -= ödenilenTaksitUcreti;
            GüncelKalanTaksitSayısı -= 1;
            lblTc.Text = Tc;
            lblTaksitID.Text = ID;
            lblÖdenecekTutar.Text = odenecekTutar + " TL ";
            txtAlanKisi.Text = AlanPersonelAdSoyad;
            txtVerenKisi.Text = VerenKisiAdSoyad;
            lblKalanTaksit.Text = GüncelKalanTaksitSayısı.ToString();
            lblKalanTutar.Text = kalanUcret.ToString();
              
            
            

        }

        private void btnTaksitOdeMakbuzBas_Click(object sender, EventArgs e)
        {
            if (lblTaksitID.Text =="" && lblTc.Text =="")
            {
                MessageBox.Show("Lütfen Önce Bir Öğrenci Seçin !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
           
            else
            {
                if (GüncelKalanTaksitSayısı >= 0)
                {
                    veriTabaniIslemleri();
                    ElemanlarıListele();
                    makbuzYazdir();
                }
                else
                {
                    MessageBox.Show("Öğrencinin Ücreti Bitmiştir", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblKalanTaksit.Text = "TAKSİT BİTTİ";
                    lblKalanTutar.Text = " ÜCRET BİTTİ";
                }
                txtAlanKisi.Text = "";
                txtVerenKisi.Text = "";
                lblTaksitID.Text = "";
                lblTc.Text = "";
                lblÖdenecekTutar.Text = "";
                lblTime.Text = "";

            }
        }

        public void veriTabaniIslemleri()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TblTaksit set KalanTaksitAdedi='" + lblKalanTaksit.Text + "',KalanPara='" + lblKalanTutar.Text + "'where TaksitID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", lblTaksitID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("taksit Ödendi");



        }


        public void ElemanlarıListele()
        {
            baglanti.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(" select TblTaksit.TaksitID,Tc,AlanPersonelID,VerenKisiAdSoyad,Ucret,Tarih,TaksitAdedi,TaksitUcreti,KalanTaksitAdedi,KalanPara from TblTaksit Inner Join TblOgrenci on TblOgrenci.TaksitID = TblTaksit.TaksitID", baglanti);
            DataSet dataset = new DataSet();
            adaptor.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            baglanti.Close();
        }


        public void makbuzYazdir()
        {
            iTextSharp.text.Document yazdir = new iTextSharp.text.Document();
            PdfWriter.GetInstance(yazdir, new FileStream("C:\\Users\\muhar\\Desktop\\MAKBUZ\\" + lblTc.Text + " TAKSİT MAKBUZU.pdf", FileMode.Create));
            yazdir.Open();
            yazdir.AddAuthor("FIRAT DERSHANESİ");
            yazdir.AddCreationDate();
            yazdir.AddSubject("MAKBUZ");
            iTextSharp.text.Image icon = iTextSharp.text.Image.GetInstance("C:\\Users\\muhar\\Desktop\\makbuz.png");
            yazdir.Add(icon);
            yazdir.AddCreator("Personel");

            //if (yazdir.IsOpen()==false)
            //{
            //    yazdir.Close();
            //}
            yazdir.Add(new Paragraph("         FIRAT DERSHANESI MAKBUZ BILGILERI                 \n" +
                "OGRENCI TC     : "+lblTc.Text+"\n"+ 
                "ALAN KISI      : "+txtAlanKisi.Text+"\n"+
                "VEREN KISI     : "+txtVerenKisi.Text+"\n"+
                "ODENILEN UCRET :"+lblÖdenecekTutar.Text+"\n"+
                "KALAN UCRET    :"+lblKalanTutar.Text+"\n"+
                "KALAN TAKSIT SAYISI :"+lblKalanTaksit.Text+"\n"+
                "TARIH                :"+lblTime.Text+"\n"+
                "                                                                                 IMZA           "));


            yazdir.Close();



            MessageBox.Show("MAKBUZ MASAUSTUNDE MAKBUZ ADLI KLASORE YAZILDI","DOSYA İŞLEMLERİ",MessageBoxButtons.OK,MessageBoxIcon.Information);








        }
    }
}
