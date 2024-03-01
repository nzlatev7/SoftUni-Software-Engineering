using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AttackMethodShoudDecreaseDurabilityPoints()
        {
            //Arrange
            Axe axe = new Axe(5, 10);
            Dummy dummy = new Dummy(15, 6);

            int beforeAttack = axe.DurabilityPoints;

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.AreEqual(beforeAttack - 1, axe.DurabilityPoints);
        }

        [Test]
        public void AttackMethodShoudThrowExceptionIfDurabilityIsZero()
        {
            //Arrange
            Axe axe = new Axe(5, 10);
            Dummy dummy = new Dummy(100, 6);

            //try
            //{
            //    axe.Attack(dummy);
            //}
            //catch (System.Exception ex)
            //{
            //    Assert.AreEqual("Axe is broken.", ex.Message);
            //}

            //Act

            for (int i = 0; i < 10; i++)
            {
                axe.Attack(dummy);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => axe.Attack(dummy), 
                "Axe is broken.");
        }
    }
}