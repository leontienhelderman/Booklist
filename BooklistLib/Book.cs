using BooklistLib.DTOsDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string Cover { get; }
        public string ExtraInfo { get; }
        public int Rating { get; }
        public string Genre { get; }
        public int Id { get; }
    }
}

