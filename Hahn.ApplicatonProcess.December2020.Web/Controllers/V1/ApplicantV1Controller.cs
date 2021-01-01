using System;
using System.Threading.Tasks;
using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Query;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Web.Models.v1;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers.V1
{
    [ApiController, ApiVersion("1.0"), Route("api/v{version:apiVersion}/[controller]")]
    public class ApplicantV1Controller : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ApplicantV1Controller(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
      
        /// <summary>
        /// Action to create a new applicant in the database.
        /// </summary>
        /// <param name="createApplicantModel">Model to create a new applicant</param>
        /// <returns>Returns the created applicant</returns>
        /// /// <response code="200">Returned if the applicant was created</response>
        /// /// <response code="400">Returned if the model couldn't be parsed or the applicant couldn't be saved</response>
        /// /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<Applicant>> Applicant([FromBody] CreateApplicantModel createApplicantModel)
        {
            try
            {
                return await _mediator.Send(new CreateApplicantCommand
                {
                    Applicant = _mapper.Map<Applicant>(createApplicantModel)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Action to update an existing applicant
        /// </summary>
        /// <param name="updateApplicantModel">Model to update an existing applicant</param>
        /// <returns>Returns the updated applicant</returns>
        /// /// <response code="200">Returned if the applicant was updated</response>
        /// /// <response code="400">Returned if the model couldn't be parsed or the applicant couldn't be found</response>
        /// /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPut]
        public async Task<ActionResult<Applicant>> Applicant([FromBody] UpdateApplicantModel updateApplicantModel)
        {
            try
            {
                var applicant = await _mediator.Send(new GetApplicantByIdQuery
                {
                    Id = updateApplicantModel.Id
                });

                if (applicant == null)
                {
                    return BadRequest($"No applicant found with the id {updateApplicantModel.Id}");
                }

                return await _mediator.Send(new UpdateApplicantCommand
                {
                    Applicant = _mapper.Map(updateApplicantModel, applicant)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
