using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для ADMRedakProfilya.xaml
    /// </summary>
    public partial class ADMRedakProfilya : Window
    {
        public ADMRedakProfilya()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
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

            if (TB1.Text == "" && TB2.Text == "" && TB3.Text == "" && TB4.Text == "" && TB5.Text == "")
            {

                MessageBox.Show("Пожалуйста заполните поля, которые хотите изменить!", "Сообщение");

            }
            else
            {
                this.Close();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
          
        }
    }
    }

