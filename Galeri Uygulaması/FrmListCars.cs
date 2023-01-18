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
    public partial class FrmListCars : Form
    {
        public FrmListCars()
        {
            InitializeComponent();
        }
        // Veri tabanı işlemleri için bağlantı nesnemi oluşturdum
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-FDGOUMJ;Initial Catalog=galeri_uygulamasi;Integrated Security=True");
        public DataTable dt = new DataTable();
        public DataTable dt2 = new DataTable();
        public int total_record = 0;
        public string brand;
        public string model;
        public string serie;
        
        private void FrmListCars_Load(object sender, EventArgs e)
        {
            label1.Text = "Toplam" + " " + total_record.ToString() + " " + "kayıt bulundu";
            advancedDataGridView1.DataSource = dt;
        }
       
        // seçili ilana ait resimleri getirme
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                ImagesofCar newform = new ImagesofCar();
                newform.ilan_no = Convert.ToInt32(textBox1.Text);
                newform.Show();
                MessageBox.Show("Resimleri görüntlemek için yön tuşlarını kullanınız");
            }
            else
            {
                MessageBox.Show("Lütfen bir ilan seçiniz");
            }
        }

       // advanced datagridview kullanımı
        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen_value = advancedDataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = advancedDataGridView1.Rows[chosen_value].Cells[0].Value.ToString();
            richTextBox1.Text = advancedDataGridView1.Rows[chosen_value].Cells[11].Value.ToString();
        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = advancedDataGridView1.FilterString;
        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            dt.DefaultView.Sort = advancedDataGridView1.SortString;
        }

        
    }
}
