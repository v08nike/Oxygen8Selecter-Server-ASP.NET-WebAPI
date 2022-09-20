using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data;
using System.Dynamic;
using Oxyzen8SelectorServer.Models;

namespace Oxyzen8SelectorServer.Controllers
{
    public class JobsController : ApiController
    {
        [HttpPost]
        [ActionName("Get")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POST api/jobs/get
        public dynamic GetJobs()
        {
            dynamic returnData = new ExpandoObject();
            returnData.jobInitInfo = JobsModel.GetInitialJobInfo();
            returnData.jobList = JobsModel.GetJobList();
            return returnData;
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