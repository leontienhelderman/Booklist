using BooklistLib.DTOsDAL;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BooklistLib
{
    public interface IBookRepository
    {
        List<BookDTO> GetAllBooks();

        BookDTO GetBook(int Id);

        bool Create(BookDTO book);

        bool Update();

        bool Delete();
    }
}
