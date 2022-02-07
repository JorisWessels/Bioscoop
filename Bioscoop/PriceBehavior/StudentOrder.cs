namespace Bioscoop.PriceBehavior
{
    public class StudentOrder : ICalculatePriceBehavior
    {
        public double CalculatePrice(IList<MovieTicket> movieTickets)
        {
            double totalPrice = 0;

            var ticketCount = 0;

            foreach(MovieTicket movieTicket in movieTickets) {
                ticketCount++;
                
                if((ticketCount % 2) != 0) {
                    totalPrice += movieTicket.getPrice(true);
                }
            }

            return totalPrice;
        }

        public string GetOrderType()
        {
            return "Student Order";
        }
    }
}
