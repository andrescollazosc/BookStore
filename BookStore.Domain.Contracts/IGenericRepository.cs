namespace BookStore.Domain.Contracts
{
    public interface IGenericRepository<T> : ICommandRepository<T>, IQueryRepository<T> 
        where T : class
    {
                
    }
}
