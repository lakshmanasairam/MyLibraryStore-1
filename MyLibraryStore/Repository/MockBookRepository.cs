using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MyLibraryStore.Models;

namespace MyLibraryStore.Repository
{
    public class MockBookRepository : IBookRepository
    {
        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            var books = GetBooks();
            return books.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>{
                new Book{Id=1, BookName="Wings of Fire", Author="APJ Kalam", ISBN="IS45612", PublishedDate=Convert.ToDateTime("10/12/2015")},
                new Book{Id=2, BookName="World India", Author="Rufson", ISBN="IS123456", PublishedDate=Convert.ToDateTime("05/05/2019")},
                new Book{Id=3, BookName="2 States", Author="Chetan Bhagat", ISBN="I789456", PublishedDate=Convert.ToDateTime("06/12/2018")},
            };
        }

        public void UpdateBook(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
