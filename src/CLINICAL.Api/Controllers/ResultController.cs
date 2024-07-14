using CLINICAL.Application.UseCase.UseCases.Result.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Result.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Result.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Result.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListResults")]
        public async Task<IActionResult> ListResults([FromQuery] GetAllResultQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{resultId:int}")]
        public async Task<IActionResult> ResultById(int resultId)
        {
            var response = await _mediator.Send(new GetResultByIdQuery() { ResultId = resultId });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterResult([FromForm] CreateResultCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditResult([FromForm] UpdateResultCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
