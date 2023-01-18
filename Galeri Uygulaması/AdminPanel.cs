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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }
        // Veri tabanı işlemleri için sql bağlantısı oluşturuyoruz
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-FDGOUMJ;Initial Catalog=galeri_uygulamasi;Integrated Security=True");

        // Koruma için captcha metodu oluşturuyoruz
        void captcha()
        {
            string[] symbol = { "a", "b", "c", "d", "e", "f", "g" };
            string[] symbol2 = { "&", "%", "+", "^", "@", "*" };
            string[] symbol4 = { "A", "Z", "P", "K", "L", "N", "M" };
            string[] symbol5 = { "?", "O", "C", "İ", "R", "/", "!" };
            Random r = new Random();
            int s1, s2, s3, s4, s5;
            s1 = r.Next(1, symbol.Length);
            s2 = r.Next(01, symbol2.Length);
            s3 = r.Next(1, 10);
            s4 = r.Next(1, symbol4.Length);
            s5 = r.Next(1, symbol5.Length);
            bunifuCustomLabel4.Text = symbol[s1].ToString() + symbol2[s2].ToString() + s3.ToString() + symbol4[s4].ToString() + symbol5[s5].ToString();
        }
        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // Koruma için captcha oluşturmak amacıyla metodumuzu çağırıyoruz
            captcha();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            // Kullanıcıyı ana sayfaya yönlendirme
            MainPage newform = new MainPage();
            newform.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            // Admin doğru bilgileri girdiği takdirde oturum açılacak ve ilan formu görüntülenecek
            connect.Open();
            SqlCommand cmd = new SqlCommand("Select *From gallery_Register Where gallery_user_name=@p1  and gallery_password=@p2", connect);
            cmd.Parameters.AddWithValue("@p1", bunifuMaterialTextbox1.Text);
            cmd.Parameters.AddWithValue("@p2", bunifuMaterialTextbox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() & bunifuMaterialTextbox3.Text == bunifuCustomLabel4.Text)
            {
                AdminDatabaseForm newform = new AdminDatabaseForm();
                newform.user_name = bunifuMaterialTextbox1.Text;
                newform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");
                bunifuMaterialTextbox1.Text = "";
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox3.Text = "";
                captcha();
            }
            connect.Close();
        }
    }
}
