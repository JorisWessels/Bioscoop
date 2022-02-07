namespace Bioscoop.PriceBehavior
{
    public interface ICalculatePriceBehavior
    {
        public double CalculatePrice(IList<MovieTicket> movieTickets);

        public string GetOrderType();
    }
}
