using System;
using System.IO;
using System.Windows.Forms;
using OdooManager.AppModels;

namespace OdooManager.AppUtils
{
    public class GlobalsManager
    {
        // Variables estáticas para la instancia, se necesita utilizar una función lambda ya que el constructor es privado
        // GET
        private static readonly Lazy<LogicManager> manager =
            new Lazy<LogicManager>(() => new LogicManager());
        private static readonly Lazy<string> appPath =
            new Lazy<string>(() => Application.StartupPath);
        private static readonly Lazy<DirectoryInfo> dirDataUser =
            new Lazy<DirectoryInfo>(() => new DirectoryInfo(string.Format(@"{0}\Data", appPath.Value)));
        private static readonly Lazy<FileInfo> fileConfig =
            new Lazy<FileInfo>(() => new FileInfo(Path.Combine(dirDataUser.Value.FullName, "Configuration.xml")));
        private static readonly Lazy<FileInfo> fileLog =
            new Lazy<FileInfo>(() => new FileInfo(Path.Combine(dirDataUser.Value.FullName, "Logs.xml")));

        // GET / SET
        private static Lazy<ConfigModel> configOdoo = 
            new Lazy<ConfigModel>(() => new ConfigModel());

        // Constructor privado para evitar la instanciación directa
        private GlobalsManager() { }

        // Propiedad para acceder a la instancia

        // GET
        public static LogicManager Manager { get { return manager.Value; } }
        public static string AppPath { get { return appPath.Value; } }
        public static DirectoryInfo DirDataUser { get { return dirDataUser.Value; } }
        public static FileInfo FileConfig { get { return fileConfig.Value; } }
        public static FileInfo FileLog { get { return fileLog.Value; } }

        // GET / SET
        public static ConfigModel ConfigOdoo
        {
            get { return configOdoo.Value; }
            set { configOdoo = new Lazy<ConfigModel>(() => value);}
        }
    }
}
