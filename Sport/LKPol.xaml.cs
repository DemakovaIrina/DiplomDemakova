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
using Sport.BDModel;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Media3D;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для LKPol.xaml
    /// </summary>
    public partial class LKPol : Window
    {

        

        public LKPol()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            
        }
        SqlConnection con = new SqlConnection("data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework");
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           //вывод данных пользователя на форму
            ID.Content = App.CurrentUser.ID_Polzovatel;
            LBImya.Content = App.CurrentUser.Imya;
            LBDateRod.Content = App.CurrentUser.Data_Rojdeniya;
            LBFam.Content = App.CurrentUser.Familiya;
            LBEm.Content = App.CurrentUser.email;
            LBRost.Content = App.CurrentUser.Rost;
           //Вывод веса с самой старой датой
            SqlCommand commandT = new SqlCommand("SELECT ves FROM DIP_Ves JOIN(SELECT MAX(date) AS min_date   FROM DIP_Ves   WHERE id_pol = '" + App.CurrentUser.ID_Polzovatel + "') t2 ON date = t2.min_date WHERE id_pol = '" + App.CurrentUser.ID_Polzovatel + "'", con);
            con.Open();
            LBVesTek.Content = commandT.ExecuteScalar().ToString();

            //вывод веса с самой новой датой
            SqlCommand command = new SqlCommand("SELECT ves FROM DIP_Ves WHERE id_pol ='" + ID.Content + "'", con);
            LBVes.Content = command.ExecuteScalar().ToString();
            con.Close();

            
            
           
        }


        //Максимка ведьмочка
        public void ObnovitLKPol()
        {
            ID.Content = App.CurrentUser.ID_Polzovatel;
            LBImya.Content = App.CurrentUser.Imya;
            LBDateRod.Content = App.CurrentUser.Data_Rojdeniya;
            LBFam.Content = App.CurrentUser.Familiya;
            LBEm.Content = App.CurrentUser.email;
            LBRost.Content = App.CurrentUser.Rost;

            SqlCommand commandT = new SqlCommand("SELECT ves FROM DIP_Ves JOIN(SELECT MAX(date) AS min_date   FROM DIP_Ves   WHERE id_pol = '" + App.CurrentUser.ID_Polzovatel + "') t2 ON date = t2.min_date WHERE id_pol = '" + App.CurrentUser.ID_Polzovatel + "'", con);
            con.Open();
            LBVesTek.Content = commandT.ExecuteScalar().ToString();


            SqlCommand command = new SqlCommand("SELECT ves FROM DIP_Ves WHERE id_pol ='" + ID.Content + "'", con);
            LBVes.Content = command.ExecuteScalar().ToString();
            con.Close();
        }

        

        private void LichKabPol_Load(object sender, EventArgs e)
        {
            //// Получение значения свойства
            //label1.Content = myValue;
        }

        public void Label_MouseLeftButtonUp00(object sender, MouseButtonEventArgs e)
        {
            PProg u = new PProg(this);
            this.Hide();
            u.Show();

        }
        public void Label_MouseLeftButtonUp11(object sender, MouseButtonEventArgs e)
        {
            PDiet u = new PDiet(this);
            this.Hide();
            u.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow p = new MainWindow();
            p.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PolRedProfil p = new PolRedProfil(this);
            p.Show();
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PTekVes f = new PTekVes(this);  
            f.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string ves = LBVesTek.Content.ToString();
            string rost = LBRost.Content.ToString();


            double v = double.Parse(ves);
            double r = double.Parse(rost);

            double heightInMeters = r / 100; // Преобразование роста из см в метры
            double bmi = v / (heightInMeters * heightInMeters);
            bmi = Math.Round(bmi, 1);


            if (bmi <= 16) 
            {
                MessageBox.Show("Ваш ИМТ = " + bmi + ". Выраженный дифицит массы тела!", "Сообщение");

            } else if (bmi > 16 && bmi <= 18)
            {

                MessageBox.Show("Ваш ИМТ = " + bmi + ". Недостаточная масса тела!", "Сообщение");
            }
            else if (bmi > 18 && bmi <= 24)
            {

                MessageBox.Show("Ваш ИМТ = " + bmi + ". Нормальная масса тела!", "Сообщение");
            }
            else if (bmi > 24 && bmi <= 30)
            {

                MessageBox.Show("Ваш ИМТ = " + bmi + ". Избыточная масса тела!", "Сообщение");
            }
            else if (bmi > 30 && bmi <= 35)
            {

                MessageBox.Show("Ваш ИМТ = " + bmi + ". Ожирение первой степени!", "Сообщение");
            }
            else if (bmi > 35 && bmi <= 40)
            {

                MessageBox.Show("Ваш ИМТ = " + bmi + ". Ожирение второй степени!", "Сообщение");
            }
            else if (bmi > 40)
            {

                MessageBox.Show("Ваш ИМТ = " + bmi + ". Ожирение третей степени!", "Сообщение");
            }


           
        }
    }
}
