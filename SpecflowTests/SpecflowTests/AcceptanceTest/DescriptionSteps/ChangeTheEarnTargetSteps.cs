using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.DescriptionSteps
{
    [Binding]
    public class ChangeTheEarnTargetSteps
    {
        [Given(@"I have changed the earn target")]
        public void GivenIHaveChangedTheEarnTarget()
        {
            Driver.driver.FindElement(By.XPath("(//i[contains(@class,'right floated outline small write icon')])[3]")).Click();
            Driver.driver.FindElement(By.XPath("//select[contains(@class,'ui right labeled dropdown')]")).Click();
            var optionTarget = Driver.driver.FindElement(By.Name("availabiltyTarget"));
            var select1 = new SelectElement(optionTarget);
            Thread.Sleep(2000);
            select1.SelectByText("More than $1000 per month");

        }
        
        [Then(@"the result should be shown on the profile page")]
        public void ThenTheResultShouldBeShownOnTheProfilePage()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("change a earn target");

                Thread.Sleep(200);
                string ExpectedValue = "More than $1000 per month";
                string ActualValue = Driver.driver.FindElement(By.XPath("//select[contains(@class,'ui right labeled dropdown')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
