using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib.Models
{
    public class BookListModel
    {
        public int ListId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
