using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Oxygen8SelectorServer.Models
{
    public class ClsPDF_Tools
    {
        public static DataTable get_dtAttachPDF()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("pdf");

            return dt;
        }


        public static Byte[] get_byt_arrFromPDF(string _strFilePath)
        {
            //string filePath = Server.MapPath("APP_DATA/TestDoc.docx");

            //string filename = Path.GetFileName(_strFilePath);

            //string filename = Path.GetFileName(HttpContext.Current.Server.MapPath("~/" + clsGV.strTempFilesFolder + "/TempDrawing.pdf"));
            //string strFilePath = HttpContext.Current.Server.MapPath("~/" + clsGV.strDrawingFolder + "/BZBC.038052200.pdf");

            Byte[] bytPDF = null;

            string strFilePath = HttpContext.Current.Server.MapPath(_strFilePath);

            if (File.Exists(strFilePath))
            {

                FileStream fs = new FileStream(strFilePath, FileMode.Open, FileAccess.Read);
                //StreamWriter sw = new StreamWriter("C://file.txt");

                BinaryReader br = new BinaryReader(fs);

                bytPDF = br.ReadBytes((Int32)fs.Length);

                br.Close();

                fs.Close();
            }

            return bytPDF;
        }


        public static void getBytArrMergeFiles(byte[] _bytPDF, List<string> lstPDF_Files)
        {
            //MemoryStream msPDFData = new MemoryStream(_bytPDF.ToArray());
            System.IO.File.WriteAllBytes("myfile.pdf", _bytPDF);

            try
            {
                int f = 0;
                // we create a reader for a certain document
                PdfReader reader = new PdfReader(lstPDF_Files[f]);
                // we retrieve the total number of pages
                int n = reader.NumberOfPages;
                Console.WriteLine("There are " + n + " pages in the original file.");
                // step 1: creation of a document-object
                Document document = new Document(reader.GetPageSizeWithRotation(1));
                // step 2: we create a writer that listens to the document
                PdfWriter PdfWriterInFile = PdfWriter.GetInstance(document, new FileStream("", FileMode.Create));
                //PdfWriter PdfWriterInMemory = PdfWriter.GetInstance(document, msPDFData);
                // step 3: we open the document
                // Our custom Header and Footer is done using Event Handler

                document.Open();
                PdfContentByte cb = PdfWriterInFile.DirectContent;
                PdfImportedPage page;
                int rotation;
                // step 4: we add content

                while (f < lstPDF_Files.Count)
                {
                    int i = 0;
                    while (i < n)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        page = PdfWriterInFile.GetImportedPage(reader, i);
                        rotation = reader.GetPageRotation(i);
                        //if (rotation == 90 || rotation == 270)
                        //{

                        //    cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        //}
                        //else
                        //{
                        //    ////cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);

                        int pageRotation = reader.GetPageRotation(i);
                        float pageWidth = reader.GetPageSizeWithRotation(i).Width;
                        float pageHeight = reader.GetPageSizeWithRotation(i).Height;

                        switch (pageRotation)
                        {
                            case 0:
                                PdfWriterInFile.DirectContent.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                                break;

                            case 90:
                                PdfWriterInFile.DirectContent.AddTemplate(page, 0, -1f, 1f, 0, 0, pageHeight);

                                break;

                            case 180:
                                PdfWriterInFile.DirectContent.AddTemplate(page, -1f, 0, 0, -1f, pageWidth, pageHeight);
                                break;

                            case 270:
                                PdfWriterInFile.DirectContent.AddTemplate(page, 0, 1f, -1f, 0, pageWidth, 0);
                                break;

                            default:
                                throw new InvalidOperationException(string.Format("Unexpected page rotation: [{0}].", pageRotation));
                        }

                        //}

                        Console.WriteLine("Processed page " + i);
                    }
                    f++;
                    if (f < lstPDF_Files.Count)
                    {
                        reader = new PdfReader(lstPDF_Files[f]);
                        // we retrieve the total number of pages
                        n = reader.NumberOfPages;
                        Console.WriteLine("There are " + n + " pages in the original file.");
                    }
                }

                // step 5: we close the document
                document.Close();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
            }

            //// load bytes from file is super easy in C#
            //byte[] bytes = System.IO.File.ReadAllBytes("myfile.pdf");

            //// munge bytes with whatever pdf software you want
            //// ...

            //// and save back
            //System.IO.File.WriteAllBytes("myfile.pdf", bytes);
        }


        public static byte[] getBytArrMergeFiles1(List<string> lstPDF_Files)
        {
            MemoryStream msPDFData = new MemoryStream();

            try
            {
                int f = 0;
                PdfReader reader = new PdfReader(lstPDF_Files[f]);  // we create a reader for a certain document
                int n = reader.NumberOfPages;   // we retrieve the total number of pages

                Document document = new Document(reader.GetPageSizeWithRotation(1));    // step 1: creation of a document-object

                //PdfWriter PdfWriterInFile = PdfWriter.GetInstance(document, new FileStream("", FileMode.Create)); // step 2: we create a writer that listens to the document
                PdfWriter PdfWriterInMemory = PdfWriter.GetInstance(document, msPDFData);   // step 2: we create a writer that listens to the document

                document.Open();                // step 3: we open the document
                PdfContentByte cb = PdfWriterInMemory.DirectContent;
                PdfImportedPage page;
                int rotation;

                while (f < lstPDF_Files.Count)   // step 4: we add content
                {
                    int i = 0;
                    while (i < n)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        page = PdfWriterInMemory.GetImportedPage(reader, i);
                        rotation = reader.GetPageRotation(i);


                        //if (rotation == 90 || rotation == 270)
                        //{

                        //    cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        //}
                        //else
                        //{
                        //    ////cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);


                        int pageRotation = reader.GetPageRotation(i);
                        float pageWidth = reader.GetPageSizeWithRotation(i).Width;
                        float pageHeight = reader.GetPageSizeWithRotation(i).Height;

                        switch (pageRotation)
                        {
                            case 0:
                                PdfWriterInMemory.DirectContent.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                                break;

                            case 90:
                                PdfWriterInMemory.DirectContent.AddTemplate(page, 0, -1f, 1f, 0, 0, pageHeight);

                                break;

                            case 180:
                                PdfWriterInMemory.DirectContent.AddTemplate(page, -1f, 0, 0, -1f, pageWidth, pageHeight);
                                break;

                            case 270:
                                PdfWriterInMemory.DirectContent.AddTemplate(page, 0, 1f, -1f, 0, pageWidth, 0);
                                break;

                            default:
                                throw new InvalidOperationException(string.Format("Unexpected page rotation: [{0}].", pageRotation));
                        }

                        //}

                        Console.WriteLine("Processed page " + i);
                    }
                    f++;
                    if (f < lstPDF_Files.Count)
                    {
                        reader = new PdfReader(lstPDF_Files[f]);
                        // we retrieve the total number of pages
                        n = reader.NumberOfPages;
                        Console.WriteLine("There are " + n + " pages in the original file.");
                    }
                }

                // step 5: we close the document
                document.Close();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
            }

            //// load bytes from file is super easy in C#
            //byte[] bytes = System.IO.File.ReadAllBytes("myfile.pdf");

            //// munge bytes with whatever pdf software you want
            //// ...

            //// and save back
            //System.IO.File.WriteAllBytes("myfile.pdf", bytes);

            return msPDFData.ToArray();
        }


        public static byte[] getBytArrRotate(string strPDF_Files)
        {
            MemoryStream msPDFData = new MemoryStream();

            try
            {
                int f = 0;
                PdfReader reader = new PdfReader(HttpContext.Current.Server.MapPath(strPDF_Files));  // we create a reader for a certain document

                int n = reader.NumberOfPages;   // we retrieve the total number of pages

                Document document = new Document(reader.GetPageSizeWithRotation(1));    // step 1: creation of a document-object

                //PdfWriter PdfWriterInFile = PdfWriter.GetInstance(document, new FileStream("", FileMode.Create)); // step 2: we create a writer that listens to the document
                PdfWriter PdfWriterInMemory = PdfWriter.GetInstance(document, msPDFData);   // step 2: we create a writer that listens to the document

                document.Open();                // step 3: we open the document
                PdfContentByte cb = PdfWriterInMemory.DirectContent;
                PdfImportedPage page;
                int rotation;


                int i = 0;
                while (i < n)
                {
                    i++;
                    document.SetPageSize(reader.GetPageSizeWithRotation(i));
                    document.NewPage();
                    page = PdfWriterInMemory.GetImportedPage(reader, i);
                    rotation = reader.GetPageRotation(i);



                    int pageRotation = reader.GetPageRotation(i);
                    float pageWidth = reader.GetPageSizeWithRotation(i).Width;
                    float pageHeight = reader.GetPageSizeWithRotation(i).Height;


                    //PdfWriterInMemory.DirectContent.AddTemplate(page, 0, 1f, -1f, 0, pageHeight, 0);    //Working

                    PdfWriterInMemory.DirectContent.AddTemplate(page, 0, -1f, 1f, 0, pageHeight, 0);

                    //PdfWriterInMemory.DirectContent.AddTemplate(page, 0, -1f, 1f, 0, 0, pageWidth); //Partially works

                    //PdfWriterInMemory.DirectContent.AddTemplate(page, 1f, 0, 0, 1f, pageWidth, 0); //original for 0
                    break;

                    //}

                    Console.WriteLine("Processed page " + i);
                }


                reader = new PdfReader(HttpContext.Current.Server.MapPath(strPDF_Files));
                // we retrieve the total number of pages
                n = reader.NumberOfPages;
                Console.WriteLine("There are " + n + " pages in the original file.");

                // step 5: we close the document
                document.Close();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
            }

            return msPDFData.ToArray();
        }


        public static byte[] concatAndAddContent1(byte[] _byteArrayPDF, string _strTag)
        {
            byte[] todos;

            using (MemoryStream ms = new MemoryStream())
            {
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                Font times = new Font(bfTimes, 12, Font.BOLD, Color.BLACK);

                Document doc = new Document();

                PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                doc.SetPageSize(PageSize.LETTER);
                doc.Open();
                PdfContentByte cb = writer.DirectContent;


                PdfImportedPage page;

                //PdfCopy copy = new PdfCopy(doc, ms);
                //PdfCopy.PageStamp stamp;

                PdfReader reader;
                //foreach (byte[] p in _lst_byteArrayPDF)
                //{
                reader = new PdfReader(_byteArrayPDF);
                int pages = reader.NumberOfPages;

                // loop over document pages
                for (int i = 1; i <= pages; i++)
                {
                    doc.SetPageSize(PageSize.LETTER);
                    doc.NewPage();
                    page = writer.GetImportedPage(reader, i);
                    cb.AddTemplate(page, 0, 0);
                    //page = copy.GetImportedPage(reader, i);
                    //stamp = copy.CreatePageStamp(page);
                    //cb = stamp.GetUnderContent();
                    //cb.SaveState();
                    //stamp.AlterContents();
                    //copy.AddPage(page);
                    //Phrase phrase = new Phrase(_strTAG, times);
                    //doc.Add(phrase);

                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb.SetColorFill(new CMYKColor(0f, 0f, 0f, 0f));

                    cb.MoveTo(0, 700);
                    cb.LineTo(100, 700);
                    cb.LineTo(100, 780);
                    cb.LineTo(0, 780);
                    cb.Fill();

                    cb.SetColorFill(Color.BLACK);
                    cb.SetFontAndSize(bf, 10);

                    cb.BeginText();
                    cb.ShowTextAligned(3, "TAG: " + _strTag, 42, 750, 0);
                    cb.EndText();
                }
                //}

                doc.Close();
                todos = ms.GetBuffer();
                ms.Flush();
                ms.Dispose();
            }

            return todos;
        }


        public static byte[] concatAndAddContent(List<byte[]> _lst_byteArrayPDF)
        {
            byte[] todos;

            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document();

                PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                doc.SetPageSize(PageSize.LETTER);
                doc.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;

                //PdfCopy copy = new PdfCopy(doc, ms);
                //PdfCopy.PageStamp stamp;

                PdfReader reader;
                foreach (byte[] p in _lst_byteArrayPDF)
                {
                    if (p != null && p.Length > 0)
                    {
                        reader = new PdfReader(p);
                        int pages = reader.NumberOfPages;

                        // loop over document pages
                        for (int i = 1; i <= pages; i++)
                        {
                            doc.SetPageSize(PageSize.LETTER);
                            doc.NewPage();
                            page = writer.GetImportedPage(reader, i);
                            cb.AddTemplate(page, 0, 0);


                            //page = copy.GetImportedPage(reader, i);
                            //stamp = copy.CreatePageStamp(page);
                            //cb = stamp.GetUnderContent();
                            //cb.SaveState();
                            //stamp.AlterContents();
                            //copy.AddPage(page);
                        }
                    }
                }

                doc.Close();
                todos = ms.GetBuffer();
                ms.Flush();
                ms.Dispose();
            }

            return todos;
        }




        public static int get_intNoOfPages(List<byte[]> pdf)
        {
            //byte[] todos;

            int intTotalPages = 0;

            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document();

                PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                doc.SetPageSize(PageSize.LETTER);
                doc.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;

                //PdfCopy copy = new PdfCopy(doc, ms);
                //PdfCopy.PageStamp stamp;

                PdfReader reader;
                foreach (byte[] p in pdf)
                {
                    reader = new PdfReader(p);
                    int intPages = reader.NumberOfPages;

                    // loop over document pages
                    for (int i = 1; i <= intPages; i++)
                    {
                        doc.SetPageSize(PageSize.LETTER);
                        doc.NewPage();
                        page = writer.GetImportedPage(reader, i);
                        cb.AddTemplate(page, 0, 0);
                        //page = copy.GetImportedPage(reader, i);
                        //stamp = copy.CreatePageStamp(page);
                        //cb = stamp.GetUnderContent();
                        //cb.SaveState();
                        //stamp.AlterContents();
                        //copy.AddPage(page);
                    }

                    intTotalPages = intTotalPages + intPages;
                }

                doc.Close();
                //todos = ms.GetBuffer();
                ms.Flush();
                ms.Dispose();
            }

            return intTotalPages;
        }


        public static void FindAndKillPDF_Process()
        {
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                //now we're going to see if any of the running processes
                //match the currently running processes by using the StartsWith Method,
                //this prevents us from incluing the .EXE for the process we're looking for.
                //. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running
                if (clsProcess.ProcessName.StartsWith("AcroRd32") || clsProcess.ProcessName.StartsWith("AdobeARM"))
                {
                    clsProcess.Kill();
                    //since we found the proccess we now need to use the
                    //Kill Method to kill the process. Remember, if you have
                    //the process running more than once, say IE open 4
                    //times the loop thr way it is now will close all 4,
                    //if you want it to just close the first one it finds
                    //then add a return; after the Kill
                    //process killed, return true
                }
            }

            //Process[] runningProcesses = Process.GetProcesses();
            //foreach (Process process in runningProcesses)
            //{
            //    // now check the modules of the process
            //    foreach (ProcessModule module in process.Modules)
            //    {
            //        if (module.FileName.Equals("AcroRd32.exe"))
            //        {
            //            process.Kill();
            //        }
            //    }
            //}
        }


        public static void FindAndKillPDF_File(string _strFile)
        {
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.StartsWith("AcroRd32") || clsProcess.ProcessName.StartsWith("AdobeARM"))
                {
                    if (clsProcess.MainWindowTitle == _strFile)
                    {
                        clsProcess.CloseMainWindow();
                    }
                }
            }
        }


        public static void ShowPDF(byte[] bytPDF, string _strFileName)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + _strFileName + ".pdf");

            HttpContext.Current.Response.BinaryWrite(bytPDF);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Clear();
        }


        public static void ShowExcel(byte[] bytPDF, string _strFileName)
        {
            //Response.ClearContent();
            //Response.AddHeader("Content-type", "application/vnd.ms-excel");
            //Response.AddHeader("content-disposition", "attachment;filename=export.xls");
            //Response.ContentType = "application/excel";

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + _strFileName + ".pdf");

            HttpContext.Current.Response.BinaryWrite(bytPDF);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Clear();
        }


        public static void CreateDirectory()
        {
            // Specify the directory you want to manipulate. 
            string path = "C:\\Users\\Public\\";

            try
            {
                // Determine whether the directory exists. 
                if (Directory.Exists(path))
                {
                    //Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                //// Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }
    }
}