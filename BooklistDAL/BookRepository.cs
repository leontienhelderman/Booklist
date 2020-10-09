using BooklistLib;
using BooklistLib.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooklistDAL
{
    public class BookRepository : IBookRepository
    {
        private List<BookDTO> _bookList;

        public BookRepository()
        {
            _bookList = new List<BookDTO>()
            {
                new BookDTO(){Id = 1, Author = "Brandon Mull", Cover = "whatever", ExtraInfo = "Fun book", Rating = 5, Title = "Fablehaven", Genre = "Fantasy"},
                new BookDTO(){Id = 2, Author = "Brandon Mull", Cover = "whatever", ExtraInfo = "Fun book", Rating = 5, Title = "Puppetmaster", Genre = "Fantasy"},
                new BookDTO(){Id = 3, Author = "Brandon Mull", Cover = "whatever", ExtraInfo = "Fun book", Rating = 5, Title = "Eveningstar", Genre = "Fantasy"}
            };
        }

        public List<BookDTO> GetAllBooks()
        {
            return _bookList;
        }

        public BookDTO GetBook(int Id)
        {
            return _bookList.FirstOrDefault(e => e.Id == Id);
        }

        public void Create()
        {

        }
    }
}
