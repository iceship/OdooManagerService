using System;
using System.Windows.Forms;
using OdooManager.AppConfig;

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
            Application.Run(new MainForm());
        }
    }
}
