using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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
            return ClsDB.GetSavedJob();
        }

        public static dynamic GetInitialJobInfo()
        {
            dynamic jobInfo = new ExpandoObject();

            jobInfo.createdDate = DateTime.Now.ToString("yyyy-MM-dd");
            jobInfo.revisedDate = DateTime.Now.ToString("yyyy-MM-dd");
            jobInfo.baseOfDesign = ClsDB.get_dtLive(ClsDBT.strSelBasisOfDesign);
            jobInfo.UoM = ClsDB.get_dtLive(ClsDBT.strSelUOM);
            jobInfo.applications = ClsDB.get_dtLive(ClsDBT.strSelGeneralApplication);
            jobInfo.country = ClsDB.get_dtLive(ClsDBT.strSelCountry);
            jobInfo.provState = ClsDB.get_dtByQuery("SELECT * FROM `" + ClsDBT.strSelWeatherData + "` GROUP BY `prov_state` ORDER BY `prov_state`");
            jobInfo.weatherData = ClsDB.get_dtLive(ClsDBT.strSelWeatherData);
            jobInfo.designCondition = ClsDB.get_dtLive(ClsDBT.strSelWeatherDesignConditions);
            jobInfo.companyInfo = ClsDB.get_dtLive(ClsDBT.strSavCustomer);
            jobInfo.usersInfo = ClsDB.get_dtLive(ClsDBT.strSavUsers);

            return jobInfo;
        }

        public static dynamic GetAllOutdoorInfo(string country, int cityId, int designCondition)
        {
            dynamic returnInfo = new ExpandoObject();
            DataTable dt = ClsDB.get_dtLive(ClsDBT.strSelWeatherData, cityId);

            if (dt.Rows.Count > 0)
            {
                returnInfo.altitude = dt.Rows[0]["elevation_foot"].ToString();
                if (designCondition == ClsID.intDesignDataCooling_010_Heating_990_ID)
                {
                    returnInfo.summerOutdoorAirDB = Math.Round(ClsFormula.get_dblFarenheit(Convert.ToDouble(dt.Rows[0]["cooling_db010"])), 1).ToString();
                    returnInfo.summerOutdoorAirWB = Math.Round(ClsFormula.get_dblFarenheit(Convert.ToDouble(dt.Rows[0]["cooling_wb_db010"])), 1).ToString();
                    returnInfo.winterOutdoorAirDB = Math.Round(ClsFormula.get_dblFarenheit(Convert.ToDouble(dt.Rows[0]["heating_db990"])), 1).ToString();
                }
                else if (designCondition == ClsID.intDesignDataCooling_004_Heating_996_ID)
                {
                    returnInfo.summerOutdoorAirDB = Math.Round(ClsFormula.get_dblFarenheit(Convert.ToDouble(dt.Rows[0]["cooling_db004"])), 1).ToString();
                    returnInfo.summerOutdoorAirWB = Math.Round(ClsFormula.get_dblFarenheit(Convert.ToDouble(dt.Rows[0]["cooling_wb_db004"])), 1).ToString();
                    returnInfo.winterOutdoorAirDB = Math.Round(ClsFormula.get_dblFarenheit(Convert.ToDouble(dt.Rows[0]["heating_db996"])), 1).ToString();
                }

                if (country == "CAN")
                {
                    returnInfo.winterOutdoorAirWB = Math.Round((Convert.ToDouble(returnInfo.winterOutdoorAirDB) - 2d), 2).ToString();
                }
                else
                {
                    returnInfo.winterOutdoorAirWB = Math.Round(Convert.ToDouble(returnInfo.winterOutdoorAirDB) - 0.1d, 2).ToString();
                }

                returnInfo.summerOutdoorAirRH = GetRH_By_DB_WB(new { first = returnInfo.summerOutdoorAirDB, second = returnInfo.summerOutdoorAirWB, altitude = returnInfo.altitude });
                returnInfo.winterOutdoorAirRH = GetRH_By_DB_WB(new { first = returnInfo.winterOutdoorAirDB, second= returnInfo.winterOutdoorAirWB, altitude = returnInfo.altitude });

                return returnInfo;
            }
            return returnInfo;
        }
        public static float GetRH_By_DB_WB(dynamic info)
        {
            if (ClsNumber.IsNumber(info.first.ToString()) && ClsNumber.IsNumber(info.second.ToString()) && ClsNumber.IsNumber(info.altitude.ToString()))
            {
                float first = (float)Convert.ToDouble(info.first);
                float second = (float)Convert.ToDouble(info.second);
                if (first < -40f)
                {
                    first = -40.0f;
                }

                if (second < -40.5f)
                {
                    second = -40.5f;
                }
                return (float)Math.Round(ClsPsyCalc.get_fltRH_ByDB_WB((float)Convert.ToDouble(info.first), (float)Convert.ToDouble(info.second), Convert.ToInt32(info.altitude)), 1);
            }
            return 0;
        }

        public static float GetWB_By_DB_RH(dynamic info)
        {
            if (ClsNumber.IsNumber(info.first.ToString()) && ClsNumber.IsNumber(info.second.ToString()) && ClsNumber.IsNumber(info.altitude.ToString()))
            {
                return (float)Math.Round(ClsPsyCalc.get_fltWB_ByDB_RH((float)Convert.ToDouble(info.first), (float)Convert.ToDouble(info.second), Convert.ToInt32(info.altitude)), 1);
            }

            return 0;
        }

        public static dynamic GetUserPerCompany(dynamic info)
        {
            DataTable dtUserPerRep = ClsDB.GetUserPerCustomer(Convert.ToInt32(info.companyNameId));
            return dtUserPerRep;
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
        
        public static DataTable UpdateJob(dynamic jobInfo)
        {
            return ClsDB.SaveJob(Convert.ToInt32(jobInfo.jobId),
                                Convert.ToInt32(jobInfo.createdUserId),
                                Convert.ToInt32(jobInfo.revisedUserId),
                                jobInfo.jobName.ToString(),
                                jobInfo.referenceNo.ToString(),
                                Convert.ToInt32(jobInfo.revision),
                                jobInfo.companyName.ToString(),
                                jobInfo.contactName.ToString(),
                                Convert.ToInt32(jobInfo.companyNameId),
                                Convert.ToInt32(jobInfo.contactNameId),
                                Convert.ToInt32(jobInfo.application),
                                jobInfo.applicationOther.ToString(),
                                Convert.ToInt32(jobInfo.basisOfDesign),
                                Convert.ToInt32(jobInfo.uom),
                                jobInfo.country.ToString(),
                                jobInfo.state.ToString(),
                                Convert.ToInt32(jobInfo.city),
                                Convert.ToInt32(jobInfo.ashareDesignConditions),
                                Convert.ToInt32(jobInfo.altitude),
                                Math.Round(Convert.ToDouble(jobInfo.summer_air_db), 1),
                                Math.Round(Convert.ToDouble(jobInfo.summer_air_wb), 1),
                                Math.Round(Convert.ToDouble(jobInfo.summer_air_rh), 1),
                                Math.Round(Convert.ToDouble(jobInfo.winter_air_db), 1),
                                Math.Round(Convert.ToDouble(jobInfo.winter_air_wb), 3),
                                Math.Round(Convert.ToDouble(jobInfo.winter_air_rh), 1),
                                Math.Round(Convert.ToDouble(jobInfo.summer_return_db), 1),
                                Math.Round(Convert.ToDouble(jobInfo.summer_return_wb), 1),
                                Math.Round(Convert.ToDouble(jobInfo.summer_return_rh), 1),
                                Math.Round(Convert.ToDouble(jobInfo.winter_return_db), 1),
                                Math.Round(Convert.ToDouble(jobInfo.winter_return_wb), 3),
                                Math.Round(Convert.ToDouble(jobInfo.winter_return_rh), 1),
                                jobInfo.createdDate.ToString(),
                                jobInfo.revisedDate.ToString(),
                                Convert.ToInt32(jobInfo.testNewPrice));
        }
    }
}