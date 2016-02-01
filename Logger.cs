using System;
using System.IO;

namespace CUITLogger
{
  /// <summary>
  /// 
  /// </summary>
  public class Logger
    {
        const string  LogLocation = "C:\\Temp\\Result.txt";

        FileInfo _outtxt = new FileInfo(LogLocation);
        /// <summary>
        /// 
        /// </summary>
        public Logger()
        {
           
        }

        public void GenerateLog(String testcaseSteps)
        {
            StreamWriter logline = _outtxt.AppendText();

            logline.WriteLine("{0}", testcaseSteps);
            logline.Flush();
            logline.Close();
        }
    }
}
