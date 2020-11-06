using BooklistLib;
using BooklistLib.DTOsDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BooklistDAL
{
    public class BookRepository : IBookRepository
    {
        private List<BookDTO> _bookList;
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
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "Select * from Book";
            command = new SqlCommand(sql, cnn);
            adapter.SelectCommand = new SqlCommand(sql, cnn);
            adapter.SelectCommand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            
            _bookList = (from DataRow dr in dataTable.Rows
                         select new BookDTO()
                         {
                             Author = dr["Author"].ToString(),
                             Genre = dr["Genre"].ToString(),
                             Title = dr["Title"].ToString()
                         }).ToList();
            return _bookList;
        }


        public BookDTO GetBook(int Id)
        {
            BookDTO bookDTO = new BookDTO();
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "Select * from Book where Book_Id = @Id";
            command.Parameters.AddWithValue("@Id", Id);
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            while (dataReader.Read())
            {
                bookDTO.Author = dataReader["Author"].ToString();
                bookDTO.Genre = dataReader["Genre"].ToString();
                bookDTO.Title = dataReader["Title"].ToString();
            }
            return bookDTO;
        }

        public bool Create()
        {
            bool added = false;
            if (!added)
            {
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "insert into book (Title, Author, Genre, Book_Id) values('PuppetMaster', 'Brandon Mull', 'Fantasy', 2)";
                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
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

