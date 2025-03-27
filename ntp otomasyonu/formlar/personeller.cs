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
using System.Data.SqlClient;

namespace ntp_otomasyonu.formlar
{
    public partial class personeller : Form
    {
        sqlbaglantısı bgln = new sqlbaglantısı();
        public personeller()
        {

            InitializeComponent();
            simpleButton2_Click(this, new EventArgs());

            güncel();


        }
        private void güncel()
        {

            try
            {


                // Ustalık tablosundaki ID ve UstalıkAdı sütunlarını çekiyoruz.
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT UstalıkId, UstalıkAdı FROM dbo.Ustalıklar", bgln.baglantı());

                // Verileri bir DataTable içine yüklüyoruz.
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // LookupEdit için veri kaynağını ayarlıyoruz.
                ustalık.Properties.DataSource = dataTable;

                // LookupEdit'te görünen ve geri dönen sütunları belirliyoruz.
                ustalık.Properties.DisplayMember = "UstalıkAdı"; // Kullanıcının göreceği sütun.
                ustalık.Properties.ValueMember = "UstalıkId"; // Seçildiğinde alacağınız ID.

                // Bağlantıyı kapatıyoruz.

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // SQL Komutunu oluşturuyoruz.
            SqlCommand komut = new SqlCommand("SELECT * FROM dbo.Personel", bgln.baglantı());

            // Verileri almak için SqlDataAdapter kullanıyoruz.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(komut);

            // Verileri bir DataTable içine dolduruyoruz.
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            // GridControl'e veri bağlama işlemi.
            gridControl1.DataSource = dataTable;

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            try
            {
                // LookupEdit'ten seçilen ID değerini alıyoruz.
                var ustalikId = ustalık.EditValue; // Seçili değer (ID).

                if (ustalikId == null)
                {
                    MessageBox.Show("Lütfen bir ustalık seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Diğer TextBox verilerini alıyoruz.
                string adSoyad = ad.Text;
                string telefon = tel.Text;
                string eposta = mail.Text;
                string yev=textEdit1.Text;



                // SQL ekleme komutunu oluşturuyoruz.
                SqlCommand komut = new SqlCommand(
                    "INSERT INTO dbo.Personel (AdSoyad, Telefon, Eposta, Ustalık ,Yevmiye) VALUES (@AdSoyad, @Telefon, @Eposta, @Ustalık, @Yevmiye)",
                    bgln.baglantı()
                );
                komut.Parameters.AddWithValue("@AdSoyad", adSoyad);
                komut.Parameters.AddWithValue("@Telefon", telefon);
                komut.Parameters.AddWithValue("@Eposta", eposta);
                komut.Parameters.AddWithValue("@Ustalık", ustalikId);
                komut.Parameters.AddWithValue("@Yevmiye", yev);

                // Komutu çalıştırıyoruz.
                komut.ExecuteNonQuery();

                // Bağlantıyı kapatıyoruz.


                MessageBox.Show("Kayıt başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Formu temizleme ve GridControl'ü yenileme.
                simpleButton2_Click(sender, e);
                simpleButton5_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                // Önce TextBox'tan ID'yi alıyoruz.
                if (!string.IsNullOrEmpty(ıd.Text))
                {
                    int id = Convert.ToInt32(ıd.Text);


                    // Silme işlemi için SQL komutunu oluşturuyoruz.
                    SqlCommand komut = new SqlCommand("DELETE FROM dbo.Personel WHERE PersonelID = @P1", bgln.baglantı());
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
                simpleButton5_Click(sender, e);
                simpleButton2_Click(sender, e);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            try
            {
                // Seçilen satırdaki verileri TextBox'lara dolduruyoruz.
                ıd.Text = gridView1.GetFocusedRowCellValue("PersonelID").ToString();
                ad.Text = gridView1.GetFocusedRowCellValue("AdSoyad").ToString();
                tel.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
                mail.Text = gridView1.GetFocusedRowCellValue("Eposta").ToString();
                textEdit1.Text= gridView1.GetFocusedRowCellValue("Yevmiye").ToString() ;

                // Ustalık ID'sini alıyoruz.
                string ustalikId = gridView1.GetFocusedRowCellValue("Ustalık").ToString();

                // Ustalık adını getirmek için veritabanı sorgusu yapıyoruz.


                SqlCommand komut = new SqlCommand("SELECT UstalıkAdı FROM dbo.Ustalıklar WHERE UstalıkId = @ID", bgln.baglantı());
                komut.Parameters.AddWithValue("@ID", ustalikId);

                // Ustalık adını okuyoruz.
                SqlDataReader reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    ustalık.Text = reader["UstalıkAdı"].ToString();
                }
                else
                {
                    ustalık.Text = "Bilinmiyor"; // Eğer ID eşleşmezse bir mesaj atanır.
                }

                reader.Close();
                güncel();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            try
            {
                // ID'nin boş olup olmadığını kontrol ediyoruz.
                if (string.IsNullOrEmpty(ıd.Text))
                {
                    MessageBox.Show("Lütfen bir ID giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // TextBox'lardan güncellenecek bilgileri alıyoruz.
                int personelId = Convert.ToInt32(ıd.Text); // Güncellenecek personelin ID'si
                string adSoyad = ad.Text;
                string telefon = tel.Text;
                string eposta = mail.Text;

                // LookupEdit'ten seçilen Ustalık ID'sini alıyoruz.
                var ustalikId = ustalık.EditValue; // Seçili değer (ID).

                if (ustalikId == null)
                {
                    MessageBox.Show("Lütfen bir ustalık seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                // Güncelleme komutunu oluşturuyoruz.
                SqlCommand komut = new SqlCommand(
                    "UPDATE dbo.Personel SET AdSoyad = @AdSoyad, Telefon = @Telefon, Eposta = @Eposta, Ustalık = @Ustalık WHERE PersonelID = @PersonelID",
                    bgln.baglantı()
                );
                komut.Parameters.AddWithValue("@AdSoyad", adSoyad);
                komut.Parameters.AddWithValue("@Telefon", telefon);
                komut.Parameters.AddWithValue("@Eposta", eposta);
                komut.Parameters.AddWithValue("@Ustalık", ustalikId); // Ustalık ID'sini ekliyoruz.
                komut.Parameters.AddWithValue("@PersonelID", personelId);

                // Komutu çalıştırıyoruz.
                int result = komut.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Kayıt başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // GridControl'ü yenilemek için listeleme metodu çağırıyoruz.
                    simpleButton2_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Güncelleme başarısız oldu. Bu ID ile bir kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                simpleButton5_Click(sender, e);
                simpleButton2_Click(sender, e);

                // Bağlantıyı kapatıyoruz.

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            try
            {
                // TextBox'ları temizliyoruz.
                ıd.Text = string.Empty;
                ad.Text = string.Empty;
                tel.Text = string.Empty;
                mail.Text = string.Empty;

                // LookupEdit'i temizliyoruz.
                ustalık.EditValue = null;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
