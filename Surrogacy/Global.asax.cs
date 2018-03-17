using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using Surrogacy.Helper;
using System.Web.Configuration;
using Surrogacy.Util;
using System.Web.Security;

namespace Surrogacy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ApplicationManager.InitlizeConfiguration();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            bool RedirectOnException = true;

            Boolean.TryParse(WebConfigurationManager.AppSettings["RedirectOnException"], out RedirectOnException);
            if (RedirectOnException)
            {
                // Code that runs when an unhandled error occurs
                // Get the exception object.
                Exception exc = Server.GetLastError();
                Session["APPLICATIONERROR"] = exc;

                // Handle HTTP errors
                if (exc.GetType() == typeof(HttpException))
                {
                    // The Complete Error Handling Example generates
                    // some errors using URLs with "NoCatch" in them;
                    // ignore these here to simulate what would happen
                    // if a global.asax handler were not implemented.
                    if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                        return;

                    //Redirect HTTP errors to HttpError page
                    Server.Transfer(WebHelper.GetPagePath(Request) + @"/Error/Error");
                }

                // For other kinds of errors give the user some information
                // but stay on the default page
                //Response.Write("<h2>Global Page Error</h2>\n");
                //Response.Write(
                // "<p>" + exc.Message + "</p>\n");
                //Response.Write("Return to the <a href='Default.aspx'>" +
                //"Default Page</a>\n");
                Server.Transfer(WebHelper.GetPagePath(Request) + @"/Error/Error");
                //// Log the exception and notify system operators
                //ExceptionUtility.LogException(exc, "DefaultPage");
                //ExceptionUtility.NotifySystemOps(exc);

                // Clear the error from the server
                Server.ClearError();
            }
        }

        [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
        public class CheckSessionOutAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var context = filterContext.HttpContext;
                if (context.Session != null)
                {
                    if (context.Session.IsNewSession || !ApplicationManager.IsUserLoggedIn)
                    {
                        string sessionCookie = context.Request.Headers["Cookie"];

                        if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                        {
                            FormsAuthentication.SignOut();
                            string redirectTo = "~/Account/Login";
                            if (!string.IsNullOrEmpty(context.Request.RawUrl))
                            {
                                redirectTo = string.Format("~/Account/Login?ReturnUrl={0}",
                                    HttpUtility.UrlEncode(context.Request.RawUrl));

                                filterContext.Result = new RedirectResult(redirectTo);
                            }
                        }
                    }
                }
                
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
