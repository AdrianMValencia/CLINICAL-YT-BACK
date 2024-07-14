using CLINICAL.Application.Dtos.Result.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class ResultRepository : GenericRepository<Result>, IResultRepository
    {
        private readonly ApplicationDbContext _context;

        public ResultRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllResultResponseDto>> GetAllResults(string storedProcedure, object parameter)
        {
            var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var results = await connection.QueryAsync<GetAllResultResponseDto>
                (storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return results;
        }

        public async Task<Result> GetResultById(int resultId)
        {
            var connection = _context.CreateConnection;
            var sql = @"SELECT ResultId, TakeExamId
                        FROM Results WHERE ResultId = @ResultId";

            var parameters = new DynamicParameters();
            parameters.Add("ResultId", resultId);

            var result = await connection.QuerySingleOrDefaultAsync<Result>(sql, param: parameters);
            return result;
        }

        public async Task<IEnumerable<ResultDetail>> GetResultDetailByResultId(int resultId)
        {
            var connection = _context.CreateConnection;
            var sql = @"SELECT ResultDetailId, ResultId, ResultFile, TakeExamDetailId
                        FROM ResultDetail WHERE ResultId = @ResultId";

            var parameters = new DynamicParameters();
            parameters.Add("ResultId", resultId);

            var resultDetail = await connection.QueryAsync<ResultDetail>(sql, param: parameters);
            return resultDetail;
        }

        public async Task<Result> RegisterResult(Result result)
        {
            var connection = _context.CreateConnection;
            var sql = @"INSERT INTO Results(TakeExamId, State, AuditCreateDate)
                        VALUES (@TakeExamId, @State, @AuditCreateDate)
                        SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", result.TakeExamId);
            parameters.Add("State", 1);
            parameters.Add("AuditCreateDate", DateTime.Now);

            var resultId = await connection
                .QueryFirstOrDefaultAsync<int>(sql, param: parameters);
            result.ResultId = resultId;
            return result;
        }

        public async Task RegisterResultDetail(ResultDetail resultDetail)
        {
            var connection = _context.CreateConnection;
            var sql = @"INSERT INTO ResultDetail(ResultId, ResultFile, TakeExamDetailId)
                        VALUES(@ResultId, @ResultFile, @TakeExamDetailId)";

            var parameters = new DynamicParameters();
            parameters.Add("ResultId", resultDetail.ResultId);
            parameters.Add("ResultFile", resultDetail.ResultFile);
            parameters.Add("TakeExamDetailId", resultDetail.TakeExamDetailId);

            await connection.ExecuteAsync(sql, param: parameters);
        }

        public async Task EditResult(Result result)
        {
            var connection = _context.CreateConnection;
            var sql = @"UPDATE Results
                        SET TakeExamId = @TakeExamId
                        WHERE ResultId = @ResultId";

            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", result.TakeExamId);
            parameters.Add("ResultId", result.ResultId);

            await connection.ExecuteAsync(sql, param: parameters);
        }

        public async Task EditResultDetail(ResultDetail resultDetail)
        {
            var connection = _context.CreateConnection;
            var sql = @"UPDATE ResultDetail
                        SET ResultFile = @ResultFile,
                            TakeExamDetailId = @TakeExamDetailId
                        WHERE ResultDetailId = @ResultDetailId";

            var parameters = new DynamicParameters();
            parameters.Add("ResultFile", resultDetail.ResultFile);
            parameters.Add("TakeExamDetailId", resultDetail.TakeExamDetailId);
            parameters.Add("ResultDetailId", resultDetail.ResultDetailId);

            await connection.ExecuteAsync(sql, param: parameters);
        }

        public async Task<ResultDetail> GetResultFile(int resultId, int resultDetailId)
        {
            var connection = _context.CreateConnection;
            var sql = @"SELECT ResultDetailId, ResultId, ResultFile, TakeExamDetailId
                        FROM ResultDetail WHERE ResultDetailId = @ResultDetailId
                        AND ResultId = @ResultId";

            var parameters = new DynamicParameters();
            parameters.Add("ResultId", resultId);
            parameters.Add("ResultDetailId", resultDetailId);

            var resultFile = await connection.QuerySingleOrDefaultAsync<ResultDetail>(sql, param: parameters);
            return resultFile;
        }
    }
}
