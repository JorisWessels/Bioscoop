namespace Bioscoop
{
    public class MovieScreening
    {
        private double _pricePerSeat;
        private DateTime _dateAndTime;
        private Movie _movie;
        private IList<MovieTicket> _movieTickets;

        public MovieScreening(Movie movie, DateTime dataAndTime, double pricePerSeat)
        {
            _dateAndTime = dataAndTime;
            _pricePerSeat = pricePerSeat;
            _movie = movie;
            _movieTickets = new List<MovieTicket>();
        }

        public double getPricePerSeat()
        {
            return _pricePerSeat;
        }

        public string toString()
        {
            return "";
        }

        public DateTime GetDateAndTime()
        {
            return _dateAndTime;
        }
    }
}
