using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Threading;
using iTextSharp.text.pdf;

namespace Oxygen8SelectorServer.Models
{
    public class ClsPerformanceERU
    {
        private DataTable dtComponentList = new DataTable();

        private ClsContainer objContainer;
        private ClsContElements objContElem;
        private ClsDrawing objDwg;
        private ClsCutsheetsPDF objCutSheet;
        public ClsPricing objPricing { get; set; }

        //PDF
        byte[] bytArrPDF_SubmittalCoverPage;
        byte[] bytArrPDF_Submittal;
        byte[] bytArrPDF_SelectionCoverPage;
        byte[] bytArrPDF_Selection;
        byte[] bytArrPDF_Drawing;
        byte[] bytArrPDF_Cutsheet;

        private double dblHeatExLvgDB = 0d;
        private bool bolHeatingReheatSameComp = false;
        private double dblHeatingCap = 0d;
        private double dblReheatCap = 0;



        private Random rndFPI = new Random();


        //bool bolERV = false;
        //bool bolAHU = false;
        //bool bolFC = false;


        public ClsPerformanceERU()
        {
        }

        public ClsPerformanceERU(int _intLoggedUserID, int _intJobID, int _intUnitNo)
        {
            objContainer = new ClsContainer(_intLoggedUserID, _intJobID, _intUnitNo);
            objContElem = objContainer.get_objContElem();
            //objCont = new ClsContainers {};           
        }


        public void CalculatePerformance()
        {
            ExecutePerformance();
        }



        #region Execute Performance
        private void ExecutePerformance()
        {
            //Preheat
            if (objContElem.objCPreheatElecHeater != null)
            {
                ExecutePreheatElectricHeater();
            }

            int intCount = 0;
            //Heat Exchanger
            switch (objContElem.objCGeneral.intProductTypeID)
            {
                case ClsID.intProdTypeNovaID:
                    if (objContElem.objCHX_CORE != null)
                    {
                        while (intCount < 20)
                        {
                            Thread.Sleep(2000);
                            ExecuteFixedPlatePrimaryCORE();
                            intCount++;
                        }
                    }
                    break;
                case ClsID.intProdTypeVentumID:
                case ClsID.intProdTypeVentumLiteID:
                case ClsID.intProdTypeTerraID:
                    break;
                default:
                    break;
            }


            if (objContElem.objCPreheatElecHeater != null)
            {
                ExecuteUpdatePreheatElecCoilStdCoil();
            }



            //Heating (DX Heat Pump)
            if (objContElem.objCCompItems.objCompOpt.intHeatingCompID == ClsID.intCompHWC_ID && objContElem.objCCompItems.objCompOpt.intReheatCompID == ClsID.intCompHWC_ID)
            {
                bolHeatingReheatSameComp = true;
                dblHeatingCap = 1.08d * objContElem.objCAirFlowData.get_intWinterOutdoorAirCFM_Actual() * (dblHeatExLvgDB - objContElem.objCCompItems.objCompOpt.dblHeatingSetpointDB);
                dblReheatCap = 1.08d * objContElem.objCAirFlowData.get_intWinterOutdoorAirCFM_Actual() * (objContElem.objCCompItems.objCompOpt.dblCoolingSetpointDB - objContElem.objCCompItems.objCompOpt.dblReheatSetpointDB);
            }
            else if (objContElem.objCCompItems.objCompOpt.intHeatingCompID == ClsID.intCompElecHeaterID && objContElem.objCCompItems.objCompOpt.intReheatCompID == ClsID.intCompElecHeaterID)
            {
                bolHeatingReheatSameComp = true;
                dblHeatingCap = 1.08d * objContElem.objCAirFlowData.get_intWinterOutdoorAirCFM_Actual() * (dblHeatExLvgDB - objContElem.objCCompItems.objCompOpt.dblHeatingSetpointDB);
                dblReheatCap = 1.08d * objContElem.objCAirFlowData.get_intWinterOutdoorAirCFM_Actual() * (objContElem.objCCompItems.objCompOpt.dblCoolingSetpointDB - objContElem.objCCompItems.objCompOpt.dblReheatSetpointDB);
            }

            dblHeatingCap = Math.Abs(dblHeatingCap);
            dblReheatCap = Math.Abs(dblReheatCap);




            //Heating
            if (objContElem.objCHeatingElecHeater != null)
            {
                ExecuteHeatingElectricHeater();
            }



            //if (objContElem.objCGeneral.intProductTypeID == ClsID.intProductTypeNovaID)
            //{
            CalcAndSavePricing();
            //}

            //Save Performance to PDF File
            SaveSelectionPDF();
            SaveSubimittalPDF();
            SaveSubmittalExcel();

            //Set PDF
            //ReportPreliminary(objCont);

            //}
            //catch (Exception e)
            //{
            //    //MessageBox.Show(e.ToString());
            //}
        }
        #endregion


        //*****************************************************************************************************************************





