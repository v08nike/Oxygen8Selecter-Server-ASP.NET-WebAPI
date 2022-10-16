using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxygen8SelectorServer.Models
{
    public class ClsGV
    {
        public static string strFolderTempFiles = "TempFiles";        //Folder for fan curves, drawings, reports...
        public static string strFolderSubmittal_Schedules = "Submittals_Schedules";        //Folder for fan curves, drawings, reports...
        //public static string strFolderDrawing = "FreshAirDrawings";
        //public static string strFolderPDF_Files = "FreshAirPDF_Files";
        public static string strFolderFiles = "FreshAirFiles";
        public static string strReport = "Report.pdf";
        //public static string strTempDrawing = "TempDrawing.pdf";
        public static string strTempDrawingPDF = "TempDrawing.pdf";
        public static string strTempDrawingDWG = "TempDrawing.dwg";
        public static string strExcelSelection = "Oxygen8_Selection_Template.xlsx";
        public static string strExcelSubmittal = "Oxygen8_Submittal_Template.xlsx";
        public static string strExcelSchedule = "Oxygen8_Schedule_Template.xlsx";


        public static string strLocDrawings = "Drawings";
        public static string strLocLayouts = "Layouts";
        //public static string strLocCutsheets = "~/Cutsheets";
        public static string strLocCutsheetsSubmittals = "~/CutsheetsSubmittals";


        public static string strResouLiteratureComm = "~/Resources/LiteratureCommercial";
        public static string strResouLiteratureResi = "~/Resources/LiteratureResidential";

        public static string strResouManualComm = "~/Resources/ManualCommercial";
        public static string strResouManualResi = "~/Resources/ManualResidential";

        public static string strResouSpecificationComm = "~/Resources/SpecificationCommercial";
        public static string strResouSpecificationResi = "~/Resources/SpecificationResidential";

        public static string strResouTechResourceComm = "~/Resources/TechResourceCommercial";
        public static string strResouTechResourceResi = "~/Resources/TechResourceResidential";

        public static string strResouPresentationEngineer = "~/Resources/PresentationEngineer";
        public static string strResouPresentationContractor = "~/Resources/PresentationContractor";
        public static string strResouPresentationSales = "~/Resources/PresentationSales";


        public static string strResouVideos = "~/Resources/Videos";

        public const double dblAHRI_SummerOA_DB_Max = 120d;
        public const double dblAHRI_WinterOA_DB_Min = 35d;
        public const double dblAHRI_WinterOA_RH_Max = 95d;
        public const double dblTERRA_PREHEAT_DX_HEATPUMP_17DEG = 17d;
        public const double dblTERRA_PREHEAT_DX_HEATPUMP_HGRH_33DEG = 33d;

        public static string strAHRISummerOnlyMsg = "Summer performance: Certified in accordance with the AHRI ERV Certification Program, which is based on AHRI Standard 1060. Certified units may be found in the AHRI Directory at www.ahridirectory.org." + Environment.NewLine + Environment.NewLine +
                                                    "Winter performance: Application rating is outside the scope of the AHRI ERV Certification Program but is rated in accordance with AHRI Standard 1060.";

        public static string strAHRIWinterOnlyMsg = "Winter performance: Certified in accordance with the AHRI ERV Certification Program, which is based on AHRI Standard 1060. Certified units may be found in the AHRI Directory at www.ahridirectory.org." + Environment.NewLine + Environment.NewLine +
                                                    "Summer performance: Application rating is outside the scope of the AHRI ERV Certification Program but is rated in accordance with AHRI Standard 1060.";

        public static string strAHRISummerAndWinterMsg = "This statement Certified in accordance with AHRI ERV Certification Program, which is based on " +
                                                        "AHRI Standard 1060. Certified units may be found in the AHRI Directory at www.ahridirectory.org";

        public static string strAHRINoSummerNoWinterMsg = "Summer performance: Application rating is outside the scope of the AHRI ERV Certification Program but is rated in accordance with AHRI Standard 1060." + Environment.NewLine + Environment.NewLine +
                                                            "Winter performance: Application rating is outside the scope of the AHRI ERV Certification Program but is rated in accordance with AHRI Standard 1060.";

        //public static string strVentumCondWarningMsg = "At current design conditions the heat exchanger is at risk of condensing and freezing. The unit does not contain a drain pan and pre-heat is recommended. Any damage that may occur to the unit due to condensation or freezing will not be covered under warranty.";
        public static string strVentumNoPreheatCondWarningMsg = "Condensation occurring across heat exchanger, drain connection required.See drawing." + Environment.NewLine + Environment.NewLine +
                                                                "At current design conditions the heat exchanger is at risk of freezing; performance will be affected. Contact Oxygen8 Applications team for a selection.";


        public static string strVentumCondWarningMsg = "At current design conditions condensation might form on the heat exchanger, unit has a drain pan and a drain connection. See drawings below for the location of drain connection.";


        public static string strVentumERV_AHRIMsg = "Certified in accordance with AHRI ERV Certification Program, which is based on AHRI Standard 1060. Certified units may be found in the AHRI Directory at www.ahridirectory.org";


        public static string strSensorPressTrans_PTH_6202 = "PTH_6202";
        public static string strSensorVTH_6202_VOC_CO2 = "VTH_6202";
        public static string strSensorTTH_6202 = "TTH_6202";
        public static string strSensorHTH_6202 = "HTH_6202";
        public static string strSensorETF_1098L1_4 = "ETF_1098L1_4";
        public static string strSensorETF_598B_5 = "ETF_598B_5";

    }
}