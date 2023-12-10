using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{


    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm ()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-6VB768D\\SQLEXPRESS02;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        void sırala ()
        {
            baglanti.Open ();
            
            SqlCommand sırala = new SqlCommand("SELECT * FROM personel WHERE cinsiyet='E' AND ulke='Türkiye' ORDER BY maas", baglanti);
            
            baglanti.Close ();
        }
        void temizle ()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtMeslek.Text = "";
            mskMaas.Text = "";
            cmbSehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked =false;
            txtAd.Focus();
        }
        private void groupBox1_Enter ( object sender, EventArgs e )
        {

        }

        private void Form1_Load ( object sender, EventArgs e )
        {

            this.tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet1.Tbl_personel);

        }

        private void btnListele_Click ( object sender, EventArgs e )
        {
            this.tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet1.Tbl_personel);
        }

        private void btnKaydet_Click ( object sender, EventArgs e )
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_personel(Perad,persoyad,persehir,permaas,permeslek,perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2",txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", mskMaas.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("personel Eklendi");
        }

        private void label8_Click ( object sender, EventArgs e )
        {
           
        }

        private void radioButton1_CheckedChanged ( object sender, EventArgs e )
        {
     

        }

        private void radioButton2_CheckedChanged ( object sender, EventArgs e )
        {
         
        }

        private void btnTemizle_Click ( object sender, EventArgs e )
        {
            temizle();
        }

        private void dataGridView1_CellContentDoubleClick ( object sender, DataGridViewCellEventArgs e )
        {
            int secilen = dataGridView1.SelectedCells [0].RowIndex;

            txtId.Text=dataGridView1.Rows [secilen].Cells [0].Value.ToString ();
            txtAd.Text=dataGridView1.Rows [secilen].Cells [1].Value.ToString ();
            txtSoyad.Text = dataGridView1.Rows [secilen].Cells [2].Value.ToString();
            cmbSehir.Text =  dataGridView1.Rows [secilen].Cells [3].Value.ToString();
            mskMaas.Text = dataGridView1.Rows [secilen].Cells [4].Value.ToString();
            label8.Text = dataGridView1.Rows [secilen].Cells [5].Value.ToString();
            label8.Text = dataGridView1.Rows [secilen].Cells [5].Value.ToString();

            if (label8.Text == "True")

            {

                radioButton1.Checked = true;

            }

            else

            {

                radioButton2.Checked = true;

            }
            txtMeslek.Text = dataGridView1.Rows [secilen].Cells [6].Value.ToString();

        }

        private void label8_TextChanged ( object sender, EventArgs e )
        {
       
        }
        private void radioButton1_TextChanged ( object sender, EventArgs e )
        {

        }

        private void btnSil_Click ( object sender, EventArgs e )
        {
            baglanti.Open ();
            SqlCommand komutsil = new SqlCommand ("Delete From Tbl_Personel Where Perid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1",txtId.Text);
            komutsil.ExecuteNonQuery ();
            baglanti.Close ();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnGuncelle_Click ( object sender, EventArgs e )
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("update Tbl_Personel Set PerAd=@a1, PerSoyad=@a2, PerSehir=@a3, PerMaas=@a4, PerDurum=@a5,PerMeslek=@a6 where Perid=@a7 " ,baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", txtAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2",txtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3",cmbSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mskMaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txtMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtId.Text);
            komutguncelle .ExecuteNonQuery ();
            MessageBox.Show("Personel Bilgi Güncellendi!");
            baglanti.Close();
        }

        private void btnIstatistik_Click ( object sender, EventArgs e )
        {
            Frmistatistik frm = new Frmistatistik();
            frm.Show();
        }

        private void btnGrafik_Click ( object sender, EventArgs e )
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }

      
    }
}
