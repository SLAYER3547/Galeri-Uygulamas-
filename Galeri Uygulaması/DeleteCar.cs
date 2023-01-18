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
    public partial class DeleteCar : Form
    {
        public DeleteCar()
        {
            InitializeComponent();
        }
        // Veri tabanı işlemleri için bağlantı nesnemi oluşturdum
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-FDGOUMJ;Initial Catalog=galeri_uygulamasi;Integrated Security=True");

        // Kayıtlı ilanların listelenmesi için metod
        void listele()
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("SELECT ilan_no AS 'İlan Numarası',ilan_tarihi AS 'İlan Tarihi',fiyat AS 'Fiyat',yil AS 'Yıl',marka AS 'Marka',model AS 'Model',seri AS 'Seri' FROM ilan WHERE gallery_user_name=@p1", connect);
            cmd.Parameters.AddWithValue("@p1", bunifuCustomLabel1.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            // İlanı ve ona ait resimleri silmek için sorgu
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("Delete From ilan_resim where ilan_id=@p1;Delete From ilan where ilan_no = @p2", connect);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", textBox1.Text);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("İlan başarıyla silindi");
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        // İlan numarası yazıldıkça ilgili ilanı getirme
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            tablo.Clear();
            connect.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ilan_no AS 'İlan Numarası',ilan_tarihi AS 'İlan Tarihi',fiyat AS 'Fiyat',yil AS 'Yıl',marka AS 'Marka',model AS 'Model',seri AS 'Seri' FROM ilan where ilan_no like'" + textBox1.Text + "'", connect);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            connect.Close();
            
        }
        // Admin formuna yönlendirme
        private void button1_Click(object sender, EventArgs e)
        {
            AdminDatabaseForm newform = new AdminDatabaseForm();
            newform.user_name = bunifuCustomLabel1.Text;
            
            newform.Show();
            this.Hide();
        }
        // Kullanıcıya ait verileri admin formunda tekrar görüntülemek için değişkenler
        public string user_name = "";
        public string gallery_name = "";
        public string gallery_phone = "";
        private void DeleteCar_Load(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text = user_name;
            bunifuCustomLabel4.Text = gallery_name;
            bunifuCustomLabel3.Text = gallery_phone;

            // Form yüklendiğinde kayıtlı ilanların listelenmesi
            listele();
        }
    }
}
