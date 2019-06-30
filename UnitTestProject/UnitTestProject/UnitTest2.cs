using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        public void TakeAScreenshot(IWebDriver driver, string fileName, int waitTime = 2000)
        {
            //すぐに実行すると、前操作の結果と同じになってしまうので、少し時間を空けて実行する。
            System.Threading.Thread.Sleep(waitTime);

            Console.WriteLine(fileName);
            var screen = ((ITakesScreenshot)driver).GetScreenshot();
            screen = ((ITakesScreenshot)driver).GetScreenshot();
            screen.SaveAsFile(fileName);
        }

        public static object Assertion { get; private set; }

        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new RemoteWebDriver(new Uri("http://unittestproject_selenium-server_1:4444/wd/hub"), new ChromeOptions());
            try
            {
                driver.Navigate().GoToUrl("https://www.google.com");
                this.TakeAScreenshot(driver, CommonEnvironment.ImageFileName());

                this.TakeAScreenshot(driver, CommonEnvironment.ImageFileName());

                driver.FindElement(By.ClassName("gLFyf")).SendKeys("きな粉餅,net");
                this.TakeAScreenshot(driver, CommonEnvironment.ImageFileName());

                driver.FindElement(By.ClassName("gLFyf")).SendKeys(Keys.Enter);
                this.TakeAScreenshot(driver, CommonEnvironment.ImageFileName(), 10000);

                driver.FindElement(By.TagName("h3")).Click();
                this.TakeAScreenshot(driver, CommonEnvironment.ImageFileName());



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

        [TestMethod]
        public void TestMethod2()
        {
            Thread.Sleep(1000);
            Assert.IsTrue(false);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Thread.Sleep(1000);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Thread.Sleep(1000);
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Thread.Sleep(1000);
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Thread.Sleep(1000);
            Assert.IsTrue(true);
        }
    }
}
