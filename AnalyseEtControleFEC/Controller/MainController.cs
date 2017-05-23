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
        public bool areControlsTerminated;

        //Static Thread stuff
        static String threadPath;
        static String threadFileName;

        static public void threadedFilterCreation(object o)
        {
            MainController controller = MainController.Get();
            controller.GetDataBaseController().requestCheckPause();
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
            addFilter(filterIdOfLastTab, false, filter1.Item1, filter1.Item2, filter1.Item3);
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
            controller.GetDataBaseController().resumeCheck();
        }

        static public void threadedLoadFromFile()
        {

            ErrorLogger logger = new ErrorLogger(config, instance.GetDataBaseController(), "BIC", "PCG");
            instance.GetDataBaseController().FillDatabaseFromFile(threadPath);
            logger.CheckName(threadFileName);
            logger.CheckColumns();
            if(logger.CheckColumns()) logger.CheckLinesInDatabase();
            instance.FinalizeOpenFileFromThread();
            //logger.check_Dates();
            //Console.WriteLine(logger.check_CompAuxNum_CompAuxLib());
            Console.WriteLine(logger.CreateLog());
            logger.CheckCompAuxNumCompAuxLib();
            logger.CheckEcritureLetDateLet();
            logger.CheckMontantdeviseIdevise();
            logger.CheckPieceDateEcritureDate();
            logger.CheckPieceDateValidDate();
            logger.CheckEcritureDateValidDate();
            logger.CheckDateLetPieceDate();
            logger.CheckDateLetEcritureDate();
            logger.CheckIsMontantSens();
            logger.CheckIsDateUniqueForEcritureNum();
            //logger.Ecrirefile(logger.lineRegexErrors, "test1.txt");
            instance.finalizeControls();
        }

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

        //Constants
        static String dataBaseFile = "data.SQLite";
        static String configuration = "Configuration.json";
        static Configuration config;
        static MainController instance;

        public DataBaseController dataBaseController { get; set; }
        public SimpleFilterController simpleFilterController { get; set; }
        Start mainWindow;

        static public MainController Get()
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

        public DataBaseController GetDataBaseController()
        {
            return dataBaseController;
        }

        public SimpleFilterController GetSimpleFilterController()
        {
            return simpleFilterController;
        }

        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Configuration config = new Configuration(configuration);
            mainWindow = new Start();
            Application.Run(mainWindow);
        }

        /// <summary>
        /// Analyser les données (controles élémentaires)
       /// </summary>
        public void AnalyzeData()
        {
            for(int i = 0; i<mainWindow.getDataGridView().RowCount; i++)
            {
                for(int j = 0; j<mainWindow.getDataGridView().ColumnCount; j++)
                {
                    if(!IsCellValid(j, (String)mainWindow.getDataGridView().Rows[i].Cells[j].Value))
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
        /// Vérifier la validiter des champs
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <param name="columnContent"></param>
        /// <returns> boolean </returns>
        private bool IsCellValid(int columnNumber, String columnContent)
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

        public void finalizeControls()
        {
            areControlsTerminated = true;
        }

        internal void openFile(string filePath, string fileName)
        {
            dataBaseController.Init();
            threadPath = filePath;
            threadFileName = fileName;
            mainWindow.reinitializeTabs();
            Thread openFileThread = new Thread(new ThreadStart(threadedLoadFromFile));
            openFileThread.Start();
            areControlsTerminated = false;
        }
        public void FinalizeOpenFileFromThread()
        {
            DataGridView gridView = mainWindow.getDataGridView();
            gridView.Invoke((Action)FinalizeOpenFile);
        }
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
