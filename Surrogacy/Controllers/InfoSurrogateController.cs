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
    public class InfoSurrogateController : Controller
    {
        // GET: InfoSurrogate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InfoSurrogate(int SurrogateID)
        {
            InfoSurrogateService infosurrogateservice = new InfoSurrogateService();
            InfoSurrogate infosurrogate = new InfoSurrogate();
            infosurrogate = infosurrogateservice.ViewInfoSurrogate(new InfoSurrogate(),SurrogateID);       
            return View("InfoSurrogateDetail", infosurrogate);
        }

        public ActionResult SaveInfoSurrogate(InfoSurrogate infosurrogate)
        {
            InfoSurrogateService infosurrogateService = new InfoSurrogateService();
            string validationMessage = string.Empty;
            try
            {
                if (ValidatePersonalInfoForm(infosurrogate, out validationMessage))
                {
                    infosurrogate.EntityState = infosurrogate.DoctorApprovalStatusID != null ? EntityState.Edit : EntityState.Save;
                    infosurrogate.ChangeBy = ApplicationManager.LoggedInUser.UserID;
                    infosurrogate.UserID = ApplicationManager.LoggedInUser.UserID;

                    infosurrogate = infosurrogateService.SaveInfoSurrogate(infosurrogate);

                    if (infosurrogate.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), infosurrogate.responseDetail.ResponseMessage, "5000");

                        return View("InfoSurrogate", infosurrogate);
                    }
                    else
                    {
                        WebHelper.SetMessageBoxProperties(this, ResponseType.Success);
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);

                    return View("InfoSurrogate", infosurrogate);
                }
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("InfoSurrogate", infosurrogate);
        }

        private bool ValidatePersonalInfoForm(InfoSurrogate infosurrogate, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> lsinfosurrogate = new List<FormData>();

            lsinfosurrogate.Add(new FormData(FormInputType.Name, infosurrogate.FirstName, "APPROVALSTATUS", "Approval Status", true));
            
            boolResponse = FormValidator.validateForm(lsinfosurrogate, out responseMessage);
            return boolResponse;
        }
    }
}