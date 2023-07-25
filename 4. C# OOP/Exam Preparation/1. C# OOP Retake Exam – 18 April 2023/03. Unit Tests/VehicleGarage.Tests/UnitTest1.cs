using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CtorShouldWorkCorrectly()
        {
            Garage garage = new Garage(10);

            Assert.AreEqual(10, garage.Capacity);
            Assert.NotNull(garage.Vehicles);
            Assert.AreEqual(0, garage.Vehicles.Count);
        }

        [TestCase(10)]
        [TestCase(5)]
        [TestCase(2)]
        public void CapacityShouldWorkCorrectly(int capacity)
        {
            Garage garage = new Garage(capacity);

            Assert.AreEqual(capacity, garage.Capacity);
        }

        [TestCase(4)]
        [TestCase(5)]
        public void CountShouldWorkCorrectly(int countOfVehicle)
        {
            Garage garage = new Garage(10);

            for (int i = 0; i < countOfVehicle; i++)
            {
                garage.AddVehicle(new Vehicle($"{i}", $"{i}", $"{i}"));
            }

            Assert.AreEqual(countOfVehicle, garage.Vehicles.Count);
        }

        [Test]
        public void AddVehicleShouldWorkCorrectly()
        {
            Garage garage = new Garage(2);

            Vehicle vehicle = new Vehicle("1", "1", "1111");

            bool actual = garage.AddVehicle(vehicle);

            Assert.AreEqual(true, actual);
            Assert.AreEqual(1, garage.Vehicles.Count);

            Assert.Contains(vehicle, garage.Vehicles);
        }

        [Test]
        public void AddVehicleIfCapacityIsEqualToVehicles()
        {
            Garage garage = new Garage(2);

            Vehicle vehicle = new Vehicle("1", "1", "1111");
            Vehicle vehicle1 = new Vehicle("12", "12", "11112");
            Vehicle vehicle2 = new Vehicle("123", "123", "111123");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle1);

            bool actual = garage.AddVehicle(vehicle2);

            var contains = garage.Vehicles.Contains(vehicle2);

            Assert.AreEqual(false, actual);
            Assert.AreEqual(false, contains);
        }

        [Test]
        public void AddVehicleIfLicensePlateNumberExists()
        {
            Garage garage = new Garage(10);

            Vehicle vehicle = new Vehicle("1", "1", "1111");
            Vehicle vehicle2 = new Vehicle("1", "1", "1111");

            garage.AddVehicle(vehicle);
            bool actual = garage.AddVehicle(vehicle2);

            Assert.AreEqual(false, actual);
        }

        [TestCase(80)]
        [TestCase(90)]
        public void ChargeVehiclesWorkCorrectly(int batteryLevel)
        {
            Garage garage = new Garage(10);

            Vehicle vehicle = new Vehicle("1", "1", "1111");
            Vehicle vehicle2 = new Vehicle("2", "2", "2222");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);

            garage.DriveVehicle("1111", 20, false);
            garage.DriveVehicle("2222", 70, false);

            int vehiclesCharged = garage.ChargeVehicles(batteryLevel);

            Assert.AreEqual(2, vehiclesCharged);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
        }

        [Test]
        public void ChargeVehiclesNotCharging()
        {
            Garage garage = new Garage(10);

            Vehicle vehicle = new Vehicle("1", "1", "1111");
            Vehicle vehicle2 = new Vehicle("2", "2", "2222");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);

            garage.DriveVehicle("1111", 20, false);
            garage.DriveVehicle("2222", 70, false);

            int vehiclesCharged = garage.ChargeVehicles(30);

            Assert.AreEqual(1, vehiclesCharged);
            Assert.AreEqual(80, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
        }

        [Test]
        public void DriveVehicleShouldWorkCorrectly()
        {
            Garage garage = new Garage(10);

            Vehicle vehicle = new Vehicle("1", "1", "1111");

            garage.AddVehicle(vehicle);

            garage.DriveVehicle("1111", 20, false);

            Assert.AreEqual(80, vehicle.BatteryLevel);
        }

        [Test]
        public void DriveVehicleAccidentOccured()
        {
            Garage garage = new Garage(10);

            Vehicle vehicle = new Vehicle("1", "1", "1111");

            garage.AddVehicle(vehicle);

            garage.DriveVehicle("1111", 20, true);

            Assert.AreEqual(80, vehicle.BatteryLevel);
            Assert.AreEqual(true, vehicle.IsDamaged);
        }

        [Test]
        public void DriveVehicleWithAllReturns()
        {
            Garage garage = new Garage(5);

            Vehicle vehicle = new Vehicle("1", "1", "1111");
            Vehicle vehicle2 = new Vehicle("2", "2", "2222");
            Vehicle vehicle3 = new Vehicle("3", "3", "3333");
            Vehicle vehicle4 = new Vehicle("4", "4", "4444");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.AddVehicle(vehicle4);

            // isDamaged
            garage.DriveVehicle("1111", 0, true);
            garage.DriveVehicle("1111", 20, true);

            //drainage
            garage.DriveVehicle("2222", 120, false);

            garage.DriveVehicle("3333", 20, false);
            garage.DriveVehicle("3333", 90, false);

            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
            Assert.AreEqual(80, vehicle3.BatteryLevel);

            Assert.IsTrue(vehicle.IsDamaged);
            Assert.IsFalse(vehicle2.IsDamaged);
            Assert.IsFalse(vehicle3.IsDamaged);
        }

        [Test]
        public void RepairVehiclesShouldWorkCorrectlyWithDamagedVehicles()
        {
            Garage garage = new Garage(10);

            Vehicle vehicle = new Vehicle("1", "1", "1111");
            Vehicle vehicle2 = new Vehicle("2", "2", "2222");
            Vehicle vehicle3 = new Vehicle("3", "3", "3333");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);

            garage.DriveVehicle("1111", 20, true);
            garage.DriveVehicle("2222", 30, true);

            string actual = garage.RepairVehicles();

            Assert.AreEqual("Vehicles repaired: 2", actual);

            Assert.IsFalse(vehicle.IsDamaged);
            Assert.IsFalse(vehicle2.IsDamaged);
        }

        [Test]
        public void RepairVehiclesShouldWorkCorrectlyWithUndamagedVehicles()
        {
            Garage garage = new Garage(10);

            Vehicle vehicle = new Vehicle("1", "1", "1111");
            Vehicle vehicle2 = new Vehicle("2", "2", "2222");
            Vehicle vehicle3 = new Vehicle("3", "3", "3333");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);

            garage.DriveVehicle("1111", 20, false);
            garage.DriveVehicle("2222", 30, false);
            garage.DriveVehicle("3333", 70, false);

            string actual = garage.RepairVehicles();

            Assert.AreEqual("Vehicles repaired: 0", actual);
        }
    }
}