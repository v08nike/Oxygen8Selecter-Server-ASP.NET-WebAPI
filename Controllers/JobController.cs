using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data;
using Oxyzen8SelectorServer.Models;

namespace Oxyzen8SelectorServer.Controllers
{
    public class JobController : ApiController
    {
        [HttpPost]
        [ActionName("Delete")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public DataTable DeleteProjectBy([FromBody]dynamic info)
        {
            if (info.action == "DELETE_ONE")
            {
                JobsModel.DeleteProjectByJobId(Convert.ToInt32(info.jobId));
                return JobsModel.GetJobList();
            } else
            {
                JobsModel.DeleteProjectByJobIds(info.jobIdData);
                return JobsModel.GetJobList();
            }
        }

        [HttpPost]
        [ActionName("GetOutdoorInfo")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic GetOutdoorInfo([FromBody]dynamic info)
        {
            switch (info.action.ToString())
            {
                case "GET_ALL_DATA":
                    {
                        return JobsModel.GetAllOutdoorInfo(info.country.ToString(), Convert.ToInt32(info.cityId), Convert.ToInt32(info.designCondition));
                    }
                case "GET_RH_BY_DB_WB":
                    {
                        return JobsModel.GetRH_By_DB_WB(info);
                    }
                case "GET_WB_BY_DB_HR":
                    {
                        return JobsModel.GetWB_By_DB_RH(info);
                    }
                case "GET_USER_PER_COMPANY":
                    {
                        return JobsModel.GetUserPerCompany(info);
                    }
                default:
                    {
                        break;
                    }
            }
            return JobsModel.DeleteProjectByJobId(Convert.ToInt32(info.jobId));
        }

        [HttpPost]
        [ActionName("Add")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POST api/job/add
        public dynamic AddNewJob([FromBody]dynamic reqeustInfo)
        {
            return JobsModel.UpdateJob(reqeustInfo);
        }

        [HttpPost]
        [ActionName("Update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POST api/job/update
        public DataTable UpdateJob([FromBody]dynamic reqeustInfo)
        {
            JobsModel.UpdateJob(reqeustInfo);
            return JobsModel.GetJobList(); 
        }

        [HttpPost]
        [ActionName("Get")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // Post api/job/get
        public dynamic GetInitialJobInfo()
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

        [HttpPost]
        [ActionName("GetWithUnit")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic GetJobAndUnitInfo([FromBody]dynamic info)
        {
            dynamic returnInfo = new ExpandoObject();
            returnInfo.jobInfo = ClsDB.GetSavedJob(Convert.ToInt32(info.jobId)); ;
            returnInfo.unitList= UnitsModel.GetUnitListByJobId(Convert.ToInt32(info.jobId));
            return returnInfo;
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