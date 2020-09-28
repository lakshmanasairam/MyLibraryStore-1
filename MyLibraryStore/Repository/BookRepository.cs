using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MyLibraryStore.Data;
using MyLibraryStore.Models;

namespace MyLibraryStore.Repository
{
    //Step 4
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext _dbContext = null;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBook(Book book)
        {
            _dbContext.Books.Add(book);
           _dbContext.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new NullReferenceException(id.ToString());
            }
        }

        public Book GetBookById(int id)
        {
            return _dbContext.Books.ToList().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _dbContext.Books.ToList();
        }

        public void UpdateBook(int id, Book book)
        {
            var bookInDb = _dbContext.Books.SingleOrDefault(b => b.Id == id);
            if (bookInDb != null)
            {
                bookInDb.BookName = book.BookName;
                bookInDb.Author = book.Author;
                bookInDb.PublishedDate = book.PublishedDate;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new NullReferenceException(id.ToString());
            }
        }
    }
}
