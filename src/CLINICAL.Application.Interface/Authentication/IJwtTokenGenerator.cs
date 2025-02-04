using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
