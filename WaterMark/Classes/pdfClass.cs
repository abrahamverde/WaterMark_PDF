using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Document = iTextSharp.text.Document;
using Newtonsoft.Json;

using System.Configuration;
using System.Threading.Tasks;

namespace WaterMark.Classes
{
    class pdfClass
    {

        private String inputPath { get; set; }
        private String outputPath { get; set; }
        private String waterMarkFile { get; set; }


        //CONSTRUCTOR METHOD
        public pdfClass()
        {
            this.inputPath = Program.objConfig.pdfInputPath;
            //
            this.outputPath = Program.objConfig.pdfOutputPath;
            //
            this.waterMarkFile = Program.objConfig.WatermarkFile;
        }


        public List<String> getPDFListing()
        {
            //LOG MESSAGE
            Program.objLog.writeLog("Attempt to read input folder");


            //RETURN LISTING
            List<String> returnListing = Directory.GetFiles(this.inputPath,"*.pdf").Select(item => Path.GetFileName(item)).ToList();   //.Where(item => item.Contains(".pdf")).ToList();


            //LOG MESSAGE
            Program.objLog.writeLog("Input folder read successful");

            return returnListing;
        }


        public Boolean setWaterMark(String PDFName)
        {

            try
            {

                String strFileLocation = this.inputPath + PDFName;

                String strFileLocationOut = this.outputPath + PDFName;

                String WatermarkLocation = this.waterMarkFile;


                //LOG MESSAGE
                Program.objLog.writeLog("Attempt to set WaterMark to " + PDFName);


                ///WATERMARK IN C#
                Document document = new Document();
                PdfReader pdfReader = new PdfReader(strFileLocation);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(strFileLocationOut, FileMode.Create, FileAccess.Write, FileShare.None));
                
                //SET WATERMARK FILE
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(WatermarkLocation);

                img.SetAbsolutePosition(50, 130);
                PdfContentByte waterMark;
                //    
                for (int pageIndex = 1; pageIndex <= pdfReader.NumberOfPages; pageIndex++)
                {
                    waterMark = pdfStamper.GetOverContent(pageIndex);
                    waterMark.AddImage(img);
                }
                //
                pdfStamper.FormFlattening = true;
                pdfStamper.Close();


                //LOG MESSAGE
                Program.objLog.writeLog("Set WaterMark to " + PDFName + " successful");

            }
            catch (Exception X)
            {

                //LOG MESSAGE
                Program.objLog.writeLog("Set WaterMark to " + PDFName + " error - Exception: " + X.Message);

                return false;

            }

            return true;
        }




    }
}
