using Ninject.Modules;
using ReactOnNorthwind.Models.Repositories;

namespace ReactOnNorthwind.App_Start
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployeeRepository>().To<EmployeeRepository>();
        }
    }
}