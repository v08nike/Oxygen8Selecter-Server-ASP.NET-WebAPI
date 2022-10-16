using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxygen8SelectorServer.Models
{
    public class ClsPricing
    {
        private ClsGeneral objGen;
        private DataSet dsSavedUnitItems = new DataSet();
        private DataTable dtSavedUnit = new DataTable();
        private DataRow drSavedUnit;
        //private DataTable dtCompOpt = new DataTable();
        DataTable dtPI = new DataTable();
        private DataRow drCompOpt;
        private string strPriceColumn = "";

        public int intLoggedUserID { get; set; }
        public int intLoggedUAL { get; set; }
        public int intCreatedUserID { get; set; }
        public int intCreatedUAL { get; set; }
        public int intJobID { get; set; }
        public int intCountryID { get; set; }
        public int intFOB_PointID { get; set; }
        public double dblCurrencyRate { get; set; }
        public int intShippingTypeID { get; set; }
        public double dblShippingFactor { get; set; }
        public int intDiscountTypeID { get; set; }
        public double dblDiscountFactor { get; set; }
        public double dblPriceAllUnit { get; set; }
        public double dblPriceMisc { get; set; }
        public double dblPriceUnitsAndMisc { get; set; }
        public double dblPriceShipping { get; set; }
        public double dblPriceSubtotal { get; set; }
        public double dblPriceDiscount { get; set; }
        public double dblPriceFinal { get; set; }
        public DataTable dtPriceDetail { get; set; }


        //Outputs
        public DataTable dtDisPricingGeneral { get; set; }
        public DataTable dtDisPricingUnitsPrice { get; set; }
        public DataTable dtDisPricingMisc { get; set; }
        public DataTable dtDisPricigShipping { get; set; }
        public DataTable dtDisPriceAddInfo { get; set; }
        public DataTable dtDisTotalPrice { get; set; }
        public string strDisIncludesInfo { get; set; }
        public DataTable dtDisPricingErrMsg { get; set; }



        //---------------------------------------------------------------------------------------------------
        public double dblUnitModelPrice { get; set; }
        public double dblDamperPrice { get; set; }
        public string strAccessSectionDetails { get; set; }
        public double dblAccessSectionPrice { get; set; }
        public double dblPreheatElecHeaterPrice { get; set; }
        public double dblHeatingElecHeaterPrice { get; set; }
        public double dblReheatElecHeaterPrice { get; set; }
        public double dblPreheatHWC_Price { get; set; }
        public double dblHeatingHWC_Price { get; set; }
        public double dblReheatHWC_Price { get; set; }
        public double dblPreheatHWC_ValvePrice { get; set; }
        public double dblHeatingHWC_ValvePrice { get; set; }
        public double dblReheatHWC_ValvePrice { get; set; }
        public double dblCWC_Price { get; set; }
        public double dblCWC_ValvePrice { get; set; }
        public double dblDXC_Price { get; set; }
        public double dblDrainPanPrice { get; set; }

        public double dblSenosrControlsPrefPrice { get; set; }
        public double dblSensorCoolingPrice { get; set; }
        public double dblSensorHeatingPrice { get; set; }
        //public double dblSensorDX_DehumElecCoilReheatPrice { get; set; }
        //public double dblSensorDX_DehumHWCReheatPrice { get; set; }
        //public double dblSensorDX_DehumNoReheatPrice { get; set; }
        //public double dblSensorCWC_DehumElecCoilReheatPrice { get; set; }
        //public double dblSensorCWC_DehumHWCReheatPrice { get; set; }
        //public double dblSensorCWC_DehumNoReheatPrice { get; set; }
        public double dblSensorHeatingHWC_Price { get; set; }
        public double dblSensorDehumReheatPrice { get; set; }
        public double dblSensorDehumNoReheatPrice { get; set; }
        public double dblControlsByOtherPrice { get; set; }     //Deduct $1000 USD


        //---------------------------------------------------------------------------------------------------


        private DataTable dtUnitModel = new DataTable();
        private DataTable dtAccessSection = new DataTable();
        private DataTable dtPreheatElecHeater = new DataTable();
        private DataTable dtHeatingElecHeater = new DataTable();
        private DataTable dtReheatElecHeater = new DataTable();
        private DataTable dtPreheatHWC = new DataTable();
        private DataTable dtHeatingHWC = new DataTable();
        private DataTable dtReheatHWC = new DataTable();
        private DataTable dtCWC_Valve = new DataTable();
        private DataTable dtHeatingHWC_Valve = new DataTable();
        private DataTable dtReheatHWC_Valve = new DataTable();
        private DataTable dtCWC = new DataTable();
        private DataTable dtPreheatHWC_Valve = new DataTable();
        private DataTable dtDXC = new DataTable();
        private DataTable dtDrainPan = new DataTable();
        //private DataTable dtCompOpt = new DataTable();
        private DataTable dtValveActuatorType = new DataTable();


        //---------------------------------------------------------------------------------------------------
        private string strUnitModelValue = "";
        private DataTable dtVoltage = new DataTable();
        private string strSelecTypeValue = "";

        private DataRow drPriceDetail;
        private string strSensorDesc = "";

        string strPriceUnitModelTable = "";
        string strPriceElecHeaterTable = "";
        string strPriceDamperTable = "";


        public ClsPricing()
        {
        }




        public ClsPricing(int _intUAL, int _intJobID, int _intUnitNo)
        {
            intLoggedUAL = _intUAL;
            intJobID = _intJobID; //Need this for Sensors pricings

            objGen = new ClsGeneral(intJobID, _intUnitNo);
            //objComp = new ClsComponentItems(_intJobID, _intUnitNo);
            DataTable dtPI = ClsDB.GetSavedJobItems(intJobID).Tables[ClsDBT.strSavJob];


            dsSavedUnitItems = objGen.dsSavedUnitItems;
            dtSavedUnit = dsSavedUnitItems.Tables[ClsDBT.strSavGeneral];
            drSavedUnit = dtSavedUnit.Rows[0];
            //dtCompOpt = dsSavedUnitItems.Tables[ClsDBT.strSavCompOption];
            drCompOpt = dsSavedUnitItems.Tables[ClsDBT.strSavCompOption].Rows[0];


            //dtCompOpt = ClsDB.GetSavedCompOpt(_intJobID, _intUnitNo);
            //dtValveActuatorType = ClsDB.get_dtByID(ClsDBT.strSelValveType, Convert.ToInt32(dtCompOpt.Rows[0]["valve_type_id"]));

            //strUnitModelValue = objGen.strUnitModelValue;
            //strUnitModelValueNoLoc = objGen.strUnitModelValueNoLoc;

            strUnitModelValue = dsSavedUnitItems.Tables["UnitModel"].Rows[0]["value"].ToString();
            strSelecTypeValue = objGen.strSelectionTypeValue;
            strPriceColumn = Convert.ToInt32(dtPI.Rows[0][ClsDBTC.is_test_new_price]) == 1 ? ClsDBTC.new_price_test : ClsDBTC.price;

            //intIsBypass = objGen.intIsBypass;
            //intLocationID = objGen.intLocationID;
            //intVolt = objGen.intVolt;
            //intPhase = objGen.intPhase;
            //intHertz = objGen.intHertz;

            //intPreheatElecHeaterMountingID = objComp.objCompOpt.intPreheatElecHeaterInstallationID;
            //intHeatElecHeaterMountingID = objComp.objCompOpt.intHeatElecHeaterInstallationID;
            //intDamperMountingID = objComp.objCompOpt.intDamperAndActuatorID;
            //dtVoltage = ClsDB.get_dtByID(ClsDBT.strSelElectricalVoltage, objComp.objCompOpt.intElecHeaterVoltageID);
            //if (dtVoltage.Rows.Count > 0)
            //{
            //    intVoltElecHeat = Convert.ToInt32(dtVoltage.Rows[0]["volt"]);
            //    intPhaseElecHeat = Convert.ToInt32(dtVoltage.Rows[0]["phase"]);
            //}

            //intSelectionTypeID = objGen.intSelectionTypeID;



            dtPriceDetail = new DataTable();
            dtPriceDetail.Columns.Add("cLabel", typeof(string));
            dtPriceDetail.Columns.Add("cValue", typeof(string));
            dtPriceDetail.Columns.Add("cSpace", typeof(string));    //Keep this column to create an empty space between price and notes since notes is Right aligned
            dtPriceDetail.Columns.Add("cNotes", typeof(string));


            //if (Convert.ToInt32(drSavedUnit["ProductTypeID"]) == ClsID.intProductTypeNovaID)
            //{
            //    CalcPricingNova();
            //}
            //else if (Convert.ToInt32(drSavedUnit["ProductTypeID"]) == ClsID.intProductTypeVentumID)
            //{
            //    //if (_objContElem.objCUser.intUAL == ClsID.intUAL_Admin || _objContElem.objCUser.intUAL == ClsID.intUAL_IntAdmin)
            //    //{
            //    CalcPricingVentum();
            //    //}
            //}

            int intProdTypeID = Convert.ToInt32(drSavedUnit["product_type_id"]);
            switch (intProdTypeID)
            {
                case ClsID.intProdTypeNovaID:
                    CalcPricingNova();
                    break;
                default:
                    break;
            }

            //if (Convert.ToInt32(drSavedUnit["product_type_id"]) == ClsID.intProdTypeNovaID)
            //{
            //}
            //else if (Convert.ToInt32(drSavedUnit["product_type_id"]) == ClsID.intProdTypeVentumID || Convert.ToInt32(drSavedUnit["product_type_id"]) == ClsID.intProdTypeVentumLiteID)
            //{
            //    //if (_objContElem.objCUser.intUAL == ClsID.intUAL_Admin || _objContElem.objCUser.intUAL == ClsID.intUAL_IntAdmin)
            //    //{
            //    //}
            //}


            setSensorPrice();


            //setControlsByOtherPrice( _objContElem);
            CalculateUnitPrice();


            if (dtPriceDetail != null && dtPriceDetail.Rows.Count > 0)
            {
                for (int i = 0; i < dtPriceDetail.Rows.Count; i++)
                {
                    if (dtPriceDetail.Rows[i]["cValue"].ToString() != "")
                    {
                        dtPriceDetail.Rows[i]["cValue"] = ("$" + String.Format("{0:#,0.00}", Convert.ToDouble(dtPriceDetail.Rows[i]["cValue"])));
                    }
                }
            }
        }


        #region CalcPricingNova
        //private void CalcPricingNova(ClsContElements _objContElem)
        private void CalcPricingNova()
        {
            dtUnitModel = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceUnitModel);
            dtAccessSection = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceAccessSection);

            var drUnitModel = dtUnitModel.AsEnumerable().Where(x => ((string)x["unit_model_value"] == strUnitModelValue));
            dtUnitModel = drUnitModel.Any() ? drUnitModel.CopyToDataTable() : new DataTable();
            drUnitModel = dtUnitModel.AsEnumerable().Where(x => (Convert.ToInt32(x["is_bypass"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.is_bypass])));
            dtUnitModel = drUnitModel.Any() ? drUnitModel.CopyToDataTable() : new DataTable();
            drUnitModel = dtUnitModel.AsEnumerable().Where(x => (Convert.ToInt32(x["volt"]) == Convert.ToInt32(dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["volt"])));
            dtUnitModel = drUnitModel.Any() ? drUnitModel.CopyToDataTable() : new DataTable();
            drUnitModel = dtUnitModel.AsEnumerable().Where(x => (Convert.ToInt32(x["phase"]) == Convert.ToInt32(dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["phase"])));
            dtUnitModel = drUnitModel.Any() ? drUnitModel.CopyToDataTable() : new DataTable();
            dblUnitModelPrice = dtUnitModel.Rows.Count > 0 ? Convert.ToDouble(dtUnitModel.Rows[0][strPriceColumn]) : 0d;

            drPriceDetail = dtPriceDetail.NewRow();
            drPriceDetail["cLabel"] = "Unit";
            drPriceDetail["cValue"] = dblUnitModelPrice;
            drPriceDetail["cNotes"] = getAllColumnValues(dtUnitModel);
            dtPriceDetail.Rows.Add(drPriceDetail);


            if (Convert.ToInt32(drCompOpt[ClsDBTC.damper_and_actuator_id]) > 1 && Convert.ToInt32(drSavedUnit[ClsDBTC.location_id]) == ClsID.intLocationIndoorID)
            {
                DataTable dtDamper = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceDamper);

                var drDamper = dtDamper.AsEnumerable().Where(x => ((string)x["unit_model_value"] == strUnitModelValue));
                dtDamper = drDamper.Any() ? drDamper.CopyToDataTable() : new DataTable();
                //drDamper = dtDamper.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == intLocationID));
                //dtDamper = drDamper.Any() ? drDamper.CopyToDataTable() : new DataTable();
                drDamper = dtDamper.AsEnumerable().Where(x => (Convert.ToInt32(x["damper_mounting_id"]) == Convert.ToInt32(drCompOpt[ClsDBTC.damper_and_actuator_id])));
                dtDamper = drDamper.Any() ? drDamper.CopyToDataTable() : new DataTable();
                dblDamperPrice = dtDamper.Rows.Count > 0 ? Convert.ToDouble(dtDamper.Rows[0][strPriceColumn]) : 0d;

                drPriceDetail = dtPriceDetail.NewRow();
                drPriceDetail["cLabel"] = "Damper";
                drPriceDetail["cValue"] = dblDamperPrice;
                drPriceDetail["cNotes"] = getAllColumnValues(dtDamper);
                dtPriceDetail.Rows.Add(drPriceDetail);
            }


            if ((Convert.ToInt32(drCompOpt["cooling_comp_id"]) > 1) && (Convert.ToInt32(drCompOpt["heating_comp_id"]) == ClsID.intCompElecHeaterID || Convert.ToInt32(drCompOpt["reheat_comp_id"]) == ClsID.intCompElecHeaterID))
            {
                var drAccessSection = dtAccessSection.AsEnumerable().Where(x => ((string)x["unit_model_value"] == strUnitModelValue));
                dtAccessSection = drAccessSection.Any() ? drAccessSection.CopyToDataTable() : new DataTable();
                drAccessSection = dtAccessSection.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.location_id])));
                dtAccessSection = drAccessSection.Any() ? drAccessSection.CopyToDataTable() : new DataTable();
                dblAccessSectionPrice = dtAccessSection.Rows.Count > 0 ? Convert.ToDouble(dtAccessSection.Rows[0][strPriceColumn]) : 0d;
                strAccessSectionDetails = "Access Cool with Elec Heat/Reheat";

                drPriceDetail = dtPriceDetail.NewRow();
                drPriceDetail["cLabel"] = strAccessSectionDetails;
                drPriceDetail["cValue"] = dblAccessSectionPrice;
                drPriceDetail["cNotes"] = getAllColumnValues(dtAccessSection);
                dtPriceDetail.Rows.Add(drPriceDetail);
            }


            if ((Convert.ToInt32(drCompOpt["cooling_comp_id"]) > 1) && (Convert.ToInt32(drCompOpt["heating_comp_id"]) == ClsID.intCompHWC_ID || Convert.ToInt32(drCompOpt["reheat_comp_id"]) == ClsID.intCompHWC_ID))
            {
                var drAccessSection = dtAccessSection.AsEnumerable().Where(x => ((string)x["unit_model_value"] == strUnitModelValue));
                dtAccessSection = drAccessSection.Any() ? drAccessSection.CopyToDataTable() : new DataTable();
                drAccessSection = dtAccessSection.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.location_id])));
                dtAccessSection = drAccessSection.Any() ? drAccessSection.CopyToDataTable() : new DataTable();
                dblAccessSectionPrice = dtAccessSection.Rows.Count > 0 ? Convert.ToDouble(dtAccessSection.Rows[0][strPriceColumn]) : 0d;
                strAccessSectionDetails = "Access Cool with Hydro Heat/Reheat";

                drPriceDetail = dtPriceDetail.NewRow();
                drPriceDetail["cLabel"] = strAccessSectionDetails;
                drPriceDetail["cValue"] = dblAccessSectionPrice;
                drPriceDetail["cNotes"] = getAllColumnValues(dtAccessSection);
                dtPriceDetail.Rows.Add(drPriceDetail);
            }


            if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_elec_heater_installation_id]) > 1)
            {
                //if (_objContElem.objCPreheatElecHeater != null)
                if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompElecHeaterID)
                {
                    //if (_objContElem.objCPreheatElecHeater.objElecHeaterIO.intStandardCoilNo > 0)
                    if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_elec_heater_std_coil_no]) > 0)
                    {
                        dtPreheatElecHeater = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceElecHeater);

                        dtPreheatElecHeater = dtPreheatElecHeater.Select("[unit_model_value]='" + strUnitModelValue + "'").CopyToDataTable();
                        //dtPreheatElecHeater = dtPreheatElecHeater.Select("[selection_type_value]='CP'").CopyToDataTable();

                        var drPreheatElecHeater = dtPreheatElecHeater.AsEnumerable().Where(x => ((string)(x["selection_type_value"]) == "CP"));
                        dtPreheatElecHeater = drPreheatElecHeater.Any() ? drPreheatElecHeater.CopyToDataTable() : new DataTable();
                        drPreheatElecHeater = dtPreheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["electric_heater_mounting_id"]) == Convert.ToInt32(drCompOpt[ClsDBTC.preheat_elec_heater_installation_id])));
                        dtPreheatElecHeater = drPreheatElecHeater.Any() ? drPreheatElecHeater.CopyToDataTable() : new DataTable();
                        drPreheatElecHeater = dtPreheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.location_id])));
                        dtPreheatElecHeater = drPreheatElecHeater.Any() ? drPreheatElecHeater.CopyToDataTable() : new DataTable();
                        drPreheatElecHeater = dtPreheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["volt"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["volt"])));
                        dtPreheatElecHeater = drPreheatElecHeater.Any() ? drPreheatElecHeater.CopyToDataTable() : new DataTable();
                        drPreheatElecHeater = dtPreheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["phase"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["phase"])));
                        dtPreheatElecHeater = drPreheatElecHeater.Any() ? drPreheatElecHeater.CopyToDataTable() : new DataTable();
                        //drPreheatElecHeater = dtPreheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["hertz"]) == intHertz));
                        //dtPreheatElecHeater = drPreheatElecHeater.Any() ? drPreheatElecHeater.CopyToDataTable() : new DataTable();

                        //drPreheatElecHeater = dtPreheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["standard_coil_no"]) == _objContElem.objCPreheatElecHeater.objElecHeaterIO.intStandardCoilNo));
                        drPreheatElecHeater = dtPreheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["standard_coil_no"]) == Convert.ToInt32(drCompOpt[ClsDBTC.preheat_elec_heater_std_coil_no])));
                        dtPreheatElecHeater = drPreheatElecHeater.Any() ? drPreheatElecHeater.CopyToDataTable() : new DataTable();
                        dblPreheatElecHeaterPrice = dtPreheatElecHeater.Rows.Count > 0 ? Convert.ToDouble(dtPreheatElecHeater.Rows[0][strPriceColumn]) : 0d;

                        ////dtPreheatElecHeater = dtPreheatElecHeater.Select("[electric_heater_mounting_id]=" + intElecHeaterMountingID).CopyToDataTable();
                        //dtPreheatElecHeater = dtPreheatElecHeater.Select("[location_id]=" + intLocationID).CopyToDataTable();
                        //dtPreheatElecHeater = dtPreheatElecHeater.Select("[volt]=" + intVolt).CopyToDataTable();
                        //dtPreheatElecHeater = dtPreheatElecHeater.Select("[phase]=" + intPhase).CopyToDataTable();
                        //dtPreheatElecHeater = dtPreheatElecHeater.Select("[hertz]=" + intHertz).CopyToDataTable();
                        //dtPreheatElecHeater = dtPreheatElecHeater.Select("[standard_coil_no]=" + _objContElem.objCPreheatElecHeater.objElecHeaterIO.intStandardCoilNo).CopyToDataTable();
                        ////dtPreheatElecHeater = dtPreheatElecHeater.Select("[standard_coil_no]=" + 1).CopyToDataTable();
                        //dblPreheatElecHeaterPrice = dtPreheatElecHeater.Rows.Count > 0 ? Convert.ToDouble(dtPreheatElecHeater.Rows[0][strPriceColumn]) : 0d;

                        drPriceDetail = dtPriceDetail.NewRow();
                        drPriceDetail["cLabel"] = "Preheat Elec Heater";
                        drPriceDetail["cValue"] = dblPreheatElecHeaterPrice;
                        drPriceDetail["cNotes"] = getAllColumnValues(dtPreheatElecHeater);

                        if (Convert.ToInt32(dtPreheatElecHeater.Rows[0][ClsDBTC.casing_drawing_exist]) == 0)
                        {
                            drPriceDetail["cNotes"] += " Electric coil size is too large for standard casing. Submit drawing request to engineering and pull custom price.";
                        }
                        dtPriceDetail.Rows.Add(drPriceDetail);
                    }
                }
            }


            if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_elec_heater_installation_id]) > 1)
            {
                if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID)
                {
                    //if (_objContElem.objCHeatingElecHeater.objElecHeaterIO.intStandardCoilNo > 0)
                    //if (Convert.ToInt32(dtCompOpt.Rows[0]["heating_elec_heater_std_coil_no"]) > 0)
                    if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_elec_heater_std_coil_no]) > 0)
                    {
                        dtHeatingElecHeater = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceElecHeater).Copy();

                        dtHeatingElecHeater = dtHeatingElecHeater.Select("[unit_model_value]='" + strUnitModelValue + "'").CopyToDataTable();
                        //dtHeatingElecHeater = dtHeatingElecHeater.Select("[selection_type_value]='" + strSelecTypeValue + "'").CopyToDataTable();

                        var drHeatingElecHeater = dtHeatingElecHeater.AsEnumerable().Where(x => ((string)(x["selection_type_value"]) == strSelecTypeValue));
                        dtHeatingElecHeater = drHeatingElecHeater.Any() ? drHeatingElecHeater.CopyToDataTable() : new DataTable();
                        drHeatingElecHeater = dtHeatingElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["electric_heater_mounting_id"]) == Convert.ToInt32(drCompOpt[ClsDBTC.heating_elec_heater_installation_id])));
                        dtHeatingElecHeater = drHeatingElecHeater.Any() ? drHeatingElecHeater.CopyToDataTable() : new DataTable();
                        drHeatingElecHeater = dtHeatingElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.location_id])));
                        dtHeatingElecHeater = drHeatingElecHeater.Any() ? drHeatingElecHeater.CopyToDataTable() : new DataTable();
                        drHeatingElecHeater = dtHeatingElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["volt"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["volt"])));
                        dtHeatingElecHeater = drHeatingElecHeater.Any() ? drHeatingElecHeater.CopyToDataTable() : new DataTable();
                        drHeatingElecHeater = dtHeatingElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["phase"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["phase"])));
                        dtHeatingElecHeater = drHeatingElecHeater.Any() ? drHeatingElecHeater.CopyToDataTable() : new DataTable();
                        //drHeatingElecHeater = dtHeatingElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["hertz"]) == intHertz));
                        //dtHeatingElecHeater = drHeatingElecHeater.Any() ? drHeatingElecHeater.CopyToDataTable() : new DataTable();
                        //drHeatingElecHeater = dtHeatingElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["standard_coil_no"]) == _objContElem.objCHeatingElecHeater.objElecHeaterIO.intStandardCoilNo));
                        drHeatingElecHeater = dtHeatingElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["standard_coil_no"]) == Convert.ToInt32(drCompOpt[ClsDBTC.heating_elec_heater_std_coil_no])));
                        dtHeatingElecHeater = drHeatingElecHeater.Any() ? drHeatingElecHeater.CopyToDataTable() : new DataTable();
                        dblHeatingElecHeaterPrice = dtHeatingElecHeater.Rows.Count > 0 ? Convert.ToDouble(dtHeatingElecHeater.Rows[0][strPriceColumn]) : 0d;


                        //dtHeatingElecHeater = dtHeatingElecHeater.Select("[electric_heater_mounting_id]=" + intElecHeaterMountingID).CopyToDataTable();
                        //dtHeatingElecHeater = dtHeatingElecHeater.Select("[location_id]=" + intLocationID).CopyToDataTable();
                        //dtHeatingElecHeater = dtHeatingElecHeater.Select("[volt]=" + intVolt).CopyToDataTable();
                        //dtHeatingElecHeater = dtHeatingElecHeater.Select("[phase]=" + intPhase).CopyToDataTable();
                        //dtHeatingElecHeater = dtHeatingElecHeater.Select("[hertz]=" + intHertz).CopyToDataTable();
                        //dtHeatingElecHeater = dtHeatingElecHeater.Select("[standard_coil_no]=" + _objContElem.objCHeatingElecHeater.objElecHeaterIO.intStandardCoilNo).CopyToDataTable();
                        //dblHeatingElecHeaterPrice = dtHeatingElecHeater.Rows.Count > 0 ? Convert.ToDouble(dtHeatingElecHeater.Rows[0][strPriceColumn]) : 0d;

                        drPriceDetail = dtPriceDetail.NewRow();
                        drPriceDetail["cLabel"] = "Heating Elec Heater";
                        drPriceDetail["cValue"] = dblHeatingElecHeaterPrice;
                        drPriceDetail["cNotes"] = getAllColumnValues(dtHeatingElecHeater);

                        if (Convert.ToInt32(dtHeatingElecHeater.Rows[0][ClsDBTC.casing_drawing_exist]) == 0)
                        {
                            drPriceDetail["cNotes"] += " Electric coil size is too large for standard casing. Submit drawing request to engineering and pull custom price.";
                        }
                        dtPriceDetail.Rows.Add(drPriceDetail);
                    }
                }
                else if (Convert.ToInt32(drCompOpt["reheat_comp_id"]) == ClsID.intCompElecHeaterID)
                {
                    //if (_objContElem.objCReheatElecHeater.objElecHeaterIO.intStandardCoilNo > 0)
                    //if (Convert.ToInt32(dtCompOpt.Rows[0]["reheat_elec_heater_std_coil_no"]) > 0)
                    if (Convert.ToInt32(drCompOpt["reheat_elec_heater_std_coil_no"]) > 0)
                    {
                        dtReheatElecHeater = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceElecHeater).Copy();

                        dtReheatElecHeater = dtReheatElecHeater.Select("[unit_model_value]='" + strUnitModelValue + "'").CopyToDataTable();
                        var drReheatElecHeater = dtReheatElecHeater.AsEnumerable().Where(x => ((string)(x["selection_type_value"]) == strSelecTypeValue));
                        dtReheatElecHeater = drReheatElecHeater.Any() ? drReheatElecHeater.CopyToDataTable() : new DataTable();
                        drReheatElecHeater = dtReheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["electric_heater_mounting_id"]) == Convert.ToInt32(drCompOpt[ClsDBTC.heating_elec_heater_installation_id])));
                        dtReheatElecHeater = drReheatElecHeater.Any() ? drReheatElecHeater.CopyToDataTable() : new DataTable();
                        drReheatElecHeater = dtReheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.location_id])));
                        dtReheatElecHeater = drReheatElecHeater.Any() ? drReheatElecHeater.CopyToDataTable() : new DataTable();
                        drReheatElecHeater = dtReheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["volt"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["volt"])));
                        dtReheatElecHeater = drReheatElecHeater.Any() ? drReheatElecHeater.CopyToDataTable() : new DataTable();
                        drReheatElecHeater = dtReheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["phase"]) == Convert.ToInt32(dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["phase"])));
                        dtReheatElecHeater = drReheatElecHeater.Any() ? drReheatElecHeater.CopyToDataTable() : new DataTable();
                        //drReheatElecHeater = dtReheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["hertz"]) == intHertz));
                        //dtReheatElecHeater = drReheatElecHeater.Any() ? drReheatElecHeater.CopyToDataTable() : new DataTable();
                        //drReheatElecHeater = dtReheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["standard_coil_no"]) == _objContElem.objCReheatElecHeater.objElecHeaterIO.intStandardCoilNo));
                        drReheatElecHeater = dtReheatElecHeater.AsEnumerable().Where(x => (Convert.ToInt32(x["standard_coil_no"]) == Convert.ToInt32(drCompOpt[ClsDBTC.reheat_elec_heater_std_coil_no])));
                        dtReheatElecHeater = drReheatElecHeater.Any() ? drReheatElecHeater.CopyToDataTable() : new DataTable();
                        dblReheatElecHeaterPrice = dtReheatElecHeater.Rows.Count > 0 ? Convert.ToDouble(dtReheatElecHeater.Rows[0][strPriceColumn]) : 0d;

                        drPriceDetail = dtPriceDetail.NewRow();
                        drPriceDetail["cLabel"] = "Reheat Elec Heater";
                        drPriceDetail["cValue"] = dblReheatElecHeaterPrice;
                        drPriceDetail["cNotes"] = getAllColumnValues(dtReheatElecHeater);

                        if (Convert.ToInt32(dtReheatElecHeater.Rows[0][ClsDBTC.casing_drawing_exist]) == 0)
                        {
                            drPriceDetail["cNotes"] += " Electric coil size is too large for standard casing. Submit drawing request to engineering and pull custom price.";
                        }
                        dtPriceDetail.Rows.Add(drPriceDetail);
                    }
                }
            }


            if (Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompHWC_ID)
            {
                dtPreheatHWC = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceHWC);

                dtPreheatHWC = dtPreheatHWC.Select("[unit_model_value]='" + strUnitModelValue + "'").CopyToDataTable();
                //dtPreheatHWC = dtPreheatHWC.Select("[selection_type_value]='CP'").CopyToDataTable();
                var drPreheatHWC = dtPreheatHWC.AsEnumerable().Where(x => ((string)(x["selection_type_value"]) == "CP"));
                dtPreheatHWC = drPreheatHWC.Any() ? drPreheatHWC.CopyToDataTable() : new DataTable();
                drPreheatHWC = dtPreheatHWC.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.location_id])));
                dtPreheatHWC = drPreheatHWC.Any() ? drPreheatHWC.CopyToDataTable() : new DataTable();
                dblPreheatHWC_Price = dtPreheatHWC.Rows.Count > 0 ? Convert.ToDouble(dtPreheatHWC.Rows[0][strPriceColumn]) : 0d;

                drPriceDetail = dtPriceDetail.NewRow();
                drPriceDetail["cLabel"] = "Preheat HWC";
                drPriceDetail["cValue"] = dblPreheatHWC_Price;
                drPriceDetail["cNotes"] = getAllColumnValues(dtPreheatHWC);
                dtPriceDetail.Rows.Add(drPriceDetail);


                //preheat_hwc_valve_and_actuator_id

                //if (_objContElem.objCPreheatHWC.objValveActuatorSize != null)
                if (Convert.ToInt32(drCompOpt[ClsDBTC.is_valve_and_actuator_included]) > 0)
                {
                    dtPreheatHWC_Valve = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceValve);

                    dtPreheatHWC_Valve = dtPreheatHWC_Valve.Select("[unit_model_value]='" + objGen.strUnitModelValueNoLoc + "'").CopyToDataTable();
                    var drPreheatHWC_Valve = dtPreheatHWC_Valve.AsEnumerable().Where(x => ((string)(x["selection_type_value"]) == "CP"));
                    dtPreheatHWC_Valve = drPreheatHWC_Valve.Any() ? drPreheatHWC_Valve.CopyToDataTable() : new DataTable();
                    //drPreheatHWC_Valve = dtPreheatHWC_Valve.AsEnumerable().Where(x => ((string)x["valve_type"] == _objContElem.objCPreheatHWC.objValveActuatorSize.strValveType));
                    drPreheatHWC_Valve = dtPreheatHWC_Valve.AsEnumerable().Where(x => ((string)x["valve_type"] == dsSavedUnitItems.Tables[ClsDBT.strSelValveType].Rows[0]["value"].ToString()));
                    dtPreheatHWC_Valve = drPreheatHWC_Valve.Any() ? drPreheatHWC_Valve.CopyToDataTable() : new DataTable();
                    dblPreheatHWC_ValvePrice = dtPreheatHWC_Valve.Rows.Count > 0 ? Convert.ToDouble(dtPreheatHWC_Valve.Rows[0][strPriceColumn]) : 0d;

                    drPriceDetail = dtPriceDetail.NewRow();
                    drPriceDetail["cLabel"] = "Preheat HWC Valve";
                    drPriceDetail["cValue"] = dblPreheatHWC_ValvePrice;
                    drPriceDetail["cNotes"] = getAllColumnValues(dtPreheatHWC_Valve);
                    dtPriceDetail.Rows.Add(drPriceDetail);
                }
            }


            if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompHWC_ID)
            {
                dtHeatingHWC = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceHWC).Copy();

                dtHeatingHWC = dtHeatingHWC.Select("[unit_model_value]='" + strUnitModelValue + "'").CopyToDataTable();
                //dtHeatingHWC = dtHeatingHWC.Select("[selection_type_value]='" + strSelecTypeValue + "'").CopyToDataTable();
                //dtHeatingHWC = dtHeatingHWC.Select("[location_id]=" + intLocationID).CopyToDataTable();
                var drHeatingHWC = dtHeatingHWC.AsEnumerable().Where(x => ((string)(x["selection_type_value"]) == strSelecTypeValue));
                dtHeatingHWC = drHeatingHWC.Any() ? drHeatingHWC.CopyToDataTable() : new DataTable();
                drHeatingHWC = dtHeatingHWC.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.location_id])));
                dtHeatingHWC = drHeatingHWC.Any() ? drHeatingHWC.CopyToDataTable() : new DataTable();
                dblHeatingHWC_Price = dtHeatingHWC.Rows.Count > 0 ? Convert.ToDouble(dtHeatingHWC.Rows[0][strPriceColumn]) : 0d;

                drPriceDetail = dtPriceDetail.NewRow();
                drPriceDetail["cLabel"] = "Heating HWC";
                drPriceDetail["cValue"] = dblHeatingHWC_Price;
                drPriceDetail["cNotes"] = getAllColumnValues(dtHeatingHWC);
                dtPriceDetail.Rows.Add(drPriceDetail);


                //if (_objContElem.objCHeatingHWC.objValveActuatorSize != null)
                if (Convert.ToInt32(drCompOpt[ClsDBTC.is_valve_and_actuator_included]) > 0)
                {
                    dtHeatingHWC_Valve = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceValve).Copy();

                    //dtValveActuatorType = ClsDB.get_dtByID(ClsDBT.strSelValveAndActuator, Convert.ToInt32(dtCompOpt.Rows[0]["heating_hwc_valve_and_actuator_id"]));

                    dtHeatingHWC_Valve = dtHeatingHWC_Valve.Select("[unit_model_value]='" + objGen.strUnitModelValueNoLoc + "'").CopyToDataTable();
                    var drHeatingHWC_Valve = dtHeatingHWC_Valve.AsEnumerable().Where(x => ((string)(x["selection_type_value"]) == strSelecTypeValue));
                    dtHeatingHWC_Valve = drHeatingHWC_Valve.Any() ? drHeatingHWC_Valve.CopyToDataTable() : new DataTable();
                    //drHeatingHWC_Valve = dtHeatingHWC_Valve.AsEnumerable().Where(x => ((string)x["valve_type"] == _objContElem.objCHeatingHWC.objValveActuatorSize.strValveType));
                    drHeatingHWC_Valve = dtHeatingHWC_Valve.AsEnumerable().Where(x => ((string)x["valve_type"] == dsSavedUnitItems.Tables[ClsDBT.strSelValveType].Rows[0]["value"].ToString()));
                    dtHeatingHWC_Valve = drHeatingHWC_Valve.Any() ? drHeatingHWC_Valve.CopyToDataTable() : new DataTable();
                    dblHeatingHWC_ValvePrice = dtHeatingHWC_Valve.Rows.Count > 0 ? Convert.ToDouble(dtHeatingHWC_Valve.Rows[0][strPriceColumn]) : 0d;

                    drPriceDetail = dtPriceDetail.NewRow();
                    drPriceDetail["cLabel"] = "Heating HWC Valve";
                    drPriceDetail["cValue"] = dblHeatingHWC_ValvePrice;
                    drPriceDetail["cNotes"] = getAllColumnValues(dtHeatingHWC_Valve);
                    dtPriceDetail.Rows.Add(drPriceDetail);
                }
            }
            else if (Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompHWC_ID)
            {
                dtReheatHWC = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceHWC).Copy();

                dtReheatHWC = dtReheatHWC.Select("[unit_model_value]='" + strUnitModelValue + "'").CopyToDataTable();
                //dtReheatHWC = dtReheatHWC.Select("[selection_type_value]='" + strSelecTypeValue + "'").CopyToDataTable();
                //dtReheatHWC = dtReheatHWC.Select("[location_id]=" + intLocationID).CopyToDataTable();
                var drReheatHWC = dtReheatHWC.AsEnumerable().Where(x => ((string)(x["selection_type_value"]) == strSelecTypeValue));
                dtReheatHWC = drReheatHWC.Any() ? drReheatHWC.CopyToDataTable() : new DataTable();
                drReheatHWC = dtReheatHWC.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.location_id])));
                dtReheatHWC = drReheatHWC.Any() ? drReheatHWC.CopyToDataTable() : new DataTable();
                dblReheatHWC_Price = dtReheatHWC.Rows.Count > 0 ? Convert.ToDouble(dtReheatHWC.Rows[0][strPriceColumn]) : 0d;

                drPriceDetail = dtPriceDetail.NewRow();
                drPriceDetail["cLabel"] = "Reheat HWC";
                drPriceDetail["cValue"] = dblReheatHWC_Price;
                drPriceDetail["cNotes"] = getAllColumnValues(dtReheatHWC);
                dtPriceDetail.Rows.Add(drPriceDetail);


                //if (_objContElem.objCReheatHWC.objValveActuatorSize != null)
                if (Convert.ToInt32(drCompOpt[ClsDBTC.is_valve_and_actuator_included]) > 0)
                {
                    dtReheatHWC_Valve = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceValve).Copy();

                    //dtValveActuatorType = ClsDB.get_dtByID(ClsDBT.strSelValveAndActuator, Convert.ToInt32(dtCompOpt.Rows[0]["reheat_hwc_valve_and_actuator_id"]));

                    dtReheatHWC_Valve = dtReheatHWC_Valve.Select("[unit_model_value]='" + objGen.strUnitModelValueNoLoc + "'").CopyToDataTable();
                    var drReheatHWC_Valve = dtReheatHWC_Valve.AsEnumerable().Where(x => ((string)(x["selection_type_value"]) == strSelecTypeValue));
                    dtReheatHWC_Valve = drReheatHWC_Valve.Any() ? drReheatHWC_Valve.CopyToDataTable() : new DataTable();
                    //drReheatHWC_Valve = dtReheatHWC_Valve.AsEnumerable().Where(x => ((string)x["valve_type"] == _objContElem.objCReheatHWC.objValveActuatorSize.strValveType));
                    drReheatHWC_Valve = dtReheatHWC_Valve.AsEnumerable().Where(x => ((string)x["valve_type"] == dsSavedUnitItems.Tables[ClsDBT.strSelValveType].Rows[0]["value"].ToString()));
                    dtReheatHWC_Valve = drReheatHWC_Valve.Any() ? drReheatHWC_Valve.CopyToDataTable() : new DataTable();
                    dblReheatHWC_ValvePrice = dtReheatHWC_Valve.Rows.Count > 0 ? Convert.ToDouble(dtReheatHWC_Valve.Rows[0][strPriceColumn]) : 0d;

                    drPriceDetail = dtPriceDetail.NewRow();
                    drPriceDetail["cLabel"] = "Reheat HWC Valve";
                    drPriceDetail["cValue"] = dblReheatHWC_ValvePrice;
                    drPriceDetail["cNotes"] = getAllColumnValues(dtReheatHWC_Valve);
                    dtPriceDetail.Rows.Add(drPriceDetail);
                }
            }



            if (Convert.ToInt32(drCompOpt[ClsDBTC.cooling_comp_id]) == ClsID.intCompCWC_ID)
            {
                dtCWC = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceCWC);

                dtCWC = dtCWC.Select("[unit_model_value]='" + strUnitModelValue + "'").CopyToDataTable();
                var drCWC = dtCWC.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == Convert.ToInt32(drSavedUnit[ClsDBTC.location_id])));
                dtCWC = drCWC.Any() ? drCWC.CopyToDataTable() : new DataTable();
                dblCWC_Price = dtCWC.Rows.Count > 0 ? Convert.ToDouble(dtCWC.Rows[0][strPriceColumn]) : 0d;

                drPriceDetail = dtPriceDetail.NewRow();
                drPriceDetail["cLabel"] = "CWC";
                drPriceDetail["cValue"] = dblCWC_Price;
                drPriceDetail["cNotes"] = getAllColumnValues(dtCWC);
                dtPriceDetail.Rows.Add(drPriceDetail);


                //if (_objContElem.objCCoolingCWC.objValveActuatorSize != null)
                if (Convert.ToInt32(drCompOpt[ClsDBTC.is_valve_and_actuator_included]) > 0)
                {
                    dtCWC_Valve = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceValve);

                    //dtValveActuatorType = ClsDB.get_dtByID(ClsDBT.strSelValveAndActuator, Convert.ToInt32(dtCompOpt.Rows[0]["cooling_cwc_valve_and_actuator_id"]));

                    dtCWC_Valve = dtCWC_Valve.Select("[unit_model_value]='" + objGen.strUnitModelValueNoLoc + "'").CopyToDataTable();
                    //var drCWC_Valve = dtCWC_Valve.AsEnumerable().Where(x => ((string)x["valve_type"] == _objContElem.objCCoolingCWC.objValveActuatorSize.strValveType));
                    var drCWC_Valve = dtCWC_Valve.AsEnumerable().Where(x => ((string)x["valve_type"] == dsSavedUnitItems.Tables[ClsDBT.strSelValveType].Rows[0]["value"].ToString()));
                    dtCWC_Valve = drCWC_Valve.Any() ? drCWC_Valve.CopyToDataTable() : new DataTable();
                    dblCWC_ValvePrice = dtCWC_Valve.Rows.Count > 0 ? Convert.ToDouble(dtCWC_Valve.Rows[0][strPriceColumn]) : 0d;

                    drPriceDetail = dtPriceDetail.NewRow();
                    drPriceDetail["cLabel"] = "CWC Valve";
                    drPriceDetail["cValue"] = dblCWC_ValvePrice;
                    drPriceDetail["cNotes"] = getAllColumnValues(dtCWC_Valve);
                    dtPriceDetail.Rows.Add(drPriceDetail);
                }
            }
            else if (Convert.ToInt32(drCompOpt[ClsDBTC.cooling_comp_id]) == ClsID.intCompDX_ID)
            {
                //if (_objContElem.objCCoolingDXC_RAE.objEKEXV_KitModel.strModel != null)
                if (Convert.ToDouble(drCompOpt["cooling_dx_vrv_kit_tonnage"]) > 0)
                {
                    dtDXC = ClsDB.get_dtLive(ClsDBT.strSelNovaPriceDXC);

                    dtDXC = dtDXC.Select("[unit_model_value]='" + strUnitModelValue + "'").CopyToDataTable();
                    //dtDXC = dtDXC.Select("[ekexv_kit_model]='" + _objContElem.objCCoolingDX.objEKEXV_KitModel.strModel + "'").CopyToDataTable();

                    //var drDXC = dtDXC.AsEnumerable().Where(x => ((string)(x["ekexv_kit_model"]) == _objContElem.objCCoolingDXC_RAE.objEKEXV_KitModel.strModel));
                    var drDXC = dtDXC.AsEnumerable().Where(x => (Convert.ToDouble(x["tonnage"]) == Convert.ToDouble(drCompOpt["cooling_dx_vrv_kit_tonnage"])));
                    dtDXC = drDXC.Any() ? drDXC.CopyToDataTable() : new DataTable();

                    dblDXC_Price = dtDXC.Rows.Count > 0 ? Convert.ToDouble(dtDXC.Rows[0][strPriceColumn]) : 0d;
                }

                drPriceDetail = dtPriceDetail.NewRow();
                drPriceDetail["cLabel"] = "DX";
                drPriceDetail["cValue"] = dblDXC_Price;
                drPriceDetail["cNotes"] = getAllColumnValues(dtDXC);
                dtPriceDetail.Rows.Add(drPriceDetail);
            }
        }
        #endregion


        private void setSensorPrice()
        {
            #region Sensors
            DataTable dtSensorPricing = ClsDB.get_dtLive(ClsDBT.strSelSensorPrice);
            strSensorDesc = "";

            if (Convert.ToInt32(drSavedUnit[ClsDBTC.product_type_id]) == ClsID.intProdTypeNovaID ||
                Convert.ToInt32(drSavedUnit[ClsDBTC.product_type_id]) == ClsID.intProdTypeVentumID)
            {
                dblControlsByOtherPrice = -1000d;
            }


            if (Convert.ToInt32(drCompOpt[ClsDBTC.is_dehumidification]) == 1 && Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompNA_ID)
            {
                dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorETF_1098L1_4);
                dblSensorDehumNoReheatPrice = dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorETF_1098L1_4 + " (Dehum)";

                if (dtPriceDetail != null)
                {
                    drPriceDetail = dtPriceDetail.NewRow();
                    drPriceDetail["cLabel"] = "Sensor " + ClsGV.strSensorETF_1098L1_4 + " (Dehum)";
                    drPriceDetail["cValue"] = dblSensorDehumNoReheatPrice.ToString();
                    dtPriceDetail.Rows.Add(drPriceDetail);
                }


                if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) > 1)
                {
                    dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorTTH_6202);
                    dblSensorHeatingPrice = dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                    strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorTTH_6202 + " (Heating)";

                    if (dtPriceDetail != null)
                    {
                        drPriceDetail = dtPriceDetail.NewRow();
                        drPriceDetail["cLabel"] = "Sensor " + ClsGV.strSensorTTH_6202 + " (Heating)";
                        drPriceDetail["cValue"] = dblSensorHeatingPrice.ToString();
                        dtPriceDetail.Rows.Add(drPriceDetail);

                    }
                }
            }
            else if (Convert.ToInt32(drCompOpt[ClsDBTC.is_dehumidification]) == 1 && Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompElecHeaterID)
            {
                dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorHTH_6202);
                dblSensorDehumReheatPrice = dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorETF_1098L1_4);
                dblSensorDehumReheatPrice += dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;

                strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorHTH_6202 + " (Dehum & Reheat)";
                strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorETF_1098L1_4 + " (Dehum & Reheat)";
                //strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorETF_598B_5 + " (Dehum & Reheat)";


                if (dtPriceDetail != null)
                {
                    drPriceDetail = dtPriceDetail.NewRow();
                    drPriceDetail["cLabel"] = "Sensor " + ClsGV.strSensorHTH_6202 + " + " + ClsGV.strSensorETF_1098L1_4 + " (Dehum & Reheat)";
                    drPriceDetail["cValue"] = dblSensorDehumReheatPrice.ToString();
                    dtPriceDetail.Rows.Add(drPriceDetail);
                }



                if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompHWC_ID)
                {
                    dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorTTH_6202);
                    dblSensorHeatingPrice = dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                    strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorTTH_6202 + " (Heating)";

                    if (dtPriceDetail != null)
                    {
                        drPriceDetail = dtPriceDetail.NewRow();
                        drPriceDetail["cLabel"] = "Sensor " + ClsGV.strSensorTTH_6202 + " (Heating)";
                        drPriceDetail["cValue"] = dblSensorHeatingPrice.ToString();
                        dtPriceDetail.Rows.Add(drPriceDetail);

                    }
                }
            }
            else if (Convert.ToInt32(drCompOpt[ClsDBTC.is_dehumidification]) == 1 && Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompHWC_ID)
            {
                dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorHTH_6202);
                dblSensorDehumReheatPrice = dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorETF_1098L1_4);
                dblSensorDehumReheatPrice += dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorETF_598B_5);
                dblSensorDehumReheatPrice += dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;


                strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorHTH_6202 + " (Dehum & Reheat)";
                strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorETF_1098L1_4 + " (Dehum & Reheat)";
                strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorETF_598B_5 + " (Dehum & Reheat)";


                if (dtPriceDetail != null)
                {
                    drPriceDetail = dtPriceDetail.NewRow();
                    drPriceDetail["cLabel"] = "Sensor " + ClsGV.strSensorHTH_6202 + " + " + ClsGV.strSensorETF_1098L1_4 + " + " + ClsGV.strSensorETF_598B_5 + " (Dehum & Reheat)";
                    drPriceDetail["cValue"] = dblSensorDehumReheatPrice.ToString();
                    dtPriceDetail.Rows.Add(drPriceDetail);
                }



                if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID)
                {
                    dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorTTH_6202);
                    dblSensorHeatingPrice = dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                    strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorTTH_6202 + " (Heating)";

                    if (dtPriceDetail != null)
                    {
                        drPriceDetail = dtPriceDetail.NewRow();
                        drPriceDetail["cLabel"] = "Sensor " + ClsGV.strSensorTTH_6202 + " (Heating)";
                        drPriceDetail["cValue"] = dblSensorHeatingPrice.ToString();
                        dtPriceDetail.Rows.Add(drPriceDetail);

                    }
                }
            }
            else
            {
                if (Convert.ToInt32(drCompOpt[ClsDBTC.cooling_comp_id]) > 1)
                {
                    dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorTTH_6202);
                    dblSensorCoolingPrice = dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                    strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorTTH_6202 + " (Cooling)";

                    if (dtPriceDetail != null)
                    {
                        drPriceDetail = dtPriceDetail.NewRow();
                        drPriceDetail["cLabel"] = "Sensor " + ClsGV.strSensorTTH_6202 + " (Cooling)";
                        drPriceDetail["cValue"] = dblSensorCoolingPrice.ToString();
                        dtPriceDetail.Rows.Add(drPriceDetail);
                    }
                }


                if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) > 1)
                {
                    dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorTTH_6202);
                    dblSensorHeatingPrice = dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                    strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorTTH_6202 + " (Heating)";

                    if (dtPriceDetail != null)
                    {
                        drPriceDetail = dtPriceDetail.NewRow();
                        drPriceDetail["cLabel"] = "Sensor " + ClsGV.strSensorTTH_6202 + " (Heating)";
                        drPriceDetail["cValue"] = dblSensorHeatingPrice.ToString();
                        dtPriceDetail.Rows.Add(drPriceDetail);
                    }


                    if (Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompHWC_ID)
                    {
                        dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorETF_598B_5);
                        dblSensorHeatingHWC_Price = dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                        strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorTTH_6202 + " (HWC)";

                        if (dtPriceDetail != null)
                        {
                            drPriceDetail = dtPriceDetail.NewRow();
                            drPriceDetail["cLabel"] = "Sensor " + ClsGV.strSensorETF_598B_5 + " (HWC)";
                            drPriceDetail["cValue"] = dblSensorHeatingHWC_Price.ToString();
                            dtPriceDetail.Rows.Add(drPriceDetail);
                        }
                    }
                }

            }







            //
            if (Convert.ToInt32(drSavedUnit[ClsDBTC.product_type_id]) == ClsID.intProdTypeNovaID ||
                Convert.ToInt32(drSavedUnit[ClsDBTC.product_type_id]) == ClsID.intProdTypeVentumID)
            {
                if (Convert.ToInt32(drSavedUnit[ClsDBTC.controls_preference_id]) == ClsID.intControlPrefByOthersID)
                {
                    if (dtPriceDetail != null)
                    {
                        drPriceDetail = dtPriceDetail.NewRow();
                        drPriceDetail["cLabel"] = "Controls: " + dsSavedUnitItems.Tables[ClsDBT.strSelControlsPreference].Rows[0]["items"].ToString();
                        drPriceDetail["cValue"] = dblControlsByOtherPrice.ToString();
                        dtPriceDetail.Rows.Add(drPriceDetail);
                    }
                }
                else if (Convert.ToInt32(drSavedUnit[ClsDBTC.controls_preference_id]) == ClsID.intControlsPrefVAV_ID)
                {
                    dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorPressTrans_PTH_6202);
                    dblSenosrControlsPrefPrice = dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                    strSensorDesc += "<br/>" + "Pressure Transmitter " + ClsGV.strSensorPressTrans_PTH_6202;

                    if (dtPriceDetail != null)
                    {
                        drPriceDetail = dtPriceDetail.NewRow();
                        drPriceDetail["cLabel"] = "Pressure Transmitter " + ClsGV.strSensorPressTrans_PTH_6202;
                        drPriceDetail["cValue"] = dblSenosrControlsPrefPrice.ToString();
                        dtPriceDetail.Rows.Add(drPriceDetail);
                    }
                }
                else if (Convert.ToInt32(drSavedUnit[ClsDBTC.controls_preference_id]) == ClsID.intControlsPrefDCV_CO2_ID)
                {
                    dtSensorPricing = ClsDB.get_dtByValue(ClsDBT.strSelSensorPrice, "value", ClsGV.strSensorVTH_6202_VOC_CO2);
                    dblSenosrControlsPrefPrice = dtSensorPricing.Rows.Count > 0 ? Convert.ToDouble(dtSensorPricing.Rows[0][strPriceColumn]) : 0d;
                    strSensorDesc += "<br/>" + "Sensor " + ClsGV.strSensorVTH_6202_VOC_CO2;

                    if (dtPriceDetail != null)
                    {
                        drPriceDetail = dtPriceDetail.NewRow();
                        drPriceDetail["cLabel"] = "Sensor " + ClsGV.strSensorVTH_6202_VOC_CO2;
                        drPriceDetail["cValue"] = dblSenosrControlsPrefPrice.ToString();
                        dtPriceDetail.Rows.Add(drPriceDetail);
                    }
                }
            }
            #endregion
        }


        //private void setControlsByOtherPrice(ClsContElements _objContElem)
        //{
        //    dblControlsByOtherPrice = _objContElem.objCGeneral.intControlsPreferenceID == ClsID.intControlPrefByOthers ? -1000d : 0d;


        //    if (dtPriceDetail != null)
        //    {
        //        drPriceDetail = dtPriceDetail.NewRow();
        //        drPriceDetail["cLabel"] = "Controls: " + ClsID.intControlPrefByOthers;
        //        drPriceDetail["cValue"] = dblControlsByOtherPrice.ToString();
        //        dtPriceDetail.Rows.Add(drPriceDetail);
        //    }

        //}


        #region Calculate Unit Price
        private void CalculateUnitPrice()
        {
            var drPriceAllUnit = dtPriceDetail.AsEnumerable().Where(x => ((string)(x["cValue"]) == "0"));
            DataTable dtPriceError = drPriceAllUnit.Any() ? drPriceAllUnit.CopyToDataTable() : new DataTable();

            if (dtPriceError.Rows.Count > 0)
            {
                dblPriceAllUnit = -99999;
            }
            else
            {
                dblPriceAllUnit = dtPriceDetail.AsEnumerable().Sum(x => Convert.ToDouble(x["cValue"]));
            }

            //if ((intLoggedUAL == ClsID.intUAL_External || intLoggedUAL == ClsID.intUAL_ExternalSpecial) &&
            //    Convert.ToInt32(drSavedUnit["product_type_id"]) == ClsID.intProdTypeVentumID &&
            //    Convert.ToInt32(drSavedUnit["unit_type_id"]) == ClsID.intUnitTypeERV_ID)
            //{
            //    dblPriceAllUnit = 0;
            //}

            drPriceDetail = dtPriceDetail.NewRow();
            drPriceDetail["cLabel"] = "Total";
            drPriceDetail["cValue"] = dblPriceAllUnit;
            dtPriceDetail.Rows.Add(drPriceDetail);
        }
        #endregion


        #region CalcPricingFinal
        public void CalcPricingFinal()
        {
            DataTable dtSavedUnitList = ClsDB.GetSavedUnitsModel(intJobID);

            if (dtSavedUnitList.Rows.Count > 0)
            {
                DataTable dtSavedPricingMisc = ClsDB.GetSavedQuoteMisc(intJobID);
                //DataTable dtSavedPricing = ClsDB.GetSavedPricing(intJobID);
                //DataRow dr = dtSavedPricing.Rows[0];

                //int intCountryID = Convert.ToInt32(dr["country_id"]);
                //int intFOB_PointID = Convert.ToInt32(dr["fob_point_id"]);
                //double dblCurrencyRate = Convert.ToDouble(dr["currency_rate"]);
                //int intShippingTypeID = Convert.ToInt32(dr["shipping_type_id"]);
                //double dblShippingFactor = Convert.ToDouble(dr["shipping_factor"]);
                //int intDiscountTypeID = Convert.ToInt32(dr["discount_type_id"]);
                //double dblDiscountFactor = Convert.ToDouble(dr["discount_factor"]);

                dblPriceAllUnit = dtSavedUnitList.AsEnumerable().Sum(x => Convert.ToDouble(x["unit_price"]) * Convert.ToInt32(x["qty"]));
                dblPriceMisc = dtSavedPricingMisc.AsEnumerable().Sum(x => Convert.ToDouble(x["price"]) * Convert.ToInt32(x["qty"]));

                dblPriceAllUnit = dblPriceAllUnit * dblCurrencyRate;
                //dblPriceMisc = dblPriceMisc * _dblCurrencyRate;

                dblPriceUnitsAndMisc = dblPriceAllUnit + dblPriceMisc;

                double dblPriceShippingInPercent = dblPriceUnitsAndMisc * (dblShippingFactor / 100);

                dblPriceShipping = intShippingTypeID == ClsID.intCurrencyPercent ? dblPriceShippingInPercent : dblShippingFactor;

                dblPriceSubtotal = dblPriceUnitsAndMisc + dblPriceShipping;

                double dblDiscountInPercent = dblPriceSubtotal * (dblDiscountFactor / 100d);

                dblPriceDiscount = intDiscountTypeID == ClsID.intCurrencyPercent ? dblDiscountInPercent : dblDiscountFactor;

                dblPriceFinal = dblPriceSubtotal - dblPriceDiscount;


                setDisPricingGeneral();
                setDisPricingUnits();
                setDisPricingMisc();
                setDisPricingShipping();
                //setIncludesAndExcept(_intJobID);
                setDisPricingTotal();
            }
        }
        #endregion


        #region set Dis Pricing General
        private void setDisPricingGeneral()
        {
            DataTable dtCountry = ClsDB.get_dtByID(ClsDBT.strSelCountry, intCountryID);
            string strCurrency = " (" + dtCountry.Rows[0]["currency"].ToString() + ")";

            //DataTable dtUser = ClsDB.GetUser(Convert.ToInt32(Request.QueryString[ClsSV._intUserID]));
            //string strFOB_Point = dtUser.Rows[0]["FOB_Point_City"].ToString() + ", " + dtUser.Rows[0]["FOB_Point_State"].ToString() + " \n" + dtUser.Rows[0]["FOB_Point_Country"].ToString();

            DataTable dtFOB_Point = ClsDB.get_dtByID(ClsDBT.strSelFOB_Point, intFOB_PointID);
            string strFOB_Point = dtFOB_Point.Rows[0]["city"].ToString() + ", " + dtFOB_Point.Rows[0]["state"].ToString() + " <br/>" + dtFOB_Point.Rows[0]["country"].ToString();

            DataTable dt = new DataTable("");
            dt.Columns.Add("notes", typeof(string));
            //dt.Columns.Add("project_name", typeof(string)); //Display number
            //dt.Columns.Add("lead_time", typeof(string));
            dt.Columns.Add("fob_point", typeof(string));
            dt.Columns.Add("terms", typeof(string));

            DataRow dr = dt.NewRow();
            dr["notes"] = ("Taxes not included. <br/>All prices are in " + strCurrency);
            //dr["project_name"] = objJobInfo.get_strJobName();
            //dr["lead_time"] = "8-10 Weeks";
            dr["fob_point"] = strFOB_Point; //Add HtmlEncode="False" to asp:BoundField ;
            dr["terms"] = "Net 30";
            dt.Rows.Add(dr);


            dtDisPricingGeneral = dt;
        }
        #endregion


        #region set Dis Pricing Units
        private void setDisPricingUnits()
        {
            double dblUnitPrice = 0d;
            double dblUnitPriceAtCurrRate = 0d;
            double dblUnitTotalPrice = 0d;


            DataTable dtDispUnitPrice = getPricingTable();
            DataTable dtDispErrMsg = getPricingErrMsgTable();

            DataRow drDispUnitPrice = dtDispUnitPrice.NewRow();
            DataRow drDispErrMsg = dtDispErrMsg.NewRow();

            DataTable dtUser = ClsDB.GetUser(intLoggedUserID);
            DataTable dtSavedUnitList = ClsDB.GetSavedUnitsModel(intJobID);
            dtPI = ClsDB.GetSavedJobItems(intJobID).Tables[ClsDBT.strSavJob];

            strPriceColumn = Convert.ToInt32(dtPI.Rows[0][ClsDBTC.is_test_new_price]) == 1 ? ClsDBTC.new_price_test : ClsDBTC.price;

            if (dtSavedUnitList.Rows.Count > 0)
            {
                for (int i = 0; i < dtSavedUnitList.Rows.Count; i++)
                {
                    int intThisProdTypeID = Convert.ToInt32(dtSavedUnitList.Rows[i]["product_type_id"]);
                    int intUnitTypeID = Convert.ToInt32(dtSavedUnitList.Rows[i]["unit_type_id"]);

                    //ClsContainer objCont = new ClsContainer(intLoggedUserID, intJobID, Convert.ToInt32(dtSavedUnitList.Rows[i]["unit_no"]));

                    drDispUnitPrice = dtDispUnitPrice.NewRow();
                    drDispUnitPrice["unit_no"] = Convert.ToInt32(dtSavedUnitList.Rows[i]["unit_no"]);
                    drDispUnitPrice["product_type_id"] = intThisProdTypeID;
                    drDispUnitPrice["unit_nbr"] = i + 1;
                    drDispUnitPrice["tag"] = dtSavedUnitList.Rows[i]["tag"].ToString();
                    drDispUnitPrice["qty"] = dtSavedUnitList.Rows[i]["qty"].ToString();
                    drDispUnitPrice["unit_type"] = ClsDB.get_dtByID(ClsDBT.strSelUnitType, Convert.ToInt32(dtSavedUnitList.Rows[i]["unit_type_id"])).Rows[0]["dwg_code"].ToString();
                    //dr["unit_model"] = Convert.ToInt32(dtUnitList.Rows[i]["unit_model_id"]) > 0 ? ClsDBM.SelectById(ClsDBT.strSelNovaUnitModel, Convert.ToInt32(dtUnitList.Rows[i]["unit_model_id"])).Rows[0]["value"].ToString() : "";

                    if (intThisProdTypeID == ClsID.intProdTypeNovaID)
                    {
                        drDispUnitPrice["unit_model"] = dtSavedUnitList.Rows[i]["NovaUnitModel"].ToString();
                    }
                    else if (intThisProdTypeID == ClsID.intProdTypeVentumID || intThisProdTypeID == ClsID.intProdTypeVentumLiteID)
                    {
                        drDispUnitPrice["unit_model"] = intUnitTypeID == ClsID.intUnitTypeERV_ID ? dtSavedUnitList.Rows[i]["VentumUnitModelERV"].ToString() : dtSavedUnitList.Rows[i]["VentumUnitModelHRV"].ToString();
                    }


                    //objCont = new ClsContainer(intLoggedUserID, intJobID, Convert.ToInt32(dtSavedUnitList.Rows[i]["unit_no"]));
                    //ClsContElements objContElem = objCont.get_objContElem();
                    //ClsComponentItems objCompItems = objCont.get_objContElem().objCCompItems;
                    objGen = new ClsGeneral(intJobID, Convert.ToInt32(dtSavedUnitList.Rows[i]["unit_no"]));
                    //objComp = new ClsComponentItems(intJobID, Convert.ToInt32(dtSavedUnitList.Rows[i]["unit_no"]));
                    dsSavedUnitItems = objGen.dsSavedUnitItems;
                    dtSavedUnit = dsSavedUnitItems.Tables[ClsDBT.strSavGeneral];
                    drSavedUnit = dtSavedUnit.Rows[0];
                    //dtCompOpt = dsSavedUnitItems.Tables[ClsDBT.strSavCompOption];
                    drCompOpt = dsSavedUnitItems.Tables[ClsDBT.strSavCompOption].Rows[0];


                    string strDesc = "";
                    string strUnitCost = "";
                    string strTotalCost = "";
                    //strDesc += "Dimensions (in): " + objGeneral.get_strUnitCabinetDim() + "";
                    //strDesc += "\nOrientation: " + objGeneral.get_strOrientation();
                    //strDesc += "\nInstallation: " + objGeneral.get_strLocation();
                    strDesc += "Controls: " + dsSavedUnitItems.Tables[ClsDBT.strSelControlsPreference].Rows[0]["items"].ToString();
                    strDesc += "<br/>Voltage: " + dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["items"].ToString();
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.damper_and_actuator_id]) > 1 ? "<br/>Damper & Actuator: " + dsSavedUnitItems.Tables[ClsDBT.strSelDamperActuator].Rows[0]["items"].ToString() : "";
                    //strDesc += objCompItems.objCompOpt.intOA_FilterModelID > 1 ? "\nOA Filter: " + objContElem.objCOA_Filter.get_strModel() : "";
                    //strDesc += objCompItems.objCompOpt.intRA_FilterModelID > 1 ? "\nRA Filter: " + objContElem.objCRA_Filter.get_strModel() : "";
                    //strDesc += objCompItems.objCompOpt.intSA_FinalFilterModelID > 1 ? "\nSA final filter: " : "";
                    //strDesc += "\n";
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompElecHeaterID ? "<br/>Preheat: Elec. heater" : "";
                    //strDesc += objCompOpt.objCompOptData.intPreheatCompID == ClsID.intUnitHeatingCoolingElecHeaterID ? "\nElec. heater voltage: " + objCompOpt.objCompOptData.strElecHeaterVoltage : "";
                    //strDesc += objCompOpt.objCompOptData.intPreheatCompID == ClsID.intUnitHeatingCoolingElecHeaterID ? "\nElec. heater installation: " + objCompOpt.objCompOptData.strElecHeaterInstallation : "";
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompHWC_ID ? "<br/>Preheat: Hot water coil" : "";
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.cooling_comp_id]) == ClsID.intCompCWC_ID ? "<br/>Cooling: Chilled water coil" : "";
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.cooling_comp_id]) == ClsID.intCompDX_ID ? "<br/>Cooling: DX coil" : "";
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompHWC_ID ? "<br/>Heating: Hot water coil" : "";
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.is_valve_and_actuator_included]) == 1 ? "<br/>Hydronic valve & actuator included" : "";
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID ? "<br/>Heating: Electric Heater" : "";
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompElecHeaterID ? "<br/>Reheat: Electric Heater" : "";
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompElecHeaterID || Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID || Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompElecHeaterID ? "<br/>Elec. heater voltage: " + dsSavedUnitItems.Tables["ElecHeaterVoltage"].Rows[0]["items"].ToString() : "";
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.preheat_comp_id]) == ClsID.intCompElecHeaterID ? "<br/>Preheat Elec. heater installation: " + dsSavedUnitItems.Tables["PreheatElecHeaterInstallation"].Rows[0]["items"].ToString() : "";
                    strDesc += Convert.ToInt32(drCompOpt[ClsDBTC.heating_comp_id]) == ClsID.intCompElecHeaterID || Convert.ToInt32(drCompOpt[ClsDBTC.reheat_comp_id]) == ClsID.intCompElecHeaterID ? "<br/>Heat/Post Elec. heater installation: " + dsSavedUnitItems.Tables["HeatingElecHeaterInstallation"].Rows[0]["items"].ToString() : "";
                    //strDesc += "<p style=\"color:Blue;\">" + "&nbsp;&nbsp;Shipping Cost:" + "</p>";


                    setSensorPrice();
                    strDesc += strSensorDesc;


                    strDesc += "<br/>";


                    dblUnitPrice = Convert.ToDouble(dtSavedUnitList.Rows[i]["unit_price"]);
                    dblUnitPriceAtCurrRate = dblUnitPrice * dblCurrencyRate;
                    strUnitCost = "$" + String.Format("{0:#,0.00}", dblUnitPriceAtCurrRate);

                    dblUnitTotalPrice = dblUnitPriceAtCurrRate * Convert.ToInt32(dtSavedUnitList.Rows[i]["qty"]);

                    int intNumLines = strDesc.Split('\n').Length;

                    strTotalCost += "$" + String.Format("{0:#,0.00}", dblUnitTotalPrice);

                    //for (int j = 0; j < intNumLines - 2; j++)
                    //{
                    //    strTotalCost += "\n";
                    //}
                    ////strTotalCost += "$" + (dblTotalPrice * dblShippingPercent).ToString();
                    //strTotalCost += "<p style=\"color:Blue;\">" + "$" + String.Format("{0:#,0.00}", (dblTotalPrice * dblShippingPercent)) + "&nbsp;&nbsp;</p>";


                    //dr["total_price"] = strCost;


                    drDispUnitPrice["description"] = strDesc;       //Add HtmlEncode="False" to asp:BoundField 
                    drDispUnitPrice["unit_price"] = strUnitCost;    //Add HtmlEncode="False" to asp:BoundField 
                    drDispUnitPrice["total_price"] = strTotalCost;

                    if (dblUnitTotalPrice == 0)    //Add HtmlEncode="False" to asp:BoundField 
                    {
                        //drDispUnitPrice["total_price"] = strTotalCost + "<br />< p style =\"color:Blue;\">Return to Selection page and re-run this unit selection to get price</p>";                //Add HtmlEncode="False" to asp:BoundField 
                        drDispUnitPrice["price_error_msg"] = "1";    //Add HtmlEncode="False" to asp:BoundField 

                        drDispErrMsg = dtDispErrMsg.NewRow();
                        drDispErrMsg["price_error_msg_no"] = "1";
                        drDispErrMsg["price_error_msg"] = "-$0.00: Return to Selection page and re-run this unit selection to get price";
                        dtDispErrMsg.Rows.Add(drDispErrMsg);
                    }
                    else if (Convert.ToInt32(dblUnitPrice) == -99999)    //Add HtmlEncode="False" to asp:BoundField 
                    {
                        //drDispUnitPrice["total_price"] = strTotalCost + "<br />< p style =\"color:Blue;\">Return to Selection page and re-run this unit selection to get price</p>";                //Add HtmlEncode="False" to asp:BoundField 
                        drDispUnitPrice["price_error_msg"] = "2";    //Add HtmlEncode="False" to asp:BoundField 
                        drDispUnitPrice["unit_price"] = dblUnitPrice.ToString();    //Add HtmlEncode="False" to asp:BoundField 
                        drDispUnitPrice["total_price"] = dblUnitPrice.ToString();

                        drDispErrMsg = dtDispErrMsg.NewRow();
                        drDispErrMsg["price_error_msg_no"] = "2";
                        drDispErrMsg["price_error_msg"] = "-$99999: Pricing error has occurred, contact applications@oxygen8.ca for a quote";
                        dtDispErrMsg.Rows.Add(drDispErrMsg);
                    }
                    else
                    {
                        drDispUnitPrice["price_error_msg"] = "0";    //Add HtmlEncode="False" to asp:BoundField 
                    }


                    if (Convert.ToInt32(dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["id"]) == ClsID.intElectricVoltage_208V_1Ph_60HzID)
                    {
                        drDispErrMsg = dtDispErrMsg.NewRow();
                        drDispErrMsg["price_error_msg_no"] = "3";
                        drDispErrMsg["price_error_msg"] = "-" + dsSavedUnitItems.Tables[ClsDBT.strSelElectricalVoltage].Rows[0]["items"].ToString() + " Fan: Contact Oxygen8 for updated lead times";
                        dtDispErrMsg.Rows.Add(drDispErrMsg);
                    }

                    dtDispUnitPrice.Rows.Add(drDispUnitPrice);
                }
            }


            //gvPricing.Visible = true;
            //gvPricing.DataSource = dtDispUnitPrice;
            //gvPricing.DataBind();
            //gvPricing.SelectedIndex = -1;


            dtDisPricingUnitsPrice = dtDispUnitPrice;

            DataView view = new DataView(dtDispErrMsg);

            DataTable distinctValues = view.ToTable(true, "price_error_msg_no", "price_error_msg");
            distinctValues.DefaultView.Sort = "price_error_msg_no";
            dtDisPricingErrMsg = distinctValues;
        }
        #endregion


        #region Set Dis Pricing Misc
        private void setDisPricingMisc()
        {
            DataTable dtSavedPricingMisc = ClsDB.GetSavedQuoteMisc(intJobID);

            DataTable dtDispMiscPrice = getPricingTable();
            DataRow drDispUnitPrice = dtDispMiscPrice.NewRow();

            //DataTable dtDispMiscPrice = dtDispUnitPrice.Clone();
            DataRow drDispMiscPrice = dtDispMiscPrice.NewRow();

            double dblUnitPrice = 0d;
            double dblTotalPrice = 0d;

            if (dtSavedPricingMisc.Rows.Count > 0)
            {
                for (int i = 0; i < dtSavedPricingMisc.Rows.Count; i++)
                {
                    drDispMiscPrice = dtDispMiscPrice.NewRow();
                    drDispMiscPrice["unit_no"] = Convert.ToInt32(dtSavedPricingMisc.Rows[i]["misc_no"]);
                    drDispMiscPrice["qty"] = dtSavedPricingMisc.Rows[i]["qty"].ToString();
                    drDispMiscPrice["unit_type"] = "Misc";
                    dblUnitPrice = Convert.ToDouble(dtSavedPricingMisc.Rows[i]["price"]);
                    dblTotalPrice = Convert.ToDouble(dtSavedPricingMisc.Rows[i]["price"]) * Convert.ToInt32(dtSavedPricingMisc.Rows[i]["qty"]);

                    drDispMiscPrice["description"] = (String.Format("{0:#,0.00}", dtSavedPricingMisc.Rows[i]["misc"].ToString())); //Add HtmlEncode="False" to asp:BoundField 
                    drDispMiscPrice["unit_price"] = ("$" + String.Format("{0:#,0.00}", dblUnitPrice)); //Add HtmlEncode="False" to asp:BoundField 
                    drDispMiscPrice["total_price"] = ("$" + String.Format("{0:#,0.00}", dblTotalPrice)); //Add HtmlEncode="False" to asp:BoundField 
                    dtDispMiscPrice.Rows.Add(drDispMiscPrice);
                }
            }

            //gvPricingMisc.Visible = true;
            //gvPricingMisc.DataSource = dtDispMiscPrice;
            //gvPricingMisc.DataBind();
            //gvPricingMisc.SelectedIndex = -1;

            dtDisPricingMisc = dtDispMiscPrice;
        }
        #endregion


        #region set Dis Pricing Shipping
        private void setDisPricingShipping()
        {
            //string strShippingCost = "<p style=\"color:Blue;\">" + "$" + String.Format("{0:#,0.00}", dblPriceShipping) + "</p>";
            string strShippingCost = "$" + String.Format("{0:#,0.00}", dblPriceShipping);

            DataTable dtDispUnitPrice = getPricingTable();
            DataRow drDispUnitPrice;

            dtDispUnitPrice.Rows.Clear();
            drDispUnitPrice = dtDispUnitPrice.NewRow();
            drDispUnitPrice["qty"] = "1";
            drDispUnitPrice["description"] = "Shipping Cost:"; //Add HtmlEncode="False" to asp:BoundField 
            //dr["unit_price"] = "&nbsp;&nbsp;" + strShippingCost.Replace("\n", "<br/>&nbsp;&nbsp;"); //Add HtmlEncode="False" to asp:BoundField 
            //dr["total_price"] = "&nbsp;&nbsp;" + strShippingCost.Replace("\n", "<br/>&nbsp;&nbsp;"); //Add HtmlEncode="False" to asp:BoundField 
            drDispUnitPrice["unit_price"] = strShippingCost; //Add HtmlEncode="False" to asp:BoundField 
            drDispUnitPrice["total_price"] = strShippingCost; //Add HtmlEncode="False" to asp:BoundField 
            dtDispUnitPrice.Rows.Add(drDispUnitPrice);


            dtDisPricigShipping = dtDispUnitPrice;
        }
        #endregion


        #region set Dis Pricing Total
        private void setDisPricingTotal()
        {
            DataTable dtCountry = ClsDB.get_dtByID(ClsDBT.strSelCountry, intCountryID);
            string strCurrency = " (" + dtCountry.Rows[0]["currency"].ToString() + ")";

            DataTable dtAddInfo = new DataTable("");
            dtAddInfo.Columns.Add("add_info", typeof(string));  //Additional info
            dtAddInfo.Columns.Add("is_add_info_bold", typeof(int));  //Additional info
            DataRow drAddInfo;

            DataTable dtTotalPrice = new DataTable("");
            dtTotalPrice.Columns.Add("price_label", typeof(string)); //Display number
            dtTotalPrice.Columns.Add("price", typeof(string)); //Display number
            dtTotalPrice.Columns.Add("currency", typeof(string)); //Display number
            DataRow drTotalPrice;


            int intDX_CoilCount = 0;
            int intOutdoorUnitCount = 0;

            drAddInfo = dtAddInfo.NewRow();
            drAddInfo["add_info"] = "Includes:";
            drAddInfo["is_add_info_bold"] = 1;
            dtAddInfo.Rows.Add(drAddInfo);

            drAddInfo = dtAddInfo.NewRow();
            drAddInfo["add_info"] = "- Integrated controls - BACNet IP and BTL Certified, filter & temperature sensors.";
            drAddInfo["is_add_info_bold"] = 0;
            dtAddInfo.Rows.Add(drAddInfo);

            drAddInfo = dtAddInfo.NewRow();
            drAddInfo["add_info"] = "- Unit warranty: 12 months from start up or 18 months from delivery.";
            drAddInfo["is_add_info_bold"] = 0;
            dtAddInfo.Rows.Add(drAddInfo);

            drAddInfo = dtAddInfo.NewRow();
            drAddInfo["add_info"] = "- CORE warranty: 5 years from shipping";
            drAddInfo["is_add_info_bold"] = 0;
            dtAddInfo.Rows.Add(drAddInfo);


            DataTable dtSavedUnits = ClsDB.GetSavedUnitsAndComps(intJobID);
            var drOutdoorUnits = dtSavedUnits.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == ClsID.intLocationOutdoorID));
            dtSavedUnits = drOutdoorUnits.Any() ? drOutdoorUnits.CopyToDataTable() : new DataTable();
            intOutdoorUnitCount = dtSavedUnits.Rows.Count > 0 ? dtSavedUnits.Rows.Count : 0;


            DataTable dtOptions = ClsDB.GetSavedCompOpt(Convert.ToInt32(intJobID));
            var drDX = dtOptions.AsEnumerable().Where(x => (Convert.ToInt32(x["cooling_comp_id"]) == ClsID.intCompDX_ID));
            dtOptions = drDX.Any() ? drDX.CopyToDataTable() : new DataTable();
            intDX_CoilCount = dtOptions.Rows.Count > 0 ? dtOptions.Rows.Count : 0;

            //if (intDX_CoilCount > 0 || intOutdoorUnitCount > 0)
            //{
            //    strDisIncludesInfo += "<br/><br/>Exceptions:";

            //    if (intDX_CoilCount > 0)
            //    {
            //        strDisIncludesInfo += "<br/> - Daikin AHU EKEXV Integration kit not included";
            //        strDisIncludesInfo += "<br/> - Daikin W Controller not included";

            //    }

            //    if (intOutdoorUnitCount > 0)
            //    {
            //        strDisIncludesInfo += "<br/> - Curb not provided by Oxygen8";
            //        strDisIncludesInfo += "<br/> - Accessory roof and hood ship separately for field installation.";
            //    }
            //}


            if (intDX_CoilCount > 0 || intOutdoorUnitCount > 0)
            {
                drAddInfo = dtAddInfo.NewRow();
                drAddInfo["add_info"] = "";
                drAddInfo["is_add_info_bold"] = 0;
                dtAddInfo.Rows.Add(drAddInfo);

                drAddInfo = dtAddInfo.NewRow();
                drAddInfo["add_info"] = "Exceptions:";
                drAddInfo["is_add_info_bold"] = 1;
                dtAddInfo.Rows.Add(drAddInfo);


                if (intDX_CoilCount > 0)
                {
                    drAddInfo = dtAddInfo.NewRow();
                    drAddInfo["add_info"] = "- Daikin AHU EKEXV Integration kit not included";
                    drAddInfo["is_add_info_bold"] = 0;
                    dtAddInfo.Rows.Add(drAddInfo);

                    drAddInfo = dtAddInfo.NewRow();
                    drAddInfo["add_info"] = "- Daikin W Controller not included";
                    drAddInfo["is_add_info_bold"] = 0;
                    dtAddInfo.Rows.Add(drAddInfo);
                }


                if (intOutdoorUnitCount > 0)
                {
                    drAddInfo = dtAddInfo.NewRow();
                    drAddInfo["add_info"] = "- Curb not provided by Oxygen8";
                    drAddInfo["is_add_info_bold"] = 0;
                    dtAddInfo.Rows.Add(drAddInfo);

                    drAddInfo = dtAddInfo.NewRow();
                    drAddInfo["add_info"] = "- Accessory roof and hood ship separately for field installation.";
                    drAddInfo["is_add_info_bold"] = 0;
                    dtAddInfo.Rows.Add(drAddInfo);
                }
            }


            drAddInfo = dtAddInfo.NewRow();
            drAddInfo["add_info"] = "";
            drAddInfo["is_add_info_bold"] = 0;
            dtAddInfo.Rows.Add(drAddInfo);

            drAddInfo = dtAddInfo.NewRow();
            drAddInfo["add_info"] = "Notes:";
            drAddInfo["is_add_info_bold"] = 1;
            dtAddInfo.Rows.Add(drAddInfo);

            //drAddInfo = dtAddInfo.NewRow();
            //drAddInfo["add_info"] = "- Shipping is an estimate, contact applications@oxygen8.ca for final quote";
            //drAddInfo["is_add_info_bold"] = 0;
            //dtAddInfo.Rows.Add(drAddInfo);


            DataTable dtNotes = ClsDB.GetSavedQuoteNotes(intJobID);
            if (dtNotes.Rows.Count > 0)
            {
                for (int i = 0; i < dtNotes.Rows.Count; i++)
                {
                    drAddInfo = dtAddInfo.NewRow();
                    drAddInfo["add_info"] = "- " + dtNotes.Rows[i]["notes"].ToString();
                    drAddInfo["is_add_info_bold"] = 0;
                    dtAddInfo.Rows.Add(drAddInfo);
                }
            }



            drTotalPrice = dtTotalPrice.NewRow();
            drTotalPrice["price_label"] = "SUBTOTAL:";
            drTotalPrice["price"] = "$" + String.Format("{0:#,0.00}", dblPriceSubtotal);
            drTotalPrice["currency"] = strCurrency;
            dtTotalPrice.Rows.Add(drTotalPrice);

            if (dblPriceDiscount > 0d)
            {
                drTotalPrice = dtTotalPrice.NewRow();
                drTotalPrice["price_label"] = "DISCOUNT:";
                drTotalPrice["price"] = "$" + String.Format("{0:#,0.00}", dblPriceDiscount);
                drTotalPrice["currency"] = strCurrency;
                dtTotalPrice.Rows.Add(drTotalPrice);
            }
            drTotalPrice = dtTotalPrice.NewRow();
            drTotalPrice["price_label"] = "TOTAL:";
            drTotalPrice["price"] = "$" + String.Format("{0:#,0.00}", dblPriceFinal);
            drTotalPrice["currency"] = strCurrency;
            dtTotalPrice.Rows.Add(drTotalPrice);


            dtDisPriceAddInfo = dtAddInfo;
            dtDisTotalPrice = dtTotalPrice;
        }
        #endregion


        #region #set Dis Includes And Exception
        private void setIncludesAndExcept()
        {
            int intDX_CoilCount = 0;
            int intOutdoorUnitCount = 0;

            strDisIncludesInfo = "Includes:";
            strDisIncludesInfo += "<br/> - Integrated controls - BACNet IP and BTL Certified, filter & temperature sensors";
            //strInfo += "\n - Standard 2 year warranty on unit, 5 year warranty on CORE";
            strDisIncludesInfo += "<br/> - Unit warranty: 12 months from start up or 18 months from delivery.";
            strDisIncludesInfo += "<br/> - CORE warranty: 5 years from shipping";

            DataTable dtSavedUnits = ClsDB.GetSavedUnitsAndComps(intJobID);
            var drOutdoorUnits = dtSavedUnits.AsEnumerable().Where(x => (Convert.ToInt32(x["location_id"]) == ClsID.intLocationOutdoorID));
            dtSavedUnits = drOutdoorUnits.Any() ? drOutdoorUnits.CopyToDataTable() : new DataTable();
            intOutdoorUnitCount = dtSavedUnits.Rows.Count > 0 ? dtSavedUnits.Rows.Count : 0;


            DataTable dtOptions = ClsDB.GetSavedCompOpt(Convert.ToInt32(intJobID));
            var drDX = dtOptions.AsEnumerable().Where(x => (Convert.ToInt32(x["cooling_comp_id"]) == ClsID.intCompDX_ID));
            dtOptions = drDX.Any() ? drDX.CopyToDataTable() : new DataTable();
            intDX_CoilCount = dtOptions.Rows.Count > 0 ? dtOptions.Rows.Count : 0;

            if (intDX_CoilCount > 0 || intOutdoorUnitCount > 0)
            {
                strDisIncludesInfo += "<br/><br/>Exceptions:";

                if (intDX_CoilCount > 0)
                {
                    strDisIncludesInfo += "<br/> - Daikin AHU EKEXV Integration kit not included";
                    strDisIncludesInfo += "<br/> - Daikin W Controller not included";

                }

                if (intOutdoorUnitCount > 0)
                {
                    strDisIncludesInfo += "<br/> - Curb not provided by Oxygen8";
                    strDisIncludesInfo += "<br/> - Accessory roof and hood ship separately for field installation.";
                }
            }


            DataTable dtNotes = ClsDB.GetSavedQuoteNotes(intJobID);
            if (dtNotes.Rows.Count > 0)
            {
                strDisIncludesInfo += "<br/><br/>Notes:";

                for (int i = 0; i < dtNotes.Rows.Count; i++)
                {
                    strDisIncludesInfo += "<br/> - " + dtNotes.Rows[i]["notes"].ToString();
                }
            }
        }
        #endregion


        private DataTable getPricingTable()
        {
            DataTable dtDispUnitPrice = new DataTable("");
            dtDispUnitPrice.Columns.Add("price_error_msg", typeof(string));
            dtDispUnitPrice.Columns.Add("unit_no", typeof(int));  //Actual unit number
            dtDispUnitPrice.Columns.Add("product_type_id", typeof(int));  //Product Type ID
            dtDispUnitPrice.Columns.Add("unit_nbr", typeof(string)); //Display number
            dtDispUnitPrice.Columns.Add("tag", typeof(string));
            dtDispUnitPrice.Columns.Add("qty", typeof(int));
            dtDispUnitPrice.Columns.Add("unit_type", typeof(string));
            dtDispUnitPrice.Columns.Add("unit_model", typeof(string));
            dtDispUnitPrice.Columns.Add("description", typeof(string));
            dtDispUnitPrice.Columns.Add("unit_price", typeof(string));
            dtDispUnitPrice.Columns.Add("total_price", typeof(string));
            dtDispUnitPrice.Columns.Add("total_price_value", typeof(string));

            return dtDispUnitPrice;
        }


        private DataTable getPricingErrMsgTable()
        {
            DataTable dtDispErrMsg = new DataTable("");
            dtDispErrMsg.Columns.Add("price_error_msg_no", typeof(int));
            dtDispErrMsg.Columns.Add("price_error_msg", typeof(string));

            return dtDispErrMsg;
        }


        private string getAllColumnValues(DataTable _dt)
        {
            string strValues = "";

            DataRow dr = _dt.Rows[0];

            foreach (DataColumn col in _dt.Columns)
            {
                strValues += dr[col.ColumnName].ToString() + " - ";
            }

            strValues.Substring(strValues.Length - 3);

            return strValues;
        }
    }
}