using HotelBooking.Core.Models;
using HotelBooking.Core.CustomExceptions;
using System.Collections.Concurrent;
using System.Data;

namespace HotelBooking.Core.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private ConcurrentBag<Booking> _bookings;
        private ConcurrentBag<Room> _rooms;
        private ConcurrentBag<Guest> _guests;

        public HotelRepository()
        {
            _bookings = new ConcurrentBag<Booking>();
            _rooms = new ConcurrentBag<Room>();
            _guests = new ConcurrentBag<Guest>();
        }

        public void AddBooking(Booking booking)
        {
            if (DoesRoomExist(booking.Room.RoomNumber))
            {
                if (IsRoomAvailable(booking.Room.RoomNumber, booking.BookedDate))
                {
                    if (!DoesGuestExist(booking.Guest.Surname))
                    {
                        _guests.Add(booking.Guest);
                    }

                    _bookings.Add(booking);
                }
                else
                {
                    throw new HotelRoomAlreadyBookedException($"Room {booking.Room.RoomNumber} is already book on {booking.BookedDate}.");
                }
            }
            else
            {
                throw new HotelRoomDoesNotExistException($"Room {booking.Room.RoomNumber} does not exist in this hotel.");
            }
        }

        public void AddGuest(Guest guest)
        {
            if (!DoesGuestExist(guest.Surname))
            {
                _guests.Add(guest);
            }
            else
            {
                throw new HotelRoomAlreadyExistsException($"Guest {guest.Surname} already exists in this hotel.");
            }
        }

        public void AddRoom(Room room)
        {
            if (!DoesRoomExist(room.RoomNumber))
            {
                _rooms.Add(room);
            }
            else
            {
                throw new HotelRoomAlreadyExistsException($"Room {room.RoomNumber} already exists in this hotel.");
            }
        }


        public IEnumerable<int> GetAvailableRooms(DateTime date)
        {
            return _rooms.Where(room => !_bookings.Select(bookings => bookings.Room.RoomNumber).Contains(room.RoomNumber)).Select(room => room.RoomNumber).AsEnumerable();
        }

        public bool IsRoomAvailable(int roomNumber, DateTime bookingDate) => !_bookings.Any(booking => booking.BookedDate == bookingDate && booking.Room.RoomNumber == roomNumber);

        private bool DoesRoomExist(int roomNumber) => _rooms.Any(room => room.RoomNumber == roomNumber);

        private bool DoesGuestExist(string surname) => _guests.Any(guest => guest.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));
    }
}
