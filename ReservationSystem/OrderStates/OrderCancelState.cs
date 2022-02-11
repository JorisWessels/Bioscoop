namespace ReservationSystem.OrderStates
{
    public class OrderCancelState : IState
    {
        private readonly Order _order;
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
            Console.WriteLine("De order is al gecanceld waardoor er niet kan worden bevestigd.");
            return this;
        }

        public IState OrderCreate(int ticketAmount, bool parking)
        {
            Console.WriteLine("De order is al gecanceld maar niet niet afgesloten.");
            return this;
        }

        public IState OrderEdit(int ticketAmount, bool parking)
        {
            Console.WriteLine("De order is al gecanceld waardoor er niet kan worden gewijzigd.");
            return this;
        }

        public IState OrderPay()
        {
            Console.WriteLine("De order is al gecanceld waardoor er niet meer kan worden betaald.");
            return this;
        }

        public IState OrderProvisional()
        {
            Console.WriteLine("De order is al gecanceld waardoor die niet meer naar Provisional kan worden verplaatst.");
            return this;
        }

        public IState OrderStart()
        {
            Console.WriteLine("Systeem wordt opnieuw gestart en Order is succesvol geannuleerd.");
            _order.ResetOrder();
            return new OrderStartState(_order);
        }
    }
}
