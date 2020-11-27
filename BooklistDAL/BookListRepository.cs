using BooklistLib.InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BooklistDAL
{
    public class BookListRepository
    {
        string connectionString = @"Server = mssql.fhict.local; Database = dbi439215_booklist; User Id = dbi439215_booklist; Password = booklist";
        SqlConnection cnn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlDataReader dataReader;
        string sql = "";

        public BookListRepository()
        {
            cnn = new SqlConnection(connectionString);
        }
    }
}
