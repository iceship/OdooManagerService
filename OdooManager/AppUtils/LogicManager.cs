using System;
using System.Collections.Generic;
using System.Linq;
using OdooManager.AppModels;

namespace OdooManager.AppUtils
{
    public class LogicManager
    {
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
    }
}
