using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Analysis> Analysis { get; }
        IExamRepository Exam { get; }
        IPatientRepository Patient { get; }
    }
}