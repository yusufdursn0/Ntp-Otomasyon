using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntp_otomasyonu.formlar
{
    public partial class konum : Form
    {
        public konum()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Şirketin Google Maps konumu
            string googleMapsLink = "https://maps.app.goo.gl/APtYSNFxgEF3a8tB9";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = googleMapsLink,
                UseShellExecute = true
            });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Şirketin Google Maps konumu
            string googleMapsLink = "https://maps.app.goo.gl/APtYSNFxgEF3a8tB9";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = googleMapsLink,
                UseShellExecute = true
            });
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string websiteLink = "https://prokontinsaat.com/";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = websiteLink,
                UseShellExecute = true
            });
        }
    }
}
