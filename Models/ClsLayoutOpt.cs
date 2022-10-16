using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxygen8SelectorServer.Models
{
    public class ClsLayoutOpt
    {
        public int intJobID { get; set; }
        public int intUnitNo { get; set; }
        public int intProductTypeID { get; set; }
        public int intUnitTypeID { get; set; }
        public int intHandingID { get; set; }
        public int intPreheatCoilHandingID { get; set; }
        public int intCoolingCoilHandingID { get; set; }
        public int intHeatingCoilHandingID { get; set; }
        public int intSupplyAirOpeningID { get; set; }
        public string strSupplyAirOpening { get; set; }
        public int intExhaustAirOpeningID { get; set; }
        public string strExhaustAirOpening { get; set; }
        public int intOutdoorAirOpeningID { get; set; }
        public string strOutdoorAirOpening { get; set; }
        public int intReturnAirOpeningID { get; set; }
        public string strReturnAirOpening { get; set; }
    }
}