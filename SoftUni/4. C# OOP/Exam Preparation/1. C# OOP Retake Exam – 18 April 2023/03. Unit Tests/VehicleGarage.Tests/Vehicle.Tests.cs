using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class VehicleTests
    {
        [TestCase("1","1", "1")]
        [TestCase("2", "2", "2")]
        public void CtorShouldWorkCorrectly(string make, string model, string licensePlatNum)
        {
            Vehicle vehicle = new Vehicle(make, model, licensePlatNum);

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(make, vehicle.Brand);
            Assert.AreEqual(model, vehicle.Model);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(false, vehicle.IsDamaged);
        }
    }
}
