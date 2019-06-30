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
        public void TakeAScreenshot(IWebDriver driver,string fileName,int waitTime=2000)
        {
            Console.WriteLine(fileName);
            var screen = ((ITakesScreenshot)driver).GetScreenshot();
            screen = ((ITakesScreenshot)driver).GetScreenshot();
            screen.SaveAsFile(fileName);
            System.Threading.Thread.Sleep(waitTime);
        }

        public static object Assertion { get; private set; }

        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new RemoteWebDriver(new Uri("http://172.17.0.2:4444/wd/hub"), new ChromeOptions());
            try
            {
                driver.Navigate().GoToUrl("https://www.google.com");
                this.TakeAScreenshot(driver, CommonEnvironment.ImageFileName());

                this.TakeAScreenshot(driver, CommonEnvironment.ImageFileName());

                driver.FindElement(By.ClassName("gLFyf")).SendKeys("‚«‚È•²–Ý,net");
                this.TakeAScreenshot(driver, CommonEnvironment.ImageFileName());

                driver.FindElement(By.ClassName("gLFyf")).SendKeys(Keys.Enter);
                this.TakeAScreenshot(driver, CommonEnvironment.ImageFileName(),10000);

                driver.FindElement(By.TagName("h3")).Click();
                this.TakeAScreenshot(driver, CommonEnvironment.ImageFileName());



                var actual = driver.FindElement(By.TagName("h1")).Text;
                var expected = "‚«‚È‚±‚à‚¿.net";
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
