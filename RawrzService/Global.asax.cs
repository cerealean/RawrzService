using System;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;

namespace RawrzService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AddBinToPath();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        private void AddBinToPath()
        {
            var path = Environment.GetEnvironmentVariable("PATH");
            var binDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin");
            Environment.SetEnvironmentVariable("PATH", path + ";" + binDir);
        }
    }
}