        #region Preheat if required
        private void ExecuteRequiredPreheat()
        {
            //ClsDB.ExecuteSQL("UPDATE `" + ClsDBT.strSavCompOption + "` SET `preheat_comp_id`=" + ClsID.intUnitHeatingCoolingElecHeaterID + " WHERE `job_id`=" + objContElem.objCJobInfo.get_intJobID() + " AND `unit_no`=" + objContElem.objCGeneral.get_intUnitNo());
            int intElecHeatInstallID = 0;

            if (objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeNovaID || objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumID)
            {
                intElecHeatInstallID = ClsID.intElecHeaterInstallInCasingID;
            }
            else if (objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumLiteID)
            {
                intElecHeatInstallID = ClsID.intElecHeaterInstallDuctMountedID;
            }

            ClsDB.ExecuteSQL("UPDATE `" + ClsDBT.strSavCompOption + "` SET `preheat_comp_id`=" + ClsID.intCompElecHeaterID + ", `preheat_elec_heater_installation_id`=" + intElecHeatInstallID + " WHERE `job_id`=" + objContElem.objCJobInfo.intJobID + " AND `unit_no`=" + objContElem.objCGeneral.intUnitNo);

            objContElem.objCCompItems.objCompOpt.intPreheatElecHeaterInstallationID = intElecHeatInstallID;

            DataTable dtTemp = ClsDB.get_dtByID(ClsDBT.strSelElectricHeaterInstallation, intElecHeatInstallID);

            objContElem.objCCompItems.objCompOpt.strPreheatElecHeaterInstallation = dtTemp.Rows.Count > 0 ? dtTemp.Rows[0]["items"].ToString() : "";

            objContElem.objCPreheatElecHeater = new ClsElectricHeater(objContElem.objCJobInfo.intJobID, objContElem.objCGeneral.intUnitNo);

            ExecutePreheatElectricHeater();
        }
        #endregion






        #region Execute Preheat Electric Heater
        private void ExecutePreheatElectricHeater()
        {
            objContElem.objCPreheatElecHeater.setElecHeater_IO_Data(objContElem.objCGeneral, objContElem.objCCompItems, false);
            objContElem.objCPreheatElecHeater.objElecHeaterIO.intUoM = objContElem.objCJobInfo.intUoM_ID;

            objContElem.objCPreheatElecHeater.objElecHeaterIO.intUnitModelID = objContElem.objCGeneral.intUnitModelID;
            objContElem.objCPreheatElecHeater.objElecHeaterIO.intUnitOrientationID = objContElem.objCGeneral.intOrientationID;
            //objContElem.objCPreheatElecHeater.objElecHeaterIO.intVolt = objContElem.objCGeneral.intVolt;
            objContElem.objCPreheatElecHeater.objElecHeaterIO.intAirFlow = objContElem.objCAirFlowData.get_intSummerSupplyAirCFM();
            objContElem.objCPreheatElecHeater.objElecHeaterIO.dblEntAirDB = objContElem.objCJobInfo.dblWinterOutdoorAirDB;
            objContElem.objCPreheatElecHeater.objElecHeaterIO.dblEntAirWB = objContElem.objCJobInfo.dblWinterOutdoorAirWB;
            objContElem.objCPreheatElecHeater.objElecHeaterIO.dblEntAirRH = objContElem.objCJobInfo.dblWinterOutdoorAirRH;

            objContElem.objCPreheatElecHeater.objElecHeaterIO.dblEntAirGrains = (double)ClsPsyCalc.get_fltGrainsByDB_WB((float)objContElem.objCPreheatElecHeater.objElecHeaterIO.dblEntAirDB,
                                                                                                                        (float)objContElem.objCPreheatElecHeater.objElecHeaterIO.dblEntAirWB,
                                                                                                                         objContElem.objCJobInfo.intAltitude);

            objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirGrains = objContElem.objCPreheatElecHeater.objElecHeaterIO.dblEntAirGrains;



            if (objContElem.objCGeneral.intUnitTypeID == ClsID.intUnitTypeHRV_ID || objContElem.objCGeneral.intUnitTypeID == ClsID.intUnitTypeERV_ID)
            {
                objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB = objContElem.objCJobInfo.dblWinterOutdoorAirDB + 1d;

                if (objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB < -22d)
                {
                    objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB = -22d;
                }
                else if (objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB < 15d)
                {
                    if (objContElem.objCJobInfo.dblWinterOutdoorAirDB < 15d && objContElem.objCJobInfo.dblWinterReturnAirRH > 40d)
                    {
                        objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB = 15d;
                    }
                }
            }
            else if (objContElem.objCGeneral.intUnitTypeID == ClsID.intUnitTypeAHU_ID)
            {
                objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB = objContElem.objCCompItems.objCompOpt.dblPreheatSetpointDB;
            }




            //objCont.objCPreheatElecHeater.objElecHeaterIO.dblKW = (1.08d * objCont.objCPreheatElecHeater.objElecHeaterIO.intAirFlow * (objCont.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirTemp - objCont.objCPreheatElecHeater.objElecHeaterIO.dblEntAirTemp)) / 3412.142d;
            ((ClsElectricHeater)objContElem.objCPreheatElecHeater).CalcPreheatPerf();


            objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirWB = (double)ClsPsyCalc.get_fltWB_ByDB_Grains((float)objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB,
                                                                                                                        (float)objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirGrains,
                                                                                                                        objContElem.objCJobInfo.intAltitude);

            objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirRH = (double)ClsPsyCalc.get_fltRH_ByDB_Grains((float)objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB,
                                                                                                                        (float)objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirGrains,
                                                                                                                        objContElem.objCJobInfo.intAltitude);

            ////Safety
            //if (bolAHU || bolERV)
            //{
            //    ((ClsElectricHeater)objCont.objCPreheatElecHeater).objElecHeaterIO.dblKW = Math.Round(((ClsElectricHeater)objCont.objCPreheatElecHeater).objElecHeaterIO.dblKW * 1.25d, 2);
            //}

            ((ClsElectricHeater)objContElem.objCPreheatElecHeater).setKw();
            //ClsDB.UpdateElectricHeaterStdCoilNo(objContElem.objCJobInfo.intJobID, objContElem.objCGeneral.intUnitNo, "preheat_elec_heater_std_coil_no", objContElem.objCPreheatElecHeater.objElecHeaterIO.intStandardCoilNo);

        }
        #endregion





