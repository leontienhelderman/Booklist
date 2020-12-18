using BooklistLib.DTOs;
using BooklistLib.DTOsDAL;
using BooklistLib.InterfacesDAL;
using BooklistLib.InterfacesView;
using BooklistLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib
{
    public class List : IBookList
    {
        public string Name { get; }
        public int Id { get; }
        private readonly IBookListRepository _bookListRepository;

        public List(IBookListRepository bookListRepository)
        {
            _bookListRepository = bookListRepository;
        }

        public List<BookListModel> GetList(int id)
        {
            List<BookListDTO> list = new List<BookListDTO>();
            List<BookListModel> listModel = new List<BookListModel>();

            list = _bookListRepository.GetList(id);
            listModel = ConvertToListBookListModel(list);
            return listModel;
        }

        public BookListModel GetBookList(int id)
        {
            BookListModel model = new BookListModel();
            BookListDTO dto = _bookListRepository.GetBookList(id);

            model = ConvertToBookListModel(dto);
            return model;
        }

        public void AddBook(BookListModel book)
        {
            BookListDTO bookListDTO = new BookListDTO();
            bookListDTO = ConvertToBookListDTO(book);
            bookListDTO = _bookListRepository.CheckIfBookExists(bookListDTO);
            if (bookListDTO.BookId != 0 && bookListDTO.ListId != 0)
            {
                _bookListRepository.AddBook(bookListDTO);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void DeleteBook(int id)
        {
            _bookListRepository.DeleteBook(id);
        }

        private List<BookListModel> ConvertToListBookListModel(List<BookListDTO> dtos)
        {
            List<BookListModel> models = new List<BookListModel>();

            foreach(BookListDTO dto in dtos)
            {
                BookListModel model = new BookListModel
                {
                    ListId = dto.ListId,
                    Author = dto.Author,
                    BookId = dto.BookId,
                    Name = dto.Name,
                    Title = dto.Title
                };
                models.Add(model);
            }
            return models;
        }

        private BookListDTO ConvertToBookListDTO(BookListModel model)
        {
            BookListDTO dto = new BookListDTO
            {
                ListId = model.ListId,
                Author = model.Author,
                BookId = model.BookId,
                Name = model.Name,
                Title = model.Title
            };
            return dto;
        }

        private BookListModel ConvertToBookListModel(BookListDTO dto)
        {
            BookListModel model = new BookListModel
            {
                ListId = dto.ListId,
                Author = dto.Author,
                BookId = dto.BookId,
                Name = dto.Name,
                Title = dto.Title
            };
            return model;
        }
            
    }
}
