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
    public class allroomController : ApiController
    {
        // GET: api/allroom
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/allroom/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/allroom
        public DataSet Post()
        {
            string mystr = ConfigurationManager.AppSettings["ConnStr"].ToString();
            MySqlConnection conn = new MySqlConnection(mystr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from room ", conn);
            MySqlDataAdapter myda = new MySqlDataAdapter(cmd);
            DataSet myds = new DataSet();
            myda.Fill(myds);
            return myds;
        }

        // PUT: api/allroom/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/allroom/5
        public void Delete(int id)
        {
        }
    }
}
