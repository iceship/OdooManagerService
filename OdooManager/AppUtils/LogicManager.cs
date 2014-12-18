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
            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                ErrorDialog = true,
                RedirectStandardError = false,
                RedirectStandardInput = false,
                RedirectStandardOutput = false,
                CreateNoWindow = false,
                FileName = GlobalsManager.ConfigOdoo.OdooExeFile.FullName,
                Arguments = string.Format("{0} --config=\"{1}\"", 
                    GlobalsManager.DebugEnabled ? "--debug" : "", 
                    GlobalsManager.ConfigOdoo.OdooConfigFile.FullName),
                WindowStyle = ProcessWindowStyle.Normal,
            };

            GlobalsManager.ProcessRunning = new Process
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true,
            };

            try
            {
                GlobalsManager.ProcessRunning.Start();
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }

        public void StopOdoo()
        {
            if (GlobalsManager.ProcessRunning.HasExited) return;

            GlobalsManager.ProcessRunning.Kill();
        }

        #endregion
    }
}
