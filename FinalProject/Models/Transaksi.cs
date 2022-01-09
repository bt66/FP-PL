using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Transaksi
    {
        public string id_transaksi { get; set; }
        public string id_pembeli { get; set; }
        public string id_obat { get; set; }
        public string jumlah { get; set; }
        public string total_harga { get; set; }
    }
}
