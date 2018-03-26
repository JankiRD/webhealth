using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Surrogacy.Helper;
using Surrogacy.Models;

namespace Surrogacy.Data
{
    public class ListData : BaseData
    {
        public DataSet GetSurrogateData(ListSurrogate listsurrogate)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGg_ListSurrogate";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(listsurrogate);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "TEMP";
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