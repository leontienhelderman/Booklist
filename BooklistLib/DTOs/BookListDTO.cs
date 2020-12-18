using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace BooklistLib.DTOs
{
    public class BookListDTO
    {
        public int ListId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
