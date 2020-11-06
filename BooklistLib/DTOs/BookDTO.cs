using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib.DTOsDAL
{
    public class BookDTO : Book
    {
        public int Id { get; set; }

        public BookDTO(int id)
        {
            this.Id = id;
        }

        public BookDTO()
        {

        }

        public static explicit operator BookDTO(string v)
        {
            throw new NotImplementedException();
        }
    }
}
