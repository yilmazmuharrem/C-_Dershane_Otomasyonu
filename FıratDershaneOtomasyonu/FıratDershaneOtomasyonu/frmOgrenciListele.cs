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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace FıratDershaneOtomasyonu
{
    public partial class frmOgrenciListele : Form
    {
        public frmOgrenciListele()
        {
            InitializeComponent();
        }
        public static void PDF_Disa_Aktar(DataGridView dataGridView1)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "PDF Dosyaları";
            save.DefaultExt = "pdf";
            save.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);

                // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.
                pdfTable.DefaultCell.Padding = 3; // hücre duvarı ve veri arasında mesafe
                pdfTable.WidthPercentage = 80; // hücre genişliği
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT; // yazı hizalaması
                pdfTable.DefaultCell.BorderWidth = 1; // kenarlık kalınlığı
                // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240); // hücre arka plan rengi
                    pdfTable.AddCell(cell);
                }
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                    }
                }
                catch (NullReferenceException)
                {
                }
                using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);// sayfa boyutu.
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }

        //SqlConnection baglanti = new SqlConnection(baglanSınıfı.baglanti);
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4SCIA0P\\SQLEXPRESS;Initial Catalog=FıratDershaneOtomasyon;Integrated Security=True");

        public void komutGir(string komut)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(komut, baglanti);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void frmOgrenciListele_Load(object sender, EventArgs e)
        {
           // dataGridView1.ClearSelection();
            komutGir("Select Ad,Soyad,Tc,DogumYili,Sınıf,TblVeli.VeliTel,TblVeli.VeliAdSoyad from TblOgrenci Inner join TblVeli ON TblOgrenci.VeliID = TblVeli.VeliID");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arancakTc = mskTc.Text;
            baglanti.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from TblOgrenci where Tc LIKE '%" + arancakTc + "%'", baglanti);
            DataSet dataset = new DataSet();
            adaptor.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            baglanti.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Uygulamadan Çıkmak İstediğinize Emin Misiniz ?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1.form.Show();
            this.Close();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            PDF_Disa_Aktar(dataGridView1);
            MessageBox.Show("Öğrenciler Yazdırıldı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                
                
                }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
