namespace ntp_otomasyonu.formlar
{
    partial class konum
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(konum));
            pictureBox1 = new PictureBox();
            linkLabel1 = new LinkLabel();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            linkLabel2 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(995, 655);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(1041, 123);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(317, 20);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://maps.app.goo.gl/Vyc5aZbU5wV7FKHr5";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(1041, 76);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(82, 16);
            labelControl1.TabIndex = 2;
            labelControl1.Text = "Şirket konumu";
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(1041, 259);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(98, 16);
            labelControl2.TabIndex = 3;
            labelControl2.Text = "Şirket Web Sitesi";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(1041, 302);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(186, 20);
            linkLabel2.TabIndex = 4;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "https://prokontinsaat.com/";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // konum
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 655);
            Controls.Add(linkLabel2);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(linkLabel1);
            Controls.Add(pictureBox1);
            Name = "konum";
            Text = "Şirket Konumu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private LinkLabel linkLabel2;
    }
}