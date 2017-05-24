using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyseEtControleFEC
{
    /// <summary>
    /// Manage the creation and the filling of the structural
    /// report file.
    /// </summary>
    class LogHelper
    {
        public static string file { get; set; } = "";

        /// <summary>
        /// Write the information about controls in the file
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        /// <param name="className"></param>
        public static void WriteToFile(string errorMessage, string className)
        {
            DateTime nowDate = DateTime.Now;
            string shortDate = String.Format("{0:yyyy-MM-dd-HH-mm}", nowDate);
            string filename = "Rapport_" + file.Split('.')[0] + "_" + string.Format("{0}.log", shortDate);
            
            // Creation of the log file
            filename = filename.Replace("/", "-");
            
            // Get complete file path
            string rootPath = Path.GetFullPath("./Data/Log/");
            string fullFilename = string.Format(@"{0}{1}", rootPath, filename);
            
            // Check Data & Log folders
            if (!Directory.Exists(rootPath))
            {
                // Folder creation
                Directory.CreateDirectory(rootPath);
            }
            
            // Check file
            if (!System.IO.File.Exists(fullFilename))
            {
                System.IO.FileStream f = System.IO.File.Create(fullFilename);
                f.Close();
            }

            using (StreamWriter writer = new StreamWriter(fullFilename, true))
            {
                // Writting in the file
                writer.WriteLine(string.Format(
                                       "[{0} ON {1}] : {2}",
                                       DateTime.Now,
                                       className,
                                       errorMessage));
            }
        }
    }
}

