using BooklistLib;
using BooklistLib.DTOsDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BooklistDAL
{
    public class BookRepository : IBookRepository
    {
        readonly ConnectionManager connection = new ConnectionManager();
        SqlCommand command;
        readonly SqlDataAdapter adapter = new SqlDataAdapter();
        SqlDataReader dataReader;
        string sql = "";

        public BookRepository()
        {
        }

        public List<BookDTO> GetAllBooks()
        {
            List<BookDTO> books;
            using (connection.OpenConnection())
            {
                sql = "SELECT Title, Author, Genre, Id FROM Book";
                adapter.SelectCommand = new SqlCommand(sql, connection.GetConnection);
                adapter.SelectCommand.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                books = (from DataRow book in dataTable.Rows
                         select new BookDTO()
                         {
                             Author = book["Author"].ToString(),
                             Genre = book["Genre"].ToString(),
                             Title = book["Title"].ToString(),
                             Id = (int)book["Id"]
                         }).ToList();
            }
            
            return books;
        }

        public BookDTO GetBook(int id)
        {
            BookDTO bookDTO = new BookDTO();
            using (connection.OpenConnection())
            {
                sql = "SELECT * FROM Book WHERE Id = @Id";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@Id", id);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    bookDTO.Author = dataReader["Author"].ToString();
                    bookDTO.Genre = dataReader["Genre"].ToString();
                    bookDTO.Title = dataReader["Title"].ToString();
                    bookDTO.Id = (int)dataReader["Id"];
                }
            }
            
            return bookDTO;
        }

        public void Create(BookDTO book)
        {
            using (connection.OpenConnection())
            {
                sql = "INSERT INTO book (Title, Author, Genre) VALUES(@Title, @Author, @Genre)";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.ExecuteNonQuery();
            }
                
        }

        public void Update(BookDTO book)
        {
            using (connection.OpenConnection())
            {
                sql = "UPDATE book SET Title = @Title, Author = @Author, Genre = @Genre WHERE Id = @Id";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@Id", book.Id);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (connection.OpenConnection())
            {
                sql = "DELETE FROM book WHERE Id = @Id";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}

