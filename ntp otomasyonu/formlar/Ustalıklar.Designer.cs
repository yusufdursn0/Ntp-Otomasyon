
namespace ntp_otomasyonu.formlar
{
    partial class Ustalıklar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ustalıklar));
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            txtustalık = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            btnekle = new DevExpress.XtraEditors.SimpleButton();
            txtıd = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtustalık.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtıd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(simpleButton1);
            groupControl1.Controls.Add(simpleButton4);
            groupControl1.Controls.Add(simpleButton3);
            groupControl1.Controls.Add(simpleButton2);
            groupControl1.Controls.Add(txtustalık);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(btnekle);
            groupControl1.Controls.Add(txtıd);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Location = new Point(957, 3);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(505, 702);
            groupControl1.TabIndex = 1;
            groupControl1.Text = "groupControl1";
            
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
            simpleButton4.Location = new Point(213, 534);
            simpleButton4.Name = "simpleButton4";
            simpleButton4.Size = new Size(207, 36);
            simpleButton4.TabIndex = 7;
            simpleButton4.Text = "Güncelle";
            simpleButton4.Click += simpleButton4_Click;
            // 
            // simpleButton3
            // 
            simpleButton3.ImageOptions.Image = (Image)resources.GetObject("simpleButton3.ImageOptions.Image");
            simpleButton3.Location = new Point(213, 451);
            simpleButton3.Name = "simpleButton3";
            simpleButton3.Size = new Size(207, 36);
            simpleButton3.TabIndex = 6;
            simpleButton3.Text = "Sil";
            simpleButton3.Click += simpleButton3_Click;
            // 
            // simpleButton2
            // 
            simpleButton2.ImageOptions.Image = (Image)resources.GetObject("simpleButton2.ImageOptions.Image");
            simpleButton2.Location = new Point(213, 276);
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
            labelControl2.Location = new Point(88, 178);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(58, 16);
            labelControl2.TabIndex = 3;
            labelControl2.Text = "Ustalık    :";
            // 
            // btnekle
            // 
            btnekle.ImageOptions.Image = (Image)resources.GetObject("btnekle.ImageOptions.Image");
            btnekle.Location = new Point(213, 365);
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
            txtıd.EditValueChanged += textEdit1_EditValueChanged;
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(88, 99);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(57, 16);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Ustalık Id:";
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(1, 3);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(950, 702);
            gridControl1.TabIndex = 2;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            gridControl1.Click += gridControl1_Click;
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            // 
            // Ustalıklar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 703);
            Controls.Add(gridControl1);
            Controls.Add(groupControl1);
            Name = "Ustalıklar";
            Text = "Ustalıklar";
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtustalık.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtıd.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }

        
        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnekle;
        private DevExpress.XtraEditors.TextEdit txtıd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit txtustalık;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}