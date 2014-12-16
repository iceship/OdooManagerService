using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using OdooManager.AppUtils;

namespace OdooManager
{
    public partial class MainForm : Form
    {
        private static Lazy<string> testString = new Lazy<string>(() => string.Empty);

        public MainForm()
        {
            InitializeComponent();

            schedulerConsoleCMD.Tick += schedulerConsoleCMD_Tick;
        }

        private void schedulerConsoleCMD_Tick(object sender, EventArgs e)
        {
            if (!GlobalsManager.Consola.Started) return;

            consoleInteractive.Text += testString.Value;
            testString = new Lazy<string>(() => string.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!GlobalsManager.Consola.Started) return;

            schedulerConsoleCMD.Start();

            var processStartInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                ErrorDialog = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                FileName = @"D:\Desarrollo\Odoo\Server\server\openerp-server.exe",
                Arguments = string.Format("--debug --config=\"{0}\"", @"D:\Desarrollo\Odoo\Server\server\openerp-server.conf")
            };

            GlobalsManager.Consola.CProccess = new Process { StartInfo = processStartInfo };

            Task.Factory.StartNew(() =>
            {
                Task.Factory.StartNew(() =>
                {
                    Timer t1 = new Timer{Interval = 100};
                    t1.Tick += (o, args) =>
                    {
                        while (GlobalsManager.Consola.COutput.Peek() >= 0)
                        {
                            testString = new Lazy<string>(() => testString.Value + GlobalsManager.Consola.COutput.ReadToEnd());
                        }
                    };
                });

                GlobalsManager.Consola.Started = GlobalsManager.Consola.CProccess.Start();
                GlobalsManager.Consola.CProccess.WaitForExit();
            })
            .ContinueWith(c =>
            {
                GlobalsManager.Consola.Started = false;
                schedulerConsoleCMD.Stop();
            });
        }
    }
}
