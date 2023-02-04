namespace DevPace.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(long id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(long id, T entity);

        Task<bool> DeleteByIdAsync(long id);
    }
}
