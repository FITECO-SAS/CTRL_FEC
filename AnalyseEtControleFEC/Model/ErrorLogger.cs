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
        private bool areColumnsCorrect;
        
        /// <summary>
        /// a list of Tuple each containing a column name, the associated error message and a list of line number where an error has been found for it
        /// </summary>
        public List<Tuple<String, String, List<int>>> lineRegexErrors { get; }

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
            areColumnsCorrect = true;
            lineRegexErrors = new List<Tuple<String, String, List<int>>>();
        }

        /// <summary>
        /// Check the consistency between the CompAuxNum and CompAuxLib columns
        /// </summary>
        public void CheckCompAuxNumCompAuxLib()
        {
            List<int> list = dataBaseAccess.CompareContentCompAuxNumCompAuxLib();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("L'un des champs CompAuxNum ou CompAuxLib est vide :\n", "Class ErrorLogger");

                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t" + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }

        /// <summary>
        /// Check the consistency between the EcritureLet and DateLet columns
        /// </summary>
        public void CheckEcritureLetDateLet()
        {
            List<int> list = dataBaseAccess.CompareContentEcritureLetDateLet();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("L'un des champs EcritureLet ou DateLet est vide :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs EcritureLet et DateLet sont pas conforment ligne :");

                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t" + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }

        /// <summary>
        /// Check the consistency between the Montantdevise and Idevise columns
        /// </summary>
        public void CheckMontantdeviseIdevise()
        {
            List<int> list = dataBaseAccess.CompareContentMontantdeviseIdevise();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("L'un des champs Montantdevise ou Idevise est vide :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs Montantdevise et Idevise sont pas conforment ligne :");

                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t" + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }

        /// <summary>
        /// Check if DateLet column is not lower than EcritureDate column
        /// </summary>
        public void CheckDateLetEcritureDate()
        {
            List<int> list = dataBaseAccess.CompareContentDateLetEcritureDate();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Le champs DateLet < EcritureDate :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs DateLet et EcritureDate sont pas conforment ligne :");

                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t" + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }

        /// <summary>
        /// Check if PieceDate column is not upper than EcritureDate column
        /// </summary>
        public void CheckPieceDateEcritureDate()
        {
            List<int> list = dataBaseAccess.CompareContentPieceDateEcritureDate();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Le champ PieceDate > EcritureDate :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs PieceDate et EcritureDate sont pas conforment ligne :");

                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t" + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }

        /// <summary>
        /// Check if EcritureDate column is not upper than ValidDate column
        /// </summary>
        public void CheckPieceDateValidDate()
        {
            List<int> list = dataBaseAccess.CompareContentPieceDateValidDate();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Le champ PieceDate > ValidDate :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs PieceDate et ValidDate sont pas conforment ligne :");

                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t" + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }

        /// <summary>
        /// Check if EcritureDate column is not upper than ValidDate column
        /// </summary>
        public void CheckEcritureDateValidDate()
        {
            List<int> list = dataBaseAccess.CompareContentEcritureDateValidDate();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Le champ EcritureDate > ValidDate :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs EcritureDate et ValidDate sont pas conforment ligne :");

                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t" + i, "Ligne numero");
                    Console.WriteLine("\t\t  " + i);
                }
            }
        }

        /// <summary>
        /// Check if DateLet column is not lower than PieceDate column
        /// </summary>
        public void CheckDateLetPieceDate()
        {
            List<int> list = dataBaseAccess.CompareContentDateLetPieceDate();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("Le champs DateLet < PieceDate :\n", "Class ErrorLogger");
                Console.WriteLine("\t\t -Les champs DateLet et PieceDate sont pas conforment ligne :");

                foreach (int i in list)
                {
                    LogHelper.WriteToFile("\t\t" + i, "Ligne numero");
                    Console.WriteLine("\t\t" + i);
                }
            }
        }

        /// <summary>
        /// Check if the sum of the Debit column is equal to the sum the Credit column for a specific EcritureNum value
        /// </summary>
        public void CheckDebitCreditEcritureNum()
        {
            List<String> list = dataBaseAccess.EcritureNumDebitCredit();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("La somme des débits est differente de la somme des crédits :", "Class ErrorLogger");

                foreach (String str in list)
                {
                    LogHelper.WriteToFile("\t\t\t"+str,"EcritureNum");
                }
            }
        }

        /// <summary>
        /// Check if the sum of the Debit column is equal to the sum the Credit column for a specific JournalCode value
        /// </summary>
        public void CheckDebitCreditJournalCode()
        {
            List<String> list = dataBaseAccess.JournalCodeDebitCredit();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("La somme des débits est differente de la somme des crédits :", "Class ErrorLogger");

                foreach (String str in list)
                {
                    LogHelper.WriteToFile("\t\t\t" + str, "JournalCode");
                }
            }
        }

        /// <summary>
        /// Check if the sum of the Debit column is equal to the sum the Credit column on the entire file
        /// </summary>
        public void CheckDebitCreditAllLines()
        {
            bool list = dataBaseAccess.AllLinesDebitCredit();

            if (list == true)
            {
                Console.WriteLine("Erreur Debit Credit\n");
                LogHelper.WriteToFile("La somme des débits est differente de la somme des crédits sur l'ensemble du fichier\n", "Class ErrorLogger");
            }
        }

        /// <summary>
        /// Check if the sum of the Debit column is equal to the sum the Credit column on the entire file (in a Montant-Sens file)
        /// </summary>
        public void CheckMontantSensAllLines()
        {
            bool list = dataBaseAccess.AllLinesMontantSens();

            if (list == true)
            {
                LogHelper.WriteToFile("La somme des débits est differente de la somme des crédits sur l'ensemble du fichier\n", "Class ErrorLogger");
            }
        }

        /// <summary>
        /// Check if the sum of the Debit column is equal to the sum the Credit column for a specific JournalCode value (in a Montant-Sens file)
        /// </summary>
        public void CheckMontantSensJournalCode()
        {
            List<String> list = dataBaseAccess.JournalCodeMontantSens();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("La somme des débits est differente de la somme des crédits sur les JournalCode :", "Class ErrorLogger");

                foreach (String str in list)
                {
                    LogHelper.WriteToFile("\t\t\t" + str, "JournalCode");
                }
            }
        }

        /// <summary>
        /// Check if the sum of the Debit column is equal to the sum the Credit column for a specific EcritureNum value (in a Montant-Sens file)
        /// </summary>
        public void CheckMontantSensEcritureNum()
        {
            List<String> list = dataBaseAccess.EcritureNumMontantSens();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("La somme des débits est differente de la somme des crédits sur les EcritureNum :", "Class ErrorLogger");

                foreach (String str in list)
                {
                     LogHelper.WriteToFile("\t\t\t" + str,"EcritureNum ");
                }
            }
        }

        /// <summary>
        /// Check if the sum of the Debit column is equal to the sum the Credit column for a specific Month value for each JournalCode (in a Montant-Sens file)
        /// </summary>
        public void CheckCompareMontantSensByMonth()
        {
            List<String> list = dataBaseAccess.CompareMontantSensByMonth();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("La somme des débits est differente de la somme des crédits sur un mois d'un journal :", "Class ErrorLogger");

                foreach (String str in list)
                {
                    LogHelper.WriteToFile("\t\t\t" + str, "JournalCode");
                }
            }
        }

        /// <summary>
        /// Check if the sum of the Debit column is equal to the sum the Credit column for a specific Month value for each JournalCode
        /// </summary>
        public void CheckCompareDebitCreditByMonth()
        {
            List<String> list = dataBaseAccess.CompareDebitCreditByMonth();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("La somme des débits est differente de la somme des crédits sur un mois d'un journal :", "Class ErrorLogger");

                foreach (String str in list)
                {
                    LogHelper.WriteToFile("\t\t\t" + str, "JournalCode");
                }
            }
        }

        /// <summary>
        /// Check if the file are a Montant-Sens file and do the associated complementary controls
        /// </summary>
        public void CheckIsMontantSens()
        {
            if (dataBaseAccess.IsMontantSens())
            {

                CheckMontantSensAllLines();
                CheckMontantSensJournalCode();
                CheckMontantSensEcritureNum();
                CheckCompareMontantSensByMonth();
            }
            else
            {
                CheckDebitCreditEcritureNum();
                CheckDebitCreditJournalCode();
                CheckDebitCreditAllLines();
                CheckCompareDebitCreditByMonth();
            }
        }

        /// <summary>
        /// Check if date are unique for each EcritureNum
        /// </summary>
        public void CheckIsDateUniqueForEcritureNum()
        {
            List<String> list = dataBaseAccess.IsDateUniqueForEcritureNum();

            if (list.Count != 0)
            {
                LogHelper.WriteToFile("La date sur l'ecritureNum n'est pas unique :", "Class ErrorLogger");

                foreach (String str in list)
                {
                    LogHelper.WriteToFile("\t\t\t" + str, "EcritureNum");
                }
            }
        }


        /// <summary>
        /// Check if a name is correct for the regex in configuration 
        /// </summary>
        /// <param name="name">the name that we want to check</param>
        /// <returns>true if the name is correct or false if it's not</returns>
        public bool CheckName(String name)
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
        public bool CheckColumns()
        {
            String[] columns = dataBaseAccess.GetColumnNames();

            foreach (List<String> set in configuration.GetColumnSets(regime, plan))
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
                    areColumnsCorrect = true;
                    return true;
                }
            }

            isFileCorrect = false;
            areColumnsCorrect = false;

            return false;
        }

        /// <summary>
        /// Check if the columns names correspond to one of the columns sets in configuration for specified regime and plan
        /// </summary>
        /// <returns>true if the column set exists and false if it's not</returns>
        public String GetErrorColumns()
        {
            String[] columns = dataBaseAccess.GetColumnNames();
            String listErrorColumns = "";

            bool checkColumns = true;
            int line = 0;

            foreach (List<String> set in configuration.GetColumnSets(regime, plan))
            {
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
                    areColumnsCorrect = true;
                    return "";
                }

                if (line == 0)
                {
                    listErrorColumns += " OU ";
                }

                line++;
            }

            isFileCorrect = false;
            areColumnsCorrect = false;

            return listErrorColumns;
        }


        /// <summary>
        /// Check if each line in the file verify the regex in the configuration
        /// </summary>
        /// <returns>false if at least one content is not correct or true if not</returns>
        public bool CheckLinesInDatabase()
        {
            bool valid = true;
            String[] columns = dataBaseAccess.GetColumnNames();

            Tuple<String, String>[] columnsRegex = configuration.GetColumnsRegex(columns);

            for (int i = 0; i < columns.Length; i++)
            {
                List<int> errors = dataBaseAccess.CheckRegexColumn(i, columnsRegex[i].Item1);

                if (errors.Count > 0)
                {
                    valid = false;
                    isFileCorrect = false;
                    lineRegexErrors.Add(new Tuple<String, String, List<int>>(columns[i], columnsRegex[i].Item2, errors));
                }
            }

            return valid;
        }



        /// <summary>
        /// Create a String that log the encountered errors
        /// </summary>
        /// <returns>the log as a String</returns>
        public String CreateLog()
        {
            String log = "Rapport d'erreur :\n";

            if (isFileCorrect)
            {
                log += "Aucune erreur structurelle n'a été détectée\n";
                LogHelper.WriteToFile("\n Aucune erreur structurelle n'a été détectée", "Class ErrorLogger");
            }
            else
            {
                log += "Une ou plusieurs erreur(s) a/ont été détéctée(s) :\n";
                LogHelper.WriteToFile("\n Une ou plusieurs erreur(s) a/ont été détéctée(s) :", "Class ErrorLogger");

                if (!isNameCorrect)
                {
                    log += "\t - Le nom du fichier n'est pas conforme\n";
                    LogHelper.WriteToFile("\n Le nom du fichier n'est pas conforme", "Class ErrorLogger");
                }

                if (!areColumnsCorrect)
                {
                    log += "\t- Les entêtes de colonnes ne correspondent à aucun ensemble possible pour le régime et le plan indiqués. Voici les ensembles possibles :\n";
                    log += "\t\t-" + GetErrorColumns() + "\n";
                    LogHelper.WriteToFile("\nLes entêtes de colonnes ne correspondent à aucun ensemble possible pour le régime et le plan indiqués. Voici les ensembles possibles :", "Class ErrorLogger");
                    LogHelper.WriteToFile("\n\t\t-" + GetErrorColumns(), "Colonnes");
                }

            }

            foreach (Tuple<String, String, List<int>> col in lineRegexErrors)
            {
                log += "\n Le champs : " + col.Item1 + " n'est pas valide : " + col.Item2;
                LogHelper.WriteToFile("\n"+ col.Item2, "Class ErrorLogger");

                foreach (int i in col.Item3)
                {
                    log += "\n erreur en ligne : " + i;
                    LogHelper.WriteToFile("\n\t\t" + i, "Ligne numero");
                }
            }

            return log;
        }
    }
}
