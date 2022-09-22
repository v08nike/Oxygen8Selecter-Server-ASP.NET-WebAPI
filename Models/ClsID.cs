using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsID
    { 
        //-------------------------------------------------------------------------
        //DATABASE TABLES SAVING COLUMNS ID's        
        //-------------------------------------------------------------------------
        public static string strColumnID = "id";
        public static string strColumnJobID = "job_id";
        public static string strColumnUnitNo = "unit_no";
        public static string strColumnComponentNo = "component_no";
        public static string strColumnDrawingRequestID = "drawing_request_id";
        public static string strColumnAttachedUnitNo = "attached_Unit_no";

        //-------------------------------------------------------------------------
        //SESSION        
        //-------------------------------------------------------------------------
        //public static string strCtrlName = "CtrlName";
        public static string strSesVarElecHeaterVoltageID = "ElecHeaterVoltageID";


        //-------------------------------------------------------------------------
        //ATTRIBUTES        
        //-------------------------------------------------------------------------
        //public static string strAttUnitNo = "UnitNo";
        public static string strAttProductTypeID = "ProductTypeID";
        //public static string strAttQuoteID = "QuoteID";
        //public static string strAttUnitModelID = "UnitModelID";
        public static string strAttSelectionTypeID = "SelectionTypeID";
        public static string strAttUnitVoltageID = "UnitVoltageID";
        public static string strAttUnitModelSelected = "UnitModelSelected";
        //public static string strAttUnitModel_1_HX_CondWarning = "UnitModel_1_HX_CondWarning";
        //public static string strAttUnitModel_2_HX_CondWarning = "UnitModel_2_HX_CondWarning";
        //public static string strAttUnitModel_3_HX_CondWarning = "UnitModel_3_HX_CondWarning";
        //public static string strAttUnitModel_4_HX_CondWarning = "UnitModel_4_HX_CondWarning";


        //-------------------------------------------------------------------------
        //ID'S FROM DATABASE TABLES
        //-------------------------------------------------------------------------
        public static int intApplicationOtherID = 10;

        public static int intDesignDataCooling_010_Heating_990_ID = 1;
        public static int intDesignDataCooling_004_Heating_996_ID = 2;
        //public static int intDesignDataCooling_010_ID = 3;
        //public static int intDesignDataCooling_004_ID = 4;


        public static int intUoM_Imperial = 1;
        public static int intUoM_Metric = 2;

        public const int intCountryCanadaID = 1;
        public const int intCountryUSA_ID = 2;

        //-------------------------------------------------------------------------
        public const int intProdTypeNovaID = 1;
        public const int intProdTypeVentumID = 2;
        public const int intProdTypeVentumLiteID = 3;
        public const int intProdTypeTerraID = 4;


        public const int intUnitTypeERV_ID = 1;
        public const int intUnitTypeHRV_ID = 2;
        public const int intUnitTypeAHU_ID = 3;


        public const int intControlsPrefCV_ID = 1;
        public const int intControlsPrefVAV_ID = 2;
        public const int intControlsPrefDCV_CO2_ID = 4;
        public const int intControlPrefByOthersID = 6;


        public static int intInstallationInteriorID = 1;
        public static int intInstalaltionExteriorID = 2;


        public static int intAirFlowApplicationCAV_ID = 1;
        public static int intAirFlowApplciationVAV_ID = 2;


        public static int intGeneralConfigurationSideSideID = 2;
        public static int intGeneralConfigurationTopBottomID = 3;


        public const int intLocationIndoorID = 1;
        public const int intLocationOutdoorID = 2;


        public static int intOrientationHorizontalID = 1;
        public static int intOrientationVerticalID = 2;


        public static int intFilterLocationOutdoorAirFilterID = 2;
        public static int intFilterLocationFinalFilterID = 3;
        public static int intFilterLocationReturnAirFilterID = 4;
        public static int intFilterModel_NA_ID = 1;
        public static int intFilterModel_2in_85_MERV_13_ID = 9;


        public const int intCoilTypeHotWaterID = 1;
        public const int intCoilTypeChilledWaterID = 2;
        public const int intCoilTypeDX_ID = 3;
        public const int intCoilTypeHotGasReheatID = 4;
        public const int intCoilTypeCondenserID = 5;
        public const int intCoilTypeSteamID = 6;   //Not in use


        public const int intCompNA_ID = 1;
        public const int intCompElecHeaterID = 2;
        public const int intCompHWC_ID = 3;
        public const int intCompCWC_ID = 4;
        public const int intCompDX_ID = 5;
        public const int intCompHGRH_ID = 6;
        public const int intCompAutoID = 7;


        public const int intDamperActuatorNA_ID = 1;
        public const int intDamperActuatorNoCasingID = 2;
        public const int intDamperActuatorInCasingID = 4;


        public const int intElecHeaterInstallNA_ID = 1;
        public const int intElecHeaterInstallDuctMountedID = 2;
        public const int intElecHeaterInstallInCasingID = 3;


        public static int intNovaUnitModelID_A16IN = 1;
        public static int intNovaUnitModelID_B20IN = 2;
        public static int intNovaUnitModelID_A18OU = 6;
        public static int intNovaUnitModelID_B22OU = 7;


        public static int intVentumUnitModelID_H05IN_ERV = 1;
        public static int intVentumUnitModelID_H10IN_ERV = 2;
        public static int intVentumUnitModelID_H05IN_HRV = 7;
        public static int intVentumUnitModelID_H10IN_HRV = 8;


        public static int intVentumLiteUnitModelID_H04IN_ERV = 1;

        public static int intElectricVoltage_208V_1Ph_60HzID = 2;
        public static int intElectricVoltage_240V_1Ph_60HzID = 3;
        public static int intElectricVoltage_208V_3Ph_60HzID = 4;
        public static int intElectricVoltage_460V_3ph_60HzID = 6;


        public static int intFanPlacementLeftID = 1;
        public static int intFanPlacementRightID = 2;


        public static int intSA_Open_2_ID = 3;


        public static int intFOB_PointVancouverID = 1;
        public static int intFOB_PointTorontoID = 2;


        public const int intCustomerTypeAllID = 1;
        public const int intCustomerTypeAdminID = 2;
        public const int intCustomerTypeInternalID = 3;
        public const int intCustomerTypeRepID = 4;
        public const int intCustomerTypeSpecifyingID = 5;


        public static int intUserAdminID = 1;   //ID
        public static int intUserAccess = 1;    //Access 1:Yes, 2:No
        public static int intUAL_Admin = 10;            //Access Level
        public static int intUAL_IntAdmin = 4;          //Access Level
        public static int intUAL_IntLvl_2 = 3;          //Access Level
        public static int intUAL_IntLvl_1 = 2;          //Access Level
        public static int intUAL_External = 1;          //Access Level
        public static int intUAL_ExternalSpecial = 5;   //Access Level


        public static int intUserID_Dorothy = 8;
        public static int intUserID_Jamey = 1592;
        public static int intUserID_Jamie_Yeh = 809;    //Jaime Yeh - AHRI Test



        //-------------------------------------------------------------------------------------------------------
        //NO DATABASE ID'S
        public static int intSelectionTypeCoupled = 1;
        public static int intSelectionTypeDecoupled = 2;

        public static string strSelectionTypeCoupledValue = "CP";
        public static string strSelectionTypeDecoupledValue = "DC";

        public static int intNotRequired = -999999;
        public static double dblWinterPreheatSetpointDB_Min = 0d;
        public static double dblSummerReheatSetpointDB_Min = 55d;

        public static string strYes = "Yes";
        public static string strNo = "No";


        public enum enmSelectType { CP, DC }
        public enum enmSeason { Summer, Winter }
        public enum enmPageOrientation { Portrait, Landscape }
        public enum enmFileType { WORD, EXCEL, PDF };
        public enum enmOutputType { Selection, Submittal };
        public enum enmFanLocation { Supply, Exhaust };

        public const int intReportStageSelecionID = 1;
        public const int intReportStageSubmittalID = 2;

        public const int intCurrencyPercent = 1;
        public const int intCurrencyDollar = 2;

        public static String[] arrFanQtyToText = { "Zero", "Single", "Two", "Three", "Four", "Five" };

        //public const string strSoftwareVersion = "Version 1.0.0.2";
        //public const string strSoftwareVersion = "Version 1.0.0.3"; //2021-Aug-10
        public const string strSoftwareVersion = "Version 1.0.0.4"; //2022-Feb-02

        public const string strPricingVersion = "Version 1.0.0.0";
    }
}