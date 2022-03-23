using BookStore.Domain.Contracts;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.Infraestructure.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly bookDBContext _context;

        public BookRepository(bookDBContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = await _context.Books.Where(x => x.Active == true).ToListAsync();
            return books;
        }

        public async Task<Book> GetBookByIdAsync(string id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);  
            return book;
        }
        
        public async Task<bool> AddBookAsync(Book book)
        {
            book.Active = true;
            book.Id = Guid.NewGuid().ToString();
            await _context.Books.AddAsync(book);

            return _context.SaveChanges() > 0 ? true : false;
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            var result = await _context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);

            result.Isbn = book.Isbn;
            result.Name = book.Name;
            result.Author = book.Author;
            result.CategoryId= book.CategoryId;
            result.PublicationDate = book.PublicationDate;

            return await _context.SaveChangesAsync() > 0 ? true: false;
            
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            var result = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);   

            result.Active = false;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
