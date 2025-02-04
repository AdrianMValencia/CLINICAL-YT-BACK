using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatients(string storedProcedure, object parameter);
    }
}