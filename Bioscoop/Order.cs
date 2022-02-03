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

        private bool isCorrectDay()
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

            if (_isStudentOrder)
            {
                double freeTickets = Math.Floor((double)_movieTicketList.Count / 2);
            }
            else
            {
                foreach (MovieTicket ticket in _movieTicketList) { 
                }
            }
          

            foreach (MovieTicket movieticket in _movieTicketList)
            {
                
            }
            return 0;
        }

        public void export(TicketExportFormat exportFormat)
        {

        }
    }
}
