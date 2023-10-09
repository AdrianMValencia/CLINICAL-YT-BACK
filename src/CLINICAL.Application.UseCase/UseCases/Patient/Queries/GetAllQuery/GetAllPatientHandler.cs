using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery
{
    public class GetAllPatientHandler : IRequestHandler<GetAllPatientQuery, BaseResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllPatientResponseDto>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllPatientResponseDto>>();

            try
            {
                var patients = await _unitOfWork.Patient.GetAllPatients(SP.uspPatientList);

                if (patients is not null)
                {
                    response.IsSuccess = true;
                    response.Data = patients;
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