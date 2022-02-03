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
        
        public double calculatePrice()
        {
            return 0;
        }

        public void export(TicketExportFormat exportFormat)
        {

        }
    }
}
