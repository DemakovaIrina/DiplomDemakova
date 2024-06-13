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
using System.Runtime.Remoting.Contexts;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для PProg.xaml
    /// </summary>
    public partial class PProg : Window
    {

        private LKPol _LKPol;

        public PProg(LKPol lKPol)
        {
            InitializeComponent();
            Update();
            this.ResizeMode = ResizeMode.NoResize;
            _LKPol = lKPol;
            LoadDataIntoComboBox();

           
        }
        SqlConnection con = new SqlConnection("data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework");

        private void LoadDataIntoComboBox()
        {
            string connectionString = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT nazvanie FROM [DIP_Programma]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB1.ItemsSource = dataTable.DefaultView;
                CB1.DisplayMemberPath = "nazvanie"; // Замените на имя колонки, которую вы хотите отобразить
            }
        }



            private void Update() //Создании функции Update для заполнения ListView фильмами
        {

            var films = App.Context.DIP_Programma.Where(p => p.id_Pol == App.CurrentUser.ID_Polzovatel).ToList(); //Переменная films, содержащая в себе список всех фильмов таблицы
            LViewFilmy.ItemsSource = films; //Заполнение ListView через переменную films

        }



        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //PProg u = new PProg();
            //this.Hide();
            //u.Show();
            _LKPol.Label_MouseLeftButtonUp00(sender, e);
            this.Hide();

        }
        private void Label_MouseLeftButtonUp1(object sender, MouseButtonEventArgs e)
        {
            //PDiet u = new PDiet();
            //this.Hide();
            //u.Show();
            _LKPol.Label_MouseLeftButtonUp11(sender, e);
            this.Hide();

        }
        private void Label_MouseLeftButtonUp2(object sender, MouseButtonEventArgs e)
        {
            LKPol u = new LKPol();
            this.Hide();
            u.Show();
            //_LKPol.Label_MouseLeftButtonUp(sender, e);

            //this.Hide();

        }

        private void LViewFilmy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PDopProg p = new PDopProg();
            p.Show();
        }
        private void UpdatePoisk() 
        {

            var prog = App.Context.DIP_Programma.Where(p => p.id_Pol == App.CurrentUser.ID_Polzovatel).ToList();
            prog = prog.Where(p => p.nazvanie.ToLower().Contains(TextBox1.Text.ToLower())).ToList();
            LViewFilmy.ItemsSource = prog;


        }



        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePoisk();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CB1.Text != "")
            {
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();

                string Varprog = "";
                string queryDN = "SELECT id_Programma FROM DIP_Programma WHERE nazvanie ='" + CB1.Text + "'";

                using (SqlConnection connection = new SqlConnection(connect))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(queryDN, connection);
                    var result = command.ExecuteScalar(); // Выполнение запроса и сохранение результата

                    if (result != null)
                    {

                        Varprog = result.ToString();

                    }

                }


                

                ZanProg a = new ZanProg(this);
                a.Show();
            }
            else { MessageBox.Show("Вы не выбрали программу!"); }

        }

        public string nazvanieProg() 
        {
            string name = CB1.Text;
            return name;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
