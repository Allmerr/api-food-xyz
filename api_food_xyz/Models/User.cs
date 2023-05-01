using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_food_xyz.Models
{
    public class User
    {
        public int Id_User { get; set; }
        public string Tipe_User { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Telpon { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}