using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib.DTOsDAL
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string ExtraInfo { get; set; }
        public int Rating { get; set; }
        public string Genre { get; set; }

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
