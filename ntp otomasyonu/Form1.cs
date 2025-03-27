using ntp_otomasyonu.formlar;

namespace ntp_otomasyonu
{
    public partial class Anakýsým : Form
    {
        public Anakýsým()
        {
            InitializeComponent();

        }


        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.projeler projeler = new formlar.projeler();
            projeler.MdiParent = this;
            projeler.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.bitmiþprojeler bt = new formlar.bitmiþprojeler();
            bt.MdiParent = this;
            bt.Show();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.personeller personeller = new formlar.personeller();
            personeller.MdiParent = this;
            personeller.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.Ustalýklar ust = new formlar.Ustalýklar();
            ust.MdiParent = this;
            ust.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.puantajh pu = new formlar.puantajh();
            pu.MdiParent = this;
            pu.Show();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.pozlar po = new formlar.pozlar();
            po.MdiParent = this; po.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.hesapmakine he = new formlar.hesapmakine();
            he.MdiParent = this;
            he.Show();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.teklif teklif = new formlar.teklif();
            teklif.MdiParent = this; teklif.Show();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.konum konum = new formlar.konum();
            konum.MdiParent = this; konum.Show();
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlar.kurlar kurlar = new formlar.kurlar();
            kurlar.MdiParent = this;
            kurlar.Show();
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formlama();
        }
        public void formlama()
        {
            formlar.haberler haber = new formlar.haberler();
            haber.MdiParent = this;
            haber.Show();
        }

        private void Anakýsým_Load(object sender, EventArgs e)
        {
            formlama();
        }
    }
}
