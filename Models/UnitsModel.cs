using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Dynamic;

namespace Oxyzen8SelectorServer.Models
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

        public static bool SaveUnitInfo(dynamic unitInfo)
        {
            int intFaceAreaHeight = 0;
            int intFaceAreaWidth = 0;
            string strSelectionType = "";
            int intSelectionTypeID = 0;
            int intVelocity = 0;

            int intProductTypeID = unitInfo.intProductTypeID;
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
                                            Convert.ToInt32(unitInfo.intUnitID),
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

            unitInfo.intUnitID = dt.Rows[0]["UnitNo"].ToString();

            ClsDB.SaveAirFlow(Convert.ToInt32(unitInfo.intJobID),
                                Convert.ToInt32(unitInfo.intUnitID),
                                Convert.ToInt32(unitInfo.txbAltitude),
                                Convert.ToInt32(unitInfo.txbSummerSupplyAirCFM),
                                Convert.ToInt32(unitInfo.txbSummerReturnAirCFM),
                                Convert.ToInt32(unitInfo.txbWinterSupplyAirCFM),
                                Convert.ToInt32(unitInfo.txbWinterReturnAirCFM),
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
                intUnitNo = Convert.ToInt32(unitInfo.intUnitID),
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

            return true;
        }

        public static bool SaveLayout(dynamic unitInfo)
        {
            try
            {
                ClsLayoutOpt objLayoutOpt = new ClsLayoutOpt
                {
                    intJobID = Convert.ToInt32(unitInfo.intJobID),
                    intUnitNo = Convert.ToInt32(unitInfo.intUnitID),
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
            intUserID = Convert.ToInt32(info.userId);
            intUAL = Convert.ToInt32(info.UAL);
            intJobID = Convert.ToInt32(info.jobId);
            intProductTypeID = Convert.ToInt32(info.productTypeId);
            intUnitTypeID = Convert.ToInt32(info.unitTypeId);
            intUnitNo = Convert.ToInt32(info.unitNo);

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
            returnInfo.orientation = getOrientation(unitInfo.txbSummerSupplyAirCFM.ToString());
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

        private static void setAllData(dynamic unitInfo)
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
            intPreheatCompID = Convert.ToInt32(unitInfo.ddlControlsPreference);
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

            dynamic preheatRequiredParameter = new ExpandoObject();
            preheatRequiredParameter.ddlUnitTypeID = intUnitTypeID;
            preheatRequiredParameter.ddlCoolingCompID = intCoolingCompID;
            preheatRequiredParameter.ddlReheatCompID = intReheatCompID;
            preheatRequiredParameter.ddlPreheatCompID = intPreheatCompID;
            preheatRequiredParameter.ddlHeatingCompID = intHeatingCompID;
            preheatRequiredParameter.ddlUnitModelID = intUnitModelID;
            preheatRequiredParameter.ddlUnitVoltageID = intUnitVoltageID;
            preheatRequiredParameter.ckbHeatPump = 0;
            preheatRequiredParameter.ckbVoltageSPP = 0;

            controlInfo.preheatInfomation = setPreheatRequired(preheatRequiredParameter);


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

        public static dynamic setPreheatRequired(dynamic info)
        {
            int ddlUnitTypeID = Convert.ToInt32(info.ddlUnitTypeID);
            int ddlCoolingCompID = Convert.ToInt32(info.ddlCoolingCompID);
            int ckbHeatPump = Convert.ToInt32(info.ckbHeatPump);
            int ddlReheatCompID = Convert.ToInt32(info.ddlReheatCompID);

            dynamic returnInfo = new ExpandoObject();
            returnInfo.lblPreheatWarningVisible = false;
            returnInfo.lblPreheatWarningText = "";
            bool bolPreheatRequired = false;
            string strPreheatRequiredWarning = "";
            double dblPreheatSetPoint = 0d;

            DataTable dtJob = ClsDB.get_dtByID(ClsDBT.strSavJob, intJobID);

            if (dtJob.Rows.Count > 0)
            {
                if (ddlUnitTypeID == ClsID.intUnitTypeERV_ID || ddlUnitTypeID == ClsID.intUnitTypeHRV_ID)
                {
                    //if (ddlPreheatComp != null)
                    //{
                    if (Convert.ToDouble(dtJob.Rows[0]["winter_outdoor_air_db"]) < 15d && Convert.ToDouble(dtJob.Rows[0]["winter_return_air_rh"]) > 40d)
                    {
                        bolPreheatRequired = true;
                        returnInfo.lblPreheatWarningText= "Preheat required. Winter OA DB is below 15 degF and RA RH is above 40%";
                    }

                }
                else if (ddlUnitTypeID == ClsID.intUnitTypeAHU_ID)
                {
                    if (ddlCoolingCompID == ClsID.intCompDX_ID && ckbHeatPump == 1 && ddlReheatCompID == ClsID.intCompHGRH_ID && Convert.ToDouble(dtJob.Rows[0]["winter_outdoor_air_db"]) < ClsGV.dblTERRA_PREHEAT_DX_HEATPUMP_HGRH_33DEG)
                    {
                        bolPreheatRequired = true;
                        strPreheatRequiredWarning = "Preheat required. Winter OA DB is below " + ClsGV.dblTERRA_PREHEAT_DX_HEATPUMP_HGRH_33DEG.ToString() + " degF";
                        dblPreheatSetPoint = ClsGV.dblTERRA_PREHEAT_DX_HEATPUMP_HGRH_33DEG;
                    }
                    else if (ddlCoolingCompID == ClsID.intCompDX_ID && ckbHeatPump == 1 && Convert.ToDouble(dtJob.Rows[0]["winter_outdoor_air_db"]) < ClsGV.dblTERRA_PREHEAT_DX_HEATPUMP_17DEG)
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

                    returnInfo.preheatElectricHeater = getPreheatElectricHeater(info);
                }
                else
                {
                    returnInfo.lblPreheatWarningVisible = false;
                }
            }
            return returnInfo;
        }

        public static dynamic getPreheatElectricHeater(dynamic info)
        {
            int ddlPreheatCompID = Convert.ToInt32(info.ddlPreheatCompID);
            int ddlLocationID = Convert.ToInt32(info.ddlPreheatCompID);
            int intSelectedValue = 0;
            dynamic returnInfo = new ExpandoObject();

            if (ddlPreheatCompID == ClsID.intCompElecHeaterID || ddlPreheatCompID == ClsID.intCompAutoID)
            {
                DataTable dtPreheatElecHeaterInstallation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricHeaterInstallation, intPreheatElecHeaterInstallationID).Copy();
                dtPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation.Select("id <> 1").CopyToDataTable();
                returnInfo.ddlPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation;

                if (ddlLocationID == ClsID.intLocationOutdoorID)
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
            }

            switch (ddlPreheatCompID)
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

        private static dynamic GetElecHeaterVoltage(dynamic fieldInfo)
        {
            dynamic elecHeaderVoltageInfo = new ExpandoObject();
            DataTable dtElecHeaterVoltage = new DataTable();
            int intProductTypeID = Convert.ToInt32(fieldInfo.productTypeId);
            int intUnitModelId = Convert.ToInt32(fieldInfo.productTypeId);
            int preheatComp = Convert.ToInt32(fieldInfo.preheatComp);
            int heatingComp = Convert.ToInt32(fieldInfo.heatingComp);
            int reheatComp = Convert.ToInt32(fieldInfo.reheatComp);
            int intElecHeaterVoltageID = Convert.ToInt32(fieldInfo.elecHeaterVoltageID);

            if (preheatComp == ClsID.intCompElecHeaterID || heatingComp == ClsID.intCompElecHeaterID || reheatComp == ClsID.intCompElecHeaterID)
            {
                elecHeaderVoltageInfo.Visible = true;

                bool bol208V_1Ph = false;


                if (intProductTypeID == ClsID.intProdTypeNovaID)
                {
                    if (intUnitModelId == ClsID.intNovaUnitModelID_A16IN || intUnitModelId == ClsID.intNovaUnitModelID_B20IN ||
                    intUnitModelId == ClsID.intNovaUnitModelID_A18OU || intUnitModelId == ClsID.intNovaUnitModelID_B22OU)
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
                    if (intUnitModelId == ClsID.intVentumUnitModelID_H05IN_ERV || intUnitModelId == ClsID.intVentumUnitModelID_H10IN_ERV ||
                        intUnitModelId == ClsID.intVentumUnitModelID_H05IN_HRV || intUnitModelId == ClsID.intVentumUnitModelID_H10IN_HRV)
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

                if (dtElecHeaterVoltage.Rows.Count > 0)
                {
                    elecHeaderVoltageInfo.data = dtElecHeaterVoltage;

                    if (bol208V_1Ph)
                    {
                        elecHeaderVoltageInfo.id = ClsID.intElectricVoltage_208V_1Ph_60HzID;
                    }
                    else
                    {
                        elecHeaderVoltageInfo.id = ClsID.intElectricVoltage_208V_3Ph_60HzID;
                    }
                }
            }
            else
            {
                elecHeaderVoltageInfo.visible = false;
            }

            return elecHeaderVoltageInfo;
        }

        public static dynamic GetPreheatElectricHeater(dynamic fieldInfo)
        {
            dynamic preheatElecticalHeaderInstallation = new ExpandoObject();
            DataTable dtElecHeaterVoltage = new DataTable();
            int intProductTypeId = Convert.ToInt32(fieldInfo.productTypeId);
            int intUnitModelId = Convert.ToInt32(fieldInfo.unitModel);
            int intLocationId = Convert.ToInt32(fieldInfo.location);
            int preheatComp = Convert.ToInt32(fieldInfo.preheatComp);
            int heatingComp = Convert.ToInt32(fieldInfo.heatingComp);
            int reheatComp = Convert.ToInt32(fieldInfo.reheatComp);
            int intElecHeaterVoltageID = Convert.ToInt32(fieldInfo.elecHeaterVoltageID);
            int intPreheatElecHeaterInstallationID = Convert.ToInt32(fieldInfo.elecHeaderInstallation);

            int intSelectedValue = 0;

            if (preheatComp == ClsID.intCompElecHeaterID || preheatComp == ClsID.intCompAutoID)
            {
                //if (!bolPreheatRequired)
                //{
                DataTable dtPreheatElecHeaterInstallation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricHeaterInstallation, intPreheatElecHeaterInstallationID).Copy();
                dtPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation.Select("id <> 1").CopyToDataTable();
                preheatElecticalHeaderInstallation.data = dtPreheatElecHeaterInstallation;

                //Outdoor Units - Only Casing Installation (Only Nova Unit can be Indoor or Outdoor, For Ventum and VentumLite Indoor unit is by default and Outdoor not available)
                if (intUnitModelId == ClsID.intLocationOutdoorID)
                {
                    dtPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation.Select("id = " + ClsID.intElecHeaterInstallInCasingID).CopyToDataTable();
                    preheatElecticalHeaderInstallation.data = dtPreheatElecHeaterInstallation;
                }
                else //Indoor Units
                {

                    if (intProductTypeId == ClsID.intProdTypeNovaID || intProductTypeId == ClsID.intProdTypeVentumID)
                    {
                        //Casing Installation should be selected by default. Duct Mount option also available
                        //if (ddlPreheatElecHeaterInstallation.Items.FindByValue(intSelectedValue.ToString()) != null)
                        //{
                        preheatElecticalHeaderInstallation.SelectedValue = intSelectedValue > 1 ? intSelectedValue.ToString() : ClsID.intElecHeaterInstallInCasingID.ToString();
                        //}
                    }
                    else if (intProductTypeId == ClsID.intProdTypeVentumLiteID)
                    {
                        //Duct Mount is the only option
                        dtPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation.Select("id = " + ClsID.intElecHeaterInstallDuctMountedID).CopyToDataTable();
                        preheatElecticalHeaderInstallation.data = dtPreheatElecHeaterInstallation;
                    }
                }
            }

            switch (preheatComp)
            {
                case ClsID.intCompNA_ID:
                case ClsID.intCompHWC_ID:
                case ClsID.intCompAutoID:
                    preheatElecticalHeaderInstallation.Visible = false;
                    break;
                case ClsID.intCompElecHeaterID:
                    preheatElecticalHeaderInstallation.Visible = true;
                    break;
                default:
                    break;
            }

            return preheatElecticalHeaderInstallation;
        }

        //public static dynamic GetElectricHeaterVoltage(dynamic fieldInfo)
        //{
        //    dynamic electricHeaderVoltageInfo = new ExpandoObject();
        //    DataTable dtElecHeaterVoltage = new DataTable();
        //    int intProductTypeID = Convert.ToInt32(fieldInfo.productTypeId);
        //    int intUnitModelId = Convert.ToInt32(fieldInfo.unitModel);
        //    int intLocationId = Convert.ToInt32(fieldInfo.location);
        //    int preheatComp = Convert.ToInt32(fieldInfo.preheatComp);
        //    int heatingComp = Convert.ToInt32(fieldInfo.heatingComp);
        //    int reheatComp = Convert.ToInt32(fieldInfo.reheatComp);
        //    int unitVoltage = Convert.ToInt32(fieldInfo.unitVoltage);
        //    int intElecHeaterVoltageID = Convert.ToInt32(fieldInfo.elecHeaterVoltageID);
        //    int intPreheatElecHeaterInstallationID = Convert.ToInt32(fieldInfo.elecHeaderInstallation);


        //    if (preheatComp == ClsID.intCompElecHeaterID ||
        //        heatingComp == ClsID.intCompElecHeaterID ||
        //        reheatComp == ClsID.intCompElecHeaterID)
        //    {
        //        electricHeaderVoltageInfo.Visible = true;

        //        bool bol208V_1Ph = false;


        //        if (intProductTypeID == ClsID.intProdTypeNovaID)
        //        {
        //            if (intUnitModelId == ClsID.intNovaUnitModelID_A16IN || intUnitModelId == ClsID.intNovaUnitModelID_B20IN ||
        //            intUnitModelId == ClsID.intNovaUnitModelID_A18OU || intUnitModelId == ClsID.intNovaUnitModelID_B22OU)
        //            {
        //                bol208V_1Ph = true;
        //                dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater_2", 1, intElecHeaterVoltageID).Copy();
        //            }
        //            else
        //            {
        //                dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater", 1, intElecHeaterVoltageID).Copy();
        //            }
        //        }
        //        else if (intProductTypeID == ClsID.intProdTypeVentumID)
        //        {
        //            if (intUnitModelId == ClsID.intVentumUnitModelID_H05IN_ERV || intUnitModelId == ClsID.intVentumUnitModelID_H10IN_ERV ||
        //                intUnitModelId == ClsID.intVentumUnitModelID_H05IN_HRV || intUnitModelId == ClsID.intVentumUnitModelID_H10IN_HRV)
        //            {
        //                bol208V_1Ph = true;
        //                dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater_2", 1, intElecHeaterVoltageID).Copy();
        //            }
        //            else
        //            {
        //                dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater", 1, intElecHeaterVoltageID).Copy();
        //            }
        //        }
        //        else if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
        //        {
        //            bol208V_1Ph = true;
        //            dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater_3", 1, intElecHeaterVoltageID).Copy();
        //        }


        //        if (dtElecHeaterVoltage.Rows.Count > 0)
        //        {
        //            electricHeaderVoltageInfo.data = dtElecHeaterVoltage;

        //            if (bol208V_1Ph)
        //            {
        //                electricHeaderVoltageInfo.selectedValue = ClsID.intElectricVoltage_208V_1Ph_60HzID;
        //            }
        //            else
        //            {
        //                electricHeaderVoltageInfo.selectedValue = ClsID.intElectricVoltage_208V_3Ph_60HzID;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
        //        {
        //            dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater_3", 1, intElecHeaterVoltageID).Copy();
        //            electricHeaderVoltageInfo.data = dtElecHeaterVoltage;
        //            electricHeaderVoltageInfo.selectedValue = unitVoltage;
        //            //ClsWFC.get_ddlLockItem(ddlElecHeaterVoltage, ClsID.intElectricVoltage_208V_1Ph_60HzID);
        //            electricHeaderVoltageInfo.Enabled = false;
        //        }
        //        else
        //        {
        //            //ddlElecHeaterVoltage.Items.Insert(0, new ListItem("NA", "0"));
        //            //ddlElecHeaterVoltage.SelectedIndex = 0;
        //            dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater", 1, intElecHeaterVoltageID).Copy();
        //            electricHeaderVoltageInfo.data = dtElecHeaterVoltage;
        //            electricHeaderVoltageInfo.selectedValue = ClsID.intElectricVoltage_208V_3Ph_60HzID;
        //        }

        //        electricHeaderVoltageInfo.Visible = false;
        //    }

        //    return electricHeaderVoltageInfo;
        //}

        public static dynamic GetCustomInputs(dynamic fieldInfo)
        {
            int preheatComp = Convert.ToInt32(fieldInfo.preheatComp);
            int coolingComp = Convert.ToInt32(fieldInfo.coolingComp);
            int heatingComp = Convert.ToInt32(fieldInfo.heatingComp);
            int reheatComp = Convert.ToInt32(fieldInfo.reheatComp);
            int unitType = Convert.ToInt32(fieldInfo.unitType);
            dynamic customInputs = new ExpandoObject();
            if (preheatComp == ClsID.intCompHWC_ID)
            {
                customInputs.preheatHWC_UseFlowRateVisible = true;
                customInputs.preheatHWC_FlowRateVisible = true;

                if (unitType == ClsID.intUnitTypeAHU_ID)
                {
                    customInputs.preheatHWC_UseCapVisible = true;
                    customInputs.preheatHWC_CapVisible = true;
                }
                else
                {
                    customInputs.preheatHWC_UseCapVisible = false;
                    customInputs.preheatHWC_CapVisible = false;
                }
            }
            else
            {
                customInputs.preheatHWC_UseCap.Visible = false;
                customInputs.preheatHWC_CapVisible = false;
                customInputs.preheatHWC_UseFlowRateVisible = false;
                customInputs.preheatHWC_FlowRateVisible = false;
            }


            if (coolingComp == ClsID.intCompCWC_ID)
            {
                customInputs.coolingCWC_UseCapVisible = true;
                customInputs.coolingCWC_CapVisible = true;
                customInputs.coolingCWC_UseFlowRateVisible = true;
                customInputs.coolingCWC_FlowRateVisible = true;
            }
            else
            {
                customInputs.coolingCWC_UseCapVisible = false;
                customInputs.coolingCWC_CapVisible = false;
                customInputs.coolingCWC_UseFlowRateVisible = false;
                customInputs.coolingCWC_FlowRateVisible = false;
            }


            if (heatingComp == ClsID.intCompHWC_ID)
            {
                customInputs.heatingHWC_UseCapVisible = true;
                customInputs.heatingHWC_CapVisible = true;
                customInputs.heatingHWC_UseFlowRateVisible = true;
                customInputs.heatingHWC_FlowRateVisible = true;
            }
            else
            {
                customInputs.heatingHWC_UseCapVisible = false;
                customInputs.heatingHWC_CapVisible = false;
                customInputs.heatingHWC_UseFlowRateVisible = false;
                customInputs.heatingHWC_FlowRateVisible = false;
            }


            if (reheatComp == ClsID.intCompHWC_ID)
            {
                customInputs.reheatHWC_UseCapVisible = true;
                customInputs.reheatHWC_CapVisible = true;
                customInputs.reheatHWC_UseFlowRateVisible = true;
                customInputs.reheatHWC_FlowRateVisible = true;
            }
            else
            {
                customInputs.reheatHWC_UseCapVisible = false;
                customInputs.reheatHWC_CapVisible = false;
                customInputs.reheatHWC_UseFlowRateVisible = false;
                customInputs.reheatHWC_FlowRateVisible = false;
            }

            return customInputs;
        }

        public static bool GetPreheatSetpoint(dynamic fieldInfo)
        {
            if (Convert.ToInt32(fieldInfo.unitTypeId )== ClsID.intUnitTypeAHU_ID &&
                (Convert.ToInt32(fieldInfo.preheatComp) == ClsID.intCompElecHeaterID ||
                Convert.ToInt32(fieldInfo.preheatComp) == ClsID.intCompHWC_ID))
            {
                return true;
            }
            else
            {
                return false;
            }
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

            returnInfo.ddlSupplyAirOpening = getSupplyAirOpening();
            intSupplyAirOpeningID = returnInfo.ddlSupplyAirOpening.value;

            return returnInfo;
        }


        public static dynamic txbSummerReturnAirCFM_Changed(dynamic fieldInfo)
        {
            if (!ClsNumber.IsNumber(fieldInfo.summerSupplyAirCFM.ToString()) || !ClsNumber.IsNumber(fieldInfo.summerReturnAirCFM.ToString()))
            {
                return 0;
            }

            dynamic returnInfo = new ExpandoObject();

            int intUAL = Convert.ToInt32(fieldInfo.UAL);
            int orientationId = Convert.ToInt32(fieldInfo.orientation);
            int intProductTypeID = Convert.ToInt32(fieldInfo.productTypeId);
            int intUnitTypeID = Convert.ToInt32(fieldInfo.unitTypeId);
            String summerReturnAirCFM = fieldInfo.summerReturnAirCFM;
            String summerSupplyAirCFM = fieldInfo.summerSupplyAirCFM;
            Boolean byPass = fieldInfo.byPass;

            if (orientationId == ClsID.intOrientationHorizontalID && Convert.ToInt32(summerSupplyAirCFM) > intNOVA_HORIZONTAL_MAX_CFM)
            {
                returnInfo.summerReturnAirCFM = intNOVA_HORIZONTAL_MAX_CFM.ToString();
            }

            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                if (Convert.ToInt32(summerReturnAirCFM) < intNOVA_MIN_CFM)
                {
                    returnInfo.summerReturnAirCFM = intNOVA_MIN_CFM.ToString();
                }
                else if (Convert.ToInt32(summerReturnAirCFM) > intNOVA_MAX_CFM)
                {
                    returnInfo.summerReturnAirCFM = intNOVA_MAX_CFM.ToString();
                }
            }
            else if (intProductTypeID == ClsID.intProdTypeVentumID)
            {
                if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1)
                {
                    if (byPass)
                    {
                        if (Convert.ToInt32(summerReturnAirCFM) < intVEN_INT_USERS_MIN_CFM_WITH_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVEN_INT_USERS_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerReturnAirCFM) > intVEN_INT_USERS_MAX_CFM_WITH_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVEN_INT_USERS_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(summerReturnAirCFM) < intVEN_INT_USERS_MIN_CFM_NO_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVEN_INT_USERS_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerReturnAirCFM) > intVEN_INT_USERS_MAX_CFM_NO_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVEN_INT_USERS_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
                else
                {
                    if (byPass)
                    {
                        if (Convert.ToInt32(summerReturnAirCFM) < intVEN_MIN_CFM_WITH_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVEN_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerReturnAirCFM) > intVEN_MAX_CFM_WITH_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVEN_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(summerReturnAirCFM) < intVEN_MIN_CFM_NO_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVEN_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerReturnAirCFM) > intVEN_MAX_CFM_NO_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVEN_MAX_CFM_NO_BYPASS.ToString();
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
                        if (Convert.ToInt32(summerReturnAirCFM) < intVENLITE_INT_USERS_MIN_CFM_WITH_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVENLITE_INT_USERS_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerReturnAirCFM) > intVENLITE_INT_USERS_MAX_CFM_WITH_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVENLITE_INT_USERS_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(summerReturnAirCFM) < intVENLITE_INT_USERS_MIN_CFM_NO_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVENLITE_INT_USERS_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerReturnAirCFM) > intVENLITE_INT_USERS_MAX_CFM_NO_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVENLITE_INT_USERS_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
                else
                {
                    if (byPass)
                    {
                        if (Convert.ToInt32(summerReturnAirCFM) < intVENLITE_MIN_CFM_WITH_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVENLITE_MIN_CFM_WITH_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerReturnAirCFM) > intVENLITE_MAX_CFM_WITH_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVENLITE_MAX_CFM_WITH_BYPASS.ToString();
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(summerReturnAirCFM) < intVENLITE_MIN_CFM_NO_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVENLITE_MIN_CFM_NO_BYPASS.ToString();
                        }
                        else if (Convert.ToInt32(summerReturnAirCFM) > intVENLITE_MAX_CFM_NO_BYPASS)
                        {
                            returnInfo.summerReturnAirCFM = intVENLITE_MAX_CFM_NO_BYPASS.ToString();
                        }
                    }
                }
            }


            if ((intProductTypeID == ClsID.intProdTypeNovaID && intUnitTypeID == ClsID.intUnitTypeERV_ID) ||
               ((intProductTypeID == ClsID.intProdTypeVentumID || intProductTypeID == ClsID.intProdTypeVentumLiteID) && intUnitTypeID == ClsID.intUnitTypeHRV_ID))
            {
                if (Convert.ToInt32(summerReturnAirCFM) < (Convert.ToInt32(summerSupplyAirCFM) * 0.5))
                {
                    returnInfo.summerReturnAirCFM = Math.Ceiling(Convert.ToDecimal(summerSupplyAirCFM) * 0.5m).ToString();
                }
                else if (Convert.ToInt32(summerReturnAirCFM) > (Convert.ToInt32(summerSupplyAirCFM) * 1.5m))
                {
                    returnInfo.summerReturnAirCFM = Math.Ceiling(Convert.ToDecimal(summerSupplyAirCFM) * 1.5m).ToString();
                }
            }
            else if ((intProductTypeID == ClsID.intProdTypeVentumID || intProductTypeID == ClsID.intProdTypeVentumLiteID) && intUnitTypeID == ClsID.intUnitTypeERV_ID)
            {
                if (Convert.ToInt32(summerReturnAirCFM) < (Convert.ToInt32(summerSupplyAirCFM) * 0.8))
                {
                    returnInfo.summerReturnAirCFM = Math.Ceiling(Convert.ToDecimal(summerSupplyAirCFM) * 0.8m).ToString();
                }
                else if (Convert.ToInt32(summerReturnAirCFM) > (Convert.ToInt32(summerSupplyAirCFM) * 1.2))
                {
                    returnInfo.summerReturnAirCFM = Math.Ceiling(Convert.ToDecimal(summerSupplyAirCFM) * 1.2m).ToString();
                }
            }

            return returnInfo;
        }


        public static string txbSupplyAirESP_Changed(string txbSupplyAirESP)
        {
            if (!ClsNumber.IsNumber(txbSupplyAirESP))
            {
                return "";
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

            return supplyAirESP;
       }


        public static dynamic txbExhaustAirESP_Changed(string exhaustAirESP)
        {
            dynamic returnInfo = new ExpandoObject();

            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                if (intUnitModelID == ClsID.intNovaUnitModelID_A16IN || intUnitModelID == ClsID.intNovaUnitModelID_B20IN ||
                    intUnitModelID == ClsID.intNovaUnitModelID_A18OU || intUnitModelID == ClsID.intNovaUnitModelID_B22OU)
                {
                    if (Convert.ToDouble(exhaustAirESP) > 2.0d)
                    {
                        returnInfo.exhaustAirESP = "2.0";
                    }

                }
                else if (Convert.ToDouble(exhaustAirESP) > 3.0d)
                {
                    returnInfo.exhaustAirESP = "3.0";
                }
                else
                {
                    returnInfo.exhaustAirESP = exhaustAirESP;
                }
            }

            return returnInfo;
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

            modelInfo.others = ddlUnitModelIndexChanged(new { txbSummerSupplyAirCFM = txbSummerSupplyAirCFMText });
            return modelInfo;
        }

        private static dynamic ddlUnitModelIndexChanged(dynamic fieldInfo)
        {
            dynamic info = new ExpandoObject();
            info.ddlUnitVoltage = getVoltage();
            info.ddlUnitVoltageValue = intUnitVoltageID;
            info.txbSupplyAirESP = txbSupplyAirESP_Changed(fieldInfo.txbSummerSupplyAirCFM.ToString());
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

        private static dynamic getSupplyAirOpening()
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
            }
            else if (intUnitTypeID == ClsID.intUnitTypeAHU_ID)
            {
                supplyAirOpeningInfo.data = ClsDB.get_dtLiveEnabled(ClsDBT.strSelOpeningsFC_SA, intSupplyAirOpeningID);
                supplyAirOpeningInfo.value = supplyAirOpeningInfo.ddlSupplyAirOpening.Rows[0]["id"];
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

        private static dynamic getCustomInputs()
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

        private static dynamic getValveAndActuator()
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

        private static dynamic getHeatElectricHeater()
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


        private static dynamic getPreheatElectricHeater()
        {
            dynamic preheatElectricHeater = new ExpandoObject();
            int intSelectedValue = 0;

            if (intPreheatCompID == ClsID.intCompElecHeaterID || intPreheatCompID == ClsID.intCompAutoID)
            {
                //if (!bolPreheatRequired)
                //{
                DataTable dtPreheatElecHeaterInstallation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricHeaterInstallation, intPreheatElecHeaterInstallationID).Copy();
                dtPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation.Select("id <> 1").CopyToDataTable();
                preheatElectricHeater.ddlPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation;

                //Outdoor Units - Only Casing Installation (Only Nova Unit can be Indoor or Outdoor, For Ventum and VentumLite Indoor unit is by default and Outdoor not available)
                if (intLocationID == ClsID.intLocationOutdoorID)
                {
                    dtPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation.Select("id = " + ClsID.intElecHeaterInstallInCasingID).CopyToDataTable();
                    preheatElectricHeater.ddlPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation;
                }
                else //Indoor Units
                {

                    if (intProductTypeID == ClsID.intProdTypeNovaID || intProductTypeID == ClsID.intProdTypeVentumID)
                    {
                        preheatElectricHeater.ddlPreheatElecHeaterInstallationValue = intSelectedValue > 1 ? intSelectedValue.ToString() : ClsID.intElecHeaterInstallInCasingID.ToString();
                    }
                    else if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
                    {
                        //Duct Mount is the only option
                        dtPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation.Select("id = " + ClsID.intElecHeaterInstallDuctMountedID).CopyToDataTable();
                        preheatElectricHeater.ddlPreheatElecHeaterInstallation = dtPreheatElecHeaterInstallation;
                    }
                }
            }

            switch (intReheatCompID)
            {
                case ClsID.intCompNA_ID:
                case ClsID.intCompHWC_ID:
                case ClsID.intCompAutoID:
                    preheatElectricHeater.divPreheatElecHeaterInstallationVisible = false;
                    break;
                case ClsID.intCompElecHeaterID:
                    preheatElectricHeater.divPreheatElecHeaterInstallationVisible = true;
                    break;
                default:
                    break;
            }

            return preheatElectricHeater;
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

        private static dynamic getRefrigerant()
        {
            dynamic refrigerantInfo = new ExpandoObject();
            if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_1 || intUAL == ClsID.intUAL_IntLvl_2)
            {
                refrigerantInfo.divDX_RefrigerantVisible = intCoolingCompID == ClsID.intCompDX_ID ? true : false;

                refrigerantInfo.divCondRefrigerantVisible = (ckbHeatPumpChecked == 1 || intReheatCompID == ClsID.intCompHGRH_ID) ? true : false;
            }
            return refrigerantInfo;
        }

        private static bool getHeatingFluidDesignConditions()
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

        private static dynamic getReheatSetpoints()
        {
            dynamic reheatSetpointsInfo = new ExpandoObject();
            reheatSetpointsInfo.divReheatSetpointVisible = intReheatCompID > 1 ? true : false;
            reheatSetpointsInfo.divCondRefrigerantVisible = intReheatCompID == ClsID.intCompHGRH_ID ? true : false;
            return reheatSetpointsInfo;
        }

        private static bool getHeatingSetpoint()
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

        private static dynamic getCoolingSetpoint()
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

        private static bool getPreheatSetpoint()
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

        private static dynamic getReheat()
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

        private static dynamic getDehumidification()
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

        private static dynamic getCooling()
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

    }
}