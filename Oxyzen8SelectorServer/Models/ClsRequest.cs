using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxyzen8SelectorServer.Models
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
        public string jobId { get; set; }
        public string createdUserId { get; set; }
        public string revisedUserId { get; set; }
        public string jobName { get; set; }
        public string referenceNo { get; set; }
        public string revisionNo { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string companyNameId { get; set; }
        public string contactNameId { get; set; }
        public string applicationId { get; set; }
        public string applicationOther { get; set; }
        public string basisOfDesignId { get; set; }
        public string UOMId { get; set; }
        public string country{ get; set; }
        public string provState{ get; set; }
        public string cityId{ get; set; }
        public string designConditionId { get; set; }
        public string altitude { get; set; }
        public string summerOutdoorAirDB { get; set; }
        public string summerOutdoorAirWB { get; set; }
        public string summerOutdoorAirRH { get; set; }
        public string winterOutdoorAirDB { get; set; }
        public string winterOutdoorAirWB { get; set; }
        public string winterOutdoorAirRH { get; set; }
        public string summerReturnAirDB { get; set; }
        public string summerReturnAirWB { get; set; }
        public string summerReturnAirRH { get; set; }
        public string winterReturnAirDB { get; set; }
        public string winterReturnAirWB { get; set; }
        public string winterReturnAirRH { get; set; }
        public string createdDate { get; set; }
        public string revisedDate { get; set; }
        public string isTestNewPrice { get; set; }
    }
}