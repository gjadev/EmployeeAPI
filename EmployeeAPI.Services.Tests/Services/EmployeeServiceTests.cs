using AutoMapper;
using EmployeeAPI.Data.Entities;
using EmployeeAPI.Repositories.Interfaces;
using EmployeeAPI.Services.Dtos;
using EmployeeAPI.Services.Services;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeAPI.Services.Tests.Services
{
    public class EmployeeServiceTests
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private EmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile<MapperProfiles.MapperProfiles>();
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [SetUp]
        public void Setup()
        {
            _employeeRepository = Substitute.For<IEmployeeRepository>();
            _employeeService = new EmployeeService(_employeeRepository, _mapper);
        }

        [TestFixture]
        public class GetEmployeesByDepartmentTests: EmployeeServiceTests
        {
            [Test]
            public void GetEmployeesByDepartmentTests_Returns_EmployeeDto()
            {
                List<Employee> mockEmployeeList = new List<Employee>();
                mockEmployeeList.Add(new Employee()
                {
                    EmployeeId = 1,
                    Name = "Tom",
                    Designation = "Supervisor",
                    Department = "Sales"
                });
                List<EmployeeDto> expectedEmployeeList = new List<EmployeeDto>();
                expectedEmployeeList.Add(new EmployeeDto()
                {
                    EmployeeId = 1,
                    Name = "Tom",
                    Designation = "Supervisor",
                    Department = "Sales"
                });

                _employeeRepository.GetEmployeesByDepartment(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>()).Returns(mockEmployeeList);
                
                List<EmployeeDto> result = _employeeService.GetEmployeesByDepartment("MockDepartment", 1, 2).ToList();

                Assert.That(result[0].EmployeeId, Is.EqualTo(expectedEmployeeList[0].EmployeeId));
                Assert.That(result[0].Name, Is.EqualTo(expectedEmployeeList[0].Name));
                Assert.That(result[0].Department, Is.EqualTo(expectedEmployeeList[0].Department));
                Assert.That(result[0].Designation, Is.EqualTo(expectedEmployeeList[0].Designation));
            }

            [Test]
            public void GetEmployeesByDepartmentTests_Returns_EmptyList()
            {
                List<Employee> mockEmployeeList = new List <Employee>();

                _employeeRepository.GetEmployeesByDepartment(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>()).Returns(mockEmployeeList);

                List<EmployeeDto> result = _employeeService.GetEmployeesByDepartment("MockDepartment", 1, 2).ToList();

                Assert.That(result, Is.EqualTo(mockEmployeeList));
            }
        }
    }
}
