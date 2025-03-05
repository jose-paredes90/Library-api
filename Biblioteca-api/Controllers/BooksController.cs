using Biblioteca_api.Application.Commands;
using Biblioteca_api.Application.Dtos;
using Biblioteca_api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_api.Controllers
{
    [Route("api/[controller]")]
    public class BooksController: Controller
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto request, CancellationToken cancellationToken)
        {
            var command = new CreateBookCommand()
            {
                Author = request.Author,
                Category = request.Category,
                Price = request.Price,
                Title = request.Title,
            };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBookQuery(), cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] CreateBookDto request, CancellationToken cancellationToken) {

            var command = new UpdateBookCommand()
            {
                Author = request.Author,
                Category = request.Category,
                Price = request.Price,
                Title = request.Title,
                Id = id
            };

            
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteBookCommand { Id = id }, cancellationToken);
            return NoContent();
        }

    }
}
