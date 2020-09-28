using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLibraryStore.Models;
using MyLibraryStore.Repository;

namespace MyLibraryStore.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepos = null;

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepos = bookRepository;
        }

        public IActionResult Index()
        {
            //return Content("This is MVC Index Page");
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

           _bookRepos.AddBook(book);

            

            return RedirectToAction("Index", "Books");
        }
    }
}
