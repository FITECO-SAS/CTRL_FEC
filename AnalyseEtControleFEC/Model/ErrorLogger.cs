using AnalyseEtControleFEC.Controller;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Threading.Tasks;

namespace AnalyseEtControleFEC.Model
{
    /// <summary>
    /// this class can be used to check the validity of an Accounting Entry File and produce an error log for it.
    /// it should be instancied once for each verification
    /// </summary>
    class ErrorLogger
    {
        /// <summary>
        /// the configuration that this logger must use
        /// </summary>
        private Configuration configuration;
        /// <summary>
        /// the dataBase access for the Accounting Entry File informations
        /// </summary>
        private DataBaseController dataBaseAccess;
        /// <summary>
        /// the regime of the Accounting Entry File
        /// </summary>
        private String regime;
        /// <summary>
        /// the plan of the Accounting Entry File
        /// </summary>
        private String plan;

        /// <summary>
        /// boolean that must become false if an error is detected
        /// </summary>
        private bool isFileCorrect;
        /// <summary>
        /// boolean that must become false if a name error is detected
        /// </summary>
        private bool isNameCorrect;
        /// <summary>
        /// boolean that must become false if the columns are not one of the possible columns sets
        /// </summary>
        private bool AreColumnsCorrect;
        // private bool CompAuxNum_CompAuxLib;
        /// <summary>
        /// a list of Tuple each containing a column name and a list of line number where an error has been found for it
        /// </summary>
        public List<Tuple<String, List<int>>> lineRegexErrors { get; }

        /// <summary>
        /// Constructor for the ErrorLogger
        /// </summary>
        /// <param name="configuration">the configuration for this logger</param>
        /// <param name="dataBaseAccess">the database access for this logger</param>
        /// <param name="regime">the regime of the Checked AEF</param>
        /// <param name="plan">the plan of the Checked AEF</param>
        public ErrorLogger(Configuration configuration, DataBaseController dataBaseAccess, String regime, String plan)
        {
            this.configuration = configuration;
            this.dataBaseAccess = dataBaseAccess;
            this.regime = regime;
            this.plan = plan;
            isFileCorrect = true;
            isNameCorrect = true;
            AreColumnsCorrect = true;
            // CompAuxNum_CompAuxLib = true;
            lineRegexErrors = new List<Tuple<String, List<int>>>();
        }

