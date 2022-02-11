namespace ReservationSystem.OrderStates
{
    public class OrderCreateState : IState
    {
        private Order _order;

        public OrderCreateState(Order order)
        {
            _order = order;
        }

        public IState OrderCancel()
        {
            Console.WriteLine("Je kan niet cancelen als de order net is aangemaakt.");
            return this;
        }

        public IState OrderConfirm()
        {
            Console.WriteLine("De Order is nu bevestigd.");
            return new OrderSubmitState(_order);
        }

        public IState OrderCreate(int ticketAmount, bool parking)
        {
            Console.WriteLine("Je hebt de order al aangemaakt.");
            return this;
        }

        public IState OrderEdit(int ticketAmount, bool parking)
        {
            Console.WriteLine("Je kan niet de order niet wijzigen als de order net is aangemaakt.");
            return this;
        }

        public IState OrderPay()
        {
            Console.WriteLine("Je kan niet betalen als de order net is aangemaakt.");
            return this;
        }

        public IState OrderProvisional()
        {
            Console.WriteLine("De ticket kan niet naar OrderProvisional als de ticket net is aangemaakt.");
            return this;
        }

        public IState OrderStart()
        {
            Console.WriteLine("De order is nog niet klaar.");
            return this;
        }
    }
}
