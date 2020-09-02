using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Linq;

namespace CefDriverTest
{
    [TestClass]
    public class CefTestsWithUpdatedApp
    {
        public static IWebDriver driver;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Start win app
            Process.Start("c:\\sources\\cefsharp_demo\\cefsharp_v2\\bin\\x64\\Debug\\cefsharp_v2");
    
            // Debugging port to communicate with
            ChromeOptions options = new ChromeOptions();
            options.DebuggerAddress = "localhost:8081";
            driver = new ChromeDriver(options);
        }

        [TestMethod]
        public void PutValuesToInputs()
        {
            driver.FindElement(By.Id("inputName")).SendKeys("cef test");
            driver.FindElement(By.Id("inputEmail")).SendKeys("cef@test.com");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Quit();
            Process.GetProcessesByName("cefsharp_v2").First().Kill();
        }
    }
}
