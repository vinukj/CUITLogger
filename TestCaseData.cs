namespace CUITLogger
{
    class TestCaseData
    {
        // Define TestOwner
        public const string Akash = "Akash Kurup";
        public const string Vinay = "Vinay Jagtap";
        public const string Kishore = "Kishore Kuruvadi";

        // Define Categories
        public const string Bat = "Build Acceptance Test";
        public const string P1Test = "P1 Test";
        public const string P2Test = "P2 Test";
        public const string RegressionTest = "Regression Test";
        public const string E2E = "End to End Test";

        // Define Priority
        public enum Priority
        {
            P1=1,
            P2,
            P3,
        }


    }
}
