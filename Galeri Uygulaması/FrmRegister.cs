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
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }
        //Veri tabanı işlemleri için bağlantı nesnesi oluşturuyorum
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-FDGOUMJ;Initial Catalog=galeri_uygulamasi;Integrated Security=True");
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            // Ana sayfaya yönlendirme 
            MainPage newform = new MainPage();
            newform.Show();
            this.Hide();
        }
        
      
        /*Veri Tabanında eğer daha önceden kayıtlı kullanıcı adı, şifre ya da telefon varsa yeni kayıt olacak kişi
        bu veriler ile kayıt olamasın diye değişkenler oluşturdum. Aşağıda sorgularda eğer bunlar 1 dönerse uyarı me-*/
        public int username;
        public int password;
        public int phone;
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                // Eğer tüm araçlar doluysa kayıt işlemi gerçekleştirilicek
                if (bunifuMaterialTextbox1.Text != "" & bunifuMaterialTextbox2.Text != "" & bunifuMaterialTextbox3.Text != "" & bunifuMaterialTextbox4.Text != "" & bunifuMaterialTextbox4.Text.Length==11)
                {
                    // Daha önce kulanıcı adının olup olmadığını kontrol ediyorum. Varsa 1 yoksa 0 dönüyor
                    connect.Open();
                    SqlCommand cmd2 = new SqlCommand("select count(*) from gallery_Register where gallery_user_name=@p1", connect);
                    cmd2.Parameters.AddWithValue("@p1", bunifuMaterialTextbox1.Text);
                    SqlDataReader read = cmd2.ExecuteReader();
                    while (read.Read())
                    {
                        username = Convert.ToInt32(read[0]);
                    }
                    connect.Close();

                    // Daha önce şifrenin olup olmadığını kontrol ediyorum. Varsa 1 yoksa 0 dönüyor
                    connect.Open();
                    SqlCommand cmd3 = new SqlCommand("select count(*) from gallery_Register where gallery_password=@p1", connect);
                    cmd3.Parameters.AddWithValue("@p1", bunifuMaterialTextbox2.Text);
                    SqlDataReader read3 = cmd3.ExecuteReader();
                    while (read3.Read())
                    {
                        password = Convert.ToInt32(read3[0]);
                    }
                    connect.Close();

                    // Daha önce telefon numarasının  olup olmadığını kontrol ediyorum. Varsa 1 yoksa 0 dönüyor
                    connect.Open();
                    SqlCommand cmd4 = new SqlCommand("select count(*) from gallery_Register where gallery_phone=@p1", connect);
                    cmd4.Parameters.AddWithValue("@p1", bunifuMaterialTextbox4.Text);
                    SqlDataReader read4 = cmd4.ExecuteReader();
                    while (read4.Read())
                    {
                        phone= Convert.ToInt32(read4[0]);
                    }
                    connect.Close();

                    //Eğer tüm hepsi 0 dönmüşse kayıt işlemi yapıyor
                    if (username != 1 &password!=1 & phone!=1)
                    {
                        connect.Close();
                        connect.Open();
                        SqlCommand cmd = new SqlCommand("insert into gallery_Register values(@p1,@p2,@p3,@p4) ", connect);
                        cmd.Parameters.AddWithValue("@p1", bunifuMaterialTextbox1.Text);
                        cmd.Parameters.AddWithValue("@p2", bunifuMaterialTextbox2.Text);
                        cmd.Parameters.AddWithValue("@p3", bunifuMaterialTextbox3.Text);
                        cmd.Parameters.AddWithValue("@p4", bunifuMaterialTextbox4.Text);
                        cmd.ExecuteNonQuery();
                        connect.Close();
                        MessageBox.Show("Kayıt başarılı");
                        MainPage newform = new MainPage();
                        newform.Show();
                        this.Hide();
                        connect.Close();
                    }
                    // Kullanıcı adı daha önce alınmışsa uyarı verir
                    else if(username==1 & password!=1 & phone!=1)
                    {
                        MessageBox.Show("Bu kullanıcı adı daha önceden alınmış lütfen başka kullanıcı adı seçiniz");
                    }
                    // Şifre daha önce alınmışsa uyarı verir
                    else if (password == 1 & username!=1 & phone!=1)
                    {
                        MessageBox.Show("Bu şifre daha önceden alınmış lütfen başka şifre seçiniz");
                    }
                    // Telefon numarası daha önce alınmışsa uyarı verir
                    else if (phone==1 & username!=1 & password != 1)
                    {
                        MessageBox.Show("Bu telefon numarası ile zaten bir hesap var lütfen başka telefon numarası giriniz.");
                    }
                    // Kullanıcı adı ve şifre daha önce alınmışsa uyarı verir
                    else if (username==1 & password == 1 & phone!=1)
                    {
                        MessageBox.Show("Bu kullanıcı adı ve şifre daha önceden alınmış lütfen başka kullanıcı adı ve şifre giriniz.");
                    }
                    // Kullanıcı adı ve telefon numarası daha önce alınmışsa uyarı verir
                    else if (username == 1 & phone == 1 & password!=1)
                    {
                        MessageBox.Show("Bu kullanıcı adı ve telefon numarası daha önceden alınmış lütfen başka kullanıcı adı ve telefon numarası giriniz.");
                    }
                    // Şifre ve telefon numarası daha önce alınmışsa uyarı verir
                    else if (password == 1 & phone == 1 & username!=1)
                    {
                        MessageBox.Show("Bu şifre ve telefon numarası daha önceden alınmış lütfen başka telefon numarası ve şifre giriniz.");
                    }
                    // Kullanıcı adı şifre ve telefon numarası daha önce alınmışsa uyarı verir
                    else if (username==1 & password==1 & phone == 1)
                    {
                        MessageBox.Show("Bu kullanıcı adı,şifre ve telefon numarasıyla zaten bir hesap var lütfen bilgilerinizi gözden geçiriniz!!!");
                    } 
                }
                // Tüm alanlar dolu değilse uyarı verir
                else if(bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox2.Text == "" || bunifuMaterialTextbox3.Text == "" || bunifuMaterialTextbox4.Text == "")
                {
                    MessageBox.Show("Lütfen tüm alanların dolu olduğundan emin olunuz!!!");
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        
    }
}
