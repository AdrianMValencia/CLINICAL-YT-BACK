using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class GetAnalysisByIdQuery : IRequest<BaseResponse<GetAnalysisByIdResponseDto>>
    {
        public int AnalysisId { get; set; }
    }
}