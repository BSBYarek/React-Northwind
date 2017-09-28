using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReactOnNorthwind.Controllers;
using ReactOnNorthwind.Models;
using ReactOnNorthwind.Models.Repositories;

namespace ReactOnNorthwind.Tests
{
    [TestClass]
    public class EmployeeControllerTests
    {
        private readonly MockEmployeeRepo _repo;

        private readonly EmployeesController _controller;

        public EmployeeControllerTests()
        {
            _repo =  new MockEmployeeRepo();
            _controller  = new EmployeesController(_repo);
        }

        [TestMethod]
        public void should_return_all_employees_from_repo()
        {
            var expected = _repo.GetAll();

            var actual = _controller.GetAllEmployees();

            Assert.AreEqual(expected.Count(), actual.Count());
        }
    }

    internal class MockEmployeeRepo : IEmployeeRepository
    {
        private readonly IEnumerable<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                FirstName = "test first name",
                LastName = "test last name",
            },
            new Employee
            {
                FirstName = "test second name",
                LastName = "test second last name"
            }
        };

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
