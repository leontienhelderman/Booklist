using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();

        Book GetBook(int Id);
    }
}
