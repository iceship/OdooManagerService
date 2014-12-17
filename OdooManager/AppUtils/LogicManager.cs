using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OdooManager.AppModels;

namespace OdooManager.AppUtils
{
    public class LogicManager
    {
        #region XML

        #region Config
        public void LoadConfig()
        {
            XmlSyncData.LoadConfig();
        }

        public void SaveConfig()
        {
            // Lo guardamos en el XML
            XmlSyncData.SaveConfig();
        }
        #endregion

        #region Log
        public IEnumerable<Log> GetLogs(Func<Log, bool> filter = null)
        {
            IEnumerable<Log> data = XmlSyncData.GetLogs();
            data = filter == null ? data.ToList() : data.Where(filter).ToList();
            return data;
        }

        public void SetLog(Log log)
        {
            // Lo guardamos en el XML
            XmlSyncData.AppendLogXML(log);
        }
        #endregion

        #endregion

        #region Odoo

        public void StartOdoo()
        {
            GlobalsManager.Consola.StartInfo = new ProcessStartInfo
            {
                //UseShellExecute = false,
                //ErrorDialog = false,
                //RedirectStandardError = true,
                //RedirectStandardInput = true,
                //RedirectStandardOutput = true,
                //CreateNoWindow = true,
                FileName = GlobalsManager.ConfigOdoo.OdooExeFile.FullName,
                Arguments = string.Format("--debug --config=\"{0}\"", GlobalsManager.ConfigOdoo.OdooConfigFile.FullName),
                WindowStyle = ProcessWindowStyle.Minimized,
            };

            GlobalsManager.Consola.CProccess = new Process
            {
                StartInfo = GlobalsManager.Consola.StartInfo,
                EnableRaisingEvents = true,
            };

            try
            {
                GlobalsManager.Consola.Started = GlobalsManager.Consola.CProccess.Start();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }

        public void StopOdoo()
        {
            if (!GlobalsManager.Consola.Started) return;

            GlobalsManager.Consola.CProccess.Kill();
            GlobalsManager.Consola.Started = false;
        }

        #endregion
    }
}
