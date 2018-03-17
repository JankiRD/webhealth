using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Surrogacy.Entity;
using Surrogacy.Helper;
using Surrogacy.Models;
using Surrogacy.Service;
using Surrogacy.Util;
using static Surrogacy.Entity.FormData;
using static Surrogacy.MvcApplication;

namespace Surrogacy.Controllers
{
    public class SurrogateController : Controller
    {
        // GET: Surrogate
        [CheckSessionOut]
        public ActionResult Index()
        {
            return View();
        }

        #region PerdonalInfo
        [CheckSessionOut]
        public ActionResult PersonalInfo()
        {
            SurrogateService surrogateService = new SurrogateService();
            SurrogatePersonalInfo surrogatePersonalInfo = new SurrogatePersonalInfo();

            try {
                surrogatePersonalInfo.UserID = ApplicationManager.LoggedInUser.UserID;
                surrogatePersonalInfo.EntityState = EntityState.View;

                surrogatePersonalInfo = surrogateService.SaveSurrogatePersonalInfo(surrogatePersonalInfo);
            }
            catch(Exception ex) {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("PersonalInfo", surrogatePersonalInfo);
        }

        [HttpPost]
        [CheckSessionOut]
        public ActionResult PersonalInfo(SurrogatePersonalInfo surrogatePersonalInfo)
        {
            SurrogateService surrogateService = new SurrogateService();
            string validationMessage = string.Empty;
            try
            {
                if (ValidatePersonalInfoForm(surrogatePersonalInfo, out validationMessage))
                {
                    surrogatePersonalInfo.EntityState = surrogatePersonalInfo.SurrogateID != null ?  EntityState.Edit : EntityState.Save;
                    surrogatePersonalInfo.ChangeBy = ApplicationManager.LoggedInUser.UserID;
                    surrogatePersonalInfo.UserID = ApplicationManager.LoggedInUser.UserID;

                    surrogatePersonalInfo = surrogateService.SaveSurrogatePersonalInfo(surrogatePersonalInfo);

                    if (surrogatePersonalInfo.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), surrogatePersonalInfo.responseDetail.ResponseMessage, "5000");

                        return View("PersonalInfo", surrogatePersonalInfo);
                    }
                    else
                    {
                        WebHelper.SetMessageBoxProperties(this, ResponseType.Success);
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);

                    return View("PersonalInfo", surrogatePersonalInfo);
                }
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("PersonalInfo", surrogatePersonalInfo);
        }

        private bool ValidatePersonalInfoForm(SurrogatePersonalInfo surrogatePersonalInfo, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> lsSurrogatePersonalInfoFormData = new List<FormData>();

            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.Name, surrogatePersonalInfo.FirstName, "FIRSTNAME", "First Name", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.Name, surrogatePersonalInfo.LastName, "LASTNAME", "Last Name", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.Name, surrogatePersonalInfo.MiddleName, "MIDDLENAME", "Middle Name", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.Date, surrogatePersonalInfo.DOB, "DOB", "DOB", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.Age, surrogatePersonalInfo.Age.ToString(), "AGE", "Age", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.Name, surrogatePersonalInfo.Citizenship, "CITIZENSHIP", "Citizen ship", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.Height, surrogatePersonalInfo.Height, "HEIGHT", "Height", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.Weight, surrogatePersonalInfo.Weight, "WEIGHT", "Weight", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.DropDownListValue, surrogatePersonalInfo.MaritalStatus, "MARITALSTATUS", "Marital Status", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.NumericOrZero, surrogatePersonalInfo.NoOfChild, "NOOFCHILD", "No of Child", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.DropDownListValue, surrogatePersonalInfo.StepChild, "STEPCHILD", "Step Child", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.DropDownListValue, surrogatePersonalInfo.Pregnant, "PREGNANT", "Pregnant", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.DropDownListValue, surrogatePersonalInfo.Adopted, "ADOPTED", "Adopted", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.DropDownListValue, surrogatePersonalInfo.Residence, "RESIDENCE", "Residence", true));
            lsSurrogatePersonalInfoFormData.Add(new FormData(FormInputType.TextNotEmpty, surrogatePersonalInfo.EthnicBackGround, "ETHNICBACKGROUND", "Ethnic Background", true));

