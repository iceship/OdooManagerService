using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using OdooManager.AppUtils;

namespace OdooManager
{
    public partial class MainForm : Form
    {
        const int WM_SYSCOMMAND = 0x112;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartOdooClick(object sender, EventArgs e)
        {
            // TODO: Eliminar hardcode
            GlobalsManager.ConfigOdoo.OdooExeFile = new FileInfo(@"D:\Desarrollo\Odoo\Server\server\openerp-server.exe");
            GlobalsManager.ConfigOdoo.OdooConfigFile = new FileInfo(@"D:\Desarrollo\Odoo\Server\server\openerp-server.conf");

            GlobalsManager.Manager.StartOdoo();

            Thread.Sleep(500);
            IntPtr value = SetParent(GlobalsManager.Consola.CProccess.MainWindowHandle, panel1.Handle);
            SendMessage(GlobalsManager.Consola.CProccess.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0);
        }

        private void StopOdooClick(object sender, EventArgs e)
        {
            GlobalsManager.Manager.StopOdoo();
        }

    }
}
