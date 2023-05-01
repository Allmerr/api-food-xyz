using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_food_xyz.Models
{
    public class Barang
    {
        public int Id_Barang { set; get; }
        public string Kode_Barang { set; get; }
        public string Nama_Barang { set; get; }
        public DateTime Expired_Date { set; get; }
        public string Jumlah_Barang { set; get; }
        public string Satuan { set; get; }
        public string Harga_Satuan { set; get; }
    }
}