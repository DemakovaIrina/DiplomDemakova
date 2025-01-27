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
    /// Логика взаимодействия для PDobDiet.xaml
    /// </summary>
    public partial class PDobDiet : Window
    {
        public PDobDiet()
        {
            InitializeComponent();
            LoadDataIntoComboBox();
            this.ResizeMode = ResizeMode.NoResize;
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
                CB1.ItemsSource = dataTable.DefaultView;
                CB1.DisplayMemberPath = "nazvanie"; // Замените на имя колонки, которую вы хотите отобразить
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT nazvanie FROM [DIP_Vremya]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB2.ItemsSource = dataTable.DefaultView;
                CB2.DisplayMemberPath = "nazvanie"; // Замените на имя колонки, которую вы хотите отобразить
            }


            //LoadGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection myConnection = new SqlConnection(@connect);
            myConnection.Open();

            string VarB = "";
            string query = "SELECT id_Blyada FROM DIP_Blyado WHERE nazvanie ='" + CB1.Text + "'";

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                var result = command.ExecuteScalar(); // Выполнение запроса и сохранение результата

                if (result != null)
                {

                    VarB = result.ToString();

                }

            }


            string VarV = "";
            string queryD = "SELECT id_vremya FROM DIP_Vremya WHERE nazvanie ='" + CB2.Text + "'";

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryD, connection);
                var result = command.ExecuteScalar(); // Выполнение запроса и сохранение результ

                if (result != null)
                {

                    VarV = result.ToString();

                }

            }

            DateTime d = DateTime.Now;



            string sInsSql = "Insert into [DIP_Dieta](id_Blyda,id_Vremya,nazvanie,razmer_porcii,date, id_pol) Values('{0}','{1}','{2}','{3}','{4}','{5}')";

            string blydo = VarB;
            string vremya = VarV;
            string nazvanie = TB1.Text;
            string razmer = TB2.Text;
            string date = d.ToString();
            string pol = App.CurrentUser.ID_Polzovatel.ToString();




            string sInsSotr = string.Format(sInsSql, blydo, vremya, nazvanie, razmer,date, pol);

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
