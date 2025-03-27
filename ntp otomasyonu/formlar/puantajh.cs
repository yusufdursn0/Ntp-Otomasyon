using DevExpress.XtraEditors.Repository;
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
    public partial class puantajh : Form
    {
        sqlbaglantısı bgln = new sqlbaglantısı();
        public puantajh()
        {
            InitializeComponent();
            LoadPersonelData();
            dateEdit1.EditValueChanged += dateEdit1_EditValueChanged;
            gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
        }
        private void LoadPersonelData()
        {
            try
            {


                SqlCommand komut = new SqlCommand("SELECT PersonelID, AdSoyad FROM Personel", bgln.baglantı());
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // GridControl'e veri bağlama.
                gridControl1.DataSource = dataTable;

                // GridView'e erişim
                DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)gridControl1.MainView;

                // Checkbox sütununu kontrol ediyoruz.
                if (gridView.Columns.ColumnByFieldName("Secim") == null)
                {
                    // Checkbox sütununu tanımlıyoruz.
                    DevExpress.XtraGrid.Columns.GridColumn checkboxColumn = new DevExpress.XtraGrid.Columns.GridColumn
                    {
                        Caption = "Seç",
                        FieldName = "Secim", // Sütunun adı
                        Visible = true,
                        UnboundType = DevExpress.Data.UnboundColumnType.Boolean // Boolean (true/false) değerler
                    };

                    // Checkbox sütunu GridView'e ekliyoruz.
                    gridView.Columns.Add(checkboxColumn);

                    // RepositoryItemCheckEdit ile Checkbox işlevselliğini sağlıyoruz.
                    RepositoryItemCheckEdit checkEdit = new RepositoryItemCheckEdit
                    {
                        ValueChecked = true, // Checkbox seçili değer
                        ValueUnchecked = false, // Checkbox seçilmemiş değer
                        AllowGrayed = false, // Kısmi seçim (gri alan) devre dışı
                        CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard // Standart checkbox stili
                    };

                    // RepositoryItem'ı GridControl'e ekliyoruz ve Checkbox sütununa bağlıyoruz.
                    gridControl1.RepositoryItems.Add(checkEdit);
                    checkboxColumn.ColumnEdit = checkEdit;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            
                try
                {
                    // Seçilen tarihi alıyoruz.
                    DateTime selectedDate = dateEdit1.DateTime;

                    if (selectedDate == null || selectedDate == DateTime.MinValue)
                    {
                        MessageBox.Show("Lütfen bir tarih seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        int personelID = Convert.ToInt32(gridView1.GetRowCellValue(i, "PersonelID"));
                        bool isChecked = Convert.ToBoolean(gridView1.GetRowCellValue(i, "Secim"));

                        // Mevcut kaydı kontrol ediyoruz.
                        SqlCommand kontrolKomut = new SqlCommand(
                            "SELECT COUNT(*) FROM Puantaj WHERE Tarih = @Tarih AND PersonelID = @PersonelID",
                            bgln.baglantı()
                        );
                        kontrolKomut.Parameters.AddWithValue("@Tarih", selectedDate);
                        kontrolKomut.Parameters.AddWithValue("@PersonelID", personelID);

                        int kayitSayisi = (int)kontrolKomut.ExecuteScalar();

                        if (kayitSayisi > 0 && !isChecked)
                        {
                            // Eğer kayıt varsa ve Checkbox işaretli değilse, kaydı siliyoruz.
                            SqlCommand silKomut = new SqlCommand(
                                "DELETE FROM Puantaj WHERE Tarih = @Tarih AND PersonelID = @PersonelID",
                                bgln.baglantı()
                            );
                            silKomut.Parameters.AddWithValue("@Tarih", selectedDate);
                            silKomut.Parameters.AddWithValue("@PersonelID", personelID);
                            silKomut.ExecuteNonQuery();
                        }
                        else if (kayitSayisi == 0 && isChecked)
                        {
                            // Eğer kayıt yoksa ve Checkbox işaretliyse, yeni kayıt ekliyoruz.
                            SqlCommand ekleKomut = new SqlCommand(
                                "INSERT INTO Puantaj (Tarih, PersonelID) VALUES (@Tarih, @PersonelID)",
                                bgln.baglantı()
                            );
                            ekleKomut.Parameters.AddWithValue("@Tarih", selectedDate);
                            ekleKomut.Parameters.AddWithValue("@PersonelID", personelID);
                            ekleKomut.ExecuteNonQuery();
                        }
                    }

                    

                    MessageBox.Show("Puantaj kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            



        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }
        private void UpdateCheckboxesForSelectedDate(DateTime selectedDate)
        {
            try
            {


                // Seçilen tarihteki personel ID'lerini sorguluyoruz
                SqlCommand komut = new SqlCommand(
                    "SELECT PersonelID FROM Puantaj WHERE Tarih = @Tarih",
                    bgln.baglantı()
                );
                komut.Parameters.AddWithValue("@Tarih", selectedDate);
                SqlDataReader reader = komut.ExecuteReader();

                // Seçilen tarihteki personel ID'lerini listeye ekliyoruz
                HashSet<int> selectedPersonelIDs = new HashSet<int>();
                while (reader.Read())
                {
                    selectedPersonelIDs.Add(Convert.ToInt32(reader["PersonelID"]));
                }
                reader.Close();
                

                // GridView üzerindeki Checkbox'ları güncelliyoruz
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    int personelID = Convert.ToInt32(gridView1.GetRowCellValue(i, "PersonelID"));
                    bool isChecked = selectedPersonelIDs.Contains(personelID); // Kayda göre işaretleme
                    gridView1.SetRowCellValue(i, "Secim", isChecked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }
        private void ConfigureGridView()
        {
            // GridView'i alın
            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)gridControl1.MainView;

            // Checkbox'lar düzenleme moduna girmeden tıklanabilir hale geliyor
            gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
        }
        private Dictionary<int, bool> checkboxValues = new Dictionary<int, bool>();
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

            if (e.Column.FieldName == "Secim") // "Secim" sütunu için çalışıyoruz
            {
                int personelId = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "PersonelID"));

                if (e.IsGetData) // Veri okunuyor
                {
                    // Daha önce seçilmiş bir değer varsa, onu getiriyoruz
                    if (checkboxValues.ContainsKey(personelId))
                    {
                        e.Value = checkboxValues[personelId];
                    }
                    else
                    {
                        e.Value = false; // Varsayılan olarak işaretli değil
                    }
                }
                else if (e.IsSetData) // Veri yazılıyor
                {
                    // Değeri güncelliyoruz
                    checkboxValues[personelId] = Convert.ToBoolean(e.Value);
                }
            }


        }
        private List<int> GetSelectedPersonelIDs()
        {
            List<int> selectedPersonelIDs = new List<int>();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                bool isChecked = Convert.ToBoolean(gridView1.GetRowCellValue(i, "Secim"));
                if (isChecked)
                {
                    int personelID = Convert.ToInt32(gridView1.GetRowCellValue(i, "PersonelID"));
                    selectedPersonelIDs.Add(personelID);
                }
            }

            return selectedPersonelIDs;
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateEdit1.DateTime;

            if (selectedDate == null || selectedDate == DateTime.MinValue)
            {
                MessageBox.Show("Lütfen geçerli bir tarih seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen tarihe göre Checkbox'ları güncelle
            UpdateCheckboxesForSelectedDate(selectedDate);
        }
    }
}
