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
        private double dblTempErrorValue = 0.000d;
        //private bool bolErrorSummerWB = false;
        //private bool bolErrorSummerRH = false;
        //private bool bolErrorWinterWB = false;
        //private bool bolErrorWinterRH = false;

        private const int intNOVA_MIN_CFM = 325;
        //private const int intNOVA_MAX_CFM = 8100;
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


        public static bool DeleteUnitById(int jobId, int unitId)
        {
            return ClsDB.DeleteUnit(jobId, unitId);
        }

        public static bool DeleteUnitsByIds(int jobId, dynamic unitIds)
        {
            return ClsDB.DeleteUnits(jobId, unitIds);
        }

        public static bool SaveUnitInfo(dynamic unitInfo)
        {
            DataTable dt = ClsDB.SaveGeneral(Convert.ToInt32(unitInfo.jobId),
                                            Convert.ToInt32(unitInfo.unitId),
                                            unitInfo.tag.ToString().ToUpper(),
                                            Convert.ToInt32(unitInfo.qty),
                                            Convert.ToInt32(unitInfo.productTypeId),
                                            Convert.ToInt32(unitInfo.unitTypeId),
                                            Convert.ToInt32(unitInfo.byPassId),
                                            Convert.ToInt32(unitInfo.unitModelId),
                                            Convert.ToInt32(unitInfo.selectionTypeId),
                                            Convert.ToInt32(unitInfo.location),
                                            Convert.ToInt32(0),
                                            Convert.ToInt32(unitInfo.orientation),
                                            Convert.ToInt32(unitInfo.controlPreference),
                                            Convert.ToDouble(unitInfo.unitHeight),
                                            Convert.ToDouble(unitInfo.unitWidth),
                                            Convert.ToDouble(unitInfo.unitLength),
                                            Convert.ToDouble(unitInfo.unitWeight),
                                            Convert.ToInt32(unitInfo.unitVoltage),
                                            Convert.ToInt32(unitInfo.voltageSPPId),
                                            1,
                                            0d);

            unitInfo.unitId = dt.Rows[0]["UnitNo"].ToString();

            ClsDB.SaveAirFlow(Convert.ToInt32(unitInfo.jobId),
                                Convert.ToInt32(unitInfo.unitId),
                                Convert.ToInt32(unitInfo.altitude),
                                Convert.ToInt32(unitInfo.summerSupplyAirCFM),
                                Convert.ToInt32(unitInfo.summerReturnAirCFM),
                                Convert.ToInt32(unitInfo.summerSupplyAirCFM),
                                Convert.ToInt32(unitInfo.summerReturnAirCFM),
                                Math.Round(Convert.ToDouble(unitInfo.summer_air_db), 1),
                                Math.Round(Convert.ToDouble(unitInfo.summer_air_wb), 1),
                                Math.Round(Convert.ToDouble(unitInfo.summer_air_rh), 1),
                                Math.Round(Convert.ToDouble(unitInfo.winter_air_db), 1),
                                Math.Round(Convert.ToDouble(unitInfo.winter_air_wb), 3),
                                Math.Round(Convert.ToDouble(unitInfo.winter_air_rh), 1),
                                Math.Round(Convert.ToDouble(unitInfo.summer_return_db), 1),
                                Math.Round(Convert.ToDouble(unitInfo.summer_return_wb), 1),
                                Math.Round(Convert.ToDouble(unitInfo.summer_return_rh), 1),
                                Math.Round(Convert.ToDouble(unitInfo.winter_return_db), 1),
                                Math.Round(Convert.ToDouble(unitInfo.winter_return_wb), 1),
                                Math.Round(Convert.ToDouble(unitInfo.winter_return_rh), 1),
                                Convert.ToDouble(unitInfo.winter_preheat_setpoint_db),
                                Convert.ToDouble(unitInfo.winter_heating_setpoint_db),
                                Convert.ToDouble(unitInfo.summer_cooling_setpoint_db),
                                Convert.ToDouble(unitInfo.summer_cooling_setpoint_wb),
                                Convert.ToDouble(unitInfo.summer_reheat_setpoint_db),
                                Convert.ToDouble(unitInfo.supplyAirESP),
                                Convert.ToDouble(unitInfo.exhaustAirESP));

            ClsCompOpt objCompOpt = new ClsCompOpt
            {
                intJobID = Convert.ToInt32(unitInfo.jobId),
                intUnitNo = Convert.ToInt32(unitInfo.unitId),
                intUnitTypeID = Convert.ToInt32(unitInfo.unitTypeId),
                //intUnitModelID = Convert.ToInt32(id_list.Attributes[ClsID.strAttUnitModelID]),
                //intVoltageID = Convert.ToInt32(id_list.Attributes[ClsID.strAttUnitVoltageID]),
                intUnitModelID = Convert.ToInt32(unitInfo.unitModelId),
                intVoltageID = Convert.ToInt32(unitInfo.unitVoltage),
                intOA_FilterModelID = Convert.ToInt32(unitInfo.qa_filter),
                intSA_FinalFilterModelID = 0,
                intRA_FilterModelID = Convert.ToInt32(unitInfo.ra_filter),
                intHeatExchCompID = Convert.ToInt32(unitInfo.heatExch),
                intPreheatCompID = Convert.ToInt32(unitInfo.preheat),
                intCoolingCompID = Convert.ToInt32(unitInfo.cooling),
                intHeatingCompID = Convert.ToInt32(unitInfo.heating),
                intReheatCompID = Convert.ToInt32(unitInfo.reheat),
                intIsHeatPump = unitInfo.heatPump,
                intIsDehumidification = unitInfo.dehumidification,
                intElecHeaterVoltageID = Convert.ToInt32(unitInfo.elecHeaderVoltage),
                intPreheatElecHeaterInstallationID = Convert.ToInt32(unitInfo.preheatElecHeaterInstallationId),
                intHeatElecHeaterInstallationID = Convert.ToInt32(unitInfo.heatElecHeaterInstallationId),
                intDamperAndActuatorID = Convert.ToInt32(unitInfo.damperActuator),
                intIsValveAndActuatorIncluded = unitInfo.valveAndActuator,
                intValveTypeID = Convert.ToInt32(unitInfo.valveTypeId),
                intIsDrainPan = unitInfo.drainPan,
                dblOA_FilterPD = Convert.ToDouble(unitInfo.qa_filter_pd),
                dblRA_FilterPD = Convert.ToDouble(unitInfo.ra_filter_pd),
                dblPreheatSetpointDB = Convert.ToDouble(unitInfo.preheatSetpointDB),
                dblCoolingSetpointDB = Convert.ToDouble(unitInfo.coolingSetpointDB),
                dblCoolingSetpointWB = Convert.ToDouble(unitInfo.coolingSetpointWB),
                dblHeatingSetpointDB = Convert.ToDouble(unitInfo.heatingSetpointDB),
                dblReheatSetpointDB = Convert.ToDouble(unitInfo.reheatSetpointDB),
                intCoolingFluidTypeID = Convert.ToInt32(unitInfo.coolingFluidType),
                intCoolingFluidConcentID = Convert.ToInt32(unitInfo.coolingFluidConcentration),
                dblCoolingFluidEntTemp = Convert.ToDouble(unitInfo.coolingFluidEntTemp),
                dblCoolingFluidLvgTemp = Convert.ToDouble(unitInfo.coolingFluidLvgTemp),
                intHeatingFluidTypeID = Convert.ToInt32(unitInfo.heatingFluidType),
                intHeatingFluidConcentID = Convert.ToInt32(unitInfo.heatingFluidConcentration),
                dblHeatingFluidEntTemp = Convert.ToDouble(unitInfo.heatingFluidEntTemp),
                dblHeatingFluidLvgTemp = Convert.ToDouble(unitInfo.heatingFluidLvgTemp),
                dblRefrigSuctionTemp = Convert.ToDouble(unitInfo.refrigSuctionTemp),
                dblRefrigLiquidTemp = Convert.ToDouble(unitInfo.refrigLiquidTemp),
                dblRefrigSuperheatTemp = Convert.ToDouble(unitInfo.refrigSuperheatTemp),
                dblRefrigCondensingTemp = Convert.ToDouble(unitInfo.refrigCondensingTemp),
                dblRefrigVaporTemp = Convert.ToDouble(unitInfo.refrigVaporTemp),
                dblRefrigSubcoolingTemp = Convert.ToDouble(unitInfo.refrigSubcoolingTemp),
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
                    intJobID = Convert.ToInt32(unitInfo.jobId),
                    intUnitNo = Convert.ToInt32(unitInfo.unitId),
                    intIsPreheatHWC_UseCap = unitInfo.preheatHWC_UseCap,
                    dblPreheatHWC_Cap = Convert.ToDouble(unitInfo.preheatHWC_Cap),
                    intIsPreheatHWC_UseFlowRate = unitInfo.preheatHWC_UseFlowRate,
                    dblPreheatHWC_FlowRate = Convert.ToDouble(unitInfo.preheatHWC_FlowRate),
                    intIsCoolingCWC_UseCap = unitInfo.coolingCWC_UseCap,
                    dblCoolingCWC_Cap = Convert.ToDouble(unitInfo.coolingCWC_Cap),
                    intIsCoolingCWC_UseFlowRate = unitInfo.coolingCWC_UseFlowRate,
                    dblCoolingCWC_FlowRate = Convert.ToDouble(unitInfo.coolingCWC_FlowRate),
                    intIsHeatingHWC_UseCap = unitInfo.heatingHWC_UseCap,
                    dblHeatingHWC_Cap = Convert.ToDouble(unitInfo.heatingHWC_Cap),
                    intIsHeatingHWC_UseFlowRate = unitInfo.heatingHWC_UseFlowRate,
                    dblHeatingHWC_FlowRate = Convert.ToDouble(unitInfo.heatingHWC_FlowRate),
                    intIsReheatHWC_UseCap = unitInfo.reheatHWC_UseCap,
                    dblReheatHWC_Cap = Convert.ToDouble(unitInfo.reheatHWC_Cap),
                    intIsReheatHWC_UseFlowRate = unitInfo.reheatHWC_UseFlowRate,
                    dblReheatHWC_FlowRate = Convert.ToDouble(unitInfo.reheatHWC_FlowRate),
                };

                ClsDB.SaveCompOptCustom(objCompOptCustom);
            }

            ClsLayoutOpt objLayoutOpt = new ClsLayoutOpt
            {
                intJobID = Convert.ToInt32(unitInfo.jobId),
                intUnitNo = Convert.ToInt32(unitInfo.unitNo),
                intProductTypeID = Convert.ToInt32(unitInfo.productTypeId),
                intUnitTypeID = Convert.ToInt32(unitInfo.unitTypeId),
                intHandingID = Convert.ToInt32(unitInfo.handing),
                intPreheatCoilHandingID = Convert.ToInt32(unitInfo.preheatCoilHandingId),
                intCoolingCoilHandingID = Convert.ToInt32(unitInfo.coolingCoilHandingId),
                intHeatingCoilHandingID = Convert.ToInt32(unitInfo.heatingCoilHandingId),
                intSupplyAirOpeningID = Convert.ToInt32(unitInfo.supplyAirOpeningId),
                strSupplyAirOpening = unitInfo.supplyAirOpening,
                intExhaustAirOpeningID = Convert.ToInt32(unitInfo.exhaustAirOpeningId),
                strExhaustAirOpening = unitInfo.exhaustAirOpening,
                intOutdoorAirOpeningID = Convert.ToInt32(unitInfo.outdoorAirOpeningId),
                strOutdoorAirOpening = unitInfo.outdoorAirOpening,
                intReturnAirOpeningID = Convert.ToInt32(unitInfo.returnAirOpeningId),
                strReturnAirOpening = unitInfo.returnAirOpening
            };

            ClsDB.SaveLayout(objLayoutOpt);

            return true;
        }
        public static dynamic GetUnitInfo(int jobId, int unitId)
        {
            dynamic unitInfo = new ExpandoObject();
            DataTable dtJob = ClsDB.GetSavedJob(Convert.ToInt32(jobId));
            var Session = HttpContext.Current.Session;

            ClsProjectInfo objProjectInfo = new ClsProjectInfo(Convert.ToInt32(jobId));
            ClsGeneral objGeneral = new ClsGeneral(jobId, unitId);
            ClsAirFlowData objAirFlowData = new ClsAirFlowData(jobId, unitId);
            ClsComponentItems objCompItems = new ClsComponentItems(jobId, unitId);
            ClsLayout objLayout = new ClsLayout(jobId, unitId);

            unitInfo.altitude = objProjectInfo.intAltitude.ToString();

            unitInfo.summerOutdoorAirDB = objProjectInfo.dblSummerOutdoorAirDB.ToString();
            unitInfo.summerOutdoorAirWB = objProjectInfo.dblSummerOutdoorAirWB.ToString();
            unitInfo.summerOutdoorAirRH = objProjectInfo.dblSummerOutdoorAirRH.ToString();

            unitInfo.winterOutdoorAirDB = objProjectInfo.dblWinterOutdoorAirDB.ToString();
            unitInfo.winterOutdoorAirWB = objProjectInfo.dblWinterOutdoorAirWB.ToString();
            unitInfo.winterOutdoorAirRH = objProjectInfo.dblWinterOutdoorAirRH.ToString();

            unitInfo.summerReturnAirDB = objProjectInfo.dblSummerReturnAirDB.ToString();
            unitInfo.summerReturnAirWB = objProjectInfo.dblSummerReturnAirWB.ToString();
            unitInfo.summerReturnAirRH = objProjectInfo.dblSummerReturnAirRH.ToString();

            unitInfo.winterReturnAirDB = objProjectInfo.dblWinterReturnAirDB.ToString();
            unitInfo.winterReturnAirWB = objProjectInfo.dblWinterReturnAirWB.ToString();
            unitInfo.winterReturnAirRH = objProjectInfo.dblWinterReturnAirRH.ToString();


            if (objGeneral != null)
            {
                unitInfo.tag = objGeneral.strTag;
                unitInfo.qty = objGeneral.intQty.ToString();

                unitInfo.productTypeId = objGeneral.intProductTypeID;
                unitInfo.unitTypeID = objGeneral.intUnitTypeID;
                unitInfo.unitTypeName = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitType, objGeneral.intUnitTypeID);
                unitInfo.locationID = objGeneral.intLocationID;
                unitInfo.orientationID = objGeneral.intOrientationID;

                unitInfo.unitModelID = objGeneral.intUnitModelID;
                unitInfo.unitVoltageID = objGeneral.intUnitVoltageID;
                unitInfo.controlsPreferenceID = objGeneral.intControlsPreferenceID;

                unitInfo.unitHeight = objGeneral.dblUnitHeight.ToString();
                unitInfo.unitWidth = objGeneral.dblUnitWidth.ToString();
                unitInfo.unitLength = objGeneral.dblUnitLength.ToString();
                unitInfo.unitWeight = objGeneral.dblUnitWeight.ToString();
            }

            if (objAirFlowData != null)
            {
                unitInfo.summerSupplyAirCFM = objAirFlowData.get_intSummerSupplyAirCFM().ToString();

                unitInfo.supplyAirESP = objAirFlowData.get_dblSupplyAirESP().ToString();
                unitInfo.exhaustAirESP = objAirFlowData.get_dblExhaustAirESP().ToString();

                unitInfo.summerReturnAirDB = objAirFlowData.get_dblSummerReturnAirDB().ToString();
                unitInfo.summerReturnAirWB = objAirFlowData.get_dblSummerReturnAirWB().ToString();
                unitInfo.summerReturnAirRH = objAirFlowData.get_dblSummerReturnAirRH().ToString();

                unitInfo.winterReturnAirDB = objAirFlowData.get_dblWinterReturnAirDB().ToString();
                unitInfo.winterReturnAirWB = objAirFlowData.get_dblWinterReturnAirWB().ToString();
                unitInfo.winterReturnAirRH = objAirFlowData.get_dblWinterReturnAirRH().ToString();

                unitInfo.winterPreheatSetpointDB = objAirFlowData.get_dblWinterPreheatSetpointDB().ToString();
                unitInfo.winterHeatingSetpointDB = objAirFlowData.get_dblWinterHeatingSetpointDB().ToString();
                unitInfo.summerCoolingSetpointDB = objAirFlowData.get_dblSummerCoolingSetpointDB().ToString();
                unitInfo.summerCoolingSetpointWB = objAirFlowData.get_dblSummerCoolingSetpointWB().ToString();
                unitInfo.summerReheatSetpointDB = objAirFlowData.get_dblSummerReheatSetpointDB().ToString();
            }

            if (objCompItems.objCompOpt != null)
            {
                //dicValues = objCompOpt.get_dicValues();
                unitInfo.OA_FilterModelID = objCompItems.objCompOpt.intOA_FilterModelID;
                unitInfo.finalFilterModelID = objCompItems.objCompOpt.intSA_FinalFilterModelID;
                unitInfo.RA_FilterModelID = objCompItems.objCompOpt.intRA_FilterModelID;
                unitInfo.heatExchCompID = objCompItems.objCompOpt.intHeatExchCompID;
                unitInfo.preheatCompID = objCompItems.objCompOpt.intPreheatCompID;
                unitInfo.coolingCompID = objCompItems.objCompOpt.intCoolingCompID;
                unitInfo.heatingCompID = objCompItems.objCompOpt.intHeatingCompID;
                unitInfo.reheatCompID = objCompItems.objCompOpt.intReheatCompID;

                unitInfo.elecHeaterVoltageID = objCompItems.objCompOpt.intElecHeaterVoltageID;
                unitInfo.preheatElecHeaterInstallationID = objCompItems.objCompOpt.intPreheatElecHeaterInstallationID;
                unitInfo.heatElecHeaterInstallationID = objCompItems.objCompOpt.intHeatElecHeaterInstallationID;
                unitInfo.damperActuatorID = objCompItems.objCompOpt.intDamperAndActuatorID;
                unitInfo.valveTypeID = objCompItems.objCompOpt.intValveTypeID;
                unitInfo.OA_FilterPD = objCompItems.objCompOpt.dblOA_FilterPD.ToString();
                unitInfo.RA_FilterPD = objCompItems.objCompOpt.dblRA_FilterPD.ToString();
                unitInfo.preheatSetpointDB = objCompItems.objCompOpt.dblPreheatSetpointDB.ToString();
                unitInfo.coolingSetpointDB = objCompItems.objCompOpt.dblCoolingSetpointDB.ToString();
                unitInfo.coolingSetpointWB = objCompItems.objCompOpt.dblCoolingSetpointWB.ToString();
                unitInfo.heatingSetpointDB = objCompItems.objCompOpt.dblHeatingSetpointDB.ToString();
                unitInfo.reheatSetpointDB = objCompItems.objCompOpt.dblReheatSetpointDB.ToString();
                unitInfo.coolingFluidTypeID = objCompItems.objCompOpt.intCoolingFluidTypeID;
                unitInfo.coolingFluidConcentrationID = objCompItems.objCompOpt.intCoolingFluidConcentID;
                unitInfo.coolingFluidEntTemp = objCompItems.objCompOpt.dblCoolingFluidEntTemp.ToString();
                unitInfo.coolingFluidLvgTemp = objCompItems.objCompOpt.dblCoolingFluidLvgTemp.ToString();
                unitInfo.heatingFluidTypeID = objCompItems.objCompOpt.intHeatingFluidTypeID;
                unitInfo.heatingFluidConcentrationID = objCompItems.objCompOpt.intHeatingFluidConcentID;
                unitInfo.heatingFluidEntTemp = objCompItems.objCompOpt.dblHeatingFluidEntTemp.ToString();
                unitInfo.heatingFluidLvgTemp = objCompItems.objCompOpt.dblHeatingFluidLvgTemp.ToString();
                unitInfo.refrigSuctionTemp = objCompItems.objCompOpt.dblRefrigSuctionTemp.ToString();
                unitInfo.refrigLiquidTemp = objCompItems.objCompOpt.dblRefrigLiquidTemp.ToString();
                unitInfo.refrigSuperheatTemp = objCompItems.objCompOpt.dblRefrigSuperheatTemp.ToString();
                unitInfo.refrigCondensingTemp = objCompItems.objCompOpt.dblRefrigCondensingTemp.ToString();
                unitInfo.refrigVaporTemp = objCompItems.objCompOpt.dblRefrigVaporTemp.ToString();
                unitInfo.refrigSubcoolingTemp = objCompItems.objCompOpt.dblRefrigSubcoolingTemp.ToString();
            }

            if (objCompItems.objCompOptCustom != null)
            {
                unitInfo.preheatHWC_Cap = objCompItems.objCompOptCustom.dblPreheatHWC_Cap.ToString();
                unitInfo.preheatHWC_FlowRate = objCompItems.objCompOptCustom.dblPreheatHWC_FlowRate.ToString();

                unitInfo.coolingCWC_Cap = objCompItems.objCompOptCustom.dblCoolingCWC_Cap.ToString();
                unitInfo.coolingCWC_FlowRate = objCompItems.objCompOptCustom.dblCoolingCWC_FlowRate.ToString();

                unitInfo.heatingHWC_Cap = objCompItems.objCompOptCustom.dblHeatingHWC_Cap.ToString();
                unitInfo.heatingHWC_FlowRate = objCompItems.objCompOptCustom.dblHeatingHWC_FlowRate.ToString();

                unitInfo.reheatHWC_Cap = objCompItems.objCompOptCustom.dblReheatHWC_Cap.ToString();
                unitInfo.reheatHWC_FlowRate = objCompItems.objCompOptCustom.dblReheatHWC_FlowRate.ToString();
            }

            if (objLayout.objLayoutOpt != null)
            {
                //dicValues = objCompOpt.get_dicValues();
                unitInfo.handingID = objLayout.objLayoutOpt.intHandingID;
                unitInfo.preheatCoilHandingID = objLayout.objLayoutOpt.intPreheatCoilHandingID;
                unitInfo.coolingCoilHandingID = objLayout.objLayoutOpt.intCoolingCoilHandingID;
                unitInfo.heatingCoilHandingID = objLayout.objLayoutOpt.intHeatingCoilHandingID;
                unitInfo.supplyAirOpeningID = objLayout.objLayoutOpt.intSupplyAirOpeningID;
                unitInfo.supplyAirOpening = objLayout.objLayoutOpt.strSupplyAirOpening;
                unitInfo.exhaustAirOpeningID = objLayout.objLayoutOpt.intExhaustAirOpeningID;
                unitInfo.exhaustAirOpening = objLayout.objLayoutOpt.strExhaustAirOpening;
                unitInfo.outdoorAirOpeningID = objLayout.objLayoutOpt.intOutdoorAirOpeningID;
                unitInfo.outdoorAirOpening = objLayout.objLayoutOpt.strOutdoorAirOpening;
                unitInfo.returnAirOpeningID = objLayout.objLayoutOpt.intReturnAirOpeningID;
                unitInfo.returnAirOpening = objLayout.objLayoutOpt.strReturnAirOpening;
            }

            DataTable dtControls = ClsDB.get_dtLiveEnabled(ClsDBT.strSelControlsPreference, unitInfo.controlsPreferenceID);

            if (unitInfo.productTypeId == ClsID.intProdTypeVentumLiteID)
            {
                dtControls = dtControls.Select("[id]='" + ClsID.intControlPrefByOthersID.ToString() + "'").CopyToDataTable();
            }
            else if (Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_External || Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_ExternalSpecial)
            {
                dtControls = dtControls.Select("[id]<>'" + ClsID.intControlPrefByOthersID.ToString() + "'").CopyToDataTable();
            }

            unitInfo.controlsPreference = dtControls;
            unitInfo.damperAndActuator = ClsDB.get_dtLiveEnabled(ClsDBT.strSelDamperActuator, unitInfo.damperActuatorID);

            switch (Convert.ToInt32(unitInfo.productTypeId))
            {
                case ClsID.intProdTypeNovaID:
                    //lblHanding = "Fan Placement";
                    if (Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_External)
                    {
                        unitInfo.BypassVisible = false;
                        unitInfo.BypassChecked = false;
                    }
                    else
                    {
                        unitInfo.BypassVisible = true;
                    }

                    unitInfo.voltageSPPChecked = false;
                    unitInfo.voltageSPPVisible = false;
                    break;
                case ClsID.intProdTypeVentumID:
                    //lblHanding = "Control Panel Placement";
                    unitInfo.BypassChecked = true; //Bypass is checked by default for Ventum
                    unitInfo.voltageSPPChecked = false;
                    unitInfo.voltageSPPVisible = false;
                    break;
                case ClsID.intProdTypeVentumLiteID:
                    //lblHanding = "Control Panel Placement";
                    unitInfo.BypassVisible = false;
                    unitInfo.BypassChecked = false;
                    unitInfo.voltageSPPChecked = false;
                    unitInfo.voltageSPPVisible = false;
                    break;
                case ClsID.intProdTypeTerraID:
                    //lblHanding = "Control Panel Placement";
                    unitInfo.BypassVisible = false;
                    unitInfo.BypassChecked = false;
                    unitInfo.voltageSPPVisible = true;
                    break;
                default:
                    break;
            }

            unitInfo.handing = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding, unitInfo.handingID);
            unitInfo.preheatHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding, unitInfo.preheatCoilHandingID);
            unitInfo.coolingCoilHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding, unitInfo.coolingCoilHandingID);
            unitInfo.heatingCoilHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding, unitInfo.heatingCoilHandingID);
            unitInfo.valueType = ClsDB.get_dtLiveEnabled(ClsDBT.strSelValveType, unitInfo.valveTypeID);


            return unitInfo;
        }

        public static dynamic GetInitUnitInfo(int jobId, int unitModelId, int productTypeId, int intUAL)
        {
            dynamic initUnitInfo = new ExpandoObject();
            var Session = HttpContext.Current.Session;

            DataTable dtJob = ClsDB.GetSavedJob(jobId);

            ClsProjectInfo objProjectInfo = new ClsProjectInfo(jobId);
            initUnitInfo.altitude = objProjectInfo.intAltitude.ToString();

            initUnitInfo.summerOutdoorAirDB = objProjectInfo.dblSummerOutdoorAirDB.ToString();
            initUnitInfo.summerOutdoorAirWB = objProjectInfo.dblSummerOutdoorAirWB.ToString();
            initUnitInfo.summerOutdoorAirRH = objProjectInfo.dblSummerOutdoorAirRH.ToString();

            initUnitInfo.winterOutdoorAirDB = objProjectInfo.dblWinterOutdoorAirDB.ToString();
            initUnitInfo.winterOutdoorAirWB = objProjectInfo.dblWinterOutdoorAirWB.ToString();
            initUnitInfo.winterOutdoorAirRH = objProjectInfo.dblWinterOutdoorAirRH.ToString();

            initUnitInfo.summerReturnAirDB = objProjectInfo.dblSummerReturnAirDB.ToString();
            initUnitInfo.summerReturnAirWB = objProjectInfo.dblSummerReturnAirWB.ToString();
            initUnitInfo.summerReturnAirRH = objProjectInfo.dblSummerReturnAirRH.ToString();

            initUnitInfo.winterReturnAirDB = objProjectInfo.dblWinterReturnAirDB.ToString();
            initUnitInfo.winterReturnAirDB = objProjectInfo.dblWinterReturnAirDB.ToString();
            initUnitInfo.winterReturnAirWB = objProjectInfo.dblWinterReturnAirWB.ToString();
            initUnitInfo.winterReturnAirRH = objProjectInfo.dblWinterReturnAirRH.ToString();

            initUnitInfo.location = ClsDB.get_dtLiveEnabled(ClsDBT.strSelGeneralLocation);
            initUnitInfo.locationId = initUnitInfo.location.Rows[0]["id"];
            initUnitInfo.orientation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelGeneralOrientation);
            initUnitInfo.orientationId = initUnitInfo.orientation.Rows[0]["id"];
            initUnitInfo.unitType = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitType);
            initUnitInfo.unitTypeId = initUnitInfo.unitType.Rows[0]["id"];
            initUnitInfo.controlsPreference = ClsDB.get_dtLiveEnabled(ClsDBT.strSelControlsPreference);
            initUnitInfo.controlsPreferenceId = initUnitInfo.controlsPreference.Rows[0]["id"];
            initUnitInfo.qaFilter = ClsDB.get_dtLiveEnabled(ClsDBT.strSelFilterModel, "outdoor_air", 1, 0);
            initUnitInfo.qaFilterId = ClsID.intFilterModel_2in_85_MERV_13_ID;

            switch (unitModelId)
            {
                case ClsID.intUnitTypeERV_ID:
                case ClsID.intUnitTypeHRV_ID:
                    initUnitInfo.raFilter = ClsDB.get_dtLiveEnabled(ClsDBT.strSelFilterModel, "return_air", 1, 0);
                    break;
                default:
                    initUnitInfo.raFilter = ClsDB.get_dtLive(ClsDBT.strSelFilterModel, ClsID.intFilterModel_NA_ID).Copy();
                    break;
            }
            initUnitInfo.raFilterId = initUnitInfo.raFilter.Rows[0]["id"];

            DataTable dtHeatExchComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitHeatExchanger, 0);
            DataTable dtCoolingComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating, 0).Copy();
            DataTable dtHeatingComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating, 0).Copy();
            DataTable dtReheatComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating, 0).Copy();


            initUnitInfo.preheatComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating, 0, "display_order, id ASC").Copy();
            initUnitInfo.preheatCompId = initUnitInfo.preheatComp.Rows[0]["id"];
            initUnitInfo.heatExchComp = ClsTS.get_dtDataFromImportRows(dtHeatExchComp, "erv", 1);
            initUnitInfo.heatExchCompId = initUnitInfo.heatExchComp.Rows[0]["id"];
            initUnitInfo.coolingComp = ClsTS.get_dtDataFromImportRows(dtCoolingComp, "erv_cooling", 1);
            initUnitInfo.coolingCompId = initUnitInfo.coolingComp.Rows[0]["id"];
            initUnitInfo.heatingComp = ClsTS.get_dtDataFromImportRows(dtHeatingComp, "erv_heating", 1);
            initUnitInfo.heatingCompId = initUnitInfo.heatingComp.Rows[0]["id"];
            initUnitInfo.reheatComp = ClsTS.get_dtDataFromImportRows(dtReheatComp, "erv_reheat", 1);
            initUnitInfo.reheatCompId = initUnitInfo.reheatComp.Rows[0]["id"];



            initUnitInfo.damperActuator = ClsDB.get_dtLiveEnabled(ClsDBT.strSelDamperActuator);
            initUnitInfo.elecHeaderVoltage = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricalVoltage);
            initUnitInfo.elecHeaderInstallation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricHeaterInstallation);

            switch (productTypeId)
            {
                case ClsID.intProdTypeNovaID:
                    //lblHanding = "Fan Placement";
                    if (intUAL == ClsID.intUAL_External)
                    {
                        initUnitInfo.BypassVisible = false;
                        initUnitInfo.BypassChecked = false;
                    }
                    else
                    {
                        initUnitInfo.BypassVisible = true;
                    }

                    initUnitInfo.voltageSPPChecked = false;
                    initUnitInfo.voltageSPPVisible = false;
                    break;
                case ClsID.intProdTypeVentumID:
                    //lblHanding = "Control Panel Placement";
                    initUnitInfo.BypassChecked = true; //Bypass is checked by default for Ventum
                    initUnitInfo.voltageSPPChecked = false;
                    initUnitInfo.voltageSPPVisible = false;
                    break;
                case ClsID.intProdTypeVentumLiteID:
                    //lblHanding = "Control Panel Placement";
                    initUnitInfo.BypassVisible = false;
                    initUnitInfo.BypassChecked = false;
                    initUnitInfo.voltageSPPChecked = false;
                    initUnitInfo.voltageSPPVisible = false;
                    break;
                case ClsID.intProdTypeTerraID:
                    //lblHanding = "Control Panel Placement";
                    initUnitInfo.BypassVisible = false;
                    initUnitInfo.BypassChecked = false;
                    initUnitInfo.voltageSPPVisible = true;
                    break;
                default:
                    break;
            }


            //initUnitInfo.unitModel = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitModel); unitModelId

            string strModelVoltageLinkTable = "";

            switch (productTypeId)
            {
                case ClsID.intProdTypeNovaID:
                    strModelVoltageLinkTable = ClsDBT.strSelNovaUnitModelVoltageLink;
                    break;
                default:
                    break;
            }


            DataTable dtVoltage = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricalVoltage);
            DataTable dtLink = ClsDB.get_dtLive(strModelVoltageLinkTable, "unit_model_id", unitModelId);

            if (productTypeId == ClsID.intProdTypeNovaID && (intUAL == ClsID.intUAL_External || intUAL == ClsID.intUAL_ExternalSpecial))
            {
                if (unitModelId == ClsID.intNovaUnitModelID_B20IN || unitModelId == ClsID.intNovaUnitModelID_B22OU)
                {
                    dtVoltage = dtVoltage.Select("[id] <> '" + ClsID.intElectricVoltage_208V_1Ph_60HzID.ToString() + "'").CopyToDataTable();
                }
            }
            else if (productTypeId == ClsID.intProdTypeTerraID )
            {
                dtVoltage = dtVoltage.Select("[terra_2] = '1'").CopyToDataTable();
            }

            DataTable dt = ClsTS.get_dtSortedASC(dtVoltage, "id");
            dtLink = ClsTS.get_dtSortedASC(dtLink, "voltage_id");
            int intID = 0;
            int intLinkID = 0;

            DataTable dtSelected = new DataTable();
            dtSelected.Columns.Add("id", typeof(int));
            dtSelected.Columns.Add("items", typeof(string));


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                intID = Convert.ToInt32(dt.Rows[i]["id"]);
                for (int j = 0; j < dtLink.Rows.Count; j++)
                {
                    intLinkID = Convert.ToInt32(dtLink.Rows[j]["voltage_id"]);

                    if (intID == intLinkID)
                    {
                        DataRow dr = dtSelected.NewRow();
                        dr["id"] = Convert.ToInt32(dt.Rows[i]["id"]);
                        dr["items"] = dt.Rows[i]["items"].ToString();

                        dtSelected.Rows.Add(dr);
                        break;
                    }

                    if (intLinkID > intID)
                    {
                        break;
                    }
                }
            }

            DataTable dtUnitModelLink = ClsDB.get_dt(ClsDBT.strSelNovaUnitModelLocOriLink);

            initUnitInfo.voltage = dtSelected;
            initUnitInfo.preheatCoilHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding);
            initUnitInfo.coolingCoilHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding);
            initUnitInfo.heatingCoilHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding);
            initUnitInfo.valueType = ClsDB.get_dtLiveEnabled(ClsDBT.strSelValveType);
            initUnitInfo.unitModel = ClsDB.get_dt(ClsDBT.strSelNovaUnitModel);
            dynamic initFieldData = new ExpandoObject();
            initFieldData.UAL = intUAL;
            initFieldData.location = initUnitInfo.location.Rows[0]["id"];
            initFieldData.orientation = initUnitInfo.orientation.Rows[0]["id"];
            initFieldData.unitTypeId = initUnitInfo.location.Rows[0]["id"];
            initFieldData.productTypeId = productTypeId;
            initFieldData.unitModelId = initUnitInfo.unitModel.Rows[0]["id"];
            initFieldData.summerSupplyAirCFM = "325";
            initFieldData.summerReturnAirCFM = "325";
            initFieldData.supplyAirESP = "0.75";
            initFieldData.exhaustAirESP = "0.75";
            initFieldData.byPass = false;
            initFieldData.voltageId = 0;

            initUnitInfo.mainInitData = txbSummerSupplyAirCFM_Changed(initFieldData);

            return initUnitInfo;
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

        public static dynamic GetPreheatElectricHeader(dynamic fieldInfo)
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

        public static dynamic GetElectricHeaterVoltage(dynamic fieldInfo)
        {
            dynamic electricHeaderVoltageInfo = new ExpandoObject();
            DataTable dtElecHeaterVoltage = new DataTable();
            int intProductTypeID = Convert.ToInt32(fieldInfo.productTypeId);
            int intUnitModelId = Convert.ToInt32(fieldInfo.unitModel);
            int intLocationId = Convert.ToInt32(fieldInfo.location);
            int preheatComp = Convert.ToInt32(fieldInfo.preheatComp);
            int heatingComp = Convert.ToInt32(fieldInfo.heatingComp);
            int reheatComp = Convert.ToInt32(fieldInfo.reheatComp);
            int unitVoltage = Convert.ToInt32(fieldInfo.unitVoltage);
            int intElecHeaterVoltageID = Convert.ToInt32(fieldInfo.elecHeaterVoltageID);
            int intPreheatElecHeaterInstallationID = Convert.ToInt32(fieldInfo.elecHeaderInstallation);


            if (preheatComp == ClsID.intCompElecHeaterID ||
                heatingComp == ClsID.intCompElecHeaterID ||
                reheatComp == ClsID.intCompElecHeaterID)
            {
                electricHeaderVoltageInfo.Visible = true;

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
                    electricHeaderVoltageInfo.data = dtElecHeaterVoltage;

                    if (bol208V_1Ph)
                    {
                        electricHeaderVoltageInfo.selectedValue = ClsID.intElectricVoltage_208V_1Ph_60HzID;
                    }
                    else
                    {
                        electricHeaderVoltageInfo.selectedValue = ClsID.intElectricVoltage_208V_3Ph_60HzID;
                    }
                }
            }
            else
            {
                if (intProductTypeID == ClsID.intProdTypeVentumLiteID)
                {
                    dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater_3", 1, intElecHeaterVoltageID).Copy();
                    electricHeaderVoltageInfo.data = dtElecHeaterVoltage;
                    electricHeaderVoltageInfo.selectedValue = unitVoltage;
                    //ClsWFC.get_ddlLockItem(ddlElecHeaterVoltage, ClsID.intElectricVoltage_208V_1Ph_60HzID);
                    electricHeaderVoltageInfo.Enabled = false;
                }
                else
                {
                    //ddlElecHeaterVoltage.Items.Insert(0, new ListItem("NA", "0"));
                    //ddlElecHeaterVoltage.SelectedIndex = 0;
                    dtElecHeaterVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, "electric_heater", 1, intElecHeaterVoltageID).Copy();
                    electricHeaderVoltageInfo.data = dtElecHeaterVoltage;
                    electricHeaderVoltageInfo.selectedValue = ClsID.intElectricVoltage_208V_3Ph_60HzID;
                }

                electricHeaderVoltageInfo.Visible = false;
            }

            return electricHeaderVoltageInfo;
        }

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

        public static dynamic txbSummerSupplyAirCFM_Changed(dynamic fieldInfo)
        {
           if (!ClsNumber.IsNumber(fieldInfo.summerSupplyAirCFM.ToString()))
            {
                return 0;
            }

            dynamic returnInfo = new ExpandoObject();
            int intUAL = Convert.ToInt32(fieldInfo.UAL);
            int intProductTypeID = Convert.ToInt32(fieldInfo.productTypeId);
            String summerSupplyAirCFM = fieldInfo.summerSupplyAirCFM;
            Boolean byPass = fieldInfo.byPass;

            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1)
                {
                    if (Convert.ToInt32(summerSupplyAirCFM) < intNOVA_MIN_CFM)
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
                    if (byPass)
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
                    if (byPass)
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
                    if (byPass)
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
                    if (byPass)
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
                    if (byPass)
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
                    if (byPass)
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
            fieldInfo.summerSupplyAirCFM = summerSupplyAirCFM;
            fieldInfo.summerReturnAirCFM = summerSupplyAirCFM;
            returnInfo.summerSupplyAirCFM = summerSupplyAirCFM;
            returnInfo.summerReturnAirCFM = summerSupplyAirCFM;
            returnInfo.orientationInfo = getOrientation(fieldInfo);
            returnInfo.orientationId = returnInfo.orientationInfo.Rows[0]["id"];
            fieldInfo.orientation = returnInfo.orientationId;
            returnInfo.modelInfo = getModel(fieldInfo);
            returnInfo.modelId = returnInfo.modelInfo.Rows[0]["id"];
            fieldInfo.unitModelId = returnInfo.modelId;
            returnInfo.voltageInfo = getVoltage(fieldInfo);
            //returnInfo.supplyAirOpening = getSupplyAirOpening(fieldInfo);

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


        public static dynamic txbSupplyAirESP_Changed(dynamic fieldInfo)
        {
            if (!ClsNumber.IsNumber(fieldInfo.supplyAirESP.ToString()))
            {
                return 0;
            }

            dynamic returnInfo = new ExpandoObject();

            int intProductTypeID = Convert.ToInt32(fieldInfo.productTypeId);
            int intUnitModelID = Convert.ToInt32(fieldInfo.unitModeldId);
            String supplyAirESP = fieldInfo.supplyAirESP;

            if (intProductTypeID == ClsID.intProdTypeNovaID)
            {
                if (intUnitModelID == ClsID.intNovaUnitModelID_A16IN || intUnitModelID == ClsID.intNovaUnitModelID_B20IN ||
                    intUnitModelID == ClsID.intNovaUnitModelID_A18OU || intUnitModelID == ClsID.intNovaUnitModelID_B22OU)
                {
                    if (Convert.ToDouble(supplyAirESP) > 2.0d)
                    {
                        returnInfo.supplyAirESP = "2.0";
                    }

                }
                else if (Convert.ToDouble(supplyAirESP) > 3.0d)
                {
                    returnInfo.supplyAirESP = "3.0";
                }
                else
                {
                    returnInfo.supplyAirESP = supplyAirESP;
                }
            }
            return returnInfo;
       }


        public static dynamic txbExhaustAirESP_Changed(dynamic fieldInfo)
        {
            if (!ClsNumber.IsNumber(fieldInfo.exhaustAirESP.ToString()))
            {
                return 0;
            }

            dynamic returnInfo = new ExpandoObject();

            int intProductTypeID = Convert.ToInt32(fieldInfo.productTypeId);
            int intUnitModelID = Convert.ToInt32(fieldInfo.unitModeldId);
            String exhaustAirESP = fieldInfo.exhaustAirESP;

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

        private static DataTable getOrientation(dynamic fieldInfo)
        {
            int productTypeId = Convert.ToInt32(fieldInfo.productTypeId);
            int unitTypeId = Convert.ToInt32(fieldInfo.unitTypeId);
            int locationId = Convert.ToInt32(fieldInfo.location);
            int orientationId = Convert.ToInt32(fieldInfo.orientation);
            String summerSupplyAirCFM = fieldInfo.summerSupplyAirCFM.ToString();
            DataTable dtLocOri = ClsDB.get_dtLive(ClsDBT.strSelLocOriLink);
            dtLocOri = dtLocOri.Select("[product_type_id]=" + productTypeId).CopyToDataTable();
            dtLocOri = dtLocOri.Select("[unit_type_id]=" + unitTypeId).CopyToDataTable();
            dtLocOri = dtLocOri.Select("[location_id]=" + locationId).CopyToDataTable();

            DataTable dtOrientation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelGeneralOrientation, Convert.ToInt32(orientationId));
            dtOrientation = ClsTS.get_dtFromLink(dtOrientation, "orientation_id", dtLocOri, "max_cfm");

            if (productTypeId == ClsID.intProdTypeNovaID)
            {
                dtOrientation = dtOrientation.Select("[max_cfm] >= '" + summerSupplyAirCFM + "'").CopyToDataTable();
            }

            return dtOrientation;
        }

         private static dynamic getVoltage(dynamic filedData)
         {
            int intProductTypeID = Convert.ToInt32(filedData.productTypeId);
            int intUnitVoltageID = Convert.ToInt32(filedData.voltageId);
            int intUnitModelID = Convert.ToInt32(filedData.unitModelId);
            int intUAL= Convert.ToInt32(filedData.UAL);
            dynamic returnInfo = new ExpandoObject();

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

            dtVoltage = ClsTS.get_dtSortedASC(dtVoltage, "id");
            dtLink = ClsTS.get_dtSortedASC(dtLink, "voltage_id");
            int intID = 0;
            int intLinkID = 0;

            DataTable dtSelected = new DataTable();
            dtSelected.Columns.Add("id", typeof(int));
            dtSelected.Columns.Add("items", typeof(string));


            for (int i = 0; i < dtVoltage.Rows.Count; i++)
            {
                intID = Convert.ToInt32(dtVoltage.Rows[i]["id"]);
                for (int j = 0; j < dtLink.Rows.Count; j++)
                {
                    intLinkID = Convert.ToInt32(dtLink.Rows[j]["voltage_id"]);

                    if (intID == intLinkID)
                    {
                        DataRow dr = dtSelected.NewRow();
                        dr["id"] = Convert.ToInt32(dtVoltage.Rows[i]["id"]);
                        dr["items"] = dtVoltage.Rows[i]["items"].ToString();

                        dtSelected.Rows.Add(dr);
                        break;
                    }

                    if (intLinkID > intID)
                    {
                        break;
                    }
                }
            }


            returnInfo.selectedVoltageId = dtSelected.Rows[0]["id"];
            returnInfo.data = dtSelected;

            return returnInfo;
        }

        private static DataTable getModel(dynamic fieldInfo)
        {
            int locationId = Convert.ToInt32(fieldInfo.location);
            int orientationId = Convert.ToInt32(fieldInfo.orientation);
            //int intUnitModelID = Convert.ToInt32(fieldInfo.unitModelId);
            int intUnitModelID = 0;
            int summerSupplyAirCFM = Convert.ToInt32(fieldInfo.summerSupplyAirCFM);
            Boolean byPass = fieldInfo.byPass;

            DataTable dtUnitModel = new DataTable();

            if (locationId > -1 && orientationId > -1)
            {
                int intUAL = Convert.ToInt32(fieldInfo.UAL);

                int intProductTypeID = Convert.ToInt32(fieldInfo.productTypeId);
                
                switch (intProductTypeID)
                {
                    case ClsID.intProdTypeNovaID:
                        DataTable dtUnitModelLink = ClsDB.get_dt(ClsDBT.strSelNovaUnitModelLocOriLink);

                        dtUnitModelLink = dtUnitModelLink.Select("[location_id]='" + locationId.ToString() + "'").CopyToDataTable();
                        dtUnitModelLink = dtUnitModelLink.Select("[orientation_id]='" + orientationId.ToString() + "'").CopyToDataTable();

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

                        if (byPass)
                        {
                            var drUnitModelBypass = dtUnitModel.AsEnumerable().Where(x => (Convert.ToInt32(x["bypass_exist"]) == 1));
                            DataTable dtUnitModelBypass = drUnitModelBypass.Any() ? drUnitModelBypass.CopyToDataTable() : new DataTable();

                            if (dtUnitModelBypass.Rows.Count > 0)
                            {
                                dtUnitModel = dtUnitModel.Select("[bypass_exist]='1'").CopyToDataTable();
                                //divUnitBypass.Visible = true;

                                if (orientationId == ClsID.intOrientationHorizontalID)
                                {
                                    var drUnitModelBypassHorUnit = dtUnitModel.AsEnumerable().Where(x => (Convert.ToInt32(x["bypass_exist_horizontal_unit"]) == 1));
                                    DataTable dtUnitModelBypassHorUnit = drUnitModelBypassHorUnit.Any() ? drUnitModelBypassHorUnit.CopyToDataTable() : new DataTable();

                                    if (dtUnitModelBypassHorUnit.Rows.Count > 0)
                                    {
                                        dtUnitModel = dtUnitModel.Select("[bypass_exist_horizontal_unit]='1'").CopyToDataTable();
                                    }
                                    else
                                    {
                                        byPass = false;
                                    }
                                }

                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return dtUnitModel;
        }
        private static DataTable getSupplyAirOpening(dynamic fieldInfo)
        {
            int intUnitTypeId = Convert.ToInt32(fieldInfo.unitTypeId);
            int intproductTypeId = Convert.ToInt32(fieldInfo.productTypeId);
            int locationId = Convert.ToInt32(fieldInfo.location);
            int orientationId = Convert.ToInt32(fieldInfo.orientation);
            int coolingCompId = Convert.ToInt32(fieldInfo.coolingComp);
            int heatingCompId = Convert.ToInt32(fieldInfo.heatingComp);
            int reheatCompId = Convert.ToInt32(fieldInfo.reheatComp);
            int intSupplyAirOpeningID = Convert.ToInt32(fieldInfo.supplyAirOpeningId);
            String strSupplyAirOpening = fieldInfo.supplyAirOpening;

            DataTable dtLink = new DataTable();

            if (intUnitTypeId == ClsID.intUnitTypeERV_ID || intUnitTypeId == ClsID.intUnitTypeHRV_ID)
            {
                dtLink = ClsDB.get_dtLive(ClsDBT.strSelOrientOpeningsERV_SA_Link, "product_type_id", intproductTypeId).Copy();
                dtLink = ClsTS.get_dtDataFromImportRows(dtLink, "location_id", locationId);
                dtLink = ClsTS.get_dtDataFromImportRows(dtLink, "orientation_id", orientationId);

                DataTable dtSelectionTable = ClsDB.get_dtLiveEnabled(ClsDBT.strSelOpeningsERV_SA, "items", strSupplyAirOpening).Copy();
                dtSelectionTable = ClsTS.get_dtDataFromImportRows(dtSelectionTable, "product_type_id", intproductTypeId);


                return dtSelectionTable;
            }
            else if (intUnitTypeId == ClsID.intUnitTypeAHU_ID)
            {
                return ClsDB.get_dtLiveEnabled(ClsDBT.strSelOpeningsFC_SA, intSupplyAirOpeningID);
            }

            return new DataTable();
        }
    }
}