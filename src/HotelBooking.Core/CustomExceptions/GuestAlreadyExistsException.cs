namespace HotelBooking.Core.CustomExceptions
{
    public class GuestAlreadyExistsException : Exception
    {
        public GuestAlreadyExistsException()
        {
        }

        public GuestAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
