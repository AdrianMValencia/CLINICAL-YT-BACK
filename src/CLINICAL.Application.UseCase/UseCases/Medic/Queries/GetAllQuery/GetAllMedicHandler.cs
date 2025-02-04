using CLINICAL.Application.Dtos.Medic;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetAllQuery
{
    public class GetAllMedicHandler : IRequestHandler<GetAllMedicQuery,
        BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMedicHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>> Handle(GetAllMedicQuery request,
            CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>();

            try
            {
                var count = await _unitOfWork.Medic.CountAsync(TB.Medics);
                var medics = await _unitOfWork.Medic.GetAllMedics(SP.uspMedicList, request);

                if (medics is not null)
                {
                    response.IsSuccess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.Data = medics;
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