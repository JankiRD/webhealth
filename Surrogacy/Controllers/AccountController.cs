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
    
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View("Login", new User());
        }

        public ActionResult UserProfile()
        {
            return View("UserProfile", new User());
        }

        public ActionResult Login()
        {
            if(ApplicationManager.IsUserLoggedIn)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }

            return View("Login", new User());
        }

        [HttpPost]
        public ActionResult Login(User user)
        {            
            UserService userService = new UserService();
            string RedirectToURL = Request.QueryString["ReturnUrl"];
            string validationMessage = string.Empty;

            try 
            {
                if (ValidateLoginForm(user, out validationMessage))
                {
                    user.UserName = SecurityHelper.getEncryptedText(user.UserName.ToLower(), Util.InputType.UserName);
                    user.Password = SecurityHelper.getEncryptedText(user.Password, Util.InputType.Password);
                    user = userService.validateUser(user);

                    if (user.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(),"Unauthorized access. Please try again!","5000");

                        return View("Login", user);
                    }
                    else
                    {
                        ApplicationManager.InitlizeUserSession(user);
                        Session["LoggedInUser"] = user;

                        WebHelper.SetMessageAlertProperties(this, ResponseType.Success.ToString(), "Welcome back,  " + ApplicationManager.UserFullName + "!","5000");
                    }
                }
                else 
                {
                    WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), "Unauthorized access. Please try again!", "5000");

                    return View("Login", user);
                } 
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteToLog(ex);

                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");

                return View("Login", user);
            }

            if (!string.IsNullOrEmpty(RedirectToURL))
            {
                return Redirect(RedirectToURL);
            }

            return RedirectToAction("Dashboard", "Dashboard");
        }

        public ActionResult Logout()
        {
            ApplicationManager.DestroyUserSession();
            Session["LoggedInUser"] = null;

            WebHelper.SetMessageAlertProperties(this, ResponseType.Success.ToString(),"Logout Successfully!","5000");

            return RedirectToAction("Login", "Account");
        }
        
        public ActionResult Register()
        {
            return View("Register", new User());
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            UserService userService = new UserService();
            string validationMessage = string.Empty;

            try
            {
                if (ValidateRegisterForm(user, out validationMessage))
                {
                    user.UserName = SecurityHelper.getEncryptedText(user.UserName.ToLower(), Util.InputType.UserName);
                    user.Password = SecurityHelper.getEncryptedText(user.Password, Util.InputType.Password);
                    user.EntityState = EntityState.Save;

                    user = userService.SaveUser(user);

                    if (user.responseDetail.responseType == ResponseType.Error)
                    {
                        WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), user.responseDetail.ResponseMessage, "5000");                        

                        return View("Register", user);
                    }
                    else
                    {
                        ApplicationManager.InitlizeUserSession(user);
                        Session["LoggedInUser"] = user;

                        WebHelper.SetMessageAlertProperties(this, ResponseType.Success.ToString(), "Welcome,  " + ApplicationManager.UserFullName + "!", "5000");
                    }
                }
                else
                {
                    WebHelper.SetMessageBoxProperties(this, ResponseType.Error, validationMessage);
                    //WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), "Invalid data!", "5000");

                    return View("Register", user);
                }

                return RedirectToAction("Dashboard", "Dashboard");
            }
            catch (Exception ex)
            {
                WebHelper.SetMessageAlertProperties(this, ResponseType.Error.ToString(), ApplicationManager.GenericErrorMessage, "5000");
                LoggerHelper.WriteToLog(ex);
            }

            return View("Register", user);
        }

        private bool ValidateRegisterForm(User user, out string responseMessage) 
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> lsUserFormData = new List<FormData>();

            lsUserFormData.Add(new FormData(FormInputType.Name, user.FirstName, "FIRSTNAME", "First Name", true));
            lsUserFormData.Add(new FormData(FormInputType.Name, user.LastName, "LASTNAME", "Last Name", true));
            lsUserFormData.Add(new FormData(FormInputType.Email, user.Email, "EMAIL", "Email", true));
            lsUserFormData.Add(new FormData(FormInputType.Name, user.UserName, "USERNAME", "User Name", true));
            lsUserFormData.Add(new FormData(FormInputType.Name, user.Password, "PASSWORD", "Password", true));
            lsUserFormData.Add(new FormData(FormInputType.Name, user.ConfirmPassword, "RETYPEPASSWORD", "Retype Password", true, true, user.Password));
            lsUserFormData.Add(new FormData(FormInputType.DropDownListValue, user.UserRole, "USERROLE", "User Role", true));

            boolResponse = FormValidator.validateForm(lsUserFormData, out responseMessage);
            return boolResponse;
        }

        private bool ValidateLoginForm(User user, out string responseMessage)
        {
            bool boolResponse = true;
            responseMessage = "<ul>";

            List<FormData> lsUserFormData = new List<FormData>();
            
            lsUserFormData.Add(new FormData(FormInputType.TextNotEmpty, user.UserName, "USERNAME", "User Name", true));
            lsUserFormData.Add(new FormData(FormInputType.TextNotEmpty, user.Password, "PASSWORD", "Password", true));

            boolResponse = FormValidator.validateForm(lsUserFormData, out responseMessage);
            return boolResponse;
        }
    }
}