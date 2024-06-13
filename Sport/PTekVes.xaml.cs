using Sport.BDModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для PTekVes.xaml
    /// </summary>
    public partial class PTekVes : Window
    {

        //Максимка ведьмочка
        private LKPol _LKPol;

        //
        private WeightDifferenceCalculator weightDifferenceCalculator;
        //

        //Максимка ведьмочка
        public PTekVes(LKPol lKPol)
        {
            InitializeComponent();
            //
            string connectionString = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
            weightDifferenceCalculator = new WeightDifferenceCalculator(connectionString);
            _LKPol = lKPol;
            this.ResizeMode = ResizeMode.NoResize;
            //
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection myConnection = new SqlConnection(@connect);
            myConnection.Open();

            string sInsSql = "Insert into [DIP_Ves](ves,date,id_pol) Values('{0}','{1}','{2}')";
           
            DateTime d = DateTime.Now;

            string ves = TBTekVes.Text;
            string date = d.ToString();
            string pol = App.CurrentUser.ID_Polzovatel.ToString();



            string sInsSotr = string.Format(sInsSql, ves, date, pol);

            SqlCommand cmdIns = new SqlCommand(sInsSotr, myConnection);

            cmdIns.ExecuteNonQuery();


            //SqlCommand SVes = new SqlCommand("SELECT ves FROM DIP_Ves JOIN(SELECT MIN(date) AS min_date FROM DIP_Ves WHERE id_pol = '" + App.CurrentUser.ID_Polzovatel + "') t2ON date = t2.min_date WHERE id_pol = '" + App.CurrentUser.ID_Polzovatel + "'", myConnection);

            //SqlCommand NVes = new SqlCommand("SELECT ves FROM DIP_Ves JOIN(SELECT MAX(date) AS min_date FROM DIP_Ves WHERE id_pol = '" + App.CurrentUser.ID_Polzovatel + "') t2ON date = t2.min_date WHERE id_pol = '" + App.CurrentUser.ID_Polzovatel + "'", myConnection);

            //int razn = Convert.ToInt32(SVes) - Convert.ToInt32(NVes);


            //
            int userId = App.CurrentUser.ID_Polzovatel;
            int weightDifference = weightDifferenceCalculator.CalculateWeightDifference(userId);
            //
            

            // SELECT ves FROM DIP_Ves JOIN( SELECT MIN(date) AS min_date   FROM DIP_Ves   WHERE id_pol = '"+ App. +"') t2ON date = t2.min_date WHERE id_pol = '"+ App. +"'";

            // SELECT ves FROM DIP_Ves JOIN( SELECT MAX(date) AS min_date   FROM DIP_Ves   WHERE id_pol = '"+ App. +"') t2ON date = t2.min_date WHERE id_pol = '"+ App. +"'";


            MessageBox.Show("Вес успешно изменён!"+" Поздравляем! За все время ваш вес уменшился на "+ -weightDifference +" кг!", "Сообщение");
            _LKPol.ObnovitLKPol();
            this.Close();
        }
        
    }
  

    //он вроде форму создает ща глянем
    public class WeightDifferenceCalculator
    {
        private string connectionString;

        public WeightDifferenceCalculator(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int CalculateWeightDifference(int userId)
        {
            DateTime minDate = GetMinDate(userId);
            DateTime maxDate = GetMaxDate(userId);

            int minWeight = GetWeight(userId, minDate);
            int maxWeight = GetWeight(userId, maxDate);

            return maxWeight - minWeight;
        }

        private DateTime GetMinDate(int userId)
        {
            DateTime minDate = DateTime.MinValue;
            string query = "SELECT MIN(date) AS min_date FROM DIP_Ves WHERE id_pol = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection); 
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    minDate = Convert.ToDateTime(result);
                }
            }

            return minDate;
        }
        
        private DateTime GetMaxDate(int userId)
        {
            DateTime maxDate = DateTime.MinValue;
            string query = "SELECT MAX(date) AS max_date FROM DIP_Ves WHERE id_pol = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    maxDate = Convert.ToDateTime(result);
                }
            }

            return maxDate;
        }

        private int GetWeight(int userId, DateTime date)
        {
            int weight = 0;
            string query = "SELECT ves FROM DIP_Ves WHERE id_pol = @userId AND date = @date";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@date", date);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    weight = Convert.ToInt32(result);
                }
            }

            return weight;
        }
    }
    //
}
