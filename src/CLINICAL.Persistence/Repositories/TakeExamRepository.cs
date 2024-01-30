using CLINICAL.Application.Dtos.TakeExam.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class TakeExamRepository : GenericRepository<TakeExam>, ITakeExamRepository
    {
        private readonly ApplicationDbContext _context;

        public TakeExamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExams(string storedProcedure, object parameter)
        {
            var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var takeExams = await connection
                .QueryAsync<GetAllTakeExamResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return takeExams;
        }

        public async Task<TakeExam> GetTakeExamById(int takeExamId)
        {
            var connection = _context.CreateConnection;
            var sql = @"SELECT TakeExamId, PatientId, MedicId FROM TakeExam WHERE TakeExamId = @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);

            var takeExam = await connection.QuerySingleOrDefaultAsync<TakeExam>(sql, param: parameters);
            return takeExam;
        }

        public async Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId)
        {
            var connection = _context.CreateConnection;
            var sql = @"SELECT TakeExamDetailId, TakeExamId, ExamId, AnalysisId 
                        FROM TakeExamDetail WHERE TakeExamId = @TakeExamId";

            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);

            var takeExamDetail = await connection.QueryAsync<TakeExamDetail>(sql, param: parameters);
            return takeExamDetail;
        }

        public async Task<TakeExam> RegisterTakeExam(TakeExam takeExam)
        {
            var connection = _context.CreateConnection;
            var sql = @"INSERT INTO TakeExam(PatientId, MedicId, State, AuditCreateDate)
                        VALUES (@PatientId, @MedicId, @State, @AuditCreateDate)
                        SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var parameters = new DynamicParameters();
            parameters.Add("PatientId", takeExam.PatientId);
            parameters.Add("MedicId", takeExam.MedicId);
            parameters.Add("State", 1);
            parameters.Add("AuditCreateDate", DateTime.Now);

            var takeExamId = await connection.QuerySingleOrDefaultAsync<int>(sql, param: parameters);
            takeExam.TakeExamId = takeExamId;
            return takeExam;
        }

        public async Task RegisterTakeExamDetail(TakeExamDetail takeExamDetail)
        {
            var connection = _context.CreateConnection;
            var sql = @"INSERT INTO TakeExamDetail(TakeExamId, ExamId, AnalysisId)
                        VALUES (@TakeExamId, @ExamId, @AnalysisId)";

            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamDetail.TakeExamId);
            parameters.Add("ExamId", takeExamDetail.ExamId);
            parameters.Add("AnalysisId", takeExamDetail.AnalysisId);

            await connection.ExecuteAsync(sql, param: parameters);
        }

        public async Task EditTakeExam(TakeExam takeExam)
        {
            var connection = _context.CreateConnection;
            var sql = @"UPDATE TakeExam
                        SET PatientId = @PatientId,
                            MedicId = @MedicId
                        WHERE TakeExamId = @TakeExamId";

            var parameters = new DynamicParameters();
            parameters.Add("PatientId", takeExam.PatientId);
            parameters.Add("MedicId", takeExam.MedicId);
            parameters.Add("TakeExamId", takeExam.TakeExamId);

            await connection.ExecuteAsync(sql, param: parameters);
        }

        public async Task EditTakeExamDetail(TakeExamDetail takeExamDetail)
        {
            var connection = _context.CreateConnection;
            var sql = @"UPDATE TakeExamDetail
                        SET ExamId = @ExamId,
                            AnalysisId = @AnalysisId
                        WHERE TakeExamDetailId = @TakeExamDetailId";

            var parameters = new DynamicParameters();
            parameters.Add("ExamId", takeExamDetail.ExamId);
            parameters.Add("AnalysisId", takeExamDetail.AnalysisId);
            parameters.Add("TakeExamDetailId", takeExamDetail.TakeExamDetailId);

            await connection.ExecuteAsync(sql, param: parameters);
        }

        public async Task<bool> ChangeStateTakeExam(TakeExam takeExam)
        {
            var connection = _context.CreateConnection;
            var sql = @"UPDATE TakeExam
                        SET State = @State
                        WHERE TakeExamId = @TakeExamId";

            var parameters = new DynamicParameters();
            parameters.Add("State", takeExam.State);
            parameters.Add("TakeExamId", takeExam.TakeExamId);

            var recordsAffected = await connection.ExecuteAsync(sql, param: parameters);
            return recordsAffected > 0;
        }
    }
}
