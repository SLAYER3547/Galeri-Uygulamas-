using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galeri_Uygulaması
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //Kullanıcı admin girişini seçerse admin paneli formuna yönlendirsin
            AdminPanel newform = new AdminPanel();
            newform.Show();
            this.Hide();
        }

        

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            //Kayıt olma formuna yönlendirme
            FrmRegister newform = new FrmRegister();
            newform.Show();
            this.Hide();

        }

        
    }
}
