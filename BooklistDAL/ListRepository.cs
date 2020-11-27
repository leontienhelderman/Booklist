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
            cnn = new SqlConnection(connectionString);
        }

        public void Create(ListDTO list)
        {
            cnn.Open();
            sql = "INSERT INTO list (Name) VALUES(@Name)";
            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@Name", list.Name);
            command.ExecuteNonQuery();
            cnn.Close();
        }

        public void Delete(int id)
        {
            cnn.Open();
            sql = "DELETE FROM list WHERE Id = @Id";
            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            cnn.Close();
        }

        public ListDTO GetList(int id)
        {
            ListDTO listDTO = new ListDTO();

            cnn.Open();
            sql = "SELECT * FROM list WHERE Id = @id";
            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@Id", id);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                listDTO.Name = dataReader["Name"].ToString();
                listDTO.Id = (int)dataReader["Id"];
            }
            return listDTO;
        }

        public List<ListDTO> GetLists()
        {
            List<ListDTO> lists;
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

        public void Update(ListDTO list)
        {
            cnn.Open();
            sql = "UPDATE book SET Name = @Name WHERE Id = @id";
            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@Name", list.Name);
            command.Parameters.AddWithValue("@Id", list.Id);
            command.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
