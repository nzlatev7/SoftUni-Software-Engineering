namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;
        private Warrior _warrior;


        [SetUp]
        public void SetUp()
        {
            _warrior = new Warrior("Pesho", 10, 4);
        }

        [Test]
        public void CtorInitializeCorrectly()
        {
            Assert.AreEqual("Pesho", _warrior.Name);
            Assert.AreEqual(10, _warrior.Damage);
            Assert.AreEqual(4, _warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void NamePropShouldThrowExceptionIfIsNullOrWhiteSpace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                    new Warrior(name, 10, 140));

            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-6)]
        public void DamagePropShouldThrowExceptionIfIsNullOrWhiteSpace(int damage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                    new Warrior("Pesho", damage, 140));

            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }

        [TestCase(-1)]
        [TestCase(-6)]
        public void HpPropShouldThrowExceptionIfNegative(int hp)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                    new Warrior("Pesho", 10, hp), "HP should not be negative!");

            Assert.AreEqual("HP should not be negative!", exception.Message);
        }

        //Attack
        //Hp
        [TestCase("Petko", 10, 2)]
        [TestCase("Gergi", 10, 15)]
        [TestCase("Gergi", 10, 30)]
        public void AtackShoulThrowExceptionIfHpLessOrEqualTo_MIN_ATTACK_HP(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                  warrior.Attack(_warrior));

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }

        //Oponent Hp
        [TestCase("Petko", 10, 4)]
        [TestCase("Gergi", 10, 3)]
        [TestCase("Gergi", 10, 5)]
        public void AtackShoulThrowExceptionIfOponentHpLessOrEqualTo_MIN_ATTACK_HP(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior warrior2 = new Warrior(name, 100, 60);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                warrior2.Attack(warrior));

            Assert.AreEqual($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!", exception.Message);
        }

        //Hp
        [TestCase("Petko", 100, 40)]
        [TestCase("Gergi", 150, 35)]
        [TestCase("Gergi", 400, 36)]
        public void AtackShoulThrowExceptionIfOponentHpLessOponentDamage(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior warrior2 = new Warrior(name, 100, 60);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                warrior2.Attack(warrior));

            Assert.AreEqual($"You are trying to attack too strong enemy", exception.Message);
        }

        [Test]
        public void AttackShoulWorkCorrectly()
        {
            int expectedAttackHp = 95;
            int expectedDefenderHp = 80;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void AttackShoulWorkCorrectlyEnemySetToZero()
        {
            int expectedAttackHp = 95;

            Warrior attacker = new Warrior("Pesho", 150, 100);
            Warrior defender = new Warrior("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackHp, attacker.HP);
            Assert.AreEqual(0, defender.HP);
        }
    }
}