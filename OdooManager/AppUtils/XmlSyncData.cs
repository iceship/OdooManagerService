using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using OdooManager.AppModels;

namespace OdooManager.AppUtils
{
    public static class XmlSyncData
    {
        #region Config
        public static void LoadConfig()
        {
            // Lo cargamos en memoria
            GlobalsManager.ConfigOdoo = new ConfigModel();

            if (!File.Exists(GlobalsManager.FileConfig.FullName))
            {
                return;
            }

            XDocument doc = XDocument.Load(GlobalsManager.FileConfig.FullName, LoadOptions.SetLineInfo);

            if (doc.Root == null)
            {
                return;
            }

            ConfigModel data = doc.Root.Descendants().Select(s => new ConfigModel
            {
                NginxNameService = s.Attribute("NGINXNAMESERVICE").Value,
                OdooConfigFile = new FileInfo(s.Attribute("ODOOCONFIGFILE").Value),
                OdooExeFile = new FileInfo(s.Attribute("ODOOEXEFILE").Value),
                OdooLogFile = new FileInfo(s.Attribute("ODOOLOGFILE").Value),
                OdooNameService = s.Attribute("ODOONAMESERVICE").Value,
                PostgresNameService = s.Attribute("POSTGRESNAMESERVICE").Value
            }).FirstOrDefault();

            if (data == null)
            {
                return;
            }

            GlobalsManager.ConfigOdoo = data;
        }

        public static void SaveConfig()
        {
            // Lo guardamos en el XML
            ConfigModel o = GlobalsManager.ConfigOdoo;
            try
            {
                XElement dataXML = new XElement("Data", 
                    new XElement("Config",
                        new XAttribute("NGINXNAMESERVICE", o.NginxNameService),
                        new XAttribute("ODOOCONFIGFILE", o.OdooConfigFile.FullName),
                        new XAttribute("ODOOEXEFILE", o.OdooExeFile.FullName),
                        new XAttribute("ODOOLOGFILE", o.OdooLogFile.FullName),
                        new XAttribute("ODOONAMESERVICE", o.OdooNameService),
                        new XAttribute("POSTGRESNAMESERVICE", o.PostgresNameService)
                ));

                // Borramos y guardamos
                if (File.Exists(GlobalsManager.FileConfig.FullName))
                    GlobalsManager.FileConfig.Delete();
                dataXML.Save(GlobalsManager.FileConfig.FullName);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }
        #endregion

        #region Logs
        public static void AppendLogXML(Log log)
        {
            XElement logXML = new XElement("Log",
                new XElement("DATAVALUES", log.DataValues ?? ""),
                new XElement("HRESULT", log.HResult ?? ""),
                new XElement("HELPLINK", log.HelpLink ?? ""),
                new XAttribute("ID", log.Id),
                new XElement("LOGLEVEL", log.LogLevel ?? "DEBUG"),
                new XElement("LOGLINE", log.LogLine ?? ""),
                new XElement("LOGLOGGER", log.LogLogger ?? "Fichmaster"),
                new XElement("LOGMACHINE", Environment.MachineName),
                new XElement("LOGMESSAGE", log.LogMessage ?? ""),
                new XElement("LOGMETHOD", log.LogMethod ?? ""),
                new XElement("LOGTHREAD", Thread.CurrentThread.Name ?? ""),
                new XElement("LOGTIME", DateTime.Now),
                new XElement("LOGUSERNAME", !string.IsNullOrEmpty(Environment.UserDomainName) ? Environment.UserDomainName : Environment.UserName),
                new XElement("MESSAGE", log.Message ?? ""),
                new XElement("METHODEXCEPTION", log.MethodException ?? ""),
                new XElement("SOURCE", log.Source ?? ""),
                new XElement("STACKTRACE", log.StackTrace ?? "")
            );

            if (!File.Exists(GlobalsManager.FileLog.FullName))
            {
                XElement dataXML = new XElement("Data", logXML);
                dataXML.Save(GlobalsManager.FileLog.FullName);
            }
            else
            {
                XDocument doc = XDocument.Load(GlobalsManager.FileLog.FullName, LoadOptions.SetLineInfo);
                if (doc.Root != null)
                {
                    doc.Root.Add(logXML);
                }
                doc.Save(GlobalsManager.FileLog.FullName);
            }
        }

        public static IEnumerable<Log> GetLogs()
        {
            IEnumerable<Log> data = new List<Log>();

            if (!File.Exists(GlobalsManager.FileLog.FullName)) return data;
            XDocument doc = XDocument.Load(GlobalsManager.FileLog.FullName, LoadOptions.SetLineInfo);

            if (doc.Root != null)
            {
                data = doc.Root.Descendants().Select(s => new Log
                {
                    DataValues = s.Element("DATAVALUES") != null ? s.Element("DATAVALUES").Value : "",
                    HResult = s.Element("HRESULT") != null ? s.Element("DATAVALUES").Value : "",
                    HelpLink = s.Element("HELPLINK") != null ? s.Element("HELPLINK").Value : "",
                    Id = Convert.ToInt32(s.Attribute("ID").Value),
                    LogLevel = s.Element("LOGLEVEL") != null ? s.Element("LOGLEVEL").Value : "",
                    LogLine = s.Element("LOGLINE") != null ? s.Element("LOGLINE").Value : "",
                    LogLogger = s.Element("LOGLOGGER") != null ? s.Element("LOGLOGGER").Value : "",
                    LogMachine = s.Element("LOGMACHINE") != null ? s.Element("LOGMACHINE").Value : "",
                    LogMessage = s.Element("LOGMESSAGE") != null ? s.Element("LOGMESSAGE").Value : "",
                    LogMethod = s.Element("LOGMETHOD") != null ? s.Element("LOGMETHOD").Value : "",
                    LogThread = s.Element("LOGTHREAD") != null ? s.Element("LOGTHREAD").Value : "",
                    LogTime = s.Element("LOGTIME") != null ? Convert.ToDateTime(s.Element("LOGTIME").Value) : DateTime.Now,
                    LogUsername = s.Element("LOGUSERNAME") != null ? s.Element("LOGUSERNAME").Value : "",
                    Message = s.Element("MESSAGE") != null ? s.Element("MESSAGE").Value : "",
                    MethodException = s.Element("METHODEXCEPTION") != null ? s.Element("METHODEXCEPTION").Value : "",
                    Source = s.Element("SOURCE") != null ? s.Element("SOURCE").Value : "",
                    StackTrace = s.Element("STACKTRACE") != null ? s.Element("STACKTRACE").Value : ""
                });
            }

            return data;
        }
        #endregion
    }
}
