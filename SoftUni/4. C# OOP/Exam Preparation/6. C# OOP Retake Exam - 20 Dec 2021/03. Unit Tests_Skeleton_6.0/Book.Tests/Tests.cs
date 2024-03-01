namespace Book.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void CtorShouldWorkCorrectly()
        {
            Book book = new Book("pipi", "emil");


            Assert.IsNotNull(book);
            Assert.AreEqual(0, book.FootnoteCount);
            Assert.AreEqual("pipi", book.BookName);
            Assert.AreEqual("emil", book.Author);
        }

        [Test]
        public void CtorShouldInitializeFootNoteDictionary()
        {
            Book book = new Book("pipi", "emil");

            Type type = book.GetType();

            FieldInfo fieldInfo = type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(x => x.Name == "footnote");

            var dictionary = fieldInfo.GetValue(book);

            Assert.IsNotNull(dictionary);
        }

        [TestCase("")]
        [TestCase(null)]
        public void BookNameShouldThrowExceptions(string name)
        {
            Book book;

            Assert.Throws<ArgumentException>(() =>
                book = new Book(name, "emil"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void AuthorShouldThrowExceptions(string author)
        {
            Book book;

            Assert.Throws<ArgumentException>(() =>
                book = new Book("pipi", author));
        }


        [Test]
        public void AddFootnoteException()
        {
            Book book = new Book("pipi", "emil");

            book.AddFootnote(1, "pipi");

            Assert.Throws<InvalidOperationException>(() =>
                book.AddFootnote(1, "pipi"));

            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void AddFootnoteCorrectly()
        {
            Book book = new Book("pipi", "emil");

            book.AddFootnote(1, "pipi");
            book.AddFootnote(2, "pipi");

            Assert.AreEqual(2, book.FootnoteCount);
        }

        [TestCase(-1)]
        [TestCase(-14)]
        [TestCase(3)]
        public void FindFootnoteException(int footNoteNumber)
        {
            Book book = new Book("pipi", "emil");

            book.AddFootnote(1, "pipi");
            book.AddFootnote(2, "pipi2");

            Assert.Throws<InvalidOperationException>(() =>
                book.FindFootnote(footNoteNumber));

            Assert.AreEqual(2, book.FootnoteCount);
        }

        [Test]
        public void FindFootnotCorrectly()
        {
            Book book = new Book("pipi", "emil");

            book.AddFootnote(1, "pipi");
            book.AddFootnote(2, "pipi2");

            string actualText = book.FindFootnote(1);

            Assert.AreEqual($"Footnote #1: pipi", actualText);
            Assert.AreEqual(2, book.FootnoteCount);
        }

        [Test]
        public void FindFootnoteExceptionIfEmpty()
        {
            Book book = new Book("pipi", "emil");

            Assert.Throws<InvalidOperationException>(() =>
              book.FindFootnote(3));

            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void AlterFootnoteException()
        {
            Book book = new Book("pipi", "emil");

            book.AddFootnote(1, "pipi");
            book.AddFootnote(2, "pipi2");

            Assert.Throws<InvalidOperationException>(() =>
               book.AlterFootnote(3, "www"));

            Assert.AreEqual(2, book.FootnoteCount);

            Assert.AreEqual($"Footnote #1: pipi", book.FindFootnote(1));
            Assert.AreEqual($"Footnote #2: pipi2", book.FindFootnote(2));
        }

        [Test]
        public void AlterFootnoteCorrectly()
        {
            Book book = new Book("pipi", "emil");

            book.AddFootnote(1, "pipi");
            book.AddFootnote(2, "pipi2");

            book.AlterFootnote(2, "www");

            Assert.AreEqual(2, book.FootnoteCount);

            Assert.AreEqual($"Footnote #1: pipi", book.FindFootnote(1));
            Assert.AreEqual($"Footnote #2: www", book.FindFootnote(2));
            Assert.AreEqual(2, book.FootnoteCount);
        }

        [Test]
        public void AlterFootnoteExceptionIfEmpty()
        {
            Book book = new Book("pipi", "emil");

            Assert.Throws<InvalidOperationException>(() =>
              book.AlterFootnote(3, "www"));

            Assert.AreEqual(0, book.FootnoteCount);
        }
    }
}