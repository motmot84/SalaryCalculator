using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprout.Exam.Business.Interface;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.Common.Models.Request;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ISalary _salary;
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeesController(ISalary salary, IEmployeeBusiness employeeBusiness)
        {
            _salary = salary;
            _employeeBusiness = employeeBusiness;
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _employeeBusiness.GetEmployees();

            return Ok(response);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _employeeBusiness.GetEmployee(id);
            
            if (response == null) 
            {
                return NotFound("Employee Not Found!");
            }

            return Ok(response);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id,[FromBody] UpdateEmployeeRequest input)
        {
            var employee = await _employeeBusiness.GetEmployee(id);

            if(employee == null)
            {
                return NotFound("Employee Not Found!");
            }

            var response = await _employeeBusiness.UpdateEmployee(id, input);
            
            return Ok(response);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeRequestBody input)
        {
            var response = _employeeBusiness.CreateEmployee(input);
            var id = response.Id;

            return Created($"/api/employees/{id}", id);
        }


        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeBusiness.GetEmployee(id);

            if (employee == null)
            {
                return NotFound("Employee Not Found!");
            }

            var response = _employeeBusiness.DeleteEmployee(id);

            return Ok(response.Id);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and use Factory pattern
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate(int id, [FromBody] CalculateRequestBody body)
        {
            var result = await Task.FromResult(StaticEmployees.ResultList.FirstOrDefault(m => m.Id == id));

            if (result == null) return NotFound();
            var type = (EmployeeType) result.TypeId;
            var days = 0m;

            switch(type)
            {
                case EmployeeType.Regular:
                    days = body.absentDays;
                    break;
                case EmployeeType.Contractual:
                    days = body.workedDays;
                    break;
                default:
                    return NotFound("Employee Type not found");
            }

            return Ok(_salary.Compute(type, days));
        }

    }
}
