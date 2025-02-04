using CLINICAL.Application.Dtos.Result.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Result.Queries.GetAllQuery
{
    public class GetAllResultHandler : IRequestHandler<GetAllResultQuery, BasePaginationResponse<IEnumerable<GetAllResultResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllResultHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllResultResponseDto>>> Handle(GetAllResultQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllResultResponseDto>>();

            try
            {
                var count = await _unitOfWork.Result.CountAsync(TB.Results);
                var results = await _unitOfWork.Result.GetAllResults(SP.uspResultList, request);

                if (results is not null)
                {
                    response.IsSuccess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.Data = results;
                    response.Message = GlobalMessages.MESSAGE_QUERY;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
