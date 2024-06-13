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
using System.Reflection.Emit;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для PolRedProfil.xaml
    /// </summary>
    public partial class PolRedProfil : Window
    {

        private LKPol _LKPol;

        public PolRedProfil(LKPol lKPol)
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            _LKPol = lKPol;
        }
       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            label4.Content = App.CurrentUser.ID_Polzovatel;
           


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TB1.Text != "")
            {
                BD db = new BD();
                DataTable table = new DataTable();
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();
                string a;
                


                SqlCommand command = new SqlCommand("update DIP_Polzovatel set Imya='" + this.TB1.Text + "' where ID_Polzovatel ='" + this.label4.Content + "'", db.getConnection());

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();

                string sql = "select Imya from  [DIP_Polzovatel]";
                command.CommandText = sql;
                DataSet m_set = new DataSet();
                adapter.Fill(m_set);

                db.closeConnection();


            }
            if (TB2.Text != "")
            {
                BD db = new BD();
                DataTable table = new DataTable();
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();
                string a;


                SqlCommand command = new SqlCommand("update DIP_Polzovatel set Familiya='" + this.TB2.Text + "' where ID_Polzovatel ='" + this.label4.Content + "'", db.getConnection());

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();

                string sql = "select Familiya from  [DIP_Polzovatel]";
                command.CommandText = sql;
                DataSet m_set = new DataSet();
                adapter.Fill(m_set);

                db.closeConnection();


            }
            if (TB3.Text != "")
            {
                BD db = new BD();
                DataTable table = new DataTable();
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();
                string a;


                SqlCommand command = new SqlCommand("update DIP_Polzovatel set email='" + this.TB3.Text + "' where ID_Polzovatel ='" + this.label4.Content + "'", db.getConnection());

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();

                string sql = "select email from  [DIP_Polzovatel]";
                command.CommandText = sql;
                DataSet m_set = new DataSet();
                adapter.Fill(m_set);

                db.closeConnection();


            }
            if (TB4.Text != "")
            {
                BD db = new BD();
                DataTable table = new DataTable();
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();
                string a;


                SqlCommand command = new SqlCommand("update DIP_Polzovatel set login='" + this.TB4.Text + "' where ID_Polzovatel ='" + this.label4.Content + "'", db.getConnection());

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();

                string sql = "select login from  [DIP_Polzovatel]";
                command.CommandText = sql;
                DataSet m_set = new DataSet();
                adapter.Fill(m_set);

                db.closeConnection();


            }
            if (TB5.Text != "")
            {
                BD db = new BD();
                DataTable table = new DataTable();
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();
                string a;


                SqlCommand command = new SqlCommand("update DIP_Polzovatel set Parol='" + this.TB5.Text + "' where ID_Polzovatel ='" + this.label4.Content + "'", db.getConnection());

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();

                string sql = "select Parol from  [DIP_Polzovatel]";
                command.CommandText = sql;
                DataSet m_set = new DataSet();
                adapter.Fill(m_set);

                db.closeConnection();


            }
            if (TB6.Text != "")
            {
                BD db = new BD();
                DataTable table = new DataTable();
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();
                string a;


                SqlCommand command = new SqlCommand("update DIP_Polzovatel set Rost='" + this.TB6.Text + "' where ID_Polzovatel ='" + this.label4.Content + "'", db.getConnection());

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();

                string sql = "select Rost from  [DIP_Polzovatel]";
                command.CommandText = sql;
                DataSet m_set = new DataSet();
                adapter.Fill(m_set);

                db.closeConnection();


            }
            if (TB7.Text != "")
            {
                BD db = new BD();
                DataTable table = new DataTable();
                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();





                DateTime d = DateTime.Now;


                SqlCommand command = new SqlCommand("update DIP_Ves set ves='" + this.TB7.Text + "',date='"+ d.ToString() +"' where id_pol ='" + this.label4.Content + "'", db.getConnection());

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();

                string sql = "select ves, date from [DIP_Ves]";
                command.CommandText = sql;
                DataSet m_set = new DataSet();
                adapter.Fill(m_set);

                db.closeConnection();
               
               

            }
            if (TB1.Text == "" && TB2.Text == "" && TB3.Text == "" && TB4.Text == "" && TB5.Text == "" && TB6.Text == "" && TB7.Text == "")
            {

                MessageBox.Show("Пожалуйста заполните поля, которые хотите изменить!", "Сообщение");

            }
            else
            {
                this.Close();
            }
            //Максимка ведьмочка
            _LKPol.ObnovitLKPol();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
