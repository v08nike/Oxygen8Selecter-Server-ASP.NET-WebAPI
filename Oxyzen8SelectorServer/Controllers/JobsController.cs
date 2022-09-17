using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Oxyzen8SelectorServer.Models;

namespace Oxyzen8SelectorServer.Controllers
{
    public class JobsController : ApiController
    {
        [HttpPost]
        [ActionName("Get")]
        // POST api/jobs/get
        public ClsReturn GetJobs([FromBody]ClsGetJobsParams reqeustInfo)
        {
            int userId = reqeustInfo.userId;
            string action = reqeustInfo.action;

            ClsReturn returnResult = new ClsReturn();

            if (action == "all")
            {
                returnResult.data = JobsModel.GetJobList();
                return returnResult;
            }
            else if (action == "not")
            {
                returnResult.data = JobsModel.getJobListByOthers(userId);
                return returnResult;
            }
            else
            {
                returnResult.data = JobsModel.getJobListByCreatedUserId(userId);
                return returnResult;
            }
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