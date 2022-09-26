using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsFormula
    {
        public static double dblLength_MM_To_Inch = 0.0393701d;
        public static double dblLength_Inch_To_MM = 25.4d;

        public static double dblLength_Meter_To_Feet = 3.28084;
        public static double dblLength_Feet_To_Meter = 0.3048d;

        public static double dblLength_Meter_To_MM = 1000d;
        public static double dblLength_MM_To_Meter = 0.001d;

        public static double dblAirVolume_CFM_To_CMS = 0.000472d;
        public static double dblAirVolume_CMS_To_CFM = 2118.88d;

        public static double dblAirVolume_CMH_To_CFM = 0.588577778;
        public static double dblAirVolume_CFM_To_CMH = 1.6990108;

        public static double dblArea_SqFt_To_SqIn = 144d;
        public static double dblArea_SqIn_To_SqFt = 0.00694444d;


        public static double dblIWC_To_Pascal = 249.08d;
        public static double dblPascal_To_IWC = 0.00401325981;

        public static double dblGrains_To_Gramms = 0.06479891d;
        public static double dblGramms_To_Grains = 15.4323584d;

        public static double dblPounds_To_KG = 0.45359237d;
        public static double dblKG_To_Pounds = 2.20462d;

        public static double dblVel_MeterPrSec_To_FPM = 196.850393701d;
        public static double dblVel_FPM_To_MeterPerSec = 0.00508d;

        public static double dblPressure_MBAR_To_AtmPressPSI = 0.0145037738d;
        public static double dblPressure_PSI_To_MBAR = 68.9475729d;

        public static double dblPressure_PSI_To_InchHg = 2.03625437d;
        public static double dblPressure_InchHg_ToPSI = 0.491097779d;

        public static double dblPressure_PSI_To_Pa = 6894.76d;
        public static double dblPressure_Pa_To_PSI = 0.000145038d;

        public static double dblPower_MBH_To_TON = 0.0833d;
        public static double dblPower_TON_To_MBH = 12d;

        public static double dblPower_BTUH_To_TON = 0.0000833d;
        public static double dblPower_TON_To_BTUH = 12000d;

        public static double dblPower_Watts_To_BTUH = 3.412141633d;
        public static double dblPower_BTUH_To_Watts = 0.29307107d;

        public static double dblPower_KW_To_BTUH = 3412.142d;
        public static double dblPower_BTUH_To_KW = 0.00029307107d;

        public static double dblKgPerHour_To_PoundPerMin = 0.0367437104d;
        public static double dblPoundPerHour_To_KgPerHour = 27.2155422d;

        public static double dblFlowRate_GPM_To_LtrPerSec = 0.06309d;
        public static double dblFlowRate_LtrPerSec_To_GPM = 15.850372483753d;

        public static double dblFlowRate_GPM_To_LtrPerMin = 3.7854d;
        public static double dblFlowRate_LtrPerMin_To_GPM = 0.26417287472922d;

        public static double dblFeetOfWater_To_PSI = 0.43352750192825d;
        public static double dblPSI_To_FeetOfWater = 2.31d;

        public static double dblFeetHead_To_InchWG = 11.996928d;
        public static double dblInchWC_To_FeetHead = 0.083354672129398d;

        public static double dblFeetHead_To_FeetWG = 0.999744d;

        public static double dblLiterPerHr_To_USGalPerHr = 0.264172d;
        public static double dblUSGalPerHr_To_LiterPerHr = 3.785412d;

        public static double dblDensity_LbsPerCuFt_To_KgPerCuM = 16.0185d;
        public static double dblDensity_KgPerCuM_To_LbsPerCuFt = 0.062428d;




        //Area******************************************************************
        public static double get_decAreaInSqInch(double _dblValue_1, double _dblValue_2)
        {
            return (_dblValue_1 * _dblValue_2);
        }

        public static double get_decAreaInSqFeet(double _dblValue_1, double _dblValue_2)
        {
            return (_dblValue_1 * _dblValue_2) / 144d;
        }

        public static double get_decSqInchToSqFeet(double _decSqInch)
        {
            return _decSqInch / 144d;
        }

        //Ratio******************************************************************
        public static double get_decRatio(double _dblNumerator, double _dblDenominator)
        {
            return _dblNumerator / _dblDenominator;
        }

        //Temperature******************************************************************
        public static double get_dblFarenheit(double _dblCelcius)
        {
            return (_dblCelcius * (9d / 5d)) + 32d;
        }

        public static double get_dblCelcius(double _dblFarenheit)
        {
            return (_dblFarenheit - 32d) * (5d / 9d);
        }


        //Capacity******************************************************************
        public static int get_intSensibleHeatBTU(int _intCFM, double _dblTemp_1, double _dblTemp_2)
        {
            return Convert.ToInt32(Math.Ceiling(Math.Abs(1.08d * Convert.ToDouble(_intCFM) * (_dblTemp_2 - _dblTemp_1))));
        }

        public static int get_intLatentHeatBTU(int _intCFM, double _dblGrainsPerPound_1, double _dblGrainsPerPound_2)
        {
            return Convert.ToInt32(Math.Ceiling(Math.Abs(0.69d * Convert.ToDouble(_intCFM) * (_dblGrainsPerPound_2 - _dblGrainsPerPound_1))));
        }

        public static int get_intTotalHeatBTU(int _intCFM, double _dblEnthalpy_1, double _dblEnthalpy_2)
        {
            return Convert.ToInt32(Math.Ceiling(Math.Abs(0.45d * Convert.ToDouble(_intCFM) * (_dblEnthalpy_2 - _dblEnthalpy_1))));
        }


        //Air Mixing*****************************************************************
        public static int get_intMixingCFM(int _intCFM_1, int _intCFM_2)
        {
            return (_intCFM_1 + _intCFM_2);
        }


        public static double get_intMixingCondition(double _dblEnteringCFM1, double _dblEnteringTemp1, double _dblEnteringCFM2, double _dblEnteringTemp2)
        {
            return (_dblEnteringCFM1 * _dblEnteringTemp1 + _dblEnteringCFM2 * _dblEnteringTemp2) / (_dblEnteringCFM1 + _dblEnteringCFM2);
        }


        //TD to BTU*******************************************************************
        public static double TD_to_BTUH(int _intCFM, double dblDeltaT, int intAltitude)
        {
            return 1.08d * Convert.ToDouble(_intCFM) * dblDeltaT /** PsyCalcFormula.AirDensityRatio(intAltitude)*/;
        }

        //Gas Burner Input***************************************************
        public static int get_intIndirectFiredGasBurnerInput(int _intOutput)
        {
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(_intOutput) * 1.25d));
        }

        public static int get_intIndirectFiredGasBurnerOutput(int _intInput)
        {
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(_intInput) * 0.8d));
        }

        //Gas Burner Leaving Air DB***************************************************
        public static double get_intGasBurnerLeavingAirDB(int _intCFM, double _dblEnteringAirDB, int _intOutput)
        {
            return _dblEnteringAirDB + (Convert.ToDouble(_intOutput) / (1.08d * Convert.ToDouble(_intCFM)));
        }

        //Velocity******************************************************************
        public static double get_decVelocity(int _intCFM, double _dblArea)
        {
            return Convert.ToDouble(_intCFM) / _dblArea;
        }

        //GPM
        public static double get_dblGPM_FromMBH_EWT_LWT(double _intMBH, double _dblEWT, double _dblLWT)
        {
            return Convert.ToDouble(_intMBH) / (0.5d * (_dblLWT - _dblEWT));
        }

        //GPM        
        public static double get_dblGPM_FromBTUH_EWT_LWT(double _dblBTUH, double _dblEWT, double _dblLWT)
        {
            return Convert.ToDouble(_dblBTUH) / (500d * (_dblLWT - _dblEWT));
        }

        //LWT
        public static double get_dblLWT_FromMBH_GPM_EWT(int _intMBH, double _dblGPM, double _dblEWT)
        {
            return (Convert.ToDouble(_intMBH) / (0.5d * _dblGPM)) + _dblEWT;
        }

        //LWT
        public static double get_dblLWT_FromBTUH_GPM_EWT(double _dblBTUH, double _dblGPM, double _dblEWT)
        {
            return (_dblBTUH / (500d * _dblGPM)) + _dblEWT;
        }




        //            public static double  getP(double h)
        //            { //  Rem H in meters

        //        getP = 101325 * (1 - 6.5 * h / 288.15 / 1000) ^ (9.80665 * 28.9644 / (8.31432 * 6.5))
        //      //  Rem getP returns pressure in Pa

        //    }




        //    public static double  P(double z, double T)
        //    { // Rem z in feet

        //    z0 = z / 3.281
        //    Tm = (T - 32) / 1.8

        ////    Rem Tz = 293.15 - z / 200
        ////    Rem T0 = (Tm + Tz) / 2

        //        P = 29.921 * (1 - 0.0065 * z0 / (Tm + 0.0065 * z0 + 273.15)) ^ 5.257
        //     //   Rem P returns pressure in inHg

        //    }




        //    public static double  Patm(double z)
        //    {  //  Rem z in meters

        ////    Rem Tm = (T - 32) / 1.8 + 273.15
        ////    Rem Tz = 293.15 - z / 200
        // //   Rem T0 = (Tm + Tz) / 2

        //        return 101325d * ((288.15d - 0.0032d * z) / 288.15d) ^ 5.2561d
        //    //    Rem Patm returns pressure in Pa

        //    }




        //    public static double  getRHO(double db,double  h)
        //    {
        //        return getP(h) * 28.9644d / (8.31432d * ((db - 32d) / 1.8d + 273.15d) * 1000d);
        //    //    Rem Returns density in lb/ft^3

        //    }




        //    public static double  getCpa(double db)
        //    {
        //        return  1.00567d + 0.000016305d * db;
        //    //    Rem Returns dry air heat capacity in kJ/kg/C

        //    }




        //    public static double  getCpv(double db)
        //    {//  Rem db must be in Celsius

        //        return  1.835d - 0.000734d * db;
        //    //    Rem Returns water vapor heat capacity in kJ/kg/C

        //    }




        //    public static double  getdp(double db,double  RH)
        //    {
        //        db = (db - 32) / 1.8
        //     //   Rem convert temp to Celsius for calculation

        //        a = 17.27
        //        b = 237.7
        //        alpha = a * db / (b + db) + Log(RH)
        //        getdp = alpha * b / (a - alpha)
        //   //     Rem getdp returns celsius temperature

        //        return = getdp * 1.8 + 32
        //    //    Rem convert temp to Farenheit

        //    }








        //    public static double  getPv(double db, double wb, double Patm)
        //    {  // Rem convert Patm to mmHg
        //    double P0 = Patm * 25.4d;
        // //   Rem Get a temperature in Celsius for the calculation of the heat capacity for dry air
        //    double c = (db - 32d) / 1.8d;

        //       return Psat(wb) - (1000 * getCpa(c) * 5d / 9d * (db - wb) * (P0 - Psat(wb)) / (0.622d * Lth(wb) * 1000d));
        //    //    Rem Returns actual vapor pressure in mmHg

        //    }




        //    public static double  Lth(double wb)
        //    {  //    Rem wb in Farenheit
        //       return 2501d - 2.65d * (wb - 32d) / 1.8d;

        //    }




        //    public static double  getRH(double db,double  wb, double Patm)
        //    { //   Rem db & wb [F] - Patm [inHg]

        //        return getPv(db, wb, Patm) / Psat(db);

        //    }





        //    public static double  getX(double db, double wb, double Patm)
        //    { //   Rem calculate humidity ratio

        //        return 0.622d * getPv(db, wb, Patm) / (Patm * 25.4d - getPv(db, wb, Patm));
        // //       Rem Returns humidity ratio in kg/kg or lb/lb

        //    }





        //    public static double  getXRH(double db,double  RH,double  Patm)
        //    {  //Rem calculate humidity ratio
        //    //Rem db in F and Patm inHg

        //        return 0.622d * RH * Psat(db) / (Patm * 25.4d - Psat(db) * RH);
        //        //Rem Returns humidity ratio in kg/kg or lb/lb

        //    }





        //    public static double  HSI(double db, double wb, double Patm)
        //    {   
        //        double T = (db - 32d) / 1.8d;
        //    //Rem convert farenheit to celsius

        //         return getCpa(T) * T - 0.026d + getX(db, wb, Patm) * (2501d + getCpv(T) * T);
        //        //Rem returns enthalpy in kJ/kg

        //    }





        //    //Rem Function H(db, wb, Patm)
        //    //Rem a = (db - 32) / 1.8
        //    //Rem convert db to celsius for heat capacity calculation

        //    //   Rem H = 0.2389 * (getCpa(a) * db) + getX(db, wb, Patm) * (1075 + 0.2389 * (getCpv(a) * db))
        //    //   Rem returns enthalpy in BTU/lb

        //    //Rem End Function




        //    public static double Hz(double db, double wb, double z)
        //    {
        //        double a = (db - 32d) / 1.8d
        //    //Rem convert db to celsius for heat capacity calculation

        //       return 0.2389d * (getCpa(a) * db) + getX(db, wb, P(z, T)) * (1075d + 0.2389d * (getCpv(a) * db))
        //       //Rem returns enthalpy in BTU/lb

        //    }



        //    public static double HRH(double db, double RH, double Patm)
        //    {
        //        double a = (db - 32) / 1.8
        //  //  Rem convert db to celsius for heat capacity calculation

        //      return 0.2389 * (getCpa(a) * db) + getXRH(db, RH, Patm) * (1075 + 0.2389 * (getCpv(a) * db));
        //    //   Rem returns enthalpy in BTU/lb

        //}

        //    Rem Function enthalpyRH(db, RH)
        //     Rem a = 0.00746 * db ^ 2 - 0.4344 * db + 11.1769
        //     Rem B = 0.2372 * db + 0.123

        //    Rem enthalpyRH = a * RH + B

        //  Rem End Function




        //     Rem Function Pws(db)
        //    Rem db is in Farenheit

        //    Rem Convert Kelvin to Farenheit
        //      Rem db = (db - 32) / 1.8 + 273.15

        //        Rem Pws = Exp(77.345 + 0.0057 * db - 7235 / db) / db ^ 8.2
        //         Rem Pws is in Pa


        //Rem End Function




        //Rem Function Pwws(db, Patm)
        //Rem db in Celsius
        //Rem Pwws return a pressure in hPa
        //Rem Patm in hPa

        //    Rem Pwws = (1.0007 + 3.46 * 10 ^ (-6) * Patm) * 6.1121 * Exp((17.502 * db) / (240.97 + db))

        //Rem End Function




        //Rem Function Pw(T)
        //Rem for saturated pressure, use dry bulb
        //Rem for actual partial pressure, use dew point

        //    Rem T = (T - 32) / 1.8
        //    Rem convert temperature from Farenheit to Celsius

        //    Rem Pw = 6.11 * Exp(17.67 * T / (243.5 + T))
        //    Rem Pw in hPa

        //Rem End Function















        //        Function getP(h)
        //    Rem H in meters

        //    getP = 101325 * (1 - 6.5 * h / 288.15 / 1000) ^ (9.80665 * 28.9644 / (8.31432 * 6.5))
        //    Rem getP returns pressure in Pa

        //End Function




        //Function P(z, T)
        //Rem z in feet

        //z0 = z / 3.281
        //Tm = (T - 32) / 1.8

        //Rem Tz = 293.15 - z / 200
        //Rem T0 = (Tm + Tz) / 2

        //    P = 29.921 * (1 - 0.0065 * z0 / (Tm + 0.0065 * z0 + 273.15)) ^ 5.257
        //    Rem P returns pressure in inHg

        //End Function




        //Function Patm(z)
        //Rem z in meters

        //Rem Tm = (T - 32) / 1.8 + 273.15
        //Rem Tz = 293.15 - z / 200
        //Rem T0 = (Tm + Tz) / 2

        //    Patm = 101325 * ((288.15 - 0.0032 * z) / 288.15) ^ 5.2561
        //    Rem Patm returns pressure in Pa

        //End Function




        //Function getRHO(db, h)

        //    getRHO = getP(h) * 28.9644 / (8.31432 * ((T - 32) / 1.8 + 273.15) * 1000)
        //    Rem Returns density in lb/ft^3

        //End Function




        //Function getCpa(db)

        //    getCpa = 1.00567 + 0.000016305 * db
        //    Rem Returns dry air heat capacity in kJ/kg/C

        //End Function




        //Function getCpv(db)
        //Rem db must be in Celsius

        //    getCpv = 1.835 - 0.000734 * db
        //    Rem Returns water vapor heat capacity in kJ/kg/C

        //End Function




        //Function getdp(db, RH)

        //    db = (db - 32) / 1.8
        //    Rem convert temp to Celsius for calculation

        //    a = 17.27
        //    b = 237.7
        //    alpha = a * db / (b + db) + Log(RH)
        //    getdp = alpha * b / (a - alpha)
        //    Rem getdp returns celsius temperature

        //    getdp = getdp * 1.8 + 32
        //    Rem convert temp to Farenheit

        //End Function




        //Function Psat(T)
        //Rem Dupre Formula

        //    If (T < 32) Then
        //        Psat = 0.0075 * Exp(28.916 - 6140.4 / ((T - 32) / 1.8 + 273.15))
        //        Rem the 0.0075 coefficient converts Ps from Pa to mmHg (required for vapor pressure calculation)

        //    Else
        //        Psat = Exp(46.784 - 6435 / ((T - 32) / 1.8 + 273.15) - 3.868 * Log(((T - 32) / 1.8 + 273.15)))
        //        Rem Psat returns a pressure in mmHg

        //    End If

        //End Function




        //Function getPv(db, wb, Patm)
        //Rem convert Patm to mmHg
        //P0 = Patm * 25.4
        //Rem Get a temperature in Celsius for the calculation of the heat capacity for dry air
        //c = (db - 32) / 1.8

        //    getPv = Psat(wb) - (1000 * getCpa(c) * 5 / 9 * (db - wb) * (P0 - Psat(wb)) / (0.622 * Lth(wb) * 1000))
        //    Rem Returns actual vapor pressure in mmHg

        //End Function




        //Function Lth(wb)
        //Rem wb in Farenheit
        //    Lth = 2501 - 2.65 * (wb - 32) / 1.8

        //End Function




        //Function getRH(db, wb, Patm)
        //Rem db & wb [F] - Patm [inHg]

        //    getRH = getPv(db, wb, Patm) / Psat(db)

        //End Function





        //Function getX(db, wb, Patm)
        //Rem calculate humidity ratio

        //    getX = 0.622 * getPv(db, wb, Patm) / (Patm * 25.4 - getPv(db, wb, Patm))
        //    Rem Returns humidity ratio in kg/kg or lb/lb

        //End Function





        //Function getXRH(db, RH, Patm)
        //Rem calculate humidity ratio
        //Rem db in F and Patm inHg

        //    getXRH = 0.622 * RH * Psat(db) / (Patm * 25.4 - Psat(db) * RH)
        //    Rem Returns humidity ratio in kg/kg or lb/lb

        //End Function





        //Function HSI(db, wb, Patm)
        //T = (db - 32) / 1.8
        //Rem convert farenheit to celsius

        //    HSI = getCpa(T) * T - 0.026 + getX(db, wb, Patm) * (2501 + getCpv(T) * T)
        //    Rem returns enthalpy in kJ/kg

        //End Function





        //Rem Function H(db, wb, Patm)
        //Rem a = (db - 32) / 1.8
        //Rem convert db to celsius for heat capacity calculation

        //   Rem H = 0.2389 * (getCpa(a) * db) + getX(db, wb, Patm) * (1075 + 0.2389 * (getCpv(a) * db))
        //   Rem returns enthalpy in BTU/lb

        //Rem End Function




        //Function Hz(db, wb, z)
        //a = (db - 32) / 1.8
        //Rem convert db to celsius for heat capacity calculation

        //   Hz = 0.2389 * (getCpa(a) * db) + getX(db, wb, P(z, T)) * (1075 + 0.2389 * (getCpv(a) * db))
        //   Rem returns enthalpy in BTU/lb

        //End Function




        //Function HRH(db, RH, Patm)
        //a = (db - 32) / 1.8
        //Rem convert db to celsius for heat capacity calculation

        //   HRH = 0.2389 * (getCpa(a) * db) + getXRH(db, RH, Patm) * (1075 + 0.2389 * (getCpv(a) * db))
        //   Rem returns enthalpy in BTU/lb

        //End Function



        //Rem Function enthalpyRH(db, RH)
        //    Rem a = 0.00746 * db ^ 2 - 0.4344 * db + 11.1769
        //    Rem B = 0.2372 * db + 0.123

        //    Rem enthalpyRH = a * RH + B

        //Rem End Function




        //Rem Function Pws(db)
        //Rem db is in Farenheit

        //    Rem Convert Kelvin to Farenheit
        //    Rem db = (db - 32) / 1.8 + 273.15

        //    Rem Pws = Exp(77.345 + 0.0057 * db - 7235 / db) / db ^ 8.2
        //    Rem Pws is in Pa


        //Rem End Function




        //Rem Function Pwws(db, Patm)
        //Rem db in Celsius
        //Rem Pwws return a pressure in hPa
        //Rem Patm in hPa

        //    Rem Pwws = (1.0007 + 3.46 * 10 ^ (-6) * Patm) * 6.1121 * Exp((17.502 * db) / (240.97 + db))

        //Rem End Function




        //Rem Function Pw(T)
        //Rem for saturated pressure, use dry bulb
        //Rem for actual partial pressure, use dew point

        //    Rem T = (T - 32) / 1.8
        //    Rem convert temperature from Farenheit to Celsius

        //    Rem Pw = 6.11 * Exp(17.67 * T / (243.5 + T))
        //    Rem Pw in hPa

        //Rem End Function
    }
}