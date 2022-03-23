using BookStore.Domain.Entities;

namespace BookStore.Domain.Contracts
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync(); 

        Task<Book> GetBookByIdAsync(string id);

        Task<bool> AddBookAsync(Book book);

        Task<bool> UpdateBookAsync(Book book);

        Task<bool> DeleteBookAsync(string id);  
    }
}
