using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Dynamic;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Oxygen8SelectorServer.Models
{
    public class UnitsModel
    {
        private static string strRedirect = "";
        private static DataTable dtTemp = new DataTable();
        private static DataTable dtLink = new DataTable();
        private static ClsProjectInfo objProjectInfo;
        private static ClsGeneral objGeneral;
        private static ClsAirFlowData objAirFlowData;
        //private static clsElectrical objElectrical;
        private static ClsComponentItems objCompItems;
        private static ClsLayout objLayout;
        //private static clsUnitList objUnitList = new clsUnitList { };
        private static DataTable dtDrawingList = new DataTable();

        private static int intUserID = 0;
        private static int intUAL = 0;
        private static int intJobID = 0;
        private static int intUnitNo = 0;
        //private static int intComponentNo = 0;
        //private static int intComponentID = 0;
        //private static int intComponentSeqNo = 0;
        //private static int intSupplierID = 0;

        private static int intProductTypeID = 0;
        private static int intUnitTypeID = 0;
        private static int intLocationID = 0;
        private static int intOrientationID = 0;
        private static int intConfigurationID = 0;
        private static int intControlsPreferenceID = 0;
        private static int intUnitModelID = 0;
        private static int intUnitVoltageID = 0;
        //private static int intUnitInsulationID = 0;
        //private static int intUnitPaintExteriorID = 0;
        //private static int intSupplyAirApplicationID = 0;
        //private static int intExhaustAirApplicationID = 0;

        private static int intOA_FilterModelID = 0;
        private static int intFinalFilterModelID = 0;
        private static int intRA_FilterModelID = 0;
        private static int intPreheatCompID = 0;
        private static int intHeatExchCompID = 0;
        private static int intHeatingCompID = 0;
        private static int intCoolingCompID = 0;
        private static int intReheatCompID = 0;
        private static int intElecHeaterVoltageID = 0;
        private static int intCoolingFluidTypeID = 0;
        private static int intCoolingFluidConcentrationID = 0;
        private static int intHeatingFluidTypeID = 0;
        private static int intHeatingFluidConcentrationID = 0;
        private static int intPreheatElecHeaterInstallationID = 0;
        private static int intHeatElecHeaterInstallationID = 0;
        private static int intDamperActuatorID = 0;

        private static int intHandingID = 0;
        private static int intPreheatCoilHandingID = 0;
        private static int intCoolingCoilHandingID = 0;
        private static int intHeatingCoilHandingID = 0;
        private static int intValveTypeID = 0;

        private static int intSupplyAirOpeningID = 0;
        private static string strSupplyAirOpening = "";
        private static int intExhaustAirOpeningID = 0;
        private static string strExhaustAirOpening = "";
        private static int intOutdoorAirOpeningID = 0;
        private static string strOutdoorAirOpening = "";
        private static int intReturnAirOpeningID = 0;
        private static string strReturnAirOpening = "";

        //private static bool bolExecuteSummerDB = false;
        private static bool bolExecuteSummerWB = true;
        private static bool bolExecuteSummerRH = true;
        //private static bool bolExecuteWinterDB = false;
        private static bool bolExecuteWinterWB = true;
        private static bool bolExecuteWinterRH = true;

        private static double dblTempErrorValue = 0.000d;

        private const int intNOVA_MIN_CFM = 325;
        private const int intNOVA_MAX_CFM = 9000;

        private const int intNOVA_INT_USERS_MIN_CFM = 325;
        private const int intNOVA_INT_USERS_MAX_CFM = 8100;
        private const int intNOVA_HORIZONTAL_MAX_CFM = 3500;


        private const int intVEN_MIN_CFM_NO_BYPASS = 325;
        private const int intVEN_MAX_CFM_NO_BYPASS = 3000;
        private const int intVEN_MIN_CFM_WITH_BYPASS = 325;
        private const int intVEN_MAX_CFM_WITH_BYPASS = 3000;

        private const int intVEN_INT_USERS_MIN_CFM_NO_BYPASS = 300;
        private const int intVEN_INT_USERS_MAX_CFM_NO_BYPASS = 3048;
        private const int intVEN_INT_USERS_MIN_CFM_WITH_BYPASS = 300;
        private const int intVEN_INT_USERS_MAX_CFM_WITH_BYPASS = 3048;

        private const int intVENLITE_MIN_CFM_NO_BYPASS = 200;
        private const int intVENLITE_MAX_CFM_NO_BYPASS = 500;
        private const int intVENLITE_MIN_CFM_WITH_BYPASS = 200;
        private const int intVENLITE_MAX_CFM_WITH_BYPASS = 500;

        private const int intVENLITE_INT_USERS_MIN_CFM_NO_BYPASS = 170;
        private const int intVENLITE_INT_USERS_MAX_CFM_NO_BYPASS = 1200;
        private const int intVENLITE_INT_USERS_MIN_CFM_WITH_BYPASS = 170;
        private const int intVENLITE_INT_USERS_MAX_CFM_WITH_BYPASS = 1200;


        private const int intTERA_MIN_CFM_NO_BYPASS = 450;
        private const int intTERA_MAX_CFM_NO_BYPASS = 2400;
        private const int intTERA_MIN_CFM_WITH_BYPASS = 450;
        private const int intTERA_MAX_CFM_WITH_BYPASS = 500;

        private const int intTERA_INT_USERS_MIN_CFM_NO_BYPASS = 400;
        private const int intTERA_INT_USERS_MAX_CFM_NO_BYPASS = 2500;
        private const int intTERA_INT_USERS_MIN_CFM_WITH_BYPASS = 400;
        private const int intTERA_INT_USERS_MAX_CFM_WITH_BYPASS = 2500;

        private static int ckbDehumidificationChecked = 0;
        private static int ckbHeatPumpChecked = 0;
        private static int ckbVoltageSPPChecked = 0;
        private static int ckbBypassChecked = 0;

        public static bool DeleteUnitById(int intJobID, int unitId)
        {
            return ClsDB.DeleteUnit(intJobID, unitId);
        }

        public static bool DeleteUnitsByIds(int intJobID, dynamic unitIds)
        {
            return ClsDB.DeleteUnits(intJobID, unitIds);
        }

        public static int SaveUnitInfo(dynamic unitInfo)
        {
            setAllData(unitInfo);
            int intFaceAreaHeight = 0;
            int intFaceAreaWidth = 0;
            string strSelectionType = "";
            int intSelectionTypeID = 0;
            int intVelocity = 0;


            intSelectionTypeID = ClsID.intSelectionTypeCoupled;

            DataTable dtUnitSizeDeratedFlow = new DataTable();
            intVelocity = 300;
            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                dtUnitSizeDeratedFlow = ClsDB.get_dtLive(ClsDBT.strSelNovaUnitSize, "unit_model_id", intSelectionTypeID);
                dtUnitSizeDeratedFlow = ClsTS.get_dtDataFromImportRows(dtUnitSizeDeratedFlow, "unit_orientation_id", unitInfo.ddlOrientation.ToString());


                DataTable dtUnitSizeDecoupled = dtUnitSizeDeratedFlow.Copy();

                dtUnitSizeDeratedFlow = ClsTS.get_dtDataFromImportRows(dtUnitSizeDeratedFlow, "selection_type_id", ClsID.intSelectionTypeCoupled);      //Derated Flowrate
                dtUnitSizeDecoupled = ClsTS.get_dtDataFromImportRows(dtUnitSizeDecoupled, "selection_type_id", ClsID.intSelectionTypeDecoupled);          //Decoupled


                intFaceAreaHeight = Convert.ToInt32(dtUnitSizeDeratedFlow.Rows[0]["cooling_coil_fin_height"]);
                intFaceAreaWidth = Convert.ToInt32(dtUnitSizeDeratedFlow.Rows[0]["cooling_coil_fin_length"]);
                strSelectionType = dtUnitSizeDeratedFlow.Rows[0]["selection_type"].ToString();
                intSelectionTypeID = Convert.ToInt32(dtUnitSizeDeratedFlow.Rows[0]["selection_type_id"]);
                intVelocity = Convert.ToInt32(Convert.ToDouble(unitInfo.txbSummerSupplyAirCFM) / ((intFaceAreaHeight * intFaceAreaWidth) / 144d));
            }

            DataTable dt = ClsDB.SaveGeneral(Convert.ToInt32(unitInfo.intJobID),
                                            Convert.ToInt32(unitInfo.intUnitNo),
                                            unitInfo.txtTag.ToString().ToUpper(),
                                            Convert.ToInt32(unitInfo.txbQty),
                                            Convert.ToInt32(unitInfo.intProductTypeID),
                                            Convert.ToInt32(unitInfo.ddlUnitType),
                                            Convert.ToInt32(unitInfo.ckbBypass),
                                            Convert.ToInt32(unitInfo.ddlUnitModel),
                                            Convert.ToInt32(intSelectionTypeID),
                                            Convert.ToInt32(unitInfo.ddlLocation),
                                            Convert.ToInt32(unitInfo.ckbDownshot),
                                            Convert.ToInt32(unitInfo.ddlOrientation),
                                            Convert.ToInt32(unitInfo.ddlControlsPreference),
                                            Convert.ToDouble(unitInfo.txbUnitHeightText),
                                            Convert.ToDouble(unitInfo.txbUnitWidthText),
                                            Convert.ToDouble(unitInfo.txbUnitLengthText),
                                            Convert.ToDouble(unitInfo.txbUnitWeightText),
                                            Convert.ToInt32(unitInfo.ddlUnitVoltage),
                                            Convert.ToInt32(unitInfo.ckbVoltageSPP),
                                            1,
                                            0d);

            unitInfo.intUnitNo = dt.Rows[0]["UnitNo"].ToString();

            ClsDB.SaveAirFlow(Convert.ToInt32(unitInfo.intJobID),
                                Convert.ToInt32(unitInfo.intUnitNo),
                                Convert.ToInt32(unitInfo.txbAltitude),
                                Convert.ToInt32(unitInfo.txbSummerSupplyAirCFM),
                                Convert.ToInt32(unitInfo.txbSummerReturnAirCFM),
                                Convert.ToInt32(unitInfo.txbSummerSupplyAirCFM),
                                Convert.ToInt32(unitInfo.txbSummerReturnAirCFM),
                                Math.Round(Convert.ToDouble(unitInfo.txbSummerOutdoorAirDB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.txbSummerOutdoorAirWB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.txbSummerOutdoorAirRH), 1),
                                Math.Round(Convert.ToDouble(unitInfo.txbWinterOutdoorAirDB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.txbWinterOutdoorAirWB), 3),
                                Math.Round(Convert.ToDouble(unitInfo.txbWinterOutdoorAirRH), 1),
                                Math.Round(Convert.ToDouble(unitInfo.txbSummerReturnAirDB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.txbSummerReturnAirWB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.txbSummerReturnAirRH), 1),
                                Math.Round(Convert.ToDouble(unitInfo.txbWinterReturnAirDB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.txbWinterReturnAirWB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.txbWinterReturnAirRH), 1),
                                Convert.ToDouble(unitInfo.txbWinterPreheatSetpointDB),
                                Convert.ToDouble(unitInfo.txbWinterHeatingSetpointDB),
                                Convert.ToDouble(unitInfo.txbSummerCoolingSetpointDB),
                                Convert.ToDouble(unitInfo.txbSummerCoolingSetpointWB),
                                Convert.ToDouble(unitInfo.txbSummerReheatSetpointDB),
                                Convert.ToDouble(unitInfo.txbSupplyAirESP),
                                Convert.ToDouble(unitInfo.txbExhaustAirESP));

            ClsCompOpt objCompOpt = new ClsCompOpt
            {
                intJobID = Convert.ToInt32(unitInfo.intJobID),
                intUnitNo = Convert.ToInt32(unitInfo.intUnitNo),
                intUnitTypeID = Convert.ToInt32(unitInfo.ddlUnitType),
                intUnitModelID = Convert.ToInt32(unitInfo.ddlUnitModel),
                intVoltageID = Convert.ToInt32(unitInfo.ddlUnitVoltage),
                intOA_FilterModelID = Convert.ToInt32(unitInfo.ddlOA_FilterModel),
                intSA_FinalFilterModelID = 0,
                intRA_FilterModelID = Convert.ToInt32(unitInfo.ddlRA_FilterModel),
                intHeatExchCompID = Convert.ToInt32(unitInfo.ddlHeatExchComp),
                intPreheatCompID = Convert.ToInt32(unitInfo.ddlPreheatComp),
                intCoolingCompID = Convert.ToInt32(unitInfo.ddlCoolingComp),
                intHeatingCompID = Convert.ToInt32(unitInfo.ddlHeatingComp),
                intReheatCompID = Convert.ToInt32(unitInfo.ddlReheatComp),
                intIsHeatPump = unitInfo.ckbHeatPump,
                intIsDehumidification = unitInfo.ckbDehumidification,
                intElecHeaterVoltageID = Convert.ToInt32(unitInfo.ddlElecHeaterVoltage),
                intPreheatElecHeaterInstallationID = Convert.ToInt32(unitInfo.ddlPreheatElecHeaterInstallation),
                intHeatElecHeaterInstallationID = Convert.ToInt32(unitInfo.ddlHeatElecHeaterInstallation),
                intDamperAndActuatorID = Convert.ToInt32(unitInfo.ddlDamperAndActuator),
                intIsValveAndActuatorIncluded = unitInfo.ckbValveAndActuator,
                intValveTypeID = Convert.ToInt32(unitInfo.ddlValveType),
                intIsDrainPan = unitInfo.ckbDrainPan,
                dblOA_FilterPD = Convert.ToDouble(unitInfo.txbOA_FilterPD),
                dblRA_FilterPD = Convert.ToDouble(unitInfo.txbRA_FilterPD),
                dblPreheatSetpointDB = Convert.ToDouble(unitInfo.txbPreheatSetpointDB),
                dblCoolingSetpointDB = Convert.ToDouble(unitInfo.txbCoolingSetpointDB),
                dblCoolingSetpointWB = Convert.ToDouble(unitInfo.txbCoolingSetpointWB),
                dblHeatingSetpointDB = Convert.ToDouble(unitInfo.txbHeatingSetpointDB),
                dblReheatSetpointDB = Convert.ToDouble(unitInfo.txbReheatSetpointDB),
                intCoolingFluidTypeID = Convert.ToInt32(unitInfo.ddlCoolingFluidType),
                intCoolingFluidConcentID = Convert.ToInt32(unitInfo.ddlCoolingFluidConcentration),
                dblCoolingFluidEntTemp = Convert.ToDouble(unitInfo.txbCoolingFluidEntTemp),
                dblCoolingFluidLvgTemp = Convert.ToDouble(unitInfo.txbCoolingFluidLvgTemp),
                intHeatingFluidTypeID = Convert.ToInt32(unitInfo.ddlHeatingFluidType),
                intHeatingFluidConcentID = Convert.ToInt32(unitInfo.ddlHeatingFluidConcentration),
                dblHeatingFluidEntTemp = Convert.ToDouble(unitInfo.txbHeatingFluidEntTemp),
                dblHeatingFluidLvgTemp = Convert.ToDouble(unitInfo.txbHeatingFluidLvgTemp),
                dblRefrigSuctionTemp = Convert.ToDouble(unitInfo.txbRefrigSuctionTemp),
                dblRefrigLiquidTemp = Convert.ToDouble(unitInfo.txbRefrigLiquidTemp),
                dblRefrigSuperheatTemp = Convert.ToDouble(unitInfo.txbRefrigSuperheatTemp),
                dblRefrigCondensingTemp = Convert.ToDouble(unitInfo.txbRefrigCondensingTemp),
                dblRefrigVaporTemp = Convert.ToDouble(unitInfo.txbRefrigVaporTemp),
                dblRefrigSubcoolingTemp = Convert.ToDouble(unitInfo.txbRefrigSubcoolingTemp),
                intPreheatValveAndActuatorID = 0,
                intCoolingValveAndActuatorID = 0,
                intHeatingValveAndActuatorID = 0,
                intReheatValveAndActuatorID = 0,
                intPreheatElecHeaterStdCoilNo = 0,
                intHeatingElecHeaterStdCoilNo = 0,
                intReheatElecHeaterStdCoilNo = 0,
                intIsHeatExchEA_Warning = 0,
            };

            //objCompOpt = new ClsComponentItems(objCompOptData);
            ClsDB.SaveCompOpt(objCompOpt);
            var Session = HttpContext.Current.Session;


            if (Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_Admin ||
                Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_IntAdmin ||
                Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_IntLvl_1 ||
                Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_IntLvl_2)
            {

                ClsCompOptCustom objCompOptCustom = new ClsCompOptCustom
                {
                    intJobID = Convert.ToInt32(unitInfo.intJobID),
                    intUnitNo = Convert.ToInt32(unitInfo.unitJobID),
                    intIsPreheatHWC_UseCap = unitInfo.ckbPreheatHWC_UseCap,
                    dblPreheatHWC_Cap = Convert.ToDouble(unitInfo.txbPreheatHWC_Cap),
                    intIsPreheatHWC_UseFlowRate = unitInfo.ckbPreheatHWC_UseFlowRate,
                    dblPreheatHWC_FlowRate = Convert.ToDouble(unitInfo.txbPreheatHWC_FlowRate),
                    intIsCoolingCWC_UseCap = unitInfo.ckbCoolingCWC_UseCap,
                    dblCoolingCWC_Cap = Convert.ToDouble(unitInfo.txbCoolingCWC_Cap),
                    intIsCoolingCWC_UseFlowRate = unitInfo.ckbCoolingCWC_UseFlowRate,
                    dblCoolingCWC_FlowRate = Convert.ToDouble(unitInfo.txbCoolingCWC_FlowRate),
                    intIsHeatingHWC_UseCap = unitInfo.ckbHeatingHWC_UseCap,
                    dblHeatingHWC_Cap = Convert.ToDouble(unitInfo.txbHeatingHWC_Cap),
                    intIsHeatingHWC_UseFlowRate = unitInfo.ckbHeatingHWC_UseFlowRate,
                    dblHeatingHWC_FlowRate = Convert.ToDouble(unitInfo.txbHeatingHWC_FlowRate),
                    intIsReheatHWC_UseCap = unitInfo.ckbReheatHWC_UseCap,
                    dblReheatHWC_Cap = Convert.ToDouble(unitInfo.txbReheatHWC_Cap),
                    intIsReheatHWC_UseFlowRate = unitInfo.ckbReheatHWC_UseFlowRate,
                    dblReheatHWC_FlowRate = Convert.ToDouble(unitInfo.txbReheatHWC_FlowRate),
                };

                ClsDB.SaveCompOptCustom(objCompOptCustom);
            }

            SaveLayout(unitInfo);
            unitInfo.ddlHandingID = 1;
            return unitInfo.intUnitNo;
        }

        public static bool SaveLayout(dynamic unitInfo)
        {
            try
            {
                ClsLayoutOpt objLayoutOpt = new ClsLayoutOpt
                {
                    intJobID = Convert.ToInt32(unitInfo.intJobID),
                    intUnitNo = Convert.ToInt32(unitInfo.intUnitNo),
                    intProductTypeID = Convert.ToInt32(unitInfo.intProductTypeID),
                    intUnitTypeID = Convert.ToInt32(unitInfo.intUnitTypeID),
                    intHandingID = Convert.ToInt32(unitInfo.ddlHandingID),
                    intPreheatCoilHandingID = Convert.ToInt32(unitInfo.ddlPreheatCoilHanding),
                    intCoolingCoilHandingID = Convert.ToInt32(unitInfo.ddlCoolingCoilHanding),
                    intHeatingCoilHandingID = Convert.ToInt32(unitInfo.ddlHeatingCoilHanding),
                    intSupplyAirOpeningID = Convert.ToInt32(unitInfo.ddlSupplyAirOpeningValue),
                    strSupplyAirOpening = unitInfo.ddlSupplyAirOpeningText,
                    intExhaustAirOpeningID = Convert.ToInt32(unitInfo.ddlExhaustAirOpeningValue),
                    strExhaustAirOpening = unitInfo.ddlExhaustAirOpeningText,
                    intOutdoorAirOpeningID = Convert.ToInt32(unitInfo.ddlOutdoorAirOpeningValue),
                    strOutdoorAirOpening = unitInfo.ddlOutdoorAirOpeningText,
                    intReturnAirOpeningID = Convert.ToInt32(unitInfo.ddlReturnAirOpeningValue),
                    strReturnAirOpening = unitInfo.ddlReturnAirOpeningText
                };

                ClsDB.SaveLayout(objLayoutOpt);
            } catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public static dynamic GetUnitInfo(dynamic info)
        {
            intUserID = Convert.ToInt32(info.intUserID);
            intUAL = Convert.ToInt32(info.intUAL);
            intJobID = Convert.ToInt32(info.intJobID);
            intProductTypeID = Convert.ToInt32(info.intProductTypeID);
            intUnitTypeID = Convert.ToInt32(info.intUnitTypeID);
            intUnitNo = Convert.ToInt32(info.intUnitNo);

            dynamic unitInfo = new ExpandoObject();
            DataTable dtJob = ClsDB.GetSavedJob(intJobID);

            if (intJobID > 0)
            {
                ClsProjectInfo objProjectInfo = new ClsProjectInfo(intJobID);
                unitInfo.txbAltitudeText = objProjectInfo.intAltitude;

                unitInfo.txbSummerOutdoorAirDBText = objProjectInfo.dblSummerOutdoorAirDB;
                unitInfo.txbSummerOutdoorAirWBText = objProjectInfo.dblSummerOutdoorAirWB;
                unitInfo.txbSummerOutdoorAirRHText = objProjectInfo.dblSummerOutdoorAirRH;

                unitInfo.txbWinterOutdoorAirDBText = objProjectInfo.dblWinterOutdoorAirDB;
                unitInfo.txbWinterOutdoorAirWBText = objProjectInfo.dblWinterOutdoorAirWB;
                unitInfo.txbWinterOutdoorAirRHText = objProjectInfo.dblWinterOutdoorAirRH;

                unitInfo.txbSummerReturnAirDBText = objProjectInfo.dblSummerReturnAirDB;
                unitInfo.txbSummerReturnAirWBText = objProjectInfo.dblSummerReturnAirWB;
                unitInfo.txbSummerReturnAirRHText = objProjectInfo.dblSummerReturnAirRH;

                unitInfo.txbWinterReturnAirDBText = objProjectInfo.dblWinterReturnAirDB;
                unitInfo.txbWinterReturnAirWBText = objProjectInfo.dblWinterReturnAirWB;
                unitInfo.txbWinterReturnAirRHText = objProjectInfo.dblWinterReturnAirRH;
            }

            if (intJobID > 0 & intUnitNo > 0)
            {
                ClsGeneral objGeneral = new ClsGeneral(intJobID, intUnitNo);
                ClsAirFlowData objAirFlowData = new ClsAirFlowData(intJobID, intUnitNo);
                ClsComponentItems objCompItems = new ClsComponentItems(intJobID, intUnitNo);
                ClsLayout objLayout = new ClsLayout(intJobID, intUnitNo);

                if (objGeneral != null)
                {
                    unitInfo.txbTagText = objGeneral.strTag;
                    unitInfo.txbQtyText = objGeneral.intQty;

                    unitInfo.productTypeID = objGeneral.intProductTypeID;
                    unitInfo.unitTypeID = objGeneral.intUnitTypeID;
                    unitInfo.locationID = objGeneral.intLocationID;
                    unitInfo.orientationID = objGeneral.intOrientationID;

                    unitInfo.unitModelID = objGeneral.intUnitModelID;
                    unitInfo.unitVoltageID = objGeneral.intUnitVoltageID;
                    unitInfo.controlsPreferenceID = objGeneral.intControlsPreferenceID;

                    unitInfo.txbUnitHeightText = objGeneral.dblUnitHeight;
                    unitInfo.txbUnitWidthText = objGeneral.dblUnitWidth;
                    unitInfo.txbUnitLengthText = objGeneral.dblUnitLength;
                    unitInfo.txbUnitWeightText = objGeneral.dblUnitWeight;

                    intProductTypeID = objGeneral.intProductTypeID;
                    intUnitTypeID = objGeneral.intUnitTypeID;
                    intLocationID = objGeneral.intLocationID;
                    intOrientationID = objGeneral.intOrientationID;

                    intUnitModelID = objGeneral.intUnitModelID;
                    intUnitVoltageID = objGeneral.intUnitVoltageID;
                    intControlsPreferenceID = objGeneral.intControlsPreferenceID;
                }

                if (objAirFlowData != null)
                {
                    unitInfo.txbSummerSupplyAirCFMText = objAirFlowData.get_intSummerSupplyAirCFM();

                    unitInfo.txbSupplyAirESPText = objAirFlowData.get_dblSupplyAirESP();
                    unitInfo.txbExhaustAirESPText = objAirFlowData.get_dblExhaustAirESP();

                    unitInfo.txbSummerReturnAirDBText = objAirFlowData.get_dblSummerReturnAirDB();
                    unitInfo.txbSummerReturnAirWBText = objAirFlowData.get_dblSummerReturnAirWB();
                    unitInfo.txbSummerReturnAirRHText = objAirFlowData.get_dblSummerReturnAirRH();

                    unitInfo.txbWinterReturnAirDBText = objAirFlowData.get_dblWinterReturnAirDB();
                    unitInfo.txbWinterReturnAirWBText = objAirFlowData.get_dblWinterReturnAirWB();
                    unitInfo.txbWinterReturnAirRHText = objAirFlowData.get_dblWinterReturnAirRH();

                    unitInfo.txbWinterPreheatSetpointDBText = objAirFlowData.get_dblWinterPreheatSetpointDB();
                    unitInfo.txbWinterHeatingSetpointDBText = objAirFlowData.get_dblWinterHeatingSetpointDB();
                    unitInfo.txbSummerCoolingSetpointDBText = objAirFlowData.get_dblSummerCoolingSetpointDB();
                    unitInfo.txbSummerCoolingSetpointWBText = objAirFlowData.get_dblSummerCoolingSetpointWB();
                    unitInfo.txbSummerReheatSetpointDBText = objAirFlowData.get_dblSummerReheatSetpointDB();
                }

                if (objCompItems.objCompOpt != null)
                {
                    unitInfo.OA_FilterModelID = objCompItems.objCompOpt.intOA_FilterModelID;
                    unitInfo.FinalFilterModelID = objCompItems.objCompOpt.intSA_FinalFilterModelID;
                    unitInfo.RA_FilterModelID = objCompItems.objCompOpt.intRA_FilterModelID;
                    unitInfo.HeatExchCompID = objCompItems.objCompOpt.intHeatExchCompID;
                    unitInfo.PreheatCompID = objCompItems.objCompOpt.intPreheatCompID;
                    unitInfo.CoolingCompID = objCompItems.objCompOpt.intCoolingCompID;
                    unitInfo.HeatingCompID = objCompItems.objCompOpt.intHeatingCompID;
                    unitInfo.ReheatCompID = objCompItems.objCompOpt.intReheatCompID;

                    unitInfo.ElecHeaterVoltageID = objCompItems.objCompOpt.intElecHeaterVoltageID;
                    unitInfo.PreheatElecHeaterInstallationID = objCompItems.objCompOpt.intPreheatElecHeaterInstallationID;
                    unitInfo.HeatElecHeaterInstallationID = objCompItems.objCompOpt.intHeatElecHeaterInstallationID;
                    unitInfo.DamperActuatorID = objCompItems.objCompOpt.intDamperAndActuatorID;
                    unitInfo.ValveTypeID = objCompItems.objCompOpt.intValveTypeID;
                    unitInfo.txbOA_FilterPDText = objCompItems.objCompOpt.dblOA_FilterPD;
                    unitInfo.txbRA_FilterPDText = objCompItems.objCompOpt.dblRA_FilterPD;
                    unitInfo.txbPreheatSetpointDBText = objCompItems.objCompOpt.dblPreheatSetpointDB;
                    unitInfo.txbCoolingSetpointDBText = objCompItems.objCompOpt.dblCoolingSetpointDB;
                    unitInfo.txbCoolingSetpointWBText = objCompItems.objCompOpt.dblCoolingSetpointWB;
                    unitInfo.txbHeatingSetpointDBText = objCompItems.objCompOpt.dblHeatingSetpointDB;
                    unitInfo.txbReheatSetpointDBText = objCompItems.objCompOpt.dblReheatSetpointDB;
                    unitInfo.CoolingFluidTypeID = objCompItems.objCompOpt.intCoolingFluidTypeID;
                    unitInfo.CoolingFluidConcentrationID = objCompItems.objCompOpt.intCoolingFluidConcentID;
                    unitInfo.txbCoolingFluidEntTempText = objCompItems.objCompOpt.dblCoolingFluidEntTemp;
                    unitInfo.txbCoolingFluidLvgTempText = objCompItems.objCompOpt.dblCoolingFluidLvgTemp;
                    unitInfo.HeatingFluidTypeID = objCompItems.objCompOpt.intHeatingFluidTypeID;
                    unitInfo.HeatingFluidConcentrationID = objCompItems.objCompOpt.intHeatingFluidConcentID;
                    unitInfo.txbHeatingFluidEntTempText = objCompItems.objCompOpt.dblHeatingFluidEntTemp;
                    unitInfo.txbHeatingFluidLvgTempText = objCompItems.objCompOpt.dblHeatingFluidLvgTemp;
                    unitInfo.txbRefrigSuctionTempText = objCompItems.objCompOpt.dblRefrigSuctionTemp;
                    unitInfo.txbRefrigLiquidTempText = objCompItems.objCompOpt.dblRefrigLiquidTemp;
                    unitInfo.txbRefrigSuperheatTempText = objCompItems.objCompOpt.dblRefrigSuperheatTemp;
                    unitInfo.txbRefrigCondensingTempText = objCompItems.objCompOpt.dblRefrigCondensingTemp;
                    unitInfo.txbRefrigVaporTempText = objCompItems.objCompOpt.dblRefrigVaporTemp;
                    unitInfo.txbRefrigSubcoolingTempText = objCompItems.objCompOpt.dblRefrigSubcoolingTemp;

                    intOA_FilterModelID = objCompItems.objCompOpt.intOA_FilterModelID;
                    intFinalFilterModelID = objCompItems.objCompOpt.intSA_FinalFilterModelID;
                    intRA_FilterModelID = objCompItems.objCompOpt.intRA_FilterModelID;
                    intHeatExchCompID = objCompItems.objCompOpt.intHeatExchCompID;
                    intPreheatCompID = objCompItems.objCompOpt.intPreheatCompID;
                    intCoolingCompID = objCompItems.objCompOpt.intCoolingCompID;
                    intHeatingCompID = objCompItems.objCompOpt.intHeatingCompID;
                    intReheatCompID = objCompItems.objCompOpt.intReheatCompID;

                    intElecHeaterVoltageID = objCompItems.objCompOpt.intElecHeaterVoltageID;
                    intPreheatElecHeaterInstallationID = objCompItems.objCompOpt.intPreheatElecHeaterInstallationID;
                    intHeatElecHeaterInstallationID = objCompItems.objCompOpt.intHeatElecHeaterInstallationID;
                    intDamperActuatorID = objCompItems.objCompOpt.intDamperAndActuatorID;
                    intValveTypeID = objCompItems.objCompOpt.intValveTypeID;

                    intCoolingFluidTypeID = objCompItems.objCompOpt.intCoolingFluidTypeID;
                    intCoolingFluidConcentrationID = objCompItems.objCompOpt.intCoolingFluidConcentID;

                    intHeatingFluidTypeID = objCompItems.objCompOpt.intHeatingFluidTypeID;
                    intHeatingFluidConcentrationID = objCompItems.objCompOpt.intHeatingFluidConcentID;
                }

                unitInfo.isCustoms = false;
                if (objCompItems.objCompOptCustom != null)
                {
                    unitInfo.isCustoms = true;
                    unitInfo.ckbPreheatHWC_UseCapValue = objCompItems.objCompOptCustom.intIsPreheatHWC_UseCap == 0 ? false : true;
                    unitInfo.txbPreheatHWC_CapText = objCompItems.objCompOptCustom.dblPreheatHWC_Cap;
                    unitInfo.ckbPreheatHWC_UseFlowRateValue = objCompItems.objCompOptCustom.intIsPreheatHWC_UseFlowRate == 0 ? false : true;
                    unitInfo.txbPreheatHWC_FlowRateText = objCompItems.objCompOptCustom.dblPreheatHWC_FlowRate;

                    unitInfo.ckbCoolingCWC_UseCapValue = objCompItems.objCompOptCustom.intIsCoolingCWC_UseCap == 0 ? false : true;
                    unitInfo.txbCoolingCWC_CapText = objCompItems.objCompOptCustom.dblCoolingCWC_Cap;
                    unitInfo.ckbCoolingCWC_UseFlowRateValue = objCompItems.objCompOptCustom.intIsCoolingCWC_UseFlowRate == 0 ? false : true;
                    unitInfo.txbCoolingCWC_FlowRateText = objCompItems.objCompOptCustom.dblCoolingCWC_FlowRate;

                    unitInfo.ckbHeatingHWC_UseCapValue = objCompItems.objCompOptCustom.intIsHeatingHWC_UseCap == 0 ? false : true;
                    unitInfo.txbHeatingHWC_CapText = objCompItems.objCompOptCustom.dblHeatingHWC_Cap;
                    unitInfo.ckbHeatingHWC_UseFlowRateValue = objCompItems.objCompOptCustom.intIsHeatingHWC_UseFlowRate == 0 ? false : true;
                    unitInfo.txbHeatingHWC_FlowRateText = objCompItems.objCompOptCustom.dblHeatingHWC_FlowRate;

                    unitInfo.ckbReheatHWC_UseCapValue = objCompItems.objCompOptCustom.intIsReheatHWC_UseCap == 0 ? false : true;
                    unitInfo.txbReheatHWC_CapText = objCompItems.objCompOptCustom.dblReheatHWC_Cap;
                    unitInfo.ckbReheatHWC_UseFlowRateValue = objCompItems.objCompOptCustom.intIsReheatHWC_UseFlowRate == 0 ? false : true;
                    unitInfo.txbReheatHWC_FlowRateText = objCompItems.objCompOptCustom.dblReheatHWC_FlowRate;
                }

                if (objLayout.objLayoutOpt != null)
                {
                    unitInfo.HandingID = objLayout.objLayoutOpt.intHandingID;
                    unitInfo.PreheatCoilHandingID = objLayout.objLayoutOpt.intPreheatCoilHandingID;
                    unitInfo.CoolingCoilHandingID = objLayout.objLayoutOpt.intCoolingCoilHandingID;
                    unitInfo.HeatingCoilHandingID = objLayout.objLayoutOpt.intHeatingCoilHandingID;
                    unitInfo.SupplyAirOpeningID = objLayout.objLayoutOpt.intSupplyAirOpeningID;
                    unitInfo.SupplyAirOpeningText = objLayout.objLayoutOpt.strSupplyAirOpening;
                    unitInfo.ExhaustAirOpeningID = objLayout.objLayoutOpt.intExhaustAirOpeningID;
                    unitInfo.ExhaustAirOpeningText = objLayout.objLayoutOpt.strExhaustAirOpening;
                    unitInfo.OutdoorAirOpeningID = objLayout.objLayoutOpt.intOutdoorAirOpeningID;
                    unitInfo.OutdoorAirOpeningText = objLayout.objLayoutOpt.strOutdoorAirOpening;
                    unitInfo.ReturnAirOpeningID = objLayout.objLayoutOpt.intReturnAirOpeningID;
                    unitInfo.ReturnAirOpeningText = objLayout.objLayoutOpt.strReturnAirOpening;

                    intHandingID = objLayout.objLayoutOpt.intHandingID;
                    intPreheatCoilHandingID = objLayout.objLayoutOpt.intPreheatCoilHandingID;
                    intCoolingCoilHandingID = objLayout.objLayoutOpt.intCoolingCoilHandingID;
                    intHeatingCoilHandingID = objLayout.objLayoutOpt.intHeatingCoilHandingID;
                    intSupplyAirOpeningID = objLayout.objLayoutOpt.intSupplyAirOpeningID;
                    strSupplyAirOpening = objLayout.objLayoutOpt.strSupplyAirOpening;
                    intExhaustAirOpeningID = objLayout.objLayoutOpt.intExhaustAirOpeningID;
                    strExhaustAirOpening = objLayout.objLayoutOpt.strExhaustAirOpening;
                    intOutdoorAirOpeningID = objLayout.objLayoutOpt.intOutdoorAirOpeningID;
                    strOutdoorAirOpening = objLayout.objLayoutOpt.strOutdoorAirOpening;
                    intReturnAirOpeningID = objLayout.objLayoutOpt.intReturnAirOpeningID;
                    strReturnAirOpening = objLayout.objLayoutOpt.strReturnAirOpening;
                }

                unitInfo.unitTypeId = intUnitTypeID;
                unitInfo.ddlControlsPreferenceValue = intControlsPreferenceID;

                unitInfo.txbSummerSupplyAirCFMText = objAirFlowData != null ? objAirFlowData.get_intSummerSupplyAirCFM() : unitInfo.txbSummerSupplyAirCFMText;
                unitInfo.txbSummerReturnAirCFMText = objAirFlowData != null ? objAirFlowData.get_intSummerReturnAirCFM() : unitInfo.txbSummerSupplyAirCFMText;
                unitInfo.ddlLocationValue = intLocationID;
                unitInfo.divDownshotVisible = getDownshot();
                unitInfo.ckbDownshot = getDownshot();

                unitInfo.ddlOrientationValue = intOrientationID;


                if (objGeneral != null)
                {
                    unitInfo.ckbBypass = objGeneral.intIsBypass;
                    unitInfo.ckbDownshot = objGeneral.intIsDownshot;
                    unitInfo.ckbVoltageSPP = objGeneral.intIsVoltageSPP;
                }


                unitInfo.ddlUnitVoltage =  getVoltage();
                unitInfo.ddlUnitVoltageValue = intUnitVoltageID;


                unitInfo.ddlOA_FilterModelValue = intOA_FilterModelID;
                unitInfo.ddlRA_FilterModelValue = intRA_FilterModelID;
                unitInfo.ddlPreheatCompValue =  intPreheatCompID;
                unitInfo.ddlHeatExchCompValue = intHeatExchCompID;
                unitInfo.ddlCoolingCompValue = intCoolingCompID;
                unitInfo.ddlHeatingCompValue = intHeatingCompID;

                if (objCompItems.objCompOpt != null)
                {
                    unitInfo.ckbHeatPump = objCompItems.objCompOpt.intIsHeatPump;
                    unitInfo.ckbDehumidification = objCompItems.objCompOpt.intIsDehumidification;
                }

                unitInfo.ddlReheatCompValue = intReheatCompID;
                unitInfo.ddlDamperAndActuatorValue = intDamperActuatorID;
                unitInfo.ddlElecHeaterVoltageValue = intElecHeaterVoltageID;
                unitInfo.ddlPreheatElecHeaterInstallationValue = intPreheatElecHeaterInstallationID;
                unitInfo.ddlHeatElecHeaterInstallationValue = intHeatElecHeaterInstallationID;

                if (objCompItems.objCompOpt != null)
                {
                    unitInfo.ckbValveAndActuator = objCompItems.objCompOpt.intIsValveAndActuatorIncluded;
                    unitInfo.ddlValveTypeValue = intValveTypeID;
                    unitInfo.ckbDrainPan = objCompItems.objCompOpt.intIsDrainPan;
                }

                unitInfo.ddlCoolingFluidTypeValue = intCoolingFluidTypeID;
                unitInfo.ddlCoolingFluidConcentrationValue = intCoolingFluidConcentrationID;
                unitInfo.ddlHeatingFluidTypeValue =  intHeatingFluidTypeID;
                unitInfo.ddlHeatingFluidConcentrationValue = intHeatingFluidConcentrationID;


                unitInfo.ddlHandingValue = intHandingID;
                unitInfo.ddlPreheatCoilHandingValue = intPreheatCoilHandingID;
                unitInfo.ddlCoolingCoilHandingValue = intCoolingCoilHandingID;
                unitInfo.ddlHeatingCoilHandingValue = intHeatingCoilHandingID;

                unitInfo.isLayout = false;
                if (objLayout != null && objLayout.objLayoutOpt != null)
                {
                    unitInfo.isLayout = true;
                    unitInfo.ddlSupplyAirOpeningText = objLayout.objLayoutOpt.strSupplyAirOpening;
                    unitInfo.ddlExhaustAirOpeningText = objLayout.objLayoutOpt.strExhaustAirOpening;
                    unitInfo.ddlOutdoorAirOpeningText = objLayout.objLayoutOpt.strOutdoorAirOpening;
                    unitInfo.ddlReturnAirOpeningText = objLayout.objLayoutOpt.strReturnAirOpening;

                    unitInfo.ddlSupplyAirOpeningValue = objLayout.objLayoutOpt.intSupplyAirOpeningID;
                    unitInfo.ddlExhaustAirOpeningValue = objLayout.objLayoutOpt.intExhaustAirOpeningID;
                    unitInfo.ddlOutdoorAirOpeningValue = objLayout.objLayoutOpt.intOutdoorAirOpeningID;
                    unitInfo.ddlReturnAirOpeningValue = objLayout.objLayoutOpt.intReturnAirOpeningID;
                }
            }

            return unitInfo;
        }

        public static void setAllData(dynamic unitInfo)
        {
            intUAL = Convert.ToInt32(unitInfo.intUAL);
            intUserID = Convert.ToInt32(unitInfo.intUserID);
            intJobID = Convert.ToInt32(unitInfo.intJobID);
            intUnitNo = Convert.ToInt32(unitInfo.intUnitNo);
            intProductTypeID = Convert.ToInt32(unitInfo.intProductTypeID);
            intUnitTypeID = Convert.ToInt32(unitInfo.ddlUnitType);
            intLocationID = Convert.ToInt32(unitInfo.ddlLocation);
            intOrientationID = Convert.ToInt32(unitInfo.ddlOrientation);
            intUnitModelID = Convert.ToInt32(unitInfo.ddlUnitModel);
            intUnitVoltageID = Convert.ToInt32(unitInfo.ddlUnitVoltage);
            intPreheatCompID = Convert.ToInt32(unitInfo.ddlPreheatComp);
            intHeatingCompID = Convert.ToInt32(unitInfo.ddlHeatingComp);
            intReheatCompID = Convert.ToInt32(unitInfo.ddlReheatComp);
            ckbVoltageSPPChecked = Convert.ToInt32(unitInfo.ckbVoltageSPP);
            intElecHeaterVoltageID = Convert.ToInt32(unitInfo.ddlElecHeaterVoltage);

            intConfigurationID = Convert.ToInt32(unitInfo.ddlElecHeaterVoltage);
            intControlsPreferenceID = Convert.ToInt32(unitInfo.ddlControlsPreference);

            intOA_FilterModelID = Convert.ToInt32(unitInfo.ddlOA_FilterModel);
            //intFinalFilterModelID = Convert.ToInt32(unitInfo.ddlControlsPreference);
            intRA_FilterModelID = Convert.ToInt32(unitInfo.ddlRA_FilterModel);
            intControlsPreferenceID = Convert.ToInt32(unitInfo.ddlControlsPreference);
            intHeatExchCompID = Convert.ToInt32(unitInfo.ddlHeatExchComp);

            intCoolingFluidTypeID = Convert.ToInt32(unitInfo.ddlCoolingFluidType);
            intCoolingFluidConcentrationID = Convert.ToInt32(unitInfo.ddlCoolingFluidConcentration);
            intHeatingFluidTypeID = Convert.ToInt32(unitInfo.ddlHeatingFluidType);
            intHeatingFluidConcentrationID = Convert.ToInt32(unitInfo.ddlHeatingFluidConcentration);
            intPreheatElecHeaterInstallationID = Convert.ToInt32(unitInfo.ddlControlsPreference);
            intHeatElecHeaterInstallationID = Convert.ToInt32(unitInfo.ddlPreheatElecHeaterInstallation);
            intDamperActuatorID = Convert.ToInt32(unitInfo.ddlDamperAndActuator);

            intPreheatCoilHandingID = Convert.ToInt32(unitInfo.ddlPreheatCoilHanding);
            intCoolingCoilHandingID = Convert.ToInt32(unitInfo.ddlCoolingCoilHanding);
            intHeatingCoilHandingID = Convert.ToInt32(unitInfo.ddlHeatingCoilHanding);
            intValveTypeID = Convert.ToInt32(unitInfo.ddlValveType);

            ckbDehumidificationChecked = Convert.ToInt32(unitInfo.ckbDehumidification);
            ckbHeatPumpChecked = Convert.ToInt32(unitInfo.ckbHeatPump);
            ckbVoltageSPPChecked = Convert.ToInt32(unitInfo.ckbVoltageSPP);
            ckbBypassChecked = Convert.ToInt32(unitInfo.ckbBypass);
        }

        private static int getDownshot()
        {
            if (intProductTypeID == ClsID.intProdTypeNovaID && intLocationID == ClsID.intLocationOutdoorID)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static dynamic getControlInfo(string txbSummerSupplyAirCFM, int ckbBypass)
        {
            dynamic controlInfo = new ExpandoObject();
            controlInfo.ddlUnitType = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitType, intUnitTypeID);
            
            if (intUnitTypeID > 0)
            {
                controlInfo.ddlUnitTypeValue = intUnitTypeID;
                controlInfo.unitTypes = ddlUnitTypeInexChanged();
            }

            DataTable dtControls = ClsDB.get_dtLiveEnabled(ClsDBT.strSelControlsPreference, intControlsPreferenceID);

            if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
            {
                dtControls = dtControls.Select("[id]='" + ClsID.intControlPrefByOthersID.ToString() + "'").CopyToDataTable();
            }
            else if (intUAL == ClsID.intUAL_External || intUAL == ClsID.intUAL_ExternalSpecial)
            {
                dtControls = dtControls.Select("[id]<>'" + ClsID.intControlPrefByOthersID.ToString() + "'").CopyToDataTable();
            }

            controlInfo.ddlControlsPreference = dtControls;
            controlInfo.ddlControlsPreferenceValue = intControlsPreferenceID == 0 ? Convert.ToInt32(dtControls.Rows[0]["id"]) : intControlsPreferenceID;
            intControlsPreferenceID = controlInfo.ddlControlsPreferenceValue;
            controlInfo.ddlDamperAndActuator = ClsDB.get_dtLiveEnabled(ClsDBT.strSelDamperActuator, intDamperActuatorID);
            controlInfo.ddlDamperAndActuatorValue = controlInfo.ddlDamperAndActuator.Rows[0]["id"];
            controlInfo.ddlDamperAndActuatorVisible = false;

            controlInfo.mainControlData = txbSummerSupplyAirCFM_Changed(txbSummerSupplyAirCFM, ckbBypass);

            ckbHeatPumpChecked = 0;
            ckbVoltageSPPChecked = 0;

            controlInfo.preheatInfomation = getPreheatRequired();


            switch (intProductTypeID)
            {
                case ClsID.intProdTypeNovaID:
                    //lblHanding.Text = "Fan Placement";
                    if (intUAL == ClsID.intUAL_External)
                    {
                        controlInfo.divUnitBypassVisible = false;
                        controlInfo.ckbBypass = false;
                    }
                    else
                    {
                        controlInfo.divUnitBypassVisible = true;
                    }

                    controlInfo.ckbVoltageSPP = 0;
                    controlInfo.divVoltageSPPVisible = false;
                    break;
                case ClsID.intProdTypeVentumID:
                    //lblHanding.Text = "Control Panel Placement";
                    controlInfo.ckbBypass = true;   //Bypass is checked by default for Ventum
                    controlInfo.ckbVoltageSPP = 1;
                    controlInfo.ckbVoltageSPP = 0;
                    controlInfo.divVoltageSPPVisible = false;
                    break;
                case ClsID.intProdTypeVentumLiteID:
                    //lblHanding.Text = "Control Panel Placement";
                    controlInfo.divUnitBypassVisible = false;
                    controlInfo.ckbBypass = false;  //No Bypass for Ventum Lite
                    controlInfo.ckbVoltageSPP = 0;
                    controlInfo.divVoltageSPPVisible = false;
                    break;
                case ClsID.intProdTypeTerraID:
                    //lblHanding.Text = "Control Panel Placement";
                    controlInfo.divUnitBypassVisible = false;
                    controlInfo.ckbBypass = false;
                    controlInfo.divVoltageSPPVisible = true;
                    break;
                default:
                    break;
            }

            controlInfo.ddlHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding, intHandingID);
            controlInfo.ddlPreheatCoilHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding, intPreheatCoilHandingID);
            controlInfo.ddlPreheatCoilHandingValue = controlInfo.ddlPreheatCoilHanding.Rows[0]["id"];

            controlInfo.ddlCoolingCoilHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding, intCoolingCoilHandingID);
            controlInfo.ddlCoolingCoilHandingValue = controlInfo.ddlCoolingCoilHanding.Rows[0]["id"];

            controlInfo.ddlHeatingCoilHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding, intHeatingCoilHandingID);
            controlInfo.ddlHeatingCoilHandingValue = controlInfo.ddlHeatingCoilHanding.Rows[0]["id"];

            controlInfo.ddlValveType = ClsDB.get_dtLiveEnabled(ClsDBT.strSelValveType, intValveTypeID);
            controlInfo.ddlValveTypeValue = controlInfo.ddlValveType.Rows[0]["id"];

            return controlInfo;
        }

        public static dynamic getPreheatRequired()
        {
            dynamic returnInfo = new ExpandoObject();
            returnInfo.lblPreheatWarningVisible = false;
            returnInfo.lblPreheatWarningText = "";
            bool bolPreheatRequired = false;
            string strPreheatRequiredWarning = "";
            double dblPreheatSetPoint = 0d;

            DataTable dtJob = ClsDB.get_dtByID(ClsDBT.strSavJob, intJobID);

            if (dtJob.Rows.Count > 0)
            {
                if (intUnitTypeID == ClsID.intUnitTypeERV_ID || intUnitTypeID == ClsID.intUnitTypeHRV_ID)
                {
                    //if (ddlPreheatComp != null)
                    //{
                    if (Convert.ToDouble(dtJob.Rows[0]["winter_outdoor_air_db"]) < 15d && Convert.ToDouble(dtJob.Rows[0]["winter_return_air_rh"]) > 40d)
                    {
                        bolPreheatRequired = true;
                        returnInfo.lblPreheatWarningText= "Preheat required. Winter OA DB is below 15 degF and RA RH is above 40%";
                    }

                }
                else if (intUnitTypeID == ClsID.intUnitTypeAHU_ID)
                {
                    if (intCoolingCompID == ClsID.intCompDX_ID && ckbHeatPumpChecked == 1 && intReheatCompID == ClsID.intCompHGRH_ID && Convert.ToDouble(dtJob.Rows[0]["winter_outdoor_air_db"]) < ClsGV.dblTERRA_PREHEAT_DX_HEATPUMP_HGRH_33DEG)
                    {
                        bolPreheatRequired = true;
                        strPreheatRequiredWarning = "Preheat required. Winter OA DB is below " + ClsGV.dblTERRA_PREHEAT_DX_HEATPUMP_HGRH_33DEG.ToString() + " degF";
                        dblPreheatSetPoint = ClsGV.dblTERRA_PREHEAT_DX_HEATPUMP_HGRH_33DEG;
                    }
                    else if (intCoolingCompID == ClsID.intCompDX_ID && ckbHeatPumpChecked == 1 && Convert.ToDouble(dtJob.Rows[0]["winter_outdoor_air_db"]) < ClsGV.dblTERRA_PREHEAT_DX_HEATPUMP_17DEG)
                    {
                        bolPreheatRequired = true;
                        strPreheatRequiredWarning = "Preheat required. Winter OA DB is below " + ClsGV.dblTERRA_PREHEAT_DX_HEATPUMP_17DEG + " degF";
                        dblPreheatSetPoint = ClsGV.dblTERRA_PREHEAT_DX_HEATPUMP_17DEG;
                    }
                }


                if (bolPreheatRequired)
                {
                    DataTable dtPreheatComp = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSelUnitCoolingHeating + " WHERE id != " + ClsID.intCompNA_ID +
                                         " AND id != " + ClsID.intCompAutoID + " AND (enabled = 1 OR id = " + intPreheatCompID + ") ORDER BY display_order, id ASC").Copy();

                    returnInfo.ddlPreheatCompValue = ClsID.intCompElecHeaterID;

                    returnInfo.lblPreheatWarningText = strPreheatRequiredWarning;
                    returnInfo.lblPreheatWarningVisible = true;
                    returnInfo.txbPreheatSetpointDBText = dblPreheatSetPoint;
                    returnInfo.txbPreheatSetpointDBEnabled = false;

                    returnInfo.preheatElectricHeater = getPreheatElectricHeater();
                }
                else
                {
                    returnInfo.lblPreheatWarningVisible = false;
                }
            }
            return returnInfo;
        }

        public static dynamic getPreheatElectricHeater()
        {
            int intSelectedValue = 0;
            dynamic returnInfo = new ExpandoObject();

            if (intPreheatCompID == ClsID.intCompElecHeaterID || intPreheatCompID == ClsID.intCompAutoID)
            {
                DataTable dtPreheatElecHeaterInstallation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricHeaterInstallation, intPreheatElecHeaterInstallationID).Copy();
                dtPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation.Select("id <> 1").CopyToDataTable();
                returnInfo.ddlPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation;

                if (intLocationID == ClsID.intLocationOutdoorID)
                { 
                    dtPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation.Select("id = " + ClsID.intElecHeaterInstallInCasingID).CopyToDataTable();
                    returnInfo.ddlPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation;
                }
                else
                {

                    if (intProductTypeID == ClsID.intProdTypeNovaID || intProductTypeID == ClsID.intProdTypeVentumID)
                    {
                        returnInfo.ddlPreheatElecHeaterInstallationValue = intSelectedValue > 1 ? intSelectedValue : ClsID.intElecHeaterInstallInCasingID;
                    }
                    else if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
                    {
                        //Duct Mount is the only option
                        dtPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation.Select("id = " + ClsID.intElecHeaterInstallDuctMountedID).CopyToDataTable();
                        returnInfo.ddlPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation;
                    }
                }
                returnInfo.ddlPreheatElecHeaterInstallationValue = dtPreheatElecHeaterInstallation.Rows[0]["id"];
            }

            switch (intPreheatCompID)
            {
                case ClsID.intCompNA_ID:
                case ClsID.intCompHWC_ID:
                case ClsID.intCompAutoID:
                    returnInfo.divPreheatElecHeaterInstallationVisible = false;
                    break;
                case ClsID.intCompElecHeaterID:
                    returnInfo.divPreheatElecHeaterInstallationVisible = true;
                    break;
                default:
                    break;
            }

            returnInfo.electricHeaterVoltageInfo = getElectricHeaterVoltage();

            return returnInfo;
        }


        public static bool GetSetpoints(dynamic fieldInfo)
        {
            if (Convert.ToInt32(fieldInfo.unitTypeId) == ClsID.intUnitTypeAHU_ID &&
                Convert.ToInt32(fieldInfo.preheatComp) > 1 ||
                    Convert.ToInt32(fieldInfo.coolingComp) > 1 ||
                    Convert.ToInt32(fieldInfo.heatingComp) > 1 ||
                    Convert.ToInt32(fieldInfo.reheatComp) > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static dynamic GetUnitTypeInfo()
        {
            dynamic unitTypInfo = new ExpandoObject();
            unitTypInfo.productType = ClsDB.get_dtLiveEnabledInternal(ClsDBT.strSelProductType);
            unitTypInfo.productTypeUnitTypeLink = ClsDB.get_dtLive(ClsDBT.strSelProductTypeUnitTypeLink);
            unitTypInfo.unitType = ClsDB.get_dtLive(ClsDBT.strSelUnitType);
            return unitTypInfo;
        }

        public static DataTable GetUnitListByJobId(int jobID)
        {
            return get_dtUnitListFormated(ClsDB.GetSavedUnitsModel(jobID));
        }

        private static DataTable get_dtUnitListFormated(DataTable _dtUnitList)
        {
            DataTable dt = new DataTable("UnitList");
            dt.Columns.Add("unit_no", typeof(string));  //Actual unit number
            dt.Columns.Add("product_type_id", typeof(int));  //Actual unit number
            dt.Columns.Add("unit_nbr", typeof(string)); //Display number
            dt.Columns.Add("tag", typeof(string));
            dt.Columns.Add("qty", typeof(int));
            dt.Columns.Add("unit_type", typeof(string));
            dt.Columns.Add("unit_model", typeof(string));
            dt.Columns.Add("cfm", typeof(string));


            if (_dtUnitList.Rows.Count > 0)
            {
                for (int i = 0; i < _dtUnitList.Rows.Count; i++)
                {
                    int intProdTypeID = Convert.ToInt32(_dtUnitList.Rows[i]["product_type_id"]);
                    int intUnitTypeID = Convert.ToInt32(_dtUnitList.Rows[i]["unit_type_id"]);
                    int intIsBypass = Convert.ToInt32(_dtUnitList.Rows[i]["is_bypass"]);

                    DataRow dr = dt.NewRow();
                    dr["unit_no"] = _dtUnitList.Rows[i]["unit_no"].ToString();
                    dr["product_type_id"] = intProdTypeID;
                    dr["unit_nbr"] = i + 1;
                    dr["tag"] = _dtUnitList.Rows[i]["tag"].ToString();
                    dr["qty"] = _dtUnitList.Rows[i]["qty"].ToString();
                    dr["unit_type"] = ClsDB.get_dtByID(ClsDBT.strSelUnitType, Convert.ToInt32(_dtUnitList.Rows[i]["unit_type_id"])).Rows[0]["items"].ToString();

                    switch (intProdTypeID)
                    {
                        case ClsID.intProdTypeNovaID:
                            dr["unit_model"] = intIsBypass == 1 ? _dtUnitList.Rows[i]["NovaUnitModelBypass"].ToString() : _dtUnitList.Rows[i]["NovaUnitModel"].ToString();
                            break;
                        case ClsID.intProdTypeVentumID:
                            dr["unit_model"] = intUnitTypeID == ClsID.intUnitTypeERV_ID ? _dtUnitList.Rows[i]["VentumUnitModelERV"].ToString() : _dtUnitList.Rows[i]["VentumUnitModelHRV"].ToString();
                            break;
                        case ClsID.intProdTypeVentumLiteID:
                            dr["unit_model"] = intUnitTypeID == ClsID.intUnitTypeERV_ID ? _dtUnitList.Rows[i]["VentumLiteUnitModelERV"].ToString() : _dtUnitList.Rows[i]["VentumLiteUnitModelHRV"].ToString();
                            break;
                        case ClsID.intProdTypeTerraID:
                            dr["unit_model"] = _dtUnitList.Rows[i]["TeraUnitModel"].ToString();
                            break;
                        default:
                            break;
                    }

                    DataTable dtAFD = get_dtAirFlowData(Convert.ToInt32(_dtUnitList.Rows[i]["job_id"]), Convert.ToInt32(_dtUnitList.Rows[i]["unit_no"]));

                    if (dtAFD.Rows.Count > 0)
                    {
                        dr["cfm"] = dtAFD.Rows[0]["summer_supply_air_cfm"].ToString();
                    }


                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        private static DataTable get_dtAirFlowData(int _intJobID, int _intUnitNo)
        {
            DataTable dt = new DataTable();

            if (_intJobID > 0 && _intUnitNo > 0)
            {
                dt = ClsDB.GetSavedUnit(_intJobID, _intUnitNo);
            }

            return dt;
        }

        public static dynamic txbSummerSupplyAirCFM_Changed(string txbSummerSupplyAirCFMText, int ckbBypass)
        {
            dynamic returnInfo = new ExpandoObject();
            string summerSupplyAirCFM = txbSummerSupplyAirCFMText;

            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1)
                {
                    if (Convert.ToInt32(txbSummerSupplyAirCFMText) < intNOVA_MIN_CFM)
                    {
                        summerSupplyAirCFM = intNOVA_MIN_CFM.ToString();
                    }
                    else if (Convert.ToInt32(summerSupplyAirCFM) > intNOVA_MAX_CFM)
                    {
                        summerSupplyAirCFM = intNOVA_MAX_CFM.ToString();
                    }
                }
                else
                {
                    if (Convert.ToInt32(summerSupplyAirCFM) < intNOVA_INT_USERS_MIN_CFM)
                    {
                        summerSupplyAirCFM = intNOVA_INT_USERS_MIN_CFM.ToString();
                    }
                    else if (Convert.ToInt32(summerSupplyAirCFM) > intNOVA_INT_USERS_MAX_CFM)
                    {
                        summerSupplyAirCFM = intNOVA_INT_USERS_MAX_CFM.ToString();
                    }
                }
            }
            else if (intProductTypeID == ClsID.intProdTypeVentumID)
            {
                if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1)
                {
                    if (ckbBypass == 1)
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intVEN_INT_USERS_MIN_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intVEN_INT_USERS_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intVEN_INT_USERS_MAX_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intVEN_INT_USERS_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intVEN_INT_USERS_MIN_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intVEN_INT_USERS_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intVEN_INT_USERS_MAX_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intVEN_INT_USERS_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
                else
                {
                    if (ckbBypass == 1)
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intVEN_MIN_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intVEN_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intVEN_MAX_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intVEN_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intVEN_MIN_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intVEN_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intVEN_MAX_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intVEN_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
            }
            else if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
            {
                if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1)
                {
                    if (ckbBypass == 1)
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intVENLITE_INT_USERS_MIN_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intVENLITE_INT_USERS_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intVENLITE_INT_USERS_MAX_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intVENLITE_INT_USERS_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intVENLITE_INT_USERS_MIN_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intVENLITE_INT_USERS_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intVENLITE_INT_USERS_MAX_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intVENLITE_INT_USERS_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
                else
                {
                    if (ckbBypass == 1)
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intVENLITE_MIN_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intVENLITE_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intVENLITE_MAX_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intVENLITE_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intVENLITE_MIN_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intVENLITE_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intVENLITE_MAX_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intVENLITE_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
            }
            else if (intProductTypeID == ClsID.intProdTypeTerraID)
            {
                if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1)
                {
                    if (ckbBypass == 1)
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intTERA_INT_USERS_MIN_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intTERA_INT_USERS_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intTERA_INT_USERS_MAX_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intTERA_INT_USERS_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intTERA_INT_USERS_MIN_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intTERA_INT_USERS_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intTERA_INT_USERS_MAX_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intTERA_INT_USERS_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
                else
                {
                    if (ckbBypass == 1)
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intTERA_MIN_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intTERA_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intTERA_MAX_CFM_WITH_BYPASS)
                        {
                            summerSupplyAirCFM = intTERA_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(summerSupplyAirCFM) < intTERA_MIN_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intTERA_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerSupplyAirCFM) > intTERA_MAX_CFM_NO_BYPASS)
                        {
                            summerSupplyAirCFM = intTERA_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
            }

            returnInfo.txbSummerSupplyAirCFM = Convert.ToInt32(summerSupplyAirCFM);
            returnInfo.txbSummerReturnAirCFM = Convert.ToInt32(summerSupplyAirCFM);
            returnInfo.ddlOrientation = getOrientation(summerSupplyAirCFM);
            returnInfo.ddlOrientationValue = returnInfo.ddlOrientation.Rows[0]["id"];
            intOrientationID = returnInfo.ddlOrientationValue;

            dynamic modelAndBypassInfo = getModel(summerSupplyAirCFM, ckbBypass);

            returnInfo.ddlUnitModel = modelAndBypassInfo.ddlUnitModel;
            returnInfo.ddlUnitModelValue = returnInfo.ddlUnitModel.Rows[0]["id"];
            intUnitModelID= returnInfo.ddlUnitModelValue;

            returnInfo.ckbBypass = modelAndBypassInfo.ckbBypass;
            returnInfo.others = modelAndBypassInfo.others;

            returnInfo.ckbBypass = modelAndBypassInfo.ckbBypass;
            ckbBypassChecked = modelAndBypassInfo.ckbBypass;

            dynamic ddlSupplyAirOpeningInfo = getSupplyAirOpening();
            returnInfo.ddlSupplyAirOpening = ddlSupplyAirOpeningInfo.data;
            returnInfo.ddlSupplyAirOpeningValue = ddlSupplyAirOpeningInfo.value;
            returnInfo.ddlSupplyAirOpeningText = ddlSupplyAirOpeningInfo.text;
            intSupplyAirOpeningID = ddlSupplyAirOpeningInfo.value;

            return returnInfo;
        }


        public static int txbSummerReturnAirCFM_Changed(string txbSummerReturnAirCFMText, string txbSummerSupplyAirCFMText, int ckbBypass)
        {
            if (!ClsNumber.IsNumber(txbSummerReturnAirCFMText) || !ClsNumber.IsNumber(txbSummerReturnAirCFMText))
            {
                return 0;
            }

            string txbSummerReturnAirCFM = txbSummerReturnAirCFMText;
            Boolean byPass = ckbBypass == 1;

            if (intOrientationID == ClsID.intOrientationHorizontalID && Convert.ToInt32(txbSummerSupplyAirCFMText) > intNOVA_HORIZONTAL_MAX_CFM)
            {
                txbSummerReturnAirCFM = intNOVA_HORIZONTAL_MAX_CFM.ToString();
            }

            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                if (Convert.ToInt32(txbSummerReturnAirCFM) < intNOVA_MIN_CFM)
                {
                    txbSummerReturnAirCFM = intNOVA_MIN_CFM.ToString();
                }
                else if (Convert.ToInt32(txbSummerReturnAirCFM) > intNOVA_MAX_CFM)
                {
                    txbSummerReturnAirCFM = intNOVA_MAX_CFM.ToString();
                }
            }
            else if (intProductTypeID == ClsID.intProdTypeVentumID)
            {
                if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1)
                {
                    if (byPass)
                    {
                        if (Convert.ToInt32(txbSummerReturnAirCFM) < intVEN_INT_USERS_MIN_CFM_WITH_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVEN_INT_USERS_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(txbSummerReturnAirCFM) > intVEN_INT_USERS_MAX_CFM_WITH_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVEN_INT_USERS_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(txbSummerReturnAirCFM) < intVEN_INT_USERS_MIN_CFM_NO_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVEN_INT_USERS_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(txbSummerReturnAirCFM) > intVEN_INT_USERS_MAX_CFM_NO_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVEN_INT_USERS_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
                else
                {
                    if (byPass)
                    {
                        if (Convert.ToInt32(txbSummerReturnAirCFM) < intVEN_MIN_CFM_WITH_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVEN_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(txbSummerReturnAirCFM) > intVEN_MAX_CFM_WITH_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVEN_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(txbSummerReturnAirCFM) < intVEN_MIN_CFM_NO_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVEN_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(txbSummerReturnAirCFM) > intVEN_MAX_CFM_NO_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVEN_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
            }
            else if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
            {
                if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1)
                {
                    if (byPass)
                    {
                        if (Convert.ToInt32(txbSummerReturnAirCFM) < intVENLITE_INT_USERS_MIN_CFM_WITH_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVENLITE_INT_USERS_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(txbSummerReturnAirCFM) > intVENLITE_INT_USERS_MAX_CFM_WITH_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVENLITE_INT_USERS_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(txbSummerReturnAirCFM) < intVENLITE_INT_USERS_MIN_CFM_NO_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVENLITE_INT_USERS_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(txbSummerReturnAirCFM) > intVENLITE_INT_USERS_MAX_CFM_NO_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVENLITE_INT_USERS_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
                else
                {
                    if (byPass)
                    {
                        if (Convert.ToInt32(txbSummerReturnAirCFM) < intVENLITE_MIN_CFM_WITH_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVENLITE_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(txbSummerReturnAirCFM) > intVENLITE_MAX_CFM_WITH_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVENLITE_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(txbSummerReturnAirCFM) < intVENLITE_MIN_CFM_NO_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVENLITE_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(txbSummerReturnAirCFM) > intVENLITE_MAX_CFM_NO_BYPASS)
                        {
                            txbSummerReturnAirCFM = intVENLITE_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
            }


            if ((intProductTypeID == ClsID.intProdTypeNovaID && intUnitTypeID == ClsID.intUnitTypeERV_ID) ||
               ((intProductTypeID == ClsID.intProdTypeVentumID || intProductTypeID == ClsID.intProdTypeVentumLiteID) && intUnitTypeID == ClsID.intUnitTypeHRV_ID))
            {
                if (Convert.ToInt32(txbSummerReturnAirCFM) < (Convert.ToInt32(txbSummerSupplyAirCFMText) * 0.5))
                {
                    txbSummerReturnAirCFM = Math.Ceiling(Convert.ToDecimal(txbSummerSupplyAirCFMText) * 0.5m).ToString();
                }
                else if (Convert.ToInt32(txbSummerReturnAirCFM) > (Convert.ToInt32(txbSummerSupplyAirCFMText) * 1.5m))
                {
                    txbSummerReturnAirCFM = Math.Ceiling(Convert.ToDecimal(txbSummerSupplyAirCFMText) * 1.5m).ToString();
                }
            }
            else if ((intProductTypeID == ClsID.intProdTypeVentumID || intProductTypeID == ClsID.intProdTypeVentumLiteID) && intUnitTypeID == ClsID.intUnitTypeERV_ID)
            {
                if (Convert.ToInt32(txbSummerReturnAirCFM) < (Convert.ToInt32(txbSummerSupplyAirCFMText) * 0.8))
                {
                    txbSummerReturnAirCFM = Math.Ceiling(Convert.ToDecimal(txbSummerSupplyAirCFMText) * 0.8m).ToString();
                }
                else if (Convert.ToInt32(txbSummerReturnAirCFM) > (Convert.ToInt32(txbSummerSupplyAirCFMText) * 1.2))
                {
                    txbSummerReturnAirCFM = Math.Ceiling(Convert.ToDecimal(txbSummerSupplyAirCFMText) * 1.2m).ToString();
                }
            }

            return Convert.ToInt32(txbSummerReturnAirCFM);
        }


        public static dynamic txbSupplyAirESP_Changed(string txbSupplyAirESP)
        {
            if (!ClsNumber.IsNumber(txbSupplyAirESP))
            {
                return "0";
            }

            String supplyAirESP = txbSupplyAirESP;

            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                if (intUnitModelID == ClsID.intNovaUnitModelID_A16IN || intUnitModelID == ClsID.intNovaUnitModelID_B20IN ||
                    intUnitModelID == ClsID.intNovaUnitModelID_A18OU || intUnitModelID == ClsID.intNovaUnitModelID_B22OU)
                {
                    if (Convert.ToDouble(txbSupplyAirESP) > 2.0d)
                    {
                        supplyAirESP = "2.0";
                    }

                }
                else if (Convert.ToDouble(txbSupplyAirESP) > 3.0d)
                {
                    supplyAirESP = "3.0";
                }
            }

            return Convert.ToDouble(supplyAirESP);
       }


        public static dynamic txbExhaustAirESP_Changed(string txbExhaustAirESPText)
        {
            string exhaustAirESP = txbExhaustAirESPText;

            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                if (intUnitModelID == ClsID.intNovaUnitModelID_A16IN || intUnitModelID == ClsID.intNovaUnitModelID_B20IN ||
                    intUnitModelID == ClsID.intNovaUnitModelID_A18OU || intUnitModelID == ClsID.intNovaUnitModelID_B22OU)
                {
                    if (Convert.ToDouble(exhaustAirESP) > 2.0d)
                    {
                        exhaustAirESP = "2.0";
                    }

                }
                else if (Convert.ToDouble(exhaustAirESP) > 3.0d)
                {
                    exhaustAirESP = "3.0";
                }
            }

            return Convert.ToDouble(exhaustAirESP);
        }

        private static DataTable getOrientation(string txbSummerSupplyAirCFMText)
        {
            String summerSupplyAirCFM = txbSummerSupplyAirCFMText;
            DataTable dtLocOri = ClsDB.get_dtLive(ClsDBT.strSelLocOriLink);
            dtLocOri = dtLocOri.Select("[product_type_id]=" + intProductTypeID).CopyToDataTable();
            dtLocOri = dtLocOri.Select("[unit_type_id]=" + intUnitTypeID).CopyToDataTable();
            dtLocOri = dtLocOri.Select("[location_id]=" + intLocationID).CopyToDataTable();

            DataTable dtOrientation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelGeneralOrientation, intOrientationID);
            dtOrientation = ClsTS.get_dtFromLink(dtOrientation, "orientation_id", dtLocOri, "max_cfm");

            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                dtOrientation = dtOrientation.Select("[max_cfm] >= '" + summerSupplyAirCFM + "'").CopyToDataTable();
            }

            return dtOrientation;
        }

        private static dynamic getVoltage()
        {
            string strModelVoltageLinkTable = "";

            switch (intProductTypeID)
            {
                case ClsID.intProdTypeNovaID:
                    strModelVoltageLinkTable = ClsDBT.strSelNovaUnitModelVoltageLink;
                    break;
                default:
                    break;
            }

            DataTable dtVoltage = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricalVoltage, intUnitVoltageID);
            DataTable dtLink = ClsDB.get_dtLive(strModelVoltageLinkTable, "unit_model_id", intUnitModelID).Copy();

            if (intProductTypeID == ClsID.intProdTypeNovaID && (intUAL == ClsID.intUAL_External || intUAL == ClsID.intUAL_ExternalSpecial))
            {
                if (intUnitModelID == ClsID.intNovaUnitModelID_B20IN || intUnitModelID == ClsID.intNovaUnitModelID_B22OU)
                {
                    dtVoltage = dtVoltage.Select("[id] <> '" + ClsID.intElectricVoltage_208V_1Ph_60HzID.ToString() + "'").CopyToDataTable();
                }
            }
            else if (intProductTypeID == ClsID.intProdTypeTerraID && true)
            {
                dtVoltage = dtVoltage.Select("[terra_2] = '1'").CopyToDataTable();

            }

            dynamic ddlUnitVoltage = ClsWFC.get_ddlItemsAddedOnID(dtVoltage, "voltage_id", dtLink);
            intUnitVoltageID = ddlUnitVoltage.Rows[0]["id"];

            return ddlUnitVoltage;
        }

        private static dynamic getModel(string txbSummerSupplyAirCFMText, int ckbByPass)
        {
            int summerSupplyAirCFM = Convert.ToInt32(txbSummerSupplyAirCFMText);
            int byPass = ckbByPass;
            dynamic modelInfo = new ExpandoObject();
            DataTable dtUnitModel = new DataTable();

            if (intLocationID > -1 && intOrientationID > -1)
            {
                switch (intProductTypeID)
                {
                    case ClsID.intProdTypeNovaID:
                        DataTable dtUnitModelLink = ClsDB.get_dt(ClsDBT.strSelNovaUnitModelLocOriLink);

                        dtUnitModelLink = dtUnitModelLink.Select("[location_id]='" + intLocationID.ToString() + "'").CopyToDataTable();
                        dtUnitModelLink = dtUnitModelLink.Select("[orientation_id]='" + intOrientationID.ToString() + "'").CopyToDataTable();

                        if (intUAL == ClsID.intUAL_External || intUAL == ClsID.intUAL_ExternalSpecial)
                        {
                            dtUnitModel = dtUnitModel = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSelNovaUnitModel + " WHERE " + summerSupplyAirCFM + " >= cfm_min_ext_users AND " +
                                            summerSupplyAirCFM + " <= cfm_max_ext_users OR id=" + intUnitModelID.ToString() + " ORDER BY cfm_max");
                        }
                        else
                        {
                            dtUnitModel = dtUnitModel = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSelNovaUnitModel + " WHERE " + summerSupplyAirCFM + " >= cfm_min AND " +
                                            summerSupplyAirCFM + " <= cfm_max OR id=" + intUnitModelID.ToString() + " ORDER BY cfm_max");
                        }


                        if (intUAL == ClsID.intUAL_External || intUAL == ClsID.intUAL_ExternalSpecial)
                        {
                            dtUnitModel = dtUnitModel.Select("[enabled_ext_users]='1'").CopyToDataTable();
                        }


                        dtUnitModel = ClsTS.get_dtFromLink(dtUnitModel, "unit_model_id", dtUnitModelLink, "cfm_max");
                        dtUnitModel = ClsTS.get_dtSortedASC(dtUnitModel, "cfm_max");

                        if (byPass == 1)
                        {
                            var drUnitModelBypass = dtUnitModel.AsEnumerable().Where(x => (Convert.ToInt32(x["bypass_exist"]) == 1));
                            DataTable dtUnitModelBypass = drUnitModelBypass.Any() ? drUnitModelBypass.CopyToDataTable() : new DataTable();

                            if (dtUnitModelBypass.Rows.Count > 0)
                            {
                                dtUnitModel = dtUnitModel.Select("[bypass_exist]='1'").CopyToDataTable();
                                //divUnitBypass.Visible = true;

                                if (intOrientationID == ClsID.intOrientationHorizontalID)
                                {
                                    var drUnitModelBypassHorUnit = dtUnitModel.AsEnumerable().Where(x => (Convert.ToInt32(x["bypass_exist_horizontal_unit"]) == 1));
                                    DataTable dtUnitModelBypassHorUnit = drUnitModelBypassHorUnit.Any() ? drUnitModelBypassHorUnit.CopyToDataTable() : new DataTable();

                                    if (dtUnitModelBypassHorUnit.Rows.Count > 0)
                                    {
                                        dtUnitModel = dtUnitModel.Select("[bypass_exist_horizontal_unit]='1'").CopyToDataTable();
                                    }
                                    else
                                    {
                                        byPass = 0;
                                    }
                                }

                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            modelInfo.ddlUnitModel = dtUnitModel;
            modelInfo.ddlUnitInfoValue = dtUnitModel.Rows[0]["id"];
            intUnitModelID = modelInfo.ddlUnitInfoValue;
            modelInfo.ckbBypass = byPass;

            modelInfo.others = ddlUnitModelIndexChanged("0.75", "0.75");
            return modelInfo;
        }

        public static dynamic ddlUnitModelIndexChanged(string txbSupplyAirESP, string txbExhaustAirESP)
        {
            dynamic info = new ExpandoObject();
            info.ddlUnitVoltage = getVoltage();
            info.ddlUnitVoltageValue = intUnitVoltageID;
            info.txbSupplyAirESP = txbSupplyAirESP_Changed(txbSupplyAirESP);
            info.txbExhaustAirESP = txbExhaustAirESP_Changed(txbExhaustAirESP);
            info.elecHeaterVoltage = getElectricHeaterVoltage();
            info.ckbBypass = getBypass();

            return info;
        }

        private static dynamic getBypass()
        {
            dynamic returnInfo = new ExpandoObject();
            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                DataTable dtUnitModel = ClsDB.get_dtByID(ClsDBT.strSelNovaUnitModel, intUnitModelID);
                int intBypassExist = Convert.ToInt32(dtUnitModel.Rows[0]["bypass_exist"]);

                if (intBypassExist == 1)
                {
                    //ckbBypass.Checked = true;
                    //divUnitBypass.Visible = true;
                    returnInfo.ckbBypassEnabled = true;
                    returnInfo.ckbBypassText = "";
                }
                else
                {
                    //divUnitBypass.Visible = false;
                    returnInfo.ckbBypassChecked = 0;
                    returnInfo.ckbBypassEnabled = false;
                    returnInfo.ckbBypassText = " Not available for selected model";

                }


                if (intOrientationID == ClsID.intOrientationHorizontalID)
                {
                    var drUnitModelBypassHorUnit = dtUnitModel.AsEnumerable().Where(x => (Convert.ToInt32(x["bypass_exist_horizontal_unit"]) == 1));
                    DataTable dtUnitModelBypassHorUnit = drUnitModelBypassHorUnit.Any() ? drUnitModelBypassHorUnit.CopyToDataTable() : new DataTable();

                    if (dtUnitModelBypassHorUnit.Rows.Count > 0)
                    {
                        returnInfo.ckbBypassEnabled = true;
                        returnInfo.ckbBypassText = "";
                    }
                    else
                    {
                        returnInfo.ckbBypassChecked = 0;
                        returnInfo.ckbBypassEnabled = false;
                        returnInfo.ckbBypassText = " Not available for selected model";
                    }
                }
            }

            return returnInfo;
        }

        public static dynamic getSupplyAirOpening()
        {
            dynamic supplyAirOpeningInfo = new ExpandoObject();
            DataTable dtLink = new DataTable();

            if (intUnitTypeID == ClsID.intUnitTypeERV_ID || intUnitTypeID == ClsID.intUnitTypeHRV_ID)
            {
                dtLink = ClsDB.get_dtLive(ClsDBT.strSelOrientOpeningsERV_SA_Link, "product_type_id", intProductTypeID).Copy();
                dtLink = ClsTS.get_dtDataFromImportRows(dtLink, "location_id", intLocationID);
                dtLink = ClsTS.get_dtDataFromImportRows(dtLink, "orientation_id", intOrientationID);

                DataTable dtSelectionTable = ClsDB.get_dtLiveEnabled(ClsDBT.strSelOpeningsERV_SA, "items", strSupplyAirOpening).Copy();
                dtSelectionTable = ClsTS.get_dtDataFromImportRows(dtSelectionTable, "product_type_id", intProductTypeID);
                supplyAirOpeningInfo.data = ClsWFC.get_ddlItemsAddedOnValue(dtSelectionTable, "openings_sa", dtLink);
                supplyAirOpeningInfo.value = getSA_OpeningForVerticalUnit();
                supplyAirOpeningInfo.text = strSupplyAirOpening;
                if (supplyAirOpeningInfo.value == 0)
                {
                    supplyAirOpeningInfo.text = strSupplyAirOpening;
                }
                for (int i = 0; i < supplyAirOpeningInfo.data.Rows.Count; i++)
                {
                    if (supplyAirOpeningInfo.ddlSupplyAirOpening.Rows[i]["id"] == supplyAirOpeningInfo.value)
                    {
                        supplyAirOpeningInfo.text = supplyAirOpeningInfo.ddlSupplyAirOpening.Rows[i]["items"];
                    }
                }
            }
            else if (intUnitTypeID == ClsID.intUnitTypeAHU_ID)
            {
                supplyAirOpeningInfo.data = ClsDB.get_dtLiveEnabled(ClsDBT.strSelOpeningsFC_SA, intSupplyAirOpeningID);
                supplyAirOpeningInfo.value = supplyAirOpeningInfo.ddlSupplyAirOpening.Rows[0]["id"];
                supplyAirOpeningInfo.text = supplyAirOpeningInfo.ddlSupplyAirOpening.Rows[0]["items"];
            }

            return supplyAirOpeningInfo;
        }

        private static int getSA_OpeningForVerticalUnit()
        {
            if (intOrientationID == ClsID.intOrientationVerticalID && intCoolingCompID > 1 || intHeatingCompID > 1 || intReheatCompID > 1)
            {
                return ClsID.intSA_Open_2_ID;
            }
            else
            {
                return 0;
            }
        }


        private static dynamic ddlUnitTypeInexChanged()
        {
            dynamic returnInfo = new ExpandoObject();

            DataTable dtProdUnitLocLink = ClsDB.get_dtLive(ClsDBT.strSelProductTypeUnitTypeLocLink);
            dtProdUnitLocLink = dtProdUnitLocLink.Select("[product_type_id]=" + intProductTypeID).CopyToDataTable();
            dtProdUnitLocLink = dtProdUnitLocLink.Select("[unit_type_id]=" + intUnitTypeID).CopyToDataTable();
            DataTable dtLocation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelGeneralLocation, intLocationID);

            returnInfo.ddlLocation = ClsWFC.get_ddlItemsAddedOnID(dtLocation, "location_id", dtProdUnitLocLink);
            returnInfo.ddlLocationValue = Convert.ToInt32(returnInfo.ddlLocation.Rows[0]["id"]);
            intLocationID = returnInfo.ddlLocationValue;
            returnInfo.ckbDownshot = getDownshot();

            DataTable dtOA_FilterType = ClsDB.get_dtLiveEnabled(ClsDBT.strSelFilterModel, "outdoor_air", 1, intOA_FilterModelID).Copy();
            returnInfo.ddlOA_FilterModel = dtOA_FilterType;
            returnInfo.ddlOA_FilterModelValue = ClsID.intFilterModel_2in_85_MERV_13_ID;
            intOA_FilterModelID = ClsID.intFilterModel_2in_85_MERV_13_ID;

            DataTable dtRA_FilterType;

            switch (intUnitTypeID)
            {
                case ClsID.intUnitTypeERV_ID:
                case ClsID.intUnitTypeHRV_ID:
                    dtRA_FilterType = ClsDB.get_dtLiveEnabled(ClsDBT.strSelFilterModel, "return_air", 1, intRA_FilterModelID).Copy();
                    returnInfo.ddlRA_FilterModel = dtRA_FilterType;
                    returnInfo.ddlRA_FilterModelValue = dtRA_FilterType.Rows[0]["id"];
                    intRA_FilterModelID = returnInfo.ddlRA_FilterModelValue;
                    break;
                default:
                    dtRA_FilterType = ClsDB.get_dtLive(ClsDBT.strSelFilterModel, ClsID.intFilterModel_NA_ID).Copy();
                    returnInfo.ddlRA_FilterModel = dtRA_FilterType;
                    returnInfo.ddlRA_FilterModelValue = dtRA_FilterType.Rows[0]["id"];
                    intRA_FilterModelID = returnInfo.ddlRA_FilterModelValue;
                    break;
            }



            DataTable dtPreheatComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating, intPreheatCompID, "display_order, id ASC").Copy();
            DataTable dtHeatExchComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitHeatExchanger, intHeatExchCompID);
            DataTable dtCoolingComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating, intCoolingCompID).Copy();
            DataTable dtHeatingComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating, intHeatingCompID).Copy();
            DataTable dtReheatComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating, intReheatCompID).Copy();


            if (intUnitTypeID == ClsID.intUnitTypeERV_ID)
            {
                returnInfo.lblSummerSupplyAirCFMText = "Supply Air (CFM):";
                returnInfo.lblSupplyAirESPText = "Supply Air ESP (inH2O):";

                returnInfo.divSummerReturnAirCFMVisible = true;
                returnInfo.divExhaustAirESPVisible = true;
                returnInfo.divRA_FilterPDVisible = true;

                returnInfo.divRA_FilterModelVisible = true;
                returnInfo.divPreheatCompVisible = true;
                returnInfo.divCoolingCompVisible = true;
                returnInfo.divHeatingCompVisible = true;

                dtPreheatComp = ClsTS.get_dtDataFromImportRows(dtPreheatComp, "erv_preheat", 1);

                if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
                {
                    var drPreheatComp = dtPreheatComp.AsEnumerable().Where(x => Convert.ToInt32(x["id"]) != ClsID.intCompHWC_ID);
                    dtPreheatComp = drPreheatComp.Any() ? drPreheatComp.CopyToDataTable() : new DataTable();
                }


                dtHeatExchComp = ClsTS.get_dtDataFromImportRows(dtHeatExchComp, "erv", 1);
                dtCoolingComp = ClsTS.get_dtDataFromImportRows(dtCoolingComp, "erv_cooling", 1);
                dtHeatingComp = ClsTS.get_dtDataFromImportRows(dtHeatingComp, "erv_heating", 1);
                //dtReheatComp = clsTS.get_dtDataFromImportRows(dtReheatComp, "erv_reheat", 1);
            }
            else if (intUnitTypeID == ClsID.intUnitTypeHRV_ID)
            {
                returnInfo.lblSummerSupplyAirCFMText = "Supply Air (CFM):";
                returnInfo.lblSupplyAirESPText = "Supply Air ESP (inH2O):";

                returnInfo.divSummerReturnAirCFMVisible = true;
                returnInfo.divExhaustAirESPVisible = true;
                returnInfo.divRA_FilterPDVisible = true;

                returnInfo.divRA_FilterModelVisible = true;
                returnInfo.divPreheatCompVisible = true;
                //divHeatExchComp.Visible = true;
                returnInfo.divCoolingCompVisible = true;
                returnInfo.divHeatingCompVisible = true;


                dtPreheatComp = ClsTS.get_dtDataFromImportRows(dtPreheatComp, "hrv_preheat", 1);

                if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
                {
                    var drPreheatComp = dtPreheatComp.AsEnumerable().Where(x => (Convert.ToInt32(x["id"]) != ClsID.intCompHWC_ID));
                    dtPreheatComp = drPreheatComp.Any() ? drPreheatComp.CopyToDataTable() : new DataTable();
                }

                dtHeatExchComp = ClsTS.get_dtDataFromImportRows(dtHeatExchComp, "hrv", 1);
                dtCoolingComp = ClsTS.get_dtDataFromImportRows(dtCoolingComp, "hrv_cooling", 1);
                dtHeatingComp = ClsTS.get_dtDataFromImportRows(dtHeatingComp, "hrv_heating", 1);
            }
            else if (intUnitTypeID == ClsID.intUnitTypeAHU_ID)
            {
                returnInfo.lblSummerSupplyAirCFMText = "Design Air Flow (CFM):";
                returnInfo.lblSupplyAirESPText = "Design ESP (inH2O):";

                returnInfo.divSummerReturnAirCFMVisible = false;
                returnInfo.divExhaustAirESPVisible = false;
                returnInfo.divRA_FilterPDVisible = false;

                returnInfo.divRA_FilterModelVisible = false;
                returnInfo.divPreheatCompVisible = true;

                returnInfo.divCoolingCompVisible = true;
                returnInfo.divHeatingCompVisible = false;


                dtHeatExchComp = ClsTS.get_dtDataFromImportRows(dtHeatExchComp, "fc", 1);
                dtPreheatComp = ClsTS.get_dtDataFromImportRows(dtPreheatComp, "fc_preheat", 1);
                dtCoolingComp = ClsTS.get_dtDataFromImportRows(dtCoolingComp, "fc_cooling", 1);
                dtHeatingComp = ClsTS.get_dtDataFromImportRows(dtHeatingComp, "fc_heating", 1);
                //dtReheatComp = clsTS.get_dtDataFromImportRows(dtReheatComp, "fc_reheat", 1);
            }




            //-----------------------------------------------------------------------------------------------------

            returnInfo.ddlPreheatComp = dtPreheatComp;
            returnInfo.ddlPreheatCompValue = dtPreheatComp.Rows[0]["id"];
            intPreheatCompID = Convert.ToInt32(dtPreheatComp.Rows[0]["id"]);

            returnInfo.ddlHeatExchComp = dtHeatExchComp;
            returnInfo.ddlHeatExchCompValue = dtHeatExchComp.Rows[0]["id"];
            intHeatExchCompID = Convert.ToInt32(dtHeatExchComp.Rows[0]["id"]);

            returnInfo.ddlHeatingComp = dtHeatingComp;
            returnInfo.ddlHeatingCompValue = dtHeatingComp.Rows[0]["id"];
            intHeatingCompID = Convert.ToInt32(dtHeatingComp.Rows[0]["id"]);

            returnInfo.ddlCoolingComp = dtCoolingComp;
            returnInfo.ddlCoolingCompValue = dtCoolingComp.Rows[0]["id"];
            intCoolingCompID = Convert.ToInt32(dtCoolingComp.Rows[0]["id"]);

            returnInfo.componentOptions = getComponentOptions();

            DataTable dtCoolingFluidType = ClsDB.get_dtLiveEnabled(ClsDBT.strSelFluidType, intCoolingFluidTypeID).Copy();
            DataTable dtHeatingFluidType = ClsDB.get_dtLiveEnabled(ClsDBT.strSelFluidType, intHeatingFluidTypeID).Copy();

            returnInfo.ddlCoolingFluidType = dtCoolingFluidType;
            returnInfo.ddlCoolingFluidTypeValue = returnInfo.ddlCoolingFluidType.Rows[0]["id"];
            intCoolingFluidTypeID = returnInfo.ddlCoolingFluidTypeValue;
            returnInfo.ddlCoolingFluidConcentration = ddlCoolingFluidTypeInexChanged();
            returnInfo.ddlCoolingFluidConcentrationValue = returnInfo.ddlCoolingFluidConcentration.Rows[0]["id"];
            intCoolingFluidTypeID = returnInfo.ddlCoolingFluidConcentrationValue;

            returnInfo.ddlHeatingFluidType = dtHeatingFluidType;
            returnInfo.ddlHeatingFluidTypeValue = returnInfo.ddlHeatingFluidType.Rows[0]["id"];
            intHeatingFluidTypeID = returnInfo.ddlHeatingFluidTypeValue;
            returnInfo.ddlHeatingFluidConcentration = ddlHeatingFluidTypeIndexChanged();
            returnInfo.ddlHeatingFluidConcentrationValue = returnInfo.ddlHeatingFluidConcentration.Rows[0]["id"];
            intCoolingFluidTypeID = returnInfo.ddlHeatingFluidConcentrationValue;


            if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
            {
                returnInfo.ventumLiteCompOptions = getVentumLiteCompOptions();
            }

            return returnInfo;
        }

        private static dynamic getVentumLiteCompOptions()
        {
            dynamic ventumLiteCompOptions = new ExpandoObject();
            ventumLiteCompOptions.divCoolingCompVisible = false;
            ventumLiteCompOptions.divHeatingCompVisible = false;
            ventumLiteCompOptions.divDehumidificationVisible = false;
            ventumLiteCompOptions.divReheatCompVisible = false;
            ventumLiteCompOptions.divCoolingCoilHandingVisible = false;
            ventumLiteCompOptions.divHeatingCoilHandingVisible = false;
            ventumLiteCompOptions.divValveTypeVisible = false;

            return ventumLiteCompOptions;
        }

        private static dynamic ddlCoolingFluidTypeInexChanged()
        {
            return ClsWFC.get_ddlItemsAddedOnID(ClsDB.get_dtLiveEnabled(ClsDBT.strSelFluidConcentration, intCoolingFluidConcentrationID), "fluid_type_id", intCoolingFluidTypeID);
        }

        private static dynamic ddlHeatingFluidTypeIndexChanged()
        {
            return ClsWFC.get_ddlItemsAddedOnID(ClsDB.get_dtLiveEnabled(ClsDBT.strSelFluidConcentration, intHeatingFluidConcentrationID), "fluid_type_id", intHeatingFluidTypeID);
        }

        private static dynamic getComponentOptions()
        {
            dynamic componentOptions = new ExpandoObject();
            //componentOptions.divDXC_MsgVisible = false;
            //componentOptions.divHeatPumpVisible = false;
            //componentOptions.divDehumidificationVisible = false;
            //componentOptions.divElecHeaterVoltageVisible = false;
            //componentOptions.divHeatElecHeaterInstallationVisible = false;

            //componentOptions.divPreheatSetpointVisible = false;
            //componentOptions.divCoolingSetpointDBVisible = false;
            //componentOptions.divCoolingSetpointWBVisible = false;
            //componentOptions.divHeatingSetpointVisible = false;
            //componentOptions.divReheatSetpointVisible = false;
            //componentOptions.divSetpointsVisible = false;

            //componentOptions.divCoolingFluidDesignConditionsVisible = false;
            //componentOptions.divDX_RefrigerantVisible = false;
            //componentOptions.divHeatingFluidDesignConditionsVisible = false;
            //componentOptions.divCondRefrigerantVisible = false;
            //componentOptions.divReheatCompVisible = false;
            //componentOptions.divValveAndActuatorVisible = false;

            ////Custom - Internal use only
            //componentOptions.divPreheatHWC_UseCapVisible = false;
            //componentOptions.divPreheatHWC_CapVisible = false;
            //componentOptions.divPreheatHWC_UseFlowRateVisible = false;
            //componentOptions.divPreheatHWC_FlowRateVisible = false;
            //componentOptions.divCoolingCWC_UseCapVisible = false;
            //componentOptions.divCoolingCWC_CapVisible = false;
            //componentOptions.divCoolingCWC_UseFlowRateVisible = false;
            //componentOptions.divCoolingCWC_FlowRateVisible = false;
            //componentOptions.divHeatingHWC_UseCapVisible = false;
            //componentOptions.divHeatingHWC_CapVisible = false;
            //componentOptions.divHeatingHWC_UseFlowRateVisible = false;
            //componentOptions.divHeatingHWC_FlowRateVisible = false;

            componentOptions.cooling = getCooling();
            componentOptions.dehumidification = getDehumidification();
            componentOptions.reheat = getReheat();
            componentOptions.divPreheatSetpointVisible = getPreheatSetpoint();
            componentOptions.divCoolingSetpointVisible = getCoolingSetpoint();
            componentOptions.divHeatingSetpointVisible = getHeatingSetpoint();
            componentOptions.reheatSetpoints = getReheatSetpoints();
            componentOptions.drainPan = getDrainPan();
            componentOptions.divSetpointsVisible = getSetPoints();
            componentOptions.divHeatingFluidDesignConditionsVisible = getHeatingFluidDesignConditions();
            componentOptions.refrigerantInfo = getRefrigerant();
            componentOptions.preheatElectricHeater = getPreheatElectricHeater();
            componentOptions.heatElectricHeater = getHeatElectricHeater();
            componentOptions.electricHeaterVoltage = getElectricHeaterVoltage();
            componentOptions.valveAndActuator = getValveAndActuator();
            componentOptions.customInputs = getCustomInputs();

            return componentOptions;
        }

        public static dynamic getCustomInputs()
        {
            dynamic costomInputs = new ExpandoObject();
            if (intPreheatCompID == ClsID.intCompHWC_ID)
            {
                costomInputs.divPreheatHWC_UseFlowRateVisible = true;
                costomInputs.divPreheatHWC_FlowRateVisible = true;

                if (intUnitTypeID == ClsID.intUnitTypeAHU_ID)
                {
                    costomInputs.divPreheatHWC_UseCapVisible = true;
                    costomInputs.divPreheatHWC_CapVisible = true;
                }
                else
                {
                    costomInputs.divPreheatHWC_UseCapVisible = false;
                    costomInputs.divPreheatHWC_CapVisible = false;
                }
            }
            else
            {
                costomInputs.divPreheatHWC_UseCapVisible = false;
                costomInputs.divPreheatHWC_CapVisible = false;
                costomInputs.divPreheatHWC_UseFlowRateVisible = false;
                costomInputs.divPreheatHWC_FlowRateVisible = false;
            }


            if (intCoolingCompID == ClsID.intCompCWC_ID)
            {
                costomInputs.divCoolingCWC_UseCapVisible = true;
                costomInputs.divCoolingCWC_CapVisible = true;
                costomInputs.divCoolingCWC_UseFlowRateVisible = true;
                costomInputs.divCoolingCWC_FlowRateVisible = true;
            }
            else
            {
                costomInputs.divCoolingCWC_UseCapVisible = false;
                costomInputs.divCoolingCWC_CapVisible = false;
                costomInputs.divCoolingCWC_UseFlowRateVisible = false;
                costomInputs.divCoolingCWC_FlowRateVisible = false;
            }


            if (intHeatingCompID == ClsID.intCompHWC_ID)
            {
                costomInputs.divHeatingHWC_UseCapVisible = true;
                costomInputs.divHeatingHWC_CapVisible = true;
                costomInputs.divHeatingHWC_UseFlowRateVisible = true;
                costomInputs.divHeatingHWC_FlowRateVisible = true;
            }
            else
            {
                costomInputs.divHeatingHWC_UseCapVisible = false;
                costomInputs.divHeatingHWC_CapVisible = false;
                costomInputs.divHeatingHWC_UseFlowRateVisible = false;
                costomInputs.divHeatingHWC_FlowRateVisible = false;
            }


            if (intReheatCompID == ClsID.intCompHWC_ID)
            {
                costomInputs.divReheatHWC_UseCapVisible = true;
                costomInputs.divReheatHWC_CapVisible = true;
                costomInputs.divReheatHWC_UseFlowRateVisible = true;
                costomInputs.divReheatHWC_FlowRateVisible = true;
            }
            else
            {
                costomInputs.divReheatHWC_UseCapVisible = false;
                costomInputs.divReheatHWC_CapVisible = false;
                costomInputs.divReheatHWC_UseFlowRateVisible = false;
                costomInputs.divReheatHWC_FlowRateVisible = false;
            }


            return costomInputs;
        }

        public static dynamic getValveAndActuator()
        {
            dynamic valveAndActuator = new ExpandoObject();
            if (intCoolingCompID == ClsID.intCompCWC_ID || intPreheatCompID == ClsID.intCompHWC_ID || intHeatingCompID == ClsID.intCompHWC_ID || intReheatCompID == ClsID.intCompHWC_ID)
            {
                valveAndActuator.divValveAndActuatorVisible = true;
                valveAndActuator.ckbValveAndActuatorChecked = 1;
                valveAndActuator.divValveTypeVisible = true;
            }
            else
            {
                valveAndActuator.divValveAndActuatorVisible = false;
                valveAndActuator.ckbValveAndActuatorChecked = 0;
                valveAndActuator.divValveTypeVisible = false;
            }

            return valveAndActuator;
        }

        public static dynamic getHeatElectricHeater()
        {
            dynamic heatElectricHeaterInfo = new ExpandoObject();
            int intSelectedValue = 0;

            if (intHeatingCompID == ClsID.intCompElecHeaterID || intReheatCompID == ClsID.intCompElecHeaterID)
            {
                //divElecHeaterVoltage.Visible = true;
                heatElectricHeaterInfo.divHeatElecHeaterInstallationVisible = true;


                //if (!bolPreheatRequired)
                //{
                DataTable dtElecHeaterInstallation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricHeaterInstallation, intHeatElecHeaterInstallationID).Copy();
                dtElecHeaterInstallation = dtElecHeaterInstallation.Select("id <> 1").CopyToDataTable();
                intSelectedValue = intHeatElecHeaterInstallationID;

                heatElectricHeaterInfo.ddlHeatElecHeaterInstallation = dtElecHeaterInstallation;

                if (intSelectedValue == ClsID.intElecHeaterInstallDuctMountedID && intHeatingCompID != ClsID.intCompElecHeaterID && intReheatCompID != ClsID.intCompElecHeaterID)
                {
                    heatElectricHeaterInfo.ddlHeatElecHeaterInstallationValue = intSelectedValue > 1 ? intSelectedValue : ClsID.intElecHeaterInstallInCasingID;
                    intHeatElecHeaterInstallationID = heatElectricHeaterInfo.ddlHeatElecHeaterInstallationValue;
                }
                else
                {
                    heatElectricHeaterInfo.ddlHeatElecHeaterInstallationValue = intSelectedValue == 1 ? ClsID.intElecHeaterInstallInCasingID : intSelectedValue;
                    intHeatElecHeaterInstallationID = heatElectricHeaterInfo.ddlHeatElecHeaterInstallationValue;
                }
            }
            else
            {
                heatElectricHeaterInfo.divHeatElecHeaterInstallationVisible = false;

                DataTable dtElecHeaterInstallation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricHeaterInstallation, intHeatElecHeaterInstallationID).Copy();
                dtElecHeaterInstallation = dtElecHeaterInstallation.Select("id = 1").CopyToDataTable();

                heatElectricHeaterInfo.ddlHeatElecHeaterInstallation = dtElecHeaterInstallation;

                if (dtElecHeaterInstallation.Rows.Count > 0)
                {
                    heatElectricHeaterInfo.ddlHeatElecHeaterInstallationValue = "1";
                }
            }

            return heatElectricHeaterInfo;
        }

        public static dynamic getElectricHeaterVoltage()
        {
            DataTable dtElecHeaterVoltage = new DataTable();
            dynamic returnInfo = new ExpandoObject();

            if (intPreheatCompID == ClsID.intCompElecHeaterID || intHeatingCompID == ClsID.intCompElecHeaterID || intReheatCompID == ClsID.intCompElecHeaterID)
            {
                returnInfo.divElecHeaterVoltageVisible = true;

                bool bol208V_1Ph = false;


                if (intProductTypeID == ClsID.intProdTypeNovaID)
                {
                    if (intUnitModelID == ClsID.intNovaUnitModelID_A16IN || intUnitModelID == ClsID.intNovaUnitModelID_B20IN || intUnitModelID == ClsID.intNovaUnitModelID_A18OU || intUnitModelID == ClsID.intNovaUnitModelID_B22OU)
                    {
                        bol208V_1Ph = true;
                        dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater_2", 1, intElecHeaterVoltageID).Copy();
                    }
                    else
                    {
                        dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater", 1, intElecHeaterVoltageID).Copy();
                    }
                }
                else if (intProductTypeID == ClsID.intProdTypeVentumID)
                {
                    if (intUnitModelID == ClsID.intVentumUnitModelID_H05IN_ERV || intUnitModelID == ClsID.intVentumUnitModelID_H10IN_ERV ||
                        intUnitModelID == ClsID.intVentumUnitModelID_H05IN_HRV || intUnitModelID == ClsID.intVentumUnitModelID_H10IN_HRV)
                    {
                        bol208V_1Ph = true;
                        dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater_2", 1, intElecHeaterVoltageID).Copy();
                    }
                    else
                    {
                        dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater", 1, intElecHeaterVoltageID).Copy();
                    }
                }
                else if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
                {
                    bol208V_1Ph = true;
                    dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater_3", 1, intElecHeaterVoltageID).Copy();
                }
                else if (intProductTypeID == ClsID.intProdTypeTerraID)
                {
                    if (ckbVoltageSPPChecked == 1)
                    {
                        dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "terra_2", 1, intElecHeaterVoltageID).Copy();

                        returnInfo.ddlElecHeaterVoltageOldValue = intUnitVoltageID;
                        returnInfo.ddlElecHeaterVoltageEnabled = false;
                    }
                    else
                    {
                        dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "terra_1", 1, intElecHeaterVoltageID).Copy();
                        returnInfo.ddlElecHeaterVoltageEnabled = true;
                    }
                }



                if (dtElecHeaterVoltage.Rows.Count > 0)
                {
                    returnInfo.ddlElecHeaterVoltage = dtElecHeaterVoltage;

                    if (bol208V_1Ph)
                    {
                        returnInfo.ddlElecHeaterVoltageValue = ClsID.intElectricVoltage_208V_1Ph_60HzID;
                    }
                    else
                    {
                        returnInfo.ddlElecHeaterVoltageValue = ClsID.intElectricVoltage_208V_3Ph_60HzID;
                    }

                    returnInfo.ddlElecHeaterVoltageOldValue = intUnitVoltageID;
                }
            }
            else
            {
                if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
                {
                    dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater_3", 1, intElecHeaterVoltageID).Copy();
                    returnInfo.ddlElecHeaterVoltage = dtElecHeaterVoltage;
                    returnInfo.ddlElecHeaterVoltageValue = intUnitVoltageID;
                    returnInfo.ddlElecHeaterVoltageEnabled = false;
                }
                else
                {
                    dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater", 1, intElecHeaterVoltageID).Copy();
                    returnInfo.ddlElecHeaterVoltage = dtElecHeaterVoltage;
                    returnInfo.ddlElecHeaterVoltageValue = ClsID.intElectricVoltage_208V_3Ph_60HzID;
                }

                returnInfo.divElecHeaterVoltageVisible = false;
            }

            return returnInfo;
        }

        public static dynamic getRefrigerant()
        {
            dynamic refrigerantInfo = new ExpandoObject();
            if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_1 || intUAL == ClsID.intUAL_IntLvl_2)
            {
                refrigerantInfo.divDX_RefrigerantVisible = intCoolingCompID == ClsID.intCompDX_ID ? true : false;

                refrigerantInfo.divCondRefrigerantVisible = (ckbHeatPumpChecked == 1 || intReheatCompID == ClsID.intCompHGRH_ID) ? true : false;
            }
            return refrigerantInfo;
        }

        public static bool getHeatingFluidDesignConditions()
        {
            return (intPreheatCompID == ClsID.intCompHWC_ID || intHeatingCompID == ClsID.intCompHWC_ID || intReheatCompID == ClsID.intCompHWC_ID) ? true : false;
        }

        private static dynamic getSetPoints()
        {
            if ((intUnitTypeID == ClsID.intUnitTypeAHU_ID && intPreheatCompID > 1) || intCoolingCompID > 1 || intHeatingCompID > 1 || intReheatCompID > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static dynamic getDrainPan()
        {
            dynamic drainPanInfo = new ExpandoObject();
            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                drainPanInfo.divDrainPanVisible = false;
                drainPanInfo.ckbDrainPanChecked = 0;
            }
            else if (intProductTypeID == ClsID.intProdTypeVentumID || intProductTypeID == ClsID.intProdTypeVentumLiteID) //Ventum
            {
                if (intUnitTypeID == ClsID.intUnitTypeERV_ID)
                {
                    drainPanInfo.divDrainPanVisible = false;
                    drainPanInfo.ckbDrainPanChecked = 0;
                }
                else if (intUnitTypeID == ClsID.intUnitTypeHRV_ID)
                {
                    drainPanInfo.divDrainPanVisible = true;
                    drainPanInfo.ckbDrainPanChecked = 1;
                }
            }

            return drainPanInfo;
        }

        public static dynamic getReheatSetpoints()
        {
            dynamic reheatSetpointsInfo = new ExpandoObject();
            reheatSetpointsInfo.divReheatSetpointVisible = intReheatCompID > 1 ? true : false;
            reheatSetpointsInfo.divCondRefrigerantVisible = intReheatCompID == ClsID.intCompHGRH_ID ? true : false;
            return reheatSetpointsInfo;
        }

        public static bool getHeatingSetpoint()
        {
            if (intHeatingCompID == ClsID.intCompElecHeaterID || intHeatingCompID == ClsID.intCompHWC_ID || ckbHeatPumpChecked == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static dynamic getCoolingSetpoint()
        {
            dynamic coolingSetPointInfo = new ExpandoObject();
            if (intCoolingCompID == ClsID.intCompCWC_ID || intCoolingCompID == ClsID.intCompDX_ID)
            {
                coolingSetPointInfo.DBVisible = true;
                coolingSetPointInfo.WBVisible = true;
            }
            else
            {
                coolingSetPointInfo.DBVisible = false;
                coolingSetPointInfo.WBVisible = false;
            }

            return coolingSetPointInfo;
        }

        public static bool getPreheatSetpoint()
        {
            if (intUnitTypeID == ClsID.intUnitTypeAHU_ID && intPreheatCompID == ClsID.intCompElecHeaterID || intPreheatCompID == ClsID.intCompHWC_ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool getSetpoints()
        {
            if (intUnitTypeID == ClsID.intUnitTypeAHU_ID && intPreheatCompID > 1 || intCoolingCompID > 1 || intHeatingCompID > 1 || intReheatCompID > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static dynamic getReheat()
        {
            dynamic reheatInfo = new ExpandoObject();
            DataTable dtReheatComp = new DataTable();

            if (ckbDehumidificationChecked == 1)
            {
                dtReheatComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating);

                switch (intCoolingCompID)
                {
                    case ClsID.intCompCWC_ID:
                        //dtReheatComp = clsDB.get_dt(clsDBT.strSelUnitCoolingHeating, " WHERE id != " + clsID.intUnitHeatingCoolingHGRH_ID + " AND enabled = 1");
                        dtReheatComp = dtReheatComp.Select("[id] <> '" + ClsID.intCompHGRH_ID.ToString() + "'").CopyToDataTable();
                        break;
                    case ClsID.intCompDX_ID:
                        if (intUAL == ClsID.intUAL_External || intUAL == ClsID.intUAL_ExternalSpecial)
                        {
                            dtReheatComp = dtReheatComp.Select("[id] <> '" + ClsID.intCompHGRH_ID.ToString() + "'").CopyToDataTable();
                        }
                        break;
                    default:
                        //dtReheatComp = clsDB.get_dt(clsDBT.strSelUnitCoolingHeating, " WHERE enabled = 1");
                        break;
                }


                switch (intUnitTypeID)
                {
                    case ClsID.intUnitTypeERV_ID:
                        dtReheatComp = ClsTS.get_dtDataFromImportRows(dtReheatComp, "erv_reheat", 1);
                        break;
                    case ClsID.intUnitTypeHRV_ID:
                        dtReheatComp = ClsTS.get_dtDataFromImportRows(dtReheatComp, "hrv_reheat", 1);
                        break;
                    case ClsID.intUnitTypeAHU_ID:
                        dtReheatComp = ClsTS.get_dtDataFromImportRows(dtReheatComp, "fc_reheat", 1);
                        break;
                    default:
                        // code block
                        break;
                }


                reheatInfo.ddlReheatComp = dtReheatComp;
                reheatInfo.divReheatCompVisible = true;
            }
            else
            {
                dtReheatComp = ClsDB.get_dt(ClsDBT.strSelUnitCoolingHeating, " WHERE enabled = 1");
                reheatInfo.ddlReheatComp = dtReheatComp;
                reheatInfo.ddlReheatCompValue = ClsID.intCompNA_ID.ToString();
                reheatInfo.divReheatCompVisible = false;
            }

            return reheatInfo;
        }

        public static dynamic getDehumidification()
        {
            dynamic dehumidificationInf = new ExpandoObject();
            if (intCoolingCompID == ClsID.intCompCWC_ID || intCoolingCompID == ClsID.intCompDX_ID)
            {
                dehumidificationInf.divDehumidificationVisible = 1;
            }
            else
            {
                dehumidificationInf.divDehumidificationVisible = false;
                dehumidificationInf.ckbDehumidification = 0;
                dehumidificationInf.ckbDehumidificationChecked = 0;
            }

            return dehumidificationInf;
        }

        public static dynamic getCooling()
        {
            dynamic coolingInfo = new ExpandoObject();
            if (intCoolingCompID == ClsID.intCompCWC_ID)
            {
                coolingInfo.divCoolingFluidDesignConditionsVisible = true;
                coolingInfo.ckbHeatPumpChecked = 0;
                coolingInfo.divHeatPumpVisible = false;
            }
            else if (intCoolingCompID == ClsID.intCompDX_ID)
            {
                coolingInfo.divCoolingFluidDesignConditionsVisible = false;
                coolingInfo.divHeatPumpVisible = true;
            }
            else
            {
                coolingInfo.divCoolingFluidDesignConditionsVisible = false;
                coolingInfo.ckbHeatPumpChecked = 0;
                coolingInfo.divHeatPumpVisible = false;
            }

            return coolingInfo;
        }


        public static dynamic ddlLocationChanged(dynamic unitInfo)
        {
            dynamic returnInfo = new ExpandoObject();
            setAllData(unitInfo);

            if (unitInfo.ddlLocation == ClsID.intLocationOutdoorID)
            {
                returnInfo.ddlDamperAndActuatorValue = ClsID.intDamperActuatorNoCasingID;
                returnInfo.divDamperAndActuatorVisible = false;
            }
            else
            {
                returnInfo.divDamperAndActuatorVisible = true;
            }

            returnInfo.downshot = getDownshot();
            returnInfo.ddlOrientation = getOrientation(unitInfo.txbSummerSupplyAirCFM.ToString());
            returnInfo.ddlOrientationValue = returnInfo.ddlOrientation.Rows[0]["id"];
            dynamic modelAndBypassInfo = getModel(unitInfo.txbSummerSupplyAirCFM.ToString(), Convert.ToInt32(unitInfo.ckbBypass));

            returnInfo.ddlUnitModel = modelAndBypassInfo.ddlUnitModel;
            returnInfo.ddlUnitModelValue = returnInfo.ddlUnitModel.Rows[0]["id"];
            intUnitModelID = returnInfo.ddlUnitModelValue;
            returnInfo.ckbBypass = modelAndBypassInfo.ckbBypass;
            returnInfo.others = modelAndBypassInfo.others;
            ckbBypassChecked = modelAndBypassInfo.ckbBypass;

            returnInfo.txbSupplyAirESP = txbSupplyAirESP_Changed(unitInfo.txbSupplyAirESP.ToString());
            returnInfo.txbExhaustAirESP = txbExhaustAirESP_Changed(unitInfo.txbExhaustAirESP.ToString());
            returnInfo.electricHeaterVoltage = getElectricHeaterVoltage();
            returnInfo.preheatElectricHeater = getPreheatElectricHeater();
            //returnInfo.supplyAirOpening = getSupplyAirOpening();

            return returnInfo;
        }


        public static dynamic ddlOrientationChanged(dynamic info)
        {
            dynamic returnInfo = new ExpandoObject();

            setAllData(info);
            
            dynamic modelAndBypassInfo = getModel(info.txbSummerSupplyAirCFM.ToString(), Convert.ToInt32(info.ckbBypass));

            returnInfo.ddlUnitModel = modelAndBypassInfo.ddlUnitModel;
            returnInfo.ddlUnitModelValue = returnInfo.ddlUnitModel.Rows[0]["id"];
            intUnitModelID = returnInfo.ddlUnitModelValue;

            returnInfo.ckbBypass = modelAndBypassInfo.ckbBypass;
            returnInfo.others = modelAndBypassInfo.others;

            returnInfo.ckbBypass = modelAndBypassInfo.ckbBypass;
            ckbBypassChecked = modelAndBypassInfo.ckbBypass;

            dynamic ddlSupplyAirOpeningInfo = getSupplyAirOpening();
            returnInfo.ddlSupplyAirOpening = ddlSupplyAirOpeningInfo.data;
            returnInfo.ddlSupplyAirOpeningValue = ddlSupplyAirOpeningInfo.value;
            returnInfo.ddlSupplyAirOpeningText = ddlSupplyAirOpeningInfo.text;
            intSupplyAirOpeningID = ddlSupplyAirOpeningInfo.value;


            return returnInfo;
        }

        public static float txbSummerOutdoorAirWB_TextChanged(string txbSummerOutdoorAirDBText, string txbSummerOutdoorAirWBText, string txbAltitudeText)
        {
            float fltDB = (float)Convert.ToDouble(txbSummerOutdoorAirDBText);
            float fltWB = (float)Convert.ToDouble(txbSummerOutdoorAirWBText);
            float fltRH = (float)Math.Round(ClsPsyCalc.get_fltRH_ByDB_WB(fltDB, fltWB, Convert.ToInt32(txbAltitudeText)), 1);

            float  txbSummerOutdoorAirRHText = 0f;
            if (fltRH < -100)
            {
                txbSummerOutdoorAirRHText = (float)dblTempErrorValue;

                if (fltDB == fltWB)
                {
                    //bolErrorSummerRH = false;
                    txbSummerOutdoorAirRHText = 100;
                }
            }
            else
            {
                //bolErrorSummerRH = false;
                txbSummerOutdoorAirRHText = fltRH;
            }

            return txbSummerOutdoorAirRHText;
        }

        public static float txbSummerOutdoorAirRH_TextChanged(dynamic info)
        {
            float fltDB = (float)Convert.ToDouble(info.txbSummerOutdoorAirDB);
            float fltRH = (float)Convert.ToDouble(info.txbSummerOutdoorAirRH);
            float fltGrain = (float)Math.Round(ClsPsyCalc.get_fltGrains_ByDB_RH(fltDB, fltRH, Convert.ToInt32(info.txbAltitude)), 1);
            float fltWB = (float)Math.Round(ClsPsyCalc.get_fltWB_ByDB_RH(fltDB, fltRH, Convert.ToInt32(info.txbAltitude)), 1);

            float txbSummerOutdoorAirWB = 0f;
            if (fltWB < -100)
            {
                //bolErrorSummerWB = true;
                txbSummerOutdoorAirWB = (float)dblTempErrorValue;
            }
            else
            {
                //bolErrorSummerWB = false;
                txbSummerOutdoorAirWB = fltWB;
            }

            return txbSummerOutdoorAirWB;
        }

        public static float txbWinterOutdoorAirWB_TextChanged(dynamic info)
        {
            float fltDB = (float)Convert.ToDouble(info.txbWinterOutdoorAirDB);
            float fltWB = (float)Convert.ToDouble(info.txbWinterOutdoorAirWB);
            float fltRH = (float)Math.Round(ClsPsyCalc.get_fltRH_ByDB_WB(fltDB, fltWB, Convert.ToInt32(info.txbAltitude)), 1);

            float txbWinterOutdoorAirRH = 0f;
            if (fltRH < -100)
            {
                txbWinterOutdoorAirRH = (float)dblTempErrorValue;

                if (fltDB == fltWB)
                {
                    txbWinterOutdoorAirRH = 100;
                }
            }
            else
            {
                txbWinterOutdoorAirRH = fltRH;
            }

            return txbWinterOutdoorAirRH;
        }

        public static float txbWinterOutdoorAirRH_TextChanged(dynamic info)
        {
            float fltDB = (float)Convert.ToDouble(info.txbWinterOutdoorAirDB);
            float fltRH = (float)Convert.ToDouble(info.txbWinterOutdoorAirRH);
            float fltGrain = (float)Math.Round(ClsPsyCalc.get_fltGrains_ByDB_RH(fltDB, fltRH, Convert.ToInt32(info.txbAltitude)), 1);
            float fltWB = (float)Math.Round(ClsPsyCalc.get_fltWB_ByDB_RH(fltDB, fltRH, Convert.ToInt32(info.txbAltitude)), 1);

            float txbWinterOutdoorAirWB = 0f;
            if (fltWB < -100)
            {
                txbWinterOutdoorAirWB = (float)dblTempErrorValue;
            }
            else
            {
                //bolErrorWinterWB = false;
                txbWinterOutdoorAirWB = fltWB;
            }

            return txbWinterOutdoorAirWB;
        }

        public static float txbSummerReturnAirWB_TextChanged(dynamic info)
        {
            float fltDB = (float)Convert.ToDouble(info.txbSummerReturnAirDB);
            float fltWB = (float)Convert.ToDouble(info.txbSummerReturnAirWB);
            float fltRH = (float)Math.Round(ClsPsyCalc.get_fltRH_ByDB_WB(fltDB, fltWB, Convert.ToInt32(info.txbAltitude)), 1);

            float txbSummerReturnAirRH = 0f;
            if (fltRH < -100)
            {
                txbSummerReturnAirRH = (float)dblTempErrorValue;

                if (fltDB == fltWB)
                {
                    txbSummerReturnAirRH = 100;
                }
            }
            else
            {
                txbSummerReturnAirRH = fltRH;
            }

            return txbSummerReturnAirRH;
        }

        public static float txbSummerReturnAirRH_TextChanged(dynamic info)
        {

            float fltDB = (float)Convert.ToDouble(info.txbSummerReturnAirDB);
            float fltRH = (float)Convert.ToDouble(info.txbSummerReturnAirRH);
            float fltGrain = (float)Math.Round(ClsPsyCalc.get_fltGrains_ByDB_RH(fltDB, fltRH, Convert.ToInt32(info.txbAltitude)), 1);
            float fltWB = (float)Math.Round(ClsPsyCalc.get_fltWB_ByDB_RH(fltDB, fltRH, Convert.ToInt32(info.txbAltitude)), 1);

            float txbSummerReturnAirWB = 0f;
            if (fltWB < -100)
            {
                //bolErrorSummerWB = true;
                txbSummerReturnAirWB = (float)dblTempErrorValue;
            }
            else
            {
                //bolErrorSummerWB = false;
                txbSummerReturnAirWB = fltWB;
            }

            return txbSummerReturnAirWB;
        }

        public static float txbWinterReturnAirWB_TextChanged(dynamic info)
        {
            float fltDB = (float)Convert.ToDouble(info.txbWinterReturnAirDB);
            float fltWB = (float)Convert.ToDouble(info.txbWinterReturnAirWB);
            float fltRH = (float)Math.Round(ClsPsyCalc.get_fltRH_ByDB_WB(fltDB, fltWB, Convert.ToInt32(info.txbAltitude)), 1);

            float txbWinterReturnAirRH = 0f;
            if (fltRH < -100)
            {
                //bolErrorWinterRH = true;
                txbWinterReturnAirRH = (float)dblTempErrorValue;

                if (fltDB == fltWB)
                {
                    //bolErrorWinterRH = false;
                    txbWinterReturnAirRH = 100;
                }
            }
            else
            {
                //bolErrorWinterRH = false;
                txbWinterReturnAirRH = (float)fltRH;
            }


            return txbWinterReturnAirRH;
        }

        #region Winter Return Air RH
        public static float txbWinterReturnAirRH_TextChanged(dynamic info)
        {
            float fltDB = (float)Convert.ToDouble(info.txbWinterReturnAirDB);
            float fltRH = (float)Convert.ToDouble(info.txbWinterReturnAirRH);
            float fltGrain = (float)Math.Round(ClsPsyCalc.get_fltGrains_ByDB_RH(fltDB, fltRH, Convert.ToInt32(info.txbAltitude)), 1);
            float fltWB = (float)Math.Round(ClsPsyCalc.get_fltWB_ByDB_RH(fltDB, fltRH, Convert.ToInt32(info.txbAltitude)), 1);

            float txbWinterReturnAirWB = 0f;
            if (fltWB < -100)
            {
                //bolErrorWinterWB = true;
                txbWinterReturnAirWB = (float)dblTempErrorValue;
            }
            else
            {
                //bolErrorWinterWB = false;
                txbWinterReturnAirWB = fltWB;
            }

            return txbWinterReturnAirWB;
        }
        #endregion

        #region ViewSelection
        public static dynamic ViewSelection(dynamic info)
        {
            intUserID = Convert.ToInt32(info.intUserID);
            intUAL = Convert.ToInt32(info.intUAL);
            intJobID = Convert.ToInt32(info.intJobID);
            intProductTypeID = Convert.ToInt32(info.intProductTypeID);
            intUnitTypeID = Convert.ToInt32(info.intUnitTypeID);
            intUnitNo = Convert.ToInt32(info.intUnitNo);

            dynamic returnInfo = new ExpandoObject();
            returnInfo.MultiView1ActiveViewIndex = 3;

            ClsPerformanceERU objPerf = new ClsPerformanceERU(intUserID, intJobID, intUnitNo);
            objPerf.CalculatePerformance();

            ClsContElements objCont = objPerf.get_objContainers();

            if (objCont.objCPreheatElecHeater != null)
            {
                returnInfo.ddlPreheatComp = ClsID.intCompElecHeaterID.ToString();
                returnInfo.divElecHeaterVoltageVisible = true;
                returnInfo.divPreheatElecHeaterInstallationVisible = true;

                if (info.ddlPreheatElecHeaterInstallation == ClsID.intElecHeaterInstallNA_ID)
                {
                    DataTable dtElecHeaterInstallation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricHeaterInstallation, intPreheatElecHeaterInstallationID).Copy();
                    dtElecHeaterInstallation = dtElecHeaterInstallation.Select("id <> 1").CopyToDataTable();
                    returnInfo.ddlPreheatElecHeaterInstallation = dtElecHeaterInstallation;
                    returnInfo.ddlPreheatElecHeaterInstallationValue = ClsID.intElecHeaterInstallInCasingID.ToString();
                }
            }



            ClsOutput objOut = new ClsOutput(objCont);

            returnInfo.divOutUnitDetailsVisible = false;
            returnInfo.divOutElecReqUnitDataVisible = false;
            returnInfo.divOutElecReqPreheatElecHeaterVisible = false;
            returnInfo.divOutElecReqCoolingDXCVisible = false;
            returnInfo.divOutElecReqHeatingElecHeaterVisible = false;
            returnInfo.divOutElecReqReheatElecHeaterVisible = false;
            returnInfo.divOutPreheatElecHeaterVisible = false;

            returnInfo.divOutPreheatHWCVisible = false;
            returnInfo.divOutPreheatHWC_ValveActuatorDataVisible = false;

            returnInfo.divOutHX_FPVisible = false;
            returnInfo.lblHX_FP_CondWarningVisible = false;

            returnInfo.divOutCoolingCWCVisible = false;
            returnInfo.divOutCoolingCWC_ValveActuatorDataVisible = false;

            returnInfo.divOutCoolingDXC_SelectionVisible = false;
            returnInfo.divOutCoolingDXCVisible = false;
            returnInfo.divOutCoolingDXC_PerfOutputsVisible = false;
            returnInfo.divOutCoolingDXC_EKEXV_KitDataVisible = false;
            returnInfo.divOutCoolingDXC_CapacityNotMetWarningVisible = false;
            returnInfo.divOutCoolingDXC_SetpointNotMetWarningVisible = false;
            returnInfo.divOutCoolingDXC_3TonNotMetWarningVisible = false;

            returnInfo.divOutCoolingDXC_RAE_SelectionVisible = false;
            returnInfo.divOutCoolingDXC_RAEVisible = false;
            returnInfo.divOutCoolingDXC_RAE_PerfOutputsVisible = false;
            returnInfo.divOutCoolingDXC_RAE_EKEXV_KitDataVisible = false;
            returnInfo.divOutCoolingDXC_RAE_CapacityNotMetWarningVisible = false;
            returnInfo.divOutCoolingDXC_RAE_SetpointNotMetWarningVisible = false;
            returnInfo.divOutCoolingDXC_RAE_3TonNotMetWarningVisible = false;

            returnInfo.divOutHeatingElecHeaterVisible = false;
            returnInfo.divOutHeatingHWCVisible = false;
            returnInfo.divOutHeatingHWC_ValveActuatorDataVisible = false;

            returnInfo.divOutHeatingCondCoilVisible = false;
            returnInfo.divOutHeatingCondCoilPerfOutputsVisible = false;

            returnInfo.divOutReheatElecHeaterVisible = false;
            returnInfo.divOutReheatHWCVisible = false;
            returnInfo.divOutReheatHWC_ValveActuatorDataVisible = false;
            returnInfo.divOutReheatHGRCVisible = false;

            returnInfo.divOutSF_ZAVisible = false;
            returnInfo.divOutSF_SoundDataVisible = false;

            returnInfo.divOutEF_ZAVisible = false;
            returnInfo.divOutEF_SoundDataVisible = false;

            returnInfo.divOutSoundDataVisible = false;
            returnInfo.divPricingVisible = false;

            returnInfo.secPreheatElecHeaterNominalDataVisible = false;
            returnInfo.secHeatingElecHeaterNominalDataVisible = false;
            returnInfo.secReheatElecHeaterNominalDataVisible = false;


            if (objCont != null)
            {
                if (objCont.objCGeneral != null)
                {
                    returnInfo.outputUnitDetails = getOutputUnitDetails(objOut.objOutputTables);
                    //setOutputUnitElecData(objOut.objOutputTables);
                }


                returnInfo.outputElecReq = setOutputElecReq(objCont.objCGeneral, objOut.objOutputTables);


                if (objCont.objCPreheatElecHeater != null)
                {
                    returnInfo.outputPreheatElecHeater = getOutputPreheatElecHeater(objCont.objCGeneral, objOut.objOutputTables);
                }



                if (objCont.objCHX_CORE != null)
                {
                    returnInfo.outputFixedPlateCORE = getOutputFixedPlateCORE(objOut.objOutputTables);
                }




                if (objCont.objCHeatingElecHeater != null)
                {
                    returnInfo.outputHeatingElecHeater = getOutputHeatingElecHeater(objOut.objOutputTables);
                }

                if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1)
                {
                    returnInfo.outputPricing = getOutputPricing(objPerf.objPricing);
                }

            }

            return returnInfo;
        }
        #endregion
        #region Out Unit Details
        public static dynamic getOutputUnitDetails(ClsOutputData _objOut)
        {
            dynamic returnInfo = new ExpandoObject();
            if (_objOut.dtUnitDetails_1 != null)
            {
                returnInfo.divOutUnitDetailsVisible = true;
                returnInfo.gvOutUnitDetails_1Visible = true;
                returnInfo.gvOutUnitDetails_1DataSource = _objOut.dtUnitDetails_1;

                returnInfo.gvOutUnitDetails_2Visible = true;
                returnInfo.gvOutUnitDetails_2DataSource = _objOut.dtUnitDetails_2;
            }

            return returnInfo;
        }
        #endregion

        #region Out Electrical Requirements
        public static dynamic setOutputElecReq(ClsGeneral _objGen, ClsOutputData _objOut)
        {
            dynamic returnInfo = new ExpandoObject();
            returnInfo.lblElecReqQtyText = _objOut.strElecReqQty;


            returnInfo.lblOutElecReqUnitDataText = _objOut.strOutElecReqUnitData;

            if (_objOut.dtElecReqUnitElecData.Rows.Count > 0)
            {
                returnInfo.divOutElecReqUnitDataVisible = true;
                returnInfo.gvOutElecReqUnitDataVisible = true;
                returnInfo.gvOutElecReqUnitDataDataSource = _objOut.dtElecReqUnitElecData;
            }


            if (_objGen.intProductTypeID == ClsID.intProdTypeNovaID ||
                _objGen.intProductTypeID == ClsID.intProdTypeVentumID ||
                (_objGen.intProductTypeID == ClsID.intProdTypeTerraID && _objGen.intIsVoltageSPP == 0))
            {
                if (_objOut.dtElecReqPreheatElecHeater.Rows.Count > 0)
                {
                    returnInfo.divOutElecReqPreheatElecHeaterVisible = true;
                    returnInfo.gvOutElecReqPreheatElecHeaterVisible = true;
                    returnInfo.gvOutElecReqPreheatElecHeaterDataSource = _objOut.dtElecReqPreheatElecHeater;
                }


                if (_objOut.dtElecReqHeatingElecHeater.Rows.Count > 0)
                {
                    returnInfo.divOutElecReqHeatingElecHeaterVisible = true;
                    returnInfo.gvOutElecReqHeatingElecHeaterVisible = true;
                    returnInfo.gvOutElecReqHeatingElecHeaterDataSource = _objOut.dtElecReqHeatingElecHeater;
                }
            }

            return returnInfo;
        }
        #endregion


        #region Out Preheat Electric Heater
        public static dynamic getOutputPreheatElecHeater(ClsGeneral _objGen, ClsOutputData _objOut)
        {
            dynamic returnInfo = new ExpandoObject();
            if (_objOut.dtPreheatElecHeaterData != null)
            {
                returnInfo.divOutPreheatElecHeaterVisible = true;
                returnInfo.gvOutPreheatElecHeaterDataVisible = true;
                returnInfo.gvOutPreheatElecHeaterDataSource = _objOut.dtPreheatElecHeaterData;
            }



            if (_objGen.intProductTypeID == ClsID.intProdTypeVentumLiteID)
            {
                returnInfo.divPreheatSeparateElecConnMsgVisible = false;

            }

            //if (_objOut.dtPreheatElecHeaterNominalData != null)
            //{
            //    gvOutPreheatElecHeaterNominalData.Visible = true;
            //    gvOutPreheatElecHeaterNominalData.DataSource = _objOut.dtPreheatElecHeaterNominalData;
            //    gvOutPreheatElecHeaterNominalData.DataBind();
            //}

            return returnInfo;
        }
        #endregion

        #region Out Fixed Plate CORE
        public static dynamic getOutputFixedPlateCORE(ClsOutputData _objOut)
        {
            dynamic returnInfo = new ExpandoObject();

            if (_objOut.dtHX_FP_CORE_Perf != null)
            {
                returnInfo.divOutHX_FPVisible = true;
                returnInfo.gvOutHX_FP_PerfVisible = true;
                returnInfo.gvOutHX_FP_PerfDataSource = _objOut.dtHX_FP_CORE_Perf;
            }

            if (_objOut.dtHX_FP_CORE_EntAir != null)
            {
                returnInfo.gvOutHX_FP_EntAirVisible = true;
                returnInfo.gvOutHX_FP_EntAirDataSource = _objOut.dtHX_FP_CORE_EntAir;
            }


            if (_objOut.dtHX_FP_CORE_LvgAir != null)
            {
                returnInfo.gvOutHX_FP_LvgAirVisible = true;
                returnInfo.gvOutHX_FP_LvgAirDataSource = _objOut.dtHX_FP_CORE_LvgAir;
            }


            if (Convert.ToInt32(_objOut.dtHX_FP_CORE_AHRIWarning.Rows[0]["ShowLogo"]) == 1)
            {
                returnInfo.divHX_FP_AHRIWarningVisible = false;
                returnInfo.divHX_FP_AHRIWarningWithLogoVisible = true;
                returnInfo.imgAHRI_LogoImageUrl = "Images/img_ahri.png";
                returnInfo.lblHX_FP_AHRIWarningWithLogoText = _objOut.dtHX_FP_CORE_AHRIWarning.Rows[0]["cValue"].ToString().Replace(Environment.NewLine, "<br />");
            }
            else
            {
                returnInfo.divHX_FP_AHRIWarningWithLogoVisible = false;
                returnInfo.divHX_FP_AHRIWarningVisible = true;
                returnInfo.imgAHRI_LogoImageUrl = null;
                returnInfo.lblHX_FP_AHRIWarningText = _objOut.dtHX_FP_CORE_AHRIWarning.Rows[0]["cValue"].ToString().Replace(Environment.NewLine, "<br />");
            }


            if (_objOut.dtHX_FP_CORE_CondWarning != null)
            {
                if (_objOut.dtHX_FP_CORE_CondWarning.Rows.Count > 0)
                {
                    returnInfo.lblHX_FP_CondWarningVisible = true;
                    returnInfo.lblHX_FP_CondWarningText = _objOut.dtHX_FP_CORE_CondWarning.Rows[0]["cValue"].ToString();
                }
            }


            return returnInfo;
        }
        #endregion


        #region Out Heating Electric Heater
        public static dynamic getOutputHeatingElecHeater(ClsOutputData _objOut)
        {
            dynamic returnInfo = new ExpandoObject();
            if (_objOut.dtHeatingElecHeaterData != null)
            {
                returnInfo.divOutHeatingElecHeaterVisible = true;
                returnInfo.gvOutHeatingElecHeaterDataVisible = true;
                returnInfo.gvOutHeatingElecHeaterDataDataSource = _objOut.dtHeatingElecHeaterData;
            }
            return returnInfo;
        }
        #endregion

        #region Out Pricing
        public static dynamic getOutputPricing(ClsPricing _objPrice)
        {
            dynamic returnInfo = new ExpandoObject();
            if (_objPrice.dtPriceDetail != null)
            {
                returnInfo.divPricingVisible = true;
                returnInfo.gvPricingVisible = true;
                returnInfo.gvPricingDataSource = _objPrice.dtPriceDetail;
            }

            return returnInfo;
        }
        #endregion
    }
}