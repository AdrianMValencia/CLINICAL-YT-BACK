using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CLINICAL.Application.UseCase.UseCases.Result.Commands.UpdateCommand
{
    public class UpdateResultCommand : IRequest<BaseResponse<bool>>
    {
        public int ResultId { get; set; }
        public int TakeExamId { get; set; }
        public IEnumerable<UpdateResultDetailCommand> ResultDetails { get; set; } = null!;
    }
    public class UpdateResultDetailCommand
    {
        public int ResultDetailId { get; set; }
        public int ResultId { get; set; }
        public IFormFile? ResultFile { get; set; }
        public int TakeExamDetailId { get; set; }
    }
}
