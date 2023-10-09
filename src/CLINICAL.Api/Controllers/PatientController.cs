using CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListPatient")]
        public async Task<IActionResult> ListPatient()
        {
            var response = await _mediator.Send(new GetAllPatientQuery());
            return Ok(response);
        }

        [HttpGet("{patientId:int}")]
        public async Task<IActionResult> PatientById(int patientId)
        {
            var response = await _mediator.Send(new GetPatientByIdQuery() { PatientId = patientId });
            return Ok(response);
        }
    }
}