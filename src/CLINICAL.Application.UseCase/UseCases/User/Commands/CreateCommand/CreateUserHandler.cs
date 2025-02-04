using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using Entity = CLINICAL.Domain.Entities;
using BC = BCrypt.Net.BCrypt;
using CLINICAL.Utilities.HelperExtensions;
using CLINICAL.Utilities.Constants;

namespace CLINICAL.Application.UseCase.UseCases.User.Commands.CreateCommand
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var user = _mapper.Map<Entity.User>(request);
                user.Password = BC.HashPassword(user.Password);
                var parameters = user.GetPropertiesWithValues();

                response.Data = await _unitOfWork.User.ExecAsync(SP.uspUserRegister, parameters);

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