        public void check_CompAuxNum_CompAuxLib()
        {
            List<int> list = dataBaseAccess.CompareContent_CompAuxNum_CompAuxLib();
            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Les champs CompAuxNum et CompAuxLib sont pas conforment ligne :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t - Les champs CompAuxNum et CompAuxLib sont pas conforment ligne :");
                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t  " + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }
        public void check_EcritureLet_DateLet()
        {
            List<int> list = dataBaseAccess.CompareContent_EcritureLet_DateLet();
            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Les champs EcritureLet et DateLet sont pas conforment ligne :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs EcritureLet et DateLet sont pas conforment ligne :");
                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t  " + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }
        public void check_Montantdevise_Idevise()
        {
            List<int> list = dataBaseAccess.CompareContent_Montantdevise_Idevise();
            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Les champs Montantdevise et Idevise sont pas conforment ligne :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs Montantdevise et Idevise sont pas conforment ligne :");
                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t  " + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }
        public void check_DateLet_EcritureDate()
        {
            List<int> list = dataBaseAccess.CompareContent_DateLet_EcritureDate();
            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Les champs DateLet et EcritureDate sont pas conforment ligne :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs DateLet et EcritureDate sont pas conforment ligne :");
                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t  " + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }
        public void check_PieceDate_EcritureDate()
        {
            List<int> list = dataBaseAccess.CompareContent_PieceDate_EcritureDate();
            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Les champs PieceDate et EcritureDate sont pas conforment ligne :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs PieceDate et EcritureDate sont pas conforment ligne :");
                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t  " + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }
        public void check_PieceDate_ValidDate()
        {
            List<int> list = dataBaseAccess.CompareContent_PieceDate_ValidDate();
            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Les champs PieceDate et ValidDate sont pas conforment ligne :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs PieceDate et ValidDate sont pas conforment ligne :");
                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t  " + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }
        public void check_EcritureDate_ValidDate()
        {
            List<int> list = dataBaseAccess.CompareContent_EcritureDate_ValidDate();
            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Les champs EcritureDate et ValidDate sont pas conforment ligne :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs EcritureDate et ValidDate sont pas conforment ligne :");
                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t  " + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }
        public void check_DateLet_PieceDate()
        {
            List<int> list = dataBaseAccess.CompareContent_DateLet_PieceDate();
            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Les champs DateLet et PieceDate sont pas conforment ligne :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs DateLet et PieceDate sont pas conforment ligne :");
                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t  " + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }

        public void check_Debit_Credit_EcritureNum()
        {
            List<String> list = dataBaseAccess.EcritureNum_Debit_Credit();
            if (list.Count != 0)
            {
                foreach (String str in list)
                {
                    LogHelper.WriteToFile("\t\t"+str,"EcritureNum");
                }
            }
        }

        public void check_Debit_Credit_JournalCode()
        {
            List<String> list = dataBaseAccess.JournalCode_Debit_Credit();
            if (list.Count != 0)
            {
                foreach (String str in list)
                {
                    //Console.WriteLine("\t\t JournalCode :" + str);
                    LogHelper.WriteToFile("\t\t"+str, "JournalCode :");
                }
            }
        }

        public void check_Debit_Credit_AllLines()
        {
            bool list = dataBaseAccess.AllLines_Debit_Credit();
            if (list == true)
            {
                Console.WriteLine("Erreur Debit Credit\n");
                LogHelper.WriteToFile("Erreur Debit Credit\n", "ErrorLogger");
            }
        }

        public void check_Montant_Sens_AllLines()
        {
            bool list = dataBaseAccess.AllLines_Montant_Sens();
            if (list == true)
            {
                //Console.WriteLine("Erreur Montant Sens \n");
                LogHelper.WriteToFile("Erreur Montant Sens \n", "ErrorLogger");
            }
        }

        public void check_Montant_Sens_JournalCode()
        {
            List<String> list = dataBaseAccess.JournalCode_Montant_Sens();
            if (list.Count != 0)
            {
                foreach (String str in list)
                {
                    //Console.WriteLine("\t\t JournalCode :" + str);
                    LogHelper.WriteToFile("\t\t"+str, "JournalCode :");
                }
            }
        }

        public void check_Montant_Sens_EcritureNum()
        {
            List<String> list = dataBaseAccess.EcritureNum_Montant_Sens();
            if (list.Count != 0)
            {
                foreach (String str in list)
                {
                    //Console.WriteLine("\t\t EcritureNum :" + str);
                     LogHelper.WriteToFile("\t\t"+str,"EcritureNum :");
                }
            }
        }

        public void check_Is_Montant_Sens()
        {
            bool is_Montant = dataBaseAccess.Is_Montant_Sens();
            if (is_Montant)
            {

                check_Montant_Sens_AllLines();
                check_Montant_Sens_JournalCode();
                check_Montant_Sens_EcritureNum();
            }
            else
            {
                check_Debit_Credit_EcritureNum();
                check_Debit_Credit_JournalCode();
                check_Debit_Credit_AllLines();
            }
        }
        /// <summary>
        /// Check if a name is correct for the regex in configuration 
        /// </summary>
        /// <param name="name">the name that we want to check</param>
        /// <returns>true if the name is correct or false if it's not</returns>
        public bool checkName(String name)
        {
            Regex nameRegex = new Regex(configuration.nameRegex);
            if (!nameRegex.IsMatch(name))
            {
                isFileCorrect = false;
                isNameCorrect = false;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check if the columns names correspond to one of the columns sets in configuration for specified regime and plan
        /// </summary>
        /// <returns>true if the column set exists and false if it's not</returns>
        public bool checkColumns()
        {
            String[] columns = dataBaseAccess.getColumnNames();
            bool check = false;
            foreach (List<String> set in configuration.getColumnSets(regime, plan))
            {
                bool found = true;
                for (int i = 0; i < columns.Length; i++)
                {
                    if (!set[i].Equals(columns[i]))
                    {
                        found = false;
                    }
                }
                if (found)
                {
                    AreColumnsCorrect = true;
                    return true;
                }
            }
            isFileCorrect = false;
            AreColumnsCorrect = false;
            return false;
        }

        /// <summary>
        /// Check if the columns names correspond to one of the columns sets in configuration for specified regime and plan
        /// </summary>
        /// <returns>true if the column set exists and false if it's not</returns>
        public String getErrorColumns()
        {
            String[] columns = dataBaseAccess.getColumnNames();
            String listErrorColumns = "";
            bool checkColumns = true;
            int line = 0;
            foreach (List<String> set in configuration.getColumnSets(regime, plan))
            {
                bool found = true;
                for (int i = 0; i < columns.Length; i++)
                {
                    if (!set[i].Equals(columns[i]))
                    {
                        checkColumns = false;
                        listErrorColumns += " " + set[i];
                    }
                }
                if (checkColumns)
                {
                    AreColumnsCorrect = true;
                    return "";
                }
                if (line == 0) listErrorColumns += " OU ";
                line++;
            }
            isFileCorrect = false;
            AreColumnsCorrect = false;
            return listErrorColumns;
        }

        /// <summary>
        /// Check if each line in the file verify the regex in the configuration
        /// </summary>
        /// <returns>false if at least one content is not correct or true if not</returns>
        public bool checkLines()
        {
            bool valid = true;
            String[] columnsRegex = configuration.getColumnsRegex(dataBaseAccess.getColumnNames());
            int nbLines = dataBaseAccess.getNumberOfLines();
            String[] lineContent;
            for (int line = 0; line < nbLines; line++)
            {
                lineContent = dataBaseAccess.getLine(line);
                for (int column = 0; column < lineContent.Length; column++)
                {
                    if (!(new Regex(columnsRegex[column]).IsMatch(lineContent[column])))
                    {
                        valid = false;
                        isFileCorrect = false;
                        bool found = false;
                        foreach (Tuple<String, List<int>> col in lineRegexErrors)
                        {
                            if (col.Item1 == lineContent[column])
                            {
                                found = true;
                                col.Item2.Add(line);
                            }
                        }
                        if (!found)
                        {
                            List<int> lineList = new List<int>();
                            lineList.Add(line);
                            lineRegexErrors.Add(new Tuple<String, List<int>>(dataBaseAccess.getColumnNames()[column], lineList));
                        }
                    }
                }
            }
            return valid;
        }

        public bool checkLinesWithAll()
        {
            bool valid = true;
            String[] columnsRegex = configuration.getColumnsRegex(dataBaseAccess.getColumnNames());
            int nbLines = dataBaseAccess.getNumberOfLines();
            String[][] content = dataBaseAccess.getAllLines();
            String[] lineContent;
            for (int line = 0; line < nbLines; line++)
            {
                lineContent = content[line];
                for (int column = 0; column < lineContent.Length; column++)
                {
                    if (!(new Regex(columnsRegex[column]).IsMatch(lineContent[column])))
                    {
                        valid = false;
                        isFileCorrect = false;
                        bool found = false;
                        foreach (Tuple<String, List<int>> col in lineRegexErrors)
                        {
                            if (col.Item1 == lineContent[column])
                            {
                                found = true;
                                col.Item2.Add(line);
                            }
                        }
                        if (!found)
                        {
                            List<int> lineList = new List<int>();
                            lineList.Add(line);
                            lineRegexErrors.Add(new Tuple<String, List<int>>(dataBaseAccess.getColumnNames()[column], lineList));
                        }
                    }
                }
            }
            return valid;
        }

        /// <summary>
        /// Check if each line in the file verify the regex in the configuration
        /// </summary>
        /// <returns>false if at least one content is not correct or true if not</returns>
        public bool checkLinesInDatabase()
        {
            bool valid = true;
            String[] columns = dataBaseAccess.getColumnNames();
            String[] columnsRegex = configuration.getColumnsRegex(columns);
            for (int i = 0; i < columns.Length; i++)
            {
                List<int> errors = dataBaseAccess.checkRegexColumn(i, columnsRegex[i]);
                if (errors.Count > 0)
                {
                    valid = false;
                    isFileCorrect = false;
                    lineRegexErrors.Add(new Tuple<String, List<int>>(columns[i], errors));
                }
            }
            return valid;
        }



        /// <summary>
        /// Create a String that log the encountered errors
        /// </summary>
        /// <returns>the log as a String</returns>
        public String createLog()
        {
            String log = "Rapport d'erreur :\n";
            if (isFileCorrect)
            {
                log += "Aucune erreur structurelle n'a été détectée\n";
            }
            else
            {
                log += "Une ou plusieurs erreur(s) a/ont été détéctée(s) :\n";
                if (!isNameCorrect)
                {
                    log += "\t - Le nom du fichier n'est pas conforme\n";
                }
                if (!AreColumnsCorrect)
                {
                    log += "\t - Les entêtes de colonnes ne correspondent à aucun ensemble possible pour le régime et le plan indiqués. Voici les ensembles possibles :\n";
                    log += "\t\t -" + getErrorColumns() + "\n";
                }

            }

            foreach (Tuple<String, List<int>> col in lineRegexErrors)
            {
                log += "\n Le champs : " + col.Item1 + " est pas valide"; LogHelper.WriteToFile("\n Le champs : " + col.Item1 + " est pas valide", "Class ErrorLogger");
                foreach (int i in col.Item2)
                {
                    log += "\n erreur en ligne : " + i;
                    LogHelper.WriteToFile("\n erreur en ligne: " + i, "erreur en ligne");
                }
            }

            return log;
        }
    }
}
