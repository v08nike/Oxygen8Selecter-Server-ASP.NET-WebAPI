using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsCutsheetsPDF
    {
        public DataTable dtSelectionCutsheetList { get; set; }
        public string strCutsheetDX = "Oxygen8_VRV_Responsibility_Chart.pdf";
        public string strCutsheetElecHeaterDuctMounted = "Electric_Heater_Duct_Mounted.pdf";
        public string strCutsheetDamperindoor = "Oxygen8_Damper_Spec_Indoor.pdf";
        public string strCutsheetDamperOutdoor = "Oxygen8_Damper_Spec_Outdoor.pdf";
        public string strCutsheetDamperActuator = "Belimo_TF24_Datasheet.pdf";
        public string strStandarTermsAndConditons = "Oxygen8_Standard_Terms_and_Conditions.pdf";
        public string strCutsheetVoltageSelectTable = "Voltage_Selection_Table.pdf";
        public string strCutsheetVoltageSelectTableSinglePhase = "Voltage_Selection_Table_Single_Phase.pdf";
        public string strCutsheetVoltageSelectTableThreePhase = "Voltage_Selection_Table_Three_Phase.pdf";
        public string strCutsheetOJ_Air2_HMI_35T = "OJ_Air2_HMI_35T.pdf";
        public string strCutsheetBACnetModbusProtocolPointsList = "Nova_BACnet_Modbus_Protocol_Points_List.pdf";
        public string strCtrlPointDiagram = "";

        public ClsCutsheetsPDF()
        {
            setCutsheets();
        }

        public ClsCutsheetsPDF(int _intUAL, int _intJobID, int _intUnitNo)
        {
            //DataTable dt = ClsDB.GetSavedUnit(_intJobID, _intUnitNo);
            setCutsheets();
            dtSelectionCutsheetList = get_dtSelectionCutsheetsList(_intUAL, _intJobID, _intUnitNo);
            //get_strControlDiagram( _intUAL,  _intJobID, _intUnitNo);
        }


        private void setCutsheets()
        {
            strCutsheetDX_PathAndFile = ClsGV.strLocCutsheetsSubmittals + "/" + strCutsheetDX;
            strCutsheetElecHeaterDuctMountedPathAndFile = ClsGV.strLocCutsheetsSubmittals + "/" + strCutsheetElecHeaterDuctMounted;
            strCutsheetDamperActuatorPathAndFile = ClsGV.strLocCutsheetsSubmittals + "/" + strCutsheetDamperActuator;
            strCutsheetDamperindoorPathAndFile = ClsGV.strLocCutsheetsSubmittals + "/" + strCutsheetDamperindoor;
            strCutsheetDamperOutdoorPathAndFile = ClsGV.strLocCutsheetsSubmittals + "/" + strCutsheetDamperOutdoor;
            strStandarTermsAndConditonsPathAndFile = ClsGV.strLocCutsheetsSubmittals + "/" + strStandarTermsAndConditons;
            strCutsheetVoltageSelectTablePathAndFile = ClsGV.strLocCutsheetsSubmittals + "/" + strCutsheetVoltageSelectTable;
            strCutsheetVoltageSelectTableSinglePhasePathAndFile = ClsGV.strLocCutsheetsSubmittals + "/" + strCutsheetVoltageSelectTableSinglePhase;
            strCutsheetVoltageSelectTableThreePhasePathAndFile = ClsGV.strLocCutsheetsSubmittals + "/" + strCutsheetVoltageSelectTableThreePhase;
            strCutsheetOJ_Air2_HMI_35TPathAndFile = ClsGV.strLocCutsheetsSubmittals + "/" + strCutsheetOJ_Air2_HMI_35T;
            strCutsheetBACnetModbusProtocolPointsListPathAndFile = ClsGV.strLocCutsheetsSubmittals + "/" + strCutsheetBACnetModbusProtocolPointsList;
        }


        private DataTable get_dtSelectionCutsheetsList(int _intUAL, int _intJobID, int _intUnitNo)
        {
            DataTable dtUnitCutsheets = ClsDB.GetSavedUnitWithDetails(_intJobID, _intUnitNo);
            DataSet dsSavedUnitItems = ClsDB.GetSavedUnitItems(_intJobID, _intUnitNo);
            DataRow drGeneral = dsSavedUnitItems.Tables[ClsDBT.strSavGeneral].Rows[0];
            DataRow drCompOpt = dsSavedUnitItems.Tables[ClsDBT.strSavCompOption].Rows[0];
            //DataRow drUnitModel = dsSavedUnitItems.Tables["UnitModel"].Rows[0];
            //DataRow drVoltage = dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0];

            DataRow drUnitCutsheets = dtUnitCutsheets.Rows[0];
            DataRow drControlsWiring = dtUnitCutsheets.Rows[0];



            string strCutsheetFile = "";




            DataTable dtCutsheetList = new DataTable();
            dtCutsheetList.Columns.Add("PathAndFile", typeof(string));
            dtCutsheetList.Columns.Add("File", typeof(string));


            DataRow drCutsheetList;
            strCutsheetFile = "";


            if (Convert.ToInt32(drGeneral[ClsDBTC.product_type_id]) == ClsID.intProdTypeVentumLiteID)
            {
                //DataTable dtPreheatEC = ClsDB.get_dtLive(ClsDBT.strSelVentumLiteElectricHeaterModel);
                //var drHeatingEC = dtPreheatEC.AsEnumerable().Where(x => ((string)x["unit_model"] == dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString()));
                //dtPreheatEC = drHeatingEC.Any() ? drHeatingEC.CopyToDataTable() : new DataTable();
                //drHeatingEC = dtPreheatEC.AsEnumerable().Where(x => (Convert.ToInt32(x["volt"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["volt"])));
                //dtPreheatEC = drHeatingEC.Any() ? drHeatingEC.CopyToDataTable() : new DataTable();
                //drHeatingEC = dtPreheatEC.AsEnumerable().Where(x => (Convert.ToInt32(x["phase"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["phase"])));
                //dtPreheatEC = drHeatingEC.Any() ? drHeatingEC.CopyToDataTable() : new DataTable();
                //drHeatingEC = dtPreheatEC.AsEnumerable().Where(x => (Convert.ToInt32(x["standard_coil_no"]) == Convert.ToInt32(drCompOpt[ClsDBTC.preheat_elec_heater_std_coil_no])));
                //dtPreheatEC = drHeatingEC.Any() ? drHeatingEC.CopyToDataTable() : new DataTable();

                string strUnitModel = dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString();
                int intElecHeaterVolt = Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["volt"]);
                int intElecHeaterPhase = Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["phase"]);
                int intElecHeaterStdCoilNo = Convert.ToInt32(drCompOpt[ClsDBTC.preheat_elec_heater_std_coil_no]);


            }
            else
            {
                if (Convert.ToInt32(drCompOpt["preheat_comp_id"]) == ClsID.intCompElecHeaterID &&
                    Convert.ToInt32(drCompOpt["preheat_elec_heater_installation_id"]) == ClsID.intElecHeaterInstallDuctMountedID)
                {
                    drCutsheetList = dtCutsheetList.NewRow();
                    //strCutsheetFile = "Electric_Heater_Duct_Mounted.pdf";
                    drCutsheetList["PathAndFile"] = strCutsheetElecHeaterDuctMountedPathAndFile;

                    //drCutsheetList["File"] = strCutsheetFile;
                    dtCutsheetList.Rows.Add(drCutsheetList);
                    strCutsheetFile = "";
                }
                else if ((Convert.ToInt32(drCompOpt["heating_comp_id"]) == ClsID.intCompElecHeaterID ||
                    Convert.ToInt32(drCompOpt["reheat_comp_id"]) == ClsID.intCompElecHeaterID) &&
                    Convert.ToInt32(drCompOpt["heat_elec_heater_installation_id"]) == ClsID.intElecHeaterInstallDuctMountedID)
                {
                    drCutsheetList = dtCutsheetList.NewRow();
                    //strCutsheetFile = "Electric_Heater_Duct_Mounted.pdf";
                    drCutsheetList["PathAndFile"] = strCutsheetElecHeaterDuctMountedPathAndFile;
                    //drCutsheetList["File"] = strCutsheetFile;
                    dtCutsheetList.Rows.Add(drCutsheetList);
                    strCutsheetFile = "";
                }
            }



            #region Controls Wiring
            string strCtrlPointDiagramFile = "";

            if (drControlsWiring != null)
            {
                //strCtrlPointDiagramFile = drControlsWiring["ControlsPrefCode"].ToString();
                //strCtrlPointDiagramFile += "_" + drControlsWiring["ProductTypeCode"].ToString();
                //strCtrlPointDiagramFile += Convert.ToInt32(drControlsWiring["IsBypass"]) == 1 ? "_BP" : "";


                //if (Convert.ToInt32(drUnitCutsheets["preheat_comp_id"]) == ClsID.intUnitHeatCoolElecHeaterID)
                //{
                //    strCtrlPointDiagramFile += "_PHEC";
                //}
                //else if (Convert.ToInt32(drUnitCutsheets["preheat_comp_id"]) == ClsID.intUnitHeatCoolHWC_ID)
                //{
                //    strCtrlPointDiagramFile += "_PHHWC";
                //}


                //if (Convert.ToInt32(drUnitCutsheets["cooling_comp_id"]) == ClsID.intUnitHeatCoolCWC_ID)
                //{
                //    strCtrlPointDiagramFile += "_CCWC";
                //}
                //else if (Convert.ToInt32(drUnitCutsheets["cooling_comp_id"]) == ClsID.intUnitHeatCoolDX_ID)
                //{
                //    strCtrlPointDiagramFile += "_CDXC";
                //}


                //if (Convert.ToInt32(drUnitCutsheets["reheat_comp_id"]) == ClsID.intUnitHeatCoolElecHeaterID)
                //{
                //    strCtrlPointDiagramFile += "_RHEC";
                //}
                //else if (Convert.ToInt32(drUnitCutsheets["reheat_comp_id"]) == ClsID.intUnitHeatCoolHWC_ID)
                //{
                //    strCtrlPointDiagramFile += "_RHHWC";
                //}
                //else if (Convert.ToInt32(drUnitCutsheets["heating_comp_id"]) == ClsID.intUnitHeatCoolElecHeaterID)
                //{
                //    strCtrlPointDiagramFile += "_HEC";
                //}
                //else if (Convert.ToInt32(drUnitCutsheets["heating_comp_id"]) == ClsID.intUnitHeatCoolHWC_ID)
                //{
                //    strCtrlPointDiagramFile += "_HHWC";
                //}


                //strCtrlPointDiagramFile += (Convert.ToInt32(drControlsWiring["damper_and_actuator_id"]) > 0 && Convert.ToInt32(drControlsWiring["damper_and_actuator_id"]) != ClsID.intDamperActuatorNA_ID) ? "_D" : "";
                //strCtrlPointDiagramFile += ".pdf";


                if (_intUAL == ClsID.intUAL_Admin || _intUAL == ClsID.intUAL_IntAdmin || _intUAL == ClsID.intUAL_IntLvl_2 || _intUAL == ClsID.intUAL_IntLvl_1)
                {
                    strCtrlPointDiagramFile = get_strControlDiagram(_intUAL, _intJobID, _intUnitNo);
                    strCtrlPointDiagramPathAndFile = ClsGV.strLocCutsheetsSubmittals + "/ControlsPointDiagram/" + strCtrlPointDiagramFile;

                    drCutsheetList = dtCutsheetList.NewRow();
                    drCutsheetList["PathAndFile"] = strCtrlPointDiagramPathAndFile;
                    drCutsheetList["File"] = strCtrlPointDiagramFile;
                    //drCutsheetList["PathAndFile"] = ClsGV.strLocCutsheetsSubmittals + "/ControlsPointDiagram/CV_NOVA_BP_CCWC.pdf";
                    //drCutsheetList["File"] = "CV_NOVA_BP_CCWC.pdf";
                    dtCutsheetList.Rows.Add(drCutsheetList);

                }
            }
            #endregion

            //strPathAndFile = ;
            //strCtrlPointDiagramPathAndFile = ClsGV.strLocCutsheetsSubmittals + "/ControlsPointDiagram/" + get_strControlDiagram(intUAL, intJobID, Convert.ToInt32(dtUnitList.Rows[i]["unit_no"]));


            if (Convert.ToInt32(drCompOpt["cooling_comp_id"]) == ClsID.intCompDX_ID)
            {
                drCutsheetList = dtCutsheetList.NewRow();
                //strCutsheetFile = "Oxygen8_VRV_Responsibility_Chart.pdf";
                drCutsheetList["PathAndFile"] = strCutsheetDX_PathAndFile;
                drCutsheetList["File"] = strCutsheetDX; ;
                dtCutsheetList.Rows.Add(drCutsheetList);
                strCutsheetFile = "";
            }


            if (Convert.ToInt32(drCompOpt["damper_and_actuator_id"]) == ClsID.intDamperActuatorNoCasingID)
            {
                //drCutsheetList = dtCutsheetList.NewRow();
                //strDwgFile = "Dampers_Unit_Mounted_In_Field.pdf";
                //drCutsheetList["PathAndFile"] = ClsGV.strLocCutsheets + "/" + strDwgFile;
                //drCutsheetList["File"] = strDwgFile;
                //dtCutsheetList.Rows.Add(drCutsheetList);
                //strDwgFile = "";


                if (Convert.ToInt32(drUnitCutsheets["LocationID"]) == ClsID.intLocationIndoorID)
                {
                    drCutsheetList = dtCutsheetList.NewRow();
                    //strCutsheetFile = "Oxygen8_Damper_Spec_Indoor.pdf";
                    drCutsheetList["PathAndFile"] = strCutsheetDamperindoorPathAndFile;
                    drCutsheetList["File"] = strCutsheetDamperindoor;
                    dtCutsheetList.Rows.Add(drCutsheetList);
                    strCutsheetFile = "";
                }


                if (Convert.ToInt32(drUnitCutsheets["LocationID"]) == ClsID.intLocationOutdoorID)
                {
                    drCutsheetList = dtCutsheetList.NewRow();
                    //strCutsheetFile = "Oxygen8_Damper_Spec_Outdoor.pdf";
                    drCutsheetList["PathAndFile"] = strCutsheetDamperOutdoorPathAndFile;
                    drCutsheetList["File"] = strCutsheetDamperOutdoor;
                    dtCutsheetList.Rows.Add(drCutsheetList);
                    strCutsheetFile = "";
                }


                drCutsheetList = dtCutsheetList.NewRow();
                //strCutsheetFile = "Belimo_TF24_Datasheet.pdf";
                drCutsheetList["PathAndFile"] = strCutsheetDamperActuatorPathAndFile;
                drCutsheetList["File"] = strCutsheetDamperActuator;
                dtCutsheetList.Rows.Add(drCutsheetList);
                strCutsheetFile = "";
            }





            //drCutsheetList = dtCutsheetList.NewRow();
            //strDwgFile = "Oxygen8_Standard_Terms_and_Conditions.pdf";
            //drCutsheetList["PathAndFile"] = ClsGV.strLocCutsheets + "/" + strDwgFile;
            //drCutsheetList["File"] = strDwgFile;
            //dtCutsheetList.Rows.Add(drCutsheetList);
            //strDwgFile = "";


            return dtCutsheetList;
        }




        public string get_strControlDiagram(int _intUAL, int _intJobID, int _intUnitNo)
        {
            DataTable dtUnitCutsheets = ClsDB.GetSavedUnitWithDetails(_intJobID, _intUnitNo);
            DataSet dsUnitItems = ClsDB.GetSavedUnitItems(_intJobID, _intUnitNo);
            DataRow drGeneral = dsUnitItems.Tables[ClsDBT.strSavGeneral].Rows[0];
            DataRow drComp = dsUnitItems.Tables[ClsDBT.strSavCompOption].Rows[0];

            DataRow drUnitCutsheets = dtUnitCutsheets.Rows[0];
            DataRow drControlsWiring = dtUnitCutsheets.Rows[0];


            #region Controls Wiring
            string strCtrlPointDiagramFile = "";

            if (drControlsWiring != null)
            {
                if (Convert.ToInt32(drControlsWiring["ControlsPrefID"]) != ClsID.intControlPrefByOthersID)
                {
                    strCtrlPointDiagramFile = drControlsWiring["ControlsPrefCode"].ToString();
                    strCtrlPointDiagramFile += "_" + drControlsWiring["ProductTypeCode"].ToString();
                    strCtrlPointDiagramFile += Convert.ToInt32(drControlsWiring["IsBypass"]) == 1 ? "_BP" : "";


                    if (Convert.ToInt32(drUnitCutsheets["preheat_comp_id"]) == ClsID.intCompElecHeaterID)
                    {
                        strCtrlPointDiagramFile += "_PHEC";
                    }
                    else if (Convert.ToInt32(drUnitCutsheets["preheat_comp_id"]) == ClsID.intCompHWC_ID)
                    {
                        strCtrlPointDiagramFile += "_PHHWC";
                    }


                    if (Convert.ToInt32(drUnitCutsheets["cooling_comp_id"]) == ClsID.intCompCWC_ID)
                    {
                        strCtrlPointDiagramFile += "_CCWC";
                    }
                    else if (Convert.ToInt32(drUnitCutsheets["cooling_comp_id"]) == ClsID.intCompDX_ID)
                    {
                        strCtrlPointDiagramFile += "_CDXC";
                    }


                    if (Convert.ToInt32(drUnitCutsheets["reheat_comp_id"]) == ClsID.intCompElecHeaterID)
                    {
                        strCtrlPointDiagramFile += "_RHEC";
                    }
                    else if (Convert.ToInt32(drUnitCutsheets["reheat_comp_id"]) == ClsID.intCompHWC_ID)
                    {
                        strCtrlPointDiagramFile += "_RHHWC";
                    }
                    else if (Convert.ToInt32(drUnitCutsheets["heating_comp_id"]) == ClsID.intCompElecHeaterID)
                    {
                        strCtrlPointDiagramFile += "_HEC";
                    }
                    else if (Convert.ToInt32(drUnitCutsheets["heating_comp_id"]) == ClsID.intCompHWC_ID)
                    {
                        strCtrlPointDiagramFile += "_HHWC";
                    }


                    strCtrlPointDiagramFile += (Convert.ToInt32(drControlsWiring["damper_and_actuator_id"]) > 0 && Convert.ToInt32(drControlsWiring["damper_and_actuator_id"]) != ClsID.intDamperActuatorNA_ID) ? "_D" : "";
                    strCtrlPointDiagramFile += ".pdf";

                    string strFilePath = ClsGV.strLocCutsheetsSubmittals + "/ControlsPointDiagram/" + strCtrlPointDiagramFile;


                    if (_intUAL == ClsID.intUAL_Admin || _intUAL == ClsID.intUAL_IntAdmin || _intUAL == ClsID.intUAL_IntLvl_2 || _intUAL == ClsID.intUAL_IntLvl_1)
                    {
                        //drCutsheetList = dtCutsheetList.NewRow();
                        //drCutsheetList["PathAndFile"] = ClsGV.strLocCutsheetsSubmittals + "/ControlsPointDiagram/" + strCtrlPointDiagramFile;
                        //drCutsheetList["File"] = strCtrlPointDiagramFile;
                        ////drCutsheetList["PathAndFile"] = ClsGV.strLocCutsheetsSubmittals + "/ControlsPointDiagram/CV_NOVA_BP_CCWC.pdf";
                        ////drCutsheetList["File"] = "CV_NOVA_BP_CCWC.pdf";
                        //dtCutsheetList.Rows.Add(drCutsheetList);


                        strCutsheetCtrlPointDiagramFile = strCtrlPointDiagramFile;
                    }
                }
            }
            #endregion


            return strCutsheetCtrlPointDiagramFile;
        }





        public string strCutsheetCtrlPointDiagramFile { get; set; }
        public string strCutsheetDX_PathAndFile { get; set; }
        public string strCutsheetElecHeaterDuctMountedPathAndFile { get; set; }
        public string strCutsheetDamperindoorPathAndFile { get; set; }
        public string strCutsheetDamperOutdoorPathAndFile { get; set; }
        public string strCutsheetDamperActuatorPathAndFile { get; set; }
        public string strStandarTermsAndConditonsPathAndFile { get; set; }
        public string strCutsheetVoltageSelectTablePathAndFile { get; set; }
        public string strCutsheetVoltageSelectTableSinglePhasePathAndFile { get; set; }
        public string strCutsheetVoltageSelectTableThreePhasePathAndFile { get; set; }
        public string strCutsheetOJ_Air2_HMI_35TPathAndFile { get; set; }
        public string strCutsheetBACnetModbusProtocolPointsListPathAndFile { get; set; }
        public string strCtrlPointDiagramPathAndFile { get; set; }
    }
}