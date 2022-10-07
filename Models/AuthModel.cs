using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace Oxyzen8SelectorServer.Models
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

        public static bool SaveSetPasswrodRequestInfo(string email, int info)
        {
            ClsDB.ExecuteSQL("UPDATE `" + ClsDBT.strSavUsers + "` SET `request_reset_password`= " + info.ToString() + " WHERE `email`=" +  email + " ");
            return true;
        }
    }
}