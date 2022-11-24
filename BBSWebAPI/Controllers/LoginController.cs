using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace BBSWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            string connString = "server=localhost;database=bbsdb;";
            SqlConnection conn = new SqlConnection(connString);
            //conn.Open();
            SqlCommand cmd = new SqlCommand("select * from users");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sda.Fill(ds);

            DataTable res = ds.Tables[0];
            DataRow dr = res.Rows[0];
            var value = dr["userNo"].ToString();

            return value;
        }
        [HttpPost]
        public string Insert(string user,string password)
        {
            return "dwv Post";
        }
        [HttpPut]
        public string Update()
        {
            return "dwv Put";
        }
        [HttpDelete]
        public string Remove()
        {
            return "dwv Del";
        }
    }
}
