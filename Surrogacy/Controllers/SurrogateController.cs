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
using System.IO;

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

            try
            {
                surrogatePersonalInfo.UserID = ApplicationManager.LoggedInUser.UserID;
                surrogatePersonalInfo.EntityState = EntityState.View;

                surrogatePersonalInfo = surrogateService.SaveSurrogatePersonalInfo(surrogatePersonalInfo);
            }
            catch (Exception ex)
            {
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
                    surrogatePersonalInfo.EntityState = surrogatePersonalInfo.SurrogateID != null ? EntityState.Edit : EntityState.Save;
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

        #region LifeStyle
        [CheckSessionOut]
        public ActionResult LifeStyle()
        {
            SurrogateService lifestyleservice = new SurrogateService();
            LifeStyle lifestyle = new LifeStyle();

            try
            {
                lifestyle.UserID = ApplicationManager.LoggedInUser.UserID;
                lifestyle.EntityState = EntityState.View;

                lifestyle = lifestyleservice.SaveLifeStyle(lifestyle);
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("LifeStyle", lifestyle);
        }

        [HttpPost]
        [CheckSessionOut]
        public ActionResult LifeStyle(LifeStyle lifestyle)
        {
            SurrogateService lifestyleservice = new SurrogateService();
            string validationMessage = string.Empty;
            try
            {
                if (ValidateMedicalInfoForm(lifestyle, out validationMessage))
                {
                    lifestyle.EntityState = lifestyle.LifeStyleID != null ? EntityState.Edit : EntityState.Save;
                    lifestyle.ChangeBy = ApplicationManager.LoggedInUser.UserID;
                    lifestyle.UserID = ApplicationManager.LoggedInUser.UserID;

                    lifestyle = lifestyleservice.SaveLifeStyle(lifestyle);

                    if (lifestyle.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), lifestyle.responseDetail.ResponseMessage, "5000");

                        return View("LifeStyle", lifestyle);
                    }
                    else
                    {
                        WebHelper.SetMessageBoxProperties(this, ResponseType.Success);
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);

                    return View("LifeStyle", lifestyle);
                }
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("LifeStyle", lifestyle);
        }

        private bool ValidateMedicalInfoForm(LifeStyle lifestyle, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> IsMedicalHelathFormData = new List<FormData>();

            IsMedicalHelathFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(lifestyle.Smoke), "SMOKE", "Do you smoke? ", true));
            IsMedicalHelathFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(lifestyle.MemberSmoke), "MEMBERSMOKE", "Does any member of your household smoke? ", true));
            IsMedicalHelathFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(lifestyle.Alcohol), "ALCOHOL", "Do you drink more than 3 glasses of alcohol per week?", true));
            IsMedicalHelathFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(lifestyle.Drug), "DRUG", "Do you use illegal or recreational drugs?", true));
            IsMedicalHelathFormData.Add(new FormData(FormInputType.DropDownListValue, Convert.ToString(lifestyle.Past), "PAST", "Have you ever abused or had a problem with alcohol or drugs in the past?", true));

            boolResponse = FormValidator.validateForm(IsMedicalHelathFormData, out responseMessage);
            return boolResponse;
        }

        #endregion LifeStyle       

        #region Documents
        [CheckSessionOut]
        public ActionResult Documents(HttpPostedFileBase file)
        {
            SurrogateService documentsservice = new SurrogateService();
            Documents document = new Documents();

            try
            {
                document.UserID = ApplicationManager.LoggedInUser.UserID;
                document.EntityState = EntityState.View;

                document = documentsservice.SaveDocuments(document);
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("Documents", document);
        }

        [HttpPost]
        [CheckSessionOut]
        public ActionResult Documents(Documents document)
        {
            SurrogateService documentsservice = new SurrogateService();
            string validationMessage = string.Empty;
            try
            {
                if (ValidateMedicalInfoForm(document, out validationMessage))
                {
                    document.EntityState = document.DocumentID != null ? EntityState.Edit : EntityState.Save;
                    document.ChangeBy = ApplicationManager.LoggedInUser.UserID;
                    document.UserID = ApplicationManager.LoggedInUser.UserID;

                    document = documentsservice.SaveDocuments(document);

                    if (document.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), document.responseDetail.ResponseMessage, "5000");

                        return View("Documents", document);
                    }
                    else
                    {
                        WebHelper.SetMessageBoxProperties(this, ResponseType.Success);
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);

                    return View("Documents", document);
                }
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("Documents", document);
        }

        private bool ValidateMedicalInfoForm(Documents document, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> IsMedicalHelathFormData = new List<FormData>();

            IsMedicalHelathFormData.Add(new FormData(FormInputType.File, Convert.ToString(document.IDProof), "IDPROOF", "Picture of Government issued ID card", true));

            boolResponse = FormValidator.validateForm(IsMedicalHelathFormData, out responseMessage);
            return boolResponse;
        }
        #endregion Documents

        #region DocUpoad
        [HttpGet]
        public ActionResult UploadIDProof()
        {
            return View("Upload");
        }

        [HttpPost]
        public ActionResult UploadIDProof(HttpPostedFileBase file)
        {
            try
            {
                UploadFileOnPath(file, CustomFileType.IdProof);
                ViewBag.Message = "File Uploaded Successfully!!";
                return View("Upload");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View("Upload");
            }
        }

        [HttpGet]
        public ActionResult UploadPic()
        {
            return View("Upload");
        }

        [HttpPost]
        public ActionResult UploadPic(HttpPostedFileBase file)
        {
            try
            {
                UploadFileOnPath(file, CustomFileType.Pic);

                ViewBag.Message = "File Uploaded Successfully!!";
                return View("Upload");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View("Upload");
            }
        }

        public ActionResult Upload()
        {
            return View();
        }

        public bool UploadFileOnPath(HttpPostedFileBase file, CustomFileType FileType)
        {
            bool result = false;
            try
            {
                if (file.ContentLength > 0)
                {
                    SurrogateService surrogateService = new SurrogateService();
                    Documents documents = new Documents();

                    string _FileName = Path.GetFileName(file.FileName);
                    string _FileType = string.Empty;
                    string _NewFileName = string.Empty;

                    string _RootPath = Server.MapPath(@"~/UploadedFiles/" + ApplicationManager.LoggedInUser.UserID.ToString());
                    if (!System.IO.File.Exists(_RootPath))
                    {
                        Directory.CreateDirectory(_RootPath);
                    }

                    string _path = Path.Combine(_RootPath, _FileName);
                    file.SaveAs(_path);
                    _FileType = Path.GetExtension(Path.Combine(_RootPath, _FileName));
                    _NewFileName = _FileName + "_" + Path.GetRandomFileName() + _FileType;
                    System.IO.File.Move(Path.Combine(_RootPath, _FileName), Path.Combine(_RootPath, _NewFileName));

                    documents.UserID = ApplicationManager.LoggedInUser.UserID.ToString();
                    documents.IDProof = _NewFileName;
                    documents.UploadPath = _RootPath;
                    documents.EntityState = EntityState.Save;
                    documents.ChangeBy = ApplicationManager.LoggedInUser.UserID.ToString();

                    documents = surrogateService.SaveDocuments(documents);

                    switch (FileType)
                    {
                        case CustomFileType.IdProof:
                            ApplicationManager.UploadedIDProof = _NewFileName;

                            break;
                        case CustomFileType.Pic:
                            ApplicationManager.UploadedPic = _NewFileName;
                            break;
                        case CustomFileType.FamilyPic:
                            ApplicationManager.UploadedFamilyPic = _NewFileName;
                            break;
                    }
                }

                WebHelper.SetMessageAlertProperties(this, ResponseType.Success.ToString(), "Document uploaded Successfully!", "5000");

                WebHelper.SetMessageBoxProperties(this, ResponseType.Success, "Document uploaded Successfully!");

                result = true;
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteToLog(ex);
                result = false;
            }

            return result;
        }
        #endregion DocUplaod       

        #region Doc Download
        public FileResult Download()
        {
            var FileVirtualPath = "~/UploadedFiles/" + ApplicationManager.LoggedInUser.UserID.ToString() + "/" + ApplicationManager.UploadedIDProof;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
        #endregion Doc Download

        #region FinalSubmit
        [CheckSessionOut]
        public ActionResult FinalSubmit()
        {
            SurrogateService finalsubmitservice = new SurrogateService();
            FinalSubmit finalsubmit = new FinalSubmit();

            try
            {
                finalsubmit.UserID = ApplicationManager.LoggedInUser.UserID;
                finalsubmit.EntityState = EntityState.View;

                finalsubmit = finalsubmitservice.SaveFinalSubmit(finalsubmit);
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("FinalSubmit", finalsubmit);
        }

        [HttpPost]
        [CheckSessionOut]
        public ActionResult FinalSubmit(FinalSubmit finalsubmit)
        {
            SurrogateService finalsubmitservice = new SurrogateService();
            string validationMessage = string.Empty;
            try
            {
                if (ValidateMedicalInfoForm(finalsubmit, out validationMessage))
                {
                    finalsubmit.EntityState = finalsubmit.FinalSubmitID != null ? EntityState.Edit : EntityState.Save;
                    finalsubmit.ChangeBy = ApplicationManager.LoggedInUser.UserID;
                    finalsubmit.UserID = ApplicationManager.LoggedInUser.UserID;

                    finalsubmit = finalsubmitservice.SaveFinalSubmit(finalsubmit);

                    if (finalsubmit.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), finalsubmit.responseDetail.ResponseMessage, "5000");

                        return View("FinalSubmit", finalsubmit);
                    }
                    else
                    {
                        WebHelper.SetMessageBoxProperties(this, ResponseType.Success);
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);

                    return View("FinalSubmit", finalsubmit);
                }
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("FinalSubmit", finalsubmit);
        }

        private bool ValidateMedicalInfoForm(FinalSubmit finalsubmit, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> IsMedicalHelathFormData = new List<FormData>();

            IsMedicalHelathFormData.Add(new FormData(FormInputType.None, Convert.ToString(finalsubmit.Agree), "AGREE", "The following box must be selected in order to submit your application ", true));
            IsMedicalHelathFormData.Add(new FormData(FormInputType.TextNotEmpty, Convert.ToString(finalsubmit.SurrogateSignature), "SIGNATURE", "Surrogate Mother Applicant Signature. Type your name into the box below.  ", true));
            IsMedicalHelathFormData.Add(new FormData(FormInputType.Date, Convert.ToString(finalsubmit.SignDate), "DATE", "Date", true));
            
            boolResponse = FormValidator.validateForm(IsMedicalHelathFormData, out responseMessage);
            return boolResponse;
        }

        #endregion LifeStyle       




    }
}