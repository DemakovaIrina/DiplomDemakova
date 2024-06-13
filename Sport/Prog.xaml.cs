using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для Prog.xaml
    /// </summary>
    public partial class Prog : Window
    {

        private ADMIN _ADMIN;

        public Prog(ADMIN aDMIN)
        {
            InitializeComponent();
            LoadGrid();
            _ADMIN = aDMIN;
            this.ResizeMode = ResizeMode.NoResize;
        }
        SqlConnection con = new SqlConnection("data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework");

        private void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from [DIP_Programma]", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(dt);
            dataGridView1.ItemsSource = dt.DefaultView;
            con.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            REDProg u = new REDProg();
           
            u.Show();
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Pol u = new Pol();
            //this.Hide();
            //u.Show();
            _ADMIN.Label_MouseLeftButtonUp00(sender, e);
            this.Hide();

        }
        private void Label_MouseLeftButtonUp1(object sender, MouseButtonEventArgs e)
        {
            //Zanatiya u = new Zanatiya();
            //this.Hide();
            //u.Show();
            _ADMIN.Label_MouseLeftButtonUp11(sender, e);
            this.Hide();

        }
        private void Label_MouseLeftButtonUp2(object sender, MouseButtonEventArgs e)
        {
            //Blyda u = new Blyda();
            //this.Hide();
            //u.Show();
            _ADMIN.Label_MouseLeftButtonUp22(sender, e);
            this.Hide();

        }
        private void Label_MouseLeftButtonUp3(object sender, MouseButtonEventArgs e)
        {
            //Prog u = new Prog();
            //this.Hide();
            //u.Show();
            _ADMIN.Label_MouseLeftButtonUp33(sender, e);
            this.Hide();

        }
        private void Label_MouseLeftButtonUp4(object sender, MouseButtonEventArgs e)
        {
            ADMIN u = new ADMIN();
            this.Hide();
            u.Show();

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            //Zanatiya u = new Zanatiya();
            //this.Hide();
            //u.Show();
            LoadGrid();
        }
    }
}
