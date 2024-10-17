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
    public partial class Liste : Form
    {
        int seciliId = 0;
        string ad, soyad;

        private void Liste_Activated(object sender, EventArgs e)
        {
            KisileriListele();
        }

        private void KisileriListele()
        {
            Entities1 db = new Entities1();
            var kisiler = db.Kisi.Where(x => x.KullaniciID == Program.kullanici.Id).ToList();
            dataGridView1.DataSource = kisiler;
            
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            EKle form= new EKle();
            form.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seciliIndex = e.RowIndex;

            string deger = dataGridView1.Rows[seciliIndex].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[seciliIndex].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[seciliIndex].Cells[2].Value.ToString();

            seciliId= int.Parse(deger);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show(ad + " "+soyad + "Kişisini Silmek İstediğinize Emin Misinz ?","Uyarı !!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dlg==DialogResult.Yes)
            {
                Entities1 db = new Entities1();
                var kisi = db.Kisi.Find(seciliId);
                if (kisi!=null)
                {
                    try
                    {
                        db.Kisi.Remove(kisi);
                        db.SaveChanges();

                        MessageBox.Show(ad + " " + soyad + " Kişi Listenizden silindi");
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Silme İŞlemi esnasında bir hata meydana geldi\nLütfen daha sonra tekrar deneyiniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            }

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Duzenle form = new Duzenle(seciliId);
            form.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Liste_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_302_TelefonRehberiDataSet.Kisi' table. You can move, or remove it, as needed.
            this.kisiTableAdapter.Fill(this._302_TelefonRehberiDataSet.Kisi);

        }

        private void Liste_FormClosing(object sender, FormClosingEventArgs e)
        {
          
         

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            var dialog =MessageBox.Show("Oturumunuzu kapatmak istediğinize emin misiniz ?","Uyarı !",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialog==DialogResult.Yes)
            {
                Form1 form = new Form1();
                form.Show();
                this.Close();
            }
        }

        private void Liste_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        public Liste()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

    }
}
