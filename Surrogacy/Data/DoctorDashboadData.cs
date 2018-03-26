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
    public class DoctorDashboadData : BaseData
    {
        public DataSet ViewDoctorDashboardData(DoctorDashboard doctordashboad)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGg_DoctorDashboad";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(doctordashboad);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "DoctorDashboard";
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