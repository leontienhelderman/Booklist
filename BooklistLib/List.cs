using BooklistLib.InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib
{
    public class List : IBookListRepository
    {
        public string Name { get; }
        public int Id { get; }
        private List<Book> books { get; }
        private readonly IBookListRepository _bookListRepository;

        public List(IBookListRepository bookListRepository)
        {
            _bookListRepository = bookListRepository;
        }

        public List<Book> AddBook(Book book)
        {

        }
    }
}
