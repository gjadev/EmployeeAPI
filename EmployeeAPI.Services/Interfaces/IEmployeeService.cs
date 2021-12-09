using EmployeeAPI.Services.Dtos;

namespace EmployeeAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetEmployeesByDepartment(string department, int pageNumber, int pageSize);
    }
}
