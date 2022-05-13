using HotelBooking.Core.Models;

namespace HotelBooking.Core.Repositories
{
    public interface IHotelRepository
    {
        void AddBooking(Booking booking);
        void AddRoom(Room room);
        void AddGuest(Guest guest);
        bool IsRoomAvailable(int roomNumber, DateTime bookingDate);
        IEnumerable<int> GetAvailableRooms(DateTime date);
    }
}