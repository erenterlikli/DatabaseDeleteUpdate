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
namespace DatabaseDelete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=EREN\\SQLEXPRESS;Integrated Security=True");
        
        private void Goster()
        {
            listView1.Items.Clear();  //tekrar kaydedince çıkmasın diye.
            conn.Open();
            SqlCommand komut = new SqlCommand("Select *from Kutuphanem.dbo.books", conn);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString() ;
                ekle.SubItems.Add(oku["kitapadi"].ToString());
                ekle.SubItems.Add(oku["yazaradi"].ToString());
                ekle.SubItems.Add(oku["yayinevi"].ToString());
                ekle.SubItems.Add(oku["sayfa"].ToString());
                listView1.Items.Add(ekle);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut2 = new SqlCommand("Insert Into Kutuphanem.dbo.books (id,kitapadi,yazaradi,yayinevi,sayfa) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString()+" ')", conn);
            komut2.ExecuteNonQuery();
            conn.Close();
            Goster();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Goster();
        }
        int id = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut3 = new SqlCommand("Delete from Kutuphanem.dbo.books where id=(" + id + ")", conn);
            komut3.ExecuteNonQuery();
            conn.Close();
            Goster();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut4 = new SqlCommand("Update Kutuphanem.dbo.books set id=' " + textBox1.Text.ToString() +"',kitapadi='"+textBox2.Text.ToString()+"',yazaradi='"+textBox3.Text.ToString()+"',yayinevi='"+textBox4.Text.ToString()+"',sayfa='"+textBox5.Text.ToString()+"'where id= " +id + " ", conn);



            komut4.ExecuteNonQuery();
            conn.Close();
            Goster();
        }
    }
}
