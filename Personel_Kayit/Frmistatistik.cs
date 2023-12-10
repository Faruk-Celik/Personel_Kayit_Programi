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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik ()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-6VB768D\\SQLEXPRESS02;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
       
        private void frmistatistik_Load ( object sender, EventArgs e )
        {
            //Toplam Personel Sayısı
            baglanti.Open ();
            SqlCommand komut1 = new SqlCommand("Select Count (*) From Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader ();
            while (dr1.Read ())
            {
                lblToplamPer.Text = dr1 [0].ToString ();
            }

            baglanti.Close ();

            //Evli Personel Sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count (*) From Tbl_Personel where perDurum =1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader ();
            while (dr2.Read())
            {
                lblEvliPer.Text = dr2 [0].ToString ();
            }
            baglanti.Close();

            //Bekar Personel Sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count (*) From Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read ()) 
            { 
                lblBekarPer.Text = dr3 [0].ToString ();
            }
            baglanti.Close();

            // Farklı Şehir Sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(persehir)) From Tbl_Personel ",baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader ();
            while (dr4.Read ())
            {
              lblFarklıSehir.Text = dr4 [0].ToString ();
            }
            baglanti.Close();

            //Toplam Maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(permaas) From Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read ())
            {
                lblToplamMaas.Text = dr5 [0].ToString () ;
            }
            baglanti.Close();

            //Ortalama Maas
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(permaas) From Tbl_Personel ", baglanti);
            SqlDataReader d6 = komut6.ExecuteReader();
            while(d6.Read())
            {
                lblOrtMaas.Text = d6 [0].ToString();
            }
            baglanti.Close();

          
        }
    }
}
