using TelefonRehberi.Properties;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            txtParola.UseSystemPasswordChar = !txtParola.UseSystemPasswordChar;

            btnView.Image = (txtParola.UseSystemPasswordChar ? Resources.a : Resources.e);
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            Entities1 db = new Entities1();
            var user = db.Kullanici.FirstOrDefault(x => x.KullaniciAdi == txtKullaniciAdi.Text && x.Parola == txtParola.Text);
            try
            {
              
                if (user !=null)
                {
                    if (user.Durum == true)
                    {
                        Program.kullanici = user;

                        Liste frm = new Liste();
                        frm.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Üyeliğiniz Pasif Duruma Düştü Destekle İletişime Geçin");
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Parola Hatalı");
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtKullaniciAdi_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt =(TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt,"Boş bırakılamaz");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txt, "");
            }

        }
    }
}
