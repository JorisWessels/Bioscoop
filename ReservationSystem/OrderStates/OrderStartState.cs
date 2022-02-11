namespace ReservationSystem.OrderStates
{
    public class OrderStartState : IState
    {
        private readonly Order _order;
        public OrderStartState(Order order)
        {
            _order = order;
        }

        public IState OrderCancel()
        {
            Console.WriteLine("Er bestaat nog geen order.");
            return this;
        }

        public IState OrderConfirm()
        {
            Console.WriteLine("Er bestaat nog geen order.");
            return this;
        }

        public IState OrderCreate(int ticketAmount, bool parking)
        {
            Console.WriteLine("Order aangemaakt.");
            _order.SetTicketAmount(ticketAmount);
            _order.SetParking(parking);
            _order.SetOrderCreateAt(DateTime.Now);
            return new OrderCreateState(_order);
        }

        public IState OrderEdit(int ticketAmount, bool parking)
        {
            Console.WriteLine("Er bestaat nog geen order.");
            return this;
        }

        public IState OrderPay()
        {
            Console.WriteLine("Er bestaat nog geen order.");
            return this;
        }

        public IState OrderProvisional()
        {
            Console.WriteLine("Er bestaat nog geen order.");
            return this;
        }

        public IState OrderStart()
        {
            Console.WriteLine("De ticket is nog niet klaar.");
            return this;
        }
    }
}
