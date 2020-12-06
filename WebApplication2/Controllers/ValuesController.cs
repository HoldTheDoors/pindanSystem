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
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            string mystr = ConfigurationManager.AppSettings["ConnStr"].ToString();
            MySqlConnection conn = new MySqlConnection(mystr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from book ", conn);
            MySqlDataAdapter myda = new MySqlDataAdapter(cmd);
            DataSet myds = new DataSet();
            myda.Fill(myds);
            if (myds.Tables[0].Rows.Count > 0)
                return "hello " + myds.Tables[0].Rows[0][0] + "'s room " + myds.Tables[0].Rows[0][1];
            return "0";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
