using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using OdooManager.AppModels;
using OdooManager.AppModels.Enums;

namespace OdooManager.AppUtils
{
    public class GlobalsManager
    {
        #region Constructor
        // Constructor privado para evitar la instanciación directa
        private GlobalsManager() { }
        #endregion

        #region Fields
        // Variables estáticas para la instancia, se necesita utilizar una función lambda ya que el constructor es privado
        
        #region Private readonly fields GET
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
        #endregion

        #region Private fields GET / SET
        private static Lazy<ConfigModel> configOdoo = 
            new Lazy<ConfigModel>(() => new ConfigModel());

        private static Lazy<StatusService> statusOdoo =
            new Lazy<StatusService>(() => StatusService.Stop);
        private static Lazy<StatusService> statusPostgres =
            new Lazy<StatusService>(() => StatusService.Stop);
        private static Lazy<StatusService> statusNginx =
            new Lazy<StatusService>(() => StatusService.Stop);
        private static Lazy<bool> debugEnabled =
            new Lazy<bool>(() => false);

        private static Lazy<Process> processRunning =
            new Lazy<Process>(() => new Process());
        #endregion

        #endregion

        #region Properties
        // Propiedad para acceder a la instancia

        #region Public readonly property GET
        public static LogicManager Manager { get { return manager.Value; } }
        public static string AppPath { get { return appPath.Value; } }
        public static DirectoryInfo DirDataUser { get { return dirDataUser.Value; } }
        public static FileInfo FileConfig { get { return fileConfig.Value; } }
        public static FileInfo FileLog { get { return fileLog.Value; } }
        #endregion

        #region Public property GET / SET
        public static ConfigModel ConfigOdoo
        {
            get { return configOdoo.Value; }
            set { configOdoo = new Lazy<ConfigModel>(() => value);}
        }

        public static StatusService StatusOdoo
        {
            get { return statusOdoo.Value; }
            set { statusOdoo = new Lazy<StatusService>(() => value); }
        }
        public static StatusService StatusPostgres
        {
            get { return statusPostgres.Value; }
            set { statusPostgres = new Lazy<StatusService>(() => value); }
        }
        public static StatusService StatusNginx
        {
            get { return statusNginx.Value; }
            set { statusNginx = new Lazy<StatusService>(() => value); }
        }
        public static bool DebugEnabled
        {
            get { return debugEnabled.Value; }
            set { debugEnabled = new Lazy<bool>(() => value); }
        }

        public static Process ProcessRunning
        {
            get { return processRunning.Value; }
            set { processRunning = new Lazy<Process>(() => value); }
        }
        #endregion

        #endregion
    }
}