using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxygen8SelectorServer.Models
{
    public class ClsOutput
    {
        public ClsOutputData objOutputTables { get; set; }
        private ClsContElements objContElem;

        public ClsOutput()
        {
        }


        public ClsOutput(ClsContElements _objCont)
        {
            objContElem = _objCont;
            objOutputTables = new ClsOutputData { };


            if (_objCont != null)
            {
                if (_objCont.objCGeneral != null)
                {
                    setOutputUnitDetails(_objCont); //Electrical data is included in Unit Details
                    //setOutUnitElectricalData(_objCont);
                    setOutElecReq(_objCont);
                }


                if (_objCont.objCPreheatElecHeater != null)
                {
                    setOutputPreheatElecHeater();
                }



                if (_objCont.objCHX_CORE != null)
                {
                    setOutputFixedPlateCORE(_objCont.objCHX_CORE, _objCont.objCGeneral);
                }


                if (_objCont.objCHeatingElecHeater != null)
                {
                    setOutputHeatingElecHeater(_objCont.objCHeatingElecHeater, _objCont.objCCompItems);
                }
            }
        }


        //Submittal Outputs--------------------------------------------------------------------------------

        #region Out Unit Electrical Data
        private void setOutUnitElectricalData(ClsContElements _objCont)
        {
            DataRow drUnitElecData = _objCont.objCGeneral.dtUnitElectricalData.Rows[0];

            //DataTable dtUnitElectricalData = new DataTable();
            //dtUnitElectricalData.Columns.Add("cLabel_1", typeof(string));
            //dtUnitElectricalData.Columns.Add("cLabel_2", typeof(string));
            //dtUnitElectricalData.Columns.Add("cLabel_3", typeof(string));
            //dtUnitElectricalData.Columns.Add("cLabel_4", typeof(string));
            //dtUnitElectricalData.Columns.Add("cLabel_5", typeof(string));
            //dtUnitElectricalData.Columns.Add("cLabel_6", typeof(string));
            //dtUnitElectricalData.Columns.Add("cLabel_7", typeof(string));
            //dtUnitElectricalData.Columns.Add("cLabel_8", typeof(string));
            ////dtUnitElectricalData.Columns.Add("cLabel_9", typeof(string));
            //dtUnitElectricalData.Columns.Add("cValue_1", typeof(string));
            //dtUnitElectricalData.Columns.Add("cValue_2", typeof(string));
            //dtUnitElectricalData.Columns.Add("cValue_3", typeof(string));
            //dtUnitElectricalData.Columns.Add("cValue_4", typeof(string));
            //dtUnitElectricalData.Columns.Add("cValue_5", typeof(string));
            //dtUnitElectricalData.Columns.Add("cValue_6", typeof(string));
            //dtUnitElectricalData.Columns.Add("cValue_7", typeof(string));
            //dtUnitElectricalData.Columns.Add("cValue_8", typeof(string));
            ////dtUnitElectricalData.Columns.Add("cValue_9", typeof(string));

            //DataRow dr;
            //dr = dtUnitElectricalData.NewRow();
            //dr["cLabel_1"] = "Size";
            //dr["cLabel_2"] = "Nominal   Volt";
            //dr["cLabel_3"] = "Motor      (kW)               ";
            //dr["cLabel_4"] = "SA Fan     (FLA)";
            //dr["cLabel_5"] = "EA Fan     (FLA)";
            ////dr["cLabel_6"] = "Transformer    (FLA)             ";
            //dr["cLabel_6"] = "MCA";
            //dr["cLabel_7"] = "MROPD";
            //dr["cLabel_8"] = "Recommended Fuse";
            //dr["cValue_1"] = drUnitElecData["size"].ToString();
            //dr["cValue_2"] = drUnitElecData["volt"].ToString();
            //dr["cValue_3"] = drUnitElecData["motor_kw"].ToString();
            //dr["cValue_4"] = drUnitElecData["sa_fan_fla"].ToString();
            //dr["cValue_5"] = drUnitElecData["ra_fan_fla"].ToString();
            ////dr["cValue_6"] = "";
            //dr["cValue_6"] = drUnitElecData["mca"].ToString();
            //dr["cValue_7"] = drUnitElecData["mropd"].ToString();
            //dr["cValue_8"] = drUnitElecData["recom_fuse"].ToString();
            //dtUnitElectricalData.Rows.Add(dr);

            DataTable dtUnitElectricalData = new DataTable();
            dtUnitElectricalData.Columns.Add("cLabel", typeof(string));
            dtUnitElectricalData.Columns.Add("cValue", typeof(string));

            DataRow dr;
            dr = dtUnitElectricalData.NewRow();
            dr["cLabel"] = "Size:";
            dr["cValue"] = drUnitElecData["unit_model"].ToString();
            dtUnitElectricalData.Rows.Add(dr);

            dr = dtUnitElectricalData.NewRow();
            dr["cLabel"] = "Nominal Volt:";
            dr["cValue"] = drUnitElecData["volt"].ToString();
            dtUnitElectricalData.Rows.Add(dr);

            //dr = dtUnitElectricalData.NewRow();
            //dr["cLabel"] = "Motor (kW):";
            //dr["cValue"] = drUnitElecData["motor_kw_"].ToString();
            //dtUnitElectricalData.Rows.Add(dr);

            //dr = dtUnitElectricalData.NewRow();
            //dr["cLabel"] = "SA Fan (FLA):";
            //dr["cValue"] = drUnitElecData["sa_fan_fla_"].ToString();
            //dtUnitElectricalData.Rows.Add(dr);

            //dr = dtUnitElectricalData.NewRow();
            //dr["cLabel"] = "EA Fan (FLA):";
            //dr["cValue"] = drUnitElecData["ra_fan_fla_"].ToString();
            //dtUnitElectricalData.Rows.Add(dr);

            dr = dtUnitElectricalData.NewRow();
            dr["cLabel"] = "MCA:";
            dr["cValue"] = drUnitElecData["mca"].ToString();
            dtUnitElectricalData.Rows.Add(dr);

            dr = dtUnitElectricalData.NewRow();
            dr["cLabel"] = "MROPD:";
            dr["cValue"] = drUnitElecData["mropd"].ToString();
            dtUnitElectricalData.Rows.Add(dr);

            dr = dtUnitElectricalData.NewRow();
            dr["cLabel"] = "Recommended Fuse:";
            dr["cValue"] = drUnitElecData["recom_fuse"].ToString();
            dtUnitElectricalData.Rows.Add(dr);

            objOutputTables.dtUnitElecData = dtUnitElectricalData;
        }
        #endregion


        #region Out Unit Details
        private void setOutputUnitDetails(ClsContElements _objCont)
        {
            DataRow drUnitElecData = _objCont.objCGeneral.dtUnitElectricalData.Rows[0];

            DataTable dtUnitDetails_1 = new DataTable();
            dtUnitDetails_1.Columns.Add("cLabel", typeof(string));
            dtUnitDetails_1.Columns.Add("cValue", typeof(string));

            DataTable dtUnitDetails_2 = new DataTable();
            dtUnitDetails_2.Columns.Add("cLabel", typeof(string));
            dtUnitDetails_2.Columns.Add("cValue", typeof(string));

            DataRow dr;
            dr = dtUnitDetails_1.NewRow();
            dr["cLabel"] = "Unit Tag:";
            dr["cValue"] = _objCont.objCGeneral.strTag;
            dtUnitDetails_1.Rows.Add(dr);

            dr = dtUnitDetails_1.NewRow();
            dr["cLabel"] = "Model:";
            dr["cValue"] = _objCont.objCGeneral.strUnitModel;
            dtUnitDetails_1.Rows.Add(dr);

            //dr = dtUnitDetails_1.NewRow();
            //dr["cLabel"] = "Dimensions (in):";
            //dr["cValue"] = _objCont.objCGeneral.get_strUnitCabinetDim();
            //dtUnitDetails_1.Rows.Add(dr);

            dr = dtUnitDetails_1.NewRow();
            dr["cLabel"] = "Qty:";
            dr["cValue"] = _objCont.objCGeneral.intQty;
            dtUnitDetails_1.Rows.Add(dr);


            dr = dtUnitDetails_1.NewRow();
            dr["cLabel"] = "Location:";
            dr["cValue"] = _objCont.objCGeneral.strLocation;
            dtUnitDetails_1.Rows.Add(dr);

            dr = dtUnitDetails_1.NewRow();
            dr["cLabel"] = "Altitude (ft):";
            dr["cValue"] = _objCont.objCJobInfo.intAltitude;
            dtUnitDetails_1.Rows.Add(dr);

            if (_objCont.objCCompItems.objCompOpt.intIsDrainPan == 1)
            {
                dr = dtUnitDetails_1.NewRow();
                dr["cLabel"] = "Drain Connection:";
                dr["cValue"] = "Yes";
                dtUnitDetails_1.Rows.Add(dr);
            }


            if (_objCont.objCGeneral.intProductTypeID == ClsID.intProdTypeNovaID || _objCont.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumID)
            {
                dr = dtUnitDetails_1.NewRow();
                dr["cLabel"] = "Bypass:";
                dr["cValue"] = _objCont.objCGeneral.intIsBypass == 1 ? "Yes" : "No";
                dtUnitDetails_1.Rows.Add(dr);
            }


            //---------------------------------------------------------------------------------------------------------------------------------------------
            dr = dtUnitDetails_2.NewRow();
            dr["cLabel"] = "Orientation:";
            dr["cValue"] = _objCont.objCGeneral.dsSavedUnitItems.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["items"].ToString();
            dtUnitDetails_2.Rows.Add(dr);


            if (_objCont.objCGeneral.intUnitTypeID == ClsID.intUnitTypeHRV_ID || _objCont.objCGeneral.intUnitTypeID == ClsID.intUnitTypeERV_ID)
            {
                dr = dtUnitDetails_2.NewRow();
                dr["cLabel"] = "ESP SA / RA (inH2O):";
                dr["cValue"] = _objCont.objCAirFlowData.get_dblSupplyAirESP().ToString() + " / " + _objCont.objCAirFlowData.get_dblExhaustAirESP();
                dtUnitDetails_2.Rows.Add(dr);

                dr = dtUnitDetails_2.NewRow();
                dr["cLabel"] = "Filters OA / RA:";
                dr["cValue"] = _objCont.objCOA_Filter.get_strModel() + " / " + _objCont.objCRA_Filter.get_strModel();
                dtUnitDetails_2.Rows.Add(dr);
            }
            else if (_objCont.objCGeneral.intUnitTypeID == ClsID.intUnitTypeAHU_ID)
            {
                dr = dtUnitDetails_2.NewRow();
                dr["cLabel"] = "ESP SA (inH2O):";
                dr["cValue"] = _objCont.objCAirFlowData.get_dblSupplyAirESP().ToString();
                dtUnitDetails_2.Rows.Add(dr);

                dr = dtUnitDetails_2.NewRow();
                dr["cLabel"] = "Filters OA:";
                dr["cValue"] = _objCont.objCOA_Filter.get_strModel();
                dtUnitDetails_2.Rows.Add(dr);
            }

            dr = dtUnitDetails_2.NewRow();
            dr["cLabel"] = "Controls Preference:";
            dr["cValue"] = _objCont.objCGeneral.strControlsPre;
            dtUnitDetails_2.Rows.Add(dr);


            //dr = dtUnitDetails_2.NewRow();
            //dr["cLabel"] = "Voltage:";
            //dr["cValue"] = _objCont.objCGeneral.get_strVoltage();
            //dtUnitDetails_2.Rows.Add(dr);

            //dr = dtUnitDetails_2.NewRow();
            //dr["cLabel"] = "MCA:";
            //dr["cValue"] = drUnitElecData["mca"].ToString();
            //dtUnitDetails_2.Rows.Add(dr);

            //dr = dtUnitDetails_2.NewRow();
            //dr["cLabel"] = "MROPD:";
            //dr["cValue"] = drUnitElecData["mropd"].ToString();
            //dtUnitDetails_2.Rows.Add(dr);

            //dr = dtUnitDetails_2.NewRow();
            //dr["cLabel"] = "Recommended Fuse:";
            //dr["cValue"] = drUnitElecData["recom_fuse"].ToString();
            //dtUnitDetails_2.Rows.Add(dr);

            dr = dtUnitDetails_2.NewRow();
            dr["cLabel"] = "Dampers & Actuator:";
            dr["cValue"] = _objCont.objCCompItems.objCompOpt.strDamperAndActuator;
            dtUnitDetails_2.Rows.Add(dr);


            objOutputTables.dtUnitDetails_1 = dtUnitDetails_1;
            objOutputTables.dtUnitDetails_2 = dtUnitDetails_2;
        }
        #endregion


        #region Out Unit Electrical Data
        private void setOutElecReq(ClsContElements _objCont)
        {
            int intElecReqQty = 1;
            objOutputTables.strOutElecReqUnitData = "Unit";

            DataRow drUnitElecData = _objCont.objCGeneral.dtUnitElectricalData.Rows[0];
            //DataRow drUnitVoltageData = _objCont.objCGeneral.dtUnitVoltageData.Rows[0];


            DataTable dtElecReqUnitElecData = new DataTable();
            dtElecReqUnitElecData.Columns.Add("cLabel", typeof(string));
            dtElecReqUnitElecData.Columns.Add("cValue", typeof(string));

            DataTable dtElecReqPreheatElecHeater = new DataTable();
            dtElecReqPreheatElecHeater.Columns.Add("cLabel", typeof(string));
            dtElecReqPreheatElecHeater.Columns.Add("cValue", typeof(string));

            DataTable dtElecReqCoolingDXC = new DataTable();
            dtElecReqCoolingDXC.Columns.Add("cLabel", typeof(string));
            dtElecReqCoolingDXC.Columns.Add("cValue", typeof(string));

            DataTable dtElecReqHeatingElecHeater = new DataTable();
            dtElecReqHeatingElecHeater.Columns.Add("cLabel", typeof(string));
            dtElecReqHeatingElecHeater.Columns.Add("cValue", typeof(string));

            DataTable dtElecReqReheatElecHeater = new DataTable();
            dtElecReqReheatElecHeater.Columns.Add("cLabel", typeof(string));
            dtElecReqReheatElecHeater.Columns.Add("cValue", typeof(string));


            DataRow dr;
            dr = dtElecReqUnitElecData.NewRow();
            dr["cLabel"] = "Voltage:";
            dr["cValue"] = _objCont.objCGeneral.strVoltage;
            dtElecReqUnitElecData.Rows.Add(dr);

            dr = dtElecReqUnitElecData.NewRow();
            dr["cLabel"] = "Range:";
            dr["cValue"] = _objCont.objCGeneral.strVoltageRange;
            dtElecReqUnitElecData.Rows.Add(dr);


            if (_objCont.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumLiteID && _objCont.objCPreheatElecHeater != null) //VentumLite is SPP (Single Power Point)
            {
                dr = dtElecReqUnitElecData.NewRow();
                dr["cLabel"] = "FLA:";
                dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.dblFLA.ToString();
                dtElecReqUnitElecData.Rows.Add(dr);

                dr = dtElecReqUnitElecData.NewRow();
                dr["cLabel"] = "MCA:";
                //dr["cValue"] = "TBA";
                dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.dblMCA;
                dtElecReqUnitElecData.Rows.Add(dr);

                dr = dtElecReqUnitElecData.NewRow();
                dr["cLabel"] = "RFS:";
                dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.strFuseSize.ToString() + "A";
                dtElecReqUnitElecData.Rows.Add(dr);

                objOutputTables.strOutElecReqUnitData = "Unit and Electric Heater";
            }
            else if (_objCont.objCGeneral.intProductTypeID == ClsID.intProdTypeTerraID &&
                        _objCont.objCPreheatElecHeater != null &&
                        _objCont.objCGeneral.intIsVoltageSPP == 1)   //VentumLite is SPP (Single Power Point)
            {
                dr = dtElecReqUnitElecData.NewRow();
                dr["cLabel"] = "FLA:";
                dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.dblFLA.ToString();
                dtElecReqUnitElecData.Rows.Add(dr);

                dr = dtElecReqUnitElecData.NewRow();
                dr["cLabel"] = "MCA:";
                //dr["cValue"] = "TBA";
                dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.dblMCA;
                dtElecReqUnitElecData.Rows.Add(dr);

                dr = dtElecReqUnitElecData.NewRow();
                dr["cLabel"] = "RFS:";
                dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.strFuseSize.ToString() + "A";
                dtElecReqUnitElecData.Rows.Add(dr);

                objOutputTables.strOutElecReqUnitData = "Unit and Electric Heater";
            }
            else
            {
                dr = dtElecReqUnitElecData.NewRow();
                dr["cLabel"] = "FLA:";
                dr["cValue"] = Convert.ToDouble(drUnitElecData["fla"]).ToString("0.00");
                //dr["cValue"] = "TBA";
                dtElecReqUnitElecData.Rows.Add(dr);

                dr = dtElecReqUnitElecData.NewRow();
                dr["cLabel"] = "MCA:";
                dr["cValue"] = Convert.ToDouble(drUnitElecData["mca"]).ToString("0.00");
                dtElecReqUnitElecData.Rows.Add(dr);

                dr = dtElecReqUnitElecData.NewRow();
                dr["cLabel"] = "RFS:";
                dr["cValue"] = drUnitElecData["recom_fuse"].ToString();
                dtElecReqUnitElecData.Rows.Add(dr);
            }


            if (_objCont.objCPreheatElecHeater != null)
            {
                if (_objCont.objCPreheatElecHeater.objElecHeaterIO.bolKW_Max == true && _objCont.objCLoggedUser.intUAL == ClsID.intUAL_External)
                {
                    dr = dtElecReqPreheatElecHeater.NewRow();
                    dr["cLabel"] = "Note:";
                    dr["cValue"] = "Electric heater required, contact Oxygen8 for a selection.";
                    dtElecReqPreheatElecHeater.Rows.Add(dr);
                }
                else
                {
                    dr = dtElecReqPreheatElecHeater.NewRow();
                    dr["cLabel"] = "Std. Coil:";
                    dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.intStandardCoilNo;
                    dtElecReqPreheatElecHeater.Rows.Add(dr);

                    dr = dtElecReqPreheatElecHeater.NewRow();
                    dr["cLabel"] = "Controls:";
                    dr["cValue"] = "SCR";
                    dtElecReqPreheatElecHeater.Rows.Add(dr);

                    dr = dtElecReqPreheatElecHeater.NewRow();
                    dr["cLabel"] = "Voltage:";
                    dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.strVoltage;
                    dtElecReqPreheatElecHeater.Rows.Add(dr);

                    dr = dtElecReqPreheatElecHeater.NewRow();
                    dr["cLabel"] = "Range:";
                    dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.strVoltageRange;
                    dtElecReqPreheatElecHeater.Rows.Add(dr);

                    dr = dtElecReqPreheatElecHeater.NewRow();
                    dr["cLabel"] = "FLA:";
                    dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.dblFLA.ToString();
                    dtElecReqPreheatElecHeater.Rows.Add(dr);

                    dr = dtElecReqPreheatElecHeater.NewRow();
                    dr["cLabel"] = "MCA:";
                    //dr["cValue"] = "TBA";
                    dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.dblMCA;
                    dtElecReqPreheatElecHeater.Rows.Add(dr);

                    dr = dtElecReqPreheatElecHeater.NewRow();
                    dr["cLabel"] = "RFS:";
                    dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.strFuseSize.ToString() + "A";
                    dtElecReqPreheatElecHeater.Rows.Add(dr);

                    dr = dtElecReqPreheatElecHeater.NewRow();
                    dr["cLabel"] = "Max KW:";
                    dr["cValue"] = _objCont.objCPreheatElecHeater.objElecHeaterIO.dblKW_Max.ToString();
                    dtElecReqPreheatElecHeater.Rows.Add(dr);
                    intElecReqQty++;


                    if (_objCont.objCPreheatElecHeater.objElecHeaterIO.bolKW_Max == true)
                    {
                        dr = dtElecReqPreheatElecHeater.NewRow();
                        dr["cLabel"] = "Note:";
                        dr["cValue"] = "Electric heater required, contact Oxygen8 for a selection.";
                        dtElecReqPreheatElecHeater.Rows.Add(dr);
                    }
                }
            }




            if (_objCont.objCHeatingElecHeater != null)
            {
                if (_objCont.objCHeatingElecHeater.objElecHeaterIO.dblFLA > 0)
                {
                    dr = dtElecReqHeatingElecHeater.NewRow();
                    dr["cLabel"] = "Std. Coil:";
                    dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.intStandardCoilNo;
                    dtElecReqHeatingElecHeater.Rows.Add(dr);

                    dr = dtElecReqHeatingElecHeater.NewRow();
                    dr["cLabel"] = "Controls:";
                    dr["cValue"] = "SCR";
                    dtElecReqHeatingElecHeater.Rows.Add(dr);

                    dr = dtElecReqHeatingElecHeater.NewRow();
                    dr["cLabel"] = "Voltage:";
                    dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.strVoltage;
                    dtElecReqHeatingElecHeater.Rows.Add(dr);

                    dr = dtElecReqHeatingElecHeater.NewRow();
                    dr["cLabel"] = "Range:";
                    dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.strVoltageRange;
                    dtElecReqHeatingElecHeater.Rows.Add(dr);

                    dr = dtElecReqHeatingElecHeater.NewRow();
                    dr["cLabel"] = "FLA:";
                    dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.dblFLA.ToString();
                    dtElecReqHeatingElecHeater.Rows.Add(dr);

                    dr = dtElecReqHeatingElecHeater.NewRow();
                    dr["cLabel"] = "MCA:";
                    //dr["cValue"] = "TBA";
                    dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.dblMCA;
                    dtElecReqHeatingElecHeater.Rows.Add(dr);

                    dr = dtElecReqHeatingElecHeater.NewRow();
                    dr["cLabel"] = "RFS:";
                    dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.strFuseSize.ToString() + "A";
                    dtElecReqHeatingElecHeater.Rows.Add(dr);

                    dr = dtElecReqHeatingElecHeater.NewRow();
                    dr["cLabel"] = "Max KW:";
                    dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.dblKW_Max.ToString();
                    dtElecReqHeatingElecHeater.Rows.Add(dr);
                    intElecReqQty++;
                }
            }


            //Uncomment if separate coils
            //if (_objCont.objCHeatingElecHeater != null)
            //{
            //    if (_objCont.objCHeatingElecHeater.objElecHeaterIO.dblFLA > 0)
            //    {
            //        dr = dtElecReqHeatingElecHeater.NewRow();
            //        dr["cLabel"] = "Std. Coil:";
            //        dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.intStandardCoilNo;
            //        dtElecReqHeatingElecHeater.Rows.Add(dr);

            //        dr = dtElecReqHeatingElecHeater.NewRow();
            //        dr["cLabel"] = "Controls:";
            //        dr["cValue"] = "SCR";
            //        dtElecReqHeatingElecHeater.Rows.Add(dr);

            //        dr = dtElecReqHeatingElecHeater.NewRow();
            //        dr["cLabel"] = "Voltage:";
            //        dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.strVoltage;
            //        dtElecReqHeatingElecHeater.Rows.Add(dr);

            //        dr = dtElecReqHeatingElecHeater.NewRow();
            //        dr["cLabel"] = "Range:";
            //        dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.strVoltageRange;
            //        dtElecReqHeatingElecHeater.Rows.Add(dr);

            //        dr = dtElecReqHeatingElecHeater.NewRow();
            //        dr["cLabel"] = "FLA:";
            //        dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.dblFLA.ToString();
            //        dtElecReqHeatingElecHeater.Rows.Add(dr);

            //        dr = dtElecReqHeatingElecHeater.NewRow();
            //        dr["cLabel"] = "MCA:";
            //        //dr["cValue"] = "TBA";
            //        dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.dblMCA;
            //        dtElecReqHeatingElecHeater.Rows.Add(dr);

            //        dr = dtElecReqHeatingElecHeater.NewRow();
            //        dr["cLabel"] = "RFS:";
            //        dr["cValue"] = _objCont.objCHeatingElecHeater.objElecHeaterIO.strFuseSize.ToString() + "A";
            //        dtElecReqHeatingElecHeater.Rows.Add(dr);
            //        intElecReqQty++;
            //    }
            //}


            //if (_objCont.objCReheatElecHeater != null)
            //{
            //    if (_objCont.objCReheatElecHeater.objElecHeaterIO.dblFLA > 0d)
            //    {
            //        dr = dtElecReqReheatElecHeater.NewRow();
            //        dr["cLabel"] = "Std. Coil:";
            //        dr["cValue"] = _objCont.objCReheatElecHeater.objElecHeaterIO.intStandardCoilNo;
            //        dtElecReqReheatElecHeater.Rows.Add(dr);

            //        dr = dtElecReqReheatElecHeater.NewRow();
            //        dr["cLabel"] = "Controls:";
            //        dr["cValue"] = "SCR";
            //        dtElecReqReheatElecHeater.Rows.Add(dr);

            //        dr = dtElecReqReheatElecHeater.NewRow();
            //        dr["cLabel"] = "Voltage:";
            //        dr["cValue"] = _objCont.objCReheatElecHeater.objElecHeaterIO.strVoltage;
            //        dtElecReqReheatElecHeater.Rows.Add(dr);

            //        dr = dtElecReqReheatElecHeater.NewRow();
            //        dr["cLabel"] = "Range:";
            //        dr["cValue"] = _objCont.objCReheatElecHeater.objElecHeaterIO.strVoltageRange;
            //        dtElecReqReheatElecHeater.Rows.Add(dr);

            //        dr = dtElecReqReheatElecHeater.NewRow();
            //        dr["cLabel"] = "FLA:";
            //        dr["cValue"] = _objCont.objCReheatElecHeater.objElecHeaterIO.dblFLA.ToString();
            //        dtElecReqReheatElecHeater.Rows.Add(dr);

            //        dr = dtElecReqReheatElecHeater.NewRow();
            //        dr["cLabel"] = "MCA:";
            //        //dr["cValue"] = "TBA";
            //        dr["cValue"] = _objCont.objCReheatElecHeater.objElecHeaterIO.dblMCA;
            //        dtElecReqReheatElecHeater.Rows.Add(dr);

            //        dr = dtElecReqReheatElecHeater.NewRow();
            //        dr["cLabel"] = "RFS:";
            //        dr["cValue"] = _objCont.objCReheatElecHeater.objElecHeaterIO.strFuseSize.ToString() + "A"; ;
            //        dtElecReqReheatElecHeater.Rows.Add(dr);
            //        intElecReqQty++;
            //    }
            //}


            objOutputTables.strElecReqQty = "Total Number of Connections Required: ";

            if ((_objCont.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumLiteID) ||
                (_objCont.objCGeneral.intProductTypeID == ClsID.intProdTypeTerraID && _objCont.objCGeneral.intIsVoltageSPP == 1))
            {
                intElecReqQty = 1;
            }

            objOutputTables.strElecReqQty += intElecReqQty.ToString();

            if (_objCont.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumLiteID && _objCont.objCPreheatElecHeater != null)
            {
                objOutputTables.strElecReqQty += " (Single Point Power)";
            }


            objOutputTables.dtElecReqUnitElecData = dtElecReqUnitElecData;
            objOutputTables.dtElecReqPreheatElecHeater = dtElecReqPreheatElecHeater;
            objOutputTables.dtElecReqHeatingElecHeater = dtElecReqHeatingElecHeater;
        }
        #endregion


        #region Out Preheat Electric Heater
        private void setOutputPreheatElecHeater()
        {
            ClsElectricHeater _obj = objContElem.objCPreheatElecHeater;
            DataTable dtPreheatElecHeaterData = new DataTable();
            dtPreheatElecHeaterData.Columns.Add("cLabel", typeof(string));
            dtPreheatElecHeaterData.Columns.Add("cValue", typeof(string));
            dtPreheatElecHeaterData.Columns.Add("cIsBold", typeof(int)).DefaultValue = 0;
            //dtPreheatElecHeaterData.Columns.Add("cIsHeader", typeof(int)).DefaultValue = 0;
            dtPreheatElecHeaterData.Columns.Add("cIsMerged", typeof(int)).DefaultValue = 0;
            dtPreheatElecHeaterData.Columns.Add("cIsWarning", typeof(int)).DefaultValue = 0;

            DataTable dtPreheatElecHeaterNominalData = new DataTable();
            dtPreheatElecHeaterNominalData.Columns.Add("cLabel", typeof(string));
            dtPreheatElecHeaterNominalData.Columns.Add("cValue", typeof(string));

            DataRow dr;

            if (objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumLiteID &&
                _obj.objElecHeaterIO.dblKW > _obj.objElecHeaterIO.dblKW_Max &&
                _obj.objElecHeaterIO.bolIsMaxStandardCoilNo &&
                objContElem.objCLoggedUser.intUAL == ClsID.intUAL_External)
            {
                dr = dtPreheatElecHeaterData.NewRow();
                dr["cLabel"] = "Note:";
                dr["cValue"] = "Electric heater outside of standard range, please contact applications@oxygen8.ca for a coil selection";
                dr["cIsWarning"] = 1;
                dtPreheatElecHeaterData.Rows.Add(dr);
            }
            else if (_obj.objElecHeaterIO.bolKW_Max == true && objContElem.objCLoggedUser.intUAL == ClsID.intUAL_External)
            {
                dr = dtPreheatElecHeaterData.NewRow();
                dr["cLabel"] = "Note:";
                dr["cValue"] = "Electric heater required, contact Oxygen8 for a selection.";
                dtPreheatElecHeaterData.Rows.Add(dr);
            }
            else
            {
                dr = dtPreheatElecHeaterData.NewRow();
                dr["cLabel"] = "Outdoor Air (CFM):";
                dr["cValue"] = _obj.objElecHeaterIO.intAirFlow.ToString();
                dtPreheatElecHeaterData.Rows.Add(dr);

                dr = dtPreheatElecHeaterData.NewRow();
                dr["cLabel"] = "Voltage:";
                dr["cValue"] = _obj.objElecHeaterIO.strVoltage;
                dtPreheatElecHeaterData.Rows.Add(dr);

                dr = dtPreheatElecHeaterData.NewRow();
                dr["cLabel"] = objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumLiteID ? "Min. Required kW" : "kW:";
                dr["cValue"] = Math.Round(_obj.objElecHeaterIO.dblKW, 1).ToString();
                dtPreheatElecHeaterData.Rows.Add(dr);

                dr = dtPreheatElecHeaterData.NewRow();
                dr["cLabel"] = "Ent. Air DB/WB (F):";
                dr["cValue"] = Math.Round(_obj.objElecHeaterIO.dblEntAirDB, 1).ToString() + " / " + Math.Round(_obj.objElecHeaterIO.dblEntAirWB, 1).ToString();
                dtPreheatElecHeaterData.Rows.Add(dr);

                dr = dtPreheatElecHeaterData.NewRow();
                dr["cLabel"] = "Lvg Air DB/WB (F):";
                dr["cValue"] = Math.Round(_obj.objElecHeaterIO.dblLvgAirDB, 1).ToString() + " / " + Math.Round(_obj.objElecHeaterIO.dblLvgAirWB, 1).ToString();
                dtPreheatElecHeaterData.Rows.Add(dr);

                //dr = dtPreheatElecHeaterData.NewRow();
                //dr["cLabel"] = "Delta T:";
                //dr["cValue"] = _obj.objElecHeaterIO.dblDeltaT.ToString();
                //dtPreheatElecHeaterData.Rows.Add(dr);

                //dr = dtPreheatElecHeaterData.NewRow();
                //dr["cLabel"] = "FLA:";
                //dr["cValue"] = _obj.objElecHeaterIO.dblFLA.ToString();
                //dtPreheatElecHeaterData.Rows.Add(dr);

                //dr = dtPreheatElecHeaterData.NewRow();
                //dr["cLabel"] = "Fuse Size:";
                //dr["cValue"] = _obj.objElecHeaterIO.dblFuseSize.ToString();
                //dtPreheatElecHeaterData.Rows.Add(dr);

                dr = dtPreheatElecHeaterData.NewRow();
                dr["cLabel"] = "Installation:";
                dr["cValue"] = objContElem.objCCompItems.objCompOpt.strPreheatElecHeaterInstallation;
                dtPreheatElecHeaterData.Rows.Add(dr);


                if (objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumLiteID ||
                    (objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeTerraID && objContElem.objCGeneral.intIsVoltageSPP == 1))
                {
                    dr = dtPreheatElecHeaterData.NewRow();
                    dr["cLabel"] = "Standard Coil:";
                    dr["cValue"] = _obj.objElecHeaterIO.intStandardCoilNo;
                    dtPreheatElecHeaterData.Rows.Add(dr);

                    dr = dtPreheatElecHeaterData.NewRow();
                    dr["cLabel"] = "Max. Coil Capacity (kW):";
                    dr["cValue"] = _obj.objElecHeaterIO.dblKW_Max;
                    dtPreheatElecHeaterData.Rows.Add(dr);

                    dr = dtPreheatElecHeaterData.NewRow();
                    dr["cLabel"] = "";
                    dtPreheatElecHeaterData.Rows.Add(dr);


                    dr = dtPreheatElecHeaterData.NewRow();
                    dr["cLabel"] = "Drawing Dimensions:";
                    dr["cIsBold"] = 1;
                    //dr["cIsHeader"] = 1;
                    dr["cIsMerged"] = 1;
                    dtPreheatElecHeaterData.Rows.Add(dr);

                    dr = dtPreheatElecHeaterData.NewRow();
                    dr["cLabel"] = "Dim D (in)";
                    dr["cValue"] = _obj.objElecHeaterIO.dblDimD;
                    dtPreheatElecHeaterData.Rows.Add(dr);

                    dr = dtPreheatElecHeaterData.NewRow();
                    dr["cLabel"] = "Dim A (in)";
                    dr["cValue"] = _obj.objElecHeaterIO.dblDimA;
                    dtPreheatElecHeaterData.Rows.Add(dr);

                    dr = dtPreheatElecHeaterData.NewRow();
                    dr["cLabel"] = "Dim B (in)";
                    dr["cValue"] = _obj.objElecHeaterIO.dblDimB;
                    dtPreheatElecHeaterData.Rows.Add(dr);

                    dr = dtPreheatElecHeaterData.NewRow();
                    dr["cLabel"] = "Dim C (in)";
                    dr["cValue"] = _obj.objElecHeaterIO.dblDimC;
                    dtPreheatElecHeaterData.Rows.Add(dr);
                }



                int intVelocity = 0;

                if (_obj.objElecHeaterIO.dblOpeningHeight > 0d && _obj.objElecHeaterIO.dblOpeningWidth > 0d)
                {
                    intVelocity = Convert.ToInt32(_obj.objElecHeaterIO.intAirFlow / ((_obj.objElecHeaterIO.dblOpeningHeight * _obj.objElecHeaterIO.dblOpeningWidth) / 144d));

                    if (intVelocity < 300)
                    {
                        dr = dtPreheatElecHeaterData.NewRow();
                        dr["cLabel"] = "Note:";
                        dr["cValue"] = "Low face velocity. Contact Oxygen8 Applications Team for final selection.";
                        dtPreheatElecHeaterData.Rows.Add(dr);
                    }
                }
                else
                {
                    dr = dtPreheatElecHeaterData.NewRow();
                    dr["cLabel"] = "Note:";
                    dr["cValue"] = "Selection error. Contact Oxygen8.";
                    dtPreheatElecHeaterData.Rows.Add(dr);
                }


                if (_obj.objElecHeaterIO.bolKW_Max)
                {
                    dr = dtPreheatElecHeaterData.NewRow();
                    dr["cLabel"] = "Note:";
                    dr["cValue"] = "Electric heater required, contact Oxygen8 for a selection.";
                    dtPreheatElecHeaterData.Rows.Add(dr);
                }


                if (objContElem.objCGeneral.intProductTypeID == ClsID.intProdTypeVentumLiteID &&
                    _obj.objElecHeaterIO.dblKW > _obj.objElecHeaterIO.dblKW_Max &&
                    _obj.objElecHeaterIO.bolIsMaxStandardCoilNo)
                {
                    dr = dtPreheatElecHeaterData.NewRow();
                    dr["cLabel"] = "Note:";
                    dr["cValue"] = "Electric heater outside of standard range, please contact applications@oxygen8.ca for a coil selection";
                    dr["cIsWarning"] = 1;
                    dtPreheatElecHeaterData.Rows.Add(dr);
                }


                dr = dtPreheatElecHeaterNominalData.NewRow();
                dr["cLabel"] = "Standard Coil:";
                dr["cValue"] = _obj.objElecHeaterIO.intStandardCoilNo;
                dtPreheatElecHeaterNominalData.Rows.Add(dr);

                dr = dtPreheatElecHeaterNominalData.NewRow();
                dr["cLabel"] = "FLA:";
                dr["cValue"] = _obj.objElecHeaterIO.dblFLA;
                dtPreheatElecHeaterNominalData.Rows.Add(dr);

                dr = dtPreheatElecHeaterNominalData.NewRow();
                dr["cLabel"] = "MCA:";
                //dr["cValue"] = "TBA";
                dr["cValue"] = _obj.objElecHeaterIO.dblMCA;
                dtPreheatElecHeaterNominalData.Rows.Add(dr);

                dr = dtPreheatElecHeaterNominalData.NewRow();
                dr["cLabel"] = "MROPD:";
                dr["cValue"] = _obj.objElecHeaterIO.dblMROPD;
                dtPreheatElecHeaterNominalData.Rows.Add(dr);
            }


            objOutputTables.dtPreheatElecHeaterData = dtPreheatElecHeaterData;
            objOutputTables.dtPreheatElecHeaterNominalData = dtPreheatElecHeaterNominalData;
            //objOutputTables.dtPreheatHWC_Entering = dtPreheatHWC_Entering;
            //objOutputTables.dtPreheatHWC_Leaving = dtPreheatHWC_Leaving;
        }
        #endregion


        #region Out Fixed Plate CORE
        private void setOutputFixedPlateCORE(ClsHeatExchCORE _obj, ClsGeneral _objGeneral)
        {
            DataTable dtHX_CORE_EntAir = new DataTable();
            dtHX_CORE_EntAir.Columns.Add("cLabel", typeof(string));
            dtHX_CORE_EntAir.Columns.Add("cValue_1", typeof(string));
            dtHX_CORE_EntAir.Columns.Add("cValue_2", typeof(string));

            DataTable dtHX_CORE_LvgAir = new DataTable();
            dtHX_CORE_LvgAir.Columns.Add("cLabel", typeof(string));
            dtHX_CORE_LvgAir.Columns.Add("cValue_1", typeof(string));
            dtHX_CORE_LvgAir.Columns.Add("cValue_2", typeof(string));

            DataTable dtHX_CORE_Perf = new DataTable();
            dtHX_CORE_Perf.Columns.Add("cLabel", typeof(string));
            dtHX_CORE_Perf.Columns.Add("cValue_1", typeof(string));
            dtHX_CORE_Perf.Columns.Add("cValue_2", typeof(string));

            DataTable dtHX_CORE_CondWarning = new DataTable();
            dtHX_CORE_CondWarning.Columns.Add("cLabel", typeof(string));
            dtHX_CORE_CondWarning.Columns.Add("cValue", typeof(string));

            DataTable dtHX_CORE_AHRIWarning = new DataTable();
            dtHX_CORE_AHRIWarning.Columns.Add("cLabel", typeof(string));
            dtHX_CORE_AHRIWarning.Columns.Add("cValue", typeof(string));
            dtHX_CORE_AHRIWarning.Columns.Add("ShowLogo", typeof(int));


            DataRow dr;
            dr = dtHX_CORE_EntAir.NewRow();
            dr["cLabel"] = "";
            dr["cValue_1"] = "Outdoor Air";
            dr["cValue_2"] = "Return Air";
            dtHX_CORE_EntAir.Rows.Add(dr);

            dr = dtHX_CORE_EntAir.NewRow();
            dr["cLabel"] = "SCFM:";
            dr["cValue_1"] = _obj.objCORE_DLL_IO_Summer.dblInOutsideAirCFM;
            dr["cValue_2"] = _obj.objCORE_DLL_IO_Summer.dblInReturnAirCFM;
            dtHX_CORE_EntAir.Rows.Add(dr);

            //dr["cValue_2"] = _obj.objCORE_DLL_IO_Winter.dblInOutsideAirCFM;
            //dr["cValue_2"] = _obj.objCORE_DLL_IO_Winter.dblInReturnAirCFM;


            dr = dtHX_CORE_EntAir.NewRow();
            dr["cLabel"] = "Summer DB (F) / WB (F) / RH (%):";
            dr["cValue_1"] = Math.Round(_obj.objCORE_DLL_IO_Summer.dblInOutsideAirDB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Summer.dblInOutsideAirWB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Summer.dblInOutsideAirRH, 1);
            dr["cValue_2"] = Math.Round(_obj.objCORE_DLL_IO_Summer.dblInReturnAirDB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Summer.dblInReturnAirWB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Summer.dblInReturnAirRH, 1);
            dtHX_CORE_EntAir.Rows.Add(dr);



            dr = dtHX_CORE_EntAir.NewRow();
            dr["cLabel"] = "Winter    DB (F) / WB (F) / RH (%):";
            dr["cValue_1"] = Math.Round(_obj.objCORE_DLL_IO_Winter.dblInOutsideAirDB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Winter.dblInOutsideAirWB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Winter.dblInOutsideAirRH, 1);
            dr["cValue_2"] = Math.Round(_obj.objCORE_DLL_IO_Winter.dblInReturnAirDB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Winter.dblInReturnAirWB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Winter.dblInReturnAirRH, 1);
            dtHX_CORE_EntAir.Rows.Add(dr);



            dr = dtHX_CORE_LvgAir.NewRow();
            dr["cLabel"] = "";
            dr["cValue_1"] = "Supply Air";
            dr["cValue_2"] = "Exhaust Air";
            //dr["cValue_2Frost"] = "";
            dtHX_CORE_LvgAir.Rows.Add(dr);


            dr = dtHX_CORE_LvgAir.NewRow();
            dr["cLabel"] = "SCFM:";
            dr["cValue_1"] = _obj.objCORE_DLL_IO_Summer.dblOutSupplyAirCFM;
            dr["cValue_2"] = _obj.objCORE_DLL_IO_Summer.dblOutExhaustAirCFM;
            dtHX_CORE_LvgAir.Rows.Add(dr);


            dr = dtHX_CORE_LvgAir.NewRow();
            dr["cLabel"] = "Summer DB (F) / WB (F) / RH (%):";
            dr["cValue_1"] = Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutSupplyAirDB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutSupplyAirWB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutSupplyAirRH, 1);
            dr["cValue_2"] = Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutExhaustAirDB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutExhaustAirWB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutExhaustAirRH, 1);
            dtHX_CORE_LvgAir.Rows.Add(dr);


            dr = dtHX_CORE_LvgAir.NewRow();
            dr["cLabel"] = "Winter    DB (F) / WB (F) / RH (%):";
            dr["cValue_1"] = Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutSupplyAirDB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutSupplyAirWB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutSupplyAirRH, 1);
            dr["cValue_2"] = Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutExhaustAirDB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutExhaustAirWB, 1) + " / " +
                             Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutExhaustAirRH, 1);
            dtHX_CORE_LvgAir.Rows.Add(dr);


            if (_obj.objCORE_DLL_IO_Summer.bolOutSupplyAirCondWarning || _obj.objCORE_DLL_IO_Summer.bolOutExhaustAirCondWar)
            {
                dr = dtHX_CORE_LvgAir.NewRow();
                dr["cLabel"] = "Summer Condensation:";
                dr["cValue_1"] = _obj.objCORE_DLL_IO_Summer.bolOutSupplyAirCondWarning == true ? "Yes" : "No";
                dr["cValue_2"] = _obj.objCORE_DLL_IO_Summer.bolOutExhaustAirCondWar == true ? "Yes" : "No";
                dtHX_CORE_LvgAir.Rows.Add(dr);
            }

            if (_obj.objCORE_DLL_IO_Winter.bolOutSupplyAirCondWarning || _obj.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar)
            {
                dr = dtHX_CORE_LvgAir.NewRow();
                dr["cLabel"] = "Winter Condensation:";
                dr["cValue_1"] = _obj.objCORE_DLL_IO_Winter.bolOutSupplyAirCondWarning == true ? "Yes" : "No";
                dr["cValue_2"] = _obj.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar == true ? "Yes" : "No";
                dtHX_CORE_LvgAir.Rows.Add(dr);
            }

            dr = dtHX_CORE_Perf.NewRow();
            dr["cLabel"] = "";
            dr["cValue_1"] = "Summer";
            dr["cValue_2"] = "Winter";
            //dr["cValue_2Frost"] = "Winter Frost";
            dtHX_CORE_Perf.Rows.Add(dr);


            dr = dtHX_CORE_Perf.NewRow();
            dr["cLabel"] = "Supply Air PD (inH2O):";
            dr["cValue_1"] = Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutSupplyAirPD, 2);
            dr["cValue_2"] = Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutSupplyAirPD, 2);
            //dr["cValue_2Frost"] = "";
            dtHX_CORE_Perf.Rows.Add(dr);

            dr = dtHX_CORE_Perf.NewRow();
            dr["cLabel"] = "Exhaust Air PD (inH2O):";
            dr["cValue_1"] = Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutExhaustAirPD, 2);
            dr["cValue_2"] = Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutExhaustAirPD, 2);
            //dr["cValue_2Frost"] = "";
            dtHX_CORE_Perf.Rows.Add(dr);

            dr = dtHX_CORE_Perf.NewRow();
            dr["cLabel"] = "Sensible Effectiveness %:";
            dr["cValue_1"] = Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutSensibleEffectiveness, 1).ToString("0.0");
            dr["cValue_2"] = Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutSensibleEffectiveness, 1).ToString("0.0");
            dtHX_CORE_Perf.Rows.Add(dr);

            dr = dtHX_CORE_Perf.NewRow();
            dr["cLabel"] = "Latent Effectiveness %:";
            dr["cValue_1"] = Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutLatentEffectiveness, 1).ToString("0.0");
            dr["cValue_2"] = Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutLatentEffectiveness, 1).ToString("0.0");
            dtHX_CORE_Perf.Rows.Add(dr);

            dr = dtHX_CORE_Perf.NewRow();
            dr["cLabel"] = "Total Effectiveness %:";
            dr["cValue_1"] = Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutTotalEffectiveness * 100d, 1).ToString("0.0");
            dr["cValue_2"] = Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutTotalEffectiveness * 100d, 1).ToString("0.0");
            dtHX_CORE_Perf.Rows.Add(dr);


            dr = dtHX_CORE_Perf.NewRow();
            dr["cLabel"] = "EATR %:";
            dr["cValue_1"] = "0.5";
            dr["cValue_2"] = "0.5";
            dtHX_CORE_Perf.Rows.Add(dr);


            dr = dtHX_CORE_Perf.NewRow();
            dr["cLabel"] = "OACF:";
            dr["cValue_1"] = "1.00";
            dr["cValue_2"] = "1.00";
            dtHX_CORE_Perf.Rows.Add(dr);


            dr = dtHX_CORE_Perf.NewRow();
            dr["cLabel"] = "Net Supply Airflow (SCFM):";
            dr["cValue_1"] = _obj.objCORE_DLL_IO_Summer.dblOutSupplyAirCFM;
            dr["cValue_2"] = _obj.objCORE_DLL_IO_Winter.dblOutSupplyAirCFM;
            dtHX_CORE_Perf.Rows.Add(dr);


            dr = dtHX_CORE_Perf.NewRow();
            dr["cLabel"] = "Energy Recover Ratio %:";
            dr["cValue_1"] = Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutEnergyRecoveryRatio, 2);
            dr["cValue_2"] = Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutEnergyRecoveryRatio, 2);
            dtHX_CORE_Perf.Rows.Add(dr);


            dr = dtHX_CORE_Perf.NewRow();
            //dr["cLabel"] = "Total Energy Saved (BTUH):";
            //dr["cLabel"] = "BTUH:";
            dr["cLabel"] = "BTU/H Saved";
            dr["cValue_1"] = Math.Round(_obj.objCORE_DLL_IO_Summer.dblOutTotalEnergySaved, 0);
            dr["cValue_2"] = Math.Round(_obj.objCORE_DLL_IO_Winter.dblOutTotalEnergySaved, 0);
            dtHX_CORE_Perf.Rows.Add(dr);


            if (_obj.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar)
            {
                dr = dtHX_CORE_CondWarning.NewRow();
                dr["cLabel"] = "Condensation Warning:";

                if (_objGeneral.intOrientationID == ClsID.intOrientationHorizontalID)
                {
                    dr["cValue"] = "At current design conditions there is a risk of condensation and freezing across the heat exchanger, frost prevention method is required. Please select a pre-heat option or contact the Oxygen8 Applications team.";
                }
                else if (_objGeneral.intOrientationID == ClsID.intOrientationVerticalID)
                {
                    dr["cValue"] = "At current design conditions the heat exchanger is at risk of freezing and performance will be affected. Contact Oxygen8 Applications team for a selection.";
                }

                //dr["cValue_2"] = _obj.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar == true ? "Yes" : "No";
                dtHX_CORE_CondWarning.Rows.Add(dr);
            }


            if (_obj.objCORE_DLL_IO_Summer.dblOutTotalEffectiveness * 100d < 50d && _obj.objCORE_DLL_IO_Winter.dblOutTotalEffectiveness * 100d < 50d)
            {
                dr = dtHX_CORE_CondWarning.NewRow();
                dr["cLabel"] = "Warning:";
                dr["cValue"] = "Total effectiveness less than 50%. To comply with ASHRAE 90.1-2010 the energy recovery system must have a total effectiveness of greater than or equal to 50%.";
                //dr["cValue_2"] = _obj.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar == true ? "Yes" : "No";
                dtHX_CORE_CondWarning.Rows.Add(dr);
            }

            //dr = dtHX_CORE_AHRIWarning.NewRow();
            ////dr["cLabel"] = "Total Energy Saved (BTUH):";
            //dr["cLabel"] = "AHRIWarning:";
            //dr["cValue"] = _obj.objCORE_DLL_IO_Summer.strAHRICertificationMessage;
            //dtHX_CORE_AHRIWarning.Rows.Add(dr);

            if (_obj.bolAHRISummerWinter)
            {
                dr = dtHX_CORE_AHRIWarning.NewRow();
                //dr["cLabel"] = "Total Energy Saved (BTUH):";
                dr["cLabel"] = "AHRIWarning:";
                dr["cValue"] = ClsGV.strAHRISummerAndWinterMsg;
                dr["ShowLogo"] = 1;
                dtHX_CORE_AHRIWarning.Rows.Add(dr);
            }
            else if (_obj.bolAHRISummer)
            {
                dr = dtHX_CORE_AHRIWarning.NewRow();
                //dr["cLabel"] = "Total Energy Saved (BTUH):";
                dr["cLabel"] = "AHRIWarning:";
                dr["cValue"] = ClsGV.strAHRISummerOnlyMsg;
                dr["ShowLogo"] = 1;
                dtHX_CORE_AHRIWarning.Rows.Add(dr);
            }
            else if (_obj.bolAHRIWinter)
            {
                dr = dtHX_CORE_AHRIWarning.NewRow();
                //dr["cLabel"] = "Total Energy Saved (BTUH):";
                dr["cLabel"] = "AHRIWarning:";
                dr["cValue"] = ClsGV.strAHRIWinterOnlyMsg;
                dr["ShowLogo"] = 1;
                dtHX_CORE_AHRIWarning.Rows.Add(dr);
            }
            else
            {
                dr = dtHX_CORE_AHRIWarning.NewRow();
                //dr["cLabel"] = "Total Energy Saved (BTUH):";
                dr["cLabel"] = "AHRIWarning:";
                dr["cValue"] = ClsGV.strAHRINoSummerNoWinterMsg;
                dr["ShowLogo"] = 0;
                dtHX_CORE_AHRIWarning.Rows.Add(dr);
            }


            //objOutputTables.dtHX_FP_CORE_PhysicalData = dtHX_FP_CORE_PhysicalData;
            objOutputTables.dtHX_FP_CORE_EntAir = dtHX_CORE_EntAir;
            objOutputTables.dtHX_FP_CORE_LvgAir = dtHX_CORE_LvgAir;
            objOutputTables.dtHX_FP_CORE_Perf = dtHX_CORE_Perf;
            objOutputTables.dtHX_FP_CORE_CondWarning = dtHX_CORE_CondWarning;
            objOutputTables.dtHX_FP_CORE_AHRIWarning = dtHX_CORE_AHRIWarning;
            //objOutputTables.dtHX_FP_CORE_ReturnEntAir = dtHX_FP_CORE_ReturnEntAir;
            //objOutputTables.dtHX_FP_CORE_ReturnLvgAir = dtHX_FP_CORE_ReturnLvgAir;
        }
        #endregion


        #region Out Heating Electric Heater
        private void setOutputHeatingElecHeater(ClsElectricHeater _obj, ClsComponentItems _objCompOpt)
        {
            DataTable dtHeatingElecHeaterData = new DataTable();
            dtHeatingElecHeaterData.Columns.Add("cLabel", typeof(string));
            dtHeatingElecHeaterData.Columns.Add("cValue", typeof(string));

            DataTable dtHeatingElecHeaterNominalData = new DataTable();
            dtHeatingElecHeaterNominalData.Columns.Add("cLabel", typeof(string));
            dtHeatingElecHeaterNominalData.Columns.Add("cValue", typeof(string));


            DataRow dr;

            dr = dtHeatingElecHeaterData.NewRow();
            dr["cLabel"] = "Outdoor Air (CFM):";
            dr["cValue"] = _obj.objElecHeaterIO.intAirFlow.ToString();
            dtHeatingElecHeaterData.Rows.Add(dr);

            dr = dtHeatingElecHeaterData.NewRow();
            dr["cLabel"] = "Voltage:";
            dr["cValue"] = _obj.objElecHeaterIO.strVoltage;
            dtHeatingElecHeaterData.Rows.Add(dr);

            dr = dtHeatingElecHeaterData.NewRow();
            dr["cLabel"] = "kW:";
            dr["cValue"] = Math.Round(_obj.objElecHeaterIO.dblKW, 1).ToString();
            dtHeatingElecHeaterData.Rows.Add(dr);

            dr = dtHeatingElecHeaterData.NewRow();
            dr["cLabel"] = "Entering Temp (F):";
            dr["cValue"] = Math.Round(_obj.objElecHeaterIO.dblEntAirDB, 1).ToString();
            dtHeatingElecHeaterData.Rows.Add(dr);

            dr = dtHeatingElecHeaterData.NewRow();
            dr["cLabel"] = "Leaving Temp (F):";
            dr["cValue"] = Math.Round(_obj.objElecHeaterIO.dblLvgAirDB, 1).ToString();
            dtHeatingElecHeaterData.Rows.Add(dr);

            //dr = dtHeatingElecHeaterData.NewRow();
            //dr["cLabel"] = "Delta T:";
            //dr["cValue"] = _obj.objElecHeaterIO.dblDeltaT.ToString();
            //dtHeatingElecHeaterData.Rows.Add(dr);

            //dr = dtHeatingElecHeaterData.NewRow();
            //dr["cLabel"] = "FLA:";
            //dr["cValue"] = _obj.objElecHeaterIO.dblFLA.ToString();
            //dtHeatingElecHeaterData.Rows.Add(dr);

            //dr = dtHeatingElecHeaterData.NewRow();
            //dr["cLabel"] = "Fuse Size:";
            //dr["cValue"] = _obj.objElecHeaterIO.dblFuseSize.ToString();
            //dtHeatingElecHeaterData.Rows.Add(dr);


            dr = dtHeatingElecHeaterData.NewRow();
            dr["cLabel"] = "Installation:";
            dr["cValue"] = _objCompOpt.objCompOpt.strHeatElecHeaterInstallation;
            dtHeatingElecHeaterData.Rows.Add(dr);


            int intVelocity = 0;

            if (_obj.objElecHeaterIO.dblOpeningHeight > 0d && _obj.objElecHeaterIO.dblOpeningWidth > 0d)
            {
                intVelocity = Convert.ToInt32(_obj.objElecHeaterIO.intAirFlow / ((_obj.objElecHeaterIO.dblOpeningHeight * _obj.objElecHeaterIO.dblOpeningWidth) / 144d));

                if (intVelocity < 300)
                {
                    dr = dtHeatingElecHeaterData.NewRow();
                    dr["cLabel"] = "Note:";
                    dr["cValue"] = "Low face velocity. Contact Oxygen8 Applications Team for final selection.";
                    dtHeatingElecHeaterData.Rows.Add(dr);
                }
            }
            else
            {
                dr = dtHeatingElecHeaterData.NewRow();
                dr["cLabel"] = "Note:";
                dr["cValue"] = "Selection error. Contact Oxygen8.";
                dtHeatingElecHeaterData.Rows.Add(dr);
            }

            dr = dtHeatingElecHeaterNominalData.NewRow();
            dr["cLabel"] = "Standard Coil:";
            dr["cValue"] = _obj.objElecHeaterIO.intStandardCoilNo;
            dtHeatingElecHeaterNominalData.Rows.Add(dr);

            dr = dtHeatingElecHeaterNominalData.NewRow();
            dr["cLabel"] = "FLA:";
            dr["cValue"] = _obj.objElecHeaterIO.dblFLA;
            dtHeatingElecHeaterNominalData.Rows.Add(dr);

            dr = dtHeatingElecHeaterNominalData.NewRow();
            dr["cLabel"] = "MCA:";
            //dr["cValue"] = "TBA";
            dr["cValue"] = _obj.objElecHeaterIO.dblMCA;
            dtHeatingElecHeaterNominalData.Rows.Add(dr);

            dr = dtHeatingElecHeaterNominalData.NewRow();
            dr["cLabel"] = "MROPD:";
            dr["cValue"] = _obj.objElecHeaterIO.dblMROPD;
            dtHeatingElecHeaterNominalData.Rows.Add(dr);



            objOutputTables.dtHeatingElecHeaterData = dtHeatingElecHeaterData;
            objOutputTables.dtHeatingElecHeaterNominalData = dtHeatingElecHeaterNominalData;
            //objOutputTables.dtPreheatHWC_Entering = dtPreheatHWC_Entering;
            //objOutputTables.dtPreheatHWC_Leaving = dtPreheatHWC_Leaving;
        }
        #endregion

    }


    public class ClsOutputData
    {
        public int intElecReqQty { get; set; }
        public string strElecReqQty { get; set; }
        public string strOutElecReqUnitData { get; set; }
        public DataTable dtUnitDetails_1 { get; set; }
        public DataTable dtUnitDetails_2 { get; set; }
        public DataTable dtUnitElecData { get; set; }
        public DataTable dtSubmittalScheduleData { get; set; }
        public DataTable dtElecReqUnitElecData { get; set; }
        public DataTable dtElecReqPreheatElecHeater { get; set; }
        public DataTable dtElecReqHeatingElecHeater { get; set; }
        public DataTable dtPreheatElecHeaterData { get; set; }
        public DataTable dtPreheatElecHeaterNominalData { get; set; }
        public DataTable dtPreheatElecHeaterEntering { get; set; }
        public DataTable dtPreheatElecHeaterLeaving { get; set; }


        //public DataTable dtHX_FP_CORE_PhysicalData { get; set; }
        public DataTable dtHX_FP_CORE_Perf { get; set; }
        public DataTable dtHX_FP_CORE_EntAir { get; set; }
        public DataTable dtHX_FP_CORE_LvgAir { get; set; }
        public DataTable dtHX_FP_CORE_CondWarning { get; set; }
        public DataTable dtHX_FP_CORE_AHRIWarning { get; set; }

        public DataTable dtHeatingElecHeaterData { get; set; }
        public DataTable dtHeatingElecHeaterNominalData { get; set; }
        public DataTable dtHeatingElecHeaterEntering { get; set; }
        public DataTable dtHeatingElecHeaterLeaving { get; set; }



        public DataTable dtSF_Data { get; set; }
        public DataTable dtSF_Graph { get; set; }
        public DataTable dtSF_SoundData { get; set; }

        public DataTable dtEF_Data { get; set; }
        public DataTable dtEF_Graph { get; set; }
        public DataTable dtEF_SoundData { get; set; }

        public DataTable dtSoundData { get; set; }
    }
}