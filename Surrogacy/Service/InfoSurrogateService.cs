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
    public class InfoSurrogateService
    {
        public InfoSurrogate ViewInfoSurrogate(InfoSurrogate infosurrogate, int SurrogateID)
        {
            InfoSurrogate localinfosurrogate = new InfoSurrogate();
            InfoSurrogateData infosurrogatedata = new InfoSurrogateData();
            DataSet dataSet = new DataSet();
            try
            {
                dataSet = infosurrogatedata.ViewInfoSurrogate(infosurrogate,SurrogateID);

                if (dataSet.Tables["InfoSurrogate"].Rows.Count > 0)
                {

                    localinfosurrogate.SurrogateID = dataSet.Tables["InfoSurrogate"].Rows[0]["SURROGATEID"].ToString();
                    localinfosurrogate.FirstName = dataSet.Tables["InfoSurrogate"].Rows[0]["FIRSTNAME"].ToString();
                    localinfosurrogate.LastName = dataSet.Tables["InfoSurrogate"].Rows[0]["LASTNAME"].ToString();
                    localinfosurrogate.MiddleName = dataSet.Tables["InfoSurrogate"].Rows[0]["MIDDLENAME"].ToString();
                    localinfosurrogate.DOB = dataSet.Tables["InfoSurrogate"].Rows[0]["DOB"].ToString();
                    localinfosurrogate.Age = Convert.ToInt16( dataSet.Tables["InfoSurrogate"].Rows[0]["AGE"].ToString());
                    localinfosurrogate.Citizenship = dataSet.Tables["InfoSurrogate"].Rows[0]["CITIZENSHIP"].ToString();
                    localinfosurrogate.Height = dataSet.Tables["InfoSurrogate"].Rows[0]["HEIGHTFEET"].ToString();
                    localinfosurrogate.Weight = dataSet.Tables["InfoSurrogate"].Rows[0]["WEIGHT"].ToString();
                    localinfosurrogate.MaritalStatus = dataSet.Tables["InfoSurrogate"].Rows[0]["MARITALSTATUS"].ToString();
                    localinfosurrogate.SpouseFullName = dataSet.Tables["InfoSurrogate"].Rows[0]["SPOUSEFULLNAME"].ToString();
                    localinfosurrogate.SpouseDOB = dataSet.Tables["InfoSurrogate"].Rows[0]["SPOUSEDOB"].ToString();
                    localinfosurrogate.NoOfChild = dataSet.Tables["InfoSurrogate"].Rows[0]["NOOFCHILD"].ToString();
                    localinfosurrogate.StepChild = dataSet.Tables["InfoSurrogate"].Rows[0]["STEPCHILD"].ToString();
                    localinfosurrogate.ChildDescription = dataSet.Tables["InfoSurrogate"].Rows[0]["CHILDDESCRIPTION"].ToString();
                    localinfosurrogate.Pregnant = dataSet.Tables["InfoSurrogate"].Rows[0]["PREGNANT"].ToString();
                    localinfosurrogate.Adopted = dataSet.Tables["InfoSurrogate"].Rows[0]["ADOPTED"].ToString();
                    localinfosurrogate.Residence = dataSet.Tables["InfoSurrogate"].Rows[0]["RESIDENCE"].ToString();
                    localinfosurrogate.EthnicBackGround = dataSet.Tables["InfoSurrogate"].Rows[0]["ETHNICBACKGROUND"].ToString();
                    localinfosurrogate.SurrogateBefore = dataSet.Tables["InfoSurrogate"].Rows[0]["SURROGATEBEFORE"].ToString();
                    localinfosurrogate.EggDonate = dataSet.Tables["InfoSurrogate"].Rows[0]["EGGDONATE"].ToString();
                    localinfosurrogate.DetailEggDonate = dataSet.Tables["InfoSurrogate"].Rows[0]["DETAILEGGDONATE"].ToString();
                    localinfosurrogate.Ablation = dataSet.Tables["InfoSurrogate"].Rows[0]["ABLATION"].ToString();
                    localinfosurrogate.WeightLoss = dataSet.Tables["InfoSurrogate"].Rows[0]["WEIGHLOSS"].ToString();
                    localinfosurrogate.Medical = dataSet.Tables["InfoSurrogate"].Rows[0]["MEDICAL"].ToString();
                    localinfosurrogate.MedicalDetail = dataSet.Tables["InfoSurrogate"].Rows[0]["MEDICALDETAIL"].ToString();
                    localinfosurrogate.Medication = dataSet.Tables["InfoSurrogate"].Rows[0]["MEDICATION"].ToString();
                    localinfosurrogate.MedicationDetail = dataSet.Tables["InfoSurrogate"].Rows[0]["MEDICATIONDETAIL"].ToString();
                    localinfosurrogate.BreastFeeding = dataSet.Tables["InfoSurrogate"].Rows[0]["BREASTFEEDING"].ToString();
                    localinfosurrogate.Periods = dataSet.Tables["InfoSurrogate"].Rows[0]["PERIODS"].ToString();
                    localinfosurrogate.NoOfPregnancy = dataSet.Tables["InfoSurrogate"].Rows[0]["NOOFPREGNANCY"].ToString();
                    localinfosurrogate.NoStillBirth = dataSet.Tables["InfoSurrogate"].Rows[0]["NOSTILLBIRTH"].ToString();
                    localinfosurrogate.NoMisCarriage = dataSet.Tables["InfoSurrogate"].Rows[0]["NOMISCARRIAGE"].ToString();
                    localinfosurrogate.NoLiveBirth = dataSet.Tables["InfoSurrogate"].Rows[0]["NOLIVEBIRTH"].ToString();
                    localinfosurrogate.NoAbortion = dataSet.Tables["InfoSurrogate"].Rows[0]["NOABORTION"].ToString();
                    localinfosurrogate.List = dataSet.Tables["InfoSurrogate"].Rows[0]["LIST"].ToString();
                    localinfosurrogate.Treatment = dataSet.Tables["InfoSurrogate"].Rows[0]["TREATMENT"].ToString();
                    localinfosurrogate.Complication = dataSet.Tables["InfoSurrogate"].Rows[0]["COMPLICATION"].ToString();
                    localinfosurrogate.ChildDeath = dataSet.Tables["InfoSurrogate"].Rows[0]["CHILDDEATH"].ToString();
                    localinfosurrogate.Problem = dataSet.Tables["InfoSurrogate"].Rows[0]["PROBLEM"].ToString();
                    localinfosurrogate.Depression = dataSet.Tables["InfoSurrogate"].Rows[0]["DEPRESSION"].ToString();
                    localinfosurrogate.Illness = dataSet.Tables["InfoSurrogate"].Rows[0]["ILLNESS"].ToString();
                    localinfosurrogate.Suicide = dataSet.Tables["InfoSurrogate"].Rows[0]["SUICIDE"].ToString();
                    localinfosurrogate.Thoughts = dataSet.Tables["InfoSurrogate"].Rows[0]["THOUGHTS"].ToString();
                    localinfosurrogate.Professional = dataSet.Tables["InfoSurrogate"].Rows[0]["PROFESSIONAL"].ToString();
                    localinfosurrogate.Details = dataSet.Tables["InfoSurrogate"].Rows[0]["DETAILS"].ToString();
                    localinfosurrogate.Smoke = dataSet.Tables["InfoSurrogate"].Rows[0]["SMOKE"].ToString();
                    localinfosurrogate.MemberSmoke = dataSet.Tables["InfoSurrogate"].Rows[0]["MEMBERSMOKE"].ToString();
                    localinfosurrogate.Alcohol = dataSet.Tables["InfoSurrogate"].Rows[0]["ALCOHOL"].ToString();
                    localinfosurrogate.Drug = dataSet.Tables["InfoSurrogate"].Rows[0]["DRUG"].ToString();
                    localinfosurrogate.Past = dataSet.Tables["InfoSurrogate"].Rows[0]["PAST"].ToString();
                    localinfosurrogate.SpouseDrug = dataSet.Tables["InfoSurrogate"].Rows[0]["SPOUSEDRUG"].ToString();
                    localinfosurrogate.ApprovalStatus = dataSet.Tables["InfoSurrogate"].Rows[0]["APPROVALSTATUS"].ToString();
                    localinfosurrogate.DoctorApprovalStatusID = dataSet.Tables["InfoSurrogate"].Rows[0]["DOCTORAPPROVALSTATUSID"].ToString();
                }
            }
            catch (SqlException sqlEx)
            {
                localinfosurrogate.responseDetail.responseType = ResponseType.Error;
                localinfosurrogate.responseDetail.ResponseMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                localinfosurrogate.responseDetail.responseType = ResponseType.Error;
                localinfosurrogate.responseDetail.ResponseMessage = ApplicationManager.GenericErrorMessage;

                LoggerHelper.WriteToLog(ex);
            }

            return localinfosurrogate == null ? new InfoSurrogate() : localinfosurrogate;
        }

        public InfoSurrogate SaveInfoSurrogate(InfoSurrogate infosurrogate)
        {
            InfoSurrogate localinfosurrogate = new InfoSurrogate();
            InfoSurrogateData infosurrogatedata = new InfoSurrogateData();
            DataSet dataSet = new DataSet();
            try
            {
                dataSet = infosurrogatedata.SaveInfoSurrogate(infosurrogate);

                if (dataSet.Tables["InfoSurrogate"].Rows.Count > 0)
                {

                    localinfosurrogate.SurrogateID = dataSet.Tables["InfoSurrogate"].Rows[0]["SURROGATEID"].ToString();
                    localinfosurrogate.FirstName = dataSet.Tables["InfoSurrogate"].Rows[0]["FIRSTNAME"].ToString();
                    localinfosurrogate.LastName = dataSet.Tables["InfoSurrogate"].Rows[0]["LASTNAME"].ToString();
                    localinfosurrogate.MiddleName = dataSet.Tables["InfoSurrogate"].Rows[0]["MIDDLENAME"].ToString();
                    localinfosurrogate.DOB = dataSet.Tables["InfoSurrogate"].Rows[0]["DOB"].ToString();
                    localinfosurrogate.Age = Convert.ToInt16(dataSet.Tables["InfoSurrogate"].Rows[0]["AGE"].ToString());
                    localinfosurrogate.Citizenship = dataSet.Tables["InfoSurrogate"].Rows[0]["CITIZENSHIP"].ToString();
                    localinfosurrogate.Height = dataSet.Tables["InfoSurrogate"].Rows[0]["HEIGHTFEET"].ToString();
                    localinfosurrogate.Weight = dataSet.Tables["InfoSurrogate"].Rows[0]["WEIGHT"].ToString();
                    localinfosurrogate.MaritalStatus = dataSet.Tables["InfoSurrogate"].Rows[0]["MARITALSTATUS"].ToString();
                    localinfosurrogate.SpouseFullName = dataSet.Tables["InfoSurrogate"].Rows[0]["SPOUSEFULLNAME"].ToString();
                    localinfosurrogate.SpouseDOB = dataSet.Tables["InfoSurrogate"].Rows[0]["SPOUSEDOB"].ToString();
                    localinfosurrogate.NoOfChild = dataSet.Tables["InfoSurrogate"].Rows[0]["NOOFCHILD"].ToString();
                    localinfosurrogate.StepChild = dataSet.Tables["InfoSurrogate"].Rows[0]["STEPCHILD"].ToString();
                    localinfosurrogate.ChildDescription = dataSet.Tables["InfoSurrogate"].Rows[0]["CHILDDESCRIPTION"].ToString();
                    localinfosurrogate.Pregnant = dataSet.Tables["InfoSurrogate"].Rows[0]["PREGNANT"].ToString();
                    localinfosurrogate.Adopted = dataSet.Tables["InfoSurrogate"].Rows[0]["ADOPTED"].ToString();
                    localinfosurrogate.Residence = dataSet.Tables["InfoSurrogate"].Rows[0]["RESIDENCE"].ToString();
                    localinfosurrogate.EthnicBackGround = dataSet.Tables["InfoSurrogate"].Rows[0]["ETHNICBACKGROUND"].ToString();
                    localinfosurrogate.SurrogateBefore = dataSet.Tables["InfoSurrogate"].Rows[0]["SURROGATEBEFORE"].ToString();
                    localinfosurrogate.EggDonate = dataSet.Tables["InfoSurrogate"].Rows[0]["EGGDONATE"].ToString();
                    localinfosurrogate.DetailEggDonate = dataSet.Tables["InfoSurrogate"].Rows[0]["DETAILEGGDONATE"].ToString();
                    localinfosurrogate.Ablation = dataSet.Tables["InfoSurrogate"].Rows[0]["ABLATION"].ToString();
                    localinfosurrogate.WeightLoss = dataSet.Tables["InfoSurrogate"].Rows[0]["WEIGHLOSS"].ToString();
                    localinfosurrogate.Medical = dataSet.Tables["InfoSurrogate"].Rows[0]["MEDICAL"].ToString();
                    localinfosurrogate.MedicalDetail = dataSet.Tables["InfoSurrogate"].Rows[0]["MEDICALDETAIL"].ToString();
                    localinfosurrogate.Medication = dataSet.Tables["InfoSurrogate"].Rows[0]["MEDICATION"].ToString();
                    localinfosurrogate.MedicationDetail = dataSet.Tables["InfoSurrogate"].Rows[0]["MEDICATIONDETAIL"].ToString();
                    localinfosurrogate.BreastFeeding = dataSet.Tables["InfoSurrogate"].Rows[0]["BREASTFEEDING"].ToString();
                    localinfosurrogate.Periods = dataSet.Tables["InfoSurrogate"].Rows[0]["PERIODS"].ToString();
                    localinfosurrogate.NoOfPregnancy = dataSet.Tables["InfoSurrogate"].Rows[0]["NOOFPREGNANCY"].ToString();
                    localinfosurrogate.NoStillBirth = dataSet.Tables["InfoSurrogate"].Rows[0]["NOSTILLBIRTH"].ToString();
                    localinfosurrogate.NoMisCarriage = dataSet.Tables["InfoSurrogate"].Rows[0]["NOMISCARRIAGE"].ToString();
                    localinfosurrogate.NoLiveBirth = dataSet.Tables["InfoSurrogate"].Rows[0]["NOLIVEBIRTH"].ToString();
                    localinfosurrogate.NoAbortion = dataSet.Tables["InfoSurrogate"].Rows[0]["NOABORTION"].ToString();
                    localinfosurrogate.List = dataSet.Tables["InfoSurrogate"].Rows[0]["LIST"].ToString();
                    localinfosurrogate.Treatment = dataSet.Tables["InfoSurrogate"].Rows[0]["TREATMENT"].ToString();
                    localinfosurrogate.Complication = dataSet.Tables["InfoSurrogate"].Rows[0]["COMPLICATION"].ToString();
                    localinfosurrogate.ChildDeath = dataSet.Tables["InfoSurrogate"].Rows[0]["CHILDDEATH"].ToString();
                    localinfosurrogate.Problem = dataSet.Tables["InfoSurrogate"].Rows[0]["PROBLEM"].ToString();
                    localinfosurrogate.Depression = dataSet.Tables["InfoSurrogate"].Rows[0]["DEPRESSION"].ToString();
                    localinfosurrogate.Illness = dataSet.Tables["InfoSurrogate"].Rows[0]["ILLNESS"].ToString();
                    localinfosurrogate.Suicide = dataSet.Tables["InfoSurrogate"].Rows[0]["SUICIDE"].ToString();
                    localinfosurrogate.Thoughts = dataSet.Tables["InfoSurrogate"].Rows[0]["THOUGHTS"].ToString();
                    localinfosurrogate.Professional = dataSet.Tables["InfoSurrogate"].Rows[0]["PROFESSIONAL"].ToString();
                    localinfosurrogate.Details = dataSet.Tables["InfoSurrogate"].Rows[0]["DETAILS"].ToString();
                    localinfosurrogate.Smoke = dataSet.Tables["InfoSurrogate"].Rows[0]["SMOKE"].ToString();
                    localinfosurrogate.MemberSmoke = dataSet.Tables["InfoSurrogate"].Rows[0]["MEMBERSMOKE"].ToString();
                    localinfosurrogate.Alcohol = dataSet.Tables["InfoSurrogate"].Rows[0]["ALCOHOL"].ToString();
                    localinfosurrogate.Drug = dataSet.Tables["InfoSurrogate"].Rows[0]["DRUG"].ToString();
                    localinfosurrogate.Past = dataSet.Tables["InfoSurrogate"].Rows[0]["PAST"].ToString();
                    localinfosurrogate.SpouseDrug = dataSet.Tables["InfoSurrogate"].Rows[0]["SPOUSEDRUG"].ToString();
                    localinfosurrogate.ApprovalStatus = dataSet.Tables["InfoSurrogate"].Rows[0]["APPROVALSTATUS"].ToString();
                    localinfosurrogate.DoctorApprovalStatusID = dataSet.Tables["InfoSurrogate"].Rows[0]["DOCTORAPPROVALSTATUSID"].ToString();
                }
            }
            catch (SqlException sqlEx)
            {
                localinfosurrogate.responseDetail.responseType = ResponseType.Error;
                localinfosurrogate.responseDetail.ResponseMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                localinfosurrogate.responseDetail.responseType = ResponseType.Error;
                localinfosurrogate.responseDetail.ResponseMessage = ApplicationManager.GenericErrorMessage;

                LoggerHelper.WriteToLog(ex);
            }

            return localinfosurrogate == null ? new InfoSurrogate() : localinfosurrogate;
        }
    }
}