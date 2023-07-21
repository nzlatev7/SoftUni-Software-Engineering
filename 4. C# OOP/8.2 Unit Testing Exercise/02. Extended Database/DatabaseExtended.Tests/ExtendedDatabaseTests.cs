namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database _database;

        [SetUp]
        public void SetUp()
        {
            _database = new Database(
                new Person[]
                { 
                    new Person(1, "Pesho"),
                    new Person(2, "Gosho")
                });
        }

        [Test]
        public void AdddShouldWorkCorrectly()
        {
            Person person = new Person(3, "Gergi");

            _database.Add(person);

            Assert.AreEqual(3, _database.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfArrayCountIs16()
        {
            Person person = new Person(3, "Toshko");

            for (int i = 3; i <= 16; i++)
            {
                _database.Add(new Person(i, $"pepi{i}"));
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                _database.Add(person));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void UsernameDoblicateAddMethodException()
        {
            Person person = new Person(3, "Pesho");

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                _database.Add(person));

            Assert.AreEqual("There is already user with this username!", exception.Message);
        }

        [Test]
        public void IsDoblicateAddMethodException()
        {
            Person person = new Person(1, "Gergi");

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                _database.Add(person));

            Assert.AreEqual("There is already user with this Id!", exception.Message);
        }

        [Test]
        public void RemoveFromEmptyCollectionThrowException()
        {
            _database.Remove();
            _database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
                _database.Remove());
        }

        [Test]
        public void CorrectlyRemove()
        {
            _database.Remove();

            Assert.AreEqual(1, _database.Count);
        }

        [Test]
        public void FindByUsernameShouldWorkCorrectly()
        {
            var person = _database.FindByUsername("Pesho");

            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("Pesho", person.UserName);
        }

        [Test]
        public void NoUserPresentWhileFindByUsername()
        {
            Assert.Throws<InvalidOperationException>(() =>
                _database.FindByUsername("pepi"), "No user is present by this username!");
        }

        [TestCase("")]
        [TestCase(null)]
        public void NullParameterWhileFindByUsername(string value)
        {
            Assert.Throws<ArgumentNullException>(() =>
                _database.FindByUsername(value), "Username parameter is null!");
        }

        [Test]
        public void FindByIdShouldWorkCorrectly()
        {
            var person = _database.FindById(1);

            Assert.AreEqual("Pesho", person.UserName);
            Assert.AreEqual(1, person.Id);
        }
        [Test]
        public void NoUserPresentByThisIdThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                _database.FindById(100), "No user is present by this ID!");
        }

        [Test]
        public void IfNegativeIdsThrowExcewption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                    _database.FindById(-10), "Id should be a positive number!");
        }
    }
}