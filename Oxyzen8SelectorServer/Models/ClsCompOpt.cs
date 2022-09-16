using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsCompOpt
    {
        public int intJobID { get; set; }
        public int intUnitNo { get; set; }
        public int intUnitTypeID { get; set; }
        public int intUnitModelID { get; set; }
        public int intVoltageID { get; set; }
        public int intOA_FilterModelID { get; set; }
        public int intSA_FinalFilterModelID { get; set; }
        public int intRA_FilterModelID { get; set; }
        public int intHeatExchCompID { get; set; }
        public int intPreheatCompID { get; set; }
        public int intCoolingCompID { get; set; }
        public int intHeatingCompID { get; set; }
        public int intReheatCompID { get; set; }
        public int intIsHeatPump { get; set; }
        public int intIsDehumidification { get; set; }
        public double dblOA_FilterPD { get; set; }
        public double dblRA_FilterPD { get; set; }
        public double dblPreheatSetpointDB { get; set; }
        public int intElecHeaterVoltageID { get; set; }
        public string strElecHeaterVoltage { get; set; }
        public int intPreheatElecHeaterModelID { get; set; }
        public int intPreheatElecHeaterStdCoilNo { get; set; }
        public double dblCoolingDX_VRV_KitTonnage { get; set; }
        public int intHeatingElecHeaterModelID { get; set; }
        public int intHeatingElecHeaterStdCoilNo { get; set; }
        public int intReheatElecHeaterModelID { get; set; }
        public int intReheatElecHeaterStdCoilNo { get; set; }
        public int intPreheatElecHeaterInstallationID { get; set; }
        public string strPreheatElecHeaterInstallation { get; set; }
        public int intHeatElecHeaterInstallationID { get; set; }
        public string strHeatElecHeaterInstallation { get; set; }
        public int intDamperAndActuatorID { get; set; }
        public string strDamperAndActuator { get; set; }
        public int intIsValveAndActuatorIncluded { get; set; }
        public int intPreheatValveAndActuatorID { get; set; }
        public double intCoolingValveAndActuatorID { get; set; }
        public int intHeatingValveAndActuatorID { get; set; }
        public int intReheatValveAndActuatorID { get; set; }
        public int intValveTypeID { get; set; }
        public int intIsDrainPan { get; set; }
        public double dblCoolingSetpointDB { get; set; }
        public double dblCoolingSetpointWB { get; set; }
        public int intCoolingFluidTypeID { get; set; }
        public string strCoolingFluidType { get; set; }
        public int intCoolingFluidConcentID { get; set; }
        public double dblCoolingFluidConcent { get; set; }
        public double dblCoolingFluidEntTemp { get; set; }
        public double dblCoolingFluidLvgTemp { get; set; }
        public double dblHeatingSetpointDB { get; set; }
        public double dblReheatSetpointDB { get; set; }
        public int intHeatingFluidTypeID { get; set; }
        public string strHeatingFluidType { get; set; }
        public int intHeatingFluidConcentID { get; set; }
        public double dblHeatingFluidConcent { get; set; }
        public double dblHeatingFluidEntTemp { get; set; }
        public double dblHeatingFluidLvgTemp { get; set; }
        public double dblRefrigSuctionTemp { get; set; }
        public double dblRefrigLiquidTemp { get; set; }
        public double dblRefrigSuperheatTemp { get; set; }
        public double dblRefrigCondensingTemp { get; set; }
        public double dblRefrigVaporTemp { get; set; }
        public double dblRefrigSubcoolingTemp { get; set; }
        public double intIsHeatExchEA_Warning { get; set; }
    }
}