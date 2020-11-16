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
        string connectionString = @"Server = mssql.fhict.local; Database = dbi439215_booklist; User Id = dbi439215_booklist; Password = booklist";
        SqlConnection cnn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlDataReader dataReader;
        string sql = "";

        public BookRepository()
        {
            
        }

        public List<BookDTO> GetAllBooks()
        {
            List<BookDTO> books;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "Select Title, Author, Genre, Book_Id from Book";
            adapter.SelectCommand = new SqlCommand(sql, cnn);
            adapter.SelectCommand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            
            books = (from DataRow book in dataTable.Rows
                         select new BookDTO()
                         {
                             Author = book["Author"].ToString(),
                             Genre = book["Genre"].ToString(),
                             Title = book["Title"].ToString(),
                             Id = (int)book["Book_Id"]
                         }).ToList();
            return books;
        }

        public BookDTO GetBook(int id)
        {
            BookDTO bookDTO = new BookDTO();
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "SELECT * FROM Book WHERE Book_Id = @Id";
            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@Id", id);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                bookDTO.Author = dataReader["Author"].ToString();
                bookDTO.Genre = dataReader["Genre"].ToString();
                bookDTO.Title = dataReader["Title"].ToString();
                bookDTO.Id = (int)dataReader["Book_Id"];
            }
            return bookDTO;
        }

        public void Create(BookDTO book)
        {
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "insert into book (Title, Author, Genre) values(@Title, @Author, @Genre)";
                command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.ExecuteNonQuery();
                cnn.Close();
        }

        public void Update(BookDTO book)
        {
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "UPDATE book SET Title = @Title, Author = @Author, Genre = @Genre WHERE Book_Id = @Id";
                command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@Id", book.Id);
                command.ExecuteNonQuery();
                cnn.Close();
        }

        public void Delete(int id)
        {
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "DELETE FROM book WHERE Book_Id = @Id";
                command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                cnn.Close();
        }
    }
}

