namespace ReservationSystem.OrderStates
{
    public class OrderProvisionalState : IState
    {
        private Order _order;
        public OrderProvisionalState(Order order)
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
            Console.WriteLine("Je kan de order niet opnieuw bevestigen.");
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
            Console.WriteLine("De order staat al in de Provisional.");
            return this;
        }

        public IState OrderStart()
        {
            Console.WriteLine("De order is nog niet klaar.");
            return this;
        }
    }
}
