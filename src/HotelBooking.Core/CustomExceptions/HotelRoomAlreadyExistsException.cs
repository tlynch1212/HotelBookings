namespace HotelBooking.Core.CustomExceptions
{
    public class HotelRoomAlreadyExistsException : Exception
    {
        public HotelRoomAlreadyExistsException()
        {
        }

        public HotelRoomAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
