using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
namespace ntp_otomasyonu.formlar
{
    public partial class kurlar : Form
    {
        public kurlar()
        {
            InitializeComponent();

        }

        private void kurlar_Load(object sender, EventArgs e)
        {
            LoadExchangeRates();
            

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void LoadExchangeRates()
        {
            try
            {
                // TCMB Döviz Kurları XML URL'si
                string url = "https://www.tcmb.gov.tr/kurlar/today.xml";

                // XML verisini çek
                XmlDocument xmlDoc = new XmlDocument();
                using (WebClient client = new WebClient())
                {
                    string xmlData = client.DownloadString(url);
                    xmlDoc.LoadXml(xmlData);
                }

                // DataTable oluştur
                DataTable dt = new DataTable();
                dt.Columns.Add("Döviz Türü", typeof(string));
                dt.Columns.Add("Alış (TL)", typeof(string));
                dt.Columns.Add("Satış (TL)", typeof(string));

                // Döviz verilerini çek
                XmlNodeList currencyNodes = xmlDoc.SelectNodes("//Currency");
                foreach (XmlNode currencyNode in currencyNodes)
                {
                    string currencyCode = currencyNode.Attributes["Kod"]?.InnerText;
                    string forexBuying = currencyNode["ForexBuying"]?.InnerText;
                    string forexSelling = currencyNode["ForexSelling"]?.InnerText;

                    // Sadece dövizleri tabloya ekle
                    if (!string.IsNullOrEmpty(currencyCode))
                    {
                        dt.Rows.Add(currencyCode, forexBuying, forexSelling);
                    }
                }

                // GridControl'e bağla
                gridControl1.DataSource = dt;

                // Grid görünüm ayarları
                gridView1.OptionsView.ShowGroupPanel = false; // Grup paneli kapalı
                gridView1.OptionsView.ColumnAutoWidth = true; // Otomatik genişlik
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Döviz fiyatları yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                
                
                    if (e.RowHandle % 2 == 0)
                        e.Appearance.BackColor = Color.MistyRose;
                    else
                        e.Appearance.BackColor = Color.LightCoral;
                
            }
        }
    }
}
