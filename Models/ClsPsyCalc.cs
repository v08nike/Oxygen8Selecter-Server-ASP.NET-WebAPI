using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Oxygen8SelectorServer.Models
{
    public class ClsPsyCalc
    {
        [DllImport("Psylib32.dll")]
        private static extern float LCWBTOGR(float temp, float tempWet, int feet);
        [DllImport("PsyLib32.dll")]
        private static extern float LCRH(float DB, float GR, int Alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCSATGRAINS(float DB, int Alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCWETBULB(float DB, float grains, int Alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCDENSITY(float DB, float grains, int Alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCDEWPOINT(float grains, int Alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCRHTOGR(float DB, float RH, int Alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCENTHALPY(float DB, float grains);


        public static float get_fltDensity_ByDB_Grains(float fltDryBulb, float fltGrains, int intAltitude)
        {
            return LCDENSITY(fltDryBulb, (float)Convert.ToDecimal(Convert.ToDecimal(Math.Floor(fltGrains * 100f)) / 100m), intAltitude);
        }

        public static float get_fltSaturationHumidityRatio_ByDB_Or_DP(float fltDryBulbOrDewPoint, int intAltitude)
        {
            return LCSATGRAINS(fltDryBulbOrDewPoint, intAltitude);
        }

        public static float get_fltRH_ByDB_Grains(float fltDryBulb, float fltGrains, int intAltitude)
        {
            return LCRH(fltDryBulb, fltGrains, intAltitude);
        }

        public static float get_fltRH_ByDB_WB(float fltDryBulb, float fltWetBulb, int intAltitude)
        {
            return LCRH(fltDryBulb, get_fltGrainsByDB_WB(fltDryBulb, fltWetBulb, intAltitude), intAltitude);
        }

        public static float get_fltGrains_ByDB_RH(float fltDryBulb, float fltRh, int intAltitude)
        {
            return LCRHTOGR(fltDryBulb, (fltRh > 1 ? fltRh / 100f : fltRh), intAltitude);
        }

        public static float get_fltDewPoint_ByGrains(float fltGrains, int intAltitude)
        {
            return LCDEWPOINT(fltGrains, intAltitude);
        }

        public static float get_fltWB_ByDB_Grains(float fltDryBulb, float fltGrains, int intAltitude)
        {
            return LCWETBULB(fltDryBulb, fltGrains, intAltitude);
        }

        public static float get_fltWB_ByDB_RH(float fltDryBulb, float fltRH, int intAltitude)
        {
            return LCWETBULB(fltDryBulb, get_fltGrains_ByDB_RH(fltDryBulb, fltRH, intAltitude), intAltitude);
        }

        public static float get_fltGrainsByDB_WB(float fltDryBulb, float fltWetBulb, int intAltitude)
        {
            return LCWBTOGR(fltDryBulb, fltWetBulb, intAltitude);
        }

        public static float get_fltEnthalpyByDB_Grains(float fltDryBulb, float fltGrains)
        {
            return LCENTHALPY(fltDryBulb, fltGrains);
        }

        public static float get_fltAirDensityRatio(int intAltitude)
        {
            float DryBulb = 70f;
            float RH = 0.50f;

            //get density at sea level (0ft)
            float SeaLevelDensity = get_fltDensity_ByDB_Grains(DryBulb, get_fltGrains_ByDB_RH(DryBulb, RH, 0), 0);
            //get density at given altitude
            float AltitudeDensity = get_fltDensity_ByDB_Grains(DryBulb, get_fltGrains_ByDB_RH(DryBulb, RH, intAltitude), intAltitude);
            //make the ratio
            float fltAirDensityRatio = AltitudeDensity / SeaLevelDensity;

            return fltAirDensityRatio;
        }
    }
}