        #region Execute Fixed Plate Primary CORE
        private void ExecuteFixedPlatePrimaryCORE()
        {
            bool bolRecalcPreheatWithCondWar = false;

            do
            {
                //Summer
                objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.intUoM = objContElem.objCJobInfo.intUoM_ID;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.dblInAltitude = objContElem.objCJobInfo.intAltitude;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.dblInPressurePSI = objContElem.objCJobInfo.dblPressure_PSI;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.dblInOutsideAirCFM = objContElem.objCAirFlowData.get_intSummerSupplyAirCFM();
                objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.dblInOutsideAirDB = objContElem.objCJobInfo.dblSummerOutdoorAirDB;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.dblInOutsideAirWB = objContElem.objCJobInfo.dblSummerOutdoorAirWB;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.dblInOutsideAirRH = objContElem.objCJobInfo.dblSummerOutdoorAirRH;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.dblInReturnAirCFM = objContElem.objCAirFlowData.get_intSummerReturnAirCFM();
                objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.dblInReturnAirDB = objContElem.objCJobInfo.dblSummerReturnAirDB;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.dblInReturnAirWB = objContElem.objCJobInfo.dblSummerReturnAirWB;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.dblInReturnAirRH = objContElem.objCJobInfo.dblSummerReturnAirRH;
                //((ClsHeatExchCORE)objContElem.objCHeatExchCORE).CalcPerfSummer();


                //Winter
                objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.intUoM = objContElem.objCJobInfo.intUoM_ID;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInAltitude = objContElem.objCJobInfo.intAltitude;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInPressurePSI = objContElem.objCJobInfo.dblPressure_PSI;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirCFM = objContElem.objCAirFlowData.get_intWinterSupplyAirCFM();


                if (objContElem.objCPreheatElecHeater != null)
                {
                    objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirDB = objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB;
                    objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirWB = objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirWB;
                    objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirRH = objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirRH;
                    //objContElem.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblInOutsideAirWB = objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB - 0.1;
                    //objContElem.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblInOutsideAirRH = 100d;
                }
                else
                {
                    objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirDB = objContElem.objCJobInfo.dblWinterOutdoorAirDB;
                    objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirWB = objContElem.objCJobInfo.dblWinterOutdoorAirWB;
                    objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirRH = objContElem.objCJobInfo.dblWinterOutdoorAirRH;
                }


                objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInReturnAirCFM = objContElem.objCAirFlowData.get_intWinterReturnAirCFM();
                objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInReturnAirDB = objContElem.objCJobInfo.dblWinterReturnAirDB;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInReturnAirWB = objContElem.objCJobInfo.dblWinterReturnAirWB;
                objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInReturnAirRH = objContElem.objCJobInfo.dblWinterReturnAirRH;
                ((ClsHeatExchCORE)objContElem.objCHX_CORE).CalcPerfWinter();


                //Preheat not selected and condensation occured on Heat exchanger. Program should automatically add an Electric Prheat if Preheat is set to Auto
                if (objContElem.objCCompItems.objCompOpt.intPreheatCompID == ClsID.intCompAutoID)
                {

                    ExecuteRequiredPreheat();
                }
                //---------------------------------------------------------------------------------------------------------------------------------------------------



                if (objContElem.objCPreheatElecHeater != null)
                {
                    bolRecalcPreheatWithCondWar = ((objContElem.objCPreheatElecHeater.objElecHeaterIO.bolKW_Max == false) &&
                                                   (objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar == true));

                    if (objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar == true)
                    {
                        //Preheat Electric Heater
                        objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB += 1d;

                        objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirWB = (double)ClsPsyCalc.get_fltWB_ByDB_Grains((float)objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB,
                                                                                                            (float)objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirGrains,
                                                                                                            objContElem.objCJobInfo.intAltitude);

                        objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirRH = (double)ClsPsyCalc.get_fltRH_ByDB_Grains((float)objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB,
                                                                                                                                    (float)objContElem.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirGrains,
                                                                                                                                    objContElem.objCJobInfo.intAltitude);

                        //objCont.objCPreheatElecHeater.objElecHeaterIO.dblKW = (1.08d * objCont.objCPreheatElecHeater.objElecHeaterIO.intAirFlow * (objCont.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirTemp - objCont.objCPreheatElecHeater.objElecHeaterIO.dblEntAirTemp)) / 3412.142d;
                    }
                }
            }
            while (bolRecalcPreheatWithCondWar);


            objContElem.objCHX_CORE.bolAHRISummer = objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.dblInOutsideAirDB < ClsGV.dblAHRI_SummerOA_DB_Max ? true : false;

            if (objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirDB < ClsGV.dblAHRI_WinterOA_DB_Min ||
                objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirRH > ClsGV.dblAHRI_WinterOA_RH_Max)
            {
                objContElem.objCHX_CORE.bolAHRIWinter = false;
            }
            else
            {
                objContElem.objCHX_CORE.bolAHRIWinter = true;
            }

            objContElem.objCHX_CORE.bolAHRISummerWinter = (objContElem.objCHX_CORE.bolAHRISummer == true && objContElem.objCHX_CORE.bolAHRIWinter == true) ? true : false;


            if (objContElem.objCPreheatElecHeater != null)
            {
                ((ClsElectricHeater)objContElem.objCPreheatElecHeater).objElecHeaterIO.bolKW_Max = true;

                ((ClsElectricHeater)objContElem.objCPreheatElecHeater).CalcPreheatPerf();

                //Safefty
                //((ClsElectricHeater)objCont.objCPreheatElecHeater).objElecHeaterIO.dblKW = Math.Round(((ClsElectricHeater)objCont.objCPreheatElecHeater).objElecHeaterIO.dblKW * 1.25d, 2);
                ((ClsElectricHeater)objContElem.objCPreheatElecHeater).objElecHeaterIO.dblKW = Math.Round(((ClsElectricHeater)objContElem.objCPreheatElecHeater).objElecHeaterIO.dblKW * 1.1d, 2);
                ((ClsElectricHeater)objContElem.objCPreheatElecHeater).setKw();

                if (((ClsElectricHeater)objContElem.objCPreheatElecHeater).objElecHeaterIO.bolKW_Max == true)
                {
                    ((ClsElectricHeater)objContElem.objCPreheatElecHeater).objElecHeaterIO.dblKW = 0; //Elec heater capacity not enough
                    objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar = true;
                }
            }

            dblHeatExLvgDB = objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutSupplyAirDB;
        }
        #endregion


