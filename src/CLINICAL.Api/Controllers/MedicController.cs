using CLINICAL.Application.UseCase.UseCases.Medic.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListMedics")]
        public async Task<IActionResult> ListMedics()
        {
            var response = await _mediator.Send(new GetAllMedicQuery());
            return Ok(response);
        }

        [HttpGet("{medicId:int}")]
        public async Task<IActionResult> MedicById(int medicId)
        {
            var response = await _mediator
                .Send(new GetMedicByIdQuery() { MedicId = medicId });

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterMedic([FromBody] CreateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditMedic([FromBody] UpdateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Remove/{medicId:int}")]
        public async Task<IActionResult> DeleteMedic(int medicId)
        {
            var response = await _mediator.Send(new DeleteMedicCommand() { MedicId = medicId });
            return Ok(response);
        }

        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateMedic([FromBody] ChangeStateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}