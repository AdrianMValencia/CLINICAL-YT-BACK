using CLINICAL.Domain.Entities;
using System.Transactions;

namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Analysis> Analysis { get; }
        IExamRepository Exam { get; }
        IPatientRepository Patient { get; }
        IMedicRepository Medic { get; }
        ITakeExamRepository TakeExam { get; }
        TransactionScope BeginTransaction();
    }
}