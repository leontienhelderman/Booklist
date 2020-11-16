using BooklistLib.DTOsDAL;
using BooklistLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib.InterfacesView
{
    public interface IBook
    {
        List<BookModel> GetBooks();

        BookModel GetBook(int id);

        void AddBook(BookModel book);

        void EditBook(BookModel book);

        void DeleteBook(int id);
    }
}
