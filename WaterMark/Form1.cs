using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaterMark.Classes;
using Newtonsoft.Json;

namespace WaterMark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //
            Program.objLog.objTextBox = textBox1;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //LOG MESSAGE
            Program.objLog.writeLog("Program Start");

            //PDF OBJECT
            pdfClass objPDF = new pdfClass();

            //GET PDF LISTING FROM INPUT DIRECTORY
            List<String> pdfListing = objPDF.getPDFListing();


            //ITERATE OVER LISTING AND SET WATERMARK
            pdfListing.ForEach(objItem =>
            {
                objPDF.setWaterMark(objItem);

            });



        }
    }
}
