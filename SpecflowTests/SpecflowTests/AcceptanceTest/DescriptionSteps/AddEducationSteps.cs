using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using SpecflowPages.Utils;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddEducationSteps
    {
       
        
        [Given(@"I have clicked the add new button in education area")]
        public void GivenIHaveClickedTheAddNewButtonInEducationArea()
        {
               
            Thread.Sleep(2000);
            // select the education 
            Driver.driver.FindElement(By.XPath("//a[@data-tab='third']")).Click();
            Thread.Sleep(4000);
            // add the new education information
            Driver.driver.FindElement(By.XPath("(//div[@class='ui teal button '])[2]")).Click();
            //fill in the university details   

            Driver.driver.FindElement(By.XPath("//input[contains(@placeholder,'College/University Name')]")).SendKeys("University of Auckland");
            // add the country
            Driver.driver.FindElement(By.XPath("//select[contains(@name,'country')]")).Click();
            var optionCountry = Driver.driver.FindElement(By.Name("country"));
            var select1 = new SelectElement(optionCountry);
            Thread.Sleep(2000);
            select1.SelectByText("New Zealand");
            // add the title
            var optionTitle = Driver.driver.FindElement(By.Name("title"));
            var select2 = new SelectElement(optionTitle);
          // add the degree
            select2.SelectByText("M.A");
            Driver.driver.FindElement(By.XPath("//input[contains(@placeholder,'Degree')]")).SendKeys("Bachelor");
           // add the year 
            var optionYear = Driver.driver.FindElement(By.Name("yearOfGraduation"));
            var select3 = new SelectElement(optionYear);
            Thread.Sleep(1000);
            select3.SelectByText("2019");
            // save it
            Driver.driver.FindElement(By.XPath("//input[contains(@class,'ui teal button ')]")).Click();
        }
        
        [Then(@"the result should be saved and shown on the profile page")]
        public void ThenTheResultShouldBeSavedAndShownOnTheProfilePage()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Education");

                Thread.Sleep(1000);
                string ExpectedValue = "University of Auckland";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id=\"account - profile - section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[2]")).Text;
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
