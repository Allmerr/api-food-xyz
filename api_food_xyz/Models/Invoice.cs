using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_food_xyz.Models
{
    public class Invoice
    {
        public string Nama_Barang { set; get; }
        public string Total_Barang_Dibeli { set; get; }
        public string Total_Bayar { set; get; }
        public string Subtotal { set; get; }

    }
}