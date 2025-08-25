using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumProjectDemoQA.Helpers
{
    public class WaitHelper
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public WaitHelper(IWebDriver driver, int timeoutInSeconds = 10)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        public IWebElement WaitUntilElementClickable(By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public IWebElement WaitUntilElementVisible(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        //public bool WaitUntilElementDisappears(By locator)
        //{
        //    return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        //}

        //public bool WaitUntilTextPresent(By locator, string text)
        //{
        //    return wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        //}
    }
}