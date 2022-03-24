using BookStore.Domain.Entities;

namespace BookStore.Domain.Contracts
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(string id);
        Task<bool> AddCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(string id);
    }
}
