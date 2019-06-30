using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace UnitTestProject
{
    public static class CommonEnvironment
    {
        public static string ImageFileDir { get; set; } = "/app/images";
        public static object FilePath { get; private set; }

        public static string ImageFileName(
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = -1)
        {
            ;
            string outputFileName = $"{ memberName }-{ lineNumber}Line -{ DateTime.Now.ToString("yyyyMMdd_hhmmss")}.png";

            return Path.Combine(ImageFileDir, outputFileName);
        }
    }
}
