using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ADMIN.xaml
    /// </summary>
    public partial class ADMIN : Window
    {
        public ADMIN()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ADMRedakProfilya a = new ADMRedakProfilya();
            a.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = "";
            label2.Content = "";
            label3.Content = "";
            label4.Content = "";

            App.CurrentUser = null;

            MainWindow g = new MainWindow();    
            this.Close();
            g.Show();

            
        }
        public void Label_MouseLeftButtonUp00(object sender, MouseButtonEventArgs e)
        {
            Pol u = new Pol(this);
            this.Hide();
            u.Show();

        }
        public void Label_MouseLeftButtonUp11(object sender, MouseButtonEventArgs e)
        {
            Zanatiya u = new Zanatiya(this);
            this.Hide();
            u.Show();

        }
        public void Label_MouseLeftButtonUp22(object sender, MouseButtonEventArgs e)
        {
            Blyda u = new Blyda(this);
            this.Hide();
            u.Show();

        }
        public void Label_MouseLeftButtonUp33(object sender, MouseButtonEventArgs e)
        {
            Prog u = new Prog(this);
            this.Hide();
            u.Show();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label1.Content = App.CurrentUser.Imya;
            label2.Content = App.CurrentUser.Data_Rojdeniya;
            label3.Content = App.CurrentUser.Familiya;
            label4.Content = App.CurrentUser.email;

        }
    }
}
