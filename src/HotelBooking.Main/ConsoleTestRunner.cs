using HotelBooking.Core.Models;
using HotelBooking.Core.Repositories;
using HotelBooking.Core.Services;
using System;

namespace HotelBooking.Main
{
    public class ConsoleTestRunner
    {
        private IHotelRepository _hotelRepository;
        private IBookingManager _bookManager;

        public void RunTest()
        {
            SetupTestApp();
            var today = new DateTime(2012, 3, 28);

            Console.WriteLine(_bookManager.IsRoomAvailable(101, today)); // outputs true 
            AddBookingWithTryCatch("Patel", 101, today);
            Console.WriteLine(_bookManager.IsRoomAvailable(101, today)); // outputs false 
            AddBookingWithTryCatch("Li", 101, today);    //throws exception
            AddBookingWithTryCatch("Li", 102, today);    //works
            Console.WriteLine($"Rooms {string.Join(',', _bookManager.getAvailableRooms(today))} are available.");   // should return 201 and 202
        }

        private void AddBookingWithTryCatch(string guest, int room, DateTime date)
        {
            try
            {
                _bookManager.AddBooking(guest, room, date);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured: {ex.GetType()}: {ex.Message}");
            }
        }

        private void SetupTestApp()
        {
            _hotelRepository = new HotelRepository();
            _bookManager = new BookingManager(_hotelRepository);

            _hotelRepository.AddRoom(new Room(101));
            _hotelRepository.AddRoom(new Room(102));
            _hotelRepository.AddRoom(new Room(201));
            _hotelRepository.AddRoom(new Room(202));
        }

    }

}
