using System.Web;
using System.Web.Mvc;

namespace Sistema_de_Gestión
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
