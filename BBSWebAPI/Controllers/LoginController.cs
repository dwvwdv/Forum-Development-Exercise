using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace BBSWebAPI.Controllers
{
    public class user
    {
        public int Name { get; set; }
        public string Passwd { get; set; }
    }

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string connString = @"Persist Security Info=False;Initial Catalog=AdventureWorks;server=LAPTOP-FOMVS4G2\MSSQLSERVER_2019;database=forum;User ID=sa;PassWord=123456;";

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.users",conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sda.Fill(ds);

            DataTable res = ds.Tables[0];
            DataRow dr = res.Rows[0];
            var user = new
            {
                username = dr["userName"].ToString(),
                password = dr["userPasswd"].ToString()
            };
            //var value = dr.ToString();
            
            

            conn.Close();

            return Ok(user);
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
