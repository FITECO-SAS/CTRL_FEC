using AnalyseEtControleFEC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AnalyseEtControleFEC.Controller
{
    public class MainController
    {
        //Static Thread stuff
        static String threadPath;
        static String threadFileName;
        static public void threadedLoadFromFile()
        {
            ErrorLogger logger = new ErrorLogger(config, instance.getDataBaseController(), "BIC", "PCG");
            instance.getDataBaseController().fillDatabaseFromFile(threadPath);
            logger.checkName(threadFileName);
            logger.checkColumns();
            //logger.checkLinesInDatabase();
            instance.finalizeOpenFileFromThread();
            //logger.check_Dates();
            //Console.WriteLine(logger.check_CompAuxNum_CompAuxLib());
            Console.WriteLine(logger.createLog());
            logger.check_CompAuxNum_CompAuxLib();
            logger.check_EcritureLet_DateLet();
            logger.check_Montantdevise_Idevise();
            logger.check_PieceDate_EcritureDate();
            logger.check_PieceDate_ValidDate();
            logger.check_EcritureDate_ValidDate();
            logger.check_DateLet_PieceDate();
            logger.check_DateLet_EcritureDate();
            logger.check_Is_Montant_Sens();
            //logger.Ecrirefile(logger.lineRegexErrors, "test1.txt");
        }

        //Constants
        static String dataBaseFile = "data.SQLite";
        static String configuration = "Configuration.json";
        static Configuration config;
        static MainController instance;

        public DataBaseController dataBaseController { get; set; }
        public SimpleFilterController simpleFilterController { get; set; }
        Start mainWindow;

        static public MainController get()
        {
            if(instance == null)
            {
                instance = new MainController();
            }
            return instance;
        }
        private MainController()
        {
            dataBaseController = new DataBaseController(dataBaseFile,this);
            simpleFilterController = new SimpleFilterController(dataBaseController);
            config = new Configuration(configuration);
        }

        public DataBaseController getDataBaseController()
        {
            return dataBaseController;
        }

        public SimpleFilterController getSimpleFilterController()
        {
            return simpleFilterController;
        }

        public void start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Configuration config = new Configuration(configuration);
            mainWindow = new Start();
            Application.Run(mainWindow);
        }

        /// <summary>
        /// analyser les données (controles élémentaires)
       /// </summary>
        public void analyzeData()
        {
            for(int i = 0; i<mainWindow.getDataGridView().RowCount; i++)
            {
                for(int j = 0; j<mainWindow.getDataGridView().ColumnCount; j++)
                {
                    if(!isCellValid(j, (String)mainWindow.getDataGridView().Rows[i].Cells[j].Value))
                    {
                        mainWindow.getDataGridView().Rows[i].Cells[j].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        mainWindow.getDataGridView().Rows[i].Cells[j].Style.ForeColor = Color.Green;
                    }
                }
            }
        }

        /// <summary>
        /// vérifier la validiter des champs
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <param name="columnContent"></param>
        /// <returns> boolean </returns>
        private bool isCellValid(int columnNumber, String columnContent)
        {
            if(columnContent==null)
            {
                return false;
            }
            switch (columnNumber)
            {
                case 0:
                     Regex regx1 = new Regex("^\\w+$");
                    return regx1.IsMatch(columnContent);
                case 1:
                    Regex regx2 = new Regex("^\\w+[^\\|]$");
                    return regx2.IsMatch(columnContent);
                case 2:
                    Regex regx3 = new Regex("^*\\w*[^\\|]+[0-9]$");
                    return regx3.IsMatch(columnContent);
                case 3:
                    Regex regx4 = new Regex("^(19|20)\\d\\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])$");
                    return regx4.IsMatch(columnContent);
                case 4:
                    Regex regx5 = new Regex("^[0-9]");
                    return regx5.IsMatch(columnContent);
                case 5:
                    Regex regx6 = new Regex("\\w+[^\\|]$");
                    return regx6.IsMatch(columnContent);
                case 6:
                    Regex regx7 = new Regex("\\w*[^\\|]$");
                    return regx7.IsMatch(columnContent);
                case 7:
                    Regex regx8 = new Regex("\\w*[^\\|]$");
                    return regx8.IsMatch(columnContent);
                case 8:
                    Regex regx9 = new Regex("\\w+[^\\|]$");
                    return regx9.IsMatch(columnContent);
                case 9:
                    Regex regx10 = new Regex("^(19|20)\\d\\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])$");
                     return regx10.IsMatch(columnContent);
                case 10:
                    Regex regx11 = new Regex("\\w+[^\\|]$");
                    return regx11.IsMatch(columnContent);
                case 11:
                    Regex regx12 = new Regex("^\\d+\\,+\\d{2}$");
                    return regx12.IsMatch(columnContent);
                case 12:
                    Regex regx13 = new Regex("^\\d+\\,+\\d{2}$");
                    return regx13.IsMatch(columnContent);
                case 13:
                    Regex regx14 = new Regex("\\w*[^\\|]$");
                    return regx14.IsMatch(columnContent);
                case 14:
                    Regex regx15 = new Regex("^(19|20)\\d\\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])$");
                    return regx15.IsMatch(columnContent);
                case 15:
                    Regex regx16 = new Regex("^(19|20)\\d\\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])$");

                    return regx16.IsMatch(columnContent);
                case 16:
                    Regex regx17 = new Regex("^\\d+\\,+\\d{2}$");
                    return regx17.IsMatch(columnContent);
                case 17:
                    Regex regx18 = new Regex("\\w+[^\\|]$");
                    return regx18.IsMatch(columnContent);
                case 18:
                    Regex regx19 = new Regex("^\\d+\\,+\\d{2}$");
                    return regx19.IsMatch(columnContent);
                case 19:
                    Regex regx20 = new Regex("^\\d*\\,*\\d{2}$");
                    return regx20.IsMatch(columnContent);


            }

            
            return false;
        }

        internal void openFile(string filePath, string fileName)
        {
            dataBaseController.init();
            threadPath = filePath;
            threadFileName = fileName;
            Thread openFileThread = new Thread(new ThreadStart(threadedLoadFromFile));
            openFileThread.Start();
        }
        public void finalizeOpenFileFromThread()
        {
            DataGridView gridView = mainWindow.getDataGridView();
            gridView.Invoke((Action)finalizeOpenFile);
        }
        public void finalizeOpenFile()
        {
            DataGridView gridView = mainWindow.getDataGridView();
            String[] Columns = dataBaseController.getColumnNames();
            int size = dataBaseController.getNumberOfLines();
            gridView.ColumnCount = Columns.Length;
            for (int i = 0; i < Columns.Length; i++)
            {
                gridView.Columns[i].Name = Columns[i];
            }
            gridView.RowCount = size;
        }

        internal void openFilter(DataGridView gridView)
        {
            String[] Columns = dataBaseController.getColumnNames();
            int size = dataBaseController.getNumberOfLinesInFilter();
            gridView.ColumnCount = Columns.Length;
            for (int i = 0; i < Columns.Length; i++)
            {
                gridView.Columns[i].Name = Columns[i];
            }
            gridView.RowCount = size;
        }
    }
}
