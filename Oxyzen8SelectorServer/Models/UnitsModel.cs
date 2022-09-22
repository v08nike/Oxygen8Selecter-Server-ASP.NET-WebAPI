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
        public static bool DeleteUnitById(int jobId, int unitId)
        {
            return ClsDB.DeleteUnit(jobId, unitId);
        }


        public static bool SaveUnitInfo(dynamic unitInfo)
        {
            DataTable dt = ClsDB.SaveGeneral(Convert.ToInt32(unitInfo.jobId),
                                            Convert.ToInt32(unitInfo.unitId),
                                            Convert.ToInt32(unitInfo.tag.ToUpper()),
                                            Convert.ToInt32(unitInfo.qty),
                                            Convert.ToInt32(unitInfo.productTypeId),
                                            Convert.ToInt32(unitInfo.unitTypeId),
                                            Convert.ToInt32(unitInfo.byPassId),
                                            Convert.ToInt32(unitInfo.unitModelId),
                                            Convert.ToInt32(unitInfo.selectionTypeId),
                                            Convert.ToInt32(unitInfo.locationId),
                                            Convert.ToInt32(unitInfo.downshotId),
                                            Convert.ToInt32(unitInfo.OrientationId),
                                            Convert.ToInt32(unitInfo.controlsPreferenceId),
                                            Convert.ToDouble(unitInfo.unitHeight),
                                            Convert.ToDouble(unitInfo.unitWidth),
                                            Convert.ToDouble(unitInfo.unitLength),
                                            Convert.ToDouble(unitInfo.unitWeight),
                                            Convert.ToInt32(unitInfo.unitVoltageId),
                                            Convert.ToInt32(unitInfo.voltageSPPId),
                                            Convert.ToInt32(unitInfo.attUnitModelSelectedId),
                                            0d);

            unitInfo.unitId = dt.Rows[0]["UnitNo"].ToString();

            ClsDB.SaveAirFlow(Convert.ToInt32(unitInfo.jobId),
                                Convert.ToInt32(unitInfo.unitId),
                                Convert.ToInt32(unitInfo.altitude),
                                Convert.ToInt32(unitInfo.summerSupplyAirCFM),
                                Convert.ToInt32(unitInfo.summerReturnAirCFM),
                                Convert.ToInt32(unitInfo.summerSupplyAirCFM),
                                Convert.ToInt32(unitInfo.summerReturnAirCFM),
                                Math.Round(Convert.ToDouble(unitInfo.summerOutdoorAirDB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.summerOutdoorAirWB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.summerOutdoorAirRH), 1),
                                Math.Round(Convert.ToDouble(unitInfo.winterOutdoorAirDB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.winterOutdoorAirWB), 3),
                                Math.Round(Convert.ToDouble(unitInfo.winterOutdoorAirRH), 1),
                                Math.Round(Convert.ToDouble(unitInfo.summerReturnAirDB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.summerReturnAirWB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.summerReturnAirRH), 1),
                                Math.Round(Convert.ToDouble(unitInfo.winterReturnAirDB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.winterReturnAirWB), 1),
                                Math.Round(Convert.ToDouble(unitInfo.winterReturnAirRH), 1),
                                Convert.ToDouble(unitInfo.winterPreheatSetpointDB),
                                Convert.ToDouble(unitInfo.winterHeatingSetpointDB),
                                Convert.ToDouble(unitInfo.summerCoolingSetpointDB),
                                Convert.ToDouble(unitInfo.summerCoolingSetpointWB),
                                Convert.ToDouble(unitInfo.summerReheatSetpointDB),
                                Convert.ToDouble(unitInfo.supplyAirESP),
                                Convert.ToDouble(unitInfo.exhaustAirESP));

            ClsCompOpt objCompOpt = new ClsCompOpt
            {
                intJobID = Convert.ToInt32(unitInfo.jobId),
                intUnitNo = Convert.ToInt32(unitInfo.unitId),
                intUnitTypeID = Convert.ToInt32(unitInfo.unitTypeId),
                //intUnitModelID = Convert.ToInt32(id_list.Attributes[clsID.strAttUnitModelID]),
                //intVoltageID = Convert.ToInt32(id_list.Attributes[clsID.strAttUnitVoltageID]),
                intUnitModelID = Convert.ToInt32(unitInfo.unitModelId),
                intVoltageID = Convert.ToInt32(unitInfo.unitVoltageId),
                intOA_FilterModelID = Convert.ToInt32(unitInfo.OA_FilterModelId),
                intSA_FinalFilterModelID = 0,
                intRA_FilterModelID = Convert.ToInt32(unitInfo.RA_FilterModelId),
                intHeatExchCompID = Convert.ToInt32(unitInfo.heatExchCompId),
                intPreheatCompID = Convert.ToInt32(unitInfo.preheatCompId),
                intCoolingCompID = Convert.ToInt32(unitInfo.coolingCompId),
                intHeatingCompID = Convert.ToInt32(unitInfo.heatingCompId),
                intReheatCompID = Convert.ToInt32(unitInfo.reheatCompId),
                intIsHeatPump = unitInfo.heatPump,
                intIsDehumidification = unitInfo.dehumidification,
                intElecHeaterVoltageID = Convert.ToInt32(unitInfo.elecHeaterVoltageId),
                intPreheatElecHeaterInstallationID = Convert.ToInt32(unitInfo.preheatElecHeaterInstallationId),
                intHeatElecHeaterInstallationID = Convert.ToInt32(unitInfo.heatElecHeaterInstallationId),
                intDamperAndActuatorID = Convert.ToInt32(unitInfo.damperAndActuatorId),
                intIsValveAndActuatorIncluded = unitInfo.valveAndActuator,
                intValveTypeID = Convert.ToInt32(unitInfo.valveTypeId),
                intIsDrainPan = unitInfo.drainPan,
                dblOA_FilterPD = Convert.ToDouble(unitInfo.OA_FilterPD),
                dblRA_FilterPD = Convert.ToDouble(unitInfo.RA_FilterPD),
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

            //objCompOpt = new clsComponentItems(objCompOptData);
            ClsDB.SaveCompOpt(objCompOpt);
            var Session = HttpContext.Current.Session;


            if (Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_Admin ||
                Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_IntAdmin ||
                Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_IntLvl_1 ||
                Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_IntLvl_2)
            {

                ClsCompOptCustom objCompOptCustom = new ClsCompOptCustom
                {
                    intJobID = Convert.ToInt32(unitInfo.uobId),
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
                intReturnAirOpeningID = Convert.ToInt32(unitInfo.returnAirOpening),
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

        public static dynamic GetInitUnitInfo(int jobId, int unitModelId, int productTypeId)
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
            initUnitInfo.orientation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelGeneralOrientation);
            initUnitInfo.unitType = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitType);
            initUnitInfo.controlsPreference = ClsDB.get_dtLiveEnabled(ClsDBT.strSelControlsPreference);
            initUnitInfo.qaFilter = ClsDB.get_dtLiveEnabled(ClsDBT.strSelFilterModel, "outdoor_air", "1");
            initUnitInfo.raFilter = ClsDB.get_dtLiveEnabled(ClsDBT.strSelFilterModel, "return_air", "1");

            initUnitInfo.preheatComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating);
            initUnitInfo.heatExchComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitHeatExchanger);
            initUnitInfo.coolingComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating);
            initUnitInfo.heatingComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating);
            initUnitInfo.reheatComp = ClsDB.get_dtLiveEnabled(ClsDBT.strSelUnitCoolingHeating);


            initUnitInfo.damperActuator = ClsDB.get_dtLiveEnabled(ClsDBT.strSelDamperActuator);
            initUnitInfo.elecHeaderVoltage = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricalVoltage);
            initUnitInfo.elecHeaderInstallation = ClsDB.get_dtLiveEnabled(ClsDBT.strSelElectricHeaterInstallation);

            switch (productTypeId)
            {
                case ClsID.intProdTypeNovaID:
                    //lblHanding = "Fan Placement";
                    if (Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_External)
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

            if (productTypeId == ClsID.intProdTypeNovaID && (Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_External || Convert.ToInt32(Session["UAL"]) == ClsID.intUAL_ExternalSpecial))
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

            initUnitInfo.voltage = dtSelected;
            initUnitInfo.preheatCoilHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding);
            initUnitInfo.coolingCoilHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding);
            initUnitInfo.heatingCoilHanding = ClsDB.get_dtLiveEnabled(ClsDBT.strSelHanding);
            initUnitInfo.valueType = ClsDB.get_dtLiveEnabled(ClsDBT.strSelValveType);

            return initUnitInfo;
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

    }
}