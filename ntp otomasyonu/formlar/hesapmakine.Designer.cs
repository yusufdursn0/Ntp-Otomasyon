namespace ntp_otomasyonu.formlar
{
    partial class hesapmakine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hesapmakine));
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            textEdit2 = new DevExpress.XtraEditors.TextEdit();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            gridControl3 = new DevExpress.XtraGrid.GridControl();
            gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView3).BeginInit();
            SuspendLayout();
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(550, 2);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(457, 651);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(simpleButton2);
            groupControl1.Controls.Add(simpleButton1);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Controls.Add(textEdit2);
            groupControl1.Controls.Add(textEdit1);
            groupControl1.Location = new Point(1013, 2);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(417, 651);
            groupControl1.TabIndex = 2;
            groupControl1.Text = "groupControl1";
            // 
            // simpleButton2
            // 
            simpleButton2.ImageOptions.Image = (Image)resources.GetObject("simpleButton2.ImageOptions.Image");
            simpleButton2.Location = new Point(205, 443);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new Size(156, 36);
            simpleButton2.TabIndex = 5;
            simpleButton2.Text = "LİSTELE";
            simpleButton2.Click += simpleButton2_Click;
            // 
            // simpleButton1
            // 
            simpleButton1.ImageOptions.Image = (Image)resources.GetObject("simpleButton1.ImageOptions.Image");
            simpleButton1.Location = new Point(205, 364);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new Size(156, 36);
            simpleButton1.TabIndex = 4;
            simpleButton1.Text = "EKLE";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(58, 178);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(85, 16);
            labelControl2.TabIndex = 3;
            labelControl2.Text = "ödenecek tutar";
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(58, 114);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(63, 16);
            labelControl1.TabIndex = 2;
            labelControl1.Text = "personel id";
            // 
            // textEdit2
            // 
            textEdit2.Location = new Point(205, 172);
            textEdit2.Name = "textEdit2";
            textEdit2.Size = new Size(156, 22);
            textEdit2.TabIndex = 1;
            // 
            // textEdit1
            // 
            textEdit1.Location = new Point(205, 111);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new Size(156, 22);
            textEdit1.TabIndex = 0;
            // 
            // gridControl3
            // 
            gridControl3.Location = new Point(0, 2);
            gridControl3.MainView = gridView3;
            gridControl3.Name = "gridControl3";
            gridControl3.Size = new Size(544, 651);
            gridControl3.TabIndex = 3;
            gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView3 });
            // 
            // gridView3
            // 
            gridView3.GridControl = gridControl3;
            gridView3.Name = "gridView3";
            gridView3.FocusedRowChanged += gridView3_FocusedRowChanged;
            // 
            // hesapmakine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 655);
            Controls.Add(gridControl3);
            Controls.Add(groupControl1);
            Controls.Add(gridControl1);
            Name = "hesapmakine";
            Text = "Personel Ödeme Bilgileri";
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl3).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}