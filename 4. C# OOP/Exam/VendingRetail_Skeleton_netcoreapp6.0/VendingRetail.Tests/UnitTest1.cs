using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {

        [Test]
        public void CtorShouldInitializeCorrectly()
        {
            CoffeeMat coffee = new CoffeeMat(20, 4);

            Assert.IsNotNull(coffee);
            Assert.AreEqual(20, coffee.WaterCapacity);
            Assert.AreEqual(4, coffee.ButtonsCount);
            Assert.AreEqual(0, coffee.Income);
        }

        [Test]
        public void FillWaterTankAlreadyFull()
        {
            CoffeeMat coffee = new CoffeeMat(20, 4);

            coffee.FillWaterTank();

            string alreadyFull = coffee.FillWaterTank();

            Assert.AreEqual("Water tank is already full!", alreadyFull);
            Assert.AreEqual(20, coffee.WaterCapacity);
            Assert.AreEqual(4, coffee.ButtonsCount);
        }

        [Test]
        public void FillWaterTankCorrectly()
        {
            CoffeeMat coffee = new CoffeeMat(20, 4);

            string correctly = coffee.FillWaterTank();

            Assert.AreEqual($"Water tank is filled with {20}ml", correctly);
            Assert.AreEqual(20, coffee.WaterCapacity);
            Assert.AreEqual(4, coffee.ButtonsCount);
        }

        [Test]
        public void AddDrink()
        {
            CoffeeMat coffee = new CoffeeMat(20, 4);

            bool isTrue = coffee.AddDrink("cola", 5.40);

            bool isFalse = coffee.AddDrink("cola", 5.40);

            coffee.AddDrink("lemonada", 5.20);
            bool isTrue2 = coffee.AddDrink("bura", 5.40);
            coffee.AddDrink("vodka", 2.00);

            bool isFalse2 = coffee.AddDrink("sok", 2);

            Assert.IsTrue(isTrue);
            Assert.IsTrue(isTrue2);
            Assert.IsFalse(isFalse);
            Assert.IsFalse(isFalse2);

            Assert.AreEqual(4, coffee.ButtonsCount);
        }

        [Test]
        public void BuyDrink()
        {
            CoffeeMat coffee = new CoffeeMat(20, 4);
            CoffeeMat coffee2 = new CoffeeMat(90, 4);

            coffee.AddDrink("lemonada", 5.20);
            coffee.AddDrink("bura", 5.40);
            coffee.AddDrink("vodka", 2.00);

            coffee2.AddDrink("lemonada", 5.20);
            coffee2.AddDrink("bura", 5.40);
            coffee2.AddDrink("vodka", 2.00);
            coffee2.FillWaterTank();

            string coffeOutOfWater = coffee.BuyDrink("lemonada");
            Assert.AreEqual("CoffeeMat is out of water!", coffeOutOfWater);
            Assert.AreEqual(0, coffee.Income);

            string notAvailable = coffee2.BuyDrink("voda");
            Assert.AreEqual("voda is not available!", notAvailable);
            Assert.AreEqual(0, coffee2.Income);

            string yourBillIs = coffee2.BuyDrink("lemonada");
            Assert.AreEqual($"Your bill is {5.20:f2}$", yourBillIs);
            Assert.AreEqual(5.20, coffee2.Income);
            Assert.AreEqual(90, coffee2.WaterCapacity);

            Assert.AreEqual($"Water tank is filled with {80}ml", coffee2.FillWaterTank());
        }

        [Test]
        public void CollectIncome()
        {
            CoffeeMat coffee = new CoffeeMat(20, 4);
            CoffeeMat coffee2 = new CoffeeMat(90, 4);

            Assert.AreEqual(0, coffee.CollectIncome());
            Assert.AreEqual(0, coffee.Income);

            coffee.AddDrink("vodka", 2.00);
            coffee.BuyDrink("vodka");
            Assert.AreEqual(0, coffee.CollectIncome());

            coffee2.AddDrink("lemonada", 5.20);
            coffee2.AddDrink("bura", 5.40);
            coffee2.AddDrink("vodka", 2.00);
            coffee2.FillWaterTank();

            coffee2.BuyDrink("lemonada");

            coffee2.FillWaterTank();
            coffee2.BuyDrink("vodka");

            Assert.AreEqual(7.20, coffee2.CollectIncome());
            Assert.AreEqual(0, coffee2.Income);
        }
    }
}