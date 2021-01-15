using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooklistLib;
using BooklistLib.InterfacesView;
using BooklistLib.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booklist.Controllers
{
    public class ListController : Controller
    {
        private readonly IList _listCollection;
        private readonly IBookList _bookList;
        public ListController(IList listCollection, IBookList bookList)
        {
            _listCollection = listCollection;
            _bookList = bookList;
        }

        public IActionResult Index()
        {
            return View(_listCollection.GetLists());
        }

        public ViewResult Details(int id)
        {
            return View(_bookList.GetList(id)); 
        }

        [HttpGet]
        public ViewResult CreateList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateList(ListModel list)
        {
            _listCollection.AddList(list);
            return RedirectToAction("Index", "List");
        }

        [HttpGet]
        public ViewResult CreateBookList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBookList(BookListModel book)
        {
            _bookList.AddBook(book);
            return RedirectToAction("Index", "List");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            return View(_listCollection.GetList(id));
        }

        [HttpPost]
        public IActionResult Edit(ListModel list)
        {
            _listCollection.EditList(list);
            return RedirectToAction("Index", "List");
        }

        [HttpGet]
        public ViewResult DeleteList(int id)
        {
            return View(_listCollection.GetList(id));
        }

        [HttpPost]
        public IActionResult DeleteList(ListModel list)
        {
            _listCollection.DeleteList(list.Id);
            return RedirectToAction("Index", "List");
        }

        [HttpGet]
        public ViewResult DeleteBook(int id)
        {
            var model = _bookList.GetBookList(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteBook(BookListModel model)
        {
            _bookList.DeleteBook(model.BookId);
            return RedirectToAction("Index", "List");
        }
    }
}