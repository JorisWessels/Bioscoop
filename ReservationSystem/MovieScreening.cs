namespace ReservationSystem
{
    public class MovieScreening
    {
        private readonly DateTime _dateAndTime;
        private readonly double _pricePerSeat;

        public MovieScreening(DateTime dateAndTime, double pricePerSeat) {
            _dateAndTime = dateAndTime;
            _pricePerSeat = pricePerSeat;
        }

        public double GetPricePerSeat() {
            return _pricePerSeat;
        }

        public DateTime GetDateAndTime() {
            return _dateAndTime;
        }

        override
        public string ToString() {
            return "price: " + _pricePerSeat + " - Date: " + _dateAndTime;
        }
    }
}
