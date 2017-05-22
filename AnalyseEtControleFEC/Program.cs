using AnalyseEtControleFEC.Controller;
using AnalyseEtControleFEC.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AnalyseEtControleFEC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MainController mainController = MainController.Get();
            mainController.Start();
            DataBaseController data = mainController.GetDataBaseController();
        }
    }
}
