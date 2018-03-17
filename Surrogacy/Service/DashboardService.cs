using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DashboardService
    {
        public List<Dashboard> ViewDashboardData(Dashboard dashboard)
        {
            List<Dashboard> localdashboard = new List<Dashboard>();
            DashboardData dashboarddata = new DashboardData();
            DataSet dataSet = new DataSet();
            Dashboard locald = new Dashboard();
            locald.UserID = ApplicationManager.LoggedInUser.UserID;
            try
            {
                dataSet = dashboarddata.ViewDashboardData(locald);

                if (dataSet.Tables["Dashboard"].Rows.Count > 0)
                {
                    for (int i = 0; i < dataSet.Tables["Dashboard"].Rows.Count; i++)
                    {
                        Dashboard lcldash = new Dashboard();
                        lcldash.UserID = dataSet.Tables["Dashboard"].Rows[i]["USERID"].ToString();
                        lcldash.ID = Convert.ToInt16(dataSet.Tables["Dashboard"].Rows[i]["ID"].ToString());
                        lcldash.FormName = dataSet.Tables["Dashboard"].Rows[i]["FORMNAME"].ToString();
                        lcldash.ApprovalStatus = dataSet.Tables["Dashboard"].Rows[i]["APPROVALSTATUS"].ToString();
                        lcldash.IsSubmitted = dataSet.Tables["Dashboard"].Rows[i]["ISSUBMITTED"].ToString();
                        lcldash.Percentage = Convert.ToDecimal(dataSet.Tables["Dashboard"].Rows[i]["PERCENTAGE"].ToString());

                        localdashboard.Add(lcldash);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteToLog(ex);
            }

            return localdashboard;
        }
    }
}