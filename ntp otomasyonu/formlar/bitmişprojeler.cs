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

    public partial class bitmişprojeler : Form
    {
        sqlbaglantısı bgln = new sqlbaglantısı();
        public bitmişprojeler()
        {
            InitializeComponent();
            ListeleProjeler();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        private void ListeleProjeler()
        {
            try
            {



                // Bitti olan projeleri çek
                string queryBitti = "SELECT * FROM Projeler WHERE ProjeDurumu = 'Bitti'";
                DataTable dataTableBitti = new DataTable();

                using (SqlCommand command = new SqlCommand(queryBitti, bgln.baglantı()))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTableBitti);
                }

                // Devam eden projeleri çek
                string queryDevam = "SELECT * FROM Projeler WHERE ProjeDurumu = 'Devam'";
                DataTable dataTableDevam = new DataTable();

                using (SqlCommand command = new SqlCommand(queryDevam, bgln.baglantı()))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTableDevam);
                }

                // Verileri GridControl'lere bağla
                gridControl1.DataSource = dataTableBitti; // Bitti olan projeler
                gridControl2.DataSource = dataTableDevam; // Devam eden projeler


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Projeler listelenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bitmişprojeler_Load(object sender, EventArgs e)
        {

        }
    }
}
