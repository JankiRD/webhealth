using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Surrogacy.Data;
using Surrogacy.Helper;
using Surrogacy.Models;
using Surrogacy.Util;

namespace Surrogacy.Service
{
    public class SurrogateService
    {

        public SurrogatePersonalInfo SaveSurrogatePersonalInfo(SurrogatePersonalInfo surrogatePersonalInfo)
        {
            SurrogatePersonalInfo localSurrogatePersonalInfo = new SurrogatePersonalInfo();
            SurrogateData surrogateData = new SurrogateData();
            DataSet dataSet = new DataSet();

            try
            {
                dataSet = surrogateData.SaveSurrogatePersonalInfo(surrogatePersonalInfo);

                if (dataSet.Tables["SurrogatePersonalInfo"].Rows.Count > 0)
                {
                    localSurrogatePersonalInfo = new SurrogatePersonalInfo();
                    localSurrogatePersonalInfo.SurrogateID = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["SURROGATEID"].ToString();
                    localSurrogatePersonalInfo.UserID = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["USERID"].ToString();
                    localSurrogatePersonalInfo.FirstName = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["FIRSTNAME"].ToString();
                    localSurrogatePersonalInfo.LastName = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["LASTNAME"].ToString();
                    localSurrogatePersonalInfo.MiddleName = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["MIDDLENAME"].ToString();
                    localSurrogatePersonalInfo.DOB = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["DOB"].ToString();
                    localSurrogatePersonalInfo.Age = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["AGE"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["AGE"].ToString());
                    localSurrogatePersonalInfo.Citizenship = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["CITIZENSHIP"].ToString();
                    localSurrogatePersonalInfo.Height = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["HEIGHTFEET"].ToString();
                    localSurrogatePersonalInfo.Weight = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["WEIGHT"].ToString();
                    localSurrogatePersonalInfo.MaritalStatus = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["MARITALSTATUS"].ToString();
                    localSurrogatePersonalInfo.SpouseFullName = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["SPOUSEFULLNAME"].ToString();
                    localSurrogatePersonalInfo.SpouseFullName = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["SPOUSEFULLNAME"].ToString();
                    localSurrogatePersonalInfo.SpouseDOB = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["SPOUSEDOB"].ToString();
                    localSurrogatePersonalInfo.NoOfChild = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["NOOFCHILD"].ToString();
                    localSurrogatePersonalInfo.StepChild = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["STEPCHILD"].ToString();
                    localSurrogatePersonalInfo.ChildDescription = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["CHILDDESCRIPTION"].ToString();
                    localSurrogatePersonalInfo.Pregnant = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["PREGNANT"].ToString();
                    localSurrogatePersonalInfo.Adopted = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["ADOPTED"].ToString();
                    localSurrogatePersonalInfo.Residence = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["RESIDENCE"].ToString();
                    localSurrogatePersonalInfo.EthnicBackGround = dataSet.Tables["SurrogatePersonalInfo"].Rows[0]["ETHNICBACKGROUND"].ToString();
                }
            }
            catch (SqlException sqlEx)
            {
                localSurrogatePersonalInfo.responseDetail.responseType = ResponseType.Error;
                localSurrogatePersonalInfo.responseDetail.ResponseMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                localSurrogatePersonalInfo.responseDetail.responseType = ResponseType.Error;
                localSurrogatePersonalInfo.responseDetail.ResponseMessage = ApplicationManager.GenericErrorMessage;

                LoggerHelper.WriteToLog(ex);
            }

            return localSurrogatePersonalInfo == null ? new SurrogatePersonalInfo() : localSurrogatePersonalInfo;
        }

