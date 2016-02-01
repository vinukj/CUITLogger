
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace CUITLogger
{
    /// <summary>
    /// 
    /// </summary>
    public class TestCaseInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Owner { get; set; }
        public int Priority { get; set; }
        public string Category { get; set; }
        public string TestId { get; set; }
        public string ModuleName { get; set; }
        public string TestName { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public TestContext TestContext { get; set; }
        public string TestOutCome { get; set; }

        public TestCaseInfo()
        {
            this.TestId = "Not Specified";
            this.ModuleName = "Not Specified";
        }

        public TestCaseInfo(MethodInfo method, Object instance)
        {
            TestName = method.Name;

            MethodInfo info = method;

            Object[] workItem = info.GetCustomAttributes(typeof(WorkItemAttribute), false);

            if (workItem.Length > 0)
            {
                this.TestId = (workItem[0] as WorkItemAttribute).Id.ToString();
            }
            else
            {
                this.TestId = "Default";
            }
            object[] attr = info.GetCustomAttributes(typeof(OwnerAttribute), true);

            if (attr.Length > 0)
            {
                Owner = (attr[0] as OwnerAttribute).Owner;
            }
            else
            {
                this.Owner = "Default";
            }
            attr = info.GetCustomAttributes(typeof(PriorityAttribute), true);

            if (attr.Length > 0)
            {
                Priority = (attr[0] as PriorityAttribute).Priority;
            }
            else
            {
                this.Priority =0;
            }
            attr = info.GetCustomAttributes(typeof(TestCategoryAttribute), true);

            if (attr.Length > 0)
            {
                Category = (attr[0] as TestCategoryAttribute).TestCategories[0];
            }
            else
            {
                this.Category = "Default";
            }
        }
    }
}
