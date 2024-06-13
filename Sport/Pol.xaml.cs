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
    /// Логика взаимодействия для Pol.xaml
    /// </summary>
    public partial class Pol : Window
    {

        private ADMIN _ADMIN;

        public Pol(ADMIN aDMIN)
        {
            InitializeComponent();
            LoadGrid();
            LoadDataIntoComboBox();
            _ADMIN = aDMIN;
            this.ResizeMode = ResizeMode.NoResize;
        }
        string connectionString = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";


        private void LoadDataIntoComboBox()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Familiya FROM [DIP_Polzovatel]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB1.ItemsSource = dataTable.DefaultView;
                CB1.DisplayMemberPath = "Familiya"; // Замените на имя колонки, которую вы хотите отобразить
            }
        }
        SqlConnection con = new SqlConnection("data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework");

        private void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from [DIP_Polzovatel]", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(dt);
            DataGrid1.ItemsSource = dt.DefaultView;
            con.Close();

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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            REDPol u = new REDPol();
            u.Show();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            //Pol u = new Pol();
            //this.Hide();
            //u.Show();
            LoadGrid();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {

            string query = "SELECT ID_Polzovatel FROM DIP_Polzovatel WHERE Familiya ='" + CB1.Text + "'";
            string a = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    a = command.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    // Обработка исключения
                    Console.WriteLine(ex.Message);
                }
            }



            SqlCommand cmd = new SqlCommand("SELECT * FROM DIP_Programma Where id_Pol = '" + a.ToString() + "'", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(dt);
            dataGridView2.ItemsSource = dt.DefaultView;
            con.Close();



        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            string query = "SELECT ID_Polzovatel FROM DIP_Polzovatel WHERE Familiya ='" + CB1.Text + "'";
            string a = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    a = command.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    // Обработка исключения
                    Console.WriteLine(ex.Message);
                }
            }



            SqlCommand cmd = new SqlCommand("SELECT * FROM DIP_Dieta Where id_pol = '" + a.ToString() + "'", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(dt);
            dataGridView2.ItemsSource = dt.DefaultView;
            con.Close();
        }
    }
}
