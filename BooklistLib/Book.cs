using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib
{
    class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Cover { get; private set; }
        public string ExtraInfo { get; private set; }
        public int Rating { get; private set; }

        public Book()
        {

        }
    }
}

