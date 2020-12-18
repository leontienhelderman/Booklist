using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooklistLib.InterfacesView;
using Microsoft.AspNetCore.Mvc;

namespace Booklist.Controllers
{
    public class BookListController : Controller
    {
        private readonly IBookList _booklist;

        public BookListController(IBookList bookList)
        {
            _booklist = bookList;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}