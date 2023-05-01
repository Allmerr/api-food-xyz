using api_food_xyz.helper;
using api_food_xyz.Models;
using Dapper;
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
    public class GetBarangLastTransaksiController : ApiController
    {
        private string connString = ConfigurationManager.AppSettings["connString"].ToString();

        // GET: Register
        public async Task<IHttpActionResult> GetTransaksi(string lastMany)
        {
            var status_code = 100;
            var message = "";
            IEnumerable<Invoice> result = new List<Invoice>() { };
            var conn = new SqlConnection(connString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                /*DataTable result = Config.query($"select top {lastMany} tb.nama_barang as 'nama_barang', tt.total_barangDibeli as 'total_barang_dibeli', tt.total_bayar as 'total_bayar', (CAST( tt.total_barangDibeli as INT) * CAST( tt.total_bayar as INT)) as 'subtotal'  from tbl_transaksi tt left join tbl_barang tb ON tt.id_barang = tb.id_barang ORDER BY id_transaksi desc");*/

                var p = new DynamicParameters();
                p.Add("@lastMany", lastMany, DbType.String, ParameterDirection.Input);

                result = await SqlMapper.QueryAsync<Invoice>(conn, "usp_get_barang_from_transaksi", p, null, null, CommandType.StoredProcedure);

                if (result != null)
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

            return Json(new { status_code = status_code, message = message, data = result });
        }
    }
}