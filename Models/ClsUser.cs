using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxygen8SelectorServer.Models
{
    public class ClsUser
    {
        //private int intID = 0;
        //private string strUsername = "";
        //private string strFirstName = "";
        //private string strLastName = "";
        //private int intAccess = 0;
        //private int intAccessLevel = 0;
        //private int intAccessPricing = 0;


        public ClsUser()
        {
        }


        public ClsUser(int _intID)
        {

            intID = _intID;
            DataTable dtUser = ClsDB.get_dtByID(ClsDBT.strSavUsers, intID);
            strUsername = dtUser.Rows[0]["username"].ToString();
            strFirstName = dtUser.Rows[0]["first_name"].ToString();
            strLastName = dtUser.Rows[0]["last_name"].ToString();
            intRepID = Convert.ToInt32(dtUser.Rows[0]["customer_id"]);
            intAccess = Convert.ToInt32(dtUser.Rows[0]["access"]);
            intUAL = Convert.ToInt32(dtUser.Rows[0]["access_level"]);
            intAccessPricing = Convert.ToInt32(dtUser.Rows[0]["access_pricing"]);
        }


        public int intID { get; set; }
        public string strUsername { get; set; }
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        public int intRepID { get; set; }
        public int intAccess { get; set; }
        public int intUAL { get; set; }
        public int intAccessPricing { get; set; }
    }
}