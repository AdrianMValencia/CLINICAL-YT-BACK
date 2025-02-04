using CLINICAL.Application.UseCase.UseCases.Medic.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery;
using CLINICAL.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permission.ListMedics)]
        [HttpGet("ListMedics")]
        public async Task<IActionResult> ListMedics()
        {
            var response = await _mediator.Send(new GetAllMedicQuery());
            return Ok(response);
        }

        [HasPermission(Permission.MedicById)]
        [HttpGet("{medicId:int}")]
        public async Task<IActionResult> MedicById(int medicId)
        {
            var response = await _mediator
                .Send(new GetMedicByIdQuery() { MedicId = medicId });

            return Ok(response);
        }

        [HasPermission(Permission.RegisterMedic)]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterMedic([FromBody] CreateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.EditMedic)]
        [HttpPut("Edit")]
        public async Task<IActionResult> EditMedic([FromBody] UpdateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.DeleteMedic)]
        [HttpDelete("Remove/{medicId:int}")]
        public async Task<IActionResult> DeleteMedic(int medicId)
        {
            var response = await _mediator.Send(new DeleteMedicCommand() { MedicId = medicId });
            return Ok(response);
        }

        [HasPermission(Permission.ChangeStateMedic)]
        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateMedic([FromBody] ChangeStateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}