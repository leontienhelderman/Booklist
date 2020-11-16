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

        BookDTO GetBook(int id);

        void Create(BookDTO book);

        void Update(BookDTO book);

        void Delete(int id);
    }
}
