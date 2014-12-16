using OdooManager.AppModels.Attrs;

namespace OdooManager.AppModels.Enums
{
    public enum StatusService
    {
        [EnumDescription("Stopped")]
        Stop = 0,
        [EnumDescription("Running")]
        Running = 1,
        [EnumDescription("Debugging")]
        Pause = 2
    }
}