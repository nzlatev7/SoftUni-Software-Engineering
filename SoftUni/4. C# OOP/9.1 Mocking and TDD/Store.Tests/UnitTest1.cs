using Moq;
using NUnit.Framework;
using Store.Tests.Fakes;
using zad;
using zad.Contracts;

namespace Store.Tests
{
    public class Tests
    {

        [Test]
        public void CountShouldWorkCorrectly()
        {
            Mock<IProductDatabase> dbMock = new Mock<IProductDatabase>();

            zad.Store store = new zad.Store(dbMock.Object);
            Product product = new Product(2, "2", 2, 2);

            // Set up the Callback to increment the Count property when Add is called
            dbMock.Setup(db => db.Add(It.IsAny<Product>()))
                        .Callback<Product>(product =>
                        {
                            dbMock.Object.Count++;
                        });

            // Act
            store.Add(product);

            // Assert
            Assert.AreEqual(1, store.Count);
        }

        [Test]
        public void AddShouldWorkCorrectlyWithSaving()
        {
            Mock<IProductDatabase> dbMock = new Mock<IProductDatabase>();

            zad.Store store = new zad.Store(dbMock.Object);
            Product product = new Product(2, "2", 2, 2);

            store.Add(product);

            dbMock.Verify(foo => foo.Add(product), Times.AtLeastOnce());
            dbMock.Verify(foo => foo.Save(), Times.AtLeastOnce());
        }

        [Test]
        public void AddShouldWorkCorrectlyWithAdding()
        {
            FakeProductDatabase db = new FakeProductDatabase();
            zad.Store store = new zad.Store(db);

            Product product = new Product(1, "1", 1, 1);
            store.Add(product);

            Assert.AreEqual(product.Id, db.AddedProduct.Id);
        }

        [Test]
        public void GetAllShouldWorkCorrectly()
        {
            zad.Store store = new zad.Store(new FakeProductDatabase());

            Assert.AreEqual(2, store.GetAll().Count);
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            FakeProductDatabase db = new FakeProductDatabase();
            zad.Store store = new zad.Store(db);

            Product expectedProduct = new Product(1, "1", 1, 1);

            store.Remove(expectedProduct);

            Assert.AreEqual(expectedProduct, db.RemovedProduct);
        }


    }
}