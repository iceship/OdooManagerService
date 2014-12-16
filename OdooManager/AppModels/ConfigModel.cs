using System.IO;

namespace OdooManager.AppModels
{
    public class ConfigModel
    {
        public FileInfo OdooLogFile { get; set; }
        public FileInfo OdooConfigFile { get; set; }
        public FileInfo OdooExeFile { get; set; }
        public string OdooNameService { get; set; }
        public string PostgresNameService { get; set; }
        public string NginxNameService { get; set; }
    }
}
