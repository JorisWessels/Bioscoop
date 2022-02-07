using System.Text.Json;
using Bioscoop.ExportBehavior;
using Bioscoop.PriceBehavior;

namespace Bioscoop
{
    public class Order
    {
        private readonly int _orderNr;
        private readonly IList<MovieTicket> _movieTicketList;

        private readonly ICalculatePriceBehavior _calculatePriceBehavior;
        private readonly IOrderExportBehavior _orderExportBehavior;

        public Order(int orderNr, ICalculatePriceBehavior calculatePriceBehavior, IOrderExportBehavior orderExportBehavior)
        {
            _orderNr = orderNr;
            _calculatePriceBehavior = calculatePriceBehavior;
            _orderExportBehavior = orderExportBehavior;
            _movieTicketList = new List<MovieTicket>();
        }

        public int getOrderNr()
        {
            return _orderNr;
        }

        public IList<MovieTicket> getMovieTicketList() {
            return _movieTicketList;
        }

        public ICalculatePriceBehavior getCalculatePriceBehavior() {
            return _calculatePriceBehavior;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            _movieTicketList.Add(ticket);
        }

        public double performCalculatePrice()
        {
            return _calculatePriceBehavior.CalculatePrice(_movieTicketList);
        }

        public void performExport()
        {
            _orderExportBehavior.Export(this);
        }

    }
}
