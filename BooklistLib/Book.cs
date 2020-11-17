using BooklistLib.DTOsDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string ExtraInfo { get; set; }
        public int Rating { get; set; }
        public string Genre { get; set; }
        public int Id { get; set; }

        //public Book(string title, string author, string genre, string cover, string extraInfo, int rating)
        //{
        //    Title = title;
        //    Author = author;
        //    Genre = genre;
        //    Cover = cover;
        //    ExtraInfo = extraInfo;
        //    Rating = rating;
        //}
    }
}

