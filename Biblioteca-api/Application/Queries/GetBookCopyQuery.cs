using Biblioteca_api.Application.Dtos;
using MediatR;

namespace Biblioteca_api.Application.Queries
{
    public class GetBookCopyQuery : IRequest<IEnumerable<BookCopyDto>>
    {

    }
}
