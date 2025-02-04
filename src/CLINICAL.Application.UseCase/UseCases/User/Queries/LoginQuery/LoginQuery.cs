using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.User.Queries.LoginQuery
{
    public class LoginQuery : IRequest<BaseResponse<string>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
