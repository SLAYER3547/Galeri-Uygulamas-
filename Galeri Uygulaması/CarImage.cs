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

namespace Galeri_Uygulaması
{
    public partial class CarImage : Form
    {
        public CarImage()
        {
            InitializeComponent();
        }
        // Veri tabanı işlemleri için bağlantı nesnemi oluşturdum
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-FDGOUMJ;Initial Catalog=galeri_uygulamasi;Integrated Security=True");

        // Dosya seçimi
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox2.Text = openFileDialog1.FileName;
        }
        public int ilan_no;
        private void CarImage_Load(object sender, EventArgs e)
        {
            textBox1.Text = ilan_no.ToString();
            try
            {
                // ilana ait resimler varsa güncellene yapar
                connect.Open();
                SqlCommand cmd = new SqlCommand("Select ilan_id,ilan_resim_id from ilan_resim where ilan_id=@p1 group by ilan_id,ilan_resim_id", connect);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    comboBox1.Items.Add(read[1]);
                }
                connect.Close();
                
                label1.Text = comboBox1.Items[0].ToString();
                label2.Text = comboBox1.Items[1].ToString();
                label3.Text = comboBox1.Items[2].ToString();
                label4.Text = comboBox1.Items[3].ToString();
                label5.Text = comboBox1.Items[4].ToString();
                label6.Text = comboBox1.Items[5].ToString();
                label7.Text = comboBox1.Items[6].ToString();
                label8.Text = comboBox1.Items[7].ToString();
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                comboBox1.Visible = false;
                MessageBox.Show("İlana ait resimler hali hazırda mevcut. Resimler güncellenecek");
                button9.Text = "Resimleri Güncelle";
            }
            catch
            {
                MessageBox.Show("Arabaya ait resim bulunamadı");
                button9.Text = "Resimleri Kaydet";
            }

            

        }

        // Resim seçimleri
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox3.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox4.Text = openFileDialog1.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox5.Text = openFileDialog1.FileName;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox6.Text = openFileDialog1.FileName;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox7.Text = openFileDialog1.FileName;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox8.Text = openFileDialog1.FileName;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox9.Text = openFileDialog1.FileName;
        }

        // Resimleri kaydetme
        private void button9_Click(object sender, EventArgs e)
        {
            connect.Open();
            
            try
            {
                if (label1.Text!="" & label2.Text != "" & label3.Text != "" & label4.Text != "" & label5.Text != "" & label6.Text != "" & label7.Text != "" & label8.Text != "" )
                {
                    SqlCommand cmd = new SqlCommand("update  ilan_resim set resim= @p1 where ilan_resim_id=@p2", connect);
                    cmd.Parameters.AddWithValue("@p1", textBox2.Text);
                    cmd.Parameters.AddWithValue("@p2", label1.Text);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("update  ilan_resim set resim= @p1 where ilan_resim_id=@p2", connect);
                    cmd2.Parameters.AddWithValue("@p1", textBox3.Text);
                    cmd2.Parameters.AddWithValue("@p2", label2.Text);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("update  ilan_resim set resim= @p1 where ilan_resim_id=@p2", connect);
                    cmd3.Parameters.AddWithValue("@p1", textBox4.Text);
                    cmd3.Parameters.AddWithValue("@p2", label3.Text);
                    cmd3.ExecuteNonQuery();

                    SqlCommand cmd4 = new SqlCommand("update  ilan_resim set resim= @p1 where ilan_resim_id=@p2", connect);
                    cmd4.Parameters.AddWithValue("@p1", textBox5.Text);
                    cmd4.Parameters.AddWithValue("@p2", label4.Text);
                    cmd4.ExecuteNonQuery();

                    SqlCommand cmd5 = new SqlCommand("update  ilan_resim set resim= @p1 where ilan_resim_id=@p2", connect);
                    cmd5.Parameters.AddWithValue("@p1", textBox6.Text);
                    cmd5.Parameters.AddWithValue("@p2", label5.Text);
                    cmd5.ExecuteNonQuery();

                    SqlCommand cmd6 = new SqlCommand("update  ilan_resim set resim= @p1 where ilan_resim_id=@p2", connect);
                    cmd6.Parameters.AddWithValue("@p1", textBox7.Text);
                    cmd6.Parameters.AddWithValue("@p2", label6.Text);
                    cmd6.ExecuteNonQuery();

                    SqlCommand cmd7 = new SqlCommand("update  ilan_resim set resim= @p1 where ilan_resim_id=@p2", connect);
                    cmd7.Parameters.AddWithValue("@p1", textBox8.Text);
                    cmd7.Parameters.AddWithValue("@p2", label7.Text);
                    cmd7.ExecuteNonQuery();

                    SqlCommand cmd8 = new SqlCommand("update  ilan_resim set resim= @p1 where ilan_resim_id=@p2", connect);
                    cmd8.Parameters.AddWithValue("@p1", textBox9.Text);
                    cmd8.Parameters.AddWithValue("@p2", label8.Text);
                    cmd8.ExecuteNonQuery();
                    MessageBox.Show("Resimler güncellendi");
                    this.Hide();

                }
                else if(label1.Text == "" & label2.Text == "" & label3.Text == "" & label4.Text == "" & label5.Text == "" & label6.Text == "" & label7.Text == "" & label8.Text == "")
                {
                    SqlCommand cmd2 = new SqlCommand("insert into ilan_resim Values (@p1,@p2),(@p3,@p4),(@p5,@p6),(@p7,@p8),(@p9,@p10),(@p11,@p12),(@p13,@p14),(@p15,@p16)", connect);
                    cmd2.Parameters.AddWithValue("@p1", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@p2", textBox2.Text);
                    cmd2.Parameters.AddWithValue("@p3", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@p4", textBox3.Text);
                    cmd2.Parameters.AddWithValue("@p5", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@p6", textBox4.Text);
                    cmd2.Parameters.AddWithValue("@p7", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@p8", textBox5.Text);
                    cmd2.Parameters.AddWithValue("@p9", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@p10", textBox6.Text);
                    cmd2.Parameters.AddWithValue("@p11", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@p12", textBox7.Text);
                    cmd2.Parameters.AddWithValue("@p13", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@p14", textBox8.Text);
                    cmd2.Parameters.AddWithValue("@p15", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@p16", textBox9.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Resimler eklendi");
                    this.Hide();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            connect.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
