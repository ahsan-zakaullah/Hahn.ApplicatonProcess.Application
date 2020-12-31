using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers.V1
{
    [ApiController, ApiVersion("1.0"), Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeeV1Controller : ControllerBase
    {

        // GET api/<EmployeeController>/5
        [HttpGet("EmployeeById")]
        public string EmployeeById(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost("SaveEmployee")]
        public void SaveEmployee([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("UpdateEmployee")]
        public void UpdateEmployee(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("DeleteEmployee")]
        public void DeleteEmployee(int id)
        {
        }
    }
}
