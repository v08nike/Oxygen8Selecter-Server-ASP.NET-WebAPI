using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Oxyzen8SelectorServer.Models;

namespace Oxyzen8SelectorServer.Controllers
{
    public class JobController : ApiController
    {
        [HttpPost]
        [ActionName("Delete")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public bool DeleteProjectBy([FromBody]dynamic info)
        {
            return JobsModel.DeleteProjectByJobId(Convert.ToInt32(info.jobId));
        }


        [HttpPost]
        [ActionName("Update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POST api/job/update
        public ClsReturn UpdateJob([FromBody]ClsSaveJobParams reqeustInfo)
        {
            ClsReturn returnResult = new ClsReturn();
            returnResult.data = JobsModel.UpdateJob(reqeustInfo);
            return returnResult;
        }

        [HttpPost]
        [ActionName("Get")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // Post api/job/get
        public ClsInitailJobInfoReturn GetInitialJobInfo()
        {
            return JobsModel.GetInitialJobInfo();
        }

        [HttpPost]
        [ActionName("Get")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POSt api/job/get/:id
        public ClsJobInfoReturn GetJobInfoByJobId(int id)
        {
            return JobsModel.GetJobInfoByJobId(id);
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