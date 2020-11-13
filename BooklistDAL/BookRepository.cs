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
            sql = "Select Title, Author, Genre from Book";
            adapter.SelectCommand = new SqlCommand(sql, cnn);
            adapter.SelectCommand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            
            books = (from DataRow book in dataTable.Rows
                         select new BookDTO()
                         {
                             Author = book["Author"].ToString(),
                             Genre = book["Genre"].ToString(),
                             Title = book["Title"].ToString()
                         }).ToList();
            return books;
        }

        public BookDTO GetBook(int Id)
        {
            BookDTO bookDTO = new BookDTO();
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "Select * from Book where Book_Id = @Id";
            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@Id", Id);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                bookDTO.Author = dataReader["Author"].ToString();
                bookDTO.Genre = dataReader["Genre"].ToString();
                bookDTO.Title = dataReader["Title"].ToString();
            }
            return bookDTO;
        }

        public bool Create(BookDTO book)
        {
            bool added = false;
            if (!added)
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
                return true;
            }
            return false;
        }

        public bool Update()
        {
            return true;
        }

        public bool Delete()
        {
            return true;
        }
    }
}

