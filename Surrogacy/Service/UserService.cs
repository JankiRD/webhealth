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
    public class UserService
    {
        public User validateUser(User user)
        {
            User localUser = null;
            UserData userData = new UserData();
            DataSet dataSet = new DataSet();

            try
            {
                dataSet = userData.ValidateUser(user);

                if (dataSet.Tables["SEC_USER"].Rows.Count > 0)
                {
                    localUser = new User();
                    localUser.UserID = dataSet.Tables["SEC_USER"].Rows[0]["USERID"].ToString();                    
                    localUser.UserName = dataSet.Tables["SEC_USER"].Rows[0]["USERNAME"].ToString();                    
                    localUser.Title = dataSet.Tables["SEC_USER"].Rows[0]["TITLE"].ToString();
                    localUser.FirstName = dataSet.Tables["SEC_USER"].Rows[0]["FIRSTNAME"].ToString();
                    localUser.LastName = dataSet.Tables["SEC_USER"].Rows[0]["LASTNAME"].ToString();
                    localUser.Email = dataSet.Tables["SEC_USER"].Rows[0]["EMAIL"].ToString();
                    localUser.DOB = dataSet.Tables["SEC_USER"].Rows[0]["DOB"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(dataSet.Tables["SEC_USER"].Rows[0]["DOB"]);
                    localUser.Age = dataSet.Tables["SEC_USER"].Rows[0]["AGE"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataSet.Tables["SEC_USER"].Rows[0]["AGE"].ToString());
                    localUser.Gender = dataSet.Tables["SEC_USER"].Rows[0]["GENDER"].ToString();
                    localUser.UserRole = dataSet.Tables["SEC_USER"].Rows[0]["USERROLE"].ToString();
                    localUser.UserRoleName = dataSet.Tables["SEC_USER"].Rows[0]["USERROLENAME"].ToString();
                    localUser.LastLoginDate = dataSet.Tables["SEC_USER"].Rows[0]["LASTLOGINDATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataSet.Tables["SEC_USER"].Rows[0]["LASTLOGINDATE"]) ;                                                 
                    localUser.PasswordExpired = dataSet.Tables["SEC_USER"].Rows[0]["PasswordExpired"] == DBNull.Value ? (int?) null : Convert.ToInt32(dataSet.Tables["SEC_USER"].Rows[0]["PasswordExpired"]);
                    localUser.ResetPassword = dataSet.Tables["SEC_USER"].Rows[0]["RESETPASSWORD"] == DBNull.Value ? (int?) null : Convert.ToInt32(dataSet.Tables["SEC_USER"].Rows[0]["RESETPASSWORD"]);
                }
                else
                {
                    throw new Exception("Unauthorized access. Please try again!");                    
                }
            }
            catch(SqlException sqlEx) 
            {
                localUser = new User();
                localUser.responseDetail.responseType = ResponseType.Error;
                localUser.responseDetail.ResponseMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                localUser = new User();
                localUser.responseDetail.responseType = ResponseType.Error;
                localUser.responseDetail.ResponseMessage = ApplicationManager.GenericErrorMessage;

                LoggerHelper.WriteToLog(ex);
            }

            return localUser == null ? new User() : localUser;
        }

        public User SaveUser(User user)
        {
            User localUser = new User();
            UserData userData = new UserData();
            DataSet dataSet = new DataSet();

            try
            {
                dataSet = userData.SaveUser(user);

                if (dataSet.Tables["SEC_USER"].Rows.Count > 0)
                {
                    localUser = new User();
                    localUser.UserID = dataSet.Tables["SEC_USER"].Rows[0]["USERID"].ToString();
                    localUser.UserName = dataSet.Tables["SEC_USER"].Rows[0]["USERNAME"].ToString();
                    localUser.Title = dataSet.Tables["SEC_USER"].Rows[0]["TITLE"].ToString();
                    localUser.FirstName = dataSet.Tables["SEC_USER"].Rows[0]["FIRSTNAME"].ToString();
                    localUser.LastName = dataSet.Tables["SEC_USER"].Rows[0]["LASTNAME"].ToString();
                    localUser.Email = dataSet.Tables["SEC_USER"].Rows[0]["EMAIL"].ToString();
                    localUser.DOB = dataSet.Tables["SEC_USER"].Rows[0]["DOB"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataSet.Tables["SEC_USER"].Rows[0]["DOB"]);
                    localUser.Age = dataSet.Tables["SEC_USER"].Rows[0]["AGE"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataSet.Tables["SEC_USER"].Rows[0]["AGE"].ToString());
                    localUser.Gender = dataSet.Tables["SEC_USER"].Rows[0]["GENDER"].ToString();
                    localUser.UserRole = dataSet.Tables["SEC_USER"].Rows[0]["USERROLE"].ToString();
                    localUser.UserRoleName = dataSet.Tables["SEC_USER"].Rows[0]["USERROLENAME"].ToString();
                    localUser.LastLoginDate = dataSet.Tables["SEC_USER"].Rows[0]["LASTLOGINDATE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataSet.Tables["SEC_USER"].Rows[0]["LASTLOGINDATE"]);
                    localUser.PasswordExpired = dataSet.Tables["SEC_USER"].Rows[0]["PasswordExpired"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataSet.Tables["SEC_USER"].Rows[0]["PasswordExpired"]);
                    localUser.ResetPassword = dataSet.Tables["SEC_USER"].Rows[0]["RESETPASSWORD"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataSet.Tables["SEC_USER"].Rows[0]["RESETPASSWORD"]);
                }
            } 
            catch (SqlException sqlEx)
            {
                localUser.responseDetail.responseType = ResponseType.Error;
                localUser.responseDetail.ResponseMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                localUser.responseDetail.responseType = ResponseType.Error;
                localUser.responseDetail.ResponseMessage = ApplicationManager.GenericErrorMessage;

                LoggerHelper.WriteToLog(ex);
            }

            return localUser == null ? new User() : localUser;
        }
    }
}