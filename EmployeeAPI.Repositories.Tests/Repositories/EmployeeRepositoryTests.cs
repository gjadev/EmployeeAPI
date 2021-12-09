using EmployeeAPI.Data.Entities;
using EmployeeAPI.Repositories.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeAPI.Repositories.Tests.Repositories
{
    public class EmployeeRepositoryTests: TestWithSqlite
    {

        private EmployeeRepository _employeeRepository;

        [SetUp]
        public void Setup()
        {
            _employeeRepository = new EmployeeRepository(EmployeeDbContext);
        }

        [TestFixture]
        public class GetEmployeesByDepartmentTests : EmployeeRepositoryTests
        {
            [Test]
            public void GetEmployeesByDepartmentTests_Returns_EmployeeDto()
            {
                Employee employee1 = new Employee()
                {
                    EmployeeId = 1,
                    Name = "Tom",
                    Designation = "Supervisor",
                    Department = "Sales"
                };

                EmployeeDbContext.Employees.Add(employee1);
                EmployeeDbContext.SaveChanges();

                List<Employee> result = _employeeRepository.GetEmployeesByDepartment("Sales", 1, 1).ToList();

                Assert.That(result[0].EmployeeId, Is.EqualTo(1));
                Assert.That(result[0].Name, Is.EqualTo(employee1.Name));
                Assert.That(result[0].Department, Is.EqualTo(employee1.Department));
                Assert.That(result[0].Designation, Is.EqualTo(employee1.Designation));
            }

            [Test]
            public void GetEmployeesByDepartmentTests_Returns_EmptyList()
            {
                Employee employee1 = new Employee()
                {
                    EmployeeId = 1,
                    Name = "Tom",
                    Designation = "Supervisor",
                    Department = "Sales"
                };

                EmployeeDbContext.Employees.Add(employee1);
                EmployeeDbContext.SaveChanges();

                List<Employee> result = _employeeRepository.GetEmployeesByDepartment("Human Resources", 1, 1).ToList();

                Assert.That(result, Is.EqualTo(new List<Employee>()));
            }
        }
    }
}
