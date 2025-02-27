﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollTestProject1.Reports
{
    internal class ExtentReportsManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static string _reportPath =
            Path.Combine(Directory.GetCurrentDirectory(), "TestResult", "ExtentReport.html");

        public static void InitReport()
        {
            var sparkReport = new ExtentSparkReporter(_reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReport);
        }

        public static void StartTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static void LongStep(bool success, string stepDetails)
        {
            if (success)
            {
                _test.Log(Status.Pass, stepDetails);
            }
            else
            {
                _test.Log(Status.Fail, stepDetails);
            }
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }

}
