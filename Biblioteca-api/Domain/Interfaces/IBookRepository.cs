using Biblioteca_api.Domain.Entities;

namespace Biblioteca_api.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task Add(Books permiso);
        Task Update(Books permiso);
        Task<Books> GetById(int id);
        Task<IEnumerable<Books>> GetAll();
        Task Delete(Books book);
    }
}
