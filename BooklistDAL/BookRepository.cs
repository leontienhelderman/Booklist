using BooklistLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooklistDAL
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _bookList;

        public BookRepository()
        {
            _bookList = new List<Book>()
            {
                new Book(){Id = 1, Author = "Brandon Mull", Cover = "whatever", ExtraInfo = "Fun book", Rating = 5, Title = "Fablehaven"},
                new Book(){Id = 2, Author = "Brandon Mull", Cover = "whatever", ExtraInfo = "Fun book", Rating = 5, Title = "Puppetmaster"},
                new Book(){Id = 3, Author = "Brandon Mull", Cover = "whatever", ExtraInfo = "Fun book", Rating = 5, Title = "Eveningstar"}
            };
        }

        public List<Book> GetAllBooks()
        {
            return _bookList;
        }

        public Book GetBook(int Id)
        {
            return _bookList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
