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
using System.Net;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;

namespace FıratDershaneOtomasyonu
{
    public partial class frmOgrenciIslemleri : Form
    {

        WebBrowser ceviri = new WebBrowser();

        public frmOgrenciIslemleri()
        {
            InitializeComponent();
        }


        // SqlConnection baglanti = new SqlConnection(baglanSınıfı.baglanti);
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4SCIA0P\\SQLEXPRESS;Initial Catalog=FıratDershaneOtomasyon;Integrated Security=True");



        private void frmOgrenciIslemleri_Load(object sender, EventArgs e)
        {
            txtAd.Focus();
            btnOgrenciKaydet.Visible = false;
            ceviri.Navigate("https://www.bing.com/translator/?from=tr&to=en");
            ceviri.ScriptErrorsSuppressed = true;

        }
        long mernisTc;
        string mernisAd;
        string mernisSoyad;
        int mernisDogumYili;
        bool durum;
        
        public void tcSorgulama(long tc, string Ad, string soyad, int dogumyili)
        {



            

            mernisTc = tc;
            mernisAd = Ad.ToUpper();
            mernisSoyad = soyad.ToUpper();
            mernisDogumYili = dogumyili;
            try
            {
                using (kimlik.KPSPublicSoapClient servis = new kimlik.KPSPublicSoapClient())
                {
                    durum = servis.TCKimlikNoDogrula(mernisTc,mernisAd,mernisSoyad,mernisDogumYili);
                }
            }
            catch (Exception)
            {


                MessageBox.Show("HATA","HATA",MessageBoxButtons.OK);
                durum = false;

            }
            if (durum)
            {
                btnOgrenciKaydet.Visible = true;
                mskOgrTel.ReadOnly = false;
                mskVeliTel.ReadOnly = false;
                mskUcret.ReadOnly = false;
                txtSınıf.ReadOnly = false;
                txtAdSoyad.ReadOnly = false;
                txtPersonel.ReadOnly = false;
                mskTaksitSayısı.ReadOnly = false;

            }

            
            
        }
        
        private void btnOgrenciKaydet_Click(object sender, EventArgs e)
            
