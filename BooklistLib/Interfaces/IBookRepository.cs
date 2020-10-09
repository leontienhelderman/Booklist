using BooklistLib.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib
{
    public interface IBookRepository
    {
        List<BookDTO> GetAllBooks();

        BookDTO GetBook(int Id);
    }
}
