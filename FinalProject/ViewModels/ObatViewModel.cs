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
    public class ObatViewModel : BaseViewModel
    {
        private ObservableCollection<Obat> collection;
        private Obat model;
        public ObatViewModel()
        {
            collection = new ObservableCollection<Obat>();
            model = new Obat();
            InsertCommand = new Command(async () => await InsertDataAsync());
            UpdateCommand = new Command(async () => await UpdateDataAsync());
            DeleteCommand = new Command(async () => await DeleteDataAsync());
            ReadCommand = new Command(async () => await ReadDataAsync());
            ReadCommand.Execute(null);
        }

        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        
        public ObservableCollection<Obat> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                SetProperty(ref collection, value);
            }
        }

        public Obat Model
        {
            get => model;
            set
            {
                SetProperty(ref model, value);
            }
        }


        private string _test;
        public string Test
        {
            get => _test;
            set => SetProperty(ref _test, value);
        }

        private async Task ReadDataAsync()
        {
            OpenConnection();
            await Task.Delay(0);
            var query = "SELECT * FROM [Obat]";
            var sqlcmd = new SQLiteCommand(query, Connection);

            var sqlresult = sqlcmd.ExecuteReader();

            if (sqlresult.HasRows)
            {
                collection.Clear();
                while (sqlresult.Read())
                {
                    collection.Add(new Obat
                    {
                        id_obat = sqlresult[0].ToString(),
                        nama_obat = sqlresult[1].ToString(),
                        khasiat = sqlresult[2].ToString(),
                        jumlah = sqlresult[3].ToString(),
                        harga_satuan = sqlresult[4].ToString(),
                    });
                }
            }
            CloseConnection();
        }
        private bool check()
        {
            var chk = false;
            if (model.id_obat == null)
            {
                MessageBox.Show("ID can't null !", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                chk = false;
            }
            else if (model.nama_obat == null)
            {
                MessageBox.Show("nama obat can't null !", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                chk = false;
            }
            else if (model.harga_satuan == null)
            {
                MessageBox.Show("harga satuan can't null !", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                chk = false;
            }
            else
            {
                chk = true;
            }
            return chk;
        }

        private async Task InsertDataAsync()
        {
            try
            {
                if (check())
                {
                    OpenConnection();
                    await Task.Delay(0);
                    var query = $"INSERT INTO Obat " +
                        $"VALUES('{model.id_obat}','{model.nama_obat}','{model.khasiat}','{model.jumlah}','{model.harga_satuan}')";
                    //$"VALUES('{model.id_obat}','{model.nama_obat}','{model.khasiat}','{model.jumlah}','{model.harga_satuan}')";
                    var sqlcmd = new SQLiteCommand(query, Connection);

                    var sqlresult = sqlcmd.ExecuteNonQuery();
                    CloseConnection();
                    await ReadDataAsync();
                    MessageBox.Show("Sucessfully Input", "Data Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            catch (SQLiteException msg)
            {
                MessageBox.Show(msg.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private async Task UpdateDataAsync()
        {
            try
            {
                if (check())
                {
                    OpenConnection();
                    await Task.Delay(0);
                    var query = $"UPDATE Obat SET " +
                        $"nama_obat = '{model.nama_obat}', "+ 
                        $"khasiat = '{model.khasiat}', "+ 
                        $"jumlah = '{model.jumlah}', "+
                        $"harga_satuan = '{model.harga_satuan}' " +
                        $"WHERE id_obat = '{model.id_obat}'";
                    //$"VALUES('{model.id_obat}','{model.nama_obat}','{model.khasiat}','{model.jumlah}','{model.harga_satuan}')";
                    var sqlcmd = new SQLiteCommand(query, Connection);

                    var sqlresult = sqlcmd.ExecuteNonQuery();
                    CloseConnection();
                    await ReadDataAsync();
                    MessageBox.Show("Sucessfully Update", "Data Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (SQLiteException msg)
            {
                MessageBox.Show(msg.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private async Task DeleteDataAsync()
        {
            try
            {
                if (check())
                {
                    OpenConnection();
                    await Task.Delay(0);
                    var query = $"DELETE FROM Obat " +
                        $"WHERE id_obat = '{model.id_obat}'";
                    //$"VALUES('{model.id_obat}','{model.nama_obat}','{model.khasiat}','{model.jumlah}','{model.harga_satuan}')";
                    var sqlcmd = new SQLiteCommand(query, Connection);

                    var sqlresult = sqlcmd.ExecuteNonQuery();
                    CloseConnection();
                    await ReadDataAsync();
                    MessageBox.Show("Sucessfully Deleted", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (SQLiteException msg)
            {
                MessageBox.Show(msg.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
