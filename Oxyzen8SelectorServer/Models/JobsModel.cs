using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Oxyzen8SelectorServer.Models
{
    public class JobsModel
    {
        public static bool DeleteProjectByJobId(int jobId)
        {
            return ClsDB.DeleteProject(jobId);
        }

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

        public static ClsInitailJobInfoReturn GetInitialJobInfo()
        {
            ClsInitailJobInfoReturn jobInfo = new ClsInitailJobInfoReturn();

            jobInfo.createdDate = DateTime.Now.ToString("yyyy-MM-dd");
            jobInfo.revisedDate = DateTime.Now.ToString("yyyy-MM-dd");
            jobInfo.baseOfDesign = ClsDB.get_dtLive(ClsDBT.strSelBasisOfDesign);
            jobInfo.UoM = ClsDB.get_dtLive(ClsDBT.strSelUOM);
            jobInfo.country = ClsDB.get_dtLive(ClsDBT.strSelCountry);
            jobInfo.designCondition = ClsDB.get_dtLive(ClsDBT.strSelWeatherDesignConditions);
            jobInfo.companyInfo = ClsDB.get_dtLive(ClsDBT.strSavCustomer);

            return jobInfo;
        }

        public static ClsJobInfoReturn GetJobInfoByJobId(int jobId)
        {
            ClsJobInfoReturn jobInfo = new ClsJobInfoReturn();
            ClsProjectInfo objJobInfo = new ClsProjectInfo(Convert.ToInt32(jobId));

            jobInfo.jobId = jobId.ToString();
            jobInfo.createdUserId = objJobInfo.intCreatedUserID.ToString();
            jobInfo.revisedUserId = objJobInfo.intRevisedUserID.ToString();
            jobInfo.jobName = objJobInfo.strJobName;
            jobInfo.referenceNo = objJobInfo.strReferenceNo;
            jobInfo.revisionNo = objJobInfo.intRevisionNo.ToString();
            jobInfo.companyName = objJobInfo.strCompanyName;
            jobInfo.contactName = objJobInfo.strContactName;
            jobInfo.companyNameId = objJobInfo.intCompanyNameID.ToString();
            jobInfo.contactNameId = objJobInfo.intContactNameID.ToString();
            jobInfo.applicationId = objJobInfo.intApplicationID.ToString();
            jobInfo.applicationOther = objJobInfo.strApplicationOther;
            jobInfo.basisOfDesignId = objJobInfo.intBasisOfDesignID.ToString();
            jobInfo.UOMId = objJobInfo.intUoM_ID.ToString();
            jobInfo.country = objJobInfo.strCountry;
            jobInfo.provState = objJobInfo.strProvState;
            jobInfo.cityId = objJobInfo.intCityID.ToString();
            jobInfo.designConditionId = objJobInfo.intDesignConditionsID.ToString();
            jobInfo.designConditionId = objJobInfo.intDesignConditionsID.ToString();
            jobInfo.altitude = objJobInfo.intAltitude.ToString();
            jobInfo.summerOutdoorAirDB = objJobInfo.dblSummerOutdoorAirDB.ToString();
            jobInfo.summerOutdoorAirWB = objJobInfo.dblSummerOutdoorAirWB.ToString();
            jobInfo.summerOutdoorAirRH = objJobInfo.dblSummerOutdoorAirRH.ToString();
            jobInfo.winterOutdoorAirDB = objJobInfo.dblWinterOutdoorAirDB.ToString();
            jobInfo.winterOutdoorAirWB = objJobInfo.dblWinterOutdoorAirWB.ToString();
            jobInfo.winterOutdoorAirRH = objJobInfo.dblWinterOutdoorAirRH.ToString();
            jobInfo.summerReturnAirDB = objJobInfo.dblSummerReturnAirDB.ToString();
            jobInfo.summerReturnAirWB = objJobInfo.dblSummerReturnAirWB.ToString();
            jobInfo.summerReturnAirRH = objJobInfo.dblSummerReturnAirRH.ToString();
            jobInfo.winterReturnAirDB = objJobInfo.dblWinterReturnAirDB.ToString();
            jobInfo.winterReturnAirWB = objJobInfo.dblWinterReturnAirWB.ToString();
            jobInfo.winterReturnAirRH = objJobInfo.dblWinterReturnAirRH.ToString();
            jobInfo.createdDate = objJobInfo.strCreatedDate;
            jobInfo.revisedDate = objJobInfo.strRevisedDate;
            jobInfo.isTestNewPrice = objJobInfo.intIsTestNewPrice.ToString();

            return jobInfo;
        }
        
        public static DataTable UpdateJob(ClsSaveJobParams jobInfo)
        {
            return ClsDB.SaveJob(Convert.ToInt32(jobInfo.jobId),
                                Convert.ToInt32(jobInfo.createdUserId),
                                Convert.ToInt32(jobInfo.revisedUserId),
                                jobInfo.jobName,
                                jobInfo.referenceNo,
                                Convert.ToInt32(jobInfo.revisionNo),
                                jobInfo.companyName,
                                jobInfo.contactName,
                                Convert.ToInt32(jobInfo.companyNameId),
                                Convert.ToInt32(jobInfo.contactNameId),
                                Convert.ToInt32(jobInfo.applicationId),
                                jobInfo.applicationOther,
                                Convert.ToInt32(jobInfo.basisOfDesignId),
                                Convert.ToInt32(jobInfo.UOMId),
                                jobInfo.country,
                                jobInfo.provState,
                                Convert.ToInt32(jobInfo.cityId),
                                Convert.ToInt32(jobInfo.designConditionId),
                                Convert.ToInt32(jobInfo.altitude),
                                Math.Round(Convert.ToDouble(jobInfo.summerOutdoorAirDB), 1),
                                Math.Round(Convert.ToDouble(jobInfo.summerOutdoorAirWB), 1),
                                Math.Round(Convert.ToDouble(jobInfo.summerOutdoorAirRH), 1),
                                Math.Round(Convert.ToDouble(jobInfo.winterOutdoorAirDB), 1),
                                Math.Round(Convert.ToDouble(jobInfo.winterOutdoorAirWB), 3),
                                Math.Round(Convert.ToDouble(jobInfo.winterOutdoorAirRH), 1),
                                Math.Round(Convert.ToDouble(jobInfo.summerReturnAirDB), 1),
                                Math.Round(Convert.ToDouble(jobInfo.summerReturnAirWB), 1),
                                Math.Round(Convert.ToDouble(jobInfo.summerReturnAirRH), 1),
                                Math.Round(Convert.ToDouble(jobInfo.winterReturnAirDB), 1),
                                Math.Round(Convert.ToDouble(jobInfo.winterReturnAirWB), 3),
                                Math.Round(Convert.ToDouble(jobInfo.winterReturnAirRH), 1),
                                jobInfo.createdDate,
                                jobInfo.revisedDate,
                                Convert.ToInt32(jobInfo.isTestNewPrice));
        }
    }
}