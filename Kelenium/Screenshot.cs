namespace Kelenium
{
    #region using

    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;

    #endregion

    /// <summary>
    /// 
    /// </summary>
    public class Screenshot
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        public Screenshot(IWebDriver driver)
        {
            this._screenshot = (ITakesScreenshot)driver;
        }

        /// <summary>
        /// 
        /// </summary>
        public ITakesScreenshot _screenshot { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="fileName"></param>
        /// <param name="waitTime"></param>
        public void TakeAScreenshot(int waitTime = 2000,[CallerMemberName] string memberName = "",
                                    [CallerLineNumber] int lineNumber = -1
                                    )
        {
            //すぐにｽｸｼｮ取得すると、操作結果の絵が取得できないので、少し待機する。
            System.Threading.Thread.Sleep(waitTime);

            var fileName = this.ImageFileName(memberName, lineNumber);


            var screen = this._screenshot.GetScreenshot();
            Console.WriteLine(fileName);
            screen.SaveAsFile(fileName);
        }


        private string ImageFileName(string memberName, int lineNumber)
        {
            ;
            string outputFileName = $"{ memberName }-{ lineNumber}Line -{ DateTime.Now.ToString("yyyyMMdd_hhmmss")}.png";

            return Path.Combine(EnvironmentExtention.GetImageFolderPath(), outputFileName);
        }
    }
}