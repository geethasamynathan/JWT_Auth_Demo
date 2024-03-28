using JWT_Auth_Demo.Interfaces;
using JWT_Auth_Demo.Models;

namespace JWT_Auth_Demo.Repositories
{
    public class EmployeeRepository : IEmployees
    {
        readonly JWTAuthenticationContext _dbContext = new();
        public EmployeeRepository(JWTAuthenticationContext context)
        {
            _dbContext = context;
        }
        public List<Employee> GetEmployeeDetails()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch
            {
                throw;
            }
        }
        public Employee GetEmployeeById(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);
                if (employee != null)
                    return employee;
                else
                    throw new ArgumentNullException();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Employee AddEmployee(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return employee;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                _dbContext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
                return employee;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public Employee DeleteEmployee(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);
                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    _dbContext.SaveChanges();
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool CheckEmployee(int id)
        {
            return _dbContext.Employees.Any(e => e.EmployeeId == id);
        }

    }
}
