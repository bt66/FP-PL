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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FinalProject.ViewModels;
using FinalProject.Models;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObatViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new ObatViewModel();
            DataContext = vm;
        }

        private void InputButtonClick(object sender, RoutedEventArgs e)
        {
            vm.Model = new Obat();
        }
    }
}
