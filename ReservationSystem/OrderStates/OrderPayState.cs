namespace ReservationSystem.OrderStates
{
    public class OrderPayState : IState
    {
        private readonly Order _order;

        public OrderPayState(Order order)
        {
            _order = order;
        }

        public IState OrderCancel()
        {
            Console.WriteLine("De order is al betaald en niet meer toeganglijk om te cancelen.");
            return this;
        }

        public IState OrderConfirm()
        {
            Console.WriteLine("De order is al betaald en niet meer toeganglijk om te bevestigen.");
            return this;
        }

        public IState OrderCreate(int ticketAmount, bool parking)
        {
            Console.WriteLine("Er bestaat al een order.");
            return this;
        }

        public IState OrderEdit(int ticketAmount, bool parking)
        {
            Console.WriteLine("De order is al betaald en niet meer toeganglijk om te veranderen.");
            return this;        
        }

        public IState OrderPay()
        {
            Console.WriteLine("De order is al betaald.");
            return this;
        }

        public IState OrderProvisional()
        {
            Console.WriteLine("De order is al betaald en niet meer toeganglijk om in Provisional te zetten.");
            return this;
        }

        public IState OrderStart()
        {
            Console.WriteLine("Systeem wordt opnieuw gestart en er is succesvol gehandeld.");
            _order.ResetOrder();
            return new OrderStartState(_order);
        }
    }
}
