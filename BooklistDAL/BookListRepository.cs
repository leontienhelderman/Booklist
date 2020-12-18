using BooklistLib;
using BooklistLib.DTOs;
using BooklistLib.DTOsDAL;
using BooklistLib.InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BooklistDAL
{
    public class BookListRepository : IBookListRepository
    {
        readonly ConnectionManager connection = new ConnectionManager();
        SqlCommand command;
        readonly SqlDataAdapter adapter = new SqlDataAdapter();
        SqlDataReader dataReader;
        string sql = "";

        public BookListRepository()
        {
            
        }

        public void AddBook(BookListDTO book)
        {
            using (connection.OpenConnection())
            {
                sql = "INSERT INTO BookList (BookId, ListId) VALUES (@BookId, @ListId)";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@BookId", book.BookId);
                command.Parameters.AddWithValue("@ListId", book.ListId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteBook(int id)
        {
            using (connection.OpenConnection())
            {
                sql = "DELETE FROM BookList WHERE BookId = @id";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public List<BookListDTO> GetList(int id)
        {
            List<BookListDTO> books;
            using (connection.OpenConnection())
            {
                sql = "select b.Title, bl.BookId, bl.ListId, l.Name, b.Author " +
                      "From Book b " +
                      "join BookList bl " +
                            "on b.Id = bl.BookId " +
                      "join List l " +
                            "on l.Id = bl.ListId " +
                      "where l.id = @id";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@id", id);
                adapter.SelectCommand = command;
                adapter.SelectCommand.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                books = (from DataRow bookList in dataTable.Rows
                         select new BookListDTO()
                         {
                             Title = bookList["Title"].ToString(),
                             Author = bookList["Author"].ToString(),
                             BookId = (int)bookList["BookId"],
                             ListId = (int)bookList["ListId"],
                             Name = bookList["Name"].ToString()
                         }).ToList();
            }
            return books;
        }

        public BookListDTO GetBookList(int id)
        {
            BookListDTO bookList = new BookListDTO();
            using (connection.OpenConnection())
            {
                sql = "select b.Title, bl.BookId, bl.ListId, l.Name, b.Author " +
                      "From List l " +
                      "join BookList bl " +
                            "on l.Id = bl.ListId " +
                      "join Book b " +
                            "on b.Id = bl.BookId " +
                      "where b.Id = @id";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@id", id);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    bookList.Author = dataReader["Author"].ToString();
                    bookList.Title = dataReader["Title"].ToString();
                    bookList.Name = dataReader["Name"].ToString();
                    bookList.BookId = (int)dataReader["BookId"];
                    bookList.ListId = (int)dataReader["ListId"];
                }

                return bookList;
            }
        }
        
        public BookListDTO CheckIfBookExists(BookListDTO dto)
        {
            BookListDTO newDto = new BookListDTO();
            using (connection.OpenConnection())
            {
                sql = "SELECT b.Id, l.Id FROM Book b, List l WHERE Title = @Title AND Author = @Author AND Name = @Name";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@Title", dto.Title);
                command.Parameters.AddWithValue("@Author", dto.Author);
                command.Parameters.AddWithValue("@Name", dto.Name);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    newDto.BookId = (int)dataReader[0];
                    newDto.ListId = (int)dataReader[1];
                    newDto.Author = dto.Author;
                    newDto.Name = dto.Name;
                    newDto.Title = dto.Title;
                }

                return newDto;
            }
            
        }
    }
}
