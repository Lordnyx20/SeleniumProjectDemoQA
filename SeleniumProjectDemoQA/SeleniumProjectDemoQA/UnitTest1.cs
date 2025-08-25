using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumProjectDemoQA.Helpers;

namespace SeleniumProjectDemoQA
{
    public class Tests
    {
        private IWebDriver driver;
        private WaitHelper wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WaitHelper(driver);
        }
        [Test]
        public void BasicNavigationElementsCard()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/");
            //XPath locator
            wait.WaitUntilElementClickable(By.XPath("//h5[text()='Elements']/ancestor::div[@class='card mt-4 top-card']")).Click();
            //CCS locator
            wait.WaitUntilElementVisible(By.CssSelector(".btn.btn-light")).Click();
            //Text Boxes
            wait.WaitUntilElementClickable(By.Id("userName")).SendKeys("Andrew Abrenica");
            wait.WaitUntilElementClickable(By.Id("userEmail")).SendKeys("andrewabrenica@demoqa.com");
            wait.WaitUntilElementClickable(By.Id("currentAddress")).SendKeys("362 P. Burgos St. Test");
            wait.WaitUntilElementClickable(By.Id("permanentAddress")).SendKeys("Tanay, Rizal");
            wait.WaitUntilElementClickable(By.Id("submit")).Click();

            //Assertion
            var nameOutput = wait.WaitUntilElementVisible(By.Id("name")).Text;
            var emailOutput = wait.WaitUntilElementVisible(By.Id("email")).Text;

            Assert.IsTrue(nameOutput.Contains("Andrew Abrenica"), "Name not displayed correctly.");
            Assert.IsTrue(emailOutput.Contains("andrewabrenica@demoqa.com"), "Email not displayed correctly.");

        }
        [Test]
        public void RadioButton()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/");

            wait.WaitUntilElementClickable(By.XPath("//h5[text()='Elements']/ancestor::div[@class='card mt-4 top-card']")).Click();
            wait.WaitUntilElementClickable(By.Id("item-2")).Click();
            wait.WaitUntilElementClickable(By.CssSelector("label[for='yesRadio']")).Click();

            var resultText = wait.WaitUntilElementVisible(By.ClassName("text-success")).Text;
            Assert.That(resultText, Is.EqualTo("Yes"), "Radio button selection result not displayed correctly.");

            wait.WaitUntilElementClickable(By.CssSelector("label[for='impressiveRadio']")).Click();

            var resultText2 = wait.WaitUntilElementVisible(By.ClassName("text-success")).Text;
            Assert.That(resultText2, Is.EqualTo("Impressive"), "Radio button selection result not displayed correctly.");
        }
        //[Test]
        //public void WebTables()
        //{
        //    driver.Navigate().GoToUrl("https://demoqa.com/");
        //    driver.Manage().Window.Maximize();
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    var elementsCard = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("addNewRecordButton")));
        //    elementsCard.Click();
        //    driver.FindElement(By.Id("firstName")).SendKeys("Andrew");
        //    driver.FindElement(By.Id("lastName")).SendKeys("Abrenica");
        //    driver.FindElement(By.Id("userEmail")).SendKeys("andrewabrenica@demoqa.com");
        //    driver.FindElement(By.Id("age")).SendKeys("31");
        //    driver.FindElement(By.Id("salary")).SendKeys("35,000");
        //    driver.FindElement(By.Id("department")).SendKeys("QA");
        //    Thread.Sleep(5000);

        //}

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}