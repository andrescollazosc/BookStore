using AutoMapper;
using BookStore.Domain.Contracts;
using BookStore.Domain.Entities;
using BookStore.Services.Dto.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IGenericRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            this._mapper = mapper;
        }

        [HttpGet("books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReadDto>>> GetBooks() {
            var result = await _bookRepository.GetAllAsync();

            return result.Select(book => _mapper.Map<ReadDto>(book)).ToList();
        }


        [HttpGet("book/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadDto>> GetBook(string id)
        {
            try
            {
                var result = await _bookRepository.GetByIdAsync(id);

                if (result is null)
                    return NotFound();

                return _mapper.Map<ReadDto>(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReadDto>> Add(CreateDto createDto)
        {
            try
            {
                var result = await _bookRepository.AddAsync(_mapper.Map<Book>(createDto));

                if (result is null)
                    return NotFound();

                return _mapper.Map<ReadDto>(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReadDto>> Update(UpdateDto updateDto)
        {
            try
            {
                var result = await _bookRepository.UpdateAsync(_mapper.Map<Book>(updateDto));

                if (result is null)
                    return BadRequest();

                return _mapper.Map<ReadDto>(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
