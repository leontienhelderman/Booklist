using BooklistLib;
using BooklistLib.DTOs;
using BooklistLib.InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BooklistDAL
{
    public class ListRepository : IListRepository
    {
        string connectionString = @"Server = mssql.fhict.local; Database = dbi439215_booklist; User Id = dbi439215_booklist; Password = booklist";
        SqlConnection cnn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlDataReader dataReader;
        string sql = "";

        public ListRepository()
        {

        }

        public void Create(ListDTO list)
        {
            try
            {
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "INSERT INTO list (Name) VALUES(@Name)";
                command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@Name", list.Name);
                command.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {
                throw new NotImplementedException();
            }
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ListDTO GetList(int id)
        {
            throw new NotImplementedException();
        }

        public List<ListDTO> GetLists()
        {
            try
            {
                List<ListDTO> lists;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "SELECT * FROM list";
                adapter.SelectCommand = new SqlCommand(sql, cnn);
                adapter.SelectCommand.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                lists = (from DataRow list in dataTable.Rows
                         select new ListDTO()
                         {
                             Name = list["Name"].ToString(),
                             Id = (int)list["Id"]
                         }).ToList();
                return lists;
            }
            catch
            {
                throw new NotImplementedException();
            }
            
        }

        public void Update(ListDTO list)
        {
            throw new NotImplementedException();
        }
    }
}
