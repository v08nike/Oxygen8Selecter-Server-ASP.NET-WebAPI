using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxygen8SelectorServer.Models
{
    public class ClsHeatExchCORE : ClsComponent
    {
        private int intJobID = 0;
        private int intUnitNo = 0;
        private int intComponentID = 0;
        private int intModelID = 0;

        public ClsHeatExchCORE()
        {
        }



        #region Load
        public ClsHeatExchCORE(int _intJobID, int _intUnitNo, int _intUnitModelID)
        {
            intJobID = _intJobID;
            intUnitNo = _intUnitNo;
            //intComponentNo = _intComponentNo;

            DataTable dtHX_FPModel = ClsDB.get_dtByID(ClsDBT.strSelNovaFixedPlateCORE_Model, "unit_model_id", _intUnitModelID);


            if (dtHX_FPModel.Rows.Count > 0)
            {
                intModelID = Convert.ToInt32(dtHX_FPModel.Rows[0]["id"]);


                objCORE_DLL_IO_Summer = new ClsCORE_DLL_IO
                {
                    strModel = dtHX_FPModel.Rows[0]["items"].ToString(),
                    strInProductModel = dtHX_FPModel.Rows[0]["product_model_code"].ToString(),
                    dblInFramedWidth = Convert.ToDouble(dtHX_FPModel.Rows[0]["framed_width_mm"]),
                    dblInHeight = Convert.ToDouble(dtHX_FPModel.Rows[0]["height_mm"]),
                    dblInSupplyPitch = Convert.ToDouble(dtHX_FPModel.Rows[0]["supply_pitch_mm"]),
                    dblInExhaustPitch = Convert.ToDouble(dtHX_FPModel.Rows[0]["exhaust_pitch_mm"]),
                    strFrameType = dtHX_FPModel.Rows[0]["frame_type"].ToString()
                };


                objCORE_DLL_IO_Winter = new ClsCORE_DLL_IO
                {
                    strModel = dtHX_FPModel.Rows[0]["items"].ToString(),
                    strInProductModel = dtHX_FPModel.Rows[0]["product_model_code"].ToString(),
                    dblInFramedWidth = Convert.ToDouble(dtHX_FPModel.Rows[0]["framed_width_mm"]),
                    dblInHeight = Convert.ToDouble(dtHX_FPModel.Rows[0]["height_mm"]),
                    dblInSupplyPitch = Convert.ToDouble(dtHX_FPModel.Rows[0]["supply_pitch_mm"]),
                    dblInExhaustPitch = Convert.ToDouble(dtHX_FPModel.Rows[0]["exhaust_pitch_mm"]),
                    strFrameType = dtHX_FPModel.Rows[0]["frame_type"].ToString()
                };
            }
        }
        #endregion



        public void setModelID(int _intModelID)
        {
            intModelID = _intModelID;
            setInputData();
        }


        private void setInputData()
        {
            DataTable dtModel = ClsDB.get_dtByID(ClsDBT.strSelNovaFixedPlateCORE_Model, intModelID);

            if (dtModel.Rows.Count > 0)
            {
                objCORE_DLL_IO_Summer = new ClsCORE_DLL_IO
                {
                    strModel = dtModel.Rows[0]["items"].ToString(),
                    strInProductModel = dtModel.Rows[0]["product_model_code"].ToString(),
                    dblInFramedWidth = Convert.ToDouble(dtModel.Rows[0]["framed_width_mm"]),
                    dblInHeight = Convert.ToDouble(dtModel.Rows[0]["height_mm"]),
                    dblInSupplyPitch = Convert.ToDouble(dtModel.Rows[0]["supply_pitch_mm"]),
                    dblInExhaustPitch = Convert.ToDouble(dtModel.Rows[0]["exhaust_pitch_mm"])
                };


                objCORE_DLL_IO_Winter = new ClsCORE_DLL_IO
                {
                    strModel = dtModel.Rows[0]["items"].ToString(),
                    strInProductModel = dtModel.Rows[0]["product_model_code"].ToString(),
                    dblInFramedWidth = Convert.ToDouble(dtModel.Rows[0]["framed_width_mm"]),
                    dblInHeight = Convert.ToDouble(dtModel.Rows[0]["height_mm"]),
                    dblInSupplyPitch = Convert.ToDouble(dtModel.Rows[0]["spacing_mm"]),
                    dblInExhaustPitch = Convert.ToDouble(dtModel.Rows[0]["exhaust_pitch_mm"])
                };
            }
        }


        public void CalcPerfSummer()
        {
            //ClsHeatExchCORE_DLL.CalcPerf(objCORE_DLL_IO_Summer, objCORE_DLL_IO_Winter);
            ////ERR=(h2-h1)/(h3-h1) *100
            ////h is enthalpy at specific air stream
            ////1: outdoot air
            ////2:supply air
            ////3:return air
            //float fltSummerOA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Summer.dblInOutsideAirDB, (float)objCORE_DLL_IO_Summer.dblInOutsideAirWB, Convert.ToInt32(objCORE_DLL_IO_Summer.dblInAltitude));
            //float fltSummerSA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Summer.dblOutSupplyAirDB, (float)objCORE_DLL_IO_Summer.dblOutSupplyAirWB, Convert.ToInt32(objCORE_DLL_IO_Summer.dblInAltitude));
            //float fltSummerRA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Summer.dblInReturnAirDB, (float)objCORE_DLL_IO_Summer.dblInReturnAirWB, Convert.ToInt32(objCORE_DLL_IO_Summer.dblInAltitude));

            //double dblSummerOA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Summer.dblInOutsideAirDB, fltSummerOA_Grains);
            //double dblSummerSA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Summer.dblOutSupplyAirDB, fltSummerSA_Grains);
            //double dblSummerRA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Summer.dblInReturnAirDB, fltSummerRA_Grains);

            //objCORE_DLL_IO_Summer.dblOutEnergyRecoveryRatio = (dblSummerSA_Enthalpy - dblSummerOA_Enthalpy) / (dblSummerRA_Enthalpy - dblSummerOA_Enthalpy) * 100d;


            //float fltWinterOA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Winter.dblInOutsideAirDB, (float)objCORE_DLL_IO_Winter.dblInOutsideAirWB, Convert.ToInt32(objCORE_DLL_IO_Winter.dblInAltitude));
            //float fltWinterSA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Winter.dblOutSupplyAirDB, (float)objCORE_DLL_IO_Winter.dblOutSupplyAirWB, Convert.ToInt32(objCORE_DLL_IO_Winter.dblInAltitude));
            //float fltWinterRA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Winter.dblInReturnAirDB, (float)objCORE_DLL_IO_Winter.dblInReturnAirWB, Convert.ToInt32(objCORE_DLL_IO_Winter.dblInAltitude));

            //double dblWinterOA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Winter.dblInOutsideAirDB, fltWinterOA_Grains);
            //double dblWinterSA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Winter.dblOutSupplyAirDB, fltWinterSA_Grains);
            //double dblWinterRA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Winter.dblInReturnAirDB, fltWinterRA_Grains);

            //objCORE_DLL_IO_Winter.dblOutEnergyRecoveryRatio = (dblWinterSA_Enthalpy - dblWinterOA_Enthalpy) / (dblWinterRA_Enthalpy - dblWinterOA_Enthalpy) * 100d;
        }


        public void CalcPerfWinter()
        {
            ClsHeatExchCORE_DLL.CalcPerf(objCORE_DLL_IO_Summer, objCORE_DLL_IO_Winter);
            //ERR=(h2-h1)/(h3-h1) *100
            //h is enthalpy at specific air stream
            //1: outdoot air
            //2:supply air
            //3:return air
            float fltSummerOA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Summer.dblInOutsideAirDB, (float)objCORE_DLL_IO_Summer.dblInOutsideAirWB, Convert.ToInt32(objCORE_DLL_IO_Summer.dblInAltitude));
            float fltSummerSA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Summer.dblOutSupplyAirDB, (float)objCORE_DLL_IO_Summer.dblOutSupplyAirWB, Convert.ToInt32(objCORE_DLL_IO_Summer.dblInAltitude));
            float fltSummerRA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Summer.dblInReturnAirDB, (float)objCORE_DLL_IO_Summer.dblInReturnAirWB, Convert.ToInt32(objCORE_DLL_IO_Summer.dblInAltitude));

            double dblSummerOA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Summer.dblInOutsideAirDB, fltSummerOA_Grains);
            double dblSummerSA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Summer.dblOutSupplyAirDB, fltSummerSA_Grains);
            double dblSummerRA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Summer.dblInReturnAirDB, fltSummerRA_Grains);

            objCORE_DLL_IO_Summer.dblOutEnergyRecoveryRatio = (dblSummerSA_Enthalpy - dblSummerOA_Enthalpy) / (dblSummerRA_Enthalpy - dblSummerOA_Enthalpy) * 100d;


            float fltWinterOA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Winter.dblInOutsideAirDB, (float)objCORE_DLL_IO_Winter.dblInOutsideAirWB, Convert.ToInt32(objCORE_DLL_IO_Winter.dblInAltitude));
            float fltWinterSA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Winter.dblOutSupplyAirDB, (float)objCORE_DLL_IO_Winter.dblOutSupplyAirWB, Convert.ToInt32(objCORE_DLL_IO_Winter.dblInAltitude));
            float fltWinterRA_Grains = ClsPsyCalc.get_fltGrainsByDB_WB((float)objCORE_DLL_IO_Winter.dblInReturnAirDB, (float)objCORE_DLL_IO_Winter.dblInReturnAirWB, Convert.ToInt32(objCORE_DLL_IO_Winter.dblInAltitude));

            double dblWinterOA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Winter.dblInOutsideAirDB, fltWinterOA_Grains);
            double dblWinterSA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Winter.dblOutSupplyAirDB, fltWinterSA_Grains);
            double dblWinterRA_Enthalpy = ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)objCORE_DLL_IO_Winter.dblInReturnAirDB, fltWinterRA_Grains);

            objCORE_DLL_IO_Winter.dblOutEnergyRecoveryRatio = (dblWinterSA_Enthalpy - dblWinterOA_Enthalpy) / (dblWinterRA_Enthalpy - dblWinterOA_Enthalpy) * 100d;
        }

        public override int get_intComponentID()
        {
            return intComponentID;
        }


        //public override string get_strDescription()
        //{
        //    return "Heat Exch " + strType;
        //}




        public ClsCORE_DLL_IO objCORE_DLL_IO_Summer { get; set; }
        public ClsCORE_DLL_IO objCORE_DLL_IO_Winter { get; set; }

        //public string strAHRISummerMsg { get; set; }
        //public string strAHRIWinterMsg { get; set; }
        //public string strAHRISummerWinterMsg { get; set; }

        public bool bolAHRISummer { get; set; }
        public bool bolAHRIWinter { get; set; }
        public bool bolAHRISummerWinter { get; set; }
    }
}