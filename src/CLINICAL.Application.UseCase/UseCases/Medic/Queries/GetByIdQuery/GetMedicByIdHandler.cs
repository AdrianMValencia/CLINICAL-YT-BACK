using AutoMapper;
using CLINICAL.Application.Dtos.Medic;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery
{
    public class GetMedicByIdHandler : IRequestHandler<GetMedicByIdQuery,
        BaseResponse<GetMedicByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMedicByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetMedicByIdResponseDto>> Handle(GetMedicByIdQuery request,
            CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetMedicByIdResponseDto>();

            try
            {
                var medic = await _unitOfWork.Medic.GetByIdAsync(SP.uspMedicById, request);

                if (medic is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetMedicByIdResponseDto>(medic);
                response.Message = GlobalMessages.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}