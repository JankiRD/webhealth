﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Surrogacy.Helper;
using Surrogacy.Models;

namespace Surrogacy.Data
{
    public class UserData : BaseData
    {
        public DataSet ValidateUser(User user)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGg_ValidateUser";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(user);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "SEC_USER";
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

        public DataSet SaveUser(User user)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGs_UserDetail";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(user);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "SEC_USER";
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