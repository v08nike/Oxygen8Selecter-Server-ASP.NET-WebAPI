using System;
using System.Dynamic;
using System.Web.Http;
using System.Web.Http.Cors;
using Oxyzen8SelectorServer.Models;

namespace Oxyzen8SelectorServer.Controllers
{
    public class SubmittalsController : ApiController
    {
        [HttpPost]
        [ActionName("getAllData")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public dynamic getAllData([FromBody]dynamic info)
        {
            int intUserID = Convert.ToInt32(info.intUserID);
            int intUAL = Convert.ToInt32(info.intUAL);
            int intJobID = Convert.ToInt32(info.intJobID);

            //intUnitNo = Convert.ToInt32(hfUnitNo.Value);

            dynamic returnInfo = new ExpandoObject();
            if (intUAL == ClsID.intUAL_Admin || intUAL == ClsID.intUAL_IntAdmin || intUAL == ClsID.intUAL_IntLvl_2 || intUAL == ClsID.intUAL_IntLvl_1)
            {
                //gvPricingMisc.Visible = true;
                returnInfo.divNotesVisible = true;
            }
            else
            {
                //gvPricingMisc.Visible = false;
                returnInfo.divNotesVisible = false;
            }


            return SubmittalsModel.getControls(intJobID, intUAL, intUserID);
        }

        [HttpPost]
        [ActionName("save")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public bool SaveUpdate([FromBody]dynamic info)
        {
            return SubmittalsModel.setSaveUpdate(info);
        }
    }
}
