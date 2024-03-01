namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void CtorInitializeCorrectly()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors.Count);

            Assert.AreEqual(0, arena.Warriors.Count);
            Assert.AreEqual(0, arena.Count);   
        }

        [Test]
        public void EnrollAddingCorrectlyNewWarrior()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Pesho", 10, 4);
            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
            Assert.AreEqual(1, arena.Warriors.Count);
        }

        [Test]
        public void EnrollShouldThrowExceptionIfContainsWarrior()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Pesho", 10, 4);
            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                    arena.Enroll(warrior));

            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [TestCase("Pesho", "Gosho")]
        public void FightMissingPlayerCheckExceptionThrowing1(string attackerName, string defenderName)
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior(attackerName, 10, 4);
            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                   arena.Fight(attackerName, defenderName));

            Assert.AreEqual($"There is no fighter with name {defenderName} enrolled for the fights!", exception.Message);
        }

        [TestCase("Pesho", "Gosho")]
        public void FightMissingPlayerCheckExceptionThrowing2(string attackerName, string defenderName)
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior(defenderName, 10, 4);
            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                   arena.Fight(attackerName, defenderName));

            Assert.AreEqual($"There is no fighter with name {attackerName} enrolled for the fights!", exception.Message);
        }

        [TestCase("Pesho", "Gosho")]
        public void FightCorrectly(string attackerName, string defenderName)
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior(attackerName, 15, 100);
            Warrior warrior2 = new Warrior(defenderName, 5, 50);

            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            arena.Fight(attackerName, defenderName);

            Assert.AreEqual(95, warrior.HP);
            Assert.AreEqual(35, warrior2.HP);
        }
    }
}
