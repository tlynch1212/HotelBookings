namespace HotelBooking.Core.Models
{
    public class Guest
    {
        public string Surname { get; set; }

        public Guest(string surname)
        {
            Surname = surname;
        }
    }
}