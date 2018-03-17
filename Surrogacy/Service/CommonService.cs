using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Surrogacy.Data;
using Surrogacy.Entity;
using Surrogacy.Helper;

namespace Surrogacy.Service
{
    public class CommonService
    {
        public List<SystemDropDown> getSystemDropDown(SystemDropDown systemDropDownList) 
        {
            List<SystemDropDown> lsSystemDropDown = new List<SystemDropDown>();
            CommonData commonData = new CommonData();
            DataSet dataset = new DataSet();

            try
            {
                dataset = commonData.getSystemDropDown(systemDropDownList);

                if (dataset.Tables["DROPDOWNLIST"].Rows.Count > 0)
                {
                    for (int i = 0; i < dataset.Tables["DROPDOWNLIST"].Rows.Count; i++)
                    {
                        SystemDropDown localSDD = new SystemDropDown();
                        localSDD.Category = dataset.Tables["DROPDOWNLIST"].Rows[i]["CATEGORY"].ToString().ToUpper();
                        localSDD.DisplayText = dataset.Tables["DROPDOWNLIST"].Rows[i]["DISPLAYTEXT"].ToString();
                        localSDD.Key = dataset.Tables["DROPDOWNLIST"].Rows[i]["KEY"].ToString();
                        localSDD.Value = dataset.Tables["DROPDOWNLIST"].Rows[i]["VALUE"].ToString();
                        localSDD.ParentCategory = dataset.Tables["DROPDOWNLIST"].Rows[i]["PARENTCATEGORY"].ToString().ToUpper();
                        localSDD.ParentValue = dataset.Tables["DROPDOWNLIST"].Rows[i]["PARENTVALUE"].ToString();
                        localSDD.ParentKey = dataset.Tables["DROPDOWNLIST"].Rows[i]["PARENTKEY"].ToString();

                        lsSystemDropDown.Add(localSDD);
                    }
                }
            }
            catch(Exception ex) 
            {
                LoggerHelper.WriteToLog(ex);
            }

            return lsSystemDropDown;
        }


        public List<SystemConfiguration> getSystemConfiguration()
        {
            List<SystemConfiguration> lsSystemConfiguration = new List<SystemConfiguration>();
            CommonData commonData = new CommonData();
            DataSet dataset = new DataSet();

            try
            {
                dataset = commonData.getSystemConfiguration();

                if (dataset.Tables["SYSTEMSETTING"].Rows.Count > 0)
                {
                    for (int i = 0; i < dataset.Tables["SYSTEMSETTING"].Rows.Count; i++)
                    {
                        SystemConfiguration localSC = new SystemConfiguration();
                        localSC.SystemSettingID = Convert.ToInt32(dataset.Tables["SYSTEMSETTING"].Rows[i]["SYSTEMSETTINGID"]);
                        localSC.Property = dataset.Tables["SYSTEMSETTING"].Rows[i]["PROPERTY"].ToString();
                        localSC.Value = dataset.Tables["SYSTEMSETTING"].Rows[i]["VALUE"].ToString();
                        localSC.DisplayText = dataset.Tables["SYSTEMSETTING"].Rows[i]["DISPLAYTEXT"].ToString();

                        lsSystemConfiguration.Add(localSC);
                    }
                }
            }
            catch(Exception ex) 
            {
                LoggerHelper.WriteToLog(ex);
            }

            return lsSystemConfiguration;
        }
    }
}