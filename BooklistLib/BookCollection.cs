using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib
{
    class BookCollection
    {
        public List<Book> Books { get; private set; }

        public BookCollection()
        {
            Book book;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void DeleteBook(Book book)
        {

        }

        public void EditBook(Book book)
        {

        }
    }
}
