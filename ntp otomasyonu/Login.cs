using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntp_otomasyonu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private const string CorrectUsername = "s";
        private const string CorrectPassword = "1";

        private void flyoutPanelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            // TextBox veya TextEdit'ten gelen giriş verileri
            string username = kul.Text; // Kullanıcı adı için TextEdit
            string password = şif.Text; // Şifre için TextEdit

            // Kullanıcı adı ve şifre kontrolü
            if (username == CorrectUsername && password == CorrectPassword)
            {
                // Giriş başarılı
                MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Anakısım an = new Anakısım();
                an.Show();

                // Mevcut Login formunu gizle
                this.Hide();
            }
            else
            {
                // Hatalı giriş
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kul.Clear();
                şif.Clear();    
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
