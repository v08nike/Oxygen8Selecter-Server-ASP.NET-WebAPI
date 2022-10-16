using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxygen8SelectorServer.Models
{
    public struct ClsReturn
    {
        public string action { get; set; }
        public DataTable data { get; set; }
    }
    public class ClsJobInfoReturn
    {
        public string jobId { get; set; }
        public string createdUserId { get; set; }
        public string revisedUserId { get; set; }
        public string jobName { get; set; }
        public string referenceNo { get; set; }
        public string revisionNo { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string companyNameId { get; set; }
        public string contactNameId { get; set; }
        public string applicationId { get; set; }
        public string applicationOther { get; set; }
        public string basisOfDesignId { get; set; }
        public string UOMId { get; set; }
        public string country { get; set; }
        public string provState { get; set; }
        public string cityId { get; set; }
        public string designConditionId { get; set; }
        public string altitude { get; set; }
        public string summerOutdoorAirDB { get; set; }
        public string summerOutdoorAirWB { get; set; }
        public string summerOutdoorAirRH { get; set; }
        public string winterOutdoorAirDB { get; set; }
        public string winterOutdoorAirWB { get; set; }
        public string winterOutdoorAirRH { get; set; }
        public string summerReturnAirDB { get; set; }
        public string summerReturnAirWB { get; set; }
        public string summerReturnAirRH { get; set; }
        public string winterReturnAirDB { get; set; }
        public string winterReturnAirWB { get; set; }
        public string winterReturnAirRH { get; set; }
        public string createdDate { get; set; }
        public string revisedDate { get; set; }
        public string isTestNewPrice { get; set; }
    }

    public class ClsInitailJobInfoReturn
    {
        public string createdDate { get; set; }
        public string revisedDate { get; set; }
        public DataTable baseOfDesign { get; set; }
        public DataTable UoM { get; set; }
        public DataTable country { get; set; }
        public DataTable designCondition { get; set; }
        public DataTable companyInfo { get; set; }
    }

    public class ClsUnitInfoReturn
    {
        public string tag { get; set; }
        public string qty { get; set; }
        public string unitTypeId { get; set; }
        public string locationId { get; set; }
        public string orientationId { get; set; }
        public string unitModelId { get; set; }
        public string unitVoltageId { get; set; }
        public string controlsPreferenceId { get; set; }
        public string unitHeight { get; set; }
        public string unitWidth { get; set; }
        public string unitLength { get; set; }
        public string unitWeight { get; set; }
        public string summerSupplyAirCFM { get; set; }
        public string supplyAirESP { get; set; }
        public string ExhaustAirESP { get; set; }
        public string summerOutdoorAirDB { get; set; }
        public string summerOutdoorAirWB { get; set; }
        public string summerOutdoorAirRH { get; set; }
        public string winterOutdoorAirDB { get; set; }
        public string winterOutdoorAirWB { get; set; }
        public string winterOutdoorAirRH { get; set; }
        public string summerReturnAirDB { get; set; }
        public string summerReturnAirWB { get; set; }
        public string summerReturnAirRH { get; set; }
        public string winterReturnAirDB { get; set; }
        public string winterReturnAirWB { get; set; }
        public string winterReturnAirRH { get; set; }
        public string winterPreheatSetpointDB { get; set; }
        public string winterHeatingSetpointDB { get; set; }
        public string summerCoolingSetpointDB { get; set; }
        public string summerCoolingSetpointWB { get; set; }
        public string summerReheatSetpointDB { get; set; }
        public string qAFilterModelId { get; set; }
        public string finalFilterModelId { get; set; }
        public string rAFilterModelId { get; set; }
        public string heatExchCompId { get; set; }
        public string preheatCompId { get; set; }
        public string coolingCompId { get; set; }
        public string heatingCompId { get; set; }
        public string reheatCompId { get; set; }
        public string elecHeaterVoltageId { get; set; }
        public string preheatElecHeaterInstallationId { get; set; }
        public string heatElecHeaterInstallcationId { get; set; }
        public string damperActuatorId { get; set; }

    }
}