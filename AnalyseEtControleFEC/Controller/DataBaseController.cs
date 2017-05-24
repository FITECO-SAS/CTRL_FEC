using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using AnalyseEtControleFEC.Controller;
using System.Threading;
using System.Diagnostics;

namespace AnalyseEtControleFEC.Controller
{
    /// <summary>
    /// Add SQLite function for REGEX
    /// </summary>
    [SQLiteFunction(Name = "REGEXP", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class RegExSQLiteFunction : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(args[1]), Convert.ToString(args[0]));
        }
    }

    /// <summary>
    /// Add SQLite function for REGEX
    /// </summary>
    [SQLiteFunction(Name = "ISSTRICTLYSUPERIOR", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class IsStrictlySuperiorSQLiteFunction : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            bool result;

            if (Convert.ToString(args[0]).Equals("") && Convert.ToString(args[1]).Equals(""))
            {
                return false;
            }
            else
            {
                if (Convert.ToString(args[0]).Equals(""))
                {
                    return false;
                }
                if (Convert.ToString(args[1]).Equals(""))
                {
                    return true;
                }

                try
                {
                    result = Double.Parse(Convert.ToString(args[0])) > Double.Parse(Convert.ToString(args[1]));
                }
                catch (Exception e)
                {
                    return false;
                }

                return result;
            }
        }
    }

    /// <summary>
    /// Add SQLite function for REGEX
    /// </summary>
    [SQLiteFunction(Name = "ISSUPERIOR", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class IsSuperiorSQLiteFunction : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            bool result;

            if (Convert.ToString(args[0]).Equals("") && Convert.ToString(args[1]).Equals(""))
            {
                return true;
            }
            else
            {
                if (Convert.ToString(args[0]).Equals(""))
                {
                    return false;
                }
                if (Convert.ToString(args[1]).Equals(""))
                {
                    return true;
                }

                try
                {
                    result = Double.Parse(Convert.ToString(args[0])) >= Double.Parse(Convert.ToString(args[1]));
                }
                catch (Exception e)
                {
                    return false;
                }

                return result;
            }
        }
    }

    /// <summary>
    /// Add SQLite function for REGEX
    /// </summary>
    [SQLiteFunction(Name = "ISEQUAL", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class IsEqualSQLiteFunction : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            bool result;

            if(Convert.ToString(args[0]).Equals("") && Convert.ToString(args[1]).Equals(""))
            {
                return true;
            }
            else
            {
                if(Convert.ToString(args[0]).Equals("") || Convert.ToString(args[1]).Equals(""))
                {
                    return false;
                }

                try
                {
                    result = Double.Parse(Convert.ToString(args[0])) == Double.Parse(Convert.ToString(args[1]));
                }
                catch (Exception e)
                {
                    return false;
                }

                return result;
            }
        }
    }

    /// <summary>
    /// This Class is the controller for database reading and writing
    /// </summary>
    public class DataBaseController
    {
        /// <summary>
        /// Main Database Connection
        /// </summary>
        SQLiteConnection mainDbConnection;

        /// <summary>
        /// Database Connection for check methods
        /// </summary>
        SQLiteConnection checkDbConnection;

        /// <summary>
        /// Database Connection for filter methods
        /// </summary>
        SQLiteConnection filterDbConnection;

        /// <summary>
        /// Database Connection for ui
        /// </summary>
        SQLiteConnection uiDbConnection;

        /// <summary>
        /// The file name
        /// </summary>
        String fileName;

        /// <summary>
        /// The sort of the filter
        /// </summary>
        private int filterNumber;

        /// <summary>
        /// Check if a pause is needed 
        /// </summary>
        private bool requestedCheckPause;

        public void RequestCheckPause()
        {
            requestedCheckPause = true;
        }

        public void ResumeCheck()
        {
            requestedCheckPause = false;
        }

        private void PauseCheckIfAsked()
        {
            checkDbConnection.Close();

            while (requestedCheckPause)
            {
                Thread.Sleep(2000);
            }

            checkDbConnection.Open();
        }

        /// <summary>
        /// Constructor for DataBaseController
        /// </summary>
        /// <param name="fileName">Name of the database file where we want to store the database</param>
        /// <param name="mainController">The main Controller for this program</param>
        public DataBaseController(String fileName, MainController mainController)
        {
            this.fileName = fileName;
            requestedCheckPause = false;

            filterNumber = 0;
        }

        /// <summary>
        /// Initialyse the database by dropping existing tables if exists and create empty ones
        /// </summary>
        public void Init()
        {
            if (File.Exists(fileName))
            {
                if (mainDbConnection != null)
                {
                    mainDbConnection.Close();
                    checkDbConnection.Close();
                    filterDbConnection.Close();
                    uiDbConnection.Close();
                    DeleteAll();
                    uiDbConnection.Open();
                    checkDbConnection.Open();
                }
                else
                {
                    File.Delete(fileName);
                    SQLiteConnection.CreateFile(fileName);

                    mainDbConnection = new SQLiteConnection("Data Source=" + fileName + ";Version=3;");
                    checkDbConnection = new SQLiteConnection("Data Source=" + fileName + ";Version=3;");
                    filterDbConnection = new SQLiteConnection("Data Source=" + fileName + ";Version=3;");
                    uiDbConnection = new SQLiteConnection("Data Source=" + fileName + ";Version=3;");

                    uiDbConnection.Open();
                    checkDbConnection.Open();
                    mainDbConnection.Open();

                    new SQLiteCommand("CREATE TABLE Column (Position INT, Name VARCHAR(20))", mainDbConnection).ExecuteNonQuery();
                    new SQLiteCommand("CREATE TABLE Content (Line INT, Column INT, Content VARCHAR(100))", mainDbConnection).ExecuteNonQuery();
                    new SQLiteCommand("CREATE INDEX AccessIndexContent ON Content (Column,Line)", mainDbConnection).ExecuteNonQuery();

                    SQLiteFunction.RegisterFunction(typeof(IsStrictlySuperiorSQLiteFunction));
                    SQLiteFunction.RegisterFunction(typeof(IsSuperiorSQLiteFunction));
                    SQLiteFunction.RegisterFunction(typeof(IsEqualSQLiteFunction));

                    mainDbConnection.Close();
                }
            }
            else
            {
                SQLiteConnection.CreateFile(fileName);

                mainDbConnection = new SQLiteConnection("Data Source=" + fileName + ";Version=3;");
                checkDbConnection = new SQLiteConnection("Data Source=" + fileName + ";Version=3;");
                filterDbConnection = new SQLiteConnection("Data Source=" + fileName + ";Version=3;");
                uiDbConnection = new SQLiteConnection("Data Source=" + fileName + ";Version=3;");

                uiDbConnection.Open();
                checkDbConnection.Open();
                mainDbConnection.Open();

                new SQLiteCommand("CREATE TABLE Column (Position INT, Name VARCHAR(20))", mainDbConnection).ExecuteNonQuery();
                new SQLiteCommand("CREATE TABLE Content (Line INT, Column INT, Content VARCHAR(100))", mainDbConnection).ExecuteNonQuery();
                new SQLiteCommand("CREATE INDEX AccessIndexContent ON Content (Column,Line)", mainDbConnection).ExecuteNonQuery();

                SQLiteFunction.RegisterFunction(typeof(IsStrictlySuperiorSQLiteFunction));
                SQLiteFunction.RegisterFunction(typeof(IsSuperiorSQLiteFunction));
                SQLiteFunction.RegisterFunction(typeof(IsEqualSQLiteFunction));

                filterNumber = 0;

                mainDbConnection.Close();
            }
        }

        /// <summary>
        /// Get the content from a filter
        /// </summary>
        /// <param name="column">The associate column</param>
        /// <param name="line">The associate line</param>
        /// <param name="filterNumber">The sort of the filter</param>
        /// <returns></returns>
        internal object GetContentFromFilter(int column, int line, int filterNumber)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT Content FROM Filter"+filterNumber+" WHERE Column = @column AND Line = @line", uiDbConnection);

            command.Parameters.Add(new SQLiteParameter("@line", line));
            command.Parameters.Add(new SQLiteParameter("@column", column));

            return (String)command.ExecuteScalar();
        }

        /// <summary>
        /// Fill the dataBase by reading an Accounting Entry File
        /// </summary>
        /// <param name="filePath">Path of the file to read</param>
        public List<int> FillDatabaseFromFile(String filePath)
        {
            Char[] separators = { '|', '\t' };
            List<int> errors = new List<int>();

            FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BufferedStream bs = new BufferedStream(fs);
            StreamReader reader = new StreamReader(bs);

            String readLine = reader.ReadLine();
            String[] splitLine = readLine.Split(separators);

            int line = 1;
            int nbColumns = splitLine.Length;

            filterDbConnection.Open();

            for (int i = 0; i < splitLine.Length; i++)
            {
                new SQLiteCommand("INSERT INTO Column (Position, Name) VALUES (" + i + ",'" + splitLine[i] + "')", filterDbConnection).ExecuteNonQuery();
            }

            SQLiteCommand beginTrans = new SQLiteCommand("BEGIN TRANSACTION", filterDbConnection);
            SQLiteCommand commitTrans = new SQLiteCommand("COMMIT TRANSACTION", filterDbConnection);
            SQLiteCommand insertCmd = new SQLiteCommand("INSERT INTO Content (Line, Column, Content) VALUES (@line,@column,@content)", filterDbConnection);

            while (!reader.EndOfStream)
            {
                beginTrans.ExecuteNonQuery();
                int curCount = 0;

                while (!reader.EndOfStream && curCount < 10000)
                {
                    readLine = reader.ReadLine();
                    splitLine = readLine.Split(separators);

                    for (int column = 0; column < Math.Min(splitLine.Length, nbColumns); column++)
                    {
                        insertCmd.Parameters.Add(new SQLiteParameter("@line", line));
                        insertCmd.Parameters.Add(new SQLiteParameter("@column", column));
                        insertCmd.Parameters.Add(new SQLiteParameter("@content", splitLine[column]));
                        insertCmd.ExecuteNonQuery();
                    }

                    if (splitLine.Length != nbColumns)
                    {
                        errors.Add(line);
                    }

                    line++;
                    curCount++;
                }

                commitTrans.ExecuteNonQuery();
            }

            fs.Close();
            filterDbConnection.Close();

            return errors;
        }

        /// <summary>
        /// Getter for Columns names in the dataBase
        /// </summary>
        /// <returns>A String array containing the columns names in the database in the same order as in the file</returns>
        public String[] GetColumnNames()
        {
            mainDbConnection.Open();

            SQLiteDataReader reader = new SQLiteCommand("SELECT Name FROM Column ORDER BY Position ASC",mainDbConnection).ExecuteReader();
            List<String> result = new List<String>();

            while (reader.Read())
            {
                result.Add((String)reader["Name"]);
            }

            mainDbConnection.Close();

            return result.ToArray();
        }

        /// <summary>
        /// return content of specified cell in base table
        /// </summary>
        /// <param name="column">column number of celle needed</param>
        /// <param name="line">line number of cell needed</param>
        /// <returns>the cell content at specified position</returns>
        public String GetContent(int column, int line)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT Content FROM Content WHERE Column = @column AND Line = @line", uiDbConnection);

            command.Parameters.Add(new SQLiteParameter("@line", line));
            command.Parameters.Add(new SQLiteParameter("@column", column));

            String result = (String)command.ExecuteScalar();

            return result;
        }

        /// <summary>
        /// Add a filter using the restriction parameter for adding ORDER BY or WHERE clause, it is restrictive from the last filter
        /// </summary>
        /// <param name="restriction">String representing the clauses for the filter, must contains ORDER BY and/or WHERE clause</param>
        public void AddFilterAdd (String restriction, int lastFilterId)
        {
            SQLiteCommand filter;
            SQLiteCommand columnNum;
            bool success = false;

            filterDbConnection.Open();
                        
            if (lastFilterId == -1)
            {
                columnNum = new SQLiteCommand("CREATE TABLE ColumnNum" + filterNumber + " AS SELECT DISTINCT Line FROM Content base " + restriction, filterDbConnection);
                success = false;

                while (!success)
                {
                    try
                    {
                        columnNum.ExecuteNonQuery();
                        success = true;
                    }
                    catch (SQLiteException e)
                    {
                        //database is certainly locked, we'll just try again after one second ...
                        filterDbConnection.Close();
                        Thread.Sleep(1000);
                        filterDbConnection.Open();
                    }
                }

                filter = new SQLiteCommand("CREATE TABLE Filter" + filterNumber + " AS SELECT base.Line AS 'BaseLine', Column, Content, colNum.rowid AS 'Line' FROM Content base INNER JOIN ColumnNum" + filterNumber + " colNum ON base.Line = colNum.Line", filterDbConnection);
            }
            else
            {
                columnNum = new SQLiteCommand("CREATE TABLE ColumnNum" + filterNumber + " AS SELECT DISTINCT Line FROM Filter"+(lastFilterId)+" base " + restriction, filterDbConnection);
                success = false;

                while (!success)
                {
                    try
                    {
                        columnNum.ExecuteNonQuery();
                        success = true;
                    }
                    catch (SQLiteException e)
                    {
                        //database is certainly locked, we'll just try again after one second ...
                        filterDbConnection.Close();
                        Thread.Sleep(1000);
                        filterDbConnection.Open();
                    }
                }

                filter = new SQLiteCommand("CREATE TABLE Filter" + filterNumber + " AS SELECT base.Line AS 'BaseLine', Column, Content, colNum.rowid AS 'Line' FROM Filter" + lastFilterId + " base INNER JOIN ColumnNum" + filterNumber + " colNum ON base.Line = colNum.Line", filterDbConnection);
            }

            success = false;

            while (!success)
            {
                try
                {
                    filter.ExecuteNonQuery();
                    new SQLiteCommand("CREATE INDEX AccessIndexFilter" + filterNumber + " ON Filter" + filterNumber + " (Column,Line)", filterDbConnection).ExecuteNonQuery();
                    success = true;
                }
                catch(SQLiteException e)
                {
                    //database is certainly locked, we'll just try again after one second ...
                    filterDbConnection.Close();
                    Thread.Sleep(1000);
                    filterDbConnection.Open();
                }
            }

            filterNumber++;

            filterDbConnection.Close();
        }

        /// <summary>
        /// Add a filter using the restriction parameter for adding ORDER BY or WHERE clause, it is additive from the last filter
        /// </summary>
        /// <param name="restriction">String representing the clauses for the filter, must contains ORDER BY and/or WHERE clause</param>
        public void AddFilterOr(String restriction, int lastTabId)
        {
            SQLiteCommand filter;
            SQLiteCommand columnNum;
            String lastTab;
            bool success;

            filterDbConnection.Open();

            if (lastTabId == -1)
            {
                lastTab = "Content";
            }
            else
            {
                lastTab = "Filter" + lastTabId;
            }

            columnNum = new SQLiteCommand("CREATE TABLE ColumnNum" + filterNumber + " AS SELECT DISTINCT Line FROM "+ lastTab +" base " + restriction + " OR Line IN (SELECT Line FROM ColumnNum" + (filterNumber-1) + ")", filterDbConnection);
            success = false;

            while (!success)
            {
                try
                {
                    columnNum.ExecuteNonQuery();
                    success = true;
                }
                catch (SQLiteException e)
                {
                    //database is certainly locked, we'll just try again after one second ...
                    filterDbConnection.Close();
                    Thread.Sleep(1000);
                    filterDbConnection.Open();
                }
            }

            filter = new SQLiteCommand("CREATE TABLE Filter" + filterNumber + " AS SELECT base.Line AS 'BaseLine', Column, Content, colNum.rowid AS 'Line' FROM " + lastTab + " base INNER JOIN ColumnNum" + filterNumber + " colNum ON base.Line = colNum.Line", filterDbConnection);
            success = false;

            while (!success)
            {
                try
                {
                    filter.ExecuteNonQuery();
                    success = true;
                }
                catch (SQLiteException e)
                {
                    //database is certainly locked, we'll just try again after one second ...
                    filterDbConnection.Close();
                    Thread.Sleep(1000);
                    filterDbConnection.Open();
                }
            }

            new SQLiteCommand("CREATE INDEX AccessIndexFilter" + filterNumber + " ON Filter" + filterNumber + " (Column,Line)", filterDbConnection).ExecuteNonQuery();

            filterNumber++;

            filterDbConnection.Close();
        }

        /// <summary>
        /// Delete temporary tables created for the last final filter
        /// </summary>
        /// <param name="numberOfTables">number of tables created for the last filter (including the final one)</param>
        public void CleanTempTables(int numberOfTables)
        {
            filterDbConnection.Open();

            SQLiteCommand dropColumnNumCommand = new SQLiteCommand(filterDbConnection);
            SQLiteCommand dropFilterCommand = new SQLiteCommand(filterDbConnection);

            if (numberOfTables > 2)
            {
                for (int i = filterNumber - 2; i >= filterNumber - numberOfTables; i--)
                {
                    dropColumnNumCommand.CommandText = "DROP TABLE ColumnNum" + i;
                    dropFilterCommand.CommandText = "DROP TABLE Filter" + i;
                    dropColumnNumCommand.ExecuteNonQuery();
                    dropFilterCommand.ExecuteNonQuery();
                }
            }

            dropColumnNumCommand.CommandText = "DROP TABLE IF EXISTS ColumnNum" + (filterNumber-1);
            dropColumnNumCommand.ExecuteNonQuery();

            filterDbConnection.Close();
        }

        /// <summary>
        /// Delete all filters created with the AddFilter function
        /// </summary>
        public void DeleteAll()
        {
            SQLiteCommand command;

            filterDbConnection.Open();

            for (;filterNumber > 0; filterNumber--)
            {
                command = new SQLiteCommand("DROP Table Filter"+(filterNumber-1), filterDbConnection);
                command.ExecuteNonQuery();
                command.Reset();
            }

            command = new SQLiteCommand("DELETE FROM Column", filterDbConnection);

            command.ExecuteNonQuery();
            command.Reset();

            command = new SQLiteCommand("DELETE FROM Content", filterDbConnection);
            command.ExecuteNonQuery();
            command.Reset();

            filterDbConnection.Close();
        }

        /// <summary>
        /// return id assigned to the last created filter
        /// </summary>
        /// <returns>the last filter id</returns>
        internal int GetLastFilterId()
        {
            return filterNumber - 1;
        }

        /// <summary>
        /// Return the number of lines in the file
        /// </summary>
        /// <returns>An integer that represent the number of different lines in the file</returns>
        public int GetNumberOfLines()
        {
            mainDbConnection.Open();

            int result = Convert.ToInt32(new SQLiteCommand("SELECT count(*) FROM Content GROUP BY Column", mainDbConnection).ExecuteScalar());

            mainDbConnection.Close();

            return result;
        }

        /// <summary>
        /// return the number of line in specified filterNumber
        /// </summary>
        /// <param name="filterNumber"> the number of the filter we want the number of lines</param>
        /// <returns>the number of lines in this filter</returns>
        public int GetNumberOfLinesInFilter(int filterNumber)
        {
            mainDbConnection.Open();

            int result = Convert.ToInt32(new SQLiteCommand("SELECT count(*) FROM Filter"+filterNumber+" GROUP BY Column", mainDbConnection).ExecuteScalar());

            mainDbConnection.Close();

            return result;
        }

        /// <summary>
        /// this method is used for regex verification using REGEXP for each content member of the specified column
        /// </summary>
        /// <param name="column">the  column number we want to check</param>
        /// <param name="regex">the regex we want to use</param>
        /// <returns></returns>
        public List<int> CheckRegexColumn(int column, String regex)
        {
            List<int> errorLines = new List<int>();

            SQLiteCommand command = new SQLiteCommand("SELECT Line FROM Content WHERE Column = @col AND Content NOT REGEXP @regex ORDER BY Line ASC", checkDbConnection);
            command.Parameters.Add(new SQLiteParameter("@col", column));
            command.Parameters.Add(new SQLiteParameter("@regex", regex));

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                errorLines.Add((int)reader["Line"]);
            }

            return errorLines;
        }

        /// <summary>
        /// Compare the consistency between the CompAuxNum and CompAuxLib columns
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentCompAuxNumCompAuxLib()
        {
            bool boolien = false;
            List<int> line = new List<int>();

            PauseCheckIfAsked();

            SQLiteDataReader reader = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='6' ORDER BY Column ASC", checkDbConnection).ExecuteReader();
            SQLiteDataReader reader1 = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='7' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (reader.Read() && reader1.Read())
            {
                if (reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }
                else if (reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }

                if (!boolien)
                {
                    line.Add(Convert.ToInt32(reader1.GetValue(1)));
                }
            }

            return line;
        }

        /// <summary>
        /// Compare the consistency between the EcritureLet and DateLet columns
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentEcritureLetDateLet()
        {
            bool boolien = false;
            List<int> line = new List<int>();

            PauseCheckIfAsked();

            SQLiteDataReader reader = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='13' ORDER BY Column ASC", checkDbConnection).ExecuteReader();
            SQLiteDataReader reader1 = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='14' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (reader.Read() && reader1.Read())
            {
                if (reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }
                else if (reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }

                if (!boolien)
                {
                    line.Add(Convert.ToInt32(reader1.GetValue(1)));
                }
            }

            return line;
        }

        /// <summary>
        /// Compare the consistency between the Montantdevise and Idevise columns
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentMontantdeviseIdevise()
        {
            bool boolien = false;
            List<int> line = new List<int>();

            PauseCheckIfAsked();

            SQLiteDataReader reader = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='16' ORDER BY Column ASC", checkDbConnection).ExecuteReader();
            SQLiteDataReader reader1 = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='17' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (reader.Read() && reader1.Read())
            {
                if (reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }
                else if (reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }

                if (!boolien)
                {
                    line.Add(Convert.ToInt32(reader1.GetValue(1)));
                }
            }

            return line;
        }

        /// <summary>
        /// Research if PieceDate column is not upper than ValidDate column
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentPieceDateValidDate()
        {
            bool boolien = false;
            List<int> line = new List<int>();
            int pieceDate = 0;
            int validDate = 0;

            PauseCheckIfAsked();

            SQLiteDataReader readerPieceDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='9' ORDER BY Column ASC", checkDbConnection).ExecuteReader();
            SQLiteDataReader readerValidDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='15' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerPieceDate.Read() && readerValidDate.Read())
            {
                if (readerPieceDate.GetValue(0).ToString().Equals(""))
                {
                    pieceDate = 0;
                }
                else
                {
                    pieceDate = Convert.ToInt32(readerPieceDate.GetValue(0));
                }

                if (readerValidDate.GetValue(0).ToString().Equals(""))
                {
                    validDate = 0;
                }
                else
                {
                    validDate = Convert.ToInt32(readerValidDate.GetValue(0));
                }
                if (pieceDate <= validDate || pieceDate == 0 || validDate == 0)
                {
                    boolien = true;
                }
                else
                {
                    boolien = false;
                }

                if (!boolien)
                {
                    line.Add(Convert.ToInt32(readerPieceDate.GetValue(1)));
                }
            }

            return line;
        }

        /// <summary>
        /// Research if PieceDate column is not upper than EcritureDate column
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentPieceDateEcritureDate()
        {
            bool boolien = false;
            List<int> line = new List<int>();
            int pieceDate = 0;
            int ecritureDate = 0;
            
            PauseCheckIfAsked();

            SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='3' ORDER BY Column ASC", checkDbConnection).ExecuteReader();
            SQLiteDataReader readerPieceDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='9' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerEcritureDate.Read() && readerPieceDate.Read())
            {
                if (readerEcritureDate.GetValue(0).ToString().Equals(""))
                {
                    ecritureDate = 0;
                }
                else
                {
                    ecritureDate = Convert.ToInt32(readerEcritureDate.GetValue(0));
                }

                if (readerPieceDate.GetValue(0).ToString().Equals(""))
                {
                    pieceDate = 0;
                }
                else
                {
                    pieceDate = Convert.ToInt32(readerPieceDate.GetValue(0));
                }
                if (pieceDate <= ecritureDate || pieceDate == 0 || ecritureDate == 0)
                {
                    boolien = true;
                }
                else
                {
                    boolien = false;
                }

                if (!boolien)
                {
                    line.Add(Convert.ToInt32(readerEcritureDate.GetValue(1)));
                }
            }

            return line;
        }

        /// <summary>
        /// Research if EcritureDate column is not upper than ValidDate column
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentEcritureDateValidDate()
        {
            bool boolien = false;
            List<int> line = new List<int>();
            int ecritureDate = 0;
            int validDate = 0;

            PauseCheckIfAsked();

            SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='3' ORDER BY Column ASC", checkDbConnection).ExecuteReader();
            SQLiteDataReader readerValidDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='15' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerEcritureDate.Read() && readerValidDate.Read())
            {
                if (readerEcritureDate.GetValue(0).ToString().Equals(""))
                {
                    ecritureDate = 0;
                }
                else
                {
                    ecritureDate = Convert.ToInt32(readerEcritureDate.GetValue(0));
                }
                if (readerValidDate.GetValue(0).ToString().Equals(""))
                {
                    validDate = 0;
                }
                else
                {
                    validDate = Convert.ToInt32(readerValidDate.GetValue(0));
                }
                if (ecritureDate <= validDate || ecritureDate == 0 || validDate == 0)
                {
                    boolien = true;
                }
                else
                {
                    boolien = false;
                }

                if (!boolien)
                {
                    line.Add(Convert.ToInt32(readerValidDate.GetValue(1)));
                }
            }

            return line;
        }

        /// <summary>
        /// Research if DateLet column is not lower than PieceDate column
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentDateLetPieceDate()
        {
            bool boolien = false;
            List<int> line = new List<int>();
            int pieceDate = 0;
            int dateLet = 0;

            PauseCheckIfAsked();

            SQLiteDataReader readerPieceDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='9' ORDER BY Column ASC", checkDbConnection).ExecuteReader();
            SQLiteDataReader readerDateLet = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='14' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerPieceDate.Read() && readerDateLet.Read())
            {
                if (readerPieceDate.GetValue(0).ToString().Equals(""))
                {
                    pieceDate = 0;
                }
                else
                {
                    pieceDate = Convert.ToInt32(readerPieceDate.GetValue(0));
                }

                if (readerDateLet.GetValue(0).ToString().Equals(""))
                {
                    dateLet = 0;
                }
                else
                {
                    dateLet = Convert.ToInt32(readerDateLet.GetValue(0));
                }

                if (dateLet >= pieceDate || pieceDate == 0 || dateLet == 0)
                {
                    boolien = true;
                }
                else
                {
                    boolien = false;
                }

                if (!boolien)
                {
                    line.Add(Convert.ToInt32(readerPieceDate.GetValue(1)));
                }
            }

            return line;
        }

        /// <summary>
        /// Research if DateLet column is not lower than EcritureDate column
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentDateLetEcritureDate()
        {
            bool boolien = false;
            List<int> line = new List<int>();
            int ecritureDate = 0;
            int dateLet = 0;

            PauseCheckIfAsked();

            SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='3' ORDER BY Column ASC", checkDbConnection).ExecuteReader();
            SQLiteDataReader readerDateLet = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='14' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerEcritureDate.Read() && readerDateLet.Read())
            {
                if (readerEcritureDate.GetValue(0).ToString().Equals(""))
                {
                    ecritureDate = 0;
                }
                else
                {
                    ecritureDate = Convert.ToInt32(readerEcritureDate.GetValue(0));
                }

                if (readerDateLet.GetValue(0).ToString().Equals(""))
                {
                    dateLet = 0;
                }
                else
                {
                    dateLet = Convert.ToInt32(readerDateLet.GetValue(0));
                }

                if (dateLet >= ecritureDate || dateLet == 0 || ecritureDate == 0)
                {
                    boolien = true;
                }
                else
                {
                    boolien = false;
                }

                if (!boolien)
                {
                    line.Add(Convert.ToInt32(readerDateLet.GetValue(1)));
                }
            }

            return line;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific EcritureNum value
        /// </summary>
        /// <returns>The list of EcritureNum where there are errors</returns>
        public List<String> EcritureNumDebitCredit()
        {
            double debit = 0.0;
            double credit = 0.0;

            PauseCheckIfAsked();

            List<String> listTemp = new List<string>();
            SQLiteDataReader readerEcritureNum = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='2' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerEcritureNum.Read())
            {
                SQLiteDataReader readerDebit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='2' and content='" + readerEcritureNum["Content"] + "')", checkDbConnection).ExecuteReader();
                SQLiteDataReader readerCredit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='2' and content='" + readerEcritureNum["Content"] + "')", checkDbConnection).ExecuteReader();

                while (readerDebit.Read() && readerCredit.Read())
                {
                    debit += Convert.ToDouble(readerDebit.GetValue(0));
                    credit += Convert.ToDouble(readerCredit.GetValue(0));
                }

                if (Math.Round(debit - credit, 4) != 0)
                {
                    listTemp.Add(readerEcritureNum["Content"].ToString());
                }

                debit = 0;
                credit = 0;
            }

            return listTemp;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific JournalCode value
        /// </summary>
        /// <returns>The list of JournalCode where there are errors</returns>
        public List<String> JournalCodeDebitCredit()
        {
            double debit = 0.0;
            double credit = 0.0;

            List<String> listTemp = new List<string>();

            PauseCheckIfAsked();

            SQLiteDataReader readerJournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerJournalCode.Read())
            {
                SQLiteDataReader readerDebit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "')", checkDbConnection).ExecuteReader();
                SQLiteDataReader readerCredit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "')", checkDbConnection).ExecuteReader();

                while (readerDebit.Read() && readerCredit.Read())
                {
                    debit += Convert.ToDouble(readerDebit.GetValue(0));
                    credit += Convert.ToDouble(readerCredit.GetValue(0));
                }

                if (Math.Round(debit - credit, 4) != 0)
                {
                    listTemp.Add(readerJournalCode["Content"].ToString());
                }

                debit = 0;
                credit = 0;
            }

            return listTemp;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column on the entire file
        /// </summary>
        /// <returns>True if the sum of Debit and Credit are not different</returns>
        public bool AllLinesDebitCredit()
        {
            double debit = 0.0;
            double credit = 0.0;
            bool check = false;

            PauseCheckIfAsked();

            SQLiteDataReader readerDebit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' ", checkDbConnection).ExecuteReader();
            SQLiteDataReader readerCredit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' ", checkDbConnection).ExecuteReader();

            while (readerDebit.Read() && readerCredit.Read())
            {
                debit += Convert.ToDouble(readerDebit.GetValue(0));
                credit += Convert.ToDouble(readerCredit.GetValue(0));
            }
            if (Math.Round(debit - credit, 4) != 0)
            {
                check = true;
            }

            return check;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column on the entire file (in a Montant-Sens file)
        /// </summary>
        /// <returns>True if the sum of Debit and Credit are not different</returns>
        public bool AllLinesMontantSens()
        {
            double debit = 0.0;
            double credit = 0.0;
            bool check = false;

            PauseCheckIfAsked();

            SQLiteDataReader readerMontant = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='11' ", checkDbConnection).ExecuteReader();
            SQLiteDataReader readerSens = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='12' ", checkDbConnection).ExecuteReader();

            while (readerMontant.Read() && readerSens.Read())
            {
                if (readerSens.GetValue(0).ToString().Equals("D"))
                {
                    debit += Convert.ToDouble(readerMontant.GetValue(0));
                }
                else if (readerSens.GetValue(0).ToString().Equals("C"))
                {
                    credit += Convert.ToDouble(readerMontant.GetValue(0));
                }
                else if (readerSens.GetValue(0).ToString().Equals("+1"))
                {
                    debit += Convert.ToDouble(readerMontant.GetValue(0));
                }
                else if (readerSens.GetValue(0).ToString().Equals("-1"))
                {
                    credit += Convert.ToDouble(readerMontant.GetValue(0));
                }
            }

            if (Math.Round(debit - credit, 4) != 0)
            {
                check = true;
            }

            return check;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific JournalCode value (in a Montant-Sens file)
        /// </summary>
        /// <returns>The list of JournalCode where there are errors</returns>
        public List<String> JournalCodeMontantSens()
        {
            double debit = 0.0;
            double credit = 0.0;

            PauseCheckIfAsked();

            List<String> listTemp = new List<string>();
            SQLiteDataReader readerJournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerJournalCode.Read())
            {
                SQLiteDataReader readerMontant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "')", checkDbConnection).ExecuteReader();
                SQLiteDataReader readerSens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' ", checkDbConnection).ExecuteReader();

                while (readerMontant.Read() && readerSens.Read())
                {
                    if (readerSens.GetValue(0).ToString().Equals("D"))
                    {
                        debit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("C"))
                    {
                        credit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("+1"))
                    {
                        debit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("-1"))
                    {
                        credit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                }

                if (Math.Round(debit - credit, 4) != 0)
                {
                    listTemp.Add(readerJournalCode["Content"].ToString());
                }

                debit = 0;
                credit = 0;
            }

            return listTemp;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific EcritureNum value (in a Montant-Sens file)
        /// </summary>
        /// <returns>The list of EcritureNum where there are errors</returns>
        public List<String> EcritureNumMontantSens()
        {
            double debit = 0.0;
            double credit = 0.0;

            PauseCheckIfAsked();

            List<String> listTemp = new List<string>();
            SQLiteDataReader readerEcritureNum = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='2' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerEcritureNum.Read())
            {
                SQLiteDataReader readerMontant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='2' and content='" + readerEcritureNum["Content"] + "')", checkDbConnection).ExecuteReader();
                SQLiteDataReader readerSens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' ", checkDbConnection).ExecuteReader();

                while (readerMontant.Read() && readerSens.Read())
                {
                    if (readerSens.GetValue(0).ToString().Equals("D"))
                    {
                        debit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("C"))
                    {
                        credit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("+1"))
                    {
                        debit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("-1"))
                    {
                        credit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                }

                if (Math.Round(debit - credit, 4) != 0)
                {
                    listTemp.Add(readerEcritureNum["Content"].ToString());
                }

                debit = 0;
                credit = 0;
            }

            return listTemp;
        }

        /// <summary>
        /// Research if the file is a Montant-Sens file
        /// </summary>
        /// <returns>True if the file is a Montant-Sens file</returns>
        public bool IsMontantSens()
        {
            PauseCheckIfAsked();

            SQLiteDataReader readerColumnName = new SQLiteCommand("SELECT DISTINCT Name FROM Column", checkDbConnection).ExecuteReader();

            while (readerColumnName.Read())
            {
                if (readerColumnName.GetValue(0).ToString().Equals("Montant"))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific Month value for each JournalCode (in a Montant-Sens file)
        /// </summary>
        /// <returns>The list of JournalCode and Month where there are errors</returns>
        public List<String> CompareMontantSensByMonth()
        {
            double debit = 0.0;
            double credit = 0.0;

            PauseCheckIfAsked();

            List<String> listTemp = new List<string>();
            SQLiteDataReader readerJournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerJournalCode.Read())
            {
                SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='3' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "')", checkDbConnection).ExecuteReader();
                String month = "";

                while (readerEcritureDate.Read())
                {
                    if (readerEcritureDate.GetValue(0).ToString().Substring(0, 6).Equals(month))
                    {
                        SQLiteDataReader readerMontant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", checkDbConnection).ExecuteReader();
                        SQLiteDataReader readerSens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", checkDbConnection).ExecuteReader();

                        while (readerMontant.Read() && readerSens.Read())
                        {
                            if (readerSens.GetValue(0).ToString().Equals("D"))
                            {
                                debit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("C"))
                            {
                                credit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("+1"))
                            {
                                debit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("-1"))
                            {
                                credit += Convert.ToDouble(readerMontant.GetValue(0));
                            }

                        }
                    }
                    else
                    {
                        if (Math.Round(debit - credit, 4) != 0)
                        {
                            listTemp.Add(readerJournalCode["Content"].ToString() + "\t Mois : " + month.Insert(4, "/"));
                        }

                        debit = 0.0;
                        credit = 0.0;
                        month = readerEcritureDate.GetValue(0).ToString().Substring(0, 6);

                        SQLiteDataReader readerMontant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", checkDbConnection).ExecuteReader();
                        SQLiteDataReader readerSens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", checkDbConnection).ExecuteReader();

                        while (readerMontant.Read() && readerSens.Read())
                        {
                            if (readerSens.GetValue(0).ToString().Equals("D"))
                            {
                                debit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("C"))
                            {
                                credit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("+1"))
                            {
                                debit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("-1"))
                            {
                                credit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                        }
                    }    
                }

                if (Math.Round(debit - credit, 4) != 0)
                {
                    listTemp.Add(readerJournalCode["Content"].ToString() + "\t Mois : " + month.Insert(4, "/"));
                }

                debit = 0.0;
                credit = 0.0;
            }

            return listTemp;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific Month value for each JournalCode
        /// </summary>
        /// <returns>The list of JournalCode and Month where there are errors</returns>
        public List<String> CompareDebitCreditByMonth()
        {
            double debit = 0.0;
            double credit = 0.0;

            PauseCheckIfAsked();

            List<String> listTemp = new List<string>();
            SQLiteDataReader readerJournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerJournalCode.Read())
            {
                SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='3' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "')", checkDbConnection).ExecuteReader();
                String month = "";

                while (readerEcritureDate.Read())
                {
                    if (readerEcritureDate.GetValue(0).ToString().Substring(0, 6).Equals(month))
                    {
                        SQLiteDataReader readerDebit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", checkDbConnection).ExecuteReader();
                        SQLiteDataReader readerCredit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", checkDbConnection).ExecuteReader();

                        while (readerDebit.Read() && readerCredit.Read())
                        {
                            debit += Convert.ToDouble(readerDebit.GetValue(0));
                            credit += Convert.ToDouble(readerCredit.GetValue(0));
                        }
                    }
                    else
                    {
                        if (Math.Round(debit - credit, 4) != 0 && !readerJournalCode["Content"].ToString().Equals(null))
                        {
                            listTemp.Add(readerJournalCode["Content"].ToString() + "\t Mois : " + month.Insert(4, "/"));
                        }

                        debit = 0.0;
                        credit = 0.0;
                        month = readerEcritureDate.GetValue(0).ToString().Substring(0, 6);

                        SQLiteDataReader readerDebit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", checkDbConnection).ExecuteReader();
                        SQLiteDataReader readerCredit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", checkDbConnection).ExecuteReader();

                        while (readerDebit.Read() && readerCredit.Read())
                        {
                            debit += Convert.ToDouble(readerDebit.GetValue(0));
                            credit += Convert.ToDouble(readerCredit.GetValue(0));
                        }
                    }
                }

                if (Math.Round(debit - credit, 4) != 0)
                {
                    listTemp.Add(readerJournalCode["Content"].ToString() + "\t Mois : " + month.Insert(4,"/"));
                }

                debit = 0.0;
                credit = 0.0;
            }

            return listTemp;
        }

        /// <summary>
        /// Research if the EcritureDate value is unique for each JournalCode
        /// </summary>
        /// <returns>The list of JournalCode and Month where there are errors</returns>
        public List<String> IsDateUniqueForEcritureNum()
        {
            PauseCheckIfAsked();

            List<String> listTemp = new List<string>();
            SQLiteDataReader readerEcritureNum = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='2' ORDER BY Column ASC", checkDbConnection).ExecuteReader();

            while (readerEcritureNum.Read())
            {
                int count = 0;

                SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='3' and Line in (SELECT Line from Content where column='2' and content='" + readerEcritureNum["Content"] + "')", checkDbConnection).ExecuteReader();

                while (readerEcritureDate.Read())
                {
                    count++;
                }

                if (count > 1)
                {
                    listTemp.Add(readerEcritureNum["Content"].ToString());
                }
            }

            return listTemp;
        }
    }
}
