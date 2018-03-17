using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using Surrogacy.Entity;
using Surrogacy.Util;

namespace Surrogacy.Helper
{
    public static class WebHelper
    {
        //// To initialize Application settings
        //public static void InitializeApplicationSetting()
        //{
        //    Utility.Util.IsSessionStarted = true;
        //    Utility.Util.ApplicationName = getApplicationSetting("ApplicationName");
        //    Utility.Util.ApplicationLogoPath = getApplicationSetting("ApplicationLogoPath");
        //    Utility.Util.ApplicationFaviconPath = getApplicationSetting("ApplicationFaviconPath");
        //    Utility.Util.ApplicationWebLink = getApplicationSetting("ApplicationWebLink");
        //}

        //To read value from web configuration file
        public static string getApplicationSetting(string key)
        {
            string value = string.Empty;

            value = WebConfigurationManager.AppSettings[key] != null ? WebConfigurationManager.AppSettings[key] : string.Empty;

            return value;
        }

        public static string UrlEncode(string url, Surrogacy.Util.InputType inputType = Surrogacy.Util.InputType.Text)
        {
            return HttpUtility.UrlEncode(SecurityHelper.getEncryptedText(url.Replace(' ', '+'), inputType));            
        }

        public static string UrlDecode(string url, Surrogacy.Util.InputType inputType = Surrogacy.Util.InputType.Text)
        {
            return SecurityHelper.getDecryptedText(HttpUtility.UrlDecode(url).Replace(' ', '+'), inputType);            
        }

        public static string GetPageFullUrl(HttpRequest request)
        {
            string url = string.Empty;
            if (!string.IsNullOrEmpty(request.Url.Query.ToString()))
            {
                url = request.Url.AbsoluteUri.Replace(request.Url.Query, String.Empty);
            }
            else
            {
                url = request.Url.AbsoluteUri;
            }
            return url;

        }

        public static string GetPagePath(HttpRequest request)
        {
            string url = string.Empty;
            if (!string.IsNullOrEmpty(request.Url.Query.ToString()))
            {
                url = request.Url.AbsoluteUri.Replace(request.Url.Query, String.Empty).Replace(Path.GetFileName(request.Url.AbsolutePath), string.Empty);
            }
            else
            {
                url = request.Url.AbsoluteUri.Replace(Path.GetFileName(request.Url.AbsolutePath), string.Empty);
            }
            return url;

        }

        public static T getDropDownList<T>(string filterCategory, DropDownControlType ddlControlType, string filterValue = null, string parentFilterCategory = null, string parentFilterValue = null, bool getFromCache = false)
        {
            SystemDropDown systemDropDown = new SystemDropDown();
            filterCategory = filterCategory.ToUpper();
            parentFilterCategory = !string.IsNullOrEmpty(parentFilterCategory) ? parentFilterCategory.ToUpper() : "";

            if (!getFromCache)
            {
                systemDropDown.Category = filterCategory;
                systemDropDown.Value = filterValue;
                systemDropDown.ParentCategory = parentFilterCategory;
                systemDropDown.ParentValue = parentFilterValue;
            }

            switch (ddlControlType)
            {
                case DropDownControlType.Html:
                    return getFromCache
                           ? (T)Convert.ChangeType(getHtmlDropDown(filterCategory, filterValue, parentFilterCategory, parentFilterValue), typeof(T))
                           : (T)Convert.ChangeType(getHtmlDropDown(filterCategory, filterValue, parentFilterCategory, parentFilterValue, systemDropDown), typeof(T));

                case DropDownControlType.Asp:
                    return getFromCache
                           ? (T)Convert.ChangeType(getHtmlDropDown(filterCategory, filterValue, parentFilterCategory, parentFilterValue), typeof(T))
                           : (T)Convert.ChangeType(getHtmlDropDown(filterCategory, filterValue, parentFilterCategory, parentFilterValue, systemDropDown), typeof(T));                
            }


            return (T)Convert.ChangeType(new Object(), typeof(T));
        }

