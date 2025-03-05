using MediatR;

namespace Biblioteca_api.Application.Commands
{
    public class UpdateBookCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
