using JWT_Auth_Demo.Models;

namespace JWT_Auth_Demo.Interfaces
{
    public interface IEmployees
    {
        public List<Employee> GetEmployeeDetails();
        public Employee GetEmployeeById(int id);
        public bool CheckEmployee(int id);
        public Employee AddEmployee(Employee employee);
        public Employee UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(int id);

    }
}
