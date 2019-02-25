using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.ReportUtility
{
   public class ReportGenerator
    {
         ExtentReports report;
        //create html report in bin/debug/reports
        public  ExtentReports createReport()
        {
            //report = new ExtentReports(CreateReportPath.dynamicPath() + "\\"+ browserName + "Report.html", false);
      //      report = new ExtentReports(CreateReportPath.dynamicPath() + "\\Report.html", true);
            report = new ExtentReports("E:/Report.html", false);

            return report;
        }
    }
}
