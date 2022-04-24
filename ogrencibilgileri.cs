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
using System.Data.SqlClient;

namespace gun1proje1
{
    public partial class ogrencibilgileri : Form
    {
        public ogrencibilgileri()
        {
            InitializeComponent();
        }
          public string numara;
        SqlConnection baganti=new SqlConnection(@"Data Source=(local);Initial Catalog=proje1;Integrated Security=True");
        private void ogrencibilgileri_Load(object sender, EventArgs e)
        {
            lblogno.Text = numara;
            baganti.Open();
            SqlCommand cmd = new SqlCommand("select * from proje1tab where ogrencino=@p1 ", baganti);
            cmd.Parameters.AddWithValue("@p1", numara);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {   lblogno.Text=oku[2].ToString();
                lblad.Text = oku[3].ToString();
                lblsoyad.Text = oku[4].ToString();
                lblv.Text=oku[5].ToString();
                lblf.Text=oku[6].ToString();
                

            }
            baganti.Close();
          } 
      
       
    }
}
