using BBSWebAPI.Core;
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
        public string Get(string username,string password)
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataTable res = sqlHelper.ExecuteTable("select userName,userPasswd from users");
            DataRow dr = res.Rows[0];

            var user = new
            {
                username = dr["userName"].ToString(),
                password = dr["userPasswd"].ToString()
            };
            
            //return Ok(user);
            if(password == user.password && username == user.username)
            {
                return "login finish.";
            }
            else
            {
                return "login failed.";
            }
        }

        [HttpPost]
        public string Insert(string username,string password,string forumname)
        {
            string connString = @"Persist Security Info=False;Initial Catalog=AdventureWorks;server=LAPTOP-FOMVS4G2\MSSQLSERVER_2019;database=forum;User ID=sa;PassWord=123456;";
            using SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand($"insert into dbo.users(userName,userPasswd,userLastTime,forumName,forumMoney) values (@username,@password,'-',@forumname,0)",conn);
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password),
                new SqlParameter("@forumname", forumname)
            };

            cmd.Parameters.AddRange(sqlParameter);
            cmd.ExecuteNonQuery();

            return "dwv Post";
        }

        [HttpPut]
        public string Update(string newPassword,string userName)
        {
            string connString = @"Persist Security Info=False;Initial Catalog=AdventureWorks;server=LAPTOP-FOMVS4G2\MSSQLSERVER_2019;database=forum;User ID=sa;PassWord=123456;";
            using SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand($"update dbo.users set userPasswd = '{newPassword}' where userName = '{userName}'",conn);
            cmd.ExecuteNonQuery();

            return "dwv Put";
        }

        [HttpDelete]
        public string Remove(string userName)
        {
            //string connString = @"Persist Security Info=False;Initial Catalog=AdventureWorks;server=LAPTOP-FOMVS4G2\MSSQLSERVER_2019;database=forum;User ID=sa;PassWord=123456;";
            //using SqlConnection conn = new SqlConnection(connString);
            //conn.Open();
            //SqlCommand cmd = new SqlCommand($"delete from users where username = @userName;",conn);
            //SqlParameter sqlParameter = new SqlParameter("@userName", userName);

            //cmd.Parameters.Add(sqlParameter);
            //cmd.ExecuteNonQuery();

            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.ExecuteNonQuery("delete from users where userName = @userName",
                new SqlParameter("@userName", userName));
             
            return "dwv Del";
        }
    }
}
