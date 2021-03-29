using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WaterMark.Classes
{
    class logClass
    {
        public String logFile { get; set; }

        public TextBox objTextBox { get; set; }



        public Boolean writeLog(String Information)
        {

            //WRITE ON PANEL
            this.objTextBox.AppendText(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss - ") + Information + Environment.NewLine);
            //
            this.objTextBox.ScrollToCaret();
            //

            try
            {
                //WRITE ON FILE
                File.AppendAllTextAsync(this.logFile, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss - ") + Information + Environment.NewLine);


            }catch(Exception)
            { }

            return true;
        }


    }
}
