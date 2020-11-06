using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooklistLib;
using BooklistLib.DTOsDAL;
using BooklistLib.InterfacesView;

namespace Booklist.Controllers
{
    public class BookController : Controller
    {
        private readonly IBook _bookCollection;

        public BookController(IBook bookCollection)
        {
            _bookCollection = bookCollection;
        }

        public IActionResult Index()
        {
            var list = _bookCollection.ShowBooks();
            return View(list);
        }

        public ViewResult Details(int id)
        {
            BookCollection book = new BookCollection();
            book.ShowBook(id);
            return View(book);
        }
    }
}