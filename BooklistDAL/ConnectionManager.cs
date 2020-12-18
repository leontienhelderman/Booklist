using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace BooklistDAL
{
    public class ConnectionManager
    {
        private protected string connectionString;
        public string ConnectionString { get => connectionString; }
        private SqlConnection _connection;
        public SqlConnection GetConnection { get => _connection; }


        public ConnectionManager()
        {
            connectionString = GetConnectionString();
        }

        public SqlConnection OpenConnection()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
            return _connection;
        }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
    }
}