        #region Execute Update Preheat Electric Coil Std Coil
        private void ExecuteUpdatePreheatElecCoilStdCoil()
        {
            //((ClsElectricHeater)objContElem.objCPreheatElecHeater).setKw();
            ClsDB.UpdateElectricHeaterStdCoilNo(objContElem.objCJobInfo.intJobID, objContElem.objCGeneral.intUnitNo, "preheat_elec_heater_std_coil_no", objContElem.objCPreheatElecHeater.objElecHeaterIO.intStandardCoilNo);
        }
        #endregion


        #region Execute Heating Electric Heater
        private void ExecuteHeatingElectricHeater()
        {
            double dblHX_OutSupplyAirDB = 0d;
            objContElem.objCHeatingElecHeater.setElecHeater_IO_Data(objContElem.objCGeneral, objContElem.objCCompItems, true);
            objContElem.objCHeatingElecHeater.objElecHeaterIO.intUoM = objContElem.objCJobInfo.intUoM_ID;

            objContElem.objCHeatingElecHeater.objElecHeaterIO.intUnitModelID = objContElem.objCGeneral.intUnitModelID;
            objContElem.objCHeatingElecHeater.objElecHeaterIO.intUnitOrientationID = objContElem.objCGeneral.intOrientationID;
            //objContElem.objCHeatingElecHeater.objElecHeaterIO.intVolt = objContElem.objCGeneral.intVolt;
            objContElem.objCHeatingElecHeater.objElecHeaterIO.intAirFlow = objContElem.objCAirFlowData.get_intSummerSupplyAirCFM();

            if (objContElem.objCGeneral.intUnitTypeID == ClsID.intUnitTypeHRV_ID || objContElem.objCGeneral.intUnitTypeID == ClsID.intUnitTypeERV_ID)
            {
                if (objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeNovaID)
                {
                    dblHX_OutSupplyAirDB = objContElem.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutSupplyAirDB;
                }
                else if (objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumID || objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumLiteID)
                {
                }


                objContElem.objCHeatingElecHeater.objElecHeaterIO.dblEntAirDB = dblHX_OutSupplyAirDB;


                //if ((objContElem.objCCompItems.objCompOpt.intCoolingCompID == ClsID.intUnitHeatCoolCWC_ID || objContElem.objCCompItems.objCompOpt.intCoolingCompID == ClsID.intUnitHeatCoolDX_ID) &&
                //    objContElem.objCCompItems.objCompOpt.intReheatCompID == ClsID.intUnitHeatCoolNA_ID)
                //{
                //    objContElem.objCHeatingElecHeater.objElecHeaterIO.dblEntAirDB = Math.Min(dblHX_OutSupplyAirDB, objContElem.objCCompItems.objCompOpt.dblCoolingSetpointDB);
                //    //objContElem.objCHeatingElecHeater.objElecHeaterIO.dblEntAirDB = dblSupplyAirDB;
                //}
            }
            else if (objContElem.objCGeneral.intUnitTypeID == ClsID.intUnitTypeAHU_ID)
            {
                objContElem.objCHeatingElecHeater.objElecHeaterIO.dblEntAirDB = objContElem.objCJobInfo.dblWinterOutdoorAirDB;
            }

            objContElem.objCHeatingElecHeater.objElecHeaterIO.dblLvgAirDB = objContElem.objCCompItems.objCompOpt.dblHeatingSetpointDB;
            objContElem.objCHeatingElecHeater.CalcHeatingPerf();
            objContElem.objCHeatingElecHeater.setKw();



            ////objCont.objCPreheatElecHeater.objElecHeaterIO.dblKW = (1.08d * objCont.objCPreheatElecHeater.objElecHeaterIO.intAirFlow * (objCont.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirTemp - objCont.objCPreheatElecHeater.objElecHeaterIO.dblEntAirTemp)) / 3412.142d;
            //objContElem.objCHeatingElecHeater.CalcHeatingPerf();
            ClsDB.UpdateElectricHeaterStdCoilNo(objContElem.objCJobInfo.intJobID, objContElem.objCGeneral.intUnitNo, "heating_elec_heater_std_coil_no", objContElem.objCHeatingElecHeater.objElecHeaterIO.intStandardCoilNo);


            //objContElem.objCHeatingElecHeater.setKw();
            //ClsDB.UpdateElectricHeaterStdCoilNo(objContElem.objCJobInfo.intJobID, objContElem.objCGeneral.intUnitNo, "heating_elec_heater_std_coil_no", objContElem.objCHeatingElecHeater.objElecHeaterIO.intStandardCoilNo);

        }
        #endregion



