namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string storedProcedure);
        Task<IEnumerable<T>> GetAllWithPaginationAsync(string storedProcedure, object parameter);
        Task<T> GetByIdAsync(string storedProcedure, object parameter);
        Task<bool> ExecAsync(string storedProcedure, object parameters);
        Task<int> CountAsync(string tableName);
    }
}