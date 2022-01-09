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
            InsertPembeliCommand = new Command(async () => await InsertDataAsync());
            UpdatePembeliCommand = new Command(async () => await UpdateDataAsync());
            DeletePembeliCommand = new Command(async () => await DeleteDataAsync());
            ReadPembeliCommand = new Command(async () => await ReadDataAsync());
            ReadPembeliCommand.Execute(null);
        }
        public ICommand ReadPembeliCommand { get; set; }
        public ICommand UpdatePembeliCommand { get; set; }
        public ICommand DeletePembeliCommand { get; set; }
        public ICommand InsertPembeliCommand { get; set; }
        public ObservableCollection<Pembeli> CollectionPembeli
        {
            get => collectionPembeli;
            set
            {
                SetProperty(ref collectionPembeli, value);
            }
        }
        public Pembeli ModelPembeli
        {
            get => modelPembeli;
            set
            {
                SetProperty(ref modelPembeli, value);
            }
        }

        private bool check()
        {
            var chk = false;
            if (modelPembeli.id_pembeli == null)
            {
                MessageBox.Show("ID pembeli can't null !", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                chk = false;
            }
            else if (modelPembeli.nama_pembeli == null)
            {
                MessageBox.Show("nama pembeli can't null !", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                chk = false;
            }
            else if (modelPembeli.alamat == null)
            {
                MessageBox.Show("Alamat can't null !", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                chk = false;
            }
            else if (modelPembeli.telepon == null)
            {
                MessageBox.Show("Nomor telepon can't null !", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
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
                        telepon = sqlresult[3].ToString(),
                    });
                }
            }
            CloseConnection();
        }

        private async Task InsertDataAsync()
        {
            try
            {
                if (check())
                {
                    OpenConnection();
                    await Task.Delay(0);
                    var query = $"INSERT INTO Pembeli " +
                        $"VALUES('{modelPembeli.id_pembeli}','{modelPembeli.nama_pembeli}','{modelPembeli.alamat}','{modelPembeli.telepon}')";
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
                        $"nama_pembeli = '{modelPembeli.nama_pembeli}', " +
                        $"alamat = '{modelPembeli.alamat}', " +
                        $"Telepon = '{modelPembeli.telepon}' " +
                        $"WHERE id_pembeli = '{modelPembeli.id_pembeli}'";
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
                if (MessageBox.Show($"yakin ingin menghapus '{modelPembeli.id_pembeli}' ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    OpenConnection();
                    await Task.Delay(0);
                    var query = $"DELETE FROM Obat " +
                        $"WHERE id_pembeli = '{modelPembeli.id_pembeli}'";
                    //$"VALUES('{model.id_obat}','{model.nama_obat}','{model.khasiat}','{model.jumlah}','{model.harga_satuan}')";
                    var sqlcmd = new SQLiteCommand(query, Connection);

                    var sqlresult = sqlcmd.ExecuteNonQuery();
                    CloseConnection();
                    await ReadDataAsync();
                    MessageBox.Show("Sucessfully Deleted", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Hapus di batalkan", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (SQLiteException msg)
            {
                MessageBox.Show(msg.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
