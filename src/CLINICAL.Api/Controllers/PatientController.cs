using CLINICAL.Application.UseCase.UseCases.Patient.Command.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Command.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Command.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Command.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery;
using CLINICAL.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permission.ListPatient)]
        [HttpGet("ListPatient")]
        public async Task<IActionResult> ListPatient()
        {
            var response = await _mediator.Send(new GetAllPatientQuery());
            return Ok(response);
        }

        [HasPermission(Permission.PatientById)]
        [HttpGet("{patientId:int}")]
        public async Task<IActionResult> PatientById(int patientId)
        {
            var response = await _mediator.Send(new GetPatientByIdQuery() { PatientId = patientId });
            return Ok(response);
        }

        [HasPermission(Permission.RegisterPatient)]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterPatient([FromBody] CreatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.EditPatient)]
        [HttpPut("Edit")]
        public async Task<IActionResult> EditPatient([FromBody] UpdatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.DeletePatient)]
        [HttpDelete("Remove/{patientId:int}")]
        public async Task<IActionResult> DeletePatient(int patientId)
        {
            var response = await _mediator.Send(new DeletePatientCommand() { PatientId = patientId });
            return Ok(response);
        }

        [HasPermission(Permission.ChangeStatePatient)]
        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStatePatient([FromBody] ChangeStatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}