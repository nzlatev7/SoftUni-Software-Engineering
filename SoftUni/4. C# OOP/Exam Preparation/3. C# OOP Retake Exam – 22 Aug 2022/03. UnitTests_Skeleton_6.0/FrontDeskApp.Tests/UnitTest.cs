using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [Test]
        public void CtorShouldWorkCorrectly()
        {
            Hotel hotel = new Hotel("kotva", 5);

            Assert.IsNotNull(hotel);
            Assert.IsNotNull(hotel.Rooms);
            Assert.IsNotNull(hotel.Bookings);
            Assert.AreEqual(0, hotel.Rooms.Count);
            Assert.AreEqual(0, hotel.Bookings.Count);
            Assert.AreEqual(0, hotel.Turnover);

            Assert.AreEqual("kotva", hotel.FullName);
            Assert.AreEqual(5, hotel.Category);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        [TestCase(null)]
        public void FullNameExceptionShouldThrow(string fullName)
        {
            Hotel hotel;

            Assert.Throws<ArgumentNullException>(() =>
                hotel = new Hotel(fullName, 5));
        }

        [TestCase(0)]
        [TestCase(-2)]
        [TestCase(6)]
        public void CatergoryShouldThrowException(int category)
        {
            Hotel hotel;

            Assert.Throws<ArgumentException>(() =>
                hotel = new Hotel("kotva", category));
        }

        [Test]
        public void AddCorrectly()
        {
            Hotel hotel = new Hotel("kotva", 5);

            Room room = new Room(2, 100);
            Room room2 = new Room(4, 140);
            Room room3 = new Room(6, 200);

            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            Assert.AreEqual(3, hotel.Rooms.Count);

            //correct room added?
        }

        [Test]
        public void BookRoomExceptions()
        {
            Hotel hotel = new Hotel("kotva", 5);

            Room room = new Room(2, 100);
            Room room2 = new Room(4, 140);
            Room room3 = new Room(6, 200);

            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            Assert.Throws<ArgumentException>(() =>
                hotel.BookRoom(-1, 2, 3, 100));

            Assert.Throws<ArgumentException>(() =>
                hotel.BookRoom(0, 2, 3, 100));

            Assert.Throws<ArgumentException>(() =>
                hotel.BookRoom(0, -2, 3, 100));

            Assert.Throws<ArgumentException>(() =>
                hotel.BookRoom(2, 1, 0, 100));

            Assert.Throws<ArgumentException>(() =>
                hotel.BookRoom(2, 1, -5, 100));
        }

        [Test]
        public void BookRoomCorrectBooking()
        {
            Hotel hotel = new Hotel("kotva", 5);

            Room room = new Room(2, 100);
            Room room2 = new Room(4, 140);
            Room room3 = new Room(6, 200);

            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            hotel.BookRoom(2, 1, 3, 430);

            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(420, hotel.Turnover);

            Assert.AreEqual(3, hotel.Rooms.Count);
        }

        [Test]
        public void BookRoomCorrectWhenBudgetTooLow()
        {
            Hotel hotel = new Hotel("kotva", 5);

            Room room = new Room(2, 100);
            Room room2 = new Room(4, 140);
            Room room3 = new Room(6, 200);

            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            hotel.BookRoom(2, 1, 3, 100);

            Assert.AreEqual(0, hotel.Bookings.Count);
            Assert.AreEqual(0, hotel.Turnover);

            Assert.AreEqual(3, hotel.Rooms.Count);
        }

        [Test]
        public void BookRoomCorrectWithoutCapacity()
        {
            Hotel hotel = new Hotel("kotva", 5);

            Room room = new Room(2, 100);
            Room room2 = new Room(4, 140);
            Room room3 = new Room(6, 200);

            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            hotel.BookRoom(3, 5, 3, 100);

            Assert.AreEqual(0, hotel.Bookings.Count);
            Assert.AreEqual(0, hotel.Turnover);

            Assert.AreEqual(3, hotel.Rooms.Count);
        }

        [Test]
        public void BookRoomCorrectWithoutRooms()
        {
            Hotel hotel = new Hotel("kotva", 5);

            hotel.BookRoom(3, 5, 3, 100);

            Assert.AreEqual(0, hotel.Bookings.Count);
            Assert.AreEqual(0, hotel.Turnover);

            Assert.AreEqual(0, hotel.Rooms.Count);
        }
    }
}