using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            return await connection
                .QueryAsync<T>(storedProcedure, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await connection
                .QuerySingleOrDefaultAsync<T>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> ExecAsync(string storedProcedure, object parameters)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameters);
            var recordAffected = await connection
                .ExecuteAsync(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return recordAffected > 0;
        }

        public async Task<IEnumerable<T>> GetAllWithPaginationAsync(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await connection
                .QueryAsync<T>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CountAsync(string tableName)
        {
            using var connection = _context.CreateConnection;
            var query = $"SELECT COUNT(1) FROM {tableName}";

            var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;
        }
    }
}