using HotelBooking.Core.CustomExceptions;
using HotelBooking.Core.Models;
using HotelBooking.Core.Repositories;
using HotelBooking.Core.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HotelBookingTests
{
    public class BookingManagerTests
    {
        private IHotelRepository _hotelRepository;
        private IBookingManager _bookingManager;
        private DateTime _today;

        [SetUp]
        public void Setup()
        {
            _hotelRepository = new HotelRepository();
            _bookingManager = new BookingManager(_hotelRepository);
            _today = new DateTime(2012, 3, 28);

            _hotelRepository.AddRoom(new Room(101));
            _hotelRepository.AddRoom(new Room(102));
            _hotelRepository.AddRoom(new Room(201));
            _hotelRepository.AddRoom(new Room(202));
        }

        [Test]
        public void AddingNewBooking_WhenRoomIsNotBookedYet_BooksRoom()
        {
            _bookingManager.AddBooking("Patel", 101, _today);
            var result = _bookingManager.IsRoomAvailable(101, _today);
            Assert.IsFalse(result);
        }

        [Test]
        public void AddingNewBooking_WhenRoomIsAlreadyBooked_ThrowsException()
        {
            _bookingManager.AddBooking("Patel", 101, _today);
            var result = _bookingManager.IsRoomAvailable(101, _today);
            Assert.Throws<HotelRoomAlreadyBookedException>(() => _bookingManager.AddBooking("Li", 101, _today));
        }

        [Test]
        public void IsBookingAvailable_WhenRoomIsNotBookedYet_ReturnsTrue()
        {
            var result = _bookingManager.IsRoomAvailable(101, _today);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsBookingAvailable_WhenRoomIsAlreadyBooked_ReturnsFalse()
        {
            _bookingManager.AddBooking("Patel", 101, _today);
            var result = _bookingManager.IsRoomAvailable(101, _today);
            Assert.IsFalse(result);
        }

        [Test]
        public void GetAvailableRooms_ReturnsExpected()
        {
            var expectedOutput = new List<int> { 202, 102 };
            _bookingManager.AddBooking("Patel", 101, _today);
            _bookingManager.AddBooking("Li", 201, _today);
            var result = _bookingManager.getAvailableRooms(_today);
            Assert.AreEqual(expectedOutput, result);
        }
    }
}