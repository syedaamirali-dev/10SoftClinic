using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ApplicationUtility
{
    public static class Logger
    {
       // static bool Isdebug = Convert.ToBoolean(ConfigurationManager.AppSettings["DebugMode"].ToString());
        //static string logPath = ConfigurationManager.AppSettings["LogPath"].ToString();
        //static string logPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string datetime = DateTime.Now.ToString("MM-dd-yyyy HH-mm");
     
        /**
         * Debug 
         * Params: 
         * String text: Any text from the developer
         * Object[] parameters: list of dynamic parameters to log relevent data to debug
         * Creates a log file with the text and paramters. 
         * **/
        //public static void Debug(string text, params object[] parameters)
        //{
        //     string appDomain = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        //    if (Isdebug)
        //    {
        //        string context = "";
        //        for (var i = 0; i < parameters.Length; i++)
        //        {
        //            context += " param" + (i + 1).ToString() + ": " + parameters[i].ToString();
        //        }
        //        string []lines = { Environment.NewLine , "[Debug: " + text + "] [" + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + "]","[Context]: " + Convert.ToString(context), Environment.NewLine };
        //        //int fCount = Directory.GetFiles(logPath, "*", SearchOption.TopDirectoryOnly).Length;
        //        LogFile(lines);
        //    }
        //}

        public static void Error(Exception ex, string logPath, string fileName, params object[] parameters)
        {
            string context = "";
            for (var i = 0; i < parameters.Length; i++)
            {
                context += " param" + (i + 1).ToString() + ": " + parameters[i].ToString();
            }
            string []lines = { Environment.NewLine ,"[Error]: " + ex.GetType().FullName.ToString(), "[Context]: " + Convert.ToString(context) + " [" + datetime + "]","Message : " + ex.Message, "InnerMessage : " + ex.InnerException,  "StackTrace : " + ex.StackTrace, Environment.NewLine };
            LogFile(lines, logPath,fileName);
        }
        public static void LogFile(string[] lines, string logPath,string fileName)
        {
             fileName = logPath + "log_" + datetime + ".txt";
            var directory = new DirectoryInfo(logPath);
            if (directory.Exists)
            {
                if (directory.GetFiles().Count() > 0)
                {
                    FileInfo myFile = directory.GetFiles()
                              .OrderByDescending(f => f.LastWriteTime)
                              .First();

                    if (datetime.Substring(datetime.Length - 5, 2) == myFile.Name.Substring(myFile.Name.Length - 9, 2))
                    {
                        int difference = Convert.ToInt32(datetime.Substring(datetime.Length - 2)) - Convert.ToInt32(myFile.Name.Substring(myFile.Name.Length - 6, 2));
                        if (difference >= 10)
                        {
                            File.WriteAllLines(fileName, lines);
                        }
                        else
                        {
                            File.AppendAllLines(myFile.FullName, lines);
                        }
                    }
                    else
                    {
                        File.WriteAllLines(fileName, lines);
                    }
                }
                else
                {
                    File.WriteAllLines(fileName, lines);
                }
            }
            else
            {
                Directory.CreateDirectory(logPath);
                File.WriteAllLines(fileName, lines);
            }
        }
    }
}
