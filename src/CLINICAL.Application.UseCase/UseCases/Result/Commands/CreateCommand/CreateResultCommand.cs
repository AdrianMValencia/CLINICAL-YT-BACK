using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CLINICAL.Application.UseCase.UseCases.Result.Commands.CreateCommand
{
    public class CreateResultCommand : IRequest<BaseResponse<bool>>
    {
        public int TakeExamId { get; set; }
        public IEnumerable<CreateResultDetailCommand> ResultDetails { get; set; } = null!;
    }

    public class CreateResultDetailCommand
    {
        public IFormFile? ResultFile { get; set; }
        public int TakeExamDetailId { get; set; }
    }
}
