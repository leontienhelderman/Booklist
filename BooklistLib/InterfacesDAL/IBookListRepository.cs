using BooklistLib.DTOs;
using BooklistLib.DTOsDAL;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BooklistLib.InterfacesDAL
{
    public interface IBookListRepository
    {
        List<BookListDTO> GetList(int id);

        void AddBook(BookListDTO book);

        void DeleteBook(int id);

        BookListDTO CheckIfBookExists(BookListDTO book);

        BookListDTO GetBookList(int id);
    }
}
