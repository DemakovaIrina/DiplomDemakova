using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {

        private MainWindow _MainWindow;

        public Reg(MainWindow mainWindow)
        {
            InitializeComponent();
            _MainWindow = mainWindow;
            this.ResizeMode = ResizeMode.NoResize;
        }
        SqlConnection con = new SqlConnection("data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework");


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBImya.Text != "" && TBFamiliya.Text != "" && TBDateRojd.Text != "" && TBRost.Text != "" && TBTelefon.Text != "" && TBParol.Text != "" && TBVes.Text != "")
            {

                string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
                SqlConnection myConnection = new SqlConnection(@connect);
                myConnection.Open();


                string sInsSql = "Insert into [DIP_Polzovatel](ID_roli,Imya,Familiya,Othestvo,Data_Rojdeniya,[Rost],login,Parol) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";


                string roli = "2";
                string Imya = TBImya.Text;
                string Familiya = TBFamiliya.Text;
                string Othestvo = TBOtchestvo.Text;
                string DataRojdeniya = TBDateRojd.Text;
             
                string Rost = TBRost.Text;
                string telefon = TBTelefon.Text;
                string Parol = TBParol.Text;


                string sInsSotr = string.Format(sInsSql, roli, Imya, Familiya, Othestvo, DataRojdeniya, Rost, telefon, Parol);

                SqlCommand cmdIns = new SqlCommand(sInsSotr, myConnection);

                cmdIns.ExecuteNonQuery();

                MessageBox.Show(string.Format("Ваша учетная запись успешно зарегестрированна!"), "Сообщение");
           


            SqlCommand command = new SqlCommand("SELECT ID_Polzovatel FROM DIP_Polzovatel WHERE Imya ='" + TBImya.Text + "' AND Familiya ='" + TBFamiliya.Text + "' AND Othestvo = '" + TBOtchestvo.Text+ "' AND Rost ='" + TBRost.Text + "' AND login ='" + TBTelefon.Text+ "' AND Parol ='" + TBParol.Text+"' ", con);
            con.Open(); 

            ID.Content = command.ExecuteScalar().ToString();
            con.Close();

                DateTime d = DateTime.Now;

                string sInsSqlVes = "Insert into [DIP_Ves]([ves],date,id_pol) Values('{0}','{1}','{2}')"; 


                string ves = TBVes.Text;
                string date = d.ToString();
                string pol = ID.Content.ToString();

                string sves = string.Format(sInsSqlVes, ves, date, pol); 

                SqlCommand cmdInsves = new SqlCommand(sves, myConnection);

                cmdInsves.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show(string.Format("Вы заполнили не все поля! Пожалуйста, проверте все данные."), "Сообщение");
            }

        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow u = new MainWindow();
            this.Hide();
            u.Show();

        }

        private void TBRost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
              && (!TBRost.Text.Contains(".")
              && TBRost.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void TBTelefon_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        private void TBImya_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (Regex.IsMatch(textBox.Text, @"[^а-яА-Яa-zA-Z]"))
            {

                textBox.Text = textBox.Text.Remove(textBox.SelectionStart - 1, 1);
            }
        }

        private void TBFamiliya_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;


            if (Regex.IsMatch(textBox.Text, @"[^а-яА-Яa-zA-Z]"))
            {

                textBox.Text = textBox.Text.Remove(textBox.SelectionStart - 1, 1);
            }
        }

        private void TBOtchestvo_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;


            if (Regex.IsMatch(textBox.Text, @"[^а-яА-Яa-zA-Z]"))
            {

                textBox.Text = textBox.Text.Remove(textBox.SelectionStart - 1, 1);
            }
        }

        private void TBDateRojd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
            //  && (!TBRost.Text.Contains(".")
            //  && TBRost.Text.Length != 0)))
            //{
            //    e.Handled = true;
            //}
        }
    }
}
