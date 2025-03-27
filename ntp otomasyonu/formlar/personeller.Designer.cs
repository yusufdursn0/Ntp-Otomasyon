namespace ntp_otomasyonu.formlar
{
    partial class personeller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(personeller));
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ad = new DevExpress.XtraEditors.TextEdit();
            tel = new DevExpress.XtraEditors.TextEdit();
            mail = new DevExpress.XtraEditors.TextEdit();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ustalık = new DevExpress.XtraEditors.LookUpEdit();
            ıd = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ad.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tel.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ustalık.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ıd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            SuspendLayout();
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(3, 4);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(950, 702);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            gridControl1.Click += gridControl1_Click;
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridView1.FocusedRowLoaded += gridView1_FocusedRowLoaded;
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(labelControl6);
            groupControl1.Controls.Add(textEdit1);
            groupControl1.Controls.Add(simpleButton5);
            groupControl1.Controls.Add(simpleButton4);
            groupControl1.Controls.Add(simpleButton3);
            groupControl1.Controls.Add(simpleButton2);
            groupControl1.Controls.Add(ad);
            groupControl1.Controls.Add(tel);
            groupControl1.Controls.Add(mail);
            groupControl1.Controls.Add(labelControl5);
            groupControl1.Controls.Add(labelControl4);
            groupControl1.Controls.Add(labelControl3);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(ustalık);
            groupControl1.Controls.Add(ıd);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Controls.Add(simpleButton1);
            groupControl1.Location = new Point(959, 4);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(505, 702);
            groupControl1.TabIndex = 1;
            groupControl1.Text = "groupControl1";
            // 
            // simpleButton5
            // 
            simpleButton5.ImageOptions.Image = (Image)resources.GetObject("simpleButton5.ImageOptions.Image");
            simpleButton5.Location = new Point(190, 635);
            simpleButton5.Name = "simpleButton5";
            simpleButton5.Size = new Size(233, 36);
            simpleButton5.TabIndex = 15;
            simpleButton5.Text = "Temizle";
            simpleButton5.Click += simpleButton5_Click;
            // 
            // simpleButton4
            // 
            simpleButton4.ImageOptions.Image = (Image)resources.GetObject("simpleButton4.ImageOptions.Image");
            simpleButton4.Location = new Point(190, 510);
            simpleButton4.Name = "simpleButton4";
            simpleButton4.Size = new Size(233, 36);
            simpleButton4.TabIndex = 14;
            simpleButton4.Text = "Sil";
            simpleButton4.Click += simpleButton4_Click;
            // 
            // simpleButton3
            // 
            simpleButton3.ImageOptions.Image = (Image)resources.GetObject("simpleButton3.ImageOptions.Image");
            simpleButton3.Location = new Point(190, 441);
            simpleButton3.Name = "simpleButton3";
            simpleButton3.Size = new Size(233, 36);
            simpleButton3.TabIndex = 13;
            simpleButton3.Text = "Ekle";
            simpleButton3.Click += simpleButton3_Click;
            // 
            // simpleButton2
            // 
            simpleButton2.ImageOptions.Image = (Image)resources.GetObject("simpleButton2.ImageOptions.Image");
            simpleButton2.Location = new Point(190, 377);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new Size(233, 36);
            simpleButton2.TabIndex = 12;
            simpleButton2.Text = "Listele";
            simpleButton2.Click += simpleButton2_Click;
            // 
            // ad
            // 
            ad.Location = new Point(190, 142);
            ad.Name = "ad";
            ad.Size = new Size(233, 22);
            ad.TabIndex = 11;
            // 
            // tel
            // 
            tel.Location = new Point(190, 185);
            tel.Name = "tel";
            tel.Size = new Size(233, 22);
            tel.TabIndex = 10;
            // 
            // mail
            // 
            mail.Location = new Point(190, 233);
            mail.Name = "mail";
            mail.Size = new Size(233, 22);
            mail.TabIndex = 9;
            // 
            // labelControl5
            // 
            labelControl5.Location = new Point(57, 145);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(107, 16);
            labelControl5.TabIndex = 7;
            labelControl5.Text = "Personel Ad Soyad";
            // 
            // labelControl4
            // 
            labelControl4.Location = new Point(57, 188);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(103, 16);
            labelControl4.TabIndex = 6;
            labelControl4.Text = "Personel Telefonu";
            // 
            // labelControl3
            // 
            labelControl3.Location = new Point(57, 236);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(95, 16);
            labelControl3.TabIndex = 5;
            labelControl3.Text = "Personel e posta";
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(57, 284);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(38, 16);
            labelControl2.TabIndex = 4;
            labelControl2.Text = "Ustalık";
            // 
            // ustalık
            // 
            ustalık.Location = new Point(190, 281);
            ustalık.Name = "ustalık";
            ustalık.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ustalık.Size = new Size(233, 22);
            ustalık.TabIndex = 3;
            // 
            // ıd
            // 
            ıd.Location = new Point(190, 104);
            ıd.Name = "ıd";
            ıd.Size = new Size(233, 22);
            ıd.TabIndex = 2;
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(57, 107);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(64, 16);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "Personel İd";
            // 
            // simpleButton1
            // 
            simpleButton1.ImageOptions.Image = (Image)resources.GetObject("simpleButton1.ImageOptions.Image");
            simpleButton1.Location = new Point(190, 575);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new Size(233, 36);
            simpleButton1.TabIndex = 0;
            simpleButton1.Text = "Güncelle";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // textEdit1
            // 
            textEdit1.Location = new Point(190, 330);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new Size(233, 22);
            textEdit1.TabIndex = 16;
            textEdit1.EditValueChanged += textEdit1_EditValueChanged;
            // 
            // labelControl6
            // 
            labelControl6.Location = new Point(57, 333);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new Size(47, 16);
            labelControl6.TabIndex = 17;
            labelControl6.Text = "Yevmiye";
            // 
            // personeller
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1432, 703);
            Controls.Add(groupControl1);
            Controls.Add(gridControl1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "personeller";
            Text = "Personeller";
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ad.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tel.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)mail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ustalık.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ıd.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit ad;
        private DevExpress.XtraEditors.TextEdit tel;
        private DevExpress.XtraEditors.TextEdit mail;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit ustalık;
        private DevExpress.XtraEditors.TextEdit ıd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit textEdit1;
    }
}