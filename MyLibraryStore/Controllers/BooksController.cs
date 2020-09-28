using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLibraryStore.Models;
using MyLibraryStore.Repository;
using MyLibraryStore.ViewModel;

namespace MyLibraryStore.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository _bookRepos = null;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepos = bookRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepos.GetBooks();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepos.GetBookById(id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new BookViewModel
            {
                Genre = Genres()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookViewModel
                {
                    Genre = Genres()
                };
                return View(viewModel);
            }

            _bookRepos.AddBook(book);

            return RedirectToAction("Index", "Books");
        }

        public IActionResult NewAction()
        {
            return View();
        }

        public List<SelectListItem> Genres()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Text="Fiction", Value="Fiction"},
                new SelectListItem {Text="Romance", Value="Romance"},
                new SelectListItem {Text="Horror", Value="Horror"},
                new SelectListItem {Text="AutoBiography", Value="AutoBiography"},
                new SelectListItem {Text="Thriller", Value="Thriller"}
            };
        }
    }
}
