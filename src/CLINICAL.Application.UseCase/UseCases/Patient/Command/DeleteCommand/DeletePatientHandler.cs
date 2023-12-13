using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Command.DeleteCommand
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                response.Data = await _unitOfWork.Patient.ExecAsync(SP.uspPatientRemove, request);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_DELETE;
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