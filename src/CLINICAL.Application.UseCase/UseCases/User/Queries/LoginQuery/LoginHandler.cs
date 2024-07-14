using CLINICAL.Application.Interface.Authentication;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;
using BC = BCrypt.Net.BCrypt;

namespace CLINICAL.Application.UseCase.UseCases.User.Queries.LoginQuery
{
    public class LoginHandler : IRequestHandler<LoginQuery, BaseResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<BaseResponse<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<string>();

            try
            {
                var user = await _unitOfWork.User.GetUserByEmailAsync(SP.uspUserByEmail, request.Email!);

                if (user is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_TOKEN_ERROR;
                    return response;
                }

                if (!BC.Verify(request.Password, user.Password))
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_ERROR_PASSWORD;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _jwtTokenGenerator.GenerateToken(user);
                response.Message = GlobalMessages.MESSAGE_TOKEN;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
