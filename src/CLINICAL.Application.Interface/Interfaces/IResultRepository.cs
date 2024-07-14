using CLINICAL.Application.Dtos.Result.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IResultRepository : IGenericRepository<Result>
    {
        Task<IEnumerable<GetAllResultResponseDto>> GetAllResults(string storedProcedure, object parameter);
        Task<Result> GetResultById(int resultId);
        Task<IEnumerable<ResultDetail>> GetResultDetailByResultId(int resultId);
        Task<Result> RegisterResult(Result result);
        Task RegisterResultDetail(ResultDetail resultDetail);
        Task EditResult(Result result);
        Task EditResultDetail(ResultDetail resultDetail);
        Task<ResultDetail> GetResultFile(int resultId, int resultDetailId);
    }
}
