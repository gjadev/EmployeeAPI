using EmployeeAPI.Controllers;
using EmployeeAPI.Services.Dtos;
using EmployeeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeAPI.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        private IEmployeeService _employeeService;
        private EmployeeController _employeeController;
        private NullLogger<EmployeeController> _testLogger;

        [SetUp]
        public void Setup()
        {
            _employeeService = Substitute.For<IEmployeeService>();
            _employeeController = new EmployeeController(_employeeService, _testLogger);
        }

        [TestFixture]
        public class GetEmployeesByDepartmentTests : EmployeeControllerTests
        {
            [Test]
            public void GetEmployeesByDepartmentTests_Returns_EmployeeDto()
            {
                List<EmployeeDto> mockEmployeeList = new List<EmployeeDto>();
                mockEmployeeList.Add(new EmployeeDto()
                {
                    EmployeeId = 1,
                    Name = "Tom",
                    Designation = "Supervisor",
                    Department = "Sales"
                });


                _employeeService.GetEmployeesByDepartment(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>()).Returns(mockEmployeeList);

                var result = _employeeController.GetEmployeesByDepartment("MockDepartment", 1, 2).Result as OkObjectResult;
                var employeeResult = result.Value as IEnumerable<EmployeeDto>;
                var employeeList = employeeResult.ToList();
                
                Assert.IsNotNull(employeeResult);
                Assert.That(employeeList[0].EmployeeId, Is.EqualTo(mockEmployeeList[0].EmployeeId));
                Assert.That(employeeList[0].Name, Is.EqualTo(mockEmployeeList[0].Name));
                Assert.That(employeeList[0].Department, Is.EqualTo(mockEmployeeList[0].Department));
                Assert.That(employeeList[0].Designation, Is.EqualTo(mockEmployeeList[0].Designation));
            }
        }
    }
}
