using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonRehberi
{
    public partial class Duzenle : Form
    {
        Entities1 db = null;
        int _kisiId;

        public Duzenle(int kisiId)
        {
            _kisiId = kisiId;
          
            db=new Entities1();
            InitializeComponent();

            var kisi = db.Kisi.Find(kisiId);
            if (kisi !=null)
            {
                txtAd.Text = kisi.Ad;
                txtSoyad.Text = kisi.Soyad;
                txtTelefon.Text = kisi.Telefon;
                txtEmail.Text= kisi.Email;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db=new Entities1();
            var dkisi = db.Kisi.Find(_kisiId);
            if (dkisi != null)
            {
               

                try
                {
                    dkisi.Ad = txtAd.Text;
                    dkisi.Soyad = txtSoyad.Text;
                    dkisi.Telefon = txtTelefon.Text;
                    dkisi.Email = txtEmail.Text;
                    db.SaveChanges();
                    MessageBox.Show("Güncelleme işlemi başarı ile tamamlandı");
                    this.Close();
                }
                catch 
                {

                    MessageBox.Show("GÜncelleme işlemi sırasında bir hata meydana geldi.Lütfen bilgileri kontrol edin");
                }
            }
        }
    }
}
