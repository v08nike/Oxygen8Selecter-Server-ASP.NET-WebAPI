using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace Oxygen8SelectorServer.Models
{
    public class AuthModel
    {
        public AuthModel()
        {
        }

        public static DataTable GetUserByEmail(string email)
        {
            DataTable dt = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSavUsers + " WHERE email = '" + email + "'");
            return dt;
        }

        public static DataTable GetUserByUsername(string username)
        {
            DataTable dt = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSavUsers + " WHERE username = '" + username + "'");
            return dt;
        }

        public static DataTable GetUserByID(int id)
        {
            DataTable dt = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSavUsers + " WHERE email = '" + id + "'");
            return dt;
        }
    }
}