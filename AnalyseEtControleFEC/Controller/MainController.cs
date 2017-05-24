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
        /// <summary>
        /// boolean intialised to true that is false when a file loading thread is running
        /// </summary>
        public bool areControlsTerminated;

        /// <summary>
        /// file path for file loading
        /// </summary>
        static String threadPath;

        /// <summary>
        /// file name for file loading
        /// </summary>
        static String threadFileName;

        /// <summary>
        /// name of the dataBase file
        /// </summary>
        static String dataBaseFile = "data.SQLite";

        /// <summary>
        /// name of the configuation file
        /// </summary>
        static String configuration = "Configuration.json";

        /// <summary>
        /// associated instance of COnfiguration class
        /// </summary>
        static Configuration config;

        /// <summary>
        /// singleton instance of the MainController
        /// </summary>
        static MainController instance;

        /// <summary>
        /// associated instance of dataBaseController
        /// </summary>
        public DataBaseController dataBaseController { get; set; }

        /// <summary>
        /// associated instance of simpleFilterController
        /// </summary>
        public SimpleFilterController simpleFilterController { get; set; }

        /// <summary>
        /// Main window for this program
        /// </summary>
        Start mainWindow;

        /// <summary>
        /// Getter for singleton instance
        /// </summary>
        /// <returns>the singleton instance of MainController</returns>
        static public MainController Get()
        {
            if (instance == null)
            {
                instance = new MainController();
            }

            return instance;
        }

        /// <summary>
        /// Default constructor for MainControler (private because of Singleton pattern)
        /// </summary>
        private MainController()
        {
            dataBaseController = new DataBaseController(dataBaseFile, this);
            simpleFilterController = new SimpleFilterController(dataBaseController);
            config = new Configuration(configuration);
            areControlsTerminated = true;
        }

        /// <summary>
        /// Main code of the filter creation thread
        /// </summary>
        /// <param name="o"> an object of type tuple as casted in begin of function</param>
        static public void threadedFilterCreation(object o)
        {
            MainController controller = MainController.Get();
            controller.GetDataBaseController().RequestCheckPause();

            Tuple<int, int,
                   Tuple<String, String, String>,
                   Tuple<Tuple<bool, String, String, String>,
                   Tuple<bool, String, String, String>,
                   Tuple<bool, String, String, String>,
                   Tuple<bool, String, String, String>,
                   Tuple<bool, String, String, String>,
                   Tuple<bool, String, String, String>,
                   Tuple<bool, String, String, String>>,
                   Start> data =
                (Tuple<int, int,
                    Tuple<String, String, String>,
                    Tuple<Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>>,
                    Start>)o;

            int filterIdOfLastTab = data.Item1;
            int numberOfFilters = data.Item2;

            Tuple<String, String, String> filter1 = data.Item3;
            Tuple<bool, String, String, String> filter2 = data.Item4.Item1;
            Tuple<bool, String, String, String> filter3 = data.Item4.Item2;
            Tuple<bool, String, String, String> filter4 = data.Item4.Item3;
            Tuple<bool, String, String, String> filter5 = data.Item4.Item4;
            Tuple<bool, String, String, String> filter6 = data.Item4.Item5;
            Tuple<bool, String, String, String> filter7 = data.Item4.Item6;
            Tuple<bool, String, String, String> filter8 = data.Item4.Item7;

            Start start = data.Item5;

            if (numberOfFilters >= 1)
            {
                addFilter(filterIdOfLastTab, false, filter1.Item1, filter1.Item2, filter1.Item3);
            }

            if (numberOfFilters >= 2)
            {
                if (!filter2.Item1)
                {
                    addFilter(controller.GetDataBaseController().GetLastFilterId(), false, filter2.Item2, filter2.Item3, filter2.Item4);
                }
                else
                {
                    addFilter(filterIdOfLastTab, true, filter2.Item2, filter2.Item3, filter2.Item4);
                }
            }

            if (numberOfFilters >= 3)
            {
                if (!filter3.Item1)
                {
                    addFilter(controller.GetDataBaseController().GetLastFilterId(), false, filter3.Item2, filter3.Item3, filter3.Item4);
                }
                else
                {
                    addFilter(filterIdOfLastTab, true, filter3.Item2, filter3.Item3, filter3.Item4);
                }
            }

            if (numberOfFilters >= 4)
            {
                if (!filter4.Item1)
                {
                    addFilter(controller.GetDataBaseController().GetLastFilterId(), false, filter4.Item2, filter4.Item3, filter4.Item4);
                }
                else
                {
                    addFilter(filterIdOfLastTab, true, filter4.Item2, filter4.Item3, filter4.Item4);
                }
            }

            if (numberOfFilters >= 5)
            {
                if (!filter5.Item1)
                {
                    addFilter(controller.GetDataBaseController().GetLastFilterId(), false, filter5.Item2, filter5.Item3, filter5.Item4);
                }
                else
                {
                    addFilter(filterIdOfLastTab, true, filter6.Item2, filter6.Item3, filter6.Item4);
                }
            }

            if (numberOfFilters >= 6)
            {
                if (!filter6.Item1)
                {
                    addFilter(controller.GetDataBaseController().GetLastFilterId(), false, filter6.Item2, filter6.Item3, filter6.Item4);
                }
                else
                {
                    addFilter(filterIdOfLastTab, true, filter6.Item2, filter6.Item3, filter6.Item4);
                }
            }

            if (numberOfFilters >= 7)
            {
                if (!filter7.Item1)
                {
                    addFilter(controller.GetDataBaseController().GetLastFilterId(), false, filter7.Item2, filter7.Item3, filter7.Item4);
                }
                else
                {
                    addFilter(filterIdOfLastTab, true, filter7.Item2, filter7.Item3, filter7.Item4);
                }
            }

            if (numberOfFilters >= 8)
            {
                if (!filter8.Item1)
                {
                    addFilter(controller.GetDataBaseController().GetLastFilterId(), false, filter8.Item2, filter8.Item3, filter8.Item4);
                }
                else
                {
                    addFilter(filterIdOfLastTab, true, filter8.Item2, filter8.Item3, filter8.Item4);
                }
            }

            controller.GetDataBaseController().CleanTempTables(numberOfFilters);
            start.Invoke((Action)start.FinalizeFilterCreation);
            controller.GetDataBaseController().ResumeCheck();
        }

        /// <summary>
        /// Main function for the file loader thread
        /// </summary>
        public void ThreadedLoadFromFile()
        {
            ErrorLogger logger = new ErrorLogger(config, instance.GetDataBaseController(), "BIC", "PCG");

            instance.GetDataBaseController().FillDatabaseFromFile(threadPath);
            logger.CheckName(threadFileName);
            instance.FinalizeOpenFileFromThread();

            if (logger.CheckColumns())
            {
                if (logger.CheckLinesInDatabase())
                {
                    logger.CreateLog();
                    logger.CheckCompAuxNumCompAuxLib();
                    mainWindow.ControlsUpdate(1);
                    logger.CheckEcritureLetDateLet();
                    mainWindow.ControlsUpdate(2);
                    logger.CheckMontantdeviseIdevise();
                    mainWindow.ControlsUpdate(3);
                    logger.CheckPieceDateEcritureDate();
                    mainWindow.ControlsUpdate(4);
                    logger.CheckPieceDateValidDate();
                    mainWindow.ControlsUpdate(5);
                    logger.CheckEcritureDateValidDate();
                    mainWindow.ControlsUpdate(6);
                    logger.CheckDateLetPieceDate();
                    mainWindow.ControlsUpdate(7);
                    logger.CheckDateLetEcritureDate();
                    mainWindow.ControlsUpdate(8);
                    logger.CheckIsMontantSens();
                    mainWindow.ControlsUpdate(9);
                    logger.CheckIsDateUniqueForEcritureNum();
                    mainWindow.ControlsUpdate(10);
                }
                else
                {
                    logger.CreateLog();
                    mainWindow.ControlsUpdate(10);
                }
            }

            instance.FinalizeControls();
        }

        /// <summary>
        /// Ask the database to create a new filter with given parameters
        /// </summary>
        /// <param name="lastTabId">ID of the currently open tab</param>
        /// <param name="isOr">Have the filter to be created a Or link to the last one</param>
        /// <param name="field">The column name on wich the filter will be created</param>
        /// <param name="condition">The condition for the filter</param>
        /// <param name="value">The value to compare with the Column content</param>
        private static void addFilter(int lastTabId, bool isOr, String field, String condition, String value)
        {
            MainController controller = MainController.Get();
            string finalWhereClause = "";

            if (field.ToUpper().Contains("DATE") || field.ToUpper().Contains("MONTANT") ||
                field.ToUpper().Contains("DEBIT") || field.ToUpper().Contains("CREDIT"))
            {
                finalWhereClause = controller.simpleFilterController.NumericOrDateSimpleFilter(field, condition, value);
            }
            else
            {
                finalWhereClause = controller.simpleFilterController.TextSimpleFilter(field, condition, value);
            }

            if (isOr)
            {
                controller.dataBaseController.AddFilterOr(finalWhereClause, lastTabId);
            }
            else
            {
                controller.dataBaseController.AddFilterAdd(finalWhereClause, lastTabId);
            }
        }

        /// <summary>
        /// Code that launch the filter creation thread
        /// </summary>
        /// <param name="data"></param>
        public void addFilters(Tuple<int, int,
                    Tuple<String, String, String>,
                    Tuple<Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>>,
                    Start> data)
        {
            Thread filterCreator = new Thread(threadedFilterCreation);
            filterCreator.Start(data);
        }

        /// <summary>
        /// getter for DataBaseCOntroller instance related to this
        /// </summary>
        /// <returns>the DataBaseCOntroller instance</returns>
        public DataBaseController GetDataBaseController()
        {
            return dataBaseController;
        }

        /// <summary>
        /// Start the configuration and the mainWindow
        /// </summary>
        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Configuration config = new Configuration(configuration);
            mainWindow = new Start();

            Application.Run(mainWindow);
        }

        /// <summary>
        /// Vérifier la validiter des champs
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <param name="columnContent"></param>
        /// <returns> boolean </returns>
        private bool IsCellValid(int columnNumber, String columnContent)
        {
            if (columnContent == null)
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

        /// <summary>
        /// function called when file loader thread has terminated
        /// </summary>
        public void FinalizeControls()
        {
            areControlsTerminated = true;
        }

        /// <summary>
        /// function that launch the file creation thread
        /// </summary>
        /// <param name="filePath">the path of the file to open</param>
        /// <param name="fileName">the name of the file to open</param>
        internal void OpenFile(string filePath, string fileName)
        {
            if (areControlsTerminated)
            {
                areControlsTerminated = false;
                mainWindow.ControlsStart();
                dataBaseController.Init();
                threadPath = filePath;
                threadFileName = fileName;
                mainWindow.reinitializeTabs();
                Thread openFileThread = new Thread(new ThreadStart(ThreadedLoadFromFile));
                openFileThread.Start();
            }
            else
            {
                MessageBox.Show("Vous ne pouvez pas ouvrir un nouveau fichier tant que les contrôles complémentaires ne sont pas terminés !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// function called from file opening thread when his job is finished
        /// </summary>
        public void FinalizeOpenFileFromThread()
        {
            DataGridView gridView = mainWindow.getDataGridView();
            gridView.Invoke((Action)FinalizeOpenFile);
        }

        /// <summary>
        /// function called for refreshing the view when a new file is loaded
        /// </summary>
        public void FinalizeOpenFile()
        {
            DataGridView gridView = mainWindow.getDataGridView();
            String[] Columns = dataBaseController.GetColumnNames();
            int size = dataBaseController.GetNumberOfLines();

            gridView.ColumnCount = Columns.Length;

            for (int i = 0; i < Columns.Length; i++)
            {
                gridView.Columns[i].Name = Columns[i];
            }

            gridView.RowCount = size;
        }

        /// <summary>
        /// function for refreshing given dataGridView with specified filterNumber
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="filterNumber"></param>
        internal void OpenFilter(DataGridView gridView, int filterNumber)
        {
            String[] Columns = dataBaseController.GetColumnNames();
            int size = dataBaseController.GetNumberOfLinesInFilter(filterNumber);

            gridView.ColumnCount = Columns.Length;

            for (int i = 0; i < Columns.Length; i++)
            {
                gridView.Columns[i].Name = Columns[i];
            }

            size++;
            gridView.RowCount = size;
        }
    }
}
