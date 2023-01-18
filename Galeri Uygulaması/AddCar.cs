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
    public partial class AddCar : Form
    {
        public AddCar()
        {
            InitializeComponent();
        }
        // Veri tabanı işlemleri için bağlantı nesnemi oluşturdum
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-FDGOUMJ;Initial Catalog=galeri_uygulamasi;Integrated Security=True");

        // Comboboxlarda otomatik tamamlama için
        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
        public string user_name = "";
        public string gallery_name = "";
        public string gallery_phone = "";
        private void AddCar_Load(object sender, EventArgs e)
        {
            // Kullanıcı o anki yıldan fazla yıl verisi girmesin. Örnek olarak sene 2022 ise kullanıcı 2100 giremez
            int year = System.DateTime.Now.Year;
            numericUpDown1.Maximum = year;
            // Form yüklendiği zaman veriler yüklenir
            
            // Comboboxlarda otomatik tamamlama için
            comboBox1.Text = "Seçiniz";
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                collection.Add(comboBox1.Items[i].ToString());
            }
            comboBox1.AutoCompleteCustomSource = collection;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            bunifuCustomLabel22.Text = user_name;
            bunifuCustomLabel24.Text = gallery_name;
            bunifuCustomLabel25.Text = gallery_phone;
            connect.Open();
            SqlCommand cmd = new SqlCommand("SELECT gallery_password FROM gallery_Register WHERE gallery_user_name=@p1", connect);
            cmd.Parameters.AddWithValue("@p1", bunifuCustomLabel22.Text);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                bunifuCustomLabel23.Text = read[0].ToString();
            }
            connect.Close();
            list();
        }

        // İlanları Listelemek için bir metod oluşturdum
        void list()
        {
            SqlCommand cmd = new SqlCommand("select *from ilan where gallery_user_name=@p1", connect);
            cmd.Parameters.AddWithValue("@p1", bunifuCustomLabel22.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        // Seçilen seriye göre model getirme 
        private void comboBox1_TextChanged_1(object sender, EventArgs e)
        {
            string[] Acura = { "RSX" };
            string[] Aion = { "S" };
            string[] AlfaRomeo = { "Giulia", "Giulietta", "145", "146", "147", "155", "156", "159", "164", "166", "33", "Brera", "GT", "GTV", "MiTo", "Spider" };
            string[] Anadol = { "A", "SV" };
            string[] AstonMartin = { "DB11" , "DB7", "DB9", "DBS", "Rapide", "Vanquish", "Vantage", "Virage" };
            string[] Audi = { "A1","A3", "A4", "A5", "A6", "A7", "A8", "E-Tron GT", "R8", "RS", "S Serisi", "TT", "TTS", "80 Serisi", "90 Serisi", "100 Serisi", "200 Serisi" };
            string[] Bentley = { "Continental", "Flying Spur", "Arnage" };
            string[] BMW = { "1 Serisi", "2 Serisi", "3 Serisi", "4 Serisi", "5 Serisi", "6 Serisi", "7 Serisi", "8 Serisi", "i Serisi", "M Serisi", "Z Serisi" };
            string[] Bugatti = { "Chiron" };
            string[] Buick = { "Lacrosse","Le Sabre", "Park Avenue", "Regal","Riviera" };
            string[] Cadillac = { "CTS", "BLS", "Brougham", "DeVille", "Eldorado", "Fleetwood", "Seville", "STS" };
            string[] Chery = { "Alia", "Chance", "Kimo", "QQ6", "Niche" };
            string[] Chevrolet = { "Aveo", "Camaro", "Caprice", "Celebrity", "Corvette", "Cruze", "Epica", "Evanda", "Impala", "Kalos", "Lacetti", "Malibu", "Monte Carlo", "Rezzo", "Spark" };
            string[] Chyresler = { "300 C", "300 M", "Concorde", "Crossfire", "LHS", "Neon", "PT Cruiser", "Sebring", "Stratus" };
            string[] Citroen = { "AMI", "C-Elysee", "C1", "C2", "C3", "C3 Picasso", "C4", "C4 Grand Picasso", "C4 Picasso", "C5", "C6", "C8", "Saxo", "Xsara", "AX", "BX", "Evasion", "Xantia", "XM", "ZX" };
            string[] Dacia = { "Jogger", "Lodgy", "Logan", "Sandero", "1310", "Nova", "Solenza" };
            string[] Daewoo = { "Chairman", "Nexia", "Nubira", "Espero", "Lanos", "Leganza", "Matiz", "Racer", "Super Saloon", "Tico" };
            string[] Daihatsu = { "Cuore", "Materia", "Move", "Sirion", "Applause", "Charade", "Copen", "YRV" };
            string[] Dodge = { "Avenger", "Challenger", "Charger", "Magnum", "Stealth" };
            string[] DSAutomobiles = { "DS 3", "DS 4", "DS 5", "DS 9" };
            string[] Ferrari = { "360", "430", "458", "488","512", "575", "599", "612", "California", "F12", "F355", "F8", "Portofino", "Roma", "SF90" };
            string[] Fiat = { "124 Spider", "Albea", "Brava", "Bravo", "126 Bis", "Coupe", "Croma", "500 Ailesi", "Egea", "Idea", "Linea", "Marea", "Multipla", "Palio", "Panda", "Punto", "Seicento", "Siena", "Stilo", "Tempra", "Tipo", "Ulysse", "UNO" };
            string[] Fisker = { "Karma" };
            string[] Ford = { "B-Max", "C-Max", "Escort", "Fiesta", "Focus", "Fusion", "Galaxy", "Grand C-Max", "Ka", "Mondeo", "Mustang", "S-Max", "Taurus", "Cougar", "Crown Victoria", "Festiva", "Granada", "Probe", "Scorpio", "Sierra", "Taunus", "Thunderbird" };
            string[] Geely = { "Echo", "Emgrand", "Familia", "FC" };
            string[] Honda = {"Accord","City","Civic","Concerto","CR-Z","CRX","E","Integra","Jazz","Legend","Prelude","S2000","Shuttle","Stream" };
            string[] Hyundai = { "Accent", "Accent Blue", "Accent Era", "Atos", "Coupe", "Elantra", "Equus", "Excel", "Genesis", "Getz", "Grandeur", "i10", "i20", "i20 Active", "i20 N", "i20 Troy", "i30", "i40", "loniq", "iX20", "Matrix", "S-Coupe", "Sonata", "Trajet" };
            string[] Ikco = { "Samand" };
            string[] Infiniti = { "Q30", "Q50", "Q60", "G", "I30", "M" };
            string[] Jaguar = { "Daimler", "F-Type", "S-Type", "Sovereign", "X-Type", "XE", "XF", "XJ", "XJR", "XJS", "XK8", "XKR" };
            string[] Kia = { "Capital", "Carens", "Carnival", "Ceed", "Cerato", "Clarus", "Magentis", "Opirus", "Optima", "Picanto", "Pride", "Pro Ceed", "Rio", "Sephia", "Shuma", "Stinger", "Venga" };
            string[] Lada = { "Kalina", "Nova", "Priora", "Samara", "Tavria", "VAZ", "Vega" };
            string[] Lamborghini = { "Aventador", "Gallardo", "Huracan" };
            string[] Lancia = { "Delta", "Thema", "Y(Ypsilon)", "Dedra" };
            string[] Leapmotor = { "T03" };
            string[] Lexus = { "CT", "ES","GS", "IS", "LS" };
            string[] Lincoln = { "MKS", "Continental", "LS", "Mark", "MKZ", "Town Car" };
            string[] Lotus = { "Evora","Elan", "Esprit" };
            string[] Marcos = { "Mantis" };
            string[] Maserati = { "Cambiocorsa", "Ghibli", "GranCabrio", "GranSport", "GranTurismo", "GT", "MC20", "Spyder", "Quattroporte" };
            string[] Mazda = { "2", "3", "5", "6", "MPV", "MX", "Premacy", "121", "323", "626", "929", "Lantis", "RX", "Xedos" };
            string[] Mclaren = { "GT" };
            string[] Mercedes = { "A Serisi", "AMG GT", "B Serisi", "C Serisi", "CL", "CLA", "CLC", "CLK", "CLS", "E Serisi", "EQE", "EQS", "Maybach S", "R Serisi", "S Serisi", "SL", "SLC", "SLK", "SLS AMG", "190", "200", "220", "230", "240", "250", "260", "280", "300", "380", "420", "500", "560", "600" };
            string[] Mercury = { "Grand Marquis" };
            string[] MG = { "F", "MG4", "ZR", "ZS" };
            string[] Mini = { "Cooper", "Cooper Clubman", "Cooper Electric", "John Cooper", "One", "Cooper S" };
            string[] Mitsubishi = { "Attrage", "Colt", "Galant", "Lancer", "Lancer Evolution", "Carisma", "Chariot", "Eclipse", "Grandis", "Space Star", "Space Wagon" };
            string[] Moskwitsch = { "Aleko" };
            string[] Nissan = { "200 SX", "350 Z", "Almera", "Altima", "Bluebird", "Cedric", "GT-R", "Laurel Altima", "Maxima", "Micra", "Note", "NX Coupe", "Primera", "Pulsar", "Sunny", "Tino" };
            string[] Opel = { "Adam", "Agila", "Ascona", "Astra", "Calibra", "Cascada", "Corsa", "GT(Roadster)", "Insignia", "Kadett", "Meriva", "Omega", "Rekord", "Senator", "Signum", "Tigra", "Vectra", "Zafira" };
            string[] Peugeot = { "106", "107", "205", "206", "206+", "207", "208", "301", "306", "307", "308", "309", "405", "406", "407", "508", "605", "607", "806", "807", "RCZ" };
            string[] Plymouth = { "Laser" };
            string[] Pontiac = { "Firebird", "Solstice", "Sunbird" };
            string[] Porsche = { "718", "911", "928", "Boxster", "Cayman", "Panamera", "Taycan" };
            string[] Proton = { "Gen-2", "Saga", "Savvy", "Waja", "218", "315", "316", "413", "415", "416", "418", "420", "Persona" };
            string[] Renault = { "Clio", "Espace", "Fluence", "Fluence Z.E", "Grand Espace", "Grand Scenic", "Laguna", "Latitude", "Megane", "Modus", "Safrane", "Scenic", "Symbol", "Taliant", "Talisman", "Twingo", "Twizy", "Vel Satis", "ZOE", "R5", "R9", "R11", "R12", "R19", "R21", "R25" };
            string[] RollsRoyce = { "Dawn", "Ghost", "Phantom", "Wraith" };
            string[] Rover = { "25", "45", "75", "200", "214", "216", "218", "220", "400", "414", "416", "420", "620", "820", "827", "Streetwise" };
            string[] Saab = { "9-3", "9-5", "900", "9000" };
            string[] Seat = { "Alhambra", "Altea", "Arosa", "Cordoba", "Exeo", "Ibiza", "Leon", "Marbella", "Toledo" };
            string[] Skoda = { "Citigo", "Fabia", "Favorit", "Felicia", "Forman", "Octavia", "Rapid", "Roomster", "Scala", "Superb" };
            string[] Smart = { "Fortwo", "Forfour", "Roadster" };
            string[] Subaru = { "BRZ", "Impreza", "Legacy", "Levorg", "Justy", "Vivio" };
            string[] Suzuki = { "Alto", "Baleno", "Splash", "Swift", "SX4", "Liana", "Maruti" };
            string[] Tata = { "Indica", "Indigo", "Marina", "Vista", "Manza" };
            string[] Tesla = { "Model 3", "Model S", "Model X", "Model Y" };
            string[] Tofas = { "Doğan", "Kartal", "Murat", "Şahin", "Serçe" };
            string[] Toyota = { "Auris", "Avensis", "Camry", "Carina", "Celica", "Corolla", "Corona", "Cressida", "Estima", "GT86", "MR2", "Picnic", "Previa", "Prius", "Starlet", "Supra", "Urban Cruiser", "Verso", "Yaris" };
            string[] Volkswagen = { "Arteon", "Beetle", "Bora", "EOS", "Golf", "ID.3", "Jetta", "Lupo", "Passat", "Passat Alltrack", "Passat Variant", "Phaeton", "Polo", "Routan", "Santana", "Scirocco", "Sharan", "Touran", "Up Club", "VW CC", "Vento" };
            string[] Volvo = { "C30", "C70", "S40", "S60", "S70", "S80", "S90", "V40", "V40 Cross Country", "V50", "V60", "V60 Cross Country", "V70", "V90 Cross Country", "440", "460", "480", "740", "850", "940", "960" };
            string[] XEV = { "Yoyo" };

            //Seçilen markaya göre ikinci seçim kutusunda ona uygun serilerin sıralanması ve ona göre logo gelmesi
            if (comboBox1.Text == "Acura")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\acura-logo.png";
                comboBox2.DataSource = Acura;
            }
            if (comboBox1.Text == "Aion")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\aion.png";
                comboBox2.DataSource = Aion;
            }
            if (comboBox1.Text == "Alfa Romeo")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\alfaromeo.jpg";
                comboBox2.DataSource = AlfaRomeo;
            }
            if (comboBox1.Text == "Anadol")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Anadol-logo.png";
                comboBox2.DataSource = Anadol;
            }
            if (comboBox1.Text == "Aston Martin")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\astonlogo.jpg";
                comboBox2.DataSource = AstonMartin;
            }
            if (comboBox1.Text == "Audi")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\audi-logo-.jpg";
                comboBox2.DataSource = Audi;
            }
            if (comboBox1.Text == "Bentley")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\bently-logo.jpg";
                comboBox2.DataSource = Bentley;
            }
            if (comboBox1.Text == "BMW")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\bmwlogo.jpg";
                comboBox2.DataSource = BMW;
            }
            if (comboBox1.Text == "Bugatti")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\bugatti-logo.png";
                comboBox2.DataSource = Bugatti;
            }
            if (comboBox1.Text == "Buick")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\buick.jpg";
                comboBox2.DataSource = Buick;
            }
            if (comboBox1.Text == "Cadillac")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\cadillac.jpg";
                comboBox2.DataSource = Cadillac;
            }
            if (comboBox1.Text == "Chery")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Chery-Logo-1997.png";
                comboBox2.DataSource = Chery;
            }
            if (comboBox1.Text == "Chevrolet")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\chevrolet.png";
                comboBox2.DataSource = Chevrolet;
            }

            if (comboBox1.Text == "Chyresler")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Chyreslerlogo.png";
                comboBox2.DataSource = Chyresler;
            }

            if (comboBox1.Text == "Citroen")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\citroen-logo.png";
                comboBox2.DataSource = Citroen;
            }

            if (comboBox1.Text == "Dacia")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\dacialogo.jpg";
                comboBox2.DataSource = Dacia;
            }

            if (comboBox1.Text == "Daewoo")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\daewoologo.png";
                comboBox2.DataSource = Daewoo;
            }

            if (comboBox1.Text == "Daihatsu")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Daihatsu-logo.png";
                comboBox2.DataSource = Daihatsu;   
            }

            if (comboBox1.Text == "Dodge")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Dodge-logo.png";
                comboBox2.DataSource = Dodge;
            }

            if (comboBox1.Text == "DS Automobiles")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\dslogo.png";
                comboBox2.DataSource = DSAutomobiles;
            }

            if (comboBox1.Text == "Ferrari")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Ferrari_Logo.png";
                comboBox2.DataSource = Ferrari;
            }


            if (comboBox1.Text == "Fiat")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Fiat_(logo).png";
                comboBox2.DataSource = Fiat;
            }

            if (comboBox1.Text == "Fisker")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Fisker_logo.png";
                comboBox2.DataSource = Fisker;
            }

            if (comboBox1.Text == "Ford")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Ford_logo.png";
                comboBox2.DataSource = Ford;
            }

            if (comboBox1.Text == "Geely")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\geely.jpg";
                comboBox2.DataSource = Geely;
            }

            if (comboBox1.Text == "Honda")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\honda.jpg";
                comboBox2.DataSource = Honda;
            }

            if (comboBox1.Text == "Hyundai")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\hyundailogo.png";
                comboBox2.DataSource = Hyundai;
            }

            if (comboBox1.Text == "Ikco")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\ıkcologo.jpg";
                comboBox2.DataSource = Ikco;
            }

            if (comboBox1.Text == "Infiniti")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\ınfinitilogo.jpg";
                comboBox2.DataSource = Infiniti;
            }

            if (comboBox1.Text == "Jaguar")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\jaguar-logo.png";
                comboBox2.DataSource = Jaguar;
            }

            if (comboBox1.Text == "Kia")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\kia-logo.jpg";
                comboBox2.DataSource = Kia;
            }
            if (comboBox1.Text == "Lada")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\ladalogo.jpg";
                comboBox2.DataSource = Lada;
            }

            if (comboBox1.Text == "Lamborghini")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Lamborghini_Logo.png";
                comboBox2.DataSource = Lamborghini;
            }
            if (comboBox1.Text == "Lancia")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\lancia.jpg";
                comboBox2.DataSource = Lancia;
            }

            if (comboBox1.Text == "Leapmotor")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\leaplogo.jpg";
                comboBox2.DataSource = Leapmotor;
            }
            if (comboBox1.Text == "Lexus")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Lexus-logo.png";
                comboBox2.DataSource = Lexus;
            }

            if (comboBox1.Text == "Lincoln")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\lincolnlogo.jpg";
                comboBox2.DataSource = Lincoln;
            }

            if (comboBox1.Text == "Lotus")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Lotus_Cars_logo.png";
                comboBox2.DataSource = Lotus;
            }

            if (comboBox1.Text == "Marcos")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Marcoslogo.jpg";
                comboBox2.DataSource = Marcos;
            }

            if (comboBox1.Text == "Maserati")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\maseratilogo.png";
                comboBox2.DataSource = Maserati;
            }

            if (comboBox1.Text == "Mazda")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\mazdalogo.jpg";
                comboBox2.DataSource = Mazda;
            }

            if (comboBox1.Text == "Mclaren")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\mclarenlogo.png";
                comboBox2.DataSource = Mclaren;
            }

            if (comboBox1.Text == "Mercedes-Benz")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\mercedeslogo.jpg";
                comboBox2.DataSource = Mercedes;
            }

            if (comboBox1.Text == "Mercury")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\mercurylogo.jpg";
                comboBox2.DataSource = Mercury;
            }

            if (comboBox1.Text == "MG")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Mg_cars_logo.png";
                comboBox2.DataSource = MG;
            }

            if (comboBox1.Text == "Mini")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\minicarlogo.jpg";
                comboBox2.DataSource = Mini;
            }

            if (comboBox1.Text == "Mitsubishi")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\mitsubishilogo.png";
                comboBox2.DataSource = Mitsubishi;
            }

            if (comboBox1.Text == "Moskwitsch")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Moskwitsch.jpg";
                comboBox2.DataSource = Moskwitsch;
            }

            if (comboBox1.Text == "Nissan")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\nissanlogo.jpg";
                comboBox2.DataSource = Nissan;
            }

            if (comboBox1.Text == "Opel")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Opel-Logo.png";
                comboBox2.DataSource = Opel;
            }

            if (comboBox1.Text == "Peugeot")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Peugeot.png";
                comboBox2.DataSource = Peugeot;
            }
            if (comboBox1.Text == "Plymouth")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\plymouthlogo.png";
                comboBox2.DataSource = Plymouth;
            }

            if (comboBox1.Text == "Pontiac")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\pontiaclogo.jpg";
                comboBox2.DataSource = Pontiac;
            }

            if (comboBox1.Text == "Porsche")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\porsche-logo.png";
                comboBox2.DataSource = Porsche;
            }

            if (comboBox1.Text == "Proton")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\protonlogo.jpg";
                comboBox2.DataSource = Proton;
            }

            if (comboBox1.Text == "Renault")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Renault-Logo.png";
                comboBox2.DataSource = Renault;
            }

            if (comboBox1.Text == "Rolls-Royce")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\rollsroycelogo.jpg";
                comboBox2.DataSource = RollsRoyce;
            }

            if (comboBox1.Text == "Rover")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\rover-logo.png";
                comboBox2.DataSource = Rover;
            }

            if (comboBox1.Text == "Saab")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\saab-logopng.png";
                comboBox2.DataSource = Saab;
            }

            if (comboBox1.Text == "Seat")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\seatlogo.jpg";
                comboBox2.DataSource = Seat;
            }

            if (comboBox1.Text == "Skoda")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\skodalogo.jpg";
                comboBox2.DataSource = Skoda;
            }

            if (comboBox1.Text == "Smart")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\smartlogo.jpg";
                comboBox2.DataSource = Smart;
            }
            if (comboBox1.Text == "Subaru")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\subarulogo.jpg";
                comboBox2.DataSource = Subaru;
            }

            if (comboBox1.Text == "Suzuki")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\suzuki-car-logo.png";
                comboBox2.DataSource = Suzuki;
            }

            if (comboBox1.Text == "Tata")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\tatalogo.png";
                comboBox2.DataSource = Tata;
            }
            if (comboBox1.Text == "Tesla")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\teslalogo.jpg";
                comboBox2.DataSource = Tesla;
            }
            if (comboBox1.Text == "Tofaş")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\Tofas_Logo.png";
                comboBox2.DataSource = Tofas;
            }

            if (comboBox1.Text == "Toyota")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\toyotalogo.png";
                comboBox2.DataSource = Toyota;
            }

            if (comboBox1.Text == "Volkswagen")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\volkswagenlogo.jpg";
                comboBox2.DataSource = Volkswagen;
            }

            if (comboBox1.Text == "Volvo")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\volvologo.png";
                comboBox2.DataSource = Volvo;
            }

            if (comboBox1.Text == "XEV")
            {
                pictureBox1.ImageLocation = "C:\\Users\\fatihPC\\Desktop\\visual c# form örnekleri\\Galeri Uygulaması\\Medya\\Logolar\\xevlogo.png";
                comboBox2.DataSource = XEV;
            }
            
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            // Seçilen serilere ait modelleri getirmek için diziler oluşturdum
            //Acura markası için
            string[] RSX = { "Type-S" };


            //Aion markası için
            string[] S = { "580" };


            //Alfa Romeo markası için
            string[] Giulia = { "2.0 Veloce","2.0 T Sprint","2.0 T Veloce" };
            string[] Giulietta = { "1.4 TB Distinctive", "1.4 TB MultiAir Distinctive", "1.4 TB MultiAir Progression Pluse", "1.4 TB MultiAir Super TCT", "1.4 TB Progression Plus", "1.6 JTD Distinctive", "1.6 JTD Giulietta", "1.6 JTD Progression", "1.6 JTD Progression Plus", "1.6 JTD Sprint", "1.6 JTD Super TCT", "1.6 JTD TI", "1.75 TBI Quadrifoglio Verde" };
            string[] ARomeo145 ={"1.4 TS STD","1.6","1.6 L","1.6 TS","2.0 Quadrifoglio","2.0 TS QV"};
            string[] ARomeo146 = { "1.4 TS","1.4 TS Ritmo", "1.6 L","1.6 TS", "2.0 Ti" };
            string[] ARomeo147 = { "1.6 TS Black Line","1.6 TS Collezione","1.6 TS Distinctive","1.6 TS Progression", "1.9 JTD Q2", "2.0 TS Distinctive","2.0 TS Selespeed Distinctive" };
            string[] ARomeo155 = {"2.0 Q4","2.0 TS","2.0 TS Super Losso"};
            string[] ARomeo156 = { "1.6 TS","1.6 TS Distinctive","1.6 Progression", "1.9 JTD Impression","1.9 JTD Sportwagon", "2.0 JTS Distinctive","2.0 TS", "2.0 TS Distinctive","2.0 TS Executive","2.0 TS Selespeed", "2.4 JDT","2.5"};
            string[] ARomeo159 = { "1.8 Distinctive", "1.9 JTD Distinctive", "1.9 JTD Distinctive Plus", "1.9 JTD Progression", "1.9 JTS Distinctive", "2.4 JDT Distinctive", "3.2 JTS Q4 Distinctive" };
            string[] ARomeo164 = { "2.0" };
            string[] ARomeo166 = { "2.0 TB", "2.0 TS", "3.0 Sportronic"};
            string[] ARomeo33 = { "1.5 Giardinetta", "1.7 IE"};
            string[] Brera = { "3.2 JTS Q4 Sky Window" };
            string[] AromeoGT = { "1.9 JTD Q2", "2.0 JTS Dis.Selespeed","2.0 JTS Distinctive" };
            string[] AromeoGTV = {"2.0 TB"};
            string[] Mito = { "1.3 JTD City", "1.4 T Distinctive","1.4 T MultiAir Quadrifoglio Verde","1.4 T MultiAir TCT", "1.4 T MultiAir TCT Sportivo", "1.4 T Progression", "1.6 JTD Distinctive","1.6 JTD Progression" };
            string[] Spider = { "2.0 TS", "3.0 TS" };


            //Anadol markası için
            string[] AnadolA = { "A2", "A2 SL" };
            string[] AnadolSV = { "1.6" };


            //Aston Martin markası için
            string[] DB11 = { "Coupe"};
            string[] DB7 = { "Coupe"};
            string[] DB9 = { "Coupe","GT 007 Bond Edition","Volante"};
            string[] DBS = { "DBS Coupe", "DBS Volante"};
            string[] Rapide = { "V12 Rapide","V12 Rapide S"};
            string[] Vanquish = { "V12" };
            string[] Vantage = { "V8 Vantage", "V8 Vantage N420C", "V8 Vantage Roadster", "V8 Vantage S" };
            string[] Virage = { "Coupe" };


            //Audi markası için
            string[] Audia1 = { "1.4 TFSI Ambition","1.4 TFSI Attraction", "1.6 TDI Ambition", "1.6 TDI Attraction", "1.6 TDI Basic", "1.6 TDI Dynamic", "1.6 TDI Sport" };
            string[] Audia3 = { "A3 Cabrio", "A3 Hatchback","A3 Sedan","A3 Sportback"};
            string[] Audia4 = { "A4 Avant", "A4 Cabrio","A4 Sedan","A4 allroad quattro"};
            string[] Audia5 = { "A5 Cabrio", "A5 Coupe","A5 Sportback"};
            string[] Audia6 = { "A6 Sedan", "A6 Avant","A6 Allroad Quattro"};
            string[] Audia7 = { "40 TDI", "50 TDI","2.0 TFSI","3.0 TDI","3.0 TFSI"};
            string[] Audia8 = { "50 TDI", "55 TFSI","2.0 TFSI Hybrid","2.0 TFSI Quattro","2.5 TDI","2.5 TDI Quattro","3.0 TDI","3.0 TFSI Quattro","3.2 FSI","3.3 TDI Quattro","3.7","4.0 TDI Quattro","4.0 TFSI Quattro","4.2","4.2 TDI","6.0"};
            string[] ETronGT ={"GT Quattro","GT RS"};
            string[] R8 = { "4.2 FSI" };
            string[] RS = { "RS 3", "RS 4", "RS 5", "RS 6", "RS 7" };
            string[] AudiS = { "S3", "S5", "S6", "S7", "S8" };
            string[] AudiTT = { "1.8", "2.0", "3.2" };
            string[] AudiTTS = { "2.0 TFSI" };
            string[] Audi80Serisi = { "1.6", "1.6 D", "1.6 TD", "1.8", "1.8 S", "1.9 TD", "1.9 TDI", "2.0", "2.0 Quattro" };
            string[] Audi90Serisi = { "2.0" };
            string[] Audi100Serisi = { "1.9", "2.0", "2.0 D", "2.2", "2.3", "2.5 TDI", "2.6 Quattro" };
            string[] Audi200Serisi = { "2.2" };


            //Bentley markası için
            string[] Continental = { "Flying Spur", "Flying Spur Speed", "GT", "GTC", "GT Speed", "GT Supersports" };
            string[] FlyingSpur = { "4.0", "6.0" };
            string[] Arnage = { "R" };


            //BMW markası için
            string[] Bmw1Serisi = { "116d", "116d ED", "116i", "118d", "118i", "120d", "120i", "128ti" };
            string[] Bmw2Serisi = { "216d Active Tourer", "216d Gran Coupe", "216d Tourer", "218i", "218i Active Tourer", "218i Gran Coupe", "220d", "220i Active Tourer" };
            string[] Bmw3Serisi = { "315", "316", "316Ci", "316i", "316ti", "318Ci", "318d", "318i", "318is", "318tds", "318ti", "320Cd", "320d GT", "320d xDrive", "320 xDrive GT", "320i", "320i ED", "320si", "320td", "323Ci", "323i", "324d", "324td", "325Ci", "325i", "325i xDrive", "325td", "325tds", "325ti", "325xi", "328Ci", "328i", "328i xDrive", "330Cd", "330Ci", "330d", "330d xDrive", "330i", "330i xDrive", "330xd", "330xi", "335d", "335i" };
            string[] Bmw4Serisi = { "418d", "418d Gran Coupe", "418i", "418i Gran Coupe", "420d", "420d Gran Coupe", "420d xDrive", "42d xDrive Gran Coupe", "420i", "420i Gran Coupe", "428i", "428i Gran Coupe", "428i xDrive", "428i xDrive Gran Coupe", "430d xDrive Gran Coupe", "430i Cabrio Edition M Sport", "430i Coupe Edition M Sport", "430i xDrive", "430i xDrive Gran Coupe", "440i xDrive" };
            string[] Bmw5Serisi = { "518i", "520", "520d", "520d Gran Turismo", "520d xDrive", "520i", "520Li", "523i", "524d", "524td", "525d", "525d xDrive", "525i", "525ix", "525tds", "525 xDrive", "525xi", "528i", "528i xDrive", "528xi", "530d", "530d xDrive", "530i", "530i xDrive", "530xd Gran Turismo", "530 xDrive", "530xi", "535d", "535 xDrive", "535i", "535i xDrive", "540i", "540i xDrive", "545i", "550d xDrive", "550 xDrive" };
            string[] Bmw6Serisi = { "620d xDrive", "630Ci", "630i", "630i Gran Tourismo", "635d", "640d", "640d xDrive", "640i", "640i Gran Turismo", "640xd", "645Ci", "650Ci", "650i", "650i xDrive" };
            string[] Bmw7Serisi = { "725d", "725d Long", "725tds", "728i", "728i Long", "730d", "730d Long", "730d xDrive", "730d xDrive Long", "730i", "730i Long", "735i", "735i Long", "740d", "740d xDrive", "740d xDrive Long", "740e xDrive Long", "740i", "740i Long", "745d", "745i", "745i Long", "750d xDrive Long", "750i", "750i Long", "750i xDrive", "750i xDrive Long", "750i Long" };
            string[] Bmw8Serisi = { "840Ci", "840d xDrive Gran Coupe", "840i xDrive", "840i xDrive Gran Coupe" };
            string[] BmwiSerisi = { "i3", "i4", "i7", "i8" };
            string[] BmwMSerisi = { "M2", "M235i xDrive", "M240i xDrive", "M2 Competition", "M3", "M3 Cabrio", "M3 Competition", "M3 Coupe", "M4", "M440i xDrive", "M4 Competition", "M5", "M5 Competition", "M5 CS xDrive", "M6", "M6 Cabrio", "M6 Gran Coupe", "M8 Coupe xDrive Competition", "M8 Gran Coupe xDrive Competition", "Z3 M Coupe", "Z4 M" };
            string[] BmwZSerisi = { "Z3", "Z4" };

            //Bugatti markası için
            string[] Chiron = { "8.0" };

            //Buick markası için
            string[] Century = { "3.3" };
            string[] LeSabre = { "3.8" };
            string[] ParkAvenue = { "3.8" };
            string[] Regal = { "3.8" };
            string[] Riviera = { "3.8" };

            // Cadillac markası için
            string[] CTS = { "2.0 L", "2.8", "3.2" };
            string[] BLS = { "1.9 Elegance"};
            string[] Brougham = { "5.0 STD", "5.7 STD" };
            string[] DeVille = { "4.6 Concours", "4.6 DTS", "4.9 STD" };
            string[] Eldorado = { "4.9 STD" };
            string[] Fleetwood = { "4.9", "5.7" };
            string[] Seville = { "4.6 STS", "4.9 STS" };
            string[] STS = { "4.6" };

            // Chery markası için
            string[] Alia = { "1.6" };
            string[] Chance = {"1.6 Norma","2.0 Lusso"};
            string[] Kimo = { "1.3" };
            string[] QQ6 = { "1.3" };
            string[] Niche = { "1.6 Norma", "2.0 Lusso" };

            // Chevrolet markası için
            string[] Aveo = { "1.2", "1.3 D", "1.4" };
            string[] Camaro = { "2.0", "3.4", "3.6", "3.8", "RS", "SS", "Z28" };
            string[] Caprice = { "3.6", "4.3 STD" };
            string[] Celebrity = { "2.8" };
            string[] Corvette = { "C4", "C5", "C6", "C7", "C8", "Z06" };
            string[] Cruze = { "1.4 T", "1.6", "2.0 D"};
            string[] Epica = { "2.0 D LT", "2.0 LT"};
            string[] Evanda = { "2.0 CDX"};
            string[] Impala = { "3.8", "5.7"};
            string[] Kalos = { "1.2", "1.4"};
            string[] Lacetti = { "1.4", "1.6", "2.0 D" };
            string[] Malibu = { "3.1"};
            string[] MonteCarlo = { "Z34"};
            string[] Rezzo = { "1.6 SX Comfort"};
            string[] Spark = { "0.8", "1.0", "1.2"};

            // Chyresler markası için
            string[] Chyr300C = { "2.7", "3.0 CRD", "3.5", "5.7", "6.1 SRT"};
            string[] Chyr300M = { "3.5" };
            string[] Concorde = { "3.5" };
            string[] Crossfire = { "Coupe 3.2","Roadster 3.2"};
            string[] LHS = { "3.5" };
            string[] Neon = { "2.0"};
            string[] PTCruiser = { "1.6", "2.2 CRD", "2.0" };
            string[] Sebring = { "2.0", "2.0 CRD", "2.4 Limited", "2.5 LXI", "2.7 Limited","2.7 LX"};
            string[] Stratus = { "2.0","2.5"};

            //Citroen markası için
            string[] AMI = { "My Ami Pop"};
            string[] CElysee = { "1.2", "1.5 BlueHDI", "1.6 BlueHDI", "1.2 VTi", "1.6 HDi", "1.6 VTi" };
            string[] C1 = { "1.0", "1.0 VTi", "1.4 HDi" };
            string[] C2 = { "1.4", "1.4 HDi", "1.6" };
            string[] C3 = { "1.2 PureTech", "1.2 VTi", "1.4", "1.4 e-HDi", "1.4 HDi", "1.4 VTi", "1.6", "1.6 BlueHDi", "1.6 HDi", "1.6 VTi" };
            string[] C3Picasso = { "1.4", "1.6 e-HDi", "1.6 HDi" };
            string[] C4 = { "1.2 PureTech", "1.4", "1.4 VTi", "1.6", "1.6 BlueHDi", "1.6 e-HDi", "1.6 HDi", "2.0", "2.0 HDi" };
            string[] C4GranPicasso = { "1.6 BlueHDi", "1.6 e-HDi", "1.6 HDi", "1.6 THP", "2.0 HDi" };
            string[] C4Picasso = { "1.6 BlueHDi", "1.6 e-HDi", "1.6 HDi", "1.6 THP" };
            string[] C5 = { "1.6 e-HDi", "1.6 HDi", "1.6 THP", "2.0", "2.0 HDi", "2.2 HDi", "3.0" };
            string[] C6 = { "2.7 HDi", "3.0" };
            string[] C8 = { "2.0 HDi SX", "2.0 X", "2.2 HDi SX" };
            string[] Saxo = { "1.1", "1.4", "1.5D", "1.6" };
            string[] Xsara = { "1.4", "1.6", "1.8", "1.9", "2.0", "Picasso 1.6", "Picasso 1.8", "Picasso 2.0" };
            string[] AX = { "1.1" };
            string[] BX = {"15"};
            string[] Evasion = { "1.9 TD SX", "2.0 SX" };
            string[] Xantia = { "1.6", "1.8", "1.9", "2.0", "2.1 TD", "3.0" };
            string[] XM = { "2.0", "2.1" };
            string[] ZX = { "1.4", "1.6", "1.8" };

            // Dacia markası için 
            string[] Jogger = { "1.0 ECO-G","1.0 T"};
            string[] Lodgy = { "1.3 TCE", "1.5 BlueDCI","1.5 dCi","1.6 ECO-G","1.6 SCE"};
            string[] Logan = { "0.9 Tce MCV", "1.0 MCV", "1.2", "1.4", "1.5 dCi", "1.5 dCi MCV", "1.6", "1.6 MCV" };
            string[] Sandero = { "0.9 ECO-G", "0.9 TCe", "1.0", "1.0 T", "1.0 T ECO-G", "1.2", "1.4", "1.5 BlueDCI", "1.5 dCi", "1.6" };
            string[] Dacia1310 = { "1310 L" };
            string[] Nova = { "Ti" };
            string[] Solenza = { "1.4" };

            // Daewoo markası için
            string[] Chairman = { "600 L", "600 S" };
            string[] Nexia = { "1.5" };
            string[] Nubira = { "1.6", "2.0" };
            string[] Espero = { "1.5i", "1.8i", "2.0i" };
            string[] Lanos = { "1.4", "1.5", "1.6"};
            string[] Leganza = { "2.0" };
            string[] Matiz = { "0.8" };
            string[] SuperSaloon = { "2.0" };
            string[] Tico = { "0.8" };

            // Daihatsu markası için
            string[] Cuore = { "0.9", "1.0" };
            string[] Materia = { "1.5" };
            string[] Move = { "1.5" };
            string[] Sirion = { "1.0", "1.3" };
            string[] Applause = { "1.6" };
            string[] Charade = { "1.3", "1.5" };
            string[] Copen = { "0.7", "1.3" };
            string[] YRV = { "1.3" };

            // Dodge markası için
            string[] Avenger = { "2.0 CRD", "2.4 SXT" };
            string[] Challenger = { "GT", "R/T", "SE", "SRT8", "SRT Hellcat", "SXT Plus" };
            string[] Charger = { "3.6", "6.2", "6.4" };
            string[] Magnum = { "5.7", "6.1" };
            string[] Stealth = { "RT-4 Turbo 3.0 V6" };

            // DS Automobiles markası için
            string[] DS3 = { "1.2 PureTech", "1.6 e-HDi", "1.6 THP", "1.6 VTi" };
            string[] DS4 = { "1.5 BlueHDi", "1.6 BlueHDi", "1.6 e-HDi", "1.6 THP", "1.6 VTi" };
            string[] DS5 = { "1.6 BlueHDi","1.6 e-HDi", "1.6 THP", "2.0 HDi" };
            string[] DS9 = { "1.6 Puretech" };

            // Ferrari markası için
            string[] F360 = { "Modena", "Modena F1" };
            string[] F430 = { "F430", "F430 Spider", "F430 Scuderia" };
            string[] F458 = { "Italia", "Speciale", "Spider" };
            string[] F488 = { "GTB", "Spider" };
            string[] F512 = { "Testarossa" };
            string[] F575 = { "575M Maranello" };
            string[] F599 = { "599 GTB F1" };
            string[] F612 = { "Scaglietti" };
            string[] California = { "4.3", "T" };
            string[] F12 = { "Berlinetta" };
            string[] F355 = { "GTS", "Spider" };
            string[] F8 = { "Spider", "Tributo" };
            string[] Portofino = { "3.9" };
            string[] Roma = { "3.9" };
            string[] SF90 = { "Stradale 4.0" };

            // Fiat markası için
            string[] F124Spider = { "1.4 T Multiair" };
            string[] Albea = { "1.2", "1.3 Multijet", "1.4 Fire", "1.6", "Sole 1.3 Multijet", "Sole 1.4 Fire" };
            string[] Brava = { "1.6" };
            string[] Bravo = { "1.4", "1.4 T Multiair", "1.4 T-Jet", "1.4 Turbo", "1.6", "1.6 Mjet", "2.0" };
            string[] F126Bis = { "126" };
            string[] Coupe = { "2.0" };
            string[] Croma = { "1.9 JTD", "2.0 iE" };
            string[] F500ailesi = { "500 0.9 TwinAir", "500 1.0 Hybrid", "500 1.2", "500 1.3 Mjet", "500 1.4", "500 Abarth", "500C 0.9 TwinAir", "500C 1.2", "500C 1.4", "500 E", "500L 0.9 TwinAir", "500L 1.3 Mjet", "500L 1.4", "500L 1.4 T-Jet", "500L 1.6 Mjet" };
            string[] Egea = { "1.0 Firefly", "1.3 Multijet", "1.4 Fire", "1.4 T-Jet", "1.5 T4 Hibrit", "1.6 E-Torq", "1.6 Multijet" };
            string[] Idea = { "1.3 Multijet", "1.4" };
            string[] Linea = { "1.3 Multijet", "1.4 Fire", "1.4 Turbo", "1.6 Multijet" };
            string[] Marea = { "1.6", "1.8 HLX", "1.9 JTD", "2.0 HLX" };
            string[] Palio = { "1.2", "1.3 MultiJet", "1.4", "1.4 Fire", "1.6" };
            string[] Panda = { "0.9 TwinAir", "1.0 Hybrid", "1.1 Active", "1.2", "1.2 Fire" };
            string[] Punto = { "1.2", "1.3 MultiJet", "1.4", "1.9 D", "EVO 1.2", "EVO 1.3 MultiJet", "EVO 1.4", "Grande 1.2 S5", "Grande 1.3 MultiJet", "Grande 1.4" };
            string[] Seicento = { "1.1" };
            string[] Siena = { "1.2", "1.4", "1.6" };
            string[] Stilo = { "1.4", "1.6", "1.8", "1.9 JTD" };
            string[] Tempra = { "1.6", "2.0" };
            string[] Tipo = { "1.4", "1.6", "2.0" };
            string[] Ulysse = { "2.0", "2.0 JTD" };
            string[] UNO = { "1.3", "1.4 ie", "1.4 ie 70 S", "1.4 ie Hobby", "1.4 ie S", "1.4 ie SX", "60 S", "70 S", "70 SX", "70 SXie" };

            // Fisker markası için
            string[] Karma = { "2.0" };

            // Ford markası için
            string[] BMax = { "1.0", "1.4", "1.5 TDCi", "1.6", "1.6 TDCi" };
            string[] CMax = { "1.0 EcoBoost", "1.5", "1.5 TDCi", "1.6", "1.6 EcoBoost", "1.6 TDCi", "2.0 TDCi" };
            string[] Escort = { "1.3", "1.4", "1.6", "1.8" };
            string[] Fiesta = { "1.0 EcoBoost", "1.0 GTDi", "1.1", "1.25", "1.3", "1.4", "1.4 TDCi", "1.5 TDCi", "1.6", "1.6 TDCi", "1.6 Ti-VCT","1.8 D","2.0" };
            string[] Focus = { "1.0 EcoBoost GTDi", "1.4", "1.5 TDCi", "1.5 Ti-VCT", "1.6", "1.6 SCTi", "1.6 TDCi", "1.6 Ti-VCT", "1.8", "1.8 TDCi", "2.0", "2.0 TDCi", "2.3" };
            string[] Fusion = { "1.4 TDCi", "1.6", "1.6 TDCi" };
            string[] Galaxy = { "1.9 TDi", "2.0i", "2.0 TDCi Ghia", "2.0 TDCi Titanium", "2.2 TDCi", "2.3 16 V" };
            string[] GrandCMax = { "1.5", "1.5 TDCI", "1.6 EcoBoost", "1.6 TDCI" };
            string[] Ka = { "1.2 Titanium", "1.3", "1.6 Street" };
            string[] Mondeo = { "1.5 Ecoboost", "1.5 TDCI", "1.6", "1.6 TDCi", "1.8", "1.8 TDCi", "2.0", "2.0 TDCi", "2.5", "3.0" };
            string[] Mustang = { "2.3 Convertible", "2.3 Fastback", "3.7 V6", "3.8", "4.0", "4.0 GT", "4.6 GT", "5.0 Convertible", "5.0 Fastback", "5.0 GT", "Shelby GT 500" };
            string[] SMax = { "1.6 TDCi Titanium", "1.6 TDCi Trend", "2.0 TDCi Titanium" };
            string[] Taurus = { "3.0 V6 GL" };
            string[] Cougar = { "2.5i" };
            string[] CrownVictoria = { "4.6" };
            string[] Festiva = { "1.3" };
            string[] Granada = { "1.7", "2.0", "2.3", "2.8" };
            string[] Probe = { "2.2 GT", "2.5", "3.0i" };
            string[] Scorpio = { "2.0", "2.3" };
            string[] Sierra = { "1.6", "1.8", "2.0", "2.3 D", "Cosworth" };
            string[] Taunus = { "1.3 L", "1.6", "2.0" };
            string[] Thunderbird = { "5.0" };

            // Geely markası için
            string[] Echo = { "1.3" };
            string[] Emgrand = { "1.5" };
            string[] Familia = { "1.5" };
            string[] FC = { "1.5" };

            // Honda markası için
            string[] Accord = { "1.5 VTEC", "1.6", "1.8", "2.0", "2.2", "2.3", "2.4", "3.0" };
            string[] City = { "1.4", "1.5 i-VTEC" };
            string[] Civic = { "1.4", "1.5", "1.5 VTEC", "1.6", "1.6i DTEC", "1.6i VTEC", "1.6 VTEC", "1.7", "1.8", "2.0", "2.2i CTDi" };
            string[] Concerto = { "1.6" };
            string[] CRZ = { "GT", "Sport" };
            string[] CRX = { "1.6" };
            string[] E = { "154 PS" };
            string[] Integra = { "1.6", "1.8" };
            string[] Jazz = { "1.3", "1.4", "1.5", "1.5 Hybrid" };
            string[] Legend = { "3.2", "3.5" };
            string[] Prelude = { "2.0", "2.2 VTi" };
            string[] S2000 = { "2.0 Vtec" };
            string[] Shuttle = { "2.2", "2.3" };
            string[] Stream = { "2.0" };

            // Hyundai markası için
            string[] Accent = { "1.3", "1.5", "1.5 CRDi", "1.6" };
            string[] AccentBlue = { "1.4 CVVT", "1.4 D-CVVT", "1.6 CRDI" };
            string[] AccentEra = { "1.4", "1.5 CRDi", "1.5 CRDi-VGT", "1.6" };
            string[] Atos = { "1.0", "1.1" };
            string[] HCoupe = { "1.6", "2.0", "2.7 FX" };
            string[] Elantra = { "1.5", "1.6", "1.6 CRDi", "1.6 D-CVVT", "1.6 MPI", "1.8", "2.0", "2.0 CRDi" };
            string[] Equus = { "5.0" };
            string[] Excel = { "1.5" };
            string[] Genesis = { "2.0L TCI", "3.8" };
            string[] Getz = { "1.3", "1.4 DOHC", "1.5 CRDi", "1.6" };
            string[] Grandeur = { "2.2 CRDi", "3.0i", "3.3" };
            string[] i10 = { "1.0 D-CVVT", "1.0 MPI", "1.1", "1.2 D-CVVT", "1.2 MPI" };
            string[] i20 = { "1.0 T-GDI", "1.2 D-CVVT", "1.2 MPI", "1.4 CRDi", "1.4 CVVT", "1.4 MPI" };
            string[] i20Active = { "1.0 T-GDI", "1.4 MPI" };
            string[] i20N = { "1.6 T-GDI" };
            string[] i20Troy = { "1.2", "1.2 DOHC", "1.4 CRDi", "1.4 CVVT" };
            string[] i30 = { "1.4", "1.4 CVVT", "1.4 MPI", "1.4 T-GDI", "1.6 CRDi", "1.6 CVVT", "1.6 DOHC", "1.6 GDi", "1.6 T-GDI" };
            string[] i40 = { "1.6 GDI Prime", "1.7 CRDi Executive" };
            string[] Ioniq = { "1.6 GDI" };
            string[] iX20 = { "1.4", "1.4 CRDi", "1.6" };
            string[] Matrix = { "1.5 CRDi", "1.6" };
            string[] SCoupe = { "1.5 LS" };
            string[] Sonata = { "2.0", "2.0 CRDi", "2.0 CVVT", "2.0 SOHC", "2.4", "2.5", "2.7", "3.0" };
            string[] Trajet = { "2.0 CRDi GLS", "2.0 GLS", "2.7 V6" };

            // Ikco markası için
            string[] Samand = { "1.6", "1.6 LX" };

            // Infiniti markası için
            string[] Q30 = { "1.5 D", "1.6", "2.0" };
            string[] Q50 = { "2.0T", "2.2d" };
            string[] Q60 = { "2.0" };
            string[] G = { "G35", "G37 GT", "G37 S" };
            string[] I30 = { "3.0" };
            string[] M = { "M30d", "M30d GT", "M30d S" };

            // Jaguar markası için
            string[] Daimler = { "4.0" };
            string[] FType = { "2.0", "2.0 T", "3.0 S" };
            string[] SType = { "2.5", "2.7 D", "3.0", "4.0" };
            string[] Sovereign = { "3.6", "4.0", "4.0 Long" };
            string[] XType = { "2.0", "2.0 D", "2.1", "2.2 D", "2.5", "3.0" };
            string[] XE = { "2.0 D" };
            string[] XF = { "2.0", "2.0 D", "2.2 D", "2.7 D", "3.0", "3.0 D" };
            string[] XJ = { "2.0", "2.0i", "3.0 D", "3.2", "4.0", "XJ6","XJ8" };
            string[] XJR = { "4.0" };
            string[] XJS = { "6.0" };
            string[] XK8 = { "4.0","4.2" };
            string[] XKR = { "4.2" };

            // Kia markası için 
            string[] Capital = { "1.5 GLX", "1.8" };
            string[] Carens = { "1.6", "2.0 CRDi" };
            string[] Carnival = { "2.5", "2.9 CRDI", "2.9 TD", "3.8" };
            string[] Ceed = { "1.0", "1.4", "1.4 T-GDI", "1.5", "1.6", "1.6 CRDi", "1.6 GDI" };
            string[] Cerato = { "1.5 CRDi", "1.6", "1.6 CRDi", "1.6 EX", "1.6 GSL", "1.6 LX", "1.6 MPI", "2.0 CRDi" };
            string[] Clarus = { "1.8 SLX","2.0 GLX" };
            string[] Magentis = { "2.0 CRDi", "2.0 LX", "2.0 SE" };
            string[] Opirus = { "3.5 V6" };
            string[] Optima = { "1.7 CRDi", "2.0 CVVT" };
            string[] Picanto = { "1.0 MPI Cool", "1.0 MPI Feel", "1.0 MPI Live", "1.1 EX", "1.1 Hiper", "1.25 EX", "1.25 MPI Comfort", "1.2 Feel" };
            string[] Pride = { "1.3", "1.3 DLX", "1.3 GLXi" };
            string[] ProCeed = { "1.6", "1.6 CRDi" };
            string[] Rio = { "1.0 TGDI", "1.25 CVVT", "1.2 MPI", "1.3", "1.4 CRDi", "1.4 CVVT", "1.4 EX", "1.4 GSL", "1.4L MPI", "1.4 WGT CRDI", "1.5", "1.5 CRDi" };
            string[] Sephia = { "1.5", "1.6" };
            string[] Shuma = { "GS", "LS", "RS" };
            string[] Stinger = { "2.0 GDI" };
            string[] Venga = { "1.4", "1.4 CRDi", "1.6", "1.6 CRDi" };

            // Lada markası için
            string[] Kalina = { "1.4", "1.6" };
            string[] LadaNova = { "1.3" };
            string[] Priora = { "1.6" };
            string[] Samara = { "1.3", "1.5" };
            string[] Tavria = { "1.2" };
            string[] VAZ = { "1.6","2102","2103","2104","2107" };
            string[] Vega = { "1.5","1.6" };

            // Lamborghini markası için
            string[] Aventador = { "LP 700-4", "LP 750-4" };
            string[] Gallardo = { "LP560-4", "LP 570-4 Superleggera","LP 570-4 Super Trofeo Stradale","Spyder" };
            string[] Huracan = { "Evo", "LP-610-4" };

            // Lancia markası için
            string[] Delta = { "1.4 T", "1.6 Mjet", "1.8" };
            string[] Thema = { "3.0 CRD" };
            string[] Ypsilon = { "0.9", "1.2", "1.3 Mjet","1.4" };
            string[] Dedra = { "1.6" };

            // Leapmotor markası için
            string[] T03 = { "400" };

            //Lexus markası için
            string[] CT = { "200h" };
            string[] ES = { "300h" };
            string[] GS = { "200t" };
            string[] IS = { "200t" };
            string[] LS = { "400","430","500h","600","600h" };

            // Lincoln markası için
            string[] MKS = { "3.5L EcoBoost V6" };
            string[] LContinental = { "4.6" };
            string[] LincolnLS = { "3.9" };
            string[] Mark = { "VIII" };
            string[] MKZ = { "3.5" };
            string[] TownCar = { "4.6" };

            //Lotus markası için
            string[] Elan = { "1.6" };
            string[] Esprit = { "S4" };
            string[] Evora = { "410" };

            // Marcos markası için
            string[] Mantis = { "4.6" };

            // Maserati markası için
            string[] Cambiocorsa = { "Coupe", "Spyder" };
            string[] Ghibli = { "2.0 MHEV", "2.8", "3.0", "3.0 D", "3.0 GDI" };
            string[] GranCabrio = { "4.7" };
            string[] GranSport = { "4.2" };
            string[] GranTurismo = { "4.2","4.7 S","MC-Stradale" };
            string[] GT = { "4200 GT" };
            string[] MC20 = { "3.0" };
            string[] Spyder = { "2.0" };
            string[] Quattroporte = { "2.0", "3.0", "3.0 D", "3.8", "4.2","4.7 S" };

            // Mazda markası için
            string[] Mazda2 = { "1.5 Sky-G", "1.3", "1.5" };
            string[] Mazda3 = { "1.5 SkyActive-D", "1.5 SkyActive-G", "1.6","1.6 D","2.3" };
            string[] Mazda5 = { "1.6", "2.0 CD", "2.0 D" };
            string[] Mazda6 = { "1.8", "2.0", "2.2","2.3 Sport" };
            string[] MX = { "MX-3", "MX-5" };
            string[] Premacy = { "1.8", "2.0", "2.0 DiTD" };
            string[] Mazda121 = {"1.3" };
            string[] Mazda323 = { "1.5", "1.6", "1.7","1.8" };
            string[] Mazda626 = { "1.6", "1.8", "2.0","2.0 DITD" };
            string[] Mazda929 = { "2.0 GLX", "3.0 Royal Classic" };
            string[] Lantis = { "1.6", "1.8"};
            string[] RX = { "RX-7", "RX-8" };
            string[] Xedos = { "6", "9" };

            // McLaren markası için
            string[] McLarenGT = { "4.0" };

            // Mercedes markası için
            string[] ASerisi = { "A 35 AMG", "A 45 AMG", "A 45 S AMG", "A 140", "A 150", "A 160", "A 170", "A 170 CDI", "A 180", "A 180 CDI", "A 180 d", "A 190", "A 200", "A 200 CDI" };
            string[] AMGGTSerisi = { "4.0", "4.0 R", "4.0 S", "43 4Matic", "53 4Matic", "63 S 4Matic" };
            string[] BSerisi = { "B 150", "B 160", "B 170", "B 180", "B 180 CDI", "B 180 D", "B 200", "B 200 CDI" };
            string[] CSerisi = { "C 63 AMG", "C 180", "C 200", "C 200 CDI", "C 200 D", "C 200 d BlueTEC", "C 220", "C 220 BlueTEC", "C 220 CDI", "C 220 d", "C 230", "C 240", "C 250", "C 250 CDI", "C 250 D", "C 250 TD", "C 270 CDI", "C 280", "C 300", "C 320", "C 320 CDI", "C 350 CDI" };
            string[] CL = { "55 AMG", "63 AMG", "500", "600" };
            string[] CLA = { "45 S", "45 AMG", "180", "180 d", "200", "220 CDI", "250 AMG" };
            string[] CLC = { "CLC 160", "CLC 180" };
            string[] CLK = { "CLK 55 AMG", "CLK 200", "CLK 230 Komp.", "CLK 240", "CLK 270 CDI", "CLK 320", "CLK 320 CDI", "CLK 430", "CLK 500" };
            string[] CLS = { "53 AMG", "55 AMG", "63 AMG", "250 CDI", "300 D", "320", "350", "350 CDI", "350 D", "400 D", "500" };
            string[] ESerisi = { "E 55 AMG", "E 63 AMG", "E 180", "E 200", "E 200 CDI", "E 200 CGI", "E 200 d", "E 220", "E 220 CDI", "E 220 d", "E 230", "E 240", "E 250", "E 250 CDI", "E 250 CGI", "E 250 D", "E 270 CDI", "E 280", "E 280 CDI", "E 290 TD", "E 300", "E 300 CGI", "E 300 D", "E 300 TD", "E 320", "E 320 CDI", "E 350", "E 350 CDI", "E 350 CGI", "E 350 D", "E 400", "E 400 CDI", "E 420", "E 430", "E 500" };
            string[] EQE = { "300+", "350+", "350 4Matic", "43 4Matic", "53 AMG" };
            string[] EQS = { "350 AMG", "450+", "53 AMG", "580" };
            string[] MaybachS = { "S 450", "S 500", "S 560", "S 580", "S 600", "S 650", "S 680" };
            string[] RSerisi = { "R 300", "R 320", "R 350" };
            string[] SSerisi = { "S 55 AMG", "S 63 AMG", "S 280", "S300", "S 320", "S 350", "S 400", "S 420", "S 430", "S 450", "S 500", "S 550", "S 560", "S 580", "S 600" };
            string[] SL = { "43 AMG", "55 AMG", "63 AMG", "65 AMG", "280", "300", "320", "350", "400", "500", "550", "600" };
            string[] SLC = { "180 AMG" };
            string[] SLK = { "200", "200 Kompressor", "230 Kompressor", "250", "300 AMG", "350" };
            string[] SLSAMG = { "Coupe" };
            string[] M190 = { "190", "190 D", "190 E" };
            string[] M200 = { "200", "200 D", "200 E", "200 TE" };
            string[] M220 = { "220 CE", "220 D" };
            string[] M230 = { "230", "230.4", "230.6", "230 CE", "230 E", "230 GE", "230 TE" };
            string[] M240 = { "240 D", "240 TD" };
            string[] M250 = { "250", "250 D", "250 TD" };
            string[] M260 = { "260 E", "260 SE" };
            string[] M280 = { "280 E", "280 S", "280 SE", "280 SEL" };
            string[] M300 = { "300", "300 CE", "300 D", "300 E", "300 SD", "300 SE", "300 SEL", "300 TD", "300 TE" };
            string[] M380 = { "380 SE", "380 SEL" };
            string[] M420 = { "420 SE" };
            string[] M500 = { "500 SE", "500 SEC", "500 SEL" };
            string[] M560 = { "560 SEC", "560 SEL" };
            string[] M600 = { "600 SEL" };

            // Mercury markası için
            string[] GranMarquis = { "4.6" };

            // MG markası için
            string[] F = { "1.8" };
            string[] MG4 = { "" };
            string[] ZR = { "160" };
            string[] ZS = { "180" };

            // Mini markası için
            string[] Cooper = { "1.5", "1.5 D", "1.6", "1.6 D", "2.0" };
            string[] CooperClubman = { "1.5", "1.5 D", "1.6", "1.6 S", "2.0" };
            string[] CooperElectric = { "SE" };
            string[] JohnCooper = { "1.6", "2.0" };
            string[] One = { "1.4", "1.6" };
            string[] CooperS = { "1.6", "2.0" };

            // Mitsubishi markası için
            string[] Attrage = { "1.2" };
            string[] Colt = { "1.1", "1.3", "1.5", "1.5 DI-D", "1.6" };
            string[] Galant = { "1.6", "1.8", "2.0", "2.4 GDI" };
            string[] Lancer = { "1.5", "1.6", "1.8" };
            string[] LancerEvolution = { "VI", "VIII", "IX","X" };
            string[] Carisma = { "1.6", "1.8 GDI", "1.9 DI-D" };
            string[] Chariot = { "2.4" };
            string[] Eclipse = { "2.0" };
            string[] Grandis = { "2.0 DI-D" };
            string[] SpaceStar = { "1.2 Intense", "1.2 Invite", "1.3", "1.6", "1.8 GDI" };
            string[] SpaceWagon = { "1800 GLX", "2.4 GDI" };

            // Moskwitsch markası için
            string[] Aleko = { "2140" };

            // Nissan markası için
            string[] N200SX = { "1.8 Turbo", "2.0 Turbo" };
            string[] N350Z = { "3.5" };
            string[] Almera = { "1.5", "1.6", "1.8", "2.0 D", "2.2 DCI" };
            string[] Altima = { "2.0" };
            string[] Bluebird = { "2.0" };
            string[] Cedric = { "3.0" };
            string[] GTR = { "Black Edition", "Premium Edition", "R34", "R35" };
            string[] LaurelAltima = { "1.5", "2.0" };
            string[] Maxima = { "2.0 QX","3.0 QX"};
            string[] Micra = { "1.0", "1.2", "1.3", "1.4", "1.5", "dCi", "1.6" };
            string[] Note = { "1.2", "1.4", "1.5 dCi", "1.6" };
            string[] NXCoupe = { "1.6" };
            string[] Primera = { "1.6", "1.8", "2.0", "2.0 TD", "2.2 TD" };
            string[] Pulsar = { "1.2", "1.5" };
            string[] Sunny = { "1.4", "1.6", "2.0" };
            string[] Tino = { "2.2" };

            // Opel markası için
            string[] Adam = { "1.0", "1.2", "1.4" };
            string[] Agila = { "1.0", "1.2" };
            string[] Ascona = { "1.3 C LS", "1.6", "2.0" };
            string[] Astra = { "1.0 T", "1.2", "1.2 GL", "1.2 T", "1.3 CDTI", "1.4", "1.4 T", "1.5 D", "1.6", "1.6 CDTI", "1.6 T", "1.7 CDTI", "1.7 D", "1.7 DTI", "1.8", "1.9 CDTI", "2.0", "2.0 CDTI", "2.0 DTI Comfort", "2.0 T", "2.2" };
            string[] Calibra = { "2.0", "2.0 Turbo" };
            string[] Cascada = { "1.6 XHT Cosmo", "2.0 DTH Cosmo" };
            string[] Corsa = { "1.0", "1.0 T", "1.2", "1.2 T", "1.2 Twinport", "1.3 CDTI", "1.4", "1.4 Twinport", "1.5 D", "1.5 D Swing", "1.5 TD", "1.6", "1.7 DTI Comfort" };
            string[] GTRoadster = { "GT 2.0 Turbo" };
            string[] Insignia = { "1.4 T", "1.5 D", "1.5 T", "1.6", "1.6 CDTI", "1.6 D", "1.6 T", "2.0 CDTI", "2.0 T", "2.8" };
            string[] Kadett = { "1.3", "1.4", "1.6", "1.6 D", "1.7 D", "2.0"  };
            string[] Meriva = { "1.3 CDTI", "1.3 DTI", "1.4", "1.4 T", "1.6", "1.6 CDTI","1.7 CDTI" };
            string[] Omega = { "1.8", "2.0", "2.2", "2.5", "2.5 TD", "2.6","3.0","3.2" };
            string[] Rekord = { "1.7","2.0" };
            string[] Senator = { "2.6" };
            string[] Signum = { "1.9 CDTI", "2.0 DTI", "2.2", "3.0 CDTi", "3.2" };
            string[] Tigra = { "1.4", "1.4 TT Sport","1.6" };
            string[] Vectra = { "1.6", "1.7 GL", "1.7 TD GLS", "1.8", "1.9 CDTI", "2.0", "2.0 DTI","2.0 T","2.2","2.2 DTI","2.5","2.6 Sport","3.0 CDTI","3.2 GTS" };
            string[] Zafira = { "1.4", "1.6", "1.6 CDTI", "1.8", "1.9 CDTI", "2.0 CDTI", "2.0 DTI","2.0 T","2.2 DTI" };

            // Peugeot markası için
            string[] P106 = { "GTI", "QuickSilver","XN","XR","XS","XSi","XT" };
            string[] P107 = { "1.0", "1.4 Hdi" };
            string[] P205 = { "1.0", "1.1", "1.4", "1.6", "1.9" };
            string[] P206 = { "1.4", "1.4 HDi", "1.6", "1.6 HDi", "2.0", "2.0 HDi" };
            string[] P206plus = { "1.4", "1.4 HDi" };
            string[] P207 = { "1.4", "1.4 HDi", "1.4 VTi", "1.6", "1.6 HDi", "1.6 THP", "1.6 VTi" };
            string[] P208 = { "1.0 VTi", "1.2 PureTech", "1.2 VTi","1.4 HDi","1.5 BlueHDi","1.6 BlueHdi","1.6 e-HDi","1.6 HDi","1.6 THP","1.6 VTi" };
            string[] P301 = { "1.2", "1.2 PureTech", "1.2 VTi", "1.5 BlueHDi", "1.6 BlueHdi", "1.6 HDi", "1.6 VTi" };
            string[] P305 = { "1.6", "1.9" };
            string[] P306 = { "1.4", "1.6", "1.8", "2.0", "2.0 HDi" };
            string[] P307 = { "1.4", "1.4 HDi", "1.6", "1.6 HDi", "2.0", "2.0 HDi" };
            string[] P308 = { "1.2", "1.2 Puretech", "1.2 VTi", "1.5 BlueHDI", "1.6 BlueHDi", "1.6 e-HDi", "1.6 HDi", "1.6 THP", "1.6 VTi" };
            string[] P309 = { "1.9 GTi" };
            string[] P405 = { "1.6", "1.8", "1.9", "2.0" };
            string[] P406 = { "1.8", "2.0", "2.0 HDi", "2.2", "3.0" };
            string[] P407 = { "1.6 HDi", "2.0", "2.0 Hdi", "2.2", "3.0" };
            string[] P508 = { "1.5 BlueHDi", "1.6 BlueHDi", "1.6 e-HDi", "1.6 HDi", "1.6 Puretech", "1.6 THP", "1.6 VTi", "2.0 HDi", "2.2 HDi" };
            string[] P605 = { "2.0 SRi", "2.0 SRTi", "2.0 SVTi" };
            string[] P607 = { "2.0 HDi", "2.2", "2.2 HDi", "2.7 HDi", "3.0" };
            string[] P806 = { "1.9", "2.0" };
            string[] P807 = { "2.0", "2.2 HDi Executive" };
            string[] RCZ = { "1.6 THP" };

            //Plymouth markası için
            string[] Laser = { "2.0 L" };

            //Pontiac markası için
            string[] Firebird = { "5.7 Trans Am", "5.7 V8 Formula" };
            string[] Solstice = { "2.4" };
            string[] Sunbird = { "LE" };

            // Porsche markası için
            string[] Prs718 = { "718", "Boxster", "Cayman" };
            string[] Prs911 = { "Carrera", "Carrera 2", "Carrera 4", "Carrera 4 GTS", "Carrera 4S", "Carrera GTS", "Carrera S", "GT2", "GT2 RS", "GT3", "GT3 RS", "Targa 4 GTS", "Targa 4S", "Turbo", "Turbo S", "Turbo S Cabriolet" };
            string[] Prs928 = { "S4" };
            string[] Boxster = { "Boxster", "S" };
            string[] Cayman = { "Cayman", "GT4 RS", "S" };
            string[] Panamera = { "Panamera", "Panamera Diesel", "Panamera GTS", "Panamera S", "Panamera S Hybrid", "Panamera 4", "Panamera 4-10 Years Edition", "Panamera 4-10 Years Edition E-Hybrid", "Panamera 4 E-Hybrid", "Panamera 4 Executive", "Panamera 4 Platinum Ediion", "Panamera 4 Sport Turismo", "Panamera 4S", "Panamera 4S Diesel", "Panamera 4S E-Hybrid", "Panamera Turbo", "Panamera Turbo S E-Hybrid" };
            string[] Taycan = { "4 Cross Turismo", "4S", "4S Performance", "4S Performance Plus", "4S Sport Turismo", "GTS", "Taycan", "Turbo", "Turbo Cross Turismo", "Turbo S", "Turbo S Cross Turismo" };

            // Proton markası için
            string[] Gen2 = { "1.6" };
            string[] Saga = { "1.6" };
            string[] Savvy = { "1.2" };
            string[] Waja = { "1.6" };
            string[] Prot218 = { "GLXi" };
            string[] Prot315 = { "GLSi" };
            string[] Prot316 = { "GLSi" };
            string[] Prot413 = { "GLSi" };
            string[] Prot415 = { "GLi","GLSi" };
            string[] Prot416 = { "GLXi" };
            string[] Prot418 = { "GLXi" };
            string[] Prot420 = { "TD GLS" };
            string[] Persona = { "1.6" };

            //Renault markası için
            string[] Avantime = { "3.0" };
            string[] Clio = { "0.9 Sport Tourer", "0.9 TCe", "1.0 SCe", "1.0 TCe", "1.2", "1.2 Grandtour", "1.2 SportTourer", "1.3 TCe", "1.4", "1.4 Grendtour", "1.5 BlueDCI", "1.5 dCi", "1.5 dCi Grandtour", "1.5 dCi SportTourer", "1.6", "1.6 Grandtour", "1.8", "1.9 D", "2.0" };
            string[] Espace = { "1.6 dCi", "1.9 Ci", "2.0", "2.0 dCi", "2.0 T", "2.0 TD", "2.2", "3.0" };
            string[] Fluence = {"1.5 dCi","1.6","1.6 dCi" };
            string[] FluenceZE = { "Dynamique" };
            string[] GranEspace = { "3.5 V6" };
            string[] GrandScenic = { "1.4 T", "1.5 dCi", "1.6", "1.9 dCi", "2.0 dCi" };
            string[] Laguna = { "1.6", "1.8", "2.0", "2.0 T", "3.0" };
            string[] Latitude = { "1.5 dCi", "2.0 dCi", "3.0 dCi" };
            string[] Megane = { "1.4","1.6","1.8","2.0" };
            string[] Modus = { "1.4", "1.5 dCi", "1.6" };
            string[] Safrane = { "2.0", "2.2", "2.5" };
            string[] Scenic = { "1.6", "2.0" };
            string[] Symbol = { "1.2", "1.4" };
            string[] Taliant = { "1.0 Sce", "1.0 T" };
            string[] Talisman = { "1.3 Tce", "1.5 dCi", "1.6 dCi" };
            string[] Twingo = { "1.2", "1.3" };
            string[] Twizy = { "75" };
            string[] VelSatis = { "2.0 T", "2.2 dCi", "3.0 dCi", "3.5" };
            string[] Zoe = { "Intense", "ZOE" };
            string[] R5 = { "1.1", "1.4" };
            string[] R9 = { "1.4 Brodway", "1.4", "1.6", "1.7" };
            string[] R11 = { "Flash", "Flash S", "GTL", "GTS", "GTX", "Rainbow", "TX" };
            string[] R12 = { "GTS", "SW", "TL", "Toros" };
            string[] R19 = { "1.4 Europa", "1.6 Europa", "1.7 Europa", "1.8 Europa", "1.9 Europa" };
            string[] R21 = { "1.6", "1.7", "2.0" };
            string[] R25 = { "2.0", "2.2" };

            // Rolls Royce markası için
            string[] Dawn = { "6.6" };
            string[] Ghost = { "6.6" };
            string[] Phantom = { "Phantom" };
            string[] Wraith = { "Wraith" };

            // Rover markası için
            string[] Rov25 ={ "1.4","1.6"};
            string[] Rov45 ={ "1.6","2.0"};
            string[] Rov75 ={ "1.8","2.0","2.5"};
            string[] Rov200 ={ "Si","Vi"};
            string[] Rov214 ={ "i","Si","SLi"};
            string[] Rov216 ={"Cabrio","Coupe","Si" };
            string[] Rov220 ={"SD" };
            string[] Rov400 ={ "2.0"};
            string[] Rov414 ={ "Si"};
            string[] Rov416 ={ "Si","SLi"};
            string[] Rov420 ={ "Si"};
            string[] Rov620 ={ "Si","Ti"};
            string[] Rov820 = { "Si", "Ti" };
            string[] Rov827 = { "Si" };
            string[] Streetwise ={ "1.4"};

            // Saab markası için
            string[] S93 = { "2.0", "2.0 T" };
            string[] S95 = { "2.0", "3.0" };
            string[] S900 = { "2.0", "2.3" };
            string[] S9000 = { "2.0", "2.3" };

            // Seat markası için
            string[] Alhambra = { "1.4 TSI", "1.9 TDI", "2.0" };
            string[] Altea = { "1.6", "2.0 TDI" };
            string[] Arosa = { "1.0 EcoTSI" };
            string[] Cordoba = { "1.4", "1.6", "1.8" };
            string[] Exeo = { "1.6" };
            string[] Ibiza = { "1.2", "1.3", "1.4" };
            string[] Leon = { "1.4", "1.6", "1.8" };
            string[] Marbella = { "903 Special" };
            string[] Toledo = { "1.6", "1.8", "2.0" };

            // Skoda markası için
            string[] Citigo= {  "1.0" };
            string[] Fabia= { "1.6", "1.2" };
            string[] Favorit = { "1.3","1.4" };
            string[] Felicia = { "1.3", "1.6"};
            string[] Forman = { "GLX","LE","LX" };
            string[] Octovia = { "1.6", "1.8", "2.0" };
            string[] Rapid = { "1.2" };
            string[] Roomster = { "1.2 ","1.4","1.6"};
            string[] Scala = { "1.0 TSI", "1.5 TSI", "1.6 TDI" };
            string[] Superb = { "1.4 TSI", "1.5 TSI", "1.6 TDI" };

            // Smart markası için
            string[] Fortwo= { "1.0" };
            string[] Forfour = { "1.0", "1.1" };
            string[] Roadster = { "Roadster"};

            // Subaru markası için
            string[] BRZ = { "2.0 Premium" };
            string[] Impreza = { "1.5", "1.6" };
            string[] Legacy = { "1.8", "2.0" };
            string[] Levorg = {  "1.6" };
            string[] Justy = { "1.0", "1.2 GLi" };
            string[] SVX = { "3.3"};
            string[] Vivio = { "2WD GL" };

            // Suzuki markası için
            string[] Alto = { "1.0" };
            string[] Baleno= { "1.6", "1.2" };
            string[] Reno= { "2.0i", };
            string[] Splash= { "1.2 GA", "1.2 GLS" };
            string[] Swift = { "1.0", "1.2", "1.3" };
            string[] SX4 = { "1.6" };
            string[] Liana= { "1.6 GLX" };
            string[] Maruti = { "800" };

            // Tata markası için
            string[] Indica = { "1.4 Basic" };
            string[] Indigo = { "1.4 TDI Comfort" };
            string[] Marina = { "1.4 TDI Comfort" };
            string[] Vista = { "1.3 TDI"};
            string[] Manza = { "Aura 1.4 Safire" };

            // Tesla markası için
            string[] Model3 = { "Long Range","Standart Plus" };
            string[] ModelS= { "75" };
            string[] ModelX = { "75D" };
            string[] ModelY = { "Long Range" };

            // Tofaş markası için
            string[] Dogan = { "L","S","SLX" };
            string[] Kartal= { "L", "S", "SLX" };
            string[] Murat = { "124","131" };
            string[] Sahin = { "1.4" ,"S"};
            string[] Serce= { "Serçe "};

            //toyota markası için
            string[] Auris= { "1.33","1.6" };
            string[] Avensis= { "1.6", "1.8", "2.0"};
            string[] Camry = {  "2.4", "3.0" };
            string[] Carina= {  "1.6", "2.0" };
            string[] Celica = { "1.6" };
            string[] Corolla = { "1.3","1.6","1.8" };
            string[] Corona= { "1.6 XL" };
            string[] Cressida= { "2.0 GLX" };
            string[] GT86 = {  "2.0 " };
            string[] MR2 = { "Roadster" };
            string[] Paseo = {  "1.5" };
            string[] Picnic= { "2.0" };
            string[] Previa = {  "2.4" };
            string[] Prius = { "1.5 Hybrid" };
            string[] Starlet = { "1.3" };
            string[] Supra = { "3.0 Turbo" };
            string[] UrbanCruiser= { "1.33" };
            string[] Verso = { "1.6","1.8" };
            string[] Windom = {  "3.0 " };
            string[] Yaris = { "1.0", "1.3" };

            //Volkswagen markası için
            string[] Arteon = { "1.5 TSI" };
            string[] Beetle = { "1.2 TSI", "1.3", "1.4"};
            string[] Bora = { "1.6", "1.9 TDI", "2.3" };
            string[] EOS= { "1.4 TSI", "1.6 FSi", "2.0" };
            string[] FOX = { "1.2" };
            string[] Golf = { "1.4","1.3","1.9" };
            string[] ID3 = { "Life" };
            string[] Jetta = { "1.6", "1.8", "2.0" };
            string[] Lupo = { "1.2 TDI", "1.4" };
            string[] Passat= {  "1.6", "1.8", "2.0" };
            string[] PassatAlltrack = { "2.0 TDI"};
            string[] PassatVariant = { "1.6", "1.8", "1.9" };
            string[] Phateon= { "3.2", "4.2" };
            string[] Polo = { "1.2", "1.4" };
            string[] Scirocco = { "1.4 TSI", "2.0" };
            string[] Sharan = { "1.9 TDI" };
            string[] Touran = { "1.6", "1.9 TDI" };
            string[] UpClub = { "1.0" };
            string[] VWCC = { "1.4 TSI", "2.0 TDI" };
            string[] Vento = { "1.6", "1.8" };

            //Volvo markası için
            string[] C30 = { "1.6" };
            string[] C70 = { "2.3", "2.5"};
            string[] S40= { "1.6", "1.8", "2.0" };
            string[] S60 = { "1.6", "1.6 D", "2.0 T" };
            string[] S70 = { "2.0 T" };
            string[] S80 = { "1.6 D", "2.4", "2.9" };
            string[] S90 = { "3.0" };
            string[] V40 = { "1.6", "1.5", "2.0" };
            string[] V40CrossC= { "1.5 T3", "1.6 D" };
            string[] V50= { "1.6", "1.6 D" };
            string[] V60 = { "2.0 D3" };
            string[] V60CrossC = { "2.0 B4", "2.0 B5", "2.0 D4" };
            string[] V70 = { "2.0 T", "2.4 D" };
            string[] V90CrossC = { "2.0 B6" };
            string[] V440 = {  "2.0 GLE" };
            string[] V740 = { "GLE" };
            string[] V850 = { "2.0 GLE" };
            string[] V940= { "2.0 GL" };
            string[] V960 = { "3.0" };

            // XEV markası için
            string[] Yoyo = { "Yoyo" };
         


            // Seçilen seriye göre model getirilmesi

            // Acura markası için
            if (comboBox1.Text=="Acura" & comboBox2.Text == "RSX")
            {
                comboBox3.DataSource = RSX;
            }
            // Aion markası için
            if (comboBox1.Text=="Aion" & comboBox2.Text == "S")
            {
                comboBox3.DataSource = S;
            }
            // Alfa Romeo markası için
            if (comboBox1.Text=="Alfa Romeo" & comboBox2.Text == "Giulia")
            {
                comboBox3.DataSource = Giulia;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "Giulietta")
            {
                comboBox3.DataSource = Giulietta;
            }
            if (comboBox1.Text == "Alfa Romeo" &comboBox2.Text == "145")
            {
                comboBox3.DataSource = ARomeo145;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "146")
            {
                comboBox3.DataSource = ARomeo146;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "147")
            {
                comboBox3.DataSource = ARomeo147;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "155")
            {
                comboBox3.DataSource = ARomeo155;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "156")
            {
                comboBox3.DataSource = ARomeo156;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "159")
            {
                comboBox3.DataSource = ARomeo159;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "164")
            {
                comboBox3.DataSource = ARomeo164;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "166")
            {
                comboBox3.DataSource = ARomeo166;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "33")
            {
                comboBox3.DataSource = ARomeo33;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "Brera")
            {
                comboBox3.DataSource = Brera;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "GT")
            {
                comboBox3.DataSource = AromeoGT;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "GTV")
            {
                comboBox3.DataSource = AromeoGTV;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "Mito")
            {
                comboBox3.DataSource = Mito;
            }
            if (comboBox1.Text == "Alfa Romeo" & comboBox2.Text == "Spider")
            {
                comboBox3.DataSource = Spider;
            }
            // Anadol markası için
            if (comboBox1.Text == "Anadol" & comboBox2.Text == "A")
            {
                comboBox3.DataSource = AnadolA;
            }
            if (comboBox1.Text == "Anadol" & comboBox2.Text == "SV")
            {
                comboBox3.DataSource = AnadolSV;
            }
            // Aston Martin markası için
            if (comboBox1.Text == "Aston Martin" & comboBox2.Text == "DB11")
            {
                comboBox3.DataSource = DB11;
            }
            if (comboBox1.Text == "Aston Martin" & comboBox2.Text == "DB7")
            {
                comboBox3.DataSource = DB7;
            }
            if (comboBox1.Text == "Aston Martin" & comboBox2.Text == "DB9")
            {
                comboBox3.DataSource = DB9;
            }
            if (comboBox1.Text == "Aston Martin" & comboBox2.Text == "DBS")
            {
                comboBox3.DataSource = DBS;
            }
            if (comboBox1.Text == "Aston Martin" & comboBox2.Text == "Rapide")
            {
                comboBox3.DataSource = Rapide;
            }
            if (comboBox1.Text == "Aston Martin" & comboBox2.Text == "Vanquish")
            {
                comboBox3.DataSource = Vanquish;
            }
            if (comboBox1.Text == "Aston Martin" & comboBox2.Text == "Vantage")
            {
                comboBox3.DataSource = Vantage;
            }
            if (comboBox1.Text == "Aston Martin" & comboBox2.Text == "Virage")
            {
                comboBox3.DataSource = Virage;
            }
            // Audi Markası için
            if (comboBox1.Text == "Audi" & comboBox2.Text == "A1")
            {
                comboBox3.DataSource = Audia1;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "A3")
            {
                comboBox3.DataSource = Audia3;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "A4")
            {
                comboBox3.DataSource = Audia4;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "A5")
            {
                comboBox3.DataSource = Audia5;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "A6")
            {
                comboBox3.DataSource = Audia6;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "A7")
            {
                comboBox3.DataSource = Audia7;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "A8")
            {
                comboBox3.DataSource = Audia8;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "E-Tron GT")
            {
                comboBox3.DataSource = ETronGT;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "R8")
            {
                comboBox3.DataSource = R8;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "RS")
            {
                comboBox3.DataSource = RS;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "S Serisi")
            {
                comboBox3.DataSource = AudiS;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "TT")
            {
                comboBox3.DataSource = AudiTT;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "TTS")
            {
                comboBox3.DataSource = AudiTTS;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "80 Serisi")
            {
                comboBox3.DataSource = Audi80Serisi;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "90 Serisi")
            {
                comboBox3.DataSource = Audi90Serisi;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "100 Serisi")
            {
                comboBox3.DataSource = Audi100Serisi;
            }
            if (comboBox1.Text == "Audi" & comboBox2.Text == "200 Serisi")
            {
                comboBox3.DataSource = Audi200Serisi;
            }
            // Bentley markası için
            if (comboBox1.Text == "Bentley" & comboBox2.Text == "Continental")
            {
                comboBox3.DataSource = Continental;
            }
            if (comboBox1.Text == "Bentley" & comboBox2.Text == "Flying Spur")
            {
                comboBox3.DataSource = FlyingSpur;
            }
            if (comboBox1.Text == "Bentley" & comboBox2.Text == "Arnage")
            {
                comboBox3.DataSource = Arnage;
            }
            // BMW markası için
            if (comboBox1.Text == "BMW" & comboBox2.Text == "1 Serisi")
            {
                comboBox3.DataSource = Bmw1Serisi;
            }
            if (comboBox1.Text == "BMW" & comboBox2.Text == "2 Serisi")
            {
                comboBox3.DataSource = Bmw2Serisi;
            }
            if (comboBox1.Text == "BMW" & comboBox2.Text == "3 Serisi")
            {
                comboBox3.DataSource = Bmw3Serisi;
            }
            if (comboBox1.Text == "BMW" & comboBox2.Text == "4 Serisi")
            {
                comboBox3.DataSource = Bmw4Serisi;
            }
            if (comboBox1.Text == "BMW" & comboBox2.Text == "5 Serisi")
            {
                comboBox3.DataSource = Bmw5Serisi;
            }
            if (comboBox1.Text == "BMW" & comboBox2.Text == "6 Serisi")
            {
                comboBox3.DataSource = Bmw6Serisi;
            }
            if (comboBox1.Text == "BMW" & comboBox2.Text == "7 Serisi")
            {
                comboBox3.DataSource = Bmw7Serisi;
            }
            if (comboBox1.Text == "BMW" & comboBox2.Text == "8 Serisi")
            {
                comboBox3.DataSource = Bmw8Serisi;
            }
            if (comboBox1.Text == "BMW" & comboBox2.Text == "i Serisi")
            {
                comboBox3.DataSource = BmwiSerisi;
            }
            if (comboBox1.Text == "BMW" & comboBox2.Text == "M Serisi")
            {
                comboBox3.DataSource = BmwMSerisi;
            }
            if (comboBox1.Text == "BMW" & comboBox2.Text == "Z Serisi")
            {
                comboBox3.DataSource = BmwZSerisi;
            }
            // Bugatti markası için
            if (comboBox1.Text == "Bugatti" & comboBox2.Text == "Chiron")
            {
                comboBox3.DataSource = Chiron;
            }

            // Buick markası için
            if (comboBox1.Text == "Buick" & comboBox2.Text == "Century")
            {
                comboBox3.DataSource = Century;
            }
            if (comboBox1.Text == "Buick" & comboBox2.Text == "Le Sabre")
            {
                comboBox3.DataSource = LeSabre;
            }
            if (comboBox1.Text == "Buick" & comboBox2.Text == "Park Avenue")
            {
                comboBox3.DataSource = ParkAvenue;
            }
            if (comboBox1.Text == "Buick" & comboBox2.Text == "Regal")
            {
                comboBox3.DataSource = Regal;
            }
            if (comboBox1.Text == "Buick" & comboBox2.Text == "Riviera")
            {
                comboBox3.DataSource = Riviera;
            }

            // Cadillac markası için
            if (comboBox1.Text == "Cadillac" & comboBox2.Text == "CTS")
            {
                comboBox3.DataSource = CTS;
            }
            if (comboBox1.Text == "Cadillac" & comboBox2.Text == "BLS")
            {
                comboBox3.DataSource = BLS;
            }
            if (comboBox1.Text == "Cadillac" & comboBox2.Text == "Brougham")
            {
                comboBox3.DataSource = Brougham;
            }
            if (comboBox1.Text == "Cadillac" & comboBox2.Text == "DeVille")
            {
                comboBox3.DataSource = DeVille;
            }
            if (comboBox1.Text == "Cadillac" & comboBox2.Text == "Eldorado")
            {
                comboBox3.DataSource = Eldorado;
            }
            if (comboBox1.Text == "Cadillac" & comboBox2.Text == "Fleetwood")
            {
                comboBox3.DataSource = Fleetwood;
            }
            if (comboBox1.Text == "Cadillac" & comboBox2.Text == "Seville")
            {
                comboBox3.DataSource = Seville;
            }
            if (comboBox1.Text == "Cadillac" & comboBox2.Text == "STS")
            {
                comboBox3.DataSource = STS;
            }

            // Chery markası için
            if (comboBox1.Text == "Chery" & comboBox2.Text == "Alia")
            {
                comboBox3.DataSource = Alia;
            }
            if (comboBox1.Text == "Chery" & comboBox2.Text == "Chance")
            {
                comboBox3.DataSource = Chance;
            }
            if (comboBox1.Text == "Chery" & comboBox2.Text == "Kimo")
            {
                comboBox3.DataSource = Kimo;
            }
            if (comboBox1.Text == "Chery" & comboBox2.Text == "QQ6")
            {
                comboBox3.DataSource = QQ6;
            }
            if (comboBox1.Text == "Chery" & comboBox2.Text == "Niche")
            {
                comboBox3.DataSource = Niche;
            }
            // Chevrolet markası için
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Aveo")
            {
                comboBox3.DataSource = Aveo;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Camaro")
            {
                comboBox3.DataSource = Camaro;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Caprice")
            {
                comboBox3.DataSource = Caprice;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Celebrity")
            {
                comboBox3.DataSource = Celebrity;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Corvette")
            {
                comboBox3.DataSource = Corvette;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Cruze")
            {
                comboBox3.DataSource = Cruze;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Epica")
            {
                comboBox3.DataSource = Epica;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Evanda")
            {
                comboBox3.DataSource = Evanda;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Impala")
            {
                comboBox3.DataSource = Impala;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Kalos")
            {
                comboBox3.DataSource = Kalos;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Lacetti")
            {
                comboBox3.DataSource = Lacetti;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Malibu")
            {
                comboBox3.DataSource = Malibu;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Monte Carlo")
            {
                comboBox3.DataSource = MonteCarlo;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Rezzo")
            {
                comboBox3.DataSource = Rezzo;
            }
            if (comboBox1.Text == "Chevrolet" & comboBox2.Text == "Spark")
            {
                comboBox3.DataSource = Spark;
            }
            // Chyresler markası için
            if (comboBox1.Text == "Chyresler" & comboBox2.Text == "300 C")
            {
                comboBox3.DataSource = Chyr300C;
            }
            if (comboBox1.Text == "Chyresler" & comboBox2.Text == "300 M")
            {
                comboBox3.DataSource = Chyr300M;
            }
            if (comboBox1.Text == "Chyresler" & comboBox2.Text == "Concorde")
            {
                comboBox3.DataSource = Concorde;
            }
            if (comboBox1.Text == "Chyresler" & comboBox2.Text == "Crossfire")
            {
                comboBox3.DataSource = Crossfire;
            }
            if (comboBox1.Text == "Chyresler" & comboBox2.Text == "LHS")
            {
                comboBox3.DataSource = LHS;
            }
            if (comboBox1.Text == "Chyresler" & comboBox2.Text == "PT Cruiser")
            {
                comboBox3.DataSource = PTCruiser;
            }
            if (comboBox1.Text == "Chyresler" & comboBox2.Text == "Sebring")
            {
                comboBox3.DataSource = Sebring;
            }
            if (comboBox1.Text == "Chyresler" & comboBox2.Text == "Stratus")
            {
                comboBox3.DataSource = Stratus;
            }

            // Citroen markası için
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "AMI")
            {
                comboBox3.DataSource = AMI;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "C-Elysee")
            {
                comboBox3.DataSource = CElysee;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "C1")
            {
                comboBox3.DataSource = C1;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "C2")
            {
                comboBox3.DataSource = C2;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "C3")
            {
                comboBox3.DataSource = C3;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "C3 Picasso")
            {
                comboBox3.DataSource = C3Picasso;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "C4")
            {
                comboBox3.DataSource = C4;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "C4 Gran Picasso")
            {
                comboBox3.DataSource = C4GranPicasso;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "C4 Picasso")
            {
                comboBox3.DataSource = C4Picasso;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "C5")
            {
                comboBox3.DataSource = C5;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "C6")
            {
                comboBox3.DataSource = C6;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "C8")
            {
                comboBox3.DataSource = C8;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "Saxo")
            {
                comboBox3.DataSource = Saxo;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "Xsara")
            {
                comboBox3.DataSource = Xsara;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "AX")
            {
                comboBox3.DataSource = AX;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "BX")
            {
                comboBox3.DataSource = BX;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "Evasion")
            {
                comboBox3.DataSource = Evasion;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "Xantia")
            {
                comboBox3.DataSource = Xantia;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "XM")
            {
                comboBox3.DataSource = XM;
            }
            if (comboBox1.Text == "Citroen" & comboBox2.Text == "ZX")
            {
                comboBox3.DataSource = ZX;
            }

            // Dacia markası için
            if (comboBox1.Text == "Dacia" & comboBox2.Text == "Jogger")
            {
                comboBox3.DataSource = Jogger;
            }
            if (comboBox1.Text == "Dacia" & comboBox2.Text == "Lodgy")
            {
                comboBox3.DataSource = Lodgy;
            }
            if (comboBox1.Text == "Dacia" & comboBox2.Text == "Logan")
            {
                comboBox3.DataSource = Logan;
            }
            if (comboBox1.Text == "Dacia" & comboBox2.Text == "Sandero")
            {
                comboBox3.DataSource = Sandero;
            }
            if (comboBox1.Text == "Dacia" & comboBox2.Text == "1310")
            {
                comboBox3.DataSource = Dacia1310;
            }
            if (comboBox1.Text == "Dacia" & comboBox2.Text == "Nova")
            {
                comboBox3.DataSource = Nova;
            }
            if (comboBox1.Text == "Dacia" & comboBox2.Text == "Solenza")
            {
                comboBox3.DataSource = Solenza;
            }
            // Daewoo markası için
            if (comboBox1.Text == "Daewoo" & comboBox2.Text == "Chairman")
            {
                comboBox3.DataSource = Chairman;
            }
            if (comboBox1.Text == "Daewoo" & comboBox2.Text == "Nexia")
            {
                comboBox3.DataSource = Nexia;
            }
            if (comboBox1.Text == "Daewoo" & comboBox2.Text == "Nubira")
            {
                comboBox3.DataSource = Nubira;
            }
            if (comboBox1.Text == "Daewoo" & comboBox2.Text == "Espero")
            {
                comboBox3.DataSource = Espero;
            }
            if (comboBox1.Text == "Daewoo" & comboBox2.Text == "Lanos")
            {
                comboBox3.DataSource = Lanos;
            }
            if (comboBox1.Text == "Daewoo" & comboBox2.Text == "Leganza")
            {
                comboBox3.DataSource = Leganza;
            }
            if (comboBox1.Text == "Daewoo" & comboBox2.Text == "Matiz")
            {
                comboBox3.DataSource = Matiz;
            }
            if (comboBox1.Text == "Daewoo" & comboBox2.Text == "Super Saloon")
            {
                comboBox3.DataSource = SuperSaloon;
            }
            if (comboBox1.Text == "Daewoo" & comboBox2.Text == "Tico")
            {
                comboBox3.DataSource = Tico;
            }

            // Daihatsu markası için
            if (comboBox1.Text == "Daihatsu" & comboBox2.Text == "Cuore")
            {
                comboBox3.DataSource = Cuore;
            }
            if (comboBox1.Text == "Daihatsu" & comboBox2.Text == "Materia")
            {
                comboBox3.DataSource = Materia;
            }
            if (comboBox1.Text == "Daihatsu" & comboBox2.Text == "Move")
            {
                comboBox3.DataSource = Move;
            }
            if (comboBox1.Text == "Daihatsu" & comboBox2.Text == "Sirion")
            {
                comboBox3.DataSource = Sirion;
            }
            if (comboBox1.Text == "Daihatsu" & comboBox2.Text == "Applause")
            {
                comboBox3.DataSource = Applause;
            }
            if (comboBox1.Text == "Daihatsu" & comboBox2.Text == "Charade")
            {
                comboBox3.DataSource = Charade;
            }
            if (comboBox1.Text == "Daihatsu" & comboBox2.Text == "Copen")
            {
                comboBox3.DataSource = Copen;
            }
            if (comboBox1.Text == "Daihatsu" & comboBox2.Text == "YRV")
            {
                comboBox3.DataSource = YRV;
            }
            // Dodge markası için
            if (comboBox1.Text == "Dodge" & comboBox2.Text == "Avenger")
            {
                comboBox3.DataSource = Avenger;
            }
            if (comboBox1.Text == "Dodge" & comboBox2.Text == "Challenger")
            {
                comboBox3.DataSource = Challenger;
            }
            if (comboBox1.Text == "Dodge" & comboBox2.Text == "Charger")
            {
                comboBox3.DataSource = Charger;
            }
            if (comboBox1.Text == "Dodge" & comboBox2.Text == "Magnum")
            {
                comboBox3.DataSource = Magnum;
            }
            if (comboBox1.Text == "Dodge" & comboBox2.Text == "Stealth")
            {
                comboBox3.DataSource = Stealth;
            }
            // Ds Automobiles markası için
            if (comboBox1.Text == "DS Automobiles" & comboBox2.Text == "DS 3")
            {
                comboBox3.DataSource = DS3;
            }
            if (comboBox1.Text == "DS Automobiles" & comboBox2.Text == "DS 4")
            {
                comboBox3.DataSource = DS4;
            }
            if (comboBox1.Text == "DS Automobiles" & comboBox2.Text == "DS 5")
            {
                comboBox3.DataSource = DS5;
            }
            if (comboBox1.Text == "DS Automobiles" & comboBox2.Text == "DS 9")
            {
                comboBox3.DataSource = DS9;
            }

            // Ferrari markası için
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "360")
            {
                comboBox3.DataSource = F360;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "430")
            {
                comboBox3.DataSource = F430;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "458")
            {
                comboBox3.DataSource = F458;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "488")
            {
                comboBox3.DataSource = F488;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "512")
            {
                comboBox3.DataSource = F512;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "575")
            {
                comboBox3.DataSource = F575;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "599")
            {
                comboBox3.DataSource = F599;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "612")
            {
                comboBox3.DataSource = F612;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "California")
            {
                comboBox3.DataSource = California;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "F12")
            {
                comboBox3.DataSource = F12;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "F355")
            {
                comboBox3.DataSource = F355;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "F8")
            {
                comboBox3.DataSource = F8;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "Portofino")
            {
                comboBox3.DataSource = Portofino;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "Roma")
            {
                comboBox3.DataSource = Roma;
            }
            if (comboBox1.Text == "Ferrari" & comboBox2.Text == "SF90")
            {
                comboBox3.DataSource = SF90;
            }
            //Fiat markası için
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "124 Spider")
            {
                comboBox3.DataSource = F124Spider;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Albea")
            {
                comboBox3.DataSource = Albea;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Brava")
            {
                comboBox3.DataSource = Brava;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Bravo")
            {
                comboBox3.DataSource = Bravo;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "126 Bis")
            {
                comboBox3.DataSource = F126Bis;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Coupe")
            {
                comboBox3.DataSource = Coupe;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Croma")
            {
                comboBox3.DataSource = Croma;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "500 Ailesi")
            {
                comboBox3.DataSource = F500ailesi;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Egea")
            {
                comboBox3.DataSource = Egea;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Idea")
            {
                comboBox3.DataSource = Idea;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Linea")
            {
                comboBox3.DataSource = Linea;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Marea")
            {
                comboBox3.DataSource = Marea;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Palio")
            {
                comboBox3.DataSource = Palio;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Panda")
            {
                comboBox3.DataSource = Panda;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Punto")
            {
                comboBox3.DataSource = Punto;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Seicento")
            {
                comboBox3.DataSource = Seicento;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Siena")
            {
                comboBox3.DataSource = Siena;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Stilo")
            {
                comboBox3.DataSource = Stilo;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Tempra")
            {
                comboBox3.DataSource = Tempra;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Tipo")
            {
                comboBox3.DataSource = Tipo;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "Ulysse")
            {
                comboBox3.DataSource = Ulysse;
            }
            if (comboBox1.Text == "Fiat" & comboBox2.Text == "UNO")
            {
                comboBox3.DataSource = UNO;
            }
            //Fisker markası için
            if (comboBox1.Text == "Fisker" & comboBox2.Text == "Karma")
            {
                comboBox3.DataSource = Karma;
            }
            //Ford markası için
            if (comboBox1.Text == "Ford" & comboBox2.Text == "B-Max")
            {
                comboBox3.DataSource = BMax;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "C-Max")
            {
                comboBox3.DataSource = CMax;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Escort")
            {
                comboBox3.DataSource = Escort;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Fiesta")
            {
                comboBox3.DataSource = Fiesta;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Focus")
            {
                comboBox3.DataSource = Focus;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Fusion")
            {
                comboBox3.DataSource = Fusion;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Galaxy")
            {
                comboBox3.DataSource = Galaxy;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Grand C-Max")
            {
                comboBox3.DataSource = GrandCMax;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Ka")
            {
                comboBox3.DataSource = Ka;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Mondeo")
            {
                comboBox3.DataSource = Mondeo;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Mustang")
            {
                comboBox3.DataSource = Mustang;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "S-Max")
            {
                comboBox3.DataSource = SMax;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Taurus")
            {
                comboBox3.DataSource = Taurus;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Cougar")
            {
                comboBox3.DataSource = Cougar;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Crown Victoria")
            {
                comboBox3.DataSource = CrownVictoria;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Festiva")
            {
                comboBox3.DataSource = Festiva;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Granada")
            {
                comboBox3.DataSource = Granada;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Probe")
            {
                comboBox3.DataSource = Probe;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Scorpio")
            {
                comboBox3.DataSource = Scorpio;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Sierra")
            {
                comboBox3.DataSource = Sierra;
            }
            if (comboBox1.Text == "Ford" & comboBox2.Text == "Taunus")
            {
                comboBox3.DataSource = Taunus;
            }
            // Geely markası için
            if (comboBox1.Text == "Geely" & comboBox2.Text == "Echo")
            {
                comboBox3.DataSource = Echo;
            }
            if (comboBox1.Text == "Geely" & comboBox2.Text == "Emgrand")
            {
                comboBox3.DataSource = Emgrand;
            }
            if (comboBox1.Text == "Geely" & comboBox2.Text == "Familia")
            {
                comboBox3.DataSource = Familia;
            }
            if (comboBox1.Text == "Geely" & comboBox2.Text == "FC")
            {
                comboBox3.DataSource = FC;
            }
            // Honda markası için 
            if (comboBox1.Text == "Honda" & comboBox2.Text == "Accord")
            {
                comboBox3.DataSource = Accord;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "City")
            {
                comboBox3.DataSource = City;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "Civic")
            {
                comboBox3.DataSource = Civic;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "Concerto")
            {
                comboBox3.DataSource = Concerto;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "CR-Z")
            {
                comboBox3.DataSource = CRZ;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "CRX")
            {
                comboBox3.DataSource = CRX;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "E")
            {
                comboBox3.DataSource = E;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "Integra")
            {
                comboBox3.DataSource = Integra;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "Jazz")
            {
                comboBox3.DataSource = Jazz;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "Legend")
            {
                comboBox3.DataSource = Legend;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "Prelude")
            {
                comboBox3.DataSource = Prelude;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "S2000")
            {
                comboBox3.DataSource = S2000;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "Shuttle")
            {
                comboBox3.DataSource = Shuttle;
            }
            if (comboBox1.Text == "Honda" & comboBox2.Text == "Stream")
            {
                comboBox3.DataSource = Stream;
            }
            // Hyundai markası için
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Accent")
            {
                comboBox3.DataSource = Accent;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Accent Blue")
            {
                comboBox3.DataSource = AccentBlue;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Accent Era")
            {
                comboBox3.DataSource = AccentEra;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Atos")
            {
                comboBox3.DataSource = Atos;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Coupe")
            {
                comboBox3.DataSource = HCoupe;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Elantra")
            {
                comboBox3.DataSource = Elantra;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Equus")
            {
                comboBox3.DataSource = Equus;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Excel")
            {
                comboBox3.DataSource = Excel;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Genesis")
            {
                comboBox3.DataSource = Genesis;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Getz")
            {
                comboBox3.DataSource = Getz;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Grandeur")
            {
                comboBox3.DataSource = Grandeur;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "i10")
            {
                comboBox3.DataSource = i10;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "i20")
            {
                comboBox3.DataSource = i20;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "i20 Active")
            {
                comboBox3.DataSource = i20Active;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "i20 N")
            {
                comboBox3.DataSource = i20N;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "i20 Troy")
            {
                comboBox3.DataSource = i20Troy;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "i30")
            {
                comboBox3.DataSource = i30;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "i40")
            {
                comboBox3.DataSource = i40;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Ioniq")
            {
                comboBox3.DataSource = Ioniq;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "iX20")
            {
                comboBox3.DataSource = iX20;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Matrix")
            {
                comboBox3.DataSource = Matrix;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "S-Coupe")
            {
                comboBox3.DataSource = SCoupe;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Sonata")
            {
                comboBox3.DataSource = Sonata;
            }
            if (comboBox1.Text == "Hyundai" & comboBox2.Text == "Trajet")
            {
                comboBox3.DataSource = Trajet;
            }
            // Ikco markası için
            if (comboBox1.Text == "Ikco" & comboBox2.Text == "Samand")
            {
                comboBox3.DataSource = Samand;
            }
            // İnfiniti markası için
            if (comboBox1.Text == "Infiniti" & comboBox2.Text == "Q30")
            {
                comboBox3.DataSource = Q30;
            }
            if (comboBox1.Text == "Infiniti" & comboBox2.Text == "Q30")
            {
                comboBox3.DataSource = Q30;
            }
            if (comboBox1.Text == "Infiniti" & comboBox2.Text == "Q50")
            {
                comboBox3.DataSource = Q50;
            }
            if (comboBox1.Text == "Infiniti" & comboBox2.Text == "Q60")
            {
                comboBox3.DataSource = Q60;
            }
            if (comboBox1.Text == "Infiniti" & comboBox2.Text == "G")
            {
                comboBox3.DataSource = G;
            }
            if (comboBox1.Text == "Infiniti" & comboBox2.Text == "I30")
            {
                comboBox3.DataSource = I30;
            }
            if (comboBox1.Text == "Infiniti" & comboBox2.Text == "M")
            {
                comboBox3.DataSource = M;
            }
            // Jaguar markası için
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "Daimler")
            {
                comboBox3.DataSource = Daimler;
            }
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "F-Type")
            {
                comboBox3.DataSource = FType;
            }
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "S-Type")
            {
                comboBox3.DataSource = SType;
            }
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "Sovereign")
            {
                comboBox3.DataSource = Sovereign;
            }
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "X-Type")
            {
                comboBox3.DataSource = XType;
            }
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "XE")
            {
                comboBox3.DataSource = XE;
            }
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "XF")
            {
                comboBox3.DataSource = XF;
            }
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "XJ")
            {
                comboBox3.DataSource = XJ;
            }
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "XJR")
            {
                comboBox3.DataSource = XJR;
            }
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "XJS")
            {
                comboBox3.DataSource = XJS;
            }
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "XK8")
            {
                comboBox3.DataSource = XK8;
            }
            if (comboBox1.Text == "Jaguar" & comboBox2.Text == "XKR")
            {
                comboBox3.DataSource = XKR;
            }
            // Kia markası için
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Capital")
            {
                comboBox3.DataSource = Capital;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Carens")
            {
                comboBox3.DataSource = Carens;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Carnival")
            {
                comboBox3.DataSource = Carnival;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Ceed")
            {
                comboBox3.DataSource = Ceed;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Cerato")
            {
                comboBox3.DataSource = Cerato;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Clarus")
            {
                comboBox3.DataSource = Clarus;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Magentis")
            {
                comboBox3.DataSource = Magentis;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Opirus")
            {
                comboBox3.DataSource = Opirus;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Optima")
            {
                comboBox3.DataSource = Optima;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Picanto")
            {
                comboBox3.DataSource = Picanto;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Pride")
            {
                comboBox3.DataSource = Pride;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Pro Ceed")
            {
                comboBox3.DataSource = ProCeed;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Rio")
            {
                comboBox3.DataSource = Rio;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Sephia")
            {
                comboBox3.DataSource = Sephia;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Shuma")
            {
                comboBox3.DataSource = Shuma;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Stinger")
            {
                comboBox3.DataSource = Stinger;
            }
            if (comboBox1.Text == "Kia" & comboBox2.Text == "Venga")
            {
                comboBox3.DataSource = Venga;
            }
            // Lada markası için
            if (comboBox1.Text == "Lada" & comboBox2.Text == "Kalina")
            {
                comboBox3.DataSource = Kalina;
            }
            if (comboBox1.Text == "Lada" & comboBox2.Text == "Priora")
            {
                comboBox3.DataSource = Priora;
            }
            if (comboBox1.Text == "Lada" & comboBox2.Text == "Samara")
            {
                comboBox3.DataSource = Samara;
            }
            if (comboBox1.Text == "Lada" & comboBox2.Text == "Tavria")
            {
                comboBox3.DataSource = Tavria;
            }
            if (comboBox1.Text == "Lada" & comboBox2.Text == "VAZ")
            {
                comboBox3.DataSource = VAZ;
            }
            if (comboBox1.Text == "Lada" & comboBox2.Text == "Vega")
            {
                comboBox3.DataSource = Vega;
            }
            // Lamborghini markası için
            if (comboBox1.Text == "Lamborghini" & comboBox2.Text == "Aventador")
            {
                comboBox3.DataSource = Aventador;
            }
            if (comboBox1.Text == "Lamborghini" & comboBox2.Text == "Gallardo")
            {
                comboBox3.DataSource = Gallardo;
            }
            if (comboBox1.Text == "Lamborghini" & comboBox2.Text == "Huracan")
            {
                comboBox3.DataSource = Huracan;
            }
            // Lancia markası için
            if (comboBox1.Text == "Lancia" & comboBox2.Text == "Delta")
            {
                comboBox3.DataSource = Delta;
            }
            if (comboBox1.Text == "Lancia" & comboBox2.Text == "Thema")
            {
                comboBox3.DataSource = Thema;
            }
            if (comboBox1.Text == "Lancia" & comboBox2.Text == "Y(Ypsilon)")
            {
                comboBox3.DataSource = Ypsilon;
            }
            if (comboBox1.Text == "Lancia" & comboBox2.Text == "Dedra")
            {
                comboBox3.DataSource = Dedra;
            }
            // Leapmotor markası için
            if (comboBox1.Text == "Leapmotor" & comboBox2.Text == "T03")
            {
                comboBox3.DataSource = T03;
            }
            // Lexus markası için
            if (comboBox1.Text == "Lexus" & comboBox2.Text == "CT")
            {
                comboBox3.DataSource = CT;
            }
            if (comboBox1.Text == "Lexus" & comboBox2.Text == "ES")
            {
                comboBox3.DataSource = ES;
            }
            if (comboBox1.Text == "Lexus" & comboBox2.Text == "GS")
            {
                comboBox3.DataSource = GS;
            }
            if (comboBox1.Text == "Lexus" & comboBox2.Text == "IS")
            {
                comboBox3.DataSource = IS;
            }
            if (comboBox1.Text == "Lexus" & comboBox2.Text == "LS")
            {
                comboBox3.DataSource = LS;
            }
            // Lincoln markası için
            if (comboBox1.Text == "Lincoln" & comboBox2.Text == "MKS")
            {
                comboBox3.DataSource = MKS;
            }
            if (comboBox1.Text == "Lincoln" & comboBox2.Text == "Continental")
            {
                comboBox3.DataSource = Continental;
            }
            if (comboBox1.Text == "Lincoln" & comboBox2.Text == "LS")
            {
                comboBox3.DataSource = LS;
            }
            if (comboBox1.Text == "Lincoln" & comboBox2.Text == "Mark")
            {
                comboBox3.DataSource = Mark;
            }
            if (comboBox1.Text == "Lincoln" & comboBox2.Text == "MKZ")
            {
                comboBox3.DataSource = MKZ;
            }
            if (comboBox1.Text == "Lincoln" & comboBox2.Text == "Town Car")
            {
                comboBox3.DataSource = TownCar;
            }
            // Lotus markası için
            if (comboBox1.Text == "Lotus" & comboBox2.Text == "Evora")
            {
                comboBox3.DataSource = Evora;
            }
            if (comboBox1.Text == "Lotus" & comboBox2.Text == "Elan")
            {
                comboBox3.DataSource = Elan;
            }
            if (comboBox1.Text == "Lotus" & comboBox2.Text == "Esprit")
            {
                comboBox3.DataSource = Esprit;
            }
            // Marcos markası için
            if (comboBox1.Text == "Marcos" & comboBox2.Text == "Mantis")
            {
                comboBox3.DataSource = Mantis;
            }
            // Maserati markası için
            if (comboBox1.Text == "Maserati" & comboBox2.Text == "Cambiocorsa")
            {
                comboBox3.DataSource = Cambiocorsa;
            }
            if (comboBox1.Text == "Maserati" & comboBox2.Text == "Ghibli")
            {
                comboBox3.DataSource = Ghibli;
            }
            if (comboBox1.Text == "Maserati" & comboBox2.Text == "GranCabrio")
            {
                comboBox3.DataSource = GranCabrio;
            }
            if (comboBox1.Text == "Maserati" & comboBox2.Text == "GranSport")
            {
                comboBox3.DataSource = GranSport;
            }
            if (comboBox1.Text == "Maserati" & comboBox2.Text == "GranTurismo")
            {
                comboBox3.DataSource = GranTurismo;
            }
            if (comboBox1.Text == "Maserati" & comboBox2.Text == "GT")
            {
                comboBox3.DataSource = GT;
            }
            if (comboBox1.Text == "Maserati" & comboBox2.Text == "MC20")
            {
                comboBox3.DataSource = MC20;
            }
            if (comboBox1.Text == "Maserati" & comboBox2.Text == "Spyder")
            {
                comboBox3.DataSource = Spyder;
            }
            if (comboBox1.Text == "Maserati" & comboBox2.Text == "Quattroporte")
            {
                comboBox3.DataSource = Quattroporte;
            }
            // Mazda markası için
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "2")
            {
                comboBox3.DataSource = Mazda2;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "3")
            {
                comboBox3.DataSource = Mazda3;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "5")
            {
                comboBox3.DataSource = Mazda5;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "6")
            {
                comboBox3.DataSource = Mazda6;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "MX")
            {
                comboBox3.DataSource = MX;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "Premacy")
            {
                comboBox3.DataSource = Premacy;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "121")
            {
                comboBox3.DataSource = Mazda121;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "323")
            {
                comboBox3.DataSource = Mazda323;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "626")
            {
                comboBox3.DataSource = Mazda626;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "929")
            {
                comboBox3.DataSource = Mazda929;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "Lantis")
            {
                comboBox3.DataSource = Lantis;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "RX")
            {
                comboBox3.DataSource = RX;
            }
            if (comboBox1.Text == "Mazda" & comboBox2.Text == "Xedos")
            {
                comboBox3.DataSource = Xedos;
            }

            // Mclaren markası için
            if (comboBox1.Text == "Maclaren" & comboBox2.Text == "GT")
            {
                comboBox3.DataSource = McLarenGT;
            }

            // Mercedes Benz markası için
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "A Serisi")
            {
                comboBox3.DataSource = ASerisi;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "AMG GT")
            {
                comboBox3.DataSource = AMGGTSerisi;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "BSerisi")
            {
                comboBox3.DataSource = BSerisi;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "C Serisi")
            {
                comboBox3.DataSource = CSerisi;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "CL")
            {
                comboBox3.DataSource = CL;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "CLA")
            {
                comboBox3.DataSource = CLA;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "CLC")
            {
                comboBox3.DataSource = CLC;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "CLK")
            {
                comboBox3.DataSource = CLK;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "CLS")
            {
                comboBox3.DataSource = CLS;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "E Serisi")
            {
                comboBox3.DataSource = ESerisi;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "EQE")
            {
                comboBox3.DataSource = EQE;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "EQS")
            {
                comboBox3.DataSource = EQS;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "Maybach S")
            {
                comboBox3.DataSource = MaybachS;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "R Serisi")
            {
                comboBox3.DataSource = RSerisi;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "S Serisi")
            {
                comboBox3.DataSource = SSerisi;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "SL")
            {
                comboBox3.DataSource = SL;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "SLC")
            {
                comboBox3.DataSource = SLC;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "SLK")
            {
                comboBox3.DataSource = SLK;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "SLS AMG")
            {
                comboBox3.DataSource = SLSAMG;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "190")
            {
                comboBox3.DataSource = M190;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "200")
            {
                comboBox3.DataSource = M200;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "220")
            {
                comboBox3.DataSource = M220;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "230")
            {
                comboBox3.DataSource = M230;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "240")
            {
                comboBox3.DataSource = M240;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "250")
            {
                comboBox3.DataSource = M250;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "260")
            {
                comboBox3.DataSource = M260;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "280")
            {
                comboBox3.DataSource = M280;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "300")
            {
                comboBox3.DataSource = M300;
            }
            
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "380")
            {
                comboBox3.DataSource = M380;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "420")
            {
                comboBox3.DataSource = M420;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "500")
            {
                comboBox3.DataSource = M500;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "560")
            {
                comboBox3.DataSource = M560;
            }
            if (comboBox1.Text == "Mercedes-Benz" & comboBox2.Text == "600")
            {
                comboBox3.DataSource = M600;
            }

            //Mercury markası için
            if (comboBox1.Text == "Mercury" & comboBox2.Text == "Grand Marquis")
            {
                comboBox3.DataSource = GranMarquis;
            }

            // MG markası için
            if (comboBox1.Text == "MG" & comboBox2.Text == "F")
            {
                comboBox3.DataSource = F;
            }
            if (comboBox1.Text == "MG" & comboBox2.Text == "MG4")
            {
                comboBox3.DataSource = MG4;
            }
            if (comboBox1.Text == "MG" & comboBox2.Text == "ZR")
            {
                comboBox3.DataSource = ZR;
            }

            // Mini markası için
            if (comboBox1.Text == "Mini" & comboBox2.Text == "Cooper")
            {
                comboBox3.DataSource = Cooper;
            }
            if (comboBox1.Text == "Mini" & comboBox2.Text == "Cooper Clubman")
            {
                comboBox3.DataSource = CooperClubman;
            }
            if (comboBox1.Text == "Mini" & comboBox2.Text == "Cooper Electric")
            {
                comboBox3.DataSource = CooperElectric;
            }
            if (comboBox1.Text == "Mini" & comboBox2.Text == "John Cooper")
            {
                comboBox3.DataSource = JohnCooper;
            }
            if (comboBox1.Text == "Mini" & comboBox2.Text == "One")
            {
                comboBox3.DataSource = One;
            }
            if (comboBox1.Text == "Mini" & comboBox2.Text == "Cooper S")
            {
                comboBox3.DataSource = CooperS;
            }

            // Mitshubishi markası için
            if (comboBox1.Text == "Mitsubishi" & comboBox2.Text == "Attrage")
            {
                comboBox3.DataSource = Attrage;
            }
            if (comboBox1.Text == "Mitsubishi" & comboBox2.Text == "Colt")
            {
                comboBox3.DataSource = Colt;
            }
            if (comboBox1.Text == "Mitsubishi" & comboBox2.Text == "Galant")
            {
                comboBox3.DataSource = Galant;
            }
            if (comboBox1.Text == "Mitsubishi" & comboBox2.Text == "Lancer")
            {
                comboBox3.DataSource = Lancer;
            }
            if (comboBox1.Text == "Mitsubishi" & comboBox2.Text == "Lancer Evolution")
            {
                comboBox3.DataSource = LancerEvolution;
            }
            if (comboBox1.Text == "Mitsubishi" & comboBox2.Text == "Carisma")
            {
                comboBox3.DataSource = Carisma;
            }
            if (comboBox1.Text == "Mitsubishi" & comboBox2.Text == "Chariot")
            {
                comboBox3.DataSource = Chariot;
            }
            if (comboBox1.Text == "Mitsubishi" & comboBox2.Text == "Eclipse")
            {
                comboBox3.DataSource = Eclipse;
            }
            if (comboBox1.Text == "Mitsubishi" & comboBox2.Text == "Grandis")
            {
                comboBox3.DataSource = Grandis;
            }
            if (comboBox1.Text == "Mitsubishi" & comboBox2.Text == "Space Star")
            {
                comboBox3.DataSource = SpaceStar;
            }
            if (comboBox1.Text == "Mitsubishi" & comboBox2.Text == "Space Wagon")
            {
                comboBox3.DataSource = SpaceWagon;
            }

            // Moskwitsch markası için
            if (comboBox1.Text == "Moskwitsch" & comboBox2.Text == "Aleko")
            {
                comboBox3.DataSource = Aleko;
            }

            // Nissan markası için
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "200 SX")
            {
                comboBox3.DataSource = N200SX;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "350 Z")
            {
                comboBox3.DataSource = N350Z;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Almera")
            {
                comboBox3.DataSource = Almera;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Altima")
            {
                comboBox3.DataSource = Altima;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Bluebird")
            {
                comboBox3.DataSource = Bluebird;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Cedric")
            {
                comboBox3.DataSource = Cedric;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "GT-R")
            {
                comboBox3.DataSource = GTR;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Laurel Altima")
            {
                comboBox3.DataSource = LaurelAltima;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Maxima")
            {
                comboBox3.DataSource = Maxima;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Micra")
            {
                comboBox3.DataSource = Micra;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Note")
            {
                comboBox3.DataSource = Note;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "NX Coupe")
            {
                comboBox3.DataSource = NXCoupe;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Primera")
            {
                comboBox3.DataSource = Primera;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Pulsar")
            {
                comboBox3.DataSource = Pulsar;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Sunny")
            {
                comboBox3.DataSource = Sunny;
            }
            if (comboBox1.Text == "Nissan" & comboBox2.Text == "Tino")
            {
                comboBox3.DataSource = Tino;
            }

            // Opel markası için
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Adam")
            {
                comboBox3.DataSource = Adam;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Agila")
            {
                comboBox3.DataSource = Agila;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Ascona")
            {
                comboBox3.DataSource = Ascona;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Astra")
            {
                comboBox3.DataSource = Astra;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Calibra")
            {
                comboBox3.DataSource = Calibra;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Cascada")
            {
                comboBox3.DataSource = Cascada;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Corsa")
            {
                comboBox3.DataSource = Corsa;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "GT (Roadster)")
            {
                comboBox3.DataSource = GTRoadster;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Insignia")
            {
                comboBox3.DataSource = Insignia;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Kadett")
            {
                comboBox3.DataSource = Kadett;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Meriva")
            {
                comboBox3.DataSource = Meriva;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Omega")
            {
                comboBox3.DataSource = Omega;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Rekord")
            {
                comboBox3.DataSource = Rekord;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Senator")
            {
                comboBox3.DataSource = Senator;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Signum")
            {
                comboBox3.DataSource = Signum;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Tigra")
            {
                comboBox3.DataSource = Tigra;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Vectra")
            {
                comboBox3.DataSource = Vectra;
            }
            if (comboBox1.Text == "Opel" & comboBox2.Text == "Zafira")
            {
                comboBox3.DataSource = Zafira;
            }

            // Peugeot markası için
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "106")
            {
                comboBox3.DataSource = P106;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "107")
            {
                comboBox3.DataSource = P107;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "205")
            {
                comboBox3.DataSource = P205;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "206")
            {
                comboBox3.DataSource = P206;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "206 +")
            {
                comboBox3.DataSource = P206plus;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "207")
            {
                comboBox3.DataSource = P207;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "208")
            {
                comboBox3.DataSource = P208;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "301")
            {
                comboBox3.DataSource = P301;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "305")
            {
                comboBox3.DataSource = P305;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "306")
            {
                comboBox3.DataSource = P306;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "307")
            {
                comboBox3.DataSource = P307;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "308")
            {
                comboBox3.DataSource = P308;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "405")
            {
                comboBox3.DataSource = P405;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "406")
            {
                comboBox3.DataSource = P406;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "407")
            {
                comboBox3.DataSource = P407;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "508")
            {
                comboBox3.DataSource = P508;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "605")
            {
                comboBox3.DataSource = P605;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "607")
            {
                comboBox3.DataSource = P607;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "806")
            {
                comboBox3.DataSource = P806;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "807")
            {
                comboBox3.DataSource = P807;
            }
            if (comboBox1.Text == "Peugeot" & comboBox2.Text == "RCZ")
            {
                comboBox3.DataSource = RCZ;
            }

            // Plymouth markası için
            if (comboBox1.Text == "Plymouth" & comboBox2.Text == "Laser")
            {
                comboBox3.DataSource = Laser;
            }

            // Pontiac markası için
            if (comboBox1.Text == "Pontiac" & comboBox2.Text == "Firebird")
            {
                comboBox3.DataSource = Firebird;
            }
            
            if (comboBox1.Text == "Pontiac" & comboBox2.Text == "Solstice")
            {
                comboBox3.DataSource = Solstice;
            }
            if (comboBox1.Text == "Pontiac" & comboBox2.Text == "Sunbird")
            {
                comboBox3.DataSource = Sunbird;
            }

            // Porsche markası için
            if (comboBox1.Text == "Porsche" & comboBox2.Text == "718")
            {
                comboBox3.DataSource = Prs718;
            }
            if (comboBox1.Text == "Porsche" & comboBox2.Text == "911")
            {
                comboBox3.DataSource = Prs911;
            }
            if (comboBox1.Text == "Porsche" & comboBox2.Text == "928")
            {
                comboBox3.DataSource = Prs928;
            }
            if (comboBox1.Text == "Porsche" & comboBox2.Text == "Boxster")
            {
                comboBox3.DataSource = Boxster;
            }
            if (comboBox1.Text == "Porsche" & comboBox2.Text == "Cayman")
            {
                comboBox3.DataSource = Cayman;
            }
            if (comboBox1.Text == "Porsche" & comboBox2.Text == "Panamera")
            {
                comboBox3.DataSource = Panamera;
            }
            if (comboBox1.Text == "Porsche" & comboBox2.Text == "Taycan")
            {
                comboBox3.DataSource = Taycan;
            }
            // Proton markası için
            if (comboBox1.Text == "Proton" & comboBox2.Text == "Gen-2")
            {
                comboBox3.DataSource = Gen2;
            }
            if (comboBox1.Text == "Proton" & comboBox2.Text == "Saga")
            {
                comboBox3.DataSource = Saga;
            }
            if (comboBox1.Text == "Proton" & comboBox2.Text == "Savvy")
            {
                comboBox3.DataSource = Savvy;
            }
            if (comboBox1.Text == "Proton" & comboBox2.Text == "Waja")
            {
                comboBox3.DataSource = Waja;
            }
            if (comboBox1.Text == "Proton" & comboBox2.Text == "218")
            {
                comboBox3.DataSource = Prot218;
            }
            if (comboBox1.Text == "Proton" & comboBox2.Text == "315")
            {
                comboBox3.DataSource = Prot315;
            }
            if (comboBox1.Text == "Proton" & comboBox2.Text == "316")
            {
                comboBox3.DataSource = Prot316;
            }
            if (comboBox1.Text == "Proton" & comboBox2.Text == "415")
            {
                comboBox3.DataSource = Prot415;
            }
            if (comboBox1.Text == "Proton" & comboBox2.Text == "416")
            {
                comboBox3.DataSource = Prot416;
            }
            if (comboBox1.Text == "Proton" & comboBox2.Text == "418")
            {
                comboBox3.DataSource = Prot418;
            }
            if (comboBox1.Text == "Proton" & comboBox2.Text == "420")
            {
                comboBox3.DataSource = Prot420;
            }
            if (comboBox1.Text == "Proton" & comboBox2.Text == "Persona")
            {
                comboBox3.DataSource = Persona;
            }

            // Renault markası için
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Clio")
            {
                comboBox3.DataSource = Clio;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Espace")
            {
                comboBox3.DataSource = Espace;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Fluence")
            {
                comboBox3.DataSource = Fluence;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Fluence Z.E")
            {
                comboBox3.DataSource = FluenceZE;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Grand Espace")
            {
                comboBox3.DataSource = GranEspace;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Grand Scenic")
            {
                comboBox3.DataSource = GrandScenic;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Laguna")
            {
                comboBox3.DataSource = Laguna;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Latitude")
            {
                comboBox3.DataSource = Latitude;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Megane")
            {
                comboBox3.DataSource = Megane;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Modus")
            {
                comboBox3.DataSource = Modus;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Safrane")
            {
                comboBox3.DataSource = Safrane;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Scenic")
            {
                comboBox3.DataSource = Scenic;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Symbol")
            {
                comboBox3.DataSource = Symbol;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Taliant")
            {
                comboBox3.DataSource = Taliant;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Talisman")
            {
                comboBox3.DataSource = Talisman;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Twingo")
            {
                comboBox3.DataSource = Twingo;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Twizy")
            {
                comboBox3.DataSource = Twizy;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "Vel Satis")
            {
                comboBox3.DataSource = VelSatis;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "ZOE")
            {
                comboBox3.DataSource = Zoe;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "R 5")
            {
                comboBox3.DataSource = R5;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "R 9")
            {
                comboBox3.DataSource = R9 ;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "R 11")
            {
                comboBox3.DataSource = R11;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "R 12")
            {
                comboBox3.DataSource = R12;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "R 19")
            {
                comboBox3.DataSource = R19;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "R 21")
            {
                comboBox3.DataSource = R21;
            }
            if (comboBox1.Text == "Renault" & comboBox2.Text == "R 25")
            {
                comboBox3.DataSource = R25;
            }

            // Rolls Royce markası için
            if (comboBox1.Text == "Rolls-Royce" & comboBox2.Text == "Dawn")
            {
                comboBox3.DataSource = Dawn;
            }
            if (comboBox1.Text == "Rolls-Royce" & comboBox2.Text == "Ghost")
            {
                comboBox3.DataSource = Ghost;
            }
            if (comboBox1.Text == "Rolls-Royce" & comboBox2.Text == "Phantom")
            {
                comboBox3.DataSource = Phantom;
            }
            if (comboBox1.Text == "Rolls-Royce" & comboBox2.Text == "Wraith")
            {
                comboBox3.DataSource = Wraith;
            }

            // Rover markası için
            if (comboBox1.Text == "Rover" & comboBox2.Text == "25")
            {
                comboBox3.DataSource = Rov25;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "45")
            {
                comboBox3.DataSource = Rov45;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "75")
            {
                comboBox3.DataSource = Rov75;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "200")
            {
                comboBox3.DataSource = Rov200;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "214")
            {
                comboBox3.DataSource = Rov214;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "216")
            {
                comboBox3.DataSource = Rov216;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "220")
            {
                comboBox3.DataSource = Rov220;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "400")
            {
                comboBox3.DataSource = Rov400;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "414")
            {
                comboBox3.DataSource = Rov414;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "416")
            {
                comboBox3.DataSource = Rov416;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "420")
            {
                comboBox3.DataSource = Rov420;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "620")
            {
                comboBox3.DataSource = Rov620;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "820")
            {
                comboBox3.DataSource = Rov820;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "827")
            {
                comboBox3.DataSource = Rov827;
            }
            if (comboBox1.Text == "Rover" & comboBox2.Text == "Streetwise")
            {
                comboBox3.DataSource = Streetwise;
            }

            // Saab markası için
            if (comboBox1.Text == "Saab" & comboBox2.Text == "9-3")
            {
                comboBox3.DataSource =S93;
            }
            if (comboBox1.Text == "Saab" & comboBox2.Text == "9-5")
            {
                comboBox3.DataSource = S95;
            }
            if (comboBox1.Text == "Saab" & comboBox2.Text == "900")
            {
                comboBox3.DataSource = S900;
            }
            if (comboBox1.Text == "Saab" & comboBox2.Text == "9000")
            {
                comboBox3.DataSource = S9000;
            }

            // Seat markası için
            if (comboBox1.Text == "Seat" & comboBox2.Text == "Alhambra")
            {
                comboBox3.DataSource = Alhambra;
            }
            if (comboBox1.Text == "Seat" & comboBox2.Text == "Alhambra")
            {
                comboBox3.DataSource = Alhambra;
            }
            if (comboBox1.Text == "Seat" & comboBox2.Text == "Altea")
            {
                comboBox3.DataSource = Altea;
            }
            if (comboBox1.Text == "Seat" & comboBox2.Text == "Arosa")
            {
                comboBox3.DataSource = Arosa;
            }
            if (comboBox1.Text == "Seat" & comboBox2.Text == "Cordoba")
            {
                comboBox3.DataSource = Cordoba;
            }
            if (comboBox1.Text == "Seat" & comboBox2.Text == "Exeo")
            {
                comboBox3.DataSource = Exeo;
            }
            if (comboBox1.Text == "Seat" & comboBox2.Text == "Ibiza")
            {
                comboBox3.DataSource = Ibiza;
            }
            if (comboBox1.Text == "Seat" & comboBox2.Text == "Leon")
            {
                comboBox3.DataSource = Leon;
            }
            if (comboBox1.Text == "Seat" & comboBox2.Text == "Marbella")
            {
                comboBox3.DataSource = Marbella;
            }
            if (comboBox1.Text == "Seat" & comboBox2.Text == "Toledo")
            {
                comboBox3.DataSource = Toledo;
            }

            // Skoda markası için
            if (comboBox1.Text == "Skoda" & comboBox2.Text == "Citigo")
            {
                comboBox3.DataSource =Citigo;
            }
            if (comboBox1.Text == "Skoda" & comboBox2.Text == "Fabia")
            {
                comboBox3.DataSource = Fabia;
            }
            if (comboBox1.Text == "Skoda" & comboBox2.Text == "Favorit")
            {
                comboBox3.DataSource = Favorit;
            }
            if (comboBox1.Text == "Skoda" & comboBox2.Text == "Felicia")
            {
                comboBox3.DataSource = Felicia;
            }
            if (comboBox1.Text == "Skoda" & comboBox2.Text == "Forman")
            {
                comboBox3.DataSource = Forman;
            }
            if (comboBox1.Text == "Skoda" & comboBox2.Text == "Octavia")
            {
                comboBox3.DataSource = Octovia;
            }
            if (comboBox1.Text == "Skoda" & comboBox2.Text == "Rapid")
            {
                comboBox3.DataSource = Rapid;
            }
            if (comboBox1.Text == "Skoda" & comboBox2.Text == "Roomster")
            {
                comboBox3.DataSource = Roomster;
            }
            if (comboBox1.Text == "Skoda" & comboBox2.Text == "Scala")
            {
                comboBox3.DataSource = Scala;
            }
            if (comboBox1.Text == "Skoda" & comboBox2.Text == "Superb")
            {
                comboBox3.DataSource = Superb;
            }

            // Smart markası için
            if (comboBox1.Text == "Smart" & comboBox2.Text == "Fortwo")
            {
                comboBox3.DataSource = Fortwo;
            }
            if (comboBox1.Text == "Smart" & comboBox2.Text == "Forfour")
            {
                comboBox3.DataSource = Forfour;
            }
            if (comboBox1.Text == "Smart" & comboBox2.Text == "Roadster")
            {
                comboBox3.DataSource = Roadster;
            }


            // Subaru markası için
            if (comboBox1.Text == "Subaru" & comboBox2.Text == "BRZ")
            {
                comboBox3.DataSource = BRZ;
            }
            if (comboBox1.Text == "Subaru" & comboBox2.Text == "Impreza")
            {
                comboBox3.DataSource = Impreza;
            }
            if (comboBox1.Text == "Subaru" & comboBox2.Text == "Legacy")
            {
                comboBox3.DataSource = Legacy;
            }
            if (comboBox1.Text == "Subaru" & comboBox2.Text == "Levorg")
            {
                comboBox3.DataSource = Levorg;
            }
            if (comboBox1.Text == "Subaru" & comboBox2.Text == "Justy")
            {
                comboBox3.DataSource = Justy;
            }
            if (comboBox1.Text == "Subaru" & comboBox2.Text == "SVX")
            {
                comboBox3.DataSource = SVX;
            }
            if (comboBox1.Text == "Subaru" & comboBox2.Text == "Vivio")
            {
                comboBox3.DataSource = Vivio;
            }

            // Suzuki markası için

            if (comboBox1.Text == "Suzuki" & comboBox2.Text == "Alto")
            {
                comboBox3.DataSource = Alto;
            }
            if (comboBox1.Text == "Suzuki" & comboBox2.Text == "Baleno")
            {
                comboBox3.DataSource = Baleno;
            }
            if (comboBox1.Text == "Suzuki" & comboBox2.Text == "Reno")
            {
                comboBox3.DataSource = Reno;
            }
            if (comboBox1.Text == "Suzuki" & comboBox2.Text == "Splash")
            {
                comboBox3.DataSource = Splash;
            }
            if (comboBox1.Text == "Suzuki" & comboBox2.Text == "Swift")
            {
                comboBox3.DataSource = Swift;
            }
            if (comboBox1.Text == "Suzuki" & comboBox2.Text == "SX4")
            {
                comboBox3.DataSource = SX4;
            }
            if (comboBox1.Text == "Suzuki" & comboBox2.Text == "Liana")
            {
                comboBox3.DataSource = Liana;
            }
            if (comboBox1.Text == "Suzuki" & comboBox2.Text == "Maruti")
            {
                comboBox3.DataSource = Maruti;
            }

            //Tata markası için
            if (comboBox1.Text == "Tata" & comboBox2.Text == "Indica")
            {
                comboBox3.DataSource = Indica;
            }
            if (comboBox1.Text == "Tata" & comboBox2.Text == "Indigo")
            {
                comboBox3.DataSource = Indigo;
            }
            if (comboBox1.Text == "Tata" & comboBox2.Text == "Marina")
            {
                comboBox3.DataSource = Marina;
            }
            if (comboBox1.Text == "Tata" & comboBox2.Text == "Vista")
            {
                comboBox3.DataSource = Vista;
            }
            if (comboBox1.Text == "Tata" & comboBox2.Text == "Manza")
            {
                comboBox3.DataSource = Manza;
            }

            // Tesla markası için
            if (comboBox1.Text == "Tesla" & comboBox2.Text == "Model 3")
            {
                comboBox3.DataSource = Model3;
            }
            if (comboBox1.Text == "Tesla" & comboBox2.Text == "Model S")
            {
                comboBox3.DataSource = ModelS;
            }
            if (comboBox1.Text == "Tesla" & comboBox2.Text == "Model X")
            {
                comboBox3.DataSource = ModelX;
            }
            if (comboBox1.Text == "Tesla" & comboBox2.Text == "Model Y")
            {
                comboBox3.DataSource = ModelY;
            }

            // Tofaş markası için
            if (comboBox1.Text == "Tofaş" & comboBox2.Text == "Doğan")
            {
                comboBox3.DataSource = Dogan;
            }
            if (comboBox1.Text == "Tofaş" & comboBox2.Text == "Kartal")
            {
                comboBox3.DataSource = Kartal;
            }
            if (comboBox1.Text == "Tofaş" & comboBox2.Text == "Murat")
            {
                comboBox3.DataSource = Murat;
            }
            if (comboBox1.Text == "Tofaş" & comboBox2.Text == "Şahin")
            {
                comboBox3.DataSource = Sahin;
            }
            if (comboBox1.Text == "Tofaş" & comboBox2.Text == "Serçe")
            {
                comboBox3.DataSource = Serce;
            }

            // Toyota markası için
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Auris")
            {
                comboBox3.DataSource = Auris;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Avensis")
            {
                comboBox3.DataSource = Avensis;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Camry")
            {
                comboBox3.DataSource = Camry;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Carina")
            {
                comboBox3.DataSource = Carina;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Celica")
            {
                comboBox3.DataSource = Celica;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Corolla")
            {
                comboBox3.DataSource = Corolla;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Corona")
            {
                comboBox3.DataSource = Corona;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Cressida")
            {
                comboBox3.DataSource = Cressida;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "GT86 ")
            {
                comboBox3.DataSource = GT86;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "MR2")
            {
                comboBox3.DataSource = MR2;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Paseo")
            {
                comboBox3.DataSource = Paseo;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Picnic")
            {
                comboBox3.DataSource = Picnic;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Previa")
            {
                comboBox3.DataSource = Previa;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Prius")
            {
                comboBox3.DataSource = Prius;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Starlet")
            {
                comboBox3.DataSource = Starlet;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Supra")
            {
                comboBox3.DataSource = Supra;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Urban Cruiser")
            {
                comboBox3.DataSource = UrbanCruiser;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Verso")
            {
                comboBox3.DataSource = Verso;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Windom")
            {
                comboBox3.DataSource = Windom;
            }
            if (comboBox1.Text == "Toyota" & comboBox2.Text == "Yaris")
            {
                comboBox3.DataSource = Yaris;
            }

            // Volkswagen markası için
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Arteon")
            {
                comboBox3.DataSource = Arteon;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Beetle")
            {
                comboBox3.DataSource = Beetle;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Bora")
            {
                comboBox3.DataSource = Bora;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "EOS")
            {
                comboBox3.DataSource = EOS;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "FOX")
            {
                comboBox3.DataSource = FOX;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Golf")
            {
                comboBox3.DataSource = Golf;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "ID.3")
            {
                comboBox3.DataSource = ID3;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Jetta")
            {
                comboBox3.DataSource = Jetta;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Lupo")
            {
                comboBox3.DataSource = Lupo;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Passat")
            {
                comboBox3.DataSource = Passat;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Passat Alltrack")
            {
                comboBox3.DataSource = PassatAlltrack;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Passat Variant")
            {
                comboBox3.DataSource = PassatVariant;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Phaeton")
            {
                comboBox3.DataSource = Phateon;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Polo")
            {
                comboBox3.DataSource = Polo;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Scirocco")
            {
                comboBox3.DataSource = Scirocco;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Sharan")
            {
                comboBox3.DataSource = Sharan;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Touran")
            {
                comboBox3.DataSource = Touran;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Up Club")
            {
                comboBox3.DataSource = UpClub;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "VW CC")
            {
                comboBox3.DataSource = VWCC;
            }
            if (comboBox1.Text == "Volkswagen" & comboBox2.Text == "Vento")
            {
                comboBox3.DataSource = Vento;
            }

            // Volvo markası için
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "C30")
            {
                comboBox3.DataSource = C30;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "C70")
            {
                comboBox3.DataSource = C70;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "S40")
            {
                comboBox3.DataSource = S40;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "S60")
            {
                comboBox3.DataSource = S60;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "S70")
            {
                comboBox3.DataSource = S70;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "S80")
            {
                comboBox3.DataSource = S80;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "S90")
            {
                comboBox3.DataSource = S90;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "V40")
            {
                comboBox3.DataSource = V40;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "V40 Cross Country")
            {
                comboBox3.DataSource = V40CrossC;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "V50")
            {
                comboBox3.DataSource = V50;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "V60")
            {
                comboBox3.DataSource = V60;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "V60 Cross Country")
            {
                comboBox3.DataSource = V60CrossC;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "V70")
            {
                comboBox3.DataSource = V70;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "V90 Cross Country")
            {
                comboBox3.DataSource = V90CrossC;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "440")
            {
                comboBox3.DataSource = V440;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "740")
            {
                comboBox3.DataSource = V740;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "850")
            {
                comboBox3.DataSource = V850;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "940")
            {
                comboBox3.DataSource = V940;
            }
            if (comboBox1.Text == "Volvo" & comboBox2.Text == "960")
            {
                comboBox3.DataSource = V960;
            }

            // Xev markası için
            if (comboBox1.Text == "XEV" & comboBox2.Text == "Yoyo")
            {
                comboBox3.DataSource = Yoyo;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // İlanı veri tabanına kaydetmek için 
            if (maskedTextBox1.Text != "" & numericUpDown1.Value.ToString() != "" & comboBox5.Text != ""& comboBox1.Text != ""& comboBox2.Text != ""& comboBox3.Text != "" & comboBox6.Text != ""& comboBox7.Text != "" & comboBox8.Text != ""& comboBox4.Text != ""& maskedTextBox2.Text != "" & maskedTextBox5.Text != "" & maskedTextBox6.Text != "" & richTextBox2.Text != "")
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("insert into ilan Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16)", connect);
                cmd.Parameters.AddWithValue("@p1", DateTime.Parse(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@p3", numericUpDown1.Value.ToString());
                cmd.Parameters.AddWithValue("@p4", comboBox5.Text);
                cmd.Parameters.AddWithValue("@p5", comboBox7.Text);
                cmd.Parameters.AddWithValue("@p6", maskedTextBox2.Text);
                cmd.Parameters.AddWithValue("@p7", comboBox8.Text);
                cmd.Parameters.AddWithValue("@p8", maskedTextBox6.Text);
                cmd.Parameters.AddWithValue("@p9", maskedTextBox5.Text);
                cmd.Parameters.AddWithValue("@p10", comboBox4.Text);
                cmd.Parameters.AddWithValue("@p11", richTextBox2.Text);
                cmd.Parameters.AddWithValue("@p12", comboBox1.Text);
                cmd.Parameters.AddWithValue("@p13", comboBox3.Text);
                cmd.Parameters.AddWithValue("@p14", comboBox2.Text);
                cmd.Parameters.AddWithValue("@p15", comboBox6.Text);
                cmd.Parameters.AddWithValue("@p16", bunifuCustomLabel22.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Eklendi");
                list();
                connect.Close();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olunuz.");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // İlana ait verileri datagridden araçlara çekmek için
            int chosen_value = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[chosen_value].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[chosen_value].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[chosen_value].Cells[2].Value.ToString();
            numericUpDown1.Text = dataGridView1.Rows[chosen_value].Cells[3].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[chosen_value].Cells[4].Value.ToString();
            comboBox7.Text = dataGridView1.Rows[chosen_value].Cells[5].Value.ToString();
            maskedTextBox2.Text = dataGridView1.Rows[chosen_value].Cells[6].Value.ToString();
            comboBox8.Text = dataGridView1.Rows[chosen_value].Cells[7].Value.ToString();
            maskedTextBox6.Text = dataGridView1.Rows[chosen_value].Cells[8].Value.ToString();
            maskedTextBox5.Text = dataGridView1.Rows[chosen_value].Cells[9].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[chosen_value].Cells[10].Value.ToString();
            richTextBox2.Text= dataGridView1.Rows[chosen_value].Cells[11].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[chosen_value].Cells[12].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[chosen_value].Cells[13].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[chosen_value].Cells[14].Value.ToString();
            comboBox6.Text = dataGridView1.Rows[chosen_value].Cells[15].Value.ToString();
        }
        
        private void button10_Click(object sender, EventArgs e)
        {
            // İlana resim eklemek için resim formunu açma
            try
            {
                if (textBox1.Text != "")
                {
                    CarImage newform = new CarImage();
                    newform.ilan_no = Convert.ToInt32(textBox1.Text);
                    newform.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen ilan numarasının doğruluğunu kontrol edin");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // İlanı güncellemek için
            connect.Open();
            SqlCommand cmd = new SqlCommand("update ilan set fiyat=@p1,yil=@p2,yakit=@p3,arac_durumu=@p4,km=@p5,kasa_tipi=@p6,motor_gucu=@p7,motor_hacmi=@p8,renk=@p9,aciklama=@p10,marka=@p11,model=@p12,seri=@p13,vites=@p14 where ilan_no=@p15", connect);
            cmd.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p2", numericUpDown1.Value.ToString());
            cmd.Parameters.AddWithValue("@p3", comboBox5.Text);
            cmd.Parameters.AddWithValue("@p4", comboBox7.Text);
            cmd.Parameters.AddWithValue("@p5", maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@p6", comboBox8.Text);
            cmd.Parameters.AddWithValue("@p7", maskedTextBox6.Text);
            cmd.Parameters.AddWithValue("@p8", maskedTextBox5.Text);
            cmd.Parameters.AddWithValue("@p9", comboBox4.Text);
            cmd.Parameters.AddWithValue("@p10", richTextBox2.Text);
            cmd.Parameters.AddWithValue("@p11", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p12", comboBox3.Text);
            cmd.Parameters.AddWithValue("@p13", comboBox2.Text);
            cmd.Parameters.AddWithValue("@p14", comboBox6.Text);
            cmd.Parameters.AddWithValue("@p15", textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi");
            list();
            connect.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Eğer ilan seçilmişse resimleri getirir
            if (textBox1.Text != "")
            {
                ImagesofCar newform = new ImagesofCar();
                newform.ilan_no = Convert.ToInt32(textBox1.Text);
                newform.Show();
                MessageBox.Show("Resimleri görüntlemek için yön tuşlarını kullanınız");
            }
            // İlan seçilmesi için uyarı
            else
            {
                MessageBox.Show("Lütfen bir ilan seçiniz");
            }
            
        }
        // Admin formuna geri dönme
        private void button3_Click(object sender, EventArgs e)
        {
            AdminDatabaseForm newform = new AdminDatabaseForm();
            newform.user_name = bunifuCustomLabel22.Text;
            newform.Show();
            this.Hide();
        }
    }
}
