using Microsoft.AspNetCore.Authorization;

namespace CLINICAL.Infrastructure.Authentication
{
    public sealed class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(Permission permission): base (policy: permission.ToString())
        {
            
        }
    }
}
