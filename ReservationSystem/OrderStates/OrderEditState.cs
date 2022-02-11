namespace ReservationSystem.OrderStates
{
    public class OrderEditState : IState
    {
        private Order _order;
        public OrderEditState(Order order)
        {
            _order = order;
        }

        public IState OrderCancel()
        {
            Console.WriteLine("De order kan op dit moment niet gecanceld worden.");
            return this;
        }

        public IState OrderConfirm()
        {
            Console.WriteLine("De order wordt bevestigd en is succesvol bijgewerkt.");
            return new OrderSubmitState(_order);
        }

        public IState OrderCreate(int ticketAmount, bool parking)
        {
            Console.WriteLine("De order is al aangemaakt.");
            return this;
        }

        public IState OrderEdit(int ticketAmount, bool parking)
        {
            Console.WriteLine("De order niet worden gewijzigd als die op dit moment al gewijzigd wordt.");
            return this;
        }

        public IState OrderPay()
        {
            Console.WriteLine("De order kan niet betaald worden als die wordt gewijzigd.");
            return this;
        }

        public IState OrderProvisional()
        {
            Console.WriteLine("De order kan niet provisional worden als die wordt gewijzigd.");
            return this;
        }

        public IState OrderStart()
        {
            Console.WriteLine("De order is nog niet klaar.");
            return this;
        }
    }
}
