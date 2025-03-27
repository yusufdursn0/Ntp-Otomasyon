namespace ntp_otomasyonu.formlar
{
    partial class projeler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(projeler));
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            durum = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            şirket = new DevExpress.XtraEditors.TextEdit();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            txtustalık = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            btnekle = new DevExpress.XtraEditors.SimpleButton();
            txtıd = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)durum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)şirket.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtustalık.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtıd.Properties).BeginInit();
            SuspendLayout();
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(-14, -24);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(950, 702);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            gridControl1.Click += gridControl1_Click;
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(durum);
            groupControl1.Controls.Add(labelControl4);
            groupControl1.Controls.Add(labelControl3);
            groupControl1.Controls.Add(şirket);
            groupControl1.Controls.Add(simpleButton1);
            groupControl1.Controls.Add(simpleButton4);
            groupControl1.Controls.Add(simpleButton3);
            groupControl1.Controls.Add(simpleButton2);
            groupControl1.Controls.Add(txtustalık);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(btnekle);
            groupControl1.Controls.Add(txtıd);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Location = new Point(942, -24);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(505, 702);
            groupControl1.TabIndex = 3;
            groupControl1.Text = "groupControl1";
            // 
            // durum
            // 
            durum.Location = new Point(213, 311);
            durum.Name = "durum";
            durum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            durum.Properties.Items.AddRange(new object[] { "Devam", "Bitti" });
            durum.Size = new Size(207, 22);
            durum.TabIndex = 13;
            // 
            // labelControl4
            // 
            labelControl4.Location = new Point(56, 251);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(151, 16);
            labelControl4.TabIndex = 12;
            labelControl4.Text = "Projenin yapılacağı şirket :";
            // 
            // labelControl3
            // 
            labelControl3.Location = new Point(56, 317);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(129, 16);
            labelControl3.TabIndex = 11;
            labelControl3.Text = "Proje devam durumu :";
            // 
            // şirket
            // 
            şirket.Location = new Point(213, 248);
            şirket.Name = "şirket";
            şirket.Size = new Size(207, 22);
            şirket.TabIndex = 10;
            // 
            // simpleButton1
            // 
            simpleButton1.ImageOptions.Image = (Image)resources.GetObject("simpleButton1.ImageOptions.Image");
            simpleButton1.Location = new Point(213, 615);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new Size(207, 36);
            simpleButton1.TabIndex = 8;
            simpleButton1.Text = "Temizle";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // simpleButton4
            // 
            simpleButton4.ImageOptions.Image = (Image)resources.GetObject("simpleButton4.ImageOptions.Image");
            simpleButton4.Location = new Point(213, 561);
            simpleButton4.Name = "simpleButton4";
            simpleButton4.Size = new Size(207, 36);
            simpleButton4.TabIndex = 7;
            simpleButton4.Text = "Güncelle";
            simpleButton4.Click += simpleButton4_Click;
            // 
            // simpleButton3
            // 
            simpleButton3.ImageOptions.Image = (Image)resources.GetObject("simpleButton3.ImageOptions.Image");
            simpleButton3.Location = new Point(213, 506);
            simpleButton3.Name = "simpleButton3";
            simpleButton3.Size = new Size(207, 36);
            simpleButton3.TabIndex = 6;
            simpleButton3.Text = "Sil";
            simpleButton3.Click += simpleButton3_Click;
            // 
            // simpleButton2
            // 
            simpleButton2.ImageOptions.Image = (Image)resources.GetObject("simpleButton2.ImageOptions.Image");
            simpleButton2.Location = new Point(204, 403);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new Size(207, 36);
            simpleButton2.TabIndex = 5;
            simpleButton2.Text = "Listele";
            simpleButton2.Click += simpleButton2_Click;
            // 
            // txtustalık
            // 
            txtustalık.Location = new Point(213, 172);
            txtustalık.Name = "txtustalık";
            txtustalık.Size = new Size(207, 22);
            txtustalık.TabIndex = 4;
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(56, 175);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(56, 16);
            labelControl2.TabIndex = 3;
            labelControl2.Text = "Proje adı:";
            // 
            // btnekle
            // 
            btnekle.ImageOptions.Image = (Image)resources.GetObject("btnekle.ImageOptions.Image");
            btnekle.Location = new Point(213, 454);
            btnekle.Name = "btnekle";
            btnekle.Size = new Size(207, 36);
            btnekle.TabIndex = 2;
            btnekle.Text = "Ekle";
            btnekle.Click += btnekle_Click;
            // 
            // txtıd
            // 
            txtıd.Location = new Point(213, 96);
            txtıd.Name = "txtıd";
            txtıd.Size = new Size(207, 22);
            txtıd.TabIndex = 1;
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(56, 99);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(49, 16);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Proje id:";
            // 
            // projeler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 655);
            Controls.Add(gridControl1);
            Controls.Add(groupControl1);
            Name = "projeler";
            Text = "Projeler";
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)durum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)şirket.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtustalık.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtıd.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit txtustalık;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnekle;
        private DevExpress.XtraEditors.TextEdit txtıd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit şirket;
        private DevExpress.XtraEditors.ComboBoxEdit durum;
    }
}