using System.Reflection;
using System.Web;
using System.Web.Http;
using Ninject;
using Ninject.MVC;
using ReactOnNorthwind.Controllers;

namespace ReactOnNorthwind
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.GetAll(typeof(EmployeesController));
        }
    }
}
