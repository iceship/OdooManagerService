using System;
using System.Configuration;
using OdooManager.AppModels;

namespace OdooManager.AppUtils
{
    public static class Logger
    {
        #region Private methods
        /// <summary>
        /// Crea un nuevo log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static Log BuildLog(string level, string message, Exception ex = null)
        {
            Log log = new Log
            {
                LogTime = DateTime.Now,
                LogThread = System.Threading.Thread.CurrentThread.Name ?? System.Threading.Thread.CurrentThread.ManagedThreadId.ToString(),
                LogLogger = "OdooManager",
                LogLevel = level,
                LogUsername = !string.IsNullOrEmpty(Environment.UserDomainName) ? Environment.UserDomainName : Environment.UserName,
                LogMachine = Environment.MachineName,
                LogMessage = message
            };

            if (ex != null)
            {
                log.Source = ex.Source;
                log.Message = GetFullMessage(ex, "");
                log.StackTrace = ex.StackTrace;
                log.HelpLink = ex.HelpLink;
                log.DataValues = string.Join(", ", ex.Data.Values);
                log.MethodException = ex.TargetSite != null ? ex.TargetSite.Name : null;
            }

            return log;
        }

        /// <summary>
        /// Funcion recursiva que va obteniendo los mensajes de los inner exception
        /// </summary>
        /// <param name="ex">Excepcion</param>
        /// <param name="fullMessage">Mensaje hasta ahora</param>
        /// <returns></returns>
        private static string GetFullMessage(Exception ex, string fullMessage)
        {
            if (ex != null)
            {
                fullMessage = string.Concat(fullMessage, "\n", ex.Message);
                return GetFullMessage(ex.InnerException, fullMessage);
            }
            else
            {
                return fullMessage;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Registra un mensaje informativo
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            GlobalsManager.Manager.SetLog(BuildLog("INFO", message));
        }

        /// <summary>
        /// Registra una alarma controlada
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Warn(string message, Exception ex = null)
        {
            GlobalsManager.Manager.SetLog(BuildLog("WARN", message, ex));
        }

        /// <summary>
        /// Registra cualquier tipo de error no controlado
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Error(string message, Exception ex = null)
        {
            GlobalsManager.Manager.SetLog(BuildLog("ERROR", message, ex));
        }

        /// <summary>
        /// Utilizado para depurar código, des/activable desde app.config
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            bool enabled = false;

            object data = ConfigurationManager.AppSettings.Get("DebugEnabled");
            if (data != null && bool.TryParse(data.ToString(), out enabled))
            {
                enabled = true;
            }

            if (enabled)
            {
                GlobalsManager.Manager.SetLog(BuildLog("DEBUG", message));
            }
        }
        #endregion
    }
}
