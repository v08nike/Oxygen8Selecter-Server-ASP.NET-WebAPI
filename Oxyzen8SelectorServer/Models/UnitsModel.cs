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
        public dynamic GetUnitInfo(int jobId, int unitId)
        {
            dynamic unitInfo = new ExpandoObject();
            DataTable dtJob = ClsDB.GetSavedJob(Convert.ToInt32(jobId));

            ClsProjectInfo objProjectInfo = new ClsProjectInfo(Convert.ToInt32(jobId));
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

            ClsGeneral objGeneral = new ClsGeneral(jobId, unitId);
            ClsAirFlowData objAirFlowData = new ClsAirFlowData(jobId, unitId);
            ClsComponentItems objCompItems = new ClsComponentItems(jobId, unitId);
            ClsLayout objLayout = new ClsLayout(jobId, unitId);

            if (objGeneral != null)
            {
                unitInfo.tag = objGeneral.strTag;
                unitInfo.qty = objGeneral.intQty.ToString();

                unitInfo.productTypeId = objGeneral.intProductTypeID.ToString();
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
            //else if (Convert.ToInt32(hfUAL.Value) == ClsID.intUAL_External || Convert.ToInt32(hfUAL.Value) == ClsID.intUAL_ExternalSpecial)
            //{
            //    dtControls = dtControls.Select("[id]<>'" + ClsID.intControlPrefByOthersID.ToString() + "'").CopyToDataTable();
            //}

            return unitInfo;
        }

        public static DataTable getUnitListByJobId(int jobID)
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