using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using iTextSharp.text.html;

namespace Oxygen8SelectorServer.Models
{
    public class ClsSelectionOutputPDF
    {
        #region Cover Page
        public static PdfPTable get_pdfPtblCoverPage(int _intJobID)
        {
            ClsProjectInfo objProjInfo = new ClsProjectInfo(_intJobID);

            PdfPTable pdfPtblTitle = get_pdfPtblSettingHeader(2, 0);
            //PdfPTable pdfPtblFooter = get_pdfPtblSettingHeader(2, 0);
            //PdfPTable pdfPtblStdFeatCol_1 = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblStdFeatCol_1 = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblStdFeatCol_2 = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblStdFeatCol_3 = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblStdFeatGroup = get_pdfPtblContent(7, 0);

            pdfPtblStdFeatGroup.KeepTogether = true;


            float[] widths = new float[] { 4f, 4.5f };
            pdfPtblTitle.SetWidths(widths);
            //pdfPtblFooter.SetWidths(widths);

            widths = new float[] { 3f };
            pdfPtblStdFeatCol_1.SetWidths(widths);

            widths = new float[] { 1f };
            pdfPtblStdFeatCol_2.SetWidths(widths);

            widths = new float[] { 5f };
            pdfPtblStdFeatCol_3.SetWidths(widths);

            widths = new float[] { 0.25f, 3f, 1f, 2f, 1f, 5.0f, 0.25f };
            pdfPtblStdFeatGroup.SetWidths(widths);

            PdfPTable pdfPTbl = new PdfPTable(1);
            pdfPTbl.KeepTogether = true;
            pdfPTbl.DefaultCell.Border = Rectangle.NO_BORDER;
            pdfPTbl.HorizontalAlignment = 1;    //0=Left, 1=Centre, 2=Right
            widths = new float[] { 90f };
            pdfPTbl.SetWidths(widths);

            iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            Image img;
            //Image img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/logo_oxygen_8.jpg"));
            //img.ScaleAbsolute(200f, 16f);
            //img.Alignment = Element.ALIGN_MIDDLE;
            //imgCell1.Border = 0;
            //imgCell1.AddElement(new Chunk(img, 0, 0));

            //pdfPtblTitle.DefaultCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            //Color myColor = WebColors.GetRGBColor("#003366");
            //pdfPtblTitle.DefaultCell.BackgroundColor = myColor;
            //pdfPtblTitle.AddCell(imgCell1);

            //pdfPtblTitle.AddCell(get_pdfPcellCustom_1(objCont.objCGeneral.get_strUnitModel() + " SUBMITTAL", 1, 22f, 2, 1, 0, 0, 1));
            ////pdfPtblTitle.AddCell(objCont.objCGeneral.get_strUnitModel() + " SUBMITTAL");
            ////pdfPtblTitle.AddCell(pdfPtblEmpty);
            //pdfPtblFooter.AddCell(get_pdfPcellCustom_1("www.OXYGEN8.ca", 2, 15f, 2, 0, 0, 0, 1));



            //--------------------------------------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------------------------------------
            //img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/img_ahri.png"));
            //imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            //img.ScaleAbsolute(140f, 90f);
            //img.Alignment = Element.ALIGN_LEFT;
            //imgCell1.Border = 0;
            //imgCell1.AddElement(new Chunk(img, -50, 0));
            //pdfPtblStdFeatCol_1.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfPtblStdFeatCol_1.AddCell(imgCell1);

            //img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/img_etl_c.png"));
            //imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            //img.ScaleAbsolute(70f, 70f);
            //imgCell1.Border = 0;
            //imgCell1.AddElement(new Chunk(img, 0, 0));

            //pdfPtblStdFeatCol_2.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfPtblStdFeatCol_2.AddCell(imgCell1);


            //img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/img_unit.png"));
            //imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            //img.ScaleAbsolute(240f, 190f);
            //imgCell1.Border = 0;
            //imgCell1.AddElement(new Chunk(img, 0, 0));

            //pdfPtblStdFeatCol_3.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfPtblStdFeatCol_3.AddCell(imgCell1);
            //--------------------------------------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------------------------------------



            //widths = new float[] { 4f, 5f, 4f, 4f };

            //pdfPtblStdFeatGroup.AddCell(pdfPtblStdFeatCol_1);
            pdfPtblStdFeatGroup.DefaultCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            pdfPtblStdFeatGroup.AddCell(pdfPtblEmpty);
            pdfPtblStdFeatGroup.AddCell(pdfPtblStdFeatCol_1);
            pdfPtblStdFeatGroup.AddCell(pdfPtblEmpty);
            pdfPtblStdFeatGroup.AddCell(pdfPtblStdFeatCol_2);
            pdfPtblStdFeatGroup.AddCell(pdfPtblEmpty);
            pdfPtblStdFeatGroup.AddCell(pdfPtblStdFeatCol_3);
            pdfPtblStdFeatGroup.AddCell(pdfPtblEmpty);

            //pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 70f));
            //pdfPTbl.AddCell(get_pdfPcellCustom(objCont.objCJobInfo.get_strJobName().ToUpper(), 0, 22, 1, 1, 0, 0, 0f, 0f));
            //pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            //pdfPTbl.AddCell(get_pdfPcellCustom("Revision #: " + objCont.objCJobInfo.get_intRevisionNo().ToString(), 0, 18, 1, 0, 0, 0, 0f, 0f));
            //pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            //pdfPTbl.AddCell(get_pdfPcellCustom(objCont.objCJobInfo.get_strCreatedDate(), 0, 18, 1, 0, 0, 0, 0f, 0f));
            //pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            //pdfPTbl.AddCell(get_pdfPcellCustom(objCont.objCJobInfo.get_strRevisedDate(), 0, 18, 1, 0, 0, 0, 0f, 0f));
            //pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            //pdfPTbl.AddCell(get_pdfPcellCustom(objCont.objCJobInfo.get_strCompanyName() != "" ? objCont.objCJobInfo.get_strCompanyName() : objCont.objCJobInfo.get_strRepName(), 0, 18, 1, 0, 0, 0, 0f, 0f));
            //pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            //pdfPTbl.AddCell(get_pdfPcellCustom(objCont.objCJobInfo.get_strContactName() != "" ? objCont.objCJobInfo.get_strContactName() : objCont.objCJobInfo.get_strRepContactName(), 0, 18, 1, 0, 0, 0, 0f, 0f));

            pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 70f));
            pdfPTbl.AddCell(get_pdfPcellCustom(objProjInfo.strJobName.ToUpper(), 0, 22, 1, 1, 0, 0, 0f, 0f));
            pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            pdfPTbl.AddCell(get_pdfPcellCustom("Revision #: " + objProjInfo.intRevisionNo.ToString(), 0, 18, 1, 0, 0, 0, 0f, 0f));
            pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            pdfPTbl.AddCell(get_pdfPcellCustom("Created Date: " + objProjInfo.strCreatedDate, 0, 18, 1, 0, 0, 0, 0f, 0f));
            pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            pdfPTbl.AddCell(get_pdfPcellCustom("Revised Date: " + objProjInfo.strRevisedDate, 0, 18, 1, 0, 0, 0, 0f, 0f));
            //pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            //pdfPTbl.AddCell(get_pdfPcellCustom("Company Name: " + (objProjInfo.strCompanyName != "" ? objProjInfo.strCompanyName : objProjInfo.strRepName), 0, 18, 1, 0, 0, 0, 0f, 0f));
            //pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            //pdfPTbl.AddCell(get_pdfPcellCustom("Contact Name: " + (objProjInfo.strContactName != "" ? objProjInfo.strContactName : objProjInfo.get_strRepContactName()), 0, 18, 1, 0, 0, 0, 0f, 0f));
            pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            pdfPTbl.AddCell(get_pdfPcellCustom("Company Name: " + (objProjInfo.strCompanyName != "" ? objProjInfo.strCompanyName : objProjInfo.strCompanyNameNew), 0, 18, 1, 0, 0, 0, 0f, 0f));
            pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 15f));
            pdfPTbl.AddCell(get_pdfPcellCustom("Contact Name: " + (objProjInfo.strContactName != "" ? objProjInfo.strContactName : objProjInfo.strContactNameNew), 0, 18, 1, 0, 0, 0, 0f, 0f));


            pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 1, 100f));
            pdfPTbl.AddCell(get_pdfPcellCustom("SELECTION ONLY", 0, 16, 1, 0, 0, 0, 0f, 0f));
            pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 1, 2f));
            pdfPTbl.AddCell(get_pdfPcellCustom("Not for Submittal. Contact Oxygen8 for final submittals", 0, 14, 1, 0, 0, 0, 0f, 0f));
            pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 2f));
            pdfPTbl.AddCell(get_pdfPcellCustom("prior to ordering.", 0, 14, 1, 0, 0, 0, 0f, 0f));

            //pdfPTbl.AddCell(get_pdfPCellEmpty("   ", 5, 170f));

            //pdfPTbl.AddCell(pdfPtblStdFeatGroup);

            //pdfPTbl.AddCell(pdfPtblFooter);

            return pdfPTbl;
        }
        #endregion


        #region Schedule
        public static List<PdfPTable> get_lst_lstPdfPtblSchedule(ClsContElements objCont)
        {
            PdfPTable pdfPtblTitle = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblTag = get_pdfPtblContent(1, 0);
            List<PdfPTable> lst_pdfPTable = new List<PdfPTable>();
            ClsOutput objOut = new ClsOutput(objCont);


            pdfPtblTitle.AddCell(get_pdfPcellCustom("Performance", 1, 14f, 0, 1, 1, 0, 0f, 0f));
            pdfPtblTag.AddCell(get_pdfPcellCustom("Unit Tag: " + objCont.objCGeneral.strTag, 1, 13f, 0, 1, 0, 0, 0f, 0f));

            lst_pdfPTable.Add(pdfPtblTitle);
            lst_pdfPTable.Add(pdfPtblTag);


            if (objCont.objCGeneral != null)
            {
                lst_pdfPTable.Add(getOutputUnitDetails(objOut.objOutputTables));
                lst_pdfPTable.Add(getOutputElectricalRequirements(objCont.objCGeneral, objOut.objOutputTables));
            }


            if (objCont.objCPreheatElecHeater != null)
            {
                lst_pdfPTable.Add(getOutputPreheatElecHeater(objCont.objCGeneral, objOut.objOutputTables));
            }



            if (objCont.objCHX_CORE != null)
            {
                lst_pdfPTable.Add(getOutputFixedPlateCORE(objOut.objOutputTables));
            }




            if (objCont.objCHeatingElecHeater != null)
            {
                lst_pdfPTable.Add(getOutputHeatingElecHeater(objOut.objOutputTables));
            }


            return lst_pdfPTable;
        }
        #endregion



        public static PdfPTable get_pdfPtblModelImageOld(ClsContElements objCont, int _intModelID)
        {
            PdfPTable pdfPtblTB_1_1 = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblTB_1_2 = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblTB_1_3 = get_pdfPtblContent(1, 0);

            PdfPTable pdfPtblTB_2_1 = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblTB_2_2 = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblTB_2_3 = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblTB_2_4 = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblDwg = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblTitleBlock_1 = get_pdfPtblContent(3, 0);
            PdfPTable pdfPtblTitleBlock_2 = get_pdfPtblContent(3, 0);

            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblStdFeatGroup = get_pdfPtblContent(7, 0);

            pdfPtblStdFeatGroup.KeepTogether = true;


            float[] widths = new float[] { 4f, 4.5f };

            widths = new float[] { 4f };
            pdfPtblDwg.SetWidths(widths);

            widths = new float[] { 1.5f, 2.5f, 3.5f };
            pdfPtblTitleBlock_1.SetWidths(widths);

            widths = new float[] { 0.75f, 3.25f, 3.5f };
            pdfPtblTitleBlock_2.SetWidths(widths);

            widths = new float[] { 3f, 0.15f, 3.5f, 0.15f, 1.5f, 0.15f, 3f };
            pdfPtblStdFeatGroup.SetWidths(widths);


            PdfPTable pdfPTbl = new PdfPTable(1);
            pdfPTbl.DefaultCell.Border = Rectangle.NO_BORDER;
            pdfPTbl.HorizontalAlignment = 1;    //0=Left, 1=Centre, 2=Right
            widths = new float[] { 90f };
            pdfPTbl.SetWidths(widths);

            iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            Image img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/logo_oxygen_8.jpg"));
            img.ScaleAbsolute(140f, 10f);
            imgCell1.Border = 0;
            imgCell1.AddElement(new Chunk(img, 0, 0));

            pdfPtblTB_1_1.AddCell(get_pdfPcellCustom_2("O  X  Y  G  E  N  8", 1, 3, 12f, 1, 5, 1, 0, 1, 5f, 5f));

            pdfPtblTB_1_2.AddCell(get_pdfPcellCustom_2("Drawn By:", 1, 1, 11f, 0, 4, 0, 0, 1, 0f, 5f));
            pdfPtblTB_1_2.AddCell(get_pdfPcellCustom_2("Approved By:", 1, 1, 11f, 0, 4, 0, 0, 1, 0f, 5f));
            pdfPtblTB_1_2.AddCell(get_pdfPcellCustom_2("Date:", 1, 1, 11f, 0, 4, 0, 0, 1, 0f, 5f));

            pdfPtblTB_1_3.AddCell(get_pdfPcellCustom_2("Name:", 1, 3, 11f, 0, 4, 0, 0, 1, 0f, 5f));

            pdfPtblTitleBlock_1.AddCell(get_pdfPCell(pdfPtblTB_1_1, 1));
            pdfPtblTitleBlock_1.AddCell(get_pdfPCell(pdfPtblTB_1_2, 1));
            pdfPtblTitleBlock_1.AddCell(get_pdfPCell(pdfPtblTB_1_3, 1));


            pdfPtblTB_2_1.AddCell(get_pdfPcellCustom_2("Scale:", 1, 2, 11f, 0, 4, 0, 0, 1, 0f, 20f));

            pdfPtblTB_2_2.AddCell(get_pdfPcellCustom_2("Pieces:", 1, 1, 11f, 0, 4, 0, 0, 1, 0f, 5f));
            pdfPtblTB_2_2.AddCell(get_pdfPcellCustom_2("Weight:", 1, 1, 11f, 0, 4, 0, 0, 1, 0f, 5f));
            pdfPtblTB_2_2.AddCell(get_pdfPcellCustom_2("Material:", 2, 1, 11f, 0, 4, 0, 0, 1, 0f, 5f));

            pdfPtblTB_2_3.AddCell(get_pdfPcellCustom_2("Drawing number:", 1, 2, 11f, 0, 4, 0, 0, 1, 0f, 5f));


            pdfPtblTitleBlock_2.AddCell(get_pdfPCell(pdfPtblTB_2_1, 1));
            pdfPtblTitleBlock_2.AddCell(get_pdfPCell(pdfPtblTB_2_2, 1));
            pdfPtblTitleBlock_2.AddCell(get_pdfPCell(pdfPtblTB_2_3, 1));
            //pdfPtblTitleBlock_1.AddCell(pdfPtblTB_2_4);


            DataTable dtModel = ClsDB.get_dtByID(ClsDBT.strSelNovaUnitModel, _intModelID);
            string strPicName = "";

            if (dtModel.Rows.Count > 0)
            {
                strPicName = "Images/" + dtModel.Rows[0]["image_name"].ToString() + ".jpg";
            }

            img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath(strPicName));
            imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            //img.ScaleAbsolute(140f, 125f);
            img.ScaleToFit(550f, 450f);
            img.SpacingAfter = 500f;

            imgCell1.Border = 0;
            imgCell1.AddElement(new Chunk(img, 0, 0));

            pdfPtblDwg.AddCell(get_pdfPCellEmpty("   ", 2, 60f));
            pdfPtblDwg.AddCell(get_pdfPcellCustom("      DIMENSIONS", 1, 12f, 0, 1, 0, 0, 0f, 0f));
            pdfPtblDwg.AddCell(get_pdfPCellEmpty("   ", 2, 80f));
            pdfPtblDwg.AddCell(imgCell1);
            pdfPtblDwg.AddCell(get_pdfPCellEmpty("   ", 2, 80f));

            pdfPtblStdFeatGroup.AddCell(get_pdfPCell(pdfPtblDwg, 7));
            //pdfPtblStdFeatGroup.AddCell(get_pdfPCell(pdfPtblTitleBlock, 7));

            pdfPTbl.AddCell(get_pdfPCell(pdfPtblStdFeatGroup, 1));
            pdfPTbl.AddCell(get_pdfPCell(pdfPtblTitleBlock_1, 1));
            pdfPTbl.AddCell(get_pdfPCell(pdfPtblTitleBlock_2, 1));

            return pdfPTbl;
        }


        #region Model Image
        public static PdfPTable get_pdfPtblModelImage(int _intJobID, int _intUnitNo)
        {
            PdfPTable pdfPtblDim = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblTitle = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblDwg = get_pdfPtblContent(3, 0);
            PdfPTable pdfPtblTitleBlock = get_pdfPtblContent(5, 1);
            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(1, 0);


            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 2f, 6f };
            pdfPtblTitle.SetWidths(widths);

            widths = new float[] { 1f, 4f };
            pdfPtblDim.SetWidths(widths);

            widths = new float[] { 0.1f, 4f, 0.1f };
            pdfPtblDwg.SetWidths(widths);

            widths = new float[] { 1f, 1f, 1.3f, 2f, 3f };
            pdfPtblTitleBlock.SetWidths(widths);

            widths = new float[] { 5f };
            pdfPtblGroup.SetWidths(widths);


            //PdfPTable pdfPTbl = new PdfPTable(1);
            //pdfPTbl.HorizontalAlignment = 1;    //0=Left, 1=Centre, 2=Right
            //pdfPTbl.DefaultCell.Border = Rectangle.BOX;
            //pdfPTbl.WidthPercentage = 50;



            //pdfPTbl.KeepTogether = true;

            //pdfPtblTitleBlock.AddCell(get_pdfPcellCustom_2("OXYGEN 8", 2, 2, 9f, 0, 1, 1, 0, 0f, 0f));
            //pdfPtblTitleBlock.AddCell(get_pdfPcellCustom_2("Drawn By:", 1, 1, 9f, 0, 1, 1, 0, 0f, 0f));
            //pdfPtblTitleBlock.AddCell(get_pdfPcellCustom_2(":", 1, 1, 9f, 0, 1, 1, 0, 0f, 0f));
            //pdfPtblTitleBlock.AddCell(get_pdfPcellCustom_2("Name:", 1, 3, 9f, 0, 1, 1, 0, 0f, 0f));
            //pdfPtblTitleBlock.AddCell(get_pdfPcellCustom_2("Approved By:", 1, 1, 9f, 0, 1, 1, 0, 0f, 0f));
            //pdfPtblTitleBlock.AddCell(get_pdfPcellCustom_2("Date:", 1, 1, 9f, 0, 1, 1, 0, 0f, 0f));
            //pdfPtblTitleBlock.AddCell(get_pdfPcellCustom_2("Scale:", 1, 2, 9f, 0, 1, 1, 0, 0f, 0f));
            //pdfPtblTitleBlock.AddCell(get_pdfPcellCustom_2("Pieces:", 2, 1, 9f, 0, 1, 1, 0, 0f, 0f));
            //pdfPtblTitleBlock.AddCell(get_pdfPcellCustom_2("Weight:", 1, 1, 9f, 0, 1, 1, 0, 0f, 0f));
            //pdfPtblTitleBlock.AddCell(get_pdfPcellCustom_2("Drawing number:", 1, 2, 9f, 0, 1, 1, 0, 0f, 0f));
            //pdfPtblTitleBlock.AddCell(get_pdfPcellCustom_2("Material:", 3, 1, 9f, 0, 1, 1, 0, 0f, 0f));


            string strPicName = "Images/pic_no_image.jpg";

            DataTable dtUnitDwg = ClsDB.GetSavedUnitWithDetails(_intJobID, _intUnitNo);
            DataRow dr = dtUnitDwg.Rows[0];

            string strImageName = ClsGV.strLocDrawings + "/O28_NOVA_M_" + dr["unit_model_dwg_code"].ToString() + "_" + dr["fan_placement_dwg_code"].ToString() + "_S1_" +
                                        //dr["location_dwg_code"].ToString() + "_" + dr["orientation_dwg_code"].ToString() + "_" +
                                        "1_" + dr["orientation_dwg_code"].ToString() + "_" +
                                        dr["opening_sa_dwg_code"].ToString() + "_" + dr["opening_ea_dwg_code"].ToString() + "_" +
                                        dr["opening_ra_dwg_code"].ToString() + "_" + dr["opening_oa_dwg_code"].ToString() + ".jpg";


            DataTable dtModel = ClsDB.get_dtByID(ClsDBT.strSelNovaUnitModel, Convert.ToInt32(dtUnitDwg.Rows[0]["unit_model_id"]));



            //if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(strImageName)))
            //{
            //    strPicName =  strImageName;
            //}
            //else 

            if (dtModel.Rows.Count > 0)
            {
                //GenerateDrawing();
                //imgDrawing.ImageUrl = "/" + ClsGV.strFolderTempFiles + "/" + Request.QueryString[ClsSV._intUserID].ToString() + "_Drawing.bmp";
                //imgDrawing.DataBind();

                strPicName = "Images/" + dtModel.Rows[0]["image_name"].ToString() + ".jpg";
            }



            iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            //Rectangle pageSize = document.PageSize;

            if (strPicName != "")
            {
                Image img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath(strPicName));
                //img.SetAbsolutePosition(document.PageSize.Width - 180f, document.PageSize.Height - 60f);
                img.ScaleAbsolute(780f, 580f);
                //img.ScaleAbsolute(0f, 200f);
                //img.ScaleAbsoluteHeight(200f);
                //img.ScalePercent(25f);
                //img.ScaleToFit(650f, 700f);
                img.RotationDegrees = 90f;
                //img.SpacingBefore = 250f;
                //img.SpacingAfter = 250f;
                imgCell1.Border = 0;
                imgCell1.HorizontalAlignment = Element.ALIGN_LEFT;
                imgCell1.VerticalAlignment = Element.ALIGN_BOTTOM;
                imgCell1.AddElement(new Chunk(img, 0, 0));
                //imgCell1.Colspan = 4;

                //pdfPtblTitle.AddCell(get_pdfPcellCustom("Dimension", 2, 14f, 0, 1, 1, 0, 0f, 0f));

                //pdfPtblDwg.AddCell(get_pdfPcellCustom("Dimension", 1, 14f, 0, 1, 1, 1, 0));


                pdfPtblDwg.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPtblDwg.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                pdfPtblDwg.AddCell(get_pdfPCellEmpty("  ", 1, 5f));
                pdfPtblDwg.AddCell(imgCell1);
                pdfPtblDwg.AddCell(get_pdfPCellEmpty("  ", 1, 5f));

                //pdfPTbl.AddCell(get_pdfPCellNoBorder("", 1, 9f, 1, 0));
                //pdfPTbl.AddCell(get_pdfPCellNoBorder("", 1, 9f, 1, 0));
            }

            //pdfPtblDim.AddCell(get_pdfPcellHeader("Dimension", 5));
            //pdfPtblDim.AddCell(get_pdfPCellEmpty("   ", 2));
            //pdfPtblDim.AddCell(pdfPtblTitle);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(imgCell1);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(pdfPtblEmpty);
            //pdfPtblDim.AddCell(get_pdfPCellEmpty("   ", 2));

            pdfPtblGroup.AddCell(pdfPtblDwg);

            return pdfPtblGroup;
        }
        #endregion


        #region Model Image
        public static PdfPTable get_pdfPtblModelImageInternal(DataTable _dtDwgList)
        {
            PdfPTable pdfPtblDim = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblDwg = get_pdfPtblContent(3, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(1, 0);


            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 2f, 6f };
            widths = new float[] { 1f, 4f };
            pdfPtblDim.SetWidths(widths);

            widths = new float[] { 0.1f, 4f, 0.1f };
            pdfPtblDwg.SetWidths(widths);


            widths = new float[] { 5f };
            pdfPtblGroup.SetWidths(widths);


            iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            //Rectangle pageSize = document.PageSize;


            for (int i = 0; i < _dtDwgList.Rows.Count; i++)
            {
                string strPicPathAndName = _dtDwgList.Rows[i]["DwgPathAndFile"].ToString();

                if (File.Exists(HttpContext.Current.Server.MapPath(strPicPathAndName)))
                {
                    //get_pdfPtblDwg(strPicPathAndName);
                    pdfPtblGroup.AddCell(get_pdfPtblDwg(strPicPathAndName));
                    //pdfPtblDwg.DeleteBodyRows();
                }
            }


            return pdfPtblGroup;
        }



        public static PdfPTable get_pdfPtblDwg(string strPicPathAndName)
        {
            PdfPTable pdfPtblDwg = get_pdfPtblContent(3, 0);



            float[] widths = new float[] { 2f, 6f };

            widths = new float[] { 0.1f, 4f, 0.1f };
            pdfPtblDwg.SetWidths(widths);


            iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            //Rectangle pageSize = document.PageSize;


            if (File.Exists(HttpContext.Current.Server.MapPath(strPicPathAndName)))
            {
                Image img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath(strPicPathAndName));
                //img.SetAbsolutePosition(document.PageSize.Width - 180f, document.PageSize.Height - 60f);
                img.ScaleAbsolute(780f, 580f);
                //img.ScaleAbsolute(0f, 200f);
                //img.ScaleAbsoluteHeight(200f);
                //img.ScalePercent(25f);
                //img.ScaleToFit(650f, 700f);
                img.RotationDegrees = 90f;
                //img.SpacingBefore = 250f;
                //img.SpacingAfter = 250f;
                imgCell1.Border = 0;
                imgCell1.HorizontalAlignment = Element.ALIGN_LEFT;
                imgCell1.VerticalAlignment = Element.ALIGN_BOTTOM;
                imgCell1.AddElement(new Chunk(img, 0, 0));
                //imgCell1.Colspan = 4;

                //pdfPtblTitle.AddCell(get_pdfPcellCustom("Dimension", 2, 14f, 0, 1, 1, 0, 0f, 0f));

                //pdfPtblDwg.AddCell(get_pdfPcellCustom("Dimension", 1, 14f, 0, 1, 1, 1, 0));


                pdfPtblDwg.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPtblDwg.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                pdfPtblDwg.AddCell(get_pdfPCellEmpty("  ", 1, 5f));
                pdfPtblDwg.AddCell(imgCell1);
                pdfPtblDwg.AddCell(get_pdfPCellEmpty("  ", 1, 5f));

                //pdfPTbl.AddCell(get_pdfPCellNoBorder("", 1, 9f, 1, 0));
                //pdfPTbl.AddCell(get_pdfPCellNoBorder("", 1, 9f, 1, 0));


            }

            return pdfPtblDwg;
        }
        #endregion



        #region Cutsheets
        public static PdfPTable get_pdfPtblCutsheets(DataTable _dtCutsheetList)
        {
            PdfPTable pdfPtblDim = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblDwg = get_pdfPtblContent(3, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(1, 0);


            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 2f, 6f };
            widths = new float[] { 1f, 4f };
            pdfPtblDim.SetWidths(widths);

            widths = new float[] { 0.1f, 4f, 0.1f };
            pdfPtblDwg.SetWidths(widths);


            widths = new float[] { 5f };
            pdfPtblGroup.SetWidths(widths);


            iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            //Rectangle pageSize = document.PageSize;


            for (int i = 0; i < _dtCutsheetList.Rows.Count; i++)
            {
                string strPicPathAndName = _dtCutsheetList.Rows[i]["DwgPathAndFile"].ToString();

                if (File.Exists(HttpContext.Current.Server.MapPath(strPicPathAndName)))
                {
                    //get_pdfPtblDwg(strPicPathAndName);
                    pdfPtblGroup.AddCell(get_pdfPtblDwg(strPicPathAndName));
                    //pdfPtblDwg.DeleteBodyRows();
                }
            }



            return pdfPtblGroup;
        }
        #endregion


        //Submittal Outputs--------------------------------------------------------------------------------
        #region Out Unit Details & Elec Heater
        private static PdfPTable getOutputUnitDetails(ClsOutputData _objOut)
        {
            PdfPTable pdfPtblHeader = get_pdfPtblSettingHeader(1, 0);
            PdfPTable pdfPtblUnitDetails_1 = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblUnitDetails_2 = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblUnitDetails = get_pdfPtblContent(2, 0);

            PdfPTable pdfPtblUnitElecData = get_pdfPtblContent(2, 0);
            //PdfPTable pdfPtblLeaving = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(5, 0);

            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 4f, 6f };
            pdfPtblUnitDetails_1.SetWidths(widths);
            pdfPtblUnitDetails_2.SetWidths(widths);

            widths = new float[] { 4f, 4f };
            pdfPtblUnitDetails.SetWidths(widths);

            widths = new float[] { 4f, 2.5f };
            pdfPtblUnitElecData.SetWidths(widths);

            //widths = new float[] { 4f, 2.5f };
            //pdfPtblLeaving.SetWidths(widths);

            widths = new float[] { 5.5f, 0.25f, 2f, 0.25f, 4f };
            pdfPtblGroup.SetWidths(widths);

            //string strSection = ClsTS.get_strItem(ClsDB.get_dt(ClsDBT.strSelComponent), obj.get_intComponentID()).ToUpper() + " (" + obj.get_strType() + ")";


            //pdfPtblHeader.AddCell(get_pdfPcellHeader("Prheat ElecHeater", 1));


            //pdfPtblUnitDetails_1.AddCell(get_pdfPCell("Unit Details", 2, 0));
            for (int i = 0; i < _objOut.dtUnitDetails_1.Rows.Count; i++)
            {
                pdfPtblUnitDetails_1.AddCell(get_pdfPCellNoBorder(_objOut.dtUnitDetails_1.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblUnitDetails_1.AddCell(get_pdfPCellNoBorder(_objOut.dtUnitDetails_1.Rows[i]["cValue"].ToString(), 0, 0, 0));
            }

            for (int i = 0; i < _objOut.dtUnitDetails_2.Rows.Count; i++)
            {
                pdfPtblUnitDetails_2.AddCell(get_pdfPCellNoBorder(_objOut.dtUnitDetails_2.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblUnitDetails_2.AddCell(get_pdfPCellNoBorder(_objOut.dtUnitDetails_2.Rows[i]["cValue"].ToString(), 0, 0, 0));
            }


            //pdfPtblUnitElecData.AddCell(get_pdfPCell("Electrical Data", 2, 0));
            //for (int i = 0; i < _objOut.dtUnitElecData.Rows.Count; i++)
            //{
            //    pdfPtblUnitElecData.AddCell(get_pdfPCellNoBorder(_objOut.dtUnitElecData.Rows[i]["cLabel"].ToString(), 0, 0, 0));
            //    pdfPtblUnitElecData.AddCell(get_pdfPCellNoBorder(_objOut.dtUnitElecData.Rows[i]["cValue"].ToString(), 0, 0, 0));
            //}

            pdfPtblUnitDetails.AddCell(get_pdfPCell("Unit Details", 2, 0));
            pdfPtblUnitDetails.AddCell(pdfPtblUnitDetails_1);
            pdfPtblUnitDetails.AddCell(pdfPtblUnitDetails_2);

            //widths = new float[] { 4f, 5f, 4f, 4f };

            pdfPtblGroup.AddCell(get_pdfPcellHeader("Summary", 5));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 5f));
            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblUnitDetails, 5));
            //pdfPtblGroup.AddCell(pdfPtblEmpty);
            //pdfPtblGroup.AddCell(pdfPtblEmpty);
            //pdfPtblGroup.AddCell(pdfPtblEmpty);
            //pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblUnitElecData, 1));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 6f));
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 5f));
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 5f));

            //pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblLeaving));
            //pdfPtblGroup.AddCell(pdfPtblEmpty);
            //lst_pdfPtbl.Add(pdfPtblGroup);

            return pdfPtblGroup;
        }
        #endregion


        #region Out Electrical Requirements
        private static PdfPTable getOutputElectricalRequirements(ClsGeneral _objGen, ClsOutputData _objOut)
        {
            PdfPTable pdfPtblHeader = get_pdfPtblSettingHeader(1, 0);
            PdfPTable pdfPtblUnitElecData = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblPreheatElecHeater = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblCoolingDX = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblHeatingElecHeater = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblReheatElecHeater = get_pdfPtblContent(2, 0);

            //PdfPTable pdfPtblUnitElecData = get_pdfPtblContent(2, 0);
            //PdfPTable pdfPtblLeaving = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(9, 0);

            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 2.8f, 4f };
            pdfPtblUnitElecData.SetWidths(widths);
            pdfPtblPreheatElecHeater.SetWidths(widths);
            pdfPtblCoolingDX.SetWidths(widths);
            pdfPtblHeatingElecHeater.SetWidths(widths);
            pdfPtblReheatElecHeater.SetWidths(widths);

            widths = new float[] { 2f, 0.05f, 2f, 0.05f, 2f, 0.05f, 2f, 0.05f, 2f };
            pdfPtblGroup.SetWidths(widths);

            //string strSection = ClsTS.get_strItem(ClsDB.get_dt(ClsDBT.strSelComponent), obj.get_intComponentID()).ToUpper() + " (" + obj.get_strType() + ")";


            //pdfPtblHeader.AddCell(get_pdfPcellHeader("Prheat ElecHeater", 1));




            //pdfPtblUnitDetails_1.AddCell(get_pdfPCell("Unit Details", 2, 0));
            //pdfPtblUnitElecData.AddCell(get_pdfPCell("Unit", 2, 0)); 

            pdfPtblUnitElecData.AddCell(get_pdfPCell(_objOut.strOutElecReqUnitData, 2, 0));
            for (int i = 0; i < _objOut.dtElecReqUnitElecData.Rows.Count; i++)
            {
                pdfPtblUnitElecData.AddCell(get_pdfPCellNoBorder(_objOut.dtElecReqUnitElecData.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblUnitElecData.AddCell(get_pdfPCellNoBorder(_objOut.dtElecReqUnitElecData.Rows[i]["cValue"].ToString(), 0, 0, 0));
            }

            if (_objGen.intProductTypeID == ClsID.intProdTypeNovaID || _objGen.intProductTypeID == ClsID.intProdTypeVentumID)
            {

                pdfPtblPreheatElecHeater.AddCell(get_pdfPCell("Preheat Electric Heater", 2, 0));
                for (int i = 0; i < _objOut.dtElecReqPreheatElecHeater.Rows.Count; i++)
                {
                    pdfPtblPreheatElecHeater.AddCell(get_pdfPCellNoBorder(_objOut.dtElecReqPreheatElecHeater.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                    pdfPtblPreheatElecHeater.AddCell(get_pdfPCellNoBorder(_objOut.dtElecReqPreheatElecHeater.Rows[i]["cValue"].ToString(), 0, 0, 0));
                }

                pdfPtblHeatingElecHeater.AddCell(get_pdfPCell("Heating Electric Heater", 2, 0));
                for (int i = 0; i < _objOut.dtElecReqHeatingElecHeater.Rows.Count; i++)
                {
                    pdfPtblHeatingElecHeater.AddCell(get_pdfPCellNoBorder(_objOut.dtElecReqHeatingElecHeater.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                    pdfPtblHeatingElecHeater.AddCell(get_pdfPCellNoBorder(_objOut.dtElecReqHeatingElecHeater.Rows[i]["cValue"].ToString(), 0, 0, 0));
                }
            }


            pdfPtblGroup.AddCell(get_pdfPcellHeader("Electrical Requirements", 9));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 9, 5f));



            pdfPtblGroup.AddCell(get_pdfPCellNoBorder(_objOut.strElecReqQty.ToString(), 9, 0, 1));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 9, 5f));


            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblUnitElecData, 1));
            pdfPtblGroup.AddCell(pdfPtblEmpty);


            bool bolPreheatElecHeater = false;
            if (pdfPtblPreheatElecHeater.Rows.Count > 1)
            {
                bolPreheatElecHeater = true;
                pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblPreheatElecHeater, 1));
                pdfPtblGroup.AddCell(pdfPtblEmpty);
            }


            bool bolHeatingElecHeater = false;
            if (pdfPtblHeatingElecHeater.Rows.Count > 1)
            {
                bolHeatingElecHeater = true;
                pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblHeatingElecHeater, 1));
                pdfPtblGroup.AddCell(pdfPtblEmpty);
            }


            bool bolReheatElecHeater = false;
            if (pdfPtblReheatElecHeater.Rows.Count > 1)
            {
                bolReheatElecHeater = true;
                pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblReheatElecHeater, 1));
            }


            if (!bolPreheatElecHeater)
            {
                pdfPtblGroup.AddCell(pdfPtblEmpty);
                pdfPtblGroup.AddCell(pdfPtblEmpty);
            }


            if (!bolHeatingElecHeater)
            {
                pdfPtblGroup.AddCell(pdfPtblEmpty);
                pdfPtblGroup.AddCell(pdfPtblEmpty);
            }



            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 9, 5f));


            return pdfPtblGroup;
        }
        #endregion


        #region Out Preheat ElecHeater
        private static PdfPTable getOutputPreheatElecHeater(ClsGeneral _objGen, ClsOutputData _objOut)
        {
            PdfPTable pdfPtblHeader = get_pdfPtblSettingHeader(1, 0);
            PdfPTable pdfPtblData = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblNominalData = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblLeaving = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(5, 0);

            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 3f, 4f };
            pdfPtblData.SetWidths(widths);

            widths = new float[] { 4f, 2.5f };
            pdfPtblNominalData.SetWidths(widths);

            widths = new float[] { 4f, 2.5f };
            pdfPtblLeaving.SetWidths(widths);

            widths = new float[] { 4f, 0.25f, 2.5f, 0.25f, 2.5f };
            pdfPtblGroup.SetWidths(widths);

            //string strSection = ClsTS.get_strItem(ClsDB.get_dt(ClsDBT.strSelComponent), obj.get_intComponentID()).ToUpper() + " (" + obj.get_strType() + ")";


            //pdfPtblHeader.AddCell(get_pdfPcellHeader("Prheat ElecHeater", 1));


            pdfPtblData.AddCell(get_pdfPCell("Actual", 2, 0));
            for (int i = 0; i < _objOut.dtPreheatElecHeaterData.Rows.Count; i++)
            {
                if (Convert.ToInt32(_objOut.dtPreheatElecHeaterData.Rows[i]["cIsWarning"]) == 1)
                {
                    pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterData.Rows[i]["cLabel"].ToString(), 0, 0, 1, Color.RED));
                    pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterData.Rows[i]["cValue"].ToString(), 0, 0, 1, Color.RED));
                }
                else if (Convert.ToInt32(_objOut.dtPreheatElecHeaterData.Rows[i]["cIsBold"]) == 1)
                {
                    if (Convert.ToInt32(_objOut.dtPreheatElecHeaterData.Rows[i]["cIsMerged"]) == 1)
                    {
                        pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterData.Rows[i]["cLabel"].ToString(), 2, 0, 1));
                    }
                    else
                    {
                        pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterData.Rows[i]["cLabel"].ToString(), 0, 0, 1));
                        pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterData.Rows[i]["cValue"].ToString(), 0, 0, 1));
                    }
                }
                else
                {
                    pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterData.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                    pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterData.Rows[i]["cValue"].ToString(), 0, 0, 0));
                }
            }


            if (_objGen.intProductTypeID == ClsID.intProdTypeNovaID || _objGen.intProductTypeID == ClsID.intProdTypeVentumID)
            {
                pdfPtblData.AddCell(get_pdfPCellNoBorder(" ", 2, 0, 0));
                pdfPtblData.AddCell(get_pdfPCellNoBorder("*Separate electrical connection required for heater", 2, 0, 0));
            }


            pdfPtblNominalData.AddCell(get_pdfPCell("Nominal", 2, 0));
            for (int i = 0; i < _objOut.dtPreheatElecHeaterNominalData.Rows.Count; i++)
            {
                pdfPtblNominalData.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterNominalData.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblNominalData.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterNominalData.Rows[i]["cValue"].ToString(), 0, 0, 0));
            }

            //pdfPtblLeaving.AddCell(get_pdfPCell("Leaving", 2, 0));
            //for (int i = 0; i < _objOut.dtPreheatElecHeaterLeaving.Rows.Count; i++)
            //{
            //    pdfPtblLeaving.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterLeaving.Rows[i]["cLabel"].ToString(), 0, 0, 0));
            //    pdfPtblLeaving.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterLeaving.Rows[i]["cValue"].ToString(), 0, 0, 0));
            //}


            //widths = new float[] { 4f, 5f, 4f, 4f };

            pdfPtblGroup.AddCell(get_pdfPcellHeader("Preheat Electric Heater", 5));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 5f));
            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblData, 1));
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            //pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblNominalData, 1));
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 0.1f));
            //pdfPtblGroup.AddCell(get_pdfPCellNoBorder("*Separate electrical connection required for heater", 5, 0, 0, Color.BLACK));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 6f));
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 5f));

            ////pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblLeaving));
            ////pdfPtblGroup.AddCell(pdfPtblEmpty);
            ////lst_pdfPtbl.Add(pdfPtblGroup);

            return pdfPtblGroup;
        }
        #endregion


        #region Out Preheat HWC DIRECT_COIL
        private static PdfPTable getOutputPreheatHWC(ClsOutputData _objOut)
        {
            PdfPTable pdfPtblHeader = get_pdfPtblSettingHeader(1, 0);
            PdfPTable pdfPtblPhysicalData = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblEntering = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblLeaving = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblValveActuator = get_pdfPtblContent(2, 0);

            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(5, 0);

            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 2.7f, 3f };
            pdfPtblPhysicalData.SetWidths(widths);

            widths = new float[] { 4f, 2.25f };
            pdfPtblEntering.SetWidths(widths);

            widths = new float[] { 4f, 2.25f };
            pdfPtblLeaving.SetWidths(widths);

            widths = new float[] { 2f, 4f };
            pdfPtblValveActuator.SetWidths(widths);

            widths = new float[] { 4.2f, 0.25f, 3.8f, 0.25f, 3.8f };
            pdfPtblGroup.SetWidths(widths);

            //string strSection = ClsTS.get_strItem(ClsDB.get_dt(ClsDBT.strSelComponent), obj.get_intComponentID()).ToUpper() + " (" + obj.get_strType() + ")";


            //pdfPtblHeader.AddCell(get_pdfPcellHeader("Prheat HWC", 1));


            pdfPtblGroup.AddCell(get_pdfPcellHeader("Preheat HWC", 5));

            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 5f));
            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblPhysicalData, 1));
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblEntering, 1));
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblLeaving, 1));

            if (pdfPtblValveActuator.Rows.Count > 0)
            {
                pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 5f));
                pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblValveActuator, 3));
                pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 2, 5f));
            }

            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 6f));
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 5f));
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 5f));
            //pdfPtblGroup.AddCell(pdfPtblEmpty);
            //lst_pdfPtbl.Add(pdfPtblGroup);

            return pdfPtblGroup;
        }
        #endregion


        #region Out Fixed Plate CORE
        private static PdfPTable getOutputFixedPlateCORE(ClsOutputData _objOut)
        {
            PdfPTable pdfPtblHeader = get_pdfPtblSettingHeader(1, 0);
            PdfPTable pdfPtblSupplyEntAir = get_pdfPtblContent(3, 0);
            PdfPTable pdfPtblSupplyLvgAir = get_pdfPtblContent(3, 0);
            //PdfPTable pdfPtblExhaustEntAir = get_pdfPtblContent(3, 0);
            //PdfPTable pdfPtblExhaustLvgAir = get_pdfPtblContent(3, 0);
            PdfPTable pdfPtblImg = get_pdfPtblContent(3, 0);
            PdfPTable pdfPtblPerf = get_pdfPtblContent(3, 0);
            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(4, 0);

            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 3.5f, 3f, 3f };
            pdfPtblPerf.SetWidths(widths);

            widths = new float[] { 3.5f, 3f, 3f };
            pdfPtblSupplyEntAir.SetWidths(widths);

            widths = new float[] { 3.5f, 3f, 3f };
            pdfPtblSupplyLvgAir.SetWidths(widths);

            widths = new float[] { 0.1f, 4f, 0.1f };
            pdfPtblImg.SetWidths(widths);

            //widths = new float[] { 4.5f, 3f, 3f };
            //pdfPtblExhaustEntAir.SetWidths(widths);

            //widths = new float[] { 4.5f, 3f, 3f };
            //pdfPtblExhaustLvgAir.SetWidths(widths);

            widths = new float[] { 0.75f, 4f, 0.25f, 1f };
            pdfPtblGroup.SetWidths(widths);


            //string strSection = ClsTS.get_strItem(ClsDB.get_dt(ClsDBT.strSelComponent), obj.get_intComponentID()).ToUpper() + " (" + obj.get_strType() + ")";


            //pdfPtblHeader.AddCell(get_pdfPcellHeader("Prheat HWC", 1));

            pdfPtblSupplyEntAir.AddCell(get_pdfPCell("Design Condtions", 1, 0));
            pdfPtblSupplyEntAir.AddCell(get_pdfPCell(_objOut.dtHX_FP_CORE_EntAir.Rows[0]["cValue_1"].ToString(), 1, 1));
            pdfPtblSupplyEntAir.AddCell(get_pdfPCell(_objOut.dtHX_FP_CORE_EntAir.Rows[0]["cValue_2"].ToString(), 1, 1));
            for (int i = 1; i < _objOut.dtHX_FP_CORE_EntAir.Rows.Count; i++)
            {
                pdfPtblSupplyEntAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_EntAir.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblSupplyEntAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_EntAir.Rows[i]["cValue_1"].ToString(), 0, 1, 0));
                pdfPtblSupplyEntAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_EntAir.Rows[i]["cValue_2"].ToString(), 0, 1, 0));
            }


            pdfPtblSupplyLvgAir.AddCell(get_pdfPCell("Performance Leaving Air", 1, 0));
            pdfPtblSupplyLvgAir.AddCell(get_pdfPCell(_objOut.dtHX_FP_CORE_LvgAir.Rows[0]["cValue_1"].ToString(), 1, 1));
            pdfPtblSupplyLvgAir.AddCell(get_pdfPCell(_objOut.dtHX_FP_CORE_LvgAir.Rows[0]["cValue_2"].ToString(), 1, 1));
            for (int i = 1; i < _objOut.dtHX_FP_CORE_LvgAir.Rows.Count; i++)
            {
                pdfPtblSupplyLvgAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_LvgAir.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblSupplyLvgAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_LvgAir.Rows[i]["cValue_1"].ToString(), 0, 1, 0));
                pdfPtblSupplyLvgAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_LvgAir.Rows[i]["cValue_2"].ToString(), 0, 1, 0));
            }


            pdfPtblPerf.AddCell(get_pdfPCell("Performance", 1, 0));
            pdfPtblPerf.AddCell(get_pdfPCell(_objOut.dtHX_FP_CORE_Perf.Rows[0]["cValue_1"].ToString(), 1, 1));
            pdfPtblPerf.AddCell(get_pdfPCell(_objOut.dtHX_FP_CORE_Perf.Rows[0]["cValue_2"].ToString(), 1, 1));
            for (int i = 1; i < _objOut.dtHX_FP_CORE_Perf.Rows.Count; i++)
            {
                pdfPtblPerf.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_Perf.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblPerf.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_Perf.Rows[i]["cValue_1"].ToString(), 0, 1, 0));
                pdfPtblPerf.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_Perf.Rows[i]["cValue_2"].ToString(), 0, 1, 0));
            }


            //pdfPtblExhaustEntAir.AddCell(get_pdfPCell("Return Entering Air", 3, 0));
            //for (int i = 0; i < _objOut.dtHX_FP_CORE_ReturnEntAir.Rows.Count; i++)
            //{
            //    pdfPtblExhaustEntAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_ReturnEntAir.Rows[i]["cLabel"].ToString(), 0, 0, 0));
            //    pdfPtblExhaustEntAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_ReturnEntAir.Rows[i]["cValue_1"].ToString(), 0, 0, 0));
            //    pdfPtblExhaustEntAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_ReturnEntAir.Rows[i]["cValue_2"].ToString(), 0, 0, 0));
            //}

            //pdfPtblExhaustLvgAir.AddCell(get_pdfPCell("Return Leaving Air", 3, 0));
            //for (int i = 0; i < _objOut.dtHX_FP_CORE_ReturnLvgAir.Rows.Count; i++)
            //{
            //    pdfPtblExhaustLvgAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_ReturnLvgAir.Rows[i]["cLabel"].ToString(), 0, 0, 0));
            //    pdfPtblExhaustLvgAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_ReturnLvgAir.Rows[i]["cValue_1"].ToString(), 0, 0, 0));
            //    pdfPtblExhaustLvgAir.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_ReturnLvgAir.Rows[i]["cValue_2"].ToString(), 0, 0, 0));
            //}





            //widths = new float[] { 4f, 5f, 4f, 4f };

            pdfPtblGroup.AddCell(get_pdfPcellHeader("Heat Exchanger", 4));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 4, 5f));
            //pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblExhaustLvgAir,1));
            //pdfPtblGroup.AddCell(pdfPtblEmpty);
            //pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblExhaustEntAir,1));
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3));
            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblSupplyEntAir, 3));
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 4, 5f));
            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblSupplyLvgAir, 3));
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 4, 5f));
            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblPerf, 3));
            pdfPtblGroup.AddCell(pdfPtblEmpty);


            iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            Image img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/img_ahri.png"));
            imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            img.ScaleAbsolute(60f, 35f);
            imgCell1.Border = 0;
            imgCell1.AddElement(new Chunk(img, 0, 0));

            if (Convert.ToInt32(_objOut.dtHX_FP_CORE_AHRIWarning.Rows[0]["ShowLogo"]) == 1)
            {
                pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 4, 5f));
                pdfPtblGroup.AddCell(imgCell1);
                pdfPtblGroup.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_AHRIWarning.Rows[0]["cValue"].ToString(), 2, 0, 0));
                pdfPtblGroup.AddCell(pdfPtblEmpty);
            }
            else
            {
                pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 4, 5f));
                pdfPtblGroup.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_AHRIWarning.Rows[0]["cValue"].ToString(), 3, 0, 0));
                pdfPtblGroup.AddCell(pdfPtblEmpty);
            }




            if (_objOut.dtHX_FP_CORE_CondWarning != null)
            {
                if (_objOut.dtHX_FP_CORE_CondWarning.Rows.Count > 0)
                {
                    pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 4, 5f));
                    pdfPtblGroup.AddCell(get_pdfPCellNoBorder(_objOut.dtHX_FP_CORE_CondWarning.Rows[0]["cValue"].ToString(), 3, 0, 0, Color.RED));
                    pdfPtblGroup.AddCell(pdfPtblEmpty);
                }
            }

            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 4, 6f));
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));

            return pdfPtblGroup;
        }
        #endregion



        #region Out Heating ElecHeater
        private static PdfPTable getOutputHeatingElecHeater(ClsOutputData _objOut)
        {
            PdfPTable pdfPtblHeader = get_pdfPtblSettingHeader(1, 0);
            PdfPTable pdfPtblData = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblNominalData = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblLeaving = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(5, 0);

            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 3f, 4f };
            pdfPtblData.SetWidths(widths);

            widths = new float[] { 4f, 2.5f };
            pdfPtblNominalData.SetWidths(widths);

            widths = new float[] { 4f, 2.5f };
            pdfPtblLeaving.SetWidths(widths);

            widths = new float[] { 4f, 0.25f, 2.5f, 0.25f, 2.5f };
            pdfPtblGroup.SetWidths(widths);

            //string strSection = ClsTS.get_strItem(ClsDB.get_dt(ClsDBT.strSelComponent), obj.get_intComponentID()).ToUpper() + " (" + obj.get_strType() + ")";


            //pdfPtblHeader.AddCell(get_pdfPcellHeader("Prheat ElecHeater", 1));


            pdfPtblData.AddCell(get_pdfPCell("Electric Heater", 2, 0));
            for (int i = 0; i < _objOut.dtHeatingElecHeaterData.Rows.Count; i++)
            {
                pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtHeatingElecHeaterData.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtHeatingElecHeaterData.Rows[i]["cValue"].ToString(), 0, 0, 0));
            }

            pdfPtblData.AddCell(get_pdfPCellNoBorder(" ", 2, 0, 0));
            pdfPtblData.AddCell(get_pdfPCellNoBorder("*Separate electrical connection required for heater", 2, 0, 0));


            pdfPtblNominalData.AddCell(get_pdfPCell("Nominal", 2, 0));
            for (int i = 0; i < _objOut.dtHeatingElecHeaterNominalData.Rows.Count; i++)
            {
                pdfPtblNominalData.AddCell(get_pdfPCellNoBorder(_objOut.dtHeatingElecHeaterNominalData.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblNominalData.AddCell(get_pdfPCellNoBorder(_objOut.dtHeatingElecHeaterNominalData.Rows[i]["cValue"].ToString(), 0, 0, 0));
            }


            //pdfPtblLeaving.AddCell(get_pdfPCell("Leaving", 2, 0));
            //for (int i = 0; i < _objOut.dtPreheatElecHeaterLeaving.Rows.Count; i++)
            //{
            //    pdfPtblLeaving.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterLeaving.Rows[i]["cLabel"].ToString(), 0, 0, 0));
            //    pdfPtblLeaving.AddCell(get_pdfPCellNoBorder(_objOut.dtPreheatElecHeaterLeaving.Rows[i]["cValue"].ToString(), 0, 0, 0));
            //}


            //widths = new float[] { 4f, 5f, 4f, 4f };

            pdfPtblGroup.AddCell(get_pdfPcellHeader("Heating Electric Heater", 5));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 5f));
            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblData, 1));
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            //pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblNominalData, 1));
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 0.1f));
            //pdfPtblGroup.AddCell(get_pdfPCellNoBorder("*Separate electrical connection required for heater", 5, 0, 0, Color.BLACK));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 6f));
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 5, 5f));

            ////pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblLeaving));
            ////pdfPtblGroup.AddCell(pdfPtblEmpty);
            ////lst_pdfPtbl.Add(pdfPtblGroup);

            return pdfPtblGroup;
        }
        #endregion



        #region Out Supply Fan ZIEHL-ABEGG
        private static PdfPTable getOutputSupplyFan(ClsUser _objUser, ClsOutputData _objOut)
        {
            PdfPTable pdfPtblHeader = get_pdfPtblSettingHeader(1, 0);
            PdfPTable pdfPtblData = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblGraph = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblSoundData = get_pdfPtblContent(12, 0);
            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(3, 0);

            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 3.2f, 3.3f };
            pdfPtblData.SetWidths(widths);

            widths = new float[] { 4f };
            pdfPtblGraph.SetWidths(widths);

            widths = new float[] { 0.1f, 3.5f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 0.1f };
            pdfPtblSoundData.SetWidths(widths);

            widths = new float[] { 4f, 1f, 7f };
            pdfPtblGroup.SetWidths(widths);

            //string strSection = ClsTS.get_strItem(ClsDB.get_dt(ClsDBT.strSelComponent), obj.get_intComponentID()).ToUpper() + " (" + obj.get_strType() + ")";


            //pdfPtblHeader.AddCell(get_pdfPcellHeader("Prheat HWC", 1));


            pdfPtblData.AddCell(get_pdfPCell("Fan", 2, 0));
            for (int i = 0; i < _objOut.dtSF_Data.Rows.Count; i++)
            {
                if (Convert.ToInt32(_objOut.dtSF_Data.Rows[i]["cIsBold"]) == 1)
                {
                    if (_objOut.dtSF_Data.Rows[i]["cValue"].ToString() == "")
                    {
                        if (Convert.ToInt32(_objOut.dtSF_Data.Rows[i]["cIsWarning"]) == 1)
                        {
                            pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_Data.Rows[i]["cLabel"].ToString(), 2, 0, 1, Color.RED));
                        }
                        else
                        {
                            pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_Data.Rows[i]["cLabel"].ToString(), 2, 0, 1));
                        }
                    }
                    else
                    {
                        pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_Data.Rows[i]["cLabel"].ToString(), 0, 0, 1));
                        pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_Data.Rows[i]["cValue"].ToString(), 0, 0, 1));
                    }
                }
                else
                {
                    pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_Data.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                    pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_Data.Rows[i]["cValue"].ToString(), 0, 0, 0));
                }
            }




            if (_objOut.dtSF_Graph.Rows.Count > 0)
            {
                byte[] bytes = Convert.FromBase64String(_objOut.dtSF_Graph.Rows[0]["cValue"].ToString());
                //imgEF_Graph.Visible = true;
                //imgEF_Graph.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(bytes);

                //pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_Data.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                //pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_Data.Rows[i]["cValue"].ToString(), 0, 0, 0));

                Image img = iTextSharp.text.Image.GetInstance(bytes);
                iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();
                img.ScaleAbsolute(300f, 200f);
                //img.ScaleAbsoluteWidth(300f);
                imgCell1.Border = 0;
                imgCell1.AddElement(new Chunk(img, 0, 0));
                pdfPtblGraph.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPtblGraph.AddCell(imgCell1);
            }


            pdfPtblSoundData.AddCell(get_pdfPCell("Sound Data", 12, 0));
            for (int i = 0; i < _objOut.dtSF_SoundData.Rows.Count; i++)
            {
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder("", 0, 0, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_SoundData.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_SoundData.Rows[i]["cValue_1"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_SoundData.Rows[i]["cValue_2"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_SoundData.Rows[i]["cValue_3"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_SoundData.Rows[i]["cValue_4"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_SoundData.Rows[i]["cValue_5"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_SoundData.Rows[i]["cValue_6"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_SoundData.Rows[i]["cValue_7"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_SoundData.Rows[i]["cValue_8"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_SoundData.Rows[i]["cValue_9"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSF_SoundData.Rows[i]["cValue_10"].ToString(), 0, 1, 0));
            }

            //pdfPtblSoundData.AddCell(get_pdfPCellNoBorder("", 12, 0, 0));
            //pdfPtblSoundData.AddCell(get_pdfPCellNoBorder("  *Sound data represents fans only, does not reflect final unit sound", 12, 0, 0));

            //widths = new float[] { 4f, 5f, 4f, 4f };

            pdfPtblGroup.AddCell(get_pdfPcellHeader("Supply Fan", 3));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblData, 1));
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            pdfPtblGroup.AddCell(pdfPtblGraph);
            //pdfPtblGroup.AddCell(pdfPtblGraph);
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            //if (_objUser.intUAL == ClsID.intUAL_Admin || _objUser.intUAL == ClsID.intUAL_IntAdmin || _objUser.intUAL == ClsID.intUAL_IntLvl_2 || _objUser.intUAL == ClsID.intUAL_IntLvl_1)
            //{
            //    pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblSoundData, 3));
            //    pdfPtblGroup.AddCell(get_pdfPCellEmpty("*Sound data represents fans only, does not reflect final unit sound", 3, 9f));
            //    pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            //}
            ////pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 6f));
            ////pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            ////lst_pdfPtbl.Add(pdfPtblGroup);

            return pdfPtblGroup;
        }
        #endregion


        #region Out Exhaust Fan ZIEHL-ABEGG
        private static PdfPTable getOutputExhaustFan(ClsUser _objUser, ClsOutputData _objOut)
        {
            PdfPTable pdfPtblHeader = get_pdfPtblSettingHeader(1, 0);
            PdfPTable pdfPtblData = get_pdfPtblContent(2, 0);
            PdfPTable pdfPtblGraph = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblSoundData = get_pdfPtblContent(12, 0);
            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(3, 0);

            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 3.2f, 3.3f };
            pdfPtblData.SetWidths(widths);

            widths = new float[] { 4f };
            pdfPtblGraph.SetWidths(widths);

            widths = new float[] { 0.1f, 3.5f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 0.1f };
            pdfPtblSoundData.SetWidths(widths);

            widths = new float[] { 4f, 1f, 7f };
            pdfPtblGroup.SetWidths(widths);

            //string strSection = ClsTS.get_strItem(ClsDB.get_dt(ClsDBT.strSelComponent), obj.get_intComponentID()).ToUpper() + " (" + obj.get_strType() + ")";


            //pdfPtblHeader.AddCell(get_pdfPcellHeader("Prheat HWC", 1));


            pdfPtblData.AddCell(get_pdfPCell("Fan", 2, 0));
            for (int i = 0; i < _objOut.dtEF_Data.Rows.Count; i++)
            {
                if (Convert.ToInt32(_objOut.dtEF_Data.Rows[i]["cIsBold"]) == 1)
                {
                    if (_objOut.dtEF_Data.Rows[i]["cValue"].ToString() == "")
                    {
                        if (Convert.ToInt32(_objOut.dtEF_Data.Rows[i]["cIsWarning"]) == 1)
                        {
                            pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_Data.Rows[i]["cLabel"].ToString(), 2, 0, 1, Color.RED));
                        }
                        else
                        {
                            pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_Data.Rows[i]["cLabel"].ToString(), 2, 0, 1));
                        }
                    }
                    else
                    {
                        pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_Data.Rows[i]["cLabel"].ToString(), 0, 0, 1));
                        pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_Data.Rows[i]["cValue"].ToString(), 0, 0, 1));
                    }
                }
                else
                {
                    pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_Data.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                    pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_Data.Rows[i]["cValue"].ToString(), 0, 0, 0));
                }
            }


            if (_objOut.dtEF_Graph.Rows.Count > 0)
            {
                byte[] bytes = Convert.FromBase64String(_objOut.dtEF_Graph.Rows[0]["cValue"].ToString());

                Image img = iTextSharp.text.Image.GetInstance(bytes);
                iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();
                img.ScaleAbsolute(300f, 200f);
                //img.ScaleAbsoluteWidth(300f);
                imgCell1.Border = 0;
                imgCell1.AddElement(new Chunk(img, 0, 0));
                pdfPtblGraph.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPtblGraph.AddCell(imgCell1);
            }


            pdfPtblSoundData.AddCell(get_pdfPCell("Sound Data", 12, 0));
            for (int i = 0; i < _objOut.dtEF_SoundData.Rows.Count; i++)
            {
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder("", 0, 0, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_SoundData.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_SoundData.Rows[i]["cValue_1"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_SoundData.Rows[i]["cValue_2"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_SoundData.Rows[i]["cValue_3"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_SoundData.Rows[i]["cValue_4"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_SoundData.Rows[i]["cValue_5"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_SoundData.Rows[i]["cValue_6"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_SoundData.Rows[i]["cValue_7"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_SoundData.Rows[i]["cValue_8"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_SoundData.Rows[i]["cValue_9"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_SoundData.Rows[i]["cValue_10"].ToString(), 0, 1, 0));
            }

            //pdfPtblSoundData.AddCell(get_pdfPCellNoBorder("", 12, 0, 0));
            //pdfPtblSoundData.AddCell(get_pdfPCellNoBorder("  *Sound data represents fans only, does not reflect final unit sound", 12, 0, 0));

            //widths = new float[] { 4f, 5f, 4f, 4f };

            pdfPtblGroup.AddCell(get_pdfPcellHeader("Exhaust Fan", 3));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblData, 1));
            pdfPtblGroup.AddCell(pdfPtblEmpty);
            pdfPtblGroup.AddCell(pdfPtblGraph);
            //pdfPtblGroup.AddCell(pdfPtblGraph);
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            //if (_objUser.intUAL == ClsID.intUAL_Admin || _objUser.intUAL == ClsID.intUAL_IntAdmin || _objUser.intUAL == ClsID.intUAL_IntLvl_2 || _objUser.intUAL == ClsID.intUAL_IntLvl_1)
            //{
            //    pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblSoundData, 3));
            //    pdfPtblGroup.AddCell(get_pdfPCellEmpty("*Sound data represents fans only, does not reflect final unit sound", 3, 9f));
            //    pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            //}
            ////pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            ////pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            ////pdfPtblGroup.AddCell(pdfPtblEmpty);
            ////pdfPtblGroup.AddCell(pdfPtblEmpty);
            ////lst_pdfPtbl.Add(pdfPtblGroup);

            return pdfPtblGroup;
        }
        #endregion


        #region Out Unit Sound Data
        private static PdfPTable getOutputSoundData(ClsUser _objUser, ClsOutputData _objOut)
        {
            PdfPTable pdfPtblHeader = get_pdfPtblSettingHeader(1, 0);
            //PdfPTable pdfPtblData = get_pdfPtblContent(2, 0);
            //PdfPTable pdfPtblGraph = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblSoundData = get_pdfPtblContent(12, 0);
            PdfPTable pdfPtblEmpty = get_pdfPtblContent(1, 0);
            PdfPTable pdfPtblGroup = get_pdfPtblContent(3, 0);

            pdfPtblGroup.KeepTogether = true;

            float[] widths = new float[] { 3.2f, 3.3f };
            //pdfPtblData.SetWidths(widths);

            //widths = new float[] { 4f };
            //pdfPtblGraph.SetWidths(widths);

            widths = new float[] { 0.1f, 3.5f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 0.1f };
            pdfPtblSoundData.SetWidths(widths);

            widths = new float[] { 4f, 1f, 7f };
            pdfPtblGroup.SetWidths(widths);

            //string strSection = ClsTS.get_strItem(ClsDB.get_dt(ClsDBT.strSelComponent), obj.get_intComponentID()).ToUpper() + " (" + obj.get_strType() + ")";


            //pdfPtblHeader.AddCell(get_pdfPcellHeader("Prheat HWC", 1));


            //pdfPtblData.AddCell(get_pdfPCell("Fan", 2, 0));
            //for (int i = 0; i < _objOut.dtEF_Data.Rows.Count; i++)
            //{
            //    if (Convert.ToInt32(_objOut.dtEF_Data.Rows[i]["cIsBold"]) == 1)
            //    {
            //        if (_objOut.dtEF_Data.Rows[i]["cValue"].ToString() == "")
            //        {
            //            pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_Data.Rows[i]["cLabel"].ToString(), 2, 0, 1));
            //        }
            //        else
            //        {
            //            pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_Data.Rows[i]["cLabel"].ToString(), 0, 0, 1));
            //            pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_Data.Rows[i]["cValue"].ToString(), 0, 0, 1));
            //        }
            //    }
            //    else
            //    {
            //        pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_Data.Rows[i]["cLabel"].ToString(), 0, 0, 0));
            //        pdfPtblData.AddCell(get_pdfPCellNoBorder(_objOut.dtEF_Data.Rows[i]["cValue"].ToString(), 0, 0, 0));
            //    }
            //}


            //if (_objOut.dtEF_Graph.Rows.Count > 0)
            //{
            //    byte[] bytes = Convert.FromBase64String(_objOut.dtEF_Graph.Rows[0]["cValue"].ToString());

            //    Image img = iTextSharp.text.Image.GetInstance(bytes);
            //    iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();
            //    img.ScaleAbsolute(300f, 200f);
            //    //img.ScaleAbsoluteWidth(300f);
            //    imgCell1.Border = 0;
            //    imgCell1.AddElement(new Chunk(img, 0, 0));
            //    pdfPtblGraph.HorizontalAlignment = Element.ALIGN_CENTER;
            //    pdfPtblGraph.AddCell(imgCell1);
            //}


            pdfPtblSoundData.AddCell(get_pdfPCell("  ", 12, 0));
            for (int i = 0; i < _objOut.dtSoundData.Rows.Count; i++)
            {
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder("", 0, 0, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSoundData.Rows[i]["cLabel"].ToString(), 0, 0, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSoundData.Rows[i]["cValue_1"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSoundData.Rows[i]["cValue_2"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSoundData.Rows[i]["cValue_3"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSoundData.Rows[i]["cValue_4"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSoundData.Rows[i]["cValue_5"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSoundData.Rows[i]["cValue_6"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSoundData.Rows[i]["cValue_7"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSoundData.Rows[i]["cValue_8"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSoundData.Rows[i]["cValue_9"].ToString(), 0, 1, 0));
                pdfPtblSoundData.AddCell(get_pdfPCellNoBorder(_objOut.dtSoundData.Rows[i]["cValue_10"].ToString(), 0, 1, 0));
            }

            //pdfPtblSoundData.AddCell(get_pdfPCellNoBorder("", 12, 0, 0));
            //pdfPtblSoundData.AddCell(get_pdfPCellNoBorder("  *Sound data represents fans only, does not reflect final unit sound", 12, 0, 0));

            //widths = new float[] { 4f, 5f, 4f, 4f };

            pdfPtblGroup.AddCell(get_pdfPcellHeader("Unit Sound Data", 3));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            //pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblData, 1));
            //pdfPtblGroup.AddCell(pdfPtblEmpty);
            //pdfPtblGroup.AddCell(pdfPtblGraph);
            //pdfPtblGroup.AddCell(pdfPtblGraph);
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));

            pdfPtblGroup.AddCell(get_pdfPCell(pdfPtblSoundData, 3));
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("*Sound data represents fans only, does not reflect final unit sound", 3, 9f));
            pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));

            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            //pdfPtblGroup.AddCell(get_pdfPCellEmpty("   ", 3, 5f));
            //pdfPtblGroup.AddCell(pdfPtblEmpty);
            //pdfPtblGroup.AddCell(pdfPtblEmpty);
            //lst_pdfPtbl.Add(pdfPtblGroup);

            return pdfPtblGroup;
        }
        #endregion



        #region PDF PTables
        private static PdfPTable get_pdfPtblSettingJobInfo(int intColumns)
        {
            PdfPTable pdfPtblJobInfo = new PdfPTable(intColumns);
            pdfPtblJobInfo.HorizontalAlignment = 0;    //0=Left, 1=Centre, 2=Right
            pdfPtblJobInfo.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPtblJobInfo.SpacingBefore = 6f;
            pdfPtblJobInfo.SpacingAfter = 0f;
            pdfPtblJobInfo.WidthPercentage = 90;
            pdfPtblJobInfo.DefaultCell.Border = Rectangle.NO_BORDER;

            return pdfPtblJobInfo;
        }

        private static PdfPTable get_pdfPtblSettingHeader(int intColumns, int _intBorder)
        {
            PdfPTable pdfPtblHeader = new PdfPTable(intColumns);
            pdfPtblHeader.HorizontalAlignment = 0;    //0=Left, 1=Centre, 2=Right
            pdfPtblHeader.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPtblHeader.SpacingBefore = 0f;
            pdfPtblHeader.SpacingAfter = 0f;
            pdfPtblHeader.WidthPercentage = 90;
            pdfPtblHeader.DefaultCell.Border = (_intBorder == 1 ? Rectangle.BOX : Rectangle.NO_BORDER);

            return pdfPtblHeader;
        }

        private static PdfPTable get_pdfPtblContent(int intColumns, int _intBorder)
        {
            PdfPTable pdfPtblContent = new PdfPTable(intColumns);
            pdfPtblContent.HorizontalAlignment = 0;    //0=Left, 1=Centre, 2=Right
            pdfPtblContent.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPtblContent.SpacingBefore = 15f;
            pdfPtblContent.SpacingAfter = 0f;
            pdfPtblContent.WidthPercentage = 90;

            pdfPtblContent.DefaultCell.Border = (_intBorder == 1 ? Rectangle.BOX : Rectangle.NO_BORDER);

            return pdfPtblContent;
        }
        #endregion


        #region PDF PTable Cells
        private static PdfPCell get_pdfPcellHeader(string _strCellContent, int _intColSpan)
        {
            PdfPCell cell = null;
            Phrase phrase = null;

            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, false);
            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            //Font times = new Font(bfTimes, 10f, Font.BOLD, Color.WHITE);
            Font font = FontFactory.GetFont("Calibri", 9.5f, Font.BOLD, Color.WHITE);
            Color myColor = WebColors.GetRGBColor("#003366");

            phrase = new Phrase(_strCellContent, font);
            cell = new PdfPCell(phrase);
            cell.Border = 0;
            //cell.BorderWidth = 0.1f;
            cell.BorderWidthBottom = 0.1f;
            cell.Colspan = _intColSpan;
            cell.BackgroundColor = myColor;
            //cell.BackgroundColor = Color.DARK_GRAY;
            //cell.BorderColor = Color.GRAY;
            cell.HorizontalAlignment = 1;
            cell.UseAscender = true;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            return cell;
        }


        private static PdfPCell get_pdfPCell(PdfPTable _pdfPTbl, int _intColSpan)
        {
            PdfPCell cell = null;
            Phrase phrase = null;

            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            //Font times = new Font(bfTimes, 8f, Font.NORMAL, Color.BLACK);

            //phrase = new Phrase(_strCellContent, times);
            //PdfPTable pdfPtbl = _strCellContent;
            //pdfPtbl.SpacingBefore = 25f;
            //pdfPtbl.SpacingAfter = 25f;

            cell = new PdfPCell(_pdfPTbl);
            //cell.Border = 0;
            cell.BorderWidth = 0.01f;
            //cell.BorderWidthBottom = 0.1f;
            cell.BorderColor = Color.GRAY;
            cell.Colspan = _intColSpan;
            cell.BackgroundColor = Color.WHITE;
            //cell.HorizontalAlignment = _intHorizontalAlignment;

            return cell;
        }

        private static PdfPCell get_pdfPCellNoBorder(PdfPTable _pdfPTbl, int _intColSpan)
        {
            PdfPCell cell = null;
            Phrase phrase = null;

            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            //Font times = new Font(bfTimes, 8f, Font.NORMAL, Color.BLACK);

            //phrase = new Phrase(_strCellContent, times);
            //PdfPTable pdfPtbl = _strCellContent;
            //pdfPtbl.SpacingBefore = 25f;
            //pdfPtbl.SpacingAfter = 25f;

            cell = new PdfPCell(_pdfPTbl);
            //cell.Border = 0;
            cell.BorderWidth = 0.00f;
            //cell.BorderWidthBottom = 0.1f;
            cell.BorderColor = Color.GRAY;
            cell.Colspan = _intColSpan;
            cell.BackgroundColor = Color.WHITE;
            //cell.HorizontalAlignment = _intHorizontalAlignment;

            return cell;
        }



        private static PdfPCell get_pdfPCell(string _strCellContent, int _intColSpan, int _intHorizontalAlignment)
        {
            PdfPCell cell = null;
            Phrase phrase = null;

            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            //Font times = new Font(bfTimes, 9f, Font.NORMAL, Color.BLACK);
            Font font = FontFactory.GetFont("Calibri", 9f, Font.BOLD, Color.WHITE);


            //Color myColor = WebColors.GetRGBColor("#4169E1");
            //Color myColor = WebColors.GetRGBColor("#87ceeb");
            Color myColor = WebColors.GetRGBColor("#003366");

            phrase = new Phrase(_strCellContent, font);
            cell = new PdfPCell(phrase);
            //cell.Border = 0;
            cell.BorderWidth = 0.1f;
            //cell.BorderWidthBottom = 0.1f;
            cell.BorderColor = myColor;
            cell.Colspan = _intColSpan;
            //cell.BackgroundColor = myColor;
            //cell.BackgroundColor = Color.LIGHT_GRAY;
            cell.BackgroundColor = myColor;
            cell.HorizontalAlignment = _intHorizontalAlignment;
            cell.UseAscender = true;
            cell.VerticalAlignment = Element.ALIGN_TOP;

            return cell;
        }


        private static PdfPCell get_pdfPCellNoBorder(string _strCellContent, int _intColSpan, int _intHorizontalAlignment, int _intBold)
        {
            PdfPCell cell = null;
            Phrase phrase = null;
            Font font = null;

            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

            if (_intBold == 1)
            {
                //font = new Font(bfTimes, 9f, Font.BOLD, Color.BLACK);
                font = FontFactory.GetFont("Calibri", 9f, Font.BOLD, Color.BLACK);
            }
            else
            {
                //font = new Font(bfTimes, 9f, Font.NORMAL, Color.BLACK);
                font = FontFactory.GetFont("Calibri", 9f, Font.NORMAL, Color.BLACK);
            }


            Color myColor = WebColors.GetRGBColor("#f3fafb");

            phrase = new Phrase(_strCellContent, font);
            cell = new PdfPCell(phrase);
            //cell.Border = 0;
            cell.BorderWidth = 0.0f;
            cell.BorderColor = Color.GRAY;
            //cell.BorderWidthBottom = 0.5f;
            cell.Colspan = _intColSpan;
            //cell.BackgroundColor = Color.LIGHT_GRAY;
            cell.BackgroundColor = Color.WHITE;
            //left	0; center	1; right	2; justified 3; top	4; middle	5; bottom	6
            cell.HorizontalAlignment = _intHorizontalAlignment;

            return cell;
        }


        private static PdfPCell get_pdfPCellNoBorder(string _strCellContent, int _intColSpan, int _intHorizontalAlignment, int _intBold, Color _clrFontColor)
        {
            PdfPCell cell = null;
            Phrase phrase = null;
            Font font = null;

            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

            if (_intBold == 1)
            {
                //font = new Font(bfTimes, 9f, Font.BOLD, Color.BLACK);
                font = FontFactory.GetFont("Calibri", 9f, Font.BOLD, _clrFontColor);
            }
            else
            {
                //font = new Font(bfTimes, 9f, Font.NORMAL, Color.BLACK);
                font = FontFactory.GetFont("Calibri", 9f, Font.NORMAL, _clrFontColor);
            }


            Color myColor = WebColors.GetRGBColor("#f3fafb");

            phrase = new Phrase(_strCellContent, font);
            cell = new PdfPCell(phrase);
            //cell.Border = 0;
            cell.BorderWidth = 0.0f;
            cell.BorderColor = Color.GRAY;
            //cell.BorderWidthBottom = 0.5f;
            cell.Colspan = _intColSpan;
            //cell.BackgroundColor = Color.LIGHT_GRAY;
            cell.BackgroundColor = Color.WHITE;
            //left	0; center	1; right	2; justified 3; top	4; middle	5; bottom	6
            cell.HorizontalAlignment = _intHorizontalAlignment;

            return cell;
        }


        private static PdfPCell get_pdfPCellBorder(string _strCellContent, int _intColSpan, int _intHorizontalAlignment, int _intBold)
        {
            PdfPCell cell = null;
            Phrase phrase = null;
            Font font = null;

            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

            if (_intBold == 1)
            {
                //font = new Font(bfTimes, 9f, Font.BOLD, Color.BLACK);
                font = FontFactory.GetFont("Calibri", 9f, Font.BOLD, Color.BLACK);
            }
            else
            {
                //font = new Font(bfTimes, 9f, Font.NORMAL, Color.BLACK);
                font = FontFactory.GetFont("Calibri", 9f, Font.NORMAL, Color.BLACK);
            }


            Color myColor = WebColors.GetRGBColor("#f3fafb");

            phrase = new Phrase(_strCellContent, font);
            cell = new PdfPCell(phrase);
            cell.PaddingTop = 7.5f;
            cell.PaddingBottom = 7.5f;
            //cell.Border = 0;
            cell.BorderWidth = 0.1f;
            cell.BorderColor = Color.GRAY;
            //cell.BorderWidthBottom = 0.5f;
            cell.Colspan = _intColSpan;
            //cell.BackgroundColor = Color.LIGHT_GRAY;
            cell.BackgroundColor = Color.WHITE;
            cell.HorizontalAlignment = _intHorizontalAlignment;

            return cell;
        }


        //private static PdfPCell get_pdfPCellLastWhite(string _strCellContent, int _intColSpan)
        //{
        //    PdfPCell cell = null;
        //    Phrase phrase = null;

        //    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        //    Font times = new Font(bfTimes, 7f, Font.NORMAL, Color.BLACK);

        //    phrase = new Phrase(_strCellContent, times);
        //    cell = new PdfPCell(phrase);
        //    //cell.Border = 0;
        //    cell.BorderWidth = 1f;
        //    //cell.BorderWidthBottom = 0.1f;
        //    cell.Colspan = _intColSpan;
        //    cell.BackgroundColor = Color.WHITE;
        //    cell.BorderColor = Color.WHITE;

        //    cell.HorizontalAlignment = 0;

        //    return cell;
        //}


        private static PdfPCell get_pdfPCellEmpty(string _strCellContent, int _intColSpan, float _fltFontSize)
        {
            PdfPCell cell = null;
            Phrase phrase = null;

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            Font times = new Font(bfTimes, _fltFontSize, Font.NORMAL, Color.BLACK);

            phrase = new Phrase(_strCellContent, times);
            cell = new PdfPCell(phrase);
            //cell.Border = 0f;
            cell.BorderWidth = 0.0f;
            //cell.BorderWidthBottom = 0.1f;
            cell.Colspan = _intColSpan;
            cell.BackgroundColor = Color.WHITE;
            cell.BorderColor = Color.WHITE;

            cell.HorizontalAlignment = 0;

            return cell;
        }


        private static PdfPCell get_pdfPcellCustom(string _strCellContent, int _intColSpan, float _fltFont, int _intHorizontalAlignment, int _intBold, int _intUnderline, int _intBorder, float _fltPaddingTop, float _fltPaddingBottom)
        {
            PdfPCell cell = null;
            Phrase phrase = null;
            Font font = null;

            //if (_intBold == 1 && _intUnderline == 1)
            //{
            //    font = FontFactory.GetFont("Calibri", _fltFont, Font.BOLD | Font.UNDERLINE, Color.BLACK);
            //}
            //else if (_intBold == 1 && _intUnderline == 0)
            //{
            //    font = FontFactory.GetFont("Calibri", _fltFont, Font.BOLD, Color.BLACK);
            //}
            //else if (_intBold == 0 && _intUnderline == 1)
            //{
            //    font = FontFactory.GetFont("Calibri", _fltFont, Font.NORMAL | Font.UNDERLINE, Color.BLACK);
            //}
            //else if (_intBold == 0 && _intUnderline == 0)
            //{
            //    font = FontFactory.GetFont("Calibri", _fltFont, Font.NORMAL, Color.BLACK);
            //}

            string fontpath = System.Web.HttpContext.Current.Server.MapPath("fonts/");
            BaseFont customfont;
            if (_intBold == 1)
            {
                customfont = BaseFont.CreateFont(fontpath + "Montserrat-SemiBold.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
            }
            else
            {
                customfont = BaseFont.CreateFont(fontpath + "Montserrat-Light.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
            }

            font = new Font(customfont, _fltFont);

            // string s = "My expensive custom font.";
            //doc.Add(new Paragraph(s, font));

            //if (_intBold == 1 && _intUnderline == 1)
            //{
            //    font = FontFactory.GetFont("Montserrat-SemiBold", _fltFont, Font.BOLD | Font.UNDERLINE, Color.BLACK);
            //}
            //else if (_intBold == 1 && _intUnderline == 0)
            //{
            //    font = FontFactory.GetFont("Montserrat-SemiBold", _fltFont, Font.BOLD, Color.BLACK);
            //}
            //else if (_intBold == 0 && _intUnderline == 1)
            //{
            //    font = FontFactory.GetFont("Montserrat-SemiBold", _fltFont, Font.NORMAL | Font.UNDERLINE, Color.BLACK);
            //}
            //else if (_intBold == 0 && _intUnderline == 0)
            //{
            //    font = FontFactory.GetFont("Montserrat-SemiBold", _fltFont, Font.NORMAL, Color.BLACK);
            //}


            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            //if (_intBold == 1)
            //{
            //    font = new Font(bfTimes, _fltFont, Font.BOLD, Color.BLACK);
            //}
            //else
            //{
            //    font = new Font(bfTimes, _fltFont, Font.NORMAL, Color.BLACK);
            //}



            phrase = new Phrase(_strCellContent, font);
            cell = new PdfPCell(phrase);
            //cell.Padding = _dblPaddingTop == 1 ? 10f : 0f;
            cell.PaddingTop = _fltPaddingTop;
            cell.PaddingBottom = _fltPaddingBottom;
            //cell.Border = 0;
            cell.BorderWidth = _intBorder == 1 ? 0.1f : 0.0f;
            cell.BorderColor = Color.GRAY;
            //cell.BorderWidthBottom = 0.1f;
            cell.Colspan = _intColSpan;
            cell.BackgroundColor = Color.WHITE;
            cell.HorizontalAlignment = _intHorizontalAlignment;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            return cell;
        }


        private static PdfPCell get_pdfPcellCustom_2(string _strCellContent, int _intColSpan, int _intRowSpan, float _fltFont, int _intHorAlign, int _intVerAlign, int _intBold, int _intUnderline, int _intBorder, float _fltPaddingTop, float _fltPaddingBottom)
        {
            PdfPCell cell = null;
            Phrase phrase = null;
            Font font = null;

            if (_intBold == 1 && _intUnderline == 1)
            {
                font = FontFactory.GetFont("Calibri", _fltFont, Font.BOLD | Font.UNDERLINE, Color.BLACK);
            }
            else if (_intBold == 1 && _intUnderline == 0)
            {
                font = FontFactory.GetFont("Calibri", _fltFont, Font.BOLD, Color.BLACK);
            }
            else if (_intBold == 0 && _intUnderline == 1)
            {
                font = FontFactory.GetFont("Calibri", _fltFont, Font.NORMAL | Font.UNDERLINE, Color.BLACK);
            }
            else if (_intBold == 0 && _intUnderline == 0)
            {
                font = FontFactory.GetFont("Calibri", _fltFont, Font.NORMAL, Color.BLACK);
            }



            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            //if (_intBold == 1)
            //{
            //    font = new Font(bfTimes, _fltFont, Font.BOLD, Color.BLACK);
            //}
            //else
            //{
            //    font = new Font(bfTimes, _fltFont, Font.NORMAL, Color.BLACK);
            //}



            phrase = new Phrase(_strCellContent, font);
            cell = new PdfPCell(phrase);
            //cell.Padding = _dblPaddingTop == 1 ? 10f : 0f;
            cell.PaddingTop = _fltPaddingTop;
            cell.PaddingBottom = _fltPaddingBottom;
            //cell.Border = 0;
            cell.BorderWidth = _intBorder == 1 ? 0.1f : 0.0f;
            cell.BorderColor = Color.GRAY;
            //cell.BorderWidthBottom = 0.1f;
            cell.Colspan = _intColSpan;
            cell.Rowspan = _intRowSpan;
            cell.BackgroundColor = Color.WHITE;
            cell.HorizontalAlignment = _intHorAlign;
            cell.VerticalAlignment = _intVerAlign == 4 ? Element.ALIGN_TOP : _intVerAlign == 6 ? Element.ALIGN_BOTTOM : Element.ALIGN_MIDDLE; //5 or other == middle
            return cell;
        }


        private static PdfPCell get_pdfPcellCustom_1(string _strCellContent, int _intColSpan, float _fltFont, int _intHorizontalAlignment, int _intBold, int _intUnderline, int _intBorder, int _intPaddingTopBottom)
        {
            PdfPCell cell = null;
            Phrase phrase = null;
            Font font = null;

            if (_intBold == 1 && _intUnderline == 1)
            {
                font = FontFactory.GetFont("Calibri", _fltFont, Font.BOLD | Font.UNDERLINE, Color.WHITE);
            }
            else if (_intBold == 1 && _intUnderline == 0)
            {
                font = FontFactory.GetFont("Calibri", _fltFont, Font.BOLD, Color.WHITE);
            }
            else if (_intBold == 0 && _intUnderline == 1)
            {
                font = FontFactory.GetFont("Calibri", _fltFont, Font.NORMAL | Font.UNDERLINE, Color.WHITE);
            }
            else if (_intBold == 0 && _intUnderline == 0)
            {
                font = FontFactory.GetFont("Calibri", _fltFont, Font.NORMAL, Color.WHITE);
            }



            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            //if (_intBold == 1)
            //{
            //    font = new Font(bfTimes, _fltFont, Font.BOLD, Color.BLACK);
            //}
            //else
            //{
            //    font = new Font(bfTimes, _fltFont, Font.NORMAL, Color.BLACK);
            //}


            //Color myColor = WebColors.GetRGBColor("#000080");
            //Color myColor = WebColors.GetRGBColor("#00008B");
            Color myColor = WebColors.GetRGBColor("#003366");

            phrase = new Phrase(_strCellContent, font);
            cell = new PdfPCell(phrase);
            cell.Padding = _intPaddingTopBottom == 1 ? 10f : 0f;
            //cell.PaddingTop = 7.5f;
            //cell.PaddingBottom = 6f;
            cell.BorderWidth = _intBorder == 1 ? 0.1f : 0.0f;
            cell.BorderColor = myColor;
            cell.FixedHeight = 34f;
            //cell.BorderWidthBottom = 0.1f;
            cell.Colspan = _intColSpan;
            cell.BackgroundColor = myColor;
            cell.HorizontalAlignment = _intHorizontalAlignment;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            return cell;
        }

        #endregion

    }
}