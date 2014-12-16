using OdooManager.AppUtils;

namespace OdooManager.AppConfig
{
    public static class DirConfig
    {
        public static void Configure()
        {
            // Creamos los directorios si no existen
            if (!GlobalsManager.DirDataUser.Exists)
            {
                GlobalsManager.DirDataUser.Create();
            }
        }
    }
}
