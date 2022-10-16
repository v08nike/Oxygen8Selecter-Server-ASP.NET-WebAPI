using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Oxygen8SelectorServer.Models
{
    public class ClsOutputExcel
    {
        private static string strExecutablePath = HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderFiles);
        private static string strOutputExcelFileName = "";
        //private static string strSalesNo = "";
        //private static string strProjectName = "";
        //private static ClsJobInfo objJobInfo;
        //private static ClsGeneral objGeneral;
        //private static ClsAirFlowData objAirFlowData;
        //private static ClsCoilREFPLUS objDX;



        public static string getPricing(DataTable _dtJob, DataTable _dtProduct)
        {
            string strFileName = "";
            strOutputExcelFileName = "PricingTemplate" + _dtJob.Rows[0]["created_user_id"].ToString() + ".xlsx";

            if (Convert.ToInt32(_dtJob.Rows[0]["id"]) > 0)
            {
                //DataTable dtUser = ClswwDBQ.SelectById(ClsDBT.strSavUser, Convert.ToInt32(Request.QueryString[ClsSV._intUserID]));
                //DataTable dtJob = ClsDBQ.SelectById(ClsDBT.strSavJob, Convert.ToInt32(Request.QueryString[ClsSV._intJobID]));
                //DataTable dtOrderScheduleLowH2O = ClsGO.get_dtOrderScheduleLowH2O(Convert.ToInt32(Request.QueryString[ClsSV._intJobID]));
                //DataTable dtOrderScheduleDynamics = ClsGO.get_dtOrderScheduleDynamics(Convert.ToInt32(Request.QueryString[ClsSV._intJobID]));


                #region Excel Interop Sample
                //////Excel Interop Sample-------------------------------------------------------------------------------------------

                ////Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                ////if (xlApp == null)
                ////{
                ////    //MessageBox.Show("Excel is not properly installed!!");
                ////    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", ClsAlert.get_sbMessage("Excel is not properly installed!!").ToString());
                ////    return;
                ////}


                ////Excel.Workbook xlWorkBook;
                ////Excel.Worksheet xlWorkSheet;
                ////object misValue = System.Reflection.Missing.Value;

                ////xlWorkBook = xlApp.Workbooks.Add(misValue);
                ////xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                ////xlWorkSheet.Cells[3, 1] = "Job: ";
                ////xlWorkSheet.Cells[3, 2] = dtJob.Rows[0]["job_name"].ToString();
                ////xlWorkSheet.Cells[4, 1] = "Prepared For: ";
                ////xlWorkSheet.Cells[4, 2] = dtJob.Rows[0]["prepared_for"].ToString();
                ////xlWorkSheet.Cells[3, 6] = "Job No.: ";
                ////xlWorkSheet.Cells[3, 7] = "J" + (100000 + Convert.ToInt32(dtJob.Rows[0]["id"])).ToString();
                ////xlWorkSheet.Cells[4, 6] = "Rev. No.: ";
                ////xlWorkSheet.Cells[4, 7] = dtJob.Rows[0]["revision_no"].ToString();
                ////xlWorkSheet.Cells[5, 6] = "Customer PO#: ";
                ////xlWorkSheet.Cells[5, 7] = dtJob.Rows[0]["customer_po"].ToString();
                ////xlWorkSheet.Cells[6, 6] = "Prepared By: ";
                ////xlWorkSheet.Cells[6, 7] = dtUser.Rows[0]["first_name"].ToString() + " " + dtUser.Rows[0]["last_name"].ToString();
                ////xlWorkSheet.Cells[6, 6] = "Prepared Date: ";
                ////xlWorkSheet.Cells[6, 7] = dtJob.Rows[0]["created_date"].ToString();


                ////xlWorkSheet.Cells[intRow, 1] = dtProduct.Rows[0]["value"].ToString().ToUpper();
                ////xlWorkSheet.Cells[intRow, 2] = dtProduct.Rows[0]["value1"].ToString().ToUpper();
                ////xlWorkSheet.Cells[intRow, 3] = dtProduct.Rows[0]["value2"].ToString().ToUpper();
                ////xlWorkSheet.Cells[intRow, 4] = dtProduct.Rows[0]["value3"].ToString().ToUpper();
                ////xlWorkSheet.Cells[intRow, 5] = dtProduct.Rows[0]["value4"].ToString().ToUpper();
                ////intRow++;

                ////for (int i = 1; i < dtProduct.Rows.Count; i++)
                ////{

                ////    xlWorkSheet.Cells[intRow, 1] = dtProduct.Rows[i]["value"].ToString().ToUpper();
                ////    xlWorkSheet.Cells[intRow, 2] = dtProduct.Rows[i]["value1"].ToString().ToUpper();
                ////    xlWorkSheet.Cells[intRow, 3] = dtProduct.Rows[i]["value2"].ToString().ToUpper();
                ////    xlWorkSheet.Cells[intRow, 4] = dtProduct.Rows[i]["value3"].ToString().ToUpper();
                ////    xlWorkSheet.Cells[intRow, 5] = dtProduct.Rows[i]["value4"].ToString().ToUpper();
                ////    intRow++;
                ////}



                ////string strExcelFilePathAndName = exePath + "\\Schedule_" + Convert.ToInt32(Request.QueryString[ClsSV.intUserID]).ToString() + ".xlsx";

                ////if (File.Exists(strExcelFilePathAndName))
                ////{
                ////    File.Delete(strExcelFilePathAndName);
                ////}

                ////xlWorkBook.SaveAs(strExcelFilePathAndName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                ////xlWorkBook.Close(true, misValue, misValue);
                ////xlApp.Quit();

                ////releaseObject(xlWorkSheet);
                ////releaseObject(xlWorkBook);
                ////releaseObject(xlApp);
                #endregion

                #region EPPlus Sample
                //////EPPlus Sample-------------------------------------------------------------------------------------------
                ////ExcelPackage ExcelPkg = new ExcelPackage();
                ////ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Sheet1");
                ////using (ExcelRange Rng = wsSheet1.Cells[2, 2, 2, 2])
                ////{
                ////    Rng.Value = "Welcome to Everyday be coding - tutorials for beginners";
                ////    Rng.Style.Font.Size = 16;
                ////    Rng.Style.Font.Bold = true;
                ////    Rng.Style.Font.Italic = true;
                ////}
                ////wsSheet1.Protection.IsProtected = false;
                ////wsSheet1.Protection.AllowSelectLockedCells = false;
                ////ExcelPkg.SaveAs(new FileInfo(Server.MapPath("~/" + ClsGV.strTempFilesFolder + "\\Schedule_1.xlsx")));
                //////EPPlus Sample-------------------------------------------------------------------------------------------
                #endregion


                int intHeadderStartRow = 3;
                int intHeadderEndRow = 6;
                int intHeadderStartColumn = 1;
                int intHeadderEndColumn = 10;
                int intScheduleStartRow = 20;
                int intScheduleStartColumn = 1;
                int intScheduleEndColumn = 10;
                int intRow = 1;
                int intColumn = 1;
                intRow = 9;
                intColumn = 1;
                DataTable dtTemp = new DataTable();
                string strTableName = "";
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");



                ExcelPackage ExcelPkg = new ExcelPackage();
                ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Sheet1");
                ExcelRange Rng = wsSheet1.Cells[1, 1, 1, 1];

                byte[] file = File.ReadAllBytes(strExecutablePath + "\\PricingTemplate.xlsx");
                using (MemoryStream ms = new MemoryStream(file))

                using (ExcelPkg = new ExcelPackage(ms))
                {
                    if (ExcelPkg.Workbook.Worksheets.Count == 0)
                    {
                        string strError = "Your Excel file does not contain any work sheets";
                    }
                    else
                    {
                        wsSheet1 = ExcelPkg.Workbook.Worksheets["Sheet1"];

                        //var unitmeasure = ewsSelection.DataValidations.AddListValidation("a1");
                        //unitmeasure.Formula.Values.Add("Sq Ft");
                        //unitmeasure.Formula.Values.Add("Meter");
                        //unitmeasure.Formula.Values.Add("Meter");



                        Rng = wsSheet1.Cells[intHeadderStartRow, intHeadderStartColumn, intHeadderEndRow, intHeadderEndColumn];
                        //Rng.Value = "Welcome to Everyday be coding - tutorials for beginners";
                        Rng.Style.Font.Size = 12;
                        Rng.Style.Font.Bold = true;
                        Rng.Style.Font.Italic = true;
                        Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //Rng.Style.Fill.BackgroundColor.SetColor(colFromHex);
                        Rng.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Gray);
                        //Rng.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                        //Rng.Style.Border.Right.Style = ExcelBorderStyle.Thick;
                        //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;


                        //wsSheet1.Cells[3, 1].Value = "Job: ";
                        wsSheet1.Cells["B11"].Value = _dtJob.Rows[0]["job_name"].ToString();
                        wsSheet1.Cells["B12"].Value = "J" + (100000 + Convert.ToInt32(_dtJob.Rows[0]["id"])).ToString();
                        wsSheet1.Cells["B13"].Value = _dtJob.Rows[0]["revision_no"].ToString();
                        //wsSheet1.Cells[4, 1].Value = "Prepared For: ";
                        wsSheet1.Cells["H11"].Value = _dtJob.Rows[0]["prepared_for"].ToString();
                        //wsSheet1.Cells[3, 8].Value = "Job No.: ";
                        //wsSheet1.Cells[4, 8].Value = "Rev. No.: ";
                        //wsSheet1.Cells[5, 8].Value = "Customer PO#: ";
                        wsSheet1.Cells["H12"].Value = _dtJob.Rows[0]["customer_po"].ToString();
                        //wsSheet1.Cells[6, 8].Value = "Prepared By: ";
                        //wsSheet1.Cells[6, 8].Value = "Prepared Date: ";
                        wsSheet1.Cells["H13"].Value = _dtJob.Rows[0]["created_date"].ToString();
                        wsSheet1.Cells["H14"].Value = _dtJob.Rows[0]["created_user_first_name"].ToString() + " " + _dtJob.Rows[0]["created_user_last_name"].ToString();

                        intRow = intScheduleStartRow;
                        //wsSheet1.Cells["A18"].Value = dtProduct.Rows[0]["value1"].ToString().ToUpper();
                        //wsSheet1.Cells["B18"].Value = dtProduct.Rows[0]["value2"].ToString().ToUpper();
                        //wsSheet1.Cells["C18"].Value = dtProduct.Rows[0]["value3"].ToString().ToUpper();
                        //wsSheet1.Cells["D18"].Value = dtProduct.Rows[0]["value4"].ToString().ToUpper();
                        //wsSheet1.Cells["E18"].Value = dtProduct.Rows[0]["value5"].ToString().ToUpper();
                        //wsSheet1.Cells["F18"].Value = dtProduct.Rows[0]["value6"].ToString().ToUpper();
                        //wsSheet1.Cells["G18"].Value = dtProduct.Rows[0]["value7"].ToString().ToUpper();
                        //wsSheet1.Cells["H18"].Value = dtProduct.Rows[0]["value8"].ToString().ToUpper();
                        //wsSheet1.Cells["I18"].Value = dtProduct.Rows[0]["value9"].ToString().ToUpper();
                        //wsSheet1.Cells["J18"].Value = dtProduct.Rows[0]["value10"].ToString().ToUpper();

                        //Rng = wsSheet1.Cells[intScheduleStartRow, intScheduleStartColumn, intScheduleStartRow, intScheduleEndColumn];
                        //Rng.Style.Font.Size = 9;
                        //Rng.Style.Font.Bold = true;
                        //Rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        //Rng.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        //Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //Rng.Style.Fill.BackgroundColor.SetColor(colFromHex);

                        //wsSheet1.Cells["A1:B1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //wsSheet1.Cells["A1:B1"].Style.Fill.BackgroundColor.SetColor(colFromHex);

                        //for (int i = 1; i < dtOrderScheduleLowH2O.Rows.Count; i++)
                        //{
                        //    wsSheet1.Cells["A" + intRow.ToString()].Value = dtOrderScheduleLowH2O.Rows[i]["value1"].ToString().ToUpper();
                        //    wsSheet1.Cells["B" + intRow.ToString()].Value = dtOrderScheduleLowH2O.Rows[i]["value2"].ToString().ToUpper();
                        //    wsSheet1.Cells["C" + intRow.ToString()].Value = dtOrderScheduleLowH2O.Rows[i]["value3"].ToString().ToUpper();
                        //    wsSheet1.Cells["D" + intRow.ToString()].Value = dtOrderScheduleLowH2O.Rows[i]["value4"].ToString().ToUpper();
                        //    wsSheet1.Cells["E" + intRow.ToString()].Value = dtOrderScheduleLowH2O.Rows[i]["value5"].ToString().ToUpper();
                        //    wsSheet1.Cells["F" + intRow.ToString()].Value = dtOrderScheduleLowH2O.Rows[i]["value6"].ToString().ToUpper();
                        //    wsSheet1.Cells["G" + intRow.ToString()].Value = dtOrderScheduleLowH2O.Rows[i]["value7"].ToString().ToUpper();
                        //    wsSheet1.Cells["H" + intRow.ToString()].Value = dtOrderScheduleLowH2O.Rows[i]["value8"].ToString().ToUpper();
                        //    wsSheet1.Cells["I" + intRow.ToString()].Value = dtOrderScheduleLowH2O.Rows[i]["value9"].ToString().ToUpper();
                        //    wsSheet1.Cells["J" + intRow.ToString()].Value = dtOrderScheduleLowH2O.Rows[i]["value10"].ToString().ToUpper();
                        //    intRow++;
                        //}

                        Rng = wsSheet1.Cells[intScheduleStartRow, intScheduleStartColumn, intRow, intScheduleEndColumn];
                        Rng.Style.Font.Size = 9;
                        Rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Rng.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;



                        intScheduleStartRow = 50;
                        intRow = intScheduleStartRow;

                        //for (int i = 1; i < dtOrderScheduleDynamics.Rows.Count; i++)
                        //{
                        //    wsSheet1.Cells["A" + intRow.ToString()].Value = dtOrderScheduleDynamics.Rows[i]["value1"].ToString().ToUpper();
                        //    wsSheet1.Cells["B" + intRow.ToString()].Value = dtOrderScheduleDynamics.Rows[i]["value2"].ToString().ToUpper();
                        //    wsSheet1.Cells["C" + intRow.ToString()].Value = dtOrderScheduleDynamics.Rows[i]["value3"].ToString().ToUpper();
                        //    wsSheet1.Cells["D" + intRow.ToString()].Value = dtOrderScheduleDynamics.Rows[i]["value4"].ToString().ToUpper();
                        //    wsSheet1.Cells["E" + intRow.ToString()].Value = dtOrderScheduleDynamics.Rows[i]["value5"].ToString().ToUpper();
                        //    wsSheet1.Cells["F" + intRow.ToString()].Value = dtOrderScheduleDynamics.Rows[i]["value6"].ToString().ToUpper();
                        //    wsSheet1.Cells["G" + intRow.ToString()].Value = dtOrderScheduleDynamics.Rows[i]["value7"].ToString().ToUpper();
                        //    wsSheet1.Cells["H" + intRow.ToString()].Value = dtOrderScheduleDynamics.Rows[i]["value8"].ToString().ToUpper();
                        //    wsSheet1.Cells["I" + intRow.ToString()].Value = dtOrderScheduleDynamics.Rows[i]["value9"].ToString().ToUpper();
                        //    wsSheet1.Cells["J" + intRow.ToString()].Value = dtOrderScheduleDynamics.Rows[i]["value10"].ToString().ToUpper();
                        //    intRow++;
                        //}


                        Rng = wsSheet1.Cells[intScheduleStartRow, intScheduleStartColumn, intRow, intScheduleEndColumn];
                        Rng.Style.Font.Size = 9;
                        Rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Rng.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        wsSheet1.Protection.IsProtected = false;
                        wsSheet1.Protection.AllowSelectLockedCells = false;
                        //ExcelPkg.SaveAs(new FileInfo("~/" + ClsGV.strFolderTempFiles + "\\PricingTemplate.xlsx"));
                        ExcelPkg.SaveAs(new FileInfo(HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderTempFiles + "\\" + strOutputExcelFileName)));

                        strFileName = strOutputExcelFileName;

                        //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                        //response.ClearContent();
                        //response.Clear();
                        //response.ContentType = "application/vnd.ms-excel";
                        //response.AddHeader("Content-Disposition", "attachment; filename=" + strExcelFileName + ";");
                        //response.TransmitFile("~/" + ClsGV.strFolderTempFiles + "\\PricingTemplate.xlsx");
                        //response.Flush();
                        //response.End();
                    }
                }

            }

            return strFileName;

        }


        #region Cutsheet
        public static void GeneralExcelCutsheet(ClsContElements _objCont, ClsID.enmOutputType _enmOutputType)
        {
            //DataTable dtJobs = _dtJob;

            int intUAL = _objCont.objCLoggedUser.intUAL;

            if (_objCont.objCJobInfo != null)
            {
                DataTable dtProducts = new DataTable();
                DataTable dtOptions = new DataTable();
                DataTable dtCustomOptions = new DataTable();

                //string strExcelFileName = "QuotesInternal_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";
                //strExcelFileName = "FreshAirOutputs_" + ((ClsProjectInfo)_objCont.objCJobInfo).get_intJobID().ToString() + ".xlsx";
                strOutputExcelFileName = _objCont.objCJobInfo.strCompanyName + " - " + _objCont.objCJobInfo.strJobName + " - " + _objCont.objCGeneral.strTag;
                strOutputExcelFileName += _enmOutputType == ClsID.enmOutputType.Selection ? " - Oxygen8 Selection.xlsx" : " - Oxygen8 Submittal.xlsx";


                DataTable dtTemp = new DataTable();
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");

                ExcelPackage ExcelPkg = new ExcelPackage();

                string strTemplateExcelFileName = _enmOutputType == ClsID.enmOutputType.Selection ? ClsGV.strExcelSelection : ClsGV.strExcelSubmittal;

                byte[] file = File.ReadAllBytes(strExecutablePath + "\\" + strTemplateExcelFileName);
                using (MemoryStream ms = new MemoryStream(file))

                using (ExcelPkg = new ExcelPackage(ms))
                {
                    if (ExcelPkg.Workbook.Worksheets.Count == 0)
                    {
                        string strError = "Your Excel file does not contain any work sheets";
                    }
                    else
                    {
                        ExcelWorkbook workbook = ExcelPkg.Workbook;
                        ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets["UNIT_1"];
                        //////int intNewSheetNo = 2;

                        //////for (int i = 0; i < dtJobs.Rows.Count - 1; i++)
                        //////{
                        //////    workbook.Worksheets.Add("J" + intNewSheetNo.ToString(), wsSheet1);
                        //////    intNewSheetNo++;
                        //////}

                        //////for (int i = 0; i < dtJobs.Rows.Count; i++)
                        //////{

                        //////var idx = wsSheet1.Cells["1:1"].First(c => c.Value.ToString() == "job_nbr").Start.Column;

                        //////wsSheet1.Column(idx).Style.Numberformat.Format = "mm-dd-yy";

                        //string strHeaderImage = _objCont.objCGeneral.get_intUnitModelID() > 0 ? "Images/img_header_" + _objCont.objCGeneral.get_strUnitModelValue().ToLower() + ".jpg" : "Images/img_header.jpg";


                        //using (System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(strHeaderImage)))
                        //{
                        //    var excelImage = wsSheet1.Drawings.AddPicture("Header", image);
                        //    excelImage.SetSize(1140, 60);
                        //    excelImage.SetPosition(0, 0, 1, 0);
                        //}

                        //var wb = ExcelPkg.Workbook; //Not workSHEET
                        workbook.Names["job_name"].Value = _objCont.objCJobInfo.strJobName;
                        //workbook.Names["job_number"].Value = (_objCont.objCJobInfo.get_intJobID() + 10000).ToString();
                        workbook.Names["job_revision_no"].Value = "Revision #: " + _objCont.objCJobInfo.intRevisionNo;
                        workbook.Names["job_created_date"].Value = _objCont.objCJobInfo.strCreatedDate;
                        workbook.Names["job_revised_date"].Value = _objCont.objCJobInfo.strRevisedDate;
                        //workbook.Names["company_name"].Value = _objCont.objCJobInfo.strCompanyName != "" ? _objCont.objCJobInfo.strCompanyName : _objCont.objCJobInfo.strRepName;
                        //workbook.Names["contact_name"].Value = _objCont.objCJobInfo.strContactName != "" ? _objCont.objCJobInfo.strContactName : _objCont.objCJobInfo.get_strRepContactName();
                        workbook.Names["company_name"].Value = _objCont.objCJobInfo.strCompanyName;
                        workbook.Names["contact_name"].Value = _objCont.objCJobInfo.strContactName;


                        //workbook.Names["comment_line_1"].Value = "";
                        //workbook.Names["comment_line_2"].Value = "";


                        #region Unit Details
                        if (_objCont.objCGeneral != null)
                        {
                            workbook.Names["unit_tag"].Value = _objCont.objCGeneral.strTag;
                            workbook.Names["unit_model"].Value = _objCont.objCGeneral.strUnitModel;
                            //workbook.Names["unit_dimensions"].Value = _objCont.objCGeneral.get_strUnitCabinetDim();
                            workbook.Names["unit_qty"].Value = _objCont.objCGeneral.intQty;
                            workbook.Names["unit_location"].Value = _objCont.objCGeneral.dsSavedUnitItems.Tables[ClsDBT.strSelGeneralLocation].Rows[0]["items"].ToString();
                            workbook.Names["unit_orientation"].Value = _objCont.objCGeneral.dsSavedUnitItems.Tables[ClsDBT.strSelGeneralOrientation].Rows[0]["items"].ToString();
                            workbook.Names["controls_preference"].Value = _objCont.objCGeneral.strControlsPre;
                            //workbook.Names["unit_voltage"].Value = _objCont.objCGeneral.get_strVoltage();


                            if (_objCont.objCGeneral.intUnitTypeID == ClsID.intUnitTypeHRV_ID || _objCont.objCGeneral.intUnitTypeID == ClsID.intUnitTypeERV_ID)
                            {
                                workbook.Names["esp"].Value = _objCont.objCAirFlowData.get_dblSupplyAirESP().ToString() + " / " + _objCont.objCAirFlowData.get_dblExhaustAirESP();
                                workbook.Names["filters"].Value = _objCont.objCOA_Filter.get_strModel() + " / " + _objCont.objCRA_Filter.get_strModel();
                            }
                            else if (_objCont.objCGeneral.intUnitTypeID == ClsID.intUnitTypeAHU_ID)
                            {
                                workbook.Names["esp"].Value = _objCont.objCAirFlowData.get_dblSupplyAirESP().ToString();
                                workbook.Names["filters"].Value = _objCont.objCOA_Filter.get_strModel();
                            }
                        }
                        else
                        {
                            //int intRow = workbook.Names["preheat_hwc_model"].Rows.ToString();
                        }
                        #endregion


                        #region Elec Requirements
                        if (_objCont.objCGeneral != null)
                        {
                            DataRow drUnitElecData = _objCont.objCGeneral.dtUnitElectricalData.Rows[0];
                            //DataRow drUnitVoltageData = _objCont.objCGeneral.dtUnitVoltageData.Rows[0];

                            //workbook.Names["unit_voltage"].Value = drUnitVoltageData["items"].ToString();
                            //workbook.Names["unit_voltage_range"].Value = drUnitVoltageData["voltage_range"].ToString();
                            workbook.Names["unit_voltage"].Value = _objCont.objCGeneral.strVoltage;
                            workbook.Names["unit_voltage_range"].Value = _objCont.objCGeneral.strVoltageRange;

                            workbook.Names["unit_elec_data_fla"].Value = _objCont.objCGeneral.dtUnitElectricalData.Rows[0]["fla"].ToString();
                            workbook.Names["unit_elec_data_mca"].Value = _objCont.objCGeneral.dtUnitElectricalData.Rows[0]["mca"].ToString();
                            //workbook.Names["unit_elec_data_mropd"].Value = _objCont.objCGeneral.get_dtUnitElectricData().Rows[0]["mropd"].ToString();
                            workbook.Names["unit_elec_data_recommmen_fuse"].Value = _objCont.objCGeneral.dtUnitElectricalData.Rows[0]["recom_fuse"].ToString();

                            if (_objCont.objCPreheatElecHeater != null)
                            {
                                workbook.Names["elec_req_preheat_elec_heater_std_coil"].Value = _objCont.objCPreheatElecHeater.objElecHeaterIO.intStandardCoilNo.ToString();
                                workbook.Names["elec_req_preheat_elec_heater_voltage"].Value = _objCont.objCPreheatElecHeater.objElecHeaterIO.strVoltage;
                                workbook.Names["elec_req_preheat_elec_heater_voltage_range"].Value = _objCont.objCPreheatElecHeater.objElecHeaterIO.strVoltageRange;
                                workbook.Names["elec_req_preheat_elec_heater_fla"].Value = Math.Round(_objCont.objCPreheatElecHeater.objElecHeaterIO.dblFLA, 1);
                                workbook.Names["elec_req_preheat_elec_heater_mca"].Value = Math.Round(_objCont.objCPreheatElecHeater.objElecHeaterIO.dblMCA, 1);
                                workbook.Names["elec_req_preheat_elec_heater_fuse"].Value = _objCont.objCPreheatElecHeater.objElecHeaterIO.strFuseSize;
                            }


                            if (_objCont.objCHeatingElecHeater != null)
                            {
                                workbook.Names["elec_req_heating_elec_heater_std_coil"].Value = _objCont.objCHeatingElecHeater.objElecHeaterIO.intStandardCoilNo.ToString();
                                workbook.Names["elec_req_heating_elec_heater_voltage"].Value = _objCont.objCHeatingElecHeater.objElecHeaterIO.strVoltage;
                                workbook.Names["elec_req_heating_elec_heater_voltage_range"].Value = _objCont.objCHeatingElecHeater.objElecHeaterIO.strVoltageRange;
                                workbook.Names["elec_req_heating_elec_heater_fla"].Value = Math.Round(_objCont.objCHeatingElecHeater.objElecHeaterIO.dblFLA, 1);
                                workbook.Names["elec_req_heating_elec_heater_mca"].Value = Math.Round(_objCont.objCHeatingElecHeater.objElecHeaterIO.dblMCA, 1);
                                workbook.Names["elec_req_heating_elec_heater_fuse"].Value = _objCont.objCHeatingElecHeater.objElecHeaterIO.strFuseSize;
                            }
                        }
                        else
                        {
                            //int intRow = workbook.Names["preheat_hwc_model"].Rows.ToString();
                        }
                        #endregion
                        //workbook.Names["preheat_elec_heater_fla"].Value = Math.Round(_objCont.objCPreheatElecHeater.objElecHeaterIO.dblFLA, 1);



                        #region Preheat Elec Heter
                        if (_objCont.objCPreheatElecHeater != null)
                        {
                            workbook.Names["preheat_elec_heater_cfm"].Value = _objCont.objCPreheatElecHeater.objElecHeaterIO.intAirFlow;
                            workbook.Names["preheat_elec_heater_voltage"].Value = _objCont.objCPreheatElecHeater.objElecHeaterIO.strVoltage;
                            workbook.Names["preheat_elec_heater_kw"].Value = Math.Round(_objCont.objCPreheatElecHeater.objElecHeaterIO.dblKW, 1);
                            workbook.Names["preheat_elec_heater_eat"].Value = Math.Round(_objCont.objCPreheatElecHeater.objElecHeaterIO.dblEntAirDB, 1);
                            workbook.Names["preheat_elec_heater_lat"].Value = Math.Round(_objCont.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB, 1);
                            //workbook.Names["preheat_elec_heater_fla"].Value = Math.Round(_objCont.objCPreheatElecHeater.objElecHeaterIO.dblFLA, 1);
                            workbook.Names["preheat_elec_heater_installation"].Value = _objCont.objCCompItems.objCompOpt.strPreheatElecHeaterInstallation; ;
                        }
                        else
                        {
                            int intStart = workbook.Names["preheat_elec_heater_start"].Start.Row;
                            int intEnd = workbook.Names["preheat_elec_heater_end"].Start.Row;
                            wsSheet1.DeleteRow(intStart, intEnd - intStart + 1, true);
                        }
                        #endregion


                        #region HeatExch CORE
                        if (_objCont.objCHX_CORE != null)
                        {
                            //workbook.Names["hx_fp_core_model"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.strInProductModel;
                            //workbook.Names["hx_fp_core_framed_width"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInFramedWidth;
                            //workbook.Names["hx_fp_core_height"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInHeight;
                            //workbook.Names["hx_fp_core_spacing"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInSpacing;

                            workbook.Names["hx_fp_core_summer_sensible_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutSensibleEffectiveness * 100d, 2);
                            workbook.Names["hx_fp_core_summer_latent_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutLatentEffectiveness * 100d, 2);
                            workbook.Names["hx_fp_core_summer_total_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutTotalEffectiveness * 100d, 2);
                            workbook.Names["hx_fp_core_summer_energy_recov_ratio"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutEnergyRecoveryRatio, 2);
                            workbook.Names["hx_fp_core_summer_total_energy_saved"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutTotalEnergySaved, 0);
                            //workbook.Names["hx_fp_core_summer_moisture_removed"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutMoistureTransfered, 1);
                            //workbook.Names["hx_fp_core_summer_energy_balance"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutTemperatureRatio, 1);
                            //workbook.Names["hx_fp_core_summer_water_balance"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutWaterTransferRatio, 1);

                            workbook.Names["hx_fp_core_winter_sensible_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutSensibleEffectiveness * 100d, 2);
                            workbook.Names["hx_fp_core_winter_latent_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutLatentEffectiveness * 100d, 2);
                            workbook.Names["hx_fp_core_winter_total_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutTotalEffectiveness * 100d, 2);
                            workbook.Names["hx_fp_core_winter_energy_recov_ratio"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutEnergyRecoveryRatio, 2);
                            workbook.Names["hx_fp_core_winter_total_energy_saved"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutTotalEnergySaved, 0);
                            //workbook.Names["hx_fp_core_winter_moisture_removed"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutMoistureTransfered, 1);
                            //workbook.Names["hx_fp_core_winter_energy_balance"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutTemperatureRatio, 1);
                            //workbook.Names["hx_fp_core_winter_water_balance"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutWaterTransferRatio, 1);

                            //
                            workbook.Names["hx_fp_core_summer_ra_ent_airflow"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInReturnAirCFM, 0);
                            workbook.Names["hx_fp_core_summer_ra_ent_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInReturnAirDB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInReturnAirWB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInReturnAirRH, 1);
                            //workbook.Names["hx_fp_core_summer_ra_ent_wb"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInReturnAirWB, 1);
                            //workbook.Names["hx_fp_core_summer_ra_ent_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInReturnAirRH, 1);

                            workbook.Names["hx_fp_core_winter_ra_ent_airflow"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInReturnAirCFM, 0);
                            workbook.Names["hx_fp_core_winter_ra_ent_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInReturnAirDB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInReturnAirWB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInReturnAirRH, 1);
                            //workbook.Names["hx_fp_core_winter_ra_ent_wb"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblInReturnAirWB, 1);
                            //workbook.Names["hx_fp_core_winter_ra_ent_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblInReturnAirRH, 1);

                            workbook.Names["hx_fp_core_summer_ra_lvg_airflow"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutExhaustAirCFM, 0);
                            workbook.Names["hx_fp_core_summer_ra_lvg_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutExhaustAirDB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutExhaustAirWB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutExhaustAirRH, 1);
                            //workbook.Names["hx_fp_core_summer_ra_lvg_wb"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutExhaustAirWB, 1);
                            //workbook.Names["hx_fp_core_summer_ra_lvg_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutExhaustAirRH, 1);
                            workbook.Names["hx_fp_core_summer_ra_lvg_cond"].Value = _objCont.objCHX_CORE.objCORE_DLL_IO_Summer.bolOutExhaustAirCondWar == true ? "Yes" : "No"; ;
                            //workbook.Names["hx_fp_core_summer_ra_lvg_vel"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutExhaustAirVel, 0);
                            workbook.Names["hx_fp_core_summer_ra_lvg_pd"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutExhaustAirPD, 2);

                            workbook.Names["hx_fp_core_winter_ra_lvg_airflow"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutExhaustAirCFM, 0);
                            workbook.Names["hx_fp_core_winter_ra_lvg_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutExhaustAirDB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutExhaustAirWB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutExhaustAirRH, 1);
                            //workbook.Names["hx_fp_core_winter_ra_lvg_wb"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutExhaustAirWB, 1);
                            //workbook.Names["hx_fp_core_winter_ra_lvg_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutExhaustAirRH, 1);
                            workbook.Names["hx_fp_core_winter_ra_lvg_cond"].Value = _objCont.objCHX_CORE.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar == true ? "Yes" : "No"; ; ;
                            //workbook.Names["hx_fp_core_winter_ra_lvg_vel"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutExhaustAirVel, 0);
                            workbook.Names["hx_fp_core_winter_ra_lvg_pd"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutExhaustAirPD, 2);

                            //
                            workbook.Names["hx_fp_core_summer_sa_ent_airflow"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInOutsideAirCFM, 0);
                            workbook.Names["hx_fp_core_summer_sa_ent_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInOutsideAirDB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInOutsideAirWB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInOutsideAirRH, 1);
                            //workbook.Names["hx_fp_core_summer_sa_ent_wb"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInOutsideAirWB, 1);
                            //workbook.Names["hx_fp_core_summer_sa_ent_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInOutsideAirRH, 1);

                            workbook.Names["hx_fp_core_winter_sa_ent_airflow"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirCFM, 0);
                            workbook.Names["hx_fp_core_winter_sa_ent_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirDB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirWB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirRH, 1);
                            //workbook.Names["hx_fp_core_winter_sa_ent_wb"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblInOutsideAirWB, 1);
                            //workbook.Names["hx_fp_core_winter_sa_ent_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblInOutsideAirRH, 1);

                            workbook.Names["hx_fp_core_summer_sa_lvg_airflow"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutSupplyAirCFM, 0);
                            workbook.Names["hx_fp_core_summer_sa_lvg_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutSupplyAirDB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutSupplyAirWB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutSupplyAirRH, 1);
                            //workbook.Names["hx_fp_core_summer_sa_lvg_wb"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutSupplyAirWB, 1);
                            //workbook.Names["hx_fp_core_summer_sa_lvg_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutSupplyAirRH, 1);
                            workbook.Names["hx_fp_core_summer_sa_lvg_cond"].Value = _objCont.objCHX_CORE.objCORE_DLL_IO_Summer.bolOutSupplyAirCondWarning == true ? "Yes" : "No"; ;
                            //workbook.Names["hx_fp_core_summer_sa_lvg_vel"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutSupplyAirVel, 0);
                            workbook.Names["hx_fp_core_summer_sa_lvg_pd"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutSupplyAirPD, 2);

                            workbook.Names["hx_fp_core_winter_sa_lvg_airflow"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutSupplyAirCFM, 0);
                            workbook.Names["hx_fp_core_winter_sa_lvg_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutSupplyAirDB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutSupplyAirWB, 1) + " / " +
                                                                                    Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutSupplyAirRH, 1);
                            //workbook.Names["hx_fp_core_winter_sa_lvg_wb"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutSupplyAirWB, 1);
                            //workbook.Names["hx_fp_core_winter_sa_lvg_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutSupplyAirRH, 1);
                            workbook.Names["hx_fp_core_winter_sa_lvg_cond"].Value = _objCont.objCHX_CORE.objCORE_DLL_IO_Winter.bolOutSupplyAirCondWarning == true ? "Yes" : "No"; ; ;
                            //workbook.Names["hx_fp_core_winter_sa_lvg_vel"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutSupplyAirVel, 0);
                            workbook.Names["hx_fp_core_winter_sa_lvg_pd"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutSupplyAirPD, 2);

                            if (_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar)
                            {
                                workbook.Names["hx_fp_core_cond_warning"].Value = "At current design conditions the ERV Core is at risk of condensing and freezing. The unit does not contain a drain pan and pre-heat is recommended. Any damage that may occur to the unit due to condensation or freezing will not be covered under warranty.";
                            }


                            if (_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutTotalEffectiveness * 100d < 50d || _objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutTotalEffectiveness * 100d < 50d)
                            {
                                workbook.Names["hx_fp_core_effect_warning"].Value = "Total effectiveness less than 50%. To comply with ASHRAE 90.1-2010 the energy recovery system must have a total effectiveness of greater than or equal to 50%.";
                            }
                        }
                        else
                        {
                            int intStart = workbook.Names["hx_fp_start"].Start.Row;
                            int intEnd = workbook.Names["hx_fp_end"].Start.Row;
                            wsSheet1.DeleteRow(intStart, intEnd - intStart + 1, true);
                        }
                        #endregion



                        #region Heating Elec Heter
                        if (_objCont.objCHeatingElecHeater != null)
                        {
                            workbook.Names["heating_elec_heater_cfm"].Value = _objCont.objCHeatingElecHeater.objElecHeaterIO.intAirFlow;
                            workbook.Names["heating_elec_heater_voltage"].Value = _objCont.objCHeatingElecHeater.objElecHeaterIO.strVoltage;
                            workbook.Names["heating_elec_heater_kw"].Value = Math.Round(_objCont.objCHeatingElecHeater.objElecHeaterIO.dblKW, 1);
                            workbook.Names["heating_elec_heater_eat"].Value = Math.Round(_objCont.objCHeatingElecHeater.objElecHeaterIO.dblEntAirDB, 1);
                            workbook.Names["heating_elec_heater_lat"].Value = Math.Round(_objCont.objCHeatingElecHeater.objElecHeaterIO.dblLvgAirDB, 1);
                            //workbook.Names["heating_elec_heater_fla"].Value = Math.Round(_objCont.objCHeatingElecHeater.objElecHeaterIO.dblFLA, 1);
                            workbook.Names["heating_elec_heater_installation"].Value = _objCont.objCCompItems.objCompOpt.strHeatElecHeaterInstallation; ;
                        }
                        else
                        {
                            int intStart = workbook.Names["heating_elec_heater_start"].Start.Row;
                            int intEnd = workbook.Names["heating_elec_heater_end"].Start.Row;
                            wsSheet1.DeleteRow(intStart, intEnd - intStart + 1, true);
                        }
                        #endregion


                        ////Footer
                        //using (System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("Images/img_footer.jpg")))
                        //{
                        //    int intEF_GraphRow = workbook.Names["footer_image"].Start.Row - 1;
                        //    int intEF_GraphColumn = workbook.Names["footer_image"].Start.Column - 1;

                        //    var excelImage = wsSheet1.Drawings.AddPicture("Footer", image);
                        //    excelImage.SetSize(1140, 60);
                        //    excelImage.SetPosition(intEF_GraphRow, 0, intEF_GraphColumn, 0);
                        //}


                        //////By range address
                        ////if (_objGeneral.get_strFilterLine_2() == "")
                        ////{
                        ////    workbook.Names["filter_line_2"].Value = "";
                        ////    wsSheet1.Cells["C71:F72"].Merge = true;
                        ////}
                        ////else
                        ////{
                        ////    workbook.Names["filter_line_2"].Value = _objGeneral.get_strFilterLine_2();
                        ////}


                        //////By indexes
                        ////worksheet.Cells[1, 1, 5, 2].Merge = true;

                        //Bitmap image = new Bitmap(HttpContext.Current.Server.MapPath("~/Images\\Test.png"));
                        //var excelImage = wsSheet1.Drawings.AddPicture("My Logo", image);
                        //excelImage.From.Column = 1;
                        //excelImage.From.Row = 31;
                        //excelImage.To.Column = 15;
                        //excelImage.To.Row = 65;
                        ////excelImage.SetSize(100, 100);

                        //////add the image to row 20, column E
                        ////excelImage.SetPosition(20, 0, 5, 0);


                        wsSheet1.Protection.IsProtected = false;
                        wsSheet1.Protection.AllowSelectLockedCells = false;
                        ExcelPkg.SaveAs(new FileInfo(HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderTempFiles + "\\" + strOutputExcelFileName)));

                        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                        response.ClearContent();
                        response.Clear();
                        response.ContentType = "application/vnd.ms-excel";
                        response.AddHeader("Content-Disposition", "attachment; filename=\"" + strOutputExcelFileName + "\";");
                        response.TransmitFile(HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderTempFiles + "\\" + strOutputExcelFileName));
                        response.Flush();
                        response.End();
                    }
                }
            }
            else
            {
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", ClsAlert.get_sbMessage("No jobs available").ToString());
            }
        }
        #endregion


        #region Schedule Individual Unit
        public static void GeneralExcelSchedule(ClsContElements _objCont)
        {
            //DataTable dtJobs = _dtJob;
            //DataTable dtJob = ClsDBM.SelectById(ClsDBT.strSavJob, intJobID);

            if (_objCont.objCJobInfo != null)
            {
                DataTable dtProducts = new DataTable();
                DataTable dtOptions = new DataTable();
                DataTable dtCustomOptions = new DataTable();

                //string strExcelFileName = "QuotesInternal_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";
                //strExcelFileName = "FreshAirOutputs_" + ((ClsProjectInfo)_objCont.objCJobInfo).get_intJobID().ToString() + ".xlsx";
                strOutputExcelFileName = _objCont.objCJobInfo.strCompanyName + " - " + _objCont.objCJobInfo.strJobName + " - Oxygen8 Schedule.xlsx";


                DataTable dtTemp = new DataTable();
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");

                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage ExcelPkg = new ExcelPackage();

                byte[] file = File.ReadAllBytes(strExecutablePath + "\\" + ClsGV.strExcelSchedule);
                using (MemoryStream ms = new MemoryStream(file))

                using (ExcelPkg = new ExcelPackage(ms))
                {
                    if (ExcelPkg.Workbook.Worksheets.Count == 0)
                    {
                        string strError = "Your Excel file does not contain any work sheets";
                    }
                    else
                    {
                        ExcelWorkbook workbook = ExcelPkg.Workbook;
                        ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets["SCHEDULE"];
                        //int intNewSheetNo = 2;

                        //for (int i = 0; i < dtJobs.Rows.Count - 1; i++)
                        //{
                        //    workbook.Worksheets.Add("J" + intNewSheetNo.ToString(), wsSheet1);
                        //    intNewSheetNo++;
                        //}

                        //for (int i = 0; i < dtJobs.Rows.Count; i++)
                        //{

                        //var idx = wsSheet1.Cells["1:1"].First(c => c.Value.ToString() == "job_nbr").Start.Column;

                        //wsSheet1.Column(idx).Style.Numberformat.Format = "mm-dd-yy";

                        //string strHeaderImage = _objCont.objCGeneral.get_intUnitModelID() > 0 ? "Images/img_header_" + _objCont.objCGeneral.get_strUnitModelValue().ToLower() + ".jpg" : "Images/img_header.jpg";

                        //using (System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(strHeaderImage)))
                        //{
                        //    var excelImage = wsSheet1.Drawings.AddPicture("Header", image);
                        //    excelImage.SetSize(1096, 60);
                        //    excelImage.SetPosition(0, 0, 1, 0);
                        //}

                        //var wb = ExcelPkg.Workbook; //Not workSHEET
                        //workbook.Names["job_name"].Value = _objCont.objCJobInfo.get_strJobName();
                        ////workbook.Names["job_number"].Value = (_objCont.objCJobInfo.get_intJobID() + 10000).ToString();
                        //workbook.Names["job_revision_no"].Value = "Revision #: " + _objCont.objCJobInfo.get_intRevisionNo();
                        //workbook.Names["job_created_date"].Value = _objCont.objCJobInfo.get_strCreatedDate();
                        //workbook.Names["job_revised_date"].Value = _objCont.objCJobInfo.get_strRevisedDate();
                        //workbook.Names["company_name"].Value = _objCont.objCJobInfo.get_strCompanyName() != "" ? _objCont.objCJobInfo.get_strCompanyName() : _objCont.objCJobInfo.get_strRepName();
                        //workbook.Names["contact_name"].Value = _objCont.objCJobInfo.get_strContactName() != "" ? _objCont.objCJobInfo.get_strContactName() : _objCont.objCJobInfo.get_strRepContactName();


                        //workbook.Names["comment_line_1"].Value = "";
                        //workbook.Names["comment_line_2"].Value = "";


                        #region Unit Detail
                        if (_objCont.objCGeneral != null)
                        {
                            //int intEF_GraphRow = workbook.Names["footer_image"].Start.Address - 1;
                            //int intEF_GraphColumn = workbook.Names["footer_image"].Start.Column - 1;

                            //workbook.Names["unit_type"].Value = _objCont.objCGeneral.get_strUnitTypeDesc();
                            workbook.Names["unit_tag"].Value = _objCont.objCGeneral.strTag;
                            workbook.Names["unit_model"].Value = _objCont.objCGeneral.strUnitModelValue;
                            //workbook.Names["unit_length"].Value = _objCont.objCGeneral.get_dblUnitLength();
                            //workbook.Names["unit_width"].Value = _objCont.objCGeneral.get_dblUnitWidth();
                            //workbook.Names["unit_height"].Value = _objCont.objCGeneral.get_dblUnitHeight();
                            //workbook.Names["unit_qty"].Value = _objCont.objCGeneral.get_intQty();
                            //workbook.Names["unit_orientation"].Value = _objCont.objCGeneral.get_strOrientation();
                            workbook.Names["unit_installation"].Value = _objCont.objCGeneral.strLocation;
                            //workbook.Names["controls_preference"].Value = _objCont.objCGeneral.get_strControlsPreference();
                            workbook.Names["unit_voltage"].Value = _objCont.objCGeneral.strVoltage;


                            if (_objCont.objCGeneral.intUnitTypeID == ClsID.intUnitTypeHRV_ID || _objCont.objCGeneral.intUnitTypeID == ClsID.intUnitTypeERV_ID)
                            {
                                workbook.Names["supply_air_esp"].Value = _objCont.objCAirFlowData.get_dblSupplyAirESP();
                                workbook.Names["exhaust_air_esp"].Value = _objCont.objCAirFlowData.get_dblExhaustAirESP();

                                //workbook.Names["filters"].Value = _objCont.objCOA_Filter.get_strModel() + " / " + _objCont.objCRA_Filter.get_strModel();
                            }
                            else if (_objCont.objCGeneral.intUnitTypeID == ClsID.intUnitTypeAHU_ID)
                            {
                                workbook.Names["supply_air_esp"].Value = _objCont.objCAirFlowData.get_dblSupplyAirESP().ToString();
                                //workbook.Names["filters"].Value = _objCont.objCOA_Filter.get_strModel();
                            }

                            workbook.Names["elec_data_mca"].Value = Convert.ToDouble(_objCont.objCGeneral.dtUnitElectricalData.Rows[0]["mca"]).ToString("0.00");
                            workbook.Names["elec_data_mropd"].Value = Convert.ToDouble(_objCont.objCGeneral.dtUnitElectricalData.Rows[0]["mropd"]).ToString("0.00");
                            workbook.Names["elec_data_recommmen_fuse"].Value = _objCont.objCGeneral.dtUnitElectricalData.Rows[0]["recom_fuse"].ToString();
                        }
                        else
                        {
                            //int intRow = workbook.Names["preheat_hwc_model"].Rows.ToString();
                        }
                        #endregion


                        #region Preheat Elec Heter
                        if (_objCont.objCPreheatElecHeater != null)
                        {
                            //workbook.Names["preheat_elec_heater_cfm"].Value = _objCont.objCPreheatElecHeater.objElecHeaterIO.intAirFlow;
                            workbook.Names["preheat_elec_heater_control_type"].Value = "SCR";
                            workbook.Names["preheat_elec_heater_voltage"].Value = _objCont.objCPreheatElecHeater.objElecHeaterIO.strVoltage;
                            workbook.Names["preheat_elec_heater_kw"].Value = Math.Round(_objCont.objCPreheatElecHeater.objElecHeaterIO.dblKW, 1);
                            workbook.Names["preheat_elec_heater_eat"].Value = Math.Round(_objCont.objCPreheatElecHeater.objElecHeaterIO.dblEntAirDB, 1);
                            workbook.Names["preheat_elec_heater_lat"].Value = Math.Round(_objCont.objCPreheatElecHeater.objElecHeaterIO.dblLvgAirDB, 1);
                            //workbook.Names["preheat_elec_heater_fla"].Value = Math.Round(_objCont.objCPreheatElecHeater.objElecHeaterIO.dblFLA, 1);
                            workbook.Names["descriptions"].Value = "Electric heat requires separate power supply.";
                        }
                        #endregion


                        #region HeatExch CORE
                        if (_objCont.objCHX_CORE != null)
                        {
                            //workbook.Names["hx_fp_core_model"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.strInProductModel;
                            //workbook.Names["hx_fp_core_framed_width"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInFramedWidth;
                            //workbook.Names["hx_fp_core_height"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInHeight;
                            //workbook.Names["hx_fp_core_spacing"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInSpacing;

                            workbook.Names["hx_fp_core_summer_sensible_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutSensibleEffectiveness, 1).ToString("0.0");
                            workbook.Names["hx_fp_core_summer_latent_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutLatentEffectiveness, 1).ToString("0.0");
                            workbook.Names["hx_fp_core_summer_total_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutTotalEffectiveness * 100d, 1).ToString("0.0");
                            //workbook.Names["hx_fp_core_summer_total_energy_saved"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutTotalEnergySaved, 0);
                            //workbook.Names["hx_fp_core_summer_energy_recov_ratio"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.ene;
                            //workbook.Names["hx_fp_core_summer_moisture_removed"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutMoistureTransfered, 1);
                            //workbook.Names["hx_fp_core_summer_energy_balance"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutTemperatureRatio, 1);
                            //workbook.Names["hx_fp_core_summer_water_balance"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutWaterTransferRatio, 1);

                            workbook.Names["hx_fp_core_winter_sensible_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutSensibleEffectiveness, 1).ToString("0.0");
                            workbook.Names["hx_fp_core_winter_latent_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutLatentEffectiveness, 1).ToString("0.0");
                            workbook.Names["hx_fp_core_winter_total_effect"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutTotalEffectiveness * 100d, 1).ToString("0.0");
                            //workbook.Names["hx_fp_core_winter_total_energy_saved"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutTotalEnergySaved, 0);
                            //workbook.Names["hx_fp_core_winter_energy_recov_ratio"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInSpacing;
                            //workbook.Names["hx_fp_core_winter_moisture_removed"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutMoistureTransfered, 1);
                            //workbook.Names["hx_fp_core_winter_energy_balance"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutTemperatureRatio, 1);
                            //workbook.Names["hx_fp_core_winter_water_balance"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutWaterTransferRatio, 1);

                            //
                            //workbook.Names["hx_fp_core_summer_ra_ent_airflow"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInReturnAirCFM, 0);
                            workbook.Names["hx_fp_core_summer_ra_ent_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInReturnAirDB, 1);
                            workbook.Names["hx_fp_core_summer_ra_ent_wb"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInReturnAirWB, 1);
                            //workbook.Names["hx_fp_core_summer_ra_ent_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInReturnAirRH, 1);

                            //workbook.Names["hx_fp_core_winter_ra_ent_airflow"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblInReturnAirCFM, 0);
                            workbook.Names["hx_fp_core_winter_ra_ent_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInReturnAirDB, 1);
                            workbook.Names["hx_fp_core_winter_ra_ent_wb"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInReturnAirWB, 1);
                            //workbook.Names["hx_fp_core_winter_ra_ent_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblInReturnAirRH, 1);

                            //workbook.Names["hx_fp_core_summer_ra_lvg_airflow"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutExhaustAirCFM, 0);
                            //workbook.Names["hx_fp_core_summer_ra_lvg_db"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutExhaustAirDB, 1);
                            //workbook.Names["hx_fp_core_summer_ra_lvg_wb"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutExhaustAirWB, 1);
                            //workbook.Names["hx_fp_core_summer_ra_lvg_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutExhaustAirRH, 1);
                            //workbook.Names["hx_fp_core_summer_ra_lvg_cond"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.bolOutExhaustAirCondWar == true ? "Yes" : "No"; ;
                            //workbook.Names["hx_fp_core_summer_ra_lvg_vel"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutExhaustAirVel, 0);
                            //workbook.Names["hx_fp_core_summer_ra_lvg_pd"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutExhaustAirPD, 1);

                            //workbook.Names["hx_fp_core_winter_ra_lvg_airflow"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutExhaustAirCFM, 0);
                            //workbook.Names["hx_fp_core_winter_ra_lvg_db"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutExhaustAirDB, 1);
                            //workbook.Names["hx_fp_core_winter_ra_lvg_wb"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutExhaustAirWB, 1);
                            //workbook.Names["hx_fp_core_winter_ra_lvg_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutExhaustAirRH, 1);
                            //workbook.Names["hx_fp_core_winter_ra_lvg_cond"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar == true ? "Yes" : "No"; ; ;
                            //workbook.Names["hx_fp_core_winter_ra_lvg_vel"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutExhaustAirVel, 0);
                            //workbook.Names["hx_fp_core_winter_ra_lvg_pd"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutExhaustAirPD, 1);

                            //
                            //workbook.Names["hx_fp_core_summer_sa_ent_airflow"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInOutsideAirCFM, 0);
                            workbook.Names["hx_fp_core_summer_sa_ent_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInOutsideAirDB, 1);
                            workbook.Names["hx_fp_core_summer_sa_ent_wb"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblInOutsideAirWB, 1);
                            //workbook.Names["hx_fp_core_summer_sa_ent_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblInOutsideAirRH, 1);

                            //workbook.Names["hx_fp_core_winter_sa_ent_airflow"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblInOutsideAirCFM, 0);
                            workbook.Names["hx_fp_core_winter_sa_ent_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirDB, 1);
                            workbook.Names["hx_fp_core_winter_sa_ent_wb"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblInOutsideAirWB, 1);
                            //workbook.Names["hx_fp_core_winter_sa_ent_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblInOutsideAirRH, 1);

                            //workbook.Names["hx_fp_core_summer_sa_lvg_airflow"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutSupplyAirCFM, 0);
                            workbook.Names["hx_fp_core_summer_sa_lvg_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutSupplyAirDB, 1);
                            workbook.Names["hx_fp_core_summer_sa_lvg_wb"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Summer.dblOutSupplyAirWB, 1);
                            //workbook.Names["hx_fp_core_summer_sa_lvg_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutSupplyAirRH, 1);
                            //workbook.Names["hx_fp_core_summer_sa_lvg_cond"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.bolOutSupplyAirCondWarning == true ? "Yes" : "No"; ;
                            //workbook.Names["hx_fp_core_summer_sa_lvg_vel"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutSupplyAirVel, 0);
                            //workbook.Names["hx_fp_core_summer_sa_lvg_pd"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutSupplyAirPD, 1);

                            //workbook.Names["hx_fp_core_winter_sa_lvg_airflow"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutSupplyAirCFM, 0);
                            workbook.Names["hx_fp_core_winter_sa_lvg_db"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutSupplyAirDB, 1);
                            workbook.Names["hx_fp_core_winter_sa_lvg_wb"].Value = Math.Round(_objCont.objCHX_CORE.objCORE_DLL_IO_Winter.dblOutSupplyAirWB, 1);
                            //workbook.Names["hx_fp_core_winter_sa_lvg_rh"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutSupplyAirRH, 1);
                            //workbook.Names["hx_fp_core_winter_sa_lvg_cond"].Value = _objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.bolOutSupplyAirCondWarning == true ? "Yes" : "No"; ; ;
                            //workbook.Names["hx_fp_core_winter_sa_lvg_vel"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutSupplyAirVel, 0);
                            //workbook.Names["hx_fp_core_winter_sa_lvg_pd"].Value = Math.Round(_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutSupplyAirPD, 1);

                            //if (_objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.bolOutExhaustAirCondWar)
                            //{
                            //    workbook.Names["hx_fp_core_cond_warning"].Value = "At current design conditions the ERV Core is at risk of condensing and freezing. The unit does not contain a drain pan and pre-heat is recommended. Any damage that may occur to the unit due to condensation or freezing will not be covered under warranty.";
                            //}


                            //if (_objCont.objCHeatExchCORE.objCORE_DLL_IO_Summer.dblOutTotalEffectiveness * 100d < 50d || _objCont.objCHeatExchCORE.objCORE_DLL_IO_Winter.dblOutTotalEffectiveness * 100d < 50d)
                            //{
                            //    workbook.Names["hx_fp_core_effect_warning"].Value = "Total effectiveness less than 50%. To comply with ASHRAE 90.1-2010 the energy recovery system must have a total effectiveness of greater than or equal to 50%.";
                            //}
                        }
                        #endregion


                        #region Heating Elec Heter
                        if (_objCont.objCHeatingElecHeater != null)
                        {
                            //workbook.Names["heating_elec_heater_cfm"].Value = _objCont.objCHeatingElecHeater.objElecHeaterIO.intAirFlow;
                            workbook.Names["heating_elec_heater_control_type"].Value = "SCR";
                            workbook.Names["heating_elec_heater_voltage"].Value = _objCont.objCHeatingElecHeater.objElecHeaterIO.strVoltage;
                            workbook.Names["heating_elec_heater_kw"].Value = Math.Round(_objCont.objCHeatingElecHeater.objElecHeaterIO.dblKW, 1);
                            workbook.Names["heating_elec_heater_eat"].Value = Math.Round(_objCont.objCHeatingElecHeater.objElecHeaterIO.dblEntAirDB, 1);
                            workbook.Names["heating_elec_heater_lat"].Value = Math.Round(_objCont.objCHeatingElecHeater.objElecHeaterIO.dblLvgAirDB, 1);
                            //workbook.Names["heating_elec_heater_fla"].Value = Math.Round(_objCont.objCHeatingElecHeater.objElecHeaterIO.dblFLA, 1);
                            workbook.Names["descriptions"].Value = "Electric heat requires separate power supply.";
                        }
                        #endregion


                        ////Footer
                        //using (System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("Images/img_footer.jpg")))
                        //{
                        //    int intEF_GraphRow = workbook.Names["footer_image"].Start.Row - 1;
                        //    int intEF_GraphColumn = workbook.Names["footer_image"].Start.Column - 1;

                        //    var excelImage = wsSheet1.Drawings.AddPicture("Footer", image);
                        //    excelImage.SetSize(1096, 60);
                        //    excelImage.SetPosition(intEF_GraphRow, 0, intEF_GraphColumn, 0);
                        //}


                        //////By range address
                        ////if (_objGeneral.get_strFilterLine_2() == "")
                        ////{
                        ////    workbook.Names["filter_line_2"].Value = "";
                        ////    wsSheet1.Cells["C71:F72"].Merge = true;
                        ////}
                        ////else
                        ////{
                        ////    workbook.Names["filter_line_2"].Value = _objGeneral.get_strFilterLine_2();
                        ////}


                        //////By indexes
                        ////worksheet.Cells[1, 1, 5, 2].Merge = true;

                        //Bitmap image = new Bitmap(HttpContext.Current.Server.MapPath("~/Images\\Test.png"));
                        //var excelImage = wsSheet1.Drawings.AddPicture("My Logo", image);
                        //excelImage.From.Column = 1;
                        //excelImage.From.Row = 31;
                        //excelImage.To.Column = 15;
                        //excelImage.To.Row = 65;
                        ////excelImage.SetSize(100, 100);

                        //////add the image to row 20, column E
                        ////excelImage.SetPosition(20, 0, 5, 0);


                        wsSheet1.Protection.IsProtected = false;
                        wsSheet1.Protection.AllowSelectLockedCells = false;
                        ExcelPkg.SaveAs(new FileInfo(HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderSubmittal_Schedules + "/" + _objCont.objCJobInfo.intJobID.ToString() + "_" + _objCont.objCGeneral.intUnitNo.ToString() + ".xlsx")));

                        //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                        //response.ClearContent();
                        //response.Clear();
                        //response.ContentType = "application/vnd.ms-excel";
                        //response.AddHeader("Content-Disposition", "attachment; filename=" + strExcelFileName + ";");
                        //response.TransmitFile(HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderTempFiles + "\\" + strExcelFileName));
                        //response.Flush();
                        //response.End();
                    }
                }
            }
            else
            {
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", ClsAlert.get_sbMessage("No jobs available").ToString());
            }
        }
        #endregion


        #region ScheduleFinal
        public static void GeneralExcelScheduleFinal(int _intJobID)
        {
            //DataTable dtJobs = _dtJob;
            DataTable dtJob = ClsDB.get_dtByID(ClsDBT.strSavJob, _intJobID);
            DataTable dtUnitList = ClsDB.get_dtByID(ClsDBT.strSavGeneral, "job_id", _intJobID);
            bool bolPreheatElecHeat = false;
            bool bolPreheatHWC = false;
            bool bolHeatExch = false;
            bool bolCooligCWC = false;
            bool bolCoolingDX = false;
            bool bolHeatingDX = false;
            bool bolHeatingElecHeat = false;
            bool bolHeatingHWC = false;
            bool bolReheatElecHeat = false;
            bool bolReheatHWC = false;
            bool bolReheatHGRC = false;
            bool bolERV_or_DOAS = false;
            //bool bolFC = false;



            if (dtJob.Rows.Count > 0)
            {
                DataTable dtProducts = new DataTable();
                DataTable dtOptions = new DataTable();
                DataTable dtCustomOptions = new DataTable();
                int intNovaQty = 0;
                int intNovaBypassQty = 0;
                int intVentumERV_Qty = 0;
                int intVentumHRV_Qty = 0;
                int intVentumBypassERV_Qty = 0;
                int intVentumBypassHRV_Qty = 0;

                int intVentumLiteERV_Qty = 0;
                int intVentumLiteHRV_Qty = 0;
                int intVentumLiteBypassERV_Qty = 0;
                int intVentumLiteBypassHRV_Qty = 0;


                //string strExcelFileName = "QuotesInternal_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";
                //strExcelFileName = "FreshAirOutputs_" + ((ClsProjectInfo)_objCont.objCJobInfo).get_intJobID().ToString() + ".xlsx";
                strOutputExcelFileName = dtJob.Rows[0]["company_name"].ToString() + " - " + dtJob.Rows[0]["job_name"].ToString() + " - Oxygen8 Schedule.xlsx";


                DataTable dtTemp = new DataTable();
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");
                //int intStartMain = 0;
                //int intEndMain = 0;

                ExcelPackage ExcelPkg = new ExcelPackage();

                byte[] bytScheduleFile = File.ReadAllBytes(strExecutablePath + "\\" + ClsGV.strExcelSchedule);
                using (MemoryStream ms = new MemoryStream(bytScheduleFile))
                using (ExcelPkg = new ExcelPackage(ms))
                {
                    if (ExcelPkg.Workbook.Worksheets.Count == 0)
                    {
                        string strError = "Your Excel file does not contain any worksheets";
                    }
                    else
                    {
                        ExcelWorkbook wbMain = ExcelPkg.Workbook;
                        ExcelWorksheet wsMain = ExcelPkg.Workbook.Worksheets["SCHEDULE"];
                        //int intNewSheetNo = 2;
                        int intStartRow = wbMain.Names["unit_tag"].Start.Row;
                        int intUnitRow = 0;


                        var drUnitListNova = dtUnitList.AsEnumerable().Where(x => (Convert.ToInt32(x["product_type_id"]) == ClsID.intProdTypeNovaID));
                        DataTable dtUnitListNova = drUnitListNova.Any() ? drUnitListNova.CopyToDataTable() : new DataTable();
                        intNovaQty = dtUnitListNova.Rows.Count;

                        DataTable dtUnitListNovaBypass = drUnitListNova.Any() ? drUnitListNova.CopyToDataTable() : new DataTable();
                        var drUnitListNovaBypass = dtUnitListNovaBypass.AsEnumerable().Where(x => (Convert.ToInt32(x["is_bypass"]) == ClsID.intUnitTypeERV_ID));
                        dtUnitListNovaBypass = drUnitListNovaBypass.Any() ? drUnitListNovaBypass.CopyToDataTable() : new DataTable();
                        intNovaBypassQty = dtUnitListNovaBypass.Rows.Count;


                        var drUnitListVentumERV = dtUnitList.AsEnumerable().Where(x => (Convert.ToInt32(x["product_type_id"]) == ClsID.intProdTypeVentumID));
                        DataTable dtUnitListVentumERV = drUnitListVentumERV.Any() ? drUnitListVentumERV.CopyToDataTable() : new DataTable();
                        drUnitListVentumERV = dtUnitListVentumERV.AsEnumerable().Where(x => (Convert.ToInt32(x["unit_type_id"]) == ClsID.intUnitTypeERV_ID));
                        dtUnitListVentumERV = drUnitListVentumERV.Any() ? drUnitListVentumERV.CopyToDataTable() : new DataTable();
                        intVentumERV_Qty = dtUnitListVentumERV.Rows.Count;

                        var drUnitListVentumERV_Bypass = drUnitListVentumERV.AsEnumerable().Where(x => (Convert.ToInt32(x["is_bypass"]) == 1));
                        DataTable dtUnitListVentumERV_Bypass = drUnitListVentumERV_Bypass.Any() ? drUnitListVentumERV_Bypass.CopyToDataTable() : new DataTable();
                        intVentumBypassERV_Qty = dtUnitListVentumERV_Bypass.Rows.Count;


                        var drUnitListVentumHRV = dtUnitList.AsEnumerable().Where(x => (Convert.ToInt32(x["product_type_id"]) == ClsID.intProdTypeVentumID));
                        DataTable dtUnitListVentumHRV = drUnitListVentumHRV.Any() ? drUnitListVentumHRV.CopyToDataTable() : new DataTable();
                        drUnitListVentumHRV = dtUnitListVentumHRV.AsEnumerable().Where(x => (Convert.ToInt32(x["unit_type_id"]) == ClsID.intUnitTypeHRV_ID));
                        dtUnitListVentumHRV = drUnitListVentumHRV.Any() ? drUnitListVentumHRV.CopyToDataTable() : new DataTable();
                        intVentumHRV_Qty = dtUnitListVentumHRV.Rows.Count;

                        var drUnitListVentumHRV_Bypass = drUnitListVentumHRV.AsEnumerable().Where(x => (Convert.ToInt32(x["is_bypass"]) == 1));
                        DataTable dtUnitListVentumHRV_Bypass = drUnitListVentumHRV_Bypass.Any() ? drUnitListVentumHRV_Bypass.CopyToDataTable() : new DataTable();
                        intVentumBypassHRV_Qty = dtUnitListVentumHRV_Bypass.Rows.Count;


                        var drUnitListVentumLiteERV = dtUnitList.AsEnumerable().Where(x => (Convert.ToInt32(x["product_type_id"]) == ClsID.intProdTypeVentumLiteID));
                        DataTable dtUnitListVentumLiteERV = drUnitListVentumLiteERV.Any() ? drUnitListVentumLiteERV.CopyToDataTable() : new DataTable();
                        drUnitListVentumLiteERV = dtUnitListVentumLiteERV.AsEnumerable().Where(x => (Convert.ToInt32(x["unit_type_id"]) == ClsID.intUnitTypeERV_ID));
                        dtUnitListVentumLiteERV = drUnitListVentumLiteERV.Any() ? drUnitListVentumLiteERV.CopyToDataTable() : new DataTable();
                        intVentumLiteERV_Qty = dtUnitListVentumLiteERV.Rows.Count;

                        var drUnitListVentumLiteERV_Bypass = drUnitListVentumLiteERV.AsEnumerable().Where(x => (Convert.ToInt32(x["is_bypass"]) == 1));
                        DataTable dtUnitListVentumLiteERV_Bypass = drUnitListVentumLiteERV_Bypass.Any() ? drUnitListVentumLiteERV_Bypass.CopyToDataTable() : new DataTable();
                        intVentumLiteBypassERV_Qty = dtUnitListVentumLiteERV_Bypass.Rows.Count;


                        var drUnitListVentumLiteHRV = dtUnitList.AsEnumerable().Where(x => (Convert.ToInt32(x["product_type_id"]) == ClsID.intProdTypeVentumLiteID));
                        DataTable dtUnitListVentumLiteHRV = drUnitListVentumLiteHRV.Any() ? drUnitListVentumLiteHRV.CopyToDataTable() : new DataTable();
                        drUnitListVentumLiteHRV = dtUnitListVentumLiteHRV.AsEnumerable().Where(x => (Convert.ToInt32(x["unit_type_id"]) == ClsID.intUnitTypeHRV_ID));
                        dtUnitListVentumLiteHRV = drUnitListVentumLiteHRV.Any() ? drUnitListVentumLiteHRV.CopyToDataTable() : new DataTable();
                        intVentumLiteHRV_Qty = dtUnitListVentumLiteHRV.Rows.Count;

                        var drUnitListVentumLiteHRV_Bypass = drUnitListVentumLiteHRV.AsEnumerable().Where(x => (Convert.ToInt32(x["is_bypass"]) == 1));
                        DataTable dtUnitListVentumLiteHRV_Bypass = drUnitListVentumLiteHRV_Bypass.Any() ? drUnitListVentumLiteHRV_Bypass.CopyToDataTable() : new DataTable();
                        intVentumLiteBypassHRV_Qty = dtUnitListVentumLiteHRV_Bypass.Rows.Count;


                        for (int i = 0; i < dtUnitList.Rows.Count; i++)
                        {
                            //intStartMain = wbMain.Names["schedule_start"].Start.Column;
                            //intEndMain = wbMain.Names["schedule_end"].Start.Column;

                            string strPathAndFile = HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderSubmittal_Schedules + "/" + _intJobID.ToString() + "_" + dtUnitList.Rows[i]["unit_no"].ToString() + ".xlsx");

                            if (System.IO.File.Exists(strPathAndFile))
                            {
                                byte[] bytFile = File.ReadAllBytes(strPathAndFile);

                                ExcelPackage ExcelPkg1 = new ExcelPackage();


                                using (MemoryStream ms1 = new MemoryStream(bytFile))
                                {
                                    using (ExcelPkg1 = new ExcelPackage(ms1))
                                    {
                                        ExcelWorkbook wb1 = ExcelPkg1.Workbook;
                                        ExcelWorksheet ws1 = ExcelPkg1.Workbook.Worksheets["SCHEDULE"];
                                        //int intStart = wb1.Names["schedule_start"].Start.Column;
                                        //int intEnd = wb1.Names["schedule_end"].Start.Column;

                                        if (ExcelPkg1.Workbook.Worksheets.Count == 0)
                                        {
                                            string strError = "Your Excel file does not contain any work sheets";
                                        }
                                        else
                                        {
                                            //for (int j = intStart; j < intEnd; j++)
                                            //{
                                            //    wsMain.Cells[intRow, intStartMain++].Value = ws1.Cells[7, j].Value;
                                            //}

                                            #region Unit Detail
                                            //wbMain.Names["unit_tag"].Value = "";
                                            //wsMain.Cells[wbMain.Names["unit_tag"].Start.Row + intUnitRow, wbMain.Names["unit_tag"].Start.Column].Value = "123";
                                            //wbMain.Names["unit_tag"].Value = wb1.Names["unit_tag"].Value;
                                            //wb1.Names.Add("unit_weight", );


                                            bool bol1 = wb1.Names.ContainsKey("descriptions");
                                            bool bol2 = wbMain.Names.ContainsKey("descriptions");


                                            //if (wb1.Names["unit_weight"] == null)
                                            //{

                                            //}

                                            wsMain.Cells[wbMain.Names["unit_tag"].Start.Row + intUnitRow, wbMain.Names["unit_tag"].Start.Column].Value = wb1.Names["unit_tag"].Value;
                                            wsMain.Cells[wbMain.Names["manufacturer"].Start.Row + intUnitRow, wbMain.Names["manufacturer"].Start.Column].Value = wb1.Names["manufacturer"].Value;
                                            wsMain.Cells[wbMain.Names["unit_model"].Start.Row + intUnitRow, wbMain.Names["unit_model"].Start.Column].Value = wb1.Names["unit_model"].Value;
                                            //wsMain.Cells[wbMain.Names["unit_length"].Start.Row + intUnitRow, wbMain.Names["unit_length"].Start.Column].Value = wb1.Names["unit_length"].Value;
                                            //wsMain.Cells[wbMain.Names["unit_width"].Start.Row + intUnitRow, wbMain.Names["unit_width"].Start.Column].Value = wb1.Names["unit_width"].Value;
                                            //wsMain.Cells[wbMain.Names["unit_height"].Start.Row + intUnitRow, wbMain.Names["unit_height"].Start.Column].Value = wb1.Names["unit_height"].Value;
                                            wsMain.Cells[wbMain.Names["unit_installation"].Start.Row + intUnitRow, wbMain.Names["unit_installation"].Start.Column].Value = wb1.Names["unit_installation"].Value;
                                            wsMain.Cells[wbMain.Names["unit_voltage"].Start.Row + intUnitRow, wbMain.Names["unit_voltage"].Start.Column].Value = wb1.Names["unit_voltage"].Value;
                                            wsMain.Cells[wbMain.Names["supply_air_esp"].Start.Row + intUnitRow, wbMain.Names["supply_air_esp"].Start.Column].Value = wb1.Names["supply_air_esp"].Value;
                                            wsMain.Cells[wbMain.Names["exhaust_air_esp"].Start.Row + intUnitRow, wbMain.Names["exhaust_air_esp"].Start.Column].Value = wb1.Names["exhaust_air_esp"].Value;
                                            wsMain.Cells[wbMain.Names["elec_data_mca"].Start.Row + intUnitRow, wbMain.Names["elec_data_mca"].Start.Column].Value = wb1.Names["elec_data_mca"].Value;
                                            wsMain.Cells[wbMain.Names["elec_data_mropd"].Start.Row + intUnitRow, wbMain.Names["elec_data_mropd"].Start.Column].Value = wb1.Names["elec_data_mropd"].Value;
                                            wsMain.Cells[wbMain.Names["elec_data_recommmen_fuse"].Start.Row + intUnitRow, wbMain.Names["elec_data_recommmen_fuse"].Start.Column].Value = wb1.Names["elec_data_recommmen_fuse"].Value;
                                            wsMain.Cells[wbMain.Names["unit_weight"].Start.Row + intUnitRow, wbMain.Names["unit_weight"].Start.Column].Value = wb1.Names.ContainsKey("unit_weight") == true ? wb1.Names["unit_weight"].Value : "";
                                            wsMain.Cells[wbMain.Names["descriptions"].Start.Row + intUnitRow, wbMain.Names["descriptions"].Start.Column].Value = wb1.Names.ContainsKey("descriptions") == true ? wb1.Names["descriptions"].Value : "";
                                            #endregion


                                            wsMain.Cells[wbMain.Names["preheat_elec_heater_control_type"].Start.Row + intUnitRow, wbMain.Names["preheat_elec_heater_control_type"].Start.Column].Value = wb1.Names["preheat_elec_heater_control_type"].Value;
                                            wsMain.Cells[wbMain.Names["preheat_elec_heater_voltage"].Start.Row + intUnitRow, wbMain.Names["preheat_elec_heater_voltage"].Start.Column].Value = wb1.Names["preheat_elec_heater_voltage"].Value;
                                            wsMain.Cells[wbMain.Names["preheat_elec_heater_kw"].Start.Row + intUnitRow, wbMain.Names["preheat_elec_heater_kw"].Start.Column].Value = wb1.Names["preheat_elec_heater_kw"].Value;
                                            wsMain.Cells[wbMain.Names["preheat_elec_heater_eat"].Start.Row + intUnitRow, wbMain.Names["preheat_elec_heater_eat"].Start.Column].Value = wb1.Names["preheat_elec_heater_eat"].Value;
                                            wsMain.Cells[wbMain.Names["preheat_elec_heater_lat"].Start.Row + intUnitRow, wbMain.Names["preheat_elec_heater_lat"].Start.Column].Value = wb1.Names["preheat_elec_heater_lat"].Value;
                                            //wsMain.Cells[wbMain.Names["preheat_elec_heater_fla"].Start.Row + intUnitRow, wbMain.Names["preheat_elec_heater_fla"].Start.Column].Value = wb1.Names["preheat_elec_heater_fla"].Value;
                                            if (!bolPreheatElecHeat)
                                            {
                                                bolPreheatElecHeat = wb1.Names["preheat_elec_heater_kw"].Value != null ? true : false;
                                            }

                                            //wsMain.Cells[wbMain.Names["preheat_hwc_rows"].Start.Row + intUnitRow, wbMain.Names["preheat_hwc_rows"].Start.Column].Value = wb1.Names["preheat_hwc_rows"].Value;
                                            wsMain.Cells[wbMain.Names["preheat_hwc_input_eat_db"].Start.Row + intUnitRow, wbMain.Names["preheat_hwc_input_eat_db"].Start.Column].Value = wb1.Names["preheat_hwc_input_eat_db"].Value;
                                            wsMain.Cells[wbMain.Names["preheat_hwc_input_fluid_ent_temp"].Start.Row + intUnitRow, wbMain.Names["preheat_hwc_input_fluid_ent_temp"].Start.Column].Value = wb1.Names["preheat_hwc_input_fluid_ent_temp"].Value;
                                            wsMain.Cells[wbMain.Names["preheat_hwc_input_fluid_lvg_temp"].Start.Row + intUnitRow, wbMain.Names["preheat_hwc_input_fluid_lvg_temp"].Start.Column].Value = wb1.Names["preheat_hwc_input_fluid_lvg_temp"].Value;
                                            wsMain.Cells[wbMain.Names["preheat_hwc_output_capacity"].Start.Row + intUnitRow, wbMain.Names["preheat_hwc_output_capacity"].Start.Column].Value = wb1.Names["preheat_hwc_output_capacity"].Value;
                                            wsMain.Cells[wbMain.Names["preheat_hwc_output_lat_db"].Start.Row + intUnitRow, wbMain.Names["preheat_hwc_output_lat_db"].Start.Column].Value = wb1.Names["preheat_hwc_output_lat_db"].Value;
                                            //wsMain.Cells[wbMain.Names["preheat_hwc_output_air_pd"].Start.Row + intUnitRow, wbMain.Names["preheat_hwc_output_air_pd"].Start.Column].Value = wb1.Names["preheat_hwc_output_air_pd"].Value;
                                            wsMain.Cells[wbMain.Names["preheat_hwc_output_fluid_flow_rate"].Start.Row + intUnitRow, wbMain.Names["preheat_hwc_output_fluid_flow_rate"].Start.Column].Value = wb1.Names["preheat_hwc_output_fluid_flow_rate"].Value;
                                            if (!bolPreheatHWC)
                                            {
                                                bolPreheatHWC = wb1.Names["preheat_hwc_output_capacity"].Value != null ? true : false;
                                            }

                                            wsMain.Cells[wbMain.Names["hx_fp_core_summer_sensible_effect"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_sensible_effect"].Start.Column].Value = wb1.Names["hx_fp_core_summer_sensible_effect"].Value;
                                            wsMain.Cells[wbMain.Names["hx_fp_core_summer_latent_effect"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_latent_effect"].Start.Column].Value = wb1.Names["hx_fp_core_summer_latent_effect"].Value;
                                            wsMain.Cells[wbMain.Names["hx_fp_core_summer_total_effect"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_total_effect"].Start.Column].Value = wb1.Names["hx_fp_core_summer_total_effect"].Value;

                                            wsMain.Cells[wbMain.Names["hx_fp_core_winter_sensible_effect"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_sensible_effect"].Start.Column].Value = wb1.Names["hx_fp_core_winter_sensible_effect"].Value;
                                            wsMain.Cells[wbMain.Names["hx_fp_core_winter_latent_effect"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_latent_effect"].Start.Column].Value = wb1.Names["hx_fp_core_winter_latent_effect"].Value;
                                            wsMain.Cells[wbMain.Names["hx_fp_core_winter_total_effect"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_total_effect"].Start.Column].Value = wb1.Names["hx_fp_core_winter_total_effect"].Value;

                                            wsMain.Cells[wbMain.Names["hx_fp_core_summer_ra_ent_db"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_ra_ent_db"].Start.Column].Value = wb1.Names["hx_fp_core_summer_ra_ent_db"].Value;
                                            wsMain.Cells[wbMain.Names["hx_fp_core_summer_ra_ent_wb"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_ra_ent_wb"].Start.Column].Value = wb1.Names["hx_fp_core_summer_ra_ent_wb"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_summer_ra_ent_rh"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_ra_ent_rh"].Start.Column].Value = wb1.Names["hx_fp_core_summer_ra_ent_rh"].Value;

                                            wsMain.Cells[wbMain.Names["hx_fp_core_winter_ra_ent_db"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_ra_ent_db"].Start.Column].Value = wb1.Names["hx_fp_core_winter_ra_ent_db"].Value;
                                            wsMain.Cells[wbMain.Names["hx_fp_core_winter_ra_ent_wb"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_ra_ent_wb"].Start.Column].Value = wb1.Names["hx_fp_core_winter_ra_ent_wb"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_winter_ra_ent_rh"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_ra_ent_rh"].Start.Column].Value = wb1.Names["hx_fp_core_winter_ra_ent_rh"].Value;

                                            //wsMain.Cells[wbMain.Names["hx_fp_core_summer_ra_lvg_db"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_ra_lvg_db"].Start.Column].Value = wb1.Names["hx_fp_core_summer_ra_lvg_db"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_summer_ra_lvg_wb"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_ra_lvg_wb"].Start.Column].Value = wb1.Names["hx_fp_core_summer_ra_lvg_wb"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_summer_ra_lvg_rh"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_ra_lvg_rh"].Start.Column].Value = wb1.Names["hx_fp_core_summer_ra_lvg_rh"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_summer_ra_lvg_pd"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_ra_lvg_pd"].Start.Column].Value = wb1.Names["hx_fp_core_summer_ra_lvg_pd"].Value;

                                            //wsMain.Cells[wbMain.Names["hx_fp_core_winter_ra_lvg_db"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_ra_lvg_db"].Start.Column].Value = wb1.Names["hx_fp_core_winter_ra_lvg_db"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_winter_ra_lvg_wb"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_ra_lvg_wb"].Start.Column].Value = wb1.Names["hx_fp_core_winter_ra_lvg_wb"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_winter_ra_lvg_rh"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_ra_lvg_rh"].Start.Column].Value = wb1.Names["hx_fp_core_winter_ra_lvg_rh"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_winter_ra_lvg_pd"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_ra_lvg_pd"].Start.Column].Value = wb1.Names["hx_fp_core_winter_ra_lvg_pd"].Value;

                                            wsMain.Cells[wbMain.Names["hx_fp_core_summer_sa_ent_db"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_sa_ent_db"].Start.Column].Value = wb1.Names["hx_fp_core_summer_sa_ent_db"].Value;
                                            wsMain.Cells[wbMain.Names["hx_fp_core_summer_sa_ent_wb"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_sa_ent_wb"].Start.Column].Value = wb1.Names["hx_fp_core_summer_sa_ent_wb"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_summer_sa_ent_rh"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_sa_ent_rh"].Start.Column].Value = wb1.Names["hx_fp_core_summer_sa_ent_rh"].Value;

                                            wsMain.Cells[wbMain.Names["hx_fp_core_winter_sa_ent_db"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_sa_ent_db"].Start.Column].Value = wb1.Names["hx_fp_core_winter_sa_ent_db"].Value;
                                            wsMain.Cells[wbMain.Names["hx_fp_core_winter_sa_ent_wb"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_sa_ent_wb"].Start.Column].Value = wb1.Names["hx_fp_core_winter_sa_ent_wb"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_winter_sa_ent_rh"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_sa_ent_rh"].Start.Column].Value = wb1.Names["hx_fp_core_winter_sa_ent_rh"].Value;

                                            wsMain.Cells[wbMain.Names["hx_fp_core_summer_sa_lvg_db"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_sa_lvg_db"].Start.Column].Value = wb1.Names["hx_fp_core_summer_sa_lvg_db"].Value;
                                            wsMain.Cells[wbMain.Names["hx_fp_core_summer_sa_lvg_wb"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_sa_lvg_wb"].Start.Column].Value = wb1.Names["hx_fp_core_summer_sa_lvg_wb"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_summer_sa_lvg_rh"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_sa_lvg_rh"].Start.Column].Value = wb1.Names["hx_fp_core_summer_sa_lvg_rh"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_summer_sa_lvg_pd"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_summer_sa_lvg_pd"].Start.Column].Value = wb1.Names["hx_fp_core_summer_sa_lvg_pd"].Value;

                                            wsMain.Cells[wbMain.Names["hx_fp_core_winter_sa_lvg_db"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_sa_lvg_db"].Start.Column].Value = wb1.Names["hx_fp_core_winter_sa_lvg_db"].Value;
                                            wsMain.Cells[wbMain.Names["hx_fp_core_winter_sa_lvg_wb"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_sa_lvg_wb"].Start.Column].Value = wb1.Names["hx_fp_core_winter_sa_lvg_wb"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_winter_sa_lvg_rh"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_sa_lvg_rh"].Start.Column].Value = wb1.Names["hx_fp_core_winter_sa_lvg_rh"].Value;
                                            //wsMain.Cells[wbMain.Names["hx_fp_core_winter_sa_lvg_pd"].Start.Row + intUnitRow, wbMain.Names["hx_fp_core_winter_sa_lvg_pd"].Start.Column].Value = wb1.Names["hx_fp_core_winter_sa_lvg_pd"].Value;
                                            if (!bolHeatExch)
                                            {
                                                bolHeatExch = wb1.Names["hx_fp_core_summer_sensible_effect"].Value != null ? true : false;
                                            }


                                            //wsMain.Cells[wbMain.Names["cooling_cwc_rows"].Start.Row + intUnitRow, wbMain.Names["cooling_cwc_rows"].Start.Column].Value = wb1.Names["cooling_cwc_rows"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_cwc_input_eat_db"].Start.Row + intUnitRow, wbMain.Names["cooling_cwc_input_eat_db"].Start.Column].Value = wb1.Names["cooling_cwc_input_eat_db"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_cwc_input_eat_wb"].Start.Row + intUnitRow, wbMain.Names["cooling_cwc_input_eat_wb"].Start.Column].Value = wb1.Names["cooling_cwc_input_eat_wb"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_cwc_input_fluid_ent_temp"].Start.Row + intUnitRow, wbMain.Names["cooling_cwc_input_fluid_ent_temp"].Start.Column].Value = wb1.Names["cooling_cwc_input_fluid_ent_temp"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_cwc_input_fluid_lvg_temp"].Start.Row + intUnitRow, wbMain.Names["cooling_cwc_input_fluid_lvg_temp"].Start.Column].Value = wb1.Names["cooling_cwc_input_fluid_lvg_temp"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_cwc_output_capacity"].Start.Row + intUnitRow, wbMain.Names["cooling_cwc_output_capacity"].Start.Column].Value = wb1.Names["cooling_cwc_output_capacity"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_cwc_output_lat_db"].Start.Row + intUnitRow, wbMain.Names["cooling_cwc_output_lat_db"].Start.Column].Value = wb1.Names["cooling_cwc_output_lat_db"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_cwc_output_lat_wb"].Start.Row + intUnitRow, wbMain.Names["cooling_cwc_output_lat_wb"].Start.Column].Value = wb1.Names["cooling_cwc_output_lat_wb"].Value;
                                            //wsMain.Cells[wbMain.Names["cooling_cwc_output_air_pd"].Start.Row + intUnitRow, wbMain.Names["cooling_cwc_output_air_pd"].Start.Column].Value = wb1.Names["cooling_cwc_output_air_pd"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_cwc_output_fluid_flow_rate"].Start.Row + intUnitRow, wbMain.Names["cooling_cwc_output_fluid_flow_rate"].Start.Column].Value = wb1.Names["cooling_cwc_output_fluid_flow_rate"].Value;
                                            if (!bolCooligCWC)
                                            {
                                                bolCooligCWC = wb1.Names["cooling_cwc_output_capacity"].Value != null ? true : false;
                                            }


                                            //wsMain.Cells[wbMain.Names["cooling_dx_rows"].Start.Row + intUnitRow, wbMain.Names["cooling_dx_rows"].Start.Column].Value = wb1.Names["cooling_dx_rows"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_dx_input_eat_db"].Start.Row + intUnitRow, wbMain.Names["cooling_dx_input_eat_db"].Start.Column].Value = wb1.Names["cooling_dx_input_eat_db"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_dx_input_eat_wb"].Start.Row + intUnitRow, wbMain.Names["cooling_dx_input_eat_wb"].Start.Column].Value = wb1.Names["cooling_dx_input_eat_wb"].Value;
                                            //wsMain.Cells[wbMain.Names["cooling_dx_input_refrig_suction_temp"].Start.Row + intUnitRow, wbMain.Names["cooling_dx_input_refrig_suction_temp"].Start.Column].Value = wb1.Names["cooling_dx_input_refrig_suction_temp"].Value;
                                            //wsMain.Cells[wbMain.Names["cooling_dx_input_refrig_liquid_temp"].Start.Row + intUnitRow, wbMain.Names["cooling_dx_input_refrig_liquid_temp"].Start.Column].Value = wb1.Names["cooling_dx_input_refrig_liquid_temp"].Value;
                                            //wsMain.Cells[wbMain.Names["cooling_dx_input_refrig_superheat_temp"].Start.Row + intUnitRow, wbMain.Names["cooling_dx_input_refrig_superheat_temp"].Start.Column].Value = wb1.Names["cooling_dx_input_refrig_superheat_temp"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_dx_output_capacity"].Start.Row + intUnitRow, wbMain.Names["cooling_dx_output_capacity"].Start.Column].Value = wb1.Names["cooling_dx_output_capacity"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_dx_output_lat_db"].Start.Row + intUnitRow, wbMain.Names["cooling_dx_output_lat_db"].Start.Column].Value = wb1.Names["cooling_dx_output_lat_db"].Value;
                                            wsMain.Cells[wbMain.Names["cooling_dx_output_lat_wb"].Start.Row + intUnitRow, wbMain.Names["cooling_dx_output_lat_wb"].Start.Column].Value = wb1.Names["cooling_dx_output_lat_wb"].Value;
                                            //wsMain.Cells[wbMain.Names["cooling_dx_output_air_pd"].Start.Row + intUnitRow, wbMain.Names["cooling_dx_output_air_pd"].Start.Column].Value = wb1.Names["cooling_dx_output_air_pd"].Value;
                                            //wsMain.Cells[wbMain.Names["cooling_dx_output_internal_volume"].Start.Row + intUnitRow, wbMain.Names["cooling_dx_output_internal_volume"].Start.Column].Value = wb1.Names["cooling_dx_output_internal_volume"].Value;

                                            wsMain.Cells[wbMain.Names["w_controller_voltage"].Start.Row + intUnitRow, wbMain.Names["w_controller_voltage"].Start.Column].Value = wb1.Names.ContainsKey("w_controller_voltage") == true ? wb1.Names["w_controller_voltage"].Value : "";
                                            if (!bolCoolingDX)
                                            {
                                                bolCoolingDX = wb1.Names["cooling_dx_output_capacity"].Value != null ? true : false;
                                            }


                                            //wsMain.Cells[wbMain.Names["heating_dx_rows"].Start.Row + intUnitRow, wbMain.Names["heating_dx_rows"].Start.Column].Value = wb1.Names["heating_dx_rows"].Value;
                                            wsMain.Cells[wbMain.Names["heating_dx_input_eat_db"].Start.Row + intUnitRow, wbMain.Names["heating_dx_input_eat_db"].Start.Column].Value = wb1.Names["heating_dx_input_eat_db"].Value;
                                            //wsMain.Cells[wbMain.Names["heating_dx_input_refrig_cond_temp"].Start.Row + intUnitRow, wbMain.Names["heating_dx_input_refrig_cond_temp"].Start.Column].Value = wb1.Names["heating_dx_input_refrig_cond_temp"].Value;
                                            //wsMain.Cells[wbMain.Names["heating_dx_input_refrig_vapor_temp"].Start.Row + intUnitRow, wbMain.Names["heating_dx_input_refrig_vapor_temp"].Start.Column].Value = wb1.Names["heating_dx_input_refrig_vapor_temp"].Value;
                                            //wsMain.Cells[wbMain.Names["heating_dx_input_refrig_subcooling_temp"].Start.Row + intUnitRow, wbMain.Names["heating_dx_input_refrig_subcooling_temp"].Start.Column].Value = wb1.Names["heating_dx_input_refrig_subcooling_temp"].Value;
                                            wsMain.Cells[wbMain.Names["heating_dx_output_capacity"].Start.Row + intUnitRow, wbMain.Names["heating_dx_output_capacity"].Start.Column].Value = wb1.Names["heating_dx_output_capacity"].Value;
                                            wsMain.Cells[wbMain.Names["heating_dx_output_lat_db"].Start.Row + intUnitRow, wbMain.Names["heating_dx_output_lat_db"].Start.Column].Value = wb1.Names["heating_dx_output_lat_db"].Value;
                                            //wsMain.Cells[wbMain.Names["heating_dx_output_air_pd"].Start.Row + intUnitRow, wbMain.Names["heating_dx_output_air_pd"].Start.Column].Value = wb1.Names["heating_dx_output_air_pd"].Value;
                                            //wsMain.Cells[wbMain.Names["heating_dx_output_internal_volume"].Start.Row + intUnitRow, wbMain.Names["heating_dx_output_internal_volume"].Start.Column].Value = wb1.Names["heating_dx_output_internal_volume"].Value;
                                            if (!bolHeatingDX)
                                            {
                                                bolHeatingDX = wb1.Names["heating_dx_output_capacity"].Value != null ? true : false;
                                            }


                                            wsMain.Cells[wbMain.Names["heating_elec_heater_control_type"].Start.Row + intUnitRow, wbMain.Names["heating_elec_heater_control_type"].Start.Column].Value = wb1.Names["heating_elec_heater_control_type"].Value;
                                            wsMain.Cells[wbMain.Names["heating_elec_heater_voltage"].Start.Row + intUnitRow, wbMain.Names["heating_elec_heater_voltage"].Start.Column].Value = wb1.Names["heating_elec_heater_voltage"].Value;
                                            wsMain.Cells[wbMain.Names["heating_elec_heater_kw"].Start.Row + intUnitRow, wbMain.Names["heating_elec_heater_kw"].Start.Column].Value = wb1.Names["heating_elec_heater_kw"].Value;
                                            wsMain.Cells[wbMain.Names["heating_elec_heater_eat"].Start.Row + intUnitRow, wbMain.Names["heating_elec_heater_eat"].Start.Column].Value = wb1.Names["heating_elec_heater_eat"].Value;
                                            wsMain.Cells[wbMain.Names["heating_elec_heater_lat"].Start.Row + intUnitRow, wbMain.Names["heating_elec_heater_lat"].Start.Column].Value = wb1.Names["heating_elec_heater_lat"].Value;
                                            //wsMain.Cells[wbMain.Names["heating_elec_heater_fla"].Start.Row + intUnitRow, wbMain.Names["heating_elec_heater_fla"].Start.Column].Value = wb1.Names["heating_elec_heater_fla"].Value;
                                            if (!bolHeatingElecHeat)
                                            {
                                                bolHeatingElecHeat = wb1.Names["heating_elec_heater_kw"].Value != null ? true : false;
                                            }


                                            //wsMain.Cells[wbMain.Names["heating_hwc_rows"].Start.Row + intUnitRow, wbMain.Names["heating_hwc_rows"].Start.Column].Value = wb1.Names["heating_hwc_rows"].Value;
                                            wsMain.Cells[wbMain.Names["heating_hwc_input_eat_db"].Start.Row + intUnitRow, wbMain.Names["heating_hwc_input_eat_db"].Start.Column].Value = wb1.Names["heating_hwc_input_eat_db"].Value;
                                            wsMain.Cells[wbMain.Names["heating_hwc_input_fluid_ent_temp"].Start.Row + intUnitRow, wbMain.Names["heating_hwc_input_fluid_ent_temp"].Start.Column].Value = wb1.Names["heating_hwc_input_fluid_ent_temp"].Value;
                                            wsMain.Cells[wbMain.Names["heating_hwc_input_fluid_lvg_temp"].Start.Row + intUnitRow, wbMain.Names["heating_hwc_input_fluid_lvg_temp"].Start.Column].Value = wb1.Names["heating_hwc_input_fluid_lvg_temp"].Value;
                                            wsMain.Cells[wbMain.Names["heating_hwc_output_capacity"].Start.Row + intUnitRow, wbMain.Names["heating_hwc_output_capacity"].Start.Column].Value = wb1.Names["heating_hwc_output_capacity"].Value;
                                            wsMain.Cells[wbMain.Names["heating_hwc_output_lat_db"].Start.Row + intUnitRow, wbMain.Names["heating_hwc_output_lat_db"].Start.Column].Value = wb1.Names["heating_hwc_output_lat_db"].Value;
                                            //wsMain.Cells[wbMain.Names["heating_hwc_output_air_pd"].Start.Row + intUnitRow, wbMain.Names["heating_hwc_output_air_pd"].Start.Column].Value = wb1.Names["heating_hwc_output_air_pd"].Value;
                                            wsMain.Cells[wbMain.Names["heating_hwc_output_fluid_flow_rate"].Start.Row + intUnitRow, wbMain.Names["heating_hwc_output_fluid_flow_rate"].Start.Column].Value = wb1.Names["heating_hwc_output_fluid_flow_rate"].Value;
                                            if (!bolHeatingHWC)
                                            {
                                                bolHeatingHWC = wb1.Names["heating_hwc_output_capacity"].Value != null ? true : false;
                                            }


                                            wsMain.Cells[wbMain.Names["reheat_elec_heater_control_type"].Start.Row + intUnitRow, wbMain.Names["reheat_elec_heater_control_type"].Start.Column].Value = wb1.Names["reheat_elec_heater_control_type"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_elec_heater_voltage"].Start.Row + intUnitRow, wbMain.Names["reheat_elec_heater_voltage"].Start.Column].Value = wb1.Names["reheat_elec_heater_voltage"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_elec_heater_kw"].Start.Row + intUnitRow, wbMain.Names["reheat_elec_heater_kw"].Start.Column].Value = wb1.Names["reheat_elec_heater_kw"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_elec_heater_eat"].Start.Row + intUnitRow, wbMain.Names["reheat_elec_heater_eat"].Start.Column].Value = wb1.Names["reheat_elec_heater_eat"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_elec_heater_lat"].Start.Row + intUnitRow, wbMain.Names["reheat_elec_heater_lat"].Start.Column].Value = wb1.Names["reheat_elec_heater_lat"].Value;
                                            //wsMain.Cells[wbMain.Names["reheat_elec_heater_fla"].Start.Row + intUnitRow, wbMain.Names["reheat_elec_heater_fla"].Start.Column].Value = wb1.Names["reheat_elec_heater_fla"].Value;
                                            if (!bolReheatElecHeat)
                                            {
                                                bolReheatElecHeat = wb1.Names["reheat_elec_heater_kw"].Value != null ? true : false;
                                            }

                                            //wsMain.Cells[wbMain.Names["reheat_hwc_rows"].Start.Row + intUnitRow, wbMain.Names["reheat_hwc_rows"].Start.Column].Value = wb1.Names["reheat_hwc_rows"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_hwc_input_eat_db"].Start.Row + intUnitRow, wbMain.Names["reheat_hwc_input_eat_db"].Start.Column].Value = wb1.Names["reheat_hwc_input_eat_db"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_hwc_input_fluid_ent_temp"].Start.Row + intUnitRow, wbMain.Names["reheat_hwc_input_fluid_ent_temp"].Start.Column].Value = wb1.Names["reheat_hwc_input_fluid_ent_temp"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_hwc_input_fluid_lvg_temp"].Start.Row + intUnitRow, wbMain.Names["reheat_hwc_input_fluid_lvg_temp"].Start.Column].Value = wb1.Names["reheat_hwc_input_fluid_lvg_temp"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_hwc_output_capacity"].Start.Row + intUnitRow, wbMain.Names["reheat_hwc_output_capacity"].Start.Column].Value = wb1.Names["reheat_hwc_output_capacity"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_hwc_output_lat_db"].Start.Row + intUnitRow, wbMain.Names["reheat_hwc_output_lat_db"].Start.Column].Value = wb1.Names["reheat_hwc_output_lat_db"].Value;
                                            //wsMain.Cells[wbMain.Names["reheat_hwc_output_air_pd"].Start.Row + intUnitRow, wbMain.Names["reheat_hwc_output_air_pd"].Start.Column].Value = wb1.Names["reheat_hwc_output_air_pd"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_hwc_output_fluid_flow_rate"].Start.Row + intUnitRow, wbMain.Names["reheat_hwc_output_fluid_flow_rate"].Start.Column].Value = wb1.Names["reheat_hwc_output_fluid_flow_rate"].Value;
                                            if (!bolReheatHWC)
                                            {
                                                bolReheatHWC = wb1.Names["reheat_hwc_output_capacity"].Value != null ? true : false;
                                            }


                                            //wsMain.Cells[wbMain.Names["reheat_hgrc_rows"].Start.Row + intUnitRow, wbMain.Names["reheat_hgrc_rows"].Start.Column].Value = wb1.Names["reheat_hgrc_rows"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_hgrc_input_eat_db"].Start.Row + intUnitRow, wbMain.Names["reheat_hgrc_input_eat_db"].Start.Column].Value = wb1.Names["reheat_hgrc_input_eat_db"].Value;
                                            //wsMain.Cells[wbMain.Names["reheat_hgrc_input_refrig_cond_temp"].Start.Row + intUnitRow, wbMain.Names["reheat_hgrc_input_refrig_cond_temp"].Start.Column].Value = wb1.Names["reheat_hgrc_input_refrig_cond_temp"].Value;
                                            //wsMain.Cells[wbMain.Names["reheat_hgrc_input_refrig_vapor_temp"].Start.Row + intUnitRow, wbMain.Names["reheat_hgrc_input_refrig_vapor_temp"].Start.Column].Value = wb1.Names["reheat_hgrc_input_refrig_vapor_temp"].Value;
                                            //wsMain.Cells[wbMain.Names["reheat_hgrc_input_refrig_percent_cond_load"].Start.Row + intUnitRow, wbMain.Names["reheat_hgrc_input_refrig_percent_cond_load"].Start.Column].Value = wb1.Names["reheat_hgrc_input_refrig_percent_cond_load"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_hgrc_output_capacity"].Start.Row + intUnitRow, wbMain.Names["reheat_hgrc_output_capacity"].Start.Column].Value = wb1.Names["reheat_hgrc_output_capacity"].Value;
                                            wsMain.Cells[wbMain.Names["reheat_hgrc_output_lat_db"].Start.Row + intUnitRow, wbMain.Names["reheat_hgrc_output_lat_db"].Start.Column].Value = wb1.Names["reheat_hgrc_output_lat_db"].Value;
                                            //wsMain.Cells[wbMain.Names["reheat_hgrc_output_air_pd"].Start.Row + intUnitRow, wbMain.Names["reheat_hgrc_output_air_pd"].Start.Column].Value = wb1.Names["reheat_hgrc_output_air_pd"].Value;
                                            if (!bolReheatHGRC)
                                            {
                                                bolReheatHGRC = wb1.Names["reheat_hgrc_output_capacity"].Value != null ? true : false;
                                            }


                                            wsMain.Cells[wbMain.Names["supply_air_cfm"].Start.Row + intUnitRow, wbMain.Names["supply_air_cfm"].Start.Column].Value = wb1.Names["supply_air_cfm"].Value;
                                            wsMain.Cells[wbMain.Names["supply_air_esp"].Start.Row + intUnitRow, wbMain.Names["supply_air_esp"].Start.Column].Value = wb1.Names["supply_air_esp"].Value;
                                            //wsMain.Cells[wbMain.Names["sf_power_input"].Start.Row + intUnitRow, wbMain.Names["sf_power_input"].Start.Column].Value = wb1.Names["sf_power_input"].Value;
                                            //wsMain.Cells[wbMain.Names["sf_lw6_sum"].Start.Row + intUnitRow, wbMain.Names["sf_lw6_sum"].Start.Column].Value = wb1.Names["sf_lw6_sum"].Value;

                                            wsMain.Cells[wbMain.Names["exhaust_air_cfm"].Start.Row + intUnitRow, wbMain.Names["exhaust_air_cfm"].Start.Column].Value = wb1.Names["exhaust_air_cfm"].Value;
                                            wsMain.Cells[wbMain.Names["exhaust_air_esp"].Start.Row + intUnitRow, wbMain.Names["exhaust_air_esp"].Start.Column].Value = wb1.Names["exhaust_air_esp"].Value;
                                            //wsMain.Cells[wbMain.Names["ef_power_input"].Start.Row + intUnitRow, wbMain.Names["ef_power_input"].Start.Column].Value = wb1.Names["ef_power_input"].Value;
                                            //wsMain.Cells[wbMain.Names["ef_lw6_sum"].Start.Row + intUnitRow, wbMain.Names["ef_lw6_sum"].Start.Column].Value = wb1.Names["ef_lw6_sum"].Value;

                                            if (!bolERV_or_DOAS)
                                            {
                                                bolERV_or_DOAS = wb1.Names["exhaust_air_cfm"].Value != null ? true : false;
                                            }


                                            intUnitRow++;
                                        }
                                    }

                                    //strPathAndFile = HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderPDF_Submittal + "/" + dtUnitList.Rows[i]["job_id"].ToString() + "_" + dtUnitList.Rows[i]["unit_no"].ToString() + ".pdf");
                                }
                            }
                        }

                        //#region Preheat Elec Heter
                        //if (_objCont.objCGeneral != null)
                        //{
                        //}
                        //else
                        //{
                        //    //int intRow = workbook.Names["preheat_hwc_model"].Rows.ToString();
                        //}
                        //#endregion




                        //wsMain.DeleteColumn(1);
                        int intEndMain = wbMain.Names["schedule_end"].End.Column;

                        //ws.Cells[7, 1, intRow, intEnd].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        wsMain.Cells[intStartRow, 1, intStartRow + intUnitRow - 1, intEndMain].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        wsMain.Cells[intStartRow, 1, intStartRow + intUnitRow - 1, intEndMain].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        wsMain.Cells[intStartRow, 1, intStartRow + intUnitRow - 1, intEndMain].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        wsMain.Cells[intStartRow, 1, intStartRow + intUnitRow - 1, intEndMain].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                        int intNoteNbr = 0;
                        int intSpecRow = intStartRow + intUnitRow + 5;

                        if (intNovaQty > 0)
                        {
                            wsMain.Cells[intSpecRow, 1].Value = "Notes for Nova";
                            wsMain.Cells[intSpecRow, 1].Style.Font.Size = 14;
                            wsMain.Cells[intSpecRow, 1].Style.Font.Bold = true;

                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Low profile – for ceiling or wall installation";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   No heat exchanger virus crossover - ASTM F1671 tested for no virus penetration";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Low cross-over energy recovery counter flow core <0.5% EATR tested to AHRI 1060";

                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Total Energy Recovery effectiveness >60% tested to AHRI 1060";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Maintenance – water washable energy/heat recovery core with no moving parts. Paper cores are not acceptable.";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide units with direct drive plenum ECM Fans  (< 1 W/CFM)";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Double wall insulated casing with minimum R4 per inch";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Units shall include factory mounted BACNet IP controls with BTL Certification";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide each unit with human interface controller.";

                            if (intNovaBypassQty > 0)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Unit shall have integral modulating bypass damper to benefit economizer hours";
                            }

                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Filter monitoring with remote alarm via pressure measurement across the filter. MERV13 filters on OA and MERV8 filters on RA.";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Certifications: UL, CSA and AHRI";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide return air CO2 sensor and control fans speed based on CO2 reading";
                            if (bolCoolingDX)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Factory mounted DX coils, factory mounted and brazed Expansion Valve Kits (EEV) approved by Daikin.";
                            }

                            if (bolCoolingDX && bolReheatHGRC)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Factory mounted dew point sensor between DX and HGRH coils for humidity control.";
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Ship loose temperature and humidity sensor for discharge air temperature and humidity control";
                            }

                            if (bolCooligCWC || bolPreheatHWC || bolHeatingHWC || bolReheatHWC)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Factory mounted hydronic coils provided with loose valves and actuators ";
                            }

                            if (bolPreheatElecHeat || bolHeatingElecHeat || bolReheatElecHeat)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide electric heaters with SCR control";
                            }

                            wsMain.Cells[intStartRow + intUnitRow + 5, 1, intSpecRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }


                        if (intVentumERV_Qty > 0)
                        {
                            intNoteNbr = 0;
                            intSpecRow = intSpecRow + 2;

                            wsMain.Cells[intSpecRow, 1].Value = "Notes for Ventum ERV";
                            wsMain.Cells[intSpecRow, 1].Style.Font.Size = 14;
                            wsMain.Cells[intSpecRow, 1].Style.Font.Bold = true;

                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Low profile – for ceiling or wall installation";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   No heat exchanger virus crossover - ASTM F1671 tested for no virus penetration";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Low cross-over energy recovery counter flow core <0.5% EATR tested to AHRI 1060";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Total Energy Recovery effectiveness >60%";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Maintenance – water washable energy/heat recovery core with no moving parts. Paper cores are not acceptable.";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide units with direct drive plenum ECM Fans  (< 1 W/CFM)";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Double wall insulated casing with minimum R4 per inch";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Units shall include factory mounted BACNet IP controls with BTL Certification";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide each unit with human interface controller.";

                            if (intVentumBypassERV_Qty > 0)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Unit shall have integral modulating bypass damper to benefit economizer hours";
                            }


                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Filter monitoring with remote alarm via pressure measurement across the filter. MERV13 filters on OA and MERV8 filters on RA.";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Certifications: UL and CSA";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide return air CO2 sensor and control fans speed based on CO2 reading";
                            if (bolCoolingDX)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Factory mounted DX coils, factory mounted and brazed Expansion Valve Kits (EEV) approved by Daikin.";
                            }

                            if (bolCoolingDX && bolReheatHGRC)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Factory mounted dew point sensor between DX and HGRH coils for humidity control.";
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Ship loose temperature and humidity sensor for discharge air temperature and humidity control";
                            }

                            if (bolCooligCWC || bolPreheatHWC || bolHeatingHWC || bolReheatHWC)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Factory mounted hydronic coils provided with loose valves and actuators ";
                            }

                            if (bolPreheatElecHeat || bolHeatingElecHeat || bolReheatElecHeat)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide electric heaters with SCR control";
                            }

                            wsMain.Cells[intStartRow + intUnitRow + 5, 1, intSpecRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }


                        if (intVentumHRV_Qty > 0)
                        {
                            intNoteNbr = 0;
                            intSpecRow = intSpecRow + 2;

                            wsMain.Cells[intSpecRow, 1].Value = "Notes for Ventum HRV";
                            wsMain.Cells[intSpecRow, 1].Style.Font.Size = 14;
                            wsMain.Cells[intSpecRow, 1].Style.Font.Bold = true;

                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Low profile – for ceiling or wall installation";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   No heat exchanger virus crossover - ASTM F1671 tested for no virus penetration";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Low cross-over energy recovery counter flow core <0.5% EATR tested to AHRI 1060";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Sensible recovery effectiveness >80% tested to AHRI 1060";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Maintenance – water washable energy/heat recovery core with no moving parts. Paper cores are not acceptable.";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide units with direct drive plenum ECM Fans  (< 1 W/CFM)";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Double wall insulated casing with minimum R4 per inch";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Units shall include factory mounted BACNet IP controls with BTL Certification";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide each unit with human interface controller.";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Unit shall have integral modulating bypass damper to benefit economizer hours";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Filter monitoring with remote alarm via pressure measurement across the filter. MERV13 filters on OA and MERV8 filters on RA.";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Certifications: UL, CSA and AHRI";
                            wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide return air CO2 sensor and control fans speed based on CO2 reading";
                            if (bolCoolingDX)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Factory mounted DX coils, factory mounted and brazed Expansion Valve Kits (EEV) approved by Daikin.";
                            }

                            if (bolCoolingDX && bolReheatHGRC)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Factory mounted dew point sensor between DX and HGRH coils for humidity control.";
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Ship loose temperature and humidity sensor for discharge air temperature and humidity control";
                            }

                            if (bolCooligCWC || bolPreheatHWC || bolHeatingHWC || bolReheatHWC)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Factory mounted hydronic coils provided with loose valves and actuators ";
                            }

                            if (bolPreheatElecHeat || bolHeatingElecHeat || bolReheatElecHeat)
                            {
                                wsMain.Cells[++intSpecRow, 1].Value = ++intNoteNbr + ".   Provide electric heaters with SCR control";
                            }

                            wsMain.Cells[intStartRow + intUnitRow + 5, 1, intSpecRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        }


                        #region Reheat Elec Heater Elec Data
                        if (!bolReheatElecHeat)
                        {
                            int intStart = wbMain.Names["reheat_elec_heater_elec_data_start"].Start.Column;
                            int intEnd = wbMain.Names["reheat_elec_heater_elec_data_end"].Start.Column;
                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region W-Controller Cooling DX
                        if (!bolCoolingDX)
                        {
                            int intStart = wbMain.Names["w_controller_start"].Start.Column;
                            int intEnd = wbMain.Names["w_controller_start"].Start.Column;
                            //for (int i = intStart; i < intEnd + 1; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //    wsMain.Column(i).Hidden = true;

                            //}
                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region Heating Elec Heater Elec Data
                        if (!bolHeatingElecHeat)
                        {
                            int intStart = wbMain.Names["heating_elec_heater_elec_data_start"].Start.Column;
                            int intEnd = wbMain.Names["heating_elec_heater_elec_data_end"].Start.Column;
                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region Preheat Elec Heater Elec Data
                        if (!bolPreheatElecHeat)
                        {
                            int intStart = wbMain.Names["preheat_elec_heater_elec_data_start"].Start.Column;
                            int intEnd = wbMain.Names["preheat_elec_heater_elec_data_end"].Start.Column;

                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region Reheat HGRC
                        if (!bolReheatHGRC)
                        {
                            int intStart = wbMain.Names["reheat_hgrc_start"].Start.Column;
                            int intEnd = wbMain.Names["reheat_hgrc_end"].Start.Column;

                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region Reheat HWC
                        if (!bolReheatHWC)
                        {
                            int intStart = wbMain.Names["reheat_hwc_start"].Start.Column;
                            int intEnd = wbMain.Names["reheat_hwc_end"].Start.Column;

                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region Reheat Elec Heter
                        if (!bolReheatElecHeat)
                        {
                            int intStart = wbMain.Names["reheat_elec_heater_start"].Start.Column;
                            int intEnd = wbMain.Names["reheat_elec_heater_end"].Start.Column;
                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region Heating HWC
                        if (!bolHeatingHWC)
                        {
                            int intStart = wbMain.Names["heating_hwc_start"].Start.Column;
                            int intEnd = wbMain.Names["heating_hwc_end"].Start.Column;

                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region Heating Elec Heter
                        if (!bolHeatingElecHeat)
                        {
                            int intStart = wbMain.Names["heating_elec_heater_start"].Start.Column;
                            int intEnd = wbMain.Names["heating_elec_heater_end"].Start.Column;
                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region Heating DX
                        if (!bolHeatingDX)
                        {
                            int intStart = wbMain.Names["heating_dx_start"].Start.Column;
                            int intEnd = wbMain.Names["heating_dx_end"].Start.Column;

                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region Cooling DX
                        if (!bolCoolingDX)
                        {
                            int intStart = wbMain.Names["cooling_dx_start"].Start.Column;
                            int intEnd = wbMain.Names["cooling_dx_end"].Start.Column;
                            //for (int i = intStart; i < intEnd + 1; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //    wsMain.Column(i).Hidden = true;

                            //}
                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region Cooling CWC
                        if (!bolCooligCWC)
                        {
                            int intStart = wbMain.Names["cooling_cwc_start"].Start.Column;
                            int intEnd = wbMain.Names["cooling_cwc_end"].Start.Column;
                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region HeatExch CORE
                        if (!bolHeatExch)
                        {
                            int intStart = wbMain.Names["hx_fp_start"].Start.Column;
                            int intEnd = wbMain.Names["hx_fp_end"].Start.Column;
                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        #region Preheat HWC
                        if (!bolPreheatHWC)
                        {
                            int intStart = wbMain.Names["preheat_hwc_start"].Start.Column;
                            int intEnd = wbMain.Names["preheat_hwc_end"].Start.Column;
                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);

                        }
                        #endregion


                        #region Preheat Elec Heter
                        if (!bolPreheatElecHeat)
                        {
                            int intStart = wbMain.Names["preheat_elec_heater_start"].Start.Column;
                            int intEnd = wbMain.Names["preheat_elec_heater_end"].Start.Column;

                            //for (int i = intStart; i < intEnd - intStart; i++)
                            //{
                            //    wsMain.DeleteColumn(i);
                            //}

                            wsMain.DeleteColumn(intStart, intEnd - intStart + 1);
                        }
                        #endregion


                        if (!bolERV_or_DOAS)
                        {
                            //Always delete columns from left to right
                            int intStart = wbMain.Names["ef_lw6_sum"].Start.Column;
                            wsMain.DeleteColumn(intStart);
                            intStart = wbMain.Names["ef_power_input"].Start.Column;
                            wsMain.DeleteColumn(intStart);
                            intStart = wbMain.Names["exhaust_air_esp"].Start.Column;
                            wsMain.DeleteColumn(intStart);
                            intStart = wbMain.Names["exhaust_air_cfm"].Start.Column;
                            wsMain.DeleteColumn(intStart);
                        }


                        wbMain.Names.Remove("schedule_start");
                        wbMain.Names.Remove("schedule_end");
                        wbMain.Names.Remove("unit_tag");
                        wbMain.Names.Remove("manufacturer");
                        wbMain.Names.Remove("unit_model");
                        wbMain.Names.Remove("unit_installation");
                        wbMain.Names.Remove("supply_air_cfm");
                        wbMain.Names.Remove("exhaust_air_cfm");
                        wbMain.Names.Remove("supply_air_esp");
                        wbMain.Names.Remove("exhaust_air_esp");
                        wbMain.Names.Remove("sf_power_input");
                        wbMain.Names.Remove("ef_power_input");
                        wbMain.Names.Remove("unit_length");
                        wbMain.Names.Remove("unit_width");
                        wbMain.Names.Remove("unit_height");
                        wbMain.Names.Remove("sf_lw6_sum");
                        wbMain.Names.Remove("ef_lw6_sum");
                        wbMain.Names.Remove("unit_voltage");
                        wbMain.Names.Remove("elec_data_mca");
                        wbMain.Names.Remove("elec_data_mropd");
                        wbMain.Names.Remove("elec_data_recommmen_fuse");
                        wbMain.Names.Remove("unit_weight");


                        wbMain.Names.Remove("preheat_elec_heater_control_type");
                        wbMain.Names.Remove("preheat_elec_heater_voltage");
                        wbMain.Names.Remove("preheat_elec_heater_kw");
                        wbMain.Names.Remove("preheat_elec_heater_eat");
                        wbMain.Names.Remove("preheat_elec_heater_lat");
                        wbMain.Names.Remove("preheat_elec_heater_fla");
                        wbMain.Names.Remove("preheat_elec_heater_start");
                        wbMain.Names.Remove("preheat_elec_heater_end");


                        wbMain.Names.Remove("preheat_hwc_rows");
                        wbMain.Names.Remove("preheat_hwc_input_eat_db");
                        wbMain.Names.Remove("preheat_hwc_input_fluid_ent_temp");
                        wbMain.Names.Remove("preheat_hwc_input_fluid_lvg_temp");
                        wbMain.Names.Remove("preheat_hwc_output_total_capacity");
                        wbMain.Names.Remove("preheat_hwc_output_lat_db");
                        wbMain.Names.Remove("preheat_hwc_output_air_pd");
                        wbMain.Names.Remove("preheat_hwc_output_fluid_flow_rate");
                        wbMain.Names.Remove("preheat_hwc_start");
                        wbMain.Names.Remove("preheat_hwc_end");


                        wbMain.Names.Remove("hx_fp_core_summer_sensible_effect");
                        wbMain.Names.Remove("hx_fp_core_summer_latent_effect");
                        wbMain.Names.Remove("hx_fp_core_summer_total_effect");

                        wbMain.Names.Remove("hx_fp_core_winter_sensible_effect");
                        wbMain.Names.Remove("hx_fp_core_winter_latent_effect");
                        wbMain.Names.Remove("hx_fp_core_winter_total_effect");

                        wbMain.Names.Remove("hx_fp_core_summer_ra_ent_db");
                        wbMain.Names.Remove("hx_fp_core_summer_ra_ent_wb");
                        wbMain.Names.Remove("hx_fp_core_summer_ra_ent_rh");

                        wbMain.Names.Remove("hx_fp_core_winter_ra_ent_db");
                        wbMain.Names.Remove("hx_fp_core_winter_ra_ent_wb");
                        wbMain.Names.Remove("hx_fp_core_winter_ra_ent_rh");

                        wbMain.Names.Remove("hx_fp_core_summer_ra_lvg_db");
                        wbMain.Names.Remove("hx_fp_core_summer_ra_lvg_wb");
                        wbMain.Names.Remove("hx_fp_core_summer_ra_lvg_rh");

                        wbMain.Names.Remove("hx_fp_core_winter_ra_lvg_db");
                        wbMain.Names.Remove("hx_fp_core_winter_ra_lvg_wb");
                        wbMain.Names.Remove("hx_fp_core_winter_ra_lvg_rh");

                        wbMain.Names.Remove("hx_fp_core_summer_sa_ent_db");
                        wbMain.Names.Remove("hx_fp_core_summer_sa_ent_wb");
                        wbMain.Names.Remove("hx_fp_core_summer_sa_ent_rh");

                        wbMain.Names.Remove("hx_fp_core_winter_sa_ent_db");
                        wbMain.Names.Remove("hx_fp_core_winter_sa_ent_wb");
                        wbMain.Names.Remove("hx_fp_core_winter_sa_ent_rh");

                        wbMain.Names.Remove("hx_fp_core_summer_sa_lvg_db");
                        wbMain.Names.Remove("hx_fp_core_summer_sa_lvg_wb");
                        wbMain.Names.Remove("hx_fp_core_summer_sa_lvg_rh");

                        wbMain.Names.Remove("hx_fp_core_winter_sa_lvg_db");
                        wbMain.Names.Remove("hx_fp_core_winter_sa_lvg_wb");
                        wbMain.Names.Remove("hx_fp_core_winter_sa_lvg_rh");
                        wbMain.Names.Remove("hx_fp_start");
                        wbMain.Names.Remove("hx_fp_end");


                        wbMain.Names.Remove("cooling_cwc_rows");
                        wbMain.Names.Remove("cooling_cwc_input_eat_db");
                        wbMain.Names.Remove("cooling_cwc_input_eat_wb");
                        wbMain.Names.Remove("cooling_cwc_input_fluid_ent_temp");
                        wbMain.Names.Remove("cooling_cwc_input_fluid_lvg_temp");
                        wbMain.Names.Remove("cooling_cwc_output_total_capacity");
                        wbMain.Names.Remove("cooling_cwc_output_lat_db");
                        wbMain.Names.Remove("cooling_cwc_output_lat_wb");
                        wbMain.Names.Remove("cooling_cwc_output_air_pd");
                        wbMain.Names.Remove("cooling_cwc_output_fluid_flow_rate");
                        wbMain.Names.Remove("cooling_cwc_start");
                        wbMain.Names.Remove("cooling_cwc_end");

                        wbMain.Names.Remove("cooling_dx_rows");
                        wbMain.Names.Remove("cooling_dx_input_eat_db");
                        wbMain.Names.Remove("cooling_dx_input_eat_wb");
                        wbMain.Names.Remove("cooling_dx_input_ref_suction_temp");
                        wbMain.Names.Remove("cooling_dx_input_ref_liquid_temp");
                        wbMain.Names.Remove("cooling_dx_input_ref_superheat_temp");
                        wbMain.Names.Remove("cooling_dx_output_total_capacity");
                        wbMain.Names.Remove("cooling_dx_output_lat_db");
                        wbMain.Names.Remove("cooling_dx_output_lat_wb");
                        wbMain.Names.Remove("cooling_dx_output_air_pd");
                        wbMain.Names.Remove("cooling_dx_output_internal_volume");
                        wbMain.Names.Remove("cooling_dx_start");
                        wbMain.Names.Remove("cooling_dx_end");

                        wbMain.Names.Remove("heating_elec_heater_control_type");
                        wbMain.Names.Remove("heating_elec_heater_voltage");
                        wbMain.Names.Remove("heating_elec_heater_kw");
                        wbMain.Names.Remove("heating_elec_heater_eat");
                        wbMain.Names.Remove("heating_elec_heater_lat");
                        wbMain.Names.Remove("heating_elec_heater_fla");
                        wbMain.Names.Remove("heating_elec_heater_start");
                        wbMain.Names.Remove("heating_elec_heater_end");

                        wbMain.Names.Remove("heating_hwc_rows");
                        wbMain.Names.Remove("heating_hwc_input_eat_db");
                        wbMain.Names.Remove("heating_hwc_input_fluid_ent_temp");
                        wbMain.Names.Remove("heating_hwc_input_fluid_lvg_temp");
                        wbMain.Names.Remove("heating_hwc_output_total_capacity");
                        wbMain.Names.Remove("heating_hwc_output_lat_db");
                        wbMain.Names.Remove("heating_hwc_output_air_pd");
                        wbMain.Names.Remove("heating_hwc_output_fluid_flow_rate");
                        wbMain.Names.Remove("heating_hwc_start");
                        wbMain.Names.Remove("heating_hwc_end");


                        wsMain.Protection.IsProtected = false;
                        wsMain.Protection.AllowSelectLockedCells = false;
                        ExcelPkg.SaveAs(new FileInfo(HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderTempFiles + "\\" + strOutputExcelFileName)));

                        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                        response.ClearContent();
                        response.Clear();
                        response.ContentType = "application/vnd.ms-excel";
                        response.AddHeader("Content-Disposition", "attachment; filename=\"" + strOutputExcelFileName + "\";");
                        response.TransmitFile(HttpContext.Current.Server.MapPath("~/" + ClsGV.strFolderTempFiles + "\\" + strOutputExcelFileName));
                        response.Flush();
                        response.End();
                    }
                }
            }
            else
            {
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", ClsAlert.get_sbMessage("No jobs available").ToString());
            }
        }
        #endregion
    }
}