            boolResponse = FormValidator.validateForm(lsSurrogatePersonalInfoFormData, out responseMessage);
            return boolResponse;
        }

        #endregion PerdonalInfo

        #region MedicalInfo

        [CheckSessionOut]
        public ActionResult MedicalInfo()
        {
            SurrogateService medicalInfoService = new SurrogateService();
            MedicalInfo medicalInfo = new MedicalInfo();

            try
            {
                medicalInfo.UserID = ApplicationManager.LoggedInUser.UserID;
                medicalInfo.EntityState = EntityState.View;

                medicalInfo = medicalInfoService.SaveMedicalInfo(medicalInfo);
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("MedicalInfo", medicalInfo);
        }

        [HttpPost]
        [CheckSessionOut]
        public ActionResult MedicalInfo(MedicalInfo medicalInfo)
        {
            SurrogateService medicalInfoService = new SurrogateService();
            string validationMessage = string.Empty;
            try
            {
                if (ValidateMedicalInfoForm(medicalInfo, out validationMessage))
                {
                    medicalInfo.EntityState = medicalInfo.UserID != null ? EntityState.Edit : EntityState.Save;
                    medicalInfo.ChangeBy = ApplicationManager.LoggedInUser.UserID;
                    medicalInfo.UserID = ApplicationManager.LoggedInUser.UserID;

                    medicalInfo = medicalInfoService.SaveMedicalInfo(medicalInfo);

                    if (medicalInfo.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), medicalInfo.responseDetail.ResponseMessage, "5000");

                        return View("MedicalInfo", medicalInfo);
                    }
                    else
                    {
                        WebHelper.SetMessageBoxProperties(this, ResponseType.Success);
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);                    

                    return View("MedicalInfo", medicalInfo);
                }
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("MedicalInfo", medicalInfo);
        }

        private bool ValidateMedicalInfoForm(MedicalInfo medicalInfo, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> lsMedicalInfoData = new List<FormData>();

            lsMedicalInfoData.Add(new FormData(FormInputType.DropDownListValue, medicalInfo.Ablation, "ABLATION", "Ablation", true));
            lsMedicalInfoData.Add(new FormData(FormInputType.DropDownListValue, medicalInfo.WeightLoss, "WEIGHTLOSS", "WeightLoss", true));
            lsMedicalInfoData.Add(new FormData(FormInputType.DropDownListValue, medicalInfo.Medical, "MEDICAL", "Medical", true));
            lsMedicalInfoData.Add(new FormData(FormInputType.NameWithSpace, medicalInfo.MedicalDetail, "MEDICALDETAIL", "Medical Detail", false));
            lsMedicalInfoData.Add(new FormData(FormInputType.DropDownListValue, medicalInfo.Medication, "MEDICATION", "Medication", true));
            lsMedicalInfoData.Add(new FormData(FormInputType.NameWithSpace, medicalInfo.MedicationDetail, "MEDICATIONDETAIL", "Medication Detail", false));
            lsMedicalInfoData.Add(new FormData(FormInputType.DropDownListValue, medicalInfo.BreastFeeding, "BREASTFEEDING", "Breast Feeding", true));
            lsMedicalInfoData.Add(new FormData(FormInputType.DropDownListValue, medicalInfo.Periods, "PERIODS", "Periods", true));

            boolResponse = FormValidator.validateForm(lsMedicalInfoData, out responseMessage);
            return boolResponse;
        }

        #endregion MedicalInfo

        #region HistoryInfo
        [CheckSessionOut]
        public ActionResult HistoryInfo()
        {
            SurrogateService surrogatehistoryService = new SurrogateService();
            SurrogacyHistory surrogacyhistory = new SurrogacyHistory();

            try
            {
                surrogacyhistory.UserID = ApplicationManager.LoggedInUser.UserID;
                surrogacyhistory.EntityState = EntityState.View;

                surrogacyhistory = surrogatehistoryService.SaveSurrogacyHistory(surrogacyhistory);
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("HistoryInfo", surrogacyhistory);
        }

        [HttpPost]
        [CheckSessionOut]
        public ActionResult HistoryInfo(SurrogacyHistory surrogacyhistory)
        {
            SurrogateService surrogateService = new SurrogateService();
            string validationMessage = string.Empty;
            try
            {
                if (ValidateHistoryInfoForm(surrogacyhistory, out validationMessage))
                {
                    surrogacyhistory.EntityState = surrogacyhistory.SurrogacyHistoryID != null ? EntityState.Edit : EntityState.Save;
                    surrogacyhistory.ChangeBy = ApplicationManager.LoggedInUser.UserID;
                    surrogacyhistory.UserID = ApplicationManager.LoggedInUser.UserID;

                    surrogacyhistory = surrogateService.SaveSurrogacyHistory(surrogacyhistory);

                    if (surrogacyhistory.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), surrogacyhistory.responseDetail.ResponseMessage, "5000");

                        return View("HistoryInfo", surrogacyhistory);
                    }
                    else
                    {
                        WebHelper.SetMessageBoxProperties(this, ResponseType.Success);
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);                    

                    return View("HistoryInfo", surrogacyhistory);
                }
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("HistoryInfo", surrogacyhistory);
        }

        private bool ValidateHistoryInfoForm(SurrogacyHistory surrogatePersonalInfo, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> lsSurrogacyHistoryFormData = new List<FormData>();

            lsSurrogacyHistoryFormData.Add(new FormData(FormInputType.DropDownListValue, surrogatePersonalInfo.SurrogateBefore, "SURROGATEBEFORE", "Surrogate Before", true));
            lsSurrogacyHistoryFormData.Add(new FormData(FormInputType.DropDownListValue, surrogatePersonalInfo.EggDonate, "EGGDONATE", "Egg Donate", true));

            boolResponse = FormValidator.validateForm(lsSurrogacyHistoryFormData, out responseMessage);
            return boolResponse;
        }

        #endregion HistoryInfo

        #region PregnancyHistory
        [CheckSessionOut]
        public ActionResult PregnancyHistory()
        {
            SurrogateService pregnancyhistoryService = new SurrogateService();
            PregnancyHistory pregnancyhistory = new PregnancyHistory();

            try
            {
                pregnancyhistory.UserID = ApplicationManager.LoggedInUser.UserID;
                pregnancyhistory.EntityState = EntityState.View;

                pregnancyhistory = pregnancyhistoryService.SavePregnancyHistory(pregnancyhistory);
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("PregnancyHistory", pregnancyhistory);
        }

        [HttpPost]
        [CheckSessionOut]
        public ActionResult PregnancyHistory(PregnancyHistory pregnancyhistory)
        {
            SurrogateService pregnancyService = new SurrogateService();
            string validationMessage = string.Empty;
            try
            {
                if (ValidatePregnancyHistoryInfoForm(pregnancyhistory, out validationMessage))
                {
                    pregnancyhistory.EntityState = pregnancyhistory.PregnancyHistoryID != null ? EntityState.Edit : EntityState.Save;
                    pregnancyhistory.ChangeBy = ApplicationManager.LoggedInUser.UserID;
                    pregnancyhistory.UserID = ApplicationManager.LoggedInUser.UserID;

                    pregnancyhistory = pregnancyService.SavePregnancyHistory(pregnancyhistory);

                    if (pregnancyhistory.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), pregnancyhistory.responseDetail.ResponseMessage, "5000");

                        return View("PregnancyHistory", pregnancyhistory);
                    }
                    else
                    {
                        WebHelper.SetMessageBoxProperties(this, ResponseType.Success);
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);                    

                    return View("PregnancyHistory", pregnancyhistory);
                }
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("PregnancyHistory", pregnancyhistory);
        }

        private bool ValidatePregnancyHistoryInfoForm(PregnancyHistory pregnancyhistory, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> IspregnancyhistoryFormData = new List<FormData>();

            IspregnancyhistoryFormData.Add(new FormData(FormInputType.NumericOrZero, Convert.ToString(pregnancyhistory.NoOfPregnancy), "NOOFPREGNANCY", "No Of Pregnancy", true));
            IspregnancyhistoryFormData.Add(new FormData(FormInputType.NumericOrZero, Convert.ToString(pregnancyhistory.NoStillBirth), "NOSTILLBIRTH", "No Of Still Birth", true));
            IspregnancyhistoryFormData.Add(new FormData(FormInputType.NumericOrZero, Convert.ToString(pregnancyhistory.NoMisCarriage), "NOMISCARRIAGE", "No Of Miscarriage", true));
            IspregnancyhistoryFormData.Add(new FormData(FormInputType.NumericOrZero, Convert.ToString(pregnancyhistory.NoLiveBirth), "NOLIVEBIRTH", "No Of Live Birth", true));
            IspregnancyhistoryFormData.Add(new FormData(FormInputType.NumericOrZero, Convert.ToString(pregnancyhistory.NoAbortion), "NOABORTION", "No Of Abortion", true));
            IspregnancyhistoryFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(pregnancyhistory.Treatment), "TREATMENT", "Have you ever received fertility treatment in an effort to become pregnant?", true));
            IspregnancyhistoryFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(pregnancyhistory.Complication), "COMPLICATION", "Did you have any severe complications with any of your pregnancies or births?", true));

            boolResponse = FormValidator.validateForm(IspregnancyhistoryFormData, out responseMessage);
            return boolResponse;
        }

        #endregion PregnancyHistory        

        #region MentalHealth
        [CheckSessionOut]
        public ActionResult MentalHealth()
        {
            SurrogateService mentalhealthservice = new SurrogateService();
            MentalHealth mentalhealth = new MentalHealth();

            try
            {
                mentalhealth.UserID = ApplicationManager.LoggedInUser.UserID;
                mentalhealth.EntityState = EntityState.View;

                mentalhealth = mentalhealthservice.SaveMentalHealth(mentalhealth);
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("MentalHealth", mentalhealth);
        }

        [HttpPost]
        [CheckSessionOut]
        public ActionResult MentalHealth(MentalHealth mentalhealth)
        {
            SurrogateService mentalhealthservice = new SurrogateService();
            string validationMessage = string.Empty;
            try
            {
                if (ValidateMedicalInfoForm(mentalhealth, out validationMessage))
                {
                    mentalhealth.EntityState = mentalhealth.MentalHealthID != null ? EntityState.Edit : EntityState.Save;
                    mentalhealth.ChangeBy = ApplicationManager.LoggedInUser.UserID;
                    mentalhealth.UserID = ApplicationManager.LoggedInUser.UserID;

                    mentalhealth = mentalhealthservice.SaveMentalHealth(mentalhealth);

                    if (mentalhealth.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), mentalhealth.responseDetail.ResponseMessage, "5000");

                        return View("MentalHealth", mentalhealth);
                    }
                    else
                    {
                        WebHelper.SetMessageBoxProperties(this, ResponseType.Success);
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);

                    return View("MentalHealth", mentalhealth);
                }
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("MentalHealth", mentalhealth);
        }

        private bool ValidateMedicalInfoForm(MentalHealth medicalhealth, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> IsMedicalHelathFormData = new List<FormData>();

            IsMedicalHelathFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(medicalhealth.Depression), "DEPRESSION", "Have you ever experienced post partum depression? ", true));
            IsMedicalHelathFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(medicalhealth.Illness), "ILLNESS", "Have you ever been diagnosed with an emotional condition or illness?", true));
            IsMedicalHelathFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(medicalhealth.Suicide), "SUICIDE", "Have you ever attempted suicide?", true));
            IsMedicalHelathFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(medicalhealth.Thoughts), "THOUGHTS", "Have you ever had suicidal thoughts?", true));
            IsMedicalHelathFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(medicalhealth.Professional), "PROFESSIONAL", "Have you ever been treated by a mental health professional?", true));
            
            boolResponse = FormValidator.validateForm(IsMedicalHelathFormData, out responseMessage);
            return boolResponse;
        }

        #endregion MentalHealth        

    }
}