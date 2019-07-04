using Kelenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        public static object Assertion { get; private set; }

        [TestMethod]
        public void TestMethod1()
        {
            using (var driver = new RemoteWebDriver(new Uri(EnvironmentExtention.GetRemoteWebDriverHost()), new ChromeOptions()))
            {
                var screenshot = new Kelenium.Screenshot(driver);
                try
                {
                    driver.Navigate().GoToUrl("https://www.google.com");
                    screenshot.TakeAScreenshot();

                    driver.FindElement(By.ClassName("gLFyf")).SendKeys("きな粉もちnet");
                    screenshot.TakeAScreenshot();

                    driver.FindElement(By.ClassName("gLFyf")).SendKeys(Keys.Enter);
                    screenshot.TakeAScreenshot(1000);

                    driver.FindElement(By.TagName("h3")).Click();
                    screenshot.TakeAScreenshot();


                    var actual = driver.FindElement(By.TagName("h1")).Text;
                    var expected = "きなこもち.net";
                    Assert.AreEqual(expected, actual);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetBaseException().ToString());
                    throw ex;
                }
                finally
                {
                    driver.Quit();
                }
            }

        }
    }
}


