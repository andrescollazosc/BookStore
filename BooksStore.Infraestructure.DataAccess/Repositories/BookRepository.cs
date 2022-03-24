using BookStore.Domain.Contracts;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Infraestructure.DataAccess.Repositories
{
    public class BookRepository : IGenericRepository<Book>
    {
        private readonly bookDBContext _context;

        public BookRepository(bookDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Book entity)
        {
            entity.Active = true;
            entity.Id = Guid.NewGuid().ToString();
            await _context.Books.AddAsync(entity);

            return _context.SaveChanges() > 0 ? true : false;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            result.Active = false;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var books = await _context.Books.Where(x => x.Active == true).ToListAsync();

            return books;
        }

        public async Task<Book> GetByIdAsync(string id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }

        public async Task<bool> UpdateAsync(Book entity)
        {
            var result = await _context.Books.FirstOrDefaultAsync(x => x.Id == entity.Id);

            result.Isbn = entity.Isbn;
            result.Name = entity.Name;
            result.Author = entity.Author;
            result.CategoryId = entity.CategoryId;
            result.PublicationDate = entity.PublicationDate;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

    }
}
