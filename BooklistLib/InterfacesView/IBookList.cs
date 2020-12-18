using BooklistLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib.InterfacesView
{
    public interface IBookList
    {
        List<BookListModel> GetList(int id);

        void AddBook(BookListModel book);

        void DeleteBook(int id);

        BookListModel GetBookList(int id);

    }
}
