namespace Bioscoop.PriceBehavior
{
    public class NormalOrder : ICalculatePriceBehavior
    {
        public double CalculatePrice(IList<MovieTicket> movieTickets)
        {
            double totalPrice = 0;

            var ticketCount = 0;

            int getTicketDay = ((int)movieTickets[0].getDateAndTime().DayOfWeek);

            IList<int> correctDays = new List<int> { 1, 2, 3, 4 };

            foreach(MovieTicket movieTicket in movieTickets)
            {
                ticketCount++;

                if(!correctDays.Any(x => x == getTicketDay) || (ticketCount % 2) != 0) {
                    totalPrice += movieTicket.getPrice(false);
                }
            }

            if(!correctDays.Any(x => x == getTicketDay) || movieTickets.Count >= 6) {
                totalPrice *= 0.9;
            }

            return totalPrice;
        }
        public string GetOrderType()
        {
            return "Normal Order";
        }
    }
}
