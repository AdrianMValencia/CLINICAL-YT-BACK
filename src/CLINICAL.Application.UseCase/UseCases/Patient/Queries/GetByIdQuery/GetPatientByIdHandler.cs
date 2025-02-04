using AutoMapper;
using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery
{
    public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, BaseResponse<GetPatientByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetPatientByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetPatientByIdResponseDto>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetPatientByIdResponseDto>();

            try
            {
                var patient = await _unitOfWork.Patient.GetByIdAsync(SP.uspPatientById, request);

                if (patient is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetPatientByIdResponseDto>(patient);
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