        //Calculate Pricing
        public void CalcAndSavePricing()
        {
            //objPricing = new ClsPricing(objContElem);
            objPricing = new ClsPricing(objContElem.objCLoggedUser.intUAL, objContElem.objCJobInfo.intJobID, objContElem.objCGeneral.intUnitNo);
            double dblUnitPrice = objPricing.dblPriceAllUnit;
            ClsDB.UpdateUnitPrice(objContElem.objCJobInfo.intJobID, objContElem.objCGeneral.intUnitNo, dblUnitPrice);
        }


        //Not Used - Do not delete
        public void ReportPreliminary(ClsContElements _objCont)
        {
            //ClsSubmittalReportPDF_old objRepPDF = new ClsSubmittalReportPDF_old();
            ClsSubmittalReportPDF objRepPDF = new ClsSubmittalReportPDF();
            List<byte[]> lst_bytArr = new List<byte[]>();
            List<byte[]> lst_bytArrSaveToDB = new List<byte[]>();
            List<PdfPTable> lst_PdfPTable_ScheduleSubmittal = new List<PdfPTable>();
            string strHeaderImage = "";
            string strFooterImage = "Images/img_footer.jpg";

            strHeaderImage = _objCont.objCGeneral.intUnitModelID > 0 ? "Images/img_header_" + objContElem.objCGeneral.strUnitModelValue.ToLower() + ".jpg" : "Images/img_header.jpg";

            //byte[] bytArrPDF_CoverPage;
            //byte[] bytArrPDF_Submittal;
            //byte[] bytArrPDF_Drawing;

            if (_objCont.objCGeneral.intUnitNo > 0)
            {
                //Cover Page
                //byte[] bytArrPDF_CoverPage = objRepPDF.getBytArr(ClsOutputPDF.get_pdfPtblCoverPageOld(_objCont), ClsID.enmPageOrientation.Portrait);
                byte[] bytArrPDF_CoverPage = objRepPDF.getBytArrCoverPage(ClsSubmittalOutputPDF.get_pdfPtblCoverPage(_objCont.objCJobInfo.intJobID), ClsID.enmPageOrientation.Portrait, strHeaderImage, strFooterImage, objContElem.objCGeneral.intProductTypeID, objContElem.objCGeneral.strUnitModelValue.ToUpper(), true, false);
                lst_bytArr.Add(bytArrPDF_CoverPage);


                //Schedule
                lst_PdfPTable_ScheduleSubmittal = ClsSubmittalOutputPDF.get_lst_lstPdfPtblSchedule(_objCont);


                if (lst_PdfPTable_ScheduleSubmittal.Count > 0)
                {
                    byte[] bytArrPDF_Submittal = objRepPDF.getBytArrSubmittal(lst_PdfPTable_ScheduleSubmittal, strHeaderImage, strFooterImage, objContElem.objCGeneral.strUnitModelValue.ToUpper());
                    lst_bytArr.Add(bytArrPDF_Submittal);
                    lst_bytArrSaveToDB.Add(bytArrPDF_Submittal);
                }


                //Drawing
                //bytArrPDF_Drawing = objRepPDF.getBytArr(ClsOutputPDF.get_pdfPtblModelImage(_objCont.objCGeneral.get_intUnitModelID()), ClsID.enmPageOrientation.Portrait, "", "", false);
                bytArrPDF_Drawing = objRepPDF.getBytArrDrawing(ClsSubmittalOutputPDF.get_pdfPtblModelImage(_objCont.objCGeneral.intJobID, _objCont.objCGeneral.intUnitNo), ClsID.enmPageOrientation.Portrait, "", "");
                lst_bytArr.Add(bytArrPDF_Drawing);
                lst_bytArrSaveToDB.Add(bytArrPDF_Drawing);


                //Cutsheet
                //bytArrPDF_Drawing = objRepPDF.getBytArr(ClsOutputPDF.get_pdfPtblModelImage(_objCont.objCGeneral.get_intUnitModelID()), ClsID.enmPageOrientation.Portrait, "", "", false);
                bytArrPDF_Drawing = objRepPDF.getBytArrDrawing(ClsSubmittalOutputPDF.get_pdfPtblModelImage(_objCont.objCGeneral.intJobID, _objCont.objCGeneral.intUnitNo), ClsID.enmPageOrientation.Portrait, "", "");
                lst_bytArr.Add(bytArrPDF_Drawing);
                lst_bytArrSaveToDB.Add(bytArrPDF_Drawing);


                //Concatenating All byteArray
                byte[] bytArrFiles = ClsPDF_Tools.concatAndAddContent(lst_bytArr);
                byte[] bytArrFilesSaveToDB = ClsPDF_Tools.concatAndAddContent(lst_bytArrSaveToDB);


                ////Save to Database
                //ClsDB.UpdatePDF(bytArrFilesSaveToDB, ClsDBT.strSavGeneral, _objCont.objCJobInfo.get_intJobID(), _objCont.objCGeneral.get_intUnitNo());

                //Save to Folder
                string strPathAndFile = HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderSubmittal_Schedules + "/" + _objCont.objCJobInfo.intJobID.ToString() + "_" + objContElem.objCGeneral.intUnitNo.ToString() + ".pdf");
                System.IO.File.WriteAllBytes(strPathAndFile, bytArrFilesSaveToDB);


                //ClsPDF_Tools.ShowPDF(bytArrPDF_Submittal, _objCont.objCJobInfo.get_intJobID().ToString() + "_" + _objCont.objCGeneral.get_intUnitNo().ToString());
                //ClsPDF_Tools.ShowPDF(bytArrFiles, _objCont.objCJobInfo.get_intJobID().ToString() + "_" + _objCont.objCGeneral.get_intUnitNo().ToString());
                ClsPDF_Tools.ShowPDF(bytArrFiles, _objCont.objCJobInfo.strCompanyName + " - " + _objCont.objCJobInfo.strJobName + " - Oxygen8 Submittal");
            }
        }



