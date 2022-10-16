using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Dynamic;
using Oxygen8SelectorServer.Models;
using System.Web.Http.Cors;

namespace Oxygen8SelectorServer.Controllers
{
    public class UnitsController : ApiController
    {
        [HttpPost]
        [ActionName("Get")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POST api/units/get
        public DataTable GetUnits([FromBody]dynamic reqeustInfo)
        {
            return UnitsModel.GetUnitListByJobId(Convert.ToInt32(reqeustInfo.jobId));
        }

        [HttpPost]
        [ActionName("GetUnitTypeInfo")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic GetUnitTypeInfo()
        {
            return UnitsModel.GetUnitTypeInfo();
        }

        [HttpPost]
        [ActionName("Save")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic SaveUnitInfo([FromBody]dynamic unitInfo)
        {
            dynamic returnInfo = new ExpandoObject();
            returnInfo.intUnitNo = UnitsModel.SaveUnitInfo(unitInfo);
            returnInfo.unitData = GetUnitInfo(unitInfo);
            return returnInfo;
        }

        [HttpPost]
        [ActionName("SaveLayout")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public bool SaveLayout([FromBody]dynamic unitInfo)
        {
            return UnitsModel.SaveLayout(unitInfo);
        }

        [HttpPost]
        [ActionName("Delete")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic DeleteUnitById([FromBody]dynamic unitInfo)
        {
            if (unitInfo.action == "DELETE_ONE")
            {
                UnitsModel.DeleteUnitById(Convert.ToInt32(unitInfo.jobId), Convert.ToInt32(unitInfo.unitId));
                return UnitsModel.GetUnitListByJobId(Convert.ToInt32(unitInfo.jobId)); 
            } else
            {
                UnitsModel.DeleteUnitsByIds(Convert.ToInt32(unitInfo.jobId), unitInfo.unitIds);
                return UnitsModel.GetUnitListByJobId(Convert.ToInt32(unitInfo.jobId));
            }

        }

        [HttpPost]
        [ActionName("GetUnitInfo")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic GetUnitInfo([FromBody]dynamic info)
        {
            //hfUserID.Value = dictionary[clsSV._intUserID].ToString();
            //hfUAL.Value = dictionary[clsSV._intUAL].ToString();
            //hfJobID.Value = dictionary[clsSV._intJobID].ToString();
            //hfProductTypeID.Value = dictionary[clsSV._intProductTypeID].ToString();
            //hfUnitTypeID.Value = dictionary[clsSV._intUnitTypeID].ToString();
            //hfUnitNo.Value = dictionary[clsSV._intUnitNo].ToString();
            dynamic returnInfo = new ExpandoObject();

            int intUserId = Convert.ToInt32(info.intUserID);
            int intUAL = Convert.ToInt32(info.intUAL);
            int intJobId = Convert.ToInt32(info.intJobID);
            int intProductTypeId = Convert.ToInt32(info.intProductTypeID);
            int intUnitTypeId = Convert.ToInt32(info.intUnitTypeID);
            int intUnitNo = Convert.ToInt32(info.intUnitNo);

            DataTable dtUser = ClsDB.GetUser(intUserId);
            int intCustomerTypeID = Convert.ToInt32(info.customerTypeId);

            dynamic visibleInfo = new ExpandoObject();
            visibleInfo.divOutdoorAirDesignConditionsVisible = intUAL == ClsID.intUAL_Admin ? true : false;
            visibleInfo.divReturnAirDesignConditionsVisible = intUAL == ClsID.intUAL_Admin ? true : false;
            visibleInfo.divSetpoint_1Visible = intUAL == ClsID.intUAL_Admin ? true : false;
            visibleInfo.divNotesVisible = intUAL == ClsID.intUAL_Admin ? true : false;
            visibleInfo.divCustomVisible = intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1 ? true : false;
            visibleInfo.divHeatExchCompVisible = false;
            visibleInfo.divSubmittalItemsVisible = intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1 ? true : false;


            visibleInfo.divUnitOpeningsMsgVisible = intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1 ? true : false;
            visibleInfo.btnViewModelOptionVisible = false;
            visibleInfo.btnSubmittalsVisible = (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1) ? true : false;
            visibleInfo.btnQuoteVisible = false;


            visibleInfo.btnNextVisible = false;
            visibleInfo.btnOutputVisible = false;
            visibleInfo.div_hx_fp_hiddenVisible = false;

            returnInfo.unitInfo = UnitsModel.GetUnitInfo(info);
            returnInfo.controlInfo = UnitsModel.getControlInfo("325", 0);
            returnInfo.visibleInfo = visibleInfo;

            return returnInfo;
        }

        [HttpPost]
        [ActionName("locationchanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic ddlLocationChanged([FromBody]dynamic info)
        {
            return UnitsModel.ddlLocationChanged(info);
        }

        [HttpPost]
        [ActionName("orientationchanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic ddlOrientationChanged([FromBody]dynamic info)
        {
            return UnitsModel.ddlOrientationChanged(info);
        }

        [HttpPost]
        [ActionName("SummerSupplyAirCFMChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic txbSummerSupplyAirCFMChanged([FromBody]dynamic info)
        {
            UnitsModel.setAllData(info);
            return UnitsModel.txbSummerSupplyAirCFM_Changed(info.txbSummerSupplyAirCFM.ToString(), Convert.ToInt32(info.ckbBypass));
        }

        [HttpPost]
        [ActionName("SummerReturnAirCFMChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic txbSummerReturnAirCFMChanged([FromBody]dynamic info)
        {
            UnitsModel.setAllData(info);
            return UnitsModel.txbSummerReturnAirCFM_Changed(info.txbSummerReturnAirCFM.ToString(), info.txbSummerSupplyAirCFM.ToString(), Convert.ToInt32(info.ckbBypass));
        }

        [HttpPost]
        [ActionName("SupplyAirESPChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic txbSupplyAirESPChanged([FromBody]dynamic info)
        {
            UnitsModel.setAllData(info);
            return UnitsModel.txbSupplyAirESP_Changed(info.txbSupplyAirESP.ToString());
        }

        [HttpPost]
        [ActionName("ExhaustAirESPChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic txbExhaustAirESPChanged([FromBody]dynamic info)
        {
            UnitsModel.setAllData(info);
            return UnitsModel.txbExhaustAirESP_Changed(info.txbExhaustAirESP.ToString());
        }

        [HttpPost]
        [ActionName("UnitVoltageChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic ddlUnitVoltageChanged([FromBody]dynamic info)
        {
            UnitsModel.setAllData(info);
            return UnitsModel.getElectricHeaterVoltage();
        }

        [HttpPost]
        [ActionName("UnitModelChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic ddlUnitModelChanged([FromBody]dynamic info)
        {
            UnitsModel.setAllData(info);
            return UnitsModel.ddlUnitModelIndexChanged(info.txbSupplyAirESP.ToString(), info.txbExhaustAirESP.ToString());
        }

        [HttpPost]
        [ActionName("SummerOutdoorAirWBChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public float txbSummerOutdoorAirWBChanged([FromBody]dynamic info)
        {
            string txbSummerOutdoorAirDB = info.txbSummerOutdoorAirDB.ToString();
            string txbSummerOutdoorAirWB = info.txbSummerOutdoorAirWB.ToString();
            string txbAltitude = info.txbAltitude.ToString();
            float result = UnitsModel.txbSummerOutdoorAirWB_TextChanged(txbSummerOutdoorAirDB, txbSummerOutdoorAirWB, txbAltitude);
            return result;
        }

        [HttpPost]
        [ActionName("SummerOutdoorAirRHChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public float txbSummerOutdoorAirRHChanged([FromBody]dynamic info)
        {
            return UnitsModel.txbSummerOutdoorAirRH_TextChanged(info);
        }

        [HttpPost]
        [ActionName("WinterOutdoorAirWBChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public float txbWinterOutdoorAirWBChanged([FromBody]dynamic info)
        {
            return UnitsModel.txbWinterOutdoorAirWB_TextChanged(info);
        }

        [HttpPost]
        [ActionName("WinterOutdoorAirRHChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public float txbWinterOutdoorAirRHChanged([FromBody]dynamic info)
        {
            return UnitsModel.txbWinterOutdoorAirRH_TextChanged(info);
        }

        [HttpPost]
        [ActionName("SummerReturnAirWBChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public float txbSummerReturnAirWBChanged([FromBody]dynamic info)
        {
            return UnitsModel.txbSummerReturnAirWB_TextChanged(info);
        }


        [HttpPost]
        [ActionName("SummerReturnAirRHChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public float txbSummerReturnAirRHChanged([FromBody]dynamic info)
        {
            return UnitsModel.txbSummerReturnAirRH_TextChanged(info);
        }

        [HttpPost]
        [ActionName("WinterReturnAirWBChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public float txbWinterReturnAirWBChanged([FromBody]dynamic info)
        {
            return UnitsModel.txbWinterReturnAirWB_TextChanged(info);
        }

        [HttpPost]
        [ActionName("WinterReturnAirRHChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public float txbWinterReturnAirRHChanged([FromBody]dynamic info)
        {
            return UnitsModel.txbWinterReturnAirRH_TextChanged(info);
        }

        [HttpPost]
        [ActionName("ddlPreheatCompChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic ddlPreheatCompChanged([FromBody]dynamic info)
        {
            dynamic returnInfo = new ExpandoObject();
            UnitsModel.setAllData(info);
            returnInfo.preheatElectricHeater = UnitsModel.getPreheatElectricHeater();
            returnInfo.preheatInfomation = UnitsModel.getPreheatRequired();
            returnInfo.divHeatingFluidDesignConditionsVisible = UnitsModel.getHeatingFluidDesignConditions();
            returnInfo.valveAndActuator = UnitsModel.getValveAndActuator();

            returnInfo.isAHUID = false;
            if (info.ddlUnitType == ClsID.intUnitTypeAHU_ID)
            {
                returnInfo.divPreheatSetpointVisible = UnitsModel.getPreheatSetpoint();
                returnInfo.divSetpointsVisible = UnitsModel.getSetpoints();
                returnInfo.isAHUID = true;
            }

            returnInfo.customInputs = UnitsModel.getCustomInputs();  //Internal users only
            returnInfo.divPreheatCoilHandingVisible = info.ddlPreheatComp > 1 ? true : false;

            return returnInfo;
        }

        [HttpPost]
        [ActionName("ddlCoolingCompChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic ddlCoolingCompChanged([FromBody]dynamic info)
        {
            dynamic returnInfo = new ExpandoObject();

            returnInfo.cooling = UnitsModel.getCooling();
            returnInfo.dehumidification = UnitsModel.getDehumidification();
            returnInfo.reheat = UnitsModel.getReheat();
            returnInfo.heatElectricHeater = UnitsModel.getHeatElectricHeater();    //Need to show/hide Electric heater
            returnInfo.divHeatingFluidDesignConditionsVisible = UnitsModel.getHeatingFluidDesignConditions();  //Need to show/hide HWC
            returnInfo.refrigerantInfo = UnitsModel.getRefrigerant();
            returnInfo.valveAndActuator = UnitsModel.getValveAndActuator();  //Need to show/hide HWC valve and actuator
            returnInfo.divCoolingSetpointVisible = UnitsModel.getCoolingSetpoint();
            returnInfo.divHeatingSetpointVisible = UnitsModel.getHeatingSetpoint(); //Need to show/hide Heating setpoint
            returnInfo.reheatSetpoints = UnitsModel.getReheatSetpoints();   //Need to show/hide Reheat setpoint
            returnInfo.divSetpointsVisible = UnitsModel.getSetpoints();
            returnInfo.customInputs = UnitsModel.getCustomInputs();  //Internal users only

            dynamic ddlSupplyAirOpeningInfo = UnitsModel.getSupplyAirOpening();
            returnInfo.ddlSupplyAirOpening = ddlSupplyAirOpeningInfo.data;
            returnInfo.ddlSupplyAirOpeningValue = ddlSupplyAirOpeningInfo.value;
            returnInfo.ddlSupplyAirOpeningText = ddlSupplyAirOpeningInfo.text;

            return returnInfo;
        }

        [HttpPost]
        [ActionName("ddlHeatingCompChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic ddlHeatingCompChanged([FromBody]dynamic info)
        {
            dynamic returnInfo = new ExpandoObject();

            returnInfo.heatElectricHeater = UnitsModel.getHeatElectricHeater();
            returnInfo.divHeatingFluidDesignConditionsVisible = UnitsModel.getHeatingFluidDesignConditions();
            returnInfo.valveAndActuator = UnitsModel.getValveAndActuator();
            returnInfo.divHeatingSetpointVisible = UnitsModel.getHeatingSetpoint();
            returnInfo.divSetpointsVisible = UnitsModel.getSetpoints();
            returnInfo.customInputs = UnitsModel.getCustomInputs();

            dynamic ddlSupplyAirOpeningInfo = UnitsModel.getSupplyAirOpening();
            returnInfo.ddlSupplyAirOpening = ddlSupplyAirOpeningInfo.data;
            returnInfo.ddlSupplyAirOpeningValue = ddlSupplyAirOpeningInfo.value;
            returnInfo.ddlSupplyAirOpeningText = ddlSupplyAirOpeningInfo.text;

            return returnInfo;
        }

        [HttpPost]
        [ActionName("ViewSelection")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic getViewSelectionInfo([FromBody] dynamic info)
        {
            return UnitsModel.ViewSelection(info);
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}