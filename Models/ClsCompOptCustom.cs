using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxygen8SelectorServer.Models
{
    public class ClsCompOptCustom
    {
        public int intJobID { get; set; }
        public int intUnitNo { get; set; }
        public int intIsPreheatHWC_UseCap { get; set; }
        public double dblPreheatHWC_Cap { get; set; }
        public int intIsPreheatHWC_UseFlowRate { get; set; }
        public double dblPreheatHWC_FlowRate { get; set; }
        public int intIsCoolingCWC_UseCap { get; set; }
        public double dblCoolingCWC_Cap { get; set; }
        public int intIsCoolingCWC_UseFlowRate { get; set; }
        public double dblCoolingCWC_FlowRate { get; set; }
        public int intIsHeatingHWC_UseCap { get; set; }
        public double dblHeatingHWC_Cap { get; set; }
        public int intIsHeatingHWC_UseFlowRate { get; set; }
        public double dblHeatingHWC_FlowRate { get; set; }
        public int intIsReheatHWC_UseCap { get; set; }
        public double dblReheatHWC_Cap { get; set; }
        public int intIsReheatHWC_UseFlowRate { get; set; }
        public double dblReheatHWC_FlowRate { get; set; }
    }
}