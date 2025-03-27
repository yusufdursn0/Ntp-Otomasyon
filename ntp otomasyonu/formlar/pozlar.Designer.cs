namespace ntp_otomasyonu.formlar
{
    partial class pozlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pozlar));
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            içerik = new DevExpress.XtraEditors.TextEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            fiyat = new DevExpress.XtraEditors.TextEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            miko = new DevExpress.XtraEditors.TextEdit();
            simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            pozıd = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ıd = new DevExpress.XtraEditors.TextEdit();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ara = new DevExpress.XtraEditors.TextEdit();
            flowLayoutPanel1 = new FlowLayoutPanel();
            gridControl2 = new DevExpress.XtraGrid.GridControl();
            gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)içerik.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fiyat.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)miko.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pozıd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ıd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ara.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
            SuspendLayout();
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(4, 3);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(465, 319);
            gridControl1.TabIndex = 0;
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
            groupControl1.Controls.Add(simpleButton4);
            groupControl1.Controls.Add(labelControl5);
            groupControl1.Controls.Add(içerik);
            groupControl1.Controls.Add(labelControl4);
            groupControl1.Controls.Add(fiyat);
            groupControl1.Controls.Add(labelControl3);
            groupControl1.Controls.Add(miko);
            groupControl1.Controls.Add(simpleButton3);
            groupControl1.Controls.Add(simpleButton2);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(pozıd);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Controls.Add(ıd);
            groupControl1.Controls.Add(simpleButton1);
            groupControl1.Controls.Add(ara);
            groupControl1.Location = new Point(959, 3);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(474, 651);
            groupControl1.TabIndex = 2;
            groupControl1.Text = "groupControl1";
            groupControl1.Paint += groupControl1_Paint;
            // 
            // simpleButton4
            // 
            simpleButton4.ImageOptions.Image = (Image)resources.GetObject("simpleButton4.ImageOptions.Image");
            simpleButton4.Location = new Point(166, 393);
            simpleButton4.Name = "simpleButton4";
            simpleButton4.Size = new Size(156, 36);
            simpleButton4.TabIndex = 15;
            simpleButton4.Text = "Proje içeriğini listele";
            simpleButton4.Click += simpleButton4_Click_1;
            // 
            // labelControl5
            // 
            labelControl5.Location = new Point(78, 357);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(50, 16);
            labelControl5.TabIndex = 14;
            labelControl5.Text = "İçerik id:";
            // 
            // içerik
            // 
            içerik.Location = new Point(166, 351);
            içerik.Name = "içerik";
            içerik.Size = new Size(156, 22);
            içerik.TabIndex = 13;
            // 
            // labelControl4
            // 
            labelControl4.Location = new Point(78, 295);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(69, 16);
            labelControl4.TabIndex = 11;
            labelControl4.Text = "Birim fiyatı :";
            // 
            // fiyat
            // 
            fiyat.Location = new Point(165, 292);
            fiyat.Name = "fiyat";
            fiyat.Size = new Size(156, 22);
            fiyat.TabIndex = 10;
            // 
            // labelControl3
            // 
            labelControl3.Location = new Point(78, 234);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(81, 16);
            labelControl3.TabIndex = 9;
            labelControl3.Text = "Birim miktarı :";
            // 
            // miko
            // 
            miko.Location = new Point(165, 231);
            miko.Name = "miko";
            miko.Size = new Size(156, 22);
            miko.TabIndex = 8;
            // 
            // simpleButton3
            // 
            simpleButton3.ImageOptions.Image = (Image)resources.GetObject("simpleButton3.ImageOptions.Image");
            simpleButton3.Location = new Point(166, 514);
            simpleButton3.Name = "simpleButton3";
            simpleButton3.Size = new Size(156, 36);
            simpleButton3.TabIndex = 7;
            simpleButton3.Text = "Sil";
            simpleButton3.Click += simpleButton3_Click;
            // 
            // simpleButton2
            // 
            simpleButton2.ImageOptions.Image = (Image)resources.GetObject("simpleButton2.ImageOptions.Image");
            simpleButton2.Location = new Point(166, 454);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new Size(156, 36);
            simpleButton2.TabIndex = 6;
            simpleButton2.Text = "Ekle";
            simpleButton2.Click += simpleButton2_Click;
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(78, 174);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(43, 16);
            labelControl2.TabIndex = 5;
            labelControl2.Text = "poz id :";
            // 
            // pozıd
            // 
            pozıd.Location = new Point(166, 171);
            pozıd.Name = "pozıd";
            pozıd.Size = new Size(156, 22);
            pozıd.TabIndex = 4;
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(78, 112);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(53, 16);
            labelControl1.TabIndex = 3;
            labelControl1.Text = "proje id :";
            labelControl1.Click += labelControl1_Click;
            // 
            // ıd
            // 
            ıd.Location = new Point(166, 109);
            ıd.Name = "ıd";
            ıd.Size = new Size(156, 22);
            ıd.TabIndex = 2;
            // 
            // simpleButton1
            // 
            simpleButton1.ImageOptions.Image = (Image)resources.GetObject("simpleButton1.ImageOptions.Image");
            simpleButton1.Location = new Point(366, 34);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new Size(103, 19);
            simpleButton1.TabIndex = 1;
            simpleButton1.Text = "Ara";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // ara
            // 
            ara.Location = new Point(5, 33);
            ara.Name = "ara";
            ara.Size = new Size(355, 22);
            ara.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(475, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(478, 651);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // gridControl2
            // 
            gridControl2.Location = new Point(4, 328);
            gridControl2.MainView = gridView2;
            gridControl2.Name = "gridControl2";
            gridControl2.Size = new Size(465, 326);
            gridControl2.TabIndex = 4;
            gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView2 });
            // 
            // gridView2
            // 
            gridView2.GridControl = gridControl2;
            gridView2.Name = "gridView2";
            gridView2.FocusedRowChanged += gridView2_FocusedRowChanged;
            // 
            // pozlar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 655);
            Controls.Add(gridControl2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(groupControl1);
            Controls.Add(gridControl1);
            Name = "pozlar";
            Text = "Proje Maliyet Belirleme";
            Load += pozlar_Load;
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)içerik.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)fiyat.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)miko.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pozıd.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ıd.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ara.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit ara;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit ıd;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit pozıd;
        private FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit miko;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit fiyat;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.TextEdit içerik;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
    }
}