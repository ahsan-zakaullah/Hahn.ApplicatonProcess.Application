using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.Commands.CreateApplicant;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.Queries.GetAllApplicants;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers.V1
{
    [ApiController, ApiVersion("1.0"), Route("api/v{version:apiVersion}/[controller]")]
    public class ApplicantV1Controller : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllApplicantsDto>>> GetAllApplicants()
        {
            var response = await Mediator.Send(new GetAllApplicantsQuery());

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateApplicantDto>> CreateApplicant(CreateApplicantCommand command)
        {
            var response = await Mediator.Send(command);

            return CreatedAtAction(nameof(CreateApplicant), response);
        }
    }
}
