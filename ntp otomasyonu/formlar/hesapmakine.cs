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
    public partial class hesapmakine : Form
    {
        sqlbaglantısı bgln = new sqlbaglantısı();
        public hesapmakine()
        {
            InitializeComponent();
            personel();
            personelyövmiyesırala();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
                string personelID = textEdit1.Text;
                string odenecekTutar = textEdit2.Text;

                string query = @"
    DECLARE @PersonelID INT;
    DECLARE @OdenecekTutar DECIMAL(15, 2);
    DECLARE @ToplamAlacagiPara DECIMAL(15, 2);
    DECLARE @KalanOdeme DECIMAL(15, 2);

    SET @PersonelID = @PersonelIDInput;
    SET @OdenecekTutar = @OdenecekTutarInput;

    SELECT @ToplamAlacagiPara = COALESCE(COUNT(P.Tarih) * Per.Yevmiye, 0)
    FROM Puantaj P
    JOIN Personel Per ON P.PersonelID = Per.PersonelID
    WHERE P.PersonelID = @PersonelID
    GROUP BY Per.Yevmiye;

    SET @KalanOdeme = @ToplamAlacagiPara - (
        SELECT COALESCE(SUM(ToplamOdenen), 0)
        FROM PersonelOdeme
        WHERE PersonelID = @PersonelID
    );

    IF EXISTS (SELECT 1 FROM PersonelOdeme WHERE PersonelID = @PersonelID)
    BEGIN
        UPDATE PersonelOdeme
        SET ToplamOdenen = ToplamOdenen + @OdenecekTutar,
            KalanOdeme = @ToplamAlacagiPara - (ToplamOdenen + @OdenecekTutar)
        WHERE PersonelID = @PersonelID;
    END
    ELSE
    BEGIN
        INSERT INTO PersonelOdeme (PersonelID, ToplamOdenen, KalanOdeme)
        VALUES (@PersonelID, @OdenecekTutar, @ToplamAlacagiPara - @OdenecekTutar);
    END";




            SqlCommand cmd = new SqlCommand(query, bgln.baglantı());
                    cmd.Parameters.AddWithValue("@PersonelIDInput", personelID);
                    cmd.Parameters.AddWithValue("@OdenecekTutarInput", odenecekTutar);

                    
                    cmd.ExecuteNonQuery();
                    
                
            



            personel();   

        }
        private void personelyövmiyesırala()
        {
            // SQL Komutunu oluşturuyoruz.
            SqlCommand komut = new SqlCommand("SELECT * FROM dbo.Personel", bgln.baglantı());

            // Verileri almak için SqlDataAdapter kullanıyoruz.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(komut);

            // Verileri bir DataTable içine dolduruyoruz.
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            // GridControl'e veri bağlama işlemi.
            gridControl3.DataSource = dataTable;
        }
        private void personel()
        {
            // SQL Komutunu oluşturuyoruz.
            SqlCommand komut = new SqlCommand("SELECT * FROM dbo.PersonelOdeme", bgln.baglantı());

            // Verileri almak için SqlDataAdapter kullanıyoruz.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(komut);

            // Verileri bir DataTable içine dolduruyoruz.
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            // GridControl'e veri bağlama işlemi.
            gridControl1.DataSource = dataTable;
        }
        

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            textEdit1.Text = gridView3.GetFocusedRowCellValue("PersonelID").ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
              
            personel();
        }
    }
}
