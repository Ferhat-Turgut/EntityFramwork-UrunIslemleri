using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityUygulamaProje
{
    public partial class frmUrunler : Form
    {
        public frmUrunler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAnaForm fr = new frmAnaForm();
            fr.Show();
            this.Hide();
        }

        Db_UrunTakipEntities ent = new Db_UrunTakipEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            dtgListe.DataSource = (from x in ent.Tbl_Urunler
                                   select new
                                   {
                                       x.URUNID,
                                       x.URUNAD,
                                       x.URUNMARKA,
                                       x.Tbl_Kategori.AD,
                                       x.STOK,
                                       x.FIYAT,
                                       x.DURUM,
                                   }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Tbl_Urunler urun = new Tbl_Urunler();
            urun.URUNAD = txtUrunAd.Text;
            urun.URUNMARKA = txtMarka.Text;
            urun.STOK =Convert.ToInt32( txtStok.Text);
            urun.FIYAT = Convert.ToInt32(txtFiyat.Text);
            urun.DURUM = true;
            urun.KATEGORI = int.Parse(cmbKtgori.SelectedValue.ToString());
            ent.Tbl_Urunler.Add(urun);
            ent.SaveChanges();
            MessageBox.Show("Ekleme Başarılı");
            dtgListe.DataSource = ent.Tbl_Urunler.ToList();


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                var silineceköge = ent.Tbl_Urunler.Find(id);
                ent.Tbl_Urunler.Remove(silineceköge);
                ent.SaveChanges();
                MessageBox.Show("Ürün silindi");
                dtgListe.DataSource = ent.Tbl_Urunler.ToList();
            }
            catch (Exception)
            {

                MessageBox.Show("ID numarasını kontrol edin");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var guncellenecekler = ent.Tbl_Urunler.Find(id);
            guncellenecekler.URUNAD = txtUrunAd.Text;
            guncellenecekler.URUNMARKA = txtMarka.Text;
            guncellenecekler.STOK =Convert.ToInt32( txtStok.Text);
            guncellenecekler.FIYAT = Convert.ToInt32(txtFiyat.Text);
            guncellenecekler.KATEGORI = Convert.ToByte(cmbKtgori.SelectedValue);
            ent.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
            dtgListe.DataSource = ent.Tbl_Urunler.ToList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDurum.Clear();
            txtFiyat.Clear();
            txtId.Clear();
            cmbKtgori.Text = "";
            txtMarka.Clear();
            txtStok.Clear();
            txtUrunAd.Clear();
        }

        private void frmUrunler_Load(object sender, EventArgs e)
        {
            var ktgoriler = (from x in ent.Tbl_Kategori
                             select new
                             {
                                 x.AD,
                                 x.ID
                             }
                             ).ToList();
            cmbKtgori.ValueMember = "ID";
            cmbKtgori.DisplayMember = "AD";
            cmbKtgori.DataSource = ktgoriler;
        }
    }
}
