using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsElectricHeater : ClsComponent
    {
        private int intJobID = 0;
        private int intUnitNo = 0;
        private int intComponentNo = 0;
        private int intComponentID = 0;
        private int intTypeID = 0;

        public ClsElectricHeater()
        {
        }

        public ClsElectricHeater(int _intJobID, int _intUnitNo)
        {
            intJobID = _intJobID;
            intUnitNo = _intUnitNo;

            objElecHeaterIO = new ClsElecHeaterIO
            {
                strFuseSize = ""
                //intModelID = intModelID,
                //dblKW = dblKW,
            };
        }


        public void setElecHeater_IO_Data(ClsGeneral _objGeneral, ClsComponentItems _objCompOpt, bool _bolCheckSelectionType)
        {
            objElecHeaterIO.intProductTypeID = _objGeneral.intProductTypeID;

            DataTable dtVoltage = ClsDB.get_dtByID(ClsDBT.strSelElectricalVoltage, _objCompOpt.objCompOpt.intElecHeaterVoltageID);
            objElecHeaterIO.intVolt = Convert.ToInt32(dtVoltage.Rows[0]["volt"]);
            objElecHeaterIO.intPhase = Convert.ToInt32(dtVoltage.Rows[0]["phase"]);
            objElecHeaterIO.intHertz = Convert.ToInt32(dtVoltage.Rows[0]["hertz"]);
            //intVolt = intVolt == 230 ? 208 : 460;
            objElecHeaterIO.strVoltage = dtVoltage.Rows[0]["items"].ToString();
            objElecHeaterIO.strVoltageRange = dtVoltage.Rows[0]["electric_heater_voltage_range"].ToString();

            DataTable dtElecHeaterModel = new DataTable();


            switch (_objGeneral.intProductTypeID)
            {
                case ClsID.intProdTypeNovaID:
                    dtElecHeaterModel = ClsDB.get_dtLive(ClsDBT.strSelNovaElectricHeaterModel, "unit_model_id", _objGeneral.intUnitModelID);
                    var drHeatingElecHeater = dtElecHeaterModel.AsEnumerable().Where(x => ((Int32)(x["standard_coil_no"]) != 100 && (Int32)(x["standard_coil_no"]) != 500));
                    dtElecHeaterModel = drHeatingElecHeater.Any() ? drHeatingElecHeater.CopyToDataTable() : new DataTable();
                    break;
                default:
                    break;
            }


            //if (_objGeneral.intProductTypeID == ClsID.intProdTypeNovaID)
            //{
            //}
            //else if (_objGeneral.intProductTypeID == ClsID.intProdTypeVentumID)
            //{
            //}


            //dtElecHeaterModel = ClsTS.get_dtDataFromImportRows(dtElecHeaterModel, "unit_orientation_id", _intOrientationID);
            //dtElecHeaterModel = ClsTS.get_dtDataFromImportRows(dtElecHeaterModel, "selection_type_id", _objGeneral.get_intSelectionTypeID());

            //if (_objGeneral.get_intSelectionTypeID() == ClsID.intSelectionTypeDeratedSize)
            //{
            //    dtElecHeaterModel = ClsTS.get_dtDataFromImportRows(dtElecHeaterModel, "unit_orientation_value", _objGeneral.get_strOrientationValue());
            //}


            if (_bolCheckSelectionType)
            {
                dtElecHeaterModel = ClsTS.get_dtDataFromImportRows(dtElecHeaterModel, "selection_type_id", _objGeneral.intSelectionTypeID);

                //if (_objGeneral.intSelectionTypeID == ClsID.intSelectionTypeCoupled)
                //{
                //    dtElecHeaterModel = ClsTS.get_dtDataFromImportRows(dtElecHeaterModel, "unit_orientation_value", _objGeneral.strOrientationValue);
                //}
            }
            else
            {
                dtElecHeaterModel = ClsTS.get_dtDataFromImportRows(dtElecHeaterModel, "selection_type_id", ClsID.intSelectionTypeCoupled);
                //dtElecHeaterModel = ClsTS.get_dtDataFromImportRows(dtElecHeaterModel, "unit_orientation_value", _objGeneral.strOrientationValue);
            }



            dtElecHeaterModel = ClsTS.get_dtDataFromImportRows(dtElecHeaterModel, "volt", objElecHeaterIO.intVolt);
            dtElecHeaterModel = ClsTS.get_dtDataFromImportRows(dtElecHeaterModel, "phase", objElecHeaterIO.intPhase);
            dtElecHeaterModel = ClsTS.get_dtSortedASC(dtElecHeaterModel, "kw");

            if (dtElecHeaterModel.Rows.Count > 0)
            {
                objElecHeaterIO.dtElecHeaterModelKW = dtElecHeaterModel;
            }
        }


        public void CalcPreheatPerf()
        {

            objElecHeaterIO.dblKW = get_dblKW(objElecHeaterIO.intAirFlow, objElecHeaterIO.dblLvgAirDB, objElecHeaterIO.dblEntAirDB);

            //objElecHeaterIO.dblKW = Math.Round(objElecHeaterIO.dblKW + (objElecHeaterIO.dblKW * 0.25d), 2);



            //if (objElecHeaterIO.dtElecHeaterModelKW.Rows.Count > 0)
            //{
            //    if (objElecHeaterIO.dblKW < Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[0]["kw"]))
            //    {
            //        objElecHeaterIO.intModelID = Convert.ToInt32(objElecHeaterIO.dtElecHeaterModelKW.Rows[0]["id"]);
            //        objElecHeaterIO.dblKW = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[0]["kw"]);
            //        objElecHeaterIO.dblFLA = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[0]["fla"]);
            //        objElecHeaterIO.dblDeltaT = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[0]["delta_t"]);
            //    }
            //}

            //objElecHeaterIO.dblLvgAirTempActual = Math.Round((Convert.ToDouble((objElecHeaterIO.dblKW * ClsFormula.dblKW_To_BTUH) / (1.08d * objElecHeaterIO.intAirFlow)) + objElecHeaterIO.dblEntAirTemp), 1);





            //if (objElecHeaterIO.intModelID == 0 && objElecHeaterIO.dblKW == 0)
            //{
            //    objElecHeaterIO.intModelID = Convert.ToInt32(objElecHeaterIO.dtElecHeaterModelKW.Rows[0]["id"]);
            //    objElecHeaterIO.dblKW = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[0]["kw"]);
            //    objElecHeaterIO.dblFLA = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[0]["fla"]);
            //    objElecHeaterIO.dblDeltaT = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[0]["delta_t"]);
            //}


            //dblLvgAirTemp = Math.Ceiling(((Convert.ToDouble((objElecHeaterIO.dblKW - (objElecHeaterIO.dblKW * 0.25d)) * ClsFormula.dblKW_To_BTUH) / (1.08d * objElecHeaterIO.intAirFlow)) + objElecHeaterIO.dblEntAirTemp) * 10d) / 10d;
            //objElecHeaterIO.dblLvgAirTemp = dblLvgAirTemp;
            //ClsDB.SaveElectricHeaterTHERMOLEC(intJobID, intUnitNo, intComponentNo, intTypeID, objElecHeaterIO.intModelID, 0);

            //dblLvgAirTemp = Math.Ceiling(((Convert.ToDouble((objElecHeaterIO.dblKW - (objElecHeaterIO.dblKW * 0.25d)) * ClsFormula.dblKW_To_BTUH) / (1.08d * objElecHeaterIO.intAirFlow)) + objElecHeaterIO.dblEntAirTemp) * 10d) / 10d;
            //objElecHeaterIO.dblLvgAirTemp = dblLvgAirTemp;
            //ClsDB.SaveElectricHeaterTHERMOLEC(intJobID, intUnitNo, intComponentNo, intTypeID, objElecHeaterIO.intModelID, 0);



            ////    //for (int i = 0; i < objElecHeaterIO.dtElecHeaterModelKW.Rows.Count; i++)
            ////    //{
            ////    //    if (Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["kw"]) > objElecHeaterIO.dblKW)
            ////    //    {
            ////    //        objElecHeaterIO.bolKW_Max = false;
            ////    //        objElecHeaterIO.intKW_Selected = Convert.ToInt32(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["kw"]);
            ////    //        dblKW = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["kw"]);
            ////    //        dblFLA = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["fla"]);


            ////    //        //DataTable dtVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, 0);
            ////    //        //int intVolt = Convert.ToInt32(dtVoltage.Rows[0]["volt"]);
            ////    //        //int intPhase = Convert.ToInt32(dtVoltage.Rows[0]["phase"]);
            ////    //        //int intHertz = Convert.ToInt32(dtVoltage.Rows[0]["hertz"]);

            ////    //        //dblFLA = Math.Round((Convert.ToDouble(intKW_Actual) * 1000d / 1.73d / Convert.ToDouble(intVolt)), 1);    //1.73 Power Factor

            ////    //        objElecHeaterIO.intModelID = Convert.ToInt32(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["id"]);
            ////    //        objElecHeaterIO.dblKW = dblKW;
            ////    //        objElecHeaterIO.dblLvgAirTemp = dblLvgAirTemp;
            ////    //        objElecHeaterIO.dblFLA = dblFLA;
            ////    //        ClsDB.SaveElectricHeaterTHERMOLEC(intJobID, intUnitNo, intComponentNo, intTypeID, objElecHeaterIO.intModelID, 0);
            ////    //        break;
            ////    //    }


            ////    //    objElecHeaterIO.bolKW_Max = true;
            ////    //}
        }


        public void CalcHeatingPerf()
        {
            objElecHeaterIO.dblKW = get_dblKW(objElecHeaterIO.intAirFlow, objElecHeaterIO.dblLvgAirDB, objElecHeaterIO.dblEntAirDB);
        }



        public void ReCalcPerf()
        {
            ////int intVolt = objElecHeaterIO.intVolt == 230 ? 208 : objElecHeaterIO.intVolt;

            ////DataTable dtModel = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSelElectricHeaterModel + " WHERE `unit_model_id`= " + objElecHeaterIO.intUnitModelID +
            ////                                                                                                      " AND `unit_orientation_id`= " + objElecHeaterIO.intUnitOrientationID +
            ////                                                                                                      " AND `volt`= " + intVolt + 
            ////                                                                                                      " AND `delta_t`= " + objElecHeaterIO.dblDeltaT);

            objElecHeaterIO.dblKW = get_dblKW(objElecHeaterIO.intAirFlow, objElecHeaterIO.dblLvgAirDB, objElecHeaterIO.dblEntAirDB);

            //dblLvgAirTemp = Math.Ceiling(((Convert.ToDouble((objElecHeaterIO.dblKW - (objElecHeaterIO.dblKW * 0.25d)) * ClsFormula.dblKW_To_BTUH) / (1.08d * objElecHeaterIO.intAirFlow)) + objElecHeaterIO.dblEntAirTemp) * 10d) / 10d;
        }


        public void CalcLvgAirTempDB()
        {
            objElecHeaterIO.dblLvgAirDB = Math.Ceiling(((Convert.ToDouble(objElecHeaterIO.dblKW * ClsFormula.dblPower_KW_To_BTUH) / (1.08d * objElecHeaterIO.intAirFlow)) + objElecHeaterIO.dblEntAirDB) * 10d) / 10d;
        }


        private double get_dblKW(int _intAirFlow, double _dblLvgAirTemp, double _dblEntAirTemp)
        {
            return Math.Round((1.08d * _intAirFlow * (_dblLvgAirTemp - _dblEntAirTemp)) / 3412.142d, 2);
        }







        public void setKw()
        {
            for (int i = 0; i < objElecHeaterIO.dtElecHeaterModelKW.Rows.Count; i++)
            {
                objElecHeaterIO.intModelID = Convert.ToInt32(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["id"]);
                objElecHeaterIO.dblKW_Max = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["kw"]);
                //dblFLA = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["fla"]);
                objElecHeaterIO.intStandardCoilNo = Convert.ToInt32(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["standard_coil_no"]);
                objElecHeaterIO.dblFLA = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["fla"]);
                objElecHeaterIO.dblMCA = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["mca"]);
                objElecHeaterIO.dblMROPD = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["mropd"]);
                objElecHeaterIO.strFuseSize = objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["fuse_size"].ToString();

                objElecHeaterIO.dblHeight = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["height_in"]);
                objElecHeaterIO.dblWidth = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["width_in"]);
                objElecHeaterIO.dblOpeningHeight = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["opening_height_in"]);
                objElecHeaterIO.dblOpeningWidth = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["opening_width_in"]);


                if (objElecHeaterIO.intProductTypeID == ClsID.intProdTypeVentumLiteID)
                {
                    objElecHeaterIO.dblDimD = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["dim_d_in"]);
                    objElecHeaterIO.dblDimA = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["dim_a_in"]);
                    objElecHeaterIO.dblDimB = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["dim_b_in"]);
                    objElecHeaterIO.dblDimC = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["dim_c_in"]);
                }

                if (i == objElecHeaterIO.dtElecHeaterModelKW.Rows.Count - 1)
                {
                    objElecHeaterIO.bolIsMaxStandardCoilNo = true;  //Used for VentumLite warning
                }


                if (Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["kw"]) > objElecHeaterIO.dblKW)
                {
                    objElecHeaterIO.bolKW_Max = false;


                    //objElecHeaterIO.dblDeltaT = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["delta_t"]);

                    ////objElecHeaterIO.intKW_Selected = Convert.ToInt32(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["kw"]);
                    ////dblKW = Convert.ToDouble(objElecHeaterIO.dtElecHeaterModelKW.Rows[i]["kw"]);

                    //dblLvgAirTemp = Math.Ceiling(((Convert.ToDouble((objElecHeaterIO.dblKW - (objElecHeaterIO.dblKW * 0.25d)) * ClsFormula.dblKW_To_BTUH) / (1.08d * objElecHeaterIO.intAirFlow)) + objElecHeaterIO.dblEntAirTemp) * 10d) / 10d;
                    //objElecHeaterIO.dblLvgAirTemp = dblLvgAirTemp;

                    ////DataTable dtVoltage = ClsDB.get_dtLive(ClsDBT.strSelElectricalVoltage, 0);
                    ////int intVolt = Convert.ToInt32(dtVoltage.Rows[0]["volt"]);
                    ////int intPhase = Convert.ToInt32(dtVoltage.Rows[0]["phase"]);
                    ////int intHertz = Convert.ToInt32(dtVoltage.Rows[0]["hertz"]);

                    ////dblFLA = Math.Round((Convert.ToDouble(intKW_Actual) * 1000d / 1.73d / Convert.ToDouble(intVolt)), 1);    //1.73 Power Factor

                    ////objElecHeaterIO.dblFLA = dblFLA;
                    ////ClsDB.SaveElectricHeaterTHERMOLEC(intJobID, intUnitNo, intComponentNo, intTypeID, objElecHeaterIO.intModelID, 0);


                    break;
                }



                //objElecHeaterIO.bolKW_Max = true;
            }

            //ClsDB.SaveElectricHeaterTHERMOLEC(intJobID, intUnitNo, intComponentNo, intTypeID, objElecHeaterIO.intModelID, 0);
        }



        public override int get_intComponentID()
        {
            return intComponentID;
        }


        public ClsElecHeaterIO objElecHeaterIO { get; set; }
    }


    public class ClsElecHeaterIO
    {
        public int intUoM { get; set; }
        public int intProductTypeID { get; set; }
        public int intUnitModelID { get; set; }
        public int intUnitOrientationID { get; set; }
        public int intVolt { get; set; }
        public int intPhase { get; set; }
        public int intHertz { get; set; }
        public int intAirFlow { get; set; }
        public double dblEntAirDB { get; set; }
        public double dblEntAirWB { get; set; }
        public double dblEntAirRH { get; set; }
        public double dblEntAirGrains { get; set; }
        public int intTypeID { get; set; }
        public int intModelID { get; set; }
        public DataTable dtElecHeaterModelKW { get; set; }
        public int intKW_Selected { get; set; }
        public bool bolKW_Max { get; set; }
        public double dblDeltaT { get; set; }
        public int intVoltageID { get; set; }
        public string strVoltage { get; set; }
        public string strVoltageRange { get; set; }
        public double dblKW { get; set; }
        public double dblLvgAirDB { get; set; }
        public double dblLvgAirDB_Actual { get; set; }
        public double dblLvgAirWB { get; set; }
        public double dblLvgAirRH { get; set; }
        public double dblLvgAirGrains { get; set; }
        public double dblPressureDrop { get; set; }
        public double dblWeight { get; set; }
        public double dblCost { get; set; }
        public double dblKW_Max { get; set; }
        public int intStandardCoilNo { get; set; }
        public bool bolIsMaxStandardCoilNo { get; set; }
        public double dblFLA { get; set; }
        public double dblMCA { get; set; }
        public double dblMROPD { get; set; }
        public string strFuseSize { get; set; }
        public double dblHeight { get; set; }
        public double dblWidth { get; set; }
        public double dblOpeningHeight { get; set; }
        public double dblOpeningWidth { get; set; }
        public double dblDimD { get; set; }
        public double dblDimA { get; set; }
        public double dblDimB { get; set; }
        public double dblDimC { get; set; }
        public double dblWeightActual { get; set; }
        public int intQty { get; set; }
    }
}