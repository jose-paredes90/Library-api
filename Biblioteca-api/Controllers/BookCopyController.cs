using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Biblioteca_api.Application.Commands;
using Biblioteca_api.Application.Commands.Handlers;
using Biblioteca_api.Application.Dtos;
using Biblioteca_api.Application.Queries;
using Biblioteca_api.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_api.Controllers
{
    [Route("api/[controller]")]
    public class BookCopyController : Controller
    {
        private IMediator mediator;

        public BookCopyController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterBookCopy([FromBody] BookCopyCreateRequestDto request, CancellationToken cancellationToken)
        {
            var command = new CreateBookCopyCommand()
            {
                Barcode = request.Barcode,
                BookId = request.BookId,
            };
            var bookCopy = await mediator.Send(command, cancellationToken);
            return Ok(bookCopy);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetBookCopyQuery();
            var bookCopy = await mediator.Send(query, cancellationToken);
            return Ok(bookCopy);
        }

    }
}

