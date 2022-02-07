namespace Bioscoop
{
    public class MovieScreening
    {
        private readonly double _pricePerSeat;
        private readonly DateTime _dateAndTime;
        private readonly Movie _movie;

        public MovieScreening(Movie movie, DateTime dataAndTime, double pricePerSeat)
        {
            _dateAndTime = dataAndTime;
            _pricePerSeat = pricePerSeat;
            _movie = movie;
        }

        public double getPricePerSeat()
        {
            return _pricePerSeat;
        }

        public string toString()
        {
            return _movie.toString() + " - ", + "Price per seat: " + _pricePerSeat + " -  Date: " + _dateAndTime;
        }

        public DateTime getDateAndTime()
        {
            return _dateAndTime;
        }

        public Movie getMovie() { return _movie; }
    }
}
