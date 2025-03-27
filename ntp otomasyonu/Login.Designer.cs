namespace ntp_otomasyonu
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            kul = new TextBox();
            şif = new TextBox();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(kul);
            panel1.Controls.Add(şif);
            panel1.Controls.Add(simpleButton2);
            panel1.Controls.Add(simpleButton1);
            panel1.Controls.Add(labelControl2);
            panel1.Controls.Add(labelControl1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(39, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(376, 336);
            panel1.TabIndex = 0;
            // 
            // kul
            // 
            kul.Location = new Point(47, 180);
            kul.Name = "kul";
            kul.Size = new Size(181, 27);
            kul.TabIndex = 9;
            // 
            // şif
            // 
            şif.Location = new Point(47, 259);
            şif.Name = "şif";
            şif.Size = new Size(181, 27);
            şif.TabIndex = 8;
            şif.UseSystemPasswordChar = true;
            // 
            // simpleButton2
            // 
            simpleButton2.ImageOptions.Image = (Image)resources.GetObject("simpleButton2.ImageOptions.Image");
            simpleButton2.Location = new Point(251, 259);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new Size(96, 27);
            simpleButton2.TabIndex = 7;
            simpleButton2.Text = "Çıkış";
            simpleButton2.Click += simpleButton2_Click;
            // 
            // simpleButton1
            // 
            simpleButton1.ImageOptions.Image = (Image)resources.GetObject("simpleButton1.ImageOptions.Image");
            simpleButton1.Location = new Point(251, 180);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new Size(96, 27);
            simpleButton1.TabIndex = 6;
            simpleButton1.Text = "Giriş";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(47, 235);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(27, 16);
            labelControl2.TabIndex = 5;
            labelControl2.Text = "Şifre";
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(47, 161);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(67, 16);
            labelControl1.TabIndex = 4;
            labelControl1.Text = "Kullanıcı adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(135, 118);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 1;
            label2.Text = "   Prokont yapı   ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(135, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(114, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(176, 9);
            label1.Name = "label1";
            label1.Size = new Size(117, 22);
            label1.TabIndex = 1;
            label1.Text = " HOŞ GELDİNİZ ";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(463, 445);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private TextBox kul;
        private TextBox şif;
    }
}