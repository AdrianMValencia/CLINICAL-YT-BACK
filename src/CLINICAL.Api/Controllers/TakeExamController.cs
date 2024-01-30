using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TakeExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListTakeExams")]
        public async Task<IActionResult> ListTakeExams([FromQuery] GetAllTakeExamQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{takeExamId:int}")]
        public async Task<IActionResult> TakeExamById(int takeExamId)
        {
            var response = await _mediator
                .Send(new GetTakeExamByIdQuery() { TakeExamId = takeExamId });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterTakeExam([FromBody] CreateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditTakeExam([FromBody] UpdateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateExam([FromBody] ChangeStateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
