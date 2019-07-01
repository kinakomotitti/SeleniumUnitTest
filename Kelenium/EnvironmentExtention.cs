namespace Kelenium
{
    #region using

    using System;
    
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public class EnvironmentExtention
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetImageFolderPath()
        {
            var value = Environment.GetEnvironmentVariable("IMAGE_DIR");
            return string.IsNullOrWhiteSpace(value) ? "/app/images" : value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetResultFolderPath()
        {
            var value = Environment.GetEnvironmentVariable("RESULT_DIR");
            return string.IsNullOrWhiteSpace(value) ? "/app/result" : value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetRemoteWebDriverHost()
        {
            var value = Environment.GetEnvironmentVariable("WEB_DRIVER_HOST");
            return string.IsNullOrWhiteSpace(value) ? $"http://localhost:4444/wd/hub" : $"http://{value}:4444/wd/hub";
        }

    }
}
