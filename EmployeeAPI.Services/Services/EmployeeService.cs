using AutoMapper;
using EmployeeAPI.Data.Entities;
using EmployeeAPI.Repositories.Interfaces;
using EmployeeAPI.Services.Dtos;
using EmployeeAPI.Services.Interfaces;

namespace EmployeeAPI.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public IEnumerable<EmployeeDto> GetEmployeesByDepartment(string department, int pageNumber, int pageSize)
        {
            IEnumerable<Employee> employees = _employeeRepository.GetEmployeesByDepartment(department, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
        }
    }
}
