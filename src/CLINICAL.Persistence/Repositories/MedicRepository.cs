using CLINICAL.Application.Dtos.Medic;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class MedicRepository : GenericRepository<Medic>, IMedicRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedics(string storedProcedure, object parameter)
        {
            var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var medics = await connection.QueryAsync<GetAllMedicResponseDto>(storedProcedure, param: objParam, 
                commandType: CommandType.StoredProcedure);
            return medics;
        }
    }
}