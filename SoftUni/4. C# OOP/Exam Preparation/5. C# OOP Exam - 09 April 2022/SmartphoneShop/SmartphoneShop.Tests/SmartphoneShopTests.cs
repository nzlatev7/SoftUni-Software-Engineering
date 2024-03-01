using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void CtorShouldWorkCorrectly()
        {
            Shop shop = new Shop(10);

            Assert.IsNotNull(shop);
            Assert.AreEqual(10, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void CapacityCheckForException()
        {
            Shop shop;
            Assert.Throws<ArgumentException>(() => shop = new Shop(-10));
        }

        [TestCase("nokia", 100)]
        [TestCase("lenovo", 90)]
        public void AddPhoneSgouldWorkCorrectly(string model, int battery)
        {
            Shop shop = new Shop(10);

            Smartphone smartphone = new Smartphone(model, battery);
            Smartphone smartphone1 = new Smartphone("233", battery);
            Smartphone smartphone2 = new Smartphone("eee", 70);

            shop.Add(smartphone);
            shop.Add(smartphone1);

            Assert.IsNotNull(smartphone);
            Assert.AreEqual(2, shop.Count);
        }

        [Test]
        public void AddPhoneExceptions()
        {
            Shop shop = new Shop(4);

            Smartphone smartphone = new Smartphone("122", 100);
            Smartphone smartphone1 = new Smartphone("233", 60);
            Smartphone smartphone2 = new Smartphone("eee", 70);
            Smartphone smartphone3 = new Smartphone("222", 100);
            Smartphone smartphone4 = new Smartphone("333", 70);

            shop.Add(smartphone);
            shop.Add(smartphone1);
            shop.Add(smartphone2);
            shop.Add(smartphone3);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone2));
            Assert.AreEqual(4, shop.Count);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone4));
            Assert.AreEqual(4, shop.Count);
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            Shop shop = new Shop(4);

            Smartphone smartphone = new Smartphone("122", 100);
            Smartphone smartphone1 = new Smartphone("233", 60);
            Smartphone smartphone2 = new Smartphone("eee", 70);

            shop.Add(smartphone);
            shop.Add(smartphone1);
            shop.Add(smartphone2);

            shop.Remove("122");

            Assert.AreEqual(2, shop.Count);
        }

        [Test]
        public void RemoveShouldThrowException()
        {
            Shop shop = new Shop(4);

            Smartphone smartphone = new Smartphone("122", 100);
            Smartphone smartphone1 = new Smartphone("233", 60);
            Smartphone smartphone2 = new Smartphone("eee", 70);

            shop.Add(smartphone);
            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("1222"));
            Assert.AreEqual(3, shop.Count);
        }

        [Test]
        public void TestPhoneShouldWorkCorrectly()
        {
            Shop shop = new Shop(4);

            Smartphone smartphone = new Smartphone("122", 80);
            Smartphone smartphone1 = new Smartphone("233", 60);
            Smartphone smartphone2 = new Smartphone("eee", 70);

            shop.Add(smartphone);
            shop.Add(smartphone1);
            shop.Add(smartphone2);

            shop.TestPhone("122", 60);

            Assert.AreEqual(3, shop.Count);
            Assert.AreEqual(20, smartphone.CurrentBateryCharge);
            Assert.AreEqual(60, smartphone1.CurrentBateryCharge);
            Assert.AreEqual(70, smartphone2.CurrentBateryCharge);
        }

        [Test]
        public void TestPhoneShouldThrowExceptions()
        {
            Shop shop = new Shop(4);

            Smartphone smartphone = new Smartphone("122", 40);
            Smartphone smartphone1 = new Smartphone("233", 60);
            Smartphone smartphone2 = new Smartphone("eee", 70);

            shop.Add(smartphone);
            shop.Add(smartphone1);
            shop.Add(smartphone2);



            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("1222", 60));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("122", 60));

            Assert.AreEqual(3, shop.Count);
            Assert.AreEqual(40, smartphone.CurrentBateryCharge);
            Assert.AreEqual(60, smartphone1.CurrentBateryCharge);
            Assert.AreEqual(70, smartphone2.CurrentBateryCharge);
        }

        [Test]
        public void ChargehoneShouldWorkCorrectly()
        {
            Shop shop = new Shop(4);

            Smartphone smartphone = new Smartphone("122", 40);
            Smartphone smartphone1 = new Smartphone("233", 60);
            Smartphone smartphone2 = new Smartphone("eee", 70);

            shop.Add(smartphone);
            shop.Add(smartphone1);
            shop.Add(smartphone2);

            shop.TestPhone("122", 20);
            shop.TestPhone("233", 20);
            shop.TestPhone("eee", 20);

            shop.ChargePhone("122");

            Assert.AreEqual(smartphone.CurrentBateryCharge, smartphone.MaximumBatteryCharge);
            Assert.AreNotEqual(smartphone1.CurrentBateryCharge, smartphone1.MaximumBatteryCharge);
            Assert.AreNotEqual(smartphone2.CurrentBateryCharge, smartphone2.MaximumBatteryCharge);
        }

        [Test]
        public void ChargehoneShouldThrowException()
        {
            Shop shop = new Shop(4);

            Smartphone smartphone = new Smartphone("122", 40);
            Smartphone smartphone1 = new Smartphone("233", 60);
            Smartphone smartphone2 = new Smartphone("eee", 70);

            shop.Add(smartphone);
            shop.Add(smartphone1);
            shop.Add(smartphone2);

            shop.TestPhone("122", 20);
            shop.TestPhone("233", 20);
            shop.TestPhone("eee", 20);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("1222"));

            Assert.AreEqual(3, shop.Count);
            Assert.AreNotEqual(smartphone.CurrentBateryCharge, smartphone.MaximumBatteryCharge);
            Assert.AreNotEqual(smartphone1.CurrentBateryCharge, smartphone1.MaximumBatteryCharge);
            Assert.AreNotEqual(smartphone2.CurrentBateryCharge, smartphone2.MaximumBatteryCharge);
        }
    }
}