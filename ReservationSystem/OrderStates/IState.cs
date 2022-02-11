namespace ReservationSystem.OrderStates
{
    public interface IState
    {
        public IState OrderCreate(int ticketAmount, bool parking);
        public IState OrderConfirm();
        public IState OrderEdit(int ticketAmount, bool parking);
        public IState OrderPay();
        public IState OrderProvisional();
        public IState OrderCancel();
        public IState OrderStart();
    }
}
