using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Oxygen8SelectorServer.Models
{
    public class ClsAirFlowData
    {
        private int intJobID = 0;
        private int intUnitNo = 0;
        private int intAltitude = 0;
        private double dblDensity_lbPerCu_ft = 0d;
        private double dblPressure_PSI = 0d;
        private double dblPressure_inHg = 0d;

        private int intSummerSupplyAirCFM = 0;
        private int intSummerReturnAirCFM = 0;
        private int intWinterSupplyAirCFM = 0;
        private int intWinterReturnAirCFM = 0;
        private double dblSummerOutdoorAirDB = 0d;
        private double dblSummerOutdoorAirWB = 0d;
        private double dblSummerOutdoorAirRH = 0d;
        private double dblSummerOutdoorAirEnthalpy = 0d;
        private double dblSummerOutdoorAirGrains = 0d;
        private double dblWinterOutdoorAirDB = 0d;
        private double dblWinterOutdoorAirWB = 0d;
        private double dblWinterOutdoorAirRH = 0d;
        private double dblWinterOutdoorAirEnthalpy = 0d;
        private double dblWinterOutdoorAirGrains = 0d;
        private double dblSummerReturnAirDB = 0d;
        private double dblSummerReturnAirWB = 0d;
        private double dblSummerReturnAirRH = 0d;
        private double dblSummerReturnAirEnthalpy = 0d;
        private double dblSummerReturnAirGrains = 0d;
        private double dblWinterReturnAirDB = 0d;
        private double dblWinterReturnAirWB = 0d;
        private double dblWinterReturnAirRH = 0d;
        private double dblWinterReturnAirEnthalpy = 0d;
        private double dblWinterReturnAirGrains = 0d;
        private double dblWinterPreheatSetpointDB = 0d;
        private double dblWinterHeatingSetpointDB = 0d;
        private double dblSummerCoolingSetpointDB = 0d;
        private double dblSummerCoolingSetpointWB = 0d;
        private double dblSummerReheatSetpointDB = 0d;
        private double dblSupplyAirESP = 0d;
        private double dblExhaustAirESP = 0d;
        private int intSupplyAirApplicationID = 0;
        private int intExhaustAirApplicationID = 0;

        private string strSupplyAirApplciation = "";
        private string strExhaustAirApplciation = "";

        private int intSummerOutdoorAirCFM = 0;
        private int intSummerExhaustAirCFM = 0;
        private int intWinterOutdoorAirCFM = 0;
        private int intWinterExhaustAirCFM = 0;
        private double dblSummerCoolingSetpointRH = 0d;


        ////Mixing
        //private int intSummerSupplyMixEntAirCFM = 0;
        //private double dblSummerSupplyMixEntAirDB = 0d;
        //private double dblSummerSupplyMixEntAirWB = 0d;
        //private double dblSummerSupplyMixEntAirRH = 0d;
        //private double dblSummerSupplyMixEntAirEnthalpy = 0d;
        //private double dblSummerSupplyMixEntAirGrains = 0d;

        //private int intWinterSupplyMixEntAirCFM = 0;
        //private double dblWinterSupplyMixEntAirDB = 0d;
        //private double dblWinterSupplyMixEntAirWB = 0d;
        //private double dblWinterSupplyMixEntAirRH = 0d;
        //private double dblWinterSupplyMixEntAirEnthalpy = 0d;
        //private double dblWinterSupplyMixEntAirGrains = 0d;

        //private double dblSummerSupplyMixLvgAirDB = 0d;
        //private double dblSummerSupplyMixLvgAirWB = 0d;
        //private double dblSummerSupplyMixLvgAirRH = 0d;
        //private double dblSummerSupplyMixLvgAirEnthalpy = 0d;
        //private double dblSummerSupplyMixLvgAirGrains = 0d;

        //private double dblWinterSupplyMixLvgAirDB = 0d;
        //private double dblWinterSupplyMixLvgAirWB = 0d;
        //private double dblWinterSupplyMixLvgAirRH = 0d;
        //private double dblWinterSupplyMixLvgAirEnthalpy = 0d;
        //private double dblWinterSupplyMixLvgAirGrains = 0d;


        private int intSummerOutdoorAirCFM_Actual = 0;
        private int intWinterOutdoorAirCFM_Actual = 0;
        private int intSummerExhaustAirCFM_Actual = 0;
        private int intWinterExhaustAirCFM_Actual = 0;
        //private int intSummerMixingAirCFM_Actual = 0;
        //private int intWinterMixingAirCFM_Actual = 0;

        private int intWheelCarryOverAndPurgeSummerCFM = 0;
        private int intWheelCarryOverAndPurgeWinterCFM = 0;

        private double dblSummerExhaustLvgAirDB_FromSecondEnergyRecoveryDevice = 0d;
        private double dblSummerExhaustLvgAirWB_FromSecondEnergyRecoveryDevice = 0d;
        private double dblSummerExhaustLvgAirRH_FromSecondEnergyRecoveryDevice = 0d;
        private double dblSummerExhaustLvgAirEnthalpy_FromSecondEnergyRecoveryDevice = 0d;
        private double dblSummerExhaustLvgAirGrains_FromSecondEnergyRecoveryDevice = 0d;

        public ClsAirFlowData()
        {
        }




        #region Load Air Flow Data
        public ClsAirFlowData(int _intJobID, int _intUnitNo)
        {
            intJobID = _intJobID;
            intUnitNo = _intUnitNo;

            //DataTable dt = ClsDBM.SelectByJobIdUnitNo(ClsDBT.strSavAirFlowData, intJobID, intUnitNo, ClsID.strColumnUnitNo);
            DataTable dt = ClsDB.GetSavedUnit(intJobID, intUnitNo);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                intAltitude = Convert.ToInt32(dr["altitude"]);
                intSummerSupplyAirCFM = Convert.ToInt32(dr["summer_supply_air_cfm"]);
                intSummerReturnAirCFM = Convert.ToInt32(dr["summer_return_air_cfm"]);
                //intSummerMixingAirCFM = Convert.ToInt32(dr["summer_mixing_air_cfm"]);
                //intSummerRecirculationAirCFM = Convert.ToInt32(dr["summer_recirculation_air_cfm"]);
                intWinterSupplyAirCFM = Convert.ToInt32(dr["winter_supply_air_cfm"]);
                intWinterReturnAirCFM = Convert.ToInt32(dr["winter_return_air_cfm"]);
                //intWinterMixingAirCFM = Convert.ToInt32(dr["winter_mixing_air_cfm"]);
                //intWinterRecirculationAirCFM = Convert.ToInt32(dr["winter_recirculation_air_cfm"]);
                dblSummerOutdoorAirDB = Math.Round(Convert.ToDouble(dr["summer_outdoor_air_db"]), 1);
                dblSummerOutdoorAirWB = Math.Round(Convert.ToDouble(dr["summer_outdoor_air_wb"]), 1);
                dblSummerOutdoorAirRH = Math.Round(Convert.ToDouble(dr["summer_outdoor_air_rh"]), 1);
                dblWinterOutdoorAirDB = Math.Round(Convert.ToDouble(dr["winter_outdoor_air_db"]), 1);
                dblWinterOutdoorAirWB = Math.Round(Convert.ToDouble(dr["winter_outdoor_air_wb"]), 3);
                dblWinterOutdoorAirRH = Math.Round(Convert.ToDouble(dr["winter_outdoor_air_rh"]), 1);
                dblSummerReturnAirDB = Math.Round(Convert.ToDouble(dr["summer_return_air_db"]), 1);
                dblSummerReturnAirWB = Math.Round(Convert.ToDouble(dr["summer_return_air_wb"]), 1);
                dblSummerReturnAirRH = Math.Round(Convert.ToDouble(dr["summer_return_air_rh"]), 1);
                dblWinterReturnAirDB = Math.Round(Convert.ToDouble(dr["winter_return_air_db"]), 1);
                dblWinterReturnAirWB = Math.Round(Convert.ToDouble(dr["winter_return_air_wb"]), 1);
                dblWinterReturnAirRH = Math.Round(Convert.ToDouble(dr["winter_return_air_rh"]), 1);

                dblWinterPreheatSetpointDB = Convert.ToDouble(dr["winter_preheat_setpoint_db"]);
                dblWinterHeatingSetpointDB = Convert.ToDouble(dr["winter_heating_setpoint_db"]);
                dblSummerCoolingSetpointDB = Convert.ToDouble(dr["summer_cooling_setpoint_db"]);
                dblSummerCoolingSetpointWB = Convert.ToDouble(dr["summer_cooling_setpoint_wb"]);
                dblSummerReheatSetpointDB = Convert.ToDouble(dr["summer_reheat_setpoint_db"]);

                dblSupplyAirESP = Convert.ToDouble(dr["supply_air_esp"]);
                dblExhaustAirESP = Convert.ToDouble(dr["exhaust_air_esp"]);

                //CalculateAltitudeData();
                //CalculateAirProperty();
            }
        }
        #endregion


        #region Calculate Altitude Data
        private void CalculateAltitudeData()
        {
            DataTable dtAltitude = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSelAltitude + " WHERE altitude = " + intAltitude.ToString());

            if ((dtAltitude != null) && (dtAltitude.Rows.Count > 0))
            {
                dblDensity_lbPerCu_ft = Math.Round(Convert.ToDouble(dtAltitude.Rows[0]["density_lb_per_cu_ft"]), 3);
                dblPressure_PSI = Convert.ToDouble(dtAltitude.Rows[0]["atm_pressure_psi"]);
            }
            else
            {
                DataTable dtAltitudeAbove = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSelAltitude + " WHERE altitude > '" + intAltitude.ToString() + "' ORDER BY altitude ASC");
                DataTable dtAltitudeBelow = ClsDB.get_dtByQuery("SELECT * FROM " + ClsDBT.strSelAltitude + " WHERE altitude < '" + intAltitude.ToString() + "' ORDER BY altitude DESC");

                if ((dtAltitudeBelow != null) && (dtAltitudeBelow.Rows.Count > 0) && (dtAltitudeAbove != null) && (dtAltitudeAbove.Rows.Count > 0))
                {
                    double dblAltitudeBelow = Convert.ToDouble(dtAltitudeBelow.Rows[0]["altitude"]);
                    double dblAltitudeAbove = Convert.ToDouble(dtAltitudeAbove.Rows[0]["altitude"]);

                    double dblAtmPressureBelow = Convert.ToDouble(dtAltitudeBelow.Rows[0]["atm_pressure_psi"]);
                    double dblAtmPressureAbove = Convert.ToDouble(dtAltitudeAbove.Rows[0]["atm_pressure_psi"]);

                    double dblDensityBelow = Convert.ToDouble(dtAltitudeBelow.Rows[0]["density_lb_per_cu_ft"]);
                    double dblDensityAbove = Convert.ToDouble(dtAltitudeAbove.Rows[0]["density_lb_per_cu_ft"]);

                    dblDensity_lbPerCu_ft = ((dblDensityAbove - dblDensityBelow) / (dblAltitudeAbove - dblAltitudeBelow)) * (dblAltitudeAbove - Convert.ToDouble(intAltitude)) + dblDensityBelow;
                    dblPressure_PSI = ((dblAtmPressureAbove - dblAtmPressureBelow) / (dblAltitudeAbove - dblAltitudeBelow)) * (dblAltitudeAbove - Convert.ToDouble(intAltitude)) + dblAtmPressureBelow;
                }
            }

            dblPressure_inHg = dblPressure_PSI * ClsFormula.dblPressure_PSI_To_InchHg;
        }
        #endregion


        #region Calculate Air Property
        public void CalculateAirProperty()
        {
            intSummerOutdoorAirCFM_Actual = intSummerSupplyAirCFM;
            intWinterOutdoorAirCFM_Actual = intWinterSupplyAirCFM;
            intSummerExhaustAirCFM_Actual = intSummerReturnAirCFM;
            intWinterExhaustAirCFM_Actual = intWinterReturnAirCFM;


            //if (intSummerMixingAirCFM > 0)
            //{
            //    intSummerOutdoorAirCFM_Actual = intSummerSupplyAirCFM - intSummerMixingAirCFM;
            //    intWinterOutdoorAirCFM_Actual = intWinterSupplyAirCFM - intSummerMixingAirCFM;
            //    intSummerExhaustAirCFM_Actual = intSummerReturnAirCFM - intSummerMixingAirCFM;
            //    intWinterExhaustAirCFM_Actual = intWinterReturnAirCFM - intSummerMixingAirCFM;
            //}
            //else if (intSummerMixingAirCFM == 0)
            //{
            //    intSummerOutdoorAirCFM_Actual = intSummerOutdoorAirCFM > 0 ? intSummerOutdoorAirCFM : intSummerSupplyAirCFM;
            //    intWinterOutdoorAirCFM_Actual = intWinterOutdoorAirCFM > 0 ? intWinterOutdoorAirCFM : intWinterSupplyAirCFM;
            //    intSummerExhaustAirCFM_Actual = intSummerExhaustAirCFM > 0 ? intSummerExhaustAirCFM : intSummerReturnAirCFM;
            //    intWinterExhaustAirCFM_Actual = intWinterExhaustAirCFM > 0 ? intWinterExhaustAirCFM : intWinterReturnAirCFM;
            //}


            //if (intSummerOutdoorAirCFM == 0)
            //{
            //    intSummerOutdoorAirCFM_Actual = intSummerSupplyAirCFM - intMixingAirCFM;
            //    intWinterOutdoorAirCFM_Actual = intWinterSupplyAirCFM - intMixingAirCFM;
            //}

            //if (intSummerExhaustAirCFM_Actual == 0)
            //{
            //    intSummerExhaustAirCFM_Actual = intSummerReturnAirCFM - intMixingAirCFM;
            //    intWinterExhaustAirCFM_Actual = intWinterReturnAirCFM - intMixingAirCFM;
            //}

            dblSummerCoolingSetpointRH = Math.Round(ClsPsyCalc.get_fltRH_ByDB_WB((float)dblSummerCoolingSetpointDB, (float)dblSummerCoolingSetpointWB, intAltitude), 1);

            dblSummerReturnAirGrains = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)dblSummerReturnAirDB, (float)dblSummerReturnAirWB, intAltitude), 1);
            dblSummerReturnAirEnthalpy = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)dblSummerReturnAirDB, (float)dblSummerReturnAirGrains), 1);

            dblWinterReturnAirGrains = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)dblWinterReturnAirDB, (float)dblWinterReturnAirWB, intAltitude), 1);
            dblWinterReturnAirEnthalpy = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)dblWinterReturnAirDB, (float)dblWinterReturnAirGrains), 1);
        }
        #endregion


        #region Calculate Mixing
        //public void CalculateMixing(double _dblSummerSupplyEntAirDB, double _dblSummerSupplyEntAirWB, double _dblWinterSupplyEntAirDB, double _dblWinterSupplyEntAirWB, double _dblSummerExhaustLvgAirDB_FromSecondEnergyRecoveryDevice, double _dblSummerExhaustLvgAirWB_FromSecondEnergyRecoveryDevice,  double _dblSummerExhaustLvgAirRH_FromSecondEnergyRecoveryDevice)
        //{
        //    if (intSummerMixingAirCFM > 0)
        //    {
        //        intSummerMixingAirCFM_Actual = intSummerMixingAirCFM;
        //        intWinterMixingAirCFM_Actual = intSummerMixingAirCFM;
        //    }
        //    else
        //    {
        //        intSummerMixingAirCFM_Actual = intSummerSupplyAirCFM - intSummerOutdoorAirCFM_Actual;
        //        intWinterMixingAirCFM_Actual = intWinterSupplyAirCFM - intWinterOutdoorAirCFM_Actual;
        //    }




        //    intSummerSupplyMixEntAirCFM = intSummerOutdoorAirCFM_Actual;
        //    dblSummerSupplyMixEntAirDB = _dblSummerSupplyEntAirDB;
        //    dblSummerSupplyMixEntAirWB = _dblSummerSupplyEntAirWB;
        //    dblSummerSupplyMixEntAirRH = Math.Round((ClsPsyCalc.get_fltRH_ByDB_WB((float)_dblSummerSupplyEntAirDB, (float)dblSummerSupplyMixEntAirWB, Convert.ToInt32(intAltitude))), 1);
        //    dblSummerSupplyMixEntAirGrains = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)_dblSummerSupplyEntAirDB, (float)dblSummerSupplyMixEntAirWB, intAltitude), 1);
        //    dblSummerSupplyMixEntAirEnthalpy = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)_dblSummerSupplyEntAirDB, (float)dblSummerSupplyMixEntAirGrains), 1);

        //    intWinterSupplyMixEntAirCFM = intWinterOutdoorAirCFM_Actual;
        //    dblWinterSupplyMixEntAirDB = _dblWinterSupplyEntAirDB;
        //    dblWinterSupplyMixEntAirWB = _dblWinterSupplyEntAirWB;
        //    dblWinterSupplyMixEntAirRH = Math.Round((ClsPsyCalc.get_fltRH_ByDB_WB((float)dblWinterSupplyMixEntAirDB, (float)dblWinterSupplyMixEntAirWB, Convert.ToInt32(intAltitude))), 1);
        //    dblWinterSupplyMixEntAirGrains = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)dblWinterSupplyMixEntAirDB, (float)dblWinterSupplyMixEntAirWB, intAltitude), 1);
        //    dblWinterSupplyMixEntAirEnthalpy = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)dblWinterSupplyMixEntAirDB, (float)dblWinterSupplyMixEntAirGrains), 1);


        //    if (_dblSummerExhaustLvgAirDB_FromSecondEnergyRecoveryDevice > 0)
        //    {
        //        dblSummerExhaustLvgAirDB_FromSecondEnergyRecoveryDevice = _dblSummerExhaustLvgAirDB_FromSecondEnergyRecoveryDevice;
        //        dblSummerExhaustLvgAirWB_FromSecondEnergyRecoveryDevice = _dblSummerExhaustLvgAirWB_FromSecondEnergyRecoveryDevice;
        //        dblSummerExhaustLvgAirRH_FromSecondEnergyRecoveryDevice = Math.Round((ClsPsyCalc.get_fltRH_ByDB_WB((float)dblSummerExhaustLvgAirDB_FromSecondEnergyRecoveryDevice, (float)dblSummerExhaustLvgAirWB_FromSecondEnergyRecoveryDevice, Convert.ToInt32(intAltitude))), 1);
        //        dblSummerExhaustLvgAirGrains_FromSecondEnergyRecoveryDevice = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)dblSummerExhaustLvgAirDB_FromSecondEnergyRecoveryDevice, (float)dblSummerExhaustLvgAirWB_FromSecondEnergyRecoveryDevice, intAltitude), 1);
        //        dblSummerExhaustLvgAirEnthalpy_FromSecondEnergyRecoveryDevice = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)dblSummerExhaustLvgAirDB_FromSecondEnergyRecoveryDevice, (float)dblSummerExhaustLvgAirGrains_FromSecondEnergyRecoveryDevice), 1);

        //        dblSummerSupplyMixLvgAirDB = Math.Round((((intSummerSupplyMixEntAirCFM * dblSummerSupplyMixEntAirDB) + (intSummerMixingAirCFM_Actual * dblSummerExhaustLvgAirDB_FromSecondEnergyRecoveryDevice)) / intSummerSupplyAirCFM), 1);
        //        dblSummerSupplyMixLvgAirWB = Math.Round((((intSummerSupplyMixEntAirCFM * dblSummerSupplyMixEntAirWB) + (intSummerMixingAirCFM_Actual * dblSummerExhaustLvgAirWB_FromSecondEnergyRecoveryDevice)) / intSummerSupplyAirCFM), 1);
        //        dblSummerSupplyMixLvgAirRH = Math.Round((ClsPsyCalc.get_fltRH_ByDB_WB((float)dblSummerSupplyMixLvgAirDB, (float)dblSummerSupplyMixLvgAirWB, Convert.ToInt32(intAltitude))), 1);
        //        dblSummerSupplyMixLvgAirGrains = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)dblSummerSupplyMixLvgAirDB, (float)dblSummerSupplyMixLvgAirWB, intAltitude), 1);
        //        dblSummerSupplyMixLvgAirEnthalpy = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)dblSummerSupplyMixLvgAirDB, (float)dblSummerSupplyMixLvgAirGrains), 1);
        //    }
        //    else
        //    {
        //        dblSummerSupplyMixLvgAirDB = Math.Round((((intSummerSupplyMixEntAirCFM * dblSummerSupplyMixEntAirDB) + (intSummerMixingAirCFM_Actual * dblSummerReturnAirDB)) / intSummerSupplyAirCFM), 1);
        //        dblSummerSupplyMixLvgAirWB = Math.Round((((intSummerSupplyMixEntAirCFM * dblSummerSupplyMixEntAirWB) + (intSummerMixingAirCFM_Actual * dblSummerReturnAirWB)) / intSummerSupplyAirCFM), 1);
        //        dblSummerSupplyMixLvgAirRH = Math.Round((ClsPsyCalc.get_fltRH_ByDB_WB((float)dblSummerSupplyMixLvgAirDB, (float)dblSummerSupplyMixLvgAirWB, Convert.ToInt32(intAltitude))), 1);
        //        dblSummerSupplyMixLvgAirGrains = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)dblSummerSupplyMixLvgAirDB, (float)dblSummerSupplyMixLvgAirWB, intAltitude), 1);
        //        dblSummerSupplyMixLvgAirEnthalpy = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)dblSummerSupplyMixLvgAirDB, (float)dblSummerSupplyMixLvgAirGrains), 1);
        //    }


        //    dblWinterSupplyMixLvgAirDB = Math.Round((((intWinterSupplyMixEntAirCFM * dblWinterSupplyMixEntAirDB) + (intWinterMixingAirCFM_Actual * dblWinterReturnAirDB)) / intWinterSupplyAirCFM), 1);
        //    dblWinterSupplyMixLvgAirWB = Math.Round((((intWinterSupplyMixEntAirCFM * dblWinterSupplyMixEntAirWB) + (intWinterMixingAirCFM_Actual * dblWinterReturnAirWB)) / intWinterSupplyAirCFM), 1);
        //    dblWinterSupplyMixLvgAirRH = Math.Round((ClsPsyCalc.get_fltRH_ByDB_WB((float)dblWinterSupplyMixLvgAirDB, (float)dblWinterSupplyMixLvgAirWB, Convert.ToInt32(intAltitude))), 1);
        //    dblWinterSupplyMixLvgAirGrains = Math.Round(ClsPsyCalc.get_fltGrainsByDB_WB((float)dblWinterSupplyMixLvgAirDB, (float)dblWinterSupplyMixLvgAirWB, intAltitude), 1);
        //    dblWinterSupplyMixLvgAirEnthalpy = Math.Round(ClsPsyCalc.get_fltEnthalpyByDB_Grains((float)dblWinterSupplyMixLvgAirDB, (float)dblWinterSupplyMixLvgAirGrains), 1);
        //}
        #endregion


        public void setSummerOutdoorAirCFM_Actual(int _intCFM)
        {
            intSummerOutdoorAirCFM_Actual = _intCFM;
        }

        public void setWinterOutdoorAirCFM_Actual(int _intCFM)
        {
            intWinterOutdoorAirCFM_Actual = _intCFM;
        }

        public void setSummerExhaustAirCFM_Actual(int _intCFM)
        {
            intSummerExhaustAirCFM_Actual = _intCFM;
        }

        public void setWinterExhaustAirCFM_Actual(int _intCFM)
        {
            intWinterExhaustAirCFM_Actual = _intCFM;
        }

        //public void setSummerSupplyAirMinCFM(int _intMinCFM)
        //{
        //    intSummerSupplyAirMinPercentCFM = _intMinCFM;
        //}

        //public void setWinterSupplyAirMinCFM(int _intMinCFM)
        //{
        //    intWinterSupplyAirMinPercentCFM = _intMinCFM;
        //}

        //public void setSummerExhaustAirMinCFM(int _intMinCFM)
        //{
        //    intSummerExhaustAirMinPercentCFM = _intMinCFM;
        //}

        //public void setWinterExhaustAirMinCFM(int _intMinCFM)
        //{
        //    intWinterExhaustAirMinPercentCFM = _intMinCFM;
        //}

        //public void setWheelCarryOverAndPurgeSummerCFM(int _intCFM)
        //{
        //    intWheelCarryOverAndPurgeSummerCFM = _intCFM;
        //}

        //public void setWheelCarryOverAndPurgeWinterCFM(int _intCFM)
        //{
        //    intWheelCarryOverAndPurgeWinterCFM = _intCFM;
        //}






        public int get_intSummerSupplyAirCFM()
        {
            return intSummerSupplyAirCFM;
        }

        //public int get_intSummerSupplyAirMinPercentCFM()
        //{
        //    return intSummerSupplyAirMinPercentCFM;
        //}

        public double get_dblSummerCoolingSetpointDB()
        {
            return dblSummerCoolingSetpointDB;
        }

        public double get_dblSummerCoolingSetpointWB()
        {
            return dblSummerCoolingSetpointWB;
        }

        public double get_dblSummerCoolingSetpointRH()
        {
            return dblSummerCoolingSetpointRH;
        }

        public double get_dblSummerReheatSetpointDB()
        {
            return dblSummerReheatSetpointDB;
        }


        public int get_intSummerReturnAirCFM()
        {
            return intSummerReturnAirCFM;
        }

        public int get_intWinterSupplyAirCFM()
        {
            return intWinterSupplyAirCFM;
        }

        //public int get_intWinterSupplyAirMinPercentCFM()
        //{
        //    return intWinterSupplyAirMinPercentCFM;
        //}

        public double get_dblWinterPreheatSetpointDB()
        {
            return dblWinterPreheatSetpointDB;
        }

        public double get_dblWinterHeatingSetpointDB()
        {
            return dblWinterHeatingSetpointDB;
        }




        public int get_intAltitude()
        {
            return intAltitude;
        }

        public double get_dblSummerOutdoorAirDB()
        {
            return dblSummerOutdoorAirDB;
        }

        public double get_dblSummerOutdoorAirWB()
        {
            return dblSummerOutdoorAirWB;
        }

        public double get_dblSummerOutdoorAirRH()
        {
            return dblSummerOutdoorAirRH;
        }

        public double get_dblSummerOutdoorAirEnthalpy()
        {
            return dblSummerOutdoorAirEnthalpy;
        }

        public double get_dblSummerOutdoorAirGrains()
        {
            return dblSummerOutdoorAirGrains;
        }

        public double get_dblWinterOutdoorAirDB()
        {
            return dblWinterOutdoorAirDB;
        }

        public double get_dblWinterOutdoorAirWB()
        {
            return dblWinterOutdoorAirWB;
        }

        public double get_dblWinterOutdoorAirRH()
        {
            return dblWinterOutdoorAirRH;
        }

        public double get_dblWinterOutdoorAirEnthalpy()
        {
            return dblWinterOutdoorAirEnthalpy;
        }

        public double get_dblWinterOutdoorAirGrains()
        {
            return dblWinterOutdoorAirGrains;
        }

        public double get_dblDensity()
        {
            return Math.Round(dblDensity_lbPerCu_ft, 4);
        }

        public double get_dblPressurePSI()
        {
            return Math.Round(dblPressure_PSI, 2);
        }

        public double get_dblPressureInHg()
        {
            return Math.Round(dblPressure_inHg, 2);
        }


        public double get_dblSummerReturnAirDB()
        {
            return dblSummerReturnAirDB;
        }

        public double get_dblSummerReturnAirWB()
        {
            return dblSummerReturnAirWB;
        }

        public double get_dblSummerReturnAirRH()
        {
            return dblSummerReturnAirRH;
        }

        public double get_dblSummerReturnAirEnthalpy()
        {
            return dblSummerReturnAirEnthalpy;
        }

        public double get_dblSummerReturnAirGrains()
        {
            return dblSummerReturnAirGrains;
        }

        public int get_intWinterReturnAirCFM()
        {
            return intWinterReturnAirCFM;
        }


        public double get_dblWinterReturnAirDB()
        {
            return dblWinterReturnAirDB;
        }

        public double get_dblWinterReturnAirWB()
        {
            return dblWinterReturnAirWB;
        }

        public double get_dblWinterReturnAirRH()
        {
            return dblWinterReturnAirRH;
        }

        public double get_dblWinterReturnAirEnthalpy()
        {
            return dblWinterReturnAirEnthalpy;
        }

        public double get_dblWinterReturnAirGrains()
        {
            return dblWinterReturnAirGrains;
        }



        public int get_intSummerExhaustAirCFM()
        {
            return intSummerExhaustAirCFM;
        }

        //public int get_intSummerExhaustAirMinPercentCFM()
        //{
        //    return intSummerExhaustAirMinPercentCFM;
        //}

        public int get_intWinterExhaustAirCFM()
        {
            return intWinterExhaustAirCFM;
        }

        //public int get_intWinterExhaustAirMinPercentCFM()
        //{
        //    return intWinterExhaustAirMinPercentCFM;
        //}

        public int get_intWheelCarryOverAndPurgeSummerCFM()
        {
            return intWheelCarryOverAndPurgeSummerCFM;
        }

        public int get_intWheelCarryOverAndPurgeWinterCFM()
        {
            return intWheelCarryOverAndPurgeWinterCFM;
        }

        //public int get_intSummerMixingAirCFM()
        //{
        //    return intSummerMixingAirCFM;
        //}

        //public int get_intWinterMixingAirCFM()
        //{
        //    return intWinterMixingAirCFM;
        //}

        //public int get_intSummerRecirculationAirCFM()
        //{
        //    return intSummerRecirculationAirCFM;
        //}

        //public int get_intWinterRecirculationAirCFM()
        //{
        //    return intWinterRecirculationAirCFM;
        //}

        public double get_dblSupplyAirESP()
        {
            return dblSupplyAirESP;
        }

        public double get_dblExhaustAirESP()
        {
            return dblExhaustAirESP;
        }

        public int get_intSupplyAirApplicationID()
        {
            return intSupplyAirApplicationID;
        }

        public int get_intExhaustAirApplicationID()
        {
            return intExhaustAirApplicationID;
        }

        public string get_strSupplyAirApplication()
        {
            return strSupplyAirApplciation;
        }

        public string get_strExhaustAirApplication()
        {
            return strExhaustAirApplciation;
        }


        public string get_strHundredPercentOutdoorAir()
        {
            return "";
        }

        public string get_strPartialOutdoorAir()
        {
            return "";
        }

        public string get_strFullRecirculation()
        {
            return "";
        }

        ////Mixing
        //public int get_intSummerSupplyMixEntAirCFM()
        //{
        //    return intSummerSupplyMixEntAirCFM;
        //}

        //public double get_dblSummerSupplyMixEntAirDB()
        //{
        //    return dblSummerSupplyMixEntAirDB;
        //}

        //public double get_dblSummerSupplyMixEntAirWB()
        //{
        //    return dblSummerSupplyMixEntAirWB;
        //}

        //public double get_dblSummerSupplyMixEntAirRH()
        //{
        //    return dblSummerSupplyMixEntAirRH;
        //}

        //public double get_dblSummerSupplyMixEntAirEnthalpy()
        //{
        //    return dblSummerSupplyMixEntAirEnthalpy;
        //}

        //public double get_dblSummerSupplyMixEntAirGrains()
        //{
        //    return dblSummerSupplyMixEntAirGrains;
        //}

        //public int get_intWinterSupplyMixEntAirCFM()
        //{
        //    return intWinterSupplyMixEntAirCFM;
        //}

        //public double get_dblWinterSupplyMixEntAirDB()
        //{
        //    return dblWinterSupplyMixEntAirDB;
        //}

        //public double get_dblWinterSupplyMixEntAirWB()
        //{
        //    return dblWinterSupplyMixEntAirWB;
        //}

        //public double get_dblWinterSupplyMixEntAirRH()
        //{
        //    return dblWinterSupplyMixEntAirRH;
        //}

        //public double get_dblWinterSupplyMixEntAirEnthalpy()
        //{
        //    return dblWinterSupplyMixEntAirEnthalpy;
        //}

        //public double get_dblWinterSupplyMixEntAirGrains()
        //{
        //    return dblWinterSupplyMixEntAirGrains;
        //}


        //public double get_dblSummerSupplyMixLvgAirDB()
        //{
        //    return dblSummerSupplyMixLvgAirDB;
        //}

        //public double get_dblSummerSupplyMixLvgAirWB()
        //{
        //    return dblSummerSupplyMixLvgAirWB;
        //}

        //public double get_dblSummerSupplyMixLvgAirRH()
        //{
        //    return dblSummerSupplyMixLvgAirRH;
        //}

        //public double get_dblSummerSupplyMixLvgAirEnthalpy()
        //{
        //    return dblSummerSupplyMixLvgAirEnthalpy;
        //}

        //public double get_dblSummerSupplyMixLvgAirGrains()
        //{
        //    return dblSummerSupplyMixLvgAirGrains;
        //}


        //public double get_dblWinterSupplyMixLvgAirDB()
        //{
        //    return dblWinterSupplyMixLvgAirDB;
        //}

        //public double get_dblWinterSupplyMixLvgAirWB()
        //{
        //    return dblWinterSupplyMixLvgAirWB;
        //}

        //public double get_dblWinterSupplyMixLvgAirRH()
        //{
        //    return dblWinterSupplyMixLvgAirRH;
        //}

        //public double get_dblWinterSupplyMixLvgAirEnthalpy()
        //{
        //    return dblWinterSupplyMixLvgAirEnthalpy;
        //}

        //public double get_dblWinterSupplyMixLvgAirGrains()
        //{
        //    return dblWinterSupplyMixLvgAirGrains;
        //}



        public int get_intSummerOutdoorAirCFM_Actual()
        {
            return intSummerOutdoorAirCFM_Actual;
        }

        public int get_intWinterOutdoorAirCFM_Actual()
        {
            return intWinterOutdoorAirCFM_Actual;
        }

        public int get_intSummerExhaustAirCFM_Actual()
        {
            return intSummerExhaustAirCFM_Actual;
        }

        public int get_intWinterExhaustAirCFM_Actual()
        {
            return intWinterExhaustAirCFM_Actual;
        }

        //public int get_intSummerMixingAirCFM_Actual()
        //{
        //    return intSummerMixingAirCFM_Actual;
        //}

        //public int get_intWinterMixingAirCFM_Actual()
        //{
        //    return intWinterMixingAirCFM_Actual;
        //}


        //public double get_dblSummerExhaustLvgAirDB_FromSecondEnergyRecoveryDevice()
        //{
        //    return dblSummerExhaustLvgAirDB_FromSecondEnergyRecoveryDevice;
        //}

        //public double get_dblSummerExhaustLvgAirWB_FromSecondEnergyRecoveryDevice()
        //{
        //    return dblSummerExhaustLvgAirWB_FromSecondEnergyRecoveryDevice;
        //}

        //public double get_dblSummerExhaustLvgAirRH_FromSecondEnergyRecoveryDevice()
        //{
        //    return dblSummerExhaustLvgAirRH_FromSecondEnergyRecoveryDevice;
        //}

        //public double get_dblSummerExhaustLvgAirEnthalpy_FromSecondEnergyRecoveryDevice()
        //{
        //    return dblSummerExhaustLvgAirEnthalpy_FromSecondEnergyRecoveryDevice;
        //}

        //public double get_dblSummerExhaustLvgAirGrains_FromSecondEnergyRecoveryDevice()
        //{
        //    return dblSummerExhaustLvgAirGrains_FromSecondEnergyRecoveryDevice;
        //}
    }
}