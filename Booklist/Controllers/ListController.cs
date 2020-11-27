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
            return View(_listCollection.GetLists());
        }

        public ViewResult Details(int id)
        {
            return View(_listCollection.GetList(id)); 
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
        public ViewResult Delete(int id)
        {
            return View(_listCollection.GetList(id));
        }

        [HttpPost]
        public IActionResult Delete(ListModel list)
        {
            _listCollection.DeleteList(list.Id);
            return RedirectToAction("Index", "List");
        }
    }
}