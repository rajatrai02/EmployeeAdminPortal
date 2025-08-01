using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")] // localhost:xxxx/api/[employees] here controller is employee
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext dbContext; // assign the field

        public EmployeesController(AppDbContext dbContext) // constructor injecting dbcontext
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()// this will give all the employees details works kind of select * from Employee table
        {
            var allEmployees = dbContext.Employees.ToList(); // this will fetch the result from Employees table

            return Ok(allEmployees); // 200 success response
        }

        [HttpGet]
        [Route("{id=guid}")] // Route parameter in order to get the id in order to search in the database id should be same as the below parameter
        public IActionResult GetEmployeeById(Guid id)  // make sure id is same spelling as the above line
        {
            var employee = dbContext.Employees.Find(id);
            if(employee == null) 
                return NotFound();
            return Ok(employee);
            
        }
        [HttpPost]
        public IActionResult AllEmployee(AddEmployeeDto addEmployeeDto) // to add the new row we need few details from the entity in models, so in function parameter we have to pass the properties of the table which will also cone in the post response
        {
            // so we have to use DTO's for transferring the data from one to another we will call it as "AddEmployeeDto.cs" file in Model folder
            // we will map the addEmployeedDto and we will convert it to the entity that we have as DbContext class only accept the entity
            var employeeEntity = new Employee()
            {  // we will ot fill the id as EntityFrameworkCore handle it for us
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };
            dbContext.Employees.Add(employeeEntity); // this line itself will not add and save data to the database, EntityFramework allow us to save the changes so next line
            dbContext.SaveChanges();
            return Ok(employeeEntity);// response body

        }
        [HttpPut] // for updating the values
        [Route("{id=guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
                return NotFound();

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;
            dbContext.SaveChanges();
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id=guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee=dbContext.Employees.Find(id);
            if(employee == null)
                return NotFound();
            dbContext.Employees.Remove(employee); // which takes the employee entity
            dbContext.SaveChanges(); // every operation except GET method we have to save the changes

            return Ok("The employee details has been deleted");
        }
        
    }
}
