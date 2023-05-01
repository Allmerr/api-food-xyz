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
    public class RegisterController : ApiController
    {
        private string connString = ConfigurationManager.AppSettings["connString"].ToString();

        // GET: Register
        public async Task<IHttpActionResult> GetResgister(string nama, string alamat, string telpon, string username, string password)
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

                /*var p = new DynamicParameters();

                p.Add("@tipe_user", "pembeli", DbType.String, ParameterDirection.Input);
                p.Add("@nama", nama, DbType.String, ParameterDirection.Input);
                p.Add("@alamat", alamat, DbType.String, ParameterDirection.Input);
                p.Add("@telpon", telpon, DbType.String, ParameterDirection.Input);
                p.Add("@username", username, DbType.String, ParameterDirection.Input);
                p.Add("@password", password, DbType.String, ParameterDirection.Input);

                result = await SqlMapper.QueryFirstOrDefaultAsync<User>(conn, "usp_insert_user", p, null, null, CommandType.StoredProcedure);*/

                SqlCommand cmd = new SqlCommand($"usp_insert_user 'pembeli', '{nama}', '{alamat}', '{telpon}', '{username}', '{password}'", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable result = new DataTable();
                sda.Fill(result);

                if (result.Rows[0]["msg"].ToString().Substring(0,7) == "success")
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