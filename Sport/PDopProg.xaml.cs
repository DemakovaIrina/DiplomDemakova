using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
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
    /// Логика взаимодействия для PDopProg.xaml
    /// </summary>
    public partial class PDopProg : Window
    {
        public PDopProg()
        {
            InitializeComponent();

            LoadDataIntoComboBox();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void LoadDataIntoComboBox()
        {
            string connectionString = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT nazvanie FROM [DIP_Kyrs]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB1.ItemsSource = dataTable.DefaultView;
                CB1.DisplayMemberPath = "nazvanie"; // Замените на имя колонки, которую вы хотите отобразить
            }
           using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT nazvanie FROM [DIP_DN]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB3.ItemsSource = dataTable.DefaultView;
                CB3.DisplayMemberPath = "nazvanie"; // Замените на имя колонки, которую вы хотите отобразить
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection myConnection = new SqlConnection(@connect);
            myConnection.Open();
           
            string VarK = "";
            string query = "SELECT id_kyrs FROM DIP_Kyrs WHERE nazvanie ='"+ CB1.Text + "'";

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                var result = command.ExecuteScalar(); // Выполнение запроса и сохранение результата

                if (result != null)
                {

                     VarK = result.ToString();
                    
                }
               
            }

            string VarDN = "";
            string queryDN = "SELECT id_DN FROM DIP_DN WHERE nazvanie ='" + CB3.Text + "'";

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryDN, connection);
                var result = command.ExecuteScalar(); // Выполнение запроса и сохранение результата

                if (result != null)
                {

                    VarDN = result.ToString();

                }

            }


            string sInsSql = "Insert into [DIP_Programma](id_kyrs,id_DN,nazvanie,id_Pol) Values('{0}','{1}','{2}','{3}')";


            string kyrs = VarK;
            string dn = VarDN;
            string nazvanie = TB1.Text;
            string pol = App.CurrentUser.ID_Polzovatel.ToString();




            string sInsSotr = string.Format(sInsSql, kyrs, dn, nazvanie, pol);

            SqlCommand cmdIns = new SqlCommand(sInsSotr, myConnection);

            cmdIns.ExecuteNonQuery();

            MessageBox.Show(string.Format("Новая запись успешно добавлена!"), "Сообщение");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
