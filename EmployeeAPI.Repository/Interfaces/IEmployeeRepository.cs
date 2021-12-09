using EmployeeAPI.Data.Entities;

namespace EmployeeAPI.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployeesByDepartment(string department, int pageNumber, int pageSize);
    }
}
