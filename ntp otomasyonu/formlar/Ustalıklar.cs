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
using DevExpress.Mvvm;

namespace ntp_otomasyonu.formlar
{
    public partial class Ustalıklar : Form
    {
        public Ustalıklar()
        {
            InitializeComponent();
            simpleButton2_Click(this, new EventArgs());
        }
       sqlbaglantısı bgln = new sqlbaglantısı();

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into dbo.Ustalıklar(UstalıkAdı) values (@P1)", bgln.baglantı());
            komut.Parameters.AddWithValue("@P1", txtustalık.Text);
            komut.ExecuteNonQuery();
            bgln.baglantı().Close();
            MessageBox.Show("Usta Sisteme  Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            simpleButton2_Click(this, new EventArgs());
            simpleButton1_Click(this, new EventArgs());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {


            // SQL Komutunu oluşturuyoruz.
            SqlCommand komut = new SqlCommand("SELECT * FROM dbo.Ustalıklar", bgln.baglantı());

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
                // Önce TextBox'tan ID'yi alıyoruz.
                if (!string.IsNullOrEmpty(txtıd.Text))
                {
                    int id = Convert.ToInt32(txtıd.Text);


                    // Silme işlemi için SQL komutunu oluşturuyoruz.
                    SqlCommand komut = new SqlCommand("DELETE FROM dbo.Ustalıklar WHERE UstalıkID = @P1", bgln.baglantı());
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
                simpleButton1_Click(sender, new EventArgs());
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
                // Öncelikle ID ve Ustalık Adı alanlarının boş olmadığını kontrol ediyoruz.
                if (!string.IsNullOrEmpty(txtıd.Text) && !string.IsNullOrEmpty(txtustalık.Text))
                {
                    int id = Convert.ToInt32(txtıd.Text); // ID'yi alıyoruz.
                    string ustalikAdi = txtustalık.Text; // Yeni Ustalık Adı değerini alıyoruz.



                    // SQL komutunu oluşturuyoruz.
                    SqlCommand komut = new SqlCommand("UPDATE dbo.Ustalıklar SET UstalıkAdı = @P1 WHERE UstalıkID = @P2", bgln.baglantı());
                    komut.Parameters.AddWithValue("@P1", ustalikAdi); // Yeni Ustalık Adı
                    komut.Parameters.AddWithValue("@P2", id); // ID

                    // Komutu çalıştırıyoruz.
                    int result = komut.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // İsterseniz GridControl'ü yenileyebilirsiniz.
                        simpleButton2_Click(sender, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir ID ve Ustalık Adı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                simpleButton1_Click(sender, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtıd.Text = gridView1.GetFocusedRowCellValue("UstalıkID").ToString();
            txtustalık.Text = gridView1.GetFocusedRowCellValue("UstalıkAdı").ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            try
            {
                // Sadece belirli TextBox'ları temizler.
                txtıd.Text = string.Empty;
                txtustalık.Text = string.Empty;

                ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
