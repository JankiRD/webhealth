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
    public class InfoSurrogateData : BaseData
    {
        public DataSet ViewInfoSurrogate(InfoSurrogate infosurrogate,int SurrogateID)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGg_InfoSurrogate";
                string parameterName = "@aXMLString";
                infosurrogate.SurrogateID = SurrogateID.ToString();
                string parameterValue = ObjectHelper.GetXMLFromObject(infosurrogate);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "InfoSurrogate";
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

        public DataSet SaveInfoSurrogate(InfoSurrogate infosurrogate)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGs_InfoSurrogate";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(infosurrogate);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "InfoSurrogate";
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