        public void SaveSelectionPDF()
        {
            ClsSelectionReportPDF objRepPDF = new ClsSelectionReportPDF();
            //List<byte[]> lst_bytArr = new List<byte[]>();
            List<byte[]> lst_bytArrSelSaveToFile = new List<byte[]>();
            List<byte[]> lst_bytArrSubSaveToFile = new List<byte[]>();
            List<PdfPTable> lst_PdfPTable_Selection = new List<PdfPTable>();
            string strHeaderImage = "";
            string strFooterImage = "Images/img_footer.jpg";
            string strPathAndFile = "";

            //strHeaderImage = objContElem.objCGeneral.get_intUnitModelID() > 0 ? "Images/img_header_" + objContElem.objCGeneral.get_strUnitModelValue().ToLower() + ".jpg" : "Images/img_header.jpg";
            strHeaderImage = "Images/img_logo_oxygen8.png";

            //byte[] bytArrPDF_CoverPage;
            //byte[] bytArrPDF_Submittal;
            //byte[] bytArrPDF_Drawing;

            if (objContElem.objCGeneral.intUnitNo > 0)
            {
                //Cover Page
                //byte[] bytArrPDF_CoverPage = objRepPDF.getBytArr(ClsOutputPDF.get_pdfPtblCoverPageOld(_objCont), ClsID.enmPageOrientation.Portrait);

                bool bolCoreAHRICertified = objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeNovaID ? objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.bolAHRICertified : false;
                //bolCoreAHRICertified = true;
                bytArrPDF_SelectionCoverPage = objRepPDF.getBytArrCoverPage(ClsID.intReportStageSelecionID, ClsSelectionOutputPDF.get_pdfPtblCoverPage(objContElem.objCJobInfo.intJobID), ClsID.enmPageOrientation.Portrait, strHeaderImage, strFooterImage, objContElem.objCGeneral.intProductTypeID, objContElem.objCGeneral.strUnitModelValue.ToUpper(), true, bolCoreAHRICertified);
                //lst_bytArr.Add(bytArrPDF_CoverPage);



                //Schedule
                lst_PdfPTable_Selection = ClsSelectionOutputPDF.get_lst_lstPdfPtblSchedule(objContElem);

                if (lst_PdfPTable_Selection.Count > 0)
                {
                    bytArrPDF_Selection = objRepPDF.getBytArrSelection(ClsID.intReportStageSelecionID, lst_PdfPTable_Selection, strHeaderImage, strFooterImage, objContElem.objCGeneral.strUnitModelValue.ToUpper());
                    lst_bytArrSelSaveToFile.Add(bytArrPDF_Selection);
                    bytArrPDF_Submittal = objRepPDF.getBytArrSelection(ClsID.intReportStageSubmittalID, lst_PdfPTable_Selection, strHeaderImage, strFooterImage, objContElem.objCGeneral.strUnitModelValue.ToUpper());
                    lst_bytArrSubSaveToFile.Add(bytArrPDF_Submittal);
                }


                //if (objContElem.objCUser.intAccessLevel == ClsID.intUAL_Admin || objContElem.objCUser.intAccessLevel == ClsID.intUAL_Internal || objContElem.objCUser.intAccessLevel == ClsID.intUAL_InternalLevel_2)
                //{
                //Drawing
                objDwg = new ClsDrawing(objContElem.objCGeneral.intJobID, objContElem.objCGeneral.intUnitNo);
                DataTable dtDwgList = objDwg.dtDrawingList;

                if (dtDwgList != null)
                {
                    bytArrPDF_Drawing = objRepPDF.getBytArrDrawing(ClsSelectionOutputPDF.get_pdfPtblModelImageInternal(dtDwgList), ClsID.enmPageOrientation.Portrait, "", "");
                    lst_bytArrSelSaveToFile.Add(bytArrPDF_Drawing);
                    lst_bytArrSubSaveToFile.Add(bytArrPDF_Drawing);
                }

                objCutSheet = new ClsCutsheetsPDF(objContElem.objCLoggedUser.intUAL, objContElem.objCGeneral.intJobID, objContElem.objCGeneral.intUnitNo);
                DataTable dtCutSheetList = objCutSheet.dtSelectionCutsheetList;

                List<byte[]> lst_bytArrCutsheet = new List<byte[]>();

                for (int i = 0; i < dtCutSheetList.Rows.Count; i++)
                {
                    //lst_bytArrCutsheet.Add(ClsPDF_Tools.get_byt_arrFromPDF(dtCutSheetList.Rows[i]["PathAndFile"].ToString()));

                    byte[] bytArrCutsheet = ClsPDF_Tools.get_byt_arrFromPDF(dtCutSheetList.Rows[i]["PathAndFile"].ToString());

                    if (bytArrCutsheet != null)
                    {
                        lst_bytArrCutsheet.Add(bytArrCutsheet);

                        //lst_bytArrSaveToFile.Add(bytArrPDF_Cutsheet);
                    }
                }


                if (lst_bytArrCutsheet.Count > 0)
                {
                    bytArrPDF_Cutsheet = ClsPDF_Tools.concatAndAddContent(lst_bytArrCutsheet);
                    //bytArrPDF_Cutsheet = ClsPDF_Tools.concatAndAddContent_1(lst_bytArrCutsheet);
                }
                //}
                //else
                //{
                //    bytArrPDF_Drawing = objRepPDF.getBytArrDrawing(ClsSelectionOutputPDF.get_pdfPtblModelImage(objContElem.objCGeneral.get_intJobID(), objContElem.objCGeneral.get_intUnitNo()), ClsID.enmPageOrientation.Portrait, "", "");
                //    lst_bytArrSaveToFile.Add(bytArrPDF_Drawing);
                //}


                //Concatenating All byteArray
                //byte[] bytArrFiles = ClsPDF_Tools.concatAndAddContent(lst_bytArr);
                byte[] bytArrSelFilesSaveToFile = ClsPDF_Tools.concatAndAddContent(lst_bytArrSelSaveToFile);
                byte[] bytArrSubFilesSaveToFile = ClsPDF_Tools.concatAndAddContent(lst_bytArrSubSaveToFile);


                ////Save to Database
                //ClsDB.UpdatePDF(bytArrFilesSaveToFile, ClsDBT.strSavGeneral, _objCont.objCJobInfo.get_intJobID(), _objCont.objCGeneral.get_intUnitNo());


                //Save to Folder
                //strPathAndFile = HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderPDF_Submittal + "/" + objCont.objCJobInfo.get_intJobID().ToString() + "_cover_page.pdf");
                //System.IO.File.WriteAllBytes(strPathAndFile, bytArrPDF_CoverPage);

                strPathAndFile = HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderSubmittal_Schedules + "/" + objContElem.objCJobInfo.intJobID.ToString() + "_" + objContElem.objCGeneral.intUnitNo.ToString() + "_SEL.pdf");
                System.IO.File.WriteAllBytes(strPathAndFile, bytArrSelFilesSaveToFile);

                strPathAndFile = HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderSubmittal_Schedules + "/" + objContElem.objCJobInfo.intJobID.ToString() + "_" + objContElem.objCGeneral.intUnitNo.ToString() + "_SUB.pdf");
                System.IO.File.WriteAllBytes(strPathAndFile, bytArrSubFilesSaveToFile);

