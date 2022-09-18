using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Dynamic;
using Oxyzen8SelectorServer.Models;

namespace Oxyzen8SelectorServer.Controllers
{
    public class UnitsController : ApiController
    {
        [HttpPost]
        [ActionName("Get")]
        // POST api/units/get
        public ClsReturn getUnits([FromBody]ClsGetUnitsParams reqeustInfo)
        {
            int jobId = reqeustInfo.jobId;

            ClsReturn returnResult = new ClsReturn();
            returnResult.data = UnitsModel.getUnitListByJobId(jobId);
            return returnResult;
        }

        [HttpPost]
        [ActionName("GetUnitInfo")]
        public dynamic GetUnitInfo([FromBody] ClsJobUnitId requestInfo)
        {
            return UnitsModel.GetUnitInfo(requestInfo.jobId, requestInfo.unitId);
        }

        [HttpPost]
        [ActionName("GetInitUnitInfo")]
        public dynamic GetInitUnitInfo([FromBody]ClsGetInitUnitInfoParams request)
        {
            return UnitsModel.GetInitUnitInfo(request.jobId, request.unitModelId, request.productTypeId);
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