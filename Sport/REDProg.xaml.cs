using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для REDProg.xaml
    /// </summary>
    public partial class REDProg : Window
    {
        public REDProg()
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

                string query = "SELECT id_kyrs FROM [DIP_Kyrs]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB1.ItemsSource = dataTable.DefaultView;
                CB1.DisplayMemberPath = "id_kyrs"; // Замените на имя колонки, которую вы хотите отобразить
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID_Polzovatel FROM [DIP_Polzovatel]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB5.ItemsSource = dataTable.DefaultView;
                CB5.DisplayMemberPath = "ID_Polzovatel"; // Замените на имя колонки, которую вы хотите отобразить
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id_DN FROM [DIP_DN]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB3.ItemsSource = dataTable.DefaultView;
                CB3.DisplayMemberPath = "id_DN"; // Замените на имя колонки, которую вы хотите отобразить
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id_Programma FROM [DIP_Programma]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB4.ItemsSource = dataTable.DefaultView;
                CB4.DisplayMemberPath = "id_Programma"; // Замените на имя колонки, которую вы хотите отобразить
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TB1.Text != "")
            {
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();

                string sInsSql = "Insert into [DIP_Programma](id_kyrs,id_DN,nazvanie,id_Pol) Values('{0}','{1}','{2}','{3}')";

                string kyrs = CB1.Text;
                string DN = CB3.Text;
                string nazvanie = TB1.Text;
                string pol = CB5.Text;


                string sInsSotr = string.Format(sInsSql, kyrs, DN, nazvanie, pol);

                SqlCommand cmdIns = new SqlCommand(sInsSotr, myConnection);

                cmdIns.ExecuteNonQuery();

                MessageBox.Show(string.Format("Новая запись успешно добавлена!"), "Сообщение");
            }
            else { MessageBox.Show(string.Format("Вы не заполнили все обязательные поля!"), "Сообщение"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CB4.Text != "")
            {
                BD db = new BD();
                DataTable table = new DataTable();
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();
                string a;


                SqlCommand command = new SqlCommand("update DIP_Programma set id_kyrs='" + this.CB1.Text + "',id_DN ='" + this.CB3.Text + "',nazvanie='" + this.TB1.Text + "',id_Pol ='"+this.CB5.Text +"' where id_Programma ='" + this.CB4.Text + "'", db.getConnection());

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();

                string sql = "select * from  [DIP_Programma]";
                command.CommandText = sql;
                DataSet m_set = new DataSet();
                adapter.Fill(m_set);

                db.closeConnection();

                MessageBox.Show(string.Format("Успешно изменено"), "Сообщение");
            }
            else { MessageBox.Show("Вы заполнили не все поля!"); }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CB4.Text != "")
            {
                BD db = new BD();


                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand("delete from [DIP_Programma] where id_Programma ='" + CB4.Text + "'", db.getConnection());
                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                string sql = "select * from [DIP_Programma]";
                command.CommandText = sql;
                DataSet m_set = new DataSet();
                adapter.Fill(m_set);

                db.closeConnection();
                MessageBox.Show(string.Format("Успешно удалено"), "Сообщение");
            }
            else { MessageBox.Show(string.Format("Выберете ID номер товара!"), "Сообщение"); }
        }
    }
}
