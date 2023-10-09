using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;

namespace CLINICAL.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Analysis> Analysis {get;}
        public IExamRepository Exam { get; }
        public IPatientRepository Patient { get; }

        public UnitOfWork(ApplicationDbContext context, IGenericRepository<Analysis> analysis)
        {
            _context = context;
            Analysis = analysis;
            Exam = new ExamRepository(_context);
            Patient = new PatientRepository(_context);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}