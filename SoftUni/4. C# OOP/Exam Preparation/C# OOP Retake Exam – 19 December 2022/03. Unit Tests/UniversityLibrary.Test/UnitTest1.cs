namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private UniversityLibrary library;

        [SetUp]
        public void Setup()
        {
            library = new UniversityLibrary();
        }

        [Test]
        public void CtorShouldInitializeCorectlyCollection()
        {
            Assert.IsNotNull(library);
            Assert.AreEqual(0, library.Catalogue.Count);
        }

        [Test]
        public void CatalogueShouldWorkCorrectly()
        {
            TextBook textBook = new TextBook("emil", "gencho", "funny");

            TextBook textBook1 = new TextBook("emil1", "gencho1", "funny1");

            library.AddTextBookToLibrary(textBook);
            library.AddTextBookToLibrary(textBook1);

            Assert.AreEqual(2, library.Catalogue.Count);
        }

        [Test]
        public void AddTextBookToLibraryShouldWorkCorrectly()
        {
            TextBook textBook = new TextBook("emil", "gencho", "funny");

            string actual = library.AddTextBookToLibrary(textBook);

            Assert.AreEqual(1, library.Catalogue.Count);
            Assert.AreEqual(textBook.Title, library.Catalogue[0].Title);
            Assert.AreEqual(1, textBook.InventoryNumber);
            Assert.AreEqual($"Book: emil - 1{Environment.NewLine}Category: funny{Environment.NewLine}Author: gencho", actual);
        }

        [Test]
        public void LoanTextBookStillHasNotReturned()
        {
            TextBook textBook = new TextBook("emil", "gencho", "funny");

            library.AddTextBookToLibrary(textBook);

            library.LoanTextBook(1, "Gosho");
            string actual = library.LoanTextBook(1, "Gosho");

            Assert.AreEqual("Gosho", textBook.Holder);
            Assert.AreEqual("Gosho still hasn't returned emil!", actual);
        }

        [Test]
        public void LoanTextBookLoanedToSomeone()
        {
            TextBook textBook = new TextBook("emil", "gencho", "funny");

            library.AddTextBookToLibrary(textBook);

            string actual = library.LoanTextBook(1, "Gosho");

            Assert.AreEqual("emil loaned to Gosho.", actual);
        }

        [Test]
        public void LoanTextShouldThrowException()
        {
            Assert.Throws<NullReferenceException>(() => library.LoanTextBook(1, "Gosho"));
        }

        [Test]
        public void ReturnTextBookCorrectly()
        {
            TextBook textBook = new TextBook("emil", "gencho", "funny");

            library.AddTextBookToLibrary(textBook);
            library.LoanTextBook(1, "Gosho");

            string actual = library.ReturnTextBook(1);

            Assert.AreEqual(string.Empty, textBook.Holder);
            Assert.AreEqual("emil is returned to the library.", actual);
        }

        [Test]
        public void ReturnTextBookMultipleBooks()
        {
            TextBook textBook = new TextBook("emil", "gencho", "funny");
            TextBook textBook1 = new TextBook("emil1", "gencho1", "funny1");

            library.AddTextBookToLibrary(textBook);
            library.AddTextBookToLibrary(textBook1);

            library.LoanTextBook(2, "Gosho");

            string actual = library.ReturnTextBook(2);

            Assert.AreEqual(string.Empty, textBook1.Holder);
            Assert.AreEqual("emil1 is returned to the library.", actual);
        }

        [Test]
        public void ReturnTextBookShouldThrowException()
        {
            Assert.Throws<NullReferenceException>(() => library.ReturnTextBook(1));
        }
    }
}