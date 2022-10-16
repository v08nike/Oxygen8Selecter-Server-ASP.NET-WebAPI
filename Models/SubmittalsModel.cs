using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Dynamic;

namespace Oxygen8SelectorServer.Models
{
    public class SubmittalsModel
    {
        private static int intUserID = 0;
        private static int intUAL = 0;
        private static int intJobID = 0;
        private static int intCountryID = 0;
        private static int intDockTypeID = 0;

        public static dynamic getControls(int JobID, int UAL, int UserID)
        {

            intJobID = JobID;
            intUAL = UAL;
            intUserID = UserID;

            dynamic returnInfo = new ExpandoObject();
            if (intJobID > 0)
            {
                DataTable dtJob = ClsDB.GetSavedJob(intJobID);
                DataTable dtSubmittals = ClsDB.GetSavedSubmittal(intJobID);


                if (dtJob.Rows.Count > 0)
                {
                    returnInfo.lblNavDetailText = "Job: " + dtJob.Rows[0]["job_name"].ToString() + " / Reference #: " + dtJob.Rows[0]["reference_no"].ToString();

                    returnInfo.txbProjectNameText = dtJob.Rows[0]["job_name"].ToString();
                    returnInfo.txbRepNameText = dtJob.Rows[0]["Customer_Name"].ToString();
                    returnInfo.txbSalesEngineerText = dtJob.Rows[0]["Customer_Contact_Name"].ToString();


                    InitializeControls();

                    //txbProjectName.Text = dtJob.Rows[0]["job_name"].ToString();

                    //dtJob.Rows[0]["customer_po"].ToString();
                    //dtJob.Rows[0]["country_id"].ToString();
                    if (dtSubmittals.Rows.Count > 0)
                    {
                        intCountryID = Convert.ToInt32(dtSubmittals.Rows[0]["shipping_country_id"]);
                        returnInfo.intCountryID = intCountryID;
                        intDockTypeID = Convert.ToInt32(dtSubmittals.Rows[0]["dock_type_id"]);
                        returnInfo.intDockTypeID = intDockTypeID;

                        returnInfo.txbLeadTimeText = dtSubmittals.Rows[0]["lead_time"].ToString();
                        returnInfo.txbRevisionNoText = dtSubmittals.Rows[0]["revision_no"].ToString();
                        returnInfo.txbPO_NumberText = dtSubmittals.Rows[0]["po_number"].ToString();
                        returnInfo.txbShippingNameText = dtSubmittals.Rows[0]["shipping_name"].ToString();
                        returnInfo.txbShippingStreetAddressText = dtSubmittals.Rows[0]["shipping_street_address"].ToString();
                        returnInfo.txbShippingCityText = dtSubmittals.Rows[0]["shipping_city"].ToString();
                        returnInfo.txbShippingProvinceText = dtSubmittals.Rows[0]["shipping_province"].ToString();
                        returnInfo.txbShippingPostalCodeText = dtSubmittals.Rows[0]["shipping_postal_code"].ToString();
                        returnInfo.ddlShippingCountryValue = intCountryID;
                        returnInfo.ddlDockTypeValue = intDockTypeID;

                        returnInfo.ckbVoltageTable = Convert.ToInt32(dtSubmittals.Rows[0]["is_pdf_voltage_table"]);
                        returnInfo.ckbBACNetPointList = Convert.ToInt32(dtSubmittals.Rows[0]["is_pdf_bacnet_points"]);
                        returnInfo.ckbOJHMISpec = Convert.ToInt32(dtSubmittals.Rows[0]["is_pdf_oj_hmi_spec"]);
                        returnInfo.ckbTerminalWiring = Convert.ToInt32(dtSubmittals.Rows[0]["is_pdf_terminal_wiring_diagram"]);
                        returnInfo.ckbFireAlarm = Convert.ToInt32(dtSubmittals.Rows[0]["is_pdf_fire_alarm"]);
                        returnInfo.ckbBackdraftDamper = Convert.ToInt32(dtSubmittals.Rows[0]["is_backdraft_dampers"]);
                        returnInfo.ckbBypassDefrost = Convert.ToInt32(dtSubmittals.Rows[0]["is_bypass_defrost"]);
                        returnInfo.ckbConstantVolume = Convert.ToInt32(dtSubmittals.Rows[0]["is_constant_volume"]);
                        returnInfo.ckbHydronicPreheat = Convert.ToInt32(dtSubmittals.Rows[0]["is_hydronic_preheat"]);
                        returnInfo.ckbHumidification = Convert.ToInt32(dtSubmittals.Rows[0]["is_humidification"]);
                        returnInfo.ckbTemControl = Convert.ToInt32(dtSubmittals.Rows[0]["is_temp_control"]);
                    }
                }
            }
            else
            {
                returnInfo.controlInfo = InitializeControls();
            }

            returnInfo.gvSubmittals = get_gvSubmittals();
            returnInfo.gvNotes = get_gvNotes();
            returnInfo.gvShippingNotes = get_gvShippingNotes();

            return returnInfo;
        }

        private static dynamic InitializeControls()
        {
            dynamic returnInfo = new ExpandoObject();

            returnInfo.txbLeadTimeText = "8-10 Weeks";
        
            if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1)
            {
                returnInfo.txbLeadTimeReadOnly = false;
                returnInfo.txbRevisionNoReadOnly = false;
            }
            else
            {
                returnInfo.txbLeadTimeReadOnly = true;
                returnInfo.txbRevisionNoReadOnly = true;
            }

