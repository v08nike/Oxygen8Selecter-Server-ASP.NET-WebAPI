using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using Oxyzen8SelectorServer.Models;

namespace Oxyzen8SelectorServer.Controllers
{
    public class AuthController : ApiController
    {

        [HttpPost]
        [ActionName("Login")]
        // POST api/auth/login
        public ClsReturn Login([FromBody]ClsLoginParams info)
        {
            DataTable dt = AuthModel.GetUserByEmail(info.email);
            ClsReturn returnLoginInfo = new ClsReturn();

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["access"]) == 1)
                {
                    if (CalculateMD5Hash(info.password).ToUpper() == dt.Rows[0]["password"].ToString().ToUpper())
                    {
                        returnLoginInfo.action = "success";
                        returnLoginInfo.data = dt;
                        return returnLoginInfo;
                    } else
                    {
                        returnLoginInfo.action = "incorrect_password";
                        return returnLoginInfo;
                    }
                } else
                {
                    returnLoginInfo.action = "no_user_access";
                    return returnLoginInfo;
                }
            } else
            {
                returnLoginInfo.action = "no_user_exist";
                return returnLoginInfo;
            }
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    }
}