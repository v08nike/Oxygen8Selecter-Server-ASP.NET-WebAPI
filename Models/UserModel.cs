using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxyzen8SelectorServer.Models
{
    public class UserModel
    {
        public static string UpdatePassword(dynamic userInfo)
        {
            int userId = Convert.ToInt32(userInfo.userId);
            string currentPassword = userInfo.currentPassword.ToString();
            string updatedPassword = userInfo.updatedPassword.ToString();

            DataTable dt = ClsDB.GetUser(userId);

            if (ClsGo.CalculateMD5Hash(currentPassword).ToUpper() != dt.Rows[0]["password"].ToString().ToUpper())
            {
                return "incorrect_current_password";
            }

            DataTable dtUpdate = ClsDB.UpdateUserPassword(userId, ClsGo.CalculateMD5Hash(updatedPassword));

            return "success";
        }

        public static bool SaveSetPasswrodRequestInfo(string email, int info)
        {
            ClsDB.ExecuteSQL("UPDATE `" + ClsDBT.strSavUsers + "` SET `request_reset_password`= " + info.ToString() + " WHERE email='" + email + "' ");
            return true;
        }
    }
}