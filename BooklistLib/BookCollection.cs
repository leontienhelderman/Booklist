using BooklistLib.DTOsDAL;
using BooklistLib.InterfacesView;
using BooklistLib.Models;
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

        public void AddBook(BookModel book)
        {
            BookDTO bookDTO = ConvertToBookDTO(book);
            _bookRepository.Create(bookDTO);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }

        public void EditBook(BookModel book)
        {
            BookDTO bookDTO = ConvertToBookDTO(book);
            _bookRepository.Update(bookDTO);
        }

        public List<BookModel> GetBooks()
        {
            List<BookDTO> bookDTOs = _bookRepository.GetAllBooks();
            List<BookModel> books = new List<BookModel>();

            foreach(BookDTO bookDTO in bookDTOs)
            {
                BookModel book = ConvertToBookModel(bookDTO);
                books.Add(book);
            }
            
            return books;
        }

        public BookModel GetBook(int id)
        {
            BookDTO bookDTO = new BookDTO(id);
            bookDTO = _bookRepository.GetBook(id);
            BookModel book = ConvertToBookModel(bookDTO);
            return book;           
        }

        public BookModel ConvertToBookModel(BookDTO bookDTO)
        {
            BookModel book = new BookModel()
            {
                Author = bookDTO.Author,
                Title = bookDTO.Title,
                Genre = bookDTO.Genre,
                ExtraInfo = bookDTO.ExtraInfo,
                Cover = bookDTO.Cover,
                Rating = bookDTO.Rating,
                Id = bookDTO.Id                
            };
            return book;
        }

        public BookDTO ConvertToBookDTO(BookModel book)
        {
            BookDTO bookDTO = new BookDTO()
            {
                Author = book.Author,
                Title = book.Title,
                Genre = book.Genre,
                ExtraInfo = book.ExtraInfo,
                Cover = book.Cover,
                Rating = book.Rating,
                Id = book.Id
            };
            return bookDTO;
        }
    }
}
