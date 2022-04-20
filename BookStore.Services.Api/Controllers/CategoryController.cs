using BookStore.Domain.Contracts;
using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Services.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IQueryRepository<Category> _categoryRepository;

        public CategoryController(IQueryRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("categories")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            try
            {
                var result = await _categoryRepository.GetAllAsync();

                return result.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("category/{id}")]
        public async Task<Category> GetById(string id)
        {
            var result = await _categoryRepository.GetByIdAsync(id);

            return result;
        }

    }
}
