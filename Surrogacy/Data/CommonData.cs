using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Surrogacy.Entity;
using Surrogacy.Helper;

namespace Surrogacy.Data
{
    public class CommonData : BaseData
    {
        public DataSet getSystemDropDown(SystemDropDown systemDropDownList)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGg_SystemDropDown";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(systemDropDownList);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "DROPDOWNLIST";
            }
            catch(Exception) 
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

            return dataSet;
        }

        public DataSet getSystemConfiguration()
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGg_SystemConfiguration";
                string parameterName = "@aXMLString";
                string parameterValue = "";
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "SYSTEMSETTING";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

            return dataSet;
        }
    }
}