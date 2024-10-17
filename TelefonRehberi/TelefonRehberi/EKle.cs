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
    public partial class EKle : Form
    {
        public EKle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kisi kisi=new Kisi();
            kisi.Ad = txtAd.Text;
            kisi.Soyad= txtSoyad.Text;
            kisi.Telefon=txtTelefon.Text;
            kisi.Email=txtEmail.Text;
            kisi.KullaniciID = Program.kullanici.Id;

            try
            {
                Entities1 db=new Entities1();
                db.Kisi.Add(kisi);
                db.SaveChanges();

                this.Close();
    
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt İşlemi Sırasında bir hata meydana geldi");
            }
        }
    }
}
