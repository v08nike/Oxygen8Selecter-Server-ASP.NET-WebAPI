using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsSubmittals
    {
        //private ClsPerformanceNew objPerf;
        private ClsPricing objpricing;
        private ClsContainer objContainer;
        //private ClsContElements objContElem;
        private ClsDrawing objDrawing;

        private ClsGeneral objGen;
        private DataSet dsSavedUnitItems = new DataSet();
        private DataTable dtSavedUnit = new DataTable();
        private DataRow drSavedUnit;
        //private DataTable dtCompOpt = new DataTable();
        private DataRow drCompOpt;



        public ClsSubmittals()
        {
        }

        public ClsSubmittals(int _intUAL, int _intJobID)
        {

            setHeaderData(_intJobID);
            setSchedule(_intUAL, _intJobID);
            setNotes(_intJobID);
            setShippingNotes(_intJobID);
        }


        #region HeaderData
        private void setHeaderData(int _intJobID)
        {
            dtHeaderData = new DataTable();
            dtHeaderData.Columns.Add("lead_time", typeof(string));
            dtHeaderData.Columns.Add("revision_nbr", typeof(string));
            dtHeaderData.Columns.Add("project", typeof(string));
            dtHeaderData.Columns.Add("company_name", typeof(string));
            //dtHeaderData.Columns.Add("engineer", typeof(string));
            dtHeaderData.Columns.Add("contact_name", typeof(string));
            dtHeaderData.Columns.Add("shippping_name", typeof(string));
            dtHeaderData.Columns.Add("shipping_street_address", typeof(string));
            dtHeaderData.Columns.Add("shipping_city", typeof(string));
            dtHeaderData.Columns.Add("shipping_province", typeof(string));
            dtHeaderData.Columns.Add("shipping_country", typeof(string));
            dtHeaderData.Columns.Add("shipping_postal_code", typeof(string));
            dtHeaderData.Columns.Add("dock_type", typeof(string));
            dtHeaderData.Columns.Add("date", typeof(string));
            dtHeaderData.Columns.Add("po_nbr", typeof(string));
            DataRow drHeader;

            DataTable dtSavedJob = ClsDB.GetSavedJob(_intJobID);
            DataTable dtSavedSubmittal = ClsDB.GetSavedSubmittal(_intJobID);

            drHeader = dtHeaderData.NewRow();
            drHeader["project"] = dtSavedJob.Rows[0]["job_name"].ToString();
            drHeader["company_name"] = dtSavedJob.Rows[0]["Customer_Name"].ToString();
            //drHeader["engineer"] = dtSavedJob.Rows[0]["contact_name"].ToString();
            //drHeader["contact_name"] = dtSavedJob.Rows[0]["User_Full_Name"].ToString();
            drHeader["contact_name"] = dtSavedJob.Rows[0]["Customer_Contact_name"].ToString();
            if (dtSavedSubmittal.Rows.Count > 0)
            {
                drHeader["lead_time"] = dtSavedSubmittal.Rows[0]["lead_time"].ToString();
                drHeader["revision_nbr"] = dtSavedSubmittal.Rows[0]["revision_no"].ToString();
                drHeader["po_nbr"] = dtSavedSubmittal.Rows[0]["po_number"].ToString();
                drHeader["shippping_name"] = dtSavedSubmittal.Rows[0]["shipping_name"].ToString();
                drHeader["shipping_street_address"] = dtSavedSubmittal.Rows[0]["shipping_street_address"].ToString();
                drHeader["shipping_city"] = dtSavedSubmittal.Rows[0]["shipping_city"].ToString();
                drHeader["shipping_province"] = dtSavedSubmittal.Rows[0]["shipping_province"].ToString();
                drHeader["shipping_country"] = dtSavedSubmittal.Rows[0]["ShippingCountry"].ToString();
                drHeader["shipping_postal_code"] = dtSavedSubmittal.Rows[0]["shipping_postal_code"].ToString();
                drHeader["dock_type"] = "TBA";
            }
            drHeader["date"] = DateTime.Now.ToString("yyyy-MM-dd");
            dtHeaderData.Rows.Add(drHeader);
        }
        #endregion


        #region Schedule
        private void setSchedule(int _intUAL, int _intJobID)
        {
            string strUnitModel = "";
            string strUnitModelValue = "";

            dtSchedule = new DataTable();
            dtSchedule.Columns.Add("qty", typeof(string));
            dtSchedule.Columns.Add("tag", typeof(string));
            dtSchedule.Columns.Add("item", typeof(string));
            dtSchedule.Columns.Add("model", typeof(string));
            dtSchedule.Columns.Add("voltage", typeof(string));
            dtSchedule.Columns.Add("duct_connection", typeof(string));
            dtSchedule.Columns.Add("controls_preference", typeof(string));
            dtSchedule.Columns.Add("installation", typeof(string));
            dtSchedule.Columns.Add("handing", typeof(string));
            dtSchedule.Columns.Add("part_desc", typeof(string));
            dtSchedule.Columns.Add("part_number", typeof(string));
            dtSchedule.Columns.Add("pricing", typeof(string));
            dtSchedule.Columns.Add("is_unit_bold", typeof(int)).DefaultValue = 0;
            //dtSchedule.Columns.Add("Controls", typeof(string));
            DataRow drSchedule;

            //DataTable dtSavedUnitsByJob = ClsDB.GetSavedUnitsWithDetails(_intJobID);
            DataSet dsSavedUnitsByJob = ClsDB.GetSavedJobItems(_intJobID);
            //DataTable dtSavedCompByJob = ClsDB.GetSavedItemsByJob(_intJobID, ClsDBT.strSavCompOption);

            //DataTable dtSavedUnitsNo = ClsDB.GetSavedUnitsNo(_intJobID);
            DataTable dtSavedUnits = dsSavedUnitsByJob.Tables[ClsDBT.strSavGeneral];
            DataTable dtOutdoorUnit = dsSavedUnitsByJob.Tables[ClsDBT.strSavGeneral].Copy();
            DataTable dtIndoorUnit = dsSavedUnitsByJob.Tables[ClsDBT.strSavGeneral].Copy();
            DataTable dtUnitsWithControls = dsSavedUnitsByJob.Tables[ClsDBT.strSavGeneral].Copy();
            DataTable dtDamper = dsSavedUnitsByJob.Tables[ClsDBT.strSavCompOption].Copy();


            DataTable dtDX_Coil = dsSavedUnitsByJob.Tables[ClsDBT.strSavCompOption].Copy();
            DataTable dtElecCoilInCasing = dsSavedUnitsByJob.Tables[ClsDBT.strSavCompOption].Copy();
            DataTable dtElecCoilDuctMount = dsSavedUnitsByJob.Tables[ClsDBT.strSavCompOption].Copy();
            DataTable dtHeatPostHeatElecCoilDuctMount = dsSavedUnitsByJob.Tables[ClsDBT.strSavCompOption].Copy();


            //drSchedule = dtSchedule.NewRow();
            //drSchedule["Qty"] = "Qty";
            //drSchedule["Item"] = "Item";
            //drSchedule["Model"] = "Model";
            //drSchedule["Voltage"] = "Voltage";
            //drSchedule["Duct connection"] = "Duct connection";
            //drSchedule["Controls Preference"] = "Controls Preference";
            //drSchedule["Installation"] = "Installation";
            //drSchedule["Handing"] = "Handing";
            //drSchedule["Controls"] = "Controls";
            //drSchedule["Tag"] = "Tag";
            //dtSchedule.Rows.Add(drSchedule);

            int intUnitNbr = 0;

            #region Units
            foreach (DataRow dr in dtSavedUnits.Rows)
            {
                //objGen = new ClsGeneral(_intJobID, Convert.ToInt32(dr["unit_no"]));
                //dsSavedUnitItems = objGen.dsSavedUnitItems;
                DataSet dsSavedUnitItems = ClsDB.GetSavedUnitItems(_intJobID, Convert.ToInt32(dr["unit_no"]));

                dtSavedUnit = dsSavedUnitItems.Tables[ClsDBT.strSavGeneral];
                drSavedUnit = dtSavedUnit.Rows[0];
                drCompOpt = dsSavedUnitItems.Tables[ClsDBT.strSavCompOption].Rows[0];
                objpricing = new ClsPricing(_intUAL, _intJobID, Convert.ToInt32(dr["unit_no"]));
                objDrawing = new ClsDrawing(_intJobID, Convert.ToInt32(dr["unit_no"]));

                ++intUnitNbr;

                strUnitModel = dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString();


                //switch (Convert.ToInt32(drSavedUnit[ClsDBTC.product_type_id]))
                //{
                //    case ClsID.intProductTypeNovaID:
                //        //strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                //        strUnitModel = dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString();
                //        break;
                //    case ClsID.intProductTypeVentumID:
                //        //strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                //        strUnitModel = dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString();
                //        break;
                //    default:
                //        break;
                //}


                #region ACcess Section
                if (objpricing.dblAccessSectionPrice > 0)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                    drSchedule["tag"] = "AS-" + intUnitNbr;
                    drSchedule["item"] = objpricing.strAccessSectionDetails;
                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "";
                    drSchedule["duct_connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = "";
                    drSchedule["handing"] = dsSavedUnitItems.Tables["CoolingCoilHanding"].Rows[0]["dwg_code"].ToString();
                    drSchedule["part_desc"] = "";
                    drSchedule["part_number"] = "";
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblAccessSectionPrice);
                    drSchedule["pricing"] = objpricing.dblAccessSectionPrice;
                    dtSchedule.Rows.Add(drSchedule);
                }
                #endregion



                #region Preheat Electric Heater
                if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompElecHeaterID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                    drSchedule["tag"] = "PEH-" + intUnitNbr;
                    drSchedule["item"] = "Electric Pre-Heat";

                    //switch (Convert.ToInt32(dr["ProductTypeID"]))
                    //{
                    //    case ClsID.intProductTypeNovaID:
                    //        strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                    //        break;
                    //    case ClsID.intProductTypeVentumID:
                    //        strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                    //        break;
                    //    default:
                    //        break;
                    //}

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["items"].ToString();
                    drSchedule["duct_connection"] = "N/A";
                    drSchedule["controls_preference"] = "SCR";
                    drSchedule["installation"] = dsSavedUnitItems.Tables["PreheatElecHeaterInstallation"].Rows[0]["items"].ToString();
                    drSchedule["handing"] = dsSavedUnitItems.Tables["PreheatCoilHanding"].Rows[0]["dwg_code"].ToString();
                    drSchedule["part_desc"] = objDrawing.strPreheatElecHeaterEpicorPartDesc;
                    drSchedule["part_number"] = objDrawing.strPreheatElecHeaterEpicorPartNbr;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblPreheatElecHeaterPrice);
                    drSchedule["pricing"] = objpricing.dblPreheatElecHeaterPrice;

                    //drSchedule["Controls"] = "SCR";
                    dtSchedule.Rows.Add(drSchedule);
                }
                #endregion


                #region Heating Electric Heater
                if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                    drSchedule["tag"] = "HEH-" + intUnitNbr;
                    drSchedule["item"] = "Electric Heating";

                    //switch (Convert.ToInt32(dr["ProductTypeID"]))
                    //{
                    //    case ClsID.intProductTypeNovaID:
                    //        strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                    //        break;
                    //    case ClsID.intProductTypeVentumID:
                    //        strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                    //        break;
                    //    default:
                    //        break;
                    //}

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["items"].ToString();
                    drSchedule["duct_connection"] = "N/A";
                    drSchedule["controls_preference"] = "SCR";
                    drSchedule["installation"] = dsSavedUnitItems.Tables["HeatingElecHeaterInstallation"].Rows[0]["items"].ToString();
                    drSchedule["handing"] = dsSavedUnitItems.Tables["HeatingCoilHanding"].Rows[0]["dwg_code"].ToString();
                    drSchedule["part_desc"] = objDrawing.strHeatingElecHeaterEpicorPartDesc;
                    drSchedule["part_number"] = objDrawing.strHeatingElecHeaterEpicorPartNbr;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblHeatingElecHeaterPrice);
                    drSchedule["pricing"] = objpricing.dblHeatingElecHeaterPrice;
                    //drSchedule["Controls"] = "SCR";
                    dtSchedule.Rows.Add(drSchedule);
                }
                #endregion


                #region Reheat Electric Heater
                if (Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompElecHeaterID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                    drSchedule["tag"] = "REH-" + intUnitNbr;
                    drSchedule["item"] = "Electric Reheat";

                    //switch (Convert.ToInt32(dr["ProductTypeID"]))
                    //{
                    //    case ClsID.intProductTypeNovaID:
                    //        strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                    //        break;
                    //    case ClsID.intProductTypeVentumID:
                    //        strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                    //        break;
                    //    default:
                    //        break;
                    //}

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["items"].ToString();
                    drSchedule["duct_connection"] = "N/A";
                    drSchedule["controls_preference"] = "SCR";
                    drSchedule["installation"] = dsSavedUnitItems.Tables["HeatingElecHeaterInstallation"].Rows[0]["items"].ToString();
                    drSchedule["handing"] = dsSavedUnitItems.Tables["HeatingCoilHanding"].Rows[0]["dwg_code"].ToString();
                    drSchedule["part_desc"] = objDrawing.strReheatElecHeaterEpicorPartDesc;
                    drSchedule["part_number"] = objDrawing.strReheatElecHeaterEpicorPartNbr;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblReheatElecHeaterPrice);
                    drSchedule["pricing"] = objpricing.dblReheatElecHeaterPrice;
                    //drSchedule["Controls"] = "SCR";
                    dtSchedule.Rows.Add(drSchedule);
                }
                #endregion


                #region Preheat HWC
                if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompHWC_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                    drSchedule["tag"] = "PHWC-" + intUnitNbr;
                    drSchedule["item"] = "HWC Pre-Heat";
                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "N/A";
                    drSchedule["duct_connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = dsSavedUnitItems.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["items"].ToString();
                    drSchedule["handing"] = dsSavedUnitItems.Tables["PreheatCoilHanding"].Rows[0]["dwg_code"].ToString();
                    drSchedule["part_desc"] = objDrawing.strPreheatHWC_EpicorPartDesc;
                    drSchedule["part_number"] = objDrawing.strPreheatHWC_EpicorPartNbr;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblPreheatHWC_Price);
                    drSchedule["pricing"] = objpricing.dblPreheatHWC_Price;
                    //drSchedule["Controls"] = "N/A";
                    dtSchedule.Rows.Add(drSchedule);

                    if (Convert.ToInt32(drCompOpt[ClsDBTC.is_valve_and_actuator_included]) == 1)
                    {
                        drSchedule = dtSchedule.NewRow();
                        drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                        drSchedule["tag"] = "PHWCV-" + intUnitNbr;
                        drSchedule["item"] = "HWC Pre-Heat Valve";
                        //drSchedule["model"] = dr["PreheatHWC_ValveType"].ToString(); ;
                        drSchedule["model"] = dsSavedUnitItems.Tables[ClsDBT.strSelValveType].Rows[0]["items"].ToString();
                        drSchedule["voltage"] = "N/A";
                        drSchedule["duct_connection"] = "N/A";
                        drSchedule["controls_preference"] = "N/A";
                        drSchedule["installation"] = "N/A";
                        drSchedule["handing"] = "";
                        //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblPreheatHWC_ValvePrice);
                        drSchedule["pricing"] = objpricing.dblPreheatHWC_ValvePrice;
                        //drSchedule["Controls"] = "N/A";
                        dtSchedule.Rows.Add(drSchedule);
                    }
                }
                #endregion


                #region Heating HWC
                if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompHWC_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                    drSchedule["tag"] = "HHWC-" + intUnitNbr;
                    drSchedule["item"] = "HWC Heating";
                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "N/A";
                    drSchedule["duct_connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = dsSavedUnitItems.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["items"].ToString();
                    drSchedule["handing"] = dsSavedUnitItems.Tables["HeatingCoilHanding"].Rows[0]["dwg_code"].ToString();
                    drSchedule["part_desc"] = objDrawing.strHeatingHWC_EpicorPartDesc;
                    drSchedule["part_number"] = objDrawing.strHeatingHWC_EpicorPartNbr;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblHeatingHWC_Price);
                    drSchedule["pricing"] = objpricing.dblHeatingHWC_Price;
                    //drSchedule["Controls"] = "N/A";
                    dtSchedule.Rows.Add(drSchedule);

                    if (Convert.ToInt32(drCompOpt[ClsDBTC.is_valve_and_actuator_included]) == 1)
                    {
                        drSchedule = dtSchedule.NewRow();
                        drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                        drSchedule["tag"] = "HHWCV-" + intUnitNbr;
                        drSchedule["item"] = "HWC Heating Valve";
                        //drSchedule["model"] = dr["HeatingHWC_ValveType"].ToString(); ;
                        drSchedule["model"] = dsSavedUnitItems.Tables[ClsDBT.strSelValveType].Rows[0]["items"].ToString();
                        drSchedule["voltage"] = "N/A";
                        drSchedule["duct_connection"] = "N/A";
                        drSchedule["controls_preference"] = "N/A";
                        drSchedule["installation"] = "N/A";
                        drSchedule["handing"] = "";
                        //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblHeatingHWC_ValvePrice);
                        drSchedule["pricing"] = objpricing.dblHeatingHWC_ValvePrice;
                        //drSchedule["Controls"] = "N/A";
                        dtSchedule.Rows.Add(drSchedule);
                    }
                }
                #endregion


                #region Reheat HWC
                if (Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompHWC_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                    drSchedule["tag"] = "RHWC-" + intUnitNbr;
                    drSchedule["item"] = "HWC Reheat";
                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "N/A";
                    drSchedule["duct_connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = dsSavedUnitItems.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["items"].ToString();
                    drSchedule["handing"] = dsSavedUnitItems.Tables["HeatingCoilHanding"].Rows[0]["dwg_code"].ToString();
                    drSchedule["part_desc"] = objDrawing.strReheatHWC_EpicorPartDesc;
                    drSchedule["part_number"] = objDrawing.strReheatHWC_EpicorPartNbr;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblReheatHWC_Price);
                    drSchedule["pricing"] = objpricing.dblReheatHWC_Price;
                    //drSchedule["Controls"] = "N/A";
                    dtSchedule.Rows.Add(drSchedule);

                    if (Convert.ToInt32(drCompOpt[ClsDBTC.is_valve_and_actuator_included]) == 1)
                    {
                        drSchedule = dtSchedule.NewRow();
                        drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                        drSchedule["tag"] = "RHWCV-" + intUnitNbr;
                        drSchedule["item"] = "HWC Pre-Heat Valve";
                        //drSchedule["model"] = dr["ReheatHWC_ValveType"].ToString(); ;
                        drSchedule["model"] = dsSavedUnitItems.Tables[ClsDBT.strSelValveType].Rows[0]["items"].ToString();
                        drSchedule["voltage"] = "N/A";
                        drSchedule["duct_connection"] = "N/A";
                        drSchedule["controls_preference"] = "N/A";
                        drSchedule["installation"] = "N/A";
                        drSchedule["handing"] = "";
                        //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblReheatHWC_ValvePrice);
                        drSchedule["pricing"] = objpricing.dblReheatHWC_ValvePrice;
                        //drSchedule["Controls"] = "N/A";
                        dtSchedule.Rows.Add(drSchedule);
                    }
                }
                #endregion


                #region Cooling CWC
                if (Convert.ToInt32(drCompOpt[ClsDBTC.cooling_comp_id]) == ClsID.intCompCWC_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                    drSchedule["tag"] = "CCWC-" + intUnitNbr;
                    drSchedule["item"] = "CWC Cooling";
                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "N/A";
                    drSchedule["duct_connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = dsSavedUnitItems.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["items"].ToString();
                    drSchedule["handing"] = dsSavedUnitItems.Tables["CoolingCoilHanding"].Rows[0]["dwg_code"].ToString();
                    drSchedule["part_desc"] = objDrawing.strCWC_EpicorPartDesc;
                    drSchedule["part_number"] = objDrawing.strCWC_EpicorPartNbr;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblCWC_Price);
                    drSchedule["pricing"] = objpricing.dblCWC_Price;
                    //drSchedule["Controls"] = "N/A";
                    dtSchedule.Rows.Add(drSchedule);

                    if (Convert.ToInt32(drCompOpt[ClsDBTC.is_valve_and_actuator_included]) == 1)
                    {
                        drSchedule = dtSchedule.NewRow();
                        drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                        drSchedule["tag"] = "CCWCV-" + intUnitNbr;
                        drSchedule["item"] = "CWC Cooling Valve";
                        //drSchedule["model"] = dr["CoolingCWC_ValveType"].ToString(); ;
                        drSchedule["model"] = dsSavedUnitItems.Tables[ClsDBT.strSelValveType].Rows[0]["items"].ToString();
                        drSchedule["voltage"] = "N/A";
                        drSchedule["duct_connection"] = "N/A";
                        drSchedule["controls_preference"] = "N/A";
                        drSchedule["installation"] = "N/A";
                        drSchedule["handing"] = "";
                        //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblCWC_ValvePrice);
                        drSchedule["pricing"] = objpricing.dblCWC_ValvePrice;
                        //drSchedule["Controls"] = "N/A";
                        dtSchedule.Rows.Add(drSchedule);
                    }
                }
                #endregion


                #region Cooling DX
                if (Convert.ToInt32(drCompOpt[ClsDBTC.cooling_comp_id]) == ClsID.intCompDX_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(drSavedUnit["qty"]);
                    drSchedule["tag"] = "CDXC-" + intUnitNbr;
                    drSchedule["item"] = "DXC Cooling";

                    //switch (Convert.ToInt32(dr["ProductTypeID"]))
                    //{
                    //    case ClsID.intProductTypeNovaID:
                    //        strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                    //        break;
                    //    case ClsID.intProductTypeVentumID:
                    //        strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                    //        break;
                    //    default:
                    //        break;
                    //}

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "230V/1ph/60Hz";
                    drSchedule["duct_connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = dsSavedUnitItems.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["items"].ToString();
                    drSchedule["handing"] = dsSavedUnitItems.Tables["CoolingCoilHanding"].Rows[0]["dwg_code"].ToString();
                    drSchedule["part_desc"] = objDrawing.strDXC_EpicorPartDesc;
                    drSchedule["part_number"] = objDrawing.strDXC_EpicorPartNbr;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblDXC_Price);
                    drSchedule["pricing"] = objpricing.dblDXC_Price;
                    //drSchedule["Controls"] = "N/A";
                    dtSchedule.Rows.Add(drSchedule);
                }
                #endregion


                #region Damper
                if (Convert.ToInt32(drCompOpt[ClsDBTC.damper_and_actuator_id]) > 1)
                {

                    //switch (Convert.ToInt32(dr["ProductTypeID"]))
                    //{
                    //    case ClsID.intProductTypeNovaID:
                    //        strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                    //        strUnitModelValue = dr["NovaUnitModelValue"].ToString();
                    //        break;
                    //    case ClsID.intProductTypeVentumID:
                    //        strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                    //        strUnitModelValue = dr["VentumUnitModelValue"].ToString();
                    //        break;
                    //    default:
                    //        break;
                    //}

                    string strDamperSize = "";

                    DataTable dtDamperSize = ClsDB.get_dtLive(ClsDBT.strSelDamperSize);
                    var drDamperSize = dtDamperSize.AsEnumerable().Where(x => (Convert.ToInt32(x["is_bypass"]) == 0));
                    dtDamperSize = drDamperSize.Any() ? drDamperSize.CopyToDataTable() : new DataTable();
                    drDamperSize = dtDamperSize.AsEnumerable().Where(x => (Convert.ToInt32(x["product_type_id"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.product_type_id])));
                    dtDamperSize = drDamperSize.Any() ? drDamperSize.CopyToDataTable() : new DataTable();
                    drDamperSize = dtDamperSize.AsEnumerable().Where(x => ((string)x["unit_model_value"] == strUnitModel));
                    dtDamperSize = drDamperSize.Any() ? drDamperSize.CopyToDataTable() : new DataTable();
                    drDamperSize = dtDamperSize.AsEnumerable().Where(x => (Convert.ToInt32(x["unit_orientation_id"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.orientation_id])));
                    dtDamperSize = drDamperSize.Any() ? drDamperSize.CopyToDataTable() : new DataTable();

                    if (Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID)
                    {
                        drDamperSize = dtDamperSize.AsEnumerable().Where(x => (Convert.ToInt32(x["damper_and_actuator_id"]) == Convert.ToInt32(drCompOpt[ClsDBTC.damper_and_actuator_id])));
                        dtDamperSize = drDamperSize.Any() ? drDamperSize.CopyToDataTable() : new DataTable();
                    }

                    if (dtDamperSize.Rows.Count > 0)
                    {
                        //strDamperSize = "Size: " + Environment.NewLine + dtDamperSize.Rows[0]["width"].ToString() + "\" x " + dtDamperSize.Rows[0]["height"].ToString() + "\"";
                        strDamperSize = dtDamperSize.Rows[0]["width"].ToString() + "\"W x " + dtDamperSize.Rows[0]["height"].ToString() + "\"H";
                    }

                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]) * 2;
                    drSchedule["tag"] = "D-" + intUnitNbr;
                    drSchedule["item"] = "OA/EA Isolation Dampers & Actuators";
                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "24 VAC";
                    drSchedule["duct_connection"] = strDamperSize;
                    drSchedule["controls_preference"] = "On/Off";
                    drSchedule["installation"] = dsSavedUnitItems.Tables[ClsDBT.strSelDamperActuator].Rows[0]["items"].ToString();
                    drSchedule["handing"] = "";
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblDamperPrice);
                    drSchedule["pricing"] = objpricing.dblDamperPrice;
                    //drSchedule["Controls"] = "On/Off";
                    dtSchedule.Rows.Add(drSchedule);


                    //drSchedule = dtSchedule.NewRow();
                    //drSchedule["qty"] = Convert.ToInt32(dr["Qty"]) * 1;
                    //drSchedule["tag"] = "EAD-" + intUnitNbr;
                    //drSchedule["item"] = "Damper & Actuator";
                    //drSchedule["model"] = strUnitModel;
                    //drSchedule["voltage"] = "24 VAC";
                    ////drSchedule["Duct connection"] = strDamperSize;
                    //drSchedule["controls_preference"] = "On/Off";
                    //drSchedule["installation"] = dr["DamperActuator"].ToString();
                    //drSchedule["handing"] = "";
                    ////drSchedule["Controls"] = "On/Off";
                    //dtSchedule.Rows.Add(drSchedule);
                }
                #endregion


                #region Sensors
                //DataTable dtSensorPricing = ClsDB.get_dtLive(ClsDBT.strSelSensorPrice);
                intUnitNbr = 0;

                if (Convert.ToInt32(drCompOpt[ClsDBTC.is_dehumidification]) == 1 && Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompNA_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = 1;
                    drSchedule["tag"] = "S-" + ++intUnitNbr;
                    drSchedule["item"] = "Sensor (Dehum)";
                    drSchedule["model"] = ClsGV.strSensorETF_1098L1_4;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblSensorDehumNoReheatPrice);
                    drSchedule["pricing"] = objpricing.dblSensorDehumNoReheatPrice;
                    dtSchedule.Rows.Add(drSchedule);

                    if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) > 1)
                    {
                        drSchedule = dtSchedule.NewRow();
                        drSchedule["qty"] = 1;
                        drSchedule["tag"] = "S-" + ++intUnitNbr;
                        drSchedule["item"] = "Sensor (Heating)";
                        drSchedule["model"] = ClsGV.strSensorTTH_6202;
                        //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblSensorHeatingPrice);
                        drSchedule["pricing"] = objpricing.dblSensorHeatingPrice;
                        dtSchedule.Rows.Add(drSchedule);
                    }
                }
                else if (Convert.ToInt32(drCompOpt[ClsDBTC.is_dehumidification]) == 1 && Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompElecHeaterID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = 1;
                    drSchedule["tag"] = "S-" + ++intUnitNbr;
                    drSchedule["item"] = "Sensor (Dehum & Reheat)";
                    drSchedule["model"] = ClsGV.strSensorHTH_6202;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblSensorDehumReheatPrice);
                    drSchedule["pricing"] = objpricing.dblSensorDehumReheatPrice;
                    dtSchedule.Rows.Add(drSchedule);

                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = 1;
                    drSchedule["tag"] = "S-" + ++intUnitNbr;
                    drSchedule["item"] = "Sensor (Dehum & Reheat)";
                    drSchedule["model"] = ClsGV.strSensorETF_1098L1_4;
                    //drSchedule["pricing"] = objpricing.dblSensorHeatingPrice;
                    dtSchedule.Rows.Add(drSchedule);


                    if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompHWC_ID)
                    {
                        drSchedule = dtSchedule.NewRow();
                        drSchedule["qty"] = 1;
                        drSchedule["tag"] = "S-" + ++intUnitNbr;
                        drSchedule["item"] = "Sensor (Heating)";
                        drSchedule["model"] = ClsGV.strSensorTTH_6202;
                        //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblSensorHeatingPrice);
                        drSchedule["pricing"] = objpricing.dblSensorHeatingPrice;
                        dtSchedule.Rows.Add(drSchedule);
                    }
                }
                else if (Convert.ToInt32(drCompOpt[ClsDBTC.is_dehumidification]) == 1 && Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompHWC_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = 1;
                    drSchedule["tag"] = "S-" + ++intUnitNbr;
                    drSchedule["item"] = "Sensor (Dehum & Reheat)";
                    drSchedule["model"] = ClsGV.strSensorHTH_6202;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblSensorDehumReheatPrice);
                    drSchedule["pricing"] = objpricing.dblSensorDehumReheatPrice;
                    dtSchedule.Rows.Add(drSchedule);


                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = 1;
                    drSchedule["tag"] = "S-" + ++intUnitNbr;
                    drSchedule["item"] = "Sensor (Dehum & Reheat)";
                    drSchedule["model"] = ClsGV.strSensorETF_1098L1_4;
                    //drSchedule["pricing"] = objpricing.dblSensorHeatingPrice;
                    dtSchedule.Rows.Add(drSchedule);

                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = 1;
                    drSchedule["tag"] = "S-" + ++intUnitNbr;
                    drSchedule["item"] = "Sensor (Dehum & Reheat)";
                    drSchedule["model"] = ClsGV.strSensorETF_598B_5;
                    //drSchedule["pricing"] = objpricing.dblSensorHeatingPrice;
                    dtSchedule.Rows.Add(drSchedule);


                    if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID)
                    {
                        drSchedule = dtSchedule.NewRow();
                        drSchedule["qty"] = 1;
                        drSchedule["tag"] = "S-" + ++intUnitNbr;
                        drSchedule["item"] = "Sensor (Heating)";
                        drSchedule["model"] = ClsGV.strSensorTTH_6202;
                        //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblSensorHeatingPrice);
                        drSchedule["pricing"] = objpricing.dblSensorHeatingPrice;
                        dtSchedule.Rows.Add(drSchedule);
                    }
                }
                else
                {
                    if (Convert.ToInt32(drCompOpt[ClsDBTC.cooling_comp_id]) > 1)
                    {
                        drSchedule = dtSchedule.NewRow();
                        drSchedule["qty"] = 1;
                        drSchedule["tag"] = "S-" + ++intUnitNbr;
                        drSchedule["item"] = "Sensor (Cooling)";
                        drSchedule["model"] = ClsGV.strSensorTTH_6202;
                        //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblSensorCoolingPrice);
                        drSchedule["pricing"] = objpricing.dblSensorCoolingPrice;
                        dtSchedule.Rows.Add(drSchedule);
                    }


                    if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) > 1)
                    {
                        drSchedule = dtSchedule.NewRow();
                        drSchedule["qty"] = 1;
                        drSchedule["tag"] = "S-" + ++intUnitNbr;
                        drSchedule["item"] = "Sensor (Heating)";
                        drSchedule["model"] = ClsGV.strSensorTTH_6202;
                        //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblSensorHeatingPrice);
                        drSchedule["pricing"] = objpricing.dblSensorHeatingPrice;
                        dtSchedule.Rows.Add(drSchedule);


                        if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompHWC_ID)
                        {
                            drSchedule = dtSchedule.NewRow();
                            drSchedule["qty"] = 1;
                            drSchedule["tag"] = "S-" + ++intUnitNbr;
                            drSchedule["item"] = "Sensor (HWC)";
                            drSchedule["model"] = ClsGV.strSensorETF_598B_5;
                            //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblSensorHeatingPrice);
                            drSchedule["pricing"] = objpricing.dblSensorHeatingHWC_Price;
                            dtSchedule.Rows.Add(drSchedule);
                        }
                    }

                }

                #region Controls
                if (Convert.ToInt32(drSavedUnit[ClsDBTC.controls_preference_id]) == ClsID.intControlPrefByOthersID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = 1;
                    drSchedule["item"] = "Controls";
                    drSchedule["model"] = dsSavedUnitItems.Tables[ClsDBT.strSelControlsPreference].Rows[0]["items"].ToString();
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblControlsByOtherPrice);
                    drSchedule["pricing"] = objpricing.dblControlsByOtherPrice;
                    dtSchedule.Rows.Add(drSchedule);
                }
                else if (Convert.ToInt32(drSavedUnit[ClsDBTC.controls_preference_id]) == ClsID.intControlsPrefVAV_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = 1;
                    drSchedule["tag"] = "S-" + ++intUnitNbr;
                    drSchedule["item"] = "Pressure Transmitter";
                    drSchedule["model"] = ClsGV.strSensorPressTrans_PTH_6202;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblSenosrControlsPrefPrice);
                    drSchedule["pricing"] = objpricing.dblSenosrControlsPrefPrice;
                    dtSchedule.Rows.Add(drSchedule);
                }
                else if (Convert.ToInt32(drSavedUnit[ClsDBTC.controls_preference_id]) == ClsID.intControlsPrefDCV_CO2_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = 1;
                    drSchedule["tag"] = "S-" + ++intUnitNbr;
                    drSchedule["item"] = "Sensor";
                    drSchedule["model"] = ClsGV.strSensorVTH_6202_VOC_CO2;
                    //drSchedule["pricing"] = "$" + String.Format("{0:#,0.00}", objpricing.dblSenosrControlsPrefPrice);
                    drSchedule["pricing"] = objpricing.dblSenosrControlsPrefPrice;
                    dtSchedule.Rows.Add(drSchedule);
                }
                else
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = "";
                    drSchedule["tag"] = "";
                    drSchedule["item"] = "Controls";
                    drSchedule["model"] = dsSavedUnitItems.Tables[ClsDBT.strSelControlsPreference].Rows[0]["items"].ToString();
                    //drSchedule["pricing"] = "";
                    dtSchedule.Rows.Add(drSchedule);
                }

                //if (Convert.ToInt32(dr["ControlsPrefID"]) > 1)
                //{ControlsPref

                //}

                #endregion  //Controls


                #endregion //Sensors



                drSchedule = dtSchedule.NewRow();
                dtSchedule.Rows.Add(drSchedule);

            }
            #endregion




            #region HMI
            if (dtUnitsWithControls.Rows.Count > 0)
            {
                var drUnitsWithControls = dtUnitsWithControls.AsEnumerable().Where(x => (Convert.ToInt32(x[ClsDBTC.controls_preference_id]) != ClsID.intControlPrefByOthersID));
                dtUnitsWithControls = drUnitsWithControls.Any() ? drUnitsWithControls.CopyToDataTable() : new DataTable();

                if (dtUnitsWithControls.Rows.Count > 0)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = dtUnitsWithControls.Compute("SUM(qty)", string.Empty);
                    drSchedule["tag"] = "";
                    drSchedule["item"] = "HMI";
                    drSchedule["model"] = "OJ-Air2-HMI";
                    drSchedule["voltage"] = "";
                    drSchedule["duct_connection"] = "N/A";
                    drSchedule["controls_preference"] = "";
                    drSchedule["installation"] = "";
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "SCR";
                    dtSchedule.Rows.Add(drSchedule);
                }
            }
            #endregion


            //
            var drIndoorUnit = dtIndoorUnit.AsEnumerable().Where(x => (Convert.ToInt32(x[ClsDBTC.location_id]) == ClsID.intLocationIndoorID));
            dtIndoorUnit = drIndoorUnit.Any() ? drIndoorUnit.CopyToDataTable() : new DataTable();
            bolIDU_Exisit = dtIndoorUnit.Rows.Count > 0 ? true : false;


            //
            var drOutdoorUnit = dtOutdoorUnit.AsEnumerable().Where(x => (Convert.ToInt32(x[ClsDBTC.location_id]) == ClsID.intLocationOutdoorID));
            dtOutdoorUnit = drOutdoorUnit.Any() ? drOutdoorUnit.CopyToDataTable() : new DataTable();
            bolODU_Exisit = dtOutdoorUnit.Rows.Count > 0 ? true : false;


            //
            var drDamper = dtDamper.AsEnumerable().Where(x => (Convert.ToInt32(x[ClsDBTC.damper_and_actuator_id]) == ClsID.intDamperActuatorNoCasingID));
            dtDamper = drDamper.Any() ? drDamper.CopyToDataTable() : new DataTable();
            bolDamperAndActuNoCasingExist = dtDamper.Rows.Count > 0 ? true : false;


            //
            var drDX_Coil = dtDX_Coil.AsEnumerable().Where(x => (Convert.ToInt32(x[ClsDBTC.cooling_comp_id]) == ClsID.intCompDX_ID));
            dtDX_Coil = drDX_Coil.Any() ? drDX_Coil.CopyToDataTable() : new DataTable();

            bolDX_CoilExist = dtDX_Coil.Rows.Count > 0 ? true : false;


            //
            var drElecCoilInCasing = dtElecCoilInCasing.AsEnumerable().Where(x => (Convert.ToInt32(x[ClsDBTC.preheat_comp_id]) == ClsID.intCompElecHeaterID ||
                                                                                  Convert.ToInt32(x[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID ||
                                                                                  Convert.ToInt32(x[ClsDBTC.reheat_comp_id]) == ClsID.intCompElecHeaterID));
            dtElecCoilInCasing = drElecCoilInCasing.Any() ? drElecCoilInCasing.CopyToDataTable() : new DataTable();
            drElecCoilInCasing = dtElecCoilInCasing.AsEnumerable().Where(x => (Convert.ToInt32(x[ClsDBTC.preheat_elec_heater_installation_id]) == ClsID.intElecHeaterInstallInCasingID ||
                                                                                  Convert.ToInt32(x[ClsDBTC.heating_elec_heater_installation_id]) == ClsID.intElecHeaterInstallInCasingID));
            dtElecCoilInCasing = drElecCoilInCasing.Any() ? drElecCoilInCasing.CopyToDataTable() : new DataTable();

            bolElecCoilInCasingExist = dtElecCoilInCasing.Rows.Count > 0 ? true : false;


            //
            var drElecCoilDuctMount = dtElecCoilDuctMount.AsEnumerable().Where(x => (Convert.ToInt32(x[ClsDBTC.preheat_comp_id]) == ClsID.intCompElecHeaterID ||
                                                                                  Convert.ToInt32(x[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID ||
                                                                                  Convert.ToInt32(x[ClsDBTC.reheat_comp_id]) == ClsID.intCompElecHeaterID));
            dtElecCoilDuctMount = drElecCoilDuctMount.Any() ? drElecCoilDuctMount.CopyToDataTable() : new DataTable();
            drElecCoilDuctMount = dtElecCoilDuctMount.AsEnumerable().Where(x => (Convert.ToInt32(x[ClsDBTC.preheat_elec_heater_installation_id]) == ClsID.intElecHeaterInstallDuctMountedID ||
                                                                                    Convert.ToInt32(x[ClsDBTC.heating_elec_heater_installation_id]) == ClsID.intElecHeaterInstallDuctMountedID));
            dtElecCoilDuctMount = drElecCoilDuctMount.Any() ? drElecCoilDuctMount.CopyToDataTable() : new DataTable();

            bolElecCoilDuctMountExist = dtElecCoilDuctMount.Rows.Count > 0 ? true : false;


            //
            var drHeatOrPostHeatElecCoilDuctMount = dtHeatPostHeatElecCoilDuctMount.AsEnumerable().Where(x => (Convert.ToInt32(x[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID ||
                                                                                                                Convert.ToInt32(x[ClsDBTC.reheat_comp_id]) == ClsID.intCompElecHeaterID));
            dtHeatPostHeatElecCoilDuctMount = drHeatOrPostHeatElecCoilDuctMount.Any() ? drHeatOrPostHeatElecCoilDuctMount.CopyToDataTable() : new DataTable();
            drHeatOrPostHeatElecCoilDuctMount = dtHeatPostHeatElecCoilDuctMount.AsEnumerable().Where(x => (Convert.ToInt32(x[ClsDBTC.heating_elec_heater_installation_id]) == ClsID.intElecHeaterInstallDuctMountedID));
            dtHeatPostHeatElecCoilDuctMount = drHeatOrPostHeatElecCoilDuctMount.Any() ? drHeatOrPostHeatElecCoilDuctMount.CopyToDataTable() : new DataTable();

            bolHeatOrPostHeatElecCoilDuctMountExist = dtElecCoilInCasing.Rows.Count > 0 ? true : false;
        }
        #endregion


        #region Notes
        private void setNotes(int _intJobID)
        {
            dtNotes = new DataTable();
            dtNotes.Columns.Add("notes_no", typeof(string));
            dtNotes.Columns.Add("notes", typeof(string));
            dtNotes.Columns.Add("is_bold", typeof(int)).DefaultValue = 0;
            DataRow drNotes;

            DataTable dtSavedSubmittalNotes = ClsDB.GetSavedSubmittalsNotes(_intJobID);

            foreach (DataRow dr in dtSavedSubmittalNotes.Rows)
            {
                drNotes = dtNotes.NewRow();
                drNotes["notes_no"] = dr["notes_no"].ToString();
                drNotes["notes"] = dr["notes"].ToString();
                dtNotes.Rows.Add(drNotes);
            }
        }
        #endregion


        #region ShippingNotes
        private void setShippingNotes(int _intJobID)
        {
            dtShippingNotes = new DataTable();
            dtShippingNotes.Columns.Add("shipping_notes_no", typeof(string));
            dtShippingNotes.Columns.Add("shipping_notes", typeof(string));
            dtShippingNotes.Columns.Add("is_bold", typeof(int)).DefaultValue = 0;
            DataRow drShippingNotes;

            DataTable dtSavedSubmittalShippingNotes = ClsDB.GetSavedSubmittalsShippingNotes(_intJobID);

            foreach (DataRow dr in dtSavedSubmittalShippingNotes.Rows)
            {
                drShippingNotes = dtShippingNotes.NewRow();
                drShippingNotes["shipping_notes_no"] = dr["shipping_notes_no"].ToString();
                drShippingNotes["shipping_notes"] = dr["shipping_notes"].ToString();
                dtShippingNotes.Rows.Add(drShippingNotes);
            }
        }
        #endregion


        private void ToBeDeletedIfNoUsefull(int _intJobID)
        {
            string strUnitModel = "";
            string strUnitModelValue = "";

            dtSchedule = new DataTable();
            dtSchedule.Columns.Add("qty", typeof(string));
            dtSchedule.Columns.Add("tag", typeof(string));
            dtSchedule.Columns.Add("item", typeof(string));
            dtSchedule.Columns.Add("model", typeof(string));
            dtSchedule.Columns.Add("voltage", typeof(string));
            //dtSchedule.Columns.Add("Duct Connection", typeof(string));
            dtSchedule.Columns.Add("controls_preference", typeof(string));
            dtSchedule.Columns.Add("installation", typeof(string));
            dtSchedule.Columns.Add("handing", typeof(string));
            //dtSchedule.Columns.Add("Controls", typeof(string));
            DataRow drSchedule;

            DataTable dtSavedUnits = ClsDB.GetSavedUnitsWithDetails(_intJobID);

            #region Preheat Electric Heater
            int intUnitNbr = 0;
            foreach (DataRow dr in dtSavedUnits.Rows)
            {
                ++intUnitNbr;
                if (Convert.ToInt32(dr["preheat_comp_id"]) == ClsID.intCompElecHeaterID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]);
                    drSchedule["tag"] = "PEH-" + intUnitNbr;
                    drSchedule["item"] = "Electric Pre-Heat";

                    switch (Convert.ToInt32(dr["ProductTypeID"]))
                    {
                        case ClsID.intProdTypeNovaID:
                            strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                            break;
                        case ClsID.intProdTypeVentumID:
                        case ClsID.intProdTypeVentumLiteID:
                            strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                            break;
                        default:
                            break;
                    }

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = dr["ElecHeatVoltage"].ToString();
                    //drSchedule["Duct connection"] = "N/A";
                    drSchedule["controls_preference"] = "SCR";
                    drSchedule["installation"] = dr["Orientation"].ToString();
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "SCR";
                    dtSchedule.Rows.Add(drSchedule);
                }
            }
            #endregion


            #region Heating Electric Heater
            intUnitNbr = 0;
            foreach (DataRow dr in dtSavedUnits.Rows)
            {
                ++intUnitNbr;
                if (Convert.ToInt32(dr["heating_comp_id"]) == ClsID.intCompElecHeaterID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]);
                    drSchedule["tag"] = "HEH-" + intUnitNbr;
                    drSchedule["item"] = "Electric Heating";

                    switch (Convert.ToInt32(dr["ProductTypeID"]))
                    {
                        case ClsID.intProdTypeNovaID:
                            strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                            break;
                        case ClsID.intProdTypeVentumID:
                        case ClsID.intProdTypeVentumLiteID:
                            strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                            break;
                        default:
                            break;
                    }

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = dr["ElecHeatVoltage"].ToString();
                    //drSchedule["Duct connection"] = "N/A";
                    drSchedule["controls_preference"] = "SCR";
                    drSchedule["installation"] = dr["Orientation"].ToString();
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "SCR";
                    dtSchedule.Rows.Add(drSchedule);
                }
            }
            #endregion


            #region Reheat Electric Heater
            intUnitNbr = 0;
            foreach (DataRow dr in dtSavedUnits.Rows)
            {
                ++intUnitNbr;

                if (Convert.ToInt32(dr["reheat_comp_id"]) == ClsID.intCompElecHeaterID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]);
                    drSchedule["tag"] = "REH-" + intUnitNbr;
                    drSchedule["item"] = "Electric Reheat";

                    switch (Convert.ToInt32(dr["ProductTypeID"]))
                    {
                        case ClsID.intProdTypeNovaID:
                            strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                            break;
                        case ClsID.intProdTypeVentumID:
                        case ClsID.intProdTypeVentumLiteID:
                            strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                            break;
                        default:
                            break;
                    }

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = dr["ElecHeatVoltage"].ToString();
                    //drSchedule["Duct connection"] = "N/A";
                    drSchedule["controls_preference"] = "SCR";
                    drSchedule["installation"] = dr["Orientation"].ToString();
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "SCR";
                    dtSchedule.Rows.Add(drSchedule);
                }
            }
            #endregion


            #region Preheat HWC
            intUnitNbr = 0;
            foreach (DataRow dr in dtSavedUnits.Rows)
            {
                ++intUnitNbr;
                if (Convert.ToInt32(dr["preheat_comp_id"]) == ClsID.intCompHWC_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]);
                    drSchedule["tag"] = "PHWC-" + intUnitNbr;
                    drSchedule["item"] = "HWC Pre-Heat";

                    switch (Convert.ToInt32(dr["ProductTypeID"]))
                    {
                        case ClsID.intProdTypeNovaID:
                            strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                            break;
                        case ClsID.intProdTypeVentumID:
                        case ClsID.intProdTypeVentumLiteID:
                            strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                            break;
                        default:
                            break;
                    }

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "N/A";
                    //drSchedule["Duct connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = dr["Orientation"].ToString();
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "N/A";
                    dtSchedule.Rows.Add(drSchedule);
                }
            }
            #endregion


            #region Preheat HWC Valve
            intUnitNbr = 0;
            foreach (DataRow dr in dtSavedUnits.Rows)
            {
                ++intUnitNbr;
                if (Convert.ToInt32(dr["preheat_comp_id"]) == ClsID.intCompHWC_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]);
                    drSchedule["tag"] = "PHWC-" + intUnitNbr;
                    drSchedule["item"] = "HWC Pre-Heat Valve";

                    //switch (Convert.ToInt32(dr["ProductTypeID"]))
                    //{
                    //    case ClsID.intProductTypeNovaID:
                    //        strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                    //        break;
                    //    case ClsID.intProductTypeVentumID:
                    //        strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                    //        break;
                    //    default:
                    //        break;
                    //}

                    drSchedule["model"] = dr["PreheatHWC_ValveType"].ToString(); ;
                    drSchedule["voltage"] = "N/A";
                    //drSchedule["Duct connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = "N/A";
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "N/A";
                    dtSchedule.Rows.Add(drSchedule);
                    break;
                }
            }
            #endregion


            #region Heating HWC
            intUnitNbr = 0;
            foreach (DataRow dr in dtSavedUnits.Rows)
            {
                ++intUnitNbr;
                if (Convert.ToInt32(dr["heating_comp_id"]) == ClsID.intCompHWC_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]);
                    drSchedule["tag"] = "HHWC-" + intUnitNbr;
                    drSchedule["item"] = "HWC Heating";

                    switch (Convert.ToInt32(dr["ProductTypeID"]))
                    {
                        case ClsID.intProdTypeNovaID:
                            strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                            break;
                        case ClsID.intProdTypeVentumID:
                        case ClsID.intProdTypeVentumLiteID:
                            strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                            break;
                        default:
                            break;
                    }

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "N/A";
                    //drSchedule["Duct connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = dr["Orientation"].ToString();
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "N/A";
                    dtSchedule.Rows.Add(drSchedule);
                }
            }
            #endregion


            #region Reheat HWC
            intUnitNbr = 0;
            foreach (DataRow dr in dtSavedUnits.Rows)
            {
                ++intUnitNbr;
                if (Convert.ToInt32(dr["reheat_comp_id"]) == ClsID.intCompHWC_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]);
                    drSchedule["tag"] = "RHWC-" + intUnitNbr;
                    drSchedule["item"] = "HWC Reheat";

                    switch (Convert.ToInt32(dr["ProductTypeID"]))
                    {
                        case ClsID.intProdTypeNovaID:
                            strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                            break;
                        case ClsID.intProdTypeVentumID:
                        case ClsID.intProdTypeVentumLiteID:
                            strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                            break;
                        default:
                            break;
                    }

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "N/A";
                    //drSchedule["Duct connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = dr["Orientation"].ToString();
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "N/A";
                    dtSchedule.Rows.Add(drSchedule);
                }
            }
            #endregion


            #region Cooling CWC
            intUnitNbr = 0;
            foreach (DataRow dr in dtSavedUnits.Rows)
            {
                ++intUnitNbr;
                if (Convert.ToInt32(dr["cooling_comp_id"]) == ClsID.intCompCWC_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]);
                    drSchedule["tag"] = "CCWC-" + intUnitNbr;
                    drSchedule["item"] = "CWC Cooling";

                    switch (Convert.ToInt32(dr["ProductTypeID"]))
                    {
                        case ClsID.intProdTypeNovaID:
                            strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                            break;
                        case ClsID.intProdTypeVentumID:
                        case ClsID.intProdTypeVentumLiteID:
                            strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                            break;
                        default:
                            break;
                    }

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "N/A";
                    //drSchedule["Duct connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = dr["Orientation"].ToString();
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "N/A";
                    dtSchedule.Rows.Add(drSchedule);
                }
            }
            #endregion


            #region Cooling DXC
            intUnitNbr = 0;
            foreach (DataRow dr in dtSavedUnits.Rows)
            {
                ++intUnitNbr;
                if (Convert.ToInt32(dr["cooling_comp_id"]) == ClsID.intCompDX_ID)
                {
                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]);
                    drSchedule["tag"] = "CDXC-" + intUnitNbr;
                    drSchedule["item"] = "DXC Cooling";

                    switch (Convert.ToInt32(dr["ProductTypeID"]))
                    {
                        case ClsID.intProdTypeNovaID:
                            strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                            break;
                        case ClsID.intProdTypeVentumID:
                        case ClsID.intProdTypeVentumLiteID:
                            strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                            break;
                        default:
                            break;
                    }

                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "N/A";
                    //drSchedule["Duct connection"] = "N/A";
                    drSchedule["controls_preference"] = "N/A";
                    drSchedule["installation"] = dr["Orientation"].ToString();
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "N/A";
                    dtSchedule.Rows.Add(drSchedule);
                }
            }
            #endregion


            #region Damper
            intUnitNbr = 0;
            foreach (DataRow dr in dtSavedUnits.Rows)
            {
                ++intUnitNbr;

                if (Convert.ToInt32(dr["damper_and_actuator_id"]) > 1)
                {

                    switch (Convert.ToInt32(dr["ProductTypeID"]))
                    {
                        case ClsID.intProdTypeNovaID:
                            strUnitModel = dr["NovaUnitModelDisCode"].ToString();
                            strUnitModelValue = dr["NovaUnitModelValue"].ToString();
                            break;
                        case ClsID.intProdTypeVentumID:
                        case ClsID.intProdTypeVentumLiteID:
                            strUnitModel = dr["VentumUnitModelDisCode"].ToString();
                            strUnitModelValue = dr["VentumUnitModelValue"].ToString();
                            break;
                        default:
                            break;
                    }

                    string strDamperSize = "";

                    DataTable dtDamperSize = ClsDB.get_dtLive(ClsDBT.strSelDamperSize);
                    var drDamperSize = dtDamperSize.AsEnumerable().Where(x => (Convert.ToInt32(x["is_bypass"]) == 0));
                    dtDamperSize = drDamperSize.Any() ? drDamperSize.CopyToDataTable() : new DataTable();
                    drDamperSize = dtDamperSize.AsEnumerable().Where(x => (Convert.ToInt32(x["product_type_id"]) == Convert.ToInt32(dr["ProductTypeID"])));
                    dtDamperSize = drDamperSize.Any() ? drDamperSize.CopyToDataTable() : new DataTable();
                    drDamperSize = dtDamperSize.AsEnumerable().Where(x => ((string)x["unit_model_value"] == strUnitModelValue));
                    dtDamperSize = drDamperSize.Any() ? drDamperSize.CopyToDataTable() : new DataTable();
                    drDamperSize = dtDamperSize.AsEnumerable().Where(x => (Convert.ToInt32(x["unit_orientation_id"]) == Convert.ToInt32(dr["OrientationID"])));
                    dtDamperSize = drDamperSize.Any() ? drDamperSize.CopyToDataTable() : new DataTable();

                    if (Convert.ToInt32(dr["LocationID"]) == ClsID.intLocationIndoorID)
                    {
                        drDamperSize = dtDamperSize.AsEnumerable().Where(x => (Convert.ToInt32(x["damper_and_actuator_id"]) == Convert.ToInt32(dr["DamperActuatorID"])));
                        dtDamperSize = drDamperSize.Any() ? drDamperSize.CopyToDataTable() : new DataTable();
                    }

                    if (dtDamperSize.Rows.Count > 0)
                    {
                        strDamperSize = "Size: " + Environment.NewLine + dtDamperSize.Rows[0]["width"].ToString() + "\" x " + dtDamperSize.Rows[0]["height"].ToString() + "\"";
                    }

                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]) * 1;
                    drSchedule["tag"] = "OAD-" + intUnitNbr;
                    drSchedule["item"] = "Damper & Actuator";
                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "24 VAC";
                    //drSchedule["Duct connection"] = strDamperSize;
                    drSchedule["controls_preference"] = "On/Off";
                    drSchedule["installation"] = dr["DamperActuator"].ToString();
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "On/Off";
                    dtSchedule.Rows.Add(drSchedule);


                    drSchedule = dtSchedule.NewRow();
                    drSchedule["qty"] = Convert.ToInt32(dr["Qty"]) * 1;
                    drSchedule["tag"] = "EAD-" + intUnitNbr;
                    drSchedule["item"] = "Damper & Actuator";
                    drSchedule["model"] = strUnitModel;
                    drSchedule["voltage"] = "24 VAC";
                    //drSchedule["Duct connection"] = strDamperSize;
                    drSchedule["controls_preference"] = "On/Off";
                    drSchedule["installation"] = dr["DamperActuator"].ToString();
                    drSchedule["handing"] = "";
                    //drSchedule["Controls"] = "On/Off";
                    dtSchedule.Rows.Add(drSchedule);

                }
            }
            #endregion

        }

        public DataTable dtSchedule { get; set; }

        public DataTable dtHeaderData { get; set; }

        public DataTable dtNotes { get; set; }

        public DataTable dtShippingNotes { get; set; }

        public bool bolIDU_Exisit { get; set; }

        public bool bolODU_Exisit { get; set; }
        public bool bolDX_CoilExist { get; set; }
        public bool bolDamperAndActuNoCasingExist { get; set; }
        public bool bolElecCoilInCasingExist { get; set; }
        public bool bolElecCoilDuctMountExist { get; set; }
        public bool bolHeatOrPostHeatElecCoilDuctMountExist { get; set; }

    }
}