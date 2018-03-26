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
    public class ListService
    {
        public List<ListSurrogate> GetListSurrogate(ListSurrogate listsurrogate)
        {
            List<ListSurrogate> locallistsurrogate = new List<ListSurrogate>();
            ListData finalsubmitdata = new ListData();
            DataSet dataSet = new DataSet();
            ListSurrogate locallist = new ListSurrogate();
            locallist.UserID = ApplicationManager.LoggedInUser.UserID;

            try
            {
                dataSet = finalsubmitdata.GetSurrogateData(locallist);
                 if (dataSet.Tables["TEMP"].Rows.Count > 0)
                {
                    for (int i = 0; i < dataSet.Tables["TEMP"].Rows.Count; i++)
                    {
                        ListSurrogate loc = new ListSurrogate();

                        loc.UserID = dataSet.Tables["TEMP"].Rows[i]["USERID"].ToString();
                        loc.SurrogateUserID = dataSet.Tables["TEMP"].Rows[i]["SURROGATEUSERID"].ToString();
                        loc.FirstName = dataSet.Tables["TEMP"].Rows[i]["FIRSTNAME"].ToString();
                        loc.LastName = dataSet.Tables["TEMP"].Rows[i]["LASTNAME"].ToString();
                        loc.EmailID = dataSet.Tables["TEMP"].Rows[i]["EMAILID"].ToString();
                        loc.DOB = dataSet.Tables["TEMP"].Rows[i]["DOB"].ToString();
                        loc.Age = dataSet.Tables["TEMP"].Rows[i]["AGE"].ToString();
                        loc.Height = dataSet.Tables["TEMP"].Rows[i]["HEIGHT"].ToString();
                        loc.Weight = dataSet.Tables["TEMP"].Rows[i]["WEIGHT"].ToString();
                        loc.Citizenship = dataSet.Tables["TEMP"].Rows[i]["CITIZENSHIP"].ToString();
                        loc.ApprovalStatus = dataSet.Tables["TEMP"].Rows[i]["APPROVALSTATUS"].ToString();
                        locallistsurrogate.Add(loc);
                    } 
                            
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteToLog(ex);
            }

            return locallistsurrogate;
        }
    }
}