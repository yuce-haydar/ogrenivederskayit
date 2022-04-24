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

namespace gun1proje1
{
    public partial class ogretmenbil : Form
    {
        public ogretmenbil()
        {
            InitializeComponent();
        }

        private void ogretmenbil_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection("Data Source=(local);Initial Catalog=proje1;Integrated Security=True");
                baglanti.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("baglanti query sirasinda hata olustu " + ex.ToString());
            }
            finally
            {
                if (baglanti != null)
                {
                    baglanti.Close();
                }


            }
            void verigoster(string veri)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(veri, baglanti);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];

            }
            verigoster("select *from  proje1tab");
        }

        private void kaydetbtn_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection("Data Source=(local);Initial Catalog=proje1;Integrated Security=True");
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("insert into proje1tab (ogrencino,ad,soyad)values('" + nomsktxt.Text + "','" + adtxt.Text + "','" + sydtxt.Text + "')", baglanti);

                cmd.ExecuteNonQuery();
                MessageBox.Show("ogrencı eklendı ");


            }
            catch (Exception ex)
            {

                MessageBox.Show("baglanti query sirasinda hata olustu " + ex.ToString());
            }
            finally
            {
                if (baglanti != null)
                {
                    baglanti.Close();
                }


            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void gncellebtn_Click(object sender, EventArgs e)
        {
            double ort, f, v;
            v = Convert.ToDouble(textBox3.Text);
            f = Convert.ToDouble(textBox4.Text);
            ort = (v * 0.6 + f * 0.4);
            lblort.Text = ort.ToString();
            bool durum;
            if (ort < 50)
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            SqlConnection baglanti = null;
            try
            {

                baglanti = new SqlConnection("Data Source=(local);Initial Catalog=proje1;Integrated Security=True");
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("ubdate proje1tab set vize=@p1, final=@p2 where ogrencino=@p4", baglanti);
                cmd.Parameters.AddWithValue("@p1",textBox3.Text);
                cmd.Parameters.AddWithValue("@p2", textBox4.Text);
                
                cmd.Parameters.AddWithValue("@p4", nomsktxt);
                cmd.ExecuteNonQuery();
                MessageBox.Show("ogrencı guncellendi ");


            }
            catch (Exception ex)
            {

                MessageBox.Show("baglanti query sirasinda hata olustu " + ex.ToString());
            }
            finally
            {
                if (baglanti != null)
                {
                    baglanti.Close();
                }
            }
        }
    }
}

