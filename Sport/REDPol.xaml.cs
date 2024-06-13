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
    /// Логика взаимодействия для REDPol.xaml
    /// </summary>
    public partial class REDPol : Window
    {
        public REDPol()
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

                string query = "SELECT ID_Polzovatel FROM [DIP_Polzovatel]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB1.ItemsSource = dataTable.DefaultView;
                CB1.DisplayMemberPath = "ID_Polzovatel"; // Замените на имя колонки, которую вы хотите отобразить
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID_Roli FROM [DIP_Rol]"; // Замените на ваш запрос SQL и таблицу
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Настройте ComboBox
                CB2.ItemsSource = dataTable.DefaultView;
                CB2.DisplayMemberPath = "ID_Roli"; // Замените на имя колонки, которую вы хотите отобразить
            }
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection myConnection = new SqlConnection(@connect);
            if (TB1.Text != "")
            {
                
                myConnection.Open();

                string sInsSql = "Insert into [DIP_Polzovatel](ID_roli,Imya,Familiya,Othestvo,Data_Rojdeniya,email,[Rost],login,Parol) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')";


                string roli = CB2.Text;
                string Imya = TB1.Text;
                string Familiya = TB2.Text;
                string Othestvo = TB3.Text;
                string DataRojdeniya = TB4.Text;
                string pochta = TB5.Text;

                string Rost = TB6.Text;
                string telefon = TB7.Text;
                string Parol = TB8.Text;


                string sInsSotr = string.Format(sInsSql, roli, Imya, Familiya, Othestvo, DataRojdeniya, pochta, Rost, telefon, Parol);

                SqlCommand cmdIns = new SqlCommand(sInsSotr, myConnection);

                cmdIns.ExecuteNonQuery();
                myConnection.Close();
              

            }
            if (TB9.Text != "") {

                myConnection.Open();

                SqlCommand cmves = new SqlCommand("SELECT ID_Polzovatel FROM DIP_Polzovatel WHERE Imya ='" + TB1.Text + "' AND Familiya ='" + TB2.Text + "' AND Othestvo = '" + TB3.Text + "' AND Rost ='" + TB6.Text + "' AND login ='" + TB7.Text + "' AND Parol ='" + TB8.Text + "'", myConnection);
                ID.Content = cmves.ExecuteScalar().ToString();  



                DateTime d = DateTime.Now;

                string sInsSqlVes = "Insert into [DIP_Ves]([ves],date,id_pol) Values('{0}','{1}','{2}')";


                string ves = TB9.Text;
                string date = d.ToString();
                string pol = ID.Content.ToString();

                string sves = string.Format(sInsSqlVes, ves, date, pol);

                SqlCommand cmdInsves = new SqlCommand(sves, myConnection);

                cmdInsves.ExecuteNonQuery();

                myConnection.Close();

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


                SqlCommand command = new SqlCommand("update DIP_Polzovatel set ID_roli='" + this.CB2.Text + "',Imya='" + this.TB1.Text + "',Familiya ='" + this.TB2.Text + "',Othestvo='" + this.TB3.Text + "',Data_Rojdeniya='" + this.TB4.Text + "',email='" + this.TB5.Text  + "',Rost='" + this.TB6.Text + "',login='" + this.TB7.Text + "',Parol='" + this.TB8.Text + "' where ID_Polzovatel ='" + this.CB1.Text + "'", db.getConnection());

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();

                string sql = "select * from  [DIP_Polzovatel]";
                command.CommandText = sql;
                DataSet m_set = new DataSet();
                adapter.Fill(m_set);

                db.closeConnection();

                MessageBox.Show(string.Format("Успешно изменено"), "Сообщение");




                DateTime d = DateTime.Now;


                SqlCommand commandves = new SqlCommand("update DIP_Ves set ves='" + this.TB9.Text + "',date='" + d.ToString() + "' where id_pol ='" + CB1.Text + "'", db.getConnection());

                db.openConnection();
                SqlDataAdapter adapterves = new SqlDataAdapter(commandves);
                commandves.ExecuteNonQuery();

                string sqlves = "select ves, date from [DIP_Ves]";
                command.CommandText = sqlves;
                DataSet m_set_ves = new DataSet();
                adapterves.Fill(m_set_ves);

                db.closeConnection();



            }
            else { MessageBox.Show("Вы заполнили не все поля!"); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {   
            if (CB1.Text != "")
            {   //Подключение к бд через класс
                BD db = new BD();
                //Вычисление айди номера веса для удаления
                SqlCommand commandves = new SqlCommand("delete from [DIP_Ves] where id_pol ='" + CB1.Text + "'", db.getConnection());
                db.openConnection();
                SqlDataAdapter adapterves = new SqlDataAdapter(commandves);
                commandves.ExecuteNonQuery();
                string sql_ves = "select * from [DIP_Ves]";
                commandves.CommandText = sql_ves;
                DataSet m_set_ves = new DataSet();
                adapterves.Fill(m_set_ves);

                //Удаление записи пользователя
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand("delete from [DIP_Polzovatel] where ID_Polzovatel ='" + CB1.Text + "'", db.getConnection());
                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                string sql = "select * from [DIP_Polzovatel]";
                command.CommandText = sql;
                DataSet m_set = new DataSet();
                adapter.Fill(m_set);
                db.closeConnection();
                //Вывод сообщения
                MessageBox.Show(string.Format("Успешно удалено"), "Сообщение");
            }
            else { MessageBox.Show(string.Format("Выберете ID номер пользователя!"), "Сообщение"); }
        }
    }
}
