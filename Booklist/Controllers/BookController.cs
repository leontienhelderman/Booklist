using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooklistLib;
using BooklistLib.DTOs;

namespace Booklist.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

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
            var list = new List<BookDTO>();
            list.Add(_bookRepository.GetBook(1));
            
            return View(list);
        }
    }
}