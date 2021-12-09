using EmployeeAPI.Data;
using EmployeeAPI.Data.Entities;
using EmployeeAPI.Repositories.Interfaces;

namespace EmployeeAPI.Repositories.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public IEnumerable<Employee> GetEmployeesByDepartment(string department, int pageNumber, int pageSize)
        {
            List<Employee>? employees = _employeeDbContext.Employees
                    .Where(employee => employee.Department == department).OrderBy(employee => employee.Name)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
        .           ToList();
            return employees;
        }
    }
}
