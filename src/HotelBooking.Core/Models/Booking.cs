namespace HotelBooking.Core.Models
{
    public class Booking
    {
        public Guest Guest { get; set; }
        public Room Room { get; set; }
        public DateTime BookedDate { get; set; }

        public Booking(Guest guest, Room room, DateTime bookedDate)
        {
            Guest = guest;
            Room = room;
            BookedDate = bookedDate;
        }
    }
}