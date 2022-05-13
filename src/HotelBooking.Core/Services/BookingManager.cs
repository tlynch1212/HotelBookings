using HotelBooking.Core.Repositories;
using HotelBooking.Core.Models;

namespace HotelBooking.Core.Services
{
    public class BookingManager : IBookingManager
    {
        private readonly IHotelRepository _hotelRepository;

        public BookingManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public void AddBooking(string guest, int room, DateTime date)
        {
            _hotelRepository.AddBooking(new Booking(new Guest(guest), new Room(room), date));
        }

        public IEnumerable<int> getAvailableRooms(DateTime date)
        {
            return _hotelRepository.GetAvailableRooms(date);
        }

        public bool IsRoomAvailable(int room, DateTime date)
        {
            return _hotelRepository.IsRoomAvailable(room, date);
        }
    }
}
