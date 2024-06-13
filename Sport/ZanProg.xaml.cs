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
using System.Windows.Threading;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для ZanProg.xaml
    /// </summary>
    public partial class ZanProg : Window
    {

        DispatcherTimer timer = new DispatcherTimer();

        private PProg _PProg;

        public ZanProg(PProg pProg)
        {

            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += timer_tick;
            media1.LoadedBehavior = MediaState.Manual;
            media1.UnloadedBehavior = MediaState.Manual;
            _PProg = pProg; 

        }

        private void timer_tick(object sender, EventArgs e)
        {
            time.Text = media1.Position.ToString(@"mm\:ss");
            sliderback2.Value = media1.Position.TotalSeconds;
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            media1.Play();
            timer.Start();
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            media1.Pause();
            timer.Stop();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            media1.Stop();
            timer.Stop();
        }

        private void media1_MediaOpened(object sender, RoutedEventArgs e)
        {
            slider2.Maximum = media1.NaturalDuration.TimeSpan.TotalSeconds;
            sliderback2.Maximum = media1.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (media1 != null)
            {
                media1.Volume = slider1.Value;
            }
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media1.Pause();
            media1.Position = TimeSpan.FromSeconds(slider2.Value);
            media1.Play();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LBNameProg.Content = _PProg.nazvanieProg();

            string connect = "data source=stud-mssql.sttec.yar.ru,38325;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection myConnection = new SqlConnection(@connect);
            myConnection.Open();

            string Varprog = "";
            
            string queryDN = "SELECT id_kyrs FROM DIP_Programma WHERE nazvanie ='" + LBNameProg.Content + "'";
           

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryDN, connection);
                var result = command.ExecuteScalar(); // Выполнение запроса и сохранение результата

                if (result != null)
                {

                    Varprog = result.ToString();

                }
                connection.Close();
            }

            if (Varprog == "") 
            {
                MessageBox.Show("такого занятия не существует");
            }
            if (Varprog == "1")
            {
                //Ягодицы
                media1.Source = new Uri("jopa.mp4", UriKind.RelativeOrAbsolute);
            }
            if (Varprog == "2")
            {
                //Пресс
                media1.Source = new Uri("press.mp4", UriKind.RelativeOrAbsolute);

            }
            if (Varprog == "3")
            {
                //Руки и плечи
                media1.Source = new Uri("ryki.mp4", UriKind.RelativeOrAbsolute);
            }



        }

        private void sliderback2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }
    }
}
