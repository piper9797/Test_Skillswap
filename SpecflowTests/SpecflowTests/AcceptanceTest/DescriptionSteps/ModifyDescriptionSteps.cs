using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.DescriptionSteps
{
    [Binding]
    public class ModifyDescriptionSteps
    {
        [Given(@"I have clicked the description button")]
        public void GivenIHaveClickedTheDescriptionButton()
        {
            Thread.Sleep(5000);
           
            Driver.driver.FindElement(By.XPath("//i[contains(@class,'outline write icon')]")).Click();
        }
        
        [Given(@"I have modified it and save it")]
        public void GivenIHaveModifiedItAndSaveIt()
        {
            var textArea = Driver.driver.FindElement(By.Name("value"));
            textArea.Click();
            textArea.Clear();
            textArea.SendKeys("I am a good tester.");
            Driver.driver.FindElement(By.XPath("//button[contains(@type,'button')]")).Click();
            
        }

        [Then(@"the result should be saved on the screen")]
        public void ThenTheResultShouldBeSavedOnTheScreen()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Modify the description");

                Thread.Sleep(1000);
                string ExpectedValue = "I am a good tester.";
                string ActualValue = Driver.driver.FindElement(By.Name("value")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, modify the description Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "DescriptionModified");
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
