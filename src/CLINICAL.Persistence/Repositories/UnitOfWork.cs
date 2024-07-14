using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using System.Transactions;

namespace CLINICAL.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Analysis> Analysis {get;}
        public IExamRepository Exam { get; }
        public IPatientRepository Patient { get; }
        public IMedicRepository Medic { get; }
        public ITakeExamRepository TakeExam {  get; }
        public IResultRepository Result { get; }
        public IUserRepository User {  get; }

        public UnitOfWork(ApplicationDbContext context, IGenericRepository<Analysis> analysis)
        {
            _context = context;
            Analysis = analysis;
            Exam = new ExamRepository(_context);
            Patient = new PatientRepository(_context);
            Medic = new MedicRepository(_context);
            TakeExam = new TakeExamRepository(_context);
            Result = new ResultRepository(_context);
            User = new UserRepository(_context);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public TransactionScope BeginTransaction()
        {
            var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            return transaction;
        }
    }
}