        public MedicalInfo SaveMedicalInfo(MedicalInfo medicalInfo)
        {
            MedicalInfo localMedicalInfo = new MedicalInfo();
            SurrogateData surrogateData = new SurrogateData();
            DataSet dataSet = new DataSet();

            try
            {
                dataSet = surrogateData.SaveMedicalInfo(medicalInfo);

                if (dataSet.Tables["MedicalInfo"].Rows.Count > 0)
                {
                    localMedicalInfo = new MedicalInfo();
                    localMedicalInfo.UserID = dataSet.Tables["MedicalInfo"].Rows[0]["MEDICALINFOID"].ToString();
                    localMedicalInfo.UserID = dataSet.Tables["MedicalInfo"].Rows[0]["USERID"].ToString();
                    localMedicalInfo.Ablation = dataSet.Tables["MedicalInfo"].Rows[0]["ABLATION"].ToString();
                    localMedicalInfo.WeightLoss = dataSet.Tables["MedicalInfo"].Rows[0]["WEIGHLOSS"].ToString();
                    localMedicalInfo.Medical = dataSet.Tables["MedicalInfo"].Rows[0]["MEDICAL"].ToString();
                    localMedicalInfo.MedicalDetail = dataSet.Tables["MedicalInfo"].Rows[0]["MEDICALDETAIL"].ToString();
                    localMedicalInfo.Medication = dataSet.Tables["MedicalInfo"].Rows[0]["MEDICATION"].ToString();
                    localMedicalInfo.MedicationDetail = dataSet.Tables["MedicalInfo"].Rows[0]["MEDICATIONDETAIL"].ToString();
                    localMedicalInfo.BreastFeeding = dataSet.Tables["MedicalInfo"].Rows[0]["BREASTFEEDING"].ToString();
                    localMedicalInfo.Periods = dataSet.Tables["MedicalInfo"].Rows[0]["PERIODS"].ToString();
                    localMedicalInfo.IsSubmit = Convert.ToInt32(dataSet.Tables["MedicalInfo"].Rows[0]["ISSUBMIT"].ToString());
                }
            }
            catch (SqlException sqlEx)
            {
                localMedicalInfo.responseDetail.responseType = ResponseType.Error;
                localMedicalInfo.responseDetail.ResponseMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                localMedicalInfo.responseDetail.responseType = ResponseType.Error;
                localMedicalInfo.responseDetail.ResponseMessage = ApplicationManager.GenericErrorMessage;

                LoggerHelper.WriteToLog(ex);
            }

            return localMedicalInfo == null ? new MedicalInfo() : localMedicalInfo;
        }

        public SurrogacyHistory SaveSurrogacyHistory(SurrogacyHistory SurrogacyHistory)
        {
            SurrogacyHistory localsurrogacyhistory = new SurrogacyHistory();
            SurrogateData surrogacyhistorydata = new SurrogateData();
            DataSet dataSet = new DataSet();

            try
            {
                dataSet = surrogacyhistorydata.SaveSurrogacyHistory(SurrogacyHistory);

                if (dataSet.Tables["SURROGACYHISTORY"].Rows.Count > 0)
                {
                    localsurrogacyhistory = new SurrogacyHistory();
                    localsurrogacyhistory.SurrogacyHistoryID = dataSet.Tables["SurrogacyHistory"].Rows[0]["SURROGACYHISTORYID"].ToString();
                    localsurrogacyhistory.UserID = dataSet.Tables["SurrogacyHistory"].Rows[0]["USERID"].ToString();
                    localsurrogacyhistory.SurrogateBefore = dataSet.Tables["SurrogacyHistory"].Rows[0]["SURROGATEBEFORE"].ToString();
                    localsurrogacyhistory.DetailSurrogate = dataSet.Tables["SurrogacyHistory"].Rows[0]["DETAILSURROGATE"].ToString();
                    localsurrogacyhistory.EggDonate = dataSet.Tables["SurrogacyHistory"].Rows[0]["EGGDONATE"].ToString();
                    localsurrogacyhistory.DetailEggDonate = dataSet.Tables["SurrogacyHistory"].Rows[0]["DETAILEGGDONATE"].ToString();
                    localsurrogacyhistory.IsSubmit = Convert.ToInt32(dataSet.Tables["SurrogacyHistory"].Rows[0]["ISSUBMIT"].ToString());
                }
            }
            catch (SqlException sqlEx)
            {
                localsurrogacyhistory.responseDetail.responseType = ResponseType.Error;
                localsurrogacyhistory.responseDetail.ResponseMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                localsurrogacyhistory.responseDetail.responseType = ResponseType.Error;
                localsurrogacyhistory.responseDetail.ResponseMessage = ApplicationManager.GenericErrorMessage;

                LoggerHelper.WriteToLog(ex);
            }

            return localsurrogacyhistory == null ? new SurrogacyHistory() : localsurrogacyhistory;
        }

