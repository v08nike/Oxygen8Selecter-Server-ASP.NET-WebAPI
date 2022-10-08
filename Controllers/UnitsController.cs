using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Dynamic;
using Oxyzen8SelectorServer.Models;
using System.Web.Http.Cors;

namespace Oxyzen8SelectorServer.Controllers
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
        public bool SaveUnitInfo([FromBody]dynamic unitInfo)
        {
            return UnitsModel.SaveUnitInfo(unitInfo);
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
        public dynamic GetUnitInfo([FromBody] ClsJobUnitId requestInfo)
        {
            return UnitsModel.GetUnitInfo(requestInfo.jobId, requestInfo.unitId);
        }

        [HttpPost]
        [ActionName("GetInitUnitInfo")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic GetInitUnitInfo([FromBody]dynamic request)
        {
            int unitId = Convert.ToInt32(request.unitId);
            int jobId = Convert.ToInt32(request.jobId);
            dynamic returnInfo = new ExpandoObject();

            returnInfo.unitSourceInfo = UnitsModel.GetInitUnitInfo(jobId, Convert.ToInt32(request.unitModelId), Convert.ToInt32(request.productTypeId), Convert.ToInt32(request.UAL));
            if (unitId != -1) {
                returnInfo.unitInfo = UnitsModel.GetUnitInfo(jobId, unitId);
            }

            return returnInfo;
        }

        [HttpPost]
        [ActionName("preheatCompChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic preheatCompChanged([FromBody]dynamic fieldInfo)
        {
            dynamic returnInfo = new ExpandoObject();

            returnInfo.preheatElecHeater = UnitsModel.GetPreheatElectricHeader(fieldInfo);
            returnInfo.elecHeaterVoltage = UnitsModel.GetElectricHeaterVoltage(fieldInfo);
            returnInfo.customInputs = UnitsModel.GetCustomInputs(fieldInfo);

            if (Convert.ToInt32(fieldInfo) == ClsID.intUnitTypeAHU_ID)
            {
                returnInfo.preheatSetPoint = UnitsModel.GetPreheatSetpoint(fieldInfo);
                returnInfo.setPoints = UnitsModel.GetSetpoints(fieldInfo);

            }
            return returnInfo;
        }

        [HttpPost]
        [ActionName("coolingCompChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic coolignCompChanged([FromBody]dynamic fieldInfo)
        {
            dynamic returnInfo = new ExpandoObject();

            returnInfo.preheatElecHeater = UnitsModel.GetPreheatElectricHeader(fieldInfo);
            returnInfo.elecHeaterVoltage = UnitsModel.GetElectricHeaterVoltage(fieldInfo);
            returnInfo.customInputs = UnitsModel.GetCustomInputs(fieldInfo);

            if (Convert.ToInt32(fieldInfo) == ClsID.intUnitTypeAHU_ID)
            {
                returnInfo.preheatSetPoint = UnitsModel.GetPreheatSetpoint(fieldInfo);
                returnInfo.setPoints = UnitsModel.GetSetpoints(fieldInfo);

            }
            return returnInfo;
        }

        [HttpPost]
        [ActionName("AirFlowDataChanged")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic AirFlowDataChanged([FromBody]dynamic info)
        {

            switch (info.action.ToString())
            {
                case "SummerSupplyAirCFM_Changed":
                    {
                        return UnitsModel.txbSummerSupplyAirCFM_Changed(info);
                    }
                case "SummerReturnAirCFM_Changed":
                    {
                        return UnitsModel.txbSummerReturnAirCFM_Changed(info);
                    }
                case "SupplyAirESP":
                    {
                        return UnitsModel.txbSupplyAirESP_Changed(info);
                    }
                case "ExhaustAirESP":
                    {
                        return UnitsModel.txbExhaustAirESP_Changed(info);
                    }
                default:
                    {
                        break;
                    }
            }

            return new DataTable();
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