using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booklist.Models
{
    public class BookModel
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
