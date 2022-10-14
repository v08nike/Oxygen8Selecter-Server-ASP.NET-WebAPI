using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsDrawing
    {
        private ClsGeneral objGen;
        private DataSet dsSavedUnitItems = new DataSet();
        private DataTable dtSavedUnitGeneral = new DataTable();
        private DataRow drSavedUnit;
        //private DataTable dtCompOpt = new DataTable();
        private DataRow drCompOpt;

        private string strNomen = "";
        private string strDwgFile = "";
        private string strDwgPath = "";
        private string strUnitImageWithPath = "";
        private string strDwgFileWithPath = "";
        private string strSF_Position = "";

        //string strUnitLocation = Convert.ToInt32(drUnitDwg["location_id"]) == ClsID.intLocationIndoorID ? "Indoor" : "Outdoor";
        private int intLocationID = 0;
        private string strModelDwgCode = "";
        private string strUnitHandingDwgCode = "";
        private string strPreheatCoilHandingDwgCode = "";
        private string strCoolingCoilHandingDwgCode = "";
        private string strHeatingCoilHandingDwgCode = "";
        private string strUnitDwgCode = "";
        private string strOriDwgCodeAccessory = "";
        private string strOriDwgCodeAccessory_2 = "";
        private string strLocationDwgCode = "";
        private string strUnitTypeDwgCode = "";

        private string strBypassDwgCode = "";
        private string strDrainPan = "";
        private string strUnitCoupledAccessory = "";
        private string strRevision = "B";
        private string strDwgCodeCasing = "";
        private string strDwgCodeHW_EC_Casing = "";
        private string strComboTypeDwgCode = "";
        private string strVoltageDwgCode = "";
        private string strPreheatEC_KW_DwgCode = "";
        private string strPostHeatEC_KW_DwgCode = "";
        private string strDX_CapDwgCode = "";
        private string strEC_Nomen = "";
        private string strCombinedEC_DwgCode = "";
        private string strTerraSizeDwgCode = "";
        private int intTerraSize = 0;


        private int intIsDownshot = 0;
        private int intIsBypass = 0;



        public string strDwgNomenc { get; set; }

        public string strUnitEpicorPartDesc { get; set; }
        public double dblDamperPartDesc { get; set; }
        public double dblAccessSectionPartDesc { get; set; }
        public string strPreheatElecHeaterEpicorPartDesc { get; set; }
        public string strHeatingElecHeaterEpicorPartDesc { get; set; }
        public string strReheatElecHeaterEpicorPartDesc { get; set; }
        public string strPreheatHWC_EpicorPartDesc { get; set; }
        public string strHeatingHWC_EpicorPartDesc { get; set; }
        public string strReheatHWC_EpicorPartDesc { get; set; }
        public string strCWC_EpicorPartDesc { get; set; }
        public string strDXC_EpicorPartDesc { get; set; }
        public double dblSenosrControlsPrefPartDesc { get; set; }
        public double dblSensorCoolingPartDesc { get; set; }
        public double dblSensorHeatingPartDesc { get; set; }
        public double dblSensorDehumReheatPartDesc { get; set; }
        public double dblSensorDehumNoReheatPartDesc { get; set; }


        public string strUnitEpicorPartNbr { get; set; }
        public double dblDamperPartNbr { get; set; }
        public double dblAccessSectionPartNbr { get; set; }
        public string strPreheatElecHeaterEpicorPartNbr { get; set; }
        public string strHeatingElecHeaterEpicorPartNbr { get; set; }
        public string strReheatElecHeaterEpicorPartNbr { get; set; }
        public string strPreheatHWC_EpicorPartNbr { get; set; }
        public string strHeatingHWC_EpicorPartNbr { get; set; }
        public string strReheatHWC_EpicorPartNbr { get; set; }
        public string strCWC_EpicorPartNbr { get; set; }
        public string strDXC_EpicorPartNbr { get; set; }
        public double dblSenosrControlsPrefPartNbr { get; set; }
        public double dblSensorCoolingPartNbr { get; set; }
        public double dblSensorHeatingPartNbr { get; set; }
        public double dblSensorDehumReheatPartNbr { get; set; }
        public double dblSensorDehumNoReheatPartNbr { get; set; }


        public DataTable dtDrawingList { get; set; }

        private DataTable dtEpicorPartNbr = new DataTable();

        public ClsDrawing()
        {
        }

        public ClsDrawing(int _intJobID, int _intUnitNo)
        {
            objGen = new ClsGeneral(_intJobID, _intUnitNo);
            dsSavedUnitItems = objGen.dsSavedUnitItems;
            dtSavedUnitGeneral = dsSavedUnitItems.Tables[ClsDBT.strSavGeneral];
            drSavedUnit = dtSavedUnitGeneral.Rows[0];
            drCompOpt = dsSavedUnitItems.Tables[ClsDBT.strSavCompOption].Rows[0];

            dtEpicorPartNbr = ClsDB.get_dtLive(ClsDBT.sel_epicor_part_number);

            strUnitDwgCode = dsSavedUnitItems.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["dwg_code"].ToString();
            strUnitHandingDwgCode = dsSavedUnitItems.Tables[ClsDBT.strSelHanding].Rows[0]["dwg_code"].ToString();
            strPreheatCoilHandingDwgCode = dsSavedUnitItems.Tables["PreheatCoilHanding"].Rows[0]["dwg_code"].ToString();
            strCoolingCoilHandingDwgCode = dsSavedUnitItems.Tables["CoolingCoilHanding"].Rows[0]["dwg_code"].ToString();
            strHeatingCoilHandingDwgCode = dsSavedUnitItems.Tables["HeatingCoilHanding"].Rows[0]["dwg_code"].ToString();
            strOriDwgCodeAccessory = strOriDwgCodeAccessory.Length > 1 ? strOriDwgCodeAccessory.Remove(1) : strOriDwgCodeAccessory;
            strOriDwgCodeAccessory_2 = strUnitDwgCode;
            strLocationDwgCode = dsSavedUnitItems.Tables[ClsDBT.strSelGeneralLocation].Rows[0]["dwg_code"].ToString();
            strVoltageDwgCode = dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["volt"].ToString() + dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["phase"].ToString();
            intIsDownshot = Convert.ToInt32(drSavedUnit[ClsDBTC.is_downshot]);
            intIsBypass = Convert.ToInt32(drSavedUnit[ClsDBTC.is_bypass]);
            strBypassDwgCode = Convert.ToInt32(drSavedUnit[ClsDBTC.is_bypass]) == 1 ? "B" : "S";
            strUnitTypeDwgCode = dsSavedUnitItems.Tables[ClsDBT.strSelUnitType].Rows[0]["dwg_code"].ToString(); ;
            strDrainPan = Convert.ToInt32(drCompOpt[ClsDBTC.is_drain_pan]) == 1 ? "DP" : "ND";
            intLocationID = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]);


            strUnitHandingDwgCode = strUnitHandingDwgCode.Replace("H", "");
            strPreheatCoilHandingDwgCode = strPreheatCoilHandingDwgCode.Replace("H", "");
            strCoolingCoilHandingDwgCode = strCoolingCoilHandingDwgCode.Replace("H", "");
            strHeatingCoilHandingDwgCode = strHeatingCoilHandingDwgCode.Replace("H", "");


            if (dtSavedUnitGeneral.Rows.Count > 0)
            {
                int intProductTypeID = Convert.ToInt32(drSavedUnit[ClsDBTC.product_type_id]);
                strModelDwgCode = dsSavedUnitItems.Tables["UnitModel"].Rows[0]["dwg_code"].ToString();

                switch (intProductTypeID)
                {
                    case ClsID.intProdTypeNovaID:
                        strDwgPath = ClsGV.strLocDrawings + "\\Nova";
                        strDwgPath += Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationOutdoorID ? "\\Outdoor" : "\\Indoor";
                        strSF_Position = (dsSavedUnitItems.Tables[ClsDBT.strSelOpeningsERV_SA].Rows[0]["dwg_code"].ToString() == "1" || dsSavedUnitItems.Tables[ClsDBT.strSelOpeningsERV_SA].Rows[0]["dwg_code"].ToString() == "1A") ? "S1" : "S2";
                        dtDrawingList = get_dtNovaDrawingList(_intJobID, _intUnitNo);
                        break;
                    default:
                        break;
                }

                setEpicorPartNumber();
            }
        }



        #region Nova Drawing List
        private DataTable get_dtNovaDrawingList(int _intJobID, int _intUnitNo)
        {
            string strNovaUnitModelValue = dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString();
            string strCoupledDwgCode = strModelDwgCode;
            string strDecoupledDwgCode = strModelDwgCode;
            string strElecCoilDwgCode = strModelDwgCode;

            strBypassDwgCode = "S";

            if (intIsBypass == 1)
            {
                strBypassDwgCode = "B";

                DataTable dtModelBypassAccs = ClsDB.get_dtByValue(ClsDBT.strSelNovaUnitModelBypassAccs, "model_value", strNovaUnitModelValue);

                if (dtModelBypassAccs.Rows.Count > 0)
                {
                    strModelDwgCode = dtModelBypassAccs.Rows[0]["model_bypass_dwg_code"].ToString();
                    strCoupledDwgCode = dtModelBypassAccs.Rows[0]["coupled_dwg_code"].ToString();
                    strElecCoilDwgCode = dtModelBypassAccs.Rows[0]["electric_coil_dwg_code"].ToString();
                    strDecoupledDwgCode = dtModelBypassAccs.Rows[0]["decoupled_dwg_code"].ToString();
                }
            }




            //string strDwgFile = "";

            //string strUnitImageWithPath = "";
            string[] arrOpeningCode = new string[4];

            //strSF_Position = (drUnitDwg["OpeningSA_DwgCode"].ToString() == "1" || drUnitDwg["OpeningSA_DwgCode"].ToString() == "1A") ? "_S1_" : "_S2_";


            DataTable dtDrawingList = new DataTable();
            dtDrawingList.Columns.Add("DwgPathAndFile", typeof(string));
            dtDrawingList.Columns.Add("DwgFile", typeof(string));

            DataRow drDwgList = dtDrawingList.NewRow();

            //strDrainPan = intIsBypass == 1  ? "ND" : "C";


            string strDwgCodeOutdoor = dsSavedUnitItems.Tables[ClsDBT.strSelOpeningsERV_OA].Rows[0]["dwg_code"].ToString();


            if (Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationOutdoorID)
            {
                strDrainPan = "ND";

                string strDwgCodeOutdoorPreheat = "";

                if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompHWC_ID)
                {
                    strDwgCodeOutdoorPreheat = "H";
                }
                else if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompElecHeaterID)
                {
                    if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_elec_heater_installation_id]) == ClsID.intElecHeaterInstallInCasingID)
                    {
                        strDwgCodeOutdoorPreheat = "E";
                    }
                }

                strDwgCodeOutdoor += strDwgCodeOutdoorPreheat;
            }


            arrOpeningCode[0] = dsSavedUnitItems.Tables[ClsDBT.strSelOpeningsERV_SA].Rows[0]["dwg_code"].ToString();
            arrOpeningCode[1] = dsSavedUnitItems.Tables[ClsDBT.strSelOpeningsERV_EA].Rows[0]["dwg_code"].ToString();
            arrOpeningCode[2] = dsSavedUnitItems.Tables[ClsDBT.strSelOpeningsERV_RA].Rows[0]["dwg_code"].ToString();
            arrOpeningCode[3] = strDwgCodeOutdoor;


            Array.Sort(arrOpeningCode);


            if (intIsDownshot == 1)
            {
                arrOpeningCode[1] = arrOpeningCode[1].ToString().PadRight(2, 'D');
                arrOpeningCode[3] = arrOpeningCode[3].ToString().PadRight(2, 'D');
            }


            arrOpeningCode[0] = arrOpeningCode[0].ToString().PadLeft(2, '0');
            arrOpeningCode[1] = arrOpeningCode[1].ToString().PadLeft(2, '0');
            arrOpeningCode[2] = arrOpeningCode[2].ToString().PadLeft(2, '0');
            arrOpeningCode[3] = arrOpeningCode[3].ToString().PadLeft(2, '0');


            string strUnitCode = "NOVA_" + strModelDwgCode + "_ERV_" +
                                    strBypassDwgCode + "_" +
                                    strLocationDwgCode + "_" +
                                    strUnitHandingDwgCode + "_" +
                                    strUnitDwgCode + "_" +
                                    strSF_Position + "_" +
                                    strDrainPan + "_" +
                                    arrOpeningCode[0] + "_" + arrOpeningCode[1] + "_" +
                                    arrOpeningCode[2] + "_" + arrOpeningCode[3];


            //For Outdoor unit with Downshot option the accessories should be indoor

            strUnitEpicorPartDesc = strUnitCode + "_" + strVoltageDwgCode + "_" + dsSavedUnitItems.Tables["OA_FilterModel"].Rows[0]["merv"].ToString().PadLeft(2, '0') + "_" + dsSavedUnitItems.Tables["RA_FilterModel"].Rows[0]["merv"].ToString().PadLeft(2, '0');

            //strDwgFile = intIsDownshot == 1 ? strUnitCode + "_B.jpg" : strUnitCode + "_A.jpg";
            strDwgFile = intIsDownshot == 1 ? strUnitCode + "_B.jpg" : strUnitCode + "_B.jpg";

            string strImageName = strDwgPath + "\\Unit\\" + strDwgFile;


            if (File.Exists(HttpContext.Current.Server.MapPath(strImageName)))
            {
                strUnitImageWithPath = strImageName;
            }
            else
            {
                DataTable dtModel = ClsDB.get_dtByID(ClsDBT.strSelNovaUnitModel, Convert.ToInt32(drSavedUnit[ClsDBTC.unit_model_id]));

                if (dtModel.Rows.Count > 0)
                {
                    strUnitImageWithPath = "Images/" + dtModel.Rows[0]["image_name"].ToString() + ".jpg";
                }
            }


            drDwgList = dtDrawingList.NewRow();
            drDwgList["DwgPathAndFile"] = strUnitImageWithPath;
            drDwgList["DwgFile"] = strDwgFile;
            dtDrawingList.Rows.Add(drDwgList);
            strDwgFile = "";



            if (intIsDownshot == 1)
            {
                string str_DownshotRoofCurb = "NOVA_" + strModelDwgCode;
                str_DownshotRoofCurb += intIsBypass == 1 ? "_Downshot_Bypass_Roof_Curb.jpg" : "_Downshot_Roof_Curb.jpg";

                drDwgList = dtDrawingList.NewRow();
                drDwgList["DwgPathAndFile"] = strDwgPath + "\\Unit\\" + str_DownshotRoofCurb;
                drDwgList["DwgFile"] = str_DownshotRoofCurb;
                dtDrawingList.Rows.Add(drDwgList);
                strDwgFile = "";

                strLocationDwgCode = "I";   //For Outdoor unit with Downshot option the accessories should be indoor
                strDwgPath = ClsGV.strLocDrawings + "\\Nova\\Indoor";       //For Outdoor unit with Downshot option the accessories should be indoor

                DataTable dtIndoorEqv = ClsDB.get_dtByValue(ClsDBT.strSelNovaUnitModelDownshotIndoorEqv, "outdoor_dwg_code", strModelDwgCode);
                if (dtIndoorEqv.Rows.Count > 0)
                {
                    strModelDwgCode = dtIndoorEqv.Rows[0]["indoor_dwg_code"].ToString();
                }
            }


            double dblKW_1 = 0d;
            double dblKW_2 = 0d;
            double dblKW_Max = 0;


            //if (_objContElem != null && _objContElem.objCHeatingElecHeater != null)
            if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_elec_heater_std_coil_no]) > 0)
            {
                DataTable dtHeatingEC = ClsDB.get_dtLive(ClsDBT.strSelNovaElectricHeaterModel);
                var drHeatingEC = dtHeatingEC.AsEnumerable().Where(x => ((string)x["unit_model"] == dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString()));
                dtHeatingEC = drHeatingEC.Any() ? drHeatingEC.CopyToDataTable() : new DataTable();
                drHeatingEC = dtHeatingEC.AsEnumerable().Where(x => (Convert.ToInt32(x["volt"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["volt"])));
                dtHeatingEC = drHeatingEC.Any() ? drHeatingEC.CopyToDataTable() : new DataTable();
                drHeatingEC = dtHeatingEC.AsEnumerable().Where(x => (Convert.ToInt32(x["phase"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["phase"])));
                dtHeatingEC = drHeatingEC.Any() ? drHeatingEC.CopyToDataTable() : new DataTable();
                drHeatingEC = dtHeatingEC.AsEnumerable().Where(x => (Convert.ToInt32(x["standard_coil_no"]) == Convert.ToInt32(drCompOpt[ClsDBTC.heating_elec_heater_std_coil_no])));
                dtHeatingEC = drHeatingEC.Any() ? drHeatingEC.CopyToDataTable() : new DataTable();

                dblKW_1 = Convert.ToInt32(dtHeatingEC.Rows[0]["kw"]);

                //dblKW_1 = _objContElem.objCHeatingElecHeater.objElecHeaterIO.dblKW_Max;
            }

            //if (_objContElem != null && _objContElem.objCReheatElecHeater != null)
            if (Convert.ToInt32(drCompOpt[ClsDBTC.reheat_elec_heater_std_coil_no]) > 0)
            {
                DataTable dtReheatEC = ClsDB.get_dtLive(ClsDBT.strSelNovaElectricHeaterModel);
                var drReheatEC = dtReheatEC.AsEnumerable().Where(x => ((string)x["unit_model"] == dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString()));
                dtReheatEC = drReheatEC.Any() ? drReheatEC.CopyToDataTable() : new DataTable();
                drReheatEC = dtReheatEC.AsEnumerable().Where(x => (Convert.ToInt32(x["volt"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["volt"])));
                dtReheatEC = drReheatEC.Any() ? drReheatEC.CopyToDataTable() : new DataTable();
                drReheatEC = dtReheatEC.AsEnumerable().Where(x => (Convert.ToInt32(x["phase"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["phase"])));
                dtReheatEC = drReheatEC.Any() ? drReheatEC.CopyToDataTable() : new DataTable();
                drReheatEC = dtReheatEC.AsEnumerable().Where(x => (Convert.ToInt32(x["standard_coil_no"]) == Convert.ToInt32(drCompOpt[ClsDBTC.reheat_elec_heater_std_coil_no])));
                dtReheatEC = drReheatEC.Any() ? drReheatEC.CopyToDataTable() : new DataTable();

                dblKW_2 = Convert.ToInt32(dtReheatEC.Rows[0]["kw"]);

                //dblKW_2 = _objContElem.objCReheatElecHeater.objElecHeaterIO.dblKW_Max;
            }


            dblKW_Max = Math.Max(dblKW_1, dblKW_2);

            if (dblKW_Max > 0)
            {
                strPostHeatEC_KW_DwgCode = dblKW_Max.ToString().PadLeft(2, '0');

                ////strEC_Nomen = "ACC_NOVA_" + strModelDwgCode + "_" + strLocationDwgCode + "_DC_" + strFanPlacementDwgCode.Replace("H", "") + "_EC_" + strVoltageDwgCode + "_" + strPostHeatEC_KW_DwgCode + "_A";   //ACC_NOVA_B20_I_DC_L_EC_2081_07_A
                //strEC_Nomen = "ACC_NOVA_" + strModelDwgCode + "_" + strLocationDwgCode + "_DC_" + strFanPlacementDwgCode.Replace("H", "") + "_EC_" + strVoltageDwgCode + "_" + strPostHeatEC_KW_DwgCode + "_A";   //ACC_NOVA_B20_I_DC_L_EC_2081_07_A


                //DataTable dtEC_Nomen = ClsDB.get_dtLive(ClsDBT.strSelNovaElecHeaterDwgCode);
                //var drEC_Nomen = dtEC_Nomen.AsEnumerable().Where(x => ((string)(x["items"]) == strEC_Nomen));
                //dtEC_Nomen = drEC_Nomen.Any() ? drEC_Nomen.CopyToDataTable() : new DataTable();
                //strCombinedEC_DwgCode = dtEC_Nomen.Rows.Count > 0 ? dtEC_Nomen.Rows[0]["dwg_code"].ToString() : "";

                DataTable dtPostHeatEC_DwgCode = ClsDB.get_dtLive(ClsDBT.strSelNovaElecHeaterDwgCode);
                dtPostHeatEC_DwgCode = dtPostHeatEC_DwgCode.Select("[unit_model]='" + dsSavedUnitItems.Tables["UnitModel"].Rows[0]["dwg_code"].ToString() + "'").CopyToDataTable();

                //if (_objContElem != null)
                //{
                if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_elec_heater_std_coil_no]) > 0)
                {
                    var drPostHeatElecHeater = dtPostHeatEC_DwgCode.AsEnumerable().Where(x => (Convert.ToInt32(x["volt"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["volt"])));
                    dtPostHeatEC_DwgCode = drPostHeatElecHeater.Any() ? drPostHeatElecHeater.CopyToDataTable() : new DataTable();
                    drPostHeatElecHeater = dtPostHeatEC_DwgCode.AsEnumerable().Where(x => (Convert.ToInt32(x["phase"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["phase"])));
                    dtPostHeatEC_DwgCode = drPostHeatElecHeater.Any() ? drPostHeatElecHeater.CopyToDataTable() : new DataTable();
                    drPostHeatElecHeater = dtPostHeatEC_DwgCode.AsEnumerable().Where(x => (Convert.ToInt32(x["kw"]) == dblKW_Max));
                    dtPostHeatEC_DwgCode = drPostHeatElecHeater.Any() ? drPostHeatElecHeater.CopyToDataTable() : new DataTable();
                }
                else if (Convert.ToInt32(drCompOpt[ClsDBTC.reheat_elec_heater_std_coil_no]) > 0)
                {
                    var drPostHeatElecHeater = dtPostHeatEC_DwgCode.AsEnumerable().Where(x => (Convert.ToInt32(x["volt"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["volt"])));
                    dtPostHeatEC_DwgCode = drPostHeatElecHeater.Any() ? drPostHeatElecHeater.CopyToDataTable() : new DataTable();
                    drPostHeatElecHeater = dtPostHeatEC_DwgCode.AsEnumerable().Where(x => (Convert.ToInt32(x["phase"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["phase"])));
                    dtPostHeatEC_DwgCode = drPostHeatElecHeater.Any() ? drPostHeatElecHeater.CopyToDataTable() : new DataTable();
                    drPostHeatElecHeater = dtPostHeatEC_DwgCode.AsEnumerable().Where(x => (Convert.ToInt32(x["kw"]) == dblKW_Max));
                    dtPostHeatEC_DwgCode = drPostHeatElecHeater.Any() ? drPostHeatElecHeater.CopyToDataTable() : new DataTable();
                }


                //strPreheatEC_KW_DwgCode = Convert.ToInt32(dtPreheatElecHeater.Rows[0]["kw"]).ToString().PadLeft(2, '0');
                strPostHeatEC_KW_DwgCode = dtPostHeatEC_DwgCode.Rows[0]["dwg_code"].ToString();
                //}
            }


            if (Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID)
            {
                if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompHWC_ID)
                {
                    #region Preheat HWC
                    strDwgCodeCasing = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "C" + strOriDwgCodeAccessory_2 : "DS";
                    strRevision = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "_C" : "_A";

                    //strDwgCodeHW_EC_Casing = "PH"; 

                    strNomen = "ACC_NOVA_" + strCoupledDwgCode + "_" + strLocationDwgCode + "_" + strDwgCodeCasing + "_" + strPreheatCoilHandingDwgCode + "_HW";
                    strPreheatHWC_EpicorPartDesc = strNomen;
                    strDwgFile = strNomen + strRevision + ".jpg";

                    drDwgList = dtDrawingList.NewRow();
                    strDwgFileWithPath = strDwgPath + "\\HWC\\" + strDwgFile;
                    drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                    drDwgList["DwgFile"] = strDwgFile;

                    if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                    {
                        dtDrawingList.Rows.Add(drDwgList);
                    }
                    #endregion
                }
                else if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompElecHeaterID)
                {
                    #region Preheat EC
                    if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_elec_heater_installation_id]) == ClsID.intElecHeaterInstallInCasingID)
                    {
                        if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_elec_heater_std_coil_no]) > 0)
                        {
                            DataTable dtPreheatEC = ClsDB.get_dtLive(ClsDBT.strSelNovaElectricHeaterModel);
                            var drPreheatEC = dtPreheatEC.AsEnumerable().Where(x => ((string)x["unit_model"] == dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString()));
                            dtPreheatEC = drPreheatEC.Any() ? drPreheatEC.CopyToDataTable() : new DataTable();
                            drPreheatEC = dtPreheatEC.AsEnumerable().Where(x => (Convert.ToInt32(x["volt"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["volt"])));
                            dtPreheatEC = drPreheatEC.Any() ? drPreheatEC.CopyToDataTable() : new DataTable();
                            drPreheatEC = dtPreheatEC.AsEnumerable().Where(x => (Convert.ToInt32(x["phase"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["phase"])));
                            dtPreheatEC = drPreheatEC.Any() ? drPreheatEC.CopyToDataTable() : new DataTable();
                            drPreheatEC = dtPreheatEC.AsEnumerable().Where(x => (Convert.ToInt32(x["standard_coil_no"]) == Convert.ToInt32(drCompOpt[ClsDBTC.preheat_elec_heater_std_coil_no])));
                            dtPreheatEC = drPreheatEC.Any() ? drPreheatEC.CopyToDataTable() : new DataTable();



                            DataTable dtPreheatEC_DwgCode = ClsDB.get_dtLive(ClsDBT.strSelNovaElecHeaterDwgCode);

                            dtPreheatEC_DwgCode = dtPreheatEC_DwgCode.Select("[unit_model]='" + dsSavedUnitItems.Tables["UnitModel"].Rows[0]["dwg_code"].ToString() + "'").CopyToDataTable();

                            //if (_objContElem != null)
                            //{
                            if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_elec_heater_std_coil_no]) > 0)
                            {
                                var drPreheatElecHeater = dtPreheatEC_DwgCode.AsEnumerable().Where(x => (Convert.ToInt32(x["volt"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["volt"])));
                                dtPreheatEC_DwgCode = drPreheatElecHeater.Any() ? drPreheatElecHeater.CopyToDataTable() : new DataTable();
                                drPreheatElecHeater = dtPreheatEC_DwgCode.AsEnumerable().Where(x => (Convert.ToInt32(x["phase"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["phase"])));
                                dtPreheatEC_DwgCode = drPreheatElecHeater.Any() ? drPreheatElecHeater.CopyToDataTable() : new DataTable();
                                //drPreheatElecHeater = dtPreheatEC_DwgCode.AsEnumerable().Where(x => (Convert.ToInt32(x["kw"]) == _objContElem.objCPreheatElecHeater.objElecHeaterIO.dblKW_Max));
                                drPreheatElecHeater = dtPreheatEC_DwgCode.AsEnumerable().Where(x => (Convert.ToInt32(x["kw"]) == Convert.ToInt32(dtPreheatEC.Rows[0]["kw"])));
                                dtPreheatEC_DwgCode = drPreheatElecHeater.Any() ? drPreheatElecHeater.CopyToDataTable() : new DataTable();

                                //strPreheatEC_KW_DwgCode = Convert.ToInt32(dtPreheatElecHeater.Rows[0]["kw"]).ToString().PadLeft(2, '0');
                                strPreheatEC_KW_DwgCode = dtPreheatEC_DwgCode.Rows[0]["dwg_code"].ToString();

                                strDwgCodeCasing = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "P" + strOriDwgCodeAccessory_2 : "DS";
                                strNomen = "ACC_NOVA_" + strCoupledDwgCode + "_" + strLocationDwgCode + "_" + strDwgCodeCasing + "_" + strPreheatCoilHandingDwgCode + "_EC_" + strPreheatEC_KW_DwgCode;
                                strPreheatElecHeaterEpicorPartDesc = strNomen;
                                strDwgFile = strNomen + "_A.jpg";

                                drDwgList = dtDrawingList.NewRow();
                                strDwgFileWithPath = strDwgPath + "\\ElectricCoil\\" + strDwgFile;
                                drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                                drDwgList["DwgFile"] = strDwgFile;


                                if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                                {
                                    dtDrawingList.Rows.Add(drDwgList);
                                }
                            }
                            //}
                        }
                    }
                    #endregion
                }
            }

            if (Convert.ToInt32(drCompOpt[ClsDBTC.cooling_comp_id]) == ClsID.intCompCWC_ID)
            {
                #region Cooling CWC
                if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompHWC_ID || Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompHWC_ID)
                {
                    strDwgFile = "";
                    strRevision = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "_C" : "_C";

                    drDwgList = dtDrawingList.NewRow();

                    strNomen = "ACC_NOVA_" + strDecoupledDwgCode + "_" + strLocationDwgCode + "_DC_" + strCoolingCoilHandingDwgCode + "_CH"; //CH: CWC and HWC
                    strCWC_EpicorPartDesc = strNomen;
                    strDwgFile = strNomen + strRevision + ".jpg";

                    strDwgFileWithPath = strDwgPath + "\\CWCAccessHWC\\" + strDwgFile;
                    drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                    drDwgList["DwgFile"] = strDwgFile;

                    if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                    {
                        dtDrawingList.Rows.Add(drDwgList);
                    }
                }
                else if ((Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID || Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompElecHeaterID) &&
                            Convert.ToInt32(drCompOpt[ClsDBTC.heating_elec_heater_installation_id]) == ClsID.intElecHeaterInstallInCasingID)
                {
                    strDwgFile = "";
                    strRevision = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "_C" : "_C";

                    strNomen = "ACC_NOVA_" + strDecoupledDwgCode + "_" + strLocationDwgCode + "_DC_" + strCoolingCoilHandingDwgCode + "_CE_" + strPostHeatEC_KW_DwgCode;
                    strCWC_EpicorPartDesc = strNomen;

                    strDwgFile = strNomen + strRevision + ".jpg";

                    drDwgList = dtDrawingList.NewRow();
                    strDwgFileWithPath = strDwgPath + "\\CWCAccessElectricCoil\\" + strDwgFile;
                    drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                    drDwgList["DwgFile"] = strDwgFile;

                    if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                    {
                        dtDrawingList.Rows.Add(drDwgList);
                    }
                }
                else
                {
                    strDwgFile = "";
                    strDwgCodeCasing = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "P" + strOriDwgCodeAccessory_2 : "DS";
                    strRevision = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "_C" : "_C";

                    //strDwgFile = "ACC_NOVA_" + strDecoupledDwgCode + "_" + strLocationDwgCode + "_DS_" + strCoolingCoilHandingDwgCode + "_CW_" + strRevision + ".jpg";
                    strNomen = "ACC_NOVA_" + strDecoupledDwgCode + "_" + strLocationDwgCode + "_DS_" + strCoolingCoilHandingDwgCode + "_CW";
                    strDwgFile = strNomen + strRevision + ".jpg";
                    strCWC_EpicorPartDesc = strNomen;


                    drDwgList = dtDrawingList.NewRow();
                    strDwgFileWithPath = strDwgPath + "\\CWC\\" + strDwgFile;
                    drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                    drDwgList["DwgFile"] = strDwgFile;

                    if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                    {
                        dtDrawingList.Rows.Add(drDwgList);
                    }
                }
                #endregion
            }
            else if (Convert.ToInt32(drCompOpt[ClsDBTC.cooling_comp_id]) == ClsID.intCompDX_ID)
            {
                #region Cooling DX
                if (Convert.ToDouble(drCompOpt["cooling_dx_vrv_kit_tonnage"]) > 0d)
                {
                    //strDX_CapDwgCode = Convert.ToInt32(_objContElem.objCCoolingDX.objEKEXV_KitModel.dblNominalTonnage * 10).ToString().PadLeft(3, '0');

                    strDX_CapDwgCode = Convert.ToInt32(Convert.ToDouble(drCompOpt["cooling_dx_vrv_kit_tonnage"]) * 10).ToString().PadLeft(3, '0');
                }


                if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompHWC_ID || Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompHWC_ID)
                {
                    strDwgFile = "";
                    strDwgCodeCasing = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "P" + strOriDwgCodeAccessory_2 : "DS";
                    strRevision = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "_D" : "_E";

                    strNomen = "ACC_NOVA_" + strDecoupledDwgCode + "_" + strLocationDwgCode + "_DC_" + strCoolingCoilHandingDwgCode + "_QH";
                    strDXC_EpicorPartDesc = strNomen;
                    strDwgFile = strNomen + strRevision + ".jpg";

                    drDwgList = dtDrawingList.NewRow();
                    strDwgFileWithPath = strDwgPath + "\\DXAccessHWC\\" + strDwgFile;
                    drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                    drDwgList["DwgFile"] = strDwgFile;

                    if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                    {
                        dtDrawingList.Rows.Add(drDwgList);
                    }
                }
                else if ((Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID || Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompElecHeaterID) &&
                            (Convert.ToInt32(drCompOpt[ClsDBTC.heating_elec_heater_installation_id]) == ClsID.intElecHeaterInstallInCasingID))
                {
                    strDwgFile = "";
                    strDwgCodeCasing = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "P" + strOriDwgCodeAccessory_2 : "DS";
                    strRevision = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "_D" : "_E";   //For Downshot indorr accessories are used


                    strNomen = "ACC_NOVA_" + strDecoupledDwgCode + "_" + strLocationDwgCode + "_DC_" + strCoolingCoilHandingDwgCode + "_QE_" + strPostHeatEC_KW_DwgCode;
                    strDXC_EpicorPartDesc = strNomen;

                    strDwgFile = strNomen + strRevision + ".jpg";

                    drDwgList = dtDrawingList.NewRow();
                    strDwgFileWithPath = strDwgPath + "\\DXAccessElectricCoil\\" + strDwgFile;
                    drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                    drDwgList["DwgFile"] = strDwgFile;

                    if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                    {
                        dtDrawingList.Rows.Add(drDwgList);
                    }


                    //else if (Convert.ToInt32(drUnitDwg["elec_heater_installation_id"]) == ClsID.intElecHeaterInstallDuctMountedID)
                    //{
                    //    drDwgList = dtDrawingList.NewRow();
                    //    //strDwgFile = "ACC_NOVA_" + strModelDwgCode + "_" + strLocationDwgCode + "_DS_" + strFanPlacementDwgCode + "_QE_" + strCombinedEC_DwgCode + "_A.jpg";
                    //    strDwgFile = "ACC_NOVA_" + strDecoupledDwgCode + "_" + strLocationDwgCode + "_DS_" + strFanPlacementDwgCode + "_QE_" + strCombinedEC_DwgCode + "_A.jpg";
                    //    drDwgList["DwgPathAndFile"] = strNovaDwgPath + "\\DX\\" + strDwgFile;
                    //    drDwgList["DwgFile"] = strDwgFile;
                    //    dtDrawingList.Rows.Add(drDwgList);
                    //    strDwgFile = "";
                    //}
                }
                else
                {
                    strDwgFile = "";
                    //strDwgCodeCasing = "DS";
                    strDwgCodeCasing = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "P" + strOriDwgCodeAccessory_2 : "DS";
                    strRevision = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "_A" : "_A";

                    //////switch (Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]))
                    //////{
                    //////    case ClsID.intLocationIndoorID:
                    //////        strNomen = "ACC_NOVA_" + strDecoupledDwgCode + "_" + strLocationDwgCode + "_DS_" + strCoolingCoilHandingDwgCode + "_DQ";
                    //////        break;
                    //////    case ClsID.intLocationOutdoorID:
                    //////        strNomen = "ACC_NOVA_" + strDecoupledDwgCode + "_" + strLocationDwgCode + "_DS_" + strCoolingCoilHandingDwgCode + "_DQ_" + strDX_CapDwgCode;
                    //////        break;
                    //////    default:
                    //////        break;
                    //////}


                    strNomen = "ACC_NOVA_" + strDecoupledDwgCode + "_" + strLocationDwgCode + "_DS_" + strCoolingCoilHandingDwgCode + "_DQ";

                    strDXC_EpicorPartDesc = strNomen;
                    strDwgFile = strNomen + strRevision + ".jpg";


                    drDwgList = dtDrawingList.NewRow();
                    //strDwgFile = "ACC_NOVA_" + strModelDwgCode + "_" + strLocationDwgCode + "_DS_" + strFanPlacementDwgCode + "_DQ_" + strDX_CapDwgCode + "_A.jpg";
                    strDwgFileWithPath = strDwgPath + "\\DX\\" + strDwgFile;
                    drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                    drDwgList["DwgFile"] = strDwgFile;

                    if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                    {
                        dtDrawingList.Rows.Add(drDwgList);
                    }
                }
                #endregion
            }
            else if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompHWC_ID)
            {
                #region Heating HWC alone
                strDwgCodeCasing = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "C" + strOriDwgCodeAccessory_2 : "DS";
                strRevision = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "_C" : "_A";

                strNomen = "ACC_NOVA_" + strCoupledDwgCode + "_" + strLocationDwgCode + "_" + strDwgCodeCasing + "_" + strHeatingCoilHandingDwgCode + "_HW";
                strHeatingHWC_EpicorPartDesc = strNomen;
                strDwgFile = strNomen + strRevision + ".jpg";

                drDwgList = dtDrawingList.NewRow();
                strDwgFileWithPath = strDwgPath + "\\HWC\\" + strDwgFile;
                drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                drDwgList["DwgFile"] = strDwgFile;

                if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                {
                    dtDrawingList.Rows.Add(drDwgList);
                }
                #endregion
            }
            else if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID)
            {
                #region Heating EC alone
                if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_elec_heater_installation_id]) == ClsID.intElecHeaterInstallInCasingID)
                {
                    strDwgFile = "";
                    strDwgCodeCasing = Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID || intIsDownshot == 1 ? "C" + strOriDwgCodeAccessory_2 : "DS";

                    strNomen = "ACC_NOVA_" + strCoupledDwgCode + "_" + strLocationDwgCode + "_" + strDwgCodeCasing + "_" + strHeatingCoilHandingDwgCode + "_EC_" + strPostHeatEC_KW_DwgCode;
                    strHeatingElecHeaterEpicorPartDesc = strNomen;
                    strDwgFile = strNomen + "_A.jpg";


                    drDwgList = dtDrawingList.NewRow();
                    //strDwgFile = "ACC_NOVA_" + strModelDwgCode + "_" + strLocationDwgCode + "_" + strDwgCodeCasing + "_" + strHeatingCoilHandingDwgCode + "_EC_" + strPostHeatEC_KW_DwgCode + "_A.jpg";   //ACC_VENTUM_H05_I_CX_L_CE_E1_A
                    strDwgFileWithPath = strDwgPath + "\\ElectricCoil\\" + strDwgFile;
                    drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                    drDwgList["DwgFile"] = strDwgFile;

                    if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                    {
                        dtDrawingList.Rows.Add(drDwgList);
                    }
                }
                #endregion
            }



            if (Convert.ToInt32(drCompOpt[ClsDBTC.damper_and_actuator_id]) == ClsID.intDamperActuatorInCasingID)
            {
                strDwgFile = "";
                drDwgList = dtDrawingList.NewRow();
                strDwgFile = "D_" + strModelDwgCode + "_" + strOriDwgCodeAccessory_2 + "_OA_" + strUnitHandingDwgCode + ".jpg";
                strDwgFileWithPath = strDwgPath + "\\Damper\\" + strDwgFile;
                drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                drDwgList["DwgFile"] = strDwgFile;

                if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                {
                    dtDrawingList.Rows.Add(drDwgList);
                }

                if (Convert.ToInt32(drSavedUnit[ClsDBTC.unit_type_id]) == ClsID.intUnitTypeERV_ID || Convert.ToInt32(drSavedUnit[ClsDBTC.unit_type_id]) == ClsID.intUnitTypeHRV_ID)
                {
                    strDwgFile = "";
                    drDwgList = dtDrawingList.NewRow();
                    strDwgFile = "D_" + strModelDwgCode + "_" + strOriDwgCodeAccessory_2 + "_EA_" + strUnitHandingDwgCode + ".jpg";
                    strDwgFileWithPath = strDwgPath + "\\Damper\\" + strDwgFile;
                    drDwgList["DwgPathAndFile"] = strDwgFileWithPath;
                    drDwgList["DwgFile"] = strDwgFile;

                    if (File.Exists(HttpContext.Current.Server.MapPath(strDwgFileWithPath)))
                    {
                        dtDrawingList.Rows.Add(drDwgList);
                    }
                }
            }


            return dtDrawingList;
        }
        #endregion




        #region Epicor Part Number
        private void setEpicorPartNumber()
        {
            DataTable dtTempPartNbr = new DataTable();

            //Unit
            var drEpicorPartNbr = dtEpicorPartNbr.AsEnumerable().Where(x => ((string)x["part_description"] == strUnitEpicorPartDesc));
            dtTempPartNbr = drEpicorPartNbr.Any() ? drEpicorPartNbr.CopyToDataTable() : new DataTable();
            strUnitEpicorPartNbr = dtTempPartNbr.Rows.Count > 0 ? dtTempPartNbr.Rows[0]["part_number"].ToString() : "";

            //Preheat Elec Heater
            drEpicorPartNbr = dtEpicorPartNbr.AsEnumerable().Where(x => ((string)x["part_description"] == strPreheatElecHeaterEpicorPartDesc));
            dtTempPartNbr = drEpicorPartNbr.Any() ? drEpicorPartNbr.CopyToDataTable() : new DataTable();
            strPreheatElecHeaterEpicorPartNbr = dtTempPartNbr.Rows.Count > 0 ? dtTempPartNbr.Rows[0]["part_number"].ToString() : "";

            //Heating Elec Heater
            drEpicorPartNbr = dtEpicorPartNbr.AsEnumerable().Where(x => ((string)x["part_description"] == strHeatingElecHeaterEpicorPartDesc));
            dtTempPartNbr = drEpicorPartNbr.Any() ? drEpicorPartNbr.CopyToDataTable() : new DataTable();
            strHeatingElecHeaterEpicorPartNbr = dtTempPartNbr.Rows.Count > 0 ? dtTempPartNbr.Rows[0]["part_number"].ToString() : "";

            //Reheat Elec Heater
            drEpicorPartNbr = dtEpicorPartNbr.AsEnumerable().Where(x => ((string)x["part_description"] == strReheatElecHeaterEpicorPartDesc));
            dtTempPartNbr = drEpicorPartNbr.Any() ? drEpicorPartNbr.CopyToDataTable() : new DataTable();
            strReheatElecHeaterEpicorPartNbr = dtTempPartNbr.Rows.Count > 0 ? dtTempPartNbr.Rows[0]["part_number"].ToString() : "";

            //Preheat HWC
            drEpicorPartNbr = dtEpicorPartNbr.AsEnumerable().Where(x => ((string)x["part_description"] == strPreheatHWC_EpicorPartDesc));
            dtTempPartNbr = drEpicorPartNbr.Any() ? drEpicorPartNbr.CopyToDataTable() : new DataTable();
            strPreheatHWC_EpicorPartNbr = dtTempPartNbr.Rows.Count > 0 ? dtTempPartNbr.Rows[0]["part_number"].ToString() : "";

            //Heating HWC
            drEpicorPartNbr = dtEpicorPartNbr.AsEnumerable().Where(x => ((string)x["part_description"] == strHeatingHWC_EpicorPartDesc));
            dtTempPartNbr = drEpicorPartNbr.Any() ? drEpicorPartNbr.CopyToDataTable() : new DataTable();
            strHeatingHWC_EpicorPartNbr = dtTempPartNbr.Rows.Count > 0 ? dtTempPartNbr.Rows[0]["part_number"].ToString() : "";

            //Reheat HWC
            drEpicorPartNbr = dtEpicorPartNbr.AsEnumerable().Where(x => ((string)x["part_description"] == strReheatHWC_EpicorPartDesc));
            dtTempPartNbr = drEpicorPartNbr.Any() ? drEpicorPartNbr.CopyToDataTable() : new DataTable();
            strReheatHWC_EpicorPartNbr = dtTempPartNbr.Rows.Count > 0 ? dtTempPartNbr.Rows[0]["part_number"].ToString() : "";

            //Cooling CWC
            drEpicorPartNbr = dtEpicorPartNbr.AsEnumerable().Where(x => ((string)x["part_description"] == strCWC_EpicorPartDesc));
            dtTempPartNbr = drEpicorPartNbr.Any() ? drEpicorPartNbr.CopyToDataTable() : new DataTable();
            strCWC_EpicorPartNbr = dtTempPartNbr.Rows.Count > 0 ? dtTempPartNbr.Rows[0]["part_number"].ToString() : "";

            //Cooling DX
            drEpicorPartNbr = dtEpicorPartNbr.AsEnumerable().Where(x => ((string)x["part_description"] == strDXC_EpicorPartDesc));
            dtTempPartNbr = drEpicorPartNbr.Any() ? drEpicorPartNbr.CopyToDataTable() : new DataTable();
            strDXC_EpicorPartNbr = dtTempPartNbr.Rows.Count > 0 ? dtTempPartNbr.Rows[0]["part_number"].ToString() : "";

        }
        #endregion

    }
}