        public PregnancyHistory SavePregnancyHistory(PregnancyHistory pregnancyHistory)
        {
            PregnancyHistory localsurrogacyhistory = new PregnancyHistory();
            SurrogateData pregnancyhistorydata = new SurrogateData();
            DataSet dataSet = new DataSet();

            try
            {
                dataSet = pregnancyhistorydata.SavePregnancyHistory(pregnancyHistory);

                if (dataSet.Tables["PregnancyHistory"].Rows.Count > 0)
                {
                    localsurrogacyhistory = new PregnancyHistory();
                    localsurrogacyhistory.PregnancyHistoryID = dataSet.Tables["PregnancyHistory"].Rows[0]["PREGNANCYHISTORYID"].ToString();
                    localsurrogacyhistory.UserID = dataSet.Tables["PregnancyHistory"].Rows[0]["USERID"].ToString();
                    localsurrogacyhistory.NoOfPregnancy = Convert.ToInt16(dataSet.Tables["PregnancyHistory"].Rows[0]["NOOFPREGNANCY"].ToString());
                    localsurrogacyhistory.NoStillBirth = Convert.ToInt16(dataSet.Tables["PregnancyHistory"].Rows[0]["NOSTILLBIRTH"].ToString());
                    localsurrogacyhistory.NoMisCarriage = Convert.ToInt16(dataSet.Tables["PregnancyHistory"].Rows[0]["NOMISCARRIAGE"].ToString());
                    localsurrogacyhistory.NoLiveBirth = Convert.ToInt16(dataSet.Tables["PregnancyHistory"].Rows[0]["NOLIVEBIRTH"].ToString());
                    localsurrogacyhistory.NoAbortion = Convert.ToInt16(dataSet.Tables["PregnancyHistory"].Rows[0]["NOABORTION"].ToString());
                    localsurrogacyhistory.List = dataSet.Tables["PregnancyHistory"].Rows[0]["LIST"].ToString();
                    localsurrogacyhistory.Treatment = dataSet.Tables["PregnancyHistory"].Rows[0]["TREATMENT"].ToString();
                    localsurrogacyhistory.Complication = dataSet.Tables["PregnancyHistory"].Rows[0]["COMPLICATION"].ToString();
                    localsurrogacyhistory.Desc = dataSet.Tables["PregnancyHistory"].Rows[0]["DESC"].ToString();
                    localsurrogacyhistory.ChildDeath = dataSet.Tables["PregnancyHistory"].Rows[0]["CHILDDEATH"].ToString();
                    localsurrogacyhistory.Problem = dataSet.Tables["PregnancyHistory"].Rows[0]["PROBLEM"].ToString();
                    localsurrogacyhistory.IsSubmit = Convert.ToInt32(dataSet.Tables["PregnancyHistory"].Rows[0]["ISSUBMIT"].ToString());
                }
            }
            catch (SqlException sqlEx)
            {
                localsurrogacyhistory.responseDetail.responseType = ResponseType.Error;
                localsurrogacyhistory.responseDetail.ResponseMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                localsurrogacyhistory.responseDetail.responseType = ResponseType.Error;
                localsurrogacyhistory.responseDetail.ResponseMessage = ApplicationManager.GenericErrorMessage;

                LoggerHelper.WriteToLog(ex);
            }

            return localsurrogacyhistory == null ? new PregnancyHistory() : localsurrogacyhistory;
        }

        public MentalHealth SaveMentalHealth(MentalHealth mentalhealth)
        {
            MentalHealth localmentalhealth = new MentalHealth();
            SurrogateData mentalhealthdata = new SurrogateData();
            DataSet dataSet = new DataSet();

            try
            {
                dataSet = mentalhealthdata.SaveMentalHealth(mentalhealth);

                if (dataSet.Tables["MentalHealth"].Rows.Count > 0)
                {
                    localmentalhealth = new MentalHealth();
                    localmentalhealth.MentalHealthID = dataSet.Tables["MentalHealth"].Rows[0]["MENTALHEALTHID"].ToString();
                    localmentalhealth.UserID = dataSet.Tables["MentalHealth"].Rows[0]["USERID"].ToString();
                    localmentalhealth.Depression = Convert.ToInt16(dataSet.Tables["MentalHealth"].Rows[0]["DEPRESSION"].ToString());
                    localmentalhealth.Illness = Convert.ToInt16(dataSet.Tables["MentalHealth"].Rows[0]["ILLNESS"].ToString());
                    localmentalhealth.Suicide = Convert.ToInt16(dataSet.Tables["MentalHealth"].Rows[0]["SUICIDE"].ToString());
                    localmentalhealth.Thoughts = Convert.ToInt16(dataSet.Tables["MentalHealth"].Rows[0]["THOUGHTS"].ToString());
                    localmentalhealth.Professional = Convert.ToInt16(dataSet.Tables["MentalHealth"].Rows[0]["PROFESSIONAL"].ToString());
                    localmentalhealth.Details = dataSet.Tables["MentalHealth"].Rows[0]["DETAILS"].ToString();
                    localmentalhealth.IsSubmit = Convert.ToInt32(dataSet.Tables["MentalHealth"].Rows[0]["ISSUBMIT"].ToString());
                }
            }
            catch (SqlException sqlEx)
            {
                localmentalhealth.responseDetail.responseType = ResponseType.Error;
                localmentalhealth.responseDetail.ResponseMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                localmentalhealth.responseDetail.responseType = ResponseType.Error;
                localmentalhealth.responseDetail.ResponseMessage = ApplicationManager.GenericErrorMessage;

                LoggerHelper.WriteToLog(ex);
            }

            return localmentalhealth == null ? new MentalHealth() : localmentalhealth;
        }
    }
}