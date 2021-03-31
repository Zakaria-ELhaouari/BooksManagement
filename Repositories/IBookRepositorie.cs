using BooksManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksManagement.Repositories
{
    public interface IBookRepositorie
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int id);
        Task<Book> Creat(Book Book);
        Task Update(Book Book);
        Task Delete(int id);
    }
}
