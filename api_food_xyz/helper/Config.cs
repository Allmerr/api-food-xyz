using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api_food_xyz.helper
{
    public class Config
    {
        public static DataTable query(string perintah)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-5U91FSN;Initial Catalog=food_xyz;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand(perintah,conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }
    }
}