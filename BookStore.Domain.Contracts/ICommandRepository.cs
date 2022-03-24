namespace BookStore.Domain.Contracts
{
    public interface ICommandRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);
    }
}
