using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using FinalProject.Models;
using FinalProject;

namespace FinalProject.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private ObservableCollection<User> collectionUser;
        private User modelUser;
        public LoginViewModel()
        {
            collectionUser = new ObservableCollection<User>();
            modelUser = new User();
            ReadLoginCommand = new Command(async () => await ReadDataAsync());
        }
        public ICommand ReadLoginCommand { get; set; }

        public ObservableCollection<User> CollectionUser
        {
            get => collectionUser;
            set
            {
                SetProperty(ref collectionUser, value);
            }
        }

        public User ModelUser
        {
            get => modelUser;
            set
            {
                SetProperty(ref modelUser, value);
            }
        }

        private bool check()
        {
            var chk = false;
            if (modelUser.username == null)
            {
                MessageBox.Show("ID can't null !", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                chk = false;
            }
            else if (modelUser.password == null)
            {
                MessageBox.Show("nama obat can't null !", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                chk = false;
            }
            else
            {
                chk = true;
            }
            return chk;
        }

        private async Task ReadDataAsync()
        {
            if (check())
            {
                OpenConnection();
                await Task.Delay(0);
                var query = $"SELECT * FROM User " +
                    $"WHERE username='{modelUser.username}' " +
                    $"AND password='{modelUser.password}'";
                var sqlcmd = new SQLiteCommand(query, Connection);

                var sqlresult = sqlcmd.ExecuteReader();

                if (sqlresult.HasRows)
                {
                    collectionUser.Clear();
                    while (sqlresult.Read())
                    {
                        collectionUser.Add(new User
                        {
                            id_user = sqlresult[0].ToString(),
                            username = sqlresult[1].ToString(),
                            role = sqlresult[3].ToString(),
                        });
                    }
                    //App.Dashboard = new Dashboard();
                    //App.Dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed Incorect Username or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            CloseConnection();
        }
    }
}
