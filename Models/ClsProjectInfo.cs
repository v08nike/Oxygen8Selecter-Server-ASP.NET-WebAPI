using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxygen8SelectorServer.Models
{
    public class ClsProjectInfo
    {
        //private int intJobID = 0;
        //private int intCreatedUserID = 0;
        //private int intRevisedUserID = 0;
        //private string strJobName = "";
        //private string strReferenceNo = "";
        //private int intRevisionNo = 0;
        //private string strCompanyName = "";
        //private string strContactName = "";
        //private int intBasisOfDesignID = 0;
        //private int intApplicationID = 0;
        //private int intUoM_ID = 0;

        //private int intRepresentativeID = 0;
        //private string strRepName = "";
        private string strUserFullName = "";
        //private string strRepStreetAddress = "";
        //private string strRepCity = "";
        //private string strRepState = "";
        //private string strRepPostalCode = "";
        //private string strRepCountry = "";

        //private string strBasisOfDesign = "";
        //private string strApplication = "";
        //private string strApplicationOther = "";
        //private string strCountry = "";
        //private string strProvState = "";
        //private int intCityID = 0;
        //private int intHeatingDesignPercentID = 0;
        //private int intDesignConditionsID = 0;
        //private int intAltitude = 0;
        //private double dblDensity_lbPerCu_ft = 0d;
        //private double dblPressure_PSI = 0d;
        //private double dblPressure_inHg = 0d;

        //private double dblSummerOutdoorAirDB = 0d;
        //private double dblSummerOutdoorAirWB = 0d;
        //private double dblSummerOutdoorAirRH = 0d;
        //private double dblSummerOutdoorAirEnthalpy = 0d;
        //private double dblSummerOutdoorAirGrains = 0d;
        //private double dblWinterOutdoorAirDB = 0d;
        //private double dblWinterOutdoorAirWB = 0d;
        //private double dblWinterOutdoorAirRH = 0d;
        //private double dblWinterOutdoorAirEnthalpy = 0d;
        //private double dblWinterOutdoorAirGrains = 0d;
        //private double dblSummerReturnAirDB = 0d;
        //private double dblSummerReturnAirWB = 0d;
        //private double dblSummerReturnAirRH = 0d;
        //private double dblSummerReturnAirEnthalpy = 0d;
        //private double dblSummerReturnAirGrains = 0d;
        //private double dblWinterReturnAirDB = 0d;
        //private double dblWinterReturnAirWB = 0d;
        //private double dblWinterReturnAirRH = 0d;
        //private double dblWinterReturnAirEnthalpy = 0d;
        //private double dblWinterReturnAirGrains = 0d;
        //private string strCreatedDate = "";
        //private string strRevisedDate = "";

        //private string strUsername = "";
        //private string strJobStatus = "";

        public ClsProjectInfo()
        {
        }

        //public ClsJobInfo(int _intID,
        //                        int _intUserID,
        //                        string _strJobName,
        //                        string _strReferenceNo,
        //                        int _intRevisionNo,
        //                        string _strDateModified,
        //                        string _strDateCreated)
        //{
        //    intJobID = _intID;
        //    intCreatedUserID = _intUserID;
        //    strJobName = _strJobName;
        //    strReferenceNo = _strReferenceNo;
        //    intRevisionNo = _intRevisionNo;
        //    strCreatedDate = _strDateCreated;
        //    strRevisedDate = _strDateModified;

        //    //SaveJobInfo();
        //}


        //Constructor for Saved
        #region Load JobInfo
        public ClsProjectInfo(int _intJobID)
        {
            intJobID = _intJobID;

            DataTable dt = ClsDB.GetSavedJob(intJobID);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                intJobID = Convert.ToInt32(dr["id"]);
                intCreatedUserID = Convert.ToInt32(dr["created_user_id"]);
                intRevisedUserID = Convert.ToInt32(dr["revised_user_id"]);
                strJobName = dr["job_name"].ToString();
                strReferenceNo = dr["reference_no"].ToString();
                intRevisionNo = Convert.ToInt32(dr["revision_no"]);
                strCompanyName = dr["company_name"].ToString();
                strContactName = dr["contact_name"].ToString();
                intCompanyNameID = Convert.ToInt32(dr["company_name_id"]);
                intContactNameID = Convert.ToInt32(dr["contact_name_id"]);
                intApplicationID = Convert.ToInt32(dr["application_id"]);
                strApplicationOther = dr["application_other"].ToString();
                intUoM_ID = Convert.ToInt32(dt.Rows[0]["uom_id"]);
                strCountry = dt.Rows[0]["country"].ToString();
                strProvState = dt.Rows[0]["prov_state"].ToString();
                intCityID = Convert.ToInt32(dt.Rows[0]["city_id"]);
                intDesignConditionsID = Convert.ToInt32(dt.Rows[0]["design_conditions_id"]);
                intBasisOfDesignID = Convert.ToInt32(dt.Rows[0]["basis_of_design_id"]);

                intAltitude = Convert.ToInt32(dt.Rows[0]["altitude"]);
                dblSummerOutdoorAirDB = Convert.ToDouble(dt.Rows[0]["summer_outdoor_air_db"]);
                dblSummerOutdoorAirWB = Convert.ToDouble(dt.Rows[0]["summer_outdoor_air_wb"]);
                dblSummerOutdoorAirRH = Convert.ToDouble(dt.Rows[0]["summer_outdoor_air_rh"]);
                dblWinterOutdoorAirDB = Convert.ToDouble(dt.Rows[0]["winter_outdoor_air_db"]);
                dblWinterOutdoorAirWB = Convert.ToDouble(dt.Rows[0]["winter_outdoor_air_wb"]);
                dblWinterOutdoorAirRH = Convert.ToDouble(dt.Rows[0]["winter_outdoor_air_rh"]);
                dblSummerReturnAirDB = Convert.ToDouble(dt.Rows[0]["summer_return_air_db"]);
                dblSummerReturnAirWB = Convert.ToDouble(dt.Rows[0]["summer_return_air_wb"]);
                dblSummerReturnAirRH = Convert.ToDouble(dt.Rows[0]["summer_return_air_rh"]);
                dblWinterReturnAirDB = Convert.ToDouble(dt.Rows[0]["winter_return_air_db"]);
                dblWinterReturnAirWB = Convert.ToDouble(dt.Rows[0]["winter_return_air_wb"]);
                dblWinterReturnAirRH = Convert.ToDouble(dt.Rows[0]["winter_return_air_rh"]);
                strCreatedDate = dr["created_date"].ToString();
                strRevisedDate = dr["revised_date"].ToString();
                intIsTestNewPrice = Convert.ToInt32(dr["is_test_new_price"]);

                strRepName = dt.Rows[0]["Customer_Name"].ToString();
                strUserFullName = dt.Rows[0]["User_Full_Name"].ToString();

                DataTable dtCompanyName = ClsDB.get_dtByID(ClsDBT.strSavCustomer, intCompanyNameID);
                DataTable dtContactName = ClsDB.GetUser(intContactNameID);
                strCompanyNameNew = dtCompanyName.Rows.Count > 0 ? dtCompanyName.Rows[0]["name"].ToString() : "";
                strContactNameNew = dtCompanyName.Rows.Count > 0 && intContactNameID != 0 ? dtContactName.Rows[0]["User_Full_name"].ToString() : "";

                CalculateAirProperty();
                //strApplication = ClsDBM.SelectById(ClsDBT.strSelGeneralApplication, intApplicationID).Rows[0]["items"].ToString(); ;

            }
        }
        #endregion




        //#region Save Job
        //public void SaveJobInfo()
        //{
        //    DataTable dt = new DataTable(ClsDBT.strSavJob);
        //    dt.Columns.Add("id", typeof(int));
        //    dt.Columns.Add("user_id", typeof(int));
        //    dt.Columns.Add("job_name", typeof(string));
        //    dt.Columns.Add("reference_no", typeof(string));
        //    dt.Columns.Add("revision_no", typeof(int));
        //    dt.Columns.Add("date_modified", typeof(string));
        //    dt.Columns.Add("date_created", typeof(string));

        //    DataRow dr = dt.NewRow();
        //    dr["id"]= intJobID;
        //    dr["user_id"] = intUserID;
        //    dr["job_name"] = strJobName;
        //    dr["reference_no"] = strReferenceNo;
        //    dr["revision_no"] = intRevisionNo;
        //    dr["date_modified"] = DateTime.Now.ToString("yyyy-MM-dd");
        //    dr["date_created"] = strDateCreated;
        //    dt.Rows.Add(dr);

        //    ClsDBM.SaveById(dt, intJobID);
        //}
        //#endregion


        #region Calculate Air Property
        public void CalculateAirProperty()
        {
            DataTable dtAltitude = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSelAltitude + " WHERE altitude = " + intAltitude.ToString());

            if ((dtAltitude != null) && (dtAltitude.Rows.Count > 0))
            {
                dblDensity_lbPerCu_ft = Convert.ToDouble(dtAltitude.Rows[0]["density_lb_per_cu_ft"]);
                dblPressure_PSI = Convert.ToDouble(dtAltitude.Rows[0]["atm_pressure_psi"]);
            }
            else
            {
                DataTable dtAltitudeAbove = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSelAltitude + " WHERE altitude > '" + intAltitude.ToString() + "' ORDER BY altitude ASC");
                DataTable dtAltitudeBelow = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSelAltitude + " WHERE altitude < '" + intAltitude.ToString() + "' ORDER BY altitude DESC");

                if ((dtAltitudeBelow != null) && (dtAltitudeBelow.Rows.Count > 0) && (dtAltitudeAbove != null) && (dtAltitudeAbove.Rows.Count > 0))
                {
                    double dblAltitudeBelow = Convert.ToDouble(dtAltitudeBelow.Rows[0]["altitude"]);
                    double dblAltitudeAbove = Convert.ToDouble(dtAltitudeAbove.Rows[0]["altitude"]);

                    double dblAtmPressureBelow = Convert.ToDouble(dtAltitudeBelow.Rows[0]["atm_pressure_psi"]);
                    double dblAtmPressureAbove = Convert.ToDouble(dtAltitudeAbove.Rows[0]["atm_pressure_psi"]);

                    double dblDensityBelow = Convert.ToDouble(dtAltitudeBelow.Rows[0]["density_lb_per_cu_ft"]);
                    double dblDensityAbove = Convert.ToDouble(dtAltitudeAbove.Rows[0]["density_lb_per_cu_ft"]);

                    dblDensity_lbPerCu_ft = ((dblDensityAbove - dblDensityBelow) / (dblAltitudeAbove - dblAltitudeBelow)) * (dblAltitudeAbove - Convert.ToDouble(intAltitude)) + dblDensityBelow;
                    dblPressure_PSI = ((dblAtmPressureAbove - dblAtmPressureBelow) / (dblAltitudeAbove - dblAltitudeBelow)) * (dblAltitudeAbove - Convert.ToDouble(intAltitude)) + dblAtmPressureBelow;
                }
            }

            dblDensity_kgPerCu_Meter = dblDensity_lbPerCu_ft * ClsFormula.dblDensity_LbsPerCuFt_To_KgPerCuM;
            dblPressure_inHg = dblPressure_PSI * ClsFormula.dblPressure_PSI_To_InchHg;


            dblSummerOutdoorAirGrains = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)dblSummerOutdoorAirDB, (float)dblSummerOutdoorAirWB, intAltitude), 1);
            dblSummerOutdoorAirEnthalpy = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)dblSummerOutdoorAirDB, (float)dblSummerOutdoorAirGrains), 1);

            dblWinterOutdoorAirGrains = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)dblWinterOutdoorAirDB, (float)dblWinterOutdoorAirWB, intAltitude), 1);
            dblWinterOutdoorAirEnthalpy = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)dblWinterOutdoorAirDB, (float)dblWinterOutdoorAirGrains), 1);

            dblSummerReturnAirGrains = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)dblSummerReturnAirDB, (float)dblSummerReturnAirWB, intAltitude), 1);
            dblSummerReturnAirEnthalpy = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)dblSummerReturnAirDB, (float)dblSummerReturnAirGrains), 1);

            dblWinterReturnAirGrains = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)dblWinterReturnAirDB, (float)dblWinterReturnAirWB, intAltitude), 1);
            dblWinterReturnAirEnthalpy = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)dblWinterReturnAirDB, (float)dblWinterReturnAirGrains), 1);
        }
        #endregion


        public int intJobID { get; set; }


        public int intCreatedUserID { get; set; }


        public int intRevisedUserID { get; set; }


        public string strJobName { get; set; }

        //public string get_strSalesNo()
        //{
        //    return strReferenceNo;
        //}

        public int intRevisionNo { get; set; }


        public string strReferenceNo { get; set; }


        //public int get_intSubmittalRev()
        //{
        //    return intUOM_ID;
        //}

        //public int get_intProjectEngineerID()
        //{
        //    return intStationID;
        //}

        //public int get_intSalesDirectorID()
        //{
        //    return intHeatingDesignPercentID;
        //}

        public string strCompanyName { get; set; }

        public string strContactName { get; set; }

        public string strCompanyNameNew { get; set; }

        public string strContactNameNew { get; set; }


        public string strRepName { get; set; }

        public string get_strRepContactName()
        {
            return strUserFullName;
        }

        public string strRepStreetAddress { get; set; }

        public string strRepCity { get; set; }

        public string strRepState { get; set; }

        public string strRepPostalCode { get; set; }

        public string strRepCountry { get; set; }

        //public int get_intJobStatusID()
        //{
        //    return intJobStatusID;
        //}

        public string strUsername { get; set; }

        public int intApplicationID { get; set; }

        public int intBasisOfDesignID { get; set; }

        public int intUoM_ID { get; set; }

        public int intCompanyNameID { get; set; }

        public int intContactNameID { get; set; }

        public string strApplication { get; set; }


        public string strApplicationOther { get; set; }

        public string strBasisOfDesign { get; set; }

        public string strCountry { get; set; }

        public string strProvState { get; set; }


        public int intCityID { get; set; }


        public int intDesignConditionsID { get; set; }


        public int intAltitude { get; set; }


        public double dblDensity_lbPerCu_ft { get; set; }

        public double dblDensity_kgPerCu_Meter { get; set; }

        public double dblPressure_PSI { get; set; }


        public double dblPressure_inHg { get; set; }

        public double dblSummerOutdoorAirDB { get; set; }
        public double dblSummerOutdoorAirWB { get; set; }
        public double dblSummerOutdoorAirRH { get; set; }
        public double dblSummerOutdoorAirEnthalpy { get; set; }
        public double dblSummerOutdoorAirGrains { get; set; }


        public double dblWinterOutdoorAirDB { get; set; }
        public double dblWinterOutdoorAirWB { get; set; }
        public double dblWinterOutdoorAirRH { get; set; }
        public double dblWinterOutdoorAirEnthalpy { get; set; }
        public double dblWinterOutdoorAirGrains { get; set; }


        public double dblSummerReturnAirDB { get; set; }
        public double dblSummerReturnAirWB { get; set; }
        public double dblSummerReturnAirRH { get; set; }
        public double dblSummerReturnAirEnthalpy { get; set; }
        public double dblSummerReturnAirGrains { get; set; }


        public double dblWinterReturnAirDB { get; set; }
        public double dblWinterReturnAirWB { get; set; }
        public double dblWinterReturnAirRH { get; set; }
        public double dblWinterReturnAirEnthalpy { get; set; }
        public double dblWinterReturnAirGrains { get; set; }

        public string strCreatedDate { get; set; }
        public string strRevisedDate { get; set; }

        public int intIsTestNewPrice { get; set; }

        //public string get_strJobStatus()
        //{
        //    return strJobStatus;
        //}
    }
}