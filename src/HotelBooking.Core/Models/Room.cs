namespace HotelBooking.Core.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }

        public Room(int roomNumber)
        {
            RoomNumber = roomNumber;
        }
    }
}