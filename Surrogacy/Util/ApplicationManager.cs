using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Surrogacy.Models;
using Surrogacy.Helper;
using Surrogacy.Service;
using Surrogacy.Entity;

namespace Surrogacy.Util
{
    public static class ApplicationManager
    {
        public static bool IsSystemConfigurationSet { get; set; }

        //Application Settings
        public static bool IsSessionStarted { get; set; }
        public static string ApplicationName { get; set; }
        public static string ApplicationNameFP { get; set; }
        public static string ApplicationNameLP { get; set; }
        public static string ApplicationNameShortName { get; set; }        
        public static string ApplicationLogoPath { get; set; }
        public static string ApplicationFaviconPath { get; set; }
        public static string ApplicationWebLink { get; set; }
        public static string GenericErrorMessage { get; set; }

        //User Settings
        public static bool IsUserLoggedIn { get; set; }
        public static string UserName { get; set; }
        public static string UserFullName { get; set; }
        public static string UserAvatar { get; set; }
        public static string RedirectUrl { get; set; }
        public static User LoggedInUser { get; set; }

        //Application property
        public static List<SystemConfiguration> SystemConfigurationList { get; set; }
        public static List<SystemDropDown> SystemDropDownList { get; set; }

        public static void InitlizeConfiguration() 
        {
            if (!IsSystemConfigurationSet)
            {
                SetSystemConfiguration();
            }
        }

        public static void SetSystemConfiguration()
        {
            string configurationFrom = string.Empty;
            configurationFrom = WebHelper.getApplicationSetting("ApplicationSettingFrom");

            try { 
                switch(configurationFrom) 
                {
                    case "DB":
                        SetSystemConfigurationFromDB();
                        break;
                    case "CONFIG":
                        SetSystemConfigurationFromCONFIG();
                        break;
                    default:
                        SetDefaultSystemConfiguration();
                        break;
                }

                SetSystemDropDown();
            }
            catch(Exception ex) 
            {
                SetDefaultSystemConfiguration();

                LoggerHelper.WriteToLog(ex);
            }

            IsSystemConfigurationSet = true;
        }

        private static void SetSystemDropDown()
        {
            CommonService commonServices = new CommonService();
            List<SystemDropDown> lsSystemDropDown = new List<SystemDropDown>();

            lsSystemDropDown = commonServices.getSystemDropDown(null);
            SystemDropDownList = lsSystemDropDown;
        }

        private static void SetSystemConfigurationFromDB() 
        {
            CommonService commonServices = new CommonService();
            List<SystemConfiguration> lsSystemConfiguration = new List<SystemConfiguration>();

            lsSystemConfiguration = commonServices.getSystemConfiguration();
            SystemConfigurationList = lsSystemConfiguration;

            ApplicationName = lsSystemConfiguration.FirstOrDefault(sys => sys.Property == "ApplicationName").Value;
            ApplicationNameFP = lsSystemConfiguration.FirstOrDefault(sys => sys.Property == "ApplicationNameFP").Value;
            ApplicationNameLP = lsSystemConfiguration.FirstOrDefault(sys => sys.Property == "ApplicationNameLP").Value;
            ApplicationNameShortName = lsSystemConfiguration.FirstOrDefault(sys => sys.Property == "ApplicationNameShortName").Value;
            ApplicationLogoPath = lsSystemConfiguration.FirstOrDefault(sys => sys.Property == "ApplicationLogoPath").Value;
            ApplicationFaviconPath = lsSystemConfiguration.FirstOrDefault(sys => sys.Property == "ApplicationFaviconPath").Value;
            ApplicationWebLink = lsSystemConfiguration.FirstOrDefault(sys => sys.Property == "ApplicationWebLink").Value;
            GenericErrorMessage = lsSystemConfiguration.FirstOrDefault(sys => sys.Property == "GenericErrorMessage").Value;
        }

        private static void SetSystemConfigurationFromCONFIG()
        {
            ApplicationName = WebHelper.getApplicationSetting("ApplicationName").ToString();
            ApplicationNameFP = WebHelper.getApplicationSetting("ApplicationNameFP").ToString();
            ApplicationNameLP = WebHelper.getApplicationSetting("ApplicationNameLP").ToString();
            ApplicationNameShortName = WebHelper.getApplicationSetting("ApplicationNameShortName").ToString();
            ApplicationLogoPath = WebHelper.getApplicationSetting("ApplicationLogoPath").ToString();
            ApplicationFaviconPath = WebHelper.getApplicationSetting("ApplicationFaviconPath").ToString();
            ApplicationWebLink = WebHelper.getApplicationSetting("ApplicationWebLink").ToString();
            GenericErrorMessage = WebHelper.getApplicationSetting("GenericErrorMessage").ToString();
        }

        private static void SetDefaultSystemConfiguration()
        {
            ApplicationName = "SecondHOPE";
            ApplicationNameFP = "Second";
            ApplicationNameLP = "HOPE";
            ApplicationNameShortName = "SHP";
            ApplicationLogoPath = "/Content/dist/img/logo.png";
            ApplicationFaviconPath = "/Content/dist/favicon/favicon.ico";
            ApplicationWebLink = "http://localhost:4356";
            GenericErrorMessage = "Something went wrong! Please contact technical team!";
        }

        public static void InitlizeUserSession(User user)
        {
            IsUserLoggedIn = true;
            UserName = user.UserName;
            UserFullName = user.FirstName + " " + user.LastName;
            LoggedInUser = user;

            if (File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + @"/Content/dist/img/User_" + user.UserID.ToString() + ".jpg"))
            {
                UserAvatar = @"/Content/dist/img/User_" + user.UserID.ToString() + ".jpg";
            }
            else if (File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + @"/Content/dist/img/User_" + user.UserID.ToString() + ".png"))
            {
                UserAvatar = @"/Content/dist/img/User_" + user.UserID.ToString() + ".png";
            }
            else
            {
                UserAvatar = @"/Content/dist/img/avatar.jpg";
            }
        }

        public static void DestroyUserSession()
        {
            IsUserLoggedIn = false;
            UserName = null;
            UserFullName = null;
            LoggedInUser = null;
        }
    } 
}