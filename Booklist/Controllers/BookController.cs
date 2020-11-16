﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooklistLib.InterfacesView;
using BooklistLib.Models;

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
            var list = _bookCollection.GetBooks();
            return View(list);
        }

        public ViewResult Details(int id)
        {
            BookModel book = _bookCollection.GetBook(id);
            return View(book);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookModel book)
        {
            _bookCollection.AddBook(book);
            return RedirectToAction("Index", "Book");
        }

        [HttpGet]
        public ViewResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(BookModel book)
        {
            _bookCollection.EditBook(book);
            return RedirectToAction("Index", "Book");
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var book = _bookCollection.GetBook(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(BookModel book)
        {
            _bookCollection.DeleteBook(book.Id);
            return RedirectToAction("Index", "Book");
        }
    }
}