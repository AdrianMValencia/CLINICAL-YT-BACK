using CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery;
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
    }
}
