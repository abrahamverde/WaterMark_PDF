using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaterMark.Classes;

namespace WaterMark
{
    static class Program
    {

        public static configClass objConfig;

        public static logClass objLog;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //GET CONFIG VALUES
            String path = "settings.json";
            ///
            objConfig = JsonConvert.DeserializeObject<configClass>(File.ReadAllText(path));
            ///
            objLog = new logClass();

            objLog.logFile = objConfig.logFile;
           

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
