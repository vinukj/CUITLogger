

using System;
using System.IO;
using System.Net;
using System.Xml;


namespace CUITLogger.Report
{
    /// <summary>
    /// 
    /// </summary>
    public class SplunkXmlTestRunReport
    {

        string _timeFormat = "yyyy-MM-dd HH:mm:ss";
        public bool Generate(TestCaseInfo testcaseinfo,string logDirectory)
        {
            DateTime endTime = DateTime.Now;
            testcaseinfo.EndTime=endTime;
            try
            {
                XmlDocument document = new XmlDocument();
                XmlElement testRun = document.CreateElement("TestRun");
                document.AppendChild(testRun);
                string runId = Guid.NewGuid().ToString(); ;
                testRun.SetAttribute("id", runId);
                string time =testcaseinfo.StartTime.ToString(_timeFormat);
                testRun.SetAttribute("StartTime", testcaseinfo.StartTime.ToString(_timeFormat));
                testRun.SetAttribute("EndTime", testcaseinfo.EndTime.ToString(_timeFormat));
                Save(testRun, document, testcaseinfo);
                String hostName = Dns.GetHostName();

                String name = hostName + "_SplunkTestLog.splog";
                //String name = Guid.NewGuid().ToString() + "_" + "SplunkTestLog.splog";
                String fileName = logDirectory + "\\" + name;
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                document.Save(fileName);
            }
            catch (Exception exe)
            {
                return false;
            }
            return true;
        }


        public String GetName()
        {
            return "Splunk Test Run Report";
        }

        public void Save(XmlElement root, XmlDocument doc, TestCaseInfo testcaseinfo)
        {
            XmlElement testElement = doc.CreateElement("TestCase");
            testElement.SetAttribute("Name", testcaseinfo.TestName);
            testElement.SetAttribute("StartTime", testcaseinfo.StartTime.ToString(_timeFormat)); ;
            testElement.SetAttribute("EndTime", testcaseinfo.EndTime.ToString(_timeFormat));
            int count = 1;
            //TestIteration iteration = testCase.GetIterations()[count - 1];
            root.AppendChild(testElement);
            Save(testElement, doc, testcaseinfo, count);
        }

        public void Save(XmlElement root, XmlDocument doc, TestCaseInfo testCaseinfo,int count)
        {
            XmlElement testElement = doc.CreateElement("Iteration");
            testElement.SetAttribute("Priority", testCaseinfo.Priority.ToString());
            testElement.SetAttribute("Owner", testCaseinfo.Owner);
            testElement.SetAttribute("TestId", testCaseinfo.TestId);
            testElement.SetAttribute("Category", testCaseinfo.Category);
            testElement.SetAttribute("Module", testCaseinfo.ModuleName);
            testElement.SetAttribute("Result", testCaseinfo.TestOutCome);
           // TestEnvironment en = TestSession.Config.GetWebActiveEnvironment();
           // testElement.SetAttribute("Project", TestSession.Config.GetAppSettings(ConfigKeys.Project));
            //testElement.SetAttribute("Environment", en.Name);
            if (count > 1)
            {
                testElement.SetAttribute("IterationName", testCaseinfo.TestName + "_" + count);
            }
            else
            {
                testElement.SetAttribute("IterationName", testCaseinfo.TestName);
            }
            //String buildNo = "";
            //BuildInfoModel info = en.BuildInfoModel;
            //if (info != null)
            //{
            //    buildNo = info.Version;
            //}
            //testElement.SetAttribute("BuildNo", buildNo);
            string timeFormat = "yyyy-MM-dd";
            string runDate = testCaseinfo.StartTime.ToString(timeFormat);
            testElement.SetAttribute("TestRunDate", runDate);
            timeFormat = "HH:mm:ss";
            string runTime = testCaseinfo.StartTime.ToString(timeFormat);
            testElement.SetAttribute("TestRunTime", runTime);
            //String text = iteration.GetMessage();
            //testElement.SetAttribute("Message", text == null ? "" : text);
            root.AppendChild(testElement);
        }
    }
}
