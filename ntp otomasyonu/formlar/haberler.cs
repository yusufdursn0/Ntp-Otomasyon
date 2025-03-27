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
using System.Xml;

namespace ntp_otomasyonu.formlar
{
    public partial class haberler : Form
    {
        public haberler()
        {
            InitializeComponent();
            LoadNews();
        }

        private void haberler_Load(object sender, EventArgs e)
        {

        }
        private async Task LoadNews()
        {
            try
            {
                // RSS URL'si
                string rssUrl = "https://www.hurriyet.com.tr/rss/anasayfa"; // Hürriyet Ana Sayfa RSS

                // Haberleri al
                var news = await GetNewsFromRssAsync(rssUrl);

                // Dinamik paneller oluştur
                CreateNewsPanels(news);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Haberler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<List<(string Title, string Description, string Link)>> GetNewsFromRssAsync(string rssUrl)
        {
            List<(string Title, string Description, string Link)> newsList = new List<(string Title, string Description, string Link)>();

            // HttpClient ile RSS içeriğini çek
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(rssUrl);

                // XML verisini işle
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(response);

                // Haber başlıkları, açıklamalar ve linkleri oku
                XmlNodeList itemNodes = xmlDoc.SelectNodes("//item");
                foreach (XmlNode itemNode in itemNodes)
                {
                    string title = itemNode["title"]?.InnerText;
                    string description = itemNode["description"]?.InnerText;
                    string link = itemNode["link"]?.InnerText; // Haber linki

                    // Açıklamaları kontrol et (en az 20 karakter uzunluğunda olmalı)
                    if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(description) && description.Length >  100 && !string.IsNullOrEmpty(link))
                    {
                        newsList.Add((title, description, link));
                    }
                }
            }

            return newsList;
        }


        private void CreateNewsPanels(List<(string Title, string Description, string Link)> news)
        {
            int panelWidth = 450; // Panel genişliği
            int panelHeight = 250; // Panel yüksekliği
            int margin = 20; // Paneller arası boşluk
            int columns = 3; // Bir sırada 3 panel olacak
            int xOffset = margin; // İlk panelin yatay başlangıç pozisyonu
            int yOffset = margin; // İlk panelin dikey başlangıç pozisyonu

            for (int i = 0; i < news.Count; i++)
            {
                string link = news[i].Link; // Haber linki

                // Panel oluştur
                Panel panel = new Panel
                {
                    BackColor = Color.Red,
                    Size = new Size(panelWidth, panelHeight),
                    Location = new Point(xOffset, yOffset),
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand // Tıklanabilir göstergesi
                };

                // Başlık için Label oluştur
                Label titleLabel = new Label
                {
                    Text = news[i].Title,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    AutoSize = false,
                    Size = new Size(panelWidth - 20, 40), // Başlık için boyut
                    Location = new Point(10, 10), // Panelin üst kısmında yer alır
                    TextAlign = ContentAlignment.TopCenter,
                    Cursor = Cursors.Hand // Tıklanabilir göstergesi
                };

                // Açıklama için Label oluştur
                Label descriptionLabel = new Label
                {
                    Text = news[i].Description,
                    ForeColor = Color.WhiteSmoke,
                    Font = new Font("Arial", 8, FontStyle.Regular),
                    AutoSize = false,
                    Size = new Size(panelWidth - 20, panelHeight - 60), // Açıklama için boyut
                    Location = new Point(10, 60), // Başlığın altında başlar
                    TextAlign = ContentAlignment.TopLeft,
                    Cursor = Cursors.Hand // Tıklanabilir göstergesi
                };

                // Panel ve içindeki bileşenler için ortak tıklama olayı
                void OpenLink(object sender, EventArgs e)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = link,
                            UseShellExecute = true // Varsayılan tarayıcıda aç
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Link açılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Tıklama olaylarını ekle
                panel.Click += OpenLink;
                titleLabel.Click += OpenLink;
                descriptionLabel.Click += OpenLink;

                // Label'leri panele ekle
                panel.Controls.Add(titleLabel);
                panel.Controls.Add(descriptionLabel);

                // Paneli forma ekle
                this.Controls.Add(panel);

                // Yatay konumu güncelle
                xOffset += panelWidth + margin;

                // Bir sırada 3 panel olunca bir alt sıraya geç
                if ((i + 1) % columns == 0)
                {
                    xOffset = margin; // Yatay konumu sıfırla
                    yOffset += panelHeight + margin; // Dikey konumu artır
                }
            }
        }



    }
}
