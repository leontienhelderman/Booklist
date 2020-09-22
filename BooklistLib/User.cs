using System;
using System.Collections.Generic;

namespace BooklistLib
{
    public class User
    {

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string EmailAddress { get; private set; }
        public List<List<Book>> AllLists { get; private set; }

        public User()
        {

        }
    }
}
