using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Surrogacy.Helper
{
    public class LoggerHelper
    {
    
        public static void WriteToLog(Exception exLog)
        {
            //
            System.IO.StreamWriter pFileStream = null;
            FileIOPermission pObjfileReadPerm = null;

            //
            string pStrFolder = string.Empty;
            string canLogErrrors = string.Empty;
            bool logInfo = bool.TryParse(getConfigurationSetting("EnableErrorLog"), out logInfo) ? logInfo : false;

            try
            {
                //
                if (logInfo)
                {
                    pStrFolder = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/ErrorLog/");

                    if (!Directory.Exists(pStrFolder))
                        Directory.CreateDirectory(pStrFolder);

                    pObjfileReadPerm = new FileIOPermission(FileIOPermissionAccess.Write, pStrFolder);
                    pObjfileReadPerm.Assert();


                    //
                    if (System.IO.Directory.Exists(pStrFolder) == false)
                    {
                        System.IO.Directory.CreateDirectory(pStrFolder);
                    }

                    try
                    {
                        //
                        pFileStream = new System.IO.StreamWriter(pStrFolder + DateTime.Now.ToString("yyyyMMdd") + " Log.txt", true);
                        pFileStream.WriteLine("-------------------------------------------------------------");
                        pFileStream.WriteLine(string.Format("{0:MM/dd/yyyy HH:mm:ss.fff}", DateTime.Now));
                        pFileStream.WriteLine("-------------------------------------------------------------");
                        pFileStream.WriteLine(string.Format("[Message]      : {0}", exLog.Message));
                        pFileStream.WriteLine(string.Format("[StackTrace]   : {0}", exLog.StackTrace));
                        pFileStream.WriteLine(string.Format("[Source]       : {0}", exLog.Source));
                        pFileStream.WriteLine(string.Format("[TargetSite]   : {0}", exLog.TargetSite.ToString()));
                        pFileStream.WriteLine(Environment.NewLine);                        
                        pFileStream.Close();
                    }
                    catch (Exception exTwo)
                    {
                        try
                        {
                            //                          
                            pFileStream = new System.IO.StreamWriter(pStrFolder + DateTime.Now.ToString("yyyyMMdd") + " LogTwo.txt", true);
                            pFileStream.WriteLine("-------------------------------------------------------------");
                            pFileStream.WriteLine(string.Format("{0:MM/dd/yyyy HH:mm:ss.fff}", DateTime.Now));
                            pFileStream.WriteLine("-------------------------------------------------------------");
                            pFileStream.WriteLine(string.Format("[Message]      : {0}", exTwo.Message));
                            pFileStream.WriteLine(string.Format("[StackTrace]   : {0}", exTwo.StackTrace));
                            pFileStream.WriteLine(string.Format("[Source]       : {0}", exTwo.Source));
                            pFileStream.WriteLine(string.Format("[TargetSite]   : {0}", exTwo.TargetSite.ToString()));
                            pFileStream.WriteLine(Environment.NewLine);

                            pFileStream.Close();
                        }
                        catch (Exception exThree)
                        {
                            //
                            pFileStream = new System.IO.StreamWriter(pStrFolder + DateTime.Now.ToString("yyyyMMdd") + " LogThree.txt", true);

                            pFileStream.WriteLine("-------------------------------------------------------------");
                            pFileStream.WriteLine(string.Format("{0:MM/dd/yyyy HH:mm:ss.fff}", DateTime.Now));
                            pFileStream.WriteLine("-------------------------------------------------------------");
                            pFileStream.WriteLine(string.Format("[Message]      : {0}", exThree.Message));
                            pFileStream.WriteLine(string.Format("[StackTrace]   : {0}", exThree.StackTrace));
                            pFileStream.WriteLine(string.Format("[Source]       : {0}", exThree.Source));
                            pFileStream.WriteLine(string.Format("[TargetSite]   : {0}", exThree.TargetSite.ToString()));
                            pFileStream.WriteLine(Environment.NewLine);

                            pFileStream.Close();
                        }
                    }

                }
            }
            catch (Exception exWriteToLog)
            {
                throw exWriteToLog;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Dispose();
            }
        }

        protected static string getConfigurationSetting(string settingKey)
        {
            string settingValue = ConfigurationManager.AppSettings[settingKey].ToString().Trim();
            settingValue = settingValue == null ? string.Empty : settingValue;

            return settingValue;
        }

        public static void SetEntryAssembly()
        {
            SetEntryAssembly(Assembly.GetCallingAssembly());
        }

        public static void SetEntryAssembly(Assembly assembly)
        {
            AppDomainManager manager = new AppDomainManager();
            FieldInfo entryAssemblyfield = manager.GetType().GetField("m_entryAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
            entryAssemblyfield.SetValue(manager, assembly);

            AppDomain domain = AppDomain.CurrentDomain;
            FieldInfo domainManagerField = domain.GetType().GetField("_domainManager", BindingFlags.Instance | BindingFlags.NonPublic);
            domainManagerField.SetValue(domain, manager);
        }
    }
}
