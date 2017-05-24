using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyseEtControleFEC.Controller
{
    public class SimpleFilterController
    {
        /// <summary>
        /// Reference to DataBaseController
        /// </summary>
        private DataBaseController dataBaseController;

        public SimpleFilterController(DataBaseController dataBaseController)
        {
            this.dataBaseController = dataBaseController;
        }


        /*
            The list of operators to be provided for the fields of type Numeric and Date is :
                 - Is greater than
                 - Is greater than or equal to
                 - Is inferior to
                 - Is less than or equal to
                 - Is equal to
                 - Is different from
            The list of operators to be provided for the String type fields is :
                 - Contains
                 - Does not contain
                 - Starts with
                 - Do not start with
                 - To end by
                 - Does not end with
                 - Is equal to
                 - Is different from
         */

        /// <summary>
        /// Filter if value is a numeric or a date
        /// </summary>
        /// <param name="column">The associate column</param>
        /// <param name="typeFilter">The sort of the filter</param>
        /// <param name="value">The value</param>
        /// <returns>The value filtered</returns>
        public string NumericOrDateSimpleFilter(string column, string typeFilter, string value)
        {
            
            string[] columnNames = dataBaseController.GetColumnNames();
            string columnNameInDb = "";

            for (int i = 0; i < columnNames.Length; i++)
            {
                if (columnNames[i].Equals(column))
                    columnNameInDb = i.ToString();
            }

            string result = " WHERE Column = " + columnNameInDb;

            switch (typeFilter)
            {
                case "Est supérieur à":
                    return result+" AND ISSTRICTLYSUPERIOR(Content, '" + value + "')";
                case "Est supérieur ou égal à":
                    return result + " AND ISSUPERIOR(Content, '" + value + "')";
                case "Est inférieur à":
                    return result + " AND NOT ISSUPERIOR(Content, '" + value + "')";
                case "Est inférieur ou égal à":
                    return result + " AND NOT ISSTRICTLYSUPERIOR(Content, '" + value + "')";
                case "Est égal à":
                    return result + " AND ISEQUAL(Content, '" + value + "')";
                case "Est différent de":
                    return result + " AND NOT ISEQUAL(Content, '" + value + "')";
                default:
                    return result + "";
            }
        }

        /// <summary>
        /// Filter if value is a text
        /// </summary>
        /// <param name="column">The associate column</param>
        /// <param name="typeFilter">The sort of the filter</param>
        /// <param name="value">The value</param>
        /// <returns>The value filtered</returns>
        public string TextSimpleFilter(string column, string typeFilter, string value)
        {
            string[] columnNames = dataBaseController.GetColumnNames();
            string columnNameInDb = "";

            for (int i = 0; i < columnNames.Length; i++)
            {
                if (columnNames[i].Equals(column))
                    columnNameInDb = i.ToString();
            }

            string result = " WHERE Column = " + columnNameInDb;

            switch (typeFilter)
            {
                case "Contient":
                    return result + " AND Content "+"LIKE '" + "%" + value + "%" + "'";
                case "Ne contient pas":
                    return result + " AND Content "+"NOT" + " LIKE '" + "%" + value + "%"+ "'";
                case "Commence par":
                    return result + " AND Content "+" LIKE '" + value + "%" + "'";
                case "Ne commence pas par":
                    return result + " AND Content " + " NOT" +" LIKE '" + value + "%" + "'";
                case "Se termine par":
                    return result + " AND Content " + " LIKE '" + "%" + value + "'";
                case "Ne se termine pas par":
                    return result + " AND Content " + " NOT" + " LIKE '" + "%" + value + "'";
                case "Est égal à":
                    return result + " AND Content " + " LIKE '" + value + "'";
                case "Est différent de":
                    return result + " AND Content " + " NOT" + " LIKE '" + value + "'";
                default:
                    return result ;
            }
        }
    }
}
