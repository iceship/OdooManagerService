using System;
using System.IO;
using System.Windows.Forms;
using OdooManager.AppConfig;
using OdooManager.AppUtils;

namespace OdooManager
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DirConfig.Configure();

            // TODO: Eliminar hardcode
            GlobalsManager.ConfigOdoo.OdooExeFile = new FileInfo(@"D:\Desarrollo\Odoo\Server\server\openerp-server.exe");
            GlobalsManager.ConfigOdoo.OdooConfigFile = new FileInfo(@"D:\Desarrollo\Odoo\Server\server\openerp-server.conf");
            GlobalsManager.ConfigOdoo.OdooLogFile = new FileInfo(@"D:\Desarrollo\Odoo\odoo-server.log");
            GlobalsManager.ConfigOdoo.OdooNameService = "odoo-server-8.0";
            GlobalsManager.ConfigOdoo.PostgresNameService = "postgresql-x64-9.3";
            GlobalsManager.ConfigOdoo.NginxNameService = "nginx-server";
            GlobalsManager.DebugEnabled = true;

            Application.Run(new MainForm());
        }
    }
}
