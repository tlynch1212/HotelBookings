namespace HotelBooking.Core.CustomExceptions
{
    public class HotelRoomAlreadyBookedException : Exception
    {
        public HotelRoomAlreadyBookedException()
        {
        }

        public HotelRoomAlreadyBookedException(string message)
            : base(message)
        {
        }
    }
}
