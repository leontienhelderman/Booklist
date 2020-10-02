using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooklistLib;

namespace Booklist.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var list = _bookRepository.GetAllBooks();

            return View(list);
        }

        public ViewResult Details(int id)
        {
            //var book1 = new Book
            //{
            //    Title = "Title",
            //    Author = "Author",
            //    Cover = "Cover",
            //    ExtraInfo = "ExtraInfo",
            //    Rating = 2
            //};

            var list = new List<Book>();
            list.Add(_bookRepository.GetBook(1));
            
            return View(list);
        }
    }
}