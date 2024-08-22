using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace CLINICAL.Infrastructure.Authentication
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public PermissionAuthorizationHandler(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task HandleRequirementAsync
            (AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            string? userId = context.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userId, out int parsedUderId))
            {
                return;
            }

            using IServiceScope scope = _scopeFactory.CreateScope();

            IPermissionService permissionService = scope.ServiceProvider
                .GetRequiredService<IPermissionService>();

            HashSet<string> permissions = await permissionService
                .GetPermissionAsync(parsedUderId);

            if (permissions.Contains(requirement.Permission))
            {
                context.Succeed(requirement);
            }
        }
    }
}
