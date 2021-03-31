using BooksManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksManagement.Repositories
{
    public class BookRepositprie : IBookRepositorie
    {
        private readonly BookContext _context;
        public BookRepositprie(BookContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> Get()
        {
            var allBooks = await _context.Books.ToListAsync();
            return allBooks;
            //return await _context.Books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
           var findBook = await _context.Books.FindAsync(id);
           return findBook;
        }

        public async Task<Book> Creat(Book Book)
        {
            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return Book;
        }

        public async Task Delete(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            
        }

        public async Task Update(Book Book)
        {
            _context.Entry(Book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
