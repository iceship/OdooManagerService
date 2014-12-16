using System.IO;
using OdooManager.AppModels.Enums;

namespace OdooManager.AppModels
{
    public class ConfigModel
    {
        public FileInfo OdooLogFile { get; set; }
        public FileInfo OdooConfigFile { get; set; }
        public FileInfo OdooExeFile { get; set; }
        public bool DebugEnabled { get; set; }
        public string NameService { get; set; }
        public StatusService StatusService { get; set; }
    }
}
