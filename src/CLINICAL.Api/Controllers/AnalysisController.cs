using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;
using CLINICAL.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permission.ListAnalysis)]
        [HttpGet]
        public async Task<IActionResult> ListAnalysis([FromQuery] GetAllAnalysisQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HasPermission(Permission.AnalysisById)]
        [HttpGet("{analysisId:int}")]
        public async Task<IActionResult> AnalysisById(int analysisId)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = analysisId });

            return Ok(response);
        }

        [HasPermission(Permission.RegisterAnalysis)]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAnalysis([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HasPermission(Permission.EditAnalysis)]
        [HttpPut("Edit")]
        public async Task<IActionResult> EditAnalysis([FromBody] UpdateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HasPermission(Permission.RemoveAnalysis)]
        [HttpDelete("Remove/{analysisId:int}")]
        public async Task<IActionResult> RemoveAnalysis(int analysisId)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand() { AnalysisId = analysisId });

            return Ok(response);
        }

        [HasPermission(Permission.ChangeStateAnalysis)]
        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeState([FromBody] ChangeStateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}