        private static HtmlSelect getHtmlDropDown(string filterCategory, string filterValue, string parentFilterCategory, string parentFilterValue)
        {
            HtmlSelect htmlSelect = new HtmlSelect();
            List<SystemDropDown> lsSystemDropDown = new List<SystemDropDown>();

            lsSystemDropDown = ApplicationManager.SystemDropDownList;

            bool isDataAvailable = lsSystemDropDown.Where(ddl => ddl.Category == filterCategory
                                                         && (ddl.Value == filterValue || string.IsNullOrEmpty(filterValue))
                                                         && (ddl.ParentCategory == parentFilterCategory || string.IsNullOrEmpty(parentFilterCategory))
                                                         && (ddl.ParentValue == parentFilterValue || string.IsNullOrEmpty(parentFilterValue))
                                   ).Count() > 0;

            if (isDataAvailable)
            {
                lsSystemDropDown = lsSystemDropDown.Where(ddl => ddl.Category == filterCategory
                                                         && (ddl.Value == filterValue || string.IsNullOrEmpty(filterValue))
                                                         && (ddl.ParentCategory == parentFilterCategory || string.IsNullOrEmpty(parentFilterCategory))
                                                         && (ddl.ParentValue == parentFilterValue || string.IsNullOrEmpty(parentFilterValue))
                                   ).ToList<SystemDropDown>();

                htmlSelect.DataTextField = "VALUE";
                htmlSelect.DataValueField = "KEY";
                htmlSelect.DataSource = lsSystemDropDown;
                htmlSelect.DataBind();
            }
            else
            {
                lsSystemDropDown = lsSystemDropDown.Where(ddl => ddl.Category == "DEFAULT").ToList<SystemDropDown>();

                htmlSelect.DataTextField = "VALUE";
                htmlSelect.DataValueField = "KEY";
                htmlSelect.DataSource = lsSystemDropDown;
                htmlSelect.DataBind();
            }

            return htmlSelect;
        }

        private static HtmlSelect getHtmlDropDown(string filterCategory, string filterValue, string parentFilterCategory, string parentFilterValue, SystemDropDown systemDropDown)
        {
            HtmlSelect htmlSelect = new HtmlSelect();

            List<SystemDropDown> lsSystemDropDown = new List<SystemDropDown>();

            lsSystemDropDown = WebHelper.getSystemDropDownList(systemDropDown);

            htmlSelect.DataTextField = "VALUE";
            htmlSelect.DataValueField = "KEY";
            htmlSelect.DataSource = lsSystemDropDown;
            htmlSelect.DataBind();

            return htmlSelect;
        }

        public static List<SelectListItem> getMVCDropDown(string filterCategory = null, string filterValue = null, string parentFilterCategory = null, string parentFilterValue = null, bool getFromCache = false)
        {
            List<SelectListItem> lsSelectListItem = new List<SelectListItem>();

            SystemDropDown systemDropDown = new SystemDropDown();
            filterCategory = filterCategory.ToUpper();
            parentFilterCategory = !string.IsNullOrEmpty(parentFilterCategory) ? parentFilterCategory.ToUpper() : "";

            if (!getFromCache)
            {
                systemDropDown.Category = filterCategory;
                systemDropDown.Value = filterValue;
                systemDropDown.ParentCategory = parentFilterCategory;
                systemDropDown.ParentValue = parentFilterValue;
            }

            lsSelectListItem = getMVCDropDownList(filterCategory, filterValue, parentFilterCategory, parentFilterValue);

            return lsSelectListItem;
        }

