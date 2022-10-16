using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxygen8SelectorServer.Models
{
    public class ClsGeneral
    {
        //private DataTable dtSavedUnit;
        //private DataRow drSavedUnit;
        //private DataSet dsSavedUnit;

        public ClsGeneral()
        {
        }


        #region Load General
        public ClsGeneral(int _intJobID, int _intUnitNo)
        {
            //bytArrPDF_Preliminary = new byte[0];
            //bytArrPDF_PreliminaryFull = new byte[0];
            //bytArrPDF_Submittal = new byte[0];
            //bytArrPDF_DrawingRequest = new byte[0];
            intJobID = _intJobID;
            intUnitNo = _intUnitNo;


            ////DataTable dt = ClsDBM.SelectByJobIdUnitNo(ClsDBT.strSavGeneral, intJobID, intUnitNo, ClsID.strColumnUnitNo);
            //DataTable dt = ClsDB.GetSavedUnit(intJobID, intUnitNo);
            dtSavedUnit = ClsDB.GetSavedUnitWithDetails(_intJobID, _intUnitNo);
            dsSavedUnitItems = ClsDB.GetSavedUnitItems(_intJobID, _intUnitNo);

            if (dtSavedUnit.Rows.Count > 0)
            {
                drSavedUnit = dtSavedUnit.Rows[0];
                strTag = drSavedUnit["tag"].ToString();
                intQty = Convert.ToInt32(drSavedUnit["qty"]);
                intProductTypeID = Convert.ToInt32(drSavedUnit["product_type_id"]);
                intUnitTypeID = Convert.ToInt32(drSavedUnit["unit_type_id"]);
                intIsBypass = Convert.ToInt32(drSavedUnit["is_bypass"]);
                intUnitModelID = Convert.ToInt32(drSavedUnit["unit_model_id"]);
                intLocationID = Convert.ToInt32(drSavedUnit["location_id"]);
                intIsDownshot = Convert.ToInt32(drSavedUnit["is_downshot"]);
                intOrientationID = Convert.ToInt32(drSavedUnit["orientation_id"]);
                intControlsPreferenceID = Convert.ToInt32(drSavedUnit["controls_preference_id"]);
                intSelectionTypeID = Convert.ToInt32(drSavedUnit["selection_type_id"]);
                dblUnitWeight = Convert.ToInt32(drSavedUnit["unit_weight"]);
                intUnitVoltageID = Convert.ToInt32(drSavedUnit["voltage_id"]);
                intIsVoltageSPP = Convert.ToInt32(drSavedUnit["is_voltage_spp"]);


                setInputData();
                setVoltageData();
                setUnitElectricalData();
            }
        }
        #endregion


        //public void setUnitModelID(int _intUnitModelID)
        //{
        //    intUnitModelID = _intUnitModelID;
        //    strUnitModel = ClsDB.get_dtByID(ClsDBT.strSelNovaUnitModel, intUnitModelID).Rows[0]["items"].ToString();
        //}


        //public void setVoltageID(int _intVoltageID)
        //{
        //    intUnitVoltageID = _intVoltageID;
        //    strVoltage = ClsDB.get_dtByID(ClsDBT.strSelElectricalVoltage, intUnitVoltageID).Rows[0]["items"].ToString();
        //    setVoltageData();
        //}


        private void setInputData()
        {
            //strProductType = ClsDB.get_dtByID(ClsDBT.strSelProductType, intProductTypeID).Rows[0]["items"].ToString();
            //strUnitType = ClsDB.get_dtByID(ClsDBT.strSelUnitType, intUnitTypeID).Rows[0]["items"].ToString();
            //strUnitTypeDesc = ClsDB.get_dtByID(ClsDBT.strSelUnitType, intUnitTypeID).Rows[0]["description"].ToString();

            strProductType = dsSavedUnitItems.Tables[ClsDBT.strSelProductType].Rows[0]["items"].ToString();
            strUnitType = dsSavedUnitItems.Tables[ClsDBT.strSelUnitType].Rows[0]["items"].ToString();
            strUnitTypeDesc = dsSavedUnitItems.Tables[ClsDBT.strSelUnitType].Rows[0]["description"].ToString();


            //string strUnitModelTable = intProductTypeID == ClsID.intProductTypeVentumID ? ClsDBT.intSelVentumUnitModel : ClsDBT.strSelNovaUnitModel;

            //DataTable dtModel = ClsDB.get_dtByID(strUnitModelTable, intUnitModelID);
            string strUnitModelColumnName = ClsGo.get_strUnitModelColumnName(intProductTypeID, intUnitTypeID, intIsBypass);


            strUnitModel = intUnitModelID > 0 ? dsSavedUnitItems.Tables["UnitModel"].Rows[0][strUnitModelColumnName].ToString() : "";
            strUnitModelValue = intUnitModelID > 0 ? dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString() : "";

            strUnitModelValueNoLoc = dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString().Replace("IN", "");
            strUnitModelValueNoLoc = strUnitModelValueNoLoc.Replace("OU", "");

            strUnitModelImg = intUnitModelID > 0 ? dsSavedUnitItems.Tables["UnitModel"].Rows[0]["image_name"].ToString() : "";
            strCFM_Range = dsSavedUnitItems.Tables["UnitModel"].Rows[0]["cfm_min"].ToString() + " - " + dsSavedUnitItems.Tables["UnitModel"].Rows[0]["cfm_max"].ToString() + " CFM";
            //DataTable dtOrientation = ClsDB.get_dtByID(ClsDBT.strSelGeneralOrientation, intOrientationID);
            //strOrientation = dtOrientation.Rows.Count > 0 ? dtOrientation.Rows[0]["items"].ToString() : "";
            //strOrientationValue = dtOrientation.Rows.Count > 0 ? dtOrientation.Rows[0]["value"].ToString() : "H";

            //strOrientation = dsSavedUnit.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["items"].ToString();
            //strOrientationValue = dsSavedUnit.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["value"].ToString();


            strLocation = dsSavedUnitItems.Tables[ClsDBT.strSelGeneralLocation].Rows[0]["items"].ToString();


            //strHousing = ClsDBM.SelectById(ClsDBT.strSelGeneralHousing, intHousingID).Rows[0]["items"].ToString();
            //strConfiguration = ClsDBM.SelectById(ClsDBT.strSelGeneralConfiguration, intConfigurationID).Rows[0]["items"].ToString();
            strControlsPre = dsSavedUnitItems.Tables[ClsDBT.strSelControlsPreference].Rows[0]["items"].ToString();

            //string strUnitSizeTable = intProductTypeID == ClsID.intProductTypeVentumID ? ClsDBT.strSelVentumUnitSize : ClsDBT.strSelNovaUnitSize;


            //DataTable dtUnitSize = ClsDB.get_dtLive(strUnitSizeTable, "unit_model_id", intUnitModelID);


            //if (intProductTypeID == ClsID.intProductTypeNovaID)
            //{
            //    //dtUnitSize = ClsTS.get_dtDataFromImportRows(dtUnitSize, "unit_orientation_id", intOrientationID);
            //    dtUnitSize = ClsTS.get_dtDataFromImportRows(dtUnitSize, "unit_orientation_value", strOrientationValue);
            //    dtUnitSize = ClsTS.get_dtDataFromImportRows(dtUnitSize, "selection_type_id", intSelectionTypeID);
            //}


            //if (dtUnitSize.Rows.Count > 0)
            //{
            //    dblUnitHeight = Convert.ToDouble(dtUnitSize.Rows[0]["cabinet_height"]);
            //    dblUnitWidth = Convert.ToDouble(dtUnitSize.Rows[0]["cabinet_width"]);
            //    dblUnitLength = Convert.ToDouble(dtUnitSize.Rows[0]["cabinet_length"]);

            //    strUnitCabinetDim = dtUnitSize.Rows[0]["cabinet_height"].ToString() + " H x " +
            //                        dtUnitSize.Rows[0]["cabinet_width"].ToString() + " W x " +
            //                        dtUnitSize.Rows[0]["cabinet_length"].ToString() + " L ";

            //    //strSelectionTypeValue = dtUnitSize.Rows[0]["selection_type_value"].ToString();
            //}

            //if (dtUnitSize.Rows.Count > 0)
            //{
            dblUnitHeight = Convert.ToDouble(dsSavedUnitItems.Tables["UnitModelSize"].Rows[0]["cabinet_height"]);
            dblUnitWidth = Convert.ToDouble(dsSavedUnitItems.Tables["UnitModelSize"].Rows[0]["cabinet_width"]);
            dblUnitLength = Convert.ToDouble(dsSavedUnitItems.Tables["UnitModelSize"].Rows[0]["cabinet_length"]);

            strUnitCabinetDim = dblUnitHeight.ToString() + " H x " + dblUnitWidth.ToString() + " W x " + dblUnitLength.ToString() + " L ";

            //strSelectionTypeValue = dtUnitSize.Rows[0]["selection_type_value"].ToString();
            //}


            strSelectionTypeValue = intSelectionTypeID == ClsID.intSelectionTypeDecoupled ? ClsID.strSelectionTypeDecoupledValue : ClsID.strSelectionTypeCoupledValue;

        }


        private void setVoltageData()
        {
            //dtUnitVoltageData = ClsDB.get_dtByID(ClsDBT.strSelElectricalVoltage, intUnitVoltageID);
            //strVoltage = dtUnitVoltageData.Rows.Count > 0 ? dtUnitVoltageData.Rows[0]["items"].ToString() : "";

            ////DataRow drVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, intUnitVoltageID).Rows[0];
            //intVolt = Convert.ToInt32(dtUnitVoltageData.Rows[0]["volt"]);
            //intPhase = Convert.ToInt32(dtUnitVoltageData.Rows[0]["phase"]);
            //intHertz = Convert.ToInt32(dtUnitVoltageData.Rows[0]["hertz"]);
            //strVoltageRange = dtUnitVoltageData.Rows[0]["voltage_range"].ToString();

            ////strVoltage = intVolt.ToString() + "V/" + intPhase.ToString() + "ph/" + intHertz.ToString() + "Hz";
            ///

            //dtUnitVoltageData = ClsDB.get_dtByID(ClsDBT.strSelElectricalVoltage, intUnitVoltageID);
            strVoltage = dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["items"].ToString();

            //DataRow drVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, intUnitVoltageID).Rows[0];
            intVolt = Convert.ToInt32(dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["volt"]);
            intPhase = Convert.ToInt32(dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["phase"]);
            intHertz = Convert.ToInt32(dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["hertz"]);
            strVoltageRange = dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["voltage_range"].ToString();


            //strVoltage = intVolt.ToString() + "V/" + intPhase.ToString() + "ph/" + intHertz.ToString() + "Hz";

        }

        private void setUnitElectricalData()
        {
            //string strUnitElectricalDataTable = intProductTypeID == ClsID.intProdTypeVentumID ? ClsDBT.strSelVentumElectricalData : ClsDBT.strSelNovaElectricalData;
            string strUnitElectricalDataTable = "";

            switch (intProductTypeID)
            {
                case ClsID.intProdTypeNovaID:
                    strUnitElectricalDataTable = ClsDBT.strSelNovaElectricalData;
                    break;
                default:
                    break;
            }

            dtUnitElectricalData = ClsDB.get_dtLive(strUnitElectricalDataTable, " WHERE `unit_type_id`=" + intUnitTypeID + " AND `unit_model_id`=" + intUnitModelID + " AND `volt`=" + intVolt);
            dtUnitElectricalData = ClsTS.get_dtDataFromImportRows(dtUnitElectricalData, "phase", intPhase);
        }

        public DataTable dtSavedUnit { get; set; }
        public DataRow drSavedUnit { get; set; }
        public DataSet dsSavedUnitItems { get; set; }

        public int intJobID { get; set; }

        public int intUnitNo { get; set; }

        public string strTag { get; set; }

        public int intQty { get; set; }

        public int intProductTypeID { get; set; }

        public int intIsBypass { get; set; }

        public int intUnitTypeID { get; set; }

        public int intUnitModelID { get; set; }

        public int intUnitSizeID { get; set; }

        public int intLocationID { get; set; }

        public int intIsDownshot { get; set; }

        public int intOrientationID { get; set; }

        public int intHousingID { get; set; }

        public int intUnitVoltageID { get; set; }

        public int intIsVoltageSPP { get; set; }

        public int intControlsPreferenceID { get; set; }

        public int intSelectionTypeID { get; set; }

        public string strSelectionTypeValue { get; set; }

        public string strVoltage { get; set; }

        public int intVolt { get; set; }

        public int intHertz { get; set; }

        public int intPhase { get; set; }

        public string strProductType { get; set; }

        public string strUnitType { get; set; }

        public string strUnitTypeDesc { get; set; }

        public string strUnitModel { get; set; }

        public string strUnitModelValue { get; set; }

        public string strUnitModelValueNoLoc { get; set; }

        public string strUnitModelImg { get; set; }

        public string strUnitCabinetDim { get; set; }

        public string strUnitSize { get; set; }

        public string strOrientation { get; set; }

        public string strOrientationValue { get; set; }

        public string strLocation { get; set; }


        public string strHousing { get; set; }


        public string strCFM_Range { get; set; }

        public string strNomenclature { get; set; }

        public string strPerformanceSuccess { get; set; }


        public double dblUnitHeight { get; set; }

        public double dblUnitWidth { get; set; }

        public double dblUnitLength { get; set; }

        public double dblUnitWeight { get; set; }

        public string strControlsPre { get; set; }
        public string strVoltageRange { get; set; }

        //public DataTable dtUnitVoltageData { get; set; }


        public DataTable dtUnitElectricalData { get; set; }
    }
}