using JWT_Auth_Demo.Interfaces;
using JWT_Auth_Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWT_Auth_Demo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployees _IEmployees;
        public EmployeesController(IEmployees employees)
        {
            _IEmployees = employees;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await Task.FromResult(_IEmployees.GetEmployeeDetails());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
          var employee=  await Task.FromResult(_IEmployees.GetEmployeeById(id));
            if(employee==null)
            {
                return NotFound();
            }
            else
            {
                return employee;
            }
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _IEmployees.AddEmployee(employee);  
            return await Task.FromResult(employee);

        }
        [HttpPut]
        public async Task<ActionResult<Employee>> PutEmployee(int id,Employee employee)
        {
            if(id!=employee.EmployeeId)
            {
                return BadRequest();
            }
            try
            {
              var updatedEmployee=_IEmployees.UpdateEmployee(employee);
                return Ok(updatedEmployee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
              
            }
        }

        [HttpDelete]
        public  IActionResult DeleteEmployee(int id)
        {
            var employee = _IEmployees.DeleteEmployee(id);
            return Ok(employee);
        }
        private bool EmployeeExists(int id)
        {
            return _IEmployees.CheckEmployee(id);
        }
    }
}
