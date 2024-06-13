using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PDobBlyda.xaml
    /// </summary>
    public partial class PDobBlyda : Window
    {
        public PDobBlyda()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection myConnection = new SqlConnection(@connect);
            myConnection.Open();

            string sInsSql = "Insert into [DIP_Blyado](nazvanie,sostav,kolorii) Values('{0}','{1}','{2}')";

            string nazvanie = TB1.Text;
            string sostav = TB2.Text;
            string koll = TB3.Text;
           
            string sInsSotr = string.Format(sInsSql, nazvanie, sostav, koll);

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
