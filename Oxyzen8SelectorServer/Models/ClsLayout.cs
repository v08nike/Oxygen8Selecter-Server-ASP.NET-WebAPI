using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsLayout
    {
        private int intJobID = 0;
        private int intUnitNo = 0;
        //private int intVoltageID = 0;   //Used to select fan model / VoltageID is saved in Electrical Table

        public ClsLayout()
        {
        }


        public ClsLayout(ClsCompOpt _objCompOptData)
        {
            //ClsDB.SaveCompOpt(_objCompOptData);
            //SaveComponents(_objCompOptData);
        }


        public ClsLayout(int _intJobID, int _intUnitNo)
        {
            intJobID = _intJobID;
            intUnitNo = _intUnitNo;

            DataTable dtLayoutOpt = ClsDB.GetSavedLayoutOpt(intJobID, intUnitNo);

            if (dtLayoutOpt.Rows.Count > 0)
            {
                DataRow dr = dtLayoutOpt.Rows[0];

                objLayoutOpt = new ClsLayoutOpt
                {
                    intJobID = Convert.ToInt32(dr["job_id"]),
                    intUnitNo = Convert.ToInt32(dr["unit_no"]),
                    intProductTypeID = Convert.ToInt32(dr["product_type_id"]),
                    intUnitTypeID = Convert.ToInt32(dr["unit_type_id"]),
                    intHandingID = Convert.ToInt32(dr["handing_id"]),
                    intPreheatCoilHandingID = Convert.ToInt32(dr["preheat_coil_handing_id"]),
                    intCoolingCoilHandingID = Convert.ToInt32(dr["cooling_coil_handing_id"]),
                    intHeatingCoilHandingID = Convert.ToInt32(dr["heating_coil_handing_id"]),
                    intSupplyAirOpeningID = Convert.ToInt32(dr["sa_opening_id"]),
                    strSupplyAirOpening = dr["sa_opening"].ToString(),
                    intExhaustAirOpeningID = Convert.ToInt32(dr["ea_opening_id"]),
                    strExhaustAirOpening = dr["ea_opening"].ToString(),
                    intOutdoorAirOpeningID = Convert.ToInt32(dr["oa_opening_id"]),
                    strOutdoorAirOpening = dr["oa_opening"].ToString(),
                    intReturnAirOpeningID = Convert.ToInt32(dr["ra_opening_id"]),
                    strReturnAirOpening = dr["ra_opening"].ToString(),
                };
            }
        }


        public ClsLayoutOpt objLayoutOpt { get; set; }
    }
}