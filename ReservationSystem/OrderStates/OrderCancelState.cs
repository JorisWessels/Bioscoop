namespace ReservationSystem.OrderStates
{
    public class OrderCancelState : IState
    {
        private Order _order;
        public OrderCancelState(Order order)
        {
            _order = order;
        }

        public IState OrderCancel()
        {
            Console.WriteLine("De order is al gecanceld.");
            return this;
        }

        public IState OrderConfirm()
        {
            Console.WriteLine("De order is al gecanceld.");
            return this;
        }

        public IState OrderCreate(int ticketAmount, bool parking)
        {
            Console.WriteLine("De order is al gecanceld.");
            return this;
        }

        public IState OrderEdit(int ticketAmount, bool parking)
        {
            Console.WriteLine("De order is al gecanceld.");
            return this;
        }

        public IState OrderPay()
        {
            Console.WriteLine("De order is al gecanceld.");
            return this;
        }

        public IState OrderProvisional()
        {
            Console.WriteLine("De order is al gecanceld.");
            return this;
        }

        public IState OrderStart()
        {
            Console.WriteLine("Systeem wordt opnieuw gestart.");
            _order.SetTicketAmount(0);
            _order.SetParking(false);
            return new OrderStartState(_order);
        }
    }
}
