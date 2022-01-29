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
using System.Net.Mail;
namespace FıratDershaneOtomasyonu
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }
        MailMessage message = new MailMessage();
        SmtpClient istemci = new SmtpClient();
         private string email;
         private   string sifre;

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4SCIA0P\\SQLEXPRESS;Initial Catalog=FıratDershaneOtomasyon;Integrated Security=True");

        // SqlConnection baglanti = new SqlConnection(baglanSınıfı.baglanti);
        private void btnSifreYenile_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select*from AdminTablosu where Admin='"+txtAdmin.Text+"'",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            if (read.Read())
            {
                read.Close();
                sifremiGonder(txtAdmin.Text);
                MessageBox.Show("Şifreniz Başarılı Bir Şekilde Sistemde Kayıtlı Olan E-posta adresinize Gönderildi","Sistem",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Sistemde Böyle bir Kullanıcı Yok Lütfen Tekrar Deneyin Eğer Sorun devam Ediyorsa Lütfen Yazılım Desteği Çağırınız","Sistem",MessageBoxButtons.OK,MessageBoxIcon.Information);
                baglanti.Close();
            }
        }

        private void sifremiGonder(string text)
        {
            
            SqlCommand komut2 = new SqlCommand("Select*from AdminTablosu where Admin='" + txtAdmin.Text + "'", baglanti);
            SqlDataReader read = komut2.ExecuteReader();
            if (read.Read())
            {
                email = read["ePosta"].ToString();
                sifre = read["parola"].ToString();


                istemci.Credentials = new System.Net.NetworkCredential("denemecsharp@hotmail.com", "05464335192van");
                istemci.Port = 587;
                istemci.Host = "smtp.live.com";
                istemci.EnableSsl = true;
                message.To.Add(email);
                message.From = new MailAddress("denemecsharp@hotmail.com");
                message.Subject = "TYT DERSHANESİ ŞİFRE HATIRLATMA";
                message.Body = "Merhaba Sayın Yetkili\nKullanıcı Adınız :" + txtAdmin.Text +
                    "\nŞifreniz :" + sifre + "\n" +
                    "İyi Günler Dileriz... ";
                istemci.Send(message);





            }
           

        }

        private void SifremiUnuttum_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
