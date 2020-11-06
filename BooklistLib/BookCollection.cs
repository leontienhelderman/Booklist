using BooklistLib.DTOsDAL;
using BooklistLib.InterfacesView;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib
{
    public class BookCollection : IBook
    {
        public IBookRepository _bookRepository;
        public List<BookDTO> Books { get; private set; }
        public BookCollection(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public BookCollection()
        {
            
        }

        public void AddBook(Book book)
        {
            _bookRepository.Create();
            BookDTO bookDTO = new BookDTO(); 
            book = bookDTO;
            BookDTO bookDTO1 = (BookDTO)book;
            Books.Add(bookDTO1);
        }

        public void DeleteBook(Book book)
        {

        }

        public void EditBook(Book book)
        {

        }

        public List<BookDTO> ShowBooks()
        {
            Books = _bookRepository.GetAllBooks();
            return Books;
        }

        public Book ShowBook(int id)
        {
            Book book = new BookDTO(id);
            book = _bookRepository.GetBook(id);
            return book;           
        }
    }
}
