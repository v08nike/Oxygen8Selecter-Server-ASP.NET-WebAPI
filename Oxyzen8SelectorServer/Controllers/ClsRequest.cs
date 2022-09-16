using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxyzen8SelectorServer.Controllers
{
    public class ClsLoginParams
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class ClsGetJobsParams
    {
        public int userId { get; set; }
        public string action { get; set; }
    }

    public class ClsGetUnitsParams
    {
        public int jobId { get; set; }
    }

    public class ClsSaveJobParams
    {
        public int jobId { get; set; }
        public int createdUserId { get; set; }
        public int revisedUserId { get; set; }
        public string jobName { get; set; }
        public string referenceNo { get; set; }
        public int revisionNo { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public int companyNameId { get; set; }
        public int contactNameId { get; set; }
        public int applicationId { get; set; }
        public int applicationOther { get; set; }
        public int basisOfDesignId { get; set; }
        public int UOBId { get; set; }
        public string country{ get; set; }
        public string provState{ get; set; }
        public int cityId{ get; set; }
        public int designConditionId { get; set; }
        public int altitude { get; set; }
        public double summerOutdoorAirDB { get; set; }
        public double summerOutdoorAirWB { get; set; }
        public double summerOutdoorAirRH { get; set; }
        public double winterOutdoorAirDB { get; set; }
        public double winterOutdoorAirWB { get; set; }
        public double winterOutdoorAirRH { get; set; }
        public double summerReturnAirDB { get; set; }
        public double summerReturnAirWB { get; set; }
        public double summerReturnAirRH { get; set; }
        public double winterReturnAirDB { get; set; }
        public double winterReturnAirWB { get; set; }
        public double winterReturnAirRH { get; set; }
        public string createdDate { get; set; }
        public string revisedDate { get; set; }
        public int isTesNewPrice { get; set; }
    }
}