            return returnInfo;
        }



        #region gvSubmittals
        public static dynamic get_gvSubmittals()
        {
            dynamic returnInfo = new ExpandoObject();
            ClsSubmittals obj = new ClsSubmittals(intUserID, intJobID);
            DataTable dtSubmittals = obj.dtSchedule;

            foreach (DataRow dr in dtSubmittals.Rows)
            {
                if (dr["pricing"].ToString() != "")
                {
                    dr["pricing"] = "$" + String.Format("{0:#,0.00}", Convert.ToDouble(dr["pricing"]));
                }
            }


            if (dtSubmittals.Rows.Count > 0)
            {
                returnInfo.gvSubmittalDetailsVisible = true;
                returnInfo.gvSubmittalDetailsDataSource = dtSubmittals;
            }

            return returnInfo;
        }
        #endregion

        #region gvNotes
        public static dynamic get_gvNotes()
        {
            dynamic returnInfo = new ExpandoObject();

            DataTable dtNotes = ClsDB.GetSavedSubmittalsNotes(intJobID);
            DataTable dtNotesFormatted = new DataTable("");
            dtNotesFormatted.Columns.Add("notes_no", typeof(int));  //Actual unit number
            dtNotesFormatted.Columns.Add("tba", typeof(string));  //Actual unit number
            dtNotesFormatted.Columns.Add("notes_nbr", typeof(int)); //Display number
            dtNotesFormatted.Columns.Add("notes", typeof(string)); //Display number

            if (dtNotes.Rows.Count > 0)
            {
                for (int i = 0; i < dtNotes.Rows.Count; i++)
                {
                    DataRow dr = dtNotesFormatted.NewRow();
                    dr["notes_no"] = Convert.ToInt32(dtNotes.Rows[i]["notes_no"]);
                    dr["tba"] = "";
                    dr["notes_nbr"] = Convert.ToInt32(dtNotes.Rows[i]["notes_no"]);
                    dr["notes"] = dtNotes.Rows[i]["notes"].ToString();
                    dtNotesFormatted.Rows.Add(dr);
                }
            }

            returnInfo.gvNotesVisible = true;
            returnInfo.gvNotesDataSource = dtNotesFormatted;
            returnInfo.gvNotesSelectedIndex = -1;
            return returnInfo;
        }
        #endregion



        #region gvShippingNotes
        public static dynamic get_gvShippingNotes()
        {
            dynamic returnInfo = new ExpandoObject();

            DataTable dtShippingNotes = ClsDB.GetSavedSubmittalsShippingNotes(intJobID);
            DataTable dtNotesFormatted = new DataTable("");
            dtNotesFormatted.Columns.Add("shipping_notes_no", typeof(int));  //Actual unit number
            dtNotesFormatted.Columns.Add("tba", typeof(string));  //Actual unit number
            dtNotesFormatted.Columns.Add("shipping_notes_nbr", typeof(int)); //Display number
            dtNotesFormatted.Columns.Add("shipping_notes", typeof(string)); //Display number

            if (dtShippingNotes.Rows.Count > 0)
            {
                for (int i = 0; i < dtShippingNotes.Rows.Count; i++)
                {
                    DataRow dr = dtNotesFormatted.NewRow();
                    dr["shipping_notes_no"] = Convert.ToInt32(dtShippingNotes.Rows[i]["shipping_notes_no"]);
                    dr["tba"] = "";
                    dr["shipping_notes_nbr"] = Convert.ToInt32(dtShippingNotes.Rows[i]["shipping_notes_no"]);
                    dr["shipping_notes"] = dtShippingNotes.Rows[i]["shipping_notes"].ToString();
                    dtNotesFormatted.Rows.Add(dr);
                }
            }

            returnInfo.gvShippingNotesVisible = true;
            returnInfo.gvShippingNotesDataSource = dtNotesFormatted;
            returnInfo.gvShippingNotesSelectedIndex = -1;

            return returnInfo;
        }

        #endregion

        #region Save Update
        public static bool setSaveUpdate(dynamic info)
        {
            string strSaveMsg = ClsDB.SaveSubmittals(Convert.ToInt32(info.intJobID),
                                                    info.txbLeadTime.ToString(),
                                                    Convert.ToInt32(info.txbRevisionNo),
                                                    info.txbPONumber.ToString(),
                                                    info.txbShipName.ToString(),
                                                    info.txbShippingStreetAddress.ToString(),
                                                    info.txbShippingCity.ToString(),
                                                    info.txbShippingProvince.ToString(),
                                                    Convert.ToInt32(info.ddlCountry),
                                                    info.txbShippingPostalCode.ToString(),
                                                    Convert.ToInt32(info.ddlDockType),
                                                    Convert.ToInt32(info.ckbVoltageTable),
                                                    Convert.ToInt32(info.ckbBACNetPointList),
                                                    Convert.ToInt32(info.ckbOJHMISpec),
                                                    Convert.ToInt32(info.ckbTerminalWiring),
                                                    Convert.ToInt32(info.ckbFireAlarm),
                                                    Convert.ToInt32(info.ckbBackdraftDamper),
                                                    Convert.ToInt32(info.ckbBypassDefrost),
                                                    Convert.ToInt32(info.ckbConstantVolume),
                                                    Convert.ToInt32(info.ckbHydronicPreheat),
                                                    Convert.ToInt32(info.ckbHumidification),
                                                    Convert.ToInt32(info.ckbTemControl));


            return true;
        }
        #endregion
    }
}