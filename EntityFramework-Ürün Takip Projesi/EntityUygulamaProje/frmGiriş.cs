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
    public partial class frmGiriş : Form
    {
        public frmGiriş()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Db_UrunTakipEntities db = new Db_UrunTakipEntities();
            var sorgu=from x in db.Tbl_Kullanici where x.KullaniciAd==textBox1.Text && x.KullaniciSifre==textBox2.Text select x;
            if (sorgu.Any())
            {
                frmAnaForm fr = new frmAnaForm();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bilgileri Kontrol Ediniz");
            }
        }
    }
}
