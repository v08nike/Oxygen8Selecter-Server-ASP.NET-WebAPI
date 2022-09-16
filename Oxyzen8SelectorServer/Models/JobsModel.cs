using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Oxyzen8SelectorServer.Models
{
    public class JobsModel
    {
        public static DataTable getJobListByCreatedUserId(int createdUserId)
        {
            return ClsDB.get_dtLive(ClsDBT.strSavJob, " WHERE created_user_id = '" + createdUserId + "' ORDER BY id DESC");
        }

        public static DataTable getJobListByOthers(int createdUserId)
        {
            return ClsDB.get_dtLive(ClsDBT.strSavJob, " WHERE NOT created_user_id = '" + createdUserId + "' ORDER BY id DESC");
        }

        public static DataTable GetJobList()
        {
            return ClsDB.get_dtLive(ClsDBT.strSavJob, " ORDER BY id DESC");
        }

    }
}