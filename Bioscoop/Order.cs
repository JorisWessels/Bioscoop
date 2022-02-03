namespace Bioscoop
{
    public class Order
    {
        private int _orderNr;
        private bool _isStudentOrder;
        private TicketExportFormat _ticketExportFormat;
        private IList<MovieTicket> _movieTicketList;

        public Order(int orderNr, bool isStudentOrder)
        {
            _orderNr = orderNr;
            _isStudentOrder = isStudentOrder;
            _movieTicketList = new List<MovieTicket>();
        }

        public int getOrderNr()
        {
            return _orderNr;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            _movieTicketList.Add(ticket);
        }

        private bool isCorrectStatus()
        {
            int getTicketDay = ((int)_movieTicketList[0].getDateAndTime().DayOfWeek);
            if (!_isStudentOrder && getTicketDay == 1 || getTicketDay == 2 || getTicketDay == 3 || getTicketDay == 4)
            {
                return true;
            }
            else if (_isStudentOrder)
            {
                return true;
            }

            return false;

        }
        
        public double calculatePrice()
        {
            double totalPrice = 0;

            // Kan makkelijker??
            var ticketCount = 0;

            foreach (MovieTicket movieticket in _movieTicketList)
            {
                ticketCount++;
                var priceTicket = movieticket.getPrice();
                // Prijs voor ticket uitrekenen met/zonder premium
                if (movieticket.IsPremiumTicket())
                {
                    if (_isStudentOrder)
                    {
                        priceTicket += 2.0;
                    } else
                    {
                        priceTicket += 3.0;
                    }
                }


                // Checken of ticket 2de is of niet (Met correcte voorwaarden)
                if(!isCorrectStatus() || (ticketCount % 2) != 0)
                {
                    totalPrice += priceTicket;
                }


            }

            // Eventuele korting voor niet studenten (Met correcte voorwaarden)
            if(!isCorrectStatus() && _movieTicketList.Count >= 6)
            {
                totalPrice *= 0.9;
            }


            // Return prijs met alle kortingen inzich
            return totalPrice;
        }

        public void export(TicketExportFormat exportFormat)
        {

        }
    }
}
