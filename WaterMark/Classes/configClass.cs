using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;


namespace WaterMark.Classes
{
    class configClass
    {

        public String pdfInputPath { get; set; }

        public String pdfOutputPath { get; set; }

        public String WatermarkFile { get; set; }

        public String logFile { get; set; }

    }
}