        {



            if (durum)
            {



                string zaman = DateTime.Now.ToString();

                baglanti.Open();
                SqlCommand ogrenciEkleme = new SqlCommand("insert into TblOgrenci (Ad,Soyad,Tc,DogumYili,Sınıf,OgrTel) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);

                ogrenciEkleme.Parameters.AddWithValue("@p1", txtAd.Text);
                ogrenciEkleme.Parameters.AddWithValue("@p2", txtSoyad.Text);
                ogrenciEkleme.Parameters.AddWithValue("@p3", mskTc.Text);
                ogrenciEkleme.Parameters.AddWithValue("@p4", mskDogumYili.Text);
                ogrenciEkleme.Parameters.AddWithValue("@p5", txtSınıf.Text);
                ogrenciEkleme.Parameters.AddWithValue("@p6", mskOgrTel.Text);
                ogrenciEkleme.ExecuteNonQuery();
                baglanti.Close();




                baglanti.Open();
                SqlCommand veliEkleme = new SqlCommand("insert into TblVeli(VeliAdSoyad,VeliTel) values (@p1,@p2)", baglanti);
                veliEkleme.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                veliEkleme.Parameters.AddWithValue("@p2", mskVeliTel.Text);
                veliEkleme.ExecuteNonQuery();
                baglanti.Close();








                double SqltoplamUcret = Double.Parse(mskUcret.Text);
                double SqltaksitAdedi = Double.Parse(mskTaksitSayısı.Text);
                if (SqltaksitAdedi == 0)
                {
                    lblTaksitÜcreti.Text = "PEŞİN VERİLDİ";
                }

                double SqltaksitUcreti = SqltoplamUcret / SqltaksitAdedi;
                SqltaksitUcreti = Math.Round(SqltaksitUcreti, 2);



                baglanti.Open();
                SqlCommand taksitKomutu = new SqlCommand("insert into TblTaksit (Ucret,AlanPersonelID,VerenKisiAdSoyad,Tarih,TaksitAdedi,TaksitUcreti,KalanTaksitAdedi,KalanPara) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);

                taksitKomutu.Parameters.AddWithValue("@p1", mskUcret.Text);
                taksitKomutu.Parameters.AddWithValue("@p2", txtPersonel.Text);
                taksitKomutu.Parameters.AddWithValue("@p3", txtAdSoyad.Text);
                taksitKomutu.Parameters.AddWithValue("@p4", zaman);
                taksitKomutu.Parameters.AddWithValue("@p5", mskTaksitSayısı.Text);
                taksitKomutu.Parameters.AddWithValue("@p6", SqltaksitUcreti.ToString());
                taksitKomutu.Parameters.AddWithValue("@p7",mskTaksitSayısı.Text);
                taksitKomutu.Parameters.AddWithValue("@p8",mskUcret.Text);
                taksitKomutu.ExecuteNonQuery();
                baglanti.Close();



                baglanti.Open();
                SqlCommand velibilgigetirme = new SqlCommand("select*from TblVeli where VeliAdSoyad=@p1 and VeliTel=@p2", baglanti);
                velibilgigetirme.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                velibilgigetirme.Parameters.AddWithValue("@p2", mskVeliTel.Text);
                SqlDataReader read = velibilgigetirme.ExecuteReader();
                while (read.Read())
                {
                    label13.Text = read["VeliID"].ToString();
                }
                read.Close();
                baglanti.Close();





                baglanti.Open();
                SqlCommand taksitIdGetirme = new SqlCommand("select*from TblTaksit where VerenKisiAdSoyad=@p1 and AlanPersonelID=@p2", baglanti);
                taksitIdGetirme.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                taksitIdGetirme.Parameters.AddWithValue("@p2", txtPersonel.Text);
                SqlDataReader reader = taksitIdGetirme.ExecuteReader();
                while (reader.Read())
                {
                    label14.Text = reader["TaksitID"].ToString();
                }

                reader.Close();
                baglanti.Close();




                baglanti.Open();
                SqlCommand ogrenciVeliIdUptade = new SqlCommand("update TblOgrenci set VeliID='" + label13.Text + "',TaksitID='" + label14.Text + "'where Ad=@p1 and Soyad=@p2 and Tc=@p3", baglanti);
                ogrenciVeliIdUptade.Parameters.AddWithValue("@p1", txtAd.Text);
                ogrenciVeliIdUptade.Parameters.AddWithValue("@p2", txtSoyad.Text);
                ogrenciVeliIdUptade.Parameters.AddWithValue("@p3", mskTc.Text);
                ogrenciVeliIdUptade.ExecuteNonQuery();
                baglanti.Close();

                ceviri.Document.GetElementById("tta_input_ta").InnerText = "Fırat Dershanesine Hoş Geldin" + txtAd.Text;
                ceviri.Document.GetElementById("tta_playiconsrc").InvokeMember("click");
                MessageBox.Show("ÖĞRENCİ BAŞARILI BİR ŞEKİLDE KAYIT EDİLDİ","ÖĞRENCİ BİLGİ",MessageBoxButtons.OK);

                double toplamUcret = Double.Parse(mskUcret.Text);
               double taksitAdedi = Double.Parse(mskTaksitSayısı.Text);
                if (taksitAdedi ==0)
                {
                    lblTaksitÜcreti.Text = "PEŞİN VERİLDİ";
                }
                
                 double taksitUcreti = toplamUcret / taksitAdedi;
                taksitUcreti = Math.Round(taksitUcreti,2);
                lblAd.Text= txtAd.Text.ToUpper();
                lblSoyad.Text = txtSoyad.Text.ToUpper();
                lblSınıf.Text = txtSınıf.Text.ToUpper();
                lblVeliAdSoyad.Text = txtAdSoyad.Text.ToUpper();
                lblOgrTel.Text = "+90 " + mskOgrTel.Text;
                lblTaksitSayısı.Text = mskTaksitSayısı.Text;
                lblToplamUcret.Text = mskUcret.Text;
                lblTaksitÜcreti.Text = taksitUcreti.ToString();


                lblAd.Visible = true;
                lblSoyad.Visible = true;
                lblSınıf.Visible = true;
                lblVeliAdSoyad.Visible = true;
                lblOgrTel.Visible = true;
                lblTaksitÜcreti.Visible = true;
                lblTaksitSayısı.Visible = true;
                lblToplamUcret.Visible = true;
                btnOgrBilgiYazdır.Visible = true;
                foreach(Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
                mskDogumYili.Text = "";
                mskOgrTel.Text = "";
                mskTc.Text = "";
                mskVeliTel.Text = "";
                mskUcret.Text = "";

            }
            else
            {
                MessageBox.Show("Kayıt Başarısız");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            if (txtAd.Text == "") 
            {
                MessageBox.Show("Eksik Bilgi Tekrar Dene !", "Öğrenci İşlemleri", MessageBoxButtons.OK);
            }
            else
            {





                long tc = long.Parse(mskTc.Text);
                string ad = txtAd.Text;
                string soyad = txtSoyad.Text;
                int dogumYili = Convert.ToInt32(mskDogumYili.Text);


                tcSorgulama(tc, ad, soyad, dogumYili);



                if (durum)
                {
                    pngTrue.Visible = true;
                    pngSearch.Visible = false;
                    pngFalse.Visible = false;

                }
                if (!durum)
                {
                    pngFalse.Visible = true ;
                    pngTrue.Visible = false;
                    pngSearch.Visible = false;

                }
                {

                }
                if (durum)
                {
                   
                    lbldeneme.Visible = false;
                    MessageBox.Show("Kişi Sorguda Bulundu","Sorgu Sistemi",MessageBoxButtons.OK);
                }
                else
                {
                    
                    MessageBox.Show("Kişi Sorguda Bulunamadı,Tekrar Deneyiniz ","Sorgu Sistemi",MessageBoxButtons.OK);

                }

                

            }
        }

        private void mskDogumYili_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtUcret_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1.form.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz ?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnOgrBilgiYazdır_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Document kayit = new iTextSharp.text.Document();
            PdfWriter.GetInstance(kayit, new FileStream("C:\\Users\\muhar\\Desktop\\KAYITMAKBUZU"+lblAd.Text+" "+lblSınıf.Text+" KAYIT DOSYASI"+".pdf", FileMode.Create));
            kayit.Open();
            kayit.AddAuthor("OLUŞTURAN : MUHARREM YILMAZ");
            kayit.AddCreationDate();
            iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, iTextSharp.text.Font.NORMAL);
            
           
            kayit.AddSubject("KONUU");
            kayit.AddKeywords("KAYIT");
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(("C:\\Users\\muhar\\Desktop\\firatkayit.png"));
            kayit.Add(img);
            kayit.AddCreator("muharrem");


            if (kayit.IsOpen() == false)
            {
                kayit.Close();
            }
            kayit.Add(new Paragraph("" +
                "FIRAT DERSHANESI KAYIT BILGISI : \n" +
                "ÖĞRENCI AD SOYAD : " + lblAd.Text + " " + lblSoyad.Text + "" + "\n" +
                "SINIF : " + lblSınıf.Text + "\n" +
                "VELI AD SOYAD : " + lblVeliAdSoyad.Text +"\n"+
                "TOPLAM ÜCRET :" + lblToplamUcret.Text + "\n" +
                "TAKSIT SAYISI :" + lblTaksitSayısı.Text
                
               ));

            kayit.Close();


            MessageBox.Show("MAKBUZ YAZILDI");

        }
    }
}
