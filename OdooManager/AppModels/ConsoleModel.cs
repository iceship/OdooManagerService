using System.Diagnostics;

namespace OdooManager.AppModels
{
    public class ConsoleModel
    {
        public Process CProccess { get; set; }
        public bool Started { get; set; }
        public ProcessStartInfo StartInfo { get; set; }
    }
}
