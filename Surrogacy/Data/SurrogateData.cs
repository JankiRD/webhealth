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
    public class SurrogateData : BaseData
    {
        public DataSet SaveSurrogatePersonalInfo(SurrogatePersonalInfo surrogatePersonalInfo)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGs_SurrogatePersonalInfo";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(surrogatePersonalInfo);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "SurrogatePersonalInfo";
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

        public DataSet SaveMedicalInfo(MedicalInfo medicalInfo)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGs_MedicalInfo";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(medicalInfo);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "MedicalInfo";
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

        public DataSet SaveSurrogacyHistory(SurrogacyHistory SurrogacyHistory)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGs_SurrogacyHistoryInfo";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(SurrogacyHistory);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "SURROGACYHISTORY";
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

        public DataSet SavePregnancyHistory(PregnancyHistory pregnancyHistory)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGs_PreganancyHistory";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(pregnancyHistory);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "PREGNANCYHISTORY";
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

        public DataSet SaveMentalHealth(MentalHealth mentalhealth)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGs_MentalHealth";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(mentalhealth);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "MENTALHEALTH";
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

        public DataSet SaveLifeStyle(LifeStyle lifestyle)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGg_LifeStyle";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(lifestyle);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "LIFESTYLE";
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

        public DataSet SaveDocuments(Documents documents)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGg_Documents";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(documents);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "DOCUMENT";
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

        public DataSet SaveFinalSubmit(FinalSubmit finalsubmit)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGg_FinalSubmit";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(finalsubmit);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "FINALSUBMIT";
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