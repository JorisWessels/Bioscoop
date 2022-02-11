namespace ReservationSystem.OrderStates
{
    public class OrderSubmitState : IState
    {
        private Order _order;

        public OrderSubmitState(Order order)
        {
            _order = order;
        }

        public IState OrderCancel()
        {
            Console.WriteLine("De order is gecanceld");
            return new OrderCancelState(_order);
        }

        public IState OrderConfirm()
        {
            Console.WriteLine("De order is al bevestigd");
            return this;
        }

        public IState OrderCreate(int ticketAmount, bool parking)
        {
            Console.WriteLine("De order is al aangemaakt.");
            return this;
        }

        public IState OrderEdit(int ticketAmount, bool parking)
        {
            Console.WriteLine("De order wordt bijgewerkt.");
            _order.SetTicketAmount(ticketAmount);
            _order.SetParking(parking);
            return new OrderEditState(_order);
        }

        public IState OrderPay()
        {
            double price = 0;
            price = _order.GetTicketAmount() * _order.GetMovieScreening().GetPricePerSeat();

            if(_order.GetParking()) {
                price += 5;
            }

            Console.WriteLine("Te betalen prijs: " + price);
            Console.WriteLine("Betaald!");
            return new OrderPayState(_order);
        }

        public IState OrderProvisional()
        {
            Console.WriteLine("De order wordt in de wacht gezet.");
            return new OrderProvisionalState(_order);
        }

        public IState OrderStart()
        {
            Console.WriteLine("De order is nog niet klaar.");
            return this;
        }
    }
}
