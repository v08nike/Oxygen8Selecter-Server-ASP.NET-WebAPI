using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Oxyzen8SelectorServer.Models;

namespace Oxyzen8SelectorServer.Controllers
{
    public class JobController : ApiController
    {
        [HttpPost]
        [ActionName("Update")]
        // POST api/job/update
        public ClsReturn getJobs([FromBody]ClsSaveJobParams reqeustInfo)
        {

            ClsReturn returnResult = new ClsReturn();
            returnResult.data = JobsModel.UpdateJob();
            return returnResult;
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