                //ClsPDF_Tools.ShowPDF(bytArrPDF_Submittal, _objCont.objCJobInfo.get_intJobID().ToString() + "_" + _objCont.objCGeneral.get_intUnitNo().ToString());
                //ClsPDF_Tools.ShowPDF(bytArrFiles, _objCont.objCJobInfo.get_intJobID().ToString() + "_" + _objCont.objCGeneral.get_intUnitNo().ToString());
                //ClsPDF_Tools.ShowPDF(bytArrFiles, _objCont.objCJobInfo.get_strCompanyName() + " - " + _objCont.objCJobInfo.get_strJobName() + " - Oxygen8 Submittal");
            }
        }


        public void SaveSubimittalPDF()
        {
            //ClsSubmittalReportPDF_old objRepPDF = new ClsSubmittalReportPDF_old();
            ClsSubmittalReportPDF objRepPDF = new ClsSubmittalReportPDF();
            //List<byte[]> lst_bytArr = new List<byte[]>();
            List<byte[]> lst_bytArrSaveToFile = new List<byte[]>();
            List<PdfPTable> lst_PdfPTable_ScheduleSubmittal = new List<PdfPTable>();
            string strHeaderImage = "";
            string strFooterImage = "Images/img_footer.jpg";
            string strPathAndFile = "";

            //strHeaderImage = objContElem.objCGeneral.get_intUnitModelID() > 0 ? "Images/img_header_" + objContElem.objCGeneral.get_strUnitModelValue().ToLower() + ".jpg" : "Images/img_header.jpg";
            strHeaderImage = "Images/img_logo_oxygen8.png";

            //byte[] bytArrPDF_CoverPage;
            //byte[] bytArrPDF_Submittal;
            //byte[] bytArrPDF_Drawing;

            if (objContElem.objCGeneral.intUnitNo > 0)
            {
                //Cover Page
                //byte[] bytArrPDF_CoverPage = objRepPDF.getBytArr(ClsOutputPDF.get_pdfPtblCoverPageOld(_objCont), ClsID.enmPageOrientation.Portrait);


                bool bolCoreAHRICertified = objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeNovaID ? objContElem.objCHX_CORE.objCORE_DLL_IO_Summer.bolAHRICertified : false;
                bytArrPDF_SubmittalCoverPage = objRepPDF.getBytArrCoverPage(ClsSubmittalOutputPDF.get_pdfPtblCoverPage(objContElem.objCJobInfo.intJobID), ClsID.enmPageOrientation.Portrait, strHeaderImage, strFooterImage, objContElem.objCGeneral.intProductTypeID, objContElem.objCGeneral.strUnitModelValue.ToUpper(), true, bolCoreAHRICertified);
                //lst_bytArr.Add(bytArrPDF_CoverPage);



                //Schedule
                lst_PdfPTable_ScheduleSubmittal = ClsSubmittalOutputPDF.get_lst_lstPdfPtblSchedule(objContElem);

                if (lst_PdfPTable_ScheduleSubmittal.Count > 0)
                {
                    bytArrPDF_Submittal = objRepPDF.getBytArrSubmittal(lst_PdfPTable_ScheduleSubmittal, strHeaderImage, strFooterImage, objContElem.objCGeneral.strUnitModelValue.ToUpper());
                    //lst_bytArr.Add(bytArrPDF_Submittal);
                    lst_bytArrSaveToFile.Add(bytArrPDF_Submittal);
                }




                //if (objContElem.objCUser.intAccessLevel == ClsID.intUAL_Admin || objContElem.objCUser.intAccessLevel == ClsID.intUAL_Internal || objContElem.objCUser.intAccessLevel == ClsID.intUAL_InternalLevel_2)
                //{
                //    //Drawing
                objDwg = new ClsDrawing(objContElem.objCGeneral.intJobID, objContElem.objCGeneral.intUnitNo);
                DataTable dtDwgList = objDwg.dtDrawingList;

                if (dtDwgList != null)
                {
                    bytArrPDF_Drawing = objRepPDF.getBytArrDrawing(ClsSubmittalOutputPDF.get_pdfPtblModelImageInternal(dtDwgList), ClsID.enmPageOrientation.Portrait, "", "");
                    lst_bytArrSaveToFile.Add(bytArrPDF_Drawing);
                }

                objCutSheet = new ClsCutsheetsPDF(objContElem.objCLoggedUser.intUAL, objContElem.objCGeneral.intJobID, objContElem.objCGeneral.intUnitNo);
                DataTable dtCutSheetList = objCutSheet.dtSelectionCutsheetList;

                List<byte[]> lst_bytArrCutsheet = new List<byte[]>();

                for (int i = 0; i < dtCutSheetList.Rows.Count; i++)
                {
                    byte[] bytArrCutsheet = ClsPDF_Tools.get_byt_arrFromPDF(dtCutSheetList.Rows[i]["PathAndFile"].ToString());

                    if (bytArrCutsheet != null)
                    {
                        lst_bytArrCutsheet.Add(bytArrCutsheet);

                        //lst_bytArrSaveToFile.Add(bytArrPDF_Cutsheet);
                    }
                }

                if (lst_bytArrCutsheet.Count > 0)
                {
                    bytArrPDF_Cutsheet = ClsPDF_Tools.concatAndAddContent(lst_bytArrCutsheet);
                    //bytArrPDF_Cutsheet = ClsPDF_Tools.concatAndAddContent_1(lst_bytArrCutsheet);
                }
                //}
                //else
                //{
                //    ////Drawing
                //    //bytArrPDF_Drawing = objRepPDF.getBytArrDrawing(ClsSubmittalOutputPDF.get_pdfPtblModelImage(objContElem.objCGeneral.get_intJobID(), objContElem.objCGeneral.get_intUnitNo()), ClsID.enmPageOrientation.Portrait, "", "");
                //    //lst_bytArr.Add(bytArrPDF_Drawing);
                //    //lst_bytArrSaveToFile.Add(bytArrPDF_Drawing);

                //}



                //Concatenating All byteArray
                //byte[] bytArrFiles = ClsPDF_Tools.concatAndAddContent(lst_bytArr);
                byte[] bytArrFilesSaveToFile = ClsPDF_Tools.concatAndAddContent(lst_bytArrSaveToFile);


                ////Save to Database
                //ClsDB.UpdatePDF(bytArrFilesSaveToFile, ClsDBT.strSavGeneral, _objCont.objCJobInfo.get_intJobID(), _objCont.objCGeneral.get_intUnitNo());


                //Save to Folder
                //strPathAndFile = HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderPDF_Submittal + "/" + objCont.objCJobInfo.get_intJobID().ToString() + "_cover_page.pdf");
                //System.IO.File.WriteAllBytes(strPathAndFile, bytArrPDF_CoverPage);

                strPathAndFile = HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderSubmittal_Schedules + "/" + objContElem.objCJobInfo.intJobID.ToString() + "_" + objContElem.objCGeneral.intUnitNo.ToString() + ".pdf");
                System.IO.File.WriteAllBytes(strPathAndFile, bytArrFilesSaveToFile);


                //ClsPDF_Tools.ShowPDF(bytArrPDF_Submittal, _objCont.objCJobInfo.get_intJobID().ToString() + "_" + _objCont.objCGeneral.get_intUnitNo().ToString());
                //ClsPDF_Tools.ShowPDF(bytArrFiles, _objCont.objCJobInfo.get_intJobID().ToString() + "_" + _objCont.objCGeneral.get_intUnitNo().ToString());
                //ClsPDF_Tools.ShowPDF(bytArrFiles, _objCont.objCJobInfo.get_strCompanyName() + " - " + _objCont.objCJobInfo.get_strJobName() + " - Oxygen8 Submittal");
            }
        }


        public void SaveSubmittalExcel()
        {
            ClsOutputExcel.GeneralExcelSchedule(objContElem);
        }


        public ClsContElements get_objContainers()
        {
            return objContElem;
        }


        public byte[] get_bytArrPDF_SubmittalCoverPage()
        {
            return bytArrPDF_SubmittalCoverPage;
        }


        public byte[] get_bytArrPDF_Submittal()
        {
            return bytArrPDF_Submittal;
        }


        public byte[] get_bytArrPDF_SelectionCoverPage()
        {
            return bytArrPDF_SelectionCoverPage;
        }


        public byte[] get_bytArrPDF_Selection()
        {
            return bytArrPDF_Selection;
        }


        public byte[] get_bytArrPDF_Drawing()
        {
            return bytArrPDF_Drawing;
        }


        public byte[] get_bytArrPDF_Cutsheet()
        {
            return bytArrPDF_Cutsheet;
        }
    }
}