        private static List<SelectListItem> getMVCDropDownList(string filterCategory, string filterValue, string parentFilterCategory, string parentFilterValue)
        {
            List<SelectListItem> lsSelectListItem = new List<SelectListItem>();
            List<SystemDropDown> lsSystemDropDown = new List<SystemDropDown>();

            lsSystemDropDown = ApplicationManager.SystemDropDownList;

            bool isDataAvailable = lsSystemDropDown.Where(ddl => ddl.Category == filterCategory
                                                         && (ddl.Value == filterValue || string.IsNullOrEmpty(filterValue))
                                                         && (ddl.ParentCategory == parentFilterCategory || string.IsNullOrEmpty(parentFilterCategory))
                                                         && (ddl.ParentValue == parentFilterValue || string.IsNullOrEmpty(parentFilterValue))
                                   ).Count() > 0;

            if (isDataAvailable)
            {
                lsSystemDropDown = lsSystemDropDown.Where(ddl => ddl.Category == filterCategory
                                                         && (ddl.Value == filterValue || string.IsNullOrEmpty(filterValue))
                                                         && (ddl.ParentCategory == parentFilterCategory || string.IsNullOrEmpty(parentFilterCategory))
                                                         && (ddl.ParentValue == parentFilterValue || string.IsNullOrEmpty(parentFilterValue))
                                   ).ToList<SystemDropDown>();
            }
            else
            {
                lsSystemDropDown = lsSystemDropDown.Where(ddl => ddl.Category == "DEFAULT").ToList<SystemDropDown>();                
            }

            foreach (var item in lsSystemDropDown)
            {
                lsSelectListItem.Add(new SelectListItem() { Text = item.Value, Value = item.Key });
            }
                        
            return lsSelectListItem;
        }

        private static List<SelectListItem> getMVCDropDownList(string filterCategory, string filterValue, string parentFilterCategory, string parentFilterValue, SystemDropDown systemDropDown)
        {
            List<SelectListItem> lsSelectListItem = new List<SelectListItem>();

            List<SystemDropDown> lsSystemDropDown = new List<SystemDropDown>();

            lsSystemDropDown = WebHelper.getSystemDropDownList(systemDropDown);

            foreach (var item in lsSystemDropDown)
            {
                lsSelectListItem.Add(new SelectListItem() { Text = item.Value, Value = item.Key });
            }

            return lsSelectListItem;
        }

        private static List<SystemDropDown> getSystemDropDownList(SystemDropDown systemDropDown)
        {
            //return new CommonService().getSystemDropDown(systemDropDown);

            return new List<SystemDropDown>();
        }
        
        public static void SetTemporaryData(Controller controller, string key, object value)
        {
            controller.TempData[key] = value;
        }
      
        public static void SetMessageAlertProperties(Controller controller, string messageType, string messageText, string messageInterval)
        {
            SetTemporaryData(controller, "ShowMessage", "Yes");
            SetTemporaryData(controller, "MessageType", messageType);
            SetTemporaryData(controller, "MessageText", messageText);
            SetTemporaryData(controller, "MessageInterval", messageInterval);            
        }

        public static void SetMessageBoxProperties(Controller controller, ResponseType responseType, string messageSummary = default(string), string messageHeader = default(string))
        {
            if (string.IsNullOrEmpty(messageHeader))
            {
                string GenericDataSuccessMessageHeader = string.IsNullOrEmpty(WebHelper.getApplicationSetting("GenericDataSuccessMessageHeader"))
                                                      ? "Data Saved Successfully!"
                                                      : WebHelper.getApplicationSetting("GenericDataSuccessMessageHeader");
                string GenericDataErrorMessageHeader = string.IsNullOrEmpty(WebHelper.getApplicationSetting("GenericDataErrorMessageHeader"))
                                                      ? "Please correct below error first!"
                                                      : WebHelper.getApplicationSetting("GenericDataErrorMessageHeader");
                messageHeader = responseType == ResponseType.Error ? GenericDataErrorMessageHeader : messageHeader;
                messageHeader = responseType == ResponseType.Success ? GenericDataSuccessMessageHeader : messageHeader;
            }

            controller.ViewBag.ShowMessage = true;
            controller.ViewBag.MessageType = responseType.ToString();            
            controller.ViewBag.MessageHeader = messageHeader;
            controller.ViewBag.MessageSummary = messageSummary;            
        }
    }
}