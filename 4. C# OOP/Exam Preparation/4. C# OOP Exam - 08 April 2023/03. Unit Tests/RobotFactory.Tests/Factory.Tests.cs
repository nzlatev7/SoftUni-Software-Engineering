using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [TestCase("bmw", 10)]
        [TestCase("mercendes", 5)]
        public void CtorShouldIntializeCorrectly(string name, int capacity)
        {
            Factory factory = new Factory(name, capacity);

            Assert.IsNotNull(factory);
            Assert.IsNotNull(factory.Supplements);
            Assert.IsNotNull(factory.Robots);
            Assert.AreEqual(name, factory.Name);
            Assert.AreEqual(capacity, factory.Capacity);
            Assert.AreEqual(0, factory.Supplements.Count);
            Assert.AreEqual(0, factory.Robots.Count);
        }

        [TestCase("bmw1", 12.4, 80)]
        [TestCase("bmw2", 10, 40)]
        [TestCase("bmw3", 12, 100)]
        public void ProduceRobot(string model, double price, int interfaceStandard)
        {
            Factory factory = new Factory("bmw", 5);

            factory.ProduceRobot(model, price, interfaceStandard);
            factory.ProduceRobot(model, price, interfaceStandard);

            string message = factory.ProduceRobot(model, price, interfaceStandard);

            Assert.AreEqual(message, $"Produced --> Robot model: {model} IS: {interfaceStandard}, Price: {price:f2}");
            Assert.AreEqual(model, factory.Robots[0].Model);
            Assert.AreEqual(price, factory.Robots[0].Price);
            Assert.AreEqual(interfaceStandard, factory.Robots[0].InterfaceStandard);
            Assert.AreEqual(3, factory.Robots.Count);
        }

        public void UnableToProduceRobot()
        {
            Factory factory = new Factory("bmw", 3);

            factory.ProduceRobot("bmw1", 22, 70);
            factory.ProduceRobot("bmw2", 2, 55);
            factory.ProduceRobot("bmw3", 212, 15);
            string message = factory.ProduceRobot("bmw4", 12, 100);

            Assert.AreEqual("The factory is unable to produce more robots for this production day!", message);
            Assert.AreEqual(3, factory.Robots.Count);
        }

        [TestCase("power", 120)]
        [TestCase("superpower", 150)]
        public void ProduceSupplementShouldWorkCorrectly(string name, int interfaceStandard)
        {
            Factory factory = new Factory("bmw", 4);

            for (int i = 0; i < 13; i++)
            {
                factory.ProduceSupplement(name, interfaceStandard);
            }

            string message = factory.ProduceSupplement(name, interfaceStandard);

            Assert.AreEqual($"Supplement: {name} IS: {interfaceStandard}", message);
            Assert.AreEqual(name, factory.Supplements[0].Name);
            Assert.AreEqual(interfaceStandard, factory.Supplements[0].InterfaceStandard);
            Assert.AreEqual(14, factory.Supplements.Count);
        }

        [Test]
        public void UpgradeRobotShouldReturnFalse()
        {
            Factory factory = new Factory("bmw", 4);

            Robot robot1 = new Robot("bmw1", 22, 70);
            Robot robot2 = new Robot("bmw2", 2, 55);
            Robot robot3 = new Robot("bmw3", 212, 15);

            factory.ProduceRobot("bmw1", 22, 70);
            factory.ProduceRobot("bmw2", 2, 55);
            factory.ProduceRobot("bmw3", 212, 15);

            Supplement supplement1 = new Supplement("power", 70);
            Supplement supplement2 = new Supplement("superpower", 140);

            factory.ProduceSupplement("power", 70);
            factory.ProduceSupplement("superpower", 140);

            factory.UpgradeRobot(robot1, supplement1);
            bool isFalse1 = factory.UpgradeRobot(robot1, supplement1);

            bool isFalse2 = factory.UpgradeRobot(robot2, supplement1);


            Assert.IsFalse(isFalse1);
            Assert.IsFalse(isFalse2);
            Assert.AreEqual(1, robot1.Supplements.Count);
            Assert.AreEqual(0, robot2.Supplements.Count);
        }

        [Test]
        public void UpgradeRobotShouldReturnTrue()
        {
            Factory factory = new Factory("bmw", 4);

            Robot robot1 = new Robot("bmw1", 22, 70);
            Robot robot2 = new Robot("bmw2", 2, 70);

            factory.ProduceRobot("bmw1", 22, 70);
            factory.ProduceRobot("bmw2", 2, 55);
            factory.ProduceRobot("bmw3", 212, 15);

            Supplement supplement1 = new Supplement("power", 70);
            Supplement supplement2 = new Supplement("superpower", 70);

            factory.UpgradeRobot(robot1, supplement1);
            bool isTrue1 = factory.UpgradeRobot(robot1, supplement2);

            bool isTrue2 = factory.UpgradeRobot(robot2, supplement1);

            Assert.AreEqual(2, robot1.Supplements.Count);
            Assert.IsTrue(isTrue1);

            Assert.AreEqual(1, robot2.Supplements.Count);
            Assert.IsTrue(isTrue2);

            Assert.AreEqual(supplement1.Name, robot1.Supplements[0].Name);
            Assert.AreEqual(supplement1.InterfaceStandard, robot1.Supplements[0].InterfaceStandard);
        }

        [Test]
        public void SellRobot()
        {
            Factory factory = new Factory("bmw", 6);

            Robot robot1 = new Robot("bmw1", 20, 70);
            Robot robot2 = new Robot("bmw2", 2, 70);
            Robot robot3 = new Robot("bmw3", 212, 15);
            Robot robot4 = new Robot("bmw4", 27, 78);
            Robot robot5 = new Robot("bmw5", 282, 35);

            factory.ProduceRobot("bmw1", 20, 70);
            factory.ProduceRobot("bmw2", 2, 70);
            factory.ProduceRobot("bmw3", 212, 15);
            factory.ProduceRobot("bmw5", 282, 35);
            factory.ProduceRobot("bmw4", 27, 78);

            Robot robot = factory.SellRobot(20);

            Assert.AreEqual(5, factory.Robots.Count);

            Assert.AreEqual(robot1.Model, robot.Model);
            Assert.AreEqual(robot1.Price, robot.Price);
            Assert.AreEqual(robot1.InterfaceStandard, robot.InterfaceStandard);
        }

        [Test]
        public void SellRobotReturnNull()
        {
            Factory factory = new Factory("bmw", 6);
            Factory factory2 = new Factory("bmw", 2);

            Robot robot1 = new Robot("bmw1", 20, 70);
            Robot robot2 = new Robot("bmw2", 20, 70);
            Robot robot3 = new Robot("bmw3", 52, 15);
            Robot robot4 = new Robot("bmw4", 27, 78);
            Robot robot5 = new Robot("bmw5", 282, 35);


            factory2.ProduceRobot("bmw1", 20, 70);
            factory2.ProduceRobot("bmw2", 20, 70);
            factory2.ProduceRobot("bmw3", 52, 15);

            Robot robot = factory.SellRobot(10);

            Robot anotherRobot = factory.SellRobot(10);

            Assert.IsNull(robot);
            Assert.IsNull(anotherRobot);
        }
    }
}