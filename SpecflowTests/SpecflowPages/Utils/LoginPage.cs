using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Utils
{
  public class LoginPage
    {
        public static void LoginStep()
        {
            Driver.NavigateUrl();
            Thread.Sleep(1000);

            //Enter Url
            Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Sign In')]")).Click();

            //Enter Username
            Driver.driver.FindElement(By.XPath("//input[contains(@placeholder,'Email address')]")).SendKeys("mvpstudio.qa@gmail.com");

            //Enter password
            Driver.driver.FindElement(By.XPath("//input[contains(@type,'password')]")).SendKeys("SydneyQa2018");
            Thread.Sleep(1000);
            //Click on Login Button
            Driver.driver.FindElement(By.XPath("//button[@class='fluid ui teal button'][contains(.,'Login')]")).Click();

          
        }

    }
}
