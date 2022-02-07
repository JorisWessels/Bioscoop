namespace Bioscoop
{
    public class MovieTicket
    {
        private readonly int _rowNr;
        private readonly int _seatNr;
        private readonly bool _isPremium;
        private readonly MovieScreening _movieScreening;

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

        public double getPrice(bool isStudentOrder) 
        {
            if(_isPremium == true) {
                if(isStudentOrder == true) {
                    return _movieScreening.getPricePerSeat() + 2;
                } else {
                    return _movieScreening.getPricePerSeat() + 3;
                }
            }

            return _movieScreening.getPricePerSeat();
        }

        public Movie getMovie()
        {
            return _movieScreening.getMovie();
        }

        public DateTime getDateAndTime()
        {
            return _movieScreening.getDateAndTime();
        }

        public string toString()
        {
            return "Row: " + _rowNr + " SeatNr: " + _seatNr + " - Is premium: " + _isPremium;
        }
    }
}
