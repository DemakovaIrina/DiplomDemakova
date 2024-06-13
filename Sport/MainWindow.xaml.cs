using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser != null) 
            {
                App.CurrentUser = null;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (TB1.Text != "" && TB2.Text != "")
            {

                {
                    var currentUser = App.Context.DIP_Polzovatel.FirstOrDefault(p => p.login == TB2.Text && p.Parol == TB1.Text); //Сравниваем значение текстовых блоков со значениями в таблице User

                    if (currentUser != null) //Такой пользователь найден в таблице User
                    {
                        App.CurrentUser = currentUser; //ПРИСВАИВАЕМ ЗНАЧЕНИЕ ПЕРЕМЕННОЙ
                        if (App.CurrentUser.ID_roli == 1)
                        {
                            ADMIN x = new ADMIN();
                            this.Hide();
                            x.Show();
                        }
                        else if (App.CurrentUser.ID_roli == 2)
                        {
                            LKPol u = new LKPol();
                            this.Hide();
                            u.Show();
                            MessageBox.Show("Не забывайте обновлять ваш текущий вес после 2х недель занятий, чтоб отслеживать ваш прогресс!", "Сообщение");
                        }
                    }
                    else //Если пользователя нет
                    {
                        MessageBox.Show("Пользователь с такими данными не найден.", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }


            }
            else
            {
                MessageBox.Show("Введите логин и пароль");
            }
        }
        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Reg u = new Reg(this);
            this.Hide();
            u.Show();

        }

    }
}
