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
    public class DoctorDashboadService
    {
        public DoctorDashboard ViewDoctorDashboardData(DoctorDashboard doctordashboard)
        {
            DoctorDashboadData dashboarddata = new DoctorDashboadData();
            DataSet dataSet = new DataSet();
            DoctorDashboard locald = new DoctorDashboard();
            locald.UserID = ApplicationManager.LoggedInUser.UserID;
            try
            {
                dataSet = dashboarddata.ViewDoctorDashboardData(locald);

                if (dataSet.Tables["DoctorDashboard"].Rows.Count > 0)
                {

                    locald.ApprovedApplication = dataSet.Tables["DoctorDashboard"].Rows[0]["APPROVED"].ToString();
                    locald.RejectedApplication = dataSet.Tables["DoctorDashboard"].Rows[0]["REJECTED"].ToString();
                    locald.PendingApplicaion = dataSet.Tables["DoctorDashboard"].Rows[0]["PENDING"].ToString();
                    locald.NAApplication = dataSet.Tables["DoctorDashboard"].Rows[0]["NA"].ToString();
                    
                }
            }
            catch (SqlException sqlEx)
            {
                locald.responseDetail.responseType = ResponseType.Error;
                locald.responseDetail.ResponseMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                locald.responseDetail.responseType = ResponseType.Error;
                locald.responseDetail.ResponseMessage = ApplicationManager.GenericErrorMessage;

                LoggerHelper.WriteToLog(ex);
            }

            return locald == null ? new DoctorDashboard() : locald;
        }
    }
}