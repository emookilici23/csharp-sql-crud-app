using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kullanıcı_Girişli_SQL_Tabanlı_Crud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
        SqlConnection bağ = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            bağ.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM GİRİŞ WHERE kad=@p1 and sifre=@p2",bağ);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);

            SqlDataReader oku=cmd.ExecuteReader();

            if (oku.Read()) { 
               bağ.Close();
              Form2 frm2=new Form2();
                frm2.Show();
               this.Hide();
            }
          else
            {
                MessageBox.Show("Kullanıcı adı veya şiren hatalı lütfen tekrar dene"+MessageBoxIcon.Error);
                bağ.Close();
            }
        
           
        
        }
    }
}
