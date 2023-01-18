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
    public partial class ImagesofCar : Form
    {
        public ImagesofCar()
        {
            InitializeComponent();
        }
        // Veri tabanı işlemleri için bağlantı nesnemi oluşturdum
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-FDGOUMJ;Initial Catalog=galeri_uygulamasi;Integrated Security=True");
        public int ilan_no;

        // ilana ait resim varsa listeler yoksa kapatır
        private void ImagesofCar_Load(object sender, EventArgs e)
        {
            textBox1.Text = ilan_no.ToString();
            connect.Open();
            SqlCommand cmd = new SqlCommand("SELECT ilan_resim_id FROM ilan_resim where ilan_id = @p1", connect);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                comboBox4.Items.Add(read[0]);

            }
            connect.Close();
        }
        public int imageIndex = 0;

        // Resimlerde ileri gitme
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                imageIndex++;
                if (imageIndex >7 )
                {
                    imageIndex = 0;
                }

                comboBox4.Text = comboBox4.Items[imageIndex].ToString();

                connect.Open();
                SqlCommand cmd = new SqlCommand("Select resim FROM ilan_resim where ilan_resim_id=@p1", connect);
                cmd.Parameters.AddWithValue("@p1", Convert.ToInt32(comboBox4.Text));
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    textBox3.Text = read[0].ToString();
                }
                connect.Close();
                pictureBox3.ImageLocation = textBox3.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show("İlana ait resim bulunamadı");
                this.Hide();
            }
            
        }
        // Resimlerde geri gitme
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                imageIndex--;
                if (imageIndex<2)
                {
                    imageIndex = 0;
                }
 
                comboBox4.Text = comboBox4.Items[imageIndex].ToString();

                connect.Open();
                SqlCommand cmd = new SqlCommand("Select resim FROM ilan_resim where ilan_resim_id=@p1", connect);
                cmd.Parameters.AddWithValue("@p1", Convert.ToInt32(comboBox4.Text));
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    textBox3.Text = read[0].ToString();
                }
                connect.Close();
                pictureBox3.ImageLocation = textBox3.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("İlana ait resim bulunamadı");
                this.Hide();
            }
        }
    }
}
