using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace Surrogacy.Helper
{
    #region Description
    /*
    Created On      :   01/06/2015
    Author          :   Mohit Vaghadiya
    Purpose         :   To handle common string operations
    Stay Connected  :   codelib.in
    */
    #endregion Description

    #region List of methods
    /*
    <methodlist>
        <method name"IsValidEmail">To validate email address</method>
        <method name"IsValidNameWithSpace">To validate name [only one spave allowed]</method>
        <method name"IsValidNameWithOutSpace">To validate name [no space allowed]</method>
        <method name"IsValidDomain">To validate domain</method>
        <method name"IsValidDataType">To validate string with specific datatype</method>
    </methodlist>
    */
    #endregion List of methods

    public class StringHelper
    {

        #region Data member initialization

        //General variables to return value
        private static bool boolResult;
        private static string stringResult;
        private static int intResult;

        //Constructor to initialized class member variables
        static StringHelper()
        {
            boolResult = false;
            stringResult = string.Empty;
            intResult = 0;
        }

        #endregion Data member initialization

        #region Enum Properties
        public enum DataType
        {
            INT,
            FLOAT,
            DECIMAL,
            DOUBLE,
            LONG,
            SHORT,
            UINT,
            ULONG,
            USHORT,
            DATETIME,
            DATE
        }
        #endregion Enum Properties

        #region Boolean type methos

        //<method>IsValidEmail</method>
        //<purpose>To validate Email address</purpose>
        //<param name="email">string to validate</param>
        //<returns type="bool">True if valid Email, False if invalid Email</returns>
        //<author>Mohit Vaghadiya</author>
        //<implementedOn>01/06/2016</implementedOn>
        //<tackNo />
        public static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                boolResult = true;
            }
            catch (Exception)
            {
                boolResult = false;
            }
            return boolResult;
        }

        //<method>IsValidNameWithSpace</method>
        //<purpose>To validate Name [Only one space allowed]</purpose>
        //<param name="name">string to validate</param>
        //<returns type="bool">True if valid Name, False if invalid Name</returns>
        //<author>Mohit Vaghadiya</author>
        //<implementedOn>01/06/2016</implementedOn>
        //<tackNo />
        public static bool IsValidNameWithSpace(string name)
        {
            boolResult = Regex.IsMatch(name, @"^[a-zA-Z\s,]*$");
            return boolResult;
        }

        public static bool IsValidAge(string age)
        {
            return boolResult;
        }

        //<method>IsValidDomain</method>
        //<purpose>To validate Domain name</purpose>
        //<param name="name">string to validate</param>
        //<returns type="bool">True if valid Name, False if invalid Name</returns>
        //<author>Mohit Vaghadiya</author>
        //<implementedOn>01/06/2016</implementedOn>
        //<tackNo />
        public static bool IsValidDomain(string domain)
        {
            return boolResult;
        }

        //<method>IsValidDataType</method>
        //<purpose>To validate string with specific datatype</purpose>
        //<param name="dataType">data type</param>
        //<param name="str">String to validate with given datatype</param>
        //<returns type="bool">True if valid datatype, False if invalid datatype</returns>
        //<author>Mohit Vaghadiya</author>
        //<implementedOn>01/06/2016</implementedOn>
        //<tackNo />
        public static bool IsValidDataType(DataType dataType, string str)
        {
            int intType;
            float floatType;
            decimal decimalType;
            double doubleType;
            long longType;
            short shortType;
            uint uintType;
            ulong ulongType;
            ushort ushortType;
            DateTime dateTimeType;            

            switch (dataType)
            {
                case DataType.INT:
                    boolResult = int.TryParse(str, out intType);
                    break;
                case DataType.FLOAT:
                    boolResult = float.TryParse(str, out floatType);
                    break;
                case DataType.DECIMAL:
                    boolResult = decimal.TryParse(str, out decimalType);
                    break;
                case DataType.DOUBLE:
                    boolResult = double.TryParse(str, out doubleType);
                    break;
                case DataType.LONG:
                    boolResult = long.TryParse(str, out longType);
                    break;
                case DataType.SHORT:
                    boolResult = short.TryParse(str, out shortType);
                    break;
                case DataType.UINT:
                    boolResult = uint.TryParse(str, out uintType);
                    break;
                case DataType.ULONG:
                    boolResult = ulong.TryParse(str, out ulongType);
                    break;
                case DataType.USHORT:
                    boolResult = ushort.TryParse(str, out ushortType);
                    break;
                case DataType.DATETIME:
                    boolResult = DateTime.TryParse(str, out dateTimeType);
                    break;
                case DataType.DATE:
                    boolResult = DateTime.TryParseExact(str, "MM/dd/yyyy",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out dateTimeType);
                    break;
                default:
                    boolResult = false;
                    break;
            }

            return boolResult;
        }

        //<method>IsOnlyAlphabetsWithSpace</method>
        //<purpose>To validate Name</purpose>
        //<param name="name">string to validate</param>
        //<returns type="bool">True if valid Name, False if invalid Name</returns>
        //<author>Mohit Vaghadiya</author>
        //<implementedOn>01/06/2016</implementedOn>
        //<tackNo />
        public static bool IsOnlyAlphabetsWithoutSpace(string str)
        {
            boolResult = Regex.IsMatch(str, @"^[a-zA-Z]+$");
            return boolResult;
        }


        //<method>IsOnlyAlphabetsWithSpace</method>
        //<purpose>To validate Name</purpose>
        //<param name="name">string to validate</param>
        //<returns type="bool">True if valid Name, False if invalid Name</returns>
        //<author>Mohit Vaghadiya</author>
        //<implementedOn>01/06/2016</implementedOn>
        //<tackNo />
        public static bool IsOnlyAlphabetsWithSpace(string str)
        {
            boolResult = Regex.IsMatch(str, @"^[a-zA-Z0-9# ]+$");
            return boolResult;
        }

        public static bool IsAlphaNumericWithSpace(string str)
        {
            boolResult = Regex.IsMatch(str, @"[^\w\s]");
            return boolResult;
        }
        public static bool IsAlphaNumericWithoutSpace(string str)
        {
            boolResult = Regex.IsMatch(str, @"^[a-zA-Z0-9\s,]*$");
            return boolResult;
        }

        public static bool IsNumeric(string str)
        {
            boolResult = Regex.IsMatch(str, @"^[0-9\s,]*$");
            return boolResult;
        }

        public static bool IsNumericWithDecimal(string str)
        {
            boolResult = Regex.IsMatch(str, @"^[0-9]+(\.[0-9]+)?$");
            return boolResult;
        }

        public static bool IsNumericWithSpace(string str)
        {
            boolResult = Regex.IsMatch(str, @"^[0-9# ]+$");
            return boolResult;
        }

        public static bool IsNumericNotZero(string str)
        {
            boolResult = !string.IsNullOrEmpty(str) && Regex.IsMatch(str, @"^[0-9\s,]*$") && str != "0";
            return boolResult;
        }

        public static bool IsNumericOrZero(string str)
        {
            boolResult = !string.IsNullOrEmpty(str) && Regex.IsMatch(str, @"^[0-9\s,]*$");
            return boolResult;
        }

        public static bool IsEmpty(string str)
        {
            boolResult = !string.IsNullOrEmpty(str.Trim());
            return boolResult;
        }

        #endregion Boolean type methos

        #region String type methods
        #endregion String type methods

        #region Integer type methos
        #endregion Integer type methods
    }
}