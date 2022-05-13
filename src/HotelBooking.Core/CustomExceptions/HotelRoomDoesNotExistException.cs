namespace HotelBooking.Core.CustomExceptions
{
    public class HotelRoomDoesNotExistException : Exception
    {
        public HotelRoomDoesNotExistException()
        {
        }

        public HotelRoomDoesNotExistException(string message)
            : base(message)
        {
        }
    }
}
