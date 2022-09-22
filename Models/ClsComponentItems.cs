using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsComponentItems
    {
        private int intJobID = 0;
        private int intUnitNo = 0;
        //private int intVoltageID = 0;   //Used to select fan model / VoltageID is saved in Electrical Table

        public ClsComponentItems()
        {
        }


        //public ClsComponentItems(ClsCompOpt _objCompOptData)
        //{
        //    ClsDB.SaveCompOpt(_objCompOptData);
        //    //SaveComponents(_objCompOptData);
        //}


        #region Load Controls
        public ClsComponentItems(int _intJobID, int _intUnitNo)
        {
            intJobID = _intJobID;
            intUnitNo = _intUnitNo;

            DataTable dtCompOpt = ClsDB.GetSavedCompOpt(intJobID, intUnitNo);
            DataTable dtCompOptCustom = ClsDB.GetSavedCompOptCustom(intJobID, intUnitNo);

            if (dtCompOpt.Rows.Count > 0)
            {
                DataRow dr = dtCompOpt.Rows[0];

                objCompOpt = new ClsCompOpt
                {
                    intJobID = Convert.ToInt32(dr["job_id"]),
                    intUnitNo = Convert.ToInt32(dr["unit_no"]),
                    intUnitTypeID = Convert.ToInt32(dr["unit_type_id"]),
                    intUnitModelID = Convert.ToInt32(dr["unit_model_id"]),
                    intOA_FilterModelID = Convert.ToInt32(dr["oa_filter_model_id"]),
                    intSA_FinalFilterModelID = 0,
                    intRA_FilterModelID = Convert.ToInt32(dr["ra_filter_model_id"]),
                    intHeatExchCompID = Convert.ToInt32(dr["heat_exch_comp_id"]),
                    intPreheatCompID = Convert.ToInt32(dr["preheat_comp_id"]),
                    intCoolingCompID = Convert.ToInt32(dr["cooling_comp_id"]),
                    intHeatingCompID = Convert.ToInt32(dr["heating_comp_id"]),
                    intReheatCompID = Convert.ToInt32(dr["reheat_comp_id"]),
                    intIsHeatPump = Convert.ToInt32(dr["is_heatpump"]),
                    intIsDehumidification = Convert.ToInt32(dr["is_dehumidification"]),
                    dblPreheatSetpointDB = Convert.ToDouble(dr["preheat_setpoint_db"]),
                    intElecHeaterVoltageID = Convert.ToInt32(dr["elec_heater_voltage_id"]),
                    intPreheatElecHeaterInstallationID = Convert.ToInt32(dr["preheat_elec_heater_installation_id"]),
                    intHeatElecHeaterInstallationID = Convert.ToInt32(dr["heat_elec_heater_installation_id"]),
                    intPreheatElecHeaterModelID = Convert.ToInt32(dr["preheat_elec_heater_std_coil_no"]),
                    dblCoolingDX_VRV_KitTonnage = Convert.ToInt32(dr["cooling_dx_vrv_kit_tonnage"]),
                    intHeatingElecHeaterModelID = Convert.ToInt32(dr["heating_elec_heater_std_coil_no"]),
                    intReheatElecHeaterModelID = Convert.ToInt32(dr["reheat_elec_heater_std_coil_no"]),
                    intDamperAndActuatorID = Convert.ToInt32(dr["damper_and_actuator_id"]),
                    intIsValveAndActuatorIncluded = Convert.ToInt32(dr["is_valve_and_actuator_included"]),
                    intValveTypeID = Convert.ToInt32(dr["valve_type_id"]),
                    intIsDrainPan = Convert.ToInt32(dr["is_drain_pan"]),
                    dblOA_FilterPD = Convert.ToDouble(dr["oa_filter_pd"]),
                    dblRA_FilterPD = Convert.ToDouble(dr["ra_filter_pd"]),
                    dblCoolingSetpointDB = Convert.ToDouble(dr["cooling_setpoint_db"]),
                    dblCoolingSetpointWB = Convert.ToDouble(dr["cooling_setpoint_wb"]),
                    intCoolingFluidTypeID = Convert.ToInt32(dr["cooling_fluid_type_id"]),
                    intCoolingFluidConcentID = Convert.ToInt32(dr["cooling_fluid_concent_id"]),
                    dblCoolingFluidEntTemp = Convert.ToDouble(dr["cooling_fluid_ent_temp"]),
                    dblCoolingFluidLvgTemp = Convert.ToDouble(dr["cooling_fluid_lvg_temp"]),
                    dblHeatingSetpointDB = Convert.ToDouble(dr["heating_setpoint_db"]),
                    dblReheatSetpointDB = Convert.ToDouble(dr["reheat_setpoint_db"]),
                    intHeatingFluidTypeID = Convert.ToInt32(dr["heating_fluid_type_id"]),
                    intHeatingFluidConcentID = Convert.ToInt32(dr["heating_fluid_concent_id"]),
                    dblHeatingFluidEntTemp = Convert.ToDouble(dr["heating_fluid_ent_temp"]),
                    dblHeatingFluidLvgTemp = Convert.ToDouble(dr["heating_fluid_lvg_temp"]),
                    dblRefrigSuctionTemp = Convert.ToDouble(dr["refrig_suction_temp"]),
                    dblRefrigLiquidTemp = Convert.ToDouble(dr["refrig_liquid_temp"]),
                    dblRefrigSuperheatTemp = Convert.ToDouble(dr["refrig_superheat_temp"]),
                    dblRefrigCondensingTemp = Convert.ToDouble(dr["refrig_condensing_temp"]),
                    dblRefrigVaporTemp = Convert.ToDouble(dr["refrig_vapor_temp"]),
                    dblRefrigSubcoolingTemp = Convert.ToDouble(dr["refrig_subcooling_temp"]),
                    intIsHeatExchEA_Warning = Convert.ToDouble(dr["is_heat_exch_ea_warning"])
                };


                DataTable dtTemp = ClsDB.get_dtByID(ClsDBT.strSelFluidType, objCompOpt.intCoolingFluidTypeID);
                objCompOpt.strCoolingFluidType = dtTemp.Rows.Count > 0 ? dtTemp.Rows[0]["value"].ToString() : "";

                dtTemp = ClsDB.get_dtByID(ClsDBT.strSelFluidConcentration, objCompOpt.intCoolingFluidConcentID);
                objCompOpt.dblCoolingFluidConcent = dtTemp.Rows.Count > 0 ? Convert.ToDouble(dtTemp.Rows[0]["value"]) : 0d;

                dtTemp = ClsDB.get_dtByID(ClsDBT.strSelFluidType, objCompOpt.intHeatingFluidTypeID);
                objCompOpt.strHeatingFluidType = dtTemp.Rows.Count > 0 ? dtTemp.Rows[0]["value"].ToString() : "";

                dtTemp = ClsDB.get_dtByID(ClsDBT.strSelFluidConcentration, objCompOpt.intHeatingFluidConcentID);
                objCompOpt.dblHeatingFluidConcent = dtTemp.Rows.Count > 0 ? Convert.ToDouble(dtTemp.Rows[0]["value"]) : 0d;

                dtTemp = ClsDB.get_dtByID(ClsDBT.strSelElectricHeaterInstallation, objCompOpt.intPreheatElecHeaterInstallationID);
                objCompOpt.strPreheatElecHeaterInstallation = dtTemp.Rows.Count > 0 ? dtTemp.Rows[0]["items"].ToString() : "";

                dtTemp = ClsDB.get_dtByID(ClsDBT.strSelElectricHeaterInstallation, objCompOpt.intHeatElecHeaterInstallationID);
                objCompOpt.strHeatElecHeaterInstallation = dtTemp.Rows.Count > 0 ? dtTemp.Rows[0]["items"].ToString() : "";

                dtTemp = ClsDB.get_dtByID(ClsDBT.strSelDamperActuator, objCompOpt.intDamperAndActuatorID);
                objCompOpt.strDamperAndActuator = dtTemp.Rows.Count > 0 ? dtTemp.Rows[0]["items"].ToString() : "";

                dtTemp = ClsDB.get_dtByID(ClsDBT.strSelElectricalVoltage, objCompOpt.intElecHeaterVoltageID);
                objCompOpt.strElecHeaterVoltage = dtTemp.Rows.Count > 0 ? dtTemp.Rows[0]["items"].ToString() : "";
            }



            if (dtCompOptCustom.Rows.Count > 0)
            {
                DataRow dr = dtCompOptCustom.Rows[0];

                objCompOptCustom = new ClsCompOptCustom
                {
                    intJobID = Convert.ToInt32(dr["job_id"]),
                    intUnitNo = Convert.ToInt32(dr["unit_no"]),
                    intIsPreheatHWC_UseCap = Convert.ToInt32(dr["is_preheat_hwc_use_cap"]),
                    dblPreheatHWC_Cap = Convert.ToDouble(dr["preheat_hwc_cap"]),
                    intIsPreheatHWC_UseFlowRate = Convert.ToInt32(dr["is_preheat_hwc_use_flow_rate"]),
                    dblPreheatHWC_FlowRate = Convert.ToDouble(dr["preheat_hwc_flow_rate"]),
                    intIsCoolingCWC_UseCap = Convert.ToInt32(dr["is_cooling_cwc_use_cap"]),
                    dblCoolingCWC_Cap = Convert.ToDouble(dr["cooling_cwc_cap"]),
                    intIsCoolingCWC_UseFlowRate = Convert.ToInt32(dr["is_cooling_cwc_use_flow_rate"]),
                    dblCoolingCWC_FlowRate = Convert.ToDouble(dr["cooling_cwc_flow_rate"]),
                    intIsHeatingHWC_UseCap = Convert.ToInt32(dr["is_heating_hwc_use_cap"]),
                    dblHeatingHWC_Cap = Convert.ToDouble(dr["heating_hwc_cap"]),
                    intIsHeatingHWC_UseFlowRate = Convert.ToInt32(dr["is_heating_hwc_use_flow_rate"]),
                    dblHeatingHWC_FlowRate = Convert.ToDouble(dr["heating_hwc_flow_rate"]),
                    intIsReheatHWC_UseCap = Convert.ToInt32(dr["is_reheat_hwc_use_cap"]),
                    dblReheatHWC_Cap = Convert.ToDouble(dr["reheat_hwc_cap"]),
                    intIsReheatHWC_UseFlowRate = Convert.ToInt32(dr["is_reheat_hwc_use_flow_rate"]),
                    dblReheatHWC_FlowRate = Convert.ToDouble(dr["reheat_hwc_flow_rate"]),
                };
            }
        }
        #endregion


        public int get_intJobID()
        {
            return intJobID;
        }

        public int get_intUnitNo()
        {
            return intUnitNo;
        }

        public void set_intUnitNo(int _intUnitNo)
        {
            intUnitNo = _intUnitNo;
        }


        //public Dictionary<string, object> get_dicValues()
        //{
        //    return dicValues;
        //}

        public ClsCompOpt objCompOpt { get; set; }
        public ClsCompOptCustom objCompOptCustom { get; set; }
    }
}