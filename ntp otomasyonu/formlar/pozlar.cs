using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Data.SqlClient;
using OfficeOpenXml;

using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using ClosedXML.Excel;
namespace ntp_otomasyonu.formlar
{


    public partial class pozlar : Form
    {
        sqlbaglantısı bgln = new sqlbaglantısı();

        public pozlar()
        {
            InitializeComponent();
            listele();


        }


        private void pozlar_Load(object sender, EventArgs e)
        {


        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            string excelPath = @"C:\Users\serhat\Downloads\birim_fiyat_temizlenmis.xlsx";

            try
            {
                // Arama metnini al
                string aramaMetni = ara.Text.Trim();

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
                pozıd.Text = poz.PozNo;
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
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // TextBox'lardan gerekli bilgileri al
                string projeId = ıd.Text.Trim();
                string pozId = pozıd.Text.Trim();
                string birimFiyatText = fiyat.Text.Trim();
                string miktarText = miko.Text.Trim();

                // Boş alanlar için kontrol
                if (string.IsNullOrWhiteSpace(projeId) || string.IsNullOrWhiteSpace(pozId) ||
                    string.IsNullOrWhiteSpace(birimFiyatText) || string.IsNullOrWhiteSpace(miktarText))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verileri uygun formata çevir
                if (!decimal.TryParse(birimFiyatText, out decimal birimFiyat))
                {
                    MessageBox.Show("Birim fiyat geçerli bir sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(miktarText, out decimal miktar))
                {
                    MessageBox.Show("Miktar geçerli bir sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Veritabanına kaydı ekle
                string query = "INSERT INTO ProjeIcerikleri (ProjeId, PozId, BirimFiyat, Miktar) " +
                               "VALUES (@ProjeId, @PozId, @BirimFiyat, @Miktar)";

                using (SqlCommand command = new SqlCommand(query, bgln.baglantı()))
                {
                    command.Parameters.AddWithValue("@ProjeId", projeId);
                    command.Parameters.AddWithValue("@PozId", pozId);
                    command.Parameters.AddWithValue("@BirimFiyat", birimFiyat);
                    command.Parameters.AddWithValue("@Miktar", miktar);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Proje maliyetini güncelle
                        decimal toplamFiyat = birimFiyat * miktar;
                        string updateQuery = "UPDATE Projeler SET ProjeMaliyeti = ISNULL(ProjeMaliyeti, 0) + @ToplamFiyat WHERE ProjeID = @ProjeID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, bgln.baglantı()))
                        {
                            updateCommand.Parameters.AddWithValue("@ToplamFiyat", toplamFiyat);
                            updateCommand.Parameters.AddWithValue("@ProjeID", projeId);

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kayıt eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                listele();
                ListeleButonu(); // Listeyi güncelle
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        private void listele()
        {

            // SQL Komutunu oluşturuyoruz.
            SqlCommand komut = new SqlCommand("SELECT * FROM dbo.Projeler", bgln.baglantı());

            // Verileri almak için SqlDataAdapter kullanıyoruz.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(komut);

            // Verileri bir DataTable içine dolduruyoruz.
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            // GridControl'e veri bağlama işlemi.
            gridControl1.DataSource = dataTable;
        }
        private void içeriklerilistele()
        {
            // SQL Komutunu oluşturuyoruz.
            SqlCommand komut = new SqlCommand("SELECT * FROM dbo.ProjeIcerikleri", bgln.baglantı());

            // Verileri almak için SqlDataAdapter kullanıyoruz.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(komut);

            // Verileri bir DataTable içine dolduruyoruz.
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            // GridControl'e veri bağlama işlemi.
            gridControl2.DataSource = dataTable;
        }
        private void ListeleButonu()
        {
            try
            {
                // Proje ID TextBox'undan değeri alıyoruz.
                string projeId = ıd.Text.Trim();

                // Eğer Proje ID boşsa kullanıcıya uyarı göster ve işlemi durdur
                if (string.IsNullOrWhiteSpace(projeId))
                {
                    MessageBox.Show("Lütfen geçerli bir Proje ID giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // SQL Komutunu oluşturuyoruz.
                SqlCommand komut = new SqlCommand("SELECT * FROM dbo.ProjeIcerikleri WHERE ProjeId = @ProjeId", bgln.baglantı());
                komut.Parameters.AddWithValue("@ProjeId", projeId); // Proje ID parametresi ekleniyor

                // Verileri almak için SqlDataAdapter kullanıyoruz.
                SqlDataAdapter dataAdapter = new SqlDataAdapter(komut);

                // Verileri bir DataTable içine dolduruyoruz.
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Eğer eşleşen bir kayıt yoksa kullanıcıya bilgi göster.
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Belirtilen Proje ID'ye ait bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // GridControl'e veri bağlama işlemi.
                gridControl2.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler getirilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ıd.Text = gridView1.GetFocusedRowCellValue("ProjeID").ToString();

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            pozıd.Text = gridView2.GetFocusedRowCellValue("PozId").ToString();
            içerik.Text = gridView2.GetFocusedRowCellValue("Id").ToString();
            fiyat.Text = gridView2.GetFocusedRowCellValue("BirimFiyat").ToString();
            miko.Text = gridView2.GetFocusedRowCellValue("Miktar").ToString();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            // Önce TextBox'tan ID'yi alıyoruz.
            if (!string.IsNullOrEmpty(içerik.Text))
            {
                int id = Convert.ToInt32(içerik.Text);


                // Silme işlemi için SQL komutunu oluşturuyoruz.
                SqlCommand komut = new SqlCommand("DELETE FROM dbo.ProjeIcerikleri WHERE Id = @P1", bgln.baglantı());
                komut.Parameters.AddWithValue("@P1", id);

                // Komutu çalıştırıyoruz.
                int result = komut.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // İsterseniz burada GridControl'ü yenileyebilirsiniz
                    

                }
                else
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ID giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListeleButonu();
        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            ListeleButonu();
        }
    }
}

public class PozBilgisi
{
    public string PozNo { get; set; } // Poz numarası
    public string Tanim { get; set; } // Tanım
    public string OlcuBirimi { get; set; } // Ölçü birimi
    public string BirimFiyat { get; set; } // Birim fiyat
}
public class PozBilgisiMap : ClassMap<PozBilgisi>
{
    public PozBilgisiMap()
    {
        Map(m => m.PozNo).Name("Poz No"); // CSV'deki "Poz No" başlığıyla eşleşir
        Map(m => m.Tanim).Name("Tanımı"); // CSV'deki "Tanımı" başlığıyla eşleşir
        Map(m => m.OlcuBirimi).Name("Ölçü Birimi"); // CSV'deki "Ölçü Birimi" başlığıyla eşleşir
        Map(m => m.BirimFiyat).Name("Birim Fiyat TL"); // CSV'deki "Birim Fiyat TL" başlığıyla eşleşir
    }
}

