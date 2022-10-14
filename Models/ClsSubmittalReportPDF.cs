using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsSubmittalReportPDF
    {
        public ClsSubmittalReportPDF()
        {
        }

        public byte[] /*MemoryStream*/ getBytArrMainPage(PdfPTable _PdfPTable, ClsID.enmPageOrientation _enmPageOrientation, string _strHeaderImg, string _strFooterImg)
        {
            MemoryStream msPDFData = new MemoryStream();
            Document document;
            //Rectangle pageSize = document.PageSize;

            if (_enmPageOrientation == ClsID.enmPageOrientation.Landscape)
            {
                document = new Document(PageSize.LETTER.Rotate(), -70, -70, 90, 45);
            }
            else
            {
                //if (_strHeaderImg == string.Empty && _strFooterImg == string.Empty)
                //{
                //    document = new Document(PageSize.LETTER, 0, 0, 0, 0);
                //}
                //else
                //{
                //document = new Document(PageSize.LETTER, 0, 0, 70, 50);
                document = new Document(PageSize.LETTER, 20, -45, 120, 50);

                //}
            }


            SubmittalHeaderFooter PageEventHandler = new SubmittalHeaderFooter();   //Custom Header and Footer is done using Event Handler
            PdfWriter PDFWriterInMemory = PdfWriter.GetInstance(document, msPDFData);
            //PDFWriterInMemory.ViewerPreferences = PdfWriter.PageModeUseOutlines;
            PDFWriterInMemory.PageEvent = PageEventHandler;
            PageEventHandler.HeaderImageName = _strHeaderImg;
            PageEventHandler.FooterImageName = _strFooterImg;
            PageEventHandler.HeaderRight = "";
            PageEventHandler.FooterLeft = ClsID.strSoftwareVersion;
            PageEventHandler.FooterRight = "oxygen8.ca";
            //PageEventHandler.bolIsCoverPage = _bolIsCoverPage;
            //PageEventHandler.bolIsCoreAHRICertified = _bolIsCoreAHRICertified;
            //PageEventHandler.intProdTypeID = _intProdTypeID;


            document.Open();
            document.Add(_PdfPTable);
            document.Close();



            return msPDFData.ToArray();
            //return msPDFData;
        }



        public byte[] /*MemoryStream*/ getBytArrCoverPage(PdfPTable _PdfPTable, ClsID.enmPageOrientation _enmPageOrientation, string _strHeaderImg, string _strFooterImg, int _intProdTypeID, string _strUnitModel, bool _bolIsCoverPage, bool _bolIsCoreAHRICertified)
        {
            MemoryStream msPDFData = new MemoryStream();
            Document document;
            //Rectangle pageSize = document.PageSize;

            if (_enmPageOrientation == ClsID.enmPageOrientation.Landscape)
            {
                document = new Document(PageSize.LETTER.Rotate(), -70, -70, 90, 45);
            }
            else
            {
                if (_strHeaderImg == string.Empty && _strFooterImg == string.Empty)
                {
                    document = new Document(PageSize.LETTER, 0, 0, 0, 0);
                }
                else
                {
                    document = new Document(PageSize.LETTER, 0, 0, 70, 50);
                }
            }


            SubmittalHeaderFooter PageEventHandler = new SubmittalHeaderFooter();   //Custom Header and Footer is done using Event Handler
            PdfWriter PDFWriterInMemory = PdfWriter.GetInstance(document, msPDFData);
            //PDFWriterInMemory.ViewerPreferences = PdfWriter.PageModeUseOutlines;
            PDFWriterInMemory.PageEvent = PageEventHandler;
            PageEventHandler.HeaderImageName = _strHeaderImg;
            PageEventHandler.FooterImageName = _strFooterImg;
            PageEventHandler.HeaderRight = _strUnitModel == "NO_UNIT_MODEL" ? " " : _strUnitModel;
            PageEventHandler.FooterLeft = ClsID.strSoftwareVersion;
            PageEventHandler.FooterRight = "oxygen8.ca";
            PageEventHandler.bolIsCoverPage = _bolIsCoverPage;
            PageEventHandler.bolIsCoreAHRICertified = _bolIsCoreAHRICertified;
            PageEventHandler.intProdTypeID = _intProdTypeID;


            document.Open();
            document.Add(_PdfPTable);
            document.Close();

            return msPDFData.ToArray();
            //return msPDFData;
        }


        public byte[] /*MemoryStream*/ getBytArrSubmittal(List<PdfPTable> _lst_PdfPTableSchedule, string _strHeaderImg, string _strFooterImg, string _strUnitModel)
        {
            //ClsPDF_Tools.FindAndKillPDF_File("Submittal.pdf - Adobe Reader");
            //ClsPDF_Tools.FindAndKillPDF_File("SubmittalFinal.pdf - Adobe Reader");
            //ClsPDF_Tools.FindAndKillPDF_Process();

            MemoryStream msPDFData = new MemoryStream();
            //Document document = new Document(PageSize.LETTER, 30, -30, 60, 40);
            Document document = new Document(PageSize.LETTER, 20, -45, 70, 50);

            // Our custom Header and Footer is done using Event Handler
            SubmittalHeaderFooter PageEventHandler = new SubmittalHeaderFooter();
            PageEventHandler.HeaderImageName = _strHeaderImg;
            PageEventHandler.FooterImageName = _strFooterImg;
            PageEventHandler.HeaderRight = _strUnitModel;
            PageEventHandler.FooterLeft = ClsID.strSoftwareVersion;
            PageEventHandler.FooterRight = "oxygen8.ca";


            PdfWriter PDFWriterInMemory = PdfWriter.GetInstance(document, msPDFData);
            PDFWriterInMemory.ViewerPreferences = PdfWriter.PageModeUseOutlines;
            PDFWriterInMemory.PageEvent = PageEventHandler;



            document.Open();

            for (int i = 0; i < _lst_PdfPTableSchedule.Count; i++)
            {
                document.Add(_lst_PdfPTableSchedule[i]);

                //if (i < _lst_PdfPTableSchedule.Count - 1)
                //{
                //    document.NewPage();
                //}
            }

            document.Close();

            return msPDFData.ToArray();
            //return msPDFData;
        }


        public byte[] /*MemoryStream*/ getBytArrDrawing(PdfPTable _PdfPTable, ClsID.enmPageOrientation _enmPageOrientation, string _strHeaderImg, string _strFooterImg)
        {
            MemoryStream msPDFData = new MemoryStream();
            Document document;
            //Rectangle pageSize = document.PageSize;

            if (_enmPageOrientation == ClsID.enmPageOrientation.Landscape)
            {
                document = new Document(PageSize.LETTER.Rotate(), -70, -70, 90, 45);
            }
            else
            {
                if (_strHeaderImg == string.Empty && _strFooterImg == string.Empty)
                {
                    document = new Document(PageSize.LETTER, 0, 0, 0, 0);
                }
                else
                {
                    document = new Document(PageSize.LETTER, 0, 0, 70, 50);
                }
            }


            SelectionHeaderFooter PageEventHandler = new SelectionHeaderFooter();   //Custom Header and Footer is done using Event Handler
            PdfWriter PDFWriterInMemory = PdfWriter.GetInstance(document, msPDFData);
            //PDFWriterInMemory.ViewerPreferences = PdfWriter.PageModeUseOutlines;
            PDFWriterInMemory.PageEvent = PageEventHandler;
            PageEventHandler.HeaderImageName = _strHeaderImg;
            PageEventHandler.FooterImageName = _strFooterImg;
            PageEventHandler.FooterRight = "";


            document.Open();
            document.Add(_PdfPTable);
            document.Close();

            return msPDFData.ToArray();
            //return msPDFData;
        }


    }



    //-----------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------
    public class SubmittalHeaderFooter : PdfPageEventHelper
    {
        PdfContentByte cb;      // This is the contentbyte object of the writer
        PdfTemplate template;   // we will put the final number of pages in a template
        BaseFont bf = null;      // this is the BaseFont we are going to use for the header / footer
        DateTime PrintTime = DateTime.Now;  // This keeps track of the creation time

        #region Properties

        private string _ReportName;
        public string ReportName
        {
            get { return _ReportName; }
            set { _ReportName = value; }
        }

        private string _TitleLeft;
        public string TitleLeft
        {
            get { return _TitleLeft; }
            set { _TitleLeft = value; }
        }

        private string _TitleMiddle;
        public string TitleMiddle
        {
            get { return _TitleMiddle; }
            set { _TitleMiddle = value; }
        }

        private string _TitleRight;
        public string TitleRight
        {
            get { return _TitleRight; }
            set { _TitleRight = value; }
        }

        private string _HeaderLeft;
        public string HeaderLeft
        {
            get { return _HeaderLeft; }
            set { _HeaderLeft = value; }
        }

        private string _HeaderLeftContent;
        public string HeaderLeftContent
        {
            get { return _HeaderLeftContent; }
            set { _HeaderLeftContent = value; }
        }

        private string _HeaderRight;
        public string HeaderRight
        {
            get { return _HeaderRight; }
            set { _HeaderRight = value; }
        }

        private string _HeaderRightContent;
        public string HeaderRightContent
        {
            get { return _HeaderRightContent; }
            set { _HeaderRightContent = value; }
        }

        private string _SubHeaderLeft;
        public string SubHeaderLeft
        {
            get { return _SubHeaderLeft; }
            set { _SubHeaderLeft = value; }
        }

        private string _SubHeaderRight;
        public string SubHeaderRight
        {
            get { return _SubHeaderRight; }
            set { _SubHeaderRight = value; }
        }

        private Font _HeaderFont;
        public Font HeaderFont
        {
            get { return _HeaderFont; }
            set { _HeaderFont = value; }
        }

        private Font _FooterFont;
        public Font FooterFont
        {
            get { return _FooterFont; }
            set { _FooterFont = value; }
        }

        private PdfPTable _HeaderTable;
        public PdfPTable HeaderTable
        {
            get { return _HeaderTable; }
            set { _HeaderTable = value; }
        }

        private string _HeaderImageName;
        public string HeaderImageName
        {
            get { return _HeaderImageName; }
            set { _HeaderImageName = value; }
        }


        private string _FooterImageName;
        public string FooterImageName
        {
            get { return _FooterImageName; }
            set { _FooterImageName = value; }
        }


        private string _FooterLeft;
        public string FooterLeft
        {
            get { return _FooterLeft; }
            set { _FooterLeft = value; }
        }

        private string _FooterLeftContent;
        public string FooterLeftContent
        {
            get { return _FooterLeftContent; }
            set { _FooterLeftContent = value; }
        }

        private string _FooterRight;
        public string FooterRight
        {
            get { return _FooterRight; }
            set { _FooterRight = value; }
        }

        private bool _bolIsCoverPage;
        public bool bolIsCoverPage
        {
            get { return _bolIsCoverPage; }
            set { _bolIsCoverPage = value; }
        }

        private bool _bolIsCoreAHRICertified;
        public bool bolIsCoreAHRICertified
        {
            get { return _bolIsCoreAHRICertified; }
            set { _bolIsCoreAHRICertified = value; }
        }

        private int _intProdTypeID;
        public int intProdTypeID
        {
            get { return _intProdTypeID; }
            set { _intProdTypeID = value; }
        }

        #endregion


        // we override the onOpenDocument method
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                template = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException de)
            {
            }
            catch (System.IO.IOException ioe)
            {
            }
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            Rectangle pageSize = document.PageSize;

            //if (TitleLeft != string.Empty)
            //{
            //    cb.BeginText();
            //    cb.SetFontAndSize(bf, 10);
            //    cb.SetRGBColorFill(0, 0, 0);
            //    cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(50));
            //    cb.ShowText(TitleLeft);
            //    cb.EndText();
            //}

            //if (TitleMiddle != string.Empty)
            //{
            //    cb.BeginText();
            //    cb.SetFontAndSize(bf, 10);
            //    cb.SetRGBColorFill(0, 0, 0);
            //    cb.SetTextMatrix(pageSize.GetLeft(300), pageSize.GetTop(40));
            //    cb.ShowText(TitleMiddle);
            //    cb.EndText();
            //}

            //if (TitleRight != string.Empty)
            //{
            //    cb.BeginText();
            //    cb.SetFontAndSize(bf, 10);
            //    cb.SetRGBColorFill(0, 0, 0);
            //    cb.SetTextMatrix(pageSize.GetRight(180), pageSize.GetTop(40));
            //    cb.ShowText(TitleRight);
            //    cb.EndText();
            //}


            if (HeaderImageName != string.Empty)
            {
                iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();
                Image img;
                img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath(HeaderImageName));
                //img.ScaleAbsolute(pageSize.Width, 35f);
                //img.ScaleAbsolute(175f, 15f);
                img.ScaleAbsolute(pageSize.Width, 100f);
                //img.Alignment = Element.ALIGN_MIDDLE;
                imgCell1.Border = 0;
                imgCell1.AddElement(new Chunk(img, 0, 0));
                //img.SetAbsolutePosition(pageSize.GetLeft(20), pageSize.GetTop(50));
                img.SetAbsolutePosition(pageSize.GetLeft(0), pageSize.GetTop(100));
                cb.AddImage(img);
            }


            if (HeaderRight != string.Empty)
            {

                PdfPTable HeaderTable = new PdfPTable(2);
                HeaderTable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                HeaderTable.DefaultCell.Border = 0;
                HeaderTable.DefaultCell.BorderWidth = 0f;
                HeaderTable.TotalWidth = 140;
                HeaderTable.SetWidthPercentage(new float[] { 5, 15 }, pageSize);

                //phrase = new Phrase(HeaderRight, font1);
                //cell1 = phrase;
                HeaderTable.AddCell(get_cellHeaderFooter(HeaderRight, 16d, 1));
                HeaderTable.AddCell(get_cellHeaderFooter("SUBMITTAL", 16d, 0));
                cb.SetRGBColorFill(0, 0, 0);
                HeaderTable.WriteSelectedRows(0, -1, pageSize.GetRight(140), pageSize.GetTop(32), cb);
            }


            //if (ReportName == "RD")
            //{

            //    if (HeaderLeft + HeaderRight != string.Empty)
            //    {
            //        PdfPTable HeaderTable = new PdfPTable(4);
            //        HeaderTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //        HeaderTable.TotalWidth = pageSize.Width - 60;
            //        //HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);

            //        HeaderTable.AddCell(get_cellRD_Header(HeaderLeft, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 5, 5, 0, 1f, 1f));
            //        HeaderTable.AddCell(get_cellRD_Header(HeaderLeftContent, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 5, 5, 0, 1f, 1f));
            //        HeaderTable.AddCell(get_cellRD_Header(HeaderRight, HeaderFont, 1, PdfPCell.ALIGN_RIGHT, 5, 5, 0, 1f, 1f));
            //        HeaderTable.AddCell(get_cellRD_Header(HeaderRightContent, HeaderFont, 1, PdfPCell.ALIGN_RIGHT, 5, 5, 0, 1f, 1f));

            //        cb.SetRGBColorFill(0, 0, 0);
            //        HeaderTable.WriteSelectedRows(0, -1, pageSize.GetLeft(30), pageSize.GetTop(50), cb);
            //    }

            //    if (SubHeaderLeft != string.Empty)
            //    {
            //        PdfPTable SubHeaderTagTable = new PdfPTable(2);
            //        SubHeaderTagTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //        SubHeaderTagTable.TotalWidth = pageSize.Width - 60;
            //        //HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);

            //        SubHeaderTagTable.AddCell(get_cellRD_Header(SubHeaderLeft, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 0, 0, 0, 0, 0));
            //        SubHeaderTagTable.AddCell(get_cellRD_Header(SubHeaderRight, HeaderFont, 1, PdfPCell.ALIGN_RIGHT, 0, 0, 0, 0, 0));

            //        cb.SetRGBColorFill(0, 0, 0);
            //        SubHeaderTagTable.WriteSelectedRows(0, -1, pageSize.GetLeft(30), pageSize.GetTop(110), cb);
            //    }
            //}

            //if (ReportName == "PO")
            //{
            //    if (HeaderLeft + HeaderRight != string.Empty)
            //    {
            //        PdfPTable HeaderTable = new PdfPTable(4);
            //        HeaderTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //        HeaderTable.TotalWidth = pageSize.Width - 60;
            //        //HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);

            //        HeaderTable.AddCell(get_cellRD_Header(HeaderLeft, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 5, 5, 0, 1f, 1f));
            //        HeaderTable.AddCell(get_cellRD_Header(HeaderLeftContent, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 5, 5, 0, 1f, 1f));
            //        HeaderTable.AddCell(get_cellRD_Header(HeaderRight, HeaderFont, 1, PdfPCell.ALIGN_RIGHT, 5, 5, 0, 1f, 1f));
            //        HeaderTable.AddCell(get_cellRD_Header(HeaderRightContent, HeaderFont, 1, PdfPCell.ALIGN_RIGHT, 5, 5, 0, 1f, 1f));
            //        cb.SetRGBColorFill(0, 0, 0);
            //        HeaderTable.WriteSelectedRows(0, -1, pageSize.GetLeft(30), pageSize.GetTop(50), cb);
            //    }

            //    if (SubHeaderLeft != string.Empty)
            //    {
            //        PdfPTable SubHeaderTagTable = new PdfPTable(2);
            //        SubHeaderTagTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //        SubHeaderTagTable.TotalWidth = pageSize.Width - 60;
            //        //HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);

            //        //SubHeaderTagTable.AddCell(get_cellPO_Header(SubHeaderLeft, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 5, 5, 0, 0, 1f, 1f, 0));
            //        //SubHeaderTagTable.AddCell(get_cellPO_Header(SubHeaderRight, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 5, 5, 0, 0, 1f, 0, 1f));

            //        SubHeaderTagTable.AddCell(get_cellRD_Header(SubHeaderLeft, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 0, 0, 0, 0, 0));
            //        SubHeaderTagTable.AddCell(get_cellRD_Header(SubHeaderRight, HeaderFont, 1, PdfPCell.ALIGN_RIGHT, 0, 0, 0, 0, 0));

            //        cb.SetRGBColorFill(0, 0, 0);
            //        SubHeaderTagTable.WriteSelectedRows(0, -1, pageSize.GetLeft(30), pageSize.GetTop(110), cb);
            //    }
            //}

            //if (ReportName == "DR")
            //{

            //    if (HeaderLeft + HeaderRight != string.Empty)
            //    {
            //        PdfPTable HeaderTable = new PdfPTable(4);
            //        HeaderTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //        HeaderTable.TotalWidth = pageSize.Width - 60;
            //        //HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);

            //        HeaderTable.AddCell(get_cellRD_Header(HeaderLeft, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 5, 5, 0, 1f, 1f));
            //        HeaderTable.AddCell(get_cellRD_Header(HeaderLeftContent, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 5, 5, 0, 1f, 1f));
            //        HeaderTable.AddCell(get_cellRD_Header(HeaderRight, HeaderFont, 1, PdfPCell.ALIGN_RIGHT, 5, 5, 0, 1f, 1f));
            //        HeaderTable.AddCell(get_cellRD_Header(HeaderRightContent, HeaderFont, 1, PdfPCell.ALIGN_RIGHT, 5, 5, 0, 1f, 1f));
            //        cb.SetRGBColorFill(0, 0, 0);
            //        HeaderTable.WriteSelectedRows(0, -1, pageSize.GetLeft(30), pageSize.GetTop(45), cb);
            //    }

            //    if (SubHeaderLeft != string.Empty)
            //    {
            //        PdfPTable SubHeaderTagTable = new PdfPTable(2);
            //        SubHeaderTagTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //        SubHeaderTagTable.TotalWidth = pageSize.Width - 60;
            //        //HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);

            //        //SubHeaderTagTable.AddCell(get_cellPO_Header(SubHeaderLeft, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 5, 5, 0, 0, 1f, 1f, 0));
            //        //SubHeaderTagTable.AddCell(get_cellPO_Header(SubHeaderRight, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 5, 5, 0, 0, 1f, 0, 1f));

            //        SubHeaderTagTable.AddCell(get_cellRD_Header(SubHeaderLeft, HeaderFont, 1, PdfPCell.ALIGN_LEFT, 0, 0, 0, 0, 0));
            //        SubHeaderTagTable.AddCell(get_cellRD_Header(SubHeaderRight, HeaderFont, 1, PdfPCell.ALIGN_RIGHT, 0, 0, 0, 0, 0));

            //        cb.SetRGBColorFill(0, 0, 0);
            //        SubHeaderTagTable.WriteSelectedRows(0, -1, pageSize.GetLeft(30), pageSize.GetTop(45), cb);
            //    }
            //}
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            int pageN = writer.PageNumber;
            String text = "Page " + pageN + " of ";
            float len = bf.GetWidthPoint(text, 8);

            Rectangle pageSize = document.PageSize;
            Image img = null;
            iTextSharp.text.pdf.PdfPCell imgCell1 = new iTextSharp.text.pdf.PdfPCell();


            if (bolIsCoverPage)
            {
                //img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/img_nova_cover_page.png"));
                switch (intProdTypeID)
                {
                    case ClsID.intProdTypeNovaID:
                        img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/img_nova_cover_page.png"));

                        break;
                    case ClsID.intProdTypeVentumID:
                    case ClsID.intProdTypeVentumLiteID:
                        img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/img_ventum_cover_page.png"));
                        break;
                    default:
                        img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/img_nova_cover_page.png"));

                        break;
                }

                imgCell1 = new iTextSharp.text.pdf.PdfPCell();
                img.ScaleAbsolute(395f, 230f);
                imgCell1.Border = 0;
                imgCell1.AddElement(new Chunk(img, 0, 0));
                img.SetAbsolutePosition(pageSize.GetLeft(30), pageSize.GetBottom(30));
                cb.AddImage(img);

                img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/img_etl_c.png"));
                imgCell1 = new iTextSharp.text.pdf.PdfPCell();
                img.ScaleAbsolute(60f, 60f);
                imgCell1.Border = 0;
                imgCell1.AddElement(new Chunk(img, 0, 0));
                img.SetAbsolutePosition(pageSize.GetLeft(425), pageSize.GetBottom(110));
                cb.AddImage(img);

                if (bolIsCoreAHRICertified)
                {
                    img = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("Images/img_ahri.png"));
                    imgCell1 = new iTextSharp.text.pdf.PdfPCell();
                    img.ScaleAbsolute(85f, 45f);
                    img.Alignment = Element.ALIGN_LEFT;
                    imgCell1.Border = 0;
                    imgCell1.AddElement(new Chunk(img, 0, 0));
                    img.SetAbsolutePosition(pageSize.GetLeft(500), pageSize.GetBottom(118));
                    cb.AddImage(img);
                }
            }



            if (FooterLeft != string.Empty)
            {
                PdfPTable FooterTable = new PdfPTable(1);
                FooterTable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                FooterTable.DefaultCell.Border = 0;
                FooterTable.DefaultCell.BorderWidth = 0f;
                FooterTable.TotalWidth = 80;
                //FooterTable.SetWidthPercentage(new float[] { 5, 15 }, pageSize);

                //phrase = new Phrase(HeaderRight, font1);
                //cell1 = phrase;
                FooterTable.AddCell(get_cellHeaderFooter(FooterLeft, 8d, 0));
                cb.SetRGBColorFill(0, 0, 0);
                FooterTable.WriteSelectedRows(0, -1, pageSize.GetLeft(15), pageSize.GetBottom(40), cb);

                //cb.BeginText();
                //cb.SetFontAndSize(bf, 8);
                //cb.SetTextMatrix(pageSize.GetRight(60), pageSize.GetBottom(15));
                //cb.ShowText(FooterRight);        //Commented by Sumith
                //cb.EndText();
            }


            if (FooterRight != string.Empty)
            {
                PdfPTable FooterTable = new PdfPTable(1);
                FooterTable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                FooterTable.DefaultCell.Border = 0;
                FooterTable.DefaultCell.BorderWidth = 0f;
                FooterTable.TotalWidth = 80;
                //FooterTable.SetWidthPercentage(new float[] { 5, 15 }, pageSize);

                //phrase = new Phrase(HeaderRight, font1);
                //cell1 = phrase;
                FooterTable.AddCell(get_cellHeaderFooter(FooterRight, 12d, 0));
                cb.SetRGBColorFill(0, 0, 0);
                FooterTable.WriteSelectedRows(0, -1, pageSize.GetRight(80), pageSize.GetBottom(40), cb);

                //cb.BeginText();
                //cb.SetFontAndSize(bf, 8);
                //cb.SetTextMatrix(pageSize.GetRight(60), pageSize.GetBottom(15));
                //cb.ShowText(FooterRight);        //Commented by Sumith
                //cb.EndText();
            }


            //cb.SetRGBColorFill(100, 100, 100);

            //cb.BeginText();
            //cb.SetFontAndSize(bf, 8);
            //cb.SetTextMatrix(pageSize.GetLeft(30), pageSize.GetBottom(30));
            ////cb.ShowText(text);        //Commented by Sumith
            //cb.EndText();

            //cb.AddTemplate(template, pageSize.GetLeft(30) + len, pageSize.GetBottom(30));

            //cb.BeginText();
            //cb.SetFontAndSize(bf, 8);
            ////cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Printed On " + PrintTime.ToString(), pageSize.GetRight(30), pageSize.GetBottom(30), 0);   //Commented by Sumith
            //cb.EndText();
        }


        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            template.BeginText();
            template.SetFontAndSize(bf, 8);
            template.SetTextMatrix(0, 0);
            //template.ShowText("" + (writer.PageNumber - 1));   //Commented by Sumith
            template.EndText();
        }

        private PdfPCell get_cellHeaderFooter(string _strCellContent, double dblFontSize, int _intBold)
        {
            string fontpath = System.Web.HttpContext.Current.Server.MapPath("fonts/");
            //BaseFont customfont = BaseFont.CreateFont(fontpath + "Montserrat-Light.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
            BaseFont customfont = BaseFont.CreateFont(fontpath + "ProximaNova-Reg.otf", BaseFont.CP1252, BaseFont.EMBEDDED);
            Font font1;

            if (_intBold == 1)
            {
                font1 = new Font(customfont, (float)dblFontSize, Font.BOLD, Color.BLACK);
            }
            else
            {
                font1 = new Font(customfont, (float)dblFontSize, Font.NORMAL, Color.BLACK);
            }

            PdfPCell cell = null;
            Phrase phrase = null;

            phrase = new Phrase(_strCellContent, font1);
            cell = new PdfPCell(phrase);
            //cell.Colspan = _intColSpan;
            cell = new PdfPCell(phrase);
            cell.Border = 0;
            cell.BorderWidthBottom = 0.0f;
            //cell.HorizontalAlignment = _intHorizontalAlignment;
            //cell.Padding = _intPadding;
            //cell.PaddingBottom = _intPaddingBottom;
            //cell.Border = _intBorder;
            //cell.BorderWidthTop = _fltBorderWidthTop;
            //cell.BorderWidthBottom = _fltBorderWidthBottom;

            return cell;
        }


        //private PdfPCell get_cellPO_Header(string _strCellContent, Font _times, int _intColSpan, int _intHorizontalAlignment, int _intPadding, int _intPaddingBottom, int _intBorder, float _fltBorderWidthTop, float _fltBorderWidthBottom, float _fltBorderWidthLeft, float _fltBorderWidthRight)
        //{
        //    PdfPCell cell = null;
        //    Phrase phrase = null;

        //    phrase = new Phrase(8, _strCellContent, _times);
        //    cell = new PdfPCell(phrase);
        //    cell.Colspan = _intColSpan;
        //    cell = new PdfPCell(phrase);
        //    //cell.BorderWidthBottom = 0.1f;
        //    cell.HorizontalAlignment = _intHorizontalAlignment;
        //    cell.BackgroundColor = Color.WHITE;
        //    //cell.Padding = _intPadding;
        //    //cell.PaddingBottom = _intPaddingBottom;
        //    cell.Border = _intBorder;
        //    cell.BorderWidthTop = _fltBorderWidthTop;
        //    cell.BorderWidthBottom = _fltBorderWidthBottom;
        //    cell.BorderWidthLeft = _fltBorderWidthLeft;
        //    cell.BorderWidthRight = _fltBorderWidthRight;

        //    return cell;
        //}

        //private PdfPCell get_cellDR_Header(string _strCellContent, Font _times, int _intColSpan, int _intHorizontalAlignment, int _intPadding, int _intPaddingBottom, int _intBorder, float _fltBorderWidthTop, float _fltBorderWidthBottom)
        //{
        //    PdfPCell cell = null;
        //    Phrase phrase = null;

        //    phrase = new Phrase(8, _strCellContent, _times);
        //    cell = new PdfPCell(phrase);
        //    cell.Colspan = _intColSpan;
        //    cell = new PdfPCell(phrase);
        //    cell.Border = 0;
        //    cell.BorderWidthBottom = 0.1f;
        //    cell.HorizontalAlignment = _intHorizontalAlignment;
        //    cell.Padding = _intPadding;
        //    cell.PaddingBottom = _intPaddingBottom;
        //    cell.Border = _intBorder;
        //    cell.BorderWidthTop = _fltBorderWidthTop;
        //    cell.BorderWidthBottom = _fltBorderWidthBottom;

        //    return cell;
        //}
    }
}