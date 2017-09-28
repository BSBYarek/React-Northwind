using System.Collections.Generic;

namespace ReactOnNorthwind.Models.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
    }
}