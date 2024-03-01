namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database _database;

        [SetUp]
        public void SetUp()
        {
            _database = new Database();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CheckForArraySize(int[] nums)
        {
            //arrange and act
            _database = new Database(nums);

            //assert
            Assert.AreEqual(nums, _database.Fetch());
        }

        [Test]
        public void CheckForExceptionIfCapacityIsMoreThan16()
        {
            //arrange and act
            _database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            //assert
            Assert.Throws<InvalidOperationException>(() =>
                _database.Add(1), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void CountShouldWorkCorrectly()
        {
            _database = new Database(1,2,3);

            Assert.AreEqual(3, _database.Count);
        }

        [Test]
        public void CheckForRemovingTheLastElement()
        {
            //arrange and act
            int[] array = new int[] { 1, 2 };

            _database = new Database(1,2,3);
            _database.Remove();

            //assert
            CollectionAssert.AreEqual(array, _database.Fetch());
        }

        [Test]
        public void CheckForExceptionIfRemovingFromEmptyDb()
        {
            //arrange and act
            _database = new Database();

            //assert
            Assert.Throws<InvalidOperationException>(() =>
                _database.Remove(), "The collection is empty!");
        }

        [Test]
        public void CheckThatFetchNeedToReturnArray()
        {
            //arrange
            _database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            //act
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};

            //assert
            CollectionAssert.AreEqual(array, _database.Fetch());
        }

        [Test]
        public void CheckCtorStoreIntegerInTheArray()
        {
            // Arrange: Prepare test data
            int[] expectedNumbers = { 1, 2, 3};

            // Act: Create an instance using the constructor
            _database = new Database(1,2,3);

            // Assert: Check that the numbers are stored in the array
            int[] actualNumbers = _database.Fetch();

            // Compare the expected and actual arrays
            CollectionAssert.AreEqual(expectedNumbers, actualNumbers);
        }
    }
}
