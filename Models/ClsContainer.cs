using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxygen8SelectorServer.Models
{
    public class ClsContainer
    {
        private ClsContElements objContElem;


        public ClsContainer()
        {
        }


        public ClsContainer(int _intLoggedUserID, int _intJobID, int _intUnitNo)
        {
            objContElem = new ClsContElements { };
            objContElem.objCLoggedUser = new ClsUser(_intLoggedUserID);
            objContElem.objCJobInfo = new ClsProjectInfo(_intJobID);
            objContElem.objCCreatedUser = new ClsUser(objContElem.objCJobInfo.intCreatedUserID);

            objContElem.objCGeneral = new ClsGeneral(_intJobID, _intUnitNo);
            objContElem.objCAirFlowData = new ClsAirFlowData(_intJobID, _intUnitNo);
            objContElem.objCAirFlowData.CalculateAirProperty();

            //objCont.objCElectrical = new ClsElectrical(_intJobID, _intUnitNo);
            //objCont.objControls = new ClsControls(_intJobID, _intUnitNo);
            objContElem.objCCompItems = new ClsComponentItems(_intJobID, _intUnitNo);


            //Filter
            if (objContElem.objCCompItems.objCompOpt.intOA_FilterModelID > 1)
            {
                objContElem.objCOA_Filter = new ClsFilter(_intJobID, _intUnitNo, ClsID.intFilterLocationOutdoorAirFilterID, objContElem.objCCompItems.objCompOpt.intOA_FilterModelID, objContElem.objCCompItems.objCompOpt.dblOA_FilterPD);
            }

            if (objContElem.objCCompItems.objCompOpt.intSA_FinalFilterModelID > 1)
            {
                objContElem.objCSA_Filter = new ClsFilter(_intJobID, _intUnitNo, ClsID.intFilterLocationFinalFilterID, objContElem.objCCompItems.objCompOpt.intOA_FilterModelID, 0d);
            }



            if (objContElem.objCCompItems.objCompOpt.intPreheatCompID == ClsID.intCompElecHeaterID)
            {
                objContElem.objCPreheatElecHeater = new ClsElectricHeater(_intJobID, _intUnitNo);
            }




            if (objContElem.objCCompItems.objCompOpt.intHeatingCompID == ClsID.intCompElecHeaterID)
            {
                objContElem.objCHeatingElecHeater = new ClsElectricHeater(_intJobID, _intUnitNo);
            }




            //Fan
            //objContElem.objCFanSupply = new ClsFanZIEHL_ABEGG(_intJobID, _intUnitNo);


            if (objContElem.objCGeneral.intUnitTypeID == ClsID.intUnitTypeHRV_ID || objContElem.objCGeneral.intUnitTypeID == ClsID.intUnitTypeERV_ID)
            {
                if (objContElem.objCCompItems.objCompOpt.intRA_FilterModelID > 1)
                {
                    objContElem.objCRA_Filter = new ClsFilter(_intJobID, _intUnitNo, ClsID.intFilterLocationReturnAirFilterID, objContElem.objCCompItems.objCompOpt.intRA_FilterModelID, objContElem.objCCompItems.objCompOpt.dblRA_FilterPD);
                }


                switch (objContElem.objCGeneral.intProductTypeID)
                {
                    case ClsID.intProdTypeNovaID:
                        objContElem.objCHX_CORE = new ClsHeatExchCORE(_intJobID, _intUnitNo, objContElem.objCGeneral.intUnitModelID);
                        break;
                    case ClsID.intProdTypeVentumID:
                    case ClsID.intProdTypeVentumLiteID:
                    default:
                        break;
                }

                //objContElem.objCFanExhaust = new ClsFanZIEHL_ABEGG(_intJobID, _intUnitNo);
            }
        }


        public ClsContElements get_objContElem()
        {
            return objContElem;
        }
    }

    public class ClsContElements
    {
        public ClsUser objCCreatedUser { get; set; }
        public ClsUser objCLoggedUser { get; set; }
        public ClsProjectInfo objCJobInfo { get; set; }
        public ClsGeneral objCGeneral { get; set; }
        public ClsAirFlowData objCAirFlowData { get; set; }
        //public ClsElectrical objCElectrical { get; set; }
        public ClsComponentItems objCCompItems { get; set; }
        //public ClsLouver objCOA_Louver { get; set; }
        //public ClsLouver objCEA_Louver { get; set; }
        //public ClsDamper objCOA_Damper { get; set; }
        //public ClsDamper objCRA_Damper { get; set; }
        public ClsFilter objCOA_Filter { get; set; }
        public ClsFilter objCSA_Filter { get; set; }
        public ClsFilter objCRA_Filter { get; set; }
        public ClsHeatExchCORE objCHX_CORE { get; set; }
        public ClsElectricHeater objCPreheatElecHeater { get; set; }
        public ClsElectricHeater objCHeatingElecHeater { get; set; }

        //public ClsPricing objCPricing { get; set; }
    }
}