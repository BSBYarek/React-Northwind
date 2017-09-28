using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ReactOnNorthwind.Controllers.DTO;
using ReactOnNorthwind.Models.Repositories;

namespace ReactOnNorthwind.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(): this(new EmployeeRepository())
        {
            
        }

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //api/employees
        public IEnumerable<EmployeeDetails> GetAllEmployees()
        {
            return _employeeRepository.GetAll().Select(e => new EmployeeDetails
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title,
                ProductsSold = e.Orders.Sum(o => o.Order_Details.Sum(od => od.Quantity)),
                RefersTo = e.RefersTo != null ? $"{e.RefersTo.FirstName} {e.RefersTo.LastName}" : string.Empty
            });
        }
    }
}
