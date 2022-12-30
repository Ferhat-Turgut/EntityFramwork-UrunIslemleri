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
    public partial class frmIstatistik : Form
    {
        public frmIstatistik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAnaForm frm = new frmAnaForm();
            frm.Show();
            this.Hide();
        }

        Db_UrunTakipEntities db = new Db_UrunTakipEntities();
        private void frmIstatistik_Load(object sender, EventArgs e)
        {
            //toplam kategori sayısı
            label2.Text = db.Tbl_Kategori.Count().ToString();

            //toplam ürün sayısı
            label3.Text=db.Tbl_Urunler.Count().ToString();

            //ŞARTLI SAYDIRMA(AKTİF MÜŞTERİ)
            label5.Text = db.Tbl_Musteriler.Count(x=> x.DURUM==true).ToString();
            //ŞARTLI SAYDIRMA(PASİF MÜŞTERİ)
            label7.Text = db.Tbl_Musteriler.Count(x=> x.DURUM==false).ToString();

            //toplam stok
            label13.Text = db.Tbl_Urunler.Sum(y => y.STOK).ToString();

            //KASADAKİ TUTAR
            label21.Text = db.Tbl_Satislar.Sum(z=> z.FIYAT).ToString()+" TL";

            //EN YÜKSEK FİYATLI ÜRÜNÜ BULMA
            label11.Text = (from x in db.Tbl_Urunler orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            label9.Text = (from x in db.Tbl_Urunler orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();

            //BEYAZ EŞYA SAYISI
            label15.Text = db.Tbl_Urunler.Count(z=> z.KATEGORI==1).ToString();

            //ŞEHİRLERİ TEKRARSIZ SAYDIRMA
            label23.Text = (from x in db.Tbl_Musteriler select x.SEHIR).Distinct().Count().ToString();

            //en fazla ürünlü marka(sql prosedür oluşturuldu ve c#ta eklendi.
            label19.Text = db.MarkaGetir().FirstOrDefault().ToString();
        }
    }
}
