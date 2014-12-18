using System;
using System.IO;
using System.Windows.Forms;
using OdooManager.AppUtils;

namespace OdooManager
{
    public partial class MainForm : Form
    {

        private long previousSize;

        public MainForm()
        {
            InitializeComponent();
            Closing += (sender, args) =>
            {
                if (!GlobalsManager.ProcessRunning.HasExited)
                {
                    GlobalsManager.Manager.StopOdoo();
                }
            };
            
        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            using (StreamReader reader = new StreamReader(new FileStream(GlobalsManager.ConfigOdoo.OdooLogFile.FullName,
                     FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                //start at the end of the file
                previousSize = reader.BaseStream.Length;

                //seek to the last max offset
                reader.BaseStream.Seek(previousSize, SeekOrigin.Begin);

                //read out of the file until the EOF
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    consoleLog.AppendText(@"\r\n" + line);
                }

                //update the last max offset
                previousSize = reader.BaseStream.Position;
            }
        }

        private void StartOdooClick(object sender, EventArgs e)
        {
            GlobalsManager.Manager.StartOdoo();

            logWatcher.Changed += new FileSystemEventHandler(watcher_Changed);
            logWatcher.Path = GlobalsManager.ConfigOdoo.OdooLogFile.DirectoryName;
            logWatcher.Filter = GlobalsManager.ConfigOdoo.OdooLogFile.Name;

            GlobalsManager.ProcessRunning.Exited += ProcessRunning_Exited;
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void StopOdooClick(object sender, EventArgs e)
        {
            GlobalsManager.Manager.StopOdoo();
        }

        void ProcessRunning_Exited(object sender, EventArgs e)
        {
            // TODO: Mostrar que el proceso esta finalizado

            Invoke(new Action(() =>
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }));
        }
    }
}
