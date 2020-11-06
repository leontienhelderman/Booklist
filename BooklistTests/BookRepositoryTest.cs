using BooklistDAL;
using NUnit.Framework;
using System.Dynamic;

namespace BooklistTests
{
    public class Tests
    {
        private BookRepository bookRepository;
        [SetUp]
        public void Setup()
        {
            bookRepository = new BookRepository();
        }

        [Test]
        public void CreateBookInDatabase()
        {
            Assert.IsTrue(bookRepository.Create());
        }
    }
}