using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Biblioteca_api.Application.Commands;
using Biblioteca_api.Application.Dtos;
using Biblioteca_api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_api.Controllers
{
    [Route("api/[controller]")]
    public class LoansController : Controller
    {
        private IMediator mediator;

        public LoansController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetLoans(CancellationToken cancellationToken)
        {
            var query = new GetLoanQuery();
            var loan = await mediator.Send(query, cancellationToken);
            return Ok(loan);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLoans([FromBody] LoanCreateRequestDto request, CancellationToken cancellationToken)
        {
            var command = new CreateLoanCommand()
            {
             ClientId = request.ClientId,
             BookCopyId = request.BookCopyId,
             DueDate = request.DueDate,
            };

            var success = await mediator.Send(command, cancellationToken);

            if (!success)
                return BadRequest("El libro no está disponible.");

            return Ok(new { message = "Préstamo registrado exitosamente" });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoan(int id, [FromBody] LoanUpdateRequestDto request, CancellationToken cancellationToken)
        {

            var command = new UpdateLoanCommand()
            {
                Id = id,
                BookCopyId = request.BookCopyId,
                ClientId = request.ClientId,
                DueDate = request.DueDate
            };
            await mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteLoanCommand()
            {
                Id = id
            };
            await mediator.Send(command, cancellationToken);
            return NoContent();
        }

    }
}

