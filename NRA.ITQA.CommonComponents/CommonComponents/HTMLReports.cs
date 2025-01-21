using System;
using System.Collections.Generic;
using System.Text;

namespace CommonComponents
{
    public static class HTMLReports
    {
        public static void CreateTest(string testname, string category) => Constants.test = Constants.extent.CreateTest(testname, "").AssignCategory(new string[1]
          {
                category
          });
    }
}
