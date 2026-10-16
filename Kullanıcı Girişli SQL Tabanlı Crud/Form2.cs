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

namespace Kullanıcı_Girişli_SQL_Tabanlı_Crud
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection bağ = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
       
          
        private void Form2_Load(object sender, EventArgs e)
        {
            tabloyuaktar();

        }



            void tabloyuaktar()
        {
            bağ.Open();
            DataTable dtt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM GİRİŞ", bağ);
            adap.Fill(dtt);
            dataGridView1.DataSource = dtt;
            bağ.Close();
        }








        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult konus = MessageBox.Show("Sistemden Çıkmak İstediğinize Emin Misiniz?","Çıkış",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (konus == DialogResult.Yes)
            {
                this.Close();
              
            }
              if (konus == DialogResult.No) { 
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bağ.Open();
            SqlCommand kom = new SqlCommand("INSERT INTO [GİRİŞ] (Id,kad,sifre) VALUES (@p3,@p1,@p2)",bağ);
            kom.Parameters.AddWithValue("@p1", textBox2.Text);
            kom.Parameters.AddWithValue("@p2", textBox3.Text);
            kom.Parameters.AddWithValue("@p3",textBox1.Text);
            kom.ExecuteNonQuery();
             bağ.Close();
            MessageBox.Show("Kullanıcı başarıyla eklendi", "Kullanıcı Eklendi");
            tabloyuaktar();

        }
    }
}
