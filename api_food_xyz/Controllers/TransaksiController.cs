using api_food_xyz.helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api_food_xyz.Controllers
{
    public class TransaksiController : ApiController
    {
        private string connString = ConfigurationManager.AppSettings["connString"].ToString();

        // GET: Register
        public async Task<IHttpActionResult> GetTransaksi(string totalBarangDibeli,string totalBayar,string idUser, string idBarang)
        {
            var status_code = 100;
            var message = "";
            /*var result = new User { };*/
            var conn = new SqlConnection(connString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                DataTable result = Config.query($"usp_insert_transaksi '{DateTime.Now.Date.ToString("yyyyMMddhhmmss")}', '{DateTime.Now.Date.ToString("yyyy-MM-dd")}', '{totalBarangDibeli}', '{totalBayar}', '{idUser}', '{idBarang}'");

                if (result.Rows[0]["msg"].ToString().Substring(0, 7) == "success")
                {
                    status_code = 200;
                    message = "success";
                }
                else
                {
                    status_code = 100;
                    message = $"failed | Data tidak Ditemukan! ";
                }


            }
            catch (Exception ex)
            {
                status_code = 500;
                message = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
            }

            return Json(new { status_code = status_code, message = message });
        }
    }
}