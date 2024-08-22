
using CLINICAL.Persistence.Context;
using Dapper;

namespace CLINICAL.Infrastructure.Authentication;

public class PermissionService : IPermissionService
{
    private readonly ApplicationDbContext _context;

    public PermissionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HashSet<string>> GetPermissionAsync(int userId)
    {
        using var connection = _context.CreateConnection;

        var query = @"
            SELECT 
	            p.Name
            FROM Users u
            INNER JOIN Roles r ON u.RoleId = r.RoleId
            INNER JOIN RolePermissions rp ON r.RoleId = rp.RoleId
            INNER JOIN Permissions p ON rp.PermissionId = p.PermissionId
            WHERE u.UserId = @UserId";

        var parameters = new DynamicParameters();
        parameters.Add("UserId", userId);

        var result = await connection.QueryAsync<string>(query, parameters);

        var permissions = new HashSet<string>(result);

        return permissions;
    }
}
