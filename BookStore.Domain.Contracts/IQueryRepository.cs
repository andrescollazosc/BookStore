namespace BookStore.Domain.Contracts
{
    public interface IQueryRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
    }
}
