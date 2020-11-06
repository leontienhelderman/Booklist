using BooklistLib.DTOsDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib.InterfacesView
{
    public interface IBook
    {
        List<BookDTO> ShowBooks();

        Book ShowBook(int id);
    }
}
