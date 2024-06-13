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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для PDiet.xaml
    /// </summary>
    public partial class PDiet : Window
    {

        private LKPol _LKPol;
       
        public PDiet(LKPol lKPol)
        {
            InitializeComponent();
            Update();
            LoadDataIntoComboBox();
            this.ResizeMode = ResizeMode.NoResize;
            _LKPol = lKPol;
        }
        SqlConnection con = new SqlConnection("data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework");

        private void LoadDataIntoComboBox()
        {
            string connectionString = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT nazvanie FROM [DIP_Blyado]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CBSostav.ItemsSource = dataTable.DefaultView;
                CBSostav.DisplayMemberPath = "nazvanie"; // Замените на имя колонки, которую вы хотите отобразить
            }
            //LoadGrid();
        }

        private void UpdatePoisk()
        {

            var prog = App.Context.DIP_Dieta.Where(p => p.id_pol == App.CurrentUser.ID_Polzovatel).ToList();
            prog = prog.Where(p => p.nazvanie.ToLower().Contains(TextBox1.Text.ToLower())).ToList();
            LViewFilmy.ItemsSource = prog;


        }



        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePoisk();
        }

        private void Update() //Создании функции Update для заполнения ListView фильмами
        {

            var films = App.Context.DIP_Dieta.Where(p => p.id_pol == App.CurrentUser.ID_Polzovatel).ToList(); //Переменная films, содержащая в себе список всех фильмов таблицы
            LViewFilmy.ItemsSource = films; //Заполнение ListView через переменную films

        }

        private void SortItems()
        {

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LViewFilmy.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("date", ListSortDirection.Descending));


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PDobDiet p = new PDobDiet();
            p.Show();
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

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
            string query = "SELECT sostav FROM DIP_Blyado WHERE nazvanie = '" + CBSostav.Text + "'";




            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show(reader[0].ToString(), "Состав блюда:");
                }
                reader.Close();


            }

        }

     


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (ChecB1.IsChecked == true)
            {
                SortItems();
            }
            else if (ChecB1.IsChecked == false) 
            { 
                Update();
            }
            
        }

        private void Button_ClickB(object sender, RoutedEventArgs e)
        {
            PDobBlyda f = new PDobBlyda();
            f.Show();
        }
    }
}
