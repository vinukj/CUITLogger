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
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
            this.UiMap.RecordedMethod1();
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //   
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            this.Logger();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>

        public UiMap UiMap
        {
            get
            {
                if ((this._map == null))
                {
                    this._map = new UiMap();
                }

                return this._map;
            }
        }

        private UiMap _map;
    }
}
