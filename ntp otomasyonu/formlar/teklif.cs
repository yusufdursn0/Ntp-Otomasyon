using CsvHelper.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using ClosedXML.Excel;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace ntp_otomasyonu.formlar
{

    public partial class teklif : Form
    {
        sqlbaglantısı bgln = new sqlbaglantısı();
        public teklif()
        {
            InitializeComponent();
            listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            string excelPath = @"C:\Users\serhat\Downloads\birim_fiyat_temizlenmis.xlsx";

            try
            {
                // Arama metnini al
                string aramaMetni = textEdit1.Text.Trim();

                // Eğer arama metni boşsa kullanıcıya uyarı göster ve işlemi durdur
                if (string.IsNullOrWhiteSpace(aramaMetni))
                {
                    MessageBox.Show("Lütfen bir arama terimi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verileri okuyun ve arama metnine göre filtreleme yapın
                List<PozBilgisi> pozlar = ReadDataFromExcel(excelPath, aramaMetni);

                if (pozlar.Count == 0)
                {
                    MessageBox.Show("Hiçbir poz bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // FlowLayoutPanel'i temizle
                flowLayoutPanel1.Controls.Clear();

                // ToolTip nesnesi oluştur
                ToolTip toolTip = new ToolTip();

                foreach (var poz in pozlar)
                {
                    // Her poz için bir panel oluştur
                    Panel panel = new Panel
                    {
                        BackColor = Color.Gold,
                        Height = 60, // Daha fazla bilgi göstereceğimiz için yüksekliği artırıyoruz
                        Width = flowLayoutPanel1.Width - 20,
                        Margin = new Padding(5),
                        Tag = poz
                    };

                    // Poz bilgilerini gösteren etiketler ekle
                    Label lblPozNo = new Label
                    {
                        Text = poz.PozNo,
                        AutoSize = true,
                        Location = new Point(10, 10)
                    };
                    Label lblTanim = new Label
                    {
                        Text = poz.Tanim.Length > 30 ? poz.Tanim.Substring(0, 30) + "..." : poz.Tanim, // 50 karaktere sınırlama
                        AutoSize = true,
                        Location = new Point(150, 10)
                    };

                    // ToolTip ile tam tanım gösterimi
                    toolTip.SetToolTip(lblTanim, poz.Tanim);

                    Label lblOlcuBirimi = new Label
                    {
                        Text = $"Ölçü Birimi: {poz.OlcuBirimi}",
                        AutoSize = true,
                        Location = new Point(10, 35)
                    };
                    Label lblBirimFiyat = new Label
                    {
                        Text = $"Birim Fiyat: {poz.BirimFiyat}",
                        AutoSize = true,
                        Location = new Point(300, 35)
                    };
                    panel.Click += Panel_Click;
                    // Etiketleri panele ekle
                    panel.Controls.Add(lblPozNo);
                    panel.Controls.Add(lblTanim);
                    panel.Controls.Add(lblOlcuBirimi);
                    panel.Controls.Add(lblBirimFiyat);

                    // Paneli FlowLayoutPanel'e ekle
                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler işlenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Panel tıklama olayı
        private void Panel_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag is PozBilgisi poz)
            {
                // TextBox'lara poz bilgilerini aktar
                pozno.Text = poz.PozNo;
                tanım.Text = poz.Tanim;
                cins.Text = poz.OlcuBirimi;
                fiyat.Text = poz.BirimFiyat;
            }
        }

        private List<PozBilgisi> ReadDataFromExcel(string excelPath, string aramaMetni)
        {
            List<PozBilgisi> pozlar = new List<PozBilgisi>();

            using (var package = new ExcelPackage(new FileInfo(excelPath)))
            {
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Başlıktan sonraki satırlar
                    {
                        string pozNo = worksheet.Cells[row, 1].Text.Trim();
                        string tanim = worksheet.Cells[row, 2].Text.Trim();
                        string olcuBirimi = worksheet.Cells[row, 3].Text.Trim();
                        string birimFiyat = worksheet.Cells[row, 4].Text.Trim();

                        // Arama metni pozNo, tanım, ölçü birimi veya birim fiyatta varsa ekle
                        if (!string.IsNullOrEmpty(pozNo) &&
                            (pozNo.Contains(aramaMetni, StringComparison.OrdinalIgnoreCase) ||
                             tanim.Contains(aramaMetni, StringComparison.OrdinalIgnoreCase) ||
                             olcuBirimi.Contains(aramaMetni, StringComparison.OrdinalIgnoreCase) ||
                             birimFiyat.Contains(aramaMetni, StringComparison.OrdinalIgnoreCase)))
                        {
                            pozlar.Add(new PozBilgisi
                            {
                                PozNo = pozNo,
                                Tanim = tanim,
                                OlcuBirimi = olcuBirimi,
                                BirimFiyat = birimFiyat
                            });
                        }
                    }
                }
            }

            return pozlar;
        }
        private void listele()
        {

            // SQL Komutunu oluşturuyoruz.
            SqlCommand komut = new SqlCommand("SELECT * FROM dbo.Teklif", bgln.baglantı());

            // Verileri almak için SqlDataAdapter kullanıyoruz.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(komut);

            // Verileri bir DataTable içine dolduruyoruz.
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            // GridControl'e veri bağlama işlemi.
            gridControl1.DataSource = dataTable;
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(pozno.Text) ||
                string.IsNullOrWhiteSpace(tanım.Text) ||
                string.IsNullOrWhiteSpace(cins.Text) ||
                string.IsNullOrWhiteSpace(fiyat.Text) ||
                string.IsNullOrWhiteSpace(miktar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Fiyat ve miktar değerlerinin sayısal olup olmadığını kontrol edin
                if (!decimal.TryParse(fiyat.Text.Trim(), out decimal fiyatDegeri))
                {
                    MessageBox.Show("Fiyat alanına geçerli bir sayı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(miktar.Text.Trim(), out int miktarDegeri))
                {
                    MessageBox.Show("Miktar alanına geçerli bir tam sayı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // PozNo'nun zaten var olup olmadığını kontrol edin
                string kontrolQuery = "SELECT COUNT(*) FROM Teklif WHERE PozNo = @PozNo";
                using (SqlCommand kontrolCommand = new SqlCommand(kontrolQuery, bgln.baglantı()))
                {
                    kontrolCommand.Parameters.AddWithValue("@PozNo", pozno.Text.Trim());

                    int count = (int)kontrolCommand.ExecuteScalar(); // Var olan kayıt sayısını döner

                    if (count > 0)
                    {
                        MessageBox.Show("Bu Poz No zaten mevcut!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Eğer kayıt yoksa, ekleme işlemini yap
                string query = @"
INSERT INTO Teklif (PozNo, Tanım, Cins, Fiyat, Miktar)
VALUES (@PozNo, @Tanim, @Cins, @Fiyat, @Miktar)";

                using (SqlCommand command = new SqlCommand(query, bgln.baglantı()))
                {
                    command.Parameters.AddWithValue("@PozNo", pozno.Text.Trim());
                    command.Parameters.AddWithValue("@Tanim", tanım.Text.Trim());
                    command.Parameters.AddWithValue("@Cins", cins.Text.Trim());
                    command.Parameters.AddWithValue("@Fiyat", fiyatDegeri);
                    command.Parameters.AddWithValue("@Miktar", miktarDegeri);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // TextBox'ları temizle
                pozno.Clear();
                tanım.Clear();
                cins.Clear();
                fiyat.Clear();
                miktar.Clear();

                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                // GridView'de satır olup olmadığını kontrol et
                if (gridView1.RowCount > 0)
                {
                    // Odaklanma işlemi burada yapılabilir
                    int focusedRowHandle = gridView1.FocusedRowHandle;

                    if (focusedRowHandle >= 0)
                    {
                        // Seçilen satırdaki verileri al ve ilgili TextBox'lara ata
                        pozno.Text = gridView1.GetFocusedRowCellValue("PozNo")?.ToString() ?? string.Empty;
                        tanım.Text = gridView1.GetFocusedRowCellValue("Tanım")?.ToString() ?? string.Empty;
                        cins.Text = gridView1.GetFocusedRowCellValue("Cins")?.ToString() ?? string.Empty;
                        fiyat.Text = gridView1.GetFocusedRowCellValue("Fiyat")?.ToString() ?? string.Empty;
                        miktar.Text = gridView1.GetFocusedRowCellValue("Miktar")?.ToString() ?? string.Empty;
                    }
                }
                else
                {
                    // Eğer GridView boşsa, tüm TextBox'ları temizle
                    pozno.Clear();
                    tanım.Clear();
                    cins.Clear();
                    fiyat.Clear();
                    miktar.Clear();
                }
            }
            catch (Exception ex)
            {
                // Hata varsa kullanıcıya bilgi ver
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

            // PozNo TextBox'un boş olup olmadığını kontrol edin
            if (string.IsNullOrWhiteSpace(pozno.Text))
            {
                MessageBox.Show("Lütfen silmek istediğiniz kaydın PozNo bilgisini giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL sorgusu: PozNo'ya göre kaydı sil
                string query = "DELETE FROM Teklif WHERE PozNo = @PozNo";

                using (SqlCommand command = new SqlCommand(query, bgln.baglantı())) // Bağlantı nesnenizi burada kullanın
                {
                    // PozNo parametresini ekle
                    command.Parameters.AddWithValue("@PozNo", pozno.Text.Trim());

                    // Sorguyu çalıştır
                    int rowsAffected = command.ExecuteNonQuery();

                    // Silme işlemi başarılı mı kontrol et
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // TextBox'ı temizle
                        pozno.Clear();

                        // Listeyi güncelle
                        listele(); // Güncellenmiş verileri listeleyen bir metot çağırın
                    }
                    else
                    {
                        MessageBox.Show("Belirtilen PozNo'ya ait bir kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            // TextBox'lardaki alanların boş olup olmadığını kontrol edin (PozNo hariç)
            if (string.IsNullOrWhiteSpace(tanım.Text) ||
                string.IsNullOrWhiteSpace(cins.Text) ||
                string.IsNullOrWhiteSpace(fiyat.Text) ||
                string.IsNullOrWhiteSpace(miktar.Text))
            {
                MessageBox.Show("Lütfen güncellemek için gerekli alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // PozNo'nun boş olmaması gerektiğini kontrol edin
            if (string.IsNullOrWhiteSpace(pozno.Text))
            {
                MessageBox.Show("Güncelleme için bir PozNo giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Fiyat ve miktar değerlerinin sayısal olup olmadığını kontrol edin
                if (!decimal.TryParse(fiyat.Text.Trim(), out decimal fiyatDegeri))
                {
                    MessageBox.Show("Fiyat alanına geçerli bir sayı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(miktar.Text.Trim(), out int miktarDegeri))
                {
                    MessageBox.Show("Miktar alanına geçerli bir tam sayı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // SQL sorgusu: PozNo'ya göre güncelleme
                string query = @"
UPDATE Teklif
SET Tanım = @Tanim,
    Cins = @Cins,
    Fiyat = @Fiyat,
    Miktar = @Miktar
WHERE PozNo = @PozNo";

                using (SqlCommand command = new SqlCommand(query, bgln.baglantı()))
                {
                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@Tanim", tanım.Text.Trim());
                    command.Parameters.AddWithValue("@Cins", cins.Text.Trim());
                    command.Parameters.AddWithValue("@Fiyat", fiyatDegeri);
                    command.Parameters.AddWithValue("@Miktar", miktarDegeri);
                    command.Parameters.AddWithValue("@PozNo", pozno.Text.Trim()); // Güncelleme koşulu için gerekli

                    // Sorguyu çalıştır
                    int rowsAffected = command.ExecuteNonQuery();

                    // Güncelleme işlemi başarılı mı kontrol et
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // TextBox'ları temizle
                        pozno.Clear();
                        tanım.Clear();
                        cins.Clear();
                        fiyat.Clear();
                        miktar.Clear();

                        // Listeyi güncelle
                        listele();
                    }
                    else
                    {
                        MessageBox.Show("Belirtilen PozNo'ya ait bir kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {



            try
            {
                string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TeklifRaporu.pdf");

                // Eğer dosya varsa önce sil
                if (File.Exists(pdfPath))
                {
                    File.Delete(pdfPath);
                }

                // Veritabanından veri çekmek için sorgu
                string query = "SELECT Tanım, Cins, Fiyat, Miktar FROM Teklif"; // PozNo hariç
                DataTable dt = new DataTable();

                using (SqlConnection connection = bgln.baglantı())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt); // DataTable'a verileri doldur
                    }
                }

                // Toplam maliyeti hesaplamak için bir değişken
                decimal toplamMaliyet = 0;

                // PDF belgesi oluştur
                using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    Document doc = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                    doc.Open();

                    // Başlık
                    Paragraph title = new Paragraph("Prokont Yapi ve Mimarlık Ltd. Şti",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);

                    // Alt Başlık
                    Paragraph subTitle = new Paragraph("\nBu bir tekliftir\n\n",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.ITALIC, BaseColor.DARK_GRAY));
                    subTitle.Alignment = Element.ALIGN_CENTER;
                    doc.Add(subTitle);

                    // Tablo oluştur
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);
                        pdfTable.WidthPercentage = 100;

                        // Tablo başlıklarını ekle
                        foreach (DataColumn column in dt.Columns)
                        {
                            PdfPCell headerCell = new PdfPCell(new Phrase(column.ColumnName,
                                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                            headerCell.BackgroundColor = BaseColor.DARK_GRAY;
                            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.AddCell(headerCell);
                        }

                        // Tablo verilerini ekle
                        foreach (DataRow row in dt.Rows)
                        {
                            decimal fiyat = Convert.ToDecimal(row["Fiyat"]);
                            int miktar = Convert.ToInt32(row["Miktar"]);
                            toplamMaliyet += fiyat * miktar; // Toplam maliyeti hesapla

                            foreach (var cellValue in row.ItemArray)
                            {
                                string cellText = cellValue?.ToString() ?? "";
                                PdfPCell dataCell = new PdfPCell(new Phrase(cellText,
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                dataCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfTable.AddCell(dataCell);
                            }
                        }

                        doc.Add(pdfTable);

                        // Toplam maliyeti PDF'e ekle
                        Paragraph toplamMaliyetParagraf = new Paragraph($"\nToplam Maliyet: {toplamMaliyet:C}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                        toplamMaliyetParagraf.Alignment = Element.ALIGN_RIGHT;
                        doc.Add(toplamMaliyetParagraf);
                    }
                    else
                    {
                        Paragraph noData = new Paragraph("Tablo için veri bulunamadı.",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.ITALIC, BaseColor.RED));
                        noData.Alignment = Element.ALIGN_CENTER;
                        doc.Add(noData);
                    }

                    doc.Close();
                }

                // PDF dosyasını kontrol et
                if (File.Exists(pdfPath))
                {
                    // Kullanıcıya PDF dosyasını açıp açmayacağını sor
                    DialogResult result = MessageBox.Show($"PDF başarıyla oluşturuldu: {pdfPath}\n\nPDF dosyasını açmak ister misiniz?",
                        "PDF Oluşturuldu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = pdfPath,
                            UseShellExecute = true
                        });
                    }
                }
                else
                {
                    MessageBox.Show("PDF oluşturulamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"PDF oluşturma sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                pozno.Clear();
                tanım.Clear();
                cins.Clear();
                fiyat.Clear();
                miktar.Clear();
                // Kullanıcıdan silme işlemi için onay al
                DialogResult result = MessageBox.Show("Teklif tablosundaki tüm veriler silinecek. Emin misiniz?",
                    "Tüm Verileri Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // SQL sorgusu: Tüm verileri sil
                    string query = "DELETE FROM Teklif";


                        using (SqlCommand command = new SqlCommand(query, bgln.baglantı()))
                        {
                            
                            command.ExecuteNonQuery(); // Sorguyu çalıştır
                        }
                    

                    MessageBox.Show("Tüm veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Listeyi güncelle
                    listele(); // Güncel verileri listeleyen metodunuz
                }
                else
                {
                    MessageBox.Show("Silme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

