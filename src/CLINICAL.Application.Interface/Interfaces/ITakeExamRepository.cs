using CLINICAL.Application.Dtos.TakeExam.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Interfaces
{
    public interface ITakeExamRepository : IGenericRepository<TakeExam>
    {
        Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExams(string storedProcedure, object parameter);
        Task<TakeExam> GetTakeExamById(int takeExamId);
        Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId);
        Task<TakeExam> RegisterTakeExam(TakeExam takeExam);
        Task RegisterTakeExamDetail(TakeExamDetail takeExamDetail);
        Task EditTakeExam(TakeExam takeExam);
        Task EditTakeExamDetail(TakeExamDetail takeExamDetail);
        Task<bool> ChangeStateTakeExam(TakeExam takeExam);
    }
}
