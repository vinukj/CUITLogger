# CUITLogger
This project aims to add a logger to automation tests writen in coded UI for monitoring the same using Splunk


## Pre-requisite
1. Copy the QTAgent.bat from the pre-requisite folder and run it ---> this is a one time thing . change the path in the QTagent for the QTagent.config
2. Create a folder called external and add CUITLogger.dll , phantomjs ( set to copy always) & loggerconfig in that folder. Reference the dll to the project
3. Enable in test manager -> test settings for the product -> data and diagnostics. enable event logs and hit configure. There you can enable all the event types to collect any data
4. implement as in example codedUI test
		
		
## Example:

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CUITLogger
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUiTest1 :CuitLogger 
    {
        /// <summary>
        /// This is an example of the usage of the CUITlogger. first of all CodedUITest1 :CUITLogger  , then set the deployment paths. then use  this.Logger(); in the test cleanup
        /// </summary>
        public CodedUiTest1()
        {
        }

        [TestMethod]
        [DeploymentItem("Externals","Externals")]
        public void CodedUiTestMethod1()
        {
           
          
            this.UiMap.RecordedMethod1();
        }

       
       

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            this.Logger();
       
        }

       

## License

This is based on MIT license. 
