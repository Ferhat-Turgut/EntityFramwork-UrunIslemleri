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
    public partial class frmKategori : Form
    {
        public frmKategori()
        {
            InitializeComponent();
        }
        Db_UrunTakipEntities db = new Db_UrunTakipEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //DB deki değerleri listeleme
            dtgList.DataSource = db.Tbl_Kategori.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //DB ye VERİ KAYDETME
            if (txtName.Text!="")
            {
                Tbl_Kategori k = new Tbl_Kategori();
                k.AD = txtName.Text;
                db.Tbl_Kategori.Add(k);
                db.SaveChanges();
                MessageBox.Show("KATEGORİ EKLENDİ");
            }
            else
            {
                MessageBox.Show("DEĞERLERİ KONTROL EDİNİZ");

            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DB de KAYIT SİLME
            int Id = Convert.ToInt32(txtID.Text);
            var ktgr = db.Tbl_Kategori.Find(Id);
            db.Tbl_Kategori.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("KATEGORİ SİLİNDİ");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
           var ktgr= db.Tbl_Kategori.Find(id);
            ktgr.AD = txtName.Text;
            db.SaveChanges();
            MessageBox.Show("güncelleme yapıldı");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmAnaForm fr = new frmAnaForm();
            fr.Show();
            this.Hide();
        }
    }
}
