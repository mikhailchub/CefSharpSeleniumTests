using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CefDriverTest
{
    [TestClass]
    public class CefTestsWithUpdatedApp
    {
        public static IWebDriver driver;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            ChromeOptions options = new ChromeOptions();
            // Debugging port to communicate with
            options.DebuggerAddress = "localhost:8081";

            driver = new ChromeDriver(options);
        }

        [TestMethod]
        public void PutValuesToInputs()
        {
            driver.FindElement(By.Id("inputName")).SendKeys("cef test");
            driver.FindElement(By.Id("inputEmail")).SendKeys("cef@test.com");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Quit();
        }
    }
}
