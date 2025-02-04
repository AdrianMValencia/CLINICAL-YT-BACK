using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetByIdQuery;
using CLINICAL.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TakeExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TakeExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permission.ListTakeExams)]
        [HttpGet("ListTakeExams")]
        public async Task<IActionResult> ListTakeExams([FromQuery] GetAllTakeExamQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HasPermission(Permission.TakeExamById)]
        [HttpGet("{takeExamId:int}")]
        public async Task<IActionResult> TakeExamById(int takeExamId)
        {
            var response = await _mediator
                .Send(new GetTakeExamByIdQuery() { TakeExamId = takeExamId });
            return Ok(response);
        }

        [HasPermission(Permission.RegisterTakeExam)]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterTakeExam([FromBody] CreateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.EditTakeExam)]
        [HttpPut("Edit")]
        public async Task<IActionResult> EditTakeExam([FromBody] UpdateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.ChangeStateTakeExam)]
        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateTakeExam([FromBody] ChangeStateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
