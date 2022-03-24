using BookStore.Domain.Contracts;
using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public BookController(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Book>>> GetBooks() {
            var result = await _bookRepository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("book/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> GetBook(string id)
        {
            try
            {
                var result = await _bookRepository.GetByIdAsync(id);

                if (result is null)
                    return NotFound();


                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }


    }
}
