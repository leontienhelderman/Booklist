using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string ExtraInfo { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }
        public string Genre { get; set; }
    }
}
