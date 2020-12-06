using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
namespace WebApplication2.Controllers
{
    public class roomController : ApiController
    {
        // GET api/room
        [HttpGet]
        public IEnumerable<string> Get(int id, string name)
        {
            return new string[] { "newroom", name + "'s room" + id.ToString() };
        }

        // GET api/room/5
        public string Get(int id)
        {
            return "room" + id.ToString();
        }
        [HttpPost]
        public string Post(dynamic q)
        {
            int value1 = Convert.ToInt32(q.value1);
            string value2 = Convert.ToString(q.value2);
            string mystr = ConfigurationManager.AppSettings["ConnStr"].ToString();
            MySqlConnection conn = new MySqlConnection(mystr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from room where ID='" + value1.ToString() + "'"+" and name='"+value2+"'", conn);
            MySqlDataAdapter myda = new MySqlDataAdapter(cmd);
            DataSet myds = new DataSet();
            myda.Fill(myds);
            if (myds.Tables[0].Rows.Count > 0)
                return "hello " + value2 + "'s room " + value1;
            else
                return "no such room";
        }
    }
}
