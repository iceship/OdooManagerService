using System.Diagnostics;
using System.IO;

namespace OdooManager.AppModels
{
    public class ConsoleModel
    {
        public Process CProccess { get; set; }
        public bool Started { get; set; }
        public StreamWriter CInput { get { return CProccess.StandardInput; } }
        public StreamReader COutput { get { return CProccess.StandardOutput; } }
        public StreamReader CError { get { return CProccess.StandardError; } }
    }
}
