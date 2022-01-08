using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FinalProject.Views;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Home Home;
        
        private void Application_Startup(Object sender, StartupEventArgs e)
        {
            Home = new Home();
            Home.Show();
        }
    }
}
