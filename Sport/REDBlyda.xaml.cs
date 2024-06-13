﻿using System;
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
    /// Логика взаимодействия для REDBlyda.xaml
    /// </summary>
    public partial class REDBlyda : Window
    {
        public REDBlyda()
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

                string query = "SELECT id_Blyada FROM [DIP_Blyado]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB1.ItemsSource = dataTable.DefaultView;
                CB1.DisplayMemberPath = "id_Blyada"; // Замените на имя колонки, которую вы хотите отобразить
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TB1.Text != "")
            {
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();

                string sInsSql = "Insert into [DIP_Blyado]([nazvanie],sostav,kolorii) Values('{0}','{1}','{2}')";


                string nazvanie = TB1.Text;
                string sostav = TB2.Text;
                string kolorii = TB3.Text;



                string sInsSotr = string.Format(sInsSql, nazvanie, sostav, kolorii);

                SqlCommand cmdIns = new SqlCommand(sInsSotr, myConnection);

                cmdIns.ExecuteNonQuery();

                MessageBox.Show(string.Format("Новая запись успешно добавлена!"), "Сообщение");
            }
            else { MessageBox.Show(string.Format("Вы не заполнили все обязательные поля!"), "Сообщение"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CB1.Text != "" && TB1.Text != "")
            {
                BD db = new BD();
                DataTable table = new DataTable();
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();
                string a;


                SqlCommand command = new SqlCommand("update DIP_Blyado set nazvanie='" + this.TB1.Text + "',sostav='" + this.TB2.Text + "',kolorii ='" + this.TB3.Text + "' where id_Blyada ='" + this.CB1.Text + "'", db.getConnection());

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();

                string sql = "select * from  [DIP_Blyado]";
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
            if (CB1.Text != "")
            {
                BD db = new BD();


                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand("delete from [DIP_Blyado] where id_Blyada ='" + CB1.Text + "'", db.getConnection());
                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                string sql = "select * from [DIP_Blyado]";
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
