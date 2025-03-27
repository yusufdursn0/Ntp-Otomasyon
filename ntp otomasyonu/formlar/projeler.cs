using DocumentFormat.OpenXml.Spreadsheet;
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

namespace ntp_otomasyonu.formlar
{
    public partial class projeler : Form
    {
        sqlbaglantısı bgln = new sqlbaglantısı();
        public projeler()
        {
            InitializeComponent();
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

        private void simpleButton2_Click(object sender, EventArgs e)
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

        private void btnekle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtustalık.Text) ||
                string.IsNullOrWhiteSpace(şirket.Text) ||  // Şirket alanı kontrolü
                string.IsNullOrWhiteSpace(durum.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (durum.Text != "Devam" && durum.Text != "Bitti")
            {
                MessageBox.Show("Proje durumu sadece 'Devam' veya 'Bitti' olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {


                string query = @"
                INSERT INTO Projeler (ProjeAdi, ProjeBaslangicTarihi, ProjeBitisTarihi, ProjeDurumu, Sirket)
                VALUES (@ProjeAdi, @ProjeBaslangicTarihi, @ProjeBitisTarihi, @ProjeDurumu, @Sirket)";

                using (SqlCommand command = new SqlCommand(query, bgln.baglantı()))
                {
                    command.Parameters.AddWithValue("@ProjeAdi", txtustalık.Text.Trim());
                    command.Parameters.AddWithValue("@ProjeBaslangicTarihi", DateTime.Now); // Başlangıç tarihi
                    command.Parameters.AddWithValue("@ProjeBitisTarihi",
                        durum.Text == "Bitti" ? (object)DateTime.Now : DBNull.Value); // Bitiş tarihi
                    command.Parameters.AddWithValue("@ProjeDurumu", durum.Text.Trim());
                    command.Parameters.AddWithValue("@Sirket", şirket.Text.Trim()); // Şirket bilgisi

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Proje başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // TextBox'ları temizle
                txtustalık.Clear();
                şirket.Clear();
                durum.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            simpleButton2_Click(sender, e);



        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                // Seçilen satırdaki verileri TextBox'lara dolduruyoruz.
                txtıd.Text = gridView1.GetFocusedRowCellValue("ProjeID").ToString();
                txtustalık.Text = gridView1.GetFocusedRowCellValue("ProjeAdi").ToString();
                şirket.Text = gridView1.GetFocusedRowCellValue("Sirket").ToString();
                durum.Text = gridView1.GetFocusedRowCellValue("ProjeDurumu").ToString();





            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                // Önce TextBox'tan ID'yi alıyoruz.
                if (!string.IsNullOrEmpty(txtıd.Text))
                {
                    int id = Convert.ToInt32(txtıd.Text);


                    // Silme işlemi için SQL komutunu oluşturuyoruz.
                    SqlCommand komut = new SqlCommand("DELETE FROM dbo.Projeler WHERE ProjeID = @P1", bgln.baglantı());
                    komut.Parameters.AddWithValue("@P1", id);

                    // Komutu çalıştırıyoruz.
                    int result = komut.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // İsterseniz burada GridControl'ü yenileyebilirsiniz
                        simpleButton2_Click(sender, new EventArgs());

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
                simpleButton2_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

            // Proje ID'yi al
            int projeId;
            if (!int.TryParse(txtıd.Text, out projeId))
            {
                MessageBox.Show("Geçerli bir Proje ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Güncellenecek değerleri al
            string projeAdi = txtustalık.Text.Trim();
            string sirket = şirket.Text.Trim();
            string yeniProjeDurumu = durum.SelectedItem?.ToString();

            try
            {



                // Mevcut proje durumunu öğren
                string selectQuery = "SELECT ProjeDurumu FROM Projeler WHERE ProjeId = @ProjeId";
                string mevcutProjeDurumu = null;

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, bgln.baglantı()))
                {
                    selectCommand.Parameters.AddWithValue("@ProjeId", projeId);
                    object result = selectCommand.ExecuteScalar();
                    mevcutProjeDurumu = result?.ToString();
                }

                if (mevcutProjeDurumu == null)
                {
                    MessageBox.Show("Belirtilen ID ile proje bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Güncelleme sorgusunu oluştur
                string updateQuery = "UPDATE Projeler SET ProjeAdi = @ProjeAdi, Sirket = @Sirket, ProjeDurumu = @ProjeDurumu";

                // Eğer proje durumu "Devam"dan "Bitti"ye geçiyorsa, ProjeBitisTarihi'ni ekle
                if (mevcutProjeDurumu == "Devam" && yeniProjeDurumu == "Bitti")
                {
                    updateQuery += ", ProjeBitisTarihi = @ProjeBitisTarihi";
                }

                // Eğer proje durumu "Bitti"den "Devam"a geçiyorsa, ProjeBitisTarihi'ni sıfırla
                if (mevcutProjeDurumu == "Bitti" && yeniProjeDurumu == "Devam")
                {
                    updateQuery += ", ProjeBitisTarihi = NULL";
                }

                updateQuery += " WHERE ProjeId = @ProjeId";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, bgln.baglantı()))
                {
                    updateCommand.Parameters.AddWithValue("@ProjeId", projeId);
                    updateCommand.Parameters.AddWithValue("@ProjeAdi", projeAdi);
                    updateCommand.Parameters.AddWithValue("@Sirket", sirket);
                    updateCommand.Parameters.AddWithValue("@ProjeDurumu", yeniProjeDurumu);

                    if (mevcutProjeDurumu == "Devam" && yeniProjeDurumu == "Bitti")
                    {
                        updateCommand.Parameters.AddWithValue("@ProjeBitisTarihi", DateTime.Now);
                    }

                    // Sorguyu çalıştır
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Proje başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız. Belirtilen ID ile proje bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                simpleButton2_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtustalık.Clear();
            txtıd.Clear();
            durum.Clear();
            şirket.Clear();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
