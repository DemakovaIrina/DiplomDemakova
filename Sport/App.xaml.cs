using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static BDModel.user45_dbEntities4 Context
        { get; } = new BDModel.user45_dbEntities4();

        public static BDModel.DIP_Polzovatel CurrentUser = null;
    }
}
