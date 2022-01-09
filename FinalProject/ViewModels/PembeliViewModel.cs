using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using FinalProject.Models;

namespace FinalProject.ViewModels
{
    class PembeliViewModel : BaseViewModel
    {
        private ObservableCollection<Pembeli> collectionPembeli;
        private Pembeli modelPembeli;

        public PembeliViewModel()
        {
            collectionPembeli = new ObservableCollection<Pembeli>();
            modelPembeli = new Pembeli();
            ReadCommand = new Command(async () => await ReadDataAsync());
            ReadCommand.Execute(null);
        }
        public ICommand ReadCommand { get; set; }
        public ObservableCollection<Pembeli> CollectionPembeli
        {
            get => collectionPembeli;
            set
            {
                SetProperty(ref collectionPembeli, value);
            }
        }
        public Pembeli Model
        {
            get => modelPembeli;
            set
            {
                SetProperty(ref modelPembeli, value);
            }
        }
        private async Task ReadDataAsync()
        {
            OpenConnection();
            await Task.Delay(0);
            var query = "SELECT * FROM [Pembeli]";
            var sqlcmd = new SQLiteCommand(query, Connection);

            var sqlresult = sqlcmd.ExecuteReader();

            if (sqlresult.HasRows)
            {
                collectionPembeli.Clear();
                while (sqlresult.Read())
                {
                    collectionPembeli.Add(new Pembeli
                    {
                        id_pembeli = sqlresult[0].ToString(),
                        nama_pembeli = sqlresult[1].ToString(),
                        alamat = sqlresult[2].ToString(),
                        Telepon = sqlresult[3].ToString(),
                    });
                }
            }
            CloseConnection();
        }
    }
}
