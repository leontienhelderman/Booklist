using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooklistLib.InterfacesView;
using BooklistLib.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booklist.Controllers
{
    public class ListController : Controller
    {
        private readonly IList _listCollection;
        public ListController(IList listCollection)
        {
            _listCollection = listCollection;
        }

        public IActionResult Index()
        {
            var lists = _listCollection.GetLists();
            return View(lists);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ListModel list)
        {
            _listCollection.AddList(list);
            return RedirectToAction("Index", "List");
        }
    }
}