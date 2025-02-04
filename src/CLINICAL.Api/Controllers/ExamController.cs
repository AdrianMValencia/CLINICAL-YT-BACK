using CLINICAL.Application.UseCase.UseCases.Exam.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery;
using CLINICAL.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permission.ListExams)]
        [HttpGet("ListExams")]
        public async Task<IActionResult> ListExams([FromQuery] GetAllExamQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HasPermission(Permission.ExamById)]
        [HttpGet("{examId:int}")]
        public async Task<IActionResult> ExamById(int examId)
        {
            var response = await _mediator.Send(new GetExamByIdQuery() { ExamId = examId });
            return Ok(response);
        }

        [HasPermission(Permission.RegisterExam)]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterExam([FromBody] CreateExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.EditExam)]
        [HttpPut("Edit")]
        public async Task<IActionResult> EditExam([FromBody] UpdateExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.DeleteExam)]
        [HttpDelete("Remove/{examId:int}")]
        public async Task<IActionResult> DeleteExam(int examId)
        {
            var response = await _mediator.Send(new DeleteExamCommand() { ExamId = examId });
            return Ok(response);
        }
        
        [HasPermission(Permission.ChangeStateExam)]
        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateExam([FromBody] ChangeStateExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}