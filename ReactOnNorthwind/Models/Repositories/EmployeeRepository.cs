using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactOnNorthwind.Models.Repositories
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private NORTHWNDContext _context;

        public EmployeeRepository() : this(new NORTHWNDContext())
        {
            
        }

        public EmployeeRepository(NORTHWNDContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}