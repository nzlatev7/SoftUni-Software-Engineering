using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void LosesHealthIfAtacked()
        {
            //Arrange
            Dummy dummy = new Dummy(100, 10);
            Axe axe = new Axe(10, 10);

            //Act
            dummy.TakeAttack(axe.AttackPoints);

            //Assert
            Assert.AreEqual(90, dummy.Health);
        }

        [Test]
        public void DeadThrowExceptionIfAttacked()
        {
            string expectedMessage = "Dummy is dead.";
            //Arrange
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(10, 10);

            //Act
            dummy.TakeAttack(axe.AttackPoints);

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                dummy.TakeAttack(axe.AttackPoints));

            // Check if the exception message is the same as the expected message
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void CheckExperienceAfterDead()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(10, 10);

            //Act
            dummy.TakeAttack(axe.AttackPoints);

            //Assert
            Assert.AreEqual(10, dummy.GiveExperience());
        }

        [Test]
        public void CheckAliveDummyThatCanNotGiveExperience()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(4, 10);

            //Act
            dummy.TakeAttack(axe.AttackPoints);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => dummy.GiveExperience(), 
                "Target is not dead.");
        }
    }
}