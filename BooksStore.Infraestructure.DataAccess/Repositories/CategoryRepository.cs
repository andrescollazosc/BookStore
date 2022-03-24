using BookStore.Domain.Contracts;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Infraestructure.DataAccess.Repositories
{
    public class CategoryRepository : IQueryRepository<Category>
    {
        private readonly bookDBContext _bookDBContext;

        public CategoryRepository(bookDBContext bookDBContext)
        {
            _bookDBContext = bookDBContext;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _bookDBContext.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetByIdAsync(string id)
        {
            var category = await _bookDBContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            return category;
        }

    }
}
