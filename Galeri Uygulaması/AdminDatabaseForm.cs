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
    public partial class AdminDatabaseForm : Form
    {
        public AdminDatabaseForm()
        {
            InitializeComponent();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            // Ana sayfa yönlendirmesi
            MainPage newform = new MainPage();
            newform.Show();
            this.Hide();
        }
        // Veri tabanı işlemleri için veri tabanı bağlantısı oluşturuyoruz
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-FDGOUMJ;Initial Catalog=galeri_uygulamasi;Integrated Security=True");

        // Kullanıcının kullanıcı adının tutan değişken tanımlıyorum
        public string user_name = "";
        private void AdminDatabaseForm_Load(object sender, EventArgs e)
        {
            // Kullanıcı adını ekrana yazdırıyoruz
            bunifuCustomLabel5.Text = user_name;

            // Kullanıcı adına göre telefon numarası ve ismi getiren sorgu
            connect.Open();
            SqlCommand cmd = new SqlCommand("SELECT gallery_name,gallery_phone FROM gallery_Register where gallery_user_name=@p1", connect);
            cmd.Parameters.AddWithValue("@p1", bunifuCustomLabel5.Text);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                bunifuCustomLabel6.Text = read[0].ToString();
                bunifuCustomLabel7.Text = read[1].ToString();
            }
            connect.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            // Kayıt ekleme için ilgili forma yönlendirme
            AddCar newform = new AddCar();
            newform.user_name = bunifuCustomLabel5.Text;
            newform.gallery_name = bunifuCustomLabel6.Text;
            newform.gallery_phone = bunifuCustomLabel7.Text;
            newform.Show();
            this.Hide();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            // Kayıt silmek için ilgili forma yönlendirme
            DeleteCar newform = new DeleteCar();
            newform.user_name = bunifuCustomLabel5.Text;
            newform.gallery_name = bunifuCustomLabel6.Text;
            newform.gallery_phone= bunifuCustomLabel7.Text;
            newform.Show();
            this.Hide();

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            // Diğer ilanlara bakmak için ilan arama formuna yönlendirme
            FindCars newform = new FindCars();
            newform.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            // Uygulamadan çıkış yapma
            Application.Exit();
        }
    }
}
