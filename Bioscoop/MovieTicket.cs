namespace Bioscoop
{
    public class MovieTicket
    {
        private int _rowNr;
        private int _seatNr;
        private bool _isPremium;
        private MovieScreening _movieScreening;
        public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
        {
            _movieScreening = movieScreening;
            _isPremium = isPremiumReservation;
            _seatNr = seatNr;
            _rowNr = seatRow;
        }

        public bool IsPremiumTicket()
        {
           return _isPremium;
        }

        public double getPrice() 
        {
            return 0;
        }

        public string toString()
        {
            return "";
        }
    }
}
