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
    public partial class FrmGiris : Form
    {
        public FrmGiris ()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-6VB768D\\SQLEXPRESS02;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void BtnGirisYap_Click ( object sender, EventArgs e )
        {
            baglanti.Open ();
            SqlCommand komutgiris = new SqlCommand(" Select * From Tbl_Yonetici where KullaniciAd=@p1 and Sifre = @p2", baglanti);
            komutgiris.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komutgiris.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komutgiris.ExecuteReader();  
            if (dr.Read())
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
            }
            baglanti.Close ();
        }
    }
}
