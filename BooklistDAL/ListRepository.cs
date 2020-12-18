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
        ConnectionManager connection = new ConnectionManager();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlDataReader dataReader;
        string sql = "";

        public ListRepository()
        {
        }

        public void Create(ListDTO list)
        {
            using (connection.OpenConnection())
            {
                sql = "INSERT INTO list (Name) VALUES(@Name)";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@Name", list.Name);
                command.ExecuteNonQuery();
            }

        }

        public void Delete(int id)
        {
            using (connection.OpenConnection())
            {
                sql = "DELETE FROM list WHERE Id = @Id";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }

        }

        public ListDTO GetList(int id)
        {
            ListDTO listDTO = new ListDTO();

            using (connection.OpenConnection())
            {
                sql = "SELECT * FROM list WHERE Id = @id";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@Id", id);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    listDTO.Name = dataReader["Name"].ToString();
                    listDTO.Id = (int)dataReader["Id"];
                }
            }

            return listDTO;
        }

        public List<ListDTO> GetLists()
        {
            List<ListDTO> lists;

            using (connection.OpenConnection())
            {
                sql = "SELECT * FROM list";
                adapter.SelectCommand = new SqlCommand(sql, connection.GetConnection);
                adapter.SelectCommand.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                lists = (from DataRow list in dataTable.Rows
                         select new ListDTO()
                         {
                             Name = list["Name"].ToString(),
                             Id = (int)list["Id"]
                         }).ToList();
            }

            return lists;

        }

        public void Update(ListDTO list)
        {
            using (connection.OpenConnection())
            {
                sql = "UPDATE book SET Name = @Name WHERE Id = @id";
                command = new SqlCommand(sql, connection.GetConnection);
                command.Parameters.AddWithValue("@Name", list.Name);
                command.Parameters.AddWithValue("@Id", list.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}
