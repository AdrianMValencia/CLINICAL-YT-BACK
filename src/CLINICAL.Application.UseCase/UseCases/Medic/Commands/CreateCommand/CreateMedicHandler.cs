using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Commands.CreateCommand
{
    public class CreateMedicHandler : IRequestHandler<CreateMedicCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateMedicCommand request, 
            CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var medic = _mapper.Map<Entity.Medic>(request);
                var parameters = medic.GetPropertiesWithValues();

                response.Data = await _unitOfWork.Medic.ExecAsync(SP.uspMedicRegister, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_SAVE;
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