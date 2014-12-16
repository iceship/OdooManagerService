using System;

namespace OdooManager.AppModels
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime LogTime { get; set; }
        public string LogThread { get; set; }
        public string LogLine { get; set; }
        public string LogMethod { get; set; }
        public string LogLogger { get; set; }
        public string LogLevel { get; set; }
        public string LogUsername { get; set; }
        public string LogMachine { get; set; }
        public string LogMessage { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string HResult { get; set; }
        public string HelpLink { get; set; }
        public string DataValues { get; set; }
        public string MethodException { get